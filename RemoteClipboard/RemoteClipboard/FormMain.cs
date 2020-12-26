using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace RemoteClipboard
{
    public partial class FormMain : Form
    {
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
        private Timer timerNetworkTest;
        private int menuButtonActive = 1;
        private ControlDeviceList deviceList = new ControlDeviceList();
        private ControlSoftwareSetting softwareSetting = new ControlSoftwareSetting();

        public FormMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();

            timerNetworkTest = new Timer();
            timerNetworkTest.Tick += TimerNetworkTest_Tick;
            timerNetworkTest.Interval = 10000;
            timerNetworkTest.Start();

            ClassStaticResources.tcpClient.OnServerCloseHandler += onServerCloseHandler;
            ClassStaticResources.tcpClient.OnServerReceiveHandler += OnServerReceiveHandler;
            ClassStaticResources.tcpClient.Start();
        }
        private void TimerNetworkTest_Tick(object sender, EventArgs e)
        {
            if(!ClassStaticResources.tcpClient.IsConnected)
            {
                ClassStaticResources.tcpClient.Start();
            }
        }

        public void OnServerReceiveHandler(int state, byte[] data)
        {

        }

        public void onServerCloseHandler()
        {

        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            FormLogin formTemp = new FormLogin();
            formTemp.ShowDialog();
            formTemp.Dispose();

            if (ClassStaticResources.password.Length < 6)
            {
                this.Dispose();
                this.Close();
                return;
            }

            this.Show();
            if(ClassStaticResources.doNotDisturb)
            {
                statusOnlineControl1.Status = 1;
            }
            
            panel1.Controls.Add(deviceList);
            portraitBox1.Portrait = ClassStaticResources.portraitPid;
        }

        private void MenuButtn_MouseHover(object sender, EventArgs e)
        {
            Panel panel;
            if (sender is Label)
            {
                sender = ((Label)sender).Parent;
            }

            if (sender is Panel)
            {
                panel = (Panel)sender;
                if (menuButtonActive != Convert.ToInt32(panel.Tag))
                {
                    panel.BackColor = Color.WhiteSmoke;
                }
            }
        }

        private void MenuButtn_MouseLeave(object sender, EventArgs e)
        {
            Panel panel;
            if (sender is Label)
            {
                sender = ((Label)sender).Parent;
            }

            if (sender is Panel)
            {
                panel = (Panel)sender;
                if (menuButtonActive != Convert.ToInt32(panel.Tag))
                {
                    panel.BackColor = Color.Transparent;
                }
            }
        }

        private void MenuButtn_Click(object sender, EventArgs e)
        {
            Panel panel;
            if (sender is Label)
            {
                sender = ((Label)sender).Parent;
            }

            if (sender is Panel)
            {
                panel = (Panel)sender;
                if (menuButtonActive != Convert.ToInt32(panel.Tag))
                {
                    panel1.Controls.Clear();

                    if (Convert.ToInt32(panel.Tag) == 1)
                    {
                        menuButtonActive = 1;
                        panel1.Controls.Add(deviceList);
                        panel2.BackColor = Color.WhiteSmoke;
                        panel3.BackColor = Color.Transparent;
                    }
                    else
                    {
                        menuButtonActive = 2;
                        panel1.Controls.Add(softwareSetting);
                        panel3.BackColor = Color.WhiteSmoke;
                        panel2.BackColor = Color.Transparent;
                    }
                }
            }
        }
    }
}
