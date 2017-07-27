using System.Collections.Generic;
using System.Linq;

namespace Project.Utilities {
    public static class EnumerableExtensions {
        public static IEnumerable<T> Combine<T>(this IEnumerable<T> initial, params IEnumerable<T>[] items) {
            return items.Aggregate(initial, (current, item) => current.Union(item));
        }
    }
}