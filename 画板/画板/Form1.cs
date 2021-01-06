﻿using System;
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
        private int cropBoxControl = 0;
        private Rectangle cropBoxRectangle;
        private List<RectangleF> cropBoxControlList = new List<RectangleF>();

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
                if (cropBoxControl != 0)
                {
                    switch(cropBoxControl)
                    {
                        case 1:
                            cropBoxRectangle.Y += e.Y - startPoint.Y;
                            cropBoxRectangle.X += e.X - startPoint.X;
                            cropBoxRectangle.Width += startPoint.X - e.X;
                            cropBoxRectangle.Height += startPoint.Y - e.Y;
                            break;
                        case 2:
                            cropBoxRectangle.X += e.X - startPoint.X;
                            cropBoxRectangle.Width += startPoint.X - e.X;
                            break;
                        case 3:
                            cropBoxRectangle.X += e.X - startPoint.X;
                            cropBoxRectangle.Width += startPoint.X - e.X;
                            cropBoxRectangle.Height += e.Y - startPoint.Y;
                            break;
                        case 4:
                            cropBoxRectangle.Height += startPoint.Y - e.Y;
                            cropBoxRectangle.Y += e.Y - startPoint.Y;
                            break;
                        case 5:
                            cropBoxRectangle.Height += e.Y - startPoint.Y;
                            break;
                        case 6:
                            cropBoxRectangle.Width += e.X - startPoint.X;
                            cropBoxRectangle.Height += startPoint.Y - e.Y;
                            cropBoxRectangle.Y += e.Y - startPoint.Y;
                            break;
                        case 7:
                            cropBoxRectangle.Width += e.X - startPoint.X;
                            break;
                        case 8:
                            cropBoxRectangle.Width += e.X - startPoint.X;
                            cropBoxRectangle.Height += e.Y - startPoint.Y;
                            break;
                    }
                    DrawCropBoxFromRectangle(GetRectangleFromSize(cropBoxRectangle.Location, cropBoxRectangle.Size));
                    startPoint = e.Location;
                }
                else
                {
                    if (cropBoxRectangle.Contains(startPoint))
                    {
                        Cursor = Cursors.SizeAll;
                        cropBoxRectangle.Offset(e.X - startPoint.X, e.Y - startPoint.Y);
                        DrawCropBoxFromRectangle(cropBoxRectangle);
                        startPoint = e.Location;
                    }
                    else
                    {
                        DrawCropBoxFromRectangle(GetRectangleFromPoint(startPoint, e.Location));
                    }
                }
            }
            else
            {
                cropBoxControl = InCropBoxControlBox(e.Location);
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if(cropBoxControl != 0)
            {
                cropBoxRectangle = GetRectangleFromSize(cropBoxRectangle.Location, cropBoxRectangle.Size);
            }
            else
            {
                if (!cropBoxRectangle.Contains(startPoint))
                {
                    cropBoxRectangle = GetRectangleFromPoint(startPoint, e.Location);
                }
            }
            Cursor = Cursors.Default;
        }
        private Rectangle GetRectangleFromPoint(Point start, Point end)
        {
            int x1 = start.X < end.X ? start.X : end.X;
            int x2 = start.X > end.X ? start.X : end.X;
            int y1 = start.Y < end.Y ? start.Y : end.Y;
            int y2 = start.Y > end.Y ? start.Y : end.Y;

            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        private Rectangle GetRectangleFromSize(Point point, Size size)
        {
            int x1 = size.Width > 0 ? point.X : point.X + size.Width;
            int y1 = size.Height > 0 ? point.Y : point.Y + size.Height;
            int x2 = size.Width > 0 ? point.X + size.Width : point.X;
            int y2 = size.Height > 0 ? point.Y + size.Height : point.Y;

            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        private void DrawCropBoxFromRectangle(Rectangle rect)
        {
            RectangleF tempRect;
            // 定义一个临时图层
            Image temp = (Image)canvasImage.Clone();
            Graphics graphics = Graphics.FromImage(temp);
            // 绘制半透明层
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(70, Color.Black)), new Rectangle(0, 0, temp.Width, temp.Height));
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


        private int InCropBoxControlBox(Point point)
        {
            int i = 0;
            foreach(RectangleF rectangle in cropBoxControlList)
            {
                i++;
                if (rectangle.Contains(point))
                {
                    return i;
                }
            }
            return 0;
        }
    }
}
