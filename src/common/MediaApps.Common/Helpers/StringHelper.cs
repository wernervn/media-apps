using System;
using System.Linq;

namespace MediaApps.Common.Helpers
{
    public static class StringHelper
    {
        public static string GetLastTokenFromString(string text, string delimiter)
            => text.Split(new string[] { delimiter }, StringSplitOptions.None).Last();
    }
}
