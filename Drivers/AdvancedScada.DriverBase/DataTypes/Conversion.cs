using System;

namespace AdvancedScada.DriverBase.Core.DataTypes
{
    public static class Conversion
    {
        public static double ToDoubleInver(byte[] value)
        {
            return BitConverter.ToDouble(value, 0);
        }

        public static double[] ToDoubleInverses(byte[] values)
        {
            Array.Reverse(values);
            var result = new double[values.Length / 8];
            for (var i = 0; i < values.Length; i += 8) result[i / 8] = BitConverter.ToDouble(values, i);
            Array.Reverse(result);
            return result;
        }

        public static double ToDouble(byte[] bytes)
        {
            Array.Reverse(bytes);
            var length = bytes.Length / 8;
            var size = 2;
            for (var i = 0; i < length; i++)
            {
                bytes[i] += bytes[i + size];
                bytes[i + size] = (byte)(bytes[i] - bytes[i + size]);
                bytes[i] = (byte)(bytes[i] - bytes[i + size]);
            }

            return BitConverter.ToDouble(bytes, 0);
        }

        public static double[] ToDoubles(byte[] bytes)
        {
            var size = 8;
            var idx = 0;
            var result = new double[bytes.Length / size];
            do
            {
                var data = new byte[8];
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
            var result = new long[values.Length / 8];
            for (var i = 0; i < values.Length; i += 8) result[i / 8] = BitConverter.ToInt64(values, i);
            Array.Reverse(result);
            return result;
        }
    }
}