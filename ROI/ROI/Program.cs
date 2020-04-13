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
            Mat srt = src.SubMat(new Rect(300, 300, 500, 500));
            Mat dst = src.SubMat(new Rect(300, 300, 500, 500));

            // 제로패딩 
            Mat zeroPadding = new Mat(dst.Size(), dst.Type());

            int shiftWidth = -100;
            int shiftHeight = -100;

            Rect srcRoi = new Rect(Math.Max(-shiftWidth, 0), Math.Max(-shiftHeight, 0), dst.Width - Math.Abs(shiftWidth), dst.Height - Math.Abs(shiftHeight));
            Rect dstRoi = new Rect(Math.Max(shiftWidth, 0), Math.Max(shiftHeight, 0), dst.Width - Math.Abs(shiftWidth), dst.Height - Math.Abs(shiftHeight));

            Cv2.ImShow("src", src);

            // Roi 
            Cv2.ImShow("str", srt);

            // 제로 패딩
            dst.SubMat(srcRoi).CopyTo(zeroPadding.SubMat(dstRoi));

            Cv2.ImShow("dst", dst);

            Cv2.ImShow("zeroPadding", zeroPadding);

            int intensity1 = zeroPadding.At<byte>(200, 100);
            int intensity2 = zeroPadding.At<byte>(499, 499);
            int intensity3 = zeroPadding.At<byte>(2, 2);

            int intensity_b = zeroPadding.At<Vec3b>(450, 450)[0];
            int intensity_g = zeroPadding.At<Vec3b>(450, 450)[1];
            int intensity_r = zeroPadding.At<Vec3b>(450, 450)[2];
            //Cv2.ImWrite(@"C:\Users\dljdg\Desktop\보내줄 사진\zero.png", zeroPadding);
            Console.WriteLine(intensity1);
            Console.WriteLine(intensity2);
            Console.WriteLine(intensity3);

            Console.WriteLine("R:{0}, G:{1}, B{2}", intensity_r, intensity_g, intensity_b);

            Cv2.WaitKey(0);
        }
    }
}
