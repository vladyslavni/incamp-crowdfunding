using System;

namespace Extension
{
    public static class IsEmptyExtension
    {
        //
        // Summary:
        //    Checks if System.Array is empty.
        //
        // Returns:
        //    Boolean result of the operation.
        public static bool IsEmpty<T>(this T[] array)
        {
            return array != null && array.Length < 1;
        }
    }
}