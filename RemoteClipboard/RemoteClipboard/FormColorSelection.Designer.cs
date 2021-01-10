
namespace RemoteClipboard
{
    partial class FormColorSelection
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormColorSelection));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.getRGBItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getHSBItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getHexItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(350, 185);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(100, 80);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getRGBItem,
            this.getHSBItem,
            this.getHexItem,
            this.toolStripMenuItemClose});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(150, 132);
            // 
            // getRGBItem
            // 
            this.getRGBItem.Checked = true;
            this.getRGBItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.getRGBItem.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.getRGBItem.Name = "getRGBItem";
            this.getRGBItem.Size = new System.Drawing.Size(149, 22);
            this.getRGBItem.Text = "获取RGB格式";
            this.getRGBItem.Click += new System.EventHandler(this.getRGBItem_Click);
            // 
            // getHSBItem
            // 
            this.getHSBItem.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.getHSBItem.Name = "getHSBItem";
            this.getHSBItem.Size = new System.Drawing.Size(149, 22);
            this.getHSBItem.Text = "获取HSB格式";
            this.getHSBItem.Click += new System.EventHandler(this.getHSBItem_Click);
            // 
            // getHexItem
            // 
            this.getHexItem.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.getHexItem.Name = "getHexItem";
            this.getHexItem.Size = new System.Drawing.Size(149, 22);
            this.getHexItem.Text = "获取十六进制";
            this.getHexItem.Click += new System.EventHandler(this.getHexItem_Click);
            // 
            // toolStripMenuItemClose
            // 
            this.toolStripMenuItemClose.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.toolStripMenuItemClose.Name = "toolStripMenuItemClose";
            this.toolStripMenuItemClose.Size = new System.Drawing.Size(149, 22);
            this.toolStripMenuItemClose.Text = "退出";
            this.toolStripMenuItemClose.Click += new System.EventHandler(this.toolStripMenuItemClose_Click);
            // 
            // FormColorSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FormColorSelection";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FormColorSelection";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormColorSelection_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormColorSelection_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormColorSelection_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem getRGBItem;
        private System.Windows.Forms.ToolStripMenuItem getHSBItem;
        private System.Windows.Forms.ToolStripMenuItem getHexItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClose;
    }
}