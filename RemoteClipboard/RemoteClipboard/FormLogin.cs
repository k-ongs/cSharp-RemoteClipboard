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

namespace RemoteClipboard
{
    public partial class FormLogin : Form
    {
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
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text == "请输入密码")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                textBox1.Text = "请输入密码";
                textBox1.ForeColor = Color.LightGray;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text != "请输入密码")
            {
                toolTipPasswd.Visible = false;
                textBox1.ForeColor = Color.Black;
            }
            else
            {
                textBox1.ForeColor = Color.LightGray;
            }
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            toolTipPasswd.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           if(!checkBox1.Checked)
            {
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string password = textBox1.Text;
            if(password.Length < 6)
            {
                toolTipPasswd.Visible = true;
                return;
            }

            ClassStaticResources.password = textBox1.Text;
            string savePassword = checkBox1.Checked ? "true" : "false";
            string notDisturb = checkBox2.Checked ? "true" : "false";

            ClassStaticResources.SetConfig("password", textBox1.Text);
            ClassStaticResources.SetConfig("savePassword", savePassword);
            ClassStaticResources.SetConfig("notDisturb", notDisturb);

            ClassStaticResources.doNotDisturb = checkBox2.Checked;

            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            string pid = ClassStaticResources.GetConfig("portrait");
            string password = ClassStaticResources.GetConfig("password");
            string savePassword = ClassStaticResources.GetConfig("savePassword");
            string notDisturb = ClassStaticResources.GetConfig("notDisturb");

            ClassStaticResources.portraitPid = (pid == "") ? 0 : Convert.ToInt32(pid);

            portraitBox1.Portrait = ClassStaticResources.portraitPid;
            if (password.Length < 6)
            {
                savePassword = "false";
                notDisturb = "false";
            }
            else
            {
                textBox1.Text = password;
            }

            if(savePassword == "true")
            {
                checkBox1.Checked = true;
            }

            if (notDisturb == "true")
            {
                checkBox2.Checked = true;
            }
        }

    }
}
