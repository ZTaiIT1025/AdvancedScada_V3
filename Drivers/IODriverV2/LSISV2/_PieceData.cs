using AdvancedScada.XLSIS_V2.Core.Comm;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedScada.XLSIS_V2.Core.Drivers
{
    public class _PieceData
    {
        public string Address
        {
            get;
            private set;
        }

        public IODriverDataTypes DataType
        {
            get;
            private set;
        }

        public double Value
        {
            get;
            private set;
        }

        public byte[] GetAsciiBytesWithoutValue => Encoding.ASCII.GetBytes($"{Address.Length:X2}{Address}");

        public byte[] GetAsciiBytes
        {
            get
            {
                List<byte> list = new List<byte>(16);
                list.AddRange(GetAsciiBytesWithoutValue);
                switch (DataType)
                {
                    case IODriverDataTypes.Bit:
                    case IODriverDataTypes.BitOnByte:
                    case IODriverDataTypes.BitOnWord:
                        list.AddRange(Encoding.ASCII.GetBytes($"{(ushort)Value:X2}"));
                        break;
                    case IODriverDataTypes.Short:
                        list.AddRange(Encoding.ASCII.GetBytes($"{(short)Value:X4}"));
                        break;
                    case IODriverDataTypes.UShort:
                        list.AddRange(Encoding.ASCII.GetBytes($"{(ushort)Value:X4}"));
                        break;
                    case IODriverDataTypes.Int:
                        list.AddRange(Encoding.ASCII.GetBytes($"{(int)Value:X8}"));
                        break;
                    case IODriverDataTypes.UInt:
                        list.AddRange(Encoding.ASCII.GetBytes($"{(uint)Value:X8}"));
                        break;
                    case IODriverDataTypes.Long:
                        list.AddRange(Encoding.ASCII.GetBytes($"{(long)Value:X16}"));
                        break;
                    case IODriverDataTypes.ULong:
                        list.AddRange(Encoding.ASCII.GetBytes($"{(ulong)Value:X16}"));
                        break;
                    case IODriverDataTypes.Float:
                        list.AddRange(Encoding.ASCII.GetBytes($"{(float)Value:X8}"));
                        break;
                    case IODriverDataTypes.Double:
                        list.AddRange(Encoding.ASCII.GetBytes($"{Value:X16}"));
                        break;
                }
                return list.ToArray();
            }
        }

        public byte[] GetBinaryBytesWithoutValue
        {
            get
            {
                List<byte> list = new List<byte>(16);
                list.AddRange(BitConverter.GetBytes((ushort)Encoding.ASCII.GetByteCount(Address)));
                list.AddRange(Encoding.ASCII.GetBytes(Address));
                return list.ToArray();
            }
        }

        public byte[] GetBinaryBytes
        {
            get
            {
                List<byte> list = new List<byte>(16);
                list.AddRange(GetBinaryBytesWithoutValue);
                switch (DataType)
                {
                    case IODriverDataTypes.Bit:
                    case IODriverDataTypes.Byte:
                    case IODriverDataTypes.BitOnByte:
                    case IODriverDataTypes.BitOnWord:
                        list.AddRange(BitConverter.GetBytes((ushort)1));
                        list.AddRange(new byte[1]
                        {
                    (byte)Value
                        });
                        break;
                    case IODriverDataTypes.Short:
                        list.AddRange(BitConverter.GetBytes((ushort)2));
                        list.AddRange(BitConverter.GetBytes((short)Value));
                        break;
                    case IODriverDataTypes.UShort:
                        list.AddRange(BitConverter.GetBytes((ushort)2));
                        list.AddRange(BitConverter.GetBytes((ushort)Value));
                        break;
                    case IODriverDataTypes.Int:
                        list.AddRange(BitConverter.GetBytes((ushort)4));
                        list.AddRange(BitConverter.GetBytes((int)Value));
                        break;
                    case IODriverDataTypes.UInt:
                        list.AddRange(BitConverter.GetBytes((ushort)4));
                        list.AddRange(BitConverter.GetBytes((uint)Value));
                        break;
                    case IODriverDataTypes.Long:
                        list.AddRange(BitConverter.GetBytes((ushort)8));
                        list.AddRange(BitConverter.GetBytes((long)Value));
                        break;
                    case IODriverDataTypes.ULong:
                        list.AddRange(BitConverter.GetBytes((ushort)8));
                        list.AddRange(BitConverter.GetBytes((ulong)Value));
                        break;
                    case IODriverDataTypes.Float:
                        list.AddRange(BitConverter.GetBytes((ushort)4));
                        list.AddRange(BitConverter.GetBytes((float)Value));
                        break;
                    case IODriverDataTypes.Double:
                        list.AddRange(BitConverter.GetBytes((ushort)8));
                        list.AddRange(BitConverter.GetBytes(Value));
                        break;
                }
                return list.ToArray();
            }
        }

        private _PieceData()
        {
        }

        public _PieceData(string address, IODriverDataTypes dataType, double value)
            : this()
        {
            Address = address;
            DataType = dataType;
            Value = value;
        }
    }
}