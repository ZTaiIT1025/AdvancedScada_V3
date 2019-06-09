using HslCommunication;
namespace AdvancedScada.DriverBase
{
    public interface IDriverAdapter
    {
        bool IsConnected { get; set; }
      
        void Connection();

        void Disconnection();

        byte[] BuildReadByte(byte station, string address, ushort length);

        byte[] BuildWriteByte(byte station, string address, byte[] value);

        TValue[] Read<TValue>(string address, ushort length);

        OperateResult<bool[]> ReadDiscrete(string address, ushort length);
        bool  Write(string address, dynamic value);

    }
}
