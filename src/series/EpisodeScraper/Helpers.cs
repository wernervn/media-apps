using System;
using System.Net;
using System.Threading.Tasks;

namespace EpisodeScraper
{
    public static class Helpers
    {
        private const long SIZE_KB = 1024;
        private const long SIZE_MB = SIZE_KB * SIZE_KB;
        private const long SIZE_GB = SIZE_MB * SIZE_KB;

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

        public async static Task<byte[]> DownloadImage(string imageUrl)
        {
            byte[] img = null;

            try
            {
                using (WebClient client = new WebClient())
                {
                    img = await client.DownloadDataTaskAsync(imageUrl);
                }
            }
            catch (HttpListenerException ex)
            {
                Console.WriteLine("Error accessing " + imageUrl + " - " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error accessing " + imageUrl + " - " + ex.Message);
            }
            return img;
        }
    }
}
