using System.Net;
using System.Linq;
using System.Threading;
using System.Net.Sockets;
using System.Collections.Generic;

namespace TCP服务端
{
    class ClassTcpServer
    {
        private bool isListening = true;
        private Socket socketServer = null;
        private IPEndPoint iPEndPoint = null;
        private Dictionary<string, Socket> socketClientList = null;

        // 客户端信息处理
        public delegate void onClientReceiveHandler(string endPoint, byte state, byte[] data);
        public event onClientReceiveHandler OnClientReceiveHandler;

        // 客户端断开连接
        public delegate void onClientCloseHandler(string endPoint);
        public event onClientCloseHandler OnClientCloseHandler;

        public ClassTcpServer(string host, int port)
        {
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
                isListening = true;
                socketServer.Bind(iPEndPoint);
                socketServer.Listen(0);

                Thread processAcceptThread = new Thread(ProcessAccept);
                processAcceptThread.IsBackground = true;
                processAcceptThread.Start();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void Stop()
        {
            isListening = false;
            foreach (Socket client in socketClientList.Values)
            {
                client.Close();
            }
        }

        public void ProcessAccept()
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

        public void SocketClientReceive(object obj)
        {
            Socket connection = obj as Socket;
            while (isListening && connection.Connected)
            {
                try
                {
                    byte[] data = new byte[1024];
                    int length = connection.Receive(data, data.Length, 0);


                    while (connection.Available > 0)
                    {
                        Thread.Sleep(100);
                        byte[] temp = new byte[1024];
                        int len = connection.Receive(temp, temp.Length, 0);
                        if (len > 0)
                        {
                            byte[] dataTemp = new byte[length + len];
                            data.CopyTo(dataTemp, 0);
                            temp.Take(len).ToArray().CopyTo(dataTemp, length);
                            length += len;
                            data = dataTemp;
                        }
                    }

                    if (length > 1)
                    {
                        // 获取标识码
                        byte state = data[length - 1];
                        // 截取数据
                        data = data.Take(length - 1).ToArray();
                        // 执行客户端信息响应事件
                        OnClientReceiveHandler?.Invoke(connection.RemoteEndPoint.ToString(), state, data);
                    }
                }
                catch
                {
                    OnClientCloseHandler?.Invoke(connection.RemoteEndPoint.ToString());
                    return;
                }

                Thread.Sleep(100);
            }
        }

        public void SocketClientSend(string endPoint, byte state, byte[] data)
        {
            if (socketClientList.Keys.Contains(endPoint) && socketClientList[endPoint] != null)
            {
                data = data.Append(state).ToArray();
                socketClientList[endPoint].Send(data);
            }
        }


    }
}
