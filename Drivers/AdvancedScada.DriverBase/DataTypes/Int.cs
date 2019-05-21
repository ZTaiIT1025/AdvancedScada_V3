using System;

namespace AdvancedScada.DriverBase.Core.DataTypes
{
    public class Int
    {
        #region Khai báo các hằng số và các biến.

        #endregion

        #region Các thuộc tính.

        public short Value { get; set; }

        #endregion

        #region ToArray

        public static short[] ToArray(byte[] bytes)
        {
            var values = new short[bytes.Length / 2];
            var counter = 0;
            for (var cnt = 0; cnt < bytes.Length / 2; cnt++)
                values[cnt] = FromByteArray(new[] { bytes[counter++], bytes[counter++] });

            return values;
        }

        #endregion

        // conversion
        public static short CWord(int value)
        {
            if (value > 32767)
            {
                value -= 32768;
                value = 32768 - value;
                value *= -1;
            }

            return (short)value;
        }

        #region Chuyển đổi mảng kiểu byte thành kiểu Int.

        /// <summary>
        ///     Phương thức chuyển đổi mảng byte thành kiểu int.
        /// </summary>
        /// <param name="bytes">Mảng giá trị kiểu byte</param>
        /// <returns>Trả về giá trị kiểu int</returns>
        public static short FromByteArray(byte[] bytes)
        {
            // bytes[0] -> HighByte
            // bytes[1] -> LowByte
            return FromBytes(bytes[1], bytes[0]);
        }

        /// <summary>
        ///     Phương thức chuyển đổi 2 byte thành kiểu int.
        /// </summary>
        /// <param name="LoVal">Giá trị byte thấp</param>
        /// <param name="HiVal">Giá trị byte cao</param>
        /// <returns>Trả về giá trị kiểu int</returns>
        public static short FromBytes(byte LoVal, byte HiVal)
        {
            return (short)(HiVal * 256 + LoVal);
        }

        #endregion

        #region Chuyển đổi kiểu Int/Int[] thành mảng kiểu byte.

        /// <summary>
        ///     Phương thức chuyển kiểu Int thành mảng kiểu byte.
        /// </summary>
        /// <param name="value">Giá trị kiểu int</param>
        /// <returns>Trả về mảng giá trị kiểu byte</returns>
        public static byte[] ToByteArray(short value)
        {
            var byteArray = BitConverter.GetBytes(value);
            Array.Reverse(byteArray);
            return byteArray;
        }

        /// <summary>
        ///     Phương thức chuyển mảng kiểu Int thành mảng kiểu byte.
        /// </summary>
        /// <param name="value">Mảng giá trị kiểu Int</param>
        /// <returns>Trả về mảng giá trị kiểu byte</returns>
        public static byte[] ToByteArray(short[] value)
        {
            var arr = new ByteArray();
            foreach (var val in value)
                arr.Add(ToByteArray(val));
            return arr.array;
        }

        #endregion
    }
}