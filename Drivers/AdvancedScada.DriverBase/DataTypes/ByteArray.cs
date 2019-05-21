using System.Collections.Generic;

namespace AdvancedScada.DriverBase.Core.DataTypes
{
    public class ByteArray
    {
        private List<byte> list = new List<byte>();

        public ByteArray()
        {
            list = new List<byte>();
        }

        public ByteArray(int size)
        {
            list = new List<byte>(size);
        }

        public byte[] array
        {
            get { return list.ToArray(); }
        }

        public void Clear()
        {
            list = new List<byte>();
        }

        public void Add(byte item)
        {
            list.Add(item);
        }

        public void Add(byte[] items)
        {
            list.AddRange(items);
        }
    }
}