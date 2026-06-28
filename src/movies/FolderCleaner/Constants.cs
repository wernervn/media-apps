namespace FolderCleaner;

internal static class Constants
{
    public static readonly List<string> MOVIE_FILES = [".avi", ".mp4", ".mkv"];
    public static readonly List<string> RELATED_FILES = [".idx", ".sub", ".srt", ".xml"];
    public static readonly List<string> WATCHED_FILES = [".t"];
    public static readonly List<string> RENAME_FILES = [.. MOVIE_FILES, .. RELATED_FILES, .. WATCHED_FILES];
    //TODO: also cater for just moving these files
    public static readonly List<string> ONLY_MOVE_FILES = [".jpg", ".jpeg", ".png"];
}
