using System.Drawing;

namespace EpisodeScraper.Configuration
{
    public class AppConfiguration
    {
        public string SeriesFolder { get; set; }
        public string ApiKey { get; set; }

        public Size LastSize { get; set; }

        public Point LastLocation { get; set; }

    }
}
