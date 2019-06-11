using IODriverV2;

namespace AdvancedScada
{
    public interface IDriverAdapterV2
    {
        bool IsConnected { get; set; }
        void AllSerialPortAdapter(SerialPortAdapter iModbusSerialPortAdapter);
        void AllEthernetAdapter(EthernetAdapter iModbusEthernetAdapter);
        void Connection();
        void Disconnection();
    }
}