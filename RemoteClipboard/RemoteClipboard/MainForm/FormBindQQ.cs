using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace RemoteClipboard.MainForm
{
    public partial class FormBindQQ : Form
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

        public FormBindQQ()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormBindQQ_Load(object sender, EventArgs e)
        {
            Action<bool, byte[]> action = new Action<bool, byte[]>(GetImage_Callback);
            ClassStatic.tcpClient.Send(204, new byte[] { }, action);
        }

        private void GetImage_Callback(bool state, byte[] data)
        {
            Image image;
            try
            {
                MemoryStream ms = new MemoryStream(data);
                image = Image.FromStream(ms);
            }
            catch
            {
                image = null;
            }

            System.Diagnostics.Debug.WriteLine(state);
            if (image != null)
            {
                this.Invoke(new Action(() => {
                    pictureQRcode.Image = image;
                    labelTip.Text = "手机QQ扫码绑定";
                    timerQrcode.Start();
                }));
            }
            else
            {
                this.Invoke(new Action(() => {
                    pictureQRcode.Image.Dispose();
                    pictureQRcode.Image = Properties.Resources.qrcodeInvalid;
                    labelTip.Text = "获取二维码失败";
                }));
            }
        }

        private void timerQrcode_Tick(object sender, EventArgs e)
        {
            if (ClassStatic.tcpClient.IsConnected)
            {
                Action<bool, byte[]> action = new Action<bool, byte[]>(TimerQrcode_Callback);
                ClassStatic.tcpClient.Send(205, new byte[] { }, action, 1500);
            }
            else
            {
                if (labelTip.Text != "与网络断开连接")
                {
                    pictureQRcode.Image.Dispose();
                    pictureQRcode.Image = Properties.Resources.qrcodeInvalid;
                    labelTip.Text = "与网络断开连接";
                }
            }
        }

        private void TimerQrcode_Callback(bool state, byte[] data)
        {
            ClassStatic.Result resultData = ClassStatic.GetResult(data);
            if (state && resultData != null)
            {
                switch (resultData.ret)
                {
                    case "0":
                        //扫码成功
                        this.Invoke(new Action(() => {
                            labelTip.Text = "绑定成功";
                            ClassStatic.bind = resultData.data;
                            System.Diagnostics.Debug.WriteLine(resultData.data);
                            timerQrcode.Stop();
                        }));
                        break;
                    case "1":
                        //二维码未失效
                        break;
                    case "2":
                        this.Invoke(new Action(() => {
                            labelTip.Text = "扫码成功，等待用户确定";
                        }));
                        break;
                    case "4":
                        this.Invoke(new Action(() => {
                            pictureQRcode.Image.Dispose();
                            pictureQRcode.Image = Properties.Resources.qrcodeInvalid;
                            labelTip.Text = "已绑定其它手机号";
                            timerQrcode.Stop();
                        }));
                        break;
                    case "5":
                        this.Invoke(new Action(() => {
                            pictureQRcode.Image.Dispose();
                            pictureQRcode.Image = Properties.Resources.qrcodeInvalid;
                            labelTip.Text = "绑定失败";
                            timerQrcode.Stop();
                        }));
                        break;

                    default:
                        //二维码已失效
                        this.Invoke(new Action(() => {
                            pictureQRcode.Image.Dispose();
                            pictureQRcode.Image = Properties.Resources.qrcodeInvalid;
                            labelTip.Text = "二维码已失效";
                            timerQrcode.Stop();
                        }));
                        break;
                }
            }
            else
            {
                this.Invoke(new Action(() => {
                    pictureQRcode.Image.Dispose();
                    pictureQRcode.Image = Properties.Resources.qrcodeInvalid;
                    labelTip.Text = "获取二维码失败";
                    timerQrcode.Stop();
                }));
            }
        }

        private void pictureQRcode_Click(object sender, EventArgs e)
        {
            Action<bool, byte[]> action = new Action<bool, byte[]>(GetImage_Callback);
            ClassStatic.tcpClient.Send(204, new byte[] { }, action);
        }
    }
}
