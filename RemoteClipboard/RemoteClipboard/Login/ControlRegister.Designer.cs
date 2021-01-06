
namespace RemoteClipboard.Login
{
    partial class ControlRegister
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonVerify = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonRegister = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.inputPassword = new RemoteClipboard.ControlInputBox();
            this.inputVerify = new RemoteClipboard.ControlInputBox();
            this.inputAccount = new RemoteClipboard.ControlInputBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.labelTitle.Location = new System.Drawing.Point(4, 46);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(82, 24);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "注册账号";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.inputAccount);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 98);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 32);
            this.panel1.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "+86";
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
            this.panel2.Controls.Add(this.buttonVerify);
            this.panel2.Controls.Add(this.inputVerify);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(0, 140);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 32);
            this.panel2.TabIndex = 18;
            // 
            // buttonVerify
            // 
            this.buttonVerify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(158)))), ((int)(((byte)(247)))));
            this.buttonVerify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonVerify.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.buttonVerify.ForeColor = System.Drawing.Color.White;
            this.buttonVerify.Location = new System.Drawing.Point(160, 0);
            this.buttonVerify.Margin = new System.Windows.Forms.Padding(0);
            this.buttonVerify.Name = "buttonVerify";
            this.buttonVerify.Size = new System.Drawing.Size(100, 30);
            this.buttonVerify.TabIndex = 3;
            this.buttonVerify.Text = "获取验证码";
            this.buttonVerify.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonVerify.Click += new System.EventHandler(this.buttonVerify_Click);
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
            // panel3
            // 
            this.panel3.Controls.Add(this.inputPassword);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(0, 186);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(260, 32);
            this.panel3.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label4.Location = new System.Drawing.Point(0, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(260, 2);
            this.label4.TabIndex = 0;
            this.label4.Text = "label4";
            // 
            // buttonRegister
            // 
            this.buttonRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(158)))), ((int)(((byte)(247)))));
            this.buttonRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRegister.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.buttonRegister.ForeColor = System.Drawing.Color.White;
            this.buttonRegister.Location = new System.Drawing.Point(0, 265);
            this.buttonRegister.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(260, 35);
            this.buttonRegister.TabIndex = 5;
            this.buttonRegister.Text = "注  册";
            this.buttonRegister.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // label5
            // 
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(80, 330);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "— 返回登录 —";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // inputPassword
            // 
            this.inputPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputPassword.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.inputPassword.ForeColor = System.Drawing.Color.LightGray;
            this.inputPassword.IsPassword = true;
            this.inputPassword.Location = new System.Drawing.Point(6, 6);
            this.inputPassword.MaxLength = 26;
            this.inputPassword.Name = "inputPassword";
            this.inputPassword.Size = new System.Drawing.Size(245, 18);
            this.inputPassword.TabIndex = 4;
            this.inputPassword.Tips = "";
            // 
            // inputVerify
            // 
            this.inputVerify.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputVerify.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.inputVerify.ForeColor = System.Drawing.Color.LightGray;
            this.inputVerify.IsPassword = false;
            this.inputVerify.Location = new System.Drawing.Point(6, 6);
            this.inputVerify.MaxLength = 6;
            this.inputVerify.Name = "inputVerify";
            this.inputVerify.Size = new System.Drawing.Size(150, 18);
            this.inputVerify.TabIndex = 2;
            this.inputVerify.Tips = "";
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
            this.inputAccount.TabIndex = 1;
            this.inputAccount.Tips = "";
            // 
            // ControlRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelTitle);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ControlRegister";
            this.Size = new System.Drawing.Size(260, 370);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panel1;
        private ControlInputBox inputAccount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private ControlInputBox inputVerify;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private ControlInputBox inputPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label buttonRegister;
        private System.Windows.Forms.Label buttonVerify;
        private System.Windows.Forms.Label label5;
    }
}
