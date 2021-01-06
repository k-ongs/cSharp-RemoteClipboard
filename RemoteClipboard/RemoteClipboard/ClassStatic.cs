using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace RemoteClipboard
{
    class ClassStatic
    {
        #region 公共变量声明
        /// <summary>
        /// 头像id
        /// </summary>
        public static int portraitPid = 0;
        /// <summary>
        /// 绑定QQ号
        /// </summary>
        public static string bind = "";
        /// <summary>
        /// 用户账号
        /// </summary>
        public static string account = "";
        /// <summary>
        /// 在线状态
        /// </summary>
        public static int onlineStatus = 0;
        /// <summary>
        /// 是否登录
        /// </summary>
        public static bool isLogined = false;
        public static int isRemoteClipboardData = 0;
        /// <summary>
        /// 主体颜色
        /// </summary>
        public static Color mainColors = Color.FromArgb(31, 158, 247);
        /// <summary>
        /// socket传输协议类
        /// </summary>
        public static ClassTcpClient tcpClient = new ClassTcpClient("192.168.211.1", 6010);
        public static Object sendCallbackLock = new Object();

        public class ShortcutKey
        {
            public const int Copy = 300;
            public const int Paste = 301;
            public const int Screenshot = 302;
            public const int Color = 303;
        }

        #endregion

        #region 数据类声明
        public class ShortcutKeys
        {
            public ShortcutKeys(ClassHotKey.KeyModifiers key1, Keys key2)
            {
                this.key1 = key1;
                this.key2 = key2;
            }
            public ClassHotKey.KeyModifiers key1 { get; set; }
            public Keys key2 { get; set; }
        }
        /// <summary>
        /// 响应信息结构体
        /// </summary>
        public class Result
        {
            public string ret { get; set; }
            public string msg { get; set; }
            public string data { get; set; }
        }

        /// <summary>
        /// 客户端发送的数据
        /// </summary>
        public class ClientData
        {
            public ClientData(string str1 = "", string str2 = "", string str3 = "", string str4 = "")
            {
                this.str1 = str1;
                this.str2 = str2;
                this.str3 = str3;
                this.str4 = str4;

            }
            public string str1 { get; set; }
            public string str2 { get; set; }
            public string str3 { get; set; }
            public string str4 { get; set; }
        }

        public class ListDrive
        {
            /// <summary>
            /// mac地址
            /// </summary>
            public string mac { get; set; }
            /// <summary>
            /// 头像ID
            /// </summary>
            public string pid { get; set; }
            /// <summary>
            /// 设备名
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 设备标识
            /// </summary>
            public string token { get; set; }
            /// <summary>
            /// 设备当前状态
            /// </summary>
            public int state { get; set; }
        }

        public class ListDriveData
        {
            public ListDriveData(string state, List<ListDrive> list)
            {
                this.state = state;
                this.list = list;
            }
            public string state { get; set; }
            public List<ListDrive> list { get; set; }
        }

        /// <summary>
        /// 软件配置信息
        /// </summary>
        public class UserLoginSuccess
        {
            public string ret { get; set; }
            public string bind { get; set; }
            public string parse { get; set; }
            public string copy { get; set; }
            public string paste { get; set; }
            public string screenshot { get; set; }
            public string color { get; set; }
        }
        #endregion

        #region 配置文件
        private static XmlDocument xmlDocument;
        private static readonly string configFileName = "AppConfig.xml";
        /// <summary>
        /// 初始化配置文件
        /// </summary>
        private static void XmlDocumentInitialize()
        {
            if (xmlDocument == null)
            {
                xmlDocument = new XmlDocument();
                if (!File.Exists(configFileName))
                {
                    XmlDeclaration dec = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
                    xmlDocument.AppendChild(dec);
                    XmlElement root = xmlDocument.CreateElement("Root");
                    xmlDocument.AppendChild(root);
                    root.AppendChild(xmlDocument.CreateElement("Config"));
                    root.AppendChild(xmlDocument.CreateElement("Software"));
                    xmlDocument.Save(configFileName);
                }
                else
                {
                    xmlDocument.Load(configFileName);
                }
            }

        }

        /// <summary>
        /// 设置配置信息
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetConfig(string key, string value)
        {
            XmlDocumentInitialize();

            XmlNode node = xmlDocument.SelectSingleNode("Root/Config/" + key);

            if (node == null)
            {
                node = xmlDocument.CreateElement(key);
                xmlDocument.SelectSingleNode("Root/Config").AppendChild(node);
            }
            node.InnerText = value;
            xmlDocument.Save(configFileName);
        }

        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfig(string key)
        {
            XmlDocumentInitialize();
            XmlNode node = xmlDocument.SelectSingleNode("Root/Config/" + key);

            return node?.InnerText ?? "";
        }

        /// <summary>
        /// 设置软件配置信息
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetConfigSoftware(string key, string value)
        {
            XmlDocumentInitialize();

            XmlNode node = xmlDocument.SelectSingleNode("Root/Software/" + key);

            if (node == null)
            {
                node = xmlDocument.CreateElement(key);
                xmlDocument.SelectSingleNode("Root/Software").AppendChild(node);
            }
            node.InnerText = value;
            xmlDocument.Save(configFileName);
        }

        /// <summary>
        /// 获取软件配置信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfigSoftware(string key)
        {
            XmlDocumentInitialize();
            XmlNode node = xmlDocument.SelectSingleNode("Root/Software/" + key);

            return node?.InnerText ?? "";
        }
        #endregion


        /// <summary>
        /// 获取头像图片
        /// </summary>
        /// <returns></returns>
        public static Image GetPortraitImage(int id)
        {
            id = id < 12 ? id : 0;
            string picName = "h" + Convert.ToChar(65 + id / 4) + (id % 4 + 1);
            return (Image)ResourcePortrait.ResourceManager.GetObject(picName);
        }

        /// <summary>
        /// 检查是否是合法手机号
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns></returns>
        public static bool IsPhone(string phone)
        {
            Regex regex = new Regex(@"^(1(3|4|5|8)[0-9])\d{8}$");
            return regex.IsMatch(phone);
        }

        /// <summary>
        /// 检查是否是合法密码
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static bool IsComplexPass(string pass)
        {
            Regex regex = new Regex(@"^(?=.*[0-9])(?=.*[a-zA-Z]).{8,30}$");
            return regex.IsMatch(pass);
        }

        /// <summary>
        /// 将byte[]转为string
        /// </summary>
        public static string GetString(byte[] data)
        {
            return Encoding.UTF8.GetString(data);
        }

        /// <summary>
        /// 将string转为byte[]
        /// </summary>
        public static byte[] GetBytes(string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        /// <summary>
        /// 将byte[]转为Result
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Result GetResult(byte[] data)
        {
            Result temp;
            try
            {
                temp = JsonConvert.DeserializeObject<ClassStatic.Result>(ClassStatic.GetString(data));
            }
            catch
            {
                temp = new Result();
                temp.ret = "false";
                temp.msg = "与服务器链接失败";
            }
            return temp;
        }

        public static ListDriveData GetListDriveData(byte[] data)
        {
            ListDriveData temp;
            try
            {
                temp = JsonConvert.DeserializeObject<ClassStatic.ListDriveData>(ClassStatic.GetString(data));
            }
            catch
            {
                temp = new ListDriveData("false", new List<ListDrive>());
            }
            return temp;
        }


        public static ListDrive GetListDrive(byte[] data)
        {
            ListDrive temp;
            try
            {
                temp = JsonConvert.DeserializeObject<ClassStatic.ListDrive>(ClassStatic.GetString(data));
            }
            catch
            {
                temp = null;
            }
            return temp;
        }

        public static UserLoginSuccess GetLoginSuccessData(byte[] data)
        {
            UserLoginSuccess temp;
            try
            {
                temp = JsonConvert.DeserializeObject<ClassStatic.UserLoginSuccess>(ClassStatic.GetString(data));
            }
            catch
            {
                temp = null;
            }
            return temp;
        }
        

        /// <summary>
        /// 将ClientData转为byte[]
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] SetClientDataByte(ClientData data)
        {
            string temp;
            try
            {
                temp = JsonConvert.SerializeObject(data);
            }
            catch
            {
                temp = "";
            }
            return GetBytes(temp);
        }

        /// <summary>
        /// 获取mac地址
        /// </summary>
        /// <returns></returns>
        public static string GetMacByNetworkInterface()
        {
            var interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var @interface in interfaces)
            {
                var up = @interface.OperationalStatus == OperationalStatus.Up;
                var loopback = @interface.NetworkInterfaceType == NetworkInterfaceType.Loopback;

                if (up && !loopback)
                {
                    var address = @interface.GetPhysicalAddress().ToString();
                    var result = Regex.Replace(address, ".{2}", "$0-");
                    return result.Remove(result.Length - 1);
                }
            }
            return "";
        }

        /// <summary>
        /// 将image转化为二进制
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static byte[] GetByteImage(Image img)
        {
            byte[] bt = null;
            if (!img.Equals(null))
            {
                using (MemoryStream mostream = new MemoryStream())
                {
                    Bitmap bmp = new Bitmap(img);
                    bmp.Save(mostream, System.Drawing.Imaging.ImageFormat.Bmp);
                    bt = new byte[mostream.Length];
                    mostream.Position = 0;
                    mostream.Read(bt, 0, Convert.ToInt32(bt.Length));
                    bmp.Dispose();
                }
            }
            return bt;
        }

        /// <summary>
        /// 读取byte[]并转化为图片
        /// </summary>
        /// <param name="bytes">byte[]</param>
        /// <returns>Image</returns>
        public static Image GetImageByBytes(byte[] bytes)
        {
            Image photo = null;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                ms.Write(bytes, 0, bytes.Length);
                photo = Image.FromStream(ms, true);
            }
            return photo;
        }
    }
}
