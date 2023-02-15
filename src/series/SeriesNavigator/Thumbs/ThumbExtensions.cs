namespace SeriesNavigator.Thumbs;

public static class ThumbExtensions
{
    public static void HideIt(this ThumbContainer thumbs)
    {
        thumbs.Visible = false;
        thumbs.Clear();
        thumbs.SendToBack();
        thumbs.Dock = DockStyle.None;
    }

    public static void ShowIt(this ThumbContainer thumbs)
    {
        thumbs.Visible = true;
        thumbs.Dock = DockStyle.Fill;
        thumbs.BringToFront();
    }

    public static string WatchedPath(this ThumbImage thumb)
    {
        return string.Concat(thumb.ItemPath, ".t");
    }
}
