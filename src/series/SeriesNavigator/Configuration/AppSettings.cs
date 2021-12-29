using Newtonsoft.Json;

namespace SeriesNavigator.Configuration;

public class AppSettings
{
    [JsonProperty("App")]
    public AppConfiguration AppConfiguration { get; set; }
}
