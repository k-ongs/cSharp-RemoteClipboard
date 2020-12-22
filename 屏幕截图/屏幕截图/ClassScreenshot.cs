using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace 屏幕截图
{
    class ClassScreenshot
    {
        /// <summary>
        /// 截图显示窗体
        /// </summary>
        private FormScreenshot formScreenshot = new FormScreenshot();
        /// <summary>
        /// 全屏的截图
        /// </summary>
        private Bitmap screenshotImage;
        /// <summary>
        /// 窗体背景图片
        /// </summary>
        private Bitmap backgroundImage;
        /// <summary>
        /// 桌面的尺寸
        /// </summary>
        private Rectangle desktopRectangle;
        /// <summary>
        /// 当前选中框
        /// </summary>
        private Rectangle windowFromRect = new Rectangle();
        /// <summary>
        /// 桌面显示窗体列表
        /// </summary>
        private List<Rectangle> visibleWindonwList = new List<Rectangle>();

        /// <summary>
        /// 鼠标点击起始坐标
        /// </summary>
        private Point pointStart;

        class FormScreenshot : Form
        {
            public new void SetStyle(ControlStyles flag, bool value)
            {
                base.SetStyle(flag, value);
            }
        }

        /// <summary>
        /// 显示窗口
        /// </summary>
        public void ShowDialog()
        {
            InitializeComponent();

            formScreenshot.ShowDialog();
            formScreenshot.Dispose();
            screenshotImage.Dispose();
            backgroundImage.Dispose();
        }

        /// <summary>
        /// 初始化窗体控件
        /// </summary>
        private void InitializeComponent()
        {
            desktopRectangle = new Rectangle(0,0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            backgroundImage = new Bitmap(desktopRectangle.Width, desktopRectangle.Height);
            Graphics graphics = Graphics.FromImage(backgroundImage);

            // 获取截图
            graphics.CopyFromScreen(new Point(0, 0), new Point(0, 0), desktopRectangle.Size, CopyPixelOperation.SourceCopy);
            screenshotImage = (Bitmap)backgroundImage.Clone();

            graphics.FillRectangle(new SolidBrush(Color.FromArgb(70, Color.Black)), Screen.PrimaryScreen.Bounds);

            // 释放Graphics使用的所有资源
            graphics.Dispose();

            // 设置窗口样式
            //formScreenshot.TopMost = true;
            formScreenshot.ShowIcon = false;
            formScreenshot.ShowInTaskbar = false;
            formScreenshot.BackgroundImage = backgroundImage;
            formScreenshot.FormBorderStyle = FormBorderStyle.None;
            formScreenshot.Width = Screen.PrimaryScreen.Bounds.Width;
            formScreenshot.Height = Screen.PrimaryScreen.Bounds.Height;
            formScreenshot.Location = Screen.PrimaryScreen.Bounds.Location;
            formScreenshot.WindowState = FormWindowState.Maximized;

            formScreenshot.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            formScreenshot.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            SetVisibleWindonwList();


            // 窗体事件
            formScreenshot.KeyDown += Form_KeyDown;
            formScreenshot.MouseDown += Form_MouseDown;
            formScreenshot.MouseMove += Form_MouseMove;

            System.Diagnostics.Debug.WriteLine("windowFromRect：" + windowFromRect.ToString());
        }

        /// <summary>
        /// 设置桌面显示的窗口列表
        /// </summary>
        private void SetVisibleWindonwList()
        {
            bool firstWinPtr = true;

            // 获取最前面的窗口句柄，一般就是本窗体
            IntPtr winPtr = ClassAPI.GetWindow(ClassAPI.GetDesktopWindow(), 5);
            while (winPtr != IntPtr.Zero)
            {
                /// 取当前桌面显示的窗口，屏蔽本窗口
                if (!firstWinPtr && !ClassAPI.IsIconic(winPtr) && ClassAPI.IsWindowVisible(winPtr))
                {
                    ClassAPI.Rect rect = new ClassAPI.Rect();
                    if (ClassAPI.GetWindowRect(winPtr, out rect))
                    {
                        SetVisibleWindonwList(rect);
                    }
                }

                if (firstWinPtr)
                {
                    firstWinPtr = false;
                }

                // 获取兄弟窗口的窗口句柄
                winPtr = ClassAPI.GetWindow(winPtr, 2);
            }

            //显示所有可见窗口的信息
            for (int i = 0; i < visibleWindonwList.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(visibleWindonwList[i].ToString());
            }
        }

        /// <summary>
        /// 设置桌面显示的窗口列表
        /// </summary>
        /// <param name="rect"></param>
        private void SetVisibleWindonwList(ClassAPI.Rect rect)
        {
            // 过滤size为0的窗口
            if (rect.right - rect.left == 0 || rect.bottom - rect.top == 0)
            {
                return;
            }
            // 过滤屏幕之外的窗口
            if (rect.right < 0 && rect.bottom < 0)
            {
                return;
            }
            // 过滤屏幕之外的窗口
            if (rect.left > desktopRectangle.Width && rect.top > desktopRectangle.Height)
            {
                return;
            }

            int x = rect.left;
            int y = rect.top;
            int width = rect.right - rect.left;
            int height = rect.bottom - rect.top;

            if (x < 0)
            {
                width = width - Math.Abs(x);
                x = 0;
            }
            if (y < 0)
            {
                height = height - Math.Abs(y);
                y = 0;
            }
            width = x + width > desktopRectangle.Width ? desktopRectangle.Width - x : width;
            height = y + height > desktopRectangle.Height ? desktopRectangle.Height - y : height;

            visibleWindonwList.Add(new Rectangle(x, y, width, height));
        }

        /// <summary>
        /// 根据鼠标位置返回指定窗口区域
        /// </summary>
        /// <param name="mousePos"></param>
        /// <returns></returns>
        private int GetVisibleWindonwFromPoint(Point mousePos)
        {
            for (int i = 0; i < visibleWindonwList.Count; i++)
            {
                if (visibleWindonwList[i].Contains(mousePos))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 窗口鼠标点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            pointStart = e.Location;
        }

        /// <summary>
        /// 窗体鼠标移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            switch(e.Button)
            {
                case MouseButtons.Left:
                    InvalidateWinSelectFrame();
                    int width = e.Location.X - pointStart.X;
                    int height = e.Location.Y - pointStart.Y;
                    if(width > 0 && height > 0)
                    {
                        windowFromRect = new Rectangle(pointStart, new Size(width, height));
                    }
                    
                    System.Diagnostics.Debug.WriteLine(windowFromRect.ToString());

                    DrawWindowFromPoint();
                    break;
                case MouseButtons.None:
                {
                    // 鼠标移动到窗口区域高亮
                    int temp = GetVisibleWindonwFromPoint(e.Location);
                    if (temp != -1 && windowFromRect != visibleWindonwList[temp])
                    {
                        InvalidateWinSelectFrame();
                        windowFromRect = visibleWindonwList[temp];
                        DrawWindowFromPoint();
                    }
                    break;
                } 
            }            
        }

        /// <summary>
        /// 窗体按键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            // 按esc退出
            if (e.KeyCode == Keys.Escape)
            {
                formScreenshot.Close();
            }
        }

        /// <summary>
        /// 初始化窗体绘制区域
        /// </summary>
        /// <param name="winRect"></param>
        private void InvalidateWinSelectFrame()
        {
            formScreenshot.Invalidate(desktopRectangle);
            formScreenshot.Update();
        }

        private void DrawWindowFromPoint()
        {
            if (!windowFromRect.IsEmpty)
            {
                Bitmap bmp = new Bitmap(windowFromRect.Width, windowFromRect.Height);
                Graphics gbmp = Graphics.FromImage(bmp);
                Rectangle rectBmp = new Rectangle(0, 0, bmp.Width, bmp.Height);
                gbmp.DrawImage(screenshotImage, rectBmp, windowFromRect, GraphicsUnit.Pixel);
                gbmp.DrawRectangle(new Pen(Color.FromArgb(0, 174, 255), 3.0F), rectBmp);

                Graphics g = formScreenshot.CreateGraphics();
                g.DrawImage(bmp, windowFromRect, rectBmp, GraphicsUnit.Pixel);

                bmp.Dispose();
                gbmp.Dispose();
            }
        }
    }
}
