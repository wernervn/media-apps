using System.Diagnostics.CodeAnalysis;
using static MediaApps.Series.Core.Constants;

namespace MediaApps.Series.Core.Mede8er;

[SuppressMessage("csharpsquid", "S101")]
public static class Mede8erHelper
{
    public static void SetItemWatched(string item)
    {
        var watchedFile = $"{item}.t";
        using var fs = File.Create(watchedFile);
    }

    public static void SetFolderWatched(string folder)
    {
        var videoFiles = VIDEO_EXTENSIONS.SelectMany(ext => Directory.EnumerateFiles(folder, ext)).ToList();
        videoFiles.ForEach(SetItemWatched);
    }
}
