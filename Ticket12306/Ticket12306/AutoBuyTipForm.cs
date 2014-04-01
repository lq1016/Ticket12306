using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Ticket12306.Utility;
using Ticket12306.Service.Utility;

namespace Ticket12306
{
    public partial class AutoBuyTipForm : Form
    {
        DataTable dt = new DataTable();
        QueryEntity qe=new QueryEntity();
        List<PassengerDTOs> passengerList = new List<PassengerDTOs>();
        public string code = string.Empty;
        public AutoBuyTipForm(DataTable dt,QueryEntity qe,List<PassengerDTOs> passengerList)
        {
            InitializeComponent();
            this.dt = dt;
            this.qe=qe;
            this.passengerList = passengerList;
            Thread t = new Thread(() =>
                {
                    DoOrder();
                });
            t.IsBackground = true;
            t.Start();
        }
        private void DoOrder()
        {
            try
            {
                string canBuyTrainCode = string.Empty;
                DataTable dtTrainCode = dt.DefaultView.ToTable("TrainCode");
                for (int i = 0; i < dtTrainCode.Rows.Count; i++)
                {
                    string trainCode = dtTrainCode.Rows[i][0].ToString().Trim();
                    if (canBuyTrainCode == "")
                    {
                        canBuyTrainCode = trainCode;
                    }
                    else
                    {
                        canBuyTrainCode = canBuyTrainCode + "," + trainCode;
                    }
                    canBuyTrainCode = canBuyTrainCode + ",";
                }
                WriteLog("查询到符合条件的车次有" + dt.Rows.Count + "个:" + canBuyTrainCode + ".", txtLog);
                //尝试订票
                string msg = string.Empty;
                bool exit = false;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!exit)
                    {
                        DataRow row = dt.Rows[i];
                        string _trainCode = row["TrainCode"].ToString().Trim();
                        List<string> seatList = GetSeatList(row);
                        if (seatList.Count > 0)
                        {
                            for (int j = 0; j < seatList.Count; j++)
                            {
                                string seatName = seatList[j];
                                string seatType = StaticValues.DicSeatType[seatName];
                                WriteLog("正在尝试预定：" + _trainCode + "次," + seatName, txtLog);
                                string _orderKey = dt.Rows[i]["OrderKey"].ToString().Trim();
                                WriteLog("正在提取预定车次信息...", txtLog);
                                TicketInfo ti = TicketHelper.GetTicketInfo(_orderKey, qe, ref msg);
                                if (ti != null)
                                {
                                    List<PassengerInfo> _passengerList = Convert2PassengerInfo(seatType);
                                    WriteLog("正在加载并识别验证码...", txtLog);
                                    VcForm vcForm = new VcForm(this, ti.Token);
                                    if (vcForm.ShowDialog() == DialogResult.OK)
                                    {
                                        WriteLog("订单确认中...", txtLog);
                                        bool flag = TicketHelper.CheckOrderInfo(ti.Token, code, _passengerList, ref msg);
                                        if (flag)
                                        {
                                            bool canBuy = true;
                                            CountInfo ci = TicketHelper.GetQueueCount(ti, seatType);
                                            string[] seatInfo = ci.ticketCnt.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                                            string info = string.Empty;
                                            if (seatInfo.Length == 2)
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
                                                flag = TicketHelper.ConfirmSingleForQueue(ti, code, _passengerList, ref msg);
                                                WriteLog("订单处理成功，正在检查订单状态...", txtLog);
                                                while (true)
                                                {
                                                    var result = TicketHelper.QueryOrderWaitTime(ti.Token);
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
                                                break;
                                            }
                                            else
                                            {
                                                this.WriteLog(msg, this.txtLog);
                                            }
                                        }
                                        else
                                        {
                                            exit = true;
                                            if (msg == "")
                                            {
                                                msg = "订单确认失败或者网络超时！";
                                            }
                                            this.WriteLog(msg, this.txtLog);
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        exit = true;
                                        this.WriteLog("提取预定车次信息错误！", this.txtLog);
                                        break;
                                    }
                                }
                                else
                                {
                                    exit = true;
                                    if (msg.Contains("您还有未处理的订单"))
                                    {
                                        msg = "您还有未处理的订单,请处理完后再订票！";
                                    }
                                    this.WriteLog(msg, this.txtLog);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            WriteLog(_trainCode + "票数不够！", txtLog);
                        }
                    }
                }
                WriteLog("本次自动购票结束！", txtLog);
            }
            catch
            { }
        }
        private List<PassengerInfo> Convert2PassengerInfo(string seatType)
        {
            List<PassengerInfo> list = new List<PassengerInfo>();
            for (int i = 0; i < passengerList.Count; i++)
            {
                list.Add(new PassengerInfo() { Passenger = passengerList[i], TicketType = passengerList[i].passenger_type, SeatType = seatType });
            }
            return list;
        }
        private List<string> GetSeatList(DataRow row)
        {
            List<string> seatList = new List<string>();
            if (qe.seatTypeList.Count > 0)
            {
                foreach (string filter in qe.seatTypeList)
                {
                    var _filter = filter;
                    string value = row[_filter].ToString();
                    if ((Common.IsNumeric(value) && Convert.ToInt32(value) >= passengerList.Count) || value.IndexOf("有") > -1)
                    {
                        if (_filter == "WuZuo")
                        {
                            _filter = "YingZuo";
                        }
                        string seatName = StaticValues.DicSeat[_filter];
                        if (!seatList.Contains(seatName))
                        {
                            seatList.Add(seatName);
                        }
                    }
                }
            }
            return seatList;
        }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="logInfo"></param>
        /// <param name="tb"></param>
        private void WriteLog(string logInfo, TextBox tb)
        {
            if(!string.IsNullOrEmpty(logInfo))
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
        }
    }
}
