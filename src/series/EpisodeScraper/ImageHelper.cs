using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace EpisodeScraper
{
    public static class ImageHelper
    {
        public static byte[] ResizeImage(byte[] inputImage, int desiredWidth, int desiredHeight)
        {
            byte[] outputImage;
            var image = Image.FromStream(new MemoryStream(inputImage));
            var bmp = new Bitmap(desiredWidth, desiredHeight);
            using (Graphics grfx = Graphics.FromImage(bmp))
            {
                grfx.CompositingQuality = CompositingQuality.HighQuality;
                grfx.SmoothingMode = SmoothingMode.HighQuality;
                grfx.InterpolationMode = InterpolationMode.High;

                var rectangle = new Rectangle(0, 0, desiredWidth, desiredHeight);
                grfx.DrawImage(image, rectangle);

                // make a memory stream to work with the image bytes
                using (var imageStream = new MemoryStream())
                {
                    bmp.Save(imageStream, ImageFormat.Jpeg);
                    outputImage = imageStream.ToArray();
                    bmp.Dispose();
                    image.Dispose();
                }
            }

            //return imageStream == null ? null : Image.FromStream(imageStream);
            return outputImage;
        }
    }
}
