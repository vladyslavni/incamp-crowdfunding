using System;
using System.Collections.Generic;

namespace Extension
{
    public static class FindFirstListExtension
    {
        //
        // Summary:
        //     Searches for an element that matches the conditions defined by the specified
        //     predicate, and returns the first occurrence within the entire System.Collections.Generic.List.
        //
        // Parameters:
        //   match:
        //     The System.Predicate delegate that defines the conditions of the element to
        //     search for.
        //
        // Returns:
        //     The first element that matches the conditions defined by the specified predicate,
        //     if found; otherwise, the default value for type T.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     match is null.
        public static T FindFirst<T>(this List<T> list, Predicate<T> match)
        {
            foreach (var item in list)
            {
                if (match(item)) return item;
            }

            throw new ArgumentNullException("There's no such item in the list");
        }
    }
}