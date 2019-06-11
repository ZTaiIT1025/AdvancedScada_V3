using AdvancedScada.DriverBase.Comm;
using System;
using AdvancedScada.XDelta.Core.Comm;
using Core.DataTypes;

namespace AdvancedScada.XDelta.Core.ASCII
{
    public class DVPASCIIMessage : BaseMessage
    {
        private const char Header = ':';
        private const char CR = '\r';
        private const char LF = '\n';
        private string Trailer = string.Empty + CR;

        private string Read(byte slaveAddress, uint startAddress, byte functionCode, uint numberOfPoints)
        {
            string frame = $"{slaveAddress:X2}";
            frame += $"{functionCode:X2}";
            frame += $"{startAddress:X4}";
            frame += $"{numberOfPoints:X4}";
            byte[] bytes = Conversion.HexToBytes(frame);
            byte lrc = LRC(bytes);
            return Header + frame + lrc.ToString("X2") + Trailer;
        }

        private string Write(byte slaveAddress, uint startAddress, byte functionCode, byte[] value)
        {
            string frame = $"{slaveAddress:X2}"; // Địa chỉ slave.
            frame += $"{functionCode:X2}"; // Mã hàm modbus.
            frame += $"{startAddress:X4}"; // Địa chỉ bắt đầu của coil.
            frame += $"{value[0]:X2}"; // Dữ liệu cần ghi xuống coil.
            frame += $"{value[1]:X2}"; // Dữ liệu cần ghi xuống coil.
            byte[] bytes = Conversion.HexToBytes(frame);
            byte lrc = LRC(bytes);
            return Header + frame + lrc.ToString("X2") + Trailer;
        }

        private string WriteAll(byte slaveAddress, uint startAddress, byte functionCode, byte[] values)
        {
            string frame = $"{slaveAddress:X2}"; // Địa chỉ slave.
            frame += $"{functionCode:X2}"; // Mã hàm modbus.
            frame += $"{startAddress:X4}"; // Địa chỉ bắt đầu của coils.
            frame += $"{((functionCode == 15) ? values.Length * 8 : values.Length / 2):X4}"; // Số lượng coils.
            frame += $"{values.Length:X2}"; // Số byte cần ghi.
            foreach (byte item in values)
            {
                frame += $"{item:X2}";
            }
            byte[] bytes = Conversion.HexToBytes(frame);
            byte lrc = LRC(bytes);
            return Header + frame + lrc.ToString("X2") + Trailer;
        }

        private byte LRC(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException("Đối số truyền vào là null không hợp lệ");
            byte lrc = 0;
            foreach (byte byt in data)
                lrc += byt;
            lrc = (byte)((lrc ^ 0xFF) + 1);
            return lrc;
        }

