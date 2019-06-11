using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataTypes
{
    public class Word
    {
        #region Chuyển đổi mảng bytes thành kiểu Word.

        /// <summary>
        /// Phương thức chuyển đổi mảng bytes thành kiểu Word.
        /// </summary>
        /// <param name="bytes">Mảng byte cần chuyển đổi</param>
        /// <returns>Trả về giá trị kiểu Word</returns>
        public static UInt16 FromByteArray(byte[] bytes)
        {
            // bytes[0] -> HighByte
            // bytes[1] -> LowByte
            return FromBytes(bytes[1], bytes[0]);
        }        

        /// <summary>
        /// Phương thức chuyển đổi mảng bytes thành kiểu Word.
        /// </summary>
        /// <param name="LoVal">Giá trị byte thấp</param>
        /// <param name="HiVal">Giá trị byte cao</param>
        /// <returns>Trả về giá trị kiểu Word</returns>
        public static UInt16 FromBytes(byte LoVal, byte HiVal)
        {
            return (UInt16)(HiVal * 256 + LoVal);
        }

        #endregion

        #region Chuyển đổi kiểu Word thành mảng bytes.

        /// <summary>
        /// Phương thức chuyển đổi kiểu Word thành mảng bytes.
        /// </summary>
        /// <param name="value">Giá trị kiểu Word</param>
        /// <returns>Trả về giá trị mảng kiểu byte</returns>
        public static byte[] ToByteArray(UInt16 value)
        {
            byte[] array = BitConverter.GetBytes(value);
            Array.Reverse(array);
            return array;
        }

        /// <summary>
        /// Phương thức chuyển đổi mảng kiểu Word thành mảng bytes.
        /// </summary>
        /// <param name="value">Mảng kiểu Word</param>
        /// <returns>Trả về mảng kiểu byte</returns>
        public static byte[] ToByteArray(UInt16[] value)
        {
            ByteArray arr = new ByteArray();
            foreach (UInt16 val in value)
                arr.Add(ToByteArray(val));
            return arr.array;
        }

        /// <summary>
        /// Phương thức chuyển đổi kiểu mảng bytes thành mảng word.
        /// </summary>
        /// <param name="bytes">Giá trị mảng bytes</param>
        /// <returns>Trả về giá trị mảng kiểu Word</returns>
        public static UInt16[] ToArray(byte[] bytes)
        {
            UInt16[] values = new UInt16[bytes.Length / 2];
            int counter = 0;
            for (int cnt = 0; cnt < bytes.Length / 2; cnt++)
                values[cnt] = FromByteArray(new byte[] { bytes[counter++], bytes[counter++] });

            return values;
        }

        #endregion

    }
}
