using System;
using System.Drawing;
using System.Windows.Forms;

namespace RemoteClipboard
{
    class ControlInputBox : TextBox
    {
        private bool password = false;
        private string textTips = "提示信息";
        public string Tips
        {
            get { return textTips; }
            set { textTips = value; Text = value; }
        }
        public bool IsPassword
        {
            get { return password; }
            set { password = value; }
        }

        public ControlInputBox()
        {
            Enter += textBox_Enter;
            Leave += textBox_Leave;
            TextChanged += textBox_TextChanged;
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            if (Text == textTips)
            {
                Text = "";
                ForeColor = Color.Black;
            }
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            if (Text == "")
            {
                Text = textTips;
                ForeColor = Color.LightGray;
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (Text != "" && Text != textTips)
            {
                if (password)
                    this.UseSystemPasswordChar = true;
                ForeColor = Color.Black;
            }
            else
            {
                ForeColor = Color.LightGray;
                this.UseSystemPasswordChar = false;
            }
        }

        // 重写键盘事件OnKeyPress()
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (!password && !char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
                return;
            }
        }
        // 重写命令键处理方法ProcessCmdKey()
        protected override void WndProc(ref Message m)
        {
            if (m.Msg != 0x007B)
            {
                base.WndProc(ref m);
            }
        }
    }
}
