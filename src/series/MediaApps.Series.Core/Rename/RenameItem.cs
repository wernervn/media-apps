namespace MediaApps.Series.Core.Rename;

public class RenameItem(string episodeName, string foundFile)
{
    public string EpisodeName { get; set; } = episodeName;
    public string FoundFile { get; set; } = foundFile;

    public bool MustRename
        => FoundFile is not null && EpisodeName != Path.GetFileNameWithoutExtension(FoundFile);

    public string NewName
        => MustRename ? string.Concat(EpisodeName, Path.GetExtension(FoundFile)) : string.Empty;
}
