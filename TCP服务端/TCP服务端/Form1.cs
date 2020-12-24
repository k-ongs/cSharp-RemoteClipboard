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
        ClassTcpServer server = new ClassTcpServer("127.0.0.1", 6010);
        public Form1()
        {
            InitializeComponent();
            server.OnClientReceiveHandler += OnClientReceiveHandler;
            server.OnClientCloseHandler += OnClientCloseHandler;
        }

        public void OnClientReceiveHandler(string endPoint, byte state, byte[] data)
        {
            this.Invoke(new Action(() => {
                listBox1.Items.Add(endPoint + "[" + state + "]：" + Encoding.Default.GetString(data));
            }));
        }
        public void OnClientCloseHandler(string endPoint)
        {
            this.Invoke(new Action(() => {
                listBox1.Items.Add(endPoint + "已断开连接");
            }));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            server.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
