
namespace RemoteClipboard
{
    partial class FormAddDevice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddDevice));
            this.controlBar1 = new RemoteClipboard.ControlBar();
            this.controlInputBoxs2 = new RemoteClipboard.ControlInputBoxs();
            this.controlInputBoxs1 = new RemoteClipboard.ControlInputBoxs();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // controlBar1
            // 
            this.controlBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(158)))), ((int)(((byte)(247)))));
            this.controlBar1.CloseToPallet = false;
            this.controlBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlBar1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.controlBar1.ForeColor = System.Drawing.Color.White;
            this.controlBar1.HideButton = false;
            this.controlBar1.Location = new System.Drawing.Point(0, 0);
            this.controlBar1.Margin = new System.Windows.Forms.Padding(0);
            this.controlBar1.Name = "controlBar1";
            this.controlBar1.Size = new System.Drawing.Size(300, 35);
            this.controlBar1.TabIndex = 0;
            this.controlBar1.Title = "添加设备";
            // 
            // controlInputBoxs2
            // 
            this.controlInputBoxs2.BackColor = System.Drawing.Color.White;
            this.controlInputBoxs2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("controlInputBoxs2.BackgroundImage")));
            this.controlInputBoxs2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.controlInputBoxs2.Location = new System.Drawing.Point(50, 108);
            this.controlInputBoxs2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.controlInputBoxs2.MaximumSize = new System.Drawing.Size(200, 30);
            this.controlInputBoxs2.MinimumSize = new System.Drawing.Size(200, 30);
            this.controlInputBoxs2.Name = "controlInputBoxs2";
            this.controlInputBoxs2.Size = new System.Drawing.Size(200, 30);
            this.controlInputBoxs2.TabIndex = 2;
            this.controlInputBoxs2.Tips = "设备密码";
            // 
            // controlInputBoxs1
            // 
            this.controlInputBoxs1.BackColor = System.Drawing.Color.White;
            this.controlInputBoxs1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("controlInputBoxs1.BackgroundImage")));
            this.controlInputBoxs1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.controlInputBoxs1.Location = new System.Drawing.Point(50, 70);
            this.controlInputBoxs1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.controlInputBoxs1.MaximumSize = new System.Drawing.Size(200, 30);
            this.controlInputBoxs1.MinimumSize = new System.Drawing.Size(200, 30);
            this.controlInputBoxs1.Name = "controlInputBoxs1";
            this.controlInputBoxs1.Size = new System.Drawing.Size(200, 30);
            this.controlInputBoxs1.TabIndex = 3;
            this.controlInputBoxs1.Tips = "IP地址";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(158)))), ((int)(((byte)(247)))));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(47, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "添加";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(162)))), ((int)(((byte)(162)))));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(160, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 30);
            this.label2.TabIndex = 5;
            this.label2.Text = "取消";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // FormAddDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(300, 220);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.controlInputBoxs1);
            this.Controls.Add(this.controlInputBoxs2);
            this.Controls.Add(this.controlBar1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 220);
            this.MinimumSize = new System.Drawing.Size(300, 220);
            this.Name = "FormAddDevice";
            this.Text = "FormAddDevice";
            this.ResumeLayout(false);

        }

        #endregion

        private ControlBar controlBar1;
        private ControlInputBoxs controlInputBoxs2;
        private ControlInputBoxs controlInputBoxs1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}