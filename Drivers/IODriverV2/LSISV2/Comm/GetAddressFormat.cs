using System;
using System.Linq;

namespace AdvancedScada.XLSIS_V2.Core.Comm
{
    public class GetAddressFormat
    {
        public static string LSGetAddressFormat(string UserDefineFormat, LSDomainTypes LsDomainType, IODriverDataTypes DataType)
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
    }
}
