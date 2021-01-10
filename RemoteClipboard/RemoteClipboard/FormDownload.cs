using System;
using System.Net;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace RemoteClipboard
{
    public partial class FormDownload : Form
    {
        string url;
        string filename;
        bool isNotDownLoad = false;
        public FormDownload(string url, string filename)
        {
            InitializeComponent();
            this.Visible = false;
            this.url = url;
            this.filename = filename;
        }
        private void FormDownload_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>        
        /// c#,.net 下载文件        
        /// </summary>        
        /// <param name="URL">下载文件地址</param>       
        /// <param name="Filename">下载后的存放地址</param>        
        /// <param name="Prog">用于显示的进度条</param>        
        /// 
        public void DownloadFile(string URL, string filename, ProgressBar prog, Label label1)
        {
            float percent = 0;
            try
            {
                HttpWebRequest Myrq = WebRequest.Create(URL) as HttpWebRequest;
                HttpWebResponse myrp = Myrq.GetResponse() as HttpWebResponse;
                long totalBytes = myrp.ContentLength;

                if(totalBytes != -1)
                {
                    this.Visible = true;
                    System.IO.Stream st = myrp.GetResponseStream();
                    System.IO.Stream so = new System.IO.FileStream(filename, System.IO.FileMode.Create);
                    long totalDownloadedByte = 0;
                    byte[] by = new byte[1024];
                    int osize = st.Read(by, 0, (int)by.Length);
                    Application.DoEvents();
                    while (osize > 0)
                    {
                        if(isNotDownLoad)
                        {
                            break;
                        }
                        totalDownloadedByte = osize + totalDownloadedByte;
                        Application.DoEvents();
                        so.Write(by, 0, osize);
                        if (prog != null)
                        {
                            prog.Value = (int)totalDownloadedByte / (int)totalBytes * 1000000;
                        }
                        osize = st.Read(by, 0, (int)by.Length);

                        percent = (float)totalDownloadedByte / (float)totalBytes * 100;
                        label1.Text = percent.ToString() + "%";
                        Application.DoEvents();
                    }
                    if(percent >= 100)
                    {
                        StringCollection file = new StringCollection();
                        file.Add(filename);
                        ClassStatic.isRemoteClipboardData = 2;
                        Clipboard.SetFileDropList(file);
                    }
                    so.Close();
                    st.Close();
                }
            }
            catch (System.Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
        }

        private void FormDownload_FormClosing(object sender, FormClosingEventArgs e)
        {
            isNotDownLoad = true;
        }

        private void FormDownload_Shown(object sender, EventArgs e)
        {
            DownloadFile(url, filename, progressBar1, label2);
        }
    }
}
