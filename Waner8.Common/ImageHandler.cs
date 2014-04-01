using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Waner8.Common
{
    public class ImageHandler
    {
        public List<string> GetImageArray(Image img)
        {
            Bitmap bmp = new Bitmap(img);
            List<string> list = new List<string>();
            for (int i = 0; i < bmp.Height; i++)
            {
                string code = string.Empty;
                for (int j = 0; j < bmp.Width; j++)
                {
                    Color color = bmp.GetPixel(j, i);
                    int v = color.R == 255 ? 0 : 1;
                    code = code + v;
                }
                list.Add(code);
            }
            return list;
        }
        public int[,] ConvertImgToArrayY(Image img)
        {
            Bitmap bmp = new Bitmap(img);
            int[,] input = new int[bmp.Height, bmp.Width];
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    Color color = bmp.GetPixel(j, i);
                    int v = color.R == 255 ? 0 : 1;
                    input[i, j] = v;
                }
            }
            return input;
        }
        public int[,] ConvertImgToArrayX(Image img)
        {
            Bitmap bmp = new Bitmap(img);
            int[,] input = new int[bmp.Width, bmp.Height];
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color color = bmp.GetPixel(i, j);
                    int v = color.R == 255 ? 0 : 1;
                    input[i, j] = v;
                }
            }
            return input;
        }
        public int[] GetArrayX(int[,] input, int y)
        {
            int w = input.GetLength(1);
            int[] xArray = new int[w];
            for (int j = 0; j < w; j++)
            {
                xArray[j] = input[y, j];
            }
            return xArray;
        }
        public int[] GetArrayY(int[,] input, int x)
        {
            int h = input.GetLength(1);
            int[] yArray = new int[h];
            for (int j = 0; j < h; j++)
            {
                yArray[j] = input[x, j];
            }
            return yArray;
        }
        public string Array2String(int[] array, bool flag)
        {
            string str = "";
            foreach (int a in array)
            {
                str = str + a;
            }
            if (flag)
            {
                while (str.StartsWith("0"))
                {
                    str = str.Remove(0, 1);
                }
                while (str.EndsWith("0"))
                {
                    int eIndex = str.LastIndexOf("0");
                    str = str.Remove(eIndex);
                }
            }
            return str;
        }
        public Point GetYBeyond(int[,] input)
        {
            int h = 0;
            h = input.GetLength(0);
            int y1 = 0;
            for (int i = 0; i < h; i++)
            {
                int[] xArray = GetArrayX(input, i);
                string str = Array2String(xArray, false);
                if (str.IndexOf("1") > -1)
                {
                    y1 = i;
                    break;
                }
            }
            int y2 = 0;
            for (int i = h - 1; i > 0; i--)
            {
                int[] xArray = GetArrayX(input, i);
                string str = Array2String(xArray, false);
                if (str.IndexOf("1") > -1)
                {
                    y2 = i;
                    break;
                }
            }
            return new Point(y1, y2);
        }
        public Point GetXBeyond(int[,] input)
        {
            int w = 0;
            w = input.GetLength(0);
            int x1 = 0;
            for (int i = 0; i < w; i++)
            {
                int[] yArray = GetArrayY(input, i);
                string str = Array2String(yArray, false);
                if (str.IndexOf("1") > -1)
                {
                    x1 = i;
                    break;
                }
            }
            int x2 = 0;
            for (int i = w - 1; i > 0; i--)
            {
                int[] yArray = GetArrayY(input, i);
                string str = Array2String(yArray, false);
                if (str.IndexOf("1") > -1)
                {
                    x2 = i;
                    break;
                }
            }
            return new Point(x1, x2);
        }

        public Bitmap TrimBmp(Image img)
        {
            int[,] inputX = ConvertImgToArrayY(img);
            int[,] inputY = ConvertImgToArrayX(img);
            Point beyondX = GetXBeyond(inputX);
            Point beyondY = GetYBeyond(inputY);
            int w = beyondY.Y - beyondY.X + 1;
            int h = beyondX.Y - beyondX.X + 1;
            Bitmap bmp = new Bitmap(w, h);
            for (int i = 0; i < h; i++)
            {
                int _y = i + beyondX.X;
                for (int j = 0; j < w; j++)
                {
                    int _x = j + beyondY.X;
                    int v = inputX[_y, _x];
                    if (v == 1)
                    {
                        bmp.SetPixel(j, i, Color.Black);
                    }
                    else
                        bmp.SetPixel(j, i, Color.White);
                }
            }
            return bmp;
        }
        public class Beyond
        {

            public int StartX { get; set; }
            public int EndX { get; set; }
        }
        /// <summary>
        ///得到图片的边界
        /// </summary>
        /// <param name="img">图片</param>
        /// <param name="v">字符的宽度预估值</param>
        /// <returns></returns>
        public List<Beyond> GetImageBeyondList(Image img, int v)
        {
            List<Beyond> resultList = new List<Beyond>();
            int[,] inputX = ConvertImgToArrayX(img);
            List<int> indexList = new List<int>();
            for (int i = 0; i < img.Width; i++)
            {
                int[] yArray = GetArrayX(inputX, i);
                string str = Array2String(yArray, false);
                int trap = img.Height / 3;
                if (str.IndexOf("1") == -1)
                {
                    indexList.Add(i);
                }
            }
            indexList.Add(-1);
            indexList.Add(img.Width);
            indexList.Sort();
            int startX = indexList[0];
            List<Beyond> listBeyond = new List<Beyond>();
            for (int i = 1; i < indexList.Count; i++)
            {
                int endX = indexList[i];
                if (endX - startX >= 4)
                {
                    Beyond beyond = new Beyond();
                    beyond.StartX = startX + 1;
                    beyond.EndX = endX - 1;
                    listBeyond.Add(beyond);
                }
                startX = endX;
            }

            if (listBeyond.Count == 1)
            {

                //平均切割
                Beyond bd = listBeyond[0];
                int avr = (bd.EndX - bd.StartX) / 4;
                int _startX = bd.StartX;
                listBeyond.Clear();
                for (int i = 0; i < 4; i++)
                {
                    int _endX = _startX + avr;
                    listBeyond.Add(new Beyond { StartX = _startX, EndX = _endX });
                    _startX = _endX;

                }
            }
            if (listBeyond.Count == 3)
            {
                Beyond max = listBeyond[0];
                int index = 0;
                for (int i = 1; i < listBeyond.Count; i++)
                {
                    Beyond _max = listBeyond[i];
                    if (max.EndX - max.StartX < _max.EndX - _max.StartX)
                    {
                        index = i;
                        max = _max;
                    }
                }
                //平分
                int _startX = max.StartX;
                int _endX = max.EndX;
                int avr = (max.EndX - max.StartX) / 2;
                listBeyond.Remove(max);
                for (int i = 0; i < 2; i++)
                {
                    _endX = _startX + avr;
                    listBeyond.Insert(index, new Beyond { StartX = _startX, EndX = _endX });
                    index = index + 1;
                    _startX = _endX;

                }

            }
            if (listBeyond.Count == 2)
            {
                if (Math.Abs((listBeyond[1].EndX - listBeyond[1].StartX) - (listBeyond[0].EndX - listBeyond[0].StartX)) > 15)
                {
                    Beyond max = (listBeyond[1].EndX - listBeyond[1].StartX) > (listBeyond[0].EndX - listBeyond[0].StartX) ? listBeyond[1] : listBeyond[0];
                    //平分
                    int index = (listBeyond[1].EndX - listBeyond[1].StartX) > (listBeyond[0].EndX - listBeyond[0].StartX) ? 1 : 0;
                    int _startX = max.StartX;
                    int _endX = max.EndX;
                    int avr = (max.EndX - max.StartX) / 3;
                    listBeyond.Remove(max);
                    for (int i = 0; i < 3; i++)
                    {
                        _endX = _startX + avr;
                        listBeyond.Insert(index, new Beyond { StartX = _startX, EndX = _endX });
                        index = index + 1;
                        _startX = _endX;
                    }
                }
                else
                {
                    List<Beyond> _temp = new List<Beyond>();
                    for (int i = 0; i < 2; i++)
                    {
                        Beyond max = listBeyond[i];
                        //平分
                        int _startX = max.StartX;
                        int _endX = max.EndX;
                        int avr = (max.EndX - max.StartX) / 2;
                        for (int j = 0; j < 2; j++)
                        {
                            if (j == 0)
                            {
                                _endX = _startX + avr;
                                _startX = _endX;
                                _temp.Add(new Beyond { StartX = max.StartX, EndX = _endX });
                            }
                            if (j == 1)
                            {
                                _temp.Add(new Beyond { StartX = _startX, EndX = max.EndX });
                            }
                        }
                    }
                    listBeyond = _temp;
                }
            }
            return listBeyond;
        }
        public List<Bitmap> CutImage(Image img, int v)
        {
            Bitmap bmpSource = new Bitmap(img);
            List<Bitmap> imgList = new List<Bitmap>();
            List<Beyond> list = GetImageBeyondList(img, v);
            for (int i = 0; i < list.Count; i++)
            {
                Beyond bd = list[i];
                int startX = bd.StartX;
                int endX = bd.EndX;
                endX = endX > img.Width - 1 ? img.Width - 1 : endX;
                Bitmap bmp = new Bitmap(endX - startX + 1, img.Height);
                for (int j = 0; j < bmpSource.Height; j++)
                {
                    for (int k = startX; k < endX + 1; k++)
                    {
                        Color pixelColor = bmpSource.GetPixel(k, j);
                        bmp.SetPixel(k - startX, j, pixelColor);
                    }
                }
                bmp = TrimBmp(bmp);
                bmp = ImageHelper.Normalized(bmp,16,16);
                imgList.Add(bmp);
            }
            return imgList;

        }

        public Bitmap CutImage(Image img, int v, ref int _cnt)
        {
            List<Beyond> list = GetImageBeyondList(img, v);
            Bitmap bmp = new Bitmap(img);
            _cnt = list.Count;
            for (int i = 0; i < list.Count; i++)
            {
                Beyond bd = list[i];
                int startx = bd.StartX;
                int endX = bd.EndX;
                endX = endX > img.Width - 1 ? img.Width - 1 : endX;
                for (int j = 0; j < img.Height - 1; j++)
                {
                    bmp.SetPixel(startx, j, Color.Red);
                    bmp.SetPixel(endX, j, Color.Red);
                }
            }
            return bmp;
        }
        /// <summary>
        /// 计算相似度
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public int CalcRate(string t1, string t2)
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
