using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace Waner8.Common
{
    public class FileHelper
    {

        public static void Write(string fileName,string txt) //读取文件
        {
            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                sw.Write(txt);
                sw.Close();
            }
        }
    }
}
