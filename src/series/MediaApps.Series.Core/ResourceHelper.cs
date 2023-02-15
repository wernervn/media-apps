using System.Drawing;
using System.Reflection;

namespace MediaApps.Series.Core;

public class ResourceHelper
{
    public async Task WriteResourceToFile(string resourceName, string fileName)
    {
        using var resource = GetType().Assembly.GetManifestResourceStream(resourceName);
        using var file = new FileStream(fileName, FileMode.Create, FileAccess.Write);
        await resource.CopyToAsync(file).ConfigureAwait(false);
    }

    public static Image GetImageResource(string resourceName)
    {
        using var resource = Assembly.GetEntryAssembly().GetManifestResourceStream(resourceName);
        return Image.FromStream(resource);
    }
}
