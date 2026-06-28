using System.Reflection;

namespace MovieCollection.Common.Extensions;

public static class Extensions
{
    public static Image GetResourceImage(this Assembly assembly, string resourceName)
    {
        using var stream = assembly.GetManifestResourceStream(resourceName);
        return Image.FromStream(stream);
    }
}
