using System;
using System.IO;
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
    public partial class ControlSoftwareSetting : UserControl
    {
        private bool shortcutkey = false;
        public ControlSoftwareSetting()
        {
            InitializeComponent();
            InitializeControl();
        }

        public void InitializeControl()
        {
            if (ClassStatic.GetConfigSoftware("cachePath") == "")
            {
                ClassStatic.SetConfigSoftware("cachePath", System.Environment.CurrentDirectory + "\\cache");
            }
            string path = ClassStatic.GetConfigSoftware("cachePath");

            if (Directory.Exists(path) == false)
            {
                path = System.Environment.CurrentDirectory + "\\cache";
                Directory.CreateDirectory(path);
                ClassStatic.SetConfigSoftware("cachePath", path);
            }

            cachePath.Text = path;

            if(ClassStatic.bind != "")
            {
                textBindNumber.Text = ClassStatic.bind;
                buttonBindQQ.Text = "解除绑定";
            }
            else
            {
                textBindNumber.Text = "等待绑定";
                buttonBindQQ.Text = "绑定QQ";
            }

            turnOn.Checked = (ClassStatic.GetConfigSoftware("turnOn") == "True");
            Parsing.Checked = (ClassStatic.GetConfigSoftware("parse") == "True");

            textCopy.Text = ClassStatic.GetConfigSoftware("copy");
            textPaste.Text = ClassStatic.GetConfigSoftware("paste");
            textScreenshot.Text = ClassStatic.GetConfigSoftware("screenshot");
            textColor.Text = ClassStatic.GetConfigSoftware("color");
        }

        private void turnOn_CheckedChanged(object sender, EventArgs e)
        {
            ClassStatic.SetConfigSoftware("turnOn", turnOn.Checked.ToString());
        }

        /// <summary>
        /// 解析连接开启
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Parsing_CheckedChanged(object sender, EventArgs e)
        {
            if(ClassStatic.GetConfigSoftware("parse") != Parsing.Checked.ToString())
            {
                ClassStatic.SetConfigSoftware("parse", Parsing.Checked.ToString());
                Action<bool, byte[]> action = new Action<bool, byte[]>(SettingChange_Callback);
                ClassStatic.ClientData clientData = new ClassStatic.ClientData("parse", Parsing.Checked.ToString());
                ClassStatic.tcpClient.Send(220, ClassStatic.SetClientDataByte(clientData), action);
            }
        }

        /// <summary>
        /// 打开缓存位置按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpenPath_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", cachePath.Text);
        }

        /// <summary>
        /// 修改缓存位置按钮被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonChangePath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                cachePath.Text = folderBrowserDialog.SelectedPath;
                ClassStatic.SetConfigSoftware("cachePath", cachePath.Text);
            }
        }

        /// <summary>
        /// 绑定QQ按钮被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBindQQ_Click(object sender, EventArgs e)
        {
            if(buttonBindQQ.Text == "绑定QQ")
            {
                MainForm.FormBindQQ formBindQQ = new MainForm.FormBindQQ();
                formBindQQ.ShowDialog();
                formBindQQ.Dispose();
                if (ClassStatic.bind != "")
                {
                    textBindNumber.Text = ClassStatic.bind;
                    buttonBindQQ.Text = "解除绑定";
                }
            }
            else
            {
                MainForm.FormUnBindQQ formBindQQ = new MainForm.FormUnBindQQ();
                formBindQQ.ShowDialog();
                formBindQQ.Dispose();
                if (ClassStatic.bind == "")
                {
                    textBindNumber.Text = "等待绑定";
                    buttonBindQQ.Text = "绑定QQ";
                }
            }
        }

        /// <summary>
        /// 修改按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextShortcutKey_DoubleClick(object sender, EventArgs e)
        {
            TextBox that = sender as TextBox;
            if (that.Tag == null)
            {
                that.Tag = that.Text;
                that.Text = "直接按键设置";
                that.Select(that.TextLength, 0);
                shortcutkey = true;
                FormMain.formMain.UndoShortcutkeyHandRegister();
            }
        }

        /// <summary>
        /// 快捷键设置按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextShortcutKey_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox that = sender as TextBox;
            if (that.Tag != null)
            {
                string key1, key2 = "";
                key1 = e.Alt ? "Alt" : e.Shift ? "Shift" : e.Control ? "Ctrl" : "";

                if (e.KeyCode != Keys.None && e.KeyCode != Keys.ShiftKey && e.KeyCode != Keys.ControlKey && e.KeyCode != Keys.Menu)
                {
                    key2 = e.KeyCode.ToString();
                }
                if (key1 != "" && key2 != "")
                {
                    that.Text = key1 + " + " + key2;
                }
                else
                {
                    if (key1 != "")
                    {
                        that.Text = key1;
                    }
                    if (key2 != "")
                    {
                        that.Text = key2;
                    }
                }
            }
        }

        /// <summary>
        /// 快捷键设置抬起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextShortcutKey_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox that = sender as TextBox;
            string type;
            if(that.Tag != null)
            {
                if (that == textCopy)
                {
                    type = "copy";
                }
                else if (that == textPaste)
                {
                    type = "paste";
                }
                else if (that == textScreenshot)
                {
                    type = "screenshot";
                }
                else if (that == textColor)
                {
                    type = "color";
                }
                else
                {
                    type = "";
                }

                if (that.Text != "" && that.Text != that.Tag.ToString())
                {
                    if (type != "")
                    {
                        Action<bool, byte[]> action = new Action<bool, byte[]>(SettingChange_Callback);
                        ClassStatic.ClientData clientData = new ClassStatic.ClientData(type, that.Text);
                        ClassStatic.tcpClient.Send(220, ClassStatic.SetClientDataByte(clientData), action);
                        ClassStatic.SetConfigSoftware(type, that.Text);
                    }
                }
                else
                {
                    that.Text = that.Tag.ToString();
                }
                that.Tag = null;
                if (shortcutkey)
                {
                    shortcutkey = false;
                    FormMain.formMain.ShortcutkeyHandRegister();
                }
            }
        }

        /// <summary>
        /// 快捷键设置鼠标移出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextShortcutKey_Leave(object sender, EventArgs e)
        {
            TextBox that = sender as TextBox;
            if (that.Tag != null)
            {
                that.Text = that.Tag.ToString();
                that.Tag = null;
            }
            if(shortcutkey)
            {
                shortcutkey = false;
                FormMain.formMain.ShortcutkeyHandRegister();
            }
        }

        private void SettingChange_Callback(bool state, byte[] data)
        {
            System.Diagnostics.Debug.WriteLine(ClassStatic.GetString(data));
        }

        /// <summary>
        /// 修改密码按钮被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonChangePass_Click(object sender, EventArgs e)
        {
            MainForm.FormEditPassword formEditPassword = new MainForm.FormEditPassword();
            formEditPassword.ShowDialog();
            formEditPassword.Dispose();
        }
    }
}
