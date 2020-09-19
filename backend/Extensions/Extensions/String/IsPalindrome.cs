using System.Text.RegularExpressions;

namespace Extension
{
    public static class IsPalindromeStringExtension
    {
        ///
        /// <summary>
        ///    Checks if a string is a palindrome.
        ///    
        ///    Level, Madam, Racecar etc.
        /// </summary>
        /// <returns>Boolean result of the operation</returns>
        public static bool IsPalindrome(this string text)
        {
            char[] chars = text.ToLower().ToCharArray();
            int len = chars.Length - 1;

            for (int i = 0; i <= len / 2; i++)
            {
                if (chars[i] != chars[len - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}