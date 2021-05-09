using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using MediaApps.Common.Extensions;
using static MediaApps.Common.Helpers.StringHelper;

namespace MediaApps.Common.Helpers
{
    public static class IOHelper
    {
        public static string CleanDirectoryName(string path)
            => path.ReplaceAllChars(Path.GetInvalidPathChars(), ' ');

        public static string CleanFileName(string path)
            => path.ReplaceAllChars(Path.GetInvalidFileNameChars(), ' ');

        public static string GetRandomFileName()
            => GetRandomFileName(Path.GetTempPath());

        public static string GetRandomFileName(string path)
            => GetRandomFileName(path, ".tmp");

        public static string GetRandomFileName(string path, string extension)
            => Path.Combine(path, string.Format("{0}.{1}", Guid.NewGuid(), extension));

        public static string GetFolderName(string path)
            => GetLastTokenFromString(path, Path.DirectorySeparatorChar.ToString());

        public static string GetFileNameFromUrl(string url)
            => GetLastTokenFromString(url, "/");

        // Regex version
        public static IEnumerable<string> GetFiles(string path, string regexPatternExpression = "", SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            var reSearchPattern = new Regex(regexPatternExpression, RegexOptions.IgnoreCase);
            return Directory.EnumerateFiles(path, "*", searchOption).AsParallel()
                            .Where(file => reSearchPattern.IsMatch(Path.GetExtension(file)));
        }

        // Takes some patterns, and executes in parallel
        public static IEnumerable<string> GetFiles(string path, string[] searchPatterns, SearchOption searchOption = SearchOption.TopDirectoryOnly)
            => GetFiles(path, searchPatterns.ToList(), searchOption);

        // Takes some patterns, and executes in parallel
        public static IEnumerable<string> GetFiles(string path, List<string> searchPatterns, SearchOption searchOption = SearchOption.TopDirectoryOnly)
            => searchPatterns.AsParallel()
                .SelectMany(searchPattern => Directory.EnumerateFiles(path, searchPattern, searchOption))
                .AsParallel();
    }
}
