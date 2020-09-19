using System;
namespace Extension
{
    public static class ExpandExtension
    {
        //
        // Summary:
        //    Increases the size of the System.Array.
        //
        // Parameters:
        //   size:
        //     A 32-bit integer representing the length by which System.Array will be extended.
        //
        // Returns:
        //     Extended System.Array.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     Array expansion size is zero or less.
        public static T[] Expand<T>(this T[] array, int size)
        {
            if ( 0 > size ) throw new ArgumentException("Array expansion size is zero or less."); 

            T[] result = new T[size];

            for (int i = 0; i < array.Length; i++)
            {
                result[i] = array[i];
            }

            return result;
        }
    }
}