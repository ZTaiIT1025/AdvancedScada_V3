using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Devices;

namespace AdvancedScada.XSiemens_V2.Core.Comm
{
    public delegate void EventConnectionStateChanged(string status);
    public interface IPLCS7Master : IDriverAdapterV2
    {

        object ReadStruct(DataBlock structType, int db, int startByteAdr = 0);

        void Write(string input, string varType, object value);



    }
}
