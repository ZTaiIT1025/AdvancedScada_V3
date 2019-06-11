using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DataTypes
{
    public static class Conversion
    {
        public static byte[] HexToBytes(string hex)
        {
            if (hex == null)
                throw new ArgumentNullException("The data is null");

            if (hex.Length % 2 != 0)
                throw new FormatException("Hex Character Count Not Even");

            byte[] bytes = new byte[hex.Length / 2];

            for (int i = 0; i < bytes.Length; i++)
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);

            return bytes;
        }
        public static double ToDoubleInver(byte[] value)
        {
            return BitConverter.ToDouble(value, 0);
        }

        public static double[] ToDoubleInverses(byte[] values)
        {
            Array.Reverse(values);
            double[] result = new double[values.Length / 8];
            for (int i = 0; i < values.Length; i += 8)
            {
                result[i / 8] = BitConverter.ToDouble(values, i);                
            }
            Array.Reverse(result);
            return result;
        }

        public static double ToDouble(byte[] bytes)
        {
            Array.Reverse(bytes);
            int length = bytes.Length / 8;
            int size = 2;
            for (int i = 0; i < length; i++)
            {
                bytes[i] += bytes[i + size];
                bytes[i + size] = (byte)(bytes[i] - bytes[i + size]);
                bytes[i] = (byte)(bytes[i] - bytes[i + size]);
            }
            return BitConverter.ToDouble(bytes, 0);
        }

        public static double[] ToDoubles(byte[] bytes)
        {
            int size = 8;
            int idx = 0;
            double[] result = new double[bytes.Length / size];                        
            do
            {
                byte[] data = new byte[8];
                Array.Copy(bytes, idx, data, 0, data.Length);
                result[idx / size] = ToDouble(data);
                idx += size;
            } while (idx < bytes.Length);
            return result;
        }

        public static long ToLong(byte[] value)
        {
            Array.Reverse(value);
            return BitConverter.ToInt64(value, 0);
        }

        public static long[] ToLongs(byte[] values)
        {
            Array.Reverse(values);
            long[] result = new long[values.Length / 8];
            for (int i = 0; i < values.Length; i += 8)
            {
                result[i / 8] = BitConverter.ToInt64(values, i);
            }
            Array.Reverse(result);
            return result;
        }
    }
}
