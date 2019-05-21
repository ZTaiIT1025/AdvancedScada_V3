using AdvancedScada.DriverBase.Devices;

namespace AdvancedScada.Management
{
    public delegate void EventSelectedDriversChanged(bool isNew);
    public delegate void EventChannelChanged(Channel ch, bool isNew);
    public delegate void EventDeviceChanged(Device dv, bool isNew);
    public delegate void EventDataBlockChanged(DataBlock db, bool IsNew);
    public delegate void EventTagChanged(Tag tg, bool isNew);
}