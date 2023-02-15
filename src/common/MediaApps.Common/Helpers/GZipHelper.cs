using System.IO.Compression;

namespace MediaApps.Common.Helpers;

public static class GZipHelper
{
    public static byte[] Compress(byte[] raw)
    {
        using MemoryStream ms = new MemoryStream();
        using GZipStream gzip = new GZipStream(ms, CompressionMode.Compress, true);
        gzip.Write(raw, 0, raw.Length);
        return ms.ToArray();
    }

    public static byte[] Decompress(Stream zipped)
    {
        using var ms = new MemoryStream();
        using var decompressionStream = new GZipStream(zipped, CompressionMode.Decompress);
        decompressionStream.CopyTo(ms);
        return ms.ToArray();
    }
}
