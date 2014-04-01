using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Waner8.Common
{
    public class StringHelper
    {
        /// <summary>
        /// 随机生成N位字符串
        /// </summary>
        /// <param name="cnt"></param>
        /// <returns></returns>
        public static string GetRndStr(int cnt)
        {
            char[] character = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            Random rnd = new Random();
            string rndStr = string.Empty;
            for (int i = 0; i <cnt; i++)
            {
                rndStr += character[rnd.Next(character.Length)];
            }
            return rndStr;
        }
    }
}
