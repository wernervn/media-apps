using System.Collections.Generic;
using System.Linq;

namespace MediaApps.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsEmptyEnumerable<T>(this IEnumerable<T> enumerable)
            => enumerable?.Count() > 0;
    }
}
