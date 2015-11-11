using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static partial class KottansLinq
    {
        public static IEnumerable<int> Concat(this IEnumerable<int> left, IEnumerable<int> right)
        {
            if (left == null) throw new ArgumentNullException();
            if (right == null) throw new ArgumentNullException();

            return ConcatIterator(left, right);
        }

        private static IEnumerable<int> ConcatIterator(IEnumerable<int> left, IEnumerable<int> right)
        {
            foreach (var value in left)
            {
                yield return value;
            }

            foreach (var value in right)
            {
                yield return value;
            }
        }
    }
}