using WVN.WinForms;

namespace FolderCleaner.Configuration;
public class AppConfiguration
{
    public string LastPath { get; set; }
    public int FoldersWidth { get; set; }
    public int DeleteItemsHeight { get; set; }
    public List<string> IgnoreList { get; set; } = DefaultIgnoreList;

    public WindowState WindowState { get; set; } = new WindowState { Location = new(0, 0), Size = new(0, 0) };

    private static List<string> DefaultIgnoreList
        => new() { "WWW.YIFY-TORRENTS.COM.jpg", "ETRG.mp4", "sample.avi", "sample.mp4", "screencaps.jpeg", "sample.mkv", "WWW.YTS.RE.jpg", "WWW.YTS.TO.jpg", "WWW.YTS.AG.jpg", "WWW.YTS.AM.jpg", "WWW.YTS.LT.jpg", "www.YTS.LT.jpg" };
}
