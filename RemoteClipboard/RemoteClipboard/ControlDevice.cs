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
    public partial class ControlDevice : UserControl
    {
        private bool oneself = false;
        private string deviceId = "";
        public string Mac
        {
            get { return labelMac.Text; }
            set { labelMac.Text = value; }
        }
        public string Title
        {
            get { return labelName.Text; }
            set { labelName.Text = value; }
        }
        public int Status
        {
            get { return controlStatusOnline.Status; }
            set { controlStatusOnline.Status = value; }
        }
        public int Portrait
        {
            get { return controlPortraitBox.Portrait; }
            set { controlPortraitBox.Portrait = value; }
        }
        public bool Oneself
        {
            get { return oneself; }
            set
            {
                oneself = value;
                if(oneself)
                {
                    ContextMenuStrip = null;
                }
                if(oneself) BackColor = Color.FromArgb(245, 245, 245);
            }
        }
        public string DeviceId
        {
            get { return deviceId; }
            set { deviceId = value; }
        }

        public ControlDevice()
        {
            InitializeComponent();
            //contextMenuStrip
        }

        private void ControlDevice_MouseHover(object sender, EventArgs e)
        {
            if (!Oneself) BackColor = Color.FromArgb(245, 245, 245);
        }

        private void ControlDevice_MouseLeave(object sender, EventArgs e)
        {
            if(!Oneself) BackColor = Color.White;
        }
    }
}
