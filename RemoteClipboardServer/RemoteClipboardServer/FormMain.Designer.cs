
namespace RemoteClipboardServer
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.controlBar1 = new RemoteClipboardServer.ControlBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.controlProgressBar1 = new RemoteClipboardServer.ControlProgressBar();
            this.controlProgressBar2 = new RemoteClipboardServer.ControlProgressBar();
            this.controlProgressBar3 = new RemoteClipboardServer.ControlProgressBar();
            this.controlProgressBar4 = new RemoteClipboardServer.ControlProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
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
            this.controlBar1.Size = new System.Drawing.Size(400, 35);
            this.controlBar1.TabIndex = 0;
            this.controlBar1.Title = "远程剪贴板-服务端";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(19, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "用户总数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(112, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "在线用户数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(215, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "CPU使用率";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(312, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "内存使用率";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(5, 173);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 103);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "调试信息";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.Location = new System.Drawing.Point(9, 20);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(376, 76);
            this.textBox1.TabIndex = 0;
            this.textBox1.TabStop = false;
            // 
            // controlProgressBar1
            // 
            this.controlProgressBar1.IsProgress = false;
            this.controlProgressBar1.Location = new System.Drawing.Point(15, 60);
            this.controlProgressBar1.Name = "controlProgressBar1";
            this.controlProgressBar1.Progress = 500;
            this.controlProgressBar1.Size = new System.Drawing.Size(70, 70);
            this.controlProgressBar1.TabIndex = 10;
            // 
            // controlProgressBar2
            // 
            this.controlProgressBar2.IsProgress = false;
            this.controlProgressBar2.Location = new System.Drawing.Point(115, 60);
            this.controlProgressBar2.Name = "controlProgressBar2";
            this.controlProgressBar2.Progress = 50;
            this.controlProgressBar2.Size = new System.Drawing.Size(70, 70);
            this.controlProgressBar2.TabIndex = 11;
            // 
            // controlProgressBar3
            // 
            this.controlProgressBar3.IsProgress = true;
            this.controlProgressBar3.Location = new System.Drawing.Point(215, 60);
            this.controlProgressBar3.Name = "controlProgressBar3";
            this.controlProgressBar3.Progress = 25;
            this.controlProgressBar3.Size = new System.Drawing.Size(70, 70);
            this.controlProgressBar3.TabIndex = 12;
            // 
            // controlProgressBar4
            // 
            this.controlProgressBar4.IsProgress = true;
            this.controlProgressBar4.Location = new System.Drawing.Point(315, 60);
            this.controlProgressBar4.Name = "controlProgressBar4";
            this.controlProgressBar4.Progress = 50;
            this.controlProgressBar4.Size = new System.Drawing.Size(70, 70);
            this.controlProgressBar4.TabIndex = 13;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 280);
            this.Controls.Add(this.controlProgressBar4);
            this.Controls.Add(this.controlProgressBar3);
            this.Controls.Add(this.controlProgressBar2);
            this.Controls.Add(this.controlProgressBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.controlBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 280);
            this.MinimumSize = new System.Drawing.Size(400, 280);
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlBar controlBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private ControlProgressBar controlProgressBar1;
        private ControlProgressBar controlProgressBar2;
        private ControlProgressBar controlProgressBar3;
        private ControlProgressBar controlProgressBar4;
        private System.Windows.Forms.Timer timer1;
    }
}

