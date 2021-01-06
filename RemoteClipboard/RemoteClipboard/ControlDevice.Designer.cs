
namespace RemoteClipboard
{
    partial class ControlDevice
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
            this.labelName = new System.Windows.Forms.Label();
            this.labelMac = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.controlStatusOnline = new RemoteClipboard.ControlStatusOnline();
            this.controlPortraitBox = new RemoteClipboard.ControlPortraitBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelName.Location = new System.Drawing.Point(80, 10);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(215, 20);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "设备名称";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelName.MouseHover += new System.EventHandler(this.ControlDevice_MouseHover);
            // 
            // labelMac
            // 
            this.labelMac.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelMac.Location = new System.Drawing.Point(80, 40);
            this.labelMac.Name = "labelMac";
            this.labelMac.Size = new System.Drawing.Size(190, 20);
            this.labelMac.TabIndex = 2;
            this.labelMac.Text = "MAC地址";
            this.labelMac.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelMac.MouseHover += new System.EventHandler(this.ControlDevice_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::RemoteClipboard.Properties.Resources.deviceType;
            this.pictureBox1.Location = new System.Drawing.Point(300, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 22);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseHover += new System.EventHandler(this.ControlDevice_MouseHover);
            // 
            // controlStatusOnline
            // 
            this.controlStatusOnline.BackColor = System.Drawing.Color.Transparent;
            this.controlStatusOnline.Cursor = System.Windows.Forms.Cursors.Hand;
            this.controlStatusOnline.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.controlStatusOnline.Location = new System.Drawing.Point(276, 42);
            this.controlStatusOnline.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.controlStatusOnline.MaximumSize = new System.Drawing.Size(54, 18);
            this.controlStatusOnline.MinimumSize = new System.Drawing.Size(54, 18);
            this.controlStatusOnline.Name = "controlStatusOnline";
            this.controlStatusOnline.Size = new System.Drawing.Size(54, 18);
            this.controlStatusOnline.Status = 0;
            this.controlStatusOnline.TabIndex = 3;
            this.controlStatusOnline.MouseHover += new System.EventHandler(this.ControlDevice_MouseHover);
            // 
            // controlPortraitBox
            // 
            this.controlPortraitBox.BackColor = System.Drawing.Color.Transparent;
            this.controlPortraitBox.Enabled = false;
            this.controlPortraitBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.controlPortraitBox.Location = new System.Drawing.Point(5, 5);
            this.controlPortraitBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.controlPortraitBox.Name = "controlPortraitBox";
            this.controlPortraitBox.Portrait = 0;
            this.controlPortraitBox.ReplaceImage = false;
            this.controlPortraitBox.Size = new System.Drawing.Size(60, 60);
            this.controlPortraitBox.TabIndex = 0;
            this.controlPortraitBox.MouseLeave += new System.EventHandler(this.ControlDevice_MouseLeave);
            this.controlPortraitBox.MouseHover += new System.EventHandler(this.ControlDevice_MouseHover);
            // 
            // ControlDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.controlStatusOnline);
            this.Controls.Add(this.labelMac);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.controlPortraitBox);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(340, 70);
            this.MinimumSize = new System.Drawing.Size(340, 70);
            this.Name = "ControlDevice";
            this.Size = new System.Drawing.Size(340, 70);
            this.MouseLeave += new System.EventHandler(this.ControlDevice_MouseLeave);
            this.MouseHover += new System.EventHandler(this.ControlDevice_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlPortraitBox controlPortraitBox;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelMac;
        private ControlStatusOnline controlStatusOnline;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
