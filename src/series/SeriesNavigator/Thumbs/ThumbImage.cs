using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace SeriesNavigator.Thumbs
{
    public class ThumbImage
    {
        public ThumbImage(string imagePath, string itemPath, int index, string description, SeriesView currentView)
            : this(GetImage(imagePath), itemPath, index, description, currentView) { }

        public ThumbImage(Image image, string itemPath, int index, string description, SeriesView currentView)
        {
            Image = image;
            ItemPath = itemPath;
            Index = index;
            Name = GetName();
            Description = description;
            CurrentView = currentView;
        }

        public Image Image { get; }
        public string ItemPath { get; }
        public int Index { get; }
        public string Name { get; }
        public string Description { get; }
        public SeriesView CurrentView { get; }

        private string GetName()
            => File.Exists(ItemPath) ? Path.GetFileName(ItemPath) : new DirectoryInfo(ItemPath).Name;

        private static Image GetImage(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return ThumbsHelper.EmptyImage;
            }

            using var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.Asynchronous);
            //return ScaleImage(Image.FromStream(fs), Constants.THUMB_WIDTH, Constants.THUMB_HEIGHT);
            return Image.FromStream(fs);
        }

        //public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        //{
        //    var ratioX = (double)maxWidth / image.Width;
        //    var ratioY = (double)maxHeight / image.Height;
        //    var ratio = Math.Min(ratioX, ratioY);

        //    var newWidth = (int)(image.Width * ratio);
        //    var newHeight = (int)(image.Height * ratio);

        //    var newImage = new Bitmap(newWidth, newHeight);

        //    _ = Task.Run(() =>
        //      {
        //          using (var graphics = Graphics.FromImage(newImage))
        //          {
        //              graphics.DrawImage(image, 0, 0, newWidth, newHeight);
        //          }
        //      });

        //    return newImage;
        //}

        //private static Image ResizePhoto(Image original, int desiredWidth, int desiredHeight)
        //{
        //    //throw error if bounding box is to small
        //    if (desiredWidth < 4 || desiredHeight < 4)
        //    {
        //        throw new InvalidOperationException("Bounding Box of Resize Photo must be larger than 4X4 pixels.");
        //    }

        //    //store image widths in variable for easier use
        //    var oW = (decimal)original.Width;
        //    var oH = (decimal)original.Height;
        //    var dW = (decimal)desiredWidth;
        //    var dH = (decimal)desiredHeight;

        //    //check if image already fits
        //    if (oW < dW && oH < dH)
        //    {
        //        return original; //image fits in bounding box, keep size (centre with CSS) If we made it bigger it would stretch the image resulting in loss of quality.
        //    }

        //    //check for double squares
        //    if (oW == oH && dW == dH)
        //    {
        //        //image and bounding box are square, no need to calculate aspects, just downsize it with the bounding box
        //        var square = new Bitmap(original, (int)dW, (int)dH);
        //        original.Dispose();
        //        return square;
        //    }

        //    //check original image is square
        //    if (oW == oH)
        //    {
        //        //image is square, bounding box isn't.  Get smallest side of bounding box and resize to a square of that centre the image vertically and horizontally with CSS there will be space on one side.
        //        var smallSide = (int)Math.Min(dW, dH);
        //        var square = new Bitmap(original, smallSide, smallSide);
        //        original.Dispose();
        //        return square;
        //    }

        //    //not dealing with squares, figure out resizing within aspect ratios
        //    if (oW > dW && oH > dH) //image is wider and taller than bounding box
        //    {
        //        var r = Math.Min(dW, dH) / Math.Min(oW, oH); //two dimensions so figure out which bounding box dimension is the smallest and which original image dimension is the smallest, already know original image is larger than bounding box
        //        var nH = oW * r; //will downscale the original image by an aspect ratio to fit in the bounding box at the maximum size within aspect ratio.
        //        var nW = oW * r;
        //        var resized = new Bitmap(original, (int)nW, (int)nH);
        //        original.Dispose();
        //        return resized;
        //    }
        //    else
        //    {
        //        if (oW > dW) //image is wider than bounding box
        //        {
        //            var r = dW / oW; //one dimension (width) so calculate the aspect ratio between the bounding box width and original image width
        //            var nW = oW * r; //downscale image by r to fit in the bounding box...
        //            var nH = oW * r;
        //            var resized = new Bitmap(original, (int)nW, (int)nH);
        //            original.Dispose();
        //            return resized;
        //        }
        //        else
        //        {
        //            //original image is taller than bounding box
        //            var r = dH / oH;
        //            var nH = oH * r;
        //            var nW = oW * r;
        //            var resized = new Bitmap(original, (int)nW, (int)nH);
        //            original.Dispose();
        //            return resized;
        //        }
        //    }
        //}
    }

}
