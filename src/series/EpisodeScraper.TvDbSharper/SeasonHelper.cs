using MediaApps.Series.Core;
using MediaApps.Series.Core.Mede8er;
using MediaApps.Series.Core.Models;
using MediaApps.Series.Core.Rename;
using WVN.IO.Helpers;

namespace EpisodeScraper.TvDbSharper;

public static class SeasonHelper
{
    public static async Task GetEpisodeMetadata(TvDbWrapper api, string seasonPath)
    {
        var parent = new DirectoryInfo(seasonPath).Parent;
        var seriesId = SeriesIOHelper.GetSeriesIdFromFile(parent.FullName);
        await GetEpisodeMetadata(api, seriesId, seasonPath);
    }

    public static async Task GetEpisodeMetadata(TvDbWrapper api, string seriesId, string seasonPath)
    {
        var fullRec = await api.GetSeriesFullRecord(seriesId);

        var seasonName = new DirectoryInfo(seasonPath).Name;
        var seasonNo = seasonName.Split(" ".ToCharArray())[1];
        var banners = await api.GetArtwork(fullRec.Series.Id, BannerType.season);

        await GetEpisodeMetadata(api, fullRec, seasonPath, banners, seasonNo);
    }

    public static async Task GetEpisodeMetadata(TvDbWrapper api, SeriesFull fullRec, string seasonPath, IEnumerable<Banner> banners, string seasonNo)
    {
        var thumbs = GetExistingEpisodeThumbs(seasonPath);
        var bannerImages = api.BannerImages(banners, BannerType.season);

        var seasonEpisodes = fullRec.Episodes.Where(ep => ep.CombinedSeason == seasonNo);

        if (!seasonEpisodes.Any())
        {
            return;
        }

        await WriteEpisodeData(thumbs, seasonEpisodes, api, fullRec, bannerImages);

        //get season thumb
        var seasonThumb = Path.Combine(seasonPath, Constants.SERIES_SEASON_THUMB);
        if (File.Exists(seasonThumb) && new FileInfo(seasonThumb).Length == 0) //if the save operation failed previously, the file would have been created without content
        {
            File.Delete(seasonThumb);
        }

        if (!File.Exists(seasonPath))
        {
            var epi = seasonEpisodes.First();
            var seasonBanner = banners.ToList().Find(banner => banner.BannerType == "season" && banner.Season == epi.CombinedSeason);
            if (seasonBanner is not null)
            {
                var img = await api.GetImage(seasonBanner.BannerPath) ?? await api.GetImage(seasonBanner.ThumbnailPath);

                if (img is not null)
                {
                    var reduced = ImageHelper.ReduceImageSize(img);
                    await File.WriteAllBytesAsync(seasonThumb, reduced);
                }
            }
        }

        //get View.xml
        var viewFile = Path.Combine(seasonPath, Constants.SEASON_VIEW);
        if (!File.Exists(viewFile))
        {
            await api.WriteSeasonViewXml(viewFile);
        }
    }

    private static async Task WriteEpisodeData(Dictionary<string, string> thumbs, IEnumerable<Episode> seasonEpisodes, TvDbWrapper api, SeriesFull fullRec, IEnumerable<string> bannerImages)
    {
        int bytesSaved = 0;
        var tasks = new List<Task>();
        foreach (var key in thumbs.Keys)
        {
            var task = Task.Run(async () =>
            {
                //key sample : C:\BT\Series\Ray Donovan\Season 5\Ray Donovan.S05E06.Shelley Duvall.mkv
                var episodeNo = SeriesIOHelper.GetSeasonEpisodeFromName(key);
                //resolve episode from seasonEpisodes
                var episode = seasonEpisodes.First(ep => ep.EpisodeNumber == episodeNo);
                var episodeFileName = episode.FileName;

                // get episode thumbnails
                if (thumbs[key]?.Length == 0 && !string.IsNullOrEmpty(episodeFileName))
                {
                    //get banner TVDB filename
                    //get image using filename
                    var data = await api.GetImage(episodeFileName);
                    if (data?.Length > 0)
                    {
                        var reduced = ImageHelper.ReduceImageSize(data);

                        if (reduced?.Length > 0)
                        {
                            //save image using episode name
                            Interlocked.Add(ref bytesSaved, data.Length - reduced.Length);
                            var newExtension = Path.GetExtension(episodeFileName);
                            var imgFile = Path.ChangeExtension(key, newExtension);
                            await File.WriteAllBytesAsync(imgFile, reduced);
                        }
                    }
                }

                // get episode xml content
                var xmlPath = Path.ChangeExtension(key, Constants.CONTENT_EXTENSION);
                if (!File.Exists(xmlPath))
                {
                    var xml = GetEpisodeXml(fullRec.Series, episode, bannerImages);
                    await File.WriteAllTextAsync(xmlPath, xml);
                }
            });
            tasks.Add(task);
        }

        for (int i = 0; i < tasks.Count; i += 10)
        {
            var batch = tasks.Skip(i).Take(10).ToArray();
            await Task.WhenAll(batch);
        }

        System.Diagnostics.Debug.WriteLine($"Total bytes saved on episode images: {bytesSaved}");
    }

