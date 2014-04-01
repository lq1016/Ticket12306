using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Waner8.Common;

namespace Ticket12306.Utility
{
    public class JsFuncitonHelper
    {
        public static string Escape(string str)
        {
            string func = "function GetEscape(str){return escape(str);};";
            ScriptEngine se = new ScriptEngine(ScriptLanguage.JavaScript);
            object obj = se.Run("GetEscape", new object[] { str }, func);
            return obj.ToString();
        }
        public static string GetJsTime(string timeStr)
        {
            string func = "function GetJsTime(timeStr){var currentDate=new Date(timeStr);return currentDate+'';}";
            ScriptEngine se = new ScriptEngine(ScriptLanguage.JavaScript);
            object obj = se.Run("GetJsTime", new object[] { timeStr }, func);
            return obj.ToString();
        }
        public static string GetCnt(string ticket, string seatType)
        {
            string func="function A(F,E){rt='';seat_1=-1;seat_2=-1;i=0;while(i<F.length){s=F.substr(i,10);c_seat=s.substr(0,1);if(c_seat==E){count=s.substr(6,4);while(count.length>1&&count.substr(0,1)=='0'){count=count.substr(1,count.length)}count=parseInt(count);if(count<3000){seat_1=count}else{seat_2=(count-3000)}}i=i+10}if(seat_1>-1){rt+=seat_1}if(seat_2>-1){rt+=','+seat_2}return rt}";
             ScriptEngine se = new ScriptEngine(ScriptLanguage.JavaScript);
            object obj = se.Run("A", new object[] { ticket,seatType }, func);
            return obj.ToString();
        }
    }
}
