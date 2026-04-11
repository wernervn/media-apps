using MediaApps.Series.Core;
using MediaApps.Series.Core.Models;
using WVN.TvDb.API.Client;
using Dto = WVN.TvDb.API.Models;
using Models = MediaApps.Series.Core.Models;

namespace EpisodeScraper.TvDbSharper;

public partial class TvDbWrapper
{
    private readonly TvDbClient _client;

    public TvDbWrapper(string apiKey)
    {
        _client = new TvDbClient();
        _client.AuthenticateAsync(apiKey);
    }

    #region Get series
    public async Task<IEnumerable<SearchResultItem>> SearchSeries(string criteria)
    {
        var found = (await _client.SearchSeriesByNameAsync(criteria)/**/).Data;
        return found.Select(Map).ToList();
    }

    public async Task<SeriesBase> GetSeriesBaseRecord(int seriesId)
    {
        var baseRec = (await _client.GetSeriesAsync(seriesId)).Data;
        var series = Map(baseRec);

        try
        {
            var actorResponse = await _client.GetActorsAsync(seriesId);
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
        => await GetSeriesFullRecord(int.Parse(seriesId));

    public async Task<SeriesFull> GetSeriesFullRecord(int seriesId)
    {
        var baseRec = await GetSeriesBaseRecord(seriesId);
        var allEpisodes = await _client.GetAllEpisodesAsync(seriesId);
        var episodeList = allEpisodes.Select(Map).ToList();
        return new SeriesFull { Series = baseRec, Episodes = episodeList };
    }

    #endregion

    #region Get banners
    public async Task<IEnumerable<Banner>> GetSeriesBanners(string seriesId)
        => await GetSeriesBanners(int.Parse(seriesId));

    public async Task<IEnumerable<Banner>> GetSeriesBanners(int seriesId)
    {
        try
        {
            var banners = (await _client.GetImagesAsync(seriesId, GetImageQuery(BannerType.season))).Data;
            return banners.Select(Map);
        }
        catch (Exception)
        {
            return [];
        }
    }

    public async Task<IEnumerable<Banner>> GetArtwork(string seriesId, BannerType bannerType)
        => await GetArtwork(int.Parse(seriesId), bannerType);

    public async Task<IEnumerable<Banner>> GetArtwork(int seriesId, BannerType bannerType)
    {
        try
        {
            var images = (await _client.GetImagesAsync(seriesId, GetImageQuery(bannerType))).Data;
            return images.Select(Map);
        }
        catch (Exception)
        {
            return [];
        }
    }

    public async Task<IEnumerable<string>> GetArtworkPaths(int seriesId, BannerType bannerType)
    {
        var artwork = await GetArtwork(seriesId, bannerType);
        return artwork.Select(b => ArtworkClient.BuildImageUrl(b.BannerPath));
    }

    private Dto.Series.ImagesQuery GetImageQuery(BannerType bannerType)
    {
        var keyType = bannerType switch
        {
            BannerType.fanart => Dto.Series.KeyType.Fanart,
            BannerType.episode => Dto.Series.KeyType.Season,
            BannerType.poster => Dto.Series.KeyType.Poster,
            BannerType.season => Dto.Series.KeyType.Season,
            BannerType.series => Dto.Series.KeyType.Series,
            _ => Dto.Series.KeyType.Season,
        };
        return new() { KeyType = keyType };
    }

    #endregion

    #region Get Actors
    public async Task<IEnumerable<Models.Actor>> GetSeriesActors(string seriesId)
=> await GetSeriesActors(int.Parse(seriesId));

    public async Task<IEnumerable<Models.Actor>> GetSeriesActors(int seriesId)
    {
        //await Authenticate()
        var actors = (await _client.GetActorsAsync(seriesId)).Data;
        return actors.Select(Map).ToList();
    }

    #endregion

    public async Task<Episode> GetEpisode(string episodeId)
        => await GetEpisode(int.Parse(episodeId));

    public async Task<Episode> GetEpisode(int episodeId)
    {
        var episode = (await _client.GetEpisodeAsync(episodeId)).Data;
        return Map(episode);
    }

    public async Task<Episode> GetSeriesEpisode(string seriesId, string seasonNo, string episodeNo)
        => await GetSeriesEpisode(int.Parse(seriesId), int.Parse(seasonNo), int.Parse(episodeNo));

    public async Task<Episode> GetSeriesEpisode(int seriesId, int seasonNo, int episodeNo)
        => (await SearchEpisodes(seriesId, new Dto.Series.EpisodeQuery { AiredSeason = seasonNo, AiredEpisode = episodeNo })).SingleOrDefault();

    private async Task<IEnumerable<Episode>> SearchEpisodes(int seriesId, Dto.Series.EpisodeQuery query)
    {
        var records = (await _client.GetEpisodesAsync(seriesId, page: 1, query)).Data;
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
        => await ArtworkClient.DownloadDataAsync(url);

    public async Task<byte[]> GetImage(string filename)
        => await GetImageByUrl(filename);
    #endregion
}
