using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 画板
{
    public partial class Form1 : Form
    {
        private Point startPoint;
        private Image canvasImage;
        private Rectangle cropBoxRectangle;
        private ArrayList cropBoxControlList = new ArrayList();

        public Form1()
        {
            InitializeComponent();

            canvasImage = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(canvasImage);
            Rectangle rectBmp = new Rectangle(0, 0, Width, Height);
            g.DrawImage(Properties.Resources.timg, rectBmp, rectBmp, GraphicsUnit.Pixel);
            g.Dispose();

            this.BackgroundImage = canvasImage;

            //SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            //SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲

            //this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            //this.UpdateStyles();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = e.Location;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if(cropBoxRectangle.Contains(e.Location))
                {
                    cropBoxRectangle.Offset(e.X - startPoint.X, e.Y - startPoint.Y);
                    //startPoint.Offset();
                    DrawCropBoxFromRectangle(cropBoxRectangle);
                    startPoint = e.Location;
                }
                else
                {
                    DrawCropBoxFromRectangle(GetRectangleFromPoint(startPoint, e.Location));
                }
                
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            cropBoxRectangle = GetRectangleFromPoint(startPoint, e.Location);
        }

        private Rectangle GetRectangleFromPoint(Point start, Point end)
        {
            int x1 = start.X < end.X ? start.X : end.X;
            int x2 = start.X > end.X ? start.X : end.X;
            int y1 = start.Y < end.Y ? start.Y : end.Y;
            int y2 = start.Y > end.Y ? start.Y : end.Y;

            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        private void DrawCropBoxFromRectangle(Rectangle rect)
        {
            RectangleF tempRect;
            // 定义一个临时图层
            Image temp = (Image)canvasImage.Clone();
            Graphics graphics = Graphics.FromImage(temp);
            // 绘制半透明层
            //graphics.FillRectangle(new SolidBrush(Color.FromArgb(70, Color.Black)), new Rectangle(0, 0, temp.Width, temp.Height));
            // 绘制高亮区域
            graphics.DrawImage(canvasImage, rect, rect, GraphicsUnit.Pixel);
            // 绘制裁剪框
            graphics.DrawRectangle(new Pen(Color.FromArgb(0, 174, 255), 1), rect);

            cropBoxControlList.Clear();
            
            // 绘制裁剪框的八个控制点
            for(int i=0; i<3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(i==1 && j==1) continue;
                    tempRect = new RectangleF((rect.X - 2) + rect.Width * (i / 2F), (rect.Y - 2) + rect.Height * (j / 2F), 5, 5);
                    cropBoxControlList.Add(tempRect);
                    graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 174, 255)), tempRect);
                }
            }

            graphics.Dispose();
            graphics = this.CreateGraphics();
            graphics.DrawImage(temp, new Point(0, 0));
            graphics.Dispose();
            temp.Dispose();
        }
    }
}
