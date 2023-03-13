namespace MovieCollection.Common;

public class ImageResizedEventArgs : EventArgs
{
    public ImageResizedEventArgs(long originalSize, long newSize)
    {
        OriginalSize = originalSize;
        NewSize = newSize;
    }

    public long OriginalSize { get; set; }
    public long NewSize { get; set; }
}
