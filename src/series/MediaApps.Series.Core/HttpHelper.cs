using System;
using System.Net;
using System.Threading.Tasks;

namespace MediaApps.Series.Core
{
    public static class HttpHelper
    {
        public async static Task<byte[]> DownloadDataAsync(string imageUrl)
        {
            byte[] data = null;

            try
            {
                using var client = new WebClient();
                data = await client.DownloadDataTaskAsync(imageUrl).ConfigureAwait(false);
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
    }
}
