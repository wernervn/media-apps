using System.IO;

namespace MediaApps.Series.Core.Rename
{
    public class RenameItem
    {
        public RenameItem(string episodeName, string foundFile)
        {
            EpisodeName = episodeName;
            FoundFile = foundFile;
        }

        public string EpisodeName { get; set; }
        public string FoundFile { get; set; }

        public bool MustRename
            => FoundFile != null && EpisodeName != Path.GetFileNameWithoutExtension(FoundFile);

        public string NewName
            => MustRename ? string.Concat(EpisodeName, Path.GetExtension(FoundFile)) : string.Empty;
    }
}
