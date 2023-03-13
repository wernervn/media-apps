namespace MovieCollection.Common;

public static class Constants
{
    public static readonly string MOVIE_DATA = "movie.tmdb";
    public static readonly string FOLDER_KEY = "Folder2";
    public static readonly string FOLDER_INFO_EXIST = "Add";

    public static List<string> IMAGE_VALUES { get; } = new() { ".jpg", ".jpeg", ".bmp", ".ico", ".png", ".gif" };
    public static List<string> MOVIE_VALUES { get; } = new() { "*.avi", "*.wmv", "*.mkv", "*.ifo", "*.vob", "*.mp4" };
}
