using System;
using AdvancedScada.XDelta.Core.Comm;
using Core.DataTypes;

namespace AdvancedScada.XDelta.Core.RTU
{
    public class DVPRTUMessage : BaseMessage
    {
        private byte[] Read(byte slaveAddress, ushort startAddress, byte functionCode, uint nuMBErOfPoints)
        {
            var frame = new byte[8];
            frame[0] = slaveAddress; // Slave address
            frame[1] = functionCode; // Function code            
            frame[2] = (byte)(startAddress >> 8); // Start address
            frame[3] = (byte)startAddress; // Start address            
            frame[4] = (byte)(nuMBErOfPoints >> 8); // NuMBEr of data to read
            frame[5] = (byte)nuMBErOfPoints; // NuMBEr of data to read
            var crc = CRC(frame);
            frame[frame.Length - 2] = crc[0];
            frame[frame.Length - 1] = crc[1];
            return frame;
        }

        private byte[] Write(byte slaveAddress, ushort startAddress, byte functionCode, byte[] values)
        {
            var size = values.Length;
            var frame = new byte[8 + size]; // Message size
            frame[0] = slaveAddress; // Slave address
            frame[1] = functionCode; // Function code            
            frame[2] = (byte)(startAddress >> 8); // Start address
            frame[3] = (byte)startAddress; // Start address 
            Array.Copy(values, 0, frame, 4, size);
            var crc = CRC(frame);
            frame[frame.Length - 2] = crc[0];
            frame[frame.Length - 1] = crc[1];
            return frame;
        }

        private byte[] WriteAll(byte slaveAddress, ushort startAddress, byte functionCode, byte[] values)
        {
            var size = values.Length;
            var amount = functionCode == FUNCTION_15 ? (ushort)(size * 8) : (ushort)(size / 2);
            var frame = new byte[9 + size];
            frame[0] = slaveAddress; // Slave address
            frame[1] = functionCode; // Function code            
            frame[2] = (byte)(startAddress >> 8); // Start address
            frame[3] = (byte)startAddress; // Start address              
            frame[4] = (byte)(amount >> 8); // Số bit của byte thấp cần ghi xuống slave.
            frame[5] = (byte)amount; // Số bit của byte cao cần ghi xuống slave.
            frame[6] = (byte)size;
            Array.Copy(values, 0, frame, 7, size);
            var crc = CRC(frame);
            frame[frame.Length - 2] = crc[0];
            frame[frame.Length - 1] = crc[1];
            return frame;
        }

        private byte[] CRC16(byte[] data)
        {
            var checkSum = new byte[2];
            ushort reg_crc = 0XFFFF;
            for (var i = 0; i < data.Length - 2; i++)
            {
                reg_crc ^= data[i];
                for (var j = 0; j < 8; j++)
                    if ((reg_crc & 0x01) == 1)
                        reg_crc = (ushort)((reg_crc >> 1) ^ 0xA001);
                    else
                        reg_crc = (ushort)(reg_crc >> 1);
            }

            checkSum[1] = (byte)((reg_crc >> 8) & 0xFF);
            checkSum[0] = (byte)(reg_crc & 0xFF);
            return checkSum;
        }

        private byte[] CRC(byte[] data)
        {
            ushort CRCFull = 0xFFFF;
            byte CRCHigh = 0xFF, CRCLow = 0xFF;
            char CRCLSB;
            var CRC = new byte[2];
            for (var i = 0; i < data.Length - 2; i++)
            {
                CRCFull = (ushort)(CRCFull ^ data[i]);

                for (var j = 0; j < 8; j++)
                {
                    CRCLSB = (char)(CRCFull & 0x0001);
                    CRCFull = (ushort)((CRCFull >> 1) & 0x7FFF);

                    if (CRCLSB == 1)
                        CRCFull = (ushort)(CRCFull ^ 0xA001);
                }
            }

            CRC[1] = CRCHigh = (byte)((CRCFull >> 8) & 0xFF);
            CRC[0] = CRCLow = (byte)(CRCFull & 0xFF);
            return CRC;
        }

        protected byte[] ReadCoilStatusMessage(byte slaveAddress, string startAddress, ushort nuMBErOfPoints)
        {
            return Read(slaveAddress, ushort.Parse(startAddress), FUNCTION_01, nuMBErOfPoints);
        }

        protected byte[] ReadInputStatusMessage(byte slaveAddress, string startAddress, ushort nuMBErOfPoints)
        {
            return Read(slaveAddress, ushort.Parse(startAddress), FUNCTION_02, nuMBErOfPoints);
        }

        protected byte[] ReadHoldingRegistersMessage(byte slaveAddress, string startAddress, ushort nuMBErOfPoints)
        {
            return Read(slaveAddress, ushort.Parse(startAddress), FUNCTION_03, nuMBErOfPoints);
        }

        protected byte[] ReadInputRegistersMessage(byte slaveAddress, string startAddress, ushort nuMBErOfPoints)
        {
            return Read(slaveAddress, ushort.Parse(startAddress), FUNCTION_04, nuMBErOfPoints);
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

            return Write(slaveAddress, ushort.Parse(startAddress), FUNCTION_05, values);
        }

        protected byte[] WriteMultipleCoilsMessage(byte slaveAddress, string startAddress, bool[] values)
        {
            var data = Bit.ToByteArray(values);
            return WriteAll(slaveAddress, ushort.Parse(startAddress), FUNCTION_15, data);
        }

        protected byte[] WriteSingleRegisterMessage(byte slaveAddress, string startAddress, byte[] values)
        {
            return Write(slaveAddress, ushort.Parse(startAddress), FUNCTION_06, values);
        }

        protected byte[] WriteMultipleRegistersMessage(byte slaveAddress, string startAddress, byte[] values)
        {
            return WriteAll(slaveAddress, ushort.Parse(startAddress), FUNCTION_16, values);
        }
    }
}