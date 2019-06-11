using AdvancedScada.XLSIS_V2.Core.Comm;
using System;
using System.Linq;
using System.Text;

namespace AdvancedScada.XLSIS_V2.Core.Drivers
{
    public class LSResponseMessage : PLCResponseMessage
    {
        private const string _X = "X";

        private const string _B = "B";

        private const string _W = "W";

        private const string _D = "D";

        private const string _L = "L";

        private static readonly byte[] _BIT_MASTS = new byte[8]
        {
        1,
        2,
        4,
        8,
        16,
        32,
        64,
        128
        };

        public LSRequestTyes OriginRequestType
        {
            get;
            private set;
        }

        public IODriverDataTypes OriginDataType
        {
            get;
            private set;
        }

        public string OriginAddress
        {
            get;
            private set;
        }

        public string DomainType
        {
            get;
            protected set;
        }

        public string DataType
        {
            get;
            private set;
        }

        public string Address
        {
            get;
            private set;
        }

        public int[] Addresses
        {
            get;
            private set;
        }

        public string RequestDomainType
        {
            get;
            private set;
        }

        public string RequestDataType
        {
            get;
            private set;
        }

        public string RequestAddress
        {
            get;
            private set;
        }

        public int[] RequestAddresses
        {
            get;
            private set;
        }

        internal LSResponseMessage(PLCMessageTypes messageType, LSRequestMessage source, byte[] data)
            : base(messageType, source.UniqueId)
        {
            OriginRequestType = source.RequestType;
            OriginDataType = source.DataType;
            OriginAddress = source.OriginAddress;
            DomainType = OriginAddress.Substring(1, 1);
            DataType = OriginAddress?.Substring(2, 1);
            Address = OriginAddress?.Remove(0, 3);
            Addresses = (from i in Address?.Split('.')
                         select int.Parse(i)).ToArray();
            RequestDomainType = source.RequestAddress.Substring(1, 1);
            RequestDataType = source.RequestAddress.Substring(2, 1);
            RequestAddress = source.RequestAddress.Remove(0, 3);
            RequestAddresses = (from i in RequestAddress?.Split('.')
                                select int.Parse(i)).ToArray();
            switch (messageType)
            {
                case PLCMessageTypes.Ascii:
                    _SetAscii(data);
                    break;
                case PLCMessageTypes.Binary:
                    _SetBinary(data);
                    break;
            }
        }

