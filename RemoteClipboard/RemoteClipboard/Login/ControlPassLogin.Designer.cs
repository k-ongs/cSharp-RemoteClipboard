
namespace RemoteClipboard.Login
{
    partial class ControlPassLogin
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.inputAccount = new RemoteClipboard.ControlInputBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.inputPassword = new RemoteClipboard.ControlInputBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxRemember = new System.Windows.Forms.CheckBox();
            this.buttonForget = new System.Windows.Forms.Label();
            this.buttonRegister = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.controlPortraitBox = new RemoteClipboard.ControlPortraitBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.inputAccount);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 170);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 32);
            this.panel1.TabIndex = 16;
            // 
            // inputAccount
            // 
            this.inputAccount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputAccount.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.inputAccount.ForeColor = System.Drawing.Color.LightGray;
            this.inputAccount.IsPassword = false;
            this.inputAccount.Location = new System.Drawing.Point(48, 6);
            this.inputAccount.MaxLength = 11;
            this.inputAccount.Name = "inputAccount";
            this.inputAccount.Size = new System.Drawing.Size(208, 18);
            this.inputAccount.TabIndex = 3;
            this.inputAccount.Tips = "";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "账号";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label2.Location = new System.Drawing.Point(40, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(2, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label1.Location = new System.Drawing.Point(0, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 2);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.inputPassword);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(0, 218);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 32);
            this.panel2.TabIndex = 17;
            // 
            // inputPassword
            // 
            this.inputPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputPassword.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.inputPassword.ForeColor = System.Drawing.Color.LightGray;
            this.inputPassword.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.inputPassword.IsPassword = true;
            this.inputPassword.Location = new System.Drawing.Point(48, 6);
            this.inputPassword.MaxLength = 26;
            this.inputPassword.Name = "inputPassword";
            this.inputPassword.Size = new System.Drawing.Size(208, 18);
            this.inputPassword.TabIndex = 3;
            this.inputPassword.Tips = "";
            this.inputPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlPassLogin_KeyDown);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 30);
            this.label4.TabIndex = 2;
            this.label4.Text = "密码";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label5.Location = new System.Drawing.Point(40, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(2, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label6.Location = new System.Drawing.Point(0, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(260, 2);
            this.label6.TabIndex = 0;
            this.label6.Text = "label6";
            // 
            // checkBoxRemember
            // 
            this.checkBoxRemember.AutoSize = true;
            this.checkBoxRemember.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.checkBoxRemember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxRemember.ForeColor = System.Drawing.Color.Silver;
            this.checkBoxRemember.Location = new System.Drawing.Point(0, 259);
            this.checkBoxRemember.Name = "checkBoxRemember";
            this.checkBoxRemember.Size = new System.Drawing.Size(72, 21);
            this.checkBoxRemember.TabIndex = 18;
            this.checkBoxRemember.Text = "记住密码";
            this.checkBoxRemember.UseVisualStyleBackColor = true;
            // 
            // buttonForget
            // 
            this.buttonForget.AutoSize = true;
            this.buttonForget.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonForget.ForeColor = System.Drawing.Color.Silver;
            this.buttonForget.Location = new System.Drawing.Point(142, 261);
            this.buttonForget.Name = "buttonForget";
            this.buttonForget.Size = new System.Drawing.Size(56, 17);
            this.buttonForget.TabIndex = 19;
            this.buttonForget.Text = "找回密码";
            this.buttonForget.Click += new System.EventHandler(this.buttonForget_Click);
            // 
            // buttonRegister
            // 
            this.buttonRegister.AutoSize = true;
            this.buttonRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRegister.ForeColor = System.Drawing.Color.Silver;
            this.buttonRegister.Location = new System.Drawing.Point(204, 261);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(56, 17);
            this.buttonRegister.TabIndex = 20;
            this.buttonRegister.Text = "用户注册";
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label7.Location = new System.Drawing.Point(199, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(2, 14);
            this.label7.TabIndex = 4;
            this.label7.Text = "label7";
            // 
            // labelLogin
            // 
            this.labelLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(158)))), ((int)(((byte)(247)))));
            this.labelLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelLogin.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labelLogin.ForeColor = System.Drawing.Color.White;
            this.labelLogin.Location = new System.Drawing.Point(0, 295);
            this.labelLogin.Margin = new System.Windows.Forms.Padding(0);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(260, 35);
            this.labelLogin.TabIndex = 21;
            this.labelLogin.Text = "登  录";
            this.labelLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelLogin.Click += new System.EventHandler(this.labelLogin_Click);
            // 
            // controlPortraitBox
            // 
            this.controlPortraitBox.BackColor = System.Drawing.Color.Transparent;
            this.controlPortraitBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.controlPortraitBox.Location = new System.Drawing.Point(77, 40);
            this.controlPortraitBox.Margin = new System.Windows.Forms.Padding(0);
            this.controlPortraitBox.Name = "controlPortraitBox";
            this.controlPortraitBox.Portrait = 0;
            this.controlPortraitBox.ReplaceImage = false;
            this.controlPortraitBox.Size = new System.Drawing.Size(106, 106);
            this.controlPortraitBox.TabIndex = 15;
            // 
            // ControlPassLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.buttonForget);
            this.Controls.Add(this.checkBoxRemember);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.controlPortraitBox);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ControlPassLogin";
            this.Size = new System.Drawing.Size(260, 330);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ControlPortraitBox controlPortraitBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private ControlInputBox inputPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxRemember;
        private System.Windows.Forms.Label buttonForget;
        private System.Windows.Forms.Label buttonRegister;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelLogin;
        private ControlInputBox inputAccount;
    }
}
