using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Ticket12306
{
    public class IEHelper
    {
        /// 设置cookie
        ///
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool InternetSetCookie(string lpszUrlName, string lbszCookieName, string lpszCookieData);
        ///
        /// 获取cookie
        ///
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool InternetGetCookie(string url, string name, StringBuilder data, ref int dataSize);

        public static void SetCookie2IE(string url)
        {
            foreach (Cookie cookie in StaticValues.MyCookies.GetCookies(new Uri(url)))
            {
                InternetSetCookie(url, cookie.Name.ToString(), cookie.Value.ToString() + ";expires=Sun,22-Feb-2099 00:00:00 GMT");
            }
        }
        public static void OpenInIE(string url)
        {
            string ieFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Internet Explorer\\iexplore.exe");
            Process.Start(ieFile, url);
        }
    }

}
