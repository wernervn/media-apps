namespace SeriesNavigator.Thumbs;

public class ThumbImage
{
    public ThumbImage(string imagePath, string itemPath, int index, string description, SeriesView currentView)
        : this(GetImage(imagePath), itemPath, index, description, currentView) { }

    public ThumbImage(Image image, string itemPath, int index, string description, SeriesView currentView)
    {
        Image = image;
        ItemPath = itemPath;
        Index = index;
        Name = GetName();
        Description = description;
        CurrentView = currentView;
    }

    public Image Image { get; }
    public string ItemPath { get; }
    public int Index { get; }
    public string Name { get; }
    public string Description { get; }
    public SeriesView CurrentView { get; }

    private string GetName()
        => File.Exists(ItemPath) ? Path.GetFileName(ItemPath) : new DirectoryInfo(ItemPath).Name;

    private static Image GetImage(string fileName)
    {
        if (!File.Exists(fileName))
        {
            return ThumbsHelper.EmptyImage;
        }

        using var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.Asynchronous);
        return Image.FromStream(fs);
    }
}
