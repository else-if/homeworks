using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static partial class KottansLinq
    {
        public static IEnumerable<int> Range(int start, int length)
        {
            if (length < 0) throw new ArgumentOutOfRangeException();

            if (length != 0)
                try
                {
                    var i = checked(length - 1 + start);
                }
                catch (OverflowException e)
                {
                    throw new ArgumentOutOfRangeException();
                }

            return RangeIterator(start, length);
        }

        private static IEnumerable<int> RangeIterator(int start, int length)
        {
            for (var i = 0; i < length; i++)
                yield return start + i;
        }
    }
}