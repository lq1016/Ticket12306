using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Waner8.Common
{
    /// <summary>
    /// Json数据转换封装
    /// </summary>
    public static class JsonHelper
    {
        public static String ToJson(object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }
        public static T FromJson<T>(String jsonStr)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonStr);
        }
        /// <summary>
        /// 将JSON数据转化为C#数据实体
        /// </summary>
        /// <param name="json">符合JSON格式的字符串</param>
        /// <returns>T类型的对象</returns>
        public static T JsonDeserialize<T>(string json)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json.ToCharArray()));
                T obj = (T)serializer.ReadObject(ms);
                ms.Close();
                return obj;
            }
            catch
            {
                return default(T);
            }
        }
    }
}
