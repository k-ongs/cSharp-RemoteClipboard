
namespace RemoteClipboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormScreenshot));
            this.colorPanel = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelColor1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.colorActive = new System.Windows.Forms.PictureBox();
            this.ponitc = new System.Windows.Forms.PictureBox();
            this.ponitb = new System.Windows.Forms.PictureBox();
            this.ponita = new System.Windows.Forms.PictureBox();
            this.toolbarPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.PictureBox();
            this.buttonFinish = new System.Windows.Forms.Label();
            this.brush = new System.Windows.Forms.PictureBox();
            this.circular = new System.Windows.Forms.PictureBox();
            this.rectangle = new System.Windows.Forms.PictureBox();
            this.colorPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ponitc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ponitb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ponita)).BeginInit();
            this.toolbarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brush)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circular)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rectangle)).BeginInit();
            this.SuspendLayout();
            // 
            // colorPanel
            // 
            this.colorPanel.Controls.Add(this.flowLayoutPanel1);
            this.colorPanel.Controls.Add(this.colorActive);
            this.colorPanel.Controls.Add(this.ponitc);
            this.colorPanel.Controls.Add(this.ponitb);
            this.colorPanel.Controls.Add(this.ponita);
            this.colorPanel.Location = new System.Drawing.Point(12, 69);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(200, 30);
            this.colorPanel.TabIndex = 3;
            this.colorPanel.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labelColor1);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.label7);
            this.flowLayoutPanel1.Controls.Add(this.label8);
            this.flowLayoutPanel1.Controls.Add(this.label9);
            this.flowLayoutPanel1.Controls.Add(this.label10);
            this.flowLayoutPanel1.Controls.Add(this.label11);
            this.flowLayoutPanel1.Controls.Add(this.label12);
            this.flowLayoutPanel1.Controls.Add(this.label13);
            this.flowLayoutPanel1.Controls.Add(this.label14);
            this.flowLayoutPanel1.Controls.Add(this.label15);
            this.flowLayoutPanel1.Controls.Add(this.label16);
            this.flowLayoutPanel1.Controls.Add(this.label17);
            this.flowLayoutPanel1.Controls.Add(this.label18);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(105, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(90, 24);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // labelColor1
            // 
            this.labelColor1.BackColor = System.Drawing.Color.Black;
            this.labelColor1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelColor1.Location = new System.Drawing.Point(1, 1);
            this.labelColor1.Margin = new System.Windows.Forms.Padding(1);
            this.labelColor1.Name = "labelColor1";
            this.labelColor1.Size = new System.Drawing.Size(9, 9);
            this.labelColor1.TabIndex = 0;
            this.labelColor1.Click += new System.EventHandler(this.ColorColorChange_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Gray;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Location = new System.Drawing.Point(12, 1);
            this.label4.Margin = new System.Windows.Forms.Padding(1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(9, 9);
            this.label4.TabIndex = 1;
            this.label4.Click += new System.EventHandler(this.ColorColorChange_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.Location = new System.Drawing.Point(23, 1);
            this.label5.Margin = new System.Windows.Forms.Padding(1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(9, 9);
            this.label5.TabIndex = 2;
            this.label5.Click += new System.EventHandler(this.ColorColorChange_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.Location = new System.Drawing.Point(34, 1);
            this.label6.Margin = new System.Windows.Forms.Padding(1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(9, 9);
            this.label6.TabIndex = 3;
            this.label6.Click += new System.EventHandler(this.ColorColorChange_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Green;
            this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label7.Location = new System.Drawing.Point(45, 1);
            this.label7.Margin = new System.Windows.Forms.Padding(1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(9, 9);
            this.label7.TabIndex = 4;
            this.label7.Click += new System.EventHandler(this.ColorColorChange_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Blue;
            this.label8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label8.Location = new System.Drawing.Point(56, 1);
            this.label8.Margin = new System.Windows.Forms.Padding(1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(9, 9);
            this.label8.TabIndex = 5;
            this.label8.Click += new System.EventHandler(this.ColorColorChange_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Purple;
            this.label9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label9.Location = new System.Drawing.Point(67, 1);
            this.label9.Margin = new System.Windows.Forms.Padding(1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(9, 9);
            this.label9.TabIndex = 6;
            this.label9.Click += new System.EventHandler(this.ColorColorChange_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Teal;
            this.label10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label10.Location = new System.Drawing.Point(78, 1);
            this.label10.Margin = new System.Windows.Forms.Padding(1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(9, 9);
            this.label10.TabIndex = 7;
            this.label10.Click += new System.EventHandler(this.ColorColorChange_Click);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label11.Location = new System.Drawing.Point(1, 12);
            this.label11.Margin = new System.Windows.Forms.Padding(1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(9, 9);
            this.label11.TabIndex = 8;
            this.label11.Click += new System.EventHandler(this.ColorColorChange_Click);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Silver;
            this.label12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label12.Location = new System.Drawing.Point(12, 12);
            this.label12.Margin = new System.Windows.Forms.Padding(1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(9, 9);
            this.label12.TabIndex = 9;
            this.label12.Click += new System.EventHandler(this.ColorColorChange_Click);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Red;
            this.label13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label13.Location = new System.Drawing.Point(23, 12);
            this.label13.Margin = new System.Windows.Forms.Padding(1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(9, 9);
            this.label13.TabIndex = 10;
            this.label13.Click += new System.EventHandler(this.ColorColorChange_Click);
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Yellow;
            this.label14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label14.Location = new System.Drawing.Point(34, 12);
            this.label14.Margin = new System.Windows.Forms.Padding(1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(9, 9);
            this.label14.TabIndex = 11;
            this.label14.Click += new System.EventHandler(this.ColorColorChange_Click);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.GreenYellow;
            this.label15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label15.Location = new System.Drawing.Point(45, 12);
            this.label15.Margin = new System.Windows.Forms.Padding(1);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(9, 9);
            this.label15.TabIndex = 12;
            this.label15.Click += new System.EventHandler(this.ColorColorChange_Click);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Aqua;
            this.label16.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label16.Location = new System.Drawing.Point(56, 12);
            this.label16.Margin = new System.Windows.Forms.Padding(1);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(9, 9);
            this.label16.TabIndex = 13;
            this.label16.Click += new System.EventHandler(this.ColorColorChange_Click);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Fuchsia;
            this.label17.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label17.Location = new System.Drawing.Point(67, 12);
            this.label17.Margin = new System.Windows.Forms.Padding(1);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(9, 9);
            this.label17.TabIndex = 14;
            this.label17.Click += new System.EventHandler(this.ColorColorChange_Click);
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label18.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label18.Location = new System.Drawing.Point(78, 12);
            this.label18.Margin = new System.Windows.Forms.Padding(1);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(9, 9);
            this.label18.TabIndex = 15;
            this.label18.Click += new System.EventHandler(this.ColorColorChange_Click);
            // 
            // colorActive
            // 
            this.colorActive.BackColor = System.Drawing.Color.Red;
            this.colorActive.Location = new System.Drawing.Point(81, 5);
            this.colorActive.Name = "colorActive";
            this.colorActive.Size = new System.Drawing.Size(20, 20);
            this.colorActive.TabIndex = 3;
            this.colorActive.TabStop = false;
            // 
            // ponitc
            // 
            this.ponitc.BackgroundImage = global::RemoteClipboard.Properties.Resources.draw_ponitcpng;
            this.ponitc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ponitc.Location = new System.Drawing.Point(56, 5);
            this.ponitc.Name = "ponitc";
            this.ponitc.Size = new System.Drawing.Size(20, 20);
            this.ponitc.TabIndex = 2;
            this.ponitc.TabStop = false;
            this.ponitc.Tag = "8";
            this.ponitc.Click += new System.EventHandler(this.ColorSizePonit_Click);
            // 
            // ponitb
            // 
            this.ponitb.BackgroundImage = global::RemoteClipboard.Properties.Resources.draw_ponitb;
            this.ponitb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ponitb.Location = new System.Drawing.Point(31, 5);
            this.ponitb.Name = "ponitb";
            this.ponitb.Size = new System.Drawing.Size(20, 20);
            this.ponitb.TabIndex = 1;
            this.ponitb.TabStop = false;
            this.ponitb.Tag = "4";
            this.ponitb.Click += new System.EventHandler(this.ColorSizePonit_Click);
            // 
            // ponita
            // 
            this.ponita.BackgroundImage = global::RemoteClipboard.Properties.Resources.draw_ponita;
            this.ponita.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ponita.Location = new System.Drawing.Point(6, 5);
            this.ponita.Name = "ponita";
            this.ponita.Size = new System.Drawing.Size(20, 20);
            this.ponita.TabIndex = 0;
            this.ponita.TabStop = false;
            this.ponita.Tag = "2";
            this.ponita.Click += new System.EventHandler(this.ColorSizePonit_Click);
            // 
            // toolbarPanel
            // 
            this.toolbarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(236)))), ((int)(((byte)(245)))));
            this.toolbarPanel.Controls.Add(this.label3);
            this.toolbarPanel.Controls.Add(this.label2);
            this.toolbarPanel.Controls.Add(this.close);
            this.toolbarPanel.Controls.Add(this.buttonFinish);
            this.toolbarPanel.Controls.Add(this.brush);
            this.toolbarPanel.Controls.Add(this.circular);
            this.toolbarPanel.Controls.Add(this.rectangle);
            this.toolbarPanel.Location = new System.Drawing.Point(12, 12);
            this.toolbarPanel.Name = "toolbarPanel";
            this.toolbarPanel.Size = new System.Drawing.Size(220, 30);
            this.toolbarPanel.TabIndex = 2;
            this.toolbarPanel.Visible = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(151, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1, 10);
            this.label3.TabIndex = 8;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(148, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
            // 
            // close
            // 
            this.close.BackgroundImage = global::RemoteClipboard.Properties.Resources.draw_close;
            this.close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close.Location = new System.Drawing.Point(160, 5);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(20, 20);
            this.close.TabIndex = 6;
            this.close.TabStop = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // buttonFinish
            // 
            this.buttonFinish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFinish.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonFinish.Location = new System.Drawing.Point(180, 0);
            this.buttonFinish.Name = "buttonFinish";
            this.buttonFinish.Size = new System.Drawing.Size(40, 30);
            this.buttonFinish.TabIndex = 5;
            this.buttonFinish.Text = "完成";
            this.buttonFinish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonFinish.Click += new System.EventHandler(this.buttonFinish_Click);
            // 
            // brush
            // 
            this.brush.BackgroundImage = global::RemoteClipboard.Properties.Resources.draw_brush;
            this.brush.Cursor = System.Windows.Forms.Cursors.Hand;
            this.brush.Location = new System.Drawing.Point(78, 5);
            this.brush.Name = "brush";
            this.brush.Size = new System.Drawing.Size(20, 20);
            this.brush.TabIndex = 3;
            this.brush.TabStop = false;
            this.brush.Click += new System.EventHandler(this.ToolbarPanelControl_Click);
            // 
            // circular
            // 
            this.circular.BackgroundImage = global::RemoteClipboard.Properties.Resources.draw_circular;
            this.circular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.circular.Location = new System.Drawing.Point(41, 5);
            this.circular.Name = "circular";
            this.circular.Size = new System.Drawing.Size(20, 20);
            this.circular.TabIndex = 1;
            this.circular.TabStop = false;
            this.circular.Click += new System.EventHandler(this.ToolbarPanelControl_Click);
            // 
            // rectangle
            // 
            this.rectangle.BackgroundImage = global::RemoteClipboard.Properties.Resources.draw_rectangle;
            this.rectangle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rectangle.Location = new System.Drawing.Point(6, 5);
            this.rectangle.Name = "rectangle";
            this.rectangle.Size = new System.Drawing.Size(20, 20);
            this.rectangle.TabIndex = 0;
            this.rectangle.TabStop = false;
            this.rectangle.Click += new System.EventHandler(this.ToolbarPanelControl_Click);
            // 
            // FormScreenshot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.colorPanel);
            this.Controls.Add(this.toolbarPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FormScreenshot";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FormScreenshot";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormScreenshot_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormScreenshot_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormScreenshot_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormScreenshot_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormScreenshot_MouseUp);
            this.colorPanel.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colorActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ponitc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ponitb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ponita)).EndInit();
            this.toolbarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brush)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circular)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rectangle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel colorPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelColor1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.PictureBox colorActive;
        private System.Windows.Forms.PictureBox ponitc;
        private System.Windows.Forms.PictureBox ponitb;
        private System.Windows.Forms.PictureBox ponita;
        private System.Windows.Forms.Panel toolbarPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox close;
        private System.Windows.Forms.Label buttonFinish;
        private System.Windows.Forms.PictureBox brush;
        private System.Windows.Forms.PictureBox circular;
        private System.Windows.Forms.PictureBox rectangle;
    }
}