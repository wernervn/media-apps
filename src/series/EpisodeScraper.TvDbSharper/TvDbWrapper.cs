using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaApps.Series.Core;
using MediaApps.Series.Core.Models;
using WVN.TvDb.API.Client;
using Dto = WVN.TvDb.API.Models;
using Models = MediaApps.Series.Core.Models;

namespace EpisodeScraper.TvDbSharper
{
    public partial class TvDbWrapper
    {
        private readonly TvDbClient _client;
        private readonly string _apiKey;

        public TvDbWrapper(string apiKey)
        {
            _client = new TvDbClient(apiKey);
            _client.AuthenticateAsync(apiKey);
            _apiKey = apiKey;
        }

        #region Get series
        public async Task<IEnumerable<SearchResultItem>> SearchSeries(string criteria)
        {
            var found = (await _client.SearchSeriesByNameAsync(criteria).ConfigureAwait(false)/*.ConfigureAwait(false)*/).Data;
            return found.Select(Map).ToList();
        }

        public async Task<SeriesBase> GetSeriesBaseRecord(int seriesId)
        {
            var baseRec = (await _client.GetSeriesAsync(seriesId).ConfigureAwait(false)).Data;
            var series = Map(baseRec);

            try
            {
                var actorResponse = await _client.GetActorsAsync(seriesId).ConfigureAwait(false);
                var actors = actorResponse.Data;
                var actorNames = actors.Select(actor => actor.Name);
                var actorList = string.Join("|", actorNames);
                series.Actors = actorList;
            }
            catch (Exception)
            {
                series.Actors = string.Empty;
            }
            return series;
        }

        public async Task<SeriesFull> GetSeriesFullRecord(string seriesId)
            => await GetSeriesFullRecord(int.Parse(seriesId)).ConfigureAwait(false);

        public async Task<SeriesFull> GetSeriesFullRecord(int seriesId)
        {
            var baseRec = await GetSeriesBaseRecord(seriesId).ConfigureAwait(false);
            var allEpisodes = await _client.GetAllEpisodesAsync(seriesId).ConfigureAwait(false);
            var episodeList = allEpisodes.Select(Map).ToList();
            return new SeriesFull { Series = baseRec, Episodes = episodeList };
        }

        #endregion

        #region Get banners
        public async Task<IEnumerable<Banner>> GetSeriesBanners(string seriesId)
            => await GetSeriesBanners(int.Parse(seriesId)).ConfigureAwait(false);

        public async Task<IEnumerable<Banner>> GetSeriesBanners(int seriesId)
        {
            try
            {
                var banners = (await _client.GetImagesAsync(seriesId, GetImageQuery(BannerType.season)).ConfigureAwait(false)).Data;
                return banners.Select(Map);
            }
            catch (Exception)
            {
                return Enumerable.Empty<Banner>();
            }
        }

        public async Task<IEnumerable<Banner>> GetArtwork(string seriesId, BannerType bannerType)
            => await GetArtwork(int.Parse(seriesId), bannerType).ConfigureAwait(false);

        public async Task<IEnumerable<Banner>> GetArtwork(int seriesId, BannerType bannerType)
        {
            try
            {
                var images = (await _client.GetImagesAsync(seriesId, GetImageQuery(bannerType)).ConfigureAwait(false)).Data;
                return images.Select(Map);
            }
            catch (Exception)
            {
                return Enumerable.Empty<Banner>();
            }
        }

        public async Task<IEnumerable<string>> GetArtworkPaths(int seriesId, BannerType bannerType)
        {
            var artwork = await GetArtwork(seriesId, bannerType).ConfigureAwait(false);
            return artwork.Select(b => ArtworkClient.BuildImageUrl(b.BannerPath));
        }

        private Dto.Series.ImagesQuery GetImageQuery(BannerType bannerType)
        {
            Dto.Series.KeyType keyType;
            switch (bannerType)
            {
                case BannerType.fanart:
                    keyType = Dto.Series.KeyType.Fanart;
                    break;
                case BannerType.episode:
                    keyType = Dto.Series.KeyType.Season;
                    break;
                case BannerType.poster:
                    keyType = Dto.Series.KeyType.Poster;
                    break;
                case BannerType.season:
                    keyType = Dto.Series.KeyType.Season;
                    break;
                case BannerType.series:
                    keyType = Dto.Series.KeyType.Series;
                    break;
                default:
                    keyType = Dto.Series.KeyType.Season;
                    break;
            }
            return new() { KeyType = keyType };
        }

        #endregion

        #region Get Actors
        public async Task<IEnumerable<Models.Actor>> GetSeriesActors(string seriesId)
    => await GetSeriesActors(int.Parse(seriesId)).ConfigureAwait(false);

        public async Task<IEnumerable<Models.Actor>> GetSeriesActors(int seriesId)
        {
            //await Authenticate()
            var actors = (await _client.GetActorsAsync(seriesId).ConfigureAwait(false)).Data;
            return actors.Select(Map).ToList();
        }

        #endregion

        public async Task<Episode> GetEpisode(string episodeId)
            => await GetEpisode(int.Parse(episodeId)).ConfigureAwait(false);

        public async Task<Episode> GetEpisode(int episodeId)
        {
            var episode = (await _client.GetEpisodeAsync(episodeId).ConfigureAwait(false)).Data;
            return Map(episode);
        }

        public async Task<Episode> GetSeriesEpisode(string seriesId, string seasonNo, string episodeNo)
            => await GetSeriesEpisode(int.Parse(seriesId), int.Parse(seasonNo), int.Parse(episodeNo)).ConfigureAwait(false);

        public async Task<Episode> GetSeriesEpisode(int seriesId, int seasonNo, int episodeNo)
            => (await SearchEpisodes(seriesId, new Dto.Series.EpisodeQuery { AiredSeason = seasonNo, AiredEpisode = episodeNo }).ConfigureAwait(false)).SingleOrDefault();

        private async Task<IEnumerable<Episode>> SearchEpisodes(int seriesId, Dto.Series.EpisodeQuery query)
        {
            var records = (await _client.GetEpisodesAsync(seriesId, page: 1, query).ConfigureAwait(false)).Data;
            return records.Select(Map);
        }

        #region Banner utility
        public IEnumerable<string> BannerImages(IEnumerable<Banner> banners, BannerType preferredType = BannerType.all)
        {
            var bannerTypes = preferredType == BannerType.all ? banners : banners.ToList().FindAll(b => b.BannerType == preferredType.ToString());
            return bannerTypes.Select(b => ArtworkClient.BuildImageUrl(b.BannerPath));
        }

        #endregion

        #region Image downloads
        public async Task<byte[]> GetImageByUrl(string url)
            => await ArtworkClient.DownloadDataAsync(url).ConfigureAwait(false);

        public async Task<byte[]> GetImage(string filename)
            => await GetImageByUrl(filename).ConfigureAwait(false);
        #endregion
    }
}
