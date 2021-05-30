using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using MediaApps.Series.Core.Mede8er;
using MediaApps.Common.Extensions;
using MediaApps.Series.Core.Exceptions;

namespace MediaApps.Series.Core
{
    public static class SeriesIOHelper
    {
        public static bool IsDoubleEpisode(string episodeName)
        {
            var pattern = "S\\d{1,2}([-+]?E\\d{1,2})([-+]?_\\d{1,2})+";
            var options = RegexOptions.IgnoreCase | RegexOptions.Singleline;
            var regex = new Regex(pattern, options, TimeSpan.FromMilliseconds(1000));
            var match = regex.Match(episodeName);
            return match.Success;
        }

        public static int GetSeasonEpisodeFromName(string episodeName)
        {
            var pattern = "S\\d{1,2}([-+]?E\\d{1,2})+";  //TODO: cater for double episodes
            var options = RegexOptions.IgnoreCase | RegexOptions.Singleline;
            var regex = new Regex(pattern, options, TimeSpan.FromMilliseconds(1000));
            var match = regex.Match(episodeName);
            if (match.Success)
            {
                var seasonEpisode = match.Value;
                var episode = seasonEpisode.Substring(seasonEpisode.IndexOf("E", StringComparison.OrdinalIgnoreCase) + 1);
                return int.Parse(episode);
            }
            else
            {
                throw new SeriesException("No season info in name: " + episodeName);
            }
        }

        public static string GetSeriesIdFromFile(string path)
        {
            var metadata = GetSeriesMetadata(path);
            return metadata.Series.TvdbId;
        }

        public static SeriesMetadata GetSeriesMetadata(string path)
        {
            var file = Path.Combine(path, Constants.SERIES_XML);
            if (File.Exists(file))
            {
                var xml = File.ReadAllText(file);
                return xml.FromXml<SeriesMetadata>();
            }
            return null;
        }

        public static EpisodeMetadata GetEpisodeMetadata(string path)
        {
            if (File.Exists(path))
            {
                var xml = File.ReadAllText(path);
                return xml.FromXml<EpisodeMetadata>();
            }
            return null;
        }

        public static string[] ToArray(string field)
        {
            var DELIM = "|".ToCharArray();
            return field is not null ? field.Split(DELIM, StringSplitOptions.RemoveEmptyEntries) : new string[] { };
        }

        public static string GetTempFileWithExtension(string extension)
        {
            if (!extension.StartsWith(".", StringComparison.CurrentCulture))
            {
                extension = string.Concat(".", extension);
            }

            return string.Concat(Path.GetTempPath(), Guid.NewGuid().ToString(), extension);
        }

        public static void Launch(string fileName, string args = null)
        {
            var psi = new ProcessStartInfo { FileName = fileName, UseShellExecute = true, CreateNoWindow = true };
            if (args is not null)
            {
                psi.Arguments = args;
            }
            var p = new Process { StartInfo = psi };
            p.Start();
        }
    }
}
