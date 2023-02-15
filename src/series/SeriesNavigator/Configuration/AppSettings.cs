using System.Text.Json.Serialization;

namespace SeriesNavigator.Configuration;

public class AppSettings
{
    [JsonPropertyName("App")]
    public AppConfiguration AppConfiguration { get; set; } = new();
}
