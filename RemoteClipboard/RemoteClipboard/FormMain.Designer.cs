
namespace RemoteClipboard
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.MenuNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemOnline = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemtoolStripMenuItemNoData = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusOnlineControl1 = new RemoteClipboard.ControlStatusOnline();
            this.portraitBox1 = new RemoteClipboard.ControlPortraitBox();
            this.controlBar1 = new RemoteClipboard.ControlBar();
            this.toolStripTextBox3 = new System.Windows.Forms.ToolStripTextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.MenuNotify.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.label1.Location = new System.Drawing.Point(190, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1, 385);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(205, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(385, 370);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel2.Location = new System.Drawing.Point(0, 230);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(190, 40);
            this.panel2.TabIndex = 5;
            this.panel2.Tag = "1";
            this.panel2.Click += new System.EventHandler(this.MenuButtn_Click);
            this.panel2.MouseLeave += new System.EventHandler(this.MenuButtn_MouseLeave);
            this.panel2.MouseHover += new System.EventHandler(this.MenuButtn_MouseHover);
            // 
            // label2
            // 
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(85, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 40);
            this.label2.TabIndex = 1;
            this.label2.Text = "设备列表";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Click += new System.EventHandler(this.MenuButtn_Click);
            this.label2.MouseLeave += new System.EventHandler(this.MenuButtn_MouseLeave);
            this.label2.MouseHover += new System.EventHandler(this.MenuButtn_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Image = global::RemoteClipboard.Properties.Resources.device;
            this.pictureBox1.Location = new System.Drawing.Point(40, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel3.Location = new System.Drawing.Point(0, 276);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(190, 40);
            this.panel3.TabIndex = 6;
            this.panel3.Tag = "2";
            this.panel3.Click += new System.EventHandler(this.MenuButtn_Click);
            this.panel3.MouseLeave += new System.EventHandler(this.MenuButtn_MouseLeave);
            this.panel3.MouseHover += new System.EventHandler(this.MenuButtn_MouseHover);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(85, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 40);
            this.label3.TabIndex = 1;
            this.label3.Text = "软件设置";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Click += new System.EventHandler(this.MenuButtn_Click);
            this.label3.MouseLeave += new System.EventHandler(this.MenuButtn_MouseLeave);
            this.label3.MouseHover += new System.EventHandler(this.MenuButtn_MouseHover);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Enabled = false;
            this.pictureBox2.Image = global::RemoteClipboard.Properties.Resources.setting;
            this.pictureBox2.Location = new System.Drawing.Point(40, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.MenuNotify;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "远程剪贴板";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // MenuNotify
            // 
            this.MenuNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOnline,
            this.toolStripMenuItemtoolStripMenuItemNoData,
            this.toolStripTextBox2,
            this.toolStripSeparator1,
            this.toolStripTextBox1,
            this.toolStripSeparator3,
            this.退出ToolStripMenuItem});
            this.MenuNotify.Name = "MenuNotify";
            this.MenuNotify.Size = new System.Drawing.Size(137, 174);
            // 
            // toolStripMenuItemOnline
            // 
            this.toolStripMenuItemOnline.Margin = new System.Windows.Forms.Padding(1, 5, 1, 5);
            this.toolStripMenuItemOnline.Name = "toolStripMenuItemOnline";
            this.toolStripMenuItemOnline.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItemOnline.Text = "在线";
            this.toolStripMenuItemOnline.Click += new System.EventHandler(this.toolStripMenuItemOnline_Click);
            // 
            // toolStripMenuItemtoolStripMenuItemNoData
            // 
            this.toolStripMenuItemtoolStripMenuItemNoData.Margin = new System.Windows.Forms.Padding(1, 5, 1, 5);
            this.toolStripMenuItemtoolStripMenuItemNoData.Name = "toolStripMenuItemtoolStripMenuItemNoData";
            this.toolStripMenuItemtoolStripMenuItemNoData.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItemtoolStripMenuItemNoData.Text = "勿扰";
            this.toolStripMenuItemtoolStripMenuItemNoData.Click += new System.EventHandler(this.toolStripMenuItemtoolStripMenuItemNoData_Click);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Margin = new System.Windows.Forms.Padding(1, 5, 1, 5);
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(136, 22);
            this.toolStripTextBox2.Text = "截屏";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Margin = new System.Windows.Forms.Padding(1, 5, 1, 5);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(136, 22);
            this.toolStripTextBox1.Text = "打开主界面";
            this.toolStripTextBox1.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(133, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.退出ToolStripMenuItem.ShowShortcutKeys = false;
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(136, 20);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // statusOnlineControl1
            // 
            this.statusOnlineControl1.BackColor = System.Drawing.Color.Transparent;
            this.statusOnlineControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.statusOnlineControl1.Location = new System.Drawing.Point(12, 396);
            this.statusOnlineControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.statusOnlineControl1.MaximumSize = new System.Drawing.Size(54, 18);
            this.statusOnlineControl1.MinimumSize = new System.Drawing.Size(54, 18);
            this.statusOnlineControl1.Name = "statusOnlineControl1";
            this.statusOnlineControl1.Size = new System.Drawing.Size(54, 18);
            this.statusOnlineControl1.Status = 0;
            this.statusOnlineControl1.TabIndex = 4;
            // 
            // portraitBox1
            // 
            this.portraitBox1.BackColor = System.Drawing.Color.Transparent;
            this.portraitBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.portraitBox1.Location = new System.Drawing.Point(45, 77);
            this.portraitBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.portraitBox1.Name = "portraitBox1";
            this.portraitBox1.Portrait = 0;
            this.portraitBox1.ReplaceImage = true;
            this.portraitBox1.Size = new System.Drawing.Size(100, 100);
            this.portraitBox1.TabIndex = 2;
            // 
            // controlBar1
            // 
            this.controlBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(158)))), ((int)(((byte)(247)))));
            this.controlBar1.CloseToPallet = true;
            this.controlBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlBar1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.controlBar1.ForeColor = System.Drawing.Color.White;
            this.controlBar1.HideButton = true;
            this.controlBar1.Location = new System.Drawing.Point(0, 0);
            this.controlBar1.Margin = new System.Windows.Forms.Padding(0);
            this.controlBar1.Name = "controlBar1";
            this.controlBar1.Size = new System.Drawing.Size(590, 35);
            this.controlBar1.TabIndex = 0;
            this.controlBar1.Title = "远程剪贴板";
            // 
            // toolStripTextBox3
            // 
            this.toolStripTextBox3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.toolStripTextBox3.Name = "toolStripTextBox3";
            this.toolStripTextBox3.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox3.Text = "退出程序";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(590, 420);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusOnlineControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.portraitBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.controlBar1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(590, 420);
            this.MinimumSize = new System.Drawing.Size(590, 420);
            this.Name = "FormMain";
            this.Text = "远程剪贴板";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.MenuNotify.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlBar controlBar1;
        private System.Windows.Forms.Label label1;
        private ControlPortraitBox portraitBox1;
        private System.Windows.Forms.Panel panel1;
        private ControlStatusOnline statusOnlineControl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip MenuNotify;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOnline;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemtoolStripMenuItemNoData;
        private System.Windows.Forms.ToolStripMenuItem toolStripTextBox2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox3;
        private System.Windows.Forms.ToolStripMenuItem toolStripTextBox1;
    }
}