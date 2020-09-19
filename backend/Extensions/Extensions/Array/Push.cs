namespace Extension
{
    public static class PushExtension
    {
        //
        // Summary:
        //    Adds values ​​to the end of System.Array.
        //
        // Parameters:
        //   objects:
        //     Parameters to add to System.Array.
        // 
        // Returns:
        //     System.Array with new objects.
        public static T[] Push<T>(this T[] array, params T[] objects)
        {
            int size = array.Length + objects.Length;
            T[] result = new T[size];

            for (int i = 0, j = 0; i < size; i++)
            {
                if (array.Length > i) 
                {
                    result[i] = array[i];
                } else {
                    result[i] = objects[j];
                    j++;
                }
            }
            
            return result;
        }
    }
}