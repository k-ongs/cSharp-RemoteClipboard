using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteClipboardServer
{
    class ClassLoginHandle
    {
        /// <summary>
        /// 发送手机验证码
        /// </summary>
        public static void SendPhoneCode(string token, int state, int callbackId, byte[] data)
        {
            if(state == 101)
            {
                DateTime dateTimeNow = DateTime.Now;
                string phone = Encoding.UTF8.GetString(data);

                ClassJsonConvertObject.PhoneSend resultData = new ClassJsonConvertObject.PhoneSend();

                resultData.ret = "1";

                if (!ClassStaticResources.IsPhone(phone))
                {
                    resultData.msg = "请输入正确的手机号";
                    // 返回
                }

                ClassStaticResources.Client client;

                // 客户端列表中不存在或者验证码过期才能发送
                if (ClassStaticResources.clientList != null && ClassStaticResources.clientList.ContainsKey(token))
                {
                    // 取客户端信息
                    client = ClassStaticResources.clientList[token];
                    // 判断验证码是否过期
                    if (DateTime.Compare(client.effective, dateTimeNow) > 0)
                    {
                        TimeSpan timeSpan = client.effective.Subtract(dateTimeNow);
                        resultData.msg = Convert.ToInt32(Math.Ceiling(timeSpan.TotalSeconds)).ToString();
                    }
                }
                else
                {
                    client = new ClassStaticResources.Client();
                    client.login = false;
                    client.state = false;
                }

            }
        }
    }
}