    public static async Task<IEnumerable<Episode>> GetEpisodes(TvDbWrapper api, string seasonPath)
    {
        var parent = new DirectoryInfo(seasonPath).Parent;
        var seriesId = SeriesIOHelper.GetSeriesIdFromFile(parent.FullName);
        var fullRec = await api.GetSeriesFullRecord(seriesId);

        var seasonName = new DirectoryInfo(seasonPath).Name;
        var seasonNo = seasonName.Split(" ".ToCharArray())[1];

        var seasonEpisodes = fullRec.Episodes.Where(ep => ep.CombinedSeason == seasonNo);
        return seasonEpisodes;
    }

    public static Dictionary<string, string> GetExistingEpisodeThumbs(string seasonPath)
    {
        var episodes = GetEpisodeFiles(seasonPath).ToDictionary(k => k, v => string.Empty);
        var keys = episodes.Keys.ToList();
        foreach (var episode in keys)
        {
            var thumbPath = Path.ChangeExtension(episode, Constants.IMAGE_EXTENSION);
            if (File.Exists(thumbPath))
            {
                var fi = new FileInfo(thumbPath);
                if (fi.Length == 0)
                {
                    fi.Delete();
                }
                else
                {
                    episodes[episode] = thumbPath;
                }
            }
        }
        return episodes;
    }

    public static Dictionary<string, string> GetExistingEpisodeXml(string seasonPath)
    {
        var episodes = GetEpisodeFiles(seasonPath).ToDictionary(v => v, k => string.Empty);
        var keys = episodes.Keys.ToList();
        foreach (var episode in keys)
        {
            var dataPath = Path.ChangeExtension(episode, Constants.CONTENT_EXTENSION);
            if (File.Exists(dataPath))
            {
                var fi = new FileInfo(dataPath);
                if (fi.Length == 0)
                {
                    fi.Delete();
                }
                else
                {
                    episodes[episode] = dataPath;
                }
            }
        }
        return episodes;
    }

    private static string GetEpisodeXml(SeriesBase series, Episode episode, IEnumerable<string> bannerImages)
    {
        var metadata = new EpisodeMetadata();

        var m = new Movie
        {
            Title = episode.EpisodeName,
            Season = episode.SeasonNumber ?? 0,
            Episode = episode.EpisodeNumber ?? 0,
            Year = episode.FirstAired.Year,
            Rating = episode.Rating,
            Plot = series.Overview,
            EpisodePlot = episode.Overview,
            MPAA = series.ContentRating,
            Runtime = series.Runtime ?? 0,
            genres = SeriesIOHelper.ToArray(series.Genre),
            Director = episode.Director,
            Credits = episode.Writer
        };
        var cast = series.Actors.Length > 0
            ? series.Actors
            : episode.GuestStars;
        m.cast = SeriesIOHelper.ToArray(cast);
        m.image = [.. bannerImages];

        metadata.Movie = m;
        return metadata.AsXml();
    }

    public static IEnumerable<string> GetEpisodeFiles(string path)
        => IOHelper.GetFiles(path, Constants.VIDEO_EXTENSIONS, SearchOption.TopDirectoryOnly);

    public static IEnumerable<string> GetSubtitleFiles(string path)
        => IOHelper.GetFiles(path, Constants.SUBTITLES, SearchOption.TopDirectoryOnly);

    public static async Task RenameFiles(TvDbWrapper api, string seriesName, string seasonPath)
    {
        var episodes = await GetEpisodes(api, seasonPath);

        //var tasks = new List<Task>
        //{
        //    new(async () =>
        //{
        //    var files = GetEpisodeFiles(seasonPath).Select(f => new FileInfo(f).Name);
        //    RenameEpisodeFiles(seriesName, seasonPath, episodes, files);
        //}),
        //    new(async () =>
        //    {
        //        var subtitles = GetSubtitleFiles(seasonPath);
        //        RenameEpisodeFiles(seriesName, seasonPath, episodes, subtitles);
        //    })
        //};
        //await Task.WhenAll(tasks);

        var files = GetEpisodeFiles(seasonPath).Select(f => new FileInfo(f).Name);
        var subtitles = GetSubtitleFiles(seasonPath);

        RenameEpisodeFiles(seriesName, seasonPath, episodes, files);
        RenameEpisodeFiles(seriesName, seasonPath, episodes, subtitles);
    }

    public static void RenameEpisodeFiles(string seriesName, string seasonPath, IEnumerable<Episode> episodes, IEnumerable<string> files)
    {
        var renamer = new RenameContainer(seriesName, seasonPath, episodes, files);
        renamer.RenameFiles();
    }
}
