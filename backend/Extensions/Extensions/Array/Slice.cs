namespace Extension
{
    public static class SliceExtension
    {
        //
        // Summary:
        //    Cuts everything except the selection
        //
        //    {1,2,3,4,5} => Array.Slice(1,3) => {2, 3, 4}
        //
        // Parameters:
        //   start:
        //     A 32-bit integer that represents the start of the selection in System.Array.
        //
        //   end:
        //     A 32-bit integer that represents the end of the selection in System.Array.
        // 
        // Returns:
        //     System.Array with clipped unselected area
        public static T[] Slice<T>(this T[] array, int start, int end)
        {
            int size = ExtensionMath.Range(start, end);
            T[] result = new T[size];
            
            for (int i = start, j = 0; i <= end; i++, j++)
            {
                result[j] = array[i];
            }

            return result;
        }
    }
}