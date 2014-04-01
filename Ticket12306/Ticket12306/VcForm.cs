using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ticket12306.Service.Utility;
using System.Threading;

namespace Ticket12306
{
    public partial class VcForm : Form
    {
        AutoBuyTipForm aft = null;
        string token = string.Empty;
        public VcForm(AutoBuyTipForm atf, string token)
        {
            InitializeComponent();
            this.aft = atf;
            this.token = token;
            ShowVc();
            
        }
        public void ShowVc()
        {
            Thread thread = new Thread(() =>
                {
                    string code = string.Empty;
                    var img  = VcHelper.GetVcImage(StaticValues.OrderVcUrl, ref code, ref StaticValues.MyCookies, token);
                    if (this.InvokeRequired)
                    {
                        this.BeginInvoke(new MethodInvoker(delegate()
                            {
                                this.imgVc.Image = img;
                                if (code.Length == 4)
                                {
                                    txtVc.Text = code;
                                }
                                else
                                    txtVc.Text = "";
                            }));
                    }
                    else
                    {
                        this.imgVc.Image = img;
                        if (code.Length == 4)
                        {
                            txtVc.Text = code;
                        }
                        else
                            txtVc.Text = "";
                    }
                });
            thread.IsBackground = true;
            thread.Start();
        }

        private void txtVc_TextChanged(object sender, EventArgs e)
        {
            if (txtVc.Text.Length == 4)
            {
                string code = txtVc.Text.Trim();
                Thread t = new Thread(() =>
                    {
                        if (VcHelper.CheckVc(StaticValues.MyCookies, code, token))
                        {
                            this.BeginInvoke(new MethodInvoker(delegate()
                             {
                                 aft.code = code;
                                 this.DialogResult = DialogResult.OK;
                             }));
                        }
                        else
                        {
                            this.BeginInvoke(new MethodInvoker(delegate()
                               {
                                   txtVc.Clear();
                                   ShowVc();
                                   lbMsg.Text = "验证码输入错误！";
                               }));
                        }
                    });
                t.IsBackground = true;
                t.Start();
            }
        }

        private void imgVc_Click(object sender, EventArgs e)
        {
            ShowVc();
        }
    }
}
