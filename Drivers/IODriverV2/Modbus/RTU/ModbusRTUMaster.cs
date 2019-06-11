using static AdvancedScada.IBaseService.Common.XCollection;
using AdvancedScada.XModbus.Core.Comm;
using IODriverV2;
using System;
using System.Diagnostics;
using System.Threading;
using Core.DataTypes;

namespace AdvancedScada.XModbus.Core.RTU
{
    public class ModbusRTUMaster : ModbusRTUMessage, IModbusMaster
    {
        private const int DELAY = 100; // delay 100 ms
     //   public static ConnectionPlc eventConnectionPlc = null;

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
            try
            {
                SerialAdaper.Close();
              
            }
            catch (TimeoutException ex)
            {

                EventscadaException?.Invoke(this.GetType().Name, $"Could Not Connect to Server : {ex.Message}");
                 
            }
        }

        public byte[] ReadCoilStatus(byte slaveAddress, string startAddress, ushort nuMBErOfPoints)
        {
            var frame = ReadCoilStatusMessage(slaveAddress, startAddress, nuMBErOfPoints);
            SerialAdaper.Write(frame, 0, frame.Length);
            Thread.Sleep(DELAY);
            var buffReceiver = SerialAdaper.Read();
            if (buffReceiver.Length == 5) ModbusExcetion(buffReceiver);
            var data = new byte[buffReceiver.Length - 5];
            Array.Copy(buffReceiver, 3, data, 0, data.Length);
            return Bit.ToByteArray(Bit.ToArray(data));
        }

        public byte[] ReadHoldingRegisters(byte slaveAddress, string startAddress, ushort nuMBErOfPoints)
        {
            var frame = ReadHoldingRegistersMessage(slaveAddress, startAddress, nuMBErOfPoints);
            SerialAdaper.Write(frame, 0, frame.Length);
            Thread.Sleep(DELAY);
            var buffReceiver = SerialAdaper.Read();
            if (buffReceiver.Length == 5) ModbusExcetion(buffReceiver);
            var data = new byte[buffReceiver.Length - 5];
            Array.Copy(buffReceiver, 3, data, 0, data.Length);
            return data;
        }

        public byte[] ReadInputRegisters(byte slaveAddress, string startAddress, ushort nuMBErOfPoints)
        {
            var frame = ReadInputRegistersMessage(slaveAddress, startAddress, nuMBErOfPoints);
            SerialAdaper.Write(frame, 0, frame.Length);
            Thread.Sleep(DELAY);
            var buffReceiver = SerialAdaper.Read();
            if (buffReceiver.Length == 5) ModbusExcetion(buffReceiver);
            var data = new byte[buffReceiver.Length - 5];
            Array.Copy(buffReceiver, 3, data, 0, data.Length);
            return data;
        }

        public byte[] ReadInputStatus(byte slaveAddress, string startAddress, ushort nuMBErOfPoints)
        {
            var frame = ReadInputStatusMessage(slaveAddress, startAddress, nuMBErOfPoints);
            SerialAdaper.Write(frame, 0, frame.Length);
            Thread.Sleep(DELAY);
            var buffReceiver = SerialAdaper.Read();
            if (buffReceiver.Length == 5) ModbusExcetion(buffReceiver);
            var data = new byte[buffReceiver.Length - 5];
            Array.Copy(buffReceiver, 3, data, 0, data.Length);
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
            SerialAdaper.Write(frame, 0, frame.Length);
            Thread.Sleep(DELAY);
            var buffReceiver = SerialAdaper.Read();
            if (buffReceiver.Length == 5) ModbusExcetion(buffReceiver);
            return buffReceiver;
        }

        public byte[] WriteMultipleRegisters(byte slaveAddress, string startAddress, byte[] values)
        {
            var frame = WriteMultipleRegistersMessage(slaveAddress, startAddress, values);
            SerialAdaper.Write(frame, 0, frame.Length);
            Thread.Sleep(DELAY);
            var buffReceiver = SerialAdaper.Read();
            if (buffReceiver.Length == 5) ModbusExcetion(buffReceiver);
            return buffReceiver;
        }

        public byte[] WriteSingleCoil(byte slaveAddress, string startAddress, bool value)
        {
            var frame = WriteSingleCoilMessage(slaveAddress, startAddress, value);
            SerialAdaper.Write(frame, 0, frame.Length);
            Thread.Sleep(DELAY);
            var buffReceiver = SerialAdaper.Read();
            if (buffReceiver.Length == 5) ModbusExcetion(buffReceiver);
            return buffReceiver;
        }

        public byte[] WriteSingleRegister(byte slaveAddress, string startAddress, byte[] values)
        {
            var frame = WriteSingleRegisterMessage(slaveAddress, startAddress, values);
            SerialAdaper.Write(frame, 0, frame.Length);
            Thread.Sleep(DELAY);
            var buffReceiver = SerialAdaper.Read();
            if (buffReceiver.Length == 5) ModbusExcetion(buffReceiver);
            return buffReceiver;
        }


    }
}