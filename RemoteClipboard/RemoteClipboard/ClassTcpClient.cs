using System;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RemoteClipboard
{
    class ClassTcpClient
    {
        // 是否连接到服务器
        private bool socketConnect = false;
        // 实现Berkeley套接字接口
        private Socket socketClient = null;
        // 服务器网络终结点
        private EndPoint iPEndPoint = null;
        // 发送信息锁
        private Object sendLock = new Object();
        // 接收服务端信息线程
        private Thread socketReceiveThread = null;
        // 向服务端发送心跳包线程
        private Thread socketHeartThread = null;
        // 回调函数列表
        private Dictionary<int, Action<bool, byte[]>> sendCallbackList = new Dictionary<int, Action<bool, byte[]>>();

        /// <summary>
        /// 是否连接到服务器
        /// </summary>
        public bool IsConnected
        {
            get { return socketConnect; }
        }

        public delegate void ServerReceiveHandler(int state, byte[] data);
        public event ServerReceiveHandler OnServerReceiveHandler;
        public delegate void onServerCloseHandler();
        public event onServerCloseHandler OnServerCloseHandler;

        /// <summary>
        /// ClassTcpClient构造函数
        /// </summary>
        /// <param name="host">服务器IP地址</param>
        /// <param name="port">服务器监听端口号</param>
        public ClassTcpClient(string host, int port)
        {
            iPEndPoint = new IPEndPoint(IPAddress.Parse(host), port);
        }

        /// <summary>
        /// 连接到服务器
        /// </summary>
        /// <returns></returns>
        public bool Start()
        {
            try
            {
                if (!socketConnect)
                {
                    socketConnect = true;
                    // 连接到服务器
                    iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6010);
                    socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socketClient.Connect(iPEndPoint);
                    // 开启服务端信息处理进程
                    socketReceiveThread = new Thread(SocketReceive);
                    socketReceiveThread.IsBackground = true;
                    socketReceiveThread.Start();
                    // 开启服务端心跳包进程
                    socketHeartThread = new Thread(SocketHeart);
                    socketHeartThread.IsBackground = true;
                    socketHeartThread.Start();
                }
            }
            catch
            {
                socketConnect = false;
            }
            return socketConnect;
        }

        /// <summary>
        /// 断开与服务端的连接
        /// </summary>
        public void Stop()
        {
            if (socketConnect)
            {
                socketConnect = false;
                socketClient.Close();
                socketClient.Dispose();
                sendCallbackList.Clear();
            }
        }

        /// <summary>
        /// 接收服务端信息
        /// </summary>
        private void SocketReceive()
        {
            while (socketConnect && socketClient != null && socketClient.Connected)
            {
                try
                {
                    byte[] temp = new byte[1024];
                    byte[] data = new byte[1024];
                    List<byte> byteSource = new List<byte>();
                    int length = socketClient.Receive(data, data.Length, 0);

                    byteSource.AddRange(data.Take(length));
                    while (socketClient.Available > 0)
                    {
                        Thread.Sleep(100);
                        int len = socketClient.Receive(temp, temp.Length, 0);
                        if (len > 0)
                        {
                            byteSource.AddRange(temp.Take(len));
                        }
                    }
                    data = byteSource.ToArray();
                    length = data.Length;

                    if (length > 3)
                    {
                        // 获取标识码
                        int state;
                        if (Int32.TryParse(Encoding.UTF8.GetString(data.Take(3).ToArray()), out state))
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
                catch (SocketException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    // 断开连接
                    socketConnect = false;
                    sendCallbackList.Clear();
                    // 断开与服务器的连接
                    OnServerCloseHandler?.Invoke();
                    return;
                }
                catch
                {
                    // 其他错误
                }
            }
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="state">标识码</param>
        /// <param name="data">数据</param>
        /// <param name="action"></param>
        public bool Send(int state, byte[] data, Action<bool, byte[]> action, int sheep = 2000)
        {
            if (socketConnect && socketClient != null && data.Length < 999999999)
            {
                lock (sendLock)
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
                        if (sendCallbackList.ContainsKey(callbackId))
                        {
                            action(false, new byte[] { });
                            RemoveCallBack(callbackId);
                        }
                    });
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 移出指定回调事件
        /// </summary>
        /// <param name="id"></param>
        private void RemoveCallBack(int id)
        {
            if (sendCallbackList.ContainsKey(id))
            {
                sendCallbackList.Remove(id);
            }
        }

        /// <summary>
        /// 向服务器发送心跳包
        /// </summary>
        private void SocketHeart()
        {
            // 每分钟发送一个心跳包
            while (socketConnect)
            {
                if (Send(100, Encoding.UTF8.GetBytes("hello"), SocketHeartCallBack))
                {
                    System.Diagnostics.Debug.WriteLine("发送成功");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("发送失败");
                }
                Thread.Sleep(60000);
            }
        }

        private void SocketHeartCallBack(bool state, byte[] data)
        {
            if (!state)
            {
                Stop();
            }
        }
    }
}
