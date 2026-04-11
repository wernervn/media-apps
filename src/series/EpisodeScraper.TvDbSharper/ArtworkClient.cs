using static MediaApps.Common.Helpers.HttpHelper;

namespace EpisodeScraper.TvDbSharper;

internal static class ArtworkClient
{
    private const string ImagePrefix = "http://thetvdb.com/banners/";

    internal static string BuildImageUrl(string imagePath)
        => Path.Combine(ImagePrefix, imagePath);

    internal static async Task<byte[]> DownloadDataAsync(string imageUrl)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(imageUrl);

        if (!imageUrl.StartsWith(ImagePrefix))
        {
            imageUrl = BuildImageUrl(imageUrl);
        }

        return await DownloadBytes(imageUrl);
    }
}
