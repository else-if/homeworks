using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static partial class KottansLinq
    {
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TResult> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();

            return SelectIterator(source, predicate);
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, int, TResult> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();

            return SelectIterator(source, predicate);
        }

        private static IEnumerable<TResult> SelectIterator<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TResult> predicate)
        {
            foreach (var value in source)
                yield return predicate(value);
        }

        private static IEnumerable<TResult> SelectIterator<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, int, TResult> predicate)
        {
            int index = 0;

            foreach (var value in source)
                yield return predicate(value, index++);
        }
    }
}