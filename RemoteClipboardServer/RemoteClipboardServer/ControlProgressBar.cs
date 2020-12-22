using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace RemoteClipboardServer
{
    public partial class ControlProgressBar : UserControl
    {
        private int progress = 50;
        private bool isProgress = true;
        private Pen penTop = new Pen(Color.FromArgb(14, 146, 231), 5);
        private Pen penBottom = new Pen(Color.FromArgb(230, 230, 240), 5);

        public int Progress
        {
            get { return this.progress; }
            set
            {
                this.progress = value;
                this.Invalidate();
            }
        }

        public bool IsProgress
        {
            get { return this.isProgress; }
            set
            {
                this.isProgress = value;
                this.Invalidate();
            }
        }

        //解决控件批量更新时带来的闪烁
        protected override CreateParams CreateParams { get { CreateParams cp = base.CreateParams; cp.ExStyle |= 0x02000000; return cp; } }

        public ControlProgressBar()
        {
            this.Width = 70;
            this.Height = 70;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // 使绘图质量最高，即消除锯齿
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;

            e.Graphics.FillRectangle(new SolidBrush(BackColor), new Rectangle(0, 0, Width, Height));
            int size = Math.Min(Width, Height);
            Rectangle rectangle = new Rectangle(Width / 2 - size / 2 + 3, Height / 2 - size / 2 + 3, size - 6, size - 6);
            e.Graphics.DrawArc(penBottom, rectangle, 0, 360);
            if (isProgress)
            {
                decimal topAngle = (progress * 1.0M / 100) * 360M;
                e.Graphics.DrawArc(penTop, rectangle, -90, (int)topAngle);

                SizeF proValSize = e.Graphics.MeasureString(this.progress.ToString() + "%", this.Font);//计算文字的范围
                e.Graphics.DrawString(this.progress.ToString() + "%", this.Font, new SolidBrush(this.ForeColor), rectangle.X + rectangle.Width / 2 - proValSize.Width / 2, rectangle.Y + rectangle.Height / 2 - proValSize.Height / 2);
            }else
            {
                SizeF proValSize = e.Graphics.MeasureString(this.progress.ToString(), this.Font);//计算文字的范围
                e.Graphics.DrawString(this.progress.ToString(), this.Font, new SolidBrush(this.ForeColor), rectangle.X + rectangle.Width / 2 - proValSize.Width / 2, rectangle.Y + rectangle.Height / 2 - proValSize.Height / 2);
            }
        }
    }
}
