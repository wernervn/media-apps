﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MediaApps.Series.Core;
using MediaApps.Series.Core.Mede8er;
using MediaApps.Series.Core.Models;
using Core = MediaApps.Series.Core;

namespace EpisodeScraper.TvDbSharper
{
    public static class SeriesHelper
    {
        private static TvDbWrapper _api;

        public static async Task GetSeriesInfo(TvDbWrapper api, string seriesPath, string seriesId, bool includeSeasons = false)
        {
            _api = api;

            var fullRec = await api.GetSeriesFullRecord(seriesId);
            var banners = await api.GetSeriesBanners(fullRec.Series.Id);
            await SetSeriesData(api, seriesPath, fullRec, banners);

            //then season data
            if (includeSeasons)
            {
                foreach (var seasonPath in Directory.EnumerateDirectories(seriesPath))
                {
                    var seasonName = new DirectoryInfo(seasonPath).Name;
                    var seasonNo = seasonName.Split(" ".ToCharArray())[1];
                    await SeasonHelper.GetEpisodeMetadata(api, fullRec, seasonPath, banners, seasonNo);
                }
            }
        }

        public static async Task GetSeriesInfo(TvDbWrapper api, string seriesPath, bool includeSeasons = false)
        {
            //first get series data
            var seriesId = Core.SeriesHelper.GetSeriesIdFromFile(seriesPath);
            await GetSeriesInfo(api, seriesPath, seriesId, includeSeasons);
        }

        private static async Task SetSeriesData(TvDbWrapper api, string seriesPath, SeriesFull fullRec, IEnumerable<Banner> banners)
        {
            //get View.xml
            var viewFile = Path.Combine(seriesPath, Constants.SERIES_VIEW);
            if (!File.Exists(viewFile))
            {
                await api.WriteSeriesViewXml(viewFile);
            }

            //fanart image
            //var fanartImages = api.BannerImages(banners, BannerType.fanart).ToArray();
            var fanartImages = await api.GetArtworkPaths(fullRec.Series.Id, BannerType.fanart);
            var fanart = Path.Combine(seriesPath, "fanart.jpg");
            if (!File.Exists(fanart) && fanartImages.Any())
            {
                var image = await api.GetImageByUrl(fanartImages.First());
                image = ImageHelper.ResizeImage(image, 1920, 1080);
                File.WriteAllBytes(fanart, image);
            }

            //folder image
            var folderImages = api.BannerImages(banners, BannerType.poster).ToArray();
            var poster = Path.Combine(seriesPath, "folder.jpg");
            if (!File.Exists(poster) && folderImages.Length > 0)
            {
                var image = await api.GetImageByUrl(folderImages[0]);
                image = ImageHelper.ResizeImage(image, 157, 237);
                File.WriteAllBytes(poster, image);
            }

            //series xml
            var xmlPath = Path.Combine(seriesPath, Constants.SERIES_XML);
            if (!File.Exists(xmlPath))
            {
                var xml = GetSeriesXml(fullRec.Series);
                File.WriteAllText(xmlPath, xml);
            }
        }

        private static string GetSeriesXml(SeriesBase series)
        {
            var metadata = new SeriesMetadata(series);
            return metadata.AsXml();
        }
    }

}