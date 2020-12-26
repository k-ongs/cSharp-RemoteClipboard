using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Threading.Tasks;
using System.Configuration;
using System.Text.RegularExpressions;

namespace RemoteClipboard
{
    class ClassStaticResources
    {
        // 头像id
        public static int portraitPid = 0;
        // 用户密码
        public static string password = "";
        // 主体颜色
        public static Color mainColors = Color.FromArgb(31, 158, 247);
        // 请勿打扰
        public static bool doNotDisturb = false;
        // 和服务器的连接状态
        public static ClassTcpClient tcpClient = new ClassTcpClient("127.0.0.1", 6010);


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

        public static bool IsPhone(string phone)
        {
            Regex regex = new Regex(@"^(1(3|4|5|8)[0-9])\d{8}$");
            return regex.IsMatch(phone);
        }

        public static bool IsComplexPass(string pass)
        {
            Regex regex = new Regex(@"^(?=.*[0-9])(?=.*[a-zA-Z]).{8,30}$");
            return regex.IsMatch(pass);
        }
    }
}
