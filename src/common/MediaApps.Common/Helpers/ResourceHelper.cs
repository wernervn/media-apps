using System.Reflection;
using System.Text;

namespace MediaApps.Common.Helpers
{
    /// <summary>
    /// Retrieve values from embedded resources
    /// </summary>
    public static class ResourceHelper
    {
        /// <summary>
        /// Retrieve string value from embedded resource
        /// </summary>
        /// <param name="assembly">Assembly containing the resources</param>
        /// <param name="resourceName">Path to the resource</param>
        /// <returns></returns>
        public static string GetResource(Assembly assembly, string resourceName)
        {
            using var stream = assembly.GetManifestResourceStream(resourceName);
            var data = new byte[stream.Length];
            stream.Read(data, 0, (int)stream.Length);
            return Encoding.UTF8.GetString(data);
        }

        /// <summary>
        /// Retrieve string value from embedded GZipped resource
        /// </summary>
        /// <param name="assembly">Assembly containing the resources</param>
        /// <param name="resourceName">Path to the resource</param>
        /// <returns></returns>
        public static string GetZippedResource(Assembly assembly, string resourceName)
        {
            using var stream = assembly.GetManifestResourceStream(resourceName);
            var data = GZipHelper.Decompress(stream);
            return Encoding.UTF8.GetString(data);
        }
    }
}
