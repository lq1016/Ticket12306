using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net;

namespace Ticket12306
{
    public class Station
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string ShortName{get;set;}
        public string ShortName1{get;set;}
        public string FullName{get;set;}
    }
    public class QueryEntity
    {
        public string from_station_telecode_name { get; set; }
        public string to_station_telecode_name { get; set; }
        public string train_date { get; set; }
        public string from_station_telecode { get; set; }
        public string to_station_telecode { get; set; }
        public string trainClass { get; set; }
        public string start_time_str { get; set; }
        public List<string> seatTypeList { get; set; }
        public List<string> trainNoList { get; set; }
        public List<string> optionDates { get; set; }
    }
    public class KeyValue
    {
        public string value { get; set; }
        public string name { get; set; }
    }
    public class LineInfo
    {
        public int y { get; set; }
        public List<int> xList { get; set; }
    }
     public class CodeEntity
    {
        public string CharStr { get; set; }
        public string GuiyiCode { get; set; }
    }
    public class StaticValues
    {
        public static bool AutoLoadVc = true;
        public static string LoginVcUrl = "https://kyfw.12306.cn/otn/passcodeNew/getPassCodeNew?module=login&rand=sjrand";//登陆的验证码地址
        public static string OrderVcUrl = "https://kyfw.12306.cn/otn/passcodeNew/getPassCodeNew?module=passenger&rand=randp";//下订单的验证码
        public static string Proxy = "";
        public static bool UserOcr = true;
        public static List<CodeEntity> CodeList0 = new List<CodeEntity>();
        public static List<CodeEntity> CodeList = new List<CodeEntity>();
        public static List<CodeEntity> CodeList1 = new List<CodeEntity>();
        public static List<CodeEntity> CodeList2 = new List<CodeEntity>();
        public static List<CodeEntity> CodeList3 = new List<CodeEntity>();
        public static CookieContainer MyCookies = new CookieContainer();
        public static List<KeyValue> TrainClassList = new List<KeyValue>
        { 
            new KeyValue(){ name = "全部", value = "QB" },
            new KeyValue(){ name = "动车", value = "D" } ,   
            new KeyValue(){ name = "Z字头", value = "Z" } ,  
            new KeyValue(){ name = "T字头", value = "T" } ,  
            new KeyValue(){ name = "K字头", value = "K" } ,  
            new KeyValue{ name = "其他", value = "QT" }  
        
        };
        public static List<PassengerDTOs> PassengerList = new List<PassengerDTOs>();
        public static Dictionary<string, string> DicSeatType = new Dictionary<string, string>()
        { 
               {"商务座", "9"},
               {"特等座", "P"},
                {"一等软座", "7"},
                {"二等软座", "8"},
               {"一等座", "M"},
               {"二等座", "O"},
               {"高级软卧", "6"},
               {"软卧", "4"},
               {"硬卧", "3"},
               {"软座", "2"},
               {"硬座", "1"},
               {"无座","1"}
        };
        public static Dictionary<string, string> DicSeatType1 = new Dictionary<string, string>()
        { 
               {"9","商务座"},
               {"P","特等座"},
               {"M","一等座"},
               {"O","二等座"},
               {"6","高级软卧"},
               {"4","软卧"},
               {"3","硬卧"},
               {"2","软座"},
               {"1","硬座"},
               {"7","一等软座"},
               {"8","二等软座"}
        };
        public static Dictionary<string, string> DicSeat = new Dictionary<string, string>()
        { 
               {"ShangWu", "商务座"},
               {"TeDeng", "特等座"},
               {"YiDeng", "一等座"},
               {"ErDeng", "二等座"},
               {"GaoJiRuanWo", "高级软卧"},
               {"RuanWo", "软卧"},
               {"YingWo", "硬卧"},
               {"RuanZuo", "软座"},
               {"YingZuo", "硬座"},
               {"WuZuo","无座"}
        };
        public static Dictionary<string, string> DicTicketType = new Dictionary<string, string>()
        {
            {"成人票","1"},{"学生票","2"},{"儿童票","3"},{"伤残军人","4"}
        };
        public static Dictionary<string, string> DicZjlx = new Dictionary<string, string>()
        {
             {"二代身份证","1"}
        };
        public static Dictionary<string, string> DicSexy = new Dictionary<string, string>()
        {
            {"男","M"},{"女","F"}
        };
        public static string UserName = string.Empty;//用户名
        public static UserInfo MyUser = new UserInfo();//用户信息
        public static List<Station> StationList = new  List<Station>();//车站信息
        public static List<UserInfo> MyUserList = new List<UserInfo>();//登录的信息
    }
    public class TrainDetails
    {
        public string station_no { get; set; }
        public string station_name { get; set; }
        public string arrive_time { get; set; }
        public string start_time { get; set; }
        public string stopover_time { get; set; }
        public bool isEnabled { get; set; }
    }
    public class TicketInfo
    {
        public string Token { get; set; }
        public string CheckKey { get; set; }
        public string TrainLocation { get; set; }
        public QueryLeftTicketRequestDTO LeftTicketInfo { get; set; }
        public List<TickePriceInfo> TicketList { get; set; }
    }
    public class TickePriceInfo
    {
        public string SeatType{get;set;}
        public string TicektCnt{get;set;}
        public string Price{get;set;}
    }
    public class Passenger
    {
        public string first_letter { get; set; }
        public string isUserSelf { get; set; }
        public string mobile_no { get; set; }
        public string old_passenger_id_no { get; set; }
        public string old_passenger_id_type_code { get; set; }
        public string old_passenger_name { get; set; }
        public string passenger_flag { get; set; }
        public string passenger_id_no { get; set; }
        public string passenger_id_type_code { get; set; }
        public string passenger_id_type_name { get; set; }
        public string passenger_name { get; set; }
        public string passenger_type { get; set; }
        public string passenger_type_name { get; set; }
        public string recordCount { get; set; }
    }
    public class PassengerInfo
    {
        public PassengerDTOs Passenger { get; set; }
        public string SeatType { get; set; }
        public string TicketType { get; set; }
    }
    public class CountInfo
    {
        public string count { get; set; }
        public string ticket { get; set; }
        public string op_2 { get; set; }
        public string countT { get; set; }
        public string op_1 { get; set; }
        public string ticketCnt { get; set; }
    }
    public class PassengerList
    {
        public List<Passenger> passengerJson { get; set; }
    }
    public class TrainClassInfo
    {
        public string end_station_name { get; set; }
        public string end_time { get; set; }
        public string id { get; set; }
        public string start_station_name { get; set; }
        public string start_time { get; set; }
        public string value { get; set; }
    }
    public class TrainClassInfoEX 
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
    public class QueryTicketResponseInfo
    {
        public string validateMessagesShowId { get; set; }
        public bool status { get; set; }
        public int httpstatus { get; set; }
        public List<QueryLeftNewDTOData> data { get; set; }
    }
    public class GetPassengerDTOsResponseInfo
    {
        public string validateMessagesShowId { get; set; }
        public bool status { get; set; }
        public int httpstatus { get; set; }
        public PassengerDTOsData data { get; set; }
    }
    public class PassengerDTOsData
    {
        public List<PassengerDTOs> normal_passengers { get; set; }
        public bool isExist { get; set; }
        public string exMsg { get; set; }
    }
    public class QueryLeftNewDTOData
    {
        public QueryLeftNewDTO queryLeftNewDTO { get; set; }
        public string secretStr { get; set; }
        public string buttonTextInfo { get; set; }
    }
    public class QueryLeftNewDTO
    {
        public string train_no { get; set; }
        public string station_train_code { get; set; }
        public string start_station_telecode { get; set; }
        public string start_station_name { get; set; }
        public string end_station_telecode { get; set; }
        public string end_station_name { get; set; }
        public string from_station_telecode { get; set; }
        public string from_station_name { get; set; }
        public string to_station_telecode { get; set; }
        public string to_station_name { get; set; }
        public string start_time { get; set; }
        public string arrive_time { get; set; }
        public string day_difference { get; set; }
        public string train_class_name { get; set; }
        public string lishi { get; set; }
        public string canWebBuy { get; set; }
        public string lishiValue { get; set; }
        public string yp_info { get; set; }
        public string control_train_day { get; set; }
        public string start_train_date { get; set; }
        public string seat_feature { get; set; }
        public string yp_ex { get; set; }
        public string train_seat_feature { get; set; }
        public string seat_types { get; set; }
        public string location_code { get; set; }
        public string from_station_no { get; set; }
        public string to_station_no { get; set; }
        public int control_day { get; set; }
        public string sale_time { get; set; }
        public string is_support_card { get; set; }
        public string gg_num { get; set; }
        public string gr_num { get; set; }
        public string qt_num { get; set; }
        public string rw_num { get; set; }
        public string rz_num { get; set; }
        public string tz_num { get; set; }
        public string wz_num { get; set; }
        public string yb_num { get; set; }
        public string yw_num { get; set; }
        public string yz_num { get; set; }
        public string ze_num { get; set; }
        public string zy_num { get; set; }
        public string swz_num { get; set; }
    }

    public class PassengerDTOs
    {
        public string code{ get; set; }
        public string passenger_name{ get; set; }
        public string sex_code{ get; set; }
        public string born_date{ get; set; }
        public string country_code{ get; set; }
        public string passenger_id_type_code{ get; set; }
        public string passenger_id_type_name{ get; set; }
        public string passenger_id_no{ get; set; }
        public string passenger_type{ get; set; }
        public string passenger_flag{ get; set; }
        public string passenger_type_name{ get; set; }
        public string mobile_no{ get; set; }
        public string phone_no{ get; set; }
        public string email{ get; set; }
        public string address{ get; set; }
        public string postalcode{ get; set; }
        public string first_letter{ get; set; }
        public int recordCount { get; set; }
    }
    public class QueryWaitTimeResult
    {
        public string queryOrderWaitTimeStatus { get; set; }
        public int count { get; set; }
        public int waitTime { get; set; }
        public long requestId { get; set; }
        public int waitCount { get; set; }
        public string tourFlag { get; set; }
        public string orderId { get; set; }
    }
    public class QueryLeftTicketRequestDTO
    {
         public string arrive_time{ get; set; }
         public string bigger20{ get; set; }
         public string from_station{ get; set; }
         public string from_station_name{ get; set; }
         public string from_station_no{ get; set; }
         public string lishi{ get; set; }
         public string login_id{ get; set; }
         public string login_mode{ get; set; }
         public string login_site{ get; set; }
         public string purpose_codes{ get; set; }
         public string query_type{ get; set; }
         public string seatTypeAndNum{ get; set; }
         public string seat_types{ get; set; }
         public string start_time{ get; set; }
         public string start_time_begin{ get; set; }
         public string start_time_end{ get; set; }
         public string station_train_code{ get; set; }
         public string to_station{ get; set; }
         public string to_station_name{ get; set; }
         public string to_station_no{ get; set; }
         public string train_date{ get; set; }
         public string train_flag{ get; set; }
         public string train_headers{ get; set; }
         public string train_no{ get; set; }
         public string useMasterPool{ get; set; }
         public string useWB10LimitTime{ get; set; }
         public string usingGemfireCache{ get; set; }
         public string ypInfoDetail { get; set; }
    }
}
