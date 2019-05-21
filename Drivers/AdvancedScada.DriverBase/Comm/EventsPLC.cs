using System;
using System.Linq;

namespace AdvancedScada.DriverBase.Comm
{
    public delegate void EventReceptionChanged(string Type, string Result, byte[] db);
    //public delegate void EventSDataChanged(string Type, string Result, string[] db);
    //public delegate void EventbDataChanged(string Type, string Result, bool[] db);
    public delegate void EventTransmissionChanged(string Type, string Result, string db);
}
