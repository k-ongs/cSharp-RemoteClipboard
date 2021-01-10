using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteClipboard
{
    public partial class FormColorSelection : Form
    {
        private int pattern = 1;
        Rectangle desktopRectangle;
        public FormColorSelection()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Opaque, false);
            this.UpdateStyles();

            desktopRectangle = new Rectangle(0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Image canvasImage = new Bitmap(desktopRectangle.Width, desktopRectangle.Height);
            // 将图片绘制到画板
            Graphics graphics = Graphics.FromImage(canvasImage);
            // 获取截图
            graphics.CopyFromScreen(new Point(0, 0), new Point(0, 0), desktopRectangle.Size, CopyPixelOperation.SourceCopy);
            graphics.Dispose();
            // 将图片保存到背景图片
            this.BackgroundImage = canvasImage;
            SetCursor(Properties.Resources.CursorColor, new Point(0, 0));
        }

        public void SetCursor(Bitmap cursor, Point hotPoint)
        {
            int hotX = hotPoint.X;
            int hotY = hotPoint.Y;
            Bitmap myNewCursor = new Bitmap(cursor.Width * 2 - hotX, cursor.Height * 2 - hotY);
            Graphics g = Graphics.FromImage(myNewCursor);
            g.Clear(Color.FromArgb(0, 0, 0, 0));
            g.DrawImage(cursor, cursor.Width - hotX, cursor.Height - hotY, cursor.Width,
            cursor.Height);

            this.Cursor = new Cursor(myNewCursor.GetHicon());

            g.Dispose();
            myNewCursor.Dispose();
        }

        private void FormColorSelection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void FormColorSelection_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics graphics = pictureBox.CreateGraphics();
            int picw = pictureBox.Width;
            int pich = pictureBox.Height;

            Point temp = new Point(e.X + 40, e.Y + 40);

            if (temp.Y + 80 > desktopRectangle.Height)
            {
                temp.Y -= 120;
            }
            if (temp.X + 100 > desktopRectangle.Width)
            {
                temp.X -= 140;
            }

            pictureBox.Location = temp;
            Rectangle destRect = new Rectangle(0, 0, picw, pich);
            Rectangle srcRect = new Rectangle(e.X - 10, e.Y + 10, picw / 4, pich / 4);

            graphics.DrawImage(BackgroundImage, destRect, srcRect, GraphicsUnit.Pixel);
            graphics.DrawRectangle(new Pen(Color.Black, 1), 0, 0, picw - 1, pich - 1);
            graphics.DrawLine(new Pen(Color.FromArgb(31, 158, 247), 1), picw / 2, 0, picw / 2, pich);
            graphics.DrawLine(new Pen(Color.FromArgb(31, 158, 247), 1), 0, pich / 2, picw, pich / 2);
            graphics.Dispose();
        }

        /// <summary>
        /// 将rgb类型的颜色转换为hsb
        /// </summary>
        /// <param name="rgb"></param>
        /// <returns></returns>
        public static string Rgb2Hsb(Color rgb)
        {
            int r = rgb.R;
            int g = rgb.G;
            int b = rgb.B;

            int h;

            int max = Math.Max(r, Math.Max(g, b));

            if (max <= 0)
            {
                return "";
            }
            int min = Math.Min(r, Math.Min(g, b));
            int dif = max - min;

            if (max > min)
            {
                if (g == max)
                {
                    h = (b - r) / dif * 60 + 120;
                }
                else if (b == max)
                {
                    h = (r - g) / dif * 60 + 240;
                }
                else if (b > g)
                {
                    h = (g - b) / dif * 60 + 360;
                }
                else
                {
                    h = (g - b) / dif * 60;
                }
                if (h < 0)
                {
                    h = h + 360;
                }
            }
            else
            {
                h = 0;
            }
            int hs = dif / max;
            int hb = max / 255;
            return "HSB(" + h + ", " + hs + ", " + hb + ")";
        }

        private void FormColorSelection_MouseClick(object sender, MouseEventArgs e)
        {
            Bitmap bmp = new Bitmap(BackgroundImage);

            Color color = bmp.GetPixel(e.X, e.Y);
            string msg = "";
            if (pattern == 1)
            {
                msg = "(" + color.R + "," + color.G + "," + color.B + ")";
            }
            else if (pattern == 2)
            {
                msg = Rgb2Hsb(color);
            }
            else
            {
                msg = ColorTranslator.ToHtml(color);
            }

            Clipboard.SetText(msg);
            this.Close();
        }

        private void getRGBItem_Click(object sender, EventArgs e)
        {
            pattern = 1;
            getRGBItem.Checked = true;
            getHSBItem.Checked = false;
            getHexItem.Checked = false;
        }

        private void getHSBItem_Click(object sender, EventArgs e)
        {
            pattern = 2;
            getRGBItem.Checked = false;
            getHSBItem.Checked = true;
            getHexItem.Checked = false;
        }

        private void getHexItem_Click(object sender, EventArgs e)
        {
            pattern = 3;
            getRGBItem.Checked = false;
            getHSBItem.Checked = false;
            getHexItem.Checked = true;
        }

        private void toolStripMenuItemClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
