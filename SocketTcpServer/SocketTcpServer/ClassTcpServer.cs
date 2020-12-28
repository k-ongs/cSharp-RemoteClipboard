using System;
using System.Net;
using System.Linq;
using System.Threading;
using System.Net.Sockets;
using System.Collections.Generic;

namespace SocketTcpServer
{
    class ClassTcpServer
    {
        // 当前监听状态
        private bool socketListen = false;
        // 实现Berkeley套接字接口
        private Socket socketServer = null;
        // 本机网络终结点
        private IPEndPoint iPEndPoint = null;
        // 接收客户端连接线程
        private Thread processAcceptThread = null;
        // 清除连接超过有效时间的客户端线程
        private Thread clearDisconnectClientsThread = null;
        // 用来存储客户端的列表
        private Dictionary<string, Client> socketClientList = new Dictionary<string, Client>();
        // 客户端结构体，包含socket和过期时间
        private struct Client
        {
            public string token;
            public Socket socket;
            public DateTime dateTime;
        }

        /// <summary>
        /// 获取监听状态
        /// </summary>
        public bool IsListening
        {
            get { return socketListen; }
        }

        /// <summary>
        /// 客户端信息处理
        /// </summary>
        /// <param name="token">客户端标识</param>
        /// <param name="state">操作标识码</param>
        /// <param name="callback">回调返回ID</param>
        /// <param name="data">客户端发送的数据</param>
        public delegate void onClientReceiveHandler(string token, int state, int callback, byte[] data);
        /// <summary>
        /// 客户端信息处理事件
        /// </summary>
        public event onClientReceiveHandler OnClientReceiveHandler;

        /// <summary>
        /// 客户端断开连接
        /// </summary>
        /// <param name="token">客户端标识</param>
        public delegate void onClientCloseHandler(string token);
        /// <summary>
        /// 客户端断开连接事件
        /// </summary>
        public event onClientCloseHandler OnClientCloseHandler;


        /// <summary>
        /// ClassTcpServer构造函数
        /// </summary>
        /// <param name="port">端口号</param>
        public ClassTcpServer(int port)
        {
            iPEndPoint = new IPEndPoint(IPAddress.Any, port);
        }

        /// <summary>
        /// 启动Server服务
        /// </summary>
        /// <returns></returns>
        public bool Start()
        {
            try
            {
                if (!socketListen)
                {
                    // 设置监听标识为真
                    socketListen = true;
                    socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    // 绑定并监听端口
                    socketServer.Bind(iPEndPoint);
                    socketServer.Listen(0);
                    // 开启客户端接入进程
                    processAcceptThread = new Thread(ProcessAccept);
                    processAcceptThread.IsBackground = true;
                    processAcceptThread.Start();
                    // 开启客户端在线检测进程
                    clearDisconnectClientsThread = new Thread(ClearDisconnectClients);
                    clearDisconnectClientsThread.IsBackground = true;
                    clearDisconnectClientsThread.Start();
                }
            }
            catch
            {
                socketListen = false;
            }
            return socketListen;
        }

        /// <summary>
        /// 关闭Server服务
        /// </summary>
        public void Stop()
        {
            if(socketListen)
            {
                socketListen = false;
                socketServer.Close();
                socketServer.Dispose();
                foreach (Client key in socketClientList.Values)
                {
                    key.socket.Close();
                }
                socketClientList.Clear();
            }
        }

        /// <summary>
        /// 客户端接入处理
        /// </summary>
        private void ProcessAccept()
        {
            // 初始化一个临时socket
            Socket connection = null;
            while (socketListen && socketServer != null)
            {
                try
                {
                    connection = socketServer.Accept();
                    if (connection != null)
                    {
                        // 为客户端生成唯一标识
                        string token = Guid.NewGuid().ToString().Replace("-", "");
                        Client client = new Client();
                        client.token = token;
                        client.socket = connection;
                        // 设置客户端有效时间
                        client.dateTime = DateTime.Now.AddMinutes(5);
                        // 将客户端添加到客户端列表
                        socketClientList.Add(token, client);
                        // 启动客户端信息处理线程
                        ThreadPool.QueueUserWorkItem(ClientReceive, client);
                    }
                }
                catch (Exception e)
                {
                }
            }
        }

