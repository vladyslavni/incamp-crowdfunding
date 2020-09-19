using System;
using System.Net;

namespace Extension
{
    public static class IsUrlStringExtension
    {
        ///
        /// <summary>
        ///     Checks if a string is a URL.
        /// </summary>
        /// <returns>Boolean result of the operation</returns>
        public static bool IsUrl(this string input)
        {
            Uri uri;

            if (Uri.TryCreate(input, UriKind.Absolute, out uri))
            {
                return true;
            }

            return false;
        }
    }
}