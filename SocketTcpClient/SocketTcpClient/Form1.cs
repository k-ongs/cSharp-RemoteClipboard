using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Net.Sockets;

namespace SocketTcpClient
{
    public partial class Form1 : Form
    {
        ClassTcpClient Client = new ClassTcpClient("127.0.0.1", 6010);

        public Form1()
        {
            InitializeComponent();
            Client.OnServerCloseHandler += Client_OnServerCloseHandler;
        }

        private void Client_OnServerCloseHandler()
        {
            Debug("与服务器断开连接！");
        }

        private void Debug(string msg)
        {
            this.Invoke(new Action(() => {
                textBox1.Text = msg + Environment.NewLine + textBox1.Text;
            }));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Client.Start())
            {
                Debug("连接服务器成功！");
            }
            else
            {
                Debug("连接服务器失败！");
            }
        }

        private void test(bool state, byte[] data)
        {
            if(state)
            {
                Debug("回调成功！");
            }
            else
            {
                Debug("回调失败！");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            byte[] by_msg = Encoding.UTF8.GetBytes("testwqe");

            if(Client.Send(100, by_msg, test))
            {
                Debug("发送成功！");
            }
            else
            {
                Debug("发送失败！");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client.Stop();
        }

    }
}
