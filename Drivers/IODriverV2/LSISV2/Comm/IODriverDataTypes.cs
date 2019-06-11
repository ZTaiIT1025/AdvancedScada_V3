using System;
using System.Linq;

namespace AdvancedScada.XLSIS_V2.Core.Comm
{
    public enum PLCMessageTypes : byte
    {
        None = 0,
        Ascii = 1,
        Binary = 2,
        Write = 3,
        Complete = 0x80,
        Continue = 129,
        Error = 224
    }
    public enum IODriverDataTypes : byte
    {
        Bit = 17,
        Byte = 18,
        SByte = 19,
        Short = 20,
        UShort = 21,
        Int = 22,
        UInt = 23,
        Long = 24,
        ULong = 25,
        Float = 26,
        Double = 27,
        String = 28,
        Post = 161,
        BitOnByte = 177,
        BitOnWord = 178
    }
}
