using System;

namespace Extension
{
    public static class RandomExtension
    {
        private static Random random = new Random();
        //
        // Summary:
        //    Takes a random element of the System.Array and returns it.
        //
        // Returns:
        //     Random element of the System.Array.
        public static T Random<T>(this T[] array)
        {
            int index = random.Next(array.Length);

            return array[index];
        }
    }
}