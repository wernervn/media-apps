namespace MovieCollection.Common;

public static class Constants
{
    public static readonly string MOVIE_DATA = "movie.tmdb";
    public static readonly string FOLDER_KEY = "Folder2";
    public static readonly string FOLDER_INFO_EXIST = "Add";

    public static List<string> IMAGE_VALUES { get; } = [".jpg", ".jpeg", ".bmp", ".ico", ".png", ".gif"];
    public static List<string> MOVIE_VALUES { get; } = ["*.avi", "*.wmv", "*.mkv", "*.ifo", "*.vob", "*.mp4"];
    public static readonly List<string> SUBTITLE_FILES = [".idx", ".sub", ".srt", ".ass"];

    public const string Poster = nameof(Poster);
    public const string Backdrop = nameof(Backdrop);

    public const string DateFormat = "yyyy-MM-dd";
}
