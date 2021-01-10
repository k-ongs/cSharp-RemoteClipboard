
namespace RemoteClipboard.MainForm
{
    partial class FormUnBindQQ
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUnBindQQ));
            this.controlBar1 = new RemoteClipboard.ControlBar();
            this.labelTip = new System.Windows.Forms.Label();
            this.pictureQRcode = new System.Windows.Forms.PictureBox();
            this.timerQrcode = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureQRcode)).BeginInit();
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
            this.controlBar1.Size = new System.Drawing.Size(300, 35);
            this.controlBar1.TabIndex = 0;
            this.controlBar1.Title = "QQ解绑";
            // 
            // labelTip
            // 
            this.labelTip.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.labelTip.Location = new System.Drawing.Point(13, 171);
            this.labelTip.Name = "labelTip";
            this.labelTip.Size = new System.Drawing.Size(276, 40);
            this.labelTip.TabIndex = 15;
            this.labelTip.Text = "手机QQ扫码解绑";
            this.labelTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureQRcode
            // 
            this.pictureQRcode.Image = global::RemoteClipboard.Properties.Resources.qrcode1;
            this.pictureQRcode.Location = new System.Drawing.Point(102, 64);
            this.pictureQRcode.Name = "pictureQRcode";
            this.pictureQRcode.Size = new System.Drawing.Size(98, 98);
            this.pictureQRcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureQRcode.TabIndex = 14;
            this.pictureQRcode.TabStop = false;
            this.pictureQRcode.Click += new System.EventHandler(this.pictureQRcode_Click);
            // 
            // timerQrcode
            // 
            this.timerQrcode.Interval = 2000;
            this.timerQrcode.Tick += new System.EventHandler(this.timerQrcode_Tick);
            // 
            // FormUnBindQQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(300, 220);
            this.Controls.Add(this.labelTip);
            this.Controls.Add(this.pictureQRcode);
            this.Controls.Add(this.controlBar1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(300, 220);
            this.MinimumSize = new System.Drawing.Size(300, 220);
            this.Name = "FormUnBindQQ";
            this.Text = "FormUnBindQQ";
            this.Load += new System.EventHandler(this.FormUnBindQQ_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureQRcode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlBar controlBar1;
        private System.Windows.Forms.Label labelTip;
        private System.Windows.Forms.PictureBox pictureQRcode;
        private System.Windows.Forms.Timer timerQrcode;
    }
}