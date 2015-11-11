using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static partial class KottansLinq
    {
        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException();

            IEnumerator<TSource> enumerator = source.GetEnumerator();
            if (enumerator.MoveNext()) return enumerator.Current;

            return default(TSource);
        }

        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();

            foreach (var value in source)
            {
                if (predicate(value)) return value;
            }

            return default(TSource);
        }
    }
}