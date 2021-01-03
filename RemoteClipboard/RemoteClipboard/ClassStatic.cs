using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Configuration;
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
        /// 用户密码
        /// </summary>
        public static string password = "";
        /// <summary>
        /// 请勿打扰
        /// </summary>
        public static bool doNotDisturb = false;
        /// <summary>
        /// 主体颜色
        /// </summary>
        public static Color mainColors = Color.FromArgb(31, 158, 247);
        /// <summary>
        /// socket传输协议类
        /// </summary>
        public static ClassTcpClient tcpClient = new ClassTcpClient("127.0.0.1", 6010);
        #endregion

        #region 数据类声明
        /// <summary>
        /// 响应信息结构体
        /// </summary>
        public class Result
        {
            public Result(string ret = "", string msg = "", string data = "")
            {
                this.ret = ret;
                this.msg = ret;
                this.data = ret;
            }
            public string ret { get; set; }
            public string msg { get; set; }
            public string data { get; set; }
        }

        /// <summary>
        /// 客户端发送的数据
        /// </summary>
        public class ClientData
        {
            public ClientData(string str1 = "", string str2 = "", string str3 = "")
            {
                this.str1 = str1;
                this.str2 = str2;
                this.str3 = str3;
            }
            public string str1 { get; set; }
            public string str2 { get; set; }
            public string str3 { get; set; }
        }
        #endregion

        private static XmlDocument xmlDocument;
        private static readonly string configFileName = "AppConfig.xml";


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
        /// 初始化配置文件
        /// </summary>
        private static void XmlDocumentInitialize()
        {
            if(xmlDocument == null)
            {
                xmlDocument = new XmlDocument();
                if (!File.Exists(configFileName))
                {
                    XmlDeclaration dec = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
                    xmlDocument.AppendChild(dec);
                    XmlElement root = xmlDocument.CreateElement("Root");
                    xmlDocument.AppendChild(root);
                    root.AppendChild(xmlDocument.CreateElement("Config"));
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

        public static Result GetResult(byte[] data)
        {
            Result temp;
            try
            {
                temp = JsonConvert.DeserializeObject<Result>(GetString(data));
            }
            catch
            {
                temp = new Result("false", "与服务器链接失败");
            }
            return temp;
        }

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
    }
}
