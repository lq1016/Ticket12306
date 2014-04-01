using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.IO.Compression;
using System.Collections;

namespace Waner8.Common
{
    #region 对Http请求的封装
    public class HttpClient
    {
        #region 变量
        public CookieContainer Cookies = new CookieContainer();//Cookies
        public string UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.63 Safari/537.36";//用户代理
        public int TimeOut = 20000;//超时时间
        public bool AllowAutoRedirect = false;//自动跳转
        public Encoding Encoding = Encoding.UTF8;//编码 
        public WebProxy Proxy = null;//代理
        #endregion
        public string ContentType = "application/x-www-form-urlencoded";
        #region 构造函数
        public HttpClient(CookieContainer cookieContainer)
        {
            this.Cookies = cookieContainer;
        }
        public HttpClient() { }
        #endregion

        #region 获取Http请求的响应
        /// <summary>
        /// 获取Http的请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="data"></param>
        /// <param name="host"></param>
        /// <param name="orign"></param>
        /// <param name="refer"></param>
        /// <returns></returns>
        private HttpWebResponse GetResponse(string url, string method, string data, string host, string orign, string refer)
        {
            HttpWebResponse response = null;
            Stream st = null;
            HttpWebRequest req = null;
            try
            { // 设置一些公用的请求头  
                NameValueCollection collection = new NameValueCollection();

                collection.Add("Accept-Encoding", "gzip,deflate,sdch");
                collection.Add("Accept-Language", "zh-CN,zh;q=0.8");
               
                req = (HttpWebRequest)WebRequest.Create(url);
                req.KeepAlive = true;
                req.Method = method.ToUpper();
                req.AllowAutoRedirect = true;
                req.CookieContainer = Cookies;
                req.ContentType = ContentType;
                req.UserAgent = UserAgent;
                req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                req.Timeout = TimeOut;
                req.Referer = refer;
                req.Headers.Add(collection);
                if (Proxy != null)
                {
                    req.Proxy = Proxy;
                }
                if (!string.IsNullOrEmpty(host))
                {
                    req.Host = host;
                }
                req.Headers.Add("X-Requested-With", "XMLHttpRequest");
                if (!string.IsNullOrEmpty(orign))
                {
                    req.Headers.Add("Origin", orign);
                }
                if (method.ToUpper() == "POST" && !string.IsNullOrEmpty(data))
                {
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    byte[] postBytes = encoding.GetBytes(data); ;
                    req.ContentLength = postBytes.Length;
                    st = req.GetRequestStream();
                    st.Write(postBytes, 0, postBytes.Length);
                    st.Close();
                }
                System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) =>
                {
                    return true;
                };
                if (req.GetResponse() != null)
                {
                    response = (HttpWebResponse)req.GetResponse();
                    if (response.Cookies.Count > 0)
                    {
                        Cookies.Add(response.Cookies);
                    }
                }
            }
            catch (WebException ex)
            {
                response = null;
            }
            return response;
        }
        #endregion

        #region 获取http请求返回的字符串（Post）
        public string Post(string url, string data = "", string host = "", string orign = "", string refer = "", string method = "post")
        {
            return GetString(method, url, data, host, orign, refer);
        }
        #endregion

        #region 获取http请求返回的字符串（Get）
        public string Get(string url, string host = "", string orign = "", string refer = "", string data = "", string method = "get")
        {
            return GetString(method, url, data, host, orign, refer);
        }
        #endregion

        #region 获取http请求返回的字符串
        private string GetString(string method, string url, string data, string host, string orign, string refer)
        {
            var result = string.Empty;
            var response = GetResponse(url, method, data, host, orign, refer);
            if (response != null)
            {
                var stream = response.GetResponseStream();
                if (response.ContentEncoding.ToLower().Contains("gzip"))
                {
                    stream = new GZipStream(stream, CompressionMode.Decompress);
                }
                using (StreamReader sr = new StreamReader(stream, Encoding))
                {
                    result = sr.ReadToEnd();
                }
            }
            return result;
        }
        #endregion

        #region 获取http请求跳转的Uri
        public Uri GetUri(string url, string method = "get", string data = "", string host = "", string orign = "", string refer = "")
        {
            AllowAutoRedirect = false;
            var response = GetResponse(url, method, data, host, orign, refer);
            return response.ResponseUri;
        }
        #endregion

        #region 获取图片的二进制数据
        public byte[] GetImageBytes(string url, string host = "", string orign = "", string refer = "", string data = "", string method = "get")
        {
            var response = GetResponse(url, method, data, host, orign, refer);
            var stream = response.GetResponseStream();
            MemoryStream ms = new MemoryStream();
            byte[] buffer = new byte[0x1000];
            int bytes;
            while ((bytes = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, bytes);
            }
            byte[] imgBytes = ms.GetBuffer();
            return imgBytes;
        }
        #endregion

        #region 获取图片流
        public Stream GetImageStream(string url, string host = "", string orign = "", string refer = "", string data = "", string method = "get")
        {
            var response = GetResponse(url, method, data, host, orign, refer);
            if (response != null)
            {
                var stream = response.GetResponseStream();
                return stream;
            }
            else
            {
                return null;
            }
        } 
        #endregion

