using AdvancedScada.XModbus.Core.Comm;
using Core.DataTypes;
using System;

namespace AdvancedScada.XModbus.Core.ASCII
{
    public class ModbusASCIIMessage : BaseMessage
    {
        private const char Header = ':';
        private const char CR = '\r';
        private const char LF = '\n';
        private readonly string Trailer = string.Empty + CR + LF;

        private string Read(byte slaveAddress, ushort startAddress, byte functionCode, uint nuMBErOfPoints)
        {
            var frame = $"{slaveAddress:X2}";
            frame += $"{functionCode:X2}";
            frame += $"{startAddress:X4}";
            frame += $"{nuMBErOfPoints:X4}";
            var bytes = Conversion.HexToBytes(frame);
            var lrc = LRC(bytes);
            return Header + frame + lrc.ToString("X2") + Trailer;
        }

        private string Write(byte slaveAddress, ushort startAddress, byte functionCode, byte[] value)
        {
            var frame = $"{slaveAddress:X2}"; // Địa chỉ slave.
            frame += $"{functionCode:X2}"; // Mã hàm modbus.
            frame += $"{startAddress:X4}"; // Địa chỉ bắt đầu của coil.
            frame += $"{value[0]:X2}"; // Dữ liệu cần ghi xuống coil.
            frame += $"{value[1]:X2}"; // Dữ liệu cần ghi xuống coil.
            var bytes = Conversion.HexToBytes(frame);
            var lrc = LRC(bytes);
            return Header + frame + lrc.ToString("X2") + Trailer;
        }

        private string WriteAll(byte slaveAddress, ushort startAddress, byte functionCode, byte[] values)
        {
            var frame = $"{slaveAddress:X2}"; // Địa chỉ slave.
            frame += $"{functionCode:X2}"; // Mã hàm modbus.
            frame += $"{startAddress:X4}"; // Địa chỉ bắt đầu của coils.
            frame += $"{(functionCode == 15 ? values.Length * 8 : values.Length / 2):X4}"; // Số lượng coils.
            frame += $"{values.Length:X2}"; // Số byte cần ghi.
            foreach (var item in values) frame += $"{item:X2}";
            var bytes = Conversion.HexToBytes(frame);
            var lrc = LRC(bytes);
            return Header + frame + lrc.ToString("X2") + Trailer;
        }

        private byte LRC(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException("Tham số truyền vào không tồn tại phần tử nào");
            byte lrc = 0;
            foreach (var b in data)
                lrc += b;
            lrc = (byte)((lrc ^ 0xFF) + 1);
            return lrc;
        }

        protected string ReadCoilStatusMessage(byte slaveAddress, string startAddress, ushort nuMBErOfPoints)
        {
            return Read(slaveAddress, ushort.Parse(startAddress), FUNCTION_01, nuMBErOfPoints);
        }

        protected string ReadInputStatusMessage(byte slaveAddress, string startAddress, ushort nuMBErOfPoints)
        {
            return Read(slaveAddress, ushort.Parse(startAddress), FUNCTION_02, nuMBErOfPoints);
        }

        protected string ReadHoldingRegistersMessage(byte slaveAddress, string startAddress, ushort nuMBErOfPoints)
        {
            return Read(slaveAddress, ushort.Parse(startAddress), FUNCTION_03, nuMBErOfPoints);
        }

        protected string ReadInputRegistersMessage(byte slaveAddress, string startAddress, ushort nuMBErOfPoints)
        {
            return Read(slaveAddress, ushort.Parse(startAddress), FUNCTION_04, nuMBErOfPoints);
        }

        protected string WriteSingleCoilMessage(byte slaveAddress, string startAddress, bool value)
        {
            short temp = 0;
            if (value)
                temp = 255; // 0xFF00(55280) = 0xFF(250) Xor 0xFFFF(65535).
            else
                temp = 0;
            var values = Int.ToByteArray(temp);
            return Write(slaveAddress, ushort.Parse(startAddress), FUNCTION_05, values);
        }

        protected string WriteMultipleCoilsMessage(byte slaveAddress, string startAddress, bool[] values)
        {
            var data = Bit.ToByteArray(values);
            return WriteAll(slaveAddress, ushort.Parse(startAddress), FUNCTION_15, data);
        }

        protected string WriteSingleRegisterMessage(byte slaveAddress, string startAddress, byte[] values)
        {
            return Write(slaveAddress, ushort.Parse(startAddress), FUNCTION_06, values);
        }

        protected string WriteMultipleRegistersMessage(byte slaveAddress, string startAddress, byte[] values)
        {
            return WriteAll(slaveAddress, ushort.Parse(startAddress), FUNCTION_16, values);
        }
    }
}