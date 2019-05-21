using System;

namespace AdvancedScada.DriverBase.Core.DataTypes
{
    public class Real
    {
        #region Chuyển đổi mảng dữ liệu byte thành kiểu dữ liệu float.

        /// <summary>
        ///     Phương thức chuyển mảng dữ liệu kiểu byte thành kiểu dữ liệu float.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns>Trả về giá trị kiểu float.</returns>
        public static float FromByteArray(byte[] bytes)
        {
            Array.Reverse(bytes);
            return BitConverter.ToSingle(bytes, 0);
        }

        #endregion

        #region Chuyển byte thành chuỗi binary.

        /// <summary>
        ///     Phương thức chuyển byte thành chuỗi binary.
        /// </summary>
        /// <param name="value">Giá trị kiểu byte</param>
        /// <returns>Trả về chuỗi binary</returns>
        private static string ValToBinString(byte value)
        {
            var txt = string.Empty;

            for (var cnt = 7; cnt >= 0; cnt += -1)
                if ((value & (byte)Math.Pow(2, cnt)) > 0)
                    txt += "1";
                else
                    txt += "0";
            return txt;
        }

        #endregion

        #region Chuyển chuỗi binary thành byte.

        /// <summary>
        ///     Phương thức chuyển đổi chuỗi binary thành kiểu byte
        /// </summary>
        /// <param name="txt">Giá trị là 1 chuỗi binary</param>
        /// <returns>Trả về giá trị kiểu byte</returns>
        private static byte? BinStringToByte(string txt)
        {
            var cnt = 0;
            var ret = 0;

            if (txt.Length == 8)
            {
                for (cnt = 7; cnt >= 0; cnt += -1)
                    if (int.Parse(txt.Substring(cnt, 1)) == 1)
                        ret += (int)Math.Pow(2, txt.Length - 1 - cnt);
                return (byte)ret;
            }

            return null;
        }

        #endregion

        #region Chuyển đổi kiểu dữ liệu DWord thành kiểu dữ liệu float.

        /// <summary>
        ///     Phương thức chuyển đổi dữ liệu từ kiểu DWord thành kiểu dữ liệu float.
        /// </summary>
        /// <param name="value">Giá trị kiểu DWord</param>
        /// <returns>Trả về giá trị kiểu float.</returns>
        public static float FromDWord(int value)
        {
            var b = DInt.ToByteArray(value);
            var d = FromByteArray(b);
            return d;
        }

        /// <summary>
        ///     Phương thức chuyển đổi dữ liệu từ kiểu DWord thành kiểu dữ liệu float.
        /// </summary>
        /// <param name="value">Giá trị kiểu DWord</param>
        /// <returns>Trả về giá trị kiểu float.</returns>
        public static float FromDWord(uint value)
        {
            var b = DWord.ToByteArray(value);
            var d = FromByteArray(b);
            return d;
        }

        #endregion

        #region Chuyển đổi kiểu dữ liệu float thành mảng dữ liệu kiểu byte.

        /// <summary>
        ///     Phương thức chuyển đổi kiểu dữ liệu float thành mảng dữ liệu kiểu byte.
        /// </summary>
        /// <param name="value">Giá trị kiểu float</param>
        /// <returns>Trả về mảng giá trị kiểu byte</returns>
        public static byte[] ToByteArray(float value)
        {
            var array = BitConverter.GetBytes(value);
            Array.Reverse(array);
            return array;
        }

        /// <summary>
        ///     Phương thức chuyển đổi mảng dữ liệu kiểu float thành mảng dữ liệu kiểu byte.
        /// </summary>
        /// <param name="value">Mảng giá trị kiểu float</param>
        /// <returns>Trả về mảng giá trị kiểu byte</returns>
        public static byte[] ToByteArray(float[] value)
        {
            var arr = new ByteArray();
            foreach (var val in value)
                arr.Add(ToByteArray(val));
            return arr.array;
        }

        #endregion

        #region Chuyển đổi mảng dữ liệu kiểu byte thành mảng dữ liệu kiểu float.

        /// <summary>
        ///     Phương thức chuyển đổi mảng dữ liệu kiểu byte thành mảng dữ liệu kiểu float.
        /// </summary>
        /// <param name="bytes">Mảng giá trị kiểu byte</param>
        /// <returns>Trả về mảng giá trị kiểu float</returns>
        public static float[] ToArrayInverse(byte[] bytes)
        {
            var values = new float[bytes.Length / 4];

            var counter = 0;
            for (var cnt = 0; cnt < bytes.Length / 4; cnt++)
                values[cnt] = FromByteArray(new[]
                    {bytes[counter++], bytes[counter++], bytes[counter++], bytes[counter++]});

            return values;
        }

        public static float ToFloat(byte[] bytes)
        {
            if (bytes.Length != 4) throw new FormatException("Size of byte array > 4)");
            Array.Reverse(bytes);
            var size = bytes.Length / 2;
            for (var i = 0; i < size; i++)
            {
                bytes[i] += bytes[i + size];
                bytes[i + size] = (byte)(bytes[i] - bytes[i + size]);
                bytes[i] = (byte)(bytes[i] - bytes[i + size]);
            }

            return BitConverter.ToSingle(bytes, 0);
        }

        public static float[] ToArray(byte[] bytes)
        {
            var size = 4;
            var idx = 0;
            var result = new float[bytes.Length / size];
            do
            {
                var data = new byte[size];
                Array.Copy(bytes, idx, data, 0, data.Length);
                result[idx / size] = ToFloat(data);
                idx += size;
            } while (idx < bytes.Length);

            return result;
        }

        #endregion
    }
}