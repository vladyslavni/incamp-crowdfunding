using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;
using System.Linq;

namespace Extension
{
    public static class IsIPStringExtension
    {
        ///
        /// <summary>
        ///     Checks if a string is an IP address.
        /// </summary>
        /// <returns>Boolean result of the operation</returns>
        public static bool IsIP(this string input)
        {
            IPAddress ip;

            if (IPAddress.TryParse(input, out ip))
            {
                return true;
            }

            return false;
        }

        ///
        /// <summary>
        ///     Checks if a string is an IPv4 address.
        /// </summary>
        /// <returns>Boolean result of the operation</returns>
        public static bool IsIPv4(this string input)
        {
            IPAddress ip;

            if (IPAddress.TryParse(input, out ip) && ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return true;
            }

            return false;
        }

        ///
        /// <summary>
        ///     Checks if a string is an IPv6 address.
        /// </summary>
        /// <returns>Boolean result of the operation</returns>
        public static bool IsIPv6(this string input)
        {
            IPAddress ip;

            if (IPAddress.TryParse(input, out ip) && ip.AddressFamily == AddressFamily.InterNetworkV6)
            {
                return true;
            }

            return false;
        }
    }
}