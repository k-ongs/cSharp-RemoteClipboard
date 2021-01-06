using System;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace RemoteClipboardServer
{
    static class ClassStatic
    {
        #region 公共变量声明

        public static Object loginSuccessLock = new Object();
        public static FormMain formMain = null;
        /// <summary>
        /// 用户总数量
        /// </summary>
        public static int totalNumberOfUsers = 0;
        public static int totalNumberOfUsersOnline = 0;
        /// <summary>
        /// 手机验证码有效时间
        /// </summary>
        public static int verifiesEffectiveTime = 5;
        /// <summary>
        /// 二维码和手机验证码接口地址
        /// </summary>
        public static string urlApi = "http://phone.xbear.vip/";
        public static ClassSqlServer sqlServer = new ClassSqlServer();
        /// <summary>
        /// socket传输协议类
        /// </summary>
        public static ClassTcpServer tcpServer = new ClassTcpServer(6010);
        /// <summary>
        /// 客户端列表
        /// </summary>
        public static Dictionary<string, Client> clientList = new Dictionary<string, Client>();
        public static Dictionary<int, List<string>> clientOnlineList = new Dictionary<int, List<string>>();

        #endregion

        #region 公共结构体、类声明
        /// <summary>
        /// 客户端结构体
        /// </summary>
        public struct Client
        {
            public int uid;         // 用户ID
            public int state;       // 在线状态
            public bool login;      // 是否登录
            public string mac;      // mac地址
            public string bind;     // 绑定QQ
            public string phone;    // 手机号码
            public string verifies; // 手机验证码
            public DateTime effective; // 验证码有效时间
        }

        /// <summary>
        /// 响应信息结构体
        /// </summary>
        public class Result
        {
            public Result(string ret = "", string msg = "", string data = "")
            {
                this.ret = ret == null ? "" : ret;
                this.msg = msg == null ? "" : msg;
                this.data = data == null ? "" : data;
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

        /// <summary>
        /// 设备信息
        /// </summary>
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

        /// <summary>
        /// 设备列表
        /// </summary>
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
        /// md5加密
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string Md5(string txt)
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

        /// <summary>
        /// 以GET方式请求链接并返回结果
        /// </summary>
        /// <param name="url">请求的url</param>
        public static Result HttpGet(string url)
        {
            Result resultData;
            try
            {
                System.Net.WebClient webClient = new System.Net.WebClient();
                webClient.Credentials = System.Net.CredentialCache.DefaultCredentials;
                webClient.Encoding = Encoding.UTF8;
                string result = webClient.DownloadString(url);
                resultData = JsonConvert.DeserializeObject<Result>(result);
            }
            catch {
                resultData = new Result("false", "暂时不支持短信发送。");
            }

            return resultData;
        }

        /// <summary>
        /// 获取二维码
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static byte[] HttpGetImage(string url)
        {
            byte[] data;
            try
            {
                System.Net.WebClient webClient = new System.Net.WebClient();
                webClient.Credentials = System.Net.CredentialCache.DefaultCredentials;
                data = webClient.DownloadData(url);
            }
            catch
            {
                data = new byte[] { };
            }
            return data;
        }

        /// <summary>
        /// 获取6位随机验证码
        /// </summary>
        /// <returns></returns>
        public static string GetVerifiesCode()
        {
            Random ran = new Random();
            int RandKey = ran.Next(102400, 996996);
            return RandKey.ToString();
        }

        /// <summary>
        /// 将回执信息转为byte[]
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static byte[] SetResultByte(object result)
        {
            string temp;
            try
            {
                temp = JsonConvert.SerializeObject(result);
            }
            catch
            {
                temp = "";
            }
            return GetBytes(temp);
        }

        /// <summary>
        /// 将byte[]转未ClientData类型
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ClientData GetClientData(byte[] data)
        {
            ClientData temp;
            try
            {
                temp = JsonConvert.DeserializeObject<ClientData>(GetString(data));
            }
            catch {
                temp = new ClientData("false", "获取客户端数据失败");
            }

            return temp;
        }
    }
}
