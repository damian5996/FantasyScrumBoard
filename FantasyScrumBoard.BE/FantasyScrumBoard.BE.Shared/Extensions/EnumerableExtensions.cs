using System.Collections.Generic;
using System.Linq;

namespace FantasyScrumBoard.BE.Shared.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }
    }
}
