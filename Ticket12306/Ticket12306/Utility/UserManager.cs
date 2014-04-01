using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Xml;
using Waner8.Common;


namespace Ticket12306
{
    public class UserInfo
    {
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public string LastQueryFromStation { get; set; }//最后一次查询的出发地
        public string LastQueryToStation { get; set; }//最后一次查询的目的地
    }
    public class UserManager
    {
        public static string userDataFile = Application.StartupPath + "\\user.data";
        public static void SaveUserInfo(string userName, string pwd,string from="",string to="")
        {
            List<UserInfo> list = GetUsers();
            UserInfo user = list.Find(l => l.UserName == userName);
            if (user != null)
            {
                user.Pwd = pwd;
                if (from != "" && to != "")
                {
                    user.LastQueryFromStation = from;
                    user.LastQueryToStation = to;
                }
            }
            else
            {
                user = new UserInfo() { UserName = userName, Pwd = pwd, LastQueryFromStation=from, LastQueryToStation=to };
                list.Add(user);
            }
            StaticValues.MyUser = user;
            Save(list);
        }
        private static void Save(List<UserInfo> list)
        {
            string listStr = JsonHelper.ToJson(list);
            string ret = DesHelper.Encrypt(listStr, Ticket12306.Resx.Strings.DesKey, Ticket12306.Resx.Strings.DesIV);
            using (StreamWriter sr = new StreamWriter(userDataFile))
            {
                sr.Write(ret);
            }
        }

        public static List<UserInfo> GetUsers()
        {
            List<UserInfo> list = new List<UserInfo>();
            string userData = string.Empty;
            using (StreamReader sr = new StreamReader(userDataFile))
            {
                userData = sr.ReadToEnd();
            }
            //解密
            if (userData != "")
            {
                userData = DesHelper.Decrypt(userData, Ticket12306.Resx.Strings.DesKey, Ticket12306.Resx.Strings.DesIV);
                list=JsonHelper.FromJson<List<UserInfo>>(userData);
            }
            return list;
        }
        public static string GetUserPwd(string userName)
        {
            if (userName == "")
            {
                return "";
            }
            List<UserInfo> list = GetUsers();
            var uList = from u in list
                        where u.UserName == userName
                        select u;
            return uList.Count() > 0 ? uList.ToList()[0].Pwd : "";
        }
        public static void DelUserInfo(string userName)
        {
            List<UserInfo> list = GetUsers();
            UserInfo[] _list = new UserInfo[list.Count];
            list.CopyTo(_list);
            for (int i = 0; i < _list.Length; i++)
            {
                if (_list[i].UserName == userName)
                {
                    list.Remove(_list[i]);
                }
            }
            Save(list);
        }
    }
}
