using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Core.DataTypes
{
    public class Bit 
    {

        /// <summary>
        /// Phương thức chuyển đổi mảng dữ liệu kiểu byte thành mảng dữ liệu kiểu bool.
        /// </summary>
        /// <param name="value">Mảng giá trị kiểu byte</param>
        /// <returns>Mảng giá trị kiểu bool</returns>
        public static bool[] ToArray(byte[] value)
        {
            List<bool> result = new List<bool>();
            BitArray bits = new BitArray(value);           
            for (int i = 0; i < bits.Count; i++)
            {
                result.Add(bits[i]);
            }
            return result.ToArray();
        }

        /// <summary>
        /// Phương thức chuyển đổi mảng dữ liệu kiểu bool thành mảng dữ liệu kiểu byte.
        /// </summary>
        /// <param name="bits">Mảng giá trị kiểu bool</param>
        /// <returns>Trả về mảng giá trị kiểu byte</returns>
        public static byte[] ToByteArray(bool[] bits)
        {                        
            int numBytes = bits.Length / 8;
            int bitEven = bits.Length % 8;
            if (bitEven != 0)
            {
                //List<bool> bitsTemp = new List<bool>();
                //for (int i = 0; i < bitEven; i++)
                //{
                    
                //}
                numBytes++;
            }
            Array.Reverse(bits);
            byte[] bytes = new byte[numBytes];
            int byteIndex = 0, bitIndex = 0;

            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i])
                    bytes[byteIndex] |= (byte)(1 << (7 - bitIndex));

                bitIndex++;
                if (bitIndex == 8)
                {
                    bitIndex = 0;                    
                    byteIndex++;
                }
            }
            Array.Reverse(bytes);
            return bytes;
        }

        public static bool GetValue(byte value, int bit)
        {
            if ((value & (int)Math.Pow(2, bit)) != 0)
                return true;
            else
                return false;
        }

        public static byte SetBit(byte value, int bit)
        {
            return (byte)(value | (byte)Math.Pow(2, bit));
        }

        public static byte ClearBit(byte value, int bit)
        {
            return (byte)(value & (byte)(~(byte)Math.Pow(2, bit)));
        }
    }
}
