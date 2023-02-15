using static MediaApps.Series.Core.Constants;

namespace MediaApps.Series.Core.Mede8er;

public static class Mede8erHelper
{
    public static void SetItemWatched(string item)
    {
        var watchedFile = string.Concat(item, ".t");
        using var fs = File.Create(watchedFile);
    }

    public static void SetFolderWatched(string folder)
    {
        var videoFiles = VIDEO_EXTENSIONS.SelectMany(ext => Directory.EnumerateFiles(folder, ext)).ToList();
        videoFiles.ForEach(SetItemWatched);
    }
}
