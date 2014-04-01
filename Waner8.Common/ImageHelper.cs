using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Waner8.Common
{
    public class ImageHelper
    {
        public enum AlgorithmsType
        {
            MaxValue,           //最大值法
            AverageValue,       //平均值法
            WeightAverage       //加权平均值法
        }
        /// <summary>
        /// Argb值判等
        /// </summary>
        /// <param name="cr1"></param>
        /// <param name="cr2"></param>
        /// <returns></returns>
        private static bool ArgbEqual(Color cr1, Color cr2)
        {
            if (cr1.A == cr2.A &&
                cr1.R == cr2.R &&
                cr1.G == cr2.G &&
                cr1.B == cr2.B)
            {
                return true;
            }

            return false;

        }
        /// <summary>
        /// 取得图像的一个连续的块
        /// 既是：连通分量（极大连通子图），Connected Component
        /// </summary>
        /// <param name="bm"></param>
        /// <param name="x">x起点</param>
        /// <param name="y">y起点</param>
        /// <returns>tslw</returns>
        private static Dictionary<string, Point> GetBlock(Bitmap bm, int x, int y)
        {
            // 极大连通分量的点的集合
            Dictionary<string, Point> Track = new Dictionary<string, Point>();
            string strKeyOfPoint;
            // 工作栈
            Stack<Point> stk = new Stack<Point>();

            Color Cr = bm.GetPixel(x, y);
            if (ArgbEqual(Cr, Color.White) == true)
            {
                // 测试点不是黑色
                return Track;
            }
            // 入栈起始位置
            stk.Push(new Point(x, y));

            // 深度优先搜索
            for (; stk.Count != 0; )
            {
                // 弹出栈顶元素
                Point Pt = stk.Pop();
                // 加入访问过的路径集合中
                strKeyOfPoint = Pt.X + "#" + Pt.Y;
                Track[strKeyOfPoint] = new Point(Pt.X, Pt.Y);

                #region 取得邻接点集合

                List<Point> lstAdjacency = new List<Point>();

                // 右
                Point ptTest = new Point(Pt.X + 1, Pt.Y);
                if (ptTest.X < bm.Width)
                {
                    Color crTest = bm.GetPixel(ptTest.X, ptTest.Y);
                    if (ArgbEqual(crTest, Color.Black))
                    {
                        lstAdjacency.Add(ptTest);
                    }
                }

                // 左
                ptTest = new Point(Pt.X - 1, Pt.Y);
                if (ptTest.X >= 0)
                {
                    Color crTest = bm.GetPixel(ptTest.X, ptTest.Y);
                    if (ArgbEqual(crTest, Color.Black))
                    {
                        lstAdjacency.Add(ptTest);
                    }
                }

                // 下
                ptTest = new Point(Pt.X, Pt.Y + 1);
                if (ptTest.Y < bm.Height)
                {
                    Color crTest = bm.GetPixel(ptTest.X, ptTest.Y);
                    if (ArgbEqual(crTest, Color.Black))
                    {
                        lstAdjacency.Add(ptTest);
                    }
                }

                // 上
                ptTest = new Point(Pt.X, Pt.Y - 1);
                if (ptTest.Y >= 0)
                {
                    Color crTest = bm.GetPixel(ptTest.X, ptTest.Y);
                    if (ArgbEqual(crTest, Color.Black))
                    {
                        lstAdjacency.Add(ptTest);
                    }
                }

                #endregion

                #region 遍历邻接点，加入路径栈

                for (int i = 0; i < lstAdjacency.Count; ++i)
                {
                    Point ptAdjacency = lstAdjacency[i];
                    strKeyOfPoint = ptAdjacency.X + "#" + ptAdjacency.Y;
                    if (Track.ContainsKey(strKeyOfPoint) == false)
                    {
                        stk.Push(ptAdjacency);
                    }
                }

                #endregion

            }
            // end for


            return Track;
        }
        /// <summary>
        /// 去除块。降噪
        /// </summary>
        /// <param name="bm">要操作的位图对象</param>
        /// /// <param name="nBelowBlockSize">块大小，低于指定的大小的块，将被抹成白色</param>
        public static Bitmap RemoveBlock(Image img, int nBlockSize)
        {
            Bitmap bm = new Bitmap(img);
            // 曾经遍历过的点
            Dictionary<string, Point> Track = new Dictionary<string, Point>();

            for (int i = 0; i < bm.Width; ++i)
            {
                for (int j = 0; j < bm.Height; ++j)
                {
                    if (Track.ContainsKey(i + "#" + j) == true)
                        continue;

                    Dictionary<string, Point> Block = GetBlock(bm, i, j);
                    foreach (string strkey in Block.Keys)
                    {
                        Track.Add(strkey, Block[strkey]);
                    }

                    if (Block.Count < nBlockSize)
                    {
                        foreach (KeyValuePair<string, Point> Item in Block)
                        {
                            Point pt = Item.Value;
                            bm.SetPixel(pt.X, pt.Y, Color.White);
                        }
                    }
                }
            }
            return bm;
        }
        /// <summary>
        /// 得到灰度图像前景背景的临界值 最大类间方差法
        /// </summary>
        /// <returns>前景背景的临界值</returns>
        public static int GetDgGrayValue(Image img)
        {
            Bitmap bmp = new Bitmap(img);
            int[] pixelNum = new int[256];           //图象直方图，共256个点
            int n, n1, n2;
            int total;                              //total为总和，累计值
            double m1, m2, sum, csum, fmax, sb;     //sb为类间方差，fmax存储最大方差值
            int k, t, q;
            int threshValue = 1;                      // 阈值
            //生成直方图
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    //返回各个点的颜色，以RGB表示
                    pixelNum[bmp.GetPixel(i, j).R]++;            //相应的直方图加1
                }
            }
            //直方图平滑化
            for (k = 0; k <= 255; k++)
            {
                total = 0;
                for (t = -2; t <= 2; t++)              //与附近2个灰度做平滑化，t值应取较小的值
                {
                    q = k + t;
                    if (q < 0)                     //越界处理
                        q = 0;
                    if (q > 255)
                        q = 255;
                    total = total + pixelNum[q];    //total为总和，累计值
                }
                pixelNum[k] = (int)((float)total / 5.0 + 0.5);    //平滑化，左边2个+中间1个+右边2个灰度，共5个，所以总和除以5，后面加0.5是用修正值
            }
            //求阈值
            sum = csum = 0.0;
            n = 0;
            //计算总的图象的点数和质量矩，为后面的计算做准备
            for (k = 0; k <= 255; k++)
            {
                sum += (double)k * (double)pixelNum[k];     //x*f(x)质量矩，也就是每个灰度的值乘以其点数（归一化后为概率），sum为其总和
                n += pixelNum[k];                       //n为图象总的点数，归一化后就是累积概率
            }

            fmax = -1.0;                          //类间方差sb不可能为负，所以fmax初始值为-1不影响计算的进行
            n1 = 0;
            for (k = 0; k < 256; k++)                  //对每个灰度（从0到255）计算一次分割后的类间方差sb
            {
                n1 += pixelNum[k];                //n1为在当前阈值遍前景图象的点数
                if (n1 == 0) { continue; }            //没有分出前景后景
                n2 = n - n1;                        //n2为背景图象的点数
                if (n2 == 0) { break; }               //n2为0表示全部都是后景图象，与n1=0情况类似，之后的遍历不可能使前景点数增加，所以此时可以退出循环
                csum += (double)k * pixelNum[k];    //前景的“灰度的值*其点数”的总和
                m1 = csum / n1;                     //m1为前景的平均灰度
                m2 = (sum - csum) / n2;               //m2为背景的平均灰度
                sb = (double)n1 * (double)n2 * (m1 - m2) * (m1 - m2);   //sb为类间方差
                if (sb > fmax)                  //如果算出的类间方差大于前一次算出的类间方差
                {
                    fmax = sb;                    //fmax始终为最大类间方差（otsu）
                    threshValue = k;              //取最大类间方差时对应的灰度的k就是最佳阈值
                }
            }
            return threshValue;
        }
        /// <summary>
        /// 二值化
        /// </summary>
        /// <param name="src"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Bitmap PBinary(Bitmap src, int v)
        {
            int w = src.Width;
            int h = src.Height;
            Bitmap dstBitmap = new Bitmap(src.Width, src.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            System.Drawing.Imaging.BitmapData srcData = src.LockBits(new Rectangle(0, 0, w, h), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            System.Drawing.Imaging.BitmapData dstData = dstBitmap.LockBits(new Rectangle(0, 0, w, h), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* pIn = (byte*)srcData.Scan0.ToPointer();
                byte* pOut = (byte*)dstData.Scan0.ToPointer();
                byte* p;
                int stride = srcData.Stride;
                int r, g, b;
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        p = pIn;
                        r = p[2];
                        g = p[1];
                        b = p[0];
                        pOut[0] = pOut[1] = pOut[2] = (byte)(((byte)(0.2125 * r + 0.7154 * g + 0.0721 * b) >= v)
                        ? 255 : 0);
                        pIn += 3;
                        pOut += 3;
                    }
                    pIn += srcData.Stride - w * 3;
                    pOut += srcData.Stride - w * 3;
                }
                src.UnlockBits(srcData);
                dstBitmap.UnlockBits(dstData);
                return dstBitmap;
            }
        }
        /// <summary>
        /// 灰度
        /// </summary>
        /// <param name="img"></param>
        /// <param name="algo"></param>
        /// <returns></returns>
        public static Image Gray(Image img, AlgorithmsType algo)
        {
            int width = img.Width;
            int height = img.Height;

            Bitmap bmp = new Bitmap(img);

            //设定实例BitmapData相关信息
            Rectangle rect = new Rectangle(0, 0, width, height);
            ImageLockMode mode = ImageLockMode.ReadWrite;
            PixelFormat format = PixelFormat.Format32bppArgb;

            //锁定bmp到系统内存中
            BitmapData data = bmp.LockBits(rect, mode, format);

            //获取位图中第一个像素数据的地址
            IntPtr ptr = data.Scan0;

            int numBytes = width * height * 4;
            byte[] rgbValues = new byte[numBytes];

            //将bmp数据Copy到申明的数组中
            Marshal.Copy(ptr, rgbValues, 0, numBytes);

            for (int i = 0; i < rgbValues.Length; i += 4)
            {
                int value = 0;
                switch (algo)
                {
                    //最大值法
                    case AlgorithmsType.MaxValue:
                        value = rgbValues[i] > rgbValues[i + 1] ? rgbValues[i] : rgbValues[i + 1];
                        value = value > rgbValues[i + 2] ? value : rgbValues[i + 2];
                        break;
                    //平均值法
                    case AlgorithmsType.AverageValue:
                        value = (int)((rgbValues[i] + rgbValues[i + 1] + rgbValues[i + 2]) / 3);
                        break;
                    //加权平均值法
                    case AlgorithmsType.WeightAverage:
                        value = (int)(rgbValues[i] * 0.1 + rgbValues[i + 1] * 0.2
                            + rgbValues[i + 2] * 0.7);
                        break;
                }

                //将数组中存放R、G、B的值修改为计算后的值
                for (int j = 0; j < 3; j++)
                {
                    rgbValues[i + j] = (byte)value;
                }
            }

            //将数据Copy到内存指针
            Marshal.Copy(rgbValues, 0, ptr, numBytes);

            //从系统内存解锁bmp
            bmp.UnlockBits(data);

            return (Image)bmp;

        }
        public static int ComputeThresholdValue(Bitmap img)
        {
            int i;
            int k;
            double csum;
            int thresholdValue = 1;
            int[] ihist = new int[0x100];
            for (i = 0; i < 0x100; i++)
            {
                ihist[i] = 0;
            }
            int gmin = 0xff;
            int gmax = 0;
            for (i = 1; i < (img.Width - 1); i++)
            {
                for (int j = 1; j < (img.Height - 1); j++)
                {
                    int cn = img.GetPixel(i, j).R;
                    ihist[cn]++;
                    if (cn > gmax)
                    {
                        gmax = cn;
                    }
                    if (cn < gmin)
                    {
                        gmin = cn;
                    }
                }
            }
            double sum = csum = 0.0;
            int n = 0;
            for (k = 0; k <= 0xff; k++)
            {
                sum += k * ihist[k];
                n += ihist[k];
            }
            if (n == 0)
            {
                return 60;
            }
            double fmax = -1.0;
            int n1 = 0;
            for (k = 0; k < 0xff; k++)
            {
                n1 += ihist[k];
                if (n1 != 0)
                {
                    int n2 = n - n1;
                    if (n2 == 0)
                    {
                        return thresholdValue;
                    }
                    csum += k * ihist[k];
                    double m1 = csum / ((double)n1);
                    double m2 = (sum - csum) / ((double)n2);
                    double sb = ((n1 * n2) * (m1 - m2)) * (m1 - m2);
                    if (sb > fmax)
                    {
                        fmax = sb;
                        thresholdValue = k;
                    }
                }
            }
            return thresholdValue;
        }
        /// <summary>
        ///  去掉杂点（适合杂点/杂线粗为1）
        /// </summary>
        /// <param name="dgGrayValue">背前景灰色界限</param>
        /// <returns></returns>
        public static Bitmap ClearNoise(Image img, int dgGrayValue, int MaxNearPoints)
        {
            Bitmap bmpobj = new Bitmap(img);
            Color piexl;
            int nearDots = 0;
            //逐点判断
            for (int i = 0; i < bmpobj.Width; i++)
                for (int j = 0; j < bmpobj.Height; j++)
                {
                    piexl = bmpobj.GetPixel(i, j);
                    if (piexl.R < dgGrayValue)
                    {
                        nearDots = 0;
                        //判断周围8个点是否全为空
                        if (i == 0 || i == bmpobj.Width - 1 || j == 0 || j == bmpobj.Height - 1)  //边框全去掉
                        {
                            bmpobj.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                        }
                        else
                        {
                            if (bmpobj.GetPixel(i - 1, j - 1).R < dgGrayValue) nearDots++;
                            if (bmpobj.GetPixel(i, j - 1).R < dgGrayValue) nearDots++;
                            if (bmpobj.GetPixel(i + 1, j - 1).R < dgGrayValue) nearDots++;
                            if (bmpobj.GetPixel(i - 1, j).R < dgGrayValue) nearDots++;
                            if (bmpobj.GetPixel(i + 1, j).R < dgGrayValue) nearDots++;
                            if (bmpobj.GetPixel(i - 1, j + 1).R < dgGrayValue) nearDots++;
                            if (bmpobj.GetPixel(i, j + 1).R < dgGrayValue) nearDots++;
                            if (bmpobj.GetPixel(i + 1, j + 1).R < dgGrayValue) nearDots++;
                        }

                        if (nearDots < MaxNearPoints)
                            bmpobj.SetPixel(i, j, Color.FromArgb(255, 255, 255));   //去掉单点 && 粗细小3邻边点
                    }
                    else  //背景
                        bmpobj.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                }
            return bmpobj;
        }
        /// 高亮
        /// </summary>
        /// <param name="bmp">图片对象</param>
        /// <param name="v">亮度</param>
        /// <returns></returns>
        public static Bitmap BrightnessP(Image img, int v)
        {
            Bitmap bmp = new Bitmap(img);
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            int bytes = bmp.Width * bmp.Height * 3;
            IntPtr ptr = bmpData.Scan0;
            int stride = bmpData.Stride;
            unsafe
            {
                byte* p = (byte*)ptr;
                int temp;
                for (int j = 0; j < bmp.Height; j++)
                {
                    for (int i = 0; i < bmp.Width * 3; i++, p++)
                    {
                        temp = (int)(p[0] + v);
                        temp = (temp > 255) ? 255 : temp < 0 ? 0 : temp;
                        p[0] = (byte)temp;
                    }
                    p += stride - bmp.Width * 3;
                }
            }
            bmp.UnlockBits(bmpData);
            return bmp;
        }
        /// <summary>
        /// 清晰化
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static Image ClearImage(Image img)
        {
            Bitmap bmp = new Bitmap(img);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    int nearDots = 0;
                    //遍历各个像素，获得bmp位图每个像素的RGB对象
                    Color pixelColor = bmp.GetPixel(i, j);
                    if (pixelColor.R >= 245 && pixelColor.G >= 245 && pixelColor.B >= 245)
                    {
                        bmp.SetPixel(i, j, Color.White);
                    }
                    if (!IsWhitePoint(pixelColor))
                    {
                        //判断周围8个点是否全为空
                        if (i == 0 || i == bmp.Width - 1 || j == 0 || j == bmp.Height - 1)  //边框全去掉
                        {
                            bmp.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                        }
                        else
                        {
                            //中间的点
                            if (bmp.GetPixel(i - 1, j - 1).R == 255) nearDots++;
                            if (bmp.GetPixel(i, j - 1).R == 255) nearDots++;
                            if (bmp.GetPixel(i + 1, j - 1).R == 255) nearDots++;
                            if (bmp.GetPixel(i - 1, j).R == 255) nearDots++;
                            if (bmp.GetPixel(i + 1, j).R == 255) nearDots++;
                            if (bmp.GetPixel(i - 1, j + 1).R == 255) nearDots++;
                            if (bmp.GetPixel(i, j + 1).R == 255) nearDots++;
                            if (bmp.GetPixel(i + 1, j + 1).R == 255) nearDots++;
                        }
                        if (nearDots == 8)
                            bmp.SetPixel(i, j, Color.FromArgb(255, 255, 255));   //去掉单点 && 粗细小3邻边点
                        else if (nearDots >= 6 && pixelColor.R == 100)
                        {
                            bmp.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                        }
                    }
                }

            }
            return bmp;
        }
        private static bool IsWhitePoint(Color pixelColor)
        {
            return (pixelColor.R >= 248 && pixelColor.G >= 248 && pixelColor.B >= 248);
        }
        public class Boundary
        {
            public int StartY { get; set; }
            public int EndY { get; set; }
            public int StartX { get; set; }
            public int EndX { get; set; }
        }
        /// <summary>
        /// 把图片的宽高统一，，行话叫归一
        /// </summary>
        /// <param name="bitmap">需要处理的图片</param>
        public static Bitmap Normalized(Bitmap bitmap,int ww,int hh)
        {
            Bitmap temp = new Bitmap(ww, hh);
            Graphics myGraphics = Graphics.FromImage(temp);
            //源图像中要裁切的区域
            Rectangle sourceRectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            ////缩小后要绘制的区域
            Rectangle destRectangle = new Rectangle(0, 0, ww, hh);
            myGraphics.Clear(Color.White);
            ////绘制缩小的图像
            myGraphics.DrawImage(bitmap, destRectangle, sourceRectangle, GraphicsUnit.Pixel);
            myGraphics.Dispose();
            return temp;
        }
        public static List<Bitmap> CutImage(Image img,int ww,int hh)
        {
            Bitmap bmp = null;
            List<Boundary> list = GetImgBoundaryList(img, ref bmp);
            List<Bitmap> imgList = new List<Bitmap>();
            if (list.Count == 4)
            {
                try
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        Boundary bd = list[i];
                        int _startY = bd.StartY;
                        int _endY = bd.EndY;
                        int _startX = bd.StartX;
                        int _endX = bd.EndX;
                        Bitmap bmp1 = new Bitmap(_endY - _startY, _endX - _startX);
                        //bmp1 = new ImageHandler().TrimBmp(bmp1);
                        for (int j = _startX; j < _endX; j++)
                        {
                            for (int k = _startY; k < _endY; k++)
                            {
                                Color pixelColor = bmp.GetPixel(k, j);
                                bmp1.SetPixel(k - _startY, j - _startX, pixelColor);
                            }
                        }
                        //归一化
                        Bitmap _bmp1 = Normalized(bmp1,ww,hh);
                        for (int j = 0; j < _bmp1.Height; j++)
                        {
                            for (int k = 0; k < _bmp1.Width; k++)
                            {
                                Color pixelColor = _bmp1.GetPixel(k, j);
                                if (pixelColor.R != 255)
                                {
                                    _bmp1.SetPixel(k, j, Color.Black);
                                }
                            }
                        }
                        imgList.Add(_bmp1);
                    }
                }
                catch
                {

                }
                return imgList;
            }
            else
                return null;
        }
        /// <summary>
        /// 获取图片的边界
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static List<Boundary> GetImgBoundaryList(Image img,ref Bitmap _bmp)
        {
            List<Boundary> list = new List<Boundary>();
            Bitmap bmp = new Bitmap(img);
            int startY = 0;
            int endY = 0;
            int startX = 0;
            int endX = 0;
            try
            {
                int cnt = 1;
                for (int i = 0; i < 10; i++)
                {
                    if (cnt < 8)
                    {
                        startY = GetStartBoundaryY(img, startY);
                        if (startY >= 0)
                        {
                            endY = GetEndBoundaryY(img, startY + 1);
                            //标记
                            startX = GetStartBoundaryX(img, startY, endY);
                            int _startX = startX;
                            bool flag = false;
                            while (!flag && cnt < 4 && _startX < img.Width)
                            {
                                endX = GetEndBoundaryX(img, _startX, startY, endY);
                                flag = endX - _startX > 4;
                                _startX = _startX + 1;
                            }
                            if (endX > 0 && endX - startX > 4)
                            {
                                list.Add(new Boundary { EndY = endY, EndX = endX, StartY = startY, StartX = startX });
                                cnt++;
                            }
                        }
                        startY = endY;
                    }
                    else
                        break;
                }
                if (list.Count == 0)
                {
                    ImageHandler ih = new ImageHandler();
                    _bmp = ih.TrimBmp(img);
                    list.Add(new Boundary() { StartX = 0, EndX = _bmp.Height - 1, EndY = _bmp.Width - 1, StartY = 0 });
                }
                else
                {
                    _bmp = new Bitmap(img);
                }
                if (list.Count == 1)
                {
                    //平均切割
                    Boundary bd = list[0];
                    int _startY = bd.StartY;
                    int _endY = _startY;
                    int _startX = bd.StartX;
                    int _endX = bd.EndX;
                    int avr = (list[0].EndY - list[0].StartY) / 4;
                    list.Clear();
                    for (int i = 0; i < 4; i++)
                    {
                        _endY = _startY + avr;
                        list.Add(new Boundary { EndY = _endY, EndX = _endX, StartY = _startY, StartX = _startX });
                        _startY = _endY;

                    }
                }
                if (list.Count == 3)
                {
                    Boundary max = list[0];
                    int index = 0;
                    for (int i = 1; i < list.Count; i++)
                    {
                        Boundary _max = list[i];
                        if (max.EndY - max.StartY < _max.EndY - _max.StartY)
                        {
                            index = i;
                            max = _max;
                        }
                    }
                    //平分
                    int _startY = max.StartY;
                    int _endY = _startY;
                    int _startX = max.StartX;
                    int _endX = max.EndX;
                    int avr = (max.EndY - max.StartY) / 2;
                    list.Remove(max);
                    for (int i = 0; i < 2; i++)
                    {
                        _endY = _startY + avr;
                        list.Insert(index, new Boundary { EndY = _endY, EndX = _endX, StartY = _startY, StartX = _startX });
                        index = index + 1;
                        _startY = _endY + 1;

                    }

                }
                if (list.Count == 2)
                {
                    if (Math.Abs((list[1].EndY - list[1].StartY) - (list[0].EndY - list[0].StartY)) > 15)
                    {
                        Boundary max = (list[1].EndY - list[1].StartY) > (list[0].EndY - list[0].StartY) ? list[1] : list[0];
                        //平分
                        int index = (list[1].EndY - list[1].StartY) > (list[0].EndY - list[0].StartY) ? 1 : 0;
                        int _startY = max.StartY;
                        int _endY = _startY;
                        int _startX = max.StartX;
                        int _endX = max.EndX;
                        int avr = (max.EndY - max.StartY) / 3;
                        list.Remove(max);
                        for (int i = 0; i < 3; i++)
                        {
                            _endY = _startY + avr;
                            list.Insert(index, new Boundary { EndY = _endY, EndX = _endX, StartY = _startY, StartX = _startX });
                            index = index + 1;
                            _startY = _endY + 1;

                        }
                    }
                    else
                    {
                        List<Boundary> _temp = new List<Boundary>();
                        for (int i = 0; i < 2; i++)
                        {
                            Boundary max = list[i];
                            //平分
                            int _startY = max.StartY;
                            int _endY = _startY;
                            int _startX = max.StartX;
                            int _endX = max.EndX;
                            int avr = (max.EndY - max.StartY) / 2;
                            for (int j = 0; j < 2; j++)
                            {
                                _endY = _startY + avr;
                                _temp.Add(new Boundary { EndY = _endY, EndX = _endX, StartY = _startY, StartX = _startX });
                                _startY = _endY + 1;

                            }
                        }
                        list = _temp;
                    }
                }
                List<Boundary> tempBdList = list;
                for (int i = 0; i < tempBdList.Count; i++)
                {
                    if (!((tempBdList[i].EndY - tempBdList[i].StartY > 4) && (tempBdList[i].EndX - tempBdList[i].StartX > 4)))
                    {
                        list.Remove(tempBdList[i]);
                    }
                }
            }
            catch
            {
            }
            return list;
        }
        //Y轴开始的边界
        public static int GetStartBoundaryY(Image img, int start)
        {
            Bitmap bmp = new Bitmap(img);
            int startB = 0;
            for (int i = start; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    //遍历各个像素，获得bmp位图每个像素的RGB对象
                    Color pixelColor = bmp.GetPixel(i, j);
                    if (pixelColor.Name != "ffffffff")
                    {
                        startB = i;
                        break;
                    }
                    else
                        continue;
                }
                if (startB != 0)
                {
                    break;
                }
                else
                    continue;
            }
            if (startB == start)
            {
                return startB + 2;
            }
            else
                return startB - 1;
        }
        //Y轴结束的边界
        private static int GetEndBoundaryY(Image img, int start)
        {
            Bitmap bmp = new Bitmap(img);
            int endB = 0;
            for (int i = start; i < bmp.Width; i++)
            {
                int cnt = 0;
                for (int j = 0; j < bmp.Height; j++)
                {
                    //遍历各个像素，获得bmp位图每个像素的RGB对象
                    Color pixelColor = bmp.GetPixel(i, j);
                    if (pixelColor.Name == "ffffffff")
                    {
                        cnt++;
                        continue;
                    }
                    else
                        break;
                }
                if (cnt == bmp.Height)
                {
                    endB = i;
                    break;
                }
            }
            return endB;
        }
        //X轴开始的边界
        private static int GetStartBoundaryX(Image img, int startY, int endY)
        {
            Bitmap bmp = new Bitmap(img);
            int startB = 0;
            for (int i = 0; i < img.Height; i++)
            {
                for (int j = startY; j < endY; j++)
                {
                    //遍历各个像素，获得bmp位图每个像素的RGB对象
                    Color pixelColor = bmp.GetPixel(j, i);
                    if (pixelColor.Name != "ffffffff")
                    {
                        startB = i;
                        break;
                    }
                    else
                        continue;
                }
                if (startB != 0)
                {
                    break;
                }
                else
                    continue;
            }
            return startB - 1;
        }
        private static int GetEndBoundaryX(Image img, int startX, int startY, int endY)
        {
            Bitmap bmp = new Bitmap(img);
            int endB = 0;
            for (int i = startX + 1; i < bmp.Height; i++)
            {
                int cnt = 0;
                for (int j = startY; j < endY; j++)
                {
                    //遍历各个像素，获得bmp位图每个像素的RGB对象
                    Color pixelColor = bmp.GetPixel(j, i);
                    if (pixelColor.Name == "ffffffff")
                    {
                        cnt++;
                        continue;
                    }
                    else
                        break;
                }
                if (cnt == endY - startY)
                {
                    endB = i;
                    break;
                }
            }
            return endB;
        }
        public static string GetBinaryCode(Image img)
        {
            string code = "";
            Bitmap bmp = new Bitmap(img);
            for (int j = 0; j < bmp.Height; j++)
            {
                for (int k = 0; k < bmp.Width; k++)
                {
                    Color color = bmp.GetPixel(k, j);
                    if (color.R == 255 && color.G == 255 && color.B == 255)
                    {
                        code = code + "0";
                    }
                    else
                        code = code + "1";
                }
            }
            return code;
        }
        /// <summary>
        /// 细化
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static Bitmap Hilditch(Image img)
        {
            Bitmap bmp = new Bitmap(img);
            int[,] input = new int[bmp.Width, bmp.Height];
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    Color color = bmp.GetPixel(j, i);
                    int v = color.R == 0 ? 1 : 0;
                    input[j, i] = v;
                }
            }
            int[,] x = ThinnerHilditch(input);
            Bitmap bm = new Bitmap(x.GetLength(0), x.GetLength(1));
            for (int i = 0; i < bm.Height; i++)
            {
                for (int j = 0; j < bm.Width; j++)
                {
                    int v = x[j, i];
                    if (v == 0)
                        bm.SetPixel(j, i, Color.White);
                    else
                        bm.SetPixel(j, i, Color.Black);
                }
            }
            return bm;
        }
        /// <summary>
        /// Hilditch细化算法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static int[,] ThinnerHilditch(int[,] input)
        {
            int lWidth = input.GetLength(0);
            int lHeight = input.GetLength(1);

            bool IsModified = true;
            int Counter = 1;
            int[] nnb = new int[9];
            //去掉边框像素
            for (int i = 0; i < lWidth; i++)
            {
                input[i, 0] = 0;
                input[i, lHeight - 1] = 0;
            }
            for (int j = 0; j < lHeight; j++)
            {
                input[0, j] = 0;
                input[lWidth - 1, j] = 0;
            }
            do
            {
                Counter++;
                IsModified = false;
                int[,] nb = new int[3, 3];
                for (int i = 1; i < lWidth; i++)
                {
                    for (int j = 1; j < lHeight; j++)
                    {
                        //条件1必须为黑点
                        if (input[i, j] != 1)
                        {
                            continue;
                        }

                        //取3*3领域
                        for (int m = 0; m < 3; m++)
                        {
                            for (int n = 0; n < 3; n++)
                            {
                                nb[m, n] = input[i - 1 + m, j - 1 + n];
                            }
                        }
                        //复制
                        nnb[0] = nb[2, 1] == 1 ? 0 : 1;
                        nnb[1] = nb[2, 0] == 1 ? 0 : 1;
                        nnb[2] = nb[1, 0] == 1 ? 0 : 1;
                        nnb[3] = nb[0, 0] == 1 ? 0 : 1;
                        nnb[4] = nb[0, 1] == 1 ? 0 : 1;
                        nnb[5] = nb[0, 2] == 1 ? 0 : 1;
                        nnb[6] = nb[1, 2] == 1 ? 0 : 1;
                        nnb[7] = nb[2, 2] == 1 ? 0 : 1;

                        // 条件2：p0,p2,p4,p6 不皆为前景点 
                        if (nnb[0] == 0 && nnb[2] == 0 && nnb[4] == 0 && nnb[6] == 0)
                        {
                            continue;
                        }
                        // 条件3: p0~p7至少两个是前景点 
                        int iCount = 0;
                        for (int ii = 0; ii < 8; ii++)
                        {
                            iCount += nnb[ii];
                        }
                        if (iCount > 6) continue;

                        // 条件4：联结数等于1 
                        if (DetectConnectivity(nnb) != 1)
                        {
                            continue;
                        }
                        // 条件5: 假设p2已标记删除，则令p2为背景，不改变p的联结数 
                        if (input[i, j - 1] == -1)
                        {
                            nnb[2] = 1;
                            if (DetectConnectivity(nnb) != 1)
                                continue;
                            nnb[2] = 0;
                        }
                        // 条件6: 假设p4已标记删除，则令p4为背景，不改变p的联结数 
                        if (input[i, j + 1] == -1)
                        {
                            nnb[6] = 1;
                            if (DetectConnectivity(nnb) != 1)
                                continue;
                            nnb[6] = 0;
                        }

                        input[i, j] = -1;
                        IsModified = true;
                    }
                }
                for (int i = 0; i < lWidth; i++)
                {
                    for (int j = 0; j < lHeight; j++)
                    {
                        if (input[i, j] == -1)
                        {
                            input[i, j] = 0;
                        }
                    }
                }

            } while (IsModified);

            return input;
        }
        /// <summary>
        /// 计算八联结的联结数，计算公式为：
        ///     (p6 - p6*p7*p0) + sigma(pk - pk*p(k+1)*p(k+2)), k = {0,2,4)
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private static Int32 DetectConnectivity(int[] list)
        {
            Int32 count = list[6] - list[6] * list[7] * list[0];
            count += list[0] - list[0] * list[1] * list[2];
            count += list[2] - list[2] * list[3] * list[4];
            count += list[4] - list[4] * list[5] * list[6];
            return count;
        }
        public static Dictionary<Color, List<Point>> GetColorDic(Bitmap bmpobj)
        {
            Dictionary<Color, List<Point>> colorDic = new Dictionary<Color, List<Point>>();
            for (int i = 0; i < bmpobj.Width; i++)
            {
                for (int j = 0; j < bmpobj.Height; j++)
                {
                    Color color = bmpobj.GetPixel(i, j);
                    if (colorDic.ContainsKey(color))
                    {
                        List<Point> pointList = colorDic[color];
                        pointList.Add(new Point() { X = i, Y = j });
                        colorDic[color] = pointList;
                    }
                    else
                    {
                        List<Point> pointList = new List<Point>();
                        pointList.Add(new Point() { X = i, Y = j });
                        colorDic.Add(color, pointList);
                    }
                }
            }
            return colorDic;
        }
        public static Bitmap ClearNoise(Image img, int MaxNearPoints)
        {
            Bitmap bmpobj = new Bitmap(img);
            int nearDots = 0;
            for (int i = 0; i < bmpobj.Width; i++)
            {
                for (int j = 0; j < bmpobj.Height; j++)
                {

                    nearDots = 0;
                    if ((((i == 0) || (i == (bmpobj.Width - 1))) || (j == 0)) || (j == (bmpobj.Height - 1)))
                    {
                        bmpobj.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                    }
                    else
                    {
                        if (bmpobj.GetPixel(i - 1, j - 1).R == 0)
                        {
                            nearDots++;
                        }
                        if (bmpobj.GetPixel(i, j - 1).R == 0)
                        {
                            nearDots++;
                        }
                        if (bmpobj.GetPixel(i + 1, j - 1).R == 0)
                        {
                            nearDots++;
                        }
                        if (bmpobj.GetPixel(i - 1, j).R == 0)
                        {
                            nearDots++;
                        }
                        if (bmpobj.GetPixel(i + 1, j).R == 0)
                        {
                            nearDots++;
                        }
                        if (bmpobj.GetPixel(i - 1, j + 1).R == 0)
                        {
                            nearDots++;
                        }
                        if (bmpobj.GetPixel(i, j + 1).R == 0)
                        {
                            nearDots++;
                        }
                        if (bmpobj.GetPixel(i + 1, j + 1).R == 0)
                        {
                            nearDots++;
                        }
                    }
                    if (nearDots < MaxNearPoints)
                    {
                        bmpobj.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                    }
                }
            }
            return bmpobj;
        }

      
        public static int CalcRate(string t1, string t2)
        {
            if (t1.Length > 0 && t2.Length > 0)
            {
                char[] b1 = t1.ToCharArray();
                char[] b2 = t2.ToCharArray();
                var result = b1.Zip(b2, (b11, b22) => b11 ^ b22).ToArray();
                int cnt = 0;
                for (int i = 0; i < result.Length; i++)
                {
                    int str = result[i];
                    if (str == 0)
                    {
                        cnt++;
                    }
                }
                return cnt * 100 / result.Length;
            }
            else
                return 0;
        }
    }
}
