using AdvancedScada.XModbus.Core.Comm;
using Core.DataTypes;
using IODriverV2;
using System;
using System.Diagnostics;
using System.Threading;
using static AdvancedScada.IBaseService.Common.XCollection;
namespace AdvancedScada.XModbus.Core.ASCII
{
    public class ModbusASCIIMaster : ModbusASCIIMessage, IModbusMaster
    {
        private const int DELAY = 100; // delay 100 ms
        private EthernetAdapter EthernetAdaper;
        private SerialPortAdapter SerialAdaper;

        public bool _IsConnected = false;
        public bool IsConnected
        {
            get { return _IsConnected; }
            set { _IsConnected = value; }
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

                EventscadaException?.Invoke(this.GetType().Name,
                    $"Could Not Connect to Server : {ex.Message}Time{stopwatch.ElapsedTicks}");
               
            }
        }

        public void Disconnection()
        {
            SerialAdaper.Close();
        }

        public byte[] ReadCoilStatus(byte slaveAddress, string startAddress, ushort nuMBErOfPoints)
        {
            var frame = ReadCoilStatusMessage(slaveAddress, startAddress, nuMBErOfPoints);
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
            var frame = ReadHoldingRegistersMessage(slaveAddress, startAddress, nuMBErOfPoints);
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
            var frame = ReadInputRegistersMessage(slaveAddress, startAddress, nuMBErOfPoints);
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
            var frame = ReadInputStatusMessage(slaveAddress, startAddress, nuMBErOfPoints);
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
            var frame = WriteMultipleCoilsMessage(slaveAddress, startAddress, values);
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
            var frame = WriteMultipleRegistersMessage(slaveAddress, startAddress, values);
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
            var frame = WriteSingleCoilMessage(slaveAddress, startAddress, value);
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
            var frame = WriteSingleRegisterMessage(slaveAddress, startAddress, values);
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