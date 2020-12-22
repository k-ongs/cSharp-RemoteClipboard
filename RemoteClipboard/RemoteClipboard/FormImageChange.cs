using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace RemoteClipboard
{
    public partial class FormImageChange : Form
    {
        #region 绘制窗体阴影
        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        private bool m_aeroEnabled;                     // variables for box shadow
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;

        public struct MARGINS                           // struct for box shadow
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        private const int WM_NCHITTEST = 0x84;          // variables for dragging the form
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();

                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }
        }

        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:                        // box shadow
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 0,
                            rightWidth = 0,
                            topHeight = 0
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }
        #endregion

        public ControlPortraitBox portrait;
        private PictureBox pictureSelect;
        private Pen pen = new Pen(Color.FromArgb(255, 31, 158, 247), 4);

        /// <summary>
        /// 构造函数
        /// </summary>
        public FormImageChange(ControlPortraitBox tempBox)
        {
            portrait = tempBox;
            InitializeComponent();
           
            for (int i = 0; i < 12; i++)
            {
                PictureBox temp = new PictureBox();
                temp.Tag = i;
                temp.BackgroundImage = (Image)ResourcePortrait.ResourceManager.GetObject("h" + Convert.ToChar(65 + i / 4)  + (i%4+1));
                temp.BackgroundImageLayout = ImageLayout.Stretch;
                temp.Size = new Size(70, 70);
                temp.SizeMode = PictureBoxSizeMode.StretchImage;
                temp.Click += new System.EventHandler(this.PictrueClick);
                flowLayoutPanel1.Controls.Add(temp);
            }
            PictrueClick(flowLayoutPanel1.Controls[portrait.Portrait], null);
        }

        /// <summary>
        /// 点击图片画选中框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictrueClick(object sender, EventArgs e)
        {
            PictureBox temp = (PictureBox)sender;
            Bitmap image = new Bitmap(temp.Width, temp.Width);

            if (pictureSelect != null)
            {
                pictureSelect.Image = (Image)image.Clone();
            }
            Graphics graphics = Graphics.FromImage(image);
            graphics.DrawRectangle(pen, 0, 0, temp.Width, temp.Width);
            graphics.Dispose();
            temp.Image = image;
            pictureSelect = temp;
        }

        /// <summary>
        /// 确定按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // 更换头像事件
            if (portrait.Portrait != (int)pictureSelect.Tag)
            {
                portrait.Portrait = (int)pictureSelect.Tag;
                ClassStaticResources.portraitPid = (int)pictureSelect.Tag;
                ClassStaticResources.SetConfig("portrait", pictureSelect.Tag.ToString());

                // 已经登录更改头像事件
                if(ClassStaticResources.password != "")
                {

                }
            }
            this.Close();
        }

        /// <summary>
        /// 关闭按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
