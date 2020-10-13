using System.Text.RegularExpressions;
using System.Linq;

namespace Extension
{
    public static class IsHexadecimalStringExtension
    {
        ///
        /// <summary>
        ///     Checks if a string is hexadecimal.
        /// </summary>
        /// <returns>Boolean result of the operation</returns>
        public static bool IsHexadecimal(this string input)
        {
            return Regex.IsMatch(input, "^[a-fA-F0-9]+$");
        }
    }
}