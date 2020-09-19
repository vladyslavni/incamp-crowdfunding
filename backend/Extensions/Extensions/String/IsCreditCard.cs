using System.Text.RegularExpressions;
using System.Linq;

namespace Extension
{
    public static class IsCreditCardStringExtension
    {
        ///
        /// <summary>
        ///     Checks if string is a credit card.
        /// </summary>
        /// <returns>Boolean result of the operation</returns>
        public static bool IsCreditCard(this string text)
        {
            text = text.RemoveChars(' ', '-');

            if (!text.IsNumeric()) return false;
            
            int sumOfDigits = text.Where((e) => '0' <= e && e <= '9')
                            .Reverse()
                            .Select((e, i) => ((int)e - 48) * (i % 2 == 0 ? 1 : 2))
                            .Sum((e) => e / 10 + e % 10);
                       
            return sumOfDigits % 10 == 0;
        }
    }
}