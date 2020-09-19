using System;
using System.Text.RegularExpressions;
using System.Text.Json;

namespace Extension
{
    public static class IsJsonStringExtension
    {
        ///
        /// <summary>
        ///     Checks if a string is Json.
        /// </summary>
        /// <returns>Boolean result of the operation</returns>
        public static bool IsJson(this string input)
        {
            try 
            {
                JsonSerializer.Deserialize<dynamic>(input);
                return true;
            } 
            catch (Exception)
            {
                return false;
            }
        }
    }
}