        private void _SetAscii(byte[] data)
        {
            try
            {
                int num = 0;
                Convert.ToUInt32(Encoding.ASCII.GetString(data, num, 2), 16);
                num += 2;
                LSRequestTyes originRequestType = OriginRequestType;
                if (originRequestType == LSRequestTyes.Consecutive)
                {
                    ushort num2 = (ushort)(Convert.ToUInt16(Encoding.ASCII.GetString(data, num, 2), 16) * 2);
                    num += 2;
                    string @string = Encoding.ASCII.GetString(data, num, num2);
                    string requestDataType = RequestDataType;
                    switch (requestDataType)
                    {
                        default:
                            if (requestDataType == "L")
                            {
                                switch (OriginDataType)
                                {
                                    case IODriverDataTypes.Float:
                                        break;
                                    case IODriverDataTypes.Long:
                                        for (int num7 = 0; num7 < num2; num7 += 16)
                                        {
                                            base.Values.Add(Convert.ToInt64(@string.Substring(num7, 16), 16));
                                        }
                                        break;
                                    case IODriverDataTypes.ULong:
                                        for (int num8 = 0; num8 < num2; num8 += 16)
                                        {
                                            base.Values.Add(Convert.ToUInt64(@string.Substring(num8, 16), 16));
                                        }
                                        break;
                                    case IODriverDataTypes.Double:
                                        for (int num6 = 0; num6 < @string.Length; num6 += 16)
                                        {
                                            base.Values.Add(BitConverter.ToSingle(new byte[8]
                                            {
                                    Convert.ToByte(@string.Substring(num6, 2), 16),
                                    Convert.ToByte(@string.Substring(num6 + 2, 2), 16),
                                    Convert.ToByte(@string.Substring(num6 + 4, 2), 16),
                                    Convert.ToByte(@string.Substring(num6 + 6, 2), 16),
                                    Convert.ToByte(@string.Substring(num6 + 8, 2), 16),
                                    Convert.ToByte(@string.Substring(num6 + 10, 2), 16),
                                    Convert.ToByte(@string.Substring(num6 + 12, 2), 16),
                                    Convert.ToByte(@string.Substring(num6 + 14, 2), 16)
                                            }, 0));
                                        }
                                        break;
                                }
                            }
                            break;
                        case "B":
                            switch (OriginDataType)
                            {
                                case IODriverDataTypes.Bit:
                                case IODriverDataTypes.BitOnByte:
                                case IODriverDataTypes.BitOnWord:
                                    for (int num3 = 0; num3 < num2; num3 += 4)
                                    {
                                        byte b = Convert.ToByte(@string.Substring(num3, 2), 16);
                                        byte b2 = Convert.ToByte(@string.Substring(num3 + 2, 2), 16);
                                        for (int num4 = 0; num4 < 8; num4++)
                                        {
                                            base.Values.Add(((_BIT_MASTS[num4] & b) == _BIT_MASTS[num4]) ? 1 : 0);
                                        }
                                        for (int num5 = 0; num5 < 8; num5++)
                                        {
                                            base.Values.Add(((_BIT_MASTS[num5] & b2) == _BIT_MASTS[num5]) ? 1 : 0);
                                        }
                                    }
                                    break;
                                case IODriverDataTypes.Byte:
                                    for (int n = 0; n < num2; n += 2)
                                    {
                                        base.Values.Add((int)Convert.ToByte(@string.Substring(n, 2), 16));
                                    }
                                    break;
                            }
                            break;
                        case "W":
                            switch (OriginDataType)
                            {
                                case IODriverDataTypes.Short:
                                    for (int m = 0; m < num2; m += 4)
                                    {
                                        base.Values.Add(Convert.ToInt16(@string.Substring(m, 4), 16));
                                    }
                                    break;
                                case IODriverDataTypes.UShort:
                                    for (int l = 0; l < num2; l += 4)
                                    {
                                        base.Values.Add((int)Convert.ToUInt16(@string.Substring(l, 4), 16));
                                    }
                                    break;
                            }
                            break;
                        case "D":
                            switch (OriginDataType)
                            {
                                case IODriverDataTypes.Long:
                                case IODriverDataTypes.ULong:
                                    break;
                                case IODriverDataTypes.Int:
                                    for (int j = 0; j < num2; j += 8)
                                    {
                                        base.Values.Add(Convert.ToInt16(@string.Substring(j, 8), 16));
                                    }
                                    break;
                                case IODriverDataTypes.UInt:
                                    for (int k = 0; k < num2; k += 8)
                                    {
                                        base.Values.Add(Convert.ToUInt64(@string.Substring(k, 8), 16));
                                    }
                                    break;
                                case IODriverDataTypes.Float:
                                    for (int i = 0; i < @string.Length; i += 8)
                                    {
                                        base.Values.Add(BitConverter.ToSingle(new byte[4]
                                        {
                                Convert.ToByte(@string.Substring(i, 2), 16),
                                Convert.ToByte(@string.Substring(i + 2, 2), 16),
                                Convert.ToByte(@string.Substring(i + 4, 2), 16),
                                Convert.ToByte(@string.Substring(i + 6, 2), 16)
                                        }, 0));
                                    }
                                    break;
                            }
                            break;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void _SetBinary(byte[] data)
        {
            try
            {
                int num = 0;
                BitConverter.ToUInt16(data, num);
                num += 2;
                LSRequestTyes originRequestType = OriginRequestType;
                if (originRequestType == LSRequestTyes.Consecutive)
                {
                    ushort num2 = BitConverter.ToUInt16(data, num);
                    num += 2;
                    string requestDataType = RequestDataType;
                    if (requestDataType == "B")
                    {
                        switch (OriginDataType)
                        {
                            case IODriverDataTypes.Bit:
                            case IODriverDataTypes.BitOnByte:
                            case IODriverDataTypes.BitOnWord:
                                for (int l = 0; l < num2; l += 2)
                                {
                                    for (int m = 0; m < 8; m++)
                                    {
                                        base.Values.Add(((_BIT_MASTS[m] & data[num + l]) == _BIT_MASTS[m]) ? 1 : 0);
                                    }
                                    for (int n = 0; n < 8; n++)
                                    {
                                        base.Values.Add(((_BIT_MASTS[n] & data[num + l + 1]) == _BIT_MASTS[n]) ? 1 : 0);
                                    }
                                }
                                break;
                            case IODriverDataTypes.Byte:
                                for (int num6 = 0; num6 < num2; num6++)
                                {
                                    base.Values.Add((int)data[num + num6]);
                                }
                                break;
                            case IODriverDataTypes.Short:
                                for (int num8 = 0; num8 < num2; num8 += 2)
                                {
                                    base.Values.Add(BitConverter.ToInt16(data, num + num8));
                                }
                                break;
                            case IODriverDataTypes.UShort:
                                for (int num4 = 0; num4 < num2; num4 += 2)
                                {
                                    base.Values.Add((int)BitConverter.ToUInt16(data, num + num4));
                                }
                                break;
                            case IODriverDataTypes.Int:
                                for (int j = 0; j < num2; j += 4)
                                {
                                    base.Values.Add(BitConverter.ToInt32(data, num + j));
                                }
                                break;
                            case IODriverDataTypes.UInt:
                                for (int num7 = 0; num7 < num2; num7 += 4)
                                {
                                    base.Values.Add(BitConverter.ToUInt32(data, num + num7));
                                }
                                break;
                            case IODriverDataTypes.Float:
                                for (int num5 = 0; num5 < num2; num5 += 4)
                                {
                                    base.Values.Add(BitConverter.ToSingle(data, num + num5));
                                }
                                break;
                            case IODriverDataTypes.Long:
                                for (int num3 = 0; num3 < num2; num3 += 8)
                                {
                                    base.Values.Add(BitConverter.ToInt64(data, num + num3));
                                }
                                break;
                            case IODriverDataTypes.ULong:
                                for (int k = 0; k < num2; k += 8)
                                {
                                    base.Values.Add(BitConverter.ToUInt64(data, num + k));
                                }
                                break;
                            case IODriverDataTypes.Double:
                                for (int i = 0; i < num2; i += 8)
                                {
                                    base.Values.Add(BitConverter.ToDouble(data, num + i));
                                }
                                break;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private string _GetBitOnByteAddress(int origin, int request, int index)
        {
            if (origin <= request + index / 8)
            {
                return $"{origin}.{index - (origin - request) * 8}";
            }
            return $"{request}.{index}";
        }

        private string _GetBitOnWordAddress(int origin, int request, int index)
        {
            return $"{origin}.{index}";
        }

        public override string GetAddressName(int index)
        {
            LSRequestTyes originRequestType = OriginRequestType;
            switch (DomainType)
            {
                case "I":
                case "Q":
                case "U":
                    Address.Split('.');
                    switch (OriginDataType)
                    {
                        case IODriverDataTypes.BitOnByte:
                            return $"%{DomainType}{DataType}{Addresses[0]}.{Addresses[1]}." + _GetBitOnByteAddress(Addresses[2], RequestAddresses[2], index);
                        case IODriverDataTypes.BitOnWord:
                            return $"%{DomainType}{DataType}{Addresses[0]}.{Addresses[1]}.{Addresses[2]}.{index}";
                        default:
                            return $"%{DomainType}{DataType}{Addresses[0]}.{Addresses[1]}.{Addresses[2] + index}";
                    }
                default:
                    switch (OriginDataType)
                    {
                        case IODriverDataTypes.BitOnByte:
                            return "%" + DomainType + DataType + _GetBitOnByteAddress(Addresses[0], RequestAddresses[0], index);
                        case IODriverDataTypes.BitOnWord:
                            return $"%{DomainType}{DataType}{Addresses[0]}.{index}";
                        default:
                            return $"%{DomainType}{DataType}{int.Parse(Address) + index}";
                    }
            }
        }
    }
}
