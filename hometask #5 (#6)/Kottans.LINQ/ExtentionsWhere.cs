using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static partial class KottansLinq
    {
        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();

            return WhereIterator(source, predicate);
        }

        public static IEnumerable<TSource> WhereIterator<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            foreach (var value in source)
            {
                if (predicate(value))
                    yield return value;
            }
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();

            return WhereIterator(source, predicate);
        }

        public static IEnumerable<TSource> WhereIterator<TSource>(this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            int index = 0;

            foreach (var value in source)
            {
                if (predicate(value, index++))
                    yield return value;
            }
        }
    }
}