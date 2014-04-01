using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Ticket12306.Service.Utility;
using Ticket12306.Resx;
using Ticket12306.Service;
using System.Diagnostics;
using Waner8.Common;

namespace Ticket12306
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void LoadVc()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate()
                {
                    imgVc.Image = Images.VcLoding;
                    toolStripMsg.Text = "正在加载验证码...";

                }));
            }
            else
            {
                imgVc.Image = Images.VcLoding;
                toolStripMsg.Text = "正在加载验证码...";

            }
            Thread t = new Thread(() =>
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    string code=string.Empty;
                    Image img = VcHelper.GetVcImage(StaticValues.LoginVcUrl, ref code, ref StaticValues.MyCookies);
                    sw.Stop();
                    this.BeginInvoke(new MethodInvoker(delegate() {
                        txtVc.Text = code;
                        imgVc.Image = img;
                        toolStripMsg.Text = "验证码加载成功,耗时:"+sw.ElapsedMilliseconds+"ms";
                    }));
                    
                });
            t.IsBackground = true;
            t.Start();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
            LoadVc();
        }
        #region 加载用户保存的用户信息
        private void LoadUsers()
        {
            if (StaticValues.MyUserList.Count > 0)
            {
                cbUserName.ValueMember = "pwd";
                cbUserName.DisplayMember = "username";
                cbUserName.DataSource = StaticValues.MyUserList;
                if (StaticValues.MyUserList.Count > 0)
                    cbUserName.SelectedIndex = 0;
            }
            else
            {
                cbUserName.DataSource = null;
                txtPwd.Clear();
            }
        }
        #endregion
        private void imgVc_Click(object sender, EventArgs e)
        {
            LoadVc();
           
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour == 23 || DateTime.Now.Hour < 7)
            {
                this.toolStripMsg.Text = "系统维护中，维护时间为23:00-07:00";
                return;
            }
            string userName = cbUserName.Text.Trim();
            string pwd = txtPwd.Text.Trim();
            string vc = txtVc.Text.Trim();
            if (userName != "" && pwd != "" && vc != "")
            {
                toolStripMsg.Text = "系统正在登陆中...";
                this.btnLogin.Enabled = false;
                string msg = string.Empty;
                Thread t = new Thread(() =>
                {
                    bool flag = LoginHelper.Login(userName, pwd, vc, ref msg, ref StaticValues.MyCookies);
                    if (flag)
                    {
                        TicketService service = new TicketService(StaticValues.MyCookies);
                        StaticValues.UserName = service.GetUserName();
                        StaticValues.PassengerList = service.GetMyPassengers().data.normal_passengers;
                        if (ckRememerUser.Checked)
                        {
                            UserManager.SaveUserInfo(userName, pwd);
                        
                        }
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        this.BeginInvoke(new MethodInvoker(delegate()
                        {
                            btnLogin.Enabled = true;
                            toolStripMsg.Text = msg;
                        }));
                    }
                });
                t.IsBackground = true;
                t.Start();
            }
            else
            {
                if (userName == "")
                {
                    toolStripMsg.Text = "请输入登录名~";
                    cbUserName.Focus();
                    return;
                }
                if (pwd == "")
                {
                    toolStripMsg.Text = "请输入密码~";
                    txtPwd.Focus();
                    return;
                }
                if (vc == "")
                {
                    toolStripMsg.Text = "请输入验证码~";
                    txtVc.Focus();
                    return;
                }
            }
        }

        private void cbUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUserName.SelectedIndex > -1)
            {
                txtPwd.Text = cbUserName.SelectedValue.ToString();
                lkDel.Visible = true;
            }
            else
            {
                txtPwd.Text = "";
                lkDel.Visible = false;
            }
        }

        private void lkDel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string userName = cbUserName.Text.Trim();
            if (userName != "")
            {
                UserManager.DelUserInfo(userName);
                StaticValues.MyUserList=UserManager.GetUsers();
                LoadUsers();
            }
        }

        private void cbUserName_Leave(object sender, EventArgs e)
        {
            string userName = cbUserName.Text.Trim();
            string pwd = UserManager.GetUserPwd(userName);
            lkDel.Visible = pwd != "";
            txtPwd.Text = pwd;
        }

        private void txtVc_TextChanged(object sender, EventArgs e)
        {
            //if (txtVc.Text.Length == 4)
            //{
            //    string code = txtVc.Text.Trim();
            //    if (VcHelper.CheckVc(StaticValues.MyCookies, code, ""))
            //    {
            //        btnLogin_Click(null, null);
            //    }
            //    else
            //    {
            //        toolStripMsg.Text = "验证码输入错误~";
            //        txtVc.Clear();
            //        LoadVc();
            //    }
            //}
        }



        private void txtVc_Validated(object sender, EventArgs e)
        {

        }

        private void chkUserOcr_CheckedChanged(object sender, EventArgs e)
        {
            StaticValues.UserOcr = chkUserOcr.Checked;
        }

       
    }
}
