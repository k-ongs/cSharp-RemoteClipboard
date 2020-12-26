using System.Net;
using System.Linq;
using System.Threading;
using System.Net.Sockets;
using System.Collections.Generic;

namespace RemoteClipboardServer
{
    class ClassTcpServer
    {
        private bool isListening = true;
        private Socket socketServer = null;
        private IPEndPoint iPEndPoint = null;
        private Thread processAcceptThread = null;
        private Dictionary<string, Socket> socketClientList = null;

        public bool IsListening
        {
            get { return isListening; }
        }

        // 客户端信息处理
        public delegate void onClientReceiveHandler(string endPoint, int state,int callback, byte[] data);
        public event onClientReceiveHandler OnClientReceiveHandler;

        // 客户端断开连接
        public delegate void onClientCloseHandler(string endPoint);
        public event onClientCloseHandler OnClientCloseHandler;

        public ClassTcpServer(string host, int port)
        {
            processAcceptThread = new Thread(ProcessAccept);
            processAcceptThread.IsBackground = true;
            iPEndPoint = new IPEndPoint(IPAddress.Parse(host), port);
            socketClientList = new Dictionary<string, Socket>();
            socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        /// <summary>
        /// 开启服务
        /// </summary>
        public bool Start()
        {
            try
            {
                if(!socketServer.IsBound)
                {
                    socketServer.Bind(iPEndPoint);
                    socketServer.Listen(0);
                    processAcceptThread.Start();
                }
                isListening = true;
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 停止服务
        /// </summary>
        public void Stop()
        {
            isListening = false;
            foreach (Socket client in socketClientList.Values)
            {
                client.Close();
            }
        }

        /// <summary>
        /// 客户端连接事件
        /// </summary>
        private void ProcessAccept()
        {
            Socket connection = null;
            while (isListening && socketServer.IsBound)
            {
                connection = socketServer.Accept();
                if (connection != null)
                {
                    socketClientList.Add(connection.RemoteEndPoint.ToString(), connection);
                    Thread socketConnectedThread = new Thread(SocketClientReceive);
                    socketConnectedThread.IsBackground = true;
                    socketConnectedThread.Start(connection);
                }
            }
        }

        /// <summary>
        /// 客户端数据接收
        /// </summary>
        /// <param name="obj"></param>
        public void SocketClientReceive(object obj)
        {
            Socket connection = obj as Socket;
            while (isListening && connection.Connected)
            {
                try
                {
                    byte[] data = new byte[1024];
                    List<byte> byteSource = new List<byte>();
                    int length = connection.Receive(data, data.Length, 0);

                    byteSource.AddRange(data.Take(length));
                    while (connection.Available > 0)
                    {
                        Thread.Sleep(100);
                        byte[] temp = new byte[1024];
                        int tempLen = connection.Receive(temp, temp.Length, 0);
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
                        if (System.Int32.TryParse(System.Text.Encoding.UTF8.GetString(data.Take(3).ToArray()), out state))
                        {
                            // 获取回调ID
                            int callbackId = -1;
                            uint isCallback = data[3];

                            data = data.Skip(4).ToArray();
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
                            OnClientReceiveHandler?.Invoke(connection.RemoteEndPoint.ToString(), state, callbackId, data);
                        }
                    }
                }
                catch
                {
                    //OnClientCloseHandler?.Invoke(connection.RemoteEndPoint.ToString());
                    return;
                }

                Thread.Sleep(100);
            }
        }

        public void Send(string endPoint, int state, byte[] data)
        {
            if (socketClientList.Keys.Contains(endPoint) && socketClientList[endPoint] != null)
            {
                List<byte> byteSource = new List<byte>();
                byte[] byteState = System.Text.Encoding.UTF8.GetBytes(state.ToString().PadLeft(3, '0'));

                byteSource.AddRange(byteState);
                byteSource.AddRange(new byte[] {0});
                byteSource.AddRange(data);

                data = byteSource.ToArray();
                socketClientList[endPoint].Send(data);
            }
        }

        public void Send(string endPoint, int state, int callbackId, byte[] data)
        {
            if (socketClientList.Keys.Contains(endPoint) && socketClientList[endPoint] != null)
            {
                List<byte> byteSource = new List<byte>();
                byte[] byteState = System.Text.Encoding.UTF8.GetBytes(state.ToString().PadLeft(3, '0'));
                byte[] byteCallbackId = System.Text.Encoding.UTF8.GetBytes(callbackId.ToString().PadLeft(4, '0'));

                byteSource.AddRange(byteState);
                byteSource.AddRange(new byte[] { 1 });
                byteSource.AddRange(byteCallbackId);
                byteSource.AddRange(data);

                data = byteSource.ToArray();
                socketClientList[endPoint].Send(data);
            }
        }
    }
}
