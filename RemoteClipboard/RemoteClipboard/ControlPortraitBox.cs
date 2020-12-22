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
    public partial class ControlPortraitBox : UserControl
    {
        private int pid = 0;
        public int Portrait
        {
            get { return pid; }
            set {
                pid = (value < 12 && value > -1) ? value : 0;
                pictureBox9.Image = ClassStaticResources.GetPortraitImage(pid);
            }
        }
        public bool ReplaceImage
        {
            get { return pictureBox10.Visible; }
            set { pictureBox10.Visible = value; }
        }
        public ControlPortraitBox()
        {
            InitializeComponent();
            pictureBox10.Parent = pictureBox9;
            pictureBox10.Dock = DockStyle.Fill;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            FormImageChange formTemp = new FormImageChange(this);
            formTemp.StartPosition = FormStartPosition.CenterParent;
            formTemp.ShowDialog();
            formTemp.Dispose();
        }
    }
}
