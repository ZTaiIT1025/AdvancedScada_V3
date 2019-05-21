using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Devices;
using HslCommunication;

namespace XSiemens.Core.Comm
{
     public interface IPLCS7Master : IDriverAdapter
    {

       

        new bool Write(string address, dynamic value);

    }
}
