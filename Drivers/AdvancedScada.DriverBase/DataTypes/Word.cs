using System;

namespace AdvancedScada.DriverBase.Core.DataTypes
{
    public class Word
    {
        #region Chuyển đổi mảng bytes thành kiểu Word.

        /// <summary>
        ///     Phương thức chuyển đổi mảng bytes thành kiểu Word.
        /// </summary>
        /// <param name="bytes">Mảng byte cần chuyển đổi</param>
        /// <returns>Trả về giá trị kiểu Word</returns>
        public static ushort FromByteArray(byte[] bytes)
        {
            // bytes[0] -> HighByte
            // bytes[1] -> LowByte
            return FromBytes(bytes[1], bytes[0]);
        }

        /// <summary>
        ///     Phương thức chuyển đổi mảng bytes thành kiểu Word.
        /// </summary>
        /// <param name="LoVal">Giá trị byte thấp</param>
        /// <param name="HiVal">Giá trị byte cao</param>
        /// <returns>Trả về giá trị kiểu Word</returns>
        public static ushort FromBytes(byte LoVal, byte HiVal)
        {
            return (ushort)(HiVal * 256 + LoVal);
        }

        #endregion

        #region Chuyển đổi kiểu Word thành mảng bytes.

        /// <summary>
        ///     Phương thức chuyển đổi kiểu Word thành mảng bytes.
        /// </summary>
        /// <param name="value">Giá trị kiểu Word</param>
        /// <returns>Trả về giá trị mảng kiểu byte</returns>
        public static byte[] ToByteArray(ushort value)
        {
            var array = BitConverter.GetBytes(value);
            Array.Reverse(array);
            return array;
        }

        /// <summary>
        ///     Phương thức chuyển đổi mảng kiểu Word thành mảng bytes.
        /// </summary>
        /// <param name="value">Mảng kiểu Word</param>
        /// <returns>Trả về mảng kiểu byte</returns>
        public static byte[] ToByteArray(ushort[] value)
        {
            var arr = new ByteArray();
            foreach (var val in value)
                arr.Add(ToByteArray(val));
            return arr.array;
        }

        /// <summary>
        ///     Phương thức chuyển đổi kiểu mảng bytes thành mảng word.
        /// </summary>
        /// <param name="bytes">Giá trị mảng bytes</param>
        /// <returns>Trả về giá trị mảng kiểu Word</returns>
        public static ushort[] ToArray(byte[] bytes)
        {
            var values = new ushort[bytes.Length / 2];
            var counter = 0;
            for (var cnt = 0; cnt < bytes.Length / 2; cnt++)
                values[cnt] = FromByteArray(new[] { bytes[counter++], bytes[counter++] });

            return values;
        }

        #endregion
    }
}