using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace AdvancedScada.Utils.Compression
{
    public class ImageCompression
    {
        public static byte[] Compress(byte[] bytes)
        {
            byte[] result = null;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                using (GZipStream g = new GZipStream(ms, CompressionMode.Compress, true))
                {
                    g.Write(bytes, 0, bytes.Length);
                }
                result = ms.ToArray();
            }
            return result;
        }
        public static byte[] DecompressString(byte[] data)
        {
            using (var compressedStream = new MemoryStream(data))
            using (var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
            using (var resultStream = new MemoryStream())
            {
                zipStream.CopyTo(resultStream);
                return resultStream.ToArray();
            }
        }
        public static byte[] ImageToByte(Image image)
        {
            return (byte[])(new ImageConverter()).ConvertTo(image, typeof(byte[]));
        }
    }
}
