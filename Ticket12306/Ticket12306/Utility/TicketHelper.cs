using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using Ticket12306.Service;
using Ticket12306.Resx;
using System.Net;
using System.Web;
using System.Text.RegularExpressions;
using Waner8.Common;

namespace Ticket12306.Utility
{
    public class TicketHelper
    {
        public static DataTable CreateTicketDt()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TrainCode");
            dt.Columns.Add("TrainCodeKey");
            dt.Columns.Add("StartStation");
            dt.Columns.Add("AimStation");
            dt.Columns.Add("TakeTime");
            dt.Columns.Add("ShangWu");
            dt.Columns.Add("TeDeng");
            dt.Columns.Add("YiDeng");
            dt.Columns.Add("ErDeng");
            dt.Columns.Add("GaoJiRuanWo");
            dt.Columns.Add("RuanWo");
            dt.Columns.Add("YingWo");
            dt.Columns.Add("RuanZuo");
            dt.Columns.Add("YingZuo");
            dt.Columns.Add("WuZuo");
            dt.Columns.Add("QiTa");
            dt.Columns.Add("OrderKey");
            dt.Columns.Add("CanOrder");
            dt.Columns.Add("Order", typeof(Image));
            dt.Columns.Add("First");
            dt.Columns.Add("Last");
            dt.AcceptChanges();
            return dt;
        }
        public static DataTable GetLeftTicket(ref QueryEntity qe)
        {
            DataTable dtTicket = CreateTicketDt();
            if (qe.optionDates.Contains(qe.train_date))
            {
                qe.optionDates.Remove(qe.train_date);
            }
            qe.optionDates.Insert(0, qe.train_date);
            TicketService service = new TicketService(StaticValues.MyCookies);
            for (int i = 0; i < qe.optionDates.Count; i++)
            {
                string date=qe.optionDates[i];
                qe.train_date = date;
                QueryTicketResponseInfo rspInfo = service.QueryLeftTicketDTO(qe.train_date, qe.from_station_telecode, qe.to_station_telecode);
                if (rspInfo!=null&&rspInfo.status)
                {
                    if (rspInfo.data != null && rspInfo.data.Count > 0)
                    {
                        string[] timeArray = qe.start_time_str.Split("--".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        int beginTime = Convert.ToInt32(timeArray[0].Replace(":", ""));
                        int endTime = Convert.ToInt32(timeArray[1].Replace(":", ""));
                        foreach (QueryLeftNewDTOData q in rspInfo.data)
                        {
                            bool flag = CheckTrainClass(q, qe);
                            if (flag)
                            {
                                int startTime = Convert.ToInt32(q.queryLeftNewDTO.start_time.Replace(":", ""));
                                if (startTime >= beginTime && endTime >= startTime)
                                {
                                    if ((qe.trainNoList!=null&&qe.trainNoList.Count>0&&qe.trainNoList.Contains(q.queryLeftNewDTO.station_train_code))||qe.trainNoList==null||qe.trainNoList.Count==0)
                                    {
                                        DataRow row = dtTicket.NewRow();
                                        row["TrainCode"] = q.queryLeftNewDTO.station_train_code;
                                        row["TrainCodeKey"] = q.queryLeftNewDTO.train_no + "#" + q.queryLeftNewDTO.start_station_telecode + "#" + q.queryLeftNewDTO.to_station_telecode;
                                        row["StartStation"] = q.queryLeftNewDTO.from_station_name + "(" + q.queryLeftNewDTO.start_time + ")";
                                        row["AimStation"] = q.queryLeftNewDTO.to_station_name + "(" + q.queryLeftNewDTO.arrive_time + ")";
                                        row["TakeTime"] = q.queryLeftNewDTO.lishi;
                                        row["ShangWu"] = q.queryLeftNewDTO.swz_num;
                                        row["TeDeng"] = q.queryLeftNewDTO.tz_num;
                                        row["YiDeng"] = q.queryLeftNewDTO.zy_num;
                                        row["ErDeng"] = q.queryLeftNewDTO.ze_num;
                                        row["GaoJiRuanWo"] = q.queryLeftNewDTO.gr_num;
                                        row["RuanWo"] = q.queryLeftNewDTO.rw_num;
                                        row["YingWo"] = q.queryLeftNewDTO.yw_num;
                                        row["RuanZuo"] = q.queryLeftNewDTO.rz_num;
                                        row["YingZuo"] = q.queryLeftNewDTO.yz_num;
                                        row["WuZuo"] = q.queryLeftNewDTO.wz_num;
                                        row["QiTa"] = q.queryLeftNewDTO.qt_num;
                                        row["OrderKey"] = q.secretStr;
                                        bool last = q.queryLeftNewDTO.to_station_name == q.queryLeftNewDTO.end_station_name;
                                        row["Last"] = last;
                                        bool first = q.queryLeftNewDTO.from_station_name == q.queryLeftNewDTO.start_station_name;
                                        row["First"] = first;
                                        row["Order"] = Images.Order;
                                        dtTicket.Rows.Add(row);
                                    }
                                }
                            }
                        }
                        dtTicket = FilterResultBySeat(dtTicket, qe);
                    }
                }
                if (dtTicket.Rows.Count > 0)
                {
                    break;
                }
            }
            return dtTicket;
        }
        public static bool CheckTrainClass(QueryLeftNewDTOData q, QueryEntity qe)
        {
            bool flag = false;
            if (qe.trainClass.Contains("QB"))
            {
                flag = true;
            }
            else
            {
                List<string> trainClasslist = qe.trainClass.Split("#".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                string trainCode = q.queryLeftNewDTO.station_train_code.Substring(0, 1).ToUpper();
                trainClasslist.ForEach(t => {
                    if (t.Contains(trainCode))
                    {
                        flag = true;
                    }
                });
               
            }
            return flag;
        }
  
        #region 过滤席别
        private static DataTable FilterResultBySeat(DataTable dt, QueryEntity qe)
        {
            DataTable dtTemp = dt.Clone();
            //过滤座位
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!FilterRowBySeat(dt.Rows[i], qe.seatTypeList))
                {
                    DataRow row = dtTemp.NewRow();
                    for (int j = 0; j < dtTemp.Columns.Count; j++)
                        row[j] = dt.Rows[i][j];
                    dtTemp.Rows.Add(row);
                }
            }
            dtTemp.AcceptChanges();
            return dtTemp;
        }
        private static bool FilterRowBySeat(DataRow row, List<string> list)
        {
            bool flag = true;//默认是要过滤的
            foreach (string seat in list)
            {
                string value = row[seat].ToString().Trim();
                if (Common.IsNumeric(value) || value.IndexOf("有") > -1)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        #endregion
    
        public static TicketInfo GetTicketInfo(string secretStr, QueryEntity qe,ref string msg)
        {
            TicketInfo ti = null;
            TicketService service = new TicketService(StaticValues.MyCookies);
            bool flag = service.SubmitOrderRequest(secretStr, qe, ref msg);
            if (flag)
            {
                ti = service.GetTicketInfo();
            }
            return ti;
        }

        public static void GetPassengers()
        {
            TicketService service = new TicketService(StaticValues.MyCookies);
            GetPassengerDTOsResponseInfo ri = service.GetMyPassengers();
            StaticValues.PassengerList= ri.data.normal_passengers;
        }
        public static bool CheckOrderInfo(string token, string vc, List<PassengerInfo> list,ref string msg)
        {
            TicketService service = new TicketService(StaticValues.MyCookies);
            return service.CheckOrderInfo(token,vc,list,ref msg);
        }
        public static CountInfo GetQueueCount(TicketInfo ti, string seatType)
        {
            TicketService service = new TicketService(StaticValues.MyCookies);
            return service.GetQueueCount(ti, seatType);
        }
        public static bool ConfirmSingleForQueue(TicketInfo ti, string vc, List<PassengerInfo> list, ref string msg)
        {
            TicketService service = new TicketService(StaticValues.MyCookies);
            return service.ConfirmSingleForQueue(ti, vc,list,ref msg);
        }
        public static QueryWaitTimeResult QueryOrderWaitTime(string token)
        {
            TicketService service = new TicketService(StaticValues.MyCookies);
            return service.QueryOrderWaitTime(token);
        }
        public static List<TrainDetails> GetTrainDetails(string train_no, string start_station, string aim_station, string date)
        {
            TicketService service = new TicketService(StaticValues.MyCookies);
            return service.GetTrainDetails(train_no, start_station, aim_station, date);
        }
    }
}
