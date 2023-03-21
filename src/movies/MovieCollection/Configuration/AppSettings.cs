using System.Text.Json.Serialization;

namespace MovieCollection.Configuration;
public class AppSettings
{
    [JsonPropertyName("App")]
    public AppConfiguration AppConfiguration { get; set; }
}
