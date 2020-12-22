using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace 屏幕截图
{
    class ClassAPI
    {
        /// <summary>
        /// 存储矩形大小
        /// </summary>
        public struct Rect
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        /// <summary>
        /// 判断矩形是否有交集
        /// </summary>
        /// <param name="rect1">矩形1</param>
        /// <param name="rect2">矩形2</param>
        /// <returns></returns>
        public static bool Judge(Rect rect1, Rect rect2)
        {
            int i1 = Math.Abs((rect1.top - rect1.bottom) / 2 - (rect2.top - rect2.bottom) / 2);
            int i2 = (rect1.bottom + rect2.bottom - rect1.top - rect2.top) / 2;
            int j1 = Math.Abs((rect1.left - rect1.right) / 2 - (rect2.left - rect2.right) / 2);
            int j2 = (rect1.right + rect2.right - rect1.left - rect2.left) / 2;

            return (i1 < i2 && j1 < j2);
        }

        /// <summary>
        /// 确定指定窗口的可见性状态
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        /// <summary>
        /// 将指定窗口标题栏的文本（如果存在话）复制到缓冲区中。如果指定的窗口是控件，则复制该控件的文本。
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="lpString">接收文本的缓冲区</param>
        /// <param name="nMaxCount">最大字符数</param>
        /// <returns>接收的文本长度</returns>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        /// <summary>
        /// 确定指定窗口是否最小化到图标
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <returns></returns>

        [DllImport("user32.dll")]
        public static extern bool IsIconic(IntPtr hWnd);

        /// <summary>
        /// 检索指定窗口的边界矩形的尺寸。尺寸以相对于屏幕左上角的屏幕坐标给出。
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="lpRect">指向RECT结构的指针</param>
        /// <returns>布尔</returns>
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, out Rect lpRect);

        /// <summary>
        /// 检索桌面窗口的句柄。
        /// </summary>
        /// <returns>窗口句柄</returns>
        [DllImport("user32.dll", EntryPoint = "GetDesktopWindow", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetDesktopWindow();

        /// <summary>
        /// 检索与指定窗口具有指定关系（Z顺序或所有者）的窗口的句柄
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="uCmd">指定窗口和要获取其句柄的窗口之间的关系。详情参考 https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getwindow</param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);

    }
}
