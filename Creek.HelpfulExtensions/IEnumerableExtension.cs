using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Creek.HelpfulExtensions
{
    public static class IEnumerableExtension
    {
        /// <summary>
        /// This extension allows a foreach loop with an index
        /// </summary>
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> source)
        {
            return source.Select((item, index) => (item, index));
        }
    }
}
