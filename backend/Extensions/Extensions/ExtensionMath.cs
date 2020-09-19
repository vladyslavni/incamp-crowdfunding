namespace Extension
{
    public class ExtensionMath
    {
        public static int Range(int start, int end)
        {
            int result = 0;

            for (int i = start; i <= end; i++)
            {
                result++;
            }

            return result;
        }
    }
}