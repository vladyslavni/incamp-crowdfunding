using System.Text.RegularExpressions;

namespace Extension
{
    public static class IsPhoneNumberStringExtension
    {
        ///
        /// <summary>
        ///     Checks if string is a phone number.
        /// </summary>
        /// <returns>Boolean result of the operation</returns>
        public static bool IsPhoneNumber(this string text)
        {
            return Regex.IsMatch(text, @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$"); 
        }
    }
}