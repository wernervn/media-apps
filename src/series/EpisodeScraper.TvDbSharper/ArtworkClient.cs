using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace EpisodeScraper.TvDbSharper
{
    internal static class ArtworkClient
    {
        private const string ImagePrefix = "http://thetvdb.com/banners/";

        internal static string BuildImageUrl(string imagePath)
            => Path.Combine(ImagePrefix, imagePath);

        internal async static Task<byte[]> DownloadDataAsync(string imageUrl)
        {
            var url = imageUrl ?? throw new ArgumentNullException(nameof(imageUrl));
            if (!url.StartsWith(ImagePrefix))
            {
                url = BuildImageUrl(url);
            }

            byte[] img = null;
            try
            {
                using var client = new WebClient();
                img = await client.DownloadDataTaskAsync(url).ConfigureAwait(false);
            }
            catch (HttpListenerException ex)
            {
                Debug.WriteLine("Error accessing " + url + " - " + ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error accessing " + url + " - " + ex.Message);
            }
            return img;
        }
    }
}
