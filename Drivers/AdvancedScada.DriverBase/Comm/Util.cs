using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace AdvancedScada.DriverBase.Comm
{
    public class Util
    {
      
        public static float Interpolation(short iaCurrent, ushort iaMin, ushort iaMax, float rlMin, float rlMax)
        {
            float result = 0.0f;
            result = (iaCurrent - iaMin) / (iaMax - iaMin) * (rlMax - rlMin) + rlMin;
            return (float)Math.Round(result, 1);
            //return result; // Math.Round(result, 1);
        }

       
        public static float Interpolation(ushort iaCurrent, ushort iaMin, ushort iaMax, float rlMin, float rlMax)
        {
            float result = 0.0f;
            result = (float)(iaCurrent - iaMin) / (iaMax - iaMin) * (rlMax - rlMin) + rlMin;
            return (float)Math.Round(result, 1);
            //return result; // Math.Round(result, 1);
        }

        private static readonly Regex validIpV4AddressRegex = new Regex(@"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$", RegexOptions.IgnoreCase);

        /// <summary>
        /// Validates an IPv4 address.
        /// </summary>
        /// <param name="address"></param>
        /// <returns>bool</returns>
        public static bool IsIpV4AddressValid(string address)
        {
            if (!string.IsNullOrWhiteSpace(address))
            {
                return validIpV4AddressRegex.IsMatch(address.Trim());
            }
            return false;
        }
        /// <summary>
        /// Validates an IPv6 address.
        /// </summary>
        /// <param name="address"></param>
        /// <returns>bool</returns>
        public static bool IsIpV6AddressValid(string address)
        {
            if (!string.IsNullOrWhiteSpace(address))
            {
                IPAddress ip;
                if (IPAddress.TryParse(address, out ip))
                {
                    return ip.AddressFamily == AddressFamily.InterNetworkV6;
                }
            }
            return false;
        }
    }
}
