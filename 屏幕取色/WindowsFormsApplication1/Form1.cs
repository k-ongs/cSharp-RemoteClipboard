using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public enum KeyModifiers
        {
            None = 0, Alt = 1, Control = 2, Shift = 4, Windows = 8
        }
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll")]//取设备场景  
        private static extern IntPtr GetDC(IntPtr hwnd);//返回设备场景句柄  
        [DllImport("gdi32.dll")]//取指定点颜色  
        private static extern int GetPixel(IntPtr hdc, Point p);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hwnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);//虽然这里没有用到注销热键  还是导进来

        private void Form1_Load(object sender, EventArgs e)
        {
            reg();
            Rectangle ScreenArea = System.Windows.Forms.Screen.GetBounds(this);
            int width1 = ScreenArea.Width; //屏幕宽度
            int height1 = ScreenArea.Height; //屏幕高度
            this.Left = width1 - 275;
            this.Top = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point p = new Point(MousePosition.X, MousePosition.Y);//取置顶点坐标  
            this.Text = "当前坐标" + p.X + "," + p.Y;//把坐标显示到窗口上  
            IntPtr hdc = GetDC(new IntPtr(0));//取到设备场景(0就是全屏的设备场景)  
            int c = GetPixel(hdc, p);//取指定点颜色  
            int r = (c & 0xFF);//转换R  
            int g = (c & 0xFF00) / 256;//转换G  
            int b = (c & 0xFF0000) / 65536;//转换B  
            textBox_10jz.Text = c.ToString();//输出10进制颜色  
            textBox_16jz.Text = r.ToString("x").PadLeft(2, '0') + g.ToString("x").PadLeft(2, '0') + b.ToString("x").PadLeft(2, '0');//输出16进制颜色  
            textBox_RGB.Text = r.ToString() + ',' + g.ToString() + ',' + b.ToString();//输出RGB  
            this.pictureBox1.BackColor = Color.FromArgb(r, g, b);//设置颜色框 
        }
        private void textBox_10jz_MouseDown(object sender, MouseEventArgs e)
        {
            Clipboard.SetDataObject(textBox_10jz.Text);//点击文本框复制内容到剪切板
        }
        private void textBox_16jz_MouseDown(object sender, MouseEventArgs e)
        {
            Clipboard.SetDataObject(textBox_16jz.Text);
        }
        private void textBox_RGB_MouseDown(object sender, MouseEventArgs e)
        {
            Clipboard.SetDataObject(textBox_RGB.Text);
        }
        public void reg()
        {
            RegisterHotKey(this.Handle, 1, 0, (int)Keys.F1);//注册热键
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case 1:
                            this.timer1.Enabled = !timer1.Enabled;
                            if (timer1.Enabled == true)
                            {
                                label4.Text = "按下F1停止拾色";
                            }
                            else
                                label4.Text = "按下F1开始拾色";

                            break;

                    }
                    break;
            }
            base.WndProc(ref m);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
