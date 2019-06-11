using AdvancedScada.DriverBase;

namespace AdvancedScada.XDelta.Core.Comm
{
    public delegate void EventConnectionStateChanged(string status);

    public interface IDVPMaster : IDriverAdapterV2
    {


        byte[] ReadCoilStatus(byte slaveAddress, string startAddress, ushort nuMBErOfPoints);

        byte[] ReadInputStatus(byte slaveAddress, string startAddress, ushort nuMBErOfPoints);

        byte[] ReadHoldingRegisters(byte slaveAddress, string startAddress, ushort nuMBErOfPoints);

        byte[] ReadInputRegisters(byte slaveAddress, string startAddress, ushort nuMBErOfPoints);

        byte[] WriteSingleCoil(byte slaveAddress, string startAddress, bool value);

        byte[] WriteMultipleCoils(byte slaveAddress, string startAddress, bool[] values);

        byte[] WriteSingleRegister(byte slaveAddress, string startAddress, byte[] values);

        byte[] WriteMultipleRegisters(byte slaveAddress, string startAddress, byte[] values);
    }
}