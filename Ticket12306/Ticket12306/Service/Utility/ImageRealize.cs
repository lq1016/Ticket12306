using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Waner8.Common;
using System.Drawing;
using Ticket12306.Resx;
namespace Ticket12306.Service.Utility
{
    public class ImageRealize
    {
        /// <summary>
        /// 获取识别后的结果
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static string  GetCode(Image img)
        {
            Image imgCommon = img;
            Bitmap bmp = Handler(Handler(imgCommon));
            int v =ImageHelper.ComputeThresholdValue(bmp);
            bmp = ImageHelper.PBinary(bmp, v);
            bmp = ImageHelper.ClearNoise(bmp, 2);
            List<Bitmap> bmpList = ImageHelper.CutImage(bmp,12,16);
            string r = string.Empty;
            if (bmpList != null)
            {
                for (int j = 0; j < bmpList.Count; j++)
                {
                    Bitmap _bmp = bmpList[j];
                    CodeEntity ce = Realize(_bmp,StaticValues.CodeList);
                    if (ce != null)
                    {
                        string charStr = ce.CharStr;
                        r = r + charStr;
                    }
                }
            }
            return r;
        }

        /// <summary>
        /// 获取识别后的结果
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static string GetCode0(Image img)
        {
            ImageHandler ih = new ImageHandler();
            Bitmap bmp = new Bitmap(img);
            int v = ImageHelper.ComputeThresholdValue(bmp);
            //二值化
            bmp = ImageHelper.PBinary(bmp, v);
            bmp = ih.TrimBmp(bmp);
            List<Bitmap> bmpList = ih.CutImage(bmp, 8);
            string r = string.Empty;
            if (bmpList != null)
            {
                for (int j = 0; j < bmpList.Count; j++)
                {
                    Bitmap _bmp = bmpList[j];
                    CodeEntity ce = Realize(_bmp, StaticValues.CodeList0);
                    if (ce != null)
                    {
                        string charStr = ce.CharStr;
                        r = r + charStr;
                    }
                }
            }
            return r;
        }

