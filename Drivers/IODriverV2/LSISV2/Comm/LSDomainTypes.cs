using System;
using System.Linq;

namespace AdvancedScada.XLSIS_V2.Core.Comm
{
    public enum LSDomainTypes : byte
    {
        I = 1,
        Q = 2,
        M = 3,
        L = 4,
        U = 5,
        R = 6,
        W = 7,
        C = 8,
        D = 9,
        F = 10,
        K = 11,
        N = 12,
        P = 13,
        T = 14,
        ZR = 33,
        Unknown = 0
    }
    public enum LSCommandTypes : byte
    {
        ReqRead = 84,
        RspRead = 85,
        ReqWrite = 88,
        RspWrite = 89,
        ReqReadWithBCC = 114,
        ReqWriteWithBCC = 119
    }
    public enum LSRequestTyes : byte
    {
        Bit = 0,
        Byte = 1,
        Word = 2,
        DWord = 3,
        LWord = 4,
        Consecutive = 20
    }
}
