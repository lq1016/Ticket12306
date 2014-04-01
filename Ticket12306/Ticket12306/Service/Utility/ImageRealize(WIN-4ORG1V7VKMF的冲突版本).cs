using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Waner8.Common;
using System.Drawing;
using Ticket12306.Resx;
namespace Ticket12306.Service.Uitility
{
    public class CodeEntity
    {
        public string CharStr { get; set; }
        public string GuiyiCode { get; set; }
    }
    public class ImageRealize
    {
        List<CodeEntity> codeList = null;
        public ImageRealize()
        {
            //初始化字模
            codeList = new List<CodeEntity>();
            string[] charList =Files.VcCode.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in charList)
            {
                string[] array = line.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string charStr = array[0];
                string guiyicode = array[1];
                codeList.Add(new CodeEntity { CharStr = charStr, GuiyiCode = guiyicode });
            }
        }
        /// <summary>
        /// 获取识别后的结果
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public List<CodeEntity> GetCode(Image img)
        {
            //1.先灰度
            Image grayImage = ImageHelper.Gray(img, ImageHelper.AlgorithmsType.WeightAverage);
            Bitmap bmp1 = grayImage as Bitmap;
            //2.亮度100
            int v = ImageHelper.GetDgGrayValue(grayImage);
            Image lightImage = ImageHelper.PBinary(bmp1, v);
            //3.去除孤点
            Bitmap bmp2 = lightImage as Bitmap;
            Image clearImage = ImageHelper.ClearImage(bmp2);
            Bitmap bmp = new Bitmap(clearImage);
            //0,1化
            for (int m = 0; m < bmp.Height; m++)
            {
                for (int n = 0; n < bmp.Width; n++)
                {
                    Color color = bmp.GetPixel(n, m);
                    if (color.R == 255 && color.G == 255 && color.B == 255)
                    { }
                    else
                    {
                        bmp.SetPixel(n, m, Color.Black);
                    }
                }
            }
            List<Bitmap> bmpList = ImageHelper.CutImage(bmp);
            List<CodeEntity> ceList = new List<CodeEntity>();
            if (bmpList != null)
            {
                for (int j = 0; j < bmpList.Count; j++)
                {
                    Bitmap _bmp = bmpList[j];
                    CodeEntity ce = Shibie(_bmp);
                    if (ce!=null&&ce.CharStr!=null)
                    {
                        ceList.Add(ce);
                    }
                }
                return ceList;
            }
            else
                return null;

        }
        private CodeEntity Shibie(Bitmap bmp)
        {
            CodeEntity _ce = new CodeEntity();
            string code = ImageHelper.GetBinaryCode(bmp).Trim();
            int _rate = 0;
            string result = string.Empty;
            for (int i = 0; i < codeList.Count; i++)
            {
                CodeEntity ce = codeList[i];
                string code1 = ce.GuiyiCode;
                string charStr = ce.CharStr;
                int rate = CalcRate(code1, code);
                if (rate >= _rate)
                {
                    _rate = rate;
                    result = charStr;
                    _ce = ce;
                }
            }
            return _ce;
        }
        /// <summary>
        /// 计算相似度
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        private int CalcRate(string t1, string t2)
        {
            if (t1.Length > 0 && t2.Length > 0)
            {
                char[] b1 = t1.ToCharArray();
                char[] b2 = t2.ToCharArray();
                int cnt = 0;
                for (int i = 0; i < b1.Length; i++)
                {
                    int bb1 = Convert.ToInt32(b1[i]);
                    int bb2 = Convert.ToInt32(b2[i]);
                    int r = bb1 ^ bb2;
                    if (r == 0)
                    {
                        cnt++;
                    }
                }
                return cnt * 100 / t1.Length;
            }
            else
                return 0;
        }
    }
}
