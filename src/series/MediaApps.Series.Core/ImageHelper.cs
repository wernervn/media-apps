using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace MediaApps.Series.Core;

public static class ImageHelper
{
    public static byte[] ReduceImageSize(byte[] inputImage, CompositingQuality compositingQuality = CompositingQuality.HighQuality, SmoothingMode smoothingMode = SmoothingMode.HighQuality, InterpolationMode interpolationMode = InterpolationMode.High)
    {
        var outputImage = Array.Empty<byte>();

        if (Debugger.IsAttached && (inputImage is null || inputImage.Length == 0))
        {
            Debugger.Break();
        }

        try
        {
            var image = Image.FromStream(new MemoryStream(inputImage));

            var desiredWidth = image.Width;
            var desiredHeight = image.Height;

            var bmp = new Bitmap(desiredWidth, desiredHeight);
            using var grfx = Graphics.FromImage(bmp);
            grfx.CompositingQuality = compositingQuality;
            grfx.SmoothingMode = smoothingMode;
            grfx.InterpolationMode = interpolationMode;

            var rectangle = new Rectangle(0, 0, desiredWidth, desiredHeight);
            grfx.DrawImage(image, rectangle);

            // make a memory stream to work with the image bytes
            using var imageStream = new MemoryStream();
            bmp.Save(imageStream, ImageFormat.Jpeg);
            outputImage = imageStream.ToArray();
            bmp.Dispose();
            image.Dispose();
        }
        catch
        {
            //return null when the input is an invalid image
        }
        return outputImage;
    }

    public static byte[] ReduceImageByFactor(byte[] inputImage, double reduceFactor, CompositingQuality compositingQuality = CompositingQuality.HighQuality, SmoothingMode smoothingMode = SmoothingMode.HighQuality, InterpolationMode interpolationMode = InterpolationMode.High)
    {
        var outputImage = Array.Empty<byte>();

        if (Debugger.IsAttached && (inputImage is null || inputImage.Length == 0))
        {
            Debugger.Break();
        }

        try
        {
            var image = Image.FromStream(new MemoryStream(inputImage));

            var desiredWidth = Convert.ToInt32(Math.Floor(image.Width / reduceFactor));
            var desiredHeight = Convert.ToInt32(Math.Floor(image.Height / reduceFactor));

            var bmp = new Bitmap(desiredWidth, desiredHeight);
            using var grfx = Graphics.FromImage(bmp);
            grfx.CompositingQuality = compositingQuality;
            grfx.SmoothingMode = smoothingMode;
            grfx.InterpolationMode = interpolationMode;

            var rectangle = new Rectangle(0, 0, desiredWidth, desiredHeight);
            grfx.DrawImage(image, rectangle);

            // make a memory stream to work with the image bytes
            using var imageStream = new MemoryStream();
            bmp.Save(imageStream, ImageFormat.Jpeg);
            outputImage = imageStream.ToArray();
            bmp.Dispose();
            image.Dispose();
        }
        catch
        {
            //return null when the input is an invalid image
        }
        return outputImage;
    }
}
