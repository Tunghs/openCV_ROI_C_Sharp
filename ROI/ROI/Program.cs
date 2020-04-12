using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenCvSharp;

namespace ROI
{
    class Program
    {
        static void Main(string[] args)
        {
            string imgPath = @"C:\Users\dljdg\Desktop\보내줄 사진\스크린샷(42).png";

            Mat src = new Mat(imgPath);
            Mat dst = src.SubMat(new Rect(300, 300, 500, 500));

            Mat trg = new Mat();

            Cv2.ImShow("src",src);
            Cv2.ImShow("dst", dst);

            Cv2.CopyMakeBorder

            Cv2.WaitKey(0);
        }
    }
}
