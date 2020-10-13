using System.Collections.Generic;

namespace Extension
{
    public static class SwapListExtension
    {
        //
        // Summary:
        //    Swaps two selected System.Collections.Generic.List items
        //
        //    {1,2,3} => List.Swap(1,2) => {2, 1, 3}
        //
        // Parameters:
        //   i:
        //     A 32-bit integer that represents the index of the first element.
        //
        //   j:
        //     A 32-bit integer that represents the index of the second element.
        public static void Swap<T>(this List<T> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}