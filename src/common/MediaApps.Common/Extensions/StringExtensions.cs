using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MediaApps.Common.Extensions
{
    public static class StringExtensions
    {
        private static readonly string ByteOrderMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());

        public static string SingleQuote(this string value)
        => string.Concat("'", value, "'");

        public static string DoubleQuote(this string value)
            => string.Concat("\"", value, "\"");

        public static bool Contains(this string source, string value, bool ignoreCase)
            => ignoreCase ? source.Contains(value, StringComparison.CurrentCultureIgnoreCase) : source.Contains(value, StringComparison.CurrentCulture);

        public static bool Contains(this string source, string value, StringComparison comparison)
            => source.IndexOf(value, comparison) != -1;

        public static string ReplaceAllChars(this string source, char[] toReplace, char replacement)
            => toReplace.Aggregate(source, (input, remove) => input = input.Replace(remove, replacement)).Trim();

        public static string ReplaceAllChars(this string source, List<string> toReplace, string replacement)
            => toReplace.Aggregate(source, (input, remove) => input = input.Replace(remove, replacement)).Trim();

        public static string RegExReplaceAllChars(this string source, List<string> toReplace, string replacement, bool ignoreCase = false)
        {
            var options = ignoreCase ? RegexOptions.IgnoreCase : RegexOptions.None;
            return toReplace.Aggregate(source, (input, remove) => input = Regex.Replace(input, remove, replacement, options)).Trim();
        }

        /// <summary>
        /// Checks if a string starts with any value of a list of arguments
        /// </summary>
        /// <param name="text">Value used for comparison</param>
        /// <param name="patterns">List of values</param>
        /// <returns>True if text matches any of the patterns, else false</returns>
        public static bool StartsWithAny(this string text, params string[] patterns) => patterns.Any(text.StartsWith);

        /// <summary>
        /// Splits a string on line break
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Array of strings split by line break</returns>
        public static string[] SplitOnCrLf(this string text) => Regex.Split(text, "\r\n|\r|\n");

        /// <summary>
        /// Remove byte order marker from a string
        /// </summary>
        /// <param name="text"></param>
        /// <returns>String containing no byte order marker</returns>
        public static string StripUtf8Bom(this string text)
        {
            if (text.StartsWith(ByteOrderMarkUtf8, StringComparison.Ordinal))
            {
                text = text.Remove(0, ByteOrderMarkUtf8.Length);
            }
            return text;
        }
    }
}
