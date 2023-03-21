namespace FolderCleaner;

internal static class Constants
{
    public static readonly List<string> MOVIE_FILES = new() { ".avi", ".mp4", ".mkv" };
    public static readonly List<string> RELATED_FILES = new() { ".idx", ".sub", ".srt", ".xml" };
    public static readonly List<string> WATCHED_FILES = new() { ".t" };
    public static readonly List<string> RENAME_FILES = MOVIE_FILES.Concat(RELATED_FILES).Concat(WATCHED_FILES).ToList();
    //TODO: also cater for just moving these files
    public static readonly List<string> ONLY_MOVE_FILES = new() { ".jpg", ".jpeg", ".png" };
}
