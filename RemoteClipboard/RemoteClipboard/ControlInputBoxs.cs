using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteClipboard
{
    public partial class ControlInputBoxs : UserControl
    {
        private string textTips = "提示信息";
        public string Tips
        {
            get { return textTips; }
            set { textTips = value; textBox1.Text = value; }
        }
        public string Value => textBox1.Text;

        public ControlInputBoxs()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == textTips)
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = textTips;
                textBox1.ForeColor = Color.LightGray;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text != textTips)
            {
                textBox1.ForeColor = Color.Black;
            }
            else
            {
                textBox1.ForeColor = Color.LightGray;
            }
        }
    }
}
