using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedScada.Utils.LSIS
{
    public class HexadecimalToDecimal
    {
        private static readonly Dictionary<char, int> hexdecval = new Dictionary<char, int>
        {
            {'0', 0},
            {'1', 1},
            {'2', 2},
            {'3', 3},
            {'4', 4},
            {'5', 5},
            {'6', 6},
            {'7', 7},
            {'8', 8},
            {'9', 9},
            {'a', 10},
            {'b', 11},
            {'c', 12},
            {'d', 13},
            {'e', 14},
            {'f', 15}
        };

        public static decimal HexToDec(string hex)
        {
            decimal result = 0;
            hex = hex.ToLower();

            for (var i = 0; i < hex.Length; i++)
            {
                var valAt = hex[hex.Length - 1 - i];
                result += hexdecval[valAt] * (int)Math.Pow(16, i);
            }

            return result;
        }

        //static void Main()
        //{

        //    Console.WriteLine("Enter Hexadecimal value");
        //    string hex = Console.ReadLine().Trim();

        //    //string hex = "29A";
        //    Console.WriteLine("Hex {0} is dec {1}", hex, HexToDec(hex));

        //    Console.ReadKey();
        //}
    }
    public class DecimalToHex
    {
        private static string hexaNumber; // other way: string hexaNumber = null; 

        public static string GetDecimalToHex(long decimalNumber)
        {
            hexaNumber = string.Empty;
            //Console.WriteLine(decimalNumber.ToString("X"));
            //Console.WriteLine("{0:X}", decimalNumber);
            //Console.WriteLine(Convert.ToString(decimalNumber, 16).ToUpper());

            if (decimalNumber == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                while (decimalNumber > 0)
                {
                    // must be long; when this type is int the result is wrong
                    var checkRemainder = decimalNumber % 16;
                    var remainder = string.Empty;
                    switch (checkRemainder)
                    {
                        case 10:
                            remainder = "A";
                            break;
                        case 11:
                            remainder = "B";
                            break;
                        case 12:
                            remainder = "C";
                            break;
                        case 13:
                            remainder = "D";
                            break;
                        case 14:
                            remainder = "E";
                            break;
                        case 15:
                            remainder = "F";
                            break;
                        default:
                            remainder = checkRemainder.ToString();
                            break;
                    }

                    hexaNumber = remainder + hexaNumber;
                    decimalNumber /= 16;
                }

                Console.WriteLine(hexaNumber);
            }

            return hexaNumber;
        }
    }
}
