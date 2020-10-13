using System;

namespace Extension
{
    public static class IsDateStringExtension
    {
        ///
        /// <summary>
        ///     Checks if a string is date.
        /// </summary>
        /// <returns>Boolean result of the operation</returns>
        public static bool IsDate(this string input)
        {
            DateTime date;

            if (DateTime.TryParse(input, out date))
            {
                return true;
            }
                       
            return false;
        }
    }
}