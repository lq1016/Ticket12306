using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Waner8.Common;
using System.Text.RegularExpressions;
namespace Ticket12306.Service.Utility
{
    public class LoginHelper
    {
        public static bool Login(string userName,string pwd,string vc,ref string msg,ref CookieContainer cookies)
        {
            HttpClient client=new HttpClient(cookies);
            if (StaticValues.Proxy != "")
            {
                client.Proxy = new WebProxy(StaticValues.Proxy);
            }
            string url = "https://kyfw.12306.cn/otn/login/loginAysnSuggest";
            string data = "loginUserDTO.user_name=" + userName + "&userDTO.password=" + pwd + "&randCode=" + vc; ;
            string result = client.Post(url, data, "kyfw.12306.cn", "https://kyfw.12306.cn", "https://kyfw.12306.cn/otn/login/init");
            result=result.Replace("\"","");
            bool flag = result.Contains("loginCheck:Y");
            if (!flag)
            {
                msg = HtmlHelper.GetContent(result, "messages:", "],").Replace("[","").Replace("]","");
            }
            return flag;
        }
    }
}
