﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static partial class KottansLinq
    {
        public static int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();

            return Count(source.Select(predicate));
        }

        public static int Count(this IEnumerable source)
        {
            if (source == null) throw new ArgumentNullException();

            int result = 0;
            foreach (var value in source)
            {
                checked
                {
                    result++;
                }
            }

            return result;
        }
    }
}