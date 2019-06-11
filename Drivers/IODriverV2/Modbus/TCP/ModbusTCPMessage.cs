using AdvancedScada.XModbus.Core.Comm;
using Core.DataTypes;
using System;

namespace AdvancedScada.XModbus.Core.TCP
{
    public class ModbusTCPMessage : BaseMessage
    {


        #region Ethernet.

        private byte[] Read(ushort id, byte slaveAddress, ushort startAddress, byte functionCode, uint nuMBErOfPoints)
        {
            var data = new byte[12];
            data[0] = (byte)(id >> 8); // Slave id high byte
            data[1] = (byte)id; // Slave id low byte
            data[5] = 6; // Message size
            data[6] = slaveAddress; // Slave address
            data[7] = functionCode; // Function code            
            data[8] = (byte)(startAddress >> 8); // Start address
            data[9] = (byte)startAddress; // Start address            
            data[10] = (byte)(nuMBErOfPoints >> 8); // NuMBEr of data to read
            data[11] = (byte)nuMBErOfPoints; // NuMBEr of data to read
            return data;
        }

        private byte[] Write(ushort id, byte slaveAddress, ushort startAddress, byte functionCode, byte[] values)
        {
            var size = values.Length;
            var frame = new byte[10 + size];
            frame[0] = (byte)(id >> 8); // Slave id high byte
            frame[1] = (byte)id; // Slave id low byte
            frame[5] = (byte)(4 + size); // Message size
            frame[6] = slaveAddress; // Slave address
            frame[7] = functionCode; // Function code            
            frame[8] = (byte)(startAddress >> 8); // Start address
            frame[9] = (byte)startAddress; // Start address 
            Array.Copy(values, 0, frame, 10, size);
            return frame;
        }

        private byte[] WriteAll(ushort id, byte slaveAddress, ushort startAddress, byte functionCode, byte[] values)
        {
            var size = values.Length;
            var frame = new byte[13 + size];
            frame[0] = (byte)(id >> 8); // Slave id high byte
            frame[1] = (byte)id; // Slave id low byte
            frame[5] = (byte)(7 + size); // Message size
            frame[6] = slaveAddress; // Slave address
            frame[7] = functionCode; // Function code            
            frame[8] = (byte)(startAddress >> 8); // Start address
            frame[9] = (byte)startAddress; // Start address  
            var amount = functionCode == FUNCTION_15 ? (ushort)(size * 8) : (ushort)(size / 2);
            frame[10] = (byte)(amount >> 8); // Số bit của byte thấp cần ghi xuống slave.
            frame[11] = (byte)amount; // Số bit của byte cao cần ghi xuống slave.
            frame[12] = (byte)size;
            Array.Copy(values, 0, frame, 13, size);
            return frame;
        }

        #endregion

        #region Functions.

        protected byte[] ReadCoilStatusMessage(byte slaveAddress, string startAddress, ushort nuMBErOfPoints)
        {
            return Read(FUNCTION_01, slaveAddress, ushort.Parse(startAddress), FUNCTION_01, nuMBErOfPoints);
        }

        protected byte[] ReadInputStatusMessage(byte slaveAddress, string startAddress, ushort nuMBErOfPoints)
        {
            return Read(FUNCTION_02, slaveAddress, ushort.Parse(startAddress), FUNCTION_02, nuMBErOfPoints);
        }

        protected byte[] ReadHoldingRegistersMessage(byte slaveAddress, string startAddress, ushort nuMBErOfPoints)
        {
            return Read(FUNCTION_03, slaveAddress, ushort.Parse(startAddress), FUNCTION_03, nuMBErOfPoints);
        }

        protected byte[] ReadInputRegistersMessage(byte slaveAddress, string startAddress, ushort nuMBErOfPoints)
        {
            return Read(FUNCTION_04, slaveAddress, ushort.Parse(startAddress), FUNCTION_04, nuMBErOfPoints);
        }

        protected byte[] WriteSingleCoilMessage(byte slaveAddress, string startAddress, bool value)
        {
            var values = new byte[2];
            if (value)
            {
                values[0] = 0xFF;
                values[1] = 0x00;
            }
            else
            {
                values[0] = 0x00;
                values[1] = 0x00;
            }

            return Write(FUNCTION_05, slaveAddress, ushort.Parse(startAddress), FUNCTION_05, values);
        }

        protected byte[] WriteMultipleCoilsMessage(byte slaveAddress, string startAddress, bool[] values)
        {
            var data = Bit.ToByteArray(values);
            return WriteAll(FUNCTION_15, slaveAddress, ushort.Parse(startAddress), FUNCTION_15, data);
        }

        protected byte[] WriteSingleRegisterMessage(byte slaveAddress, string startAddress, byte[] values)
        {
            //byte[] values = Modbus.Core.DataTypes.Int.ToByteArray(value);
            return Write(FUNCTION_06, slaveAddress, ushort.Parse(startAddress), FUNCTION_06, values);
        }

        protected byte[] WriteMultipleRegistersMessage(byte slaveAddress, string startAddress, byte[] values)
        {
            //byte[] data = Modbus.Core.DataTypes.Int.ToByteArray(values);
            return WriteAll(FUNCTION_16, slaveAddress, ushort.Parse(startAddress), FUNCTION_16, values);
        }

        #endregion
    }
}