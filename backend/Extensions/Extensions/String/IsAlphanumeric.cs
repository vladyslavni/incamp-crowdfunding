using System.Text.RegularExpressions;
using System.Linq;

namespace Extension
{
    public static class IsAlphanumericStringExtension
    {
        ///
        /// <summary>
        ///     Checks if a string contains only letters and numbers.
        /// </summary>
        /// <returns>Boolean result of the operation</returns>
        public static bool IsAlphanumeric(this string input)
        {
            return Regex.IsMatch(input, "^[a-zA-Z0-9]+$");
        }
    }
}