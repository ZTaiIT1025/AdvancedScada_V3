using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataTypes
{
    public class Real
    {

        #region Chuyển đổi mảng dữ liệu byte thành kiểu dữ liệu float.

        /// <summary>
        /// Phương thức chuyển mảng dữ liệu kiểu byte thành kiểu dữ liệu float. 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns>Trả về giá trị kiểu float.</returns>
        public static float FromByteArray(byte[] bytes)
        {
            Array.Reverse(bytes);
            return BitConverter.ToSingle(bytes, 0);            
        }

        #endregion

        #region Chuyển đổi kiểu dữ liệu DWord thành kiểu dữ liệu float.

        /// <summary>
        /// Phương thức chuyển đổi dữ liệu từ kiểu DWord thành kiểu dữ liệu float.
        /// </summary>
        /// <param name="value">Giá trị kiểu DWord</param>
        /// <returns>Trả về giá trị kiểu float.</returns>
        public static float FromDWord(Int32 value)
        {
            byte[] b = DInt.ToByteArray(value);
            float d = FromByteArray(b);
            return d;
        }

        /// <summary>
        /// Phương thức chuyển đổi dữ liệu từ kiểu DWord thành kiểu dữ liệu float.
        /// </summary>
        /// <param name="value">Giá trị kiểu DWord</param>
        /// <returns>Trả về giá trị kiểu float.</returns>
        public static float FromDWord(UInt32 value)
        {
            byte[] b = DWord.ToByteArray(value);
            float d = FromByteArray(b);
            return d;
        }

        #endregion

        #region Chuyển đổi kiểu dữ liệu float thành mảng dữ liệu kiểu byte.

        /// <summary>
        /// Phương thức chuyển đổi kiểu dữ liệu float thành mảng dữ liệu kiểu byte.
        /// </summary>
        /// <param name="value">Giá trị kiểu float</param>
        /// <returns>Trả về mảng giá trị kiểu byte</returns>
        public static byte[] ToByteArray(float value)
        {
            byte[] array = BitConverter.GetBytes(value);
            Array.Reverse(array);
            return array;
        }

        /// <summary>
        /// Phương thức chuyển đổi mảng dữ liệu kiểu float thành mảng dữ liệu kiểu byte.
        /// </summary>
        /// <param name="value">Mảng giá trị kiểu float</param>
        /// <returns>Trả về mảng giá trị kiểu byte</returns>
        public static byte[] ToByteArray(float[] value)
        {
            ByteArray arr = new ByteArray();
            foreach (float val in value)
                arr.Add(ToByteArray(val));
            return arr.array;
        }

        #endregion

        #region Chuyển đổi mảng dữ liệu kiểu byte thành mảng dữ liệu kiểu float.

        /// <summary>
        /// Phương thức chuyển đổi mảng dữ liệu kiểu byte thành mảng dữ liệu kiểu float.
        /// </summary>
        /// <param name="bytes">Mảng giá trị kiểu byte</param>
        /// <returns>Trả về mảng giá trị kiểu float</returns>
        public static float[] ToArrayInverse(byte[] bytes)
        {
            float[] values = new float[bytes.Length / 4];

            int counter = 0;
            for (int cnt = 0; cnt < bytes.Length / 4; cnt++)
                values[cnt] = FromByteArray(new byte[] { bytes[counter++], bytes[counter++], bytes[counter++], bytes[counter++] });

            return values;
        }

        public static float ToFloat(byte[] bytes)
        {
            if (bytes.Length != 4) throw new FormatException("Size of byte array > 4)");
            Array.Reverse(bytes);
            int size = bytes.Length / 2;            
            for (int i = 0; i < size; i++)
            {
                bytes[i] += bytes[i + size];
                bytes[i + size] = (byte)(bytes[i] - bytes[i + size]);
                bytes[i] = (byte)(bytes[i] - bytes[i + size]);
            }
            return BitConverter.ToSingle(bytes, 0);
        }

        public static float[] ToArray(byte[] bytes)
        {
            int size = 4;
            int idx = 0;
            float[] result = new float[bytes.Length / size];
            do
            {
                byte[] data = new byte[size];
                Array.Copy(bytes, idx, data, 0, data.Length);
                result[idx / size] = ToFloat(data);
                idx += size;
            } while (idx < bytes.Length);
            return result;
        }

        #endregion
                
        #region Chuyển byte thành chuỗi binary.

        /// <summary>
        /// Phương thức chuyển byte thành chuỗi binary.
        /// </summary>
        /// <param name="value">Giá trị kiểu byte</param>
        /// <returns>Trả về chuỗi binary</returns>
        private static string ValToBinString(byte value)
        {
            string txt = "";

            for (int cnt = 7; cnt >= 0; cnt += -1)
            {
                if ((value & (byte)Math.Pow(2, cnt)) > 0)
                    txt += "1";
                else
                    txt += "0";
            }
            return txt;
        }
        #endregion

        #region Chuyển chuỗi binary thành byte.
        
        /// <summary>
        /// Phương thức chuyển đổi chuỗi binary thành kiểu byte
        /// </summary>
        /// <param name="txt">Giá trị là 1 chuỗi binary</param>
        /// <returns>Trả về giá trị kiểu byte</returns>
        private static byte? BinStringToByte(string txt)
        {
            int cnt = 0;
            int ret = 0;

            if (txt.Length == 8)
            {
                for (cnt = 7; cnt >= 0; cnt += -1)
                {
                    if (int.Parse(txt.Substring(cnt, 1)) == 1)
                    {
                        ret += (int)(Math.Pow(2, (txt.Length - 1 - cnt)));
                    }
                }
                return (byte)ret;
            }
            return null;
        }
        #endregion
    }
}
