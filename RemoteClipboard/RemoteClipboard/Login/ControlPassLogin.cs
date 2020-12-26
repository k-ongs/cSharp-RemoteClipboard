using System;
using System.Drawing;
using System.Windows.Forms;

namespace RemoteClipboard.Login
{
    /// <summary>
    /// 密码登录界面
    /// </summary>
    public class ControlPassLogin : Control
    {
        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label8;
        private Label buttonLogin;
        private Label buttonForget;
        private Label buttonRegister;
        private ControlInputBox inputAccount;
        private ControlInputBox inputPassword;
        private CheckBox checkBoxRemember;
        private ControlPortraitBox controlPortraitBox;
        public ControlPassLogin()
        {
            this.Width = 260;
            this.Height = 330;
            InitializeComponent();

            if (!ClassStaticResources.isConnected)
            {
                buttonLogin.Cursor = Cursors.No;
            }

            string pid = ClassStaticResources.GetConfig("portrait");
            string account = ClassStaticResources.GetConfig("account");
            string password = ClassStaticResources.GetConfig("password");
            string remember = ClassStaticResources.GetConfig("remember");

            ClassStaticResources.portraitPid = (pid == "") ? 0 : Convert.ToInt32(pid);

            controlPortraitBox.Portrait = ClassStaticResources.portraitPid;


            if (account.Length == 11)
            {
                inputAccount.Text = account;
                if (password.Length >= 6)
                {
                    inputPassword.Text = password;
                    if (remember == "true")
                    {
                        checkBoxRemember.Checked = true;
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            this.panel1 = new Panel();
            this.panel2 = new Panel();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();
            this.label6 = new Label();
            this.label8 = new Label();
            this.buttonLogin = new Label();
            this.buttonForget = new Label();
            this.buttonRegister = new Label();
            this.inputAccount = new ControlInputBox();
            this.inputPassword = new ControlInputBox();
            this.checkBoxRemember = new CheckBox();
            this.controlPortraitBox = new ControlPortraitBox();

            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();

            //
            // labelLogin
            //
            this.buttonLogin.Text = "登  录";
            this.buttonLogin.Name = "labelLogin";
            this.buttonLogin.ForeColor = Color.White;
            this.buttonLogin.Margin = new Padding(0);
            this.buttonLogin.Size = new Size(260, 35);
            this.buttonLogin.Location = new Point(0, 295);
            this.buttonLogin.Font = new Font("微软雅黑", 10F);
            this.buttonLogin.BackColor = Color.FromArgb(31, 158, 247);
            this.buttonLogin.TextAlign = ContentAlignment.MiddleCenter;
            this.buttonLogin.Click += ButtonLogin_Click;

            // 
            // controlPortraitBox
            // 
            this.controlPortraitBox.BackColor = Color.Transparent;
            this.controlPortraitBox.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.controlPortraitBox.Location = new Point(77, 40);
            this.controlPortraitBox.Margin = new Padding(3, 4, 3, 4);
            this.controlPortraitBox.Name = "controlPortraitBox";
            this.controlPortraitBox.Portrait = 0;
            this.controlPortraitBox.ReplaceImage = true;
            this.controlPortraitBox.Size = new Size(106, 106);
            this.controlPortraitBox.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.inputAccount);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new Point(0, 170);
            this.panel1.Margin = new Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(260, 32);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Font = new Font("微软雅黑", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 134);
            this.label1.ForeColor = Color.Black;
            this.label1.Location = new Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(46, 30);
            this.label1.Text = "账号";
            this.label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = Color.FromArgb(240, 240, 240);
            this.label2.Location = new Point(48, 5);
            this.label2.Name = "label2";
            this.label2.Size = new Size(2, 20);
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.BackColor = Color.FromArgb(240, 240, 240);
            this.label3.Location = new Point(0, 30);
            this.label3.Name = "label3";
            this.label3.Size = new Size(260, 2);
            this.label3.Text = "label3";
            // 
            // inputAccount
            // 
            this.inputAccount.BorderStyle = BorderStyle.None;
            this.inputAccount.Font = new Font("微软雅黑", 10F);
            this.inputAccount.ForeColor = Color.Silver;
            this.inputAccount.Location = new Point(56, 6);
            this.inputAccount.Name = "inputAccount";
            this.inputAccount.Size = new Size(200, 18);
            this.inputAccount.Tips = "请输入账号";
            this.inputAccount.MaxLength = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.inputPassword);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new Point(0, 218);
            this.panel2.Margin = new Padding(0);
            this.panel2.Size = new Size(260, 32);
            this.panel2.TabIndex = 4;
            // 
            // inputPassword
            // 
            this.inputPassword.BorderStyle = BorderStyle.None;
            this.inputPassword.Font = new Font("微软雅黑", 10F);
            this.inputPassword.ForeColor = Color.Silver;
            this.inputPassword.Location = new Point(56, 6);
            this.inputPassword.Name = "inputPassword";
            this.inputPassword.Size = new Size(200, 18);
            this.inputPassword.Tips = "请输入密码";
            this.inputPassword.IsPassword = true;
            this.inputPassword.MaxLength = 26;
            // 
            // label4
            // 
            this.label4.BackColor = Color.FromArgb(240, 240, 240);
            this.label4.Location = new Point(0, 30);
            this.label4.Name = "label4";
            this.label4.Size = new Size(260, 2);
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.BackColor = Color.FromArgb(240, 240, 240);
            this.label5.Location = new Point(48, 5);
            this.label5.Name = "label5";
            this.label5.Size = new Size(2, 20);
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.Font = new Font("微软雅黑", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 134);
            this.label6.Location = new Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new Size(46, 30);
            this.label6.Text = "密码";
            this.label6.ForeColor = Color.Black;
            this.label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // checkBoxRemember
            // 
            this.checkBoxRemember.AutoSize = true;
            this.checkBoxRemember.FlatAppearance.BorderColor = Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.checkBoxRemember.FlatStyle = FlatStyle.Flat;
            this.checkBoxRemember.ForeColor = SystemColors.AppWorkspace;
            this.checkBoxRemember.Location = new Point(0, 259);
            this.checkBoxRemember.Name = "checkBoxRemember";
            this.checkBoxRemember.Size = new Size(72, 21);
            this.checkBoxRemember.Text = "记住密码";
            this.checkBoxRemember.UseVisualStyleBackColor = true;
            // 
            // buttonForget
            // 
            this.buttonForget.AutoSize = true;
            this.buttonForget.ForeColor = Color.Silver;
            this.buttonForget.Location = new Point(142, 261);
            this.buttonForget.Name = "buttonForget";
            this.buttonForget.Size = new Size(56, 17);
            this.buttonForget.Text = "忘记密码";
            this.buttonForget.Cursor = Cursors.Hand;
            this.buttonForget.Click += ButtonForget_Click;
            // 
            // label8
            // 
            this.label8.BackColor = Color.FromArgb(240, 240, 240);
            this.label8.Location = new Point(200, 262);
            this.label8.Name = "label8";
            this.label8.Size = new Size(2, 14);
            this.label8.Text = "label8";
            // 
            // buttonRegister
            // 
            this.buttonRegister.AutoSize = true;
            this.buttonRegister.ForeColor = Color.Silver;
            this.buttonRegister.Location = new Point(204, 261);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new Size(56, 17);
            this.buttonRegister.Text = "用户注册";
            this.buttonRegister.Cursor = Cursors.Hand;
            this.buttonRegister.Click += ButtonRegister_Click;

            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.buttonForget);
            this.Controls.Add(this.checkBoxRemember);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.controlPortraitBox);
            this.Controls.Add(this.buttonLogin);

            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            if (!ClassStaticResources.isConnected) return;
            if (FormLogin.formLogin != null)
            {
                FormLogin.formLogin.SwitchHide();
                FormLogin.formLogin.animation.Start(2);
            }
        }
        private void ButtonForget_Click(object sender, EventArgs e)
        {
            if (!ClassStaticResources.isConnected) return;
            if (FormLogin.formLogin != null)
            {
                FormLogin.formLogin.SwitchHide();
                FormLogin.formLogin.animation.Start(3);
            }
        }
        
        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (!ClassStaticResources.isConnected) return;
            string account = inputAccount.Text;
            string password = inputPassword.Text;

            if(FormLogin.formLogin != null)
            {
                if (account == "")
                {
                    FormLogin.formLogin.TipsShow("请输入账号后再登录");
                    return;
                }
                if (ClassStaticResources.IsPhone(account))
                {
                    FormLogin.formLogin.TipsShow("请输入正确的手机号再登录");
                    return;
                }
                if (password == "")
                {
                    FormLogin.formLogin.TipsShow("请输入密码后再登录");
                    return;
                }

                ClassStaticResources.password = password;
                string remember = checkBoxRemember.Checked ? "true" : "false";
                ClassStaticResources.SetConfig("account", account);
                ClassStaticResources.SetConfig("password", password);
                ClassStaticResources.SetConfig("remember", remember);
                FormLogin.formLogin.Close();
            }
        }
    }
}
