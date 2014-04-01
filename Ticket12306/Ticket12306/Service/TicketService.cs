using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Waner8.Common;
using System.Text.RegularExpressions;
using System.Web;
using Ticket12306.Utility;

namespace Ticket12306.Service
{
    public class TicketService
    {
        public CookieContainer Cookies = new CookieContainer();
        public TicketService(CookieContainer cookies)
        {
            this.Cookies = cookies;
        }
        public string GetUserName()
        {
            HttpClient client =new HttpClient(Cookies);
            if (StaticValues.Proxy != "")
            {
                client.Proxy = new WebProxy(StaticValues.Proxy);
            }
            string url = "https://kyfw.12306.cn/otn/index/initMy12306";
            string result = client.Get(url);
            string userName = HtmlHelper.GetContent(result, "user_name=", ";").Replace("'", "");
            return Regex.Unescape(userName);
        }
        public QueryTicketResponseInfo QueryLeftTicketDTO(string train_date, string from_station, string to_station)
        {
            HttpClient client =new HttpClient(Cookies);
            if (StaticValues.Proxy != "")
            {
                client.Proxy = new WebProxy(StaticValues.Proxy);
            }
            string url = "https://kyfw.12306.cn/otn/leftTicket/query?leftTicketDTO.train_date={0}&leftTicketDTO.from_station={1}&leftTicketDTO.to_station={2}&purpose_codes=ADULT";
            url = string.Format(url, train_date, from_station, to_station);
            string result = client.Get(url);
            if (result != "")
            {
                QueryTicketResponseInfo ri = JsonHelper.JsonDeserialize<QueryTicketResponseInfo>(result);
                return ri;
            }
            else
                return null;
        }
        public GetPassengerDTOsResponseInfo GetMyPassengers()
        {
            HttpClient client = new HttpClient(Cookies);
            if (StaticValues.Proxy != "")
            {
                client.Proxy = new WebProxy(StaticValues.Proxy);
            }
            string url = "https://kyfw.12306.cn/otn/confirmPassenger/getPassengerDTOs";
            string result = client.Get(url);
            if (result != "")
            {
                GetPassengerDTOsResponseInfo ri = JsonHelper.JsonDeserialize<GetPassengerDTOsResponseInfo>(result);
                return ri;
            }
            else
                return null;
        }
        public void CheckUser()
        {
            HttpClient client = new HttpClient(Cookies);
            if (StaticValues.Proxy != "")
            {
                client.Proxy = new WebProxy(StaticValues.Proxy);
            }
            string url = "https://kyfw.12306.cn/otn/login/checkUser";
            string result = client.Post(url, "_json_att=", "kyfw.12306.cn", "https://kyfw.12306.cn", "https://kyfw.12306.cn/otn/leftTicket/init");
        }
        public bool SubmitOrderRequest(string secretStr,QueryEntity qe,ref string msg)
        {
            HttpClient client = new HttpClient(Cookies);
            if (StaticValues.Proxy != "")
            {
                client.Proxy = new WebProxy(StaticValues.Proxy);
            }
            string url = "https://kyfw.12306.cn/otn/leftTicket/submitOrderRequest";
            string data = "secretStr={0}&train_date={1}&back_train_date={2}&tour_flag=dc&purpose_codes=ADULT&query_from_station_name={3}&query_to_station_name={4}&undefined";
            object[] objs = new object[] { secretStr, qe.train_date, qe.train_date,qe.from_station_telecode_name, qe.to_station_telecode_name};
            data = string.Format(data, objs);
            url = url + "?" + data;
            string result = client.Get(url, "kyfw.12306.cn", "https://kyfw.12306.cn", "https://kyfw.12306.cn/otn/leftTicket/init").Replace("\"","");
            string status = HtmlHelper.GetContent(result, "status:", ",");
            msg = HtmlHelper.GetContent(result, "messages:", ",").Replace("[","").Replace("]","");
            return status == "true";
        }
        public TicketInfo GetTicketInfo()
        {
            try
            {
                TicketInfo ti = null;
                HttpClient client = new HttpClient(Cookies);
                if (StaticValues.Proxy != "")
                {
                    client.Proxy = new WebProxy(StaticValues.Proxy);
                }
                string url = "https://kyfw.12306.cn/otn/confirmPassenger/initDc";
                string result = client.Get(url, "kyfw.12306.cn", "https://kyfw.12306.cn", "https://kyfw.12306.cn/otn/leftTicket/init");
                var pTicketInfo = HtmlHelper.GetContent(result, "'leftDetails':\\[", "],");
                pTicketInfo = Regex.Unescape(pTicketInfo).Replace("'", "");
                string[] list = pTicketInfo.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (list.Length > 0)
                {
                    ti = new TicketInfo();
                    List<TickePriceInfo> tpiList = new List<TickePriceInfo>();
                    for (int i = 0; i < list.Length; i++)
                    {
                        string trainTicketInfoStr = list[i];
                        trainTicketInfoStr = trainTicketInfoStr.Replace("(", "#").Replace(")", "#");
                        string[] priceArray = trainTicketInfoStr.Split("#".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        TickePriceInfo tpi = new TickePriceInfo();
                        tpi.SeatType = priceArray[0];
                        tpi.Price = priceArray[1];
                        tpi.TicektCnt = priceArray[2];
                        tpiList.Add(tpi);
                    }
                    ti.TicketList = tpiList;
                    ti.Token = HtmlHelper.GetContent(result, "globalRepeatSubmitToken", ";").Replace("=", "").Replace("'", "").Trim();
                    string leftTicket = HtmlHelper.GetContent(result, "'queryLeftTicketRequestDTO':", "}");
                    leftTicket = leftTicket + "}";
                    QueryLeftTicketRequestDTO leftTicketRequst = JsonHelper.FromJson<QueryLeftTicketRequestDTO>(leftTicket);
                    //日期转换
                    string trainDate = leftTicketRequst.train_date;
                    leftTicketRequst.train_date = trainDate.Substring(0, 4) + "-" + trainDate.Substring(4, 2) + "-" + trainDate.Substring(6);
                    var key_check_isChange = HtmlHelper.GetContent(result, "'key_check_isChange':", ",").Replace("'", "");
                    var _temp = HtmlHelper.GetContent(result, "'queryLeftTicketRequestDTO':", "};");
                    _temp = _temp + "};";
                    var train_location = HtmlHelper.GetContent(_temp, "'train_location':", "};").Replace("'", "");
                    ti.CheckKey = key_check_isChange;
                    ti.TrainLocation = train_location;
                    ti.LeftTicketInfo = leftTicketRequst;
                }
                return ti;
            }
            catch
            {
                return null;
            }
        }
        public bool CheckOrderInfo(string token, string vc, List<PassengerInfo> list,ref string msg)
        {
            try
            {
                HttpClient client = new HttpClient(Cookies);
                if (StaticValues.Proxy != "")
                {
                    client.Proxy = new WebProxy(StaticValues.Proxy);
                }
                string passengerTicketStr = "";
                string oldpassengerTicketStr = "";
                foreach (PassengerInfo pi in list)
                {
                    var ap = pi.SeatType + ",0," + pi.TicketType + "," + pi.Passenger.passenger_name + "," + pi.Passenger.passenger_id_type_code + "," + pi.Passenger.passenger_id_no + "," + (pi.Passenger.phone_no == null ? "" : pi.Passenger.phone_no) + "," + "N";
                    passengerTicketStr += ap + "_";
                    var ao = pi.Passenger.passenger_name + "," + pi.Passenger.passenger_id_type_code + "," + pi.Passenger.passenger_id_no + "," + pi.Passenger.passenger_type;
                    oldpassengerTicketStr += ao + "_";
                }
                passengerTicketStr = HttpUtility.UrlEncode(passengerTicketStr);
                oldpassengerTicketStr = HttpUtility.UrlEncode(oldpassengerTicketStr);
                string data = "cancel_flag=2&bed_level_order_num=000000000000000000000000000000&passengerTicketStr={0}&oldPassengerStr={1}&tour_flag=dc&randCode={2}&_json_att=&REPEAT_SUBMIT_TOKEN={3}";
                string url = "https://kyfw.12306.cn/otn/confirmPassenger/checkOrderInfo";
                data = string.Format(data, passengerTicketStr, oldpassengerTicketStr, vc, token);
                string result = client.Post(url, data, "kyfw.12306.cn", "https://kyfw.12306.cn", "https://kyfw.12306.cn/otn/confirmPassenger/initDc");
                result = result.Replace("\"", "");
                bool flag = result.Contains("submitStatus:true");
                if (!flag)
                {
                    msg = HtmlHelper.GetContent(result, "errMsg:", ",");
                }
                return flag;
            }
            catch
            {
                return false;
            }
        }
        public CountInfo GetQueueCount(TicketInfo ti,string seatType)
        {
            try
            {
                HttpClient client = new HttpClient(Cookies);
                if (StaticValues.Proxy != "")
                {
                    client.Proxy = new WebProxy(StaticValues.Proxy);
                }
                string trainDate = ti.LeftTicketInfo.train_date + " 00:00:00"; ;
                trainDate = Convert.ToDateTime(trainDate).ToString("ddd MMM dd yyyy HH:mm:ss 'GMT'zzz ", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                trainDate = trainDate.Replace("08:00", "0800") + "(中国标准时间)";
                string trainNo = ti.LeftTicketInfo.train_no;
                string trainCode = ti.LeftTicketInfo.station_train_code;
                string leftTicket = ti.LeftTicketInfo.ypInfoDetail;
                string fromStationTelecode = ti.LeftTicketInfo.from_station;
                string toStationTelecode = ti.LeftTicketInfo.to_station;
                string purpose_codes = "00";
                string token = ti.Token;
                string data = "train_date={0}&train_no={1}&stationTrainCode={2}&seatType={3}&fromStationTelecode={4}&toStationTelecode={5}&leftTicket={6}&purpose_codes={7}&_json_att=&REPEAT_SUBMIT_TOKEN={8}";
                object[] objs = new object[] { HttpUtility.UrlEncode(trainDate), trainNo, trainCode, seatType, fromStationTelecode, toStationTelecode, leftTicket, purpose_codes, token };
                data = string.Format(data, objs);
                string url = "https://kyfw.12306.cn/otn/confirmPassenger/getQueueCount";
                string result = client.Post(url, data, "kyfw.12306.cn", "https://kyfw.12306.cn", "https://kyfw.12306.cn/otn/confirmPassenger/initDc");
                result = result.Replace("\"", "");
                string count = HtmlHelper.GetContent(result, "count:", ",");
                string ticket = HtmlHelper.GetContent(result, "ticket:", ",");
                string op_2 = HtmlHelper.GetContent(result, "op_2:", ",");
                string countT = HtmlHelper.GetContent(result, "countT:", ",");
                string op_1 = HtmlHelper.GetContent(result, "op_1:", "}");
                string ticketCnt = JsFuncitonHelper.GetCnt(ticket, seatType);
                CountInfo ci = new CountInfo();
                ci.count = count;
                ci.countT = countT;
                ci.op_1 = op_1;
                ci.op_2 = op_2;
                ci.ticket = ticket;
                ci.ticketCnt = ticketCnt;
                return ci;
            }
            catch
            {
                return null;
            }
        }
        public bool ConfirmSingleForQueue(TicketInfo ti,string vc,List<PassengerInfo> list,ref string msg)
        {
            try
            {
                msg = string.Empty;
                HttpClient client = new HttpClient(Cookies);
                if (StaticValues.Proxy != "")
                {
                    client.Proxy = new WebProxy(StaticValues.Proxy);
                }
                string passengerTicketStr = "";
                string oldpassengerTicketStr = "";
                foreach (PassengerInfo pi in list)
                {
                    var ap = pi.SeatType + ",0," + pi.TicketType + "," + pi.Passenger.passenger_name + "," + pi.Passenger.passenger_id_type_code + "," + pi.Passenger.passenger_id_no + "," + (pi.Passenger.phone_no == null ? "" : pi.Passenger.phone_no) + "," + "N";
                    passengerTicketStr += ap + "_";
                    var ao = pi.Passenger.passenger_name + "," + pi.Passenger.passenger_id_type_code + "," + pi.Passenger.passenger_id_no + "," + pi.Passenger.passenger_type;
                    oldpassengerTicketStr += ao + "_";
                }
                string token = ti.Token;
                string checkKey = ti.CheckKey;
                string leftTicket = ti.LeftTicketInfo.ypInfoDetail;
                passengerTicketStr = HttpUtility.UrlEncode(passengerTicketStr);
                oldpassengerTicketStr = HttpUtility.UrlEncode(oldpassengerTicketStr);
                string trainLocation = ti.TrainLocation;
                string purpose_codes = "00";
                string data = "passengerTicketStr={0}&oldPassengerStr={1}&randCode={2}&purpose_codes={3}&key_check_isChange={4}&leftTicketStr={5}&train_location={6}&_json_att=&REPEAT_SUBMIT_TOKEN={7}";
                data = string.Format(data, passengerTicketStr, oldpassengerTicketStr, vc, purpose_codes, checkKey, leftTicket, trainLocation, token);
                string url = "https://kyfw.12306.cn/otn/confirmPassenger/confirmSingleForQueue";
                string result = client.Post(url, data, "kyfw.12306.cn", "https://kyfw.12306.cn", "https://kyfw.12306.cn/otn/confirmPassenger/initDc");
                bool flag = result.Contains("submitStatus:true");
                if (!flag)
                {
                    msg = HtmlHelper.GetContent(result, "errMsg:", ",");
                }
                return flag;
            }
            catch
            {
                return false;
            }
        }
        public QueryWaitTimeResult QueryOrderWaitTime(string token)
        {
            try
            {
                HttpClient client = new HttpClient(Cookies);
                if (StaticValues.Proxy != "")
                {
                    client.Proxy = new WebProxy(StaticValues.Proxy);
                }
                string url = "https://kyfw.12306.cn/otn/confirmPassenger/queryOrderWaitTime?tourFlag=dc&_json_att=&REPEAT_SUBMIT_TOKEN=" + token;
                string result = client.Get(url, "kyfw.12306.cn", "https://kyfw.12306.cn", "https://kyfw.12306.cn/otn/confirmPassenger/initDc");
                string json = HtmlHelper.GetContent(result, "\"data\":", "},") + "}";
                QueryWaitTimeResult qw = JsonHelper.FromJson<QueryWaitTimeResult>(json);
                return qw;
            }
            catch
            {
                return null;
            }
        }
        public List<TrainDetails> GetTrainDetails(string train_no, string start_station, string aim_station, string date)
        {
            try
            {
                HttpClient client = new HttpClient(Cookies);
                if (StaticValues.Proxy != "")
                {
                    client.Proxy = new WebProxy(StaticValues.Proxy);
                }
                List<TrainDetails> list = new List<TrainDetails>();
                string url = "https://kyfw.12306.cn/otn/czxx/queryByTrainNo?";
                string data = "train_no=" + train_no + "&from_station_telecode=" + start_station + "&to_station_telecode=" + aim_station + "&depart_date=" + date; ;
                data = string.Format(data, train_no, start_station, aim_station, date);
                url = url + data;
                string result = client.Get(url);
                string json = HtmlHelper.GetContent(result, "\"data\":{\"data\":", "]}");
                json = json + "]";
                list = JsonHelper.FromJson<List<TrainDetails>>(json);
                return list;
            }
            catch
            {
                return null;
            }
 
        }
    }
}
