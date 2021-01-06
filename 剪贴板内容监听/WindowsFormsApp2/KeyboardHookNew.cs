using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApp2
{
    public class KeyboardHookNew
    {
        private const int VK_LALT = 0xA4;
        private const int VK_RALT = 0xA5;
        private const int VK_RSHIFT = 0xA1;
        private const int VK_LSHIFT = 0xA0;
        private const int VK_RCONTROL = 0x3;
        private const int VK_CAPITAL = 0x14;
        private const int VK_LCONTROL = 0xA2;
        private const int WM_KEYDOWN = 0x100;
        private const int WM_SYSKEYDOWN = 0x104;

        public event KeyEventHandler KeyDownEvent;
        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);

        static int hKeyboardHook = 0; // 声明键盘钩子处理的初始值
        public const int WH_KEYBOARD_LL = 13;   // 全局键盘监听鼠标消息设为13
        HookProc KeyboardHookProcedure; // 声明KeyboardHookProcedure作为HookProc类型
        // 键盘结构
        [StructLayout(LayoutKind.Sequential)]
        public class KeyboardHookStruct
        {
            public int vkCode;  // 定一个虚拟键码。该代码必须有一个价值的范围1至254
            public int scanCode; // 指定的硬件扫描码的关键
            public int flags;  // 键标志
            public int time; // 指定的时间戳记的这个讯息
            public int dwExtraInfo; // 指定额外信息相关的信息
        }

        //使用此功能，安装了一个钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        //调用此函数卸载钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        //使用此功能，通过信息钩子继续下一个钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);

        //使用WINDOWS API函数代替获取当前实例的函数,防止钩子失效
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);


        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern short GetKeyState(int vKey);

        public void Start()
        {
            if (hKeyboardHook == 0)
            {
                KeyboardHookProcedure = new HookProc(KeyboardHookProc);
                hKeyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyboardHookProcedure, GetModuleHandle(System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName), 0);
            }
        }
        public void Stop()
        {
            if (hKeyboardHook != 0)
            {
                UnhookWindowsHookEx(hKeyboardHook);
                hKeyboardHook = 0;
            }
        }

        private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            // 侦听键盘事件
            if ((nCode >= 0) && KeyDownEvent != null)
            {
                KeyboardHookStruct MyKeyboardHookStruct = (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));
                bool control = ((GetKeyState(VK_LCONTROL) & 0x80) != 0) || ((GetKeyState(VK_RCONTROL) & 0x80) != 0);
                bool shift = ((GetKeyState(VK_LSHIFT) & 0x80) != 0) || ((GetKeyState(VK_RSHIFT) & 0x80) != 0);
                bool alt = ((GetKeyState(VK_LALT) & 0x80) != 0) || ((GetKeyState(VK_RALT) & 0x80) != 0);
                bool capslock = (GetKeyState(VK_CAPITAL) != 0);
                if(wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN)
                {
                    KeyEventArgs e = new KeyEventArgs((Keys)(MyKeyboardHookStruct.vkCode | (control ? (int)Keys.Control : 0) | (shift ? (int)Keys.Shift : 0) | (alt ? (int)Keys.Alt : 0) ));
                    KeyDownEvent(this, e);
                }
            }
            return CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
        }

        ~KeyboardHookNew()
        {
            Stop();
        }
    }
}
