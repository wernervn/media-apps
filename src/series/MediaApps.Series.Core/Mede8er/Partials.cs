using System;
using MediaApps.Series.Core.Models;
using MediaApps.Common.Extensions;

namespace MediaApps.Series.Core.Mede8er
{
    public partial class EpisodeMetadata
    {
        public string AsXml()
            => this.ToXml();
    }

    public partial class SeriesMetadata
    {
        public SeriesMetadata() { }

        public SeriesMetadata(SeriesBase series)
        {
            var s = new Series
            {
                Title = series.SeriesName,
                genres = SeriesHelper.ToArray(series.Genre),
                Premiered = series.FirstAired?.ToString(Constants.DATE_FMT),
                Year = series.FirstAired.HasValue ? series.FirstAired.Value.Year : DateTime.Today.Year,
                Rating = double.Parse(series.RatingString ?? "0") * 10,
                Status = series.Status,
                MPAA = series.MPAA,
                TvdbId = series.Id.ToString(),
                Runtime = series.Runtime.Value,
                Plot = series.Overview,
                cast = SeriesHelper.ToArray(series.Actors)
            };

            Series = s;
        }

        public string AsXml()
            => this.ToXml();
    }
}
