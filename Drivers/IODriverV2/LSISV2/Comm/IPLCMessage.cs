using AdvancedScada.XLSIS_V2.Core.Drivers;
using System;
using System.Linq;

namespace AdvancedScada.XLSIS_V2.Core.Comm
{
    public interface IPLCMessage
    {
        PLCResponseMessage CheckAsciiData(byte[] data);

        PLCResponseMessage CheckBinaryData(byte[] data);
    }
}
