using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Management;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

//using CSR = RemoteClipboardServer.ClassStaticResources;

namespace RemoteClipboardServer
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// 此结构包含有关当前内存可用性的信息。参考至https://docs.microsoft.com/zh-cn/previous-versions/bb202730(v=msdn.10)
        /// </summary>
        public struct MEMORYSTATUS
        {
            public uint dwLength;
            public uint dwMemoryLoad; // 使用占用率，是一个介于0到100之间的数字。
            public uint dwTotalPhys;
            public uint dwAvailPhys;
            public uint dwTotalPageFile;
            public uint dwAvailPageFile;
            public uint dwTotalVirtual;
            public uint dwAvailVirtual;
        }

        /// <summary>
        /// 获取有关系统物理和虚拟内存的信息。 参考至https://docs.microsoft.com/zh-cn/previous-versions/aa908760(v=msdn.10)
        /// </summary>
        /// <param name="meminfo">指向MEMORYSTATUS结构的指针</param>
        [DllImport("kernel32")]
        public static extern void GlobalMemoryStatus(ref MEMORYSTATUS meminfo);

        #region 绘制窗体阴影
        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        private bool m_aeroEnabled;                     // variables for box shadow
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;

        public struct MARGINS                           // struct for box shadow
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        private const int WM_NCHITTEST = 0x84;          // variables for dragging the form
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();

                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }
        }

        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:                        // box shadow
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 0,
                            rightWidth = 0,
                            topHeight = 0
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }
        #endregion
        public FormMain()
        {
            InitializeComponent();
            ClassStatic.formMain = this;
            ClassStatic.tcpServer.OnClientCloseHandler += OnClientCloseHandler;
            ClassStatic.tcpServer.OnClientReceiveHandler += ClassLoginHandle.Login;
            ClassStatic.tcpServer.OnClientReceiveHandler += ClassLoginHandle.Register;
            ClassStatic.tcpServer.OnClientReceiveHandler += ClassLoginHandle.RegisterSendCode;
            ClassStatic.tcpServer.OnClientReceiveHandler += ClassLoginHandle.RetrievePassword;
            ClassStatic.tcpServer.OnClientReceiveHandler += ClassLoginHandle.RetrievePasswordSendCode;
        }

        /// <summary>
        /// 窗体启动后初始化参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            timer1.Start();

            /// 获取用户数量
            DataTable dataTable = ClassStatic.sqlServer.Field("count(*)").Select("userInfo");
            if(dataTable.Rows.Count > 0)
            {
                ClassStatic.totalNumberOfUsers = Convert.ToInt32(dataTable.Rows[0][0]);
                controlProgressBar1.Progress = ClassStatic.totalNumberOfUsers;
            }
        }

        /// <summary>
        /// 每隔一秒刷新内存使用率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            /// 获取内存使用率
            MEMORYSTATUS MemInfo = new MEMORYSTATUS();
            GlobalMemoryStatus(ref MemInfo);
            int dwMemoryLoad = Convert.ToInt32(MemInfo.dwMemoryLoad);
            if(dwMemoryLoad != controlProgressBar4.Progress)
            {
                controlProgressBar4.Progress = Convert.ToInt32(MemInfo.dwMemoryLoad);
            }

            controlProgressBar1.Progress = ClassStatic.totalNumberOfUsers;
        }

        /// <summary>
        /// 开启服务按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if(ClassStatic.tcpServer.Start())
            {
                button2.Cursor = Cursors.Hand;
                button2.ForeColor = Color.White;
                button2.BackColor = Color.FromArgb(31, 148, 247);

                button1.Cursor = Cursors.Default;
                button1.ForeColor = Color.Black;
                button1.BackColor = Color.Gainsboro;

                button2.Enabled = true;
                button1.Enabled = false;
                textBox1.Text = "[系统] 启动服务成功" + Environment.NewLine + textBox1.Text;
            }
            else
            {
                textBox1.Text = "[错误] 启动服务错误，请检查端口是否被占用！" + Environment.NewLine + textBox1.Text;
            }
        }

        /// <summary>
        /// 关闭服务按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            ClassStatic.tcpServer.Stop();
            button1.Cursor = Cursors.Hand;
            button1.ForeColor = Color.White;
            button1.BackColor = Color.FromArgb(31, 148, 247);

            button2.Cursor = Cursors.Default;
            button2.ForeColor = Color.Black;
            button2.BackColor = Color.Gainsboro;

            button1.Enabled = true;
            button2.Enabled = false;

            textBox1.Text = "[系统] 关闭服务成功" + Environment.NewLine + textBox1.Text;
        }

        /// <summary>
        /// 调试框输出
        /// </summary>
        /// <param name="msg"></param>
        public void ConsoleWrite(string msg)
        {
            this.Invoke(new Action(() => {
                textBox1.Text = msg + Environment.NewLine + textBox1.Text;
            }));
        }

        /// <summary>
        /// 客户端断开连接事件
        /// </summary>
        /// <param name="endPoint"></param>
        private void OnClientCloseHandler(string token)
        {
            ConsoleWrite("[系统] 客户端：" + token + "已断开连接！");
        }
    }
}
