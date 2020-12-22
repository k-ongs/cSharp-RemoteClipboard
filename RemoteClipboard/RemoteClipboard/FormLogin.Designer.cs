
namespace RemoteClipboard
{
    partial class FormLogin
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.portraitBox1 = new RemoteClipboard.ControlPortraitBox();
            this.controlBar1 = new RemoteClipboard.ControlBar();
            this.toolTipPasswd = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.toolTipPasswd.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(158)))), ((int)(((byte)(247)))));
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(31, 333);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "确  定";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.ForeColor = System.Drawing.Color.DarkGray;
            this.checkBox1.Location = new System.Drawing.Point(35, 285);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 21);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "记住密码";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label2.Location = new System.Drawing.Point(31, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 2);
            this.label2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label3.Location = new System.Drawing.Point(77, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(2, 20);
            this.label3.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(37, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "密码";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.textBox1.ForeColor = System.Drawing.Color.LightGray;
            this.textBox1.Location = new System.Drawing.Point(85, 252);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(206, 18);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "请输入密码";
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox2.ForeColor = System.Drawing.Color.DarkGray;
            this.checkBox2.Location = new System.Drawing.Point(144, 285);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(72, 21);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "请勿打扰";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // portraitBox1
            // 
            this.portraitBox1.BackColor = System.Drawing.Color.Transparent;
            this.portraitBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.portraitBox1.Location = new System.Drawing.Point(106, 94);
            this.portraitBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.portraitBox1.Name = "portraitBox1";
            this.portraitBox1.Portrait = 0;
            this.portraitBox1.ReplaceImage = true;
            this.portraitBox1.Size = new System.Drawing.Size(110, 110);
            this.portraitBox1.TabIndex = 9;
            // 
            // controlBar1
            // 
            this.controlBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(158)))), ((int)(((byte)(247)))));
            this.controlBar1.CloseToPallet = false;
            this.controlBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlBar1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.controlBar1.ForeColor = System.Drawing.Color.White;
            this.controlBar1.HideButton = true;
            this.controlBar1.Location = new System.Drawing.Point(0, 0);
            this.controlBar1.Margin = new System.Windows.Forms.Padding(0);
            this.controlBar1.Name = "controlBar1";
            this.controlBar1.Size = new System.Drawing.Size(322, 35);
            this.controlBar1.TabIndex = 8;
            this.controlBar1.Title = "远程剪贴板";
            // 
            // toolTipPasswd
            // 
            this.toolTipPasswd.BackgroundImage = global::RemoteClipboard.Properties.Resources.toolTip;
            this.toolTipPasswd.Controls.Add(this.label5);
            this.toolTipPasswd.Location = new System.Drawing.Point(76, 216);
            this.toolTipPasswd.MaximumSize = new System.Drawing.Size(160, 33);
            this.toolTipPasswd.MinimumSize = new System.Drawing.Size(160, 33);
            this.toolTipPasswd.Name = "toolTipPasswd";
            this.toolTipPasswd.Size = new System.Drawing.Size(160, 33);
            this.toolTipPasswd.TabIndex = 12;
            this.toolTipPasswd.Visible = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label5.ForeColor = System.Drawing.Color.DarkGray;
            this.label5.Location = new System.Drawing.Point(3, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "密码长度必须超过6位！";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(322, 400);
            this.Controls.Add(this.toolTipPasswd);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.portraitBox1);
            this.Controls.Add(this.controlBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(322, 400);
            this.MinimumSize = new System.Drawing.Size(322, 400);
            this.Name = "FormLogin";
            this.Text = "远程剪贴板";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.toolTipPasswd.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ControlBar controlBar1;
        private ControlPortraitBox portraitBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Panel toolTipPasswd;
        private System.Windows.Forms.Label label5;
    }
}

