using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 屏幕截图
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Image img = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
            //Graphics g = Graphics.FromImage(img);
            //g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.AllScreens[0].Bounds.Size);
            //g.Dispose();

            //FormScreenshot form = new FormScreenshot(img);
            //form.ShowDialog();
            //form.Dispose();
            //img.Dispose();
            ClassScreenshot form = new ClassScreenshot();
            form.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

    }
}
