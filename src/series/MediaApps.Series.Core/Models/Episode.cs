using System;

namespace MediaApps.Series.Core.Models
{
    public class Episode
    {
        public string CombinedEpisodeNumber { get; set; }
        public string CombinedSeason { get; set; }
        public string EpisodeName { get; set; }
        public int? EpisodeNumber { get; set; }
        public string GuestStars { get; set; }
        public string ImdbId { get; set; }
        public string Overview { get; set; }
        public double Rating { get; set; }
        public string RatingString { get; set; }
        public int? SeasonNumber { get; set; }
        public int? SeasonId { get; set; }
        public int? SeriesId { get; set; }
        public string FileName { get; set; }
        public DateTime FirstAired { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
    }
}
