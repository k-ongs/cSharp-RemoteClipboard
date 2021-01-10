using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteClipboardServer
{
    class ClassFormMainHandle
    {
        /// <summary>
        /// 客户端登录成功
        /// </summary>
        /// <param name="token"></param>
        /// <param name="state"></param>
        /// <param name="callbackId"></param>
        /// <param name="data"></param>
        public static void LoginSuccess(string token, int state, string callbackId, byte[] data)
        {
            if (state == 201)
            {
                ClassStatic.UserLoginSuccess resultData = new ClassStatic.UserLoginSuccess();
                resultData.ret = "false";

                // 判断设备信息是否存在
                if (ClassStatic.clientList.ContainsKey(token))
                {
                    // 解析客户端提交的数据
                    ClassStatic.ClientData clientData = ClassStatic.GetClientData(data);
                    // 判断提交的信息是否存在
                    if (clientData.str1 != "" && clientData.str2 != "" && clientData.str3 != "")
                    {
                        string name = clientData.str1;
                        string mac = clientData.str2;
                        int pid = Convert.ToInt32(clientData.str3);
                        if (pid < 0 || pid > 12)
                        {
                            pid = 0;
                        }
                        // 获取设备信息
                        ClassStatic.Client client = ClassStatic.clientList[token];
                        client.mac = mac;
                        client.state = 0;
                        ClassStatic.clientList[token] = client;

                        // 更新数据库中的信息
                        Dictionary<string, string> dataSql = new Dictionary<string, string>();
                        dataSql.Add("name", name);
                        dataSql.Add("mac", mac);
                        dataSql.Add("uid", client.uid.ToString());
                        dataSql.Add("pid", pid.ToString());

                        System.Data.DataTable dataTable = ClassStatic.sqlServer.Field("*").Where("uid='" + client.uid + "' and mac='" + mac + "'").Select("userDevice");
                        if (dataTable.Rows.Count == 0)
                        {
                            ClassStatic.sqlServer.Insert("userDevice", dataSql);
                        }
                        else
                        {
                            ClassStatic.sqlServer.Where("uid='" + client.uid + "' and mac='" + mac + "'").Update("userDevice", dataSql);
                        }

                        /// 获取在线设备列表
                        List<string> clientOnlineList;
                        if (ClassStatic.clientOnlineList.ContainsKey(client.uid))
                        {
                            clientOnlineList = ClassStatic.clientOnlineList[client.uid];
                        }
                        else
                        {
                            clientOnlineList = new List<string>();
                        }

                        // 向其它客户端发送有新的设备上线
                        foreach (string tokenTemp in clientOnlineList)
                        {
                            if (token != tokenTemp)
                            {
                                ClassStatic.tcpServer.Send(tokenTemp, 201, ClassStatic.GetBytes("有新的设备上线"));
                            }
                        }

                        clientOnlineList.Add(token);
                        if (ClassStatic.clientOnlineList.ContainsKey(client.uid))
                        {
                            ClassStatic.clientOnlineList[client.uid] = clientOnlineList;
                        }
                        else
                        {
                            ClassStatic.clientOnlineList.Add(client.uid, clientOnlineList);
                        }

                        // 在线用户数量加一
                        ClassStatic.totalNumberOfUsersOnline++;

                        System.Data.DataTable userConfig = ClassStatic.sqlServer.Field("parse,copy,paste,screenshot,color").Where("uid='" + client.uid + "'").Select("userConfig");
                        if (userConfig.Rows.Count > 0 && userConfig.Columns.Count > 4)
                        {
                            resultData.parse = userConfig.Rows[0][0].ToString();
                            resultData.copy = userConfig.Rows[0][1].ToString();
                            resultData.paste = userConfig.Rows[0][2].ToString();
                            resultData.screenshot = userConfig.Rows[0][3].ToString();
                            resultData.color = userConfig.Rows[0][4].ToString();
                        }
                        else
                        {
                            resultData.parse = "False";
                            resultData.copy = "Ctrl + C";
                            resultData.paste = "Ctrl + V";
                            resultData.screenshot = "Ctrl + P";
                            resultData.color = "Ctrl + L";
                        }

                        resultData.ret = "true";
                        resultData.bind = client.bind;
                    }
                }
                // 向客户端返回处理结果
                ClassStatic.tcpServer.Send(token, state, callbackId, ClassStatic.SetResultByte(resultData));
            }
        }

        /// <summary>
        /// 获取设备列表
        /// </summary>
        /// <param name="token"></param>
        /// <param name="state"></param>
        /// <param name="callbackId"></param>
        /// <param name="data"></param>
        public static void GetDeviceList(string token, int state, string callbackId, byte[] data)
        {
            if (state == 200)
            {
                ClassStatic.ListDriveData listDriveData = new ClassStatic.ListDriveData("true", new List<ClassStatic.ListDrive>());
                if (ClassStatic.clientList.ContainsKey(token))
                {
                    List<string> clientOnlineList;
                    ClassStatic.Client client = ClassStatic.clientList[token];

                    System.Data.DataTable dataTableDrive = ClassStatic.sqlServer.Field("userDevice.name,userDevice.mac,userDevice.pid").Where("userInfo.uid ="+client.uid).Select("userInfo left join userDevice on userInfo.uid = userDevice.uid");

                    Dictionary<string, string> listMacTemp = new Dictionary<string, string>();

                    // 在线的客户端
                    clientOnlineList = ClassStatic.clientOnlineList[client.uid];
                    foreach (string tokenTemp in clientOnlineList)
                    {
                        if (ClassStatic.clientList.ContainsKey(tokenTemp))
                        {
                            string macTemp = ClassStatic.clientList[tokenTemp].mac;
                            listMacTemp.Add(macTemp, tokenTemp);
                        }
                    }

                    foreach (System.Data.DataRow row in dataTableDrive.Rows)
                    {
                        ClassStatic.ListDrive temp = new ClassStatic.ListDrive();
                        temp.name = row[0].ToString();
                        temp.mac = row[1].ToString();
                        temp.pid = row[2].ToString();

                        if (listMacTemp.ContainsKey(temp.mac))
                        {
                            temp.token = listMacTemp[temp.mac];
                            temp.state = ClassStatic.clientList[listMacTemp[temp.mac]].state;
                        }
                        else
                        {
                            temp.state = 2;
                            temp.token = "";
                        }

                        if (client.mac != temp.mac)
                        {
                            listDriveData.list.Add(temp);
                        }
                    }
                }
                // 向客户端返回处理结果
                ClassStatic.tcpServer.Send(token, state, callbackId, ClassStatic.SetResultByte(listDriveData));
            }
        }

        /// <summary>
        /// 有设备改变运行状态
        /// </summary>
        /// <param name="token"></param>
        /// <param name="state"></param>
        /// <param name="callbackId"></param>
        /// <param name="data"></param>
        public static void OnDeviceChangeState(string token, int state, string callbackId, byte[] data)
        {
            if(state == 203)
            {
                string stateDrive = ClassStatic.GetString(data);
                if (ClassStatic.clientList.ContainsKey(token))
                {
                    ClassStatic.Client client = ClassStatic.clientList[token];
                    client.state = (stateDrive == "在线" ? 0 : 1);
                    ClassStatic.clientList[token] = client;
                    if (ClassStatic.clientOnlineList.ContainsKey(client.uid))
                    {
                        List<string> clientOnlineList = ClassStatic.clientOnlineList[client.uid];
                        foreach (string tokenTemp in clientOnlineList)
                        {
                            if (tokenTemp!= token)
                            {
                                ClassStatic.tcpServer.Send(tokenTemp, 203, ClassStatic.GetBytes(token + (client.state == 1 ? "勿扰" : "在线")));
                                System.Diagnostics.Debug.WriteLine("发送改变到客户端："+ tokenTemp);
                            }
                        }
                    }
                }

                // 向客户端返回处理结果
                ClassStatic.tcpServer.Send(token, state, callbackId, ClassStatic.GetBytes("处理完毕"));
            }
        }

        /// <summary>
        /// 获取二维码图片
        /// </summary>
        public static void QrcodeBindImage(string token, int state, string callbackId, byte[] data)
        {
            if (state == 204)
            {
                byte[] imageData = ClassStatic.HttpGetImage(ClassStatic.urlApi + "qrcode.php?token=" + token);
                // 向客户端返回处理结果
                ClassStatic.tcpServer.Send(token, state, callbackId, imageData);
                System.Diagnostics.Debug.Write("已向客户端发送二维码");
            }
        }

        /// <summary>
        /// 解绑获取二维码状态
        /// </summary>
        /// <param name="token"></param>
        /// <param name="state"></param>
        /// <param name="callbackId"></param>
        /// <param name="data"></param>
        public static void QrcodeBindImageState(string token, int state, string callbackId, byte[] data)
        {
            if (state == 205)
            {
                ClassStatic.Result resultData;
                ClassStatic.Client client = ClassStatic.clientList[token];
                resultData = ClassStatic.HttpGet(ClassStatic.urlApi + "ptqrlogin.php?token=" + token);
                System.Diagnostics.Debug.WriteLine("二维码状态：" + resultData.ret + ";  QQ：" + resultData.data);
                if (resultData.ret == "0")
                {
                    System.Data.DataTable dataTable = ClassStatic.sqlServer.Field("uid,phone").Where("binding='" + resultData.data + "'").Select("userInfo");
                    if (dataTable.Rows.Count > 0)
                    {
                        resultData.ret = "4";
                        resultData.msg = "已绑定其它手机号";
                    }
                    else
                    {
                        Dictionary<string, string> dataSql = new Dictionary<string, string>();
                        dataSql.Add("binding", resultData.data);
                        if (ClassStatic.sqlServer.Where("uid='" + client.uid + "'").Update("userInfo", dataSql) > 0)
                        {
                            resultData.ret = "0";
                            resultData.msg = "绑定成功";
                        }
                        else
                        {
                            resultData.ret = "5";
                            resultData.msg = "绑定失败";
                        }
                    }
                }
                // 向客户端返回处理结果
                ClassStatic.tcpServer.Send(token, state, callbackId, ClassStatic.SetResultByte(resultData));
            }
        }

        /// <summary>
        /// 获取二维码状态
        /// </summary>
        /// <param name="token"></param>
        /// <param name="state"></param>
        /// <param name="callbackId"></param>
        /// <param name="data"></param>
        public static void QrcodeUnBindImageState(string token, int state, string callbackId, byte[] data)
        {
            if (state == 206)
            {
                ClassStatic.Result resultData;
                ClassStatic.Client client = ClassStatic.clientList[token];
                resultData = ClassStatic.HttpGet(ClassStatic.urlApi + "ptqrlogin.php?token=" + token);
                System.Diagnostics.Debug.WriteLine("二维码状态：" + resultData.ret + ";  QQ：" + resultData.data);
                if (resultData.ret == "0")
                {
                    System.Data.DataTable dataTable = ClassStatic.sqlServer.Field("uid,phone").Where("binding='" + resultData.data + "'").Select("userInfo");
                    if (dataTable.Rows.Count == 0)
                    {
                        resultData.ret = "4";
                        resultData.msg = "未绑定到手机号";
                    }
                    else
                    {
                        Dictionary<string, string> dataSql = new Dictionary<string, string>();
                        dataSql.Add("binding", "");
                        if (ClassStatic.sqlServer.Where("uid='" + client.uid + "'").Update("userInfo", dataSql) > 0)
                        {
                            resultData.ret = "0";
                            resultData.msg = "解绑成功";
                        }
                        else
                        {
                            resultData.ret = "5";
                            resultData.msg = "解绑失败";
                        }
                    }
                }
                // 向客户端返回处理结果
                ClassStatic.tcpServer.Send(token, state, callbackId, ClassStatic.SetResultByte(resultData));
            }
        }

        /// <summary>
        /// 用户修改配置
        /// </summary>
        /// <param name="token"></param>
        /// <param name="state"></param>
        /// <param name="callbackId"></param>
        /// <param name="data"></param>
        public static void SettingChange(string token, int state, string callbackId, byte[] data)
        {
            if (state == 220)
            {
                string msg = "配置修改失败";
                if (ClassStatic.clientList.ContainsKey(token) && ClassStatic.clientList[token].phone != "")
                {
                    ClassStatic.Client client = ClassStatic.clientList[token];
                    ClassStatic.ClientData clientData = ClassStatic.GetClientData(data);

                    Dictionary<string, string> dataSql = new Dictionary<string, string>();
                    switch(clientData.str1)
                    {
                        //parse,copy,paste,screenshot,color
                        case "parse":
                            dataSql.Add("parse", (clientData.str2 == "True" ? "True" : "False"));
                            break;
                        case "copy":
                            dataSql.Add("copy", clientData.str2);
                            break;
                        case "paste":
                            dataSql.Add("paste", clientData.str2);
                            break;
                        case "screenshot":
                            dataSql.Add("screenshot", clientData.str2);
                            break;
                        case "color":
                            dataSql.Add("color", clientData.str2);
                            break;
                    }
                    if(dataSql.Count > 0 && clientData.str2 != "")
                    {
                        System.Data.DataTable dataTable = ClassStatic.sqlServer.Field("*").Where("uid='" + client.uid + "'").Select("userConfig");
                        if (dataTable.Rows.Count == 0)
                        {
                            if(clientData.str1 != "parse")
                                dataSql.Add("parse", "False");
                            if (clientData.str1 != "copy")
                                dataSql.Add("copy", "Ctrl + C");
                            if (clientData.str1 != "paste")
                                dataSql.Add("paste", "Ctrl + V");
                            if (clientData.str1 != "screenshot")
                                dataSql.Add("screenshot", "Ctrl + P");
                            if (clientData.str1 != "color")
                                dataSql.Add("color", "Ctrl + L");
                            dataSql.Add("uid", client.uid.ToString());
                            if (ClassStatic.sqlServer.Insert("userConfig", dataSql) > 0)
                            {
                                msg = "配置修改成功";
                            }
                        }
                        else
                        {
                            if (ClassStatic.sqlServer.Where("uid='" + client.uid + "'").Update("userConfig", dataSql) > 0)
                            {
                                msg = "配置修改成功";
                            }
                        }
                    }
                }
                // 向客户端返回处理结果
                ClassStatic.tcpServer.Send(token, state, callbackId, ClassStatic.GetBytes(msg));
            }
        }

        /// <summary>
        /// 剪贴板文本数据共享
        /// </summary>
        /// <param name="token"></param>
        /// <param name="state"></param>
        /// <param name="callbackId"></param>
        /// <param name="data"></param>
        public static void OnDriveClipboardDataTextHandler(string token, int state, string callbackId, byte[] data)
        {
            if (state == 221)
            {
                if (ClassStatic.clientList.ContainsKey(token))
                {
                    ClassStatic.Client client = ClassStatic.clientList[token];

                    /// 获取在线设备列表
                    List<string> clientOnlineList;
                    if (ClassStatic.clientOnlineList.ContainsKey(client.uid))
                    {
                        clientOnlineList = ClassStatic.clientOnlineList[client.uid];
                    }
                    else
                    {
                        clientOnlineList = new List<string>();
                    }
                    // 向其它客户端发送信息
                    foreach (string tokenTemp in clientOnlineList)
                    {
                        if (token != tokenTemp)
                        {
                            ClassStatic.tcpServer.Send(tokenTemp, state, data);
                        }
                    }
                }
                // 向客户端返回处理结果
                ClassStatic.tcpServer.Send(token, state, callbackId, ClassStatic.GetBytes("发送成功"));
            }
        }

        /// <summary>
        /// 剪贴板图片数据共享
        /// </summary>
        /// <param name="token"></param>
        /// <param name="state"></param>
        /// <param name="callbackId"></param>
        /// <param name="data"></param>
        public static void OnDriveClipboardDataImageHandler(string token, int state, string callbackId, byte[] data)
        {
            if (state == 222)
            {
                if (ClassStatic.clientList.ContainsKey(token))
                {
                    ClassStatic.Client client = ClassStatic.clientList[token];

                    /// 获取在线设备列表
                    List<string> clientOnlineList;
                    if (ClassStatic.clientOnlineList.ContainsKey(client.uid))
                    {
                        clientOnlineList = ClassStatic.clientOnlineList[client.uid];
                    }
                    else
                    {
                        clientOnlineList = new List<string>();
                    }
                    // 向其它客户端发送信息
                    foreach (string tokenTemp in clientOnlineList)
                    {
                        if (token != tokenTemp)
                        {
                            ClassStatic.tcpServer.Send(tokenTemp, state, data);
                        }
                    }
                }
                // 向客户端返回处理结果
                ClassStatic.tcpServer.Send(token, state, callbackId, ClassStatic.GetBytes("发送成功"));
            }
        }

        /// <summary>
        /// 剪贴板文件数据共享
        /// </summary>
        /// <param name="token"></param>
        /// <param name="state"></param>
        /// <param name="callbackId"></param>
        /// <param name="data"></param>
        public static void OnDriveClipboardDataFileHandler(string token, int state, string callbackId, byte[] data)
        {
            if (state == 223)
            {
                if (ClassStatic.clientList.ContainsKey(token))
                {
                    ClassStatic.Client client = ClassStatic.clientList[token];

                    /// 获取在线设备列表
                    List<string> clientOnlineList;
                    if (ClassStatic.clientOnlineList.ContainsKey(client.uid))
                    {
                        clientOnlineList = ClassStatic.clientOnlineList[client.uid];
                    }
                    else
                    {
                        clientOnlineList = new List<string>();
                    }
                    // 向其它客户端发送信息
                    foreach (string tokenTemp in clientOnlineList)
                    {
                        if (token != tokenTemp)
                        {
                            ClassStatic.tcpServer.Send(tokenTemp, state, data);
                        }
                    }
                }
                // 向客户端返回处理结果
                ClassStatic.tcpServer.Send(token, state, callbackId, ClassStatic.GetBytes("发送成功"));
            }
        }


        /// <summary>
        /// 客户端删除设备
        /// </summary>
        /// <param name="token"></param>
        /// <param name="state"></param>
        /// <param name="callbackId"></param>
        /// <param name="data"></param>
        public static void OnDriveDeleteHandler(string token, int state, string callbackId, byte[] data)
        {
            if (state == 238)
            {
                ClassStatic.Result resultData = new ClassStatic.Result();
                resultData.ret = "false";

                // 判断设备信息是否存在
                if (ClassStatic.clientList.ContainsKey(token))
                {
                    // 解析客户端提交的数据
                    ClassStatic.ClientData clientData = ClassStatic.GetClientData(data);
                    // 判断提交的信息是否存在
                    if (clientData.str1 != "")
                    {
                        string mac = clientData.str1;
                        // 获取设备信息
                        ClassStatic.Client client = ClassStatic.clientList[token];

                        if(ClassStatic.sqlServer.Where("uid='" + client.uid + "' and mac='" + mac + "'").Delete("userDevice") > 0)
                        {
                            // 删除成功
                            /// 获取在线设备列表
                            List<string> clientOnlineList;
                            if (ClassStatic.clientOnlineList.ContainsKey(client.uid))
                            {
                                clientOnlineList = ClassStatic.clientOnlineList[client.uid];
                            }
                            else
                            {
                                clientOnlineList = new List<string>();
                            }
                            
                            foreach (string tokenTemp in clientOnlineList)
                            {
                                if(tokenTemp != token && ClassStatic.clientList[tokenTemp].mac != mac)
                                {
                                    ClassStatic.tcpServer.Send(tokenTemp, 238, ClassStatic.GetBytes("有设备被删除"));
                                }
                            }
                            resultData.ret = "true";
                        }
                    }
                }
                // 向客户端返回处理结果
                ClassStatic.tcpServer.Send(token, state, callbackId, ClassStatic.SetResultByte(resultData));
            }
        }


    }
}
