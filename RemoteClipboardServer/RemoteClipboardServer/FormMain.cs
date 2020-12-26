using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Management;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace RemoteClipboardServer
{
    public partial class FormMain : Form
    {
        // 用户数量
        private int totalNumberOfUsers = 0;
        // 手机验证码有效时间
        private int verifiesEffectiveTime = 5;
        private string apiUrl = "http://phone.xbear.vip/";
        private ClassSqlServer sqlServer = new ClassSqlServer();
        private ClassTcpServer tcpServer = new ClassTcpServer("0.0.0.0", 6010);
        private Dictionary<string, Client> ClientList = new Dictionary<string, Client>();

        struct Client
        {
            public bool login;      // 是否登录
            public bool state;      // 接收状态
            public string phone;    // 手机号码
            public string verifies; // 手机验证码
            public DateTime effective; // 验证码有效时间
        }

        /// <summary>
        /// 获取有关系统物理和虚拟内存的信息。 参考至https://docs.microsoft.com/zh-cn/previous-versions/aa908760(v=msdn.10)
        /// </summary>
        /// <param name="meminfo">指向MEMORYSTATUS结构的指针</param>
        [DllImport("kernel32")]
        public static extern void GlobalMemoryStatus(ref MEMORYSTATUS meminfo);
        /// <summary>
        /// 此结构包含有关当前内存可用性的信息。参考至https://docs.microsoft.com/zh-cn/previous-versions/bb202730(v=msdn.10)
        /// </summary>
        public struct MEMORYSTATUS
        {
            public uint dwLength;
            public uint dwMemoryLoad; // 使用占用率，是一个介于0到100之间的数字。
            public uint dwTotalPhys;
            public uint dwAvailPhys;
            public uint dwTotalPageFile;
            public uint dwAvailPageFile;
            public uint dwTotalVirtual;
            public uint dwAvailVirtual;
        }

        #region 绘制窗体阴影
        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        private bool m_aeroEnabled;                     // variables for box shadow
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;

        public struct MARGINS                           // struct for box shadow
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        private const int WM_NCHITTEST = 0x84;          // variables for dragging the form
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();

                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }
        }

        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:                        // box shadow
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 0,
                            rightWidth = 0,
                            topHeight = 0
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }
        #endregion
        public FormMain()
        {
            InitializeComponent();
            tcpServer.OnClientCloseHandler += OnClientCloseHandler;
            tcpServer.OnClientReceiveHandler += OnClientReceiveHandler;
        }

        /// <summary>
        /// 窗体启动后初始化参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            timer1.Start();

            /// 获取用户数量
            DataTable dataTable = sqlServer.Field("count(*)").Select("userInfo");
            System.Diagnostics.Debug.WriteLine(dataTable.Rows.Count);
            if(dataTable.Rows.Count > 0)
            {
                totalNumberOfUsers = Convert.ToInt32(dataTable.Rows[0][0]);
                controlProgressBar1.Progress = totalNumberOfUsers;
            }
        }

        /// <summary>
        /// 每隔一秒刷新数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            /// 获取内存使用率
            MEMORYSTATUS MemInfo = new MEMORYSTATUS();
            GlobalMemoryStatus(ref MemInfo);
            int dwMemoryLoad = Convert.ToInt32(MemInfo.dwMemoryLoad);
            if(dwMemoryLoad != controlProgressBar4.Progress)
            {
                controlProgressBar4.Progress = Convert.ToInt32(MemInfo.dwMemoryLoad);
            }
        }

        /// <summary>
        /// 开启服务按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if(tcpServer.Start())
            {
                button2.Cursor = Cursors.Hand;
                button2.ForeColor = Color.White;
                button2.BackColor = Color.FromArgb(31, 148, 247);

                button1.Cursor = Cursors.Default;
                button1.ForeColor = Color.Black;
                button1.BackColor = Color.Gainsboro;

                button2.Enabled = true;
                button1.Enabled = false;
                textBox1.Text = "[系统] 启动服务成功" + Environment.NewLine + textBox1.Text;
            }
            else
            {
                textBox1.Text = "[错误] 启动服务错误，请检查端口是否被占用！" + Environment.NewLine + textBox1.Text;
            }
        }

        /// <summary>
        /// 关闭服务按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            tcpServer.Stop();
            button1.Cursor = Cursors.Hand;
            button1.ForeColor = Color.White;
            button1.BackColor = Color.FromArgb(31, 148, 247);

            button2.Cursor = Cursors.Default;
            button2.ForeColor = Color.Black;
            button2.BackColor = Color.Gainsboro;

            button1.Enabled = true;
            button2.Enabled = false;

            textBox1.Text = "[系统] 关闭服务成功" + Environment.NewLine + textBox1.Text;
        }

        /// <summary>
        /// 调试框输出
        /// </summary>
        /// <param name="msg"></param>
        private void ConsoleWrite(string msg)
        {
            this.Invoke(new Action(() => {
                textBox1.Text = msg + Environment.NewLine + textBox1.Text;
            }));
        }

        /// <summary>
        /// 发送手机验证码
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="state"></param>
        /// <param name="callbackId"></param>
        /// <param name="data"></param>
        private void OnClientReceiveSendPhone(string endPoint, int state, int callbackId, byte[] data)
        {
            Client client;
            string temp;
            DateTime dateTimeNow = DateTime.Now;
            string phone = Encoding.UTF8.GetString(data);
            ClassJsonConvertObject.PhoneSend resultData = new ClassJsonConvertObject.PhoneSend();
            resultData.state = "false";
            resultData.code = "发送短信失败";
            resultData.SessionContext = "";

            // 客户端列表中不存在或者验证码过期才能发送
            if (ClientList.ContainsKey(endPoint))
            {
                client = ClientList[endPoint];
                // 验证码没有过期
                if (DateTime.Compare(client.effective, dateTimeNow) > 0)
                {
                    resultData.code = "验证码没有过期";
                    ConsoleWrite("验证码没有过期");
                    temp = JsonConvert.SerializeObject(resultData);
                    tcpServer.Send(endPoint, state, callbackId, Encoding.UTF8.GetBytes(temp));
                    return;
                }
            }
            else
            {
                client = new Client();
                client.login = false;
                client.state = false;
            }

            client.verifies = GetVerifiesCode();
            client.effective = DateTime.Now.AddMinutes(verifiesEffectiveTime);

            // 获取返回值
            //
            try
            {
                string result = HttpGet(apiUrl + "index.php?code=" + client.verifies + "&time=" + verifiesEffectiveTime + "&phone=" + phone);
                resultData = JsonConvert.DeserializeObject<ClassJsonConvertObject.PhoneSend>(result);
            }
            catch { }

            if (resultData.state == "true")
            {
                client.phone = phone;
                if (ClientList.ContainsKey(endPoint))
                {
                    ClientList[endPoint] = client;
                }
                else
                {
                    ClientList.Add(endPoint, client);
                }
                ConsoleWrite("成功向手机号:" + phone + "发送了验证码:" + client.verifies);
            }
            temp = JsonConvert.SerializeObject(resultData);
            tcpServer.Send(endPoint, state, callbackId, Encoding.UTF8.GetBytes(temp));
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="state"></param>
        /// <param name="callbackId"></param>
        /// <param name="data"></param>
        private void OnClientReceiveRegister(string endPoint, int state, int callbackId, byte[] data)
        {
            string temp;
            ClassJsonConvertObject.PhoneSend resultData = new ClassJsonConvertObject.PhoneSend();
            resultData.state = "false";
            resultData.code = "请先发送验证码";
            resultData.SessionContext = "";

            if (!ClientList.ContainsKey(endPoint))
            {
                temp = JsonConvert.SerializeObject(resultData);
                tcpServer.Send(endPoint, state, callbackId, Encoding.UTF8.GetBytes(temp));
                return;
            }

            ClassJsonConvertObject.PhonePass dataJson = new ClassJsonConvertObject.PhonePass("", "", "");
            try
            {
                dataJson = JsonConvert.DeserializeObject<ClassJsonConvertObject.PhonePass>(Encoding.UTF8.GetString(data));
            }
            catch { }

            if(!IsComplexPass(dataJson.pass))
            {
                resultData.code = "请输入复杂密码再注册";
                temp = JsonConvert.SerializeObject(resultData);
                tcpServer.Send(endPoint, state, callbackId, Encoding.UTF8.GetBytes(temp));
                return;
            }

            if (!IsComplexPass(dataJson.pass))
            {
                resultData.code = "请输入复杂密码再注册";
                temp = JsonConvert.SerializeObject(resultData);
                tcpServer.Send(endPoint, state, callbackId, Encoding.UTF8.GetBytes(temp));
                return;
            }

            Client client = ClientList[endPoint];

            // 验证码错误
            if (DateTime.Compare(client.effective, DateTime.Now) < 0 || dataJson.code != client.verifies || client.phone != dataJson.user)
            {
                resultData.code = "验证码错误";
                temp = JsonConvert.SerializeObject(resultData);
                tcpServer.Send(endPoint, state, callbackId, Encoding.UTF8.GetBytes(temp));
                return;
            }

            DataTable dataTable = sqlServer.Field("*").Where("phone='"+ dataJson.user + "'").Select("userInfo");
            if(dataTable.Rows.Count > 0)
            {
                resultData.code = "此手机号已被注册";
                temp = JsonConvert.SerializeObject(resultData);
                tcpServer.Send(endPoint, state, callbackId, Encoding.UTF8.GetBytes(temp));
                return;
            }

            Dictionary<string, string> dataSql = new Dictionary<string, string>();

            dataSql.Add("phone", dataJson.user);
            dataSql.Add("password", GenerateMD5(dataJson.pass));
            dataSql.Add("binding", "");

            if(sqlServer.Insert("userInfo", dataSql) > 0)
            {
                resultData.state = "true";
                resultData.code = "注册账号成功！";

                totalNumberOfUsers++;
                controlProgressBar1.Progress = totalNumberOfUsers;
            }
            else
            {
                resultData.code = "注册账号失败";
            }

            temp = JsonConvert.SerializeObject(resultData);
            tcpServer.Send(endPoint, state, callbackId, Encoding.UTF8.GetBytes(temp));
            return;
        }

        /// <summary>
        /// 接收客户端消息并处理
        /// </summary>
        /// <param name="endPoint">来源</param>
        /// <param name="state">标识码</param>
        /// <param name="data">数据</param>
        private void OnClientReceiveHandler(string endPoint, int state, int callbackId, byte[] data)
        {
            switch(state)
            {
                // 发送手机验证码
                case 104:
                    OnClientReceiveSendPhone(endPoint, state, callbackId, data);
                    break;
                case 105:
                    OnClientReceiveRegister(endPoint, state, callbackId, data);
                    break;
            }
        }
        /// <summary>
        /// 客户端断开连接事件
        /// </summary>
        /// <param name="endPoint"></param>
        private void OnClientCloseHandler(string endPoint)
        {

        }


        /// <summary>
        /// GET方式发送得结果
        /// </summary>
        /// <param name="url">请求的url</param>
        public static string HttpGet(string url)
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            wc.Credentials = System.Net.CredentialCache.DefaultCredentials;
            wc.Encoding = Encoding.UTF8;
            string returnText = wc.DownloadString(url);

            if (returnText.Contains("errcode"))
            {
                //可能发生错误 
            }

            return returnText;
        }

        private string GetVerifiesCode()
        {
            Random ran = new Random();
            int RandKey = ran.Next(102400, 996996);
            return RandKey.ToString();
        }

        public static bool IsComplexPass(string pass)
        {
            Regex regex = new Regex(@"^(?=.*[0-9])(?=.*[a-zA-Z]).{8,30}$");
            return regex.IsMatch(pass);
        }

        public static bool IsPhone(string phone)
        {
            Regex regex = new Regex(@"^(1(3|4|5|8)[0-9])\d{8}$");
            return regex.IsMatch(phone);
        }

        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string GenerateMD5(string txt)
        {
            using (MD5 mi = MD5.Create())
            {
                byte[] buffer = Encoding.Default.GetBytes(txt);
                byte[] newBuffer = mi.ComputeHash(buffer);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < newBuffer.Length; i++)
                {
                    sb.Append(newBuffer[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
