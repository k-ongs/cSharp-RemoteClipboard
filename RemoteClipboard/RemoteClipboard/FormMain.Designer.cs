
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
            this.statusOnlineControl1 = new RemoteClipboard.ControlStatusOnline();
            this.portraitBox1 = new RemoteClipboard.ControlPortraitBox();
            this.controlBar1 = new RemoteClipboard.ControlBar();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
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
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "远程剪贴板";
            this.notifyIcon1.Visible = true;
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
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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
    }
}