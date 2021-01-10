using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Linq;

namespace RemoteClipboard
{
    public partial class FormMain : Form
    {
        #region 绘制窗体阴影

        #region WindowsAPI

           [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

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

        private bool m_aeroEnabled;                     // variables for box shadow
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;

        public struct MARGINS                           // struct for box shadow
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();

                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }
        }

        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x312;
            const int WM_DRAWCLIPBOARD = 0x308;
            const int WM_CHANGECBCHAIN = 0x030D;
            switch (m.Msg)
            {
                case WM_NCPAINT:                        // box shadow
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 0,
                            rightWidth = 0,
                            topHeight = 0
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                    }
                    break;
                case WM_HOTKEY:
                    ShortcutkeyHandlere(ref m);
                    break;
                case WM_DRAWCLIPBOARD:
                    DisplayClipboardData();
                    SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;
                case WM_CHANGECBCHAIN:
                    if (m.WParam == nextClipboardViewer)
                        nextClipboardViewer = m.LParam;
                    else
                        SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }
        #endregion

        private IntPtr nextClipboardViewer;
        private int menuButtonActive = 1;
        public static FormMain formMain;
        public ControlDeviceList deviceList = null;
        public ControlSoftwareSetting softwareSetting = null;

        public FormMain()
        {
            formMain = this;
            InitializeComponent();
            nextClipboardViewer = (IntPtr)SetClipboardViewer((int)Handle);
            this.StartPosition = FormStartPosition.CenterScreen;
            notifyIcon1.Visible = false;
            this.Hide();
            ClassStatic.tcpClient.OnServerCloseHandler += onServerCloseHandler;
            ClassStatic.tcpClient.OnServerReceiveHandler += OnOtherDriveClipboardDataTextHandler;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Invoke(new Action(() => {
                // 显示登录框
                FormLogin formTemp = new FormLogin();
                formTemp.ShowDialog();
                formTemp.Dispose();

                // 判断是否登录成功
                if(ClassStatic.isLogined)
                {
                    deviceList = new ControlDeviceList();
                    softwareSetting = new ControlSoftwareSetting();
                    // 显示托盘图标
                    notifyIcon1.Visible = true;
                    // 设置在线状态
                    ClassStatic.onlineStatus = 0;
                    // 设置窗体在线状态
                    statusOnlineControl1.Status = 0;
                    // 设置窗体中的头像为用户选中头像
                    portraitBox1.Portrait = ClassStatic.portraitPid;
                    // 初始化设备列表
                    deviceList.InitializeDeviceList();
                    // 将设备列表添加到显示容器
                    panel1.Controls.Add(deviceList);

                    ShortcutkeyHandRegister();
                    // 显示本窗体
                    this.Show();
                }
                else
                {
                    this.Dispose();
                    this.Close();
                }
            }));
        }
        private void FormMain_Load()
        {
            FormMain_Load(null, null);
        }

        /// <summary>
        /// 与服务器断开连接
        /// </summary>
        public void onServerCloseHandler()
        {
            if (ClassStatic.isLogined)
            {
                this.Invoke(new Action(() => {
                    this.Hide();
                    notifyIcon1.Visible = false;
                    ClassStatic.isLogined = false;
                    panel1.Controls.Clear();
                    deviceList.Dispose();
                    softwareSetting.Dispose();
                    UndoShortcutkeyHandRegister();
                    (new Thread(FormMain_Load)).Start();
                }));
            }
            System.Diagnostics.Debug.WriteLine("断开连接");
        }

        /// <summary>
        /// 菜单鼠标移入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuButtn_MouseHover(object sender, EventArgs e)
        {
            Panel panel;
            if (sender is Label)
            {
                sender = ((Label)sender).Parent;
            }

            if (sender is Panel)
            {
                panel = (Panel)sender;
                if (menuButtonActive != Convert.ToInt32(panel.Tag))
                {
                    panel.BackColor = Color.WhiteSmoke;
                }
            }
        }

        /// <summary>
        /// 菜单鼠标移出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuButtn_MouseLeave(object sender, EventArgs e)
        {
            Panel panel;
            if (sender is Label)
            {
                sender = ((Label)sender).Parent;
            }

            if (sender is Panel)
            {
                panel = (Panel)sender;
                if (menuButtonActive != Convert.ToInt32(panel.Tag))
                {
                    panel.BackColor = Color.Transparent;
                }
            }
        }

        /// <summary>
        /// 菜单切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuButtn_Click(object sender, EventArgs e)
        {
            Panel panel;
            if (sender is Label)
            {
                sender = ((Label)sender).Parent;
            }

            if (sender is Panel)
            {
                panel = (Panel)sender;
                if (menuButtonActive != Convert.ToInt32(panel.Tag))
                {
                    panel1.Controls.Clear();

                    if (Convert.ToInt32(panel.Tag) == 1)
                    {
                        menuButtonActive = 1;
                        panel1.Controls.Add(deviceList);
                        panel2.BackColor = Color.WhiteSmoke;
                        panel3.BackColor = Color.Transparent;
                    }
                    else
                    {
                        menuButtonActive = 2;
                        panel1.Controls.Add(softwareSetting);
                        panel3.BackColor = Color.WhiteSmoke;
                        panel2.BackColor = Color.Transparent;
                    }
                }
            }
        }

        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 打开主面板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        /// <summary>
        /// 鼠标双击图标显示主面板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        /// <summary>
        /// 鼠标左键点击图标显示主面板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Show();
            }
        }

        /// <summary>
        /// 模式更改到在线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemOnline_Click(object sender, EventArgs e)
        {
            if (ClassStatic.tcpClient.IsConnected && ClassStatic.onlineStatus != 0)
            {
                if (ClassStatic.isLogined)
                {
                    this.Invoke(new Action(() => {
                        ClassStatic.onlineStatus = 0;
                        statusOnlineControl1.Status = 0;
                        deviceList.controlDeviceMyself.Status = 0;
                        notifyIcon1.Icon = Properties.Resources.RemoteClipboard;
                        Action<bool, byte[]> action = new Action<bool, byte[]>(MenuItemChangeState_Callback);
                        ClassStatic.tcpClient.Send(203, ClassStatic.GetBytes("在线"), action);
                    }));
                }
            }
        }

        /// <summary>
        /// 模式更改到勿扰
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemtoolStripMenuItemNoData_Click(object sender, EventArgs e)
        {
            if (ClassStatic.tcpClient.IsConnected && ClassStatic.onlineStatus != 1)
            {
                if (ClassStatic.isLogined)
                {
                    this.Invoke(new Action(() => {
                        ClassStatic.onlineStatus = 1;
                        statusOnlineControl1.Status = 1;
                        deviceList.controlDeviceMyself.Status = 1;
                        notifyIcon1.Icon = Properties.Resources.RemoteClipboardRed;
                        Action<bool, byte[]> action = new Action<bool, byte[]>(MenuItemChangeState_Callback);
                        ClassStatic.tcpClient.Send(203, ClassStatic.GetBytes("勿扰"), action);
                    }));
                }
            }
        }

        /// <summary>
        /// 修改设备模式
        /// </summary>
        /// <param name="state"></param>
        /// <param name="data"></param>
        private void MenuItemChangeState_Callback(bool state, byte[] data)
        {
            System.Diagnostics.Debug.WriteLine("状态更改成功！");
        }

        /// <summary>
        /// 快捷键注册按键
        /// </summary>
        /// <param name="code"></param>
        public void ShortcutkeyHandRegister()
        {
            string temp = ClassStatic.GetConfigSoftware("copy");
            ClassStatic.ShortcutKeys tempkey = GetShortcutKey(temp, ClassHotKey.KeyModifiers.Ctrl, Keys.C);
            if(tempkey.key1 != ClassHotKey.KeyModifiers.Ctrl || tempkey.key2 != Keys.C)
            {
                ClassHotKey.RegisterHotKey(Handle, ClassStatic.ShortcutKey.Copy, tempkey.key1, tempkey.key2);
            }

            temp = ClassStatic.GetConfigSoftware("paste");
            tempkey = GetShortcutKey(temp, ClassHotKey.KeyModifiers.Ctrl, Keys.V);
            if (tempkey.key1 != ClassHotKey.KeyModifiers.Ctrl || tempkey.key2 != Keys.V)
            {
                ClassHotKey.RegisterHotKey(Handle, ClassStatic.ShortcutKey.Paste, tempkey.key1, tempkey.key2);
            }

            temp = ClassStatic.GetConfigSoftware("screenshot");
            tempkey = GetShortcutKey(temp, ClassHotKey.KeyModifiers.Ctrl, Keys.P);
            ClassHotKey.RegisterHotKey(Handle, ClassStatic.ShortcutKey.Screenshot, tempkey.key1, tempkey.key2);

            temp = ClassStatic.GetConfigSoftware("color");
            tempkey = GetShortcutKey(temp, ClassHotKey.KeyModifiers.Ctrl, Keys.L);
            ClassHotKey.RegisterHotKey(Handle, ClassStatic.ShortcutKey.Color, tempkey.key1, tempkey.key2);
        }

        /// <summary>
        /// 注销快捷热键
        /// </summary>
        public void UndoShortcutkeyHandRegister()
        {
            ClassHotKey.UnregisterHotKey(Handle, ClassStatic.ShortcutKey.Copy);
            ClassHotKey.UnregisterHotKey(Handle, ClassStatic.ShortcutKey.Paste);
            ClassHotKey.UnregisterHotKey(Handle, ClassStatic.ShortcutKey.Screenshot);
            ClassHotKey.UnregisterHotKey(Handle, ClassStatic.ShortcutKey.Color);
        }

        /// <summary>
        /// 将字符串转为按键
        /// </summary>
        /// <param name="data"></param>
        /// <param name="controlKey"></param>
        /// <param name="funcKey"></param>
        /// <returns></returns>
        private ClassStatic.ShortcutKeys GetShortcutKey(string data, ClassHotKey.KeyModifiers controlKey, Keys funcKey)
        {
            ClassHotKey.KeyModifiers key1 = controlKey;
            Keys key2 = funcKey;
            string[] tempArray = data.Replace(" ", "").Split('+');
            if (tempArray.Length == 1)
            {
                try
                {
                    key2 = (Keys)Enum.Parse(typeof(Keys), tempArray[0]);
                }
                catch { }
            }
            if (tempArray.Length > 1)
            {
                try
                {
                    key1 = (ClassHotKey.KeyModifiers)Enum.Parse(typeof(ClassHotKey.KeyModifiers), tempArray[0]);
                    key2 = (Keys)Enum.Parse(typeof(Keys), tempArray[1]);
                }
                catch {}
            }

            if (key1 != ClassHotKey.KeyModifiers.None && key1 != ClassHotKey.KeyModifiers.Ctrl && key1 != ClassHotKey.KeyModifiers.Shift && key1 != ClassHotKey.KeyModifiers.Alt)
            {
                key1 = ClassHotKey.KeyModifiers.Ctrl;
            }
            if (key2 == Keys.None)
            {
                key2 = Keys.C;
            }
            return new ClassStatic.ShortcutKeys(key1, key2);
        }

        /// <summary>
        /// 快捷键注册执行事件
        /// </summary>
        /// <param name="code"></param>
        private void ShortcutkeyHandlere(ref Message m)
        {
            switch (m.WParam.ToInt32())
            {
                case ClassStatic.ShortcutKey.Copy:
                    SendKeys.Send("^c");
                    break;
                case ClassStatic.ShortcutKey.Paste:
                    SendKeys.Send("^v");
                    break;
                case ClassStatic.ShortcutKey.Screenshot:
                    toolStripTextBox2_Click(null, null);
                    break;
                case ClassStatic.ShortcutKey.Color:
                    FormColorSelection formTemp = new FormColorSelection();
                    formTemp.ShowDialog();
                    break;
            }
        }

        /// <summary>
        /// 剪贴板内容改变事件
        /// </summary>
        private void DisplayClipboardData()
        {
            if (ClassStatic.isLogined)
            {
                if (ClassStatic.isRemoteClipboardData < 1)
                {
                    if (Clipboard.ContainsImage())
                    {
                        Action<bool, byte[]> action = new Action<bool, byte[]>(ClipboardData_Callback);
                        ClassStatic.tcpClient.Send(222,ClassStatic.GetByteImage(Clipboard.GetImage()), action);
                    }
                    if (Clipboard.ContainsText())
                    {
                        if (ClassStatic.GetConfigSoftware("parse") == "True")
                        {
                            string url = Clipboard.GetText();
                            string path = ClassStatic.GetConfigSoftware("cachePath");
                            MatchCollection mc = Regex.Matches(url, @"^http://(.*?)\.\w+$");
                            if (mc.Count > 0)
                            {
                                string filename = "";
                                try
                                {
                                    Uri uri = new Uri(url);
                                    filename = System.Web.HttpUtility.UrlDecode(uri.Segments.Last());
                                }
                                catch{}
                                if(filename!="")
                                {
                                    path += "\\" + filename;
                                    FormDownload temp = new FormDownload(url, path);
                                    temp.Show();
                                }   
                            }
                        }
                        Action<bool, byte[]> action = new Action<bool, byte[]>(ClipboardData_Callback);
                        ClassStatic.tcpClient.Send(221, ClassStatic.GetBytes(Clipboard.GetText()), action);
                    }
                    if (Clipboard.ContainsFileDropList())
                    {
                        if (Clipboard.GetFileDropList().Count == 1)
                        {
                            string file = Clipboard.GetFileDropList()[0];
                            if (File.Exists(file) == true)
                            {
                                byte[] buffur = { };
                                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                                {
                                    try
                                    {
                                        buffur = new byte[fs.Length];
                                        fs.Read(buffur, 0, (int)fs.Length);
                                    }
                                    catch (Exception ex)
                                    {
                                        throw ex;
                                    }
                                }
                                string fileName = Path.GetFileName(file);
                                Action<bool, byte[]> action = new Action<bool, byte[]>(ClipboardData_Callback);

                                List<byte> byteSource = new List<byte>();

                                byte[] fileNameByte = ClassStatic.GetBytes(fileName);
                                byte[] fileNameByteLenth = ClassStatic.GetBytes(fileNameByte.Length.ToString());
                                byteSource.AddRange(new byte[] { Convert.ToByte(fileNameByteLenth.Length) });
                                byteSource.AddRange(fileNameByteLenth);
                                byteSource.AddRange(fileNameByte);
                                byteSource.AddRange(buffur);

                                ClassStatic.tcpClient.Send(223, byteSource.ToArray(), action);
                            }
                        }
                    }
                }
                else
                {
                    ClassStatic.isRemoteClipboardData--;
                }
                
            }
        }

        /// <summary>
        /// 发送剪贴板数据
        /// </summary>
        /// <param name="state"></param>
        /// <param name="data"></param>
        private void ClipboardData_Callback(bool state, byte[] data)
        {
            
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            ChangeClipboardChain(Handle, nextClipboardViewer);
            UndoShortcutkeyHandRegister();
        }


        /// <summary>
        /// 远程发送剪贴板中含有文字
        /// </summary>
        /// <param name="state"></param>
        /// <param name="data"></param>
        public void OnOtherDriveClipboardDataTextHandler(int state, byte[] data)
        {
            if (state == 221)
            {
                this.Invoke(new Action(() => {
                    ClassStatic.isRemoteClipboardData = 2;
                    Clipboard.SetText(ClassStatic.GetString(data));
                }));
            }
            if (state == 222)
            {
                this.Invoke(new Action(() => {
                    Bitmap bmp = new Bitmap(Clipboard.GetImage());
                    string path = ClassStatic.GetConfigSoftware("cachePath");
                    if (Directory.Exists(path) == false)
                    {
                        path = System.Environment.CurrentDirectory + "\\cache";
                        Directory.CreateDirectory(path);
                        ClassStatic.SetConfigSoftware("cachePath", path);
                    }
                    path += "\\img";
                    if (Directory.Exists(path) == false)
                    {
                        Directory.CreateDirectory(path);
                    }

                    path += "\\" + DateTime.Now.ToString("yyyy-MM-dd.HHmmss") + ".png";
                    bmp.Save(path, Clipboard.GetImage().RawFormat);
                    StringCollection file = new StringCollection();
                    file.Add(path);
                    ClassStatic.isRemoteClipboardData = 2;
                    Clipboard.SetFileDropList(file);
                    bmp.Dispose();
                }));
            }
            if(state == 223)
            {
                string fileName = "";

                try
                {
                    int lenth = Convert.ToInt32(ClassStatic.GetString(data.Skip(1).Take(data[0]).ToArray()));
                    data = data.Skip(data[0] + 1).ToArray();
                    fileName = ClassStatic.GetString(data.Take(lenth).ToArray());
                    data = data.Skip(lenth).ToArray();
                }
                catch
                {

                }
                
                if (fileName != "")
                {
                    this.Invoke(new Action(() => {
                        string path = ClassStatic.GetConfigSoftware("cachePath");
                        if (Directory.Exists(path) == false)
                        {
                            path = System.Environment.CurrentDirectory + "\\cache";
                            Directory.CreateDirectory(path);
                            ClassStatic.SetConfigSoftware("cachePath", path);
                        }
                        path += "\\" + fileName;

                        System.Diagnostics.Debug.WriteLine(path);
                        FileStream fs = new FileStream(path, FileMode.Create);

                        System.Diagnostics.Debug.WriteLine(data.Length);
                        fs.Write(data, 0, data.Length);
                        fs.Close();

                        StringCollection file = new StringCollection();
                        file.Add(path);
                        ClassStatic.isRemoteClipboardData = 2;
                        Clipboard.SetFileDropList(file);
                        System.Diagnostics.Debug.WriteLine(Clipboard.GetFileDropList().Count);
                    }));
                }
            }
            if(state == 238)
            {
                this.Invoke(new Action(() =>
                {
                    FormMain.formMain.deviceList.InitializeDeviceList();
                }));
            }
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
            FormScreenshot formTemp = new FormScreenshot();
            formTemp.ShowDialog();
        }
    }
}
