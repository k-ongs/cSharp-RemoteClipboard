using System;
using System.IO;
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

        private void test(string file)
        {

        }

        private byte[] ReadFile(string fileName)
        {
            FileStream pFileStream = null;
            byte[] pReadByte = new byte[0];
            try 
            {
                pFileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader r = new BinaryReader(pFileStream);
                r.BaseStream.Seek(0, SeekOrigin.Begin);    //将文件指针设置到文件开
                pReadByte = r.ReadBytes((int)r.BaseStream.Length);
                return pReadByte;
            }
            catch
            {
                return pReadByte;
            }
            finally
            {
                if (pFileStream != null)
                    pFileStream.Close();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Action<string> action = new Action<string>(test);
            //action("D:/web/test/1.png");
            if(!client.Start())
            {
                this.Invoke(new Action(() => {
                    listBox1.Items.Add("连接服务器失败！");
                }));
            }
        }

        public void OnServerReceiveHandler(int state, byte[] data)
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

        private void sendMsgCallback(bool state, byte[] data)
        {
            this.Invoke(new Action(() => {
                if (state)
                {
                    listBox1.Items.Add(Encoding.UTF8.GetString(data));
                }
                else
                {
                    listBox1.Items.Add("发送信息回调超时！");
                }
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = textBox1.Text;
            if(msg != "")
            {
                Action<bool, byte[]> action = new Action<bool, byte[]>(sendMsgCallback);
                int callback = client.Send(144, Encoding.UTF8.GetBytes(msg), action);
            }
        }
    }
}
