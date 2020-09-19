using System.Text.RegularExpressions;
using System.Linq;

namespace Extension
{
    public static class IsAlphaStringExtension
    {
        ///
        /// <summary>
        ///     Checks if a string contains only letters.
        /// </summary>
        /// <returns>Boolean result of the operation</returns>
        public static bool IsAlpha(this string input)
        {
            return Regex.IsMatch(input, "^[a-zA-Z]+$");
        }
    }
}