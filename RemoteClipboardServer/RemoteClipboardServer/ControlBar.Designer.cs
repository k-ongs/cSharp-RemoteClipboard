
namespace RemoteClipboardServer
{
    partial class ControlBar
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btn_minimize = new System.Windows.Forms.PictureBox();
            this.btn_close = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoEllipsis = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(226, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "标题";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            // 
            // btn_minimize
            // 
            this.btn_minimize.BackColor = System.Drawing.Color.Transparent;
            this.btn_minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_minimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_minimize.Image = global::RemoteClipboardServer.Properties.Resources.minimize;
            this.btn_minimize.Location = new System.Drawing.Point(230, 0);
            this.btn_minimize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_minimize.Name = "btn_minimize";
            this.btn_minimize.Size = new System.Drawing.Size(35, 35);
            this.btn_minimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btn_minimize.TabIndex = 2;
            this.btn_minimize.TabStop = false;
            this.btn_minimize.Click += new System.EventHandler(this.btn_minimize_Click);
            this.btn_minimize.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btn_minimize.MouseHover += new System.EventHandler(this.btn_MouseHover);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_close.Image = global::RemoteClipboardServer.Properties.Resources.close;
            this.btn_close.Location = new System.Drawing.Point(265, 0);
            this.btn_close.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(35, 35);
            this.btn_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btn_close.TabIndex = 1;
            this.btn_close.TabStop = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            this.btn_close.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btn_close.MouseHover += new System.EventHandler(this.btn_MouseHover);
            // 
            // ControlBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(158)))), ((int)(((byte)(247)))));
            this.Controls.Add(this.btn_minimize);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ControlBar";
            this.Size = new System.Drawing.Size(300, 35);
            this.SizeChanged += new System.EventHandler(this.ControlBar_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btn_close;
        private System.Windows.Forms.PictureBox btn_minimize;
    }
}
