using System;

namespace Extension
{
    /// <summary>
    ///     Checks if a string is null or empty
    /// </summary>
    /// <returns>Boolean result of the operation</returns>
    public static class IsNullOrEmptyStringExtension
    {
        public static bool IsNullOrEmpty(this string input)
        {
            return String.IsNullOrEmpty(input);
        }
    }
}