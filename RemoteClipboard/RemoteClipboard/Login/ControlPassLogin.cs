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
    public partial class ControlPassLogin : UserControl
    {
        public ControlPassLogin()
        {
            InitializeComponent();
        }

        private void buttonForget_Click(object sender, EventArgs e)
        {
            buttonForget.Focus();
            FormLogin.formLogin.timerControlForgetPass.Start();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            buttonRegister.Focus();
            FormLogin.formLogin.timerControlRegister.Start();
        }

        public void InitializeControl()
        {
            ForeColor = Color.Black;
            inputAccount.Tips = "请输入手机号";
            inputPassword.Tips = "请输入至少8位的密码";

            // 账号
            string account = ClassStatic.GetConfig("account");
            // 头像
            string portrait = ClassStatic.GetConfig("portrait");
            // 密码
            string password = ClassStatic.GetConfig("password");
            // 记住密码
            string remember = ClassStatic.GetConfig("remember");

            ClassStatic.portraitPid = (portrait == "") ? 0 : Convert.ToInt32(portrait);
            controlPortraitBox.Portrait = ClassStatic.portraitPid;

            if (ClassStatic.IsPhone(account))
            {
                inputAccount.Text = account;
                if (ClassStatic.IsComplexPass(password))
                {
                    inputPassword.Text = password;
                    if (remember == "true")
                    {
                        checkBoxRemember.Checked = true;
                    }
                }
            }
        }

        private void labelLogin_Click(object sender, EventArgs e)
        {
            labelLogin.Focus();
            if (!ClassStatic.tcpClient.IsConnected) return;

            string account = inputAccount.Text;
            string password = inputPassword.Text;

            if (!ClassStatic.IsPhone(account))
            {
                FormLogin.formLogin.LabelTipShow("请输入正确的手机号再登录");
                return;
            }
            if (password.Length == 0)
            {
                FormLogin.formLogin.LabelTipShow("请输入密码后再登录");
                return;
            }

            ClassStatic.ClientData clientData = new ClassStatic.ClientData(account, password);
            Action<bool, byte[]> action = new Action<bool, byte[]>(LabelLogin_Callback);
            ClassStatic.tcpClient.Send(101, ClassStatic.SetClientDataByte(clientData), action);
        }

        private void ControlPassLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                labelLogin_Click(labelLogin, null);
            }
        }

        /// <summary>
        /// 登录回调函数
        /// </summary>
        /// <param name="state"></param>
        /// <param name="data"></param>
        private void LabelLogin_Callback(bool state, byte[] data)
        {
            ClassStatic.Result resultData = ClassStatic.GetResult(data);
            if(state && resultData != null)
            {
                if (resultData.ret == "true")
                {
                    this.Invoke(new Action(() => {
                        string remember = checkBoxRemember.Checked ? "true" : "false";
                        ClassStatic.SetConfig("account", inputAccount.Text);
                        ClassStatic.SetConfig("password", inputPassword.Text);
                        ClassStatic.SetConfig("remember", remember);
                        FormLogin.formLogin.LoginSuccess(inputAccount.Text);
                    }));
                }
                else
                {
                    FormLogin.formLogin.LabelTipShow(resultData.msg);
                }
            }
            else
            {
                FormLogin.formLogin.LabelTipShow("登录失败，请检查网络");
            }

        }
    }
}
