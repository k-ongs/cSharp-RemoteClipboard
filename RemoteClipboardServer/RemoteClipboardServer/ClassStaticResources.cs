using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RemoteClipboardServer
{
    class ClassStaticResources
    {
        /// <summary>
        /// 客户端结构体
        /// </summary>
        public struct Client
        {
            public bool login;      // 是否登录
            public bool state;      // 接收状态
            public string phone;    // 手机号码
            public string verifies; // 手机验证码
            public DateTime effective; // 验证码有效时间
        }

        public static Dictionary<string, Client> clientList = null;

        /// <summary>
        /// 检查是否是合法手机号
        /// </summary>
        /// <param name="phone"></param>
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
    }
}
