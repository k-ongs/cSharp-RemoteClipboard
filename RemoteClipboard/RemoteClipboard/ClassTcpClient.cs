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
        private Thread sendCallbackListClearThread = null;
        // 回调函数列表
        private Dictionary<string, SendCallback> sendCallbackList = new Dictionary<string, SendCallback>();

        struct SendCallback
        {
            public DateTime date;
            public Action<bool, byte[]> action;
        }

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
                    // 开启回调函数清除进程
                    if(sendCallbackListClearThread == null)
                    {
                        sendCallbackListClearThread = new Thread(SendCallbackListClear);
                        sendCallbackListClearThread.IsBackground = true;
                        sendCallbackListClearThread.Start();
                    }
                }
            }
            catch(Exception e)
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
                            // 是否使用回调函数
                            uint isCallback = data[3];
                            // 截取数据
                            data = data.Skip(4).ToArray();
                            if (isCallback == 1)
                            {
                                string token = ClassStatic.GetString(data.Take(32).ToArray());
                                if (sendCallbackList.ContainsKey(token))
                                {
                                    data = data.Skip(32).ToArray();
                                    sendCallbackList[token].action(true, data);
                                    sendCallbackList.Remove(token);
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
                    // 断开连接
                    socketConnect = false;
                    // 断开与服务器的连接
                    OnServerCloseHandler?.Invoke();
                    return;
                }
                catch(Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
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
            bool stateTemp = false;
            lock (sendLock)
            {
                lock (ClassStatic.sendCallbackLock)
                {
                    if (socketConnect && socketClient != null && data.Length < 999999999)
                    {
                        // 为回调函数生成唯一标识
                        string token = Guid.NewGuid().ToString().Replace("-", "");
                        List<byte> byteSource = new List<byte>();
                        byte[] byteState = Encoding.UTF8.GetBytes(state.ToString().PadLeft(3, '0'));

                        byte[] byteCallbackId = Encoding.UTF8.GetBytes(token);

                        byteSource.AddRange(byteState);
                        byteSource.AddRange(new byte[] { 1 });
                        byteSource.AddRange(byteCallbackId);
                        byteSource.AddRange(data);

                        data = byteSource.ToArray();

                        try
                        {
                            socketClient.Send(data);

                            SendCallback sendCallback = new SendCallback();
                            sendCallback.date = DateTime.Now.AddMilliseconds(sheep);
                            sendCallback.action = action;

                            lock (ClassStatic.sendCallbackLock)
                            {
                                sendCallbackList.Add(token, sendCallback);
                            }
                            stateTemp = true;
                        }
                        catch
                        {

                        }
                    }
                }
            }// sendLock锁
            return stateTemp;
        }

        /// <summary>
        /// 移出指定回调事件
        /// </summary>
        /// <param name="id"></param>
        private void RemoveCallBack(string id)
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
                Send(100, Encoding.UTF8.GetBytes("hello"), SocketHeartCallBack);
                Thread.Sleep(60000);
            }
        }

        private void SendCallbackListClear()
        {
            while(true)
            {
                foreach (string token in sendCallbackList.Keys.ToArray())
                {
                    if (DateTime.Compare(sendCallbackList[token].date, DateTime.Now) < 0)
                    {
                        lock (ClassStatic.sendCallbackLock)
                        {
                            sendCallbackList[token].action(false, new byte[] { });
                            System.Diagnostics.Debug.WriteLine("移出一个回调函数");
                            RemoveCallBack(token);
                        }
                    }
                }
                Thread.Sleep(3000);
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