        /// <summary>
        /// 客户端信息处理
        /// </summary>
        /// <param name="obj">客户端信息</param>
        private void ClientReceive(object obj)
        {
            Client client = (Client)obj;
            while (client.socket.Connected)
            {
                try
                {
                    byte[] temp = new byte[1024];
                    byte[] data = new byte[1024];
                    List<byte> byteSource = new List<byte>();
                    int length = client.socket.Receive(data, data.Length, 0);

                    byteSource.AddRange(data.Take(length));
                    while (client.socket.Available > 0)
                    {
                        Thread.Sleep(100);
                        int len = client.socket.Receive(temp, temp.Length, 0);
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
                        if (System.Int32.TryParse(System.Text.Encoding.UTF8.GetString(data.Take(3).ToArray()), out state))
                        {
                            // 获取回调ID
                            int callbackId = -1;
                            // 是否使用回调函数
                            uint isCallback = data[3];
                            // 截取数据
                            data = data.Skip(4).ToArray();
                            // 获取回调ID
                            if (isCallback == 1)
                            {
                                if (System.Int32.TryParse(System.Text.Encoding.UTF8.GetString(data.Take(4).ToArray()), out callbackId))
                                {
                                    data = data.Skip(4).ToArray();
                                }
                                else
                                {
                                    callbackId = -1;
                                }
                            }

                            // 100是心跳检测包
                            if(state == 100)
                            {
                                client.dateTime = DateTime.Now.AddMinutes(5);
                                socketClientList[client.token] = client;
                                Send(client.token, 100, callbackId, data);
                            }
                            else
                            {
                                // 执行处理函数
                                OnClientReceiveHandler?.Invoke(client.token, state, callbackId, data);
                            }
                        }
                        // 丢弃错误标识码的包
                    }
                }
                catch (SocketException ex)
                {
                    // 客户端断开连接
                    DisconnectClient(client.token);
                    break;
                }
                catch{
                    // 其他错误
                }
            }
            // 循环结束
        }

        /// <summary>
        /// 清除掉线的客户端
        /// </summary>
        private void ClearDisconnectClients()
        {
            // 每分钟检测一下客户端有效性
            while (socketListen)
            {
                foreach (string key in socketClientList.Keys)
                {
                    Client client = socketClientList[key];
                    // 客户端时间过期断开连接
                    if (DateTime.Compare(DateTime.Now, client.dateTime) > 0)
                    {
                        if (client.socket != null && client.socket.Connected)
                        {
                            // 关闭此连接
                            client.socket.Close();
                        }
                    }
                }
                Thread.Sleep(60000);
            }
        }

        /// <summary>
        /// 指定客户端掉线处理
        /// </summary>
        /// <param name="key">客户端标识</param>
        private void DisconnectClient(string key)
        {
            if (socketClientList.ContainsKey(key))
            {
                socketClientList.Remove(key);
                OnClientCloseHandler?.Invoke(key);
            }
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="token"></param>
        /// <param name="state"></param>
        /// <param name="data"></param>
        public void Send(string token, int state, byte[] data)
        {
            if (socketClientList.Keys.Contains(token) && socketClientList[token].socket != null)
            {
                List<byte> byteSource = new List<byte>();
                byte[] byteState = System.Text.Encoding.UTF8.GetBytes(state.ToString().PadLeft(3, '0'));

                byteSource.AddRange(byteState);
                byteSource.AddRange(new byte[] { 0 });
                byteSource.AddRange(data);

                data = byteSource.ToArray();
                socketClientList[token].socket.Send(data);
            }
        }
        public void Send(string token, int state, int callbackId, byte[] data)
        {
            if (socketClientList.Keys.Contains(token) && socketClientList[token].socket != null)
            {
                List<byte> byteSource = new List<byte>();
                byte[] byteState = System.Text.Encoding.UTF8.GetBytes(state.ToString().PadLeft(3, '0'));
                byte[] byteCallbackId = System.Text.Encoding.UTF8.GetBytes(callbackId.ToString().PadLeft(4, '0'));

                byteSource.AddRange(byteState);
                byteSource.AddRange(new byte[] { 1 });
                byteSource.AddRange(byteCallbackId);
                byteSource.AddRange(data);

                data = byteSource.ToArray();
                socketClientList[token].socket.Send(data);
            }
        }
    }
}
