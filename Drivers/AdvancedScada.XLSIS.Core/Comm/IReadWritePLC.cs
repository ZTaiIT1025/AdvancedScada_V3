using AdvancedScada.DriverBase;
using HslCommunication;

namespace AdvancedScada.XLSIS.Core.Comm
{
   
    public interface IReadWritePLC : IDriverAdapter
    {

        byte[] BuildReadByte(byte station, string address, ushort length);

        byte[] BuildWriteByte(byte station, string address, byte[] value);

        new bool Write(string address, dynamic value);
    }

}
