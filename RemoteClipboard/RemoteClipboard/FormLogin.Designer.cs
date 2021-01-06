
namespace RemoteClipboard
{
    partial class FormLogin
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.labelScan = new System.Windows.Forms.Label();
            this.labelPass = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelShow = new System.Windows.Forms.Panel();
            this.controlPassLogin = new RemoteClipboard.Login.ControlPassLogin();
            this.controlScanLogin = new RemoteClipboard.Login.ControlScanLogin();
            this.panelLoginShow = new System.Windows.Forms.Panel();
            this.controlForgetPass = new RemoteClipboard.Login.ControlForgetPass();
            this.controlRegister = new RemoteClipboard.Login.ControlRegister();
            this.timerLabelSwitch = new System.Windows.Forms.Timer(this.components);
            this.timerControlRegister = new System.Windows.Forms.Timer(this.components);
            this.timerControlForgetPass = new System.Windows.Forms.Timer(this.components);
            this.timerNetwork = new System.Windows.Forms.Timer(this.components);
            this.labelTipShow = new System.Windows.Forms.Label();
            this.timerTipShow = new System.Windows.Forms.Timer(this.components);
            this.controlBar1 = new RemoteClipboard.ControlBar();
            this.timerControlLoading = new System.Windows.Forms.Timer(this.components);
            this.userControlLoading = new RemoteClipboard.Login.UserControlLoading();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelShow.SuspendLayout();
            this.panelLoginShow.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelScan
            // 
            this.labelScan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelScan.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.labelScan.Location = new System.Drawing.Point(0, 0);
            this.labelScan.Margin = new System.Windows.Forms.Padding(0);
            this.labelScan.Name = "labelScan";
            this.labelScan.Size = new System.Drawing.Size(130, 30);
            this.labelScan.TabIndex = 11;
            this.labelScan.Text = "扫码登录";
            this.labelScan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelScan.Click += new System.EventHandler(this.labelSwitch_Click);
            this.labelScan.Paint += new System.Windows.Forms.PaintEventHandler(this.labelSwitch_Paint);
            // 
            // labelPass
            // 
            this.labelPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelPass.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.labelPass.Location = new System.Drawing.Point(130, 0);
            this.labelPass.Margin = new System.Windows.Forms.Padding(0);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(130, 30);
            this.labelPass.TabIndex = 12;
            this.labelPass.Text = "密码登录";
            this.labelPass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPass.Click += new System.EventHandler(this.labelSwitch_Click);
            this.labelPass.Paint += new System.Windows.Forms.PaintEventHandler(this.labelSwitch_Paint);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labelScan);
            this.flowLayoutPanel1.Controls.Add(this.labelPass);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 10);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(260, 30);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // panelShow
            // 
            this.panelShow.Controls.Add(this.controlPassLogin);
            this.panelShow.Controls.Add(this.controlScanLogin);
            this.panelShow.Location = new System.Drawing.Point(0, 40);
            this.panelShow.Margin = new System.Windows.Forms.Padding(0);
            this.panelShow.Name = "panelShow";
            this.panelShow.Size = new System.Drawing.Size(260, 330);
            this.panelShow.TabIndex = 14;
            // 
            // controlPassLogin
            // 
            this.controlPassLogin.BackColor = System.Drawing.Color.White;
            this.controlPassLogin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.controlPassLogin.ForeColor = System.Drawing.Color.Black;
            this.controlPassLogin.Location = new System.Drawing.Point(0, 0);
            this.controlPassLogin.Margin = new System.Windows.Forms.Padding(0);
            this.controlPassLogin.Name = "controlPassLogin";
            this.controlPassLogin.Size = new System.Drawing.Size(260, 330);
            this.controlPassLogin.TabIndex = 1;
            // 
            // controlScanLogin
            // 
            this.controlScanLogin.BackColor = System.Drawing.Color.White;
            this.controlScanLogin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.controlScanLogin.ForeColor = System.Drawing.Color.Black;
            this.controlScanLogin.Location = new System.Drawing.Point(-260, 0);
            this.controlScanLogin.Margin = new System.Windows.Forms.Padding(0);
            this.controlScanLogin.Name = "controlScanLogin";
            this.controlScanLogin.Size = new System.Drawing.Size(260, 330);
            this.controlScanLogin.TabIndex = 0;
            // 
            // panelLoginShow
            // 
            this.panelLoginShow.Controls.Add(this.userControlLoading);
            this.panelLoginShow.Controls.Add(this.controlForgetPass);
            this.panelLoginShow.Controls.Add(this.controlRegister);
            this.panelLoginShow.Controls.Add(this.panelShow);
            this.panelLoginShow.Controls.Add(this.flowLayoutPanel1);
            this.panelLoginShow.Location = new System.Drawing.Point(30, 45);
            this.panelLoginShow.Name = "panelLoginShow";
            this.panelLoginShow.Size = new System.Drawing.Size(260, 370);
            this.panelLoginShow.TabIndex = 15;
            // 
            // controlForgetPass
            // 
            this.controlForgetPass.BackColor = System.Drawing.Color.White;
            this.controlForgetPass.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.controlForgetPass.ForeColor = System.Drawing.Color.Black;
            this.controlForgetPass.Location = new System.Drawing.Point(260, 0);
            this.controlForgetPass.Margin = new System.Windows.Forms.Padding(0);
            this.controlForgetPass.Name = "controlForgetPass";
            this.controlForgetPass.Size = new System.Drawing.Size(260, 370);
            this.controlForgetPass.TabIndex = 16;
            // 
            // controlRegister
            // 
            this.controlRegister.BackColor = System.Drawing.Color.White;
            this.controlRegister.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.controlRegister.ForeColor = System.Drawing.Color.Black;
            this.controlRegister.Location = new System.Drawing.Point(260, 0);
            this.controlRegister.Margin = new System.Windows.Forms.Padding(0);
            this.controlRegister.Name = "controlRegister";
            this.controlRegister.Size = new System.Drawing.Size(260, 370);
            this.controlRegister.TabIndex = 15;
            // 
            // timerLabelSwitch
            // 
            this.timerLabelSwitch.Interval = 10;
            this.timerLabelSwitch.Tick += new System.EventHandler(this.timerLabelSwitch_Tick);
            // 
            // timerControlRegister
            // 
            this.timerControlRegister.Interval = 10;
            this.timerControlRegister.Tick += new System.EventHandler(this.TimerControlRegister_Tick);
            // 
            // timerControlForgetPass
            // 
            this.timerControlForgetPass.Interval = 10;
            this.timerControlForgetPass.Tick += new System.EventHandler(this.TimerControlForgetPass_Tick);
            // 
            // timerNetwork
            // 
            this.timerNetwork.Enabled = true;
            this.timerNetwork.Interval = 10000;
            this.timerNetwork.Tick += new System.EventHandler(this.timerNetwork_Tick);
            // 
            // labelTipShow
            // 
            this.labelTipShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.labelTipShow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTipShow.Location = new System.Drawing.Point(30, 45);
            this.labelTipShow.Margin = new System.Windows.Forms.Padding(0);
            this.labelTipShow.Name = "labelTipShow";
            this.labelTipShow.Padding = new System.Windows.Forms.Padding(3);
            this.labelTipShow.Size = new System.Drawing.Size(260, 40);
            this.labelTipShow.TabIndex = 16;
            this.labelTipShow.Text = "提示信息";
            this.labelTipShow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTipShow.Visible = false;
            // 
            // timerTipShow
            // 
            this.timerTipShow.Interval = 3500;
            this.timerTipShow.Tick += new System.EventHandler(this.timerTipShow_Tick);
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
            this.controlBar1.Size = new System.Drawing.Size(320, 35);
            this.controlBar1.TabIndex = 8;
            this.controlBar1.Title = "远程剪贴板";
            // 
            // timerControlLoading
            // 
            this.timerControlLoading.Interval = 10;
            this.timerControlLoading.Tick += new System.EventHandler(this.timerControlLoading_Tick);
            // 
            // userControlLoading
            // 
            this.userControlLoading.BackColor = System.Drawing.Color.White;
            this.userControlLoading.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userControlLoading.Location = new System.Drawing.Point(260, 0);
            this.userControlLoading.Margin = new System.Windows.Forms.Padding(0);
            this.userControlLoading.Name = "userControlLoading";
            this.userControlLoading.Size = new System.Drawing.Size(260, 370);
            this.userControlLoading.TabIndex = 17;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(320, 440);
            this.Controls.Add(this.labelTipShow);
            this.Controls.Add(this.controlBar1);
            this.Controls.Add(this.panelLoginShow);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(320, 440);
            this.MinimumSize = new System.Drawing.Size(320, 440);
            this.Name = "FormLogin";
            this.Text = " ";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panelShow.ResumeLayout(false);
            this.panelLoginShow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ControlBar controlBar1;
        private System.Windows.Forms.Label labelScan;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelShow;
        private System.Windows.Forms.Panel panelLoginShow;
        private Login.ControlScanLogin controlScanLogin;
        private Login.ControlPassLogin controlPassLogin;
        private System.Windows.Forms.Timer timerLabelSwitch;
        private Login.ControlRegister controlRegister;
        private Login.ControlForgetPass controlForgetPass;
        public System.Windows.Forms.Timer timerControlRegister;
        public System.Windows.Forms.Timer timerControlForgetPass;
        private System.Windows.Forms.Timer timerNetwork;
        public System.Windows.Forms.Label labelTipShow;
        private System.Windows.Forms.Timer timerTipShow;
        public System.Windows.Forms.Timer timerControlLoading;
        private Login.UserControlLoading userControlLoading;
    }
}

