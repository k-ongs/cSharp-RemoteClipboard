using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP服务端
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Boolean running = true;

            string host = "127.0.0.1";
            // socket服务端口
            int port = 21000;
            // 将将IP地址字符串转换为IPAddress对象
            IPAddress ip = IPAddress.Parse(host);
            // 终结点EndPoint
            IPEndPoint ipe = new IPEndPoint(ip, port);

            //============================================================================//
            // 2、创建socket连接服务端并监听端口
            //============================================================================//
            //创建TCP Socket对象
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //绑定EndPoint对象（地址）
            server.Bind(ipe);
            //开始监听
            server.Listen(0);
            Console.WriteLine("已经处于监听状态，等待客户端连接 . . . ");

            //============================================================================//
            // 3、与客户端交互
            //============================================================================//
            while (running)
            {
                Socket remote = server.Accept();
                Console.WriteLine("客户端连接 . . . ");
                // 接收客户端消息
                Receive(remote);
                // 发送给客户端消息
                Send(remote);
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
