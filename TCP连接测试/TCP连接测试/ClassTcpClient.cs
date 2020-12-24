using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace TCP连接测试
{
    class ClassTcpClient
    {
        public Socket socketClient = null;
        public EndPoint iPEndPoint = null;
        public bool isConnected = false;

        
        public delegate void ServerReceiveHandler(byte state, byte[] data);
        public event ServerReceiveHandler OnServerReceiveHandler;

        public delegate void onServerCloseHandler();
        public event onServerCloseHandler OnServerCloseHandler;

        public ClassTcpClient(string host, int port)
        {
            iPEndPoint = new IPEndPoint(IPAddress.Parse(host), port);
            socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public bool Start()
        {
            try
            {
                socketClient.Connect(iPEndPoint);
                isConnected = true;

                Thread socketThread = new Thread(SocketClientReceive);
                socketThread.IsBackground = true;
                socketThread.Start();
            }
            catch {
                return false;
            }
            return true;
        }

        public void SocketClientReceive()
        {
            while (isConnected)
            {
                try
                {
                    byte[] data = new byte[1024];
                    int length = socketClient.Receive(data, data.Length, 0);


                    while (socketClient.Available > 0)
                    {
                        Thread.Sleep(100);
                        byte[] temp = new byte[1024];
                        int len = socketClient.Receive(temp, temp.Length, 0);
                        if (len > 0)
                        {
                            byte[] dataTemp = new byte[length + len];
                            data.CopyTo(dataTemp, 0);
                            temp.Take(len).ToArray().CopyTo(dataTemp, length);
                            length += len;
                            data = dataTemp;
                        }
                    }

                    if (length > 1)
                    {
                        // 获取标识码
                        byte state = data[length - 1];
                        // 截取数据
                        data = data.Take(length - 1).ToArray();
                        // 执行客户端信息响应事件
                        OnServerReceiveHandler?.Invoke(state, data);
                    }
                }
                catch
                {
                    OnServerCloseHandler?.Invoke();
                    return;
                }

                Thread.Sleep(100);
            }
        }

        public void SocketClientSend(byte state, byte[] data)
        {
            System.Diagnostics.Debug.WriteLine(BitConverter.ToString(data));
            data = data.Append(state).ToArray();
            System.Diagnostics.Debug.WriteLine(BitConverter.ToString(data));
            if (isConnected && socketClient != null)
            {
                
                socketClient.Send(data);
            }
        }
    }
}
