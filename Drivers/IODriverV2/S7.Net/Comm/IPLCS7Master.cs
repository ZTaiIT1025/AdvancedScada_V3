using AdvancedScada;
using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Devices;
using S7.Net;

namespace XSiemens.Core.Comm
{
    public delegate void EventConnectionStateChanged(string status);
    public interface IPLCS7Master : IDriverAdapterV2
    {

        object Read(DataType dataType, int db, int startByteAdr, VarType varType, int varCount, byte bitAdr = 0);
        byte[] ReadBytes(DataType dataType, int db, int startByteAdr, int count);
        object ReadStruct(DataBlock structType, int db, int startByteAdr = 0);
        int ReadClass(object sourceClass, int db, int startByteAdr = 0);
        void Write(string variable, object value);
        void WriteString(string variable, object value);
        void WriteBytes(DataType DataType, int DB, int StartByteAdr, byte[] value);

    }
}
