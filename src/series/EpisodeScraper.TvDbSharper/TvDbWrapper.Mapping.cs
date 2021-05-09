using System;
using MediaApps.Series.Core.Models;
using WVN.SimpleMapper;
using WVN.TvDb.API.Models.Episode;
using WVN.TvDb.API.Models.Search;
using Dto = WVN.TvDb.API.Models;
using Models = MediaApps.Series.Core.Models;

namespace EpisodeScraper.TvDbSharper
{
    public partial class TvDbWrapper
    {
        private SearchResultItem Map(SeriesSearchResult item)
        {
            var mapper = new Mapper<SeriesSearchResult, SearchResultItem>(StringComparison.OrdinalIgnoreCase);
            mapper.AddMapping((s, d) => d.SeriesId = s.Id);
            return mapper.CreateMappedObject(item);
        }

        private SeriesBase Map(Dto.Series.Series series)
        {
            var mapper = new Mapper<Dto.Series.Series, SeriesBase>(StringComparison.OrdinalIgnoreCase);
            mapper.AddMapping((s, d) =>
            {
                d.ContentRating = s.Rating;
                d.Genre = s.Genre.Length > 0 ? s.Genre[0] : null;
                d.IMDB_ID = s.ImdbId;
                d.MPAA = s.Rating;
                if (DateTime.TryParse(s.FirstAired, out var firstAired))
                {
                    d.FirstAired = firstAired;
                }
                if (int.TryParse(s.Runtime, out var runtime))
                {
                    d.Runtime = runtime;
                }
                if (int.TryParse(s.SeriesId, out var seriesId))
                {
                    d.SeriesID = seriesId;
                }
            });
            return mapper.CreateMappedObject(series);
        }

        private Episode Map(EpisodeRecord episode)
        {
            var episodeMapper = new Mapper<EpisodeRecord, Episode>(StringComparison.OrdinalIgnoreCase);
            episodeMapper.AddMapping((s, d) =>
            {
                d.SeasonNumber = s.AiredSeason;
                d.CombinedEpisodeNumber = (s.AbsoluteNumber?.ToString());
                d.CombinedSeason = (s.AiredSeason?.ToString());
                d.Director = s.Directors.Length > 0 ? s.Directors[0] : null;
                d.EpisodeNumber = s.AiredEpisodeNumber;
                if (DateTime.TryParse(s.FirstAired, out var firstAired))
                {
                    d.FirstAired = firstAired;
                }
                d.GuestStars = string.Join(";", s.GuestStars);
                d.Rating = (double)(s.SiteRating ?? 0);
                d.RatingString = d.Rating.ToString();
                d.Writer = s.Writers.Length > 0 ? s.Writers[0] : null;
            });
            return episodeMapper.CreateMappedObject(episode);
        }

        private Banner Map(Dto.Series.Image banner)
        {
            var mapper = new Mapper<Dto.Series.Image, Banner>();
            mapper.AddMapping((s, d) =>
            {
                d.BannerPath = s.FileName;
                d.BannerType = s.KeyType;
                d.RatingString = s.RatingsInfo.Average?.ToString();
                d.ThumbnailPath = s.Thumbnail;
                d.Season = s.SubKey;
            });
            return mapper.CreateMappedObject(banner);
        }

        private Models.Actor Map(Dto.Series.Actor actor)
        {
            var mapper = new Mapper<Dto.Series.Actor, Models.Actor>();
            mapper.AddMapping((s, d) => d.SortOrder = s.SortOrder ?? 1);
            return mapper.CreateMappedObject(actor);
        }
    }
}
