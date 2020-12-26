using System.Drawing;
using System.Windows.Forms;

namespace RemoteClipboard.Login
{
    /// <summary>
    /// 扫码登录界面
    /// </summary>
    public class ControlScanLogin : Control
    {
        private Label labelTips;
        private PictureBox pictureQRcode;

        public ControlScanLogin()
        {
            this.Width = 260;
            this.Height = 330;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.pictureQRcode = new PictureBox();
            this.labelTips = new Label();
            this.SuspendLayout();
            // 
            // pictureQRcode
            // 
            this.pictureQRcode.Location = new Point(48, 55);
            this.pictureQRcode.Margin = new Padding(0);
            this.pictureQRcode.Name = "pictureQRcode";
            this.pictureQRcode.Size = new Size(164, 164);
            this.pictureQRcode.TabIndex = 0;
            this.pictureQRcode.Image = Properties.Resources.qrcode;
            this.pictureQRcode.TabStop = false;
            // 
            // labelTips
            // 
            this.labelTips.Font = new Font("微软雅黑", 13F);
            this.labelTips.Location = new Point(0, 255);
            this.labelTips.Name = "labelTips";
            this.labelTips.Size = new Size(260, 40);
            this.labelTips.TabIndex = 1;
            this.labelTips.Text = "手机QQ扫码登录";
            this.labelTips.TextAlign = ContentAlignment.MiddleCenter;

            this.Controls.Add(this.labelTips);
            this.Controls.Add(this.pictureQRcode);
            this.ResumeLayout(false);
        }
    }
}
