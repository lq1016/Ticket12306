using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Waner8.Common;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;
using Ticket12306.Resx;

namespace Ticket12306.Service.Uitility
{
    public class VcHelper
    {
        [DllImport("VC.dll", CharSet = CharSet.Ansi)]
        public static extern bool GetCodeFromBuffer(Int32 LibFileIndex, Byte[] FileBuffer, Int32 ImgBufLen, StringBuilder Code);
        [DllImport("VC.dll", CharSet = CharSet.Ansi)]
        public static extern bool LoadLibFromBuffer(Byte[] FileBuffer, Int32 BufLen, String Password);

        /// <summary>
        /// 检测验证码是否正确
        /// </summary>
        /// <param name="vcCookie"></param>
        /// <param name="vc"></param>
        /// <returns></returns>
        public bool CheckVc(CookieContainer vcCookie, string vc)
        {
            HttpClient client = new HttpClient(vcCookie);
            string url = "https://kyfw.12306.cn/otn/passcodeNew/checkRandCodeAnsyn";
            string data = "randCode={0}&rand=sjrand";
            data = string.Format(data, vc);
            var result = client.Post(url, data, "kyfw.12306.cn", "https://kyfw.12306.cn", "https://kyfw.12306.cn/otn/login/init");
            var ok = HtmlHelper.GetContent(result, "\"data\":", ",").Replace("\"", "") == "Y";
            return ok;
        }
        /// <summary>
        /// 加载验证码识别码
        /// </summary>
        public void InitVcRealizeCode()
        {
            byte[] buffer = Files.CodeData;
            LoadLibFromBuffer(buffer, buffer.Length, Strings.CodePwd);
        }

        /// <summary>
        /// 获取验证码，并且识别
        /// </summary>
        /// <param name="yzmUrl"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public Image GetVcImage(string vcUrl,ref string code,ref CookieContainer vcCookie)
        {
            Image vcImage = null;
            HttpClient client = new HttpClient(vcCookie);
            //while (true)
            //{
                Stream stream = client.GetImageStream(vcUrl);
                vcImage = Image.FromStream(stream); 
                ImageRealize ir = new ImageRealize();
                //code = ir.GetCode(vcImage);
                //if (CheckVc(vcCookie, code))
                //{
                //    break;
                //}
                //byte[] m_buffer = new byte[4096];
                //int offset = 0;
                //int count = 0;
                //do
                //{
                //    count = stream.Read(m_buffer, offset, m_buffer.Length - offset);
                //    if (count > 0)
                //    {
                //        offset += count;
                //    }

                //}
                //while (count > 0);
                //if (offset > 0)
                //{
                //    StringBuilder codeBuilder = new StringBuilder(8, 8);
                //    byte[] ret = new byte[offset];
                //    Array.Copy(m_buffer, ret, offset);
                //    codeBuilder.Length = 0;
                //    if (ret.Length > 0)
                //    {
                //        if (GetCodeFromBuffer(1, ret, ret.Length, codeBuilder))
                //        {
                //            code = codeBuilder.ToString().ToUpper();
                //        }
                //        if (code.Length == 4)
                //        {
                //            code = code.Replace("V", "N").Replace("B", "8");
                //            if (CheckVc(vcCookie, code))
                //            {
                //                vcImage = Image.FromStream(new MemoryStream(ret, false));
                //                break;
                //            }
                //        }
                //    }

                //}
                stream.Close();
            //}
            return vcImage;
            
        }
    }
}