        protected string ReadCoilStatusMessage(byte slaveAddress, uint startAddress, ushort numberOfPoints)
        {
            try
            {
                string frame = $"{slaveAddress:X2}";   // Slave Address
                frame += $"{FUNCTION_01:X2}";          // Function  
                frame += $"{startAddress:X4}";         // Starting Address
                frame += $"{numberOfPoints:X4}";       // Quantity of Coils.
                byte[] bytes = Conversion.HexToBytes(frame);            // Calculate LRC.
                byte lrc = LRC(bytes);
                return Header + frame + lrc.ToString("X2") + Trailer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected string ReadInputStatusMessage(byte slaveAddress, uint startAddress, ushort numberOfPoints)
        {
            try
            {
                string frame = $"{slaveAddress:X2}";      // Slave Address
                frame += $"{FUNCTION_02:X2}";             // Function  
                frame += $"{startAddress:X4}";            // Starting Address
                frame += $"{numberOfPoints:X4}";          // Quantity of Coils.
                byte[] bytes = Conversion.HexToBytes(frame);               // Calculate LRC.
                byte lrc = LRC(bytes);
                return Header + frame + lrc.ToString("X2") + Trailer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected string ReadHoldingRegistersMessage(byte slaveAddress, uint startAddress, ushort numberOfPoints)
        {
            return this.Read(slaveAddress, startAddress, FUNCTION_03, numberOfPoints);
        }

        protected string ReadInputRegistersMessage(byte slaveAddress, uint startAddress, ushort numberOfPoints)
        {
            try
            {
                string frame = $"{slaveAddress:X2}";   // Slave Address
                frame += $"{FUNCTION_04:X2}";          // Function  
                frame += $"{startAddress:X4}";         // Starting Address
                frame += $"{numberOfPoints:X4}";       // Quantity of Coils.
                byte[] bytes = Conversion.HexToBytes(frame);            // Calculate LRC.
                byte lrc = LRC(bytes);
                return Header + frame + lrc.ToString("X2") + Trailer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected string WriteSingleCoilMessage(byte slaveAddress, uint startAddress, bool value)
        {
            try
            {
                string frame = $"{slaveAddress:X2}";   // Slave Address.
                frame += $"{FUNCTION_05:X2}";          // Function.
                frame += $"{startAddress:X4}";         // Coil Address.
                frame += $"{(value ? 65280 : 0):X4}";    // Write Data.
                byte[] bytes = Conversion.HexToBytes(frame);
                byte lrc = LRC(bytes);
                return Header + frame + lrc.ToString("X2") + Trailer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected string WriteMultipleCoilsMessage(byte slaveAddress, uint startAddress, byte[] values)
        {
            try
            {
                string frame = $"{slaveAddress:X2}"; // Slave Address.
                frame += $"{FUNCTION_15:X2}"; // Function.
                frame += $"{startAddress:X4}"; // Coil Address.
                frame += $"{((FUNCTION_15 == 15) ? values.Length * 8 : values.Length / 2):X4}"; // Quantity of Coils.
                frame += $"{values.Length:X2}"; // Byte Count.
                foreach (byte item in values)
                {
                    frame += $"{item:X2}"; // Write Data
                }
                byte[] bytes = Conversion.HexToBytes(frame);
                byte lrc = LRC(bytes);
                return Header + frame + lrc.ToString("X2") + Trailer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected string WriteMultipleCoilsMessage(byte slaveAddress, string startAddress, bool[] values)
        {
            var data = Bit.ToByteArray(values);
            return WriteAll(slaveAddress, ushort.Parse(startAddress), FUNCTION_15, data);
        }
        protected string WriteSingleRegisterMessage(byte slaveAddress, uint startAddress, byte[] values)
        {
            try
            {
                string frame = $"{slaveAddress:X2}";   // Slave Address.
                frame += $"{FUNCTION_06:X2}";         // Function.
                frame += $"{startAddress:X4}";         // Register Address.
                foreach (byte item in values)
                {
                    frame += $"{item:X2}";               // Write Data.
                }
                byte[] bytes = Conversion.HexToBytes(frame);
                byte lrc = LRC(bytes);
                return Header + frame + lrc.ToString("X2") + Trailer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected string WriteMultipleRegistersMessage(byte slaveAddress, uint startAddress, byte[] values)
        {
            try
            {
                string frame = $"{slaveAddress:X2}"; // Slave Address.
                frame += $"{FUNCTION_16:X2}"; // Function.
                frame += $"{startAddress:X4}"; // Starting Address.
                frame += $"{((FUNCTION_16 == 15) ? values.Length * 8 : values.Length / 2):X4}"; // Quantity of Registers.
                frame += $"{values.Length:X2}"; // Byte Count.
                foreach (byte item in values)
                {
                    frame += $"{item:X2}"; // Write Data
                }
                byte[] bytes = Conversion.HexToBytes(frame);
                byte lrc = LRC(bytes);
                return Header + frame + lrc.ToString("X2") + Trailer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Command Code：17, Report Slave ID
        /// </summary>
        /// <param name="slaveAddress">Địa chỉ slave</param>
        /// <returns>Trả về chuỗi message</returns>
        protected string ReportSlaveIDMessage(byte slaveAddress)
        {
            try
            {
                string frame = $"{slaveAddress:X2}"; // Slave Address.
                frame += $"{FUNCTION_17:X2}"; // Function.
                byte[] bytes = Conversion.HexToBytes(frame);
                byte lrc = LRC(bytes);
                return Header + frame + lrc.ToString("X2") + Trailer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}