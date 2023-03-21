namespace MovieCollection.Common;

public class ImageResizedEventArgs : EventArgs
{
    public ImageResizedEventArgs(string imageName, long originalSize, long newSize)
    {
        ImageName = imageName;
        OriginalSize = originalSize;
        NewSize = newSize;
    }

    public string ImageName { get; set; }
    public long OriginalSize { get; set; }
    public long NewSize { get; set; }
}
