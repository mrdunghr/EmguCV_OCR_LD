using Emgu.CV.CvEnum;
using Emgu.CV;
using IronOcr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace ScreenShotToHandleConsole.Properties
{
    internal class OrcVietName
    {
        public static string OCR_ToanBoAnh(string pathImage)
        {
            var OCR = new IronTesseract();
            OCR.Language = OcrLanguage.Vietnamese;

            OcrInput Input = new OcrInput(pathImage);

            OcrResult result = OCR.Read(Input);

            string AllText = result.Text;

            Input.Dispose();

            return AllText;
        }

        public static string OCR_MotVungTrenAnh(string pathImage, int startX, int startY, int width, int height)
        {
            // Khởi tạo đối tượng OCR từ thư viện IronTesseract
            var OCR = new IronTesseract();
            // Đặt ngôn ngữ cho OCR là tiếng Việt
            OCR.Language = OcrLanguage.Vietnamese;

            // Load ảnh sử dụng EmguCV
            Mat image = CvInvoke.Imread(pathImage, ImreadModes.Color);

            // Xác định vùng cắt (ROI - Region of Interest) trên ảnh
            Rectangle roi = new Rectangle(startX, startY, width, height);
            // Cắt ảnh theo vùng được xác định
            Mat croppedImage = new Mat(image, roi);

            // Lưu ảnh đã cắt vào một tệp tạm thời
            string tempImagePath = "temp.jpg";
            croppedImage.Save(tempImagePath);

            // Thực hiện OCR trên vùng đã cắt
            OcrInput Input = new OcrInput(tempImagePath);
            OcrResult result = OCR.Read(Input);

            // Lấy văn bản từ kết quả OCR
            string AllText = result.Text;

            // Giải phóng tài nguyên
            Input.Dispose();
            croppedImage.Dispose();
            image.Dispose();

            // Xóa tệp ảnh tạm thời
            if (File.Exists(tempImagePath))
            {
                File.Delete(tempImagePath);
            }

            return AllText;
        }
    }
}
