using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using Newtonsoft.Json;

namespace TCP连接测试
{
    class ClassTcpClient
    {
        public bool isConnected = false;

        private Socket socketClient = null;
        private EndPoint iPEndPoint = null;
        private Thread socketReceiveThread = null;
        private Dictionary<int, Action<bool, byte[]>> sendCallbackList = new Dictionary<int, Action<bool, byte[]>>();

        public delegate void ServerReceiveHandler(int state, byte[] data);
        public event ServerReceiveHandler OnServerReceiveHandler;
        public delegate void onServerCloseHandler();
        public event onServerCloseHandler OnServerCloseHandler;

        public ClassTcpClient(string host, int port)
        {
            socketReceiveThread = new Thread(SocketClientReceive);
            socketReceiveThread.IsBackground = true;

            iPEndPoint = new IPEndPoint(IPAddress.Parse(host), port);
            socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        /// <summary>
        /// Receive事件
        /// </summary>
        private void SocketClientReceive()
        {
            while (isConnected)
            {
                try
                {
                    byte[] data = new byte[1024];
                    List<byte> byteSource = new List<byte>();
                    int length = socketClient.Receive(data, data.Length, 0);

                    byteSource.AddRange(data.Take(length));
                    while (socketClient.Available > 0)
                    {
                        Thread.Sleep(100);
                        byte[] temp = new byte[1024];
                        int tempLen = socketClient.Receive(temp, temp.Length, 0);
                        if (tempLen > 0)
                        {
                            byteSource.AddRange(temp.Take(tempLen));
                        }
                    }

                    data = byteSource.ToArray();
                    length = data.Length;

                    if (length > 3)
                    {
                        // 获取标识码
                        int state;
                        if(Int32.TryParse(Encoding.UTF8.GetString(data.Take(3).ToArray()), out state))
                        {
                            // 获取回调ID
                            int callbackId = -1;
                            uint isCallback = data[3];
                            // 截取数据
                            data = data.Skip(4).ToArray();
                            if (isCallback == 1)
                            {
                                if (System.Int32.TryParse(System.Text.Encoding.UTF8.GetString(data.Take(4).ToArray()), out callbackId))
                                {
                                    // 回调函数是否存在
                                    if (sendCallbackList.ContainsKey(callbackId))
                                    {
                                        data = data.Skip(4).ToArray();
                                        sendCallbackList[callbackId](true, data);
                                        sendCallbackList.Remove(callbackId);
                                    }
                                }
                                // 丢弃错误回调ID的数据包
                            }
                            else
                            {
                                // 执行客户端信息响应事件
                                OnServerReceiveHandler?.Invoke(state, data);
                            }
                        }
                        // 丢弃协议不合法的数据包
                    }
                    // 丢弃长度不合法的数据包
                }
                catch
                {
                    isConnected = false;
                    // 断开与服务器的连接
                    OnServerCloseHandler?.Invoke();
                    return;
                }
                Thread.Sleep(100);
            }
            // 退出Receive事件
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="state">标识码</param>
        /// <param name="data">数据</param>
        /// <param name="action"></param>
        /// <returns></returns>
        public int Send(int state, byte[] data, Action<bool, byte[]> action, int sheep = 2000)
        {
            if (isConnected && socketClient != null && data.Length < 999999999)
            {
                int callbackId = sendCallbackList.Count;

                List<byte> byteSource = new List<byte>();
                byte[] byteState = Encoding.UTF8.GetBytes(state.ToString().PadLeft(3, '0'));
                byte[] byteCallbackId = Encoding.UTF8.GetBytes(callbackId.ToString().PadLeft(4, '0'));

                byteSource.AddRange(byteState);
                byteSource.AddRange(new byte[] { 1 });
                byteSource.AddRange(byteCallbackId);
                byteSource.AddRange(data);

                data = byteSource.ToArray();
                socketClient.Send(data);

                sendCallbackList.Add(callbackId, action);
                Task.Run(async delegate
                {
                    await Task.Delay(sheep);
                    if(sendCallbackList.ContainsKey(callbackId))
                    {
                        RemoveCallBack(callbackId);
                        action(false, new byte[] { });
                    }
                });

                return callbackId;
            }
            return -1;
        }

        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <returns></returns>
        public bool Start()
        {
            try
            {
                socketClient.Connect(iPEndPoint);
                socketReceiveThread.Start();
                isConnected = true;
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 移出指定回调事件
        /// </summary>
        /// <param name="id"></param>
        public void RemoveCallBack(int id)
        {
            if(sendCallbackList.ContainsKey(id))
            {
                sendCallbackList.Remove(id);
            }
        }
    }
}
