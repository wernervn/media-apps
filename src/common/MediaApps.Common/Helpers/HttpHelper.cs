using System.Diagnostics;
using System.Net;

namespace MediaApps.Common.Helpers;

public static class HttpHelper
{
    public async static Task<byte[]> DownloadBytes(string imageUrl)
    {
        byte[] data = null;

        try
        {
            using var client = new HttpClient();
            data = await client.GetByteArrayAsync(imageUrl).ConfigureAwait(false);
        }
        catch (HttpListenerException ex)
        {
            DebugOutput("Error accessing " + imageUrl + " - " + ex.Message);
        }
        catch (Exception ex)
        {
            DebugOutput("Error accessing " + imageUrl + " - " + ex.Message);
        }
        return data;
    }

    private static void DebugOutput(string text)
    {
        Debug.WriteLine(text);
        Trace.WriteLine(text);
    }
}
