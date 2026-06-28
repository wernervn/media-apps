namespace MovieCollection.Common;

[Serializable]
public class ImageInfo
{
    public string FileName { get; set; } = string.Empty;
    public byte[] ImageData { get; set; } = [];
}
