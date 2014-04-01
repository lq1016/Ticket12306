using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Waner8.Common;
using System.Diagnostics;
using System.Threading;

namespace Ticket12306
{
    public partial class ProxyForm : Form
    {
        LoginForm lf = new LoginForm();
        public ProxyForm(LoginForm lf)
        {
            InitializeComponent();
            this.lf = lf;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (txtIP.Text.Trim() != "" && txtPort.Text.Trim() != "")
            {
                string proxy = txtIP.Text.Trim() + ":" + txtPort.Text.Trim();
                string result = string.Empty;
                btnTest.Enabled = false;
                Thread thread = new Thread(() =>
                    {
                        Stopwatch sw = new Stopwatch();
                        sw.Start();
                        HttpClient client = new HttpClient();
                        client.Proxy = new System.Net.WebProxy(proxy);
                        client.TimeOut = 2000;
                        try
                        {
                            string html = client.Get("http://www.baidu.com");
                            if (html != "")
                            {
                                result = "响应成功！";

                            }
                            else
                            {
                                result = "响应失败！";
                            }
                        }
                        catch
                        { }
                        sw.Stop();
                        result += ",响应花费:" + sw.ElapsedMilliseconds + "ms";
                        this.BeginInvoke(new MethodInvoker(delegate()
                        {
                            lbResult.Text = result;
                            btnTest.Enabled = true;
                        }));
                    });
                thread.IsBackground = true;
                thread.Start();
            }
            else
            {
                lbResult.Text = "请输入完整再提交！";
            }
        }

        private void btnUserProxy_Click(object sender, EventArgs e)
        {
            if (txtIP.Text.Trim() != "" && txtPort.Text.Trim() != "")
            {
                string proxy = txtIP.Text.Trim() + ":" + txtPort.Text.Trim();
                StaticValues.Proxy = proxy;
                this.Close();
            }
            else
            {
                lbResult.Text = "请输入完整再提交！";
            }

        }

        private void ProxyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (StaticValues.Proxy == "")
            {
                lf.chkUserOcr.Checked = false;
            }
        }
    }
}
