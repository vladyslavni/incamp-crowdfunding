namespace Extension
{
    public static class CutExtension
    {
        //
        // Summary:
        //    Cuts the selection out.
        //
        //    {1,2,3,4,5} => Array.Cut(1,3) => {1, 5}
        //
        // Parameters:
        //   start:
        //     A 32-bit integer that represents the start of the selection in System.Array.
        //
        //   end:
        //     A 32-bit integer that represents the end of the selection in System.Array.
        // 
        // Returns:
        //     System.Array with clipped selection.
        public static T[] Cut<T>(this T[] array, int start, int end)
        {
            int size = array.Length - ExtensionMath.Range(start, end);
            T[] result = new T[size];
            
            for (int i = 0, j = 0; i < array.Length; i++)
            {
                if ((start > i) | (i > end)) 
                {
                    result[j] = array[i];
                    j++;
                }   
            }

            return result;
        }
    }
}