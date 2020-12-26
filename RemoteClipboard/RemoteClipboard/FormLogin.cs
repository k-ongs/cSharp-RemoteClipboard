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

namespace RemoteClipboard
{
    public partial class FormLogin : Form
    {
        private int timerTipsNum = 3;
        public static FormLogin formLogin;
        private Login.ControlPassLogin controlPassLogin = new Login.ControlPassLogin();
        private Login.ControlScanLogin controlScanLogin = new Login.ControlScanLogin();
        private Login.ControlRegister controlRegister = new Login.ControlRegister();
        private Login.ControlForgetPass controlForgetPass = new Login.ControlForgetPass();
        

        public Animation animation = new Animation(10);
        #region 绘制窗体阴影
        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

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

        private const int WM_NCHITTEST = 0x84;          // variables for dragging the form
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

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
                default:
                    break;
            }
            base.WndProc(ref m);
        }
        #endregion
        public FormLogin()
        {
            formLogin = this;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            if(!ClassStaticResources.isConnected)
            {
                labelTips.Text = "您的网络异常，请先检查网络。";
                labelTips.Visible = true;
            }
        }

        /// <summary>
        /// 窗体加载初始化参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            labelSwitch_Click(labelPass, null);
            controlScanLogin.Location = new Point(-260,0);
            controlRegister.Location = new Point(260, 0);
            controlForgetPass.Location = new Point(260, 0);
            panelShow.Controls.Add(controlPassLogin);
            panelShow.Controls.Add(controlScanLogin);
            panelShow.Controls.Add(controlRegister);
            panelShow.Controls.Add(controlForgetPass);

            animation.Add(controlScanLogin);
            animation.Add(controlPassLogin);
            animation.Add(controlRegister);
            animation.Add(controlForgetPass);

            animation.Index = 1;
        }

        /// <summary>
        /// 菜单切换按钮重绘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelSwitch_Paint(object sender, PaintEventArgs e)
        {
            Label that = sender as Label;
            Graphics graphics = e == null ? that.CreateGraphics() : e.Graphics;
            Pen pen = that.Tag == null ? new Pen(Color.FromArgb(240, 240, 240)) : new Pen(Color.FromArgb(31, 148, 247));
            graphics.DrawLine(pen, 0, that.Height - 1, that.Width, that.Height - 1);
            if (e == null) graphics.Dispose();
        }

        /// <summary>
        /// 菜单切换按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelSwitch_Click(object sender, EventArgs e)
        {
            Label that = sender as Label;
            if (that.Tag == null)
            {
                that.Tag = true;
                if (that == labelScan)
                {
                    animation.Start(0);
                    labelPass.Tag = null;
                }
                else
                {
                    animation.Start(1);
                    labelScan.Tag = null;
                }
                labelSwitch_Paint(labelPass, null);
                labelSwitch_Paint(labelScan, null);
            }
        }

        /// <summary>
        /// 显示错误提示信息
        /// </summary>
        /// <param name="msg">提示信息</param>
        public void TipsShow(string msg)
        {
            labelTips.Tag = msg;
            labelTips.Text = msg + "(" + timerTipsNum + ")";
            labelTips.Visible = true;
            timerTips.Start();
        }

        public void SwitchHide()
        {
            flowLayoutPanel1.Visible = false;
        }
        public void SwitchShow()
        {
            flowLayoutPanel1.Visible = true;
        }

        /// <summary>
        /// 显示控件切换动画
        /// </summary>
        public class Animation : Timer
        {
            // 当前选中控件的下标
            int index = 0;
            // 动画任务队列
            Queue taskList = new Queue();
            // 控件列表
            Dictionary<int, Control> controlList = new Dictionary<int, Control>();

            public int Index
            {
                get { return index; }
                set { 
                    if(value > -1 && value < controlList.Count)
                    {
                        index = value;
                    }
                }
            }
            public Animation(int speed)
            {
                this.Interval = speed;
                this.Tick += Animation_Tick;
            }
            /// <summary>
            /// 添加控件
            /// </summary>
            /// <param name="control"></param>
            public void Add(Control control)
            {
                controlList.Add(controlList.Count, control);
            }
            /// <summary>
            /// 切换控件至指定id控件
            /// </summary>
            /// <param name="i"></param>
            public void Start(int i)
            {
                if (controlList.ContainsKey(i) && controlList.Count > 1)
                {
                    taskList.Enqueue(i);
                    if (this.Enabled == false)
                    {
                        this.Start();
                    }
                }
            }
            /// <summary>
            /// 计时器事件
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void Animation_Tick(object sender, EventArgs e)
            {
                if(controlList.Count > 1 && taskList.Count > 0 && index != Convert.ToInt32(taskList.Peek()))
                {
                    // 获取控件宽度
                    int width = controlList[index].Width;
                    // 获取将要移入的目标下标
                    int targetId = Convert.ToInt32(taskList.Peek());

                    // 判断是否第一次，初始化目标位置
                    if (controlList[index].Location.X == 0)
                    {
                        // 从右往左移入
                        if (targetId > index)
                        {
                            controlList[targetId].Location = new Point(width, 0);
                        }
                        else
                        {
                            controlList[targetId].Location = new Point(-width, 0);
                        }
                    }
                    // 设置偏移量
                    int offset = (targetId > index) ? -15 : 15;
                    int x1 = controlList[index].Location.X + offset;
                    int x2 = controlList[targetId].Location.X + offset;

                    // 防止控件移出窗体
                    if (targetId > index)
                    {
                        x2 = x2 < 0 ? 0 : x2;
                    }else
                    {
                        x2 = x2 > 0 ? 0 : x2;
                    }
                    controlList[index].Location = new Point(x1, 0);
                    controlList[targetId].Location = new Point(x2, 0);

                    // 移动完毕，更改当前显示ID，并将此ID移出队列
                    if (x2 == 0)
                    {
                        index = Convert.ToInt32(taskList.Dequeue());
                    }
                }
                else
                {
                    Stop();
                }
            }
        }

        private void timerTips_Tick(object sender, EventArgs e)
        {
            if (timerTipsNum == 0)
            {
                timerTipsNum = 3;
                timerTips.Stop();
                labelTips.Visible = false;
            }
            string msg = labelTips.Tag.ToString();
            labelTips.Text = msg + "(" + (--timerTipsNum) + ")";
        }
    }
}
