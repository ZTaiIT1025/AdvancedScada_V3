using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataTypes
{
    public class DWord
    {

        #region Chuyển đổi mảng bytes thành kiểu DWord.

        /// <summary>
        /// Phương thức chuyển đổi mảng bytes thành DWord.
        /// </summary>
        /// <param name="bytes">Mảng bytes</param>
        /// <returns>Giá trị kiểu DWord</returns>
        public static UInt32 FromByteArray(byte[] bytes)
        {
            Array.Reverse(bytes);
            return BitConverter.ToUInt32(bytes, 0);
        }

        /// <summary>
        /// Phương thức chuyển đổi mảng bytes thành DWord.
        /// </summary>
        /// <param name="param1">byte thứ 1</param>
        /// <param name="param2">byte thứ 2</param>
        /// <param name="param3">byte thứ 3</param>
        /// <param name="param4">byte thứ 4</param>
        /// <returns>Giá trị kiểu DWord</returns>
        public static UInt32 FromBytes(byte param1, byte param2, byte param3, byte param4)
        {
            byte[] bytes = new byte[]{param1, param2, param3, param4};
            return BitConverter.ToUInt32(bytes, 0);            
        }

        /// <summary>
        /// Phương thức chuyển đổi mảng bytes thành DWord.
        /// </summary>
        /// <param name="bytes">Mảng bytes</param>
        /// <returns>Giá trị kiểu DWord</returns>
        public static UInt32[] ToArray(byte[] bytes)
        {
            UInt32[] values = new UInt32[bytes.Length / 4];
            int counter = 0;
            for (int cnt = 0; cnt < bytes.Length / 4; cnt++)
                values[cnt] = FromByteArray(new byte[] { bytes[counter++], bytes[counter++], bytes[counter++], bytes[counter++] });
            return values;
        }

        #endregion

        #region Chuyển đổi kiểu DWord thành mảng bytes.

        /// <summary>
        /// Phương thức chuyển đổi kiểu DWord thành mảng bytes.
        /// </summary>
        /// <param name="value">DWord cần chuyển</param>
        /// <returns>Mảng bytes</returns>
        public static byte[] ToByteArray(UInt32 value)
        {
            byte[] byteArray = BitConverter.GetBytes(value);
            Array.Reverse(byteArray);
            return byteArray;
        }

        /// <summary>
        /// Phương thức chuyển đổi kiểu DWord thành mảng bytes.
        /// </summary>
        /// <param name="value">DWord cần chuyển</param>
        /// <returns>Mảng bytes</returns>
        public static byte[] ToByteArray(UInt32[] value)
        {
            ByteArray arr = new ByteArray();
            foreach (UInt32 val in value)
                arr.Add(ToByteArray(val));
            return arr.array;
        }
        
        #endregion
    }
}
