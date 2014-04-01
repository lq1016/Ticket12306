using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Waner8.Common
{
    #region 封装了使用正则表达式对html的查找操作
    /// <summary>
    /// 封装了使用正则表达式对html的查找操作
    /// </summary>
    public class HtmlHelper
    {
        #region 获取指定ID的标签内容
        /// <summary>
        /// 获取指定ID的标签内容
        /// </summary>
        /// <param name="html">HTML源码</param>
        /// <param name="id">标签ID</param>
        /// <returns></returns>
        public static string GetElementById(string html, string id)
        {
            string pattern = @"<([a-z]+)(?:(?!id)[^<>])*id=([""']?){0}\2[^>]*>(?>(?<o><\1[^>]*>)|(?<-o></\1>)|(?:(?!</?\1).))*(?(o)(?!))</\1>";
            pattern = string.Format(pattern, Regex.Escape(id));
            Match match = Regex.Match(html, pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
            return match.Success ? match.Value : "";
        }
        #endregion
        #region 通过class属性获取对应标签集合
        /// <summary>
        /// 通过class属性获取对应标签集合
        /// </summary>
        /// <param name="html">HTML源码</param>
        /// <param name="className">class值</param>
        /// <returns></returns>
        public static string[] GetElementsByClass(string html, string className)
        {
            return GetElements(html, "", className);
        }
        #endregion
        #region 通过标签名获取标签集合
        /// <summary>
        /// 通过标签名获取标签集合
        /// </summary>
        /// <param name="html">HTML源码</param>
        /// <param name="tagName">标签名(如div)</param>
        /// <returns></returns>
        public static string[] GetElementsByTagName(string html, string tagName)
        {
            return GetElements(html, tagName, "");
        }
        #endregion
        #region 通过同时指定标签名+class值获取标签集合
        /// <summary>
        /// 通过同时指定标签名+class值获取标签集合
        /// </summary>
        /// <param name="html">HTML源码</param>
        /// <param name="tagName">标签名</param>
        /// <param name="className">class值</param>
        /// <returns></returns>
        public static string[] GetElementsByTagAndClass(string html, string tagName, string className)
        {
            return GetElements(html, tagName, className);
        }
        #endregion
        #region 通过同时指定标签名+class值获取标签集合（内部方法）
        /// <summary>
        /// 通过同时指定标签名+class值获取标签集合（内部方法）
        /// </summary>
        /// <param name="html"></param>
        /// <param name="tagName"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        private static string[] GetElements(string html, string tagName, string className)
        {
            string pattern = "";
            if (tagName != "" && className != "")
            {
                pattern = @"<({0})(?:(?!class)[^<>])*class=([""']?){1}\2[^>]*>(?>(?<o><\1[^>]*>)|(?<-o></\1>)|(?:(?!</?\1).))*(?(o)(?!))</\1>";
                pattern = string.Format(pattern, Regex.Escape(tagName), Regex.Escape(className));
            }
            else if (tagName != "")
            {
                pattern = @"<({0})(?:[^<>])*>(?>(?<o><\1[^>]*>)|(?<-o></\1>)|(?:(?!</?\1).))*(?(o)(?!))</\1>";
                pattern = string.Format(pattern, Regex.Escape(tagName));
            }
            else if (className != "")
            {
                pattern = @"<([a-z]+)(?:(?!class)[^<>])*class=([""']?){0}\2[^>]*>(?>(?<o><\1[^>]*>)|(?<-o></\1>)|(?:(?!</?\1).))*(?(o)(?!))</\1>";
                pattern = string.Format(pattern, Regex.Escape(className));
            }
            if (pattern == "")
            {
                return new string[] { };
            }
            List<string> list = new List<string>();
            Regex reg = new Regex(pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
            Match match = reg.Match(html);
            while (match.Success)
            {
                list.Add(match.Value);
                match = reg.Match(html, match.Index + match.Length);
            }
            return list.ToArray();
        }
        /// <summary>
        /// 根据正则获取内容
        /// </summary>
        /// <param name="text">内容</param>
        /// <param name="pat">正则</param>
        public static List<string> GetListByHtml(string text, string pat)
        {
            List<string> list = new List<string>();
            Regex r = new Regex(pat, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Match m = r.Match(text);
            //int matchCount = 0;
            while (m.Success)
            {
                list.Add(m.Value);
                m = m.NextMatch();
            }
            return list;
        }
        /// <summary>
        /// 根据正则获取内容
        /// </summary>
        /// <param name="text">内容</param>
        /// <param name="pat">正则</param>
        public static string GetResultByHtml(string text, string pat)
        {
            string result = string.Empty;
            Regex r = new Regex(pat, System.Text.RegularExpressions.RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(text);
            //int matchCount = 0;
            while (m.Success)
            {
                result = m.Value;
                break;
            }
            return result;
        }
        /// <summary>
        /// 去除html标签
        /// </summary>
        /// <param name="Htmlstring"></param>
        /// <returns></returns>
        public static string NoHTML(string Htmlstring)
        {
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring = Htmlstring.Trim();
            return Htmlstring;
        }
        /// <summary>
        /// 取得HTML中所有图片的 URL。
        /// </summary>
        /// <param name="sHtmlText">HTML代码</param>
        /// <returns>图片的URL列表</returns>
        public static string[] GetHtmlImageUrlList(string sHtmlText)
        {
            // 定义正则表达式用来匹配 img 标签
            Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);
            // 搜索匹配的字符串
            MatchCollection matches = regImg.Matches(sHtmlText);
            int i = 0;
            string[] sUrlList = new string[matches.Count];
            // 取得匹配项列表
            foreach (Match match in matches)
                sUrlList[i++] = match.Groups["imgUrl"].Value;
            return sUrlList;
        }
        /// <summary>
        /// 获取img的alt标签
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string[] GetImagAltList(string strHtml)
        {
            // 定义正则表达式用来匹配 img 标签
            Regex regImg = new Regex(@"<img\b[^<>]*?\balt[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgAlt>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);
            // 搜索匹配的字符串
            MatchCollection matches = regImg.Matches(strHtml);
            int i = 0;
            string[] sUrlList = new string[matches.Count];
            // 取得匹配项列表
            foreach (Match match in matches)
                sUrlList[i++] = match.Groups["imgAlt"].Value;
            return sUrlList;
        }
        /// <summary>
        /// 获取字符中指定标签的值
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="tag">标签</param>
        /// <returns>值</returns>
        public static string GetTagContent(string str, string tag)
        {
            string tmpStr = string.Format("<{0}[^>]*?>(?<Text>[^<]*)</{1}>", tag, tag); //获取<tag>之间内容
            Match TitleMatch = Regex.Match(str, tmpStr, RegexOptions.IgnoreCase);
            string result = TitleMatch.Groups["Text"].Value;
            return result;
        }
        /// <summary>
        /// 获取字符中指定标签的值
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="tag">标签</param>
        /// <param name="attrib">属性名</param>
        /// <returns>属性</returns>
        public static string GetTagContent(string str, string tag, string attrib)
        {
            string tmpStr = string.Format("<{0}[^>]*?{1}=(['\"\"]?)(?<url>[^'\"\"\\s>]+)\\1[^>]*>", tag, attrib); //获取<tag>之间内容
            Match TitleMatch = Regex.Match(str, tmpStr, RegexOptions.IgnoreCase);
            string result = TitleMatch.Groups["url"].Value;
            return result;
        }
        #endregion
        #region 通过标签头和尾获取标签中间的文本内容
        public static string GetContent(string str, string startTag, string endTag)
        {
            string result = string.Empty;
            string pattern = "(?<=" + startTag + ")[\\s\\S]*?(?=" + endTag + ")";
            Regex reg = new Regex(pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
            Match match = reg.Match(str);
            if (match.Success)
            {
                result = match.Value;
            }
            return result;
        }
        #endregion
    } 
    #endregion
}