        public static string GetCode2(Image img)
        {
            Bitmap bmp = new Bitmap(img);
            for (int m = 0; m < bmp.Height; m++)
            {
                for (int n = 0; n < bmp.Width; n++)
                {
                    Color color = bmp.GetPixel(n, m);
                    if (color.R == 202 && color.G == 202 && color.B == 202)
                    {
                        bmp.SetPixel(n, m, Color.White);
                    }
                    else
                    {
                        bmp.SetPixel(n, m, Color.Black);
                    }
                }
            }
            string r = string.Empty;
            List<Bitmap> bmpList = ImageHelper.CutImage(bmp, 16, 16);
            if (bmpList != null)
            {

                for (int j = 0; j < bmpList.Count; j++)
                {
                    Bitmap _bmp = bmpList[j];
                    CodeEntity result = Realize(_bmp, StaticValues.CodeList2);
                    if (result != null)
                    {

                        string charStr = result.CharStr;
                        r = r + charStr;
                    }
                }
            }
            return r;
        }
        public static string GetCode3(Image img)
        {
            Bitmap bmp = new Bitmap(img);
            for (int m = 0; m < bmp.Height; m++)
            {
                for (int n = 0; n < bmp.Width; n++)
                {
                    Color color = bmp.GetPixel(n, m);
                    if (color.R == 202 && color.G == 202 && color.B == 202)
                    {
                        bmp.SetPixel(n, m, Color.White);
                    }
                    else
                    {
                        bmp.SetPixel(n, m, Color.Black);
                    }
                }
            }
            string r = string.Empty;
            List<Bitmap> bmpList = ImageHelper.CutImage(bmp, 16, 16);
            if (bmpList != null)
            {

                for (int j = 0; j < bmpList.Count; j++)
                {
                    Bitmap _bmp = bmpList[j];
                    CodeEntity result = Realize(_bmp, StaticValues.CodeList3);
                    if (result != null)
                    {

                        string charStr = result.CharStr;
                        r = r + charStr;
                    }
                }
            }
            return r;
        }
        public static string GetCode1(Image img)
        {
            Image imgCommon = img;
            //1.先灰度
            Image grayImage = ImageHelper.Gray(imgCommon, ImageHelper.AlgorithmsType.WeightAverage);
            Bitmap bmp1 = grayImage as Bitmap;
            //2.亮度100
            int v = ImageHelper.GetDgGrayValue(grayImage);
            Image lightImage = ImageHelper.PBinary(bmp1, v);
            // picGrayNoBg.Image = lightImage;
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
            string r = string.Empty;
            List<Bitmap> bmpList = ImageHelper.CutImage(bmp,16,16);
            if (bmpList != null)
            {
                for (int j = 0; j < bmpList.Count; j++)
                {
                    Bitmap _bmp = bmpList[j];
                    CodeEntity result = Realize(_bmp,StaticValues.CodeList1);
                    if (result != null)
                    {

                        string charStr = result.CharStr;
                        r = r + charStr;
                    }
                }
            }
            return r;
        }
        private static CodeEntity Realize(Bitmap bmp,List<CodeEntity> codeList)
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
                int rate = ImageHelper.CalcRate(code1, code);
                if (rate >=_rate)
                {
                    _rate = rate;
                    result = charStr;
                    _ce = ce;
                }
            }
            return _ce;
        }
        public static Bitmap Handler(Image img)
        {
            Bitmap bmp = new Bitmap(img);
            Color colorGray = Color.FromArgb(202, 202, 202);
            Dictionary<Color, List<Point>> colorDic = ImageHelper.GetColorDic(bmp);
            foreach (Color color in colorDic.Keys)
            {
                if (color != colorGray)
                {
                    List<Point> pointList = colorDic[color];
                    Dictionary<int, List<int>> yList = new Dictionary<int, List<int>>();
                    List<int> pXList = new List<int>();
                    List<int> pYList = new List<int>();
                    foreach (Point p in pointList)
                    {
                        if (yList.ContainsKey(p.Y))
                        {
                            List<int> xList = yList[p.Y];
                            xList.Add(p.X);
                            yList[p.Y] = xList;
                        }
                        else
                        {
                            List<int> xList = new List<int>();
                            xList.Add(p.X);
                            yList.Add(p.Y, xList);
                        }
                    }
                    List<int> keyList = yList.Keys.ToList();
                    bool flag = true;
                    if (keyList.Count == 1)
                    {
                        flag = yList[keyList[0]].Count > 10;
                        if (flag) Mark(bmp, keyList[0], yList[keyList[0]]);
                    }
                    else
                    {
                        List<LineInfo> listLine = GetLineInfo(yList);
                        if (listLine != null && listLine.Count > 0)
                        {
                            foreach (LineInfo line in listLine)
                            {
                                Mark(bmp, line.y, line.xList);
                            }
                        }
                        foreach (int y in yList.Keys)
                        {
                            List<int> xList = yList[y];
                            List<List<int>> _xList = SplitList(xList);
                            if (_xList.Count > 0)
                            {
                                _xList.ForEach(t =>
                                {
                                    if (t.Count >= 5)
                                    {
                                        Mark(bmp, y, t);
                                    }
                                });
                            }
                        }
                    }
                }
            }
            return bmp;
        }

        private static List<LineInfo> GetLineInfo(Dictionary<int, List<int>> yList)
         {
             List<List<int>> totalXList = new List<List<int>>();
             List<LineInfo> lineList = new List<LineInfo>();
             foreach (int y in yList.Keys)
             {
                 List<int> xList = yList[y];
                 List<List<int>> _xList = SplitList(xList);
                 if (_xList.Count > 0)
                 {
                     _xList.ForEach(t => { totalXList.Add(t); lineList.Add(new LineInfo() { xList = t, y = y }); });
                 }
             }
             bool flag = true;
             List<int> tmp = new List<int>() { 0 };
             for (int i = 0; i < totalXList.Count; i++)
             {
                 List<int> xList = totalXList[i];
                 if (xList.Count > 0)
                 {
                     if (xList[0] <= tmp[tmp.Count - 1])
                     {
                         flag = false;
                         break;
                     }
                 }
                 tmp = xList;
             }
             if (flag)
             {
                 return lineList;
             }
             else
                 return null;
         }
        private static List<List<int>> SplitList(List<int> list)
         {
             List<List<int>> splitList = new List<List<int>>();
             int start = list[0];
             int index1 = 0;
             int index2 = 0;
             for (int i = 1; i < list.Count; i++)
             {
                 if (list[i] - start != 1)
                 {
                     index2 = i;
                     List<int> xList = GetChildList(list, index1, index2);
                     if (xList.Count > 1)
                     {
                         splitList.Add(xList);
                     }
                     index1 = index2;
                 }
                 start = list[i];
             }
             List<int> xListLast = GetChildList(list, index1, list.Count);
             if (xListLast.Count > 1)
             {
                 splitList.Add(xListLast);
             }
             return splitList;

         }
        private static List<int> GetChildList(List<int> list, int index1, int index2)
         {
             List<int> listChild = new List<int>();
             for (int i = index1; i < index2; i++)
             {
                 listChild.Add(list[i]);
             }
             return listChild;
         }
        private static void Mark(Bitmap bmp, int y, List<int> xList)
         {
             for (int j = 0; j < xList.Count; j++)
             {
                 int newY = y - 1 < 0 ? y + 1 : y - 1;
                 Color color = bmp.GetPixel(xList[j], newY);
                 bmp.SetPixel(xList[j], y, color);
             }
         }
    }
}
