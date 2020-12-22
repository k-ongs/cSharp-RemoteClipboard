using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace 屏幕截图
{
    public partial class FormScreenshot : Form
    {
        private Rectangle desktopRectangle;
        /// <summary>
        /// 桌面显示窗体列表
        /// </summary>
        private List<Rectangle> visibleWindonwList = new List<Rectangle>();

        public static int i = 0;
        Bitmap bmp;
        public FormScreenshot(Image img)
        {
            InitializeComponent();
            BackgroundImage = img;

            desktopRectangle = new Rectangle(0,0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        }

        private void FormScreenshot_Load(object sender, EventArgs e)
        {

            IntPtr winPtr = ClassAPI.GetWindow(ClassAPI.GetDesktopWindow(), 5);

            ClassAPI.Rect rectangleDesktop = new ClassAPI.Rect();
            rectangleDesktop.top = 0;
            rectangleDesktop.left = 0;
            rectangleDesktop.right = Screen.PrimaryScreen.Bounds.Width;
            rectangleDesktop.bottom = Screen.PrimaryScreen.Bounds.Height;

            Graphics gbmp = Graphics.FromImage(bmp);

            while (winPtr != IntPtr.Zero)
            {
                if (!ClassAPI.IsIconic(winPtr) && ClassAPI.IsWindowVisible(winPtr))
                {
                    ClassAPI.Rect rect = new ClassAPI.Rect();
                    if (ClassAPI.GetWindowRect(winPtr, out rect))
                    {
                        if (ClassAPI.Judge(rectangleDesktop, rect))
                        {
                            int y = rect.top;
                            int x = rect.left;
                            int w = rect.right - rect.left;
                            int h = rect.bottom - rect.top;
                            //string msg = String.Format("t:{0} l:{1} r:{2} b:{3}", rect.top, rect.left, rect.right, rect.bottom);
                            //System.Diagnostics.Debug.WriteLine(msg);
                            //drow(x, y, w, h);

                            gbmp.DrawRectangle(new Pen(Color.Red, 5), new Rectangle(x, y, w, h));
                        }

                    }
                }
                winPtr = ClassAPI.GetWindow(winPtr, 2);
            }

            bmp.Save("1.png");
        }

        private void FormScreenshot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void FormScreenshot_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.DrawImage(bmp, 0,0);
        }

        private void FormScreenshot_MouseMove(object sender, MouseEventArgs e)
        {

        }

        public void DrawWindowFromPoint()
        {

        }

        // 设置桌面显示的窗口列表
        private void SetVisibleWindonwList()
        {
            //visibleWindonwList

            // 获取最前面的窗口句柄，一般就是本窗体
            IntPtr winPtr = ClassAPI.GetWindow(ClassAPI.GetDesktopWindow(), 5);
            while (winPtr != IntPtr.Zero)
            {
                if (!ClassAPI.IsIconic(winPtr) && ClassAPI.IsWindowVisible(winPtr))
                {
                    ClassAPI.Rect rect = new ClassAPI.Rect();
                    if (ClassAPI.GetWindowRect(winPtr, out rect))
                    {
                        
                    }
                }
                winPtr = ClassAPI.GetWindow(winPtr, 2);
            }
        }
    }
}
