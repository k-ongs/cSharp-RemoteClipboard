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
    public partial class ControlStatusOnline : UserControl
    {
        private int status = 0;
        public int Status
        {
            get { return status; }
            set
            {
                status = value;
                switch(status)
                {
                    case 1:
                        label1.Text = "勿扰";
                        pictureBox1.Image = Properties.Resources.pointRed;
                        break;
                    case 2:
                        label1.Text = "离线";
                        pictureBox1.Image = Properties.Resources.pointGray;
                        break;
                    default:
                        label1.Text = "在线";
                        pictureBox1.Image = Properties.Resources.pointGreen;
                        break;
                }
            }
        }
        public ControlStatusOnline()
        {
            InitializeComponent();
        }
    }
}
