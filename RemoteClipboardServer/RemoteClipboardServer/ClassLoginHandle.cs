using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RemoteClipboardServer
{
    class ClassLoginHandle
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        public static void Login(string token, int state, string callbackId, byte[] data)
        {
            if (state == 101)
            {
                ClassStatic.Result resultData = new ClassStatic.Result("false");
                ClassStatic.ClientData clientData = ClassStatic.GetClientData(data);

                if (ClassStatic.IsPhone(clientData.str1))
                {
                    if (ClassStatic.IsComplexPass(clientData.str2))
                    {
                        System.Data.DataTable dataTable = ClassStatic.sqlServer.Field("*").Where("phone='" + clientData.str1 + "' and password='" + ClassStatic.Md5(clientData.str2) + "'").Select("userInfo");
                        if (dataTable.Rows.Count > 0)
                        {
                            ClassStatic.Client client = new ClassStatic.Client();
                            client.login = true;
                            client.state = 0;
                            client.phone = clientData.str1;
                            client.uid = Convert.ToInt32(dataTable.Rows[0][0]);
                            client.bind = dataTable.Rows[0][3].ToString();
                            if (ClassStatic.clientList.ContainsKey(token))
                            {
                                ClassStatic.clientList[token] = client;
                            }
                            else
                            {
                                ClassStatic.clientList.Add(token, client);
                            }
                            resultData.ret = "true";
                            resultData.msg = "登录成功！";
                        }
                        else
                        {
                            resultData.msg = "账号或密码错误！";
                        }
                    }
                    else
                    {
                        resultData.msg = "请输入合法的密码！";
                    }
                }
                else
                {
                    resultData.msg = "请输入正确的用户名！";
                }
                // 向客户端返回处理结果
                ClassStatic.tcpServer.Send(token, state, callbackId, ClassStatic.SetResultByte(resultData));
            }
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="token"></param>
        /// <param name="state"></param>
        /// <param name="callbackId"></param>
        /// <param name="data"></param>
        public static void Register(string token, int state, string callbackId, byte[] data)
        {
            if (state == 105)
            {
                ClassStatic.Result resultData = new ClassStatic.Result("false");

                // 验证是否发送验证码
                if (ClassStatic.clientList.ContainsKey(token) && ClassStatic.clientList[token].verifies != "")
                {
                    ClassStatic.Client client = ClassStatic.clientList[token];

                    ClassStatic.ClientData clientData = ClassStatic.GetClientData(data);

                    if (ClassStatic.IsComplexPass(clientData.str2))
                    {
                        // 验证码错误
                        if (DateTime.Compare(client.effective, DateTime.Now) > 0 && clientData.str3 == client.verifies && client.phone == clientData.str1)
                        {
                            System.Data.DataTable dataTable = ClassStatic.sqlServer.Field("*").Where("phone='" + clientData.str1 + "'").Select("userInfo");
                            if (dataTable.Rows.Count == 0)
                            {
                                Dictionary<string, string> dataSql = new Dictionary<string, string>();
                                dataSql.Add("phone", clientData.str1);
                                dataSql.Add("password", ClassStatic.Md5(clientData.str2));
                                dataSql.Add("binding", "");

                                if (ClassStatic.sqlServer.Insert("userInfo", dataSql) > 0)
                                {
                                    resultData.ret = "true";
                                    resultData.msg = "注册账号成功！";

                                    ClassStatic.totalNumberOfUsers++;
                                }
                                else
                                {
                                    resultData.msg = "注册账号失败";
                                }
                            }
                            else
                            {
                                resultData.msg = "此手机号已被注册";
                            }
                        }
                        else
                        {
                            resultData.msg = "验证码错误";
                        }
                    }
                    else
                    {
                        resultData.msg = "请输入复杂密码再注册";
                    }
                }
                else
                {
                    resultData.msg = "请先发送验证码";
                }

                // 向客户端返回处理结果
                ClassStatic.tcpServer.Send(token, state, callbackId, ClassStatic.SetResultByte(resultData));
            }
        }

        /// <summary>
        /// 发送手机验证码
        /// </summary>
        public static void RegisterSendCode(string token, int state, string callbackId, byte[] data)
        {
            if(state == 104)
            {
                ClassStatic.Client client;
                DateTime dateTimeNow = DateTime.Now;
                string phone = ClassStatic.GetString(data);

                ClassStatic.Result resultData = new ClassStatic.Result("false");
  
                if (ClassStatic.IsPhone(phone))
                {
                    // 客户端列表中不存在或者验证码过期才能发送

                    if(ClassStatic.clientList.ContainsKey(token))
                    {
                        client = ClassStatic.clientList[token];
                    }
                    else
                    {
                        client = new ClassStatic.Client();
                        client.login = false;
                        client.state = 2;
                    }

                    // 判断验证码是否过期
                    if (client.effective == null || client.phone != phone || (DateTime.Compare(client.effective, dateTimeNow) < 0))
                    {
                        // 设置手机号
                        client.phone = phone;

                        System.Data.DataTable dataTable = ClassStatic.sqlServer.Field("*").Where("phone='" + phone + "'").Select("userInfo");
                        if (dataTable.Rows.Count == 0)
                        {
                            // 设置验证码
                            client.verifies = ClassStatic.GetVerifiesCode();
                            // 设置手机验证码过期时间
                            client.effective = DateTime.Now.AddMinutes(ClassStatic.verifiesEffectiveTime);
                            // 通过API接口将验证码发送到对应手机号
                            resultData = ClassStatic.HttpGet(ClassStatic.urlApi + "index.php?type=1&code=" + client.verifies + "&time=" + ClassStatic.verifiesEffectiveTime + "&phone=" + phone);
                            // 短信发送成功
                            if (resultData.ret == "true")
                            {
                                resultData.msg = "发送验证码成功！";
                                // 更新客户端信息
                                if (ClassStatic.clientList.ContainsKey(token))
                                {
                                    ClassStatic.clientList[token] = client;
                                }
                                else
                                {
                                    ClassStatic.clientList.Add(token, client);
                                }
                                ClassStatic.formMain.ConsoleWrite("成功向手机号:" + phone + "发送了验证码:" + client.verifies);
                            }
                        }
                        else
                        {
                            resultData.msg = "此手机号已被注册";
                        }
                    }
                    else
                    {
                        resultData.msg = "发送短信超时，请稍后再尝试。";
                    }
                }
                else
                {
                    resultData.msg = "请输入正确的手机号";
                }

                // 向客户端返回处理结果
                ClassStatic.tcpServer.Send(token, state, callbackId, ClassStatic.SetResultByte(resultData));
            }
        }
        
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="token"></param>
        /// <param name="state"></param>
        /// <param name="callbackId"></param>
        /// <param name="data"></param>
        public static void RetrievePassword(string token, int state, string callbackId, byte[] data)
        {
            if (state == 107)
            {
                ClassStatic.Result resultData = new ClassStatic.Result("false");

                // 验证是否发送验证码
                if (ClassStatic.clientList.ContainsKey(token) && ClassStatic.clientList[token].verifies != "")
                {
                    ClassStatic.Client client = ClassStatic.clientList[token];

                    ClassStatic.ClientData clientData = ClassStatic.GetClientData(data);

                    if (ClassStatic.IsComplexPass(clientData.str2))
                    {
                        // 验证码错误
                        if (DateTime.Compare(client.effective, DateTime.Now) > 0 && clientData.str3 == client.verifies && client.phone == clientData.str1)
                        {
                            System.Data.DataTable dataTable = ClassStatic.sqlServer.Field("*").Where("phone='" + clientData.str1 + "'").Select("userInfo");
                            if (dataTable.Rows.Count > 0)
                            {
                                Dictionary<string, string> dataSql = new Dictionary<string, string>();
                                dataSql.Add("phone", clientData.str1);
                                dataSql.Add("password", ClassStatic.Md5(clientData.str2));

                                if (ClassStatic.sqlServer.Where("phone='" + clientData.str1 + "'").Update("userInfo", dataSql) > 0)
                                {
                                    resultData.ret = "true";
                                    resultData.msg = "密码修改成功";
                                }
                                else
                                {
                                    resultData.msg = "密码修改失败";
                                }
                            }
                            else
                            {
                                resultData.msg = "此手机号未注册";
                            }
                        }
                        else
                        {
                            resultData.msg = "验证码错误";
                        }
                    }
                    else
                    {
                        resultData.msg = "请输入复杂密码再注册";
                    }
                }
                else
                {
                    resultData.msg = "请先发送验证码";
                }

                // 向客户端返回处理结果
                ClassStatic.tcpServer.Send(token, state, callbackId, ClassStatic.SetResultByte(resultData));
            }
        }

        /// <summary>
        /// 修改密码发送手机验证码
        /// </summary>
        public static void RetrievePasswordSendCode(string token, int state, string callbackId, byte[] data)
        {
            if (state == 106)
            {
                ClassStatic.Client client;
                DateTime dateTimeNow = DateTime.Now;
                string phone = ClassStatic.GetString(data);

                ClassStatic.Result resultData = new ClassStatic.Result("false");

                if (ClassStatic.IsPhone(phone))
                {
                    // 客户端列表中不存在或者验证码过期才能发送
                    if (ClassStatic.clientList.ContainsKey(token))
                    {
                        client = ClassStatic.clientList[token];
                    }
                    else
                    {
                        client = new ClassStatic.Client();
                        client.login = false;
                        client.state = 2;
                    }

                    // 判断验证码是否过期
                    if (client.effective == null || DateTime.Compare(client.effective, dateTimeNow) < 0)
                    {
                        // 设置手机号
                        client.phone = phone;

                        System.Data.DataTable dataTable = ClassStatic.sqlServer.Field("*").Where("phone='" + phone + "'").Select("userInfo");
                        if (dataTable.Rows.Count > 0)
                        {
                            // 设置验证码
                            client.verifies = ClassStatic.GetVerifiesCode();
                            // 设置手机验证码过期时间
                            client.effective = DateTime.Now.AddMinutes(ClassStatic.verifiesEffectiveTime);
                            // 通过API接口将验证码发送到对应手机号
                            resultData = ClassStatic.HttpGet(ClassStatic.urlApi + "index.php?type=2&code=" + client.verifies + "&time=" + ClassStatic.verifiesEffectiveTime + "&phone=" + phone);
                            // 短信发送成功
                            if (resultData.ret == "true")
                            {
                                resultData.msg = "发送验证码成功！";
                                // 更新客户端信息
                                if (ClassStatic.clientList.ContainsKey(token))
                                {
                                    ClassStatic.clientList[token] = client;
                                }
                                else
                                {
                                    ClassStatic.clientList.Add(token, client);
                                }
                                ClassStatic.formMain.ConsoleWrite("成功向手机号:" + phone + "发送了验证码:" + client.verifies);
                            }
                        }
                        else
                        {
                            resultData.msg = "此手机号未注册";
                        }
                    }
                    else
                    {
                        resultData.msg = "发送短信超时，请稍后再尝试。";
                    }
                }
                else
                {
                    resultData.msg = "请输入正确的手机号";
                }

                // 向客户端返回处理结果
                ClassStatic.tcpServer.Send(token, state, callbackId, ClassStatic.SetResultByte(resultData));
            }
        }

        /// <summary>
        /// 获取二维码图片
        /// </summary>
        public static void QrcodeImage(string token, int state, string callbackId, byte[] data)
        {
            if (state == 102)
            {
                byte[] imageData =  ClassStatic.HttpGetImage(ClassStatic.urlApi + "qrcode.php?token=" + token);
                // 向客户端返回处理结果
                ClassStatic.tcpServer.Send(token, state, callbackId, imageData);
            }
        }

        /// <summary>
        /// 获取二维码状态
        /// </summary>
        /// <param name="token"></param>
        /// <param name="state"></param>
        /// <param name="callbackId"></param>
        /// <param name="data"></param>
        public static void QrcodeImageState(string token, int state, string callbackId, byte[] data)
        {
            if (state == 103)
            {
                ClassStatic.Result resultData;
                resultData = ClassStatic.HttpGet(ClassStatic.urlApi + "ptqrlogin.php?token=" + token);
                System.Diagnostics.Debug.WriteLine(resultData.ret + " QQ: " + resultData.data);
                if (resultData.ret == "0")
                {
                    //resultData.data
                    System.Data.DataTable dataTable = ClassStatic.sqlServer.Field("uid,phone,binding").Where("binding='"+ resultData.data + "'").Select("userInfo");
                    if (dataTable.Rows.Count > 0)
                    {
                        ClassStatic.Client client = new ClassStatic.Client();
                        client.login = true;
                        client.state = 0;
                        client.phone = dataTable.Rows[0][1].ToString();
                        client.uid = Convert.ToInt32(dataTable.Rows[0][0]);
                        client.bind = dataTable.Rows[0][2].ToString();
                        if (ClassStatic.clientList.ContainsKey(token))
                        {
                            ClassStatic.clientList[token] = client;
                        }
                        else
                        {
                            ClassStatic.clientList.Add(token, client);
                        }
                        resultData.data = client.phone;
                    }
                    else
                    {
                        resultData.ret = "4";
                        resultData.msg = "此QQ没有绑定账号";
                    }
                }
                // 向客户端返回处理结果
                ClassStatic.tcpServer.Send(token, state, callbackId, ClassStatic.SetResultByte(resultData));
            }
        }
    }
}
