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
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace Ticket12306.Service.Utility
{
    public class VcHelper
    {
        /// <summary>
        /// 检测验证码是否正确
        /// </summary>
        /// <param name="vcCookie"></param>
        /// <param name="vc"></param>
        /// <returns></returns>
        public static bool CheckVc(CookieContainer vcCookie, string vc,string token)
        {
            HttpClient client = new HttpClient(vcCookie);
            if (StaticValues.Proxy != "")
            {
                client.Proxy = new WebProxy(StaticValues.Proxy);
            }
            string url = "https://kyfw.12306.cn/otn/passcodeNew/checkRandCodeAnsyn";
            string data = "randCode=" + vc;
            if (token != "")
            {
                data = data + "&rand=randp&REPEAT_SUBMIT_TOKEN=" + token;
            }
            else
            {
                data=data+"&rand=sjrand";
            }
            var result = client.Post(url, data, "kyfw.12306.cn", "https://kyfw.12306.cn", "https://kyfw.12306.cn/otn/login/init");
            var ok = HtmlHelper.GetContent(result, "\"data\":", ",").Replace("\"", "") == "Y";
            return ok;
        }

        public static Image GetVcImage(string vcUrl, ref string code, ref CookieContainer vcCookie, string token = "")
        {
            //Image vcImage = null;
            Image vcImage = null;
            bool continueFlag=true;
            do
            {
                try
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    HttpClient client = new HttpClient(vcCookie);
                    if (StaticValues.Proxy != "")
                    {
                        client.Proxy = new WebProxy(StaticValues.Proxy);
                    }
                    Stream stream = client.GetImageStream(vcUrl);
                    sw.Stop();
                    if (stream != null)
                    {
                        vcImage = Image.FromStream(stream);
                        if (sw.ElapsedMilliseconds > 2000)
                        {
                            //continueFlag = false;
                        }
                        else
                        {
                            if (vcImage.Width == 78)
                            {
                                code = ImageRealize.GetCode0(vcImage);
                            }
                            else
                            {
                                code = ImageRealize.GetCode1(vcImage);
                            }
                            if (CheckVc(vcCookie, code, token))
                            {
                                break;
                            }
                            else
                                code = "";
                        }
                        //else
                        //{
                        //    break;
                        //}
                        //gif验证码
                        //FrameDimension fd = new FrameDimension(gif.FrameDimensionsList[0]);
                        //int count = gif.GetFrameCount(fd);
                        ////if (count == 6)
                        ////{
                        ////    gif.SelectActiveFrame(fd, 4);
                        ////    MemoryStream ms = new MemoryStream();
                        ////    gif.Save(ms, ImageFormat.Bmp);
                        ////    Image img1 = Image.FromStream(ms);
                        ////    picCommon.Image = img1;
                        ////}
                        //if (count == 1)
                        //{
                        //     code = ImageRealize.GetCode0(gif);
                        //     if (CheckVc(vcCookie, code, token))
                        //     {
                        //         break;
                        //     }
                        //}
                        //code = ImageRealize.GetCode(vcImage);
                        //if (CheckVc(vcCookie, code, token))
                        //{
                        //    break;
                        //}
                    }
                }
                catch
                {
                    break;
                }
            }
            while (continueFlag);
            return vcImage;
        }

        /// <summary>
        /// 获取验证码，并且识别
        /// </summary>
        /// <param name="yzmUrl"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetVcImage0(byte[] ret, Image img)
        {
            string code = string.Empty;
            StringBuilder codeBuilder = new StringBuilder(8, 8);
            codeBuilder.Length = 0;
            if (ret.Length > 0)
            {
                if (CodeAPI.GetCodeFromBuffer(1, ret, ret.Length, codeBuilder))
                {
                    code = codeBuilder.ToString().ToUpper();
                }
                if (code.Length == 4)
                {
                    code = code.Replace("V", "N").Replace("B", "8");
                }
                else
                    code = ImageRealize.GetCode1(img);
            }
            return code;
        }
        /// <summary>
        /// 获取验证码，并且识别
        /// </summary>
        /// <param name="vcUrl"></param>
        /// <param name="code"></param>
        /// <param name="vcCookie"></param>
        /// <returns></returns>
        private static string GetVcImage1(Image vcImage)
        {
            string code = ImageRealize.GetCode0(vcImage);
            return code;
        }
       
    }
}
