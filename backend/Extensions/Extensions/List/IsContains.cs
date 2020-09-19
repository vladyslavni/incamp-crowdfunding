using System.Collections.Generic;

namespace Extension
{
    public static class IsContainsListExtension
    {
        //
        // Summary:
        //    Checks the System.Collections.Generic.List for an object in it
        //
        // Parameters:
        //   obj:
        //     The object we are looking for in the list.
        //
        // Returns:
        //    Boolean result of the operation.
        public static bool IsContains<T>(this List<T> list, T obj)
        {
            foreach (var item in list)
            {
                if (item.Equals(obj)) return true;
            }

            return false;
        }
    }
}