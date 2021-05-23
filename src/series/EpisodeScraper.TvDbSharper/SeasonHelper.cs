using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MediaApps.Series.Core;
using MediaApps.Series.Core.Mede8er;
using MediaApps.Series.Core.Models;
using MediaApps.Series.Core.Rename;
using MediaApps.Common.Helpers;
using Core = MediaApps.Series.Core;
using System.Diagnostics;

namespace EpisodeScraper.TvDbSharper
{
    public static partial class SeasonHelper
    {
        public static async Task GetEpisodeMetadata(TvDbWrapper api, string seasonPath)
        {
            var parent = new DirectoryInfo(seasonPath).Parent;
            var seriesId = Core.SeriesHelper.GetSeriesIdFromFile(parent.FullName);
            await GetEpisodeMetadata(api, seriesId, seasonPath).ConfigureAwait(false);
        }

        public static async Task GetEpisodeMetadata(TvDbWrapper api, string seriesId, string seasonPath)
        {
            var fullRec = await api.GetSeriesFullRecord(seriesId).ConfigureAwait(false);

            var seasonName = new DirectoryInfo(seasonPath).Name;
            var seasonNo = seasonName.Split(" ".ToCharArray())[1];
            var banners = await api.GetArtwork(fullRec.Series.Id, BannerType.season).ConfigureAwait(false);

            await GetEpisodeMetadata(api, fullRec, seasonPath, banners, seasonNo).ConfigureAwait(false);
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

            var bytesSaved = 0;
            foreach (var key in thumbs.Keys)
            {
                //key sample : C:\BT\Series\Ray Donovan\Season 5\Ray Donovan.S05E06.Shelley Duvall.mkv
                var episodeNo = Core.SeriesHelper.GetSeasonEpisodeFromName(key);
                //resolve episode from seasonEpisodes
                var episode = seasonEpisodes.First(ep => ep.EpisodeNumber == episodeNo);
                var episodeFileName = episode.FileName;

                // thumbnails
                if (thumbs[key]?.Length == 0 && !string.IsNullOrEmpty(episodeFileName))
                {
                    //get banner TVDB filename
                    //get image using filename
                    var data = await api.GetImage(episodeFileName).ConfigureAwait(false);
                    if (data?.Length > 0)
                    {
                        var reduced = ImageHelper.ReduceImageSize(data);

                        if (reduced?.Length > 0)
                        {
                            bytesSaved += data.Length - reduced.Length;
                            //save image using episode name
                            var extension = Path.GetExtension(key);
                            var newExtension = Path.GetExtension(episodeFileName);
                            var imgFile = Path.ChangeExtension(key, newExtension);
                            File.WriteAllBytes(imgFile, reduced);
                        }
                    }
                }

                // xml content
                var xmlPath = Path.ChangeExtension(key, Constants.CONTENT_EXTENSION);
                if (!File.Exists(xmlPath))
                {
                    var xml = GetEpisodeXml(fullRec.Series, episode, bannerImages);
                    File.WriteAllText(xmlPath, xml);
                }
            }
            Debug.WriteLine($"Total bytes saved on episode images: {bytesSaved}");

            //get season thumb
            var seasonThumb = Path.Combine(seasonPath, Constants.SERIES_SEASON_THUMB);
            if (File.Exists(seasonThumb) && new FileInfo(seasonThumb).Length == 0)
            {
                File.Delete(seasonThumb);
            }

            if (!File.Exists(seasonPath))
            {
                var epi = seasonEpisodes.First();
                var seasonBanner = banners.ToList().Find(banner => banner.BannerType == "season" && banner.Season == epi.CombinedSeason);
                if (seasonBanner != null)
                {
                    var img = await api.GetImage(seasonBanner.BannerPath).ConfigureAwait(false) ?? await api.GetImage(seasonBanner.ThumbnailPath).ConfigureAwait(false);

                    if (img != null)
                    {
                        var reduced = ImageHelper.ReduceImageSize(img);
                        File.WriteAllBytes(seasonThumb, reduced);
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

        public static async Task<IEnumerable<Episode>> GetEpisodes(TvDbWrapper api, string seasonPath)
        {
            var parent = new DirectoryInfo(seasonPath).Parent;
            var series = parent.Name;
            var seriesId = Core.SeriesHelper.GetSeriesIdFromFile(parent.FullName);
            var fullRec = await api.GetSeriesFullRecord(seriesId).ConfigureAwait(false);

            var seasonName = new DirectoryInfo(seasonPath).Name;
            var seasonNo = seasonName.Split(" ".ToCharArray())[1];

            var seasonEpisodes = fullRec.Episodes.Where(ep => ep.CombinedSeason == seasonNo);
            return seasonEpisodes.ToList();
        }

        public static Dictionary<string, string> GetExistingEpisodeThumbs(string seasonPath)
        {
            var episodes = GetEpisodes(seasonPath).ToDictionary(k => k, v => string.Empty);
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
            var episodes = GetEpisodes(seasonPath).ToDictionary(v => v, k => string.Empty);
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
                Season = episode.SeasonNumber.Value,
                Episode = episode.EpisodeNumber.Value,
                Year = episode.FirstAired.Year,
                Rating = episode.Rating,
                Plot = series.Overview,
                EpisodePlot = episode.Overview,
                MPAA = series.ContentRating,
                Runtime = series.Runtime.Value,
                genres = Core.SeriesHelper.ToArray(series.Genre),
                Director = episode.Director,
                Credits = episode.Writer
            };
            var cast = series.Actors.Length > 0
                ? series.Actors
                : episode.GuestStars;
            m.cast = Core.SeriesHelper.ToArray(cast);
            m.image = bannerImages.ToArray();

            metadata.Movie = m;
            return metadata.AsXml();
        }

        private static string CData(string text)
            => $"<![CDATA[{text}]]>";

        public static IEnumerable<string> GetEpisodes(string path)
            => IOHelper.GetFiles(path, Constants.VIDEO_EXTENSIONS, SearchOption.TopDirectoryOnly).ToList();

        public static IEnumerable<string> GetSubtitles(string path)
            => IOHelper.GetFiles(path, Constants.SUBTITLES, SearchOption.TopDirectoryOnly).ToList();

        public static async Task RenameFiles(TvDbWrapper api, string seriesName, string seasonPath)
        {
            var episodes = await GetEpisodes(api, seasonPath).ConfigureAwait(false);
            var files = GetEpisodes(seasonPath).Select(f => new FileInfo(f).Name);
            var subtitles = GetSubtitles(seasonPath);

            RenameEpisodeFiles(seriesName, seasonPath, episodes, files);
            RenameEpisodeFiles(seriesName, seasonPath, episodes, subtitles);
        }

        public static void RenameEpisodeFiles(string seriesName, string seasonPath, IEnumerable<Episode> episodes, IEnumerable<string> files)
        {
            var renamer = new RenameContainer(seriesName, seasonPath, episodes, files);
            renamer.RenameFiles();
        }
    }
}
