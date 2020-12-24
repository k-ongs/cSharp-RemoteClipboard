using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP连接测试
{
    public partial class Form1 : Form
    {
        ClassTcpClient client = new ClassTcpClient("127.0.0.1", 6010);
        public Form1()
        {
            InitializeComponent();
            client.OnServerReceiveHandler += OnServerReceiveHandler;
            client.OnServerCloseHandler += OnServerCloseHandler;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client.Start();
        }

        public void OnServerReceiveHandler(byte state, byte[] data)
        {
            this.Invoke(new Action(() => {
                listBox1.Items.Add("收到服务器信息["+state+"]：" + Encoding.ASCII.GetString(data));
            }));
        }
        public void OnServerCloseHandler()
        {
            this.Invoke(new Action(() => {
                listBox1.Items.Add("与服务器断开连接");
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = textBox1.Text;
            if(msg != "")
            {
                client.SocketClientSend(100, Encoding.Default.GetBytes(msg));
            }
        }
    }
}
