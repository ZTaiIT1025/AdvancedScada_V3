using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Devices;
using System;
using System.Linq;

namespace AdvancedScada.XLSIS_V2.Core.Comm
{
    public interface IPLC_LS_Master : IDriverAdapterV2
    {


        byte[] BeginRead(Channel ch, Device dv, DataBlock db);

        bool BeginWrite(Channel ch, Device dv, Tag variable, string value);



    }
}
