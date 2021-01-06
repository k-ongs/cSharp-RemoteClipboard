
namespace RemoteClipboard.MainForm
{
    partial class FormEditPassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditPassword));
            this.controlBar1 = new RemoteClipboard.ControlBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.inputAccount = new RemoteClipboard.ControlInputBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonVerify = new System.Windows.Forms.Label();
            this.inputVerify = new RemoteClipboard.ControlInputBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.inputPassword = new RemoteClipboard.ControlInputBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Label();
            this.timerVerify = new System.Windows.Forms.Timer(this.components);
            this.labelTipShow = new System.Windows.Forms.Label();
            this.timerTipShow = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlBar1
            // 
            this.controlBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(158)))), ((int)(((byte)(247)))));
            this.controlBar1.CloseToPallet = false;
            this.controlBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlBar1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.controlBar1.ForeColor = System.Drawing.Color.White;
            this.controlBar1.HideButton = true;
            this.controlBar1.Location = new System.Drawing.Point(0, 0);
            this.controlBar1.Margin = new System.Windows.Forms.Padding(0);
            this.controlBar1.Name = "controlBar1";
            this.controlBar1.Size = new System.Drawing.Size(340, 35);
            this.controlBar1.TabIndex = 0;
            this.controlBar1.Title = "修改密码";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.inputAccount);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(40, 87);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 32);
            this.panel1.TabIndex = 29;
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
            this.panel2.Location = new System.Drawing.Point(40, 129);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 32);
            this.panel2.TabIndex = 30;
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
            this.panel3.Location = new System.Drawing.Point(40, 175);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(260, 32);
            this.panel3.TabIndex = 31;
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
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label4.Location = new System.Drawing.Point(0, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(260, 2);
            this.label4.TabIndex = 0;
            this.label4.Text = "label4";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(158)))), ((int)(((byte)(247)))));
            this.buttonSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSubmit.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.buttonSubmit.ForeColor = System.Drawing.Color.White;
            this.buttonSubmit.Location = new System.Drawing.Point(40, 226);
            this.buttonSubmit.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(90, 33);
            this.buttonSubmit.TabIndex = 32;
            this.buttonSubmit.Text = "确定";
            this.buttonSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.buttonClose.ForeColor = System.Drawing.Color.Black;
            this.buttonClose.Location = new System.Drawing.Point(210, 226);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(90, 33);
            this.buttonClose.TabIndex = 33;
            this.buttonClose.Text = "取消";
            this.buttonClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerVerify
            // 
            this.timerVerify.Interval = 1000;
            this.timerVerify.Tick += new System.EventHandler(this.TimerVerify_Tick);
            // 
            // labelTipShow
            // 
            this.labelTipShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.labelTipShow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTipShow.Location = new System.Drawing.Point(40, 45);
            this.labelTipShow.Margin = new System.Windows.Forms.Padding(0);
            this.labelTipShow.Name = "labelTipShow";
            this.labelTipShow.Padding = new System.Windows.Forms.Padding(3);
            this.labelTipShow.Size = new System.Drawing.Size(260, 30);
            this.labelTipShow.TabIndex = 34;
            this.labelTipShow.Text = "提示信息";
            this.labelTipShow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTipShow.Visible = false;
            // 
            // timerTipShow
            // 
            this.timerTipShow.Interval = 3500;
            this.timerTipShow.Tick += new System.EventHandler(this.timerTipShow_Tick);
            // 
            // FormEditPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(340, 280);
            this.Controls.Add(this.labelTipShow);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.controlBar1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(340, 280);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(340, 280);
            this.Name = "FormEditPassword";
            this.Text = "FormEditPassword";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlBar controlBar1;
        private System.Windows.Forms.Panel panel1;
        private ControlInputBox inputAccount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label buttonVerify;
        private ControlInputBox inputVerify;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private ControlInputBox inputPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label buttonSubmit;
        private System.Windows.Forms.Label buttonClose;
        private System.Windows.Forms.Timer timerVerify;
        public System.Windows.Forms.Label labelTipShow;
        private System.Windows.Forms.Timer timerTipShow;
    }
}