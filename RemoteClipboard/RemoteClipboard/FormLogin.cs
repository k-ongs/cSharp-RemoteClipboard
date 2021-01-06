using System;
using System.Net;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace RemoteClipboard
{
    public partial class FormLogin : Form
    {
        public static FormLogin formLogin;
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
        public FormLogin()
        {
            formLogin = this;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// 窗体加载初始化参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            labelSwitch_Click(labelPass, null);
            timerNetwork_Tick(null, null);
        }

        /// <summary>
        /// 菜单切换按钮重绘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelSwitch_Paint(object sender, PaintEventArgs e)
        {
            Label that = sender as Label;
            Graphics graphics = e == null ? that.CreateGraphics() : e.Graphics;
            Pen pen = that.Tag == null ? new Pen(Color.FromArgb(240, 240, 240)) : new Pen(Color.FromArgb(31, 148, 247));
            graphics.DrawLine(pen, 0, that.Height - 1, that.Width, that.Height - 1);
            if (e == null) graphics.Dispose();
        }

        /// <summary>
        /// 菜单切换按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelSwitch_Click(object sender, EventArgs e)
        {
            Label that = sender as Label;
            if (that.Tag == null && !timerLabelSwitch.Enabled)
            {
                that.Tag = true;
                if (that == labelScan)
                {
                    labelPass.Tag = null;
                }
                else
                {
                    labelScan.Tag = null;
                }
                labelSwitch_Paint(labelPass, null);
                labelSwitch_Paint(labelScan, null);
                timerLabelSwitch.Start();
            }
        }

        /// <summary>
        /// 菜单切换动画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerLabelSwitch_Tick(object sender, EventArgs e)
        {
            // labelScan.Tag为空，此时选中的密码登录
            int x1 = controlPassLogin.Location.X;
            int x2 = controlScanLogin.Location.X;
            if (labelScan.Tag == null)
            {
                x1 -= 15;
                x2 -= 15;
                x1 = (x1 < 0 ? 0 : x1);
                controlPassLogin.Location = new Point(x1, 0);
                controlScanLogin.Location = new Point(x2, 0);
            }
            else
            {
                x1 += 15;
                x2 += 15;
                x2 = (x2 > 0 ? 0 : x2);
                controlPassLogin.Location = new Point(x1, 0);
                controlScanLogin.Location = new Point(x2, 0);
            }
            if (x1 == 0 || x2 == 0)
            {
                if(labelScan.Tag == null)
                {
                    controlScanLogin.timerQrcode.Stop();
                    controlPassLogin.InitializeControl();
                }
                else
                {
                    controlScanLogin.InitializeControl();
                }
                timerLabelSwitch.Stop();
            }
        }

        /// <summary>
        ///  切换到用户注册界面动画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerControlRegister_Tick(object sender, EventArgs e)
        {
            int x1 = controlRegister.Location.X;
            if (controlRegister.Tag != null)
            {
                x1 += 15;
                controlRegister.Location = new Point(x1, 0);
            }
            else
            {
                x1 -= 15;
                x1 = (x1 < 0 ? 0 : x1);
                controlRegister.Location = new Point(x1, 0);
            }

            if (x1 == 0 || x1 > 260)
            {
                if (x1 >= 260)
                {
                    controlRegister.Tag = null;
                }
                else
                {
                    controlRegister.Tag = true;
                }
                controlRegister.InitializeControl();
                timerControlRegister.Stop();
            }
        }

        /// <summary>
        /// 切换到找回密码界面动画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerControlForgetPass_Tick(object sender, EventArgs e)
        {
            int x1 = controlForgetPass.Location.X;
            if(controlForgetPass.Tag != null)
            {
                x1 += 15;
                controlForgetPass.Location = new Point(x1, 0);
            }
            else
            {
                x1 -= 15;
                x1 = (x1 < 0 ? 0 : x1);
                controlForgetPass.Location = new Point(x1, 0);
            }
            if (x1 == 0 || x1 >= 260)
            {
                if(x1 >= 260)
                {
                    controlForgetPass.Tag = null;
                }
                else
                {
                    controlForgetPass.Tag = true;
                }
                controlForgetPass.InitializeControl();
                timerControlForgetPass.Stop();
            }
        }

        /// <summary>
        /// 切换到加载界面动画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerControlLoading_Tick(object sender, EventArgs e)
        {
            int x1 = userControlLoading.Location.X;
            if (userControlLoading.Tag != null)
            {
                x1 += 15;
                userControlLoading.Location = new Point(x1, 0);
            }
            else
            {
                x1 -= 15;
                x1 = (x1 < 0 ? 0 : x1);
                userControlLoading.Location = new Point(x1, 0);
            }
            if (x1 == 0 || x1 >= 260)
            {
                if (x1 >= 260)
                {
                    userControlLoading.Tag = null;
                }
                else
                {
                    userControlLoading.Tag = true;
                }
                timerControlLoading.Stop();
            }
        }

        /// <summary>
        /// 每10秒检查一下网络连接情况
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerNetwork_Tick(object sender, EventArgs e)
        {
            if(!ClassStatic.tcpClient.IsConnected)
            {
                LabelTipShow("与服务器断开连接，正在重新连接。。。", true, false);
                if(ClassStatic.tcpClient.Start())
                {
                    labelTipShow.Visible = false;
                }
            }
            else
            {
                labelTipShow.Visible = false;
            }
        }

        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="msg">提示信息</param>
        /// <param name="error">是否是错误信息</param>
        /// <param name="await">是否自动消失</param>
        public void LabelTipShow(string msg, bool error = true, bool await=true)
        {
            this.Invoke(new Action(() => {
                if (error)
                {
                    labelTipShow.BackColor = Color.FromArgb(255, 240, 240);
                }
                else
                {
                    labelTipShow.BackColor = Color.FromArgb(168, 236, 186);
                }
                labelTipShow.Text = msg;
                labelTipShow.Visible = true;

                if (await) timerTipShow.Start();
            }));
            
        }

        /// <summary>
        /// 提示信息自动隐藏定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerTipShow_Tick(object sender, EventArgs e)
        {
            labelTipShow.Visible = false;
            timerTipShow.Stop();
        }

        /// <summary>
        /// 登录成功，加载数据
        /// </summary>
        /// <param name="phone"></param>
        public void LoginSuccess(string phone)
        {

            this.Invoke(new Action(() => {
                timerControlLoading.Start();
                if (!ClassStatic.IsPhone(phone))
                {
                    LabelTipShow("登录失败，登录账号格式有误", true);
                    return;
                }
                ClassStatic.account = phone;

                string name = Dns.GetHostName();
                string mac = ClassStatic.GetMacByNetworkInterface();
                Action<bool, byte[]> action = new Action<bool, byte[]>(SendMyOnline_Callback);
                ClassStatic.ClientData clientData = new ClassStatic.ClientData(name, mac, ClassStatic.portraitPid.ToString());
                ClassStatic.tcpClient.Send(201, ClassStatic.SetClientDataByte(clientData), action);
            }));

        }

        /// <summary>
        /// 上线信息响应回调处理
        /// </summary>
        /// <param name="state"></param>
        /// <param name="data"></param>
        private void SendMyOnline_Callback(bool state, byte[] data)
        {
            this.Invoke(new Action(() => {
                if (state)
                {
                    ClassStatic.UserLoginSuccess resultData = ClassStatic.GetLoginSuccessData(data);
                    if (resultData != null && resultData.ret == "true")
                    {
                        ClassStatic.isLogined = true;
                        ClassStatic.bind = resultData.bind;

                        if (ClassStatic.GetConfigSoftware("turnOn") == "")
                        {
                            ClassStatic.SetConfigSoftware("turnOn", "False");
                        }
                        if (ClassStatic.GetConfigSoftware("parse") == "")
                        {
                            ClassStatic.SetConfigSoftware("parse", resultData.parse);
                        }
                        if (ClassStatic.GetConfigSoftware("copy") == "")
                        {
                            ClassStatic.SetConfigSoftware("copy", resultData.copy);
                        }
                        if (ClassStatic.GetConfigSoftware("paste") == "")
                        {
                            ClassStatic.SetConfigSoftware("paste", resultData.paste);
                        }
                        if (ClassStatic.GetConfigSoftware("screenshot") == "")
                        {
                            ClassStatic.SetConfigSoftware("screenshot", resultData.screenshot);
                        }
                        if (ClassStatic.GetConfigSoftware("color") == "")
                        {
                            ClassStatic.SetConfigSoftware("color", resultData.color);
                        }

                        FormLogin.formLogin.Close();
                        return;
                    }
                }
                ClassStatic.account = "";
                LabelTipShow("登录失败，请稍后再试", true);
            }));
            
        }
    }
}
