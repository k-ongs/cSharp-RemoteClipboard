using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace TCP服务端
{
    class ClassTcpServer
    {
        private bool isListening = true;
        private Socket socketServer = null;
        private IPEndPoint iPEndPoint = null;
        private Thread processAcceptThread = null;

        /*
        public delegate void OnConnectedHandler();
        public event OnConnectedHandler OnConnected;
        public event OnConnectedHandler OnFaildConnect;
        public delegate void OnReceiveMsgHandler();
        public event OnReceiveMsgHandler OnReceiveMsg;
        */

        // 存储客户端地址

        private static Dictionary<string, Socket> clientItems = new Dictionary<string, Socket> { };


        public ClassTcpServer(string host, int port)
        {
            processAcceptThread = new Thread(ProcessAccept);
            processAcceptThread.IsBackground = true;
            iPEndPoint = new IPEndPoint(IPAddress.Parse(host), port);
            socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        /// <summary>
        /// 开启服务
        /// </summary>
        public bool Start()
        {
            try
            {
                // 绑定端口
                socketServer.Bind(iPEndPoint);
                socketServer.Listen(0);
                isListening = true;
                processAcceptThread.Start();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void ProcessAccept()
        {
            Socket connection = null;
            while (isListening && socketServer.IsBound)
            {
                try
                {
                    connection = socketServer.Accept();
                }
                catch{}

                // 获取客户端的IP和端口号
                IPAddress clientIP = (connection.RemoteEndPoint as IPEndPoint).Address;
                int clientPort = (connection.RemoteEndPoint as IPEndPoint).Port;

                string remoteEndPoint = connection.RemoteEndPoint.ToString();

                string sendmsg = "连接服务端成功！\r\n" + "本地IP:" + clientIP + "，本地端口" + clientPort.ToString();
            }
        }

        static void Receive(Socket socket)
        {
            byte[] bytes = new byte[1024];
            //从客户端接收消息
            int len = socket.Receive(bytes, bytes.Length, 0);
            //将消息转为字符串
            string recvStr = Encoding.ASCII.GetString(bytes, 0, len);
            Console.WriteLine("接收的客户端消息 ： {0}", recvStr);
        }

        static void Send(Socket socket)
        {
            string sendStr = "www.what21.com, What21ServerSocket, Client send message successful！";
            Console.WriteLine("发送给客户端消息 ： {0}", sendStr);
            // 将字符串消息转为数组
            byte[] bytes = Encoding.ASCII.GetBytes(sendStr);
            //发送消息给客户端
            socket.Send(bytes, bytes.Length, 0);
        }
    }
}
