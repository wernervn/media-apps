using static MediaApps.Common.Helpers.HttpHelper;

namespace EpisodeScraper.TvDbSharper;

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

        return await DownloadBytes(url).ConfigureAwait(false);
    }
}
