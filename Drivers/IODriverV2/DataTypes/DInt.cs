using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataTypes
{
    public class DInt
    {

        #region Chuyển đổi mảng kiểu byte thành DInt.

        /// <summary>
        /// Phương thức chuyển mảng kiểu byte thành kiểu DInt.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static int FromByteArray(byte[] bytes)
        {
            Array.Reverse(bytes);            
            return BitConverter.ToInt32(bytes, 0);            
        }


        public static int FromBytes(byte v1, byte v2, byte v3, byte v4)
        {
            return (int)(v1 + v2 * Math.Pow(2, 8) + v3 * Math.Pow(2, 16) + v4 * Math.Pow(2, 24));
        }

        #endregion

        #region Chuyển kiểu DInt thành mảng byte.

        /// <summary>
        /// Phương thức chuyển kiểu DInt thành mảng byte.
        /// </summary>
        /// <param name="value">Giá trị kiểu DInt</param>
        /// <returns>Trả về mảng dữ liệu kiểu byte</returns>
        public static byte[] ToByteArray(int value)
        {
            byte[] array = BitConverter.GetBytes(value);
            Array.Reverse(array);
            return array;
        }

        /// <summary>
        /// Phương thức chuyển mảng dữ liệu kiểu DInt thành mảng byte.
        /// </summary>
        /// <param name="value">Mảng giá trị kiểu DInt</param>
        /// <returns>Trả về mảng dữ liệu kiểu byte</returns>
        public static byte[] ToByteArray(int[] value)
        {
            ByteArray arr = new ByteArray();
            foreach (int val in value)
                arr.Add(ToByteArray(val));
            return arr.array;
        }

        #endregion

        #region ToArray
        public static int[] ToArray(byte[] bytes)
        {
            int[] values = new int[bytes.Length / 4];

            int counter = 0;
            for (int cnt = 0; cnt < bytes.Length / 4; cnt++)
                values[cnt] = FromByteArray(new byte[] { bytes[counter++], bytes[counter++], bytes[counter++], bytes[counter++] });

            return values;
        }
        #endregion

        // conversion
        public static int CDWord(Int64 value)
        {
            if (value > int.MaxValue)
            {
                value -= (long)int.MaxValue + 1;
                value = (long)int.MaxValue + 1 - value;
                value *= -1;
            }
            return (int)value;
        }
    }
}
