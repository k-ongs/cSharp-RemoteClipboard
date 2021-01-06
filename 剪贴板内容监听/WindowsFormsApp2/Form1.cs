using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        IntPtr nextClipboardViewer;

        public Form1()
        {
            InitializeComponent();
            nextClipboardViewer = (IntPtr)SetClipboardViewer((int)Handle);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            System.Diagnostics.Debug.WriteLine(dt.ToString("yyyy-MM-dd.HH:mm:ss"));
            KeyboardHookNew keyboardHookNew = new KeyboardHookNew();
            //keyboardHookNew.KeyUpEvent += keyboardHook_KeyUp;
            ///keyboardHookNew.KeyPressEvent += keyboardHook_KeyUp;
            keyboardHookNew.KeyDownEvent += keyboardHook_KeyUp;
            keyboardHookNew.Start();
        }

        void keyboardHook_KeyUp(object sender, KeyEventArgs e)
        {

            //e.KeyCode == Keys.Alt
            string s1 = (e.KeyCode).ToString();
            string s2 = e.Shift.ToString();
            string s3 = e.Alt.ToString();
            string s4 = e.Control.ToString();
            System.Diagnostics.Debug.WriteLine(s1 + " " + s2 + " " + s3 + " " + s4);
        }

        private const int WM_PASTE = 0x302;
        protected override void WndProc(ref Message m)
        {
            // defined in winuser.h
            const int WM_DRAWCLIPBOARD = 0x308;
            const int WM_CHANGECBCHAIN = 0x030D;

            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    DisplayClipboardData();
                    SendMessage(nextClipboardViewer, WM_PASTE, m.WParam, m.LParam);
                    break;
                case WM_CHANGECBCHAIN:
                    if (m.WParam == nextClipboardViewer)
                        nextClipboardViewer = m.LParam;
                    else
                        SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;
            }
            base.WndProc(ref m);
        }
        /// <summary>
        /// 显示剪贴板内容
        /// </summary>
        private void DisplayClipboardData()
        {
            try
            {
                if (Clipboard.ContainsImage())
                {
                    richTextBox1.Text = "这是一张图片";
                }
                if (Clipboard.ContainsText())
                {
                    richTextBox1.Text = Clipboard.GetText();
                }
                if (Clipboard.ContainsFileDropList())
                {
                    foreach (string file in Clipboard.GetFileDropList())
                    {
                        //输出文件的全路径
                        Console.WriteLine(file);
                        richTextBox1.Text += file + "\n";
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            ChangeClipboardChain(Handle, nextClipboardViewer);
        }

        #region WindowsAPI
        /// <summary>
        /// 将CWnd加入一个窗口链，每当剪贴板的内容发生变化时，就会通知这些窗口
        /// </summary>
        /// <param name="hWndNewViewer">句柄</param>
        /// <returns>返回剪贴板观察器链中下一个窗口的句柄</returns>
        [DllImport("User32.dll")]
        protected static extern int SetClipboardViewer(int hWndNewViewer);

        /// <summary>
        /// 从剪贴板链中移出的窗口句柄
        /// </summary>
        /// <param name="hWndRemove">从剪贴板链中移出的窗口句柄</param>
        /// <param name="hWndNewNext">hWndRemove的下一个在剪贴板链中的窗口句柄</param>
        /// <returns>如果成功，非零;否则为0。</returns>
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        /// <summary>
        /// 将指定的消息发送到一个或多个窗口
        /// </summary>
        /// <param name="hwnd">其窗口程序将接收消息的窗口的句柄</param>
        /// <param name="wMsg">指定被发送的消息</param>
        /// <param name="wParam">指定附加的消息特定信息</param>
        /// <param name="lParam">指定附加的消息特定信息</param>
        /// <returns>消息处理的结果</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("test");
        }
    }
}
