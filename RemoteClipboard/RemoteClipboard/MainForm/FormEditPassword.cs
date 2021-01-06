using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace RemoteClipboard.MainForm
{
    public partial class FormEditPassword : Form
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

        private int timeVerify = 300;
        public FormEditPassword()
        {
            InitializeComponent();
            inputVerify.Tips = "请输入验证码";
            inputPassword.Tips = "请输入至少8位的密码";
            inputAccount.Tips = "请输入手机号";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// 刷新验证码按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerVerify_Tick(object sender, EventArgs e)
        {
            buttonVerify.Text = (--timeVerify).ToString();

            if (timeVerify == 0)
            {
                buttonVerify.BackColor = ClassStatic.mainColors;
                buttonVerify.ForeColor = Color.White;
                buttonVerify.Cursor = Cursors.Hand;
                timeVerify = 300;
                timerVerify.Stop();
            }
        }

        /// <summary>
        /// 发送验证码点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonVerify_Click(object sender, EventArgs e)
        {
            if (!ClassStatic.tcpClient.IsConnected || buttonVerify.Cursor == Cursors.No) return;

            string account = inputAccount.Text;

            if (!ClassStatic.IsPhone(account))
            {
                LabelTipShow("请输入正确的手机号再试");
                return;
            }

            Action<bool, byte[]> action = new Action<bool, byte[]>(ButtonVerify_Callback);
            ClassStatic.tcpClient.Send(106, System.Text.Encoding.UTF8.GetBytes(account), action);
        }

        /// <summary>
        /// 发送验证码回调函数
        /// </summary>
        /// <param name="state"></param>
        /// <param name="data"></param>
        private void ButtonVerify_Callback(bool state, byte[] data)
        {
            ClassStatic.Result resultData = ClassStatic.GetResult(data);
            this.Invoke(new Action(() => {
                if (resultData != null)
                {
                    if (resultData.ret == "true")
                    {
                            buttonVerify.ForeColor = Color.Black;
                            buttonVerify.BackColor = Color.WhiteSmoke;
                            buttonVerify.Cursor = Cursors.No;
                            buttonVerify.Text = timeVerify.ToString();
                            timerVerify.Start();
                    }
                    else
                    {
                        LabelTipShow(resultData.msg);
                    }
                }
                else
                {
                    LabelTipShow("发送验证码失败");
                }
            }));
        }

        /// <summary>
        /// 修改密码按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (!ClassStatic.tcpClient.IsConnected) return;
            string account = inputAccount.Text;
            string verify = inputVerify.Text;
            string password = inputPassword.Text;

            if (!ClassStatic.IsPhone(account))
            {
                LabelTipShow("请输入正确的手机号");
                return;
            }
            if (verify.Length != 6)
            {
                LabelTipShow("请输入正确的验证码");
                return;
            }
            if (!ClassStatic.IsComplexPass(password))
            {
                LabelTipShow("请输入8位以上的复杂密码");
                return;
            }

            ClassStatic.ClientData clientData = new ClassStatic.ClientData(account, password, verify);
            Action<bool, byte[]> action = new Action<bool, byte[]>(ButtonSubmit_Callback);
            ClassStatic.tcpClient.Send(107, ClassStatic.SetClientDataByte(clientData), action);
        }

        /// <summary>
        /// 找回密码按钮提交回调函数
        /// </summary>
        /// <param name="state"></param>
        /// <param name="data"></param>
        private void ButtonSubmit_Callback(bool state, byte[] data)
        {
            ClassStatic.Result resultData = ClassStatic.GetResult(data);

            this.Invoke(new Action(() => {
                if (resultData != null)
                {
                    if (resultData.ret == "true")
                    {
                        buttonVerify.Enabled = false;
                        buttonSubmit.Enabled = false;
                        LabelTipShow("修改密码成功", false, false);
                    }
                    else
                    {
                        LabelTipShow(resultData.msg);
                    }
                }
                else
                {
                    LabelTipShow("修改密码失败");
                }
            }));

        }

        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="error"></param>
        /// <param name="await"></param>
        public void LabelTipShow(string msg, bool error = true, bool await = true)
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
    }
}
