using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace RemoteClipboard.Login
{
    public partial class ControlScanLogin : UserControl
    {
        public ControlScanLogin()
        {
            InitializeComponent();
        }

        public void InitializeControl()
        {
            ForeColor = Color.Black;

            Action<bool, byte[]> action = new Action<bool, byte[]>(GetImage_Callback);
            ClassStatic.tcpClient.Send(102, new byte[]{}, action);
        }

        /// <summary>
        /// 获取二维码图片
        /// </summary>
        /// <param name="state"></param>
        /// <param name="data"></param>
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

            if(image != null)
            {
                this.Invoke(new Action(() => {
                    pictureQRcode.Image = image;
                    labelTip.Text = "手机QQ扫码登录";
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
                ClassStatic.tcpClient.Send(103, new byte[] { }, action, 1500);
            }
            else
            {
                if(labelTip.Text != "与网络断开连接")
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
            System.Diagnostics.Debug.WriteLine(resultData.ret);
            if(state && resultData != null)
            {
                switch(resultData.ret)
                {
                    case "0":
                        //登录成功
                        this.Invoke(new Action(() => {
                            FormLogin.formLogin.LoginSuccess(resultData.data);
                            pictureQRcode.Image.Dispose();
                            pictureQRcode.Image = Properties.Resources.qrcodeInvalid;
                            labelTip.Text = "二维码已失效";
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
                            labelTip.Text = "没有绑定手机号，请先注册";
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
            ClassStatic.tcpClient.Send(102, new byte[] { }, action);
        }
    }
}
