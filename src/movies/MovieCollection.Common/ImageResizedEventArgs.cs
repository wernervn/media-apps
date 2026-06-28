namespace MovieCollection.Common;

public class ImageResizedEventArgs(string imageName, long originalSize, long newSize) : EventArgs
{
    public string ImageName { get; set; } = imageName;
    public long OriginalSize { get; set; } = originalSize;
    public long NewSize { get; set; } = newSize;
}
