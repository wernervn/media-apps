using System.Text.Json.Serialization;

namespace EpisodeScraper.Configuration;

public class AppSettings
{
    [JsonPropertyName("App")]
    public AppConfiguration AppConfiguration { get; set; }
}
