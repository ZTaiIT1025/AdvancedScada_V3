using AdvancedScada.XLSIS_V2.Core.Comm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedScada.XLSIS_V2.Core.Drivers
{
    public class LSNetBase
    {
        public static LSRequestTyes GetRequestType(IODriverDataTypes dataType)
        {
            switch (dataType)
            {
                case IODriverDataTypes.Bit:
                    return LSRequestTyes.Bit;
                case IODriverDataTypes.Short:
                case IODriverDataTypes.UShort:
                    return LSRequestTyes.Word;
                case IODriverDataTypes.Int:
                case IODriverDataTypes.UInt:
                    return LSRequestTyes.DWord;
                case IODriverDataTypes.Long:
                case IODriverDataTypes.ULong:
                    return LSRequestTyes.LWord;
                case IODriverDataTypes.Float:
                    return LSRequestTyes.DWord;
                case IODriverDataTypes.Double:
                    return LSRequestTyes.LWord;
                default:
                    return LSRequestTyes.Word;
            }
        }
        public static string GetDomainType(LSDomainTypes domainType)
        {
            switch (domainType)
            {
                case LSDomainTypes.I:
                    return "I";
                case LSDomainTypes.Q:
                    return "Q";
                case LSDomainTypes.M:
                    return "M";
                case LSDomainTypes.L:
                    return "L";
                case LSDomainTypes.U:
                    return "U";
                case LSDomainTypes.R:
                    return "R";
                case LSDomainTypes.W:
                    return "W";
                case LSDomainTypes.C:
                    return "C";
                case LSDomainTypes.D:
                    return "D";
                case LSDomainTypes.F:
                    return "F";
                case LSDomainTypes.K:
                    return "K";
                case LSDomainTypes.N:
                    return "N";
                case LSDomainTypes.P:
                    return "P";
                case LSDomainTypes.T:
                    return "T";
                default:
                    return "M";
            }
        }
        public static string GetAddressFormat(string UserDefineFormat, LSDomainTypes LsDomainType, IODriverDataTypes DataType)
        {
            string result = UserDefineFormat ?? "{0}";
            string empty = string.Empty;


            result = "%";
            empty = "{0}";
            switch (LsDomainType)
            {
                case LSDomainTypes.I:
                    result += "I";
                    empty = "{3}.{4}.";
                    break;
                case LSDomainTypes.Q:
                    result += "Q";
                    empty = "{3}.{4}.";
                    break;
                case LSDomainTypes.M:
                    result += "M";
                    empty = "{0}";
                    break;
                case LSDomainTypes.L:
                    result += "L";
                    empty = "{0}";
                    break;
                case LSDomainTypes.U:
                    result += "U";
                    empty = "{3}.{4}.";
                    break;
                case LSDomainTypes.R:
                    result += "R";
                    empty = "{0}";
                    break;
                case LSDomainTypes.W:
                    result += "W";
                    empty = "{0}";
                    break;
                case LSDomainTypes.C:
                    result += "C";
                    empty = "{0}";
                    break;
                case LSDomainTypes.D:
                    result += "D";
                    empty = "{0}";
                    break;
                case LSDomainTypes.F:
                    result += "F";
                    empty = "{0}";
                    break;
                case LSDomainTypes.K:
                    result += "K";
                    empty = "{0}";
                    break;
                case LSDomainTypes.N:
                    result += "N";
                    empty = "{0}";
                    break;
                case LSDomainTypes.P:
                    result += "P";
                    empty = "{0}";
                    break;
                case LSDomainTypes.T:
                    result += "T";
                    empty = "{0}";
                    break;
                default:
                    result += "M";
                    empty = "{0}";
                    break;
            }
            switch (DataType)
            {
                case IODriverDataTypes.BitOnByte:
                    {
                        result += "B";
                        LSDomainTypes lsDomainType = LsDomainType;
                        empty = ((lsDomainType - 1 > LSDomainTypes.I && lsDomainType != LSDomainTypes.U) ? "{1}.{2}" : (empty + "{1}.{2}"));
                        break;
                    }
                case IODriverDataTypes.BitOnWord:
                    {
                        result += "W";
                        LSDomainTypes lsDomainType = LsDomainType;
                        empty = ((lsDomainType - 1 > LSDomainTypes.I && lsDomainType != LSDomainTypes.U) ? "{1}.{2}" : (empty + "{1}.{2}"));
                        break;
                    }
                case IODriverDataTypes.Bit:
                    {
                        result += "X";
                        LSDomainTypes lsDomainType = LsDomainType;
                        if (lsDomainType - 1 <= LSDomainTypes.I || lsDomainType == LSDomainTypes.U)
                        {
                            empty += "{0}";
                        }
                        break;
                    }
                case IODriverDataTypes.Byte:
                case IODriverDataTypes.SByte:
                    {
                        result = (result = "B");
                        LSDomainTypes lsDomainType = LsDomainType;
                        if (lsDomainType - 1 <= LSDomainTypes.I || lsDomainType == LSDomainTypes.U)
                        {
                            empty += "{0}";
                        }
                        break;
                    }
                case IODriverDataTypes.Int:
                case IODriverDataTypes.UInt:
                    {
                        result += "D";
                        LSDomainTypes lsDomainType = LsDomainType;
                        if (lsDomainType - 1 <= LSDomainTypes.I || lsDomainType == LSDomainTypes.U)
                        {
                            empty += "{0}";
                        }
                        break;
                    }
                case IODriverDataTypes.Long:
                case IODriverDataTypes.ULong:
                    {
                        result += "L";
                        LSDomainTypes lsDomainType = LsDomainType;
                        if (lsDomainType - 1 <= LSDomainTypes.I || lsDomainType == LSDomainTypes.U)
                        {
                            empty += "{0}";
                        }
                        break;
                    }
                default:
                    {
                        result += "W";
                        LSDomainTypes lsDomainType = LsDomainType;
                        if (lsDomainType - 1 <= LSDomainTypes.I || lsDomainType == LSDomainTypes.U)
                        {
                            empty += "{0}";
                        }
                        break;
                    }
            }
            result += empty;


            return result;
        }
        public static string GetAddress(IODriverDataTypes dataType, LSDomainTypes domainType, int baseNumber, int slotNumber, int baseAddress)
        {
            string text = string.Empty;
            string text2 = string.Empty;
            switch (dataType)
            {
                case IODriverDataTypes.BitOnByte:
                    text = "B";
                    text2 = ".0";
                    break;
                case IODriverDataTypes.BitOnWord:
                    text = "W";
                    text2 = ".0";
                    break;
                case IODriverDataTypes.Bit:
                    text = "X";
                    break;
                case IODriverDataTypes.Byte:
                    text = "B";
                    break;
                case IODriverDataTypes.Short:
                case IODriverDataTypes.UShort:
                    text = "W";
                    break;
                case IODriverDataTypes.Int:
                case IODriverDataTypes.UInt:
                    text = "D";
                    break;
                case IODriverDataTypes.Long:
                case IODriverDataTypes.ULong:
                    text = "L";
                    break;
                case IODriverDataTypes.Float:
                    text = "D";
                    break;
                case IODriverDataTypes.Double:
                    text = "L";
                    break;
            }
            if (domainType - 1 <= LSDomainTypes.I || domainType == LSDomainTypes.U)
            {
                return $"{text}{baseNumber}.{slotNumber}.{baseAddress}{text2}";
            }
            return $"{text}{baseAddress}{text2}";
        }

        public static ushort GetCount(IODriverDataTypes dataType, int offset, int count)
        {
            switch (dataType)
            {
                case IODriverDataTypes.BitOnByte:
                    {
                        int num = offset * 8;
                        return (ushort)((((num + count >= 17) ? ((num + count) / 16) : 0) + 1) * 2);
                    }
                case IODriverDataTypes.BitOnWord:
                    return (ushort)((((count >= 17) ? (count / 16) : 0) + 1) * 2);
                case IODriverDataTypes.Bit:
                    return (ushort)((((offset + count >= 17) ? ((offset + count) / 16) : 0) + 1) * 2);
                case IODriverDataTypes.Byte:
                    return (ushort)count;
                case IODriverDataTypes.Short:
                case IODriverDataTypes.UShort:
                    return (ushort)(count * 2);
                case IODriverDataTypes.Int:
                case IODriverDataTypes.UInt:
                    return (ushort)(count * 4);
                case IODriverDataTypes.Long:
                case IODriverDataTypes.ULong:
                    return (ushort)(count * 8);
                case IODriverDataTypes.Float:
                    return (ushort)(count * 4);
                case IODriverDataTypes.Double:
                    return (ushort)(count * 8);
                default:
                    return (ushort)(count * 2);
            }
        }

        public Dictionary<ushort, LSRequestMessage> Requests
        {
            get;
            private set;
        }

    }
}