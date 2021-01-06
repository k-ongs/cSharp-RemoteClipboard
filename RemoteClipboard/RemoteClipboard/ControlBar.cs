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
    public partial class ControlBar : UserControl
    {
        private bool closeToPallet = false;
        Point mousePoint;
        public String Title
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        public bool HideButton
        {
            get { return btn_close.Visible; }
            set {
                btn_close.Visible = value;
                btn_minimize.Visible = value;
                label1.Width = Width;
            }
        }
        public bool CloseToPallet
        {
            get { return closeToPallet; }
            set
            {
                closeToPallet = value;
            }
        }
        
        public ControlBar()
        {
            InitializeComponent();
        }

        private void ControlBar_SizeChanged(object sender, EventArgs e)
        {
            btn_close.Width = Height;
            btn_minimize.Width = Height;
        }
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mousePoint = new Point(e.X, e.Y);
            }
        }
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mouseSet = Parent.Location;
                mouseSet.Offset(e.X - mousePoint.X, e.Y - mousePoint.Y);
                Parent.Location = mouseSet;
            }
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            Control parent = Parent;
            if (parent is Form)
                (parent as Form).WindowState = FormWindowState.Minimized;
        }

        private void btn_MouseHover(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.FromArgb(255, 10, 135, 229);
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.Transparent;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            if (Parent is Form)
            {
                Form formTemp = (Form)Parent;
                // 最小化到托盘
                if (closeToPallet)
                {
                    formTemp.Hide();
                    return;
                }
                else
                {
                    formTemp.Close();
                }
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
