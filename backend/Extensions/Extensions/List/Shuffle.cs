using System;
using System.Collections.Generic;

namespace Extension
{
    public static class ShuffleListExtension
    {
        private static Random random = new Random();
        //
        // Summary:
        //    Sorts the System.Collections.Generic.List randomly using the
        //    Fisher-Yates shuffle algorithm.
        public static void Shuffle<T>(this List<T> list)
        {
            for (var i = 0; i < list.Count - 1; i++)
			{
				list.Swap(i, random.Next(i, list.Count));
			}
        }
    }
}