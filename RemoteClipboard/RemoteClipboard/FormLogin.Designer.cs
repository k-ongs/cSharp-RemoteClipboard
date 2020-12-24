
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.labelTips = new System.Windows.Forms.Label();
            this.labelScan = new System.Windows.Forms.Label();
            this.labelPass = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.controlBar1 = new RemoteClipboard.ControlBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTips
            // 
            this.labelTips.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.labelTips.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.labelTips.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTips.Location = new System.Drawing.Point(30, 45);
            this.labelTips.Margin = new System.Windows.Forms.Padding(0);
            this.labelTips.Name = "labelTips";
            this.labelTips.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.labelTips.Size = new System.Drawing.Size(260, 40);
            this.labelTips.TabIndex = 9;
            this.labelTips.Text = "您的网络异常，请先检查网络。";
            this.labelTips.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTips.Visible = false;
            // 
            // labelScan
            // 
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(30, 55);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(260, 30);
            this.flowLayoutPanel1.TabIndex = 13;
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
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(30, 85);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 330);
            this.panel1.TabIndex = 14;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(320, 440);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelTips);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.controlBar1);
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
            this.ResumeLayout(false);

        }

        #endregion
        private ControlBar controlBar1;
        private System.Windows.Forms.Label labelTips;
        private System.Windows.Forms.Label labelScan;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
    }
}

