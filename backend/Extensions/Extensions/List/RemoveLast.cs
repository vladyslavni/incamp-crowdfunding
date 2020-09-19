using System;
using System.Collections.Generic;

namespace Extension
{
    public static class RemoveLastListExtension
    {
        //
        // Summary:
        //    Removes the last element in the System.Collections.Generic.List.
        public static void RemoveLast<T>(this List<T> list)
        {
            list.RemoveAt(list.Count - 1);
        }
    }
}