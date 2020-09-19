using System.Text.RegularExpressions;

namespace Extension
{
    public static class IsNumericStringExtension
    {
        ///
        /// <summary>
        ///     Checks if a string contains only numbers.
        /// </summary>
        /// <returns>Boolean result of the operation</returns>
        public static bool IsNumeric(this string text)
        {
            return Regex.IsMatch(text, "^[0-9]+$"); 
        }
    }
}