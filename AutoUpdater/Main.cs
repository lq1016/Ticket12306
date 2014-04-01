using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace AutoUpdater
{
    public partial class Main : Form
    {
        UpdateInfo updateInfo = null;
        public Main(UpdateInfo ui)
        {
            InitializeComponent();
            updateInfo = ui;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.btnDrop.Enabled = false;
            this.btnOk.Enabled = false;
            this.Height = 282;
            Thread t = new Thread(() =>
            {
               
                for (int i = 0; i < updateInfo.FileList.Count; i++)
                {
                    string fileUrl = updateInfo.RootUrl + "/" + updateInfo.FileList[i];
                    DownloadFile(fileUrl, updateInfo.FileList[i]);
                }
                //启动
                Process.Start(updateInfo.ExcuteFileName);
                this.Close();
            });
            t.IsBackground = true;
            t.Start();
          
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.txtUpdate.Text = updateInfo.UpdateContent;
            this.Text = updateInfo.ExcuteName + "更新程序";
            lbOldVersion.Text = updateInfo.OldVersion;
            lbNewVersion.Text = updateInfo.NewVersion;
           
        }

        private void btnDrop_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("放弃此次更新，将不能继续使用，确定要放弃更新吗","取消更新确定",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            Application.Exit();
        }
        public void DownloadFile(string URL, string filename)
        {
            float percent = 0;
            try
            {
                string fileName = Application.StartupPath + "\\" + filename;
                System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
                System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();
                long totalBytes = myrp.ContentLength;
                if (prog != null)
                {
                    this.BeginInvoke(new MethodInvoker(delegate()
                    {
                        prog.Maximum = (int)totalBytes;
                    }));
                }
                System.IO.Stream st = myrp.GetResponseStream();
                System.IO.Stream so = new System.IO.FileStream(fileName, System.IO.FileMode.Create);
                long totalDownloadedByte = 0;
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    so.Write(by, 0, osize);
                    if (prog != null)
                    {
                        this.BeginInvoke(new MethodInvoker(delegate()
                        {
                            prog.Value = (int)totalDownloadedByte;
                        }));
                       
                    }
                    osize = st.Read(by, 0, (int)by.Length);
                    percent = (float)totalDownloadedByte * 1.0f / (float)totalBytes * 100;
                    this.BeginInvoke(new MethodInvoker(delegate()
                        {
                            lbDownInfo.Text = "正在下载" + filename + ",下载进度为:" + Math.Round(percent,2) + "%";
                        }));
                }
                so.Close();
                st.Close();
            }
            catch (System.Exception ex)
            {

            }
        }
    }
}
