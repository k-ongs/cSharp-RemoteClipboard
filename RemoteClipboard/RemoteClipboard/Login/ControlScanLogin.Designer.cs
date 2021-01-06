
namespace RemoteClipboard.Login
{
    partial class ControlScanLogin
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
            this.components = new System.ComponentModel.Container();
            this.labelTip = new System.Windows.Forms.Label();
            this.pictureQRcode = new System.Windows.Forms.PictureBox();
            this.timerQrcode = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureQRcode)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTip
            // 
            this.labelTip.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.labelTip.Location = new System.Drawing.Point(0, 255);
            this.labelTip.Name = "labelTip";
            this.labelTip.Size = new System.Drawing.Size(260, 40);
            this.labelTip.TabIndex = 12;
            this.labelTip.Text = "手机QQ扫码登录";
            this.labelTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureQRcode
            // 
            this.pictureQRcode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureQRcode.Image = global::RemoteClipboard.Properties.Resources.qrcode1;
            this.pictureQRcode.Location = new System.Drawing.Point(48, 45);
            this.pictureQRcode.Name = "pictureQRcode";
            this.pictureQRcode.Size = new System.Drawing.Size(164, 164);
            this.pictureQRcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureQRcode.TabIndex = 11;
            this.pictureQRcode.TabStop = false;
            this.pictureQRcode.Click += new System.EventHandler(this.pictureQRcode_Click);
            // 
            // timerQrcode
            // 
            this.timerQrcode.Interval = 2000;
            this.timerQrcode.Tick += new System.EventHandler(this.timerQrcode_Tick);
            // 
            // ControlScanLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.labelTip);
            this.Controls.Add(this.pictureQRcode);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ControlScanLogin";
            this.Size = new System.Drawing.Size(260, 330);
            ((System.ComponentModel.ISupportInitialize)(this.pictureQRcode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureQRcode;
        private System.Windows.Forms.Label labelTip;
        public System.Windows.Forms.Timer timerQrcode;
    }
}
