using System;
using System.Collections.Generic;

namespace Extension
{
    public static class RandomListExtension
    {
        private static Random random = new Random();
        //
        // Summary:
        //    Takes a random element of the System.Collections.Generic.List
        //    and returns it.
        //
        // Returns:
        //     Random element of the System.Collections.Generic.List.
        public static T Random<T>(this List<T> list)
        {
            int index = random.Next(list.Count);

            return list[index];
        }
    }
}