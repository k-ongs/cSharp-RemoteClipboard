using System;
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
    public partial class ControlDeviceList : UserControl
    {
        private int DeviceOnlineCount = 1;
        public ControlDevice controlDeviceMyself = new ControlDevice();
        Dictionary<string, ControlDevice> controlDeviceOnline = new Dictionary<string, ControlDevice>();
        Dictionary<string, ControlDevice> controlDeviceOffline = new Dictionary<string, ControlDevice>();

        public ControlDeviceList()
        {
            InitializeComponent();
            flowLayoutPanelList.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelList.WrapContents = false;
            flowLayoutPanelList.HorizontalScroll.Maximum = 0;
            flowLayoutPanelList.AutoScroll = true;

            ClassStatic.tcpClient.OnServerReceiveHandler -= OnDeviceOnlineHandler;
            ClassStatic.tcpClient.OnServerReceiveHandler -= OnDeviceShutdownHandler;
            ClassStatic.tcpClient.OnServerReceiveHandler -= OnDeviceChangeStateHandler;
            ClassStatic.tcpClient.OnServerReceiveHandler += OnDeviceOnlineHandler;
            ClassStatic.tcpClient.OnServerReceiveHandler += OnDeviceShutdownHandler;
            ClassStatic.tcpClient.OnServerReceiveHandler += OnDeviceChangeStateHandler;
        }

        /// <summary>
        /// 有新的设备上线了
        /// </summary>
        /// <param name="state"></param>
        /// <param name="data"></param>
        public void OnDeviceOnlineHandler(int state, byte[] data)
        {
            if(state == 201)
            {
                this.Invoke(new Action(() => {
                    InitializeDeviceList();
                }));
            }
        }

        /// <summary>
        /// 有设备下线
        /// </summary>
        /// <param name="state"></param>
        /// <param name="data"></param>
        public void OnDeviceShutdownHandler(int state, byte[] data)
        {
            if (state == 202)
            {
                this.Invoke(new Action(() => {
                    InitializeDeviceList();
                }));
            }
        }

        /// <summary>
        /// 有设备改变运行状态
        /// </summary>
        /// <param name="state"></param>
        /// <param name="data"></param>
        public void OnDeviceChangeStateHandler(int state, byte[] data)
        {
            if (state == 203)
            {
                string token = ClassStatic.GetString(data);
                string stateDrive = token.Substring(token.Length - 2, 2);
                token = token.Substring(0, token.Length-2);
                this.Invoke(new Action(() => {
                    if (controlDeviceOnline.ContainsKey(token))
                    {
                        ControlDevice temp = controlDeviceOnline[token];
                        temp.Status = (stateDrive == "在线" ? 0 : 1);
                    }
                }));
            }
        }

        /// <summary>
        /// 刷新设备列表
        /// </summary>
        public void InitializeDeviceList()
        {
            DeviceOnlineCount = 1;
            flowLayoutPanelList.Controls.Clear();
            controlDeviceOnline.Clear();
            controlDeviceOffline.Clear();

            controlDeviceMyself.Title = System.Net.Dns.GetHostName();
            controlDeviceMyself.Mac = ClassStatic.GetMacByNetworkInterface();
            controlDeviceMyself.Status = ClassStatic.onlineStatus;
            controlDeviceMyself.Oneself = true;
            controlDeviceMyself.Portrait = ClassStatic.portraitPid;

            flowLayoutPanelList.Controls.Add(controlDeviceMyself);

            // 获取设备列表
            Action<bool, byte[]> action = new Action<bool, byte[]>(GetDeviceList_Callback);
            ClassStatic.tcpClient.Send(200, ClassStatic.GetBytes("获取设备列表"), action);
        }

        /// <summary>
        /// 获取设备列表回调函数
        /// </summary>
        /// <param name="state"></param>
        /// <param name="data"></param>
        private void GetDeviceList_Callback(bool state, byte[] data)
        {
            if(state)
            {
                this.Invoke(new Action(() => {
                    ClassStatic.ListDriveData listDriveData = ClassStatic.GetListDriveData(data);
                    if (listDriveData != null)
                    {
                        DeviceOnlineCount = 1;
                        foreach (ClassStatic.ListDrive drive in listDriveData.list)
                        {
                            ControlDevice temp = new ControlDevice();
                            temp.DeviceId = drive.mac;
                            temp.Title = drive.name;
                            temp.Mac = drive.mac;
                            temp.Portrait = Convert.ToInt32(drive.pid);
                            temp.Status = drive.state;
                            if (drive.token != "" && drive.token != null)
                            {
                                DeviceOnlineCount++;
                                controlDeviceOnline.Add(drive.token, temp);
                                flowLayoutPanelList.Controls.Add(temp);
                            }
                            else
                            {
                                controlDeviceOffline.Add(temp.Mac, temp);
                            }
                        }
                        foreach (ControlDevice temp in controlDeviceOffline.Values)
                        {
                            flowLayoutPanelList.Controls.Add(temp);
                        }

                        labelListNum.Text = "我的设备("+ DeviceOnlineCount + "/"+ (listDriveData.list.Count+1) + ")";
                    }
                }));
            }
        }

        /// <summary>
        /// 刷新设备列表按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            InitializeDeviceList();
        }
    }
}