using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net;
using WVN.Extensions;
using WVN.IO.Helpers;

namespace MovieCollection.Common;

public static class Helpers
{
    private const long SIZE_KB = 1024;
    private const long SIZE_MB = SIZE_KB * SIZE_KB;
    private const long SIZE_GB = SIZE_MB * SIZE_KB;

    public static string GetTempFileWithExtension(string extension)
    {
        if (!extension.StartsWith(".", StringComparison.CurrentCulture))
        {
            extension = string.Concat(".", extension);
        }

        return string.Concat(Path.GetTempPath(), Guid.NewGuid().ToString(), extension);
    }

    public static string GetSize(long size)
    {
        if (size > SIZE_GB)
        {
            return Math.Round((decimal)size / SIZE_GB, 2) + " GB";
        }
        else if (size > SIZE_MB)
        {
            return Math.Round((decimal)size / SIZE_MB, 2) + " MB";
        }
        else if (size > SIZE_KB)
        {
            return Math.Round((decimal)size / SIZE_KB, 0) + " KB";
        }
        else
        {
            return size + " Bytes";
        }
    }

    public static string ScrubMovieName(string name)
    {
        var spaceChars = new List<string> { ".", "_", "(", ")", "[", "]" };
        var removals = new List<string> { "Extended", "DVDRip", "BDRip", "BRRip", "HDTV", "Xvid", @"\d{4}p", @"\d{4}", @"\d{3}p", "dvdscr", "limited", "hdrip", "x264", "r5", "bluray", "unrated", "directors cut", "AC3", "webrip", "webdl", "remastered", "YTS AG", "-EVO", "-ETRG", "AAC", "READNFO", "YTS PE", "-RARBG", "H264", "YTS.ME", "YTS.AM" };
        name = name.ReplaceAllChars(spaceChars, " ");
        name = name.RegExReplaceAllChars(removals, string.Empty, true);
        return name.Trim();
    }

    public static async Task<byte[]> DownloadImage(string imageUrl)
    {
        byte[] data = null;

        try
        {
            using var client = new HttpClient();
            return await client.GetByteArrayAsync(imageUrl);
        }
        catch (HttpListenerException ex)
        {
            Console.WriteLine("Error accessing " + imageUrl + " - " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error accessing " + imageUrl + " - " + ex.Message);
        }
        return data;
    }

    /// <summary>
    /// System.Drawing.Image.FromFile locks the file, this method doesn't
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns>Image</returns>
    public static Image ImageFromFile(string fileName)
    {
        if (fileName == null) throw new ArgumentNullException(nameof(fileName));

        using (FileStream lStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
        {
            return Image.FromStream(lStream);
        }
    }

    #region File searching
    public static List<string> GetFolderImages(string path) => FileUtil.GetFiles(path, Constants.IMAGE_VALUES, SearchOption.TopDirectoryOnly).ToList();
    #endregion

    public static bool IsImageFile(string extension) => Constants.IMAGE_VALUES.Contains(extension.ToLower());

    public static bool IsMovieFile(string extension) => Constants.MOVIE_VALUES.Contains(extension.ToLower());

    public static void Launch(string fileName, string args = null)
    {
        var p = new Process();
        var psi = new ProcessStartInfo { FileName = fileName, UseShellExecute = true };
        if (args != null)
        {
            psi.Arguments = args;
        }
        p.StartInfo = psi;
        p.Start();
    }

    #region Imaging
    public static byte[] ResizeImage(byte[] inputImage, int desiredWidth, int desiredHeight)
    {
        byte[] outputImage = { };
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
            using (MemoryStream imageStream = new MemoryStream())
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

    public static byte[] GetMovieImage(string url)
    {
        byte[] data = DownloadImage(url).Result;
        if (data != null)
        {
            var checkImage = data != null ? Image.FromStream(new MemoryStream(data)) : null;
            byte[] resized = ResizedImage(data, checkImage.Width, checkImage.Height);
            return data.LongLength > resized.LongLength ? resized : data;
        }
        else
        {
            return null;
        }
    }

    private static byte[] ResizedImage(byte[] data, int width, int height)
    {
        byte[] resized = Helpers.ResizeImage(data, width, height);
        return resized;
    }

    #endregion

    public static bool FolderContainsInfo(string path) => FileUtil.GetFiles(path, Constants.MOVIE_DATA, SearchOption.AllDirectories).Any();

    public static string CleanSQL(string text) => text.Replace("'", "''");
}
