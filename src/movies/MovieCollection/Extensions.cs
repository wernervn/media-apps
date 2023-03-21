using System.Reflection;

namespace MovieCollection;

public static class Extensions
{
    public static Image GetResourceImage(this Assembly assembly, string resourceName)
    {
        using var stream = assembly.GetManifestResourceStream(resourceName);
        return Image.FromStream(stream);
    }
}
