using System.Text.Json.Serialization;

namespace FolderCleaner.Configuration;

public class AppSettings
{
    [JsonPropertyName("App")]
    public AppConfiguration AppConfiguration { get; set; }
}
