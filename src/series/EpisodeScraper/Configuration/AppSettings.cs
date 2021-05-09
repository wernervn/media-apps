using Newtonsoft.Json;

namespace EpisodeScraper.Configuration
{
    public class AppSettings
    {
        [JsonProperty("App")]
        public AppConfiguration AppConfiguration { get; set; }
    }
}
