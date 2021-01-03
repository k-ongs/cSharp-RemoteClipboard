using System;
using System.Drawing;
using System.Windows.Forms;

namespace RemoteClipboard.Login
{
    class ControlForgetPass : Control
    {
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label labelBack;
        private Label labelTitle;
        private Label buttonVerify;
        private Label buttonRegister;
        private ControlInputBox inputVerify;
        private ControlInputBox inputAccount;
        private ControlInputBox inputPassword;

        public ControlForgetPass()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.panel1 = new Panel();
            this.panel2 = new Panel();
            this.panel3 = new Panel();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();
            this.labelBack = new Label();
            this.labelTitle = new Label();
            this.buttonVerify = new Label();
            this.buttonRegister = new Label();
            this.inputVerify = new ControlInputBox();
            this.inputAccount = new ControlInputBox();
            this.inputPassword = new ControlInputBox();

            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();

            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new Font("微软雅黑", 13F);
            this.labelTitle.ForeColor = Color.Black;
            this.labelTitle.Location = new Point(4, 6);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new Size(82, 24);
            this.labelTitle.Text = "忘记密码";
            // 
            // panel1
            // 
            this.panel1.Location = new Point(0, 58);
            this.panel1.Margin = new Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(260, 32);
            // 
            // label1
            // 
            this.label1.Font = new Font("微软雅黑", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 134);
            this.label1.ForeColor = Color.Black;
            this.label1.Location = new Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(46, 30);
            this.label1.Text = "+86";
            this.label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = Color.FromArgb(240, 240, 240);
            this.label2.Location = new Point(48, 5);
            this.label2.Name = "label2";
            this.label2.Size = new Size(2, 20);
            this.label2.Text = "";
            // 
            // label3
            // 
            this.label3.BackColor = Color.FromArgb(240, 240, 240);
            this.label3.Location = new Point(0, 30);
            this.label3.Name = "label3";
            this.label3.Size = new Size(260, 2);
            this.label3.Text = "";
            // 
            // inputAccount
            // 
            this.inputAccount.BorderStyle = BorderStyle.None;
            this.inputAccount.Font = new Font("微软雅黑", 10F);
            this.inputAccount.ForeColor = Color.Silver;
            this.inputAccount.Location = new Point(56, 6);
            this.inputAccount.Name = "inputAccount";
            this.inputAccount.Size = new Size(200, 18);
            this.inputAccount.Tips = "请输入手机号";
            this.inputAccount.MaxLength = 11;

            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.inputAccount);

            // 
            // panel2
            // 
            this.panel2.Location = new Point(0, 100);
            this.panel2.Margin = new Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(260, 32);
            // 
            // label4
            // 
            this.label4.BackColor = Color.FromArgb(240, 240, 240);
            this.label4.Location = new Point(0, 30);
            this.label4.Name = "label4";
            this.label4.Size = new Size(260, 2);
            this.label4.Text = "";
            // 
            // inputVerify
            // 
            this.inputVerify.BorderStyle = BorderStyle.None;
            this.inputVerify.Font = new Font("微软雅黑", 10F);
            this.inputVerify.ForeColor = Color.Silver;
            this.inputVerify.Location = new Point(10, 6);
            this.inputVerify.Name = "inputVerify";
            this.inputVerify.Size = new Size(150, 18);
            this.inputVerify.Tips = "请输入验证码";
            this.inputVerify.MaxLength = 6;
            //
            // buttonVerify
            //
            this.buttonVerify.AutoSize = false;
            this.buttonVerify.Width = 100;
            this.buttonVerify.Height = 22;
            this.buttonVerify.BackColor = ClassStatic.mainColors;
            this.buttonVerify.ForeColor = Color.White;
            this.buttonVerify.TextAlign = ContentAlignment.MiddleCenter;
            this.buttonVerify.Location = new Point(160, 5);
            this.buttonVerify.Name = "buttonVerify";
            this.buttonVerify.Text = "获取验证码";
            this.buttonVerify.Cursor = Cursors.Hand;


            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.inputVerify);
            this.panel2.Controls.Add(this.buttonVerify);

            // 
            // panel3
            // 
            this.panel3.Location = new Point(0, 146);
            this.panel3.Margin = new Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(260, 32);
            // 
            // label5
            // 
            this.label5.BackColor = Color.FromArgb(240, 240, 240);
            this.label5.Location = new Point(0, 30);
            this.label5.Name = "label5";
            this.label5.Size = new Size(260, 2);
            this.label5.Text = "";
            // 
            // inputVerify
            // 
            this.inputPassword.BorderStyle = BorderStyle.None;
            this.inputPassword.Font = new Font("微软雅黑", 10F);
            this.inputPassword.ForeColor = Color.Silver;
            this.inputPassword.Location = new Point(10, 6);
            this.inputPassword.Name = "inputPassword";
            this.inputPassword.Size = new Size(245, 18);
            this.inputPassword.Tips = "请输入修改后的密码";
            this.inputPassword.IsPassword = true;
            this.inputPassword.MaxLength = 26;


            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.inputPassword);

            //
            // buttonRegister
            //
            this.buttonRegister.Text = "确  定";
            this.buttonRegister.Cursor = Cursors.Hand;
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.ForeColor = Color.White;
            this.buttonRegister.Margin = new Padding(0);
            this.buttonRegister.Size = new Size(260, 35);
            this.buttonRegister.Location = new Point(0, 225);
            this.buttonRegister.Font = new Font("微软雅黑", 10F);
            this.buttonRegister.BackColor = Color.FromArgb(31, 158, 247);
            this.buttonRegister.TextAlign = ContentAlignment.MiddleCenter;

            //
            // labelBack
            //
            this.labelBack.Text = "— 返回登录 —";
            this.labelBack.AutoSize = false;
            this.labelBack.Width = 100;
            this.labelBack.Height = 20;
            this.labelBack.Cursor = Cursors.Hand;
            this.labelBack.Location = new Point(80, 290);
            this.labelBack.ForeColor = Color.FromArgb(211, 211, 211);
            this.labelBack.TextAlign = ContentAlignment.MiddleCenter;
            this.labelBack.Click += LabelBack_Click;

            // 
            // ControlRegister
            // 
            this.Width = 260;
            this.Height = 330;
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.labelBack);

            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void LabelBack_Click(object sender, EventArgs e)
        {
            if (FormLogin.formLogin != null)
            {
                FormLogin.formLogin.SwitchShow();
                FormLogin.formLogin.animation.Start(1);
            }
        }
    }
}
