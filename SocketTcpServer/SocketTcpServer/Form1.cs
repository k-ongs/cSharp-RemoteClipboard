using System;
using System.Net;
using System.Linq;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SocketTcpServer
{
    public partial class Form1 : Form
    {
        ClassTcpServer server = new ClassTcpServer(6010);

        public Form1()
        {
            InitializeComponent();
            server.OnClientCloseHandler += Server_OnClientCloseHandler;
        }

        private void Server_OnClientCloseHandler(string token)
        {
            Debug("客户端：" + token + "已下线");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void Debug(string msg)
        {
            this.Invoke(new Action(() => {
                textBox1.Text = msg + Environment.NewLine + textBox1.Text;
            }));
        }

        /// <summary>
        /// 开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if(server.Start())
            {
                Debug("启动服务成功！");
            }
            else
            {
                Debug("启动服务失败！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            server.Stop();

            Debug("停止服务成功！");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ThreadPool.

            int MaxWorkerThreads, miot, AvailableWorkerThreads, aiot;

            //获得最大的线程数量
            ThreadPool.GetMaxThreads(out MaxWorkerThreads, out miot);

            AvailableWorkerThreads = aiot = 0;

            //获得可用的线程数量
            ThreadPool.GetAvailableThreads(out AvailableWorkerThreads, out aiot);

            //返回线程池中活动的线程数
            Debug("当前线程池中活动的线程数为：" + (MaxWorkerThreads - AvailableWorkerThreads));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            char[] a = {'a'};
            System.Diagnostics.Debug.WriteLine(a[22]) ;
        }

    }
}
