using MediaApps.Series.Core.Models;
using static WVN.IO.Helpers.IOHelper;

//TODO: handle double episodes

namespace MediaApps.Series.Core.Rename;

public class RenameContainer
{
    private const string NAME = "{0}.{1}.{2}";
    private const string KEY = "S{0:D2}E{1:D2}";
    private const string DOUBLE_KEY = "S{0:D2}E{1:D2}_{2:D2}";

    private RenameItems _renameItems;

    public RenameContainer(string seriesName, string folder, IEnumerable<Episode> episodes, IEnumerable<string> files)
    {
        SeriesName = seriesName;
        Folder = folder;
        Episodes = episodes.ToList();
        FoundFiles = files.ToList();

        LoadEpisodes();
    }

    private string SeriesName { get; }
    private string Folder { get; }
    private List<Episode> Episodes { get; }
    private List<string> FoundFiles { get; }

    public void RenameFiles()
    {
        var selected = _renameItems.Where(i => i.MustRename).ToList();
        selected.ForEach(RenameFile);
    }

    private void RenameFile(RenameItem item)
    {
        if (!item.MustRename)
        {
            return;
        }

        var source = Path.Combine(Folder, item.FoundFile);
        var destination = Path.Combine(Folder, item.NewName);
        if (source.Equals(destination, StringComparison.OrdinalIgnoreCase))
        {
            return;
        }
        if (File.Exists(destination))
        {
            File.Delete(destination);
        }
        File.Move(source, destination);
    }

    private void LoadEpisodes()
    {
        _renameItems = new RenameItems();
        Episodes.ForEach(LoadEpisode);
    }

    private void LoadEpisode(Episode episode)
    {
        //TODO: cater for double episodes e.g. S01E01_02
        var episodeNumber = episode.EpisodeNumber ?? 0;
        var key = string.Format(KEY, episode.SeasonNumber, episodeNumber);
        var episodeName = CleanFileName(string.Format(NAME, SeriesName, key, episode.EpisodeName));
        var foundFiles = FoundFiles.Where(f => f.Contains(key, StringComparison.OrdinalIgnoreCase)).Select(foundFile => new RenameItem(episodeName, foundFile));

        if (foundFiles.Any())
        {
            _renameItems.AddRange(foundFiles);
        }
    }
}
