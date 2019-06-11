using System;
using System.Diagnostics;
using System.Threading;
using AdvancedScada.XDelta.Core.Comm;
using Core.DataTypes;
using IODriverV2;
using static AdvancedScada.IBaseService.Common.XCollection;

namespace AdvancedScada.XDelta.Core.ASCII
{
    public class DVPASCIIMaster : DVPASCIIMessage, IDVPMaster
    {
        private const int DELAY = 100; // delay 100 ms
        private EthernetAdapter EthernetAdaper;
        private SerialPortAdapter SerialAdaper;
        public bool _IsConnected = false;
        public bool IsConnected
        {
            get
            {
                return _IsConnected;
            }

            set
            {
                _IsConnected = value;
            }
        }

        public void Connection()
        {
            var stopwatch = Stopwatch.StartNew();

            try
            {
                IsConnected = SerialAdaper.Connect();
               

                stopwatch.Stop();
            }
            catch (TimeoutException ex)
            {
                stopwatch.Stop();

                EventscadaException?.Invoke(this.GetType().Name, string.Format("Could Not Connect to Server : {0}Time{1}", this.GetType().Name, ex.Message,
                    stopwatch.ElapsedTicks));
                
                IsConnected = false;
            }
        }

        public void Disconnection()
        {
            try
            {
                SerialAdaper.Close();
                
            }
            catch (TimeoutException ex)
            {

                EventscadaException?.Invoke(this.GetType().Name, string.Format("Could Not Connect to Server : {0}", this.GetType().Name, ex.Message));
                
            }
        }
        /// <summary>
        /// Command Code：17, Report Slave ID
        /// </summary>
        /// <param name="slaveAddress">Địa chỉ slave</param>
        /// <returns>byte[]</returns>
        public byte[] ReportSlaveID(byte slaveAddress)
        {
            try
            {
                string frame = this.ReportSlaveIDMessage(slaveAddress);
                this.SerialAdaper.WriteLine(frame);
                Thread.Sleep(DELAY);
                string buffReceiver = this.SerialAdaper.ReadLine();
                string tempStrg = buffReceiver.Substring(1, buffReceiver.Length - 2);
                byte[] data = Conversion.HexToBytes(tempStrg);
                if (buffReceiver.Length == 10) this.ModbusExcetion(data);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public byte[] ReadCoilStatus(byte slaveAddress, string startAddress, ushort nuMBErOfPoints)
        {
            var Address = DMT.DevToAddrW("DVP", startAddress, slaveAddress);
            var frame = ReadCoilStatusMessage(slaveAddress, Convert.ToUInt32(Address), nuMBErOfPoints);
            SerialAdaper.WriteLine(frame);
            Thread.Sleep(DELAY);
            var buffReceiver = SerialAdaper.ReadLine();
            var tempStrg = buffReceiver.Substring(1, buffReceiver.Length - 2);
            var messageReceived = Conversion.HexToBytes(tempStrg);
            if (buffReceiver.Length == 10) ModbusExcetion(messageReceived);
            var data = new byte[messageReceived[2]];
            Array.Copy(messageReceived, 3, data, 0, data.Length);
            return Bit.ToByteArray(Bit.ToArray(data));
        }

        public byte[] ReadHoldingRegisters(byte slaveAddress, string startAddress, ushort nuMBErOfPoints)
        {
            var Address = DMT.DevToAddrW("DVP", startAddress, slaveAddress);
            var frame = ReadHoldingRegistersMessage(slaveAddress, Convert.ToUInt32(Address), nuMBErOfPoints);
            SerialAdaper.WriteLine(frame);
            Thread.Sleep(DELAY);
            var buffReceiver = SerialAdaper.ReadLine();
            if (string.IsNullOrEmpty(buffReceiver)) return new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            var tempStrg = buffReceiver.Substring(1, buffReceiver.Length - 2);
            var messageReceived = Conversion.HexToBytes(tempStrg);
            if (buffReceiver.Length == 10) ModbusExcetion(messageReceived);
            var data = new byte[messageReceived[2]];
            Array.Copy(messageReceived, 3, data, 0, data.Length);
            return data;
        }

        public byte[] ReadInputRegisters(byte slaveAddress, string startAddress, ushort nuMBErOfPoints)
        {
            var Address = DMT.DevToAddrW("DVP", startAddress, slaveAddress);
            var frame = ReadInputRegistersMessage(slaveAddress, Convert.ToUInt32(Address), nuMBErOfPoints);
            SerialAdaper.WriteLine(frame);
            Thread.Sleep(DELAY);
            var buffReceiver = SerialAdaper.ReadLine();
            var tempStrg = buffReceiver.Substring(1, buffReceiver.Length - 2);
            var messageReceived = Conversion.HexToBytes(tempStrg);
            if (buffReceiver.Length == 10) ModbusExcetion(messageReceived);
            var data = new byte[messageReceived[2]];
            Array.Copy(messageReceived, 3, data, 0, data.Length);
            return data;
        }

        public byte[] ReadInputStatus(byte slaveAddress, string startAddress, ushort nuMBErOfPoints)
        {
            var Address = DMT.DevToAddrW("DVP", startAddress, slaveAddress);
            var frame = ReadInputStatusMessage(slaveAddress, Convert.ToUInt32(Address), nuMBErOfPoints);
            SerialAdaper.WriteLine(frame);
            Thread.Sleep(DELAY);
            var buffReceiver = SerialAdaper.ReadLine();
            var tempStrg = buffReceiver.Substring(1, buffReceiver.Length - 2);
            var messageReceived = Conversion.HexToBytes(tempStrg);
            if (buffReceiver.Length == 10) ModbusExcetion(messageReceived);
            var data = new byte[messageReceived[2]];
            Array.Copy(messageReceived, 3, data, 0, data.Length);
            return Bit.ToByteArray(Bit.ToArray(data));
        }

        public void AllSerialPortAdapter(SerialPortAdapter iModbusSerialPortAdapter)
        {
            SerialAdaper = iModbusSerialPortAdapter;
        }

        public void AllEthernetAdapter(EthernetAdapter iModbusEthernetAdapter)
        {
            EthernetAdaper = iModbusEthernetAdapter;
        }

        public byte[] WriteMultipleCoils(byte slaveAddress, string startAddress, bool[] values)
        {
            var Address = DMT.DevToAddrW("DVP", startAddress, slaveAddress);
            var data1 = Bit.ToByteArray(values);
            var frame = WriteMultipleCoilsMessage(slaveAddress, Convert.ToUInt32(Address), data1);
            SerialAdaper.WriteLine(frame);
            Thread.Sleep(DELAY);
            var buffReceiver = SerialAdaper.ReadLine();
            var tempStrg = buffReceiver.Substring(1, buffReceiver.Length - 2);
            var data = Conversion.HexToBytes(tempStrg);
            if (buffReceiver.Length == 10) ModbusExcetion(data);
            return data;
        }

        public byte[] WriteMultipleRegisters(byte slaveAddress, string startAddress, byte[] values)
        {
            var Address = DMT.DevToAddrW("DVP", startAddress, slaveAddress);
            var frame = WriteMultipleRegistersMessage(slaveAddress, Convert.ToUInt32(Address), values);
            SerialAdaper.WriteLine(frame);
            Thread.Sleep(DELAY);
            var buffReceiver = SerialAdaper.ReadLine();
            var tempStrg = buffReceiver.Substring(1, buffReceiver.Length - 2);
            var data = Conversion.HexToBytes(tempStrg);
            if (buffReceiver.Length == 10) ModbusExcetion(data);
            return data;
        }

        public byte[] WriteSingleCoil(byte slaveAddress, string startAddress, bool value)
        {
            var Address = DMT.DevToAddrW("DVP", startAddress, slaveAddress);
            var frame = WriteSingleCoilMessage(slaveAddress, Convert.ToUInt32(Address), value);
            SerialAdaper.WriteLine(frame);
            Thread.Sleep(DELAY);
            var buffReceiver = SerialAdaper.ReadLine();
            var tempStrg = buffReceiver.Substring(1, buffReceiver.Length - 2);
            var data = Conversion.HexToBytes(tempStrg);
            if (buffReceiver.Length == 10) ModbusExcetion(data);
            return data;
        }

        public byte[] WriteSingleRegister(byte slaveAddress, string startAddress, byte[] values)
        {
            var Address = DMT.DevToAddrW("DVP", startAddress, slaveAddress);
            var frame = WriteSingleRegisterMessage(slaveAddress, Convert.ToUInt32(Address), values);
            SerialAdaper.WriteLine(frame);
            Thread.Sleep(DELAY);
            var buffReceiver = SerialAdaper.ReadLine();
            var tempStrg = buffReceiver.Substring(1, buffReceiver.Length - 2);
            var data = Conversion.HexToBytes(tempStrg);
            if (buffReceiver.Length == 10) ModbusExcetion(data);
            return data;
        }
    }
}