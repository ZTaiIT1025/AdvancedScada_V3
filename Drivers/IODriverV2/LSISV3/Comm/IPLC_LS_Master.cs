using AdvancedScada.DriverBase;

namespace AdvancedScada.XLSIS.Core.Comm
{
    public delegate void EventConnectionStateChanged(string status);
    public interface IPLC_LS_Master : IDriverAdapterV2
    {


        byte[] BeginRead(int station, string type, int strVar, int numberOfElements, string DataBlockName);

        bool BeginWrite(int station, string variable, int numberOfElements, string value);

    }

}
