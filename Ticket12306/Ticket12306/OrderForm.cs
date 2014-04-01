using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Ticket12306.Resx;
using Ticket12306.Service.Utility;
using Ticket12306.Utility;

namespace Ticket12306
{
    public partial class OrderForm : Form
    {
        public TicketInfo ti = new TicketInfo();
        public OrderForm(TicketInfo ti)
        {
            InitializeComponent();
            this.ti = ti; 
            LoadVc();
            InitiControl(ti);
        }
        private void InitiControl(TicketInfo ti)
        {
            QueryLeftTicketRequestDTO qt=ti.LeftTicketInfo;
            string trainInfo=qt.train_date+" "+qt.station_train_code+"次 "+qt.from_station_name+"("+qt.start_time+") → "+qt.to_station_name+"("+qt.arrive_time+") 历时:"+qt.lishi;
            lbStationInfo.Text = trainInfo;
            int i = 0;
            int btnX = 2;
            int margin = 0;
            Font f = this.Font;
            Graphics g = this.plSeatType.CreateGraphics();
            foreach (TickePriceInfo tpi in ti.TicketList)
            {
                i++;
                string seatInfo = tpi.SeatType + tpi.TicektCnt + "(" + tpi.Price + ") ";
                string tag = tpi.SeatType;
                LinkLabel lnkSeatType = new LinkLabel();
                lnkSeatType.LinkBehavior = LinkBehavior.HoverUnderline;
                lnkSeatType.Tag = tpi.SeatType;
                lnkSeatType.Text = seatInfo;
                lnkSeatType.Name = "btnSeatType" + i;
                lnkSeatType.Location = new Point(btnX, 7);
                lnkSeatType.Font = f;
                lnkSeatType.ForeColor = Color.DarkOliveGreen;
                lnkSeatType.FlatStyle = FlatStyle.Flat;
                g.PageUnit = GraphicsUnit.Display;
                int leng = Convert.ToInt32(g.MeasureString(seatInfo, f).Width) + 10;
                lnkSeatType.Size = new Size(leng, 30);
                btnX = btnX + margin + leng;
                lnkSeatType.Enabled = !tpi.TicektCnt.Contains("无");
                plSeatType.Controls.Add(lnkSeatType);
                lnkSeatType.Click += new EventHandler(SelectSeat);
            }
            LoadPassenger(StaticValues.PassengerList);
            //默认选择自己
            for (int j = 0; j < chkListPassenger.Items.Count; j++)
            {
                PassengerDTOs p = (PassengerDTOs)chkListPassenger.Items[j];
                if (p.passenger_name == StaticValues.UserName)
                {
                    chkListPassenger.SetItemCheckState(j, CheckState.Checked);
                    break;
                }
            }
        }
        void SelectSeat(object sender, EventArgs e)
        {
            LinkLabel lnkSeatType = sender as LinkLabel;
            defaultSeatType = lnkSeatType.Tag.ToString().Trim();
            defaultSeatType = defaultSeatType.Contains("无座") ? "硬座" : defaultSeatType;
            BindPassengerGrid(myList);
        }
        private void LoadPassenger(List<PassengerDTOs> list)
        {
            this.chkListPassenger.DataSource = list;
            this.chkListPassenger.DisplayMember = "passenger_name";
            this.chkListPassenger.ValueMember = "passenger_id_no";
            this.chkListPassenger.SelectedIndex = -1;
            chkListPassenger.ItemCheck -= new ItemCheckEventHandler(chkListPassenger_ItemCheck);
            for (int i = 0; i < chkListPassenger.Items.Count; i++)
            {
                PassengerDTOs p = ((PassengerDTOs)this.chkListPassenger.Items[i]);
                if (myList.Contains(p))
                {
                    this.chkListPassenger.SetItemChecked(i, true);
                }
                else
                {
                    this.chkListPassenger.SetItemChecked(i, false);
                }
            }
            chkListPassenger.ItemCheck += new ItemCheckEventHandler(chkListPassenger_ItemCheck);
        }
        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            string key = txtKey.Text.Trim().ToUpper();
            List<PassengerDTOs> list = StaticValues.PassengerList;
            List<PassengerDTOs> listFilter = list.FindAll(p => p.passenger_name.Contains(key) || p.first_letter.ToUpper().Contains(key));
            LoadPassenger(listFilter);
        }
        List<PassengerDTOs> myList = new List<PassengerDTOs>();
        #region 加载验证码
        private void LoadVc()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate()
                {
                    imgVc.Image = Images.VcLoding;
                }));
            }
            else
            {
                imgVc.Image = Images.VcLoding;
            }
            Thread t = new Thread(() =>
            {
                string code = string.Empty;
                Image img = VcHelper.GetVcImage(StaticValues.OrderVcUrl, ref code, ref StaticValues.MyCookies, ti.Token);
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new MethodInvoker(delegate()
                    {
                        txtVc.Text = code;
                        imgVc.Image = img;
                    }));
                }
                else
                {
                    txtVc.Text = code;
                    imgVc.Image = img;
                }
            });
            t.IsBackground = true;
            t.Start();
        }
        #endregion
        private string defaultSeatType = string.Empty;
        private void BindPassengerGrid(List<PassengerDTOs> list)
        {
            //1.绑定席别
            DataTable dtseatType = new DataTable();
            dtseatType.Columns.Add("seatType");
            dtseatType.Columns.Add("code");
            for (int i = 0; i < ti.TicketList.Count; i++)
            {
                string ticketCnt = ti.TicketList[i].TicektCnt;
                string seatType = ti.TicketList[i].SeatType;
                if (ticketCnt.IndexOf("张票") > -1 || ticketCnt.IndexOf("有") > -1)
                {
                    seatType = seatType == "无座" ? "硬座" : seatType;
                    if (dtseatType.Select("seatType='" + seatType + "'").Length == 0)
                    {
                        DataRow row = dtseatType.NewRow();
                        row["seatType"] = seatType;
                        row["code"] = StaticValues.DicSeatType[seatType];
                        dtseatType.Rows.Add(row);
                    }
                }
            }
            defaultSeatType = defaultSeatType == string.Empty ? dtseatType.Rows[0]["seatType"].ToString().Trim() : defaultSeatType;
            if (dtseatType.Rows.Count > 0)
            {
                ((DataGridViewComboBoxColumn)dgPassenger.Columns["colSeatType"]).DataSource = dtseatType;
                ((DataGridViewComboBoxColumn)dgPassenger.Columns["colSeatType"]).ValueMember = "code";
                ((DataGridViewComboBoxColumn)dgPassenger.Columns["colSeatType"]).DisplayMember = "seatType";
                ((DataGridViewComboBoxColumn)dgPassenger.Columns["colSeatType"]).DataPropertyName = "seatType";
                ((DataGridViewComboBoxColumn)dgPassenger.Columns["colSeatType"]).DefaultCellStyle.NullValue = defaultSeatType;
                ((DataGridViewComboBoxColumn)dgPassenger.Columns["colSeatType"]).DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            }
            DataTable dtPiaozhong = new DataTable();
            dtPiaozhong.Columns.Add("name");
            dtPiaozhong.Columns.Add("value");
            foreach (string key in StaticValues.DicTicketType.Keys)
            {
                DataRow row = dtPiaozhong.NewRow();
                row["name"] = key;
                row["value"] = StaticValues.DicTicketType[key];
                dtPiaozhong.Rows.Add(row);
            }
            ((DataGridViewComboBoxColumn)dgPassenger.Columns["colTicketType"]).DataSource = dtPiaozhong;
            ((DataGridViewComboBoxColumn)dgPassenger.Columns["colTicketType"]).ValueMember = "value";
            ((DataGridViewComboBoxColumn)dgPassenger.Columns["colTicketType"]).DisplayMember = "name";
            ((DataGridViewComboBoxColumn)dgPassenger.Columns["colTicketType"]).DefaultCellStyle.NullValue = dtPiaozhong.Rows[0]["name"];
            ((DataGridViewComboBoxColumn)dgPassenger.Columns["colTicketType"]).DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            //绑定
            DataTable dtGoupiao = new DataTable();
            dtGoupiao.Columns.Add("xh");
            dtGoupiao.Columns.Add("xm");
            dtGoupiao.Columns.Add("zjhm");
            dtGoupiao.Columns.Add("sjhm");
            dtGoupiao.Columns.Add("zjlx");
            for (int i = 0; i < list.Count; i++)
            {
                DataRow row = dtGoupiao.NewRow();
                string xm = list[i].passenger_name;
                string xh = "第" + (i + 1) + "位";
                string zjhm = list[i].passenger_id_no;
                string zjlx = list[i].passenger_id_type_name;
                string sjhm = list[i].mobile_no;
                row["xh"] = xh;
                row["xm"] = xm;
                row["zjhm"] = zjhm;
                row["zjlx"] = zjlx;
                row["sjhm"] = sjhm;
                dtGoupiao.Rows.Add(row);
            }
            this.dgPassenger.DataSource = dtGoupiao;
            this.dgPassenger.EditMode = DataGridViewEditMode.EditOnEnter;
        }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="logInfo"></param>
        /// <param name="tb"></param>
        private void WriteLog(string logInfo, TextBox tb)
        {  
            logInfo = "[" + DateTime.Now.ToString() + "] " + logInfo;
            if (tb.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate()
                {
                    tb.Text = logInfo + "\r\n" + tb.Text;
                }));
            }
            else
            {
                tb.Text = logInfo + "\r\n" + tb.Text;
            }
            Thread.Sleep(500);
        }
        private void btnOrder_Click(object sender, EventArgs e)
        {
            List<PassengerInfo> list = new List<PassengerInfo>();
            //循环获取乘客信息
            if (txtVc.Text.Length == 4)
            {
                string vc = txtVc.Text.Trim();
                string pssengerstr = string.Empty;
                if (this.dgPassenger.Rows.Count > 0)
                {
                    for (int i = 0; i < this.dgPassenger.Rows.Count; i++)
                    {
                        string seatType = this.dgPassenger.Rows[i].Cells[0].FormattedValue.ToString();
                        seatType = StaticValues.DicSeatType[seatType];
                        string ticketType = this.dgPassenger.Rows[i].Cells[1].FormattedValue.ToString();
                        ticketType = StaticValues.DicTicketType[ticketType];
                        list.Add(new PassengerInfo() { Passenger = myList[i], TicketType = ticketType, SeatType = seatType });
                    }
                    this.btnOrder.Enabled = false;
                    Thread orderThread = new Thread(() => { DoOrder(vc, list); });
                    orderThread.IsBackground = true;
                    orderThread.Start();
                }
                else
                    MessageBox.Show("请至少选择一名乘客信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("请输入验证码！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void DoOrder(string vc, List<PassengerInfo> list)
        {
            string seatType=list[0].SeatType;
            WriteLog("订单确认中...", txtLog);
            string msg = string.Empty;
            bool flag = TicketHelper.CheckOrderInfo(ti.Token, vc, list,ref msg);
            if (flag)
            {
                bool canBuy = true;
                CountInfo ci = TicketHelper.GetQueueCount(ti, seatType);
               string[] seatInfo = ci.ticketCnt.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
               string info=string.Empty;
                if(seatInfo.Length==2)
                {
                    info = "本次列车，剩余" + "[" + StaticValues.DicSeatType1[seatType] + "]" + seatInfo[0] + "张,[无座]" + seatInfo[1] + "张。";
                }
                if (seatInfo.Length == 1)
                {
                    info = "本次列车，剩余" + "[" + StaticValues.DicSeatType1[seatType] + "]" + seatInfo[0] + "张。";
                }
               if (ci.op_2 == "true")
               {
                   info += "目前排队人数已经超过余票张数，请您选择其他席别或车次。";
                   canBuy = false;
               }
               else
               {
                   if (Convert.ToInt32(ci.countT) > 0)
                   {
                       info += "目前排队人数" + ci.countT + "人";
                   }
               }
               WriteLog(info, txtLog);
               if (canBuy)
               {
                   WriteLog("正在处理订单中，请稍后...", txtLog);
                   //确认
                   flag = TicketHelper.ConfirmSingleForQueue(ti, vc, list, ref msg);
                   WriteLog("订单处理成功，正在检查订单状态...", txtLog);
                   while (true)
                   {
                       var result = TicketHelper.QueryOrderWaitTime(ti.Token);
                       if (result != null)
                       {
                           if (result.waitTime <= 0)
                           {
                               if (result.orderId != "")
                               {
                                   string tip = "恭喜你，订单完成，订单编号为:" + result.orderId + "！";
                                   MessageBox.Show(tip, "订单成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                   this.BeginInvoke(new MethodInvoker(delegate()
                                   {
                                       TipForm tf = new TipForm(tip, "订单号:" + result.orderId);
                                       tf.Show();
                                       this.Close();
                                   }));
                               }
                               else
                               {
                                   WriteLog("出票失败，可能没有足够的票!", txtLog);
                               }
                               break;
                           }
                           else
                           {
                               string tip = result.count > 0 ? "你前面还有" + result.count + "个订单要处理，大约需要等待时间:" + result.waitTime + "秒" : "订单正在处理，大概需要等待+:" + result.waitTime + "秒";
                               WriteLog(tip, txtLog);
                               Thread.Sleep(500);
                           }
                       }
                   }
               }
               else
               {
                   this.WriteLog(msg, this.txtLog);
                   this.BeginInvoke(new MethodInvoker(delegate()
                   {
                       this.btnOrder.Enabled = true;
                   }));
                   LoadVc();
               }
            }
            else
            {
                this.WriteLog(msg, this.txtLog);
                this.BeginInvoke(new MethodInvoker(delegate()
                {
                    this.btnOrder.Enabled = true;
                }));
                LoadVc();
            }
        }

        private void chkListPassenger_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            PassengerDTOs p = ((PassengerDTOs)this.chkListPassenger.Items[e.Index]);
            if (e.NewValue == CheckState.Checked)
            {
                if (myList.Count == 5)
                {
                    e.NewValue = CheckState.Unchecked;
                    MessageBox.Show("对不起，你最多只能选择5位联系人！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!myList.Contains(p))
                    {
                        myList.Add(p);
                    }
                }
            }
            else
            {
                myList.Remove(p);
            }
            BindPassengerGrid(myList);
        }

        private void imgVc_Click(object sender, EventArgs e)
        {
            LoadVc();
        }

        private void linkRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtKey.Text = "";
            myList.Clear();
            TicketHelper.GetPassengers();
            BindPassengerGrid(myList);
            LoadPassenger(StaticValues.PassengerList);
        }

        private void txtVc_TextChanged(object sender, EventArgs e)
        {
            //if (txtVc.Text.Length == 4)
            //{
            //    string code = txtVc.Text.Trim();
            //    if (VcHelper.CheckVc(StaticValues.MyCookies, code, ti.Token))
            //    {
            //        btnOrder_Click(null, null);
            //    }
            //    else
            //    {
            //        txtVc.Clear();
            //        LoadVc();
            //        WriteLog("验证码输入错误!", txtLog);
            //    }
            //}
        }
    }
}
