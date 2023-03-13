namespace MovieCollection.Common;

[Serializable]
public class ImageInfo
{
    public ImageInfo()
    {
        FileName = string.Empty;
        ImageData = Array.Empty<byte>();
    }
    public string FileName { get; set; }
    public byte[] ImageData { get; set; }
}
