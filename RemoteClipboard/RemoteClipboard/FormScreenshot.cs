using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace RemoteClipboard
{
    public partial class FormScreenshot : Form
    {
        /// <summary>
        /// 最大宽度
        /// </summary>
        private int width;
        /// <summary>
        /// 最大高度
        /// </summary>
        private int height;
        /// <summary>
        /// 移动起始坐标
        /// </summary>
        private Point startPoint;
        /// <summary>
        /// 是否开启绘制
        /// </summary>
        private bool draw = false;
        /// <summary>
        /// 画板
        /// </summary>
        private Image canvasImage;
        /// <summary>
        /// 当前鼠标在哪一个裁剪框控制点
        /// </summary>
        private int cropBoxControl = 0;
        private bool cropBoxRectangleMove = false;
        /// <summary>
        /// 裁剪框
        /// </summary>
        private Rectangle cropBoxRectangle = new Rectangle();
        /// <summary>
        /// 裁剪框控制点
        /// </summary>
        private List<RectangleF> cropBoxControlList = new List<RectangleF>();

        /// <summary>
        /// 画笔大小
        /// </summary>
        private PictureBox colorPonitActive = null;
        /// <summary>
        /// 画笔形状
        /// </summary>
        private PictureBox toolbarPanelActive = null;
        /// <summary>
        /// 绘制任务列表
        /// </summary>
        private List<DrawShape> drawShapeList = new List<DrawShape>();

        /// <summary>
        /// 裁剪框的最小范围
        /// </summary>
        private Point minCropPoint;
        private Point maxCropPoint;

        /// <summary>
        /// 画的线
        /// </summary>
        DrawShape DrawShapeBrushTemp;

        class DrawShape
        {
            public int size;
            public Color color;
            public string type;
            public Rectangle rect;
            public List<Point> point = new List<Point>();
            public DrawShape(string type, Rectangle rect, Color color, int size)
            {
                this.size = size;
                this.type = type;
                this.rect = rect;
                this.color = color;
            }
        }

        public FormScreenshot()
        {
            InitializeComponent();
            Rectangle desktopRectangle = new Rectangle(0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            width = desktopRectangle.Width; height = desktopRectangle.Height;
            // 初始化画板
            canvasImage = new Bitmap(width, height);
            // 将图片绘制到画板
            Graphics graphics = Graphics.FromImage(canvasImage);
            minCropPoint = new Point(0, 0);
            maxCropPoint = new Point(width, height);
            // 获取截图
            graphics.CopyFromScreen(new Point(0, 0), new Point(0, 0), desktopRectangle.Size, CopyPixelOperation.SourceCopy);
            graphics.Dispose();
            // 将图片保存到背景图片
            this.BackgroundImage = canvasImage;
        }


        /// <summary>
        /// 绘制画板初始化
        /// </summary>
        private void DrawInitialization()
        {
            int y2 = 0;
            int x1 = cropBoxRectangle.X, y1 = cropBoxRectangle.Y;
            if (cropBoxRectangle.Y + cropBoxRectangle.Height + 90 < height)
            {
                y1 += cropBoxRectangle.Height + 5;
                y2 = y1 + 35;
            }
            else if (cropBoxRectangle.Y - 90 > 0)
            {
                y1 = cropBoxRectangle.Y - 35;
                y2 = y1 - 35;
            }
            else if (cropBoxRectangle.Y - 90 < 0)
            {
                y1 = cropBoxRectangle.Y;
                y2 = y1 + 35;
            }

            if (cropBoxRectangle.Width < 230 && cropBoxRectangle.X + 230 > width)
            {
                x1 -= 220 - cropBoxRectangle.Width;
            }

            toolbarPanel.Location = new Point(x1, y1);
            colorPanel.Location = new Point(x1, y2);

            if (toolbarPanelActive != null)
            {
                ToolbarPanelControl_Click(toolbarPanelActive, null);
            }
            toolbarPanel.Visible = true;
        }

        /// <summary>
        /// 移动裁剪框
        /// </summary>
        /// <param name="e"></param>
        private void CropBoxRectangle_Move(MouseEventArgs e)
        {
            if (cropBoxRectangleMove)
            {
                cropBoxRectangle.X += e.X - startPoint.X;
                cropBoxRectangle.Y += e.Y - startPoint.Y;
                DrawCropBoxFromRectangle(GetRectangleForMinRange(cropBoxRectangle, minCropPoint, maxCropPoint));
                startPoint = e.Location;
            }
        }

        /// <summary>
        /// 通过控制点修改裁剪框
        /// </summary>
        /// <param name="e"></param>
        private void CropBoxRectangle_Control(MouseEventArgs e)
        {
            if (!draw && cropBoxControl != 0 && !cropBoxRectangleMove && drawShapeList.Count == 0)
            {
                switch (cropBoxControl)
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
        }

        /// <summary>
        /// 根据两点绘制矩形
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private Rectangle GetRectangleFromPoint(Point start, Point end, Rectangle divide = new Rectangle())
        {
            int dx = divide.X;
            int dy = divide.Y;
            int dw = divide.Width == 0 ? width : divide.Width;
            int dh = divide.Height == 0 ? height : divide.Height;

            int x1 = start.X < end.X ? start.X : end.X;
            int x2 = start.X > end.X ? start.X : end.X;
            int y1 = start.Y < end.Y ? start.Y : end.Y;
            int y2 = start.Y > end.Y ? start.Y : end.Y;

            x1 = x1 < dx + 1 ? dx + 1 : x1;
            y1 = y1 < dy + 1 ? dy + 1 : y1;

            x2 = x2 > dx + dw - 1 ? dx + dw - 1 : x2;
            y2 = y2 > dy + dh - 1 ? dy + dh - 1 : y2;

            int w = x2 - x1 < 10 ? 10 : x2 - x1;
            int h = y2 - y1 < 10 ? 10 : y2 - y1;

            return new Rectangle(x1, y1, w, h);
        }

        /// <summary>
        /// 根据矩形大小重新计算矩形位置
        /// </summary>
        /// <param name="point"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        private Rectangle GetRectangleFromSize(Point point, Size size)
        {
            int x1 = size.Width > 0 ? point.X : point.X + size.Width;
            int y1 = size.Height > 0 ? point.Y : point.Y + size.Height;
            int x2 = size.Width > 0 ? point.X + size.Width : point.X;
            int y2 = size.Height > 0 ? point.Y + size.Height : point.Y;

            x1 = x1 < 1 ? 1 : x1;
            y1 = y1 < 1 ? 1 : y1;
            x2 = x2 > width - 1 ? width - 1 : x2;
            y2 = y2 > height - 1 ? height - 1 : y2;

            int w = x2 - x1 < 10 ? 10 : x2 - x1;
            int h = y2 - y1 < 10 ? 10 : y2 - y1;

            return new Rectangle(x1, y1, w, h);
        }

        /// <summary>
        /// 绘制绘制半透明层以及裁剪框
        /// </summary>
        /// <param name="rect"></param>
        private void DrawCropBoxFromRectangle(Rectangle rect, DrawShape drawShapeTemp = null)
        {
            RectangleF tempRect;
            // 定义一个临时图层
            Image temp = (Image)canvasImage.Clone();
            Graphics graphics = Graphics.FromImage(temp);
            // 绘制半透明层
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Black)), new Rectangle(0, 0, temp.Width, temp.Height));

            if (rect.Width != 0 && rect.Height != 0)
            {
                // 绘制高亮区域
                graphics.DrawImage(canvasImage, rect, rect, GraphicsUnit.Pixel);
                // 绘制裁剪框
                graphics.DrawRectangle(new Pen(Color.FromArgb(0, 174, 255), 1), rect);

                cropBoxControlList.Clear();

                // 绘制裁剪框的八个控制点
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (i == 1 && j == 1) continue;
                        tempRect = new RectangleF((rect.X - 2) + rect.Width * (i / 2F), (rect.Y - 2) + rect.Height * (j / 2F), 5, 5);
                        cropBoxControlList.Add(tempRect);
                        graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 174, 255)), tempRect);
                    }
                }
                foreach (DrawShape drawShape in drawShapeList)
                {
                    DrawShapeOnGraphics(graphics, drawShape);
                }

                if (drawShapeTemp != null)
                    DrawShapeOnGraphics(graphics, drawShapeTemp);
            }

            graphics.Dispose();
            graphics = this.CreateGraphics();
            graphics.DrawImage(temp, new Point(0, 0));
            graphics.Dispose();
            temp.Dispose();
        }

        private void DrawShapeOnGraphics(Graphics graphics, DrawShape drawShape)
        {
            switch (drawShape.type)
            {
                case "Rectangle":
                    graphics.DrawRectangle(new Pen(drawShape.color, drawShape.size), drawShape.rect);
                    break;
                case "Circular":
                    graphics.DrawEllipse(new Pen(drawShape.color, drawShape.size), drawShape.rect);
                    break;
                case "Brush":
                    using (Pen p = new Pen(drawShape.color, drawShape.size))
                    {
                        p.StartCap = LineCap.Round;
                        p.EndCap = LineCap.Round;
                        p.LineJoin = LineJoin.Round;

                        graphics.DrawCurve(p, drawShape.point.ToArray()); //画平滑曲线
                    }
                    break;

            }
        }

        /// <summary>
        /// 获取当前工具栏工具名
        /// </summary>
        /// <returns></returns>
        private string GetToolbarPanelActive()
        {
            if (toolbarPanelActive == rectangle)
            {
                return "Rectangle";
            }
            if (toolbarPanelActive == circular)
            {
                return "Circular";
            }
            if (toolbarPanelActive == brush)
            {
                return "Brush";
            }
            return "";
        }
        private DrawShape GetDrawShape(string type, MouseEventArgs e)
        {
            int size = Convert.ToInt32(colorPonitActive.Tag);
            size = size == 2 ? 2 : size == 4 ? 4 : size == 8 ? 8 : 2;
            DrawShape drawShape = new DrawShape(type, GetRectangleFromPoint(startPoint, e.Location, cropBoxRectangle), colorActive.BackColor, size);
            return drawShape;
        }

        /// <summary>
        /// 将矩形框限制在最小尺寸
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        private Rectangle GetRectangleForMinRange(Rectangle rectangle, Point min, Point max)
        {
            if (rectangle.X > max.X - 10)
            {
                rectangle.X = max.X - 10;
            }
            if (rectangle.Y > max.Y - 10)
            {
                rectangle.Y = max.Y - 10;
            }

            if (rectangle.X < 1)
            {
                rectangle.X = 1;
            }
            if (rectangle.Y < 1)
            {
                rectangle.Y = 1;
            }

            if (rectangle.X + rectangle.Width < min.X + 10)
            {
                rectangle.X = min.X - rectangle.Width + 10;
            }
            if (rectangle.Y + rectangle.Height < min.Y + 10)
            {
                rectangle.Y = min.Y - rectangle.Height + 10;
            }

            if (rectangle.X + rectangle.Width > width - 1)
            {
                rectangle.X = width - 1 - rectangle.Width;
            }
            if (rectangle.Y + rectangle.Height > height - 1)
            {
                rectangle.Y = height - 1 - rectangle.Height;
            }

            return rectangle;
        }

        /// <summary>
        /// 判断是否在控制点
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private int InCropBoxControlBox(Point point)
        {
            int i = 0;
            foreach (RectangleF rectangle in cropBoxControlList)
            {
                i++;
                if (rectangle.Contains(point))
                {
                    return i;
                }
            }
            return 0;
        }

        /// <summary>
        /// 切换画笔样式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolbarPanelControl_Click(object sender, EventArgs e)
        {
            PictureBox that = sender as PictureBox;

            if (toolbarPanelActive != that)
            {
                that.Image = Properties.Resources.draw_border;
                if (toolbarPanelActive != null)
                {
                    toolbarPanelActive.Image = null;
                }
                toolbarPanelActive = that;
                if (colorPonitActive == null)
                {
                    ColorSizePonit_Click(ponita, null);
                }
                colorPanel.Visible = true;
            }
            else
            {
                that.Image = null;
                toolbarPanelActive = null;
                colorPanel.Visible = false;
            }
        }

        /// <summary>
        /// 画笔大小改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorSizePonit_Click(object sender, EventArgs e)
        {
            PictureBox that = sender as PictureBox;
            if (colorPonitActive != that)
            {
                that.Image = Properties.Resources.draw_border;
                if (colorPonitActive != null)
                {
                    colorPonitActive.Image = null;
                }
                colorPonitActive = that;
            }
        }

        /// <summary>
        /// 颜色改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorColorChange_Click(object sender, EventArgs e)
        {
            Label that = sender as Label;
            colorActive.BackColor = that.BackColor;
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {
            // 定义一个临时图层
            Image temp = (Image)canvasImage.Clone();
            Graphics graphics = Graphics.FromImage(temp);
            foreach (DrawShape drawShape in drawShapeList)
            {
                DrawShapeOnGraphics(graphics, drawShape);
            }
            graphics.Dispose();
            int w = cropBoxRectangle.Width;
            int h = cropBoxRectangle.Height;
            Image temp2 = new Bitmap(w, h);
            graphics = Graphics.FromImage(temp2);
            graphics.DrawImage(temp, new Rectangle(0, 0, w, h), cropBoxRectangle, GraphicsUnit.Pixel);
            graphics.Dispose();
            string path = ClassStatic.GetConfigSoftware("cachePath");

            if (Directory.Exists(path) == false)
            {
                path = System.Environment.CurrentDirectory + "\\cache";
                Directory.CreateDirectory(path);
                ClassStatic.SetConfigSoftware("cachePath", path);
            }

            path = path + "\\" + DateTime.Now.ToString("yyyy-MM-dd.HHmmss") + ".png";
            temp2.Save(path);
            StringCollection file = new StringCollection();
            file.Add(path);
            Clipboard.SetFileDropList(file);
            temp.Dispose();
            temp2.Dispose();
            this.Close();
        }

        private void FormScreenshot_Paint(object sender, PaintEventArgs e)
        {
            DrawCropBoxFromRectangle(cropBoxRectangle);
        }

        private void FormScreenshot_MouseDown(object sender, MouseEventArgs e)
        {
            // 左键点击事件
            if (e.Button == MouseButtons.Left)
            {
                startPoint = e.Location;
                cropBoxControl = InCropBoxControlBox(e.Location);
                if (toolbarPanelActive == null || !draw)
                {
                    if (cropBoxControl == 0 && cropBoxRectangle.Contains(startPoint))
                    {
                        cropBoxRectangleMove = true;
                    }
                }
                if (draw && (cropBoxRectangleMove || (cropBoxControl != 0 && drawShapeList.Count == 0)))
                {
                    draw = false;
                    toolbarPanel.Visible = false;
                    colorPanel.Visible = false;
                }
            }
        }

        private void FormScreenshot_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (draw && toolbarPanelActive != null && cropBoxRectangle.Contains(startPoint))
                {
                    string type = GetToolbarPanelActive();
                    switch (type)
                    {
                        case "Rectangle":
                            DrawCropBoxFromRectangle(cropBoxRectangle, GetDrawShape(type, e));
                            break;
                        case "Circular":
                            DrawCropBoxFromRectangle(cropBoxRectangle, GetDrawShape(type, e));
                            break;
                        case "Brush":
                            if (DrawShapeBrushTemp == null)
                            {
                                DrawShapeBrushTemp = GetDrawShape(type, e);
                                DrawShapeBrushTemp.point.Add(startPoint);
                            }
                            DrawShapeBrushTemp.point.Add(e.Location);
                            DrawCropBoxFromRectangle(cropBoxRectangle, DrawShapeBrushTemp);
                            break;
                    }
                }
                else
                {
                    CropBoxRectangle_Move(e);
                    CropBoxRectangle_Control(e);
                    // 正常绘制
                    if (!draw && cropBoxControl == 0 && !cropBoxRectangleMove)
                    {
                        DrawCropBoxFromRectangle(GetRectangleFromPoint(startPoint, e.Location));
                    }
                }
            }
        }

        private void FormScreenshot_MouseUp(object sender, MouseEventArgs e)
        {
            if (!draw)
            {
                if (e.Button == MouseButtons.Left)
                {
                    // 正常绘制鼠标抬起
                    if (!draw && cropBoxControl == 0 && !cropBoxRectangleMove)
                    {
                        cropBoxRectangle = GetRectangleFromPoint(startPoint, e.Location);
                    }
                    // 调整裁剪框大小
                    if (cropBoxControl != 0 && !cropBoxRectangleMove)
                    {
                        cropBoxControl = 0;
                        cropBoxRectangle = GetRectangleFromSize(cropBoxRectangle.Location, cropBoxRectangle.Size);
                    }
                    // 移动裁剪框
                    if (cropBoxRectangleMove)
                    {
                        cropBoxRectangleMove = false;
                    }
                    draw = true;
                    DrawInitialization();
                }
            }
            else
            {
                if (draw && toolbarPanelActive != null && cropBoxRectangle.Contains(startPoint))
                {
                    string type = GetToolbarPanelActive();
                    if (type == "Rectangle" || type == "Circular")
                    {
                        DrawShape temp = GetDrawShape(GetToolbarPanelActive(), e);
                        if (temp.rect.X < maxCropPoint.X)
                        {
                            maxCropPoint.X = temp.rect.X;
                        }
                        if (temp.rect.Y < maxCropPoint.Y)
                        {
                            maxCropPoint.Y = temp.rect.Y;
                        }
                        if (temp.rect.X + temp.rect.Width > minCropPoint.X)
                        {
                            minCropPoint.X = temp.rect.X + temp.rect.Width;
                        }
                        if (temp.rect.Y + temp.rect.Height > minCropPoint.Y)
                        {
                            minCropPoint.Y = temp.rect.Y + temp.rect.Height;
                        }

                        drawShapeList.Add(temp);
                    }

                    if (type == "Brush")
                    {
                        drawShapeList.Add(DrawShapeBrushTemp);
                        DrawShapeBrushTemp = null;
                    }
                }
                if (e.Button == MouseButtons.Right && drawShapeList.Count == 0 && !cropBoxRectangle.Contains(e.Location))
                {
                    draw = false;
                    cropBoxRectangle = new Rectangle();
                    toolbarPanel.Visible = false;
                    colorPanel.Visible = false;
                }
            }
        }

        private void FormScreenshot_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
