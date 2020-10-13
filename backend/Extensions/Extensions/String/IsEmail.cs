using System.Text.RegularExpressions;

namespace Extension
{
    public static class IsEmailStringExtension
    {
        ///
        /// <summary>
        ///     Checks if a string is an email address.
        /// </summary>
        /// <returns>Boolean result of the operation</returns>
        public static bool IsEmail(this string text)
        {
            return Regex.IsMatch(text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"); 
        }
    }
}