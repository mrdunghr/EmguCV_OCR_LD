using Emgu.CV.CvEnum;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenShotToHandleConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            WindowCapture windowCapture = new WindowCapture("LdPlayer");

            Mat mat = windowCapture.CaptureWindow();
            Console.WriteLine("Rows: " + mat.Rows);
            Console.WriteLine("Cols: " + mat.Cols);
            Console.WriteLine("Depth: " + mat.Depth);

            CvInvoke.Imshow("Image", mat);
            CvInvoke.WaitKey(0); // Đợi người dùng nhấn một phím bất kỳ trước khi đóng cửa sổ

            Mat source = CvInvoke.Imread("captured_image.png", ImreadModes.Color);
            Mat template = CvInvoke.Imread("temp/4.png", ImreadModes.Color);

            Console.WriteLine("Rows: " + template.Rows);
            Console.WriteLine("Cols: " + template.Cols);
            Console.WriteLine("Depth: " + template.Depth);
            windowCapture.MathTemplateByThreshold(source, template);
        }
    }
}