        #region 下载
        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="url"></param>
        /// <param name="fileName"></param>
        /// <param name="host"></param>
        /// <param name="orign"></param>
        /// <param name="refer"></param>
        /// <param name="data"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public bool DownLoad(string url, string fileName, string host = "", string orign = "", string refer = "", string data = "", string method = "get")
        {
            var result = string.Empty;
            var response = GetResponse(url, method, data, host, orign, refer);
            var stream = response.GetResponseStream();
            FileStream fs = new FileStream(fileName, FileMode.Create);
            int bufferSize = 2048;
            byte[] bytes = new byte[bufferSize];
            bool flag = true;
            try
            {
                int length = stream.Read(bytes, 0, bufferSize);
                while (length > 0)
                {
                    fs.Write(bytes, 0, length);
                    length = stream.Read(bytes, 0, bufferSize);
                }
                stream.Close();
                fs.Close();
                response.Close();
            }
            catch
            {
                flag = false;
            }
            return flag;
        }
        #endregion

        #region 上传图片到服务器(模拟swf）
        public string Upload(string url, string fileName, string paramName, string contentType, NameValueCollection nvc, string host = "", string orign = "", string refer = "")
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.CookieContainer = this.Cookies;
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.KeepAlive = true;
            wr.Credentials = System.Net.CredentialCache.DefaultCredentials;

            Stream rs = wr.GetRequestStream();

            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            foreach (string key in nvc.Keys)
            {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = string.Format(formdataTemplate, key, nvc[key]);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
            }
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            FileInfo fi = new FileInfo(fileName);
            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, paramName, fi.Name, contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();

            WebResponse wresp = null;
            var result = "";
            wresp = wr.GetResponse();
            Stream stream2 = wresp.GetResponseStream();
            StreamReader reader2 = new StreamReader(stream2);
            result = reader2.ReadToEnd();
            return result;
        }

        #endregion

        #region 上传图片到服务器
        /// <summary>
        /// 上传图片到服务器
        /// </summary>
        /// <param name="url"></param>
        /// <param name="fileKeyName"></param>
        /// <param name="filePath"></param>
        /// <param name="stringDict"></param>
        /// <returns></returns>
        public string Upload(string url, string fileKeyName, string filePath, NameValueCollection nvc)
        {
            string responseContent;
            var memStream = new MemoryStream();
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.CookieContainer = this.Cookies;
            // 边界符
            var boundary = "---------------" + DateTime.Now.Ticks.ToString("x");
            // 边界符
            var beginBoundary = Encoding.ASCII.GetBytes("--" + boundary + "\r\n");
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            // 最后的结束符
            var endBoundary = Encoding.ASCII.GetBytes("--" + boundary + "--\r\n");
            // 设置属性
            webRequest.Method = "POST";
            webRequest.Timeout = TimeOut;
            webRequest.ContentType = "multipart/form-data; boundary=" + boundary;
            FileInfo fileInfo = new FileInfo(filePath);
            // 写入文件
            const string filePartHeader =
                "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n" +
                 "Content-Type: image/jpeg\r\n\r\n";
            var header = string.Format(filePartHeader, fileKeyName, fileInfo.Name);
            var headerbytes = Encoding.UTF8.GetBytes(header);
            memStream.Write(beginBoundary, 0, beginBoundary.Length);
            memStream.Write(headerbytes, 0, headerbytes.Length);
            var buffer = new byte[1024];
            int bytesRead; // =0
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                memStream.Write(buffer, 0, bytesRead);
            }
            // 写入字符串的Key
            var stringKeyHeader = "\r\n--" + boundary +
                                   "\r\nContent-Disposition: form-data; name=\"{0}\"" +
                                   "\r\n\r\n{1}\r\n";

            foreach (byte[] formitembytes in from string key in nvc.Keys
                                             select string.Format(stringKeyHeader, key, nvc[key])
                                                 into formitem
                                                 select Encoding.UTF8.GetBytes(formitem))
            {
                memStream.Write(formitembytes, 0, formitembytes.Length);
            }
            // 写入最后的结束边界符
            memStream.Write(endBoundary, 0, endBoundary.Length);
            webRequest.ContentLength = memStream.Length;
            var requestStream = webRequest.GetRequestStream();
            memStream.Position = 0;
            var tempBuffer = new byte[memStream.Length];
            memStream.Read(tempBuffer, 0, tempBuffer.Length);
            memStream.Close();
            requestStream.Write(tempBuffer, 0, tempBuffer.Length);
            requestStream.Close();
            var httpWebResponse = (HttpWebResponse)webRequest.GetResponse();
            using (var httpStreamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("utf-8")))
            {
                responseContent = httpStreamReader.ReadToEnd();
            }
            fileStream.Close();
            httpWebResponse.Close();
            webRequest.Abort();
            return responseContent;
        }
        #endregion

        #region 获取所有的cookie
        public List<Cookie> GetAllCookies()
        {
            CookieContainer cc = this.Cookies;
            List<Cookie> lstCookies = new List<Cookie>();
            Hashtable table = (Hashtable)cc.GetType().InvokeMember("m_domainTable", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.Instance, null, cc, new object[] { });
            foreach (object pathList in table.Values)
            {
                SortedList lstCookieCol = (SortedList)pathList.GetType().InvokeMember("m_list", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.Instance, null, pathList, new object[] { });
                foreach (CookieCollection colCookies in lstCookieCol.Values)
                    foreach (Cookie c in colCookies) lstCookies.Add(c);
            }

            return lstCookies;
        } 
        #endregion
    }
    #endregion
}
