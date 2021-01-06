using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteClipboard.Login
{
    public partial class ControlForgetPass : UserControl
    {
        private Timer timerVerify;
        private int timeVerify = 300;

        public ControlForgetPass()
        {
            InitializeComponent();
            timerVerify = new Timer();
            timerVerify.Interval = 1000;
            timerVerify.Tick += TimerVerify_Tick;
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
        /// 返回登录界面按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelBackLogin_Click(object sender, EventArgs e)
        {
            FormLogin.formLogin.timerControlForgetPass.Start();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void InitializeControl()
        {
            ForeColor = Color.Black;
            inputVerify.Tips = "请输入验证码";
            inputPassword.Tips = "请输入至少8位的密码";
            inputAccount.Tips = "请输入手机号";
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
                FormLogin.formLogin.LabelTipShow("请输入正确的手机号再试");
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

            if (resultData != null)
            {
                if (resultData.ret == "true")
                {
                    this.Invoke(new Action(() => {
                        buttonVerify.ForeColor = Color.Black;
                        buttonVerify.BackColor = Color.WhiteSmoke;
                        buttonVerify.Cursor = Cursors.No;
                        buttonVerify.Text = timeVerify.ToString();
                        timerVerify.Start();
                    }));
                }
                else
                {
                    FormLogin.formLogin.LabelTipShow(resultData.msg);
                }
            }
            else
            {
                FormLogin.formLogin.LabelTipShow("注册失败");
            }
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
                FormLogin.formLogin.LabelTipShow("请输入正确的手机号");
                return;
            }
            if (verify.Length != 6)
            {
                FormLogin.formLogin.LabelTipShow("请输入正确的验证码");
                return;
            }
            if (!ClassStatic.IsComplexPass(password))
            {
                FormLogin.formLogin.LabelTipShow("请输入8位以上的复杂密码");
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

            if (resultData != null)
            {
                if (resultData.ret == "true")
                {
                    FormLogin.formLogin.LabelTipShow("修改密码成功，正在跳转...", false);
                    this.Invoke(new Action(() => {
                        labelBackLogin_Click(labelBackLogin, null);
                    }));
                }
                else
                {
                    FormLogin.formLogin.LabelTipShow(resultData.msg);
                }
            }
            else
            {
                FormLogin.formLogin.LabelTipShow("修改密码失败");
            }

        }
    }
}
