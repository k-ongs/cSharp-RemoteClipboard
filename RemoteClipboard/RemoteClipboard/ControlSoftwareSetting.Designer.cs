
namespace RemoteClipboard
{
    partial class ControlSoftwareSetting
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
            this.label2 = new System.Windows.Forms.Label();
            this.turnOn = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cachePath = new System.Windows.Forms.TextBox();
            this.buttonChangePath = new System.Windows.Forms.Button();
            this.buttonOpenPath = new System.Windows.Forms.Button();
            this.Parsing = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textCopy = new System.Windows.Forms.TextBox();
            this.textPaste = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textScreenshot = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textColor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonChangePass = new System.Windows.Forms.Button();
            this.buttonBindQQ = new System.Windows.Forms.Button();
            this.textBindNumber = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "常规";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(5, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "按键";
            // 
            // turnOn
            // 
            this.turnOn.AutoSize = true;
            this.turnOn.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.turnOn.Location = new System.Drawing.Point(64, 40);
            this.turnOn.Name = "turnOn";
            this.turnOn.Size = new System.Drawing.Size(87, 21);
            this.turnOn.TabIndex = 2;
            this.turnOn.Text = "开机自启动";
            this.turnOn.UseVisualStyleBackColor = true;
            this.turnOn.CheckedChanged += new System.EventHandler(this.turnOn_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label3.Location = new System.Drawing.Point(60, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "绑定QQ：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label4.Location = new System.Drawing.Point(60, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "默认将缓存文件保存到此文件夹中：";
            // 
            // cachePath
            // 
            this.cachePath.Location = new System.Drawing.Point(64, 125);
            this.cachePath.Name = "cachePath";
            this.cachePath.Size = new System.Drawing.Size(298, 23);
            this.cachePath.TabIndex = 5;
            // 
            // buttonChangePath
            // 
            this.buttonChangePath.Location = new System.Drawing.Point(64, 154);
            this.buttonChangePath.Name = "buttonChangePath";
            this.buttonChangePath.Size = new System.Drawing.Size(75, 31);
            this.buttonChangePath.TabIndex = 6;
            this.buttonChangePath.Text = "更改路径";
            this.buttonChangePath.UseVisualStyleBackColor = true;
            this.buttonChangePath.Click += new System.EventHandler(this.buttonChangePath_Click);
            // 
            // buttonOpenPath
            // 
            this.buttonOpenPath.Location = new System.Drawing.Point(157, 154);
            this.buttonOpenPath.Name = "buttonOpenPath";
            this.buttonOpenPath.Size = new System.Drawing.Size(75, 31);
            this.buttonOpenPath.TabIndex = 7;
            this.buttonOpenPath.Text = "打开路径";
            this.buttonOpenPath.UseVisualStyleBackColor = true;
            this.buttonOpenPath.Click += new System.EventHandler(this.buttonOpenPath_Click);
            // 
            // Parsing
            // 
            this.Parsing.AutoSize = true;
            this.Parsing.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Parsing.Location = new System.Drawing.Point(63, 203);
            this.Parsing.Name = "Parsing";
            this.Parsing.Size = new System.Drawing.Size(159, 21);
            this.Parsing.TabIndex = 8;
            this.Parsing.Text = "允许解析剪贴板中的链接";
            this.Parsing.UseVisualStyleBackColor = true;
            this.Parsing.CheckedChanged += new System.EventHandler(this.Parsing_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label5.Location = new System.Drawing.Point(55, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "复制";
            // 
            // textCopy
            // 
            this.textCopy.Location = new System.Drawing.Point(95, 268);
            this.textCopy.Margin = new System.Windows.Forms.Padding(0);
            this.textCopy.Name = "textCopy";
            this.textCopy.ReadOnly = true;
            this.textCopy.Size = new System.Drawing.Size(100, 23);
            this.textCopy.TabIndex = 10;
            this.textCopy.TabStop = false;
            this.textCopy.DoubleClick += new System.EventHandler(this.TextShortcutKey_DoubleClick);
            this.textCopy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextShortcutKey_KeyDown);
            this.textCopy.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextShortcutKey_KeyUp);
            this.textCopy.Leave += new System.EventHandler(this.TextShortcutKey_Leave);
            // 
            // textPaste
            // 
            this.textPaste.Location = new System.Drawing.Point(262, 267);
            this.textPaste.Margin = new System.Windows.Forms.Padding(0);
            this.textPaste.Name = "textPaste";
            this.textPaste.ReadOnly = true;
            this.textPaste.Size = new System.Drawing.Size(100, 23);
            this.textPaste.TabIndex = 12;
            this.textPaste.TabStop = false;
            this.textPaste.DoubleClick += new System.EventHandler(this.TextShortcutKey_DoubleClick);
            this.textPaste.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextShortcutKey_KeyDown);
            this.textPaste.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextShortcutKey_KeyUp);
            this.textPaste.Leave += new System.EventHandler(this.TextShortcutKey_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label6.Location = new System.Drawing.Point(222, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "粘贴";
            // 
            // textScreenshot
            // 
            this.textScreenshot.Location = new System.Drawing.Point(95, 310);
            this.textScreenshot.Margin = new System.Windows.Forms.Padding(0);
            this.textScreenshot.Name = "textScreenshot";
            this.textScreenshot.ReadOnly = true;
            this.textScreenshot.Size = new System.Drawing.Size(100, 23);
            this.textScreenshot.TabIndex = 14;
            this.textScreenshot.TabStop = false;
            this.textScreenshot.DoubleClick += new System.EventHandler(this.TextShortcutKey_DoubleClick);
            this.textScreenshot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextShortcutKey_KeyDown);
            this.textScreenshot.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextShortcutKey_KeyUp);
            this.textScreenshot.Leave += new System.EventHandler(this.TextShortcutKey_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label7.Location = new System.Drawing.Point(55, 310);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "截屏";
            // 
            // textColor
            // 
            this.textColor.Location = new System.Drawing.Point(262, 309);
            this.textColor.Margin = new System.Windows.Forms.Padding(0);
            this.textColor.Name = "textColor";
            this.textColor.ReadOnly = true;
            this.textColor.Size = new System.Drawing.Size(100, 23);
            this.textColor.TabIndex = 16;
            this.textColor.TabStop = false;
            this.textColor.DoubleClick += new System.EventHandler(this.TextShortcutKey_DoubleClick);
            this.textColor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextShortcutKey_KeyDown);
            this.textColor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextShortcutKey_KeyUp);
            this.textColor.Leave += new System.EventHandler(this.TextShortcutKey_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label8.Location = new System.Drawing.Point(222, 310);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "取色";
            // 
            // buttonChangePass
            // 
            this.buttonChangePass.Location = new System.Drawing.Point(272, 30);
            this.buttonChangePass.Name = "buttonChangePass";
            this.buttonChangePass.Size = new System.Drawing.Size(90, 30);
            this.buttonChangePass.TabIndex = 17;
            this.buttonChangePass.Text = "修改密码";
            this.buttonChangePass.UseVisualStyleBackColor = true;
            this.buttonChangePass.Click += new System.EventHandler(this.buttonChangePass_Click);
            // 
            // buttonBindQQ
            // 
            this.buttonBindQQ.Location = new System.Drawing.Point(272, 64);
            this.buttonBindQQ.Name = "buttonBindQQ";
            this.buttonBindQQ.Size = new System.Drawing.Size(90, 30);
            this.buttonBindQQ.TabIndex = 18;
            this.buttonBindQQ.Text = "绑定QQ";
            this.buttonBindQQ.UseVisualStyleBackColor = true;
            this.buttonBindQQ.Click += new System.EventHandler(this.buttonBindQQ_Click);
            // 
            // textBindNumber
            // 
            this.textBindNumber.AutoSize = true;
            this.textBindNumber.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBindNumber.Location = new System.Drawing.Point(127, 71);
            this.textBindNumber.Name = "textBindNumber";
            this.textBindNumber.Size = new System.Drawing.Size(56, 17);
            this.textBindNumber.TabIndex = 19;
            this.textBindNumber.Text = "等待绑定";
            // 
            // ControlSoftwareSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.textBindNumber);
            this.Controls.Add(this.buttonBindQQ);
            this.Controls.Add(this.buttonChangePass);
            this.Controls.Add(this.textColor);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textScreenshot);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textPaste);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textCopy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Parsing);
            this.Controls.Add(this.buttonOpenPath);
            this.Controls.Add(this.buttonChangePath);
            this.Controls.Add(this.cachePath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.turnOn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(385, 370);
            this.MinimumSize = new System.Drawing.Size(385, 370);
            this.Name = "ControlSoftwareSetting";
            this.Size = new System.Drawing.Size(385, 370);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox turnOn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cachePath;
        private System.Windows.Forms.Button buttonChangePath;
        private System.Windows.Forms.Button buttonOpenPath;
        private System.Windows.Forms.CheckBox Parsing;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textCopy;
        private System.Windows.Forms.TextBox textPaste;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textScreenshot;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textColor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonChangePass;
        private System.Windows.Forms.Button buttonBindQQ;
        private System.Windows.Forms.Label textBindNumber;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}
