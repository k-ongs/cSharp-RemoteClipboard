
namespace 屏幕截图
{
    partial class FormScreenshot
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormScreenshot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 313);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "FormScreenshot";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FormScreenshot";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormScreenshot_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormScreenshot_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormScreenshot_KeyDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormScreenshot_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion
    }
}