using AdvancedScada.XDelta.Core.Comm;
using Core.DataTypes;
using IODriverV2;
using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading;
using static AdvancedScada.IBaseService.Common.XCollection;
namespace AdvancedScada.XDelta.Core.TCP
{
    public class DVPTCPMaster : DVPTCPMessage, IDVPMaster
    {
        private const int DELAY = 10;


        private EthernetAdapter EthernetAdaper;
        public EventConnectionStateChanged eventConnectionStateChanged = null;
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
        public DVPTCPMaster()
        {
        }

        public DVPTCPMaster(string ip, int port)
            : this()
        {
            EthernetAdaper = new EthernetAdapter(ip, port);
        }

        public DVPTCPMaster(string ip, short port, int connectTimeout)
            : this()
        {
            EthernetAdaper = new EthernetAdapter(ip, port, connectTimeout);
        }

        public void Connection()
        {
            var stopwatch = Stopwatch.StartNew();

            try
            {
                IsConnected = EthernetAdaper.Connect();
               

                stopwatch.Stop();
            }
            catch (SocketException ex)
            {
                stopwatch.Stop();
                EventscadaException?.Invoke(this.GetType().Name,
                    $"Could Not Connect to Server : {ex.SocketErrorCode} Time: {stopwatch.ElapsedTicks}");
                IsConnected = false;

                

                if (eventConnectionStateChanged != null) eventConnectionStateChanged(DISCONNECTED);
            }
        }

        public void Disconnection()
        {
            try
            {
                EthernetAdaper.Close();
               
                IsConnected = false;
            }
            catch (SocketException)
            {
            }
            finally
            {
               
                if (eventConnectionStateChanged != null) eventConnectionStateChanged(DISCONNECTED);
            }
        }

        public byte[] ReadCoilStatus(byte slaveAddress, string startAddress, ushort nuMBErOfPoints)
        {
            var stopwatch = Stopwatch.StartNew();

            var Address = DMT.DevToAddrW("DVP", startAddress, slaveAddress);
            var frame = ReadCoilStatusMessage(slaveAddress, $"{Address}", nuMBErOfPoints);
            stopwatch.Stop();
            //   RequestAndResponseMessage _RequestAndResponseMessage = new RequestAndResponseMessage("RequestRead", frame);

            EthernetAdaper.Write(frame);
            Thread.Sleep(DELAY);
            var buffReceiver = EthernetAdaper.Read();
            if (FUNCTION_01 != buffReceiver[7])
            {
                var errorbytes = new byte[3];
                Array.Copy(buffReceiver, 6, errorbytes, 0, errorbytes.Length);
                ModbusExcetion(errorbytes);
            }

            int SizeByte = buffReceiver[8]; // Số lượng byte dữ liệu thu được.
            var data = new byte[SizeByte];
            Array.Copy(buffReceiver, 9, data, 0,
                data.Length); // Dữ liệu cần lấy bắt đầu từ byte có chỉ số 9 trong buffReceive.            
            return Bit.ToByteArray(Bit.ToArray(data));
        }

        public byte[] ReadInputStatus(byte slaveAddress, string startAddress, ushort nuMBErOfPoints)
        {
            var Address = DMT.DevToAddrW("DVP", startAddress, slaveAddress);
            var frame = ReadInputStatusMessage(slaveAddress, $"{Address}", nuMBErOfPoints);
            EthernetAdaper.Write(frame);
            // RequestAndResponseMessage _RequestAndResponseMessage = new RequestAndResponseMessage("RequestRead", frame);

            Thread.Sleep(DELAY);
            var buffReceiver = EthernetAdaper.Read();
            if (FUNCTION_02 != buffReceiver[7])
            {
                var errorbytes = new byte[3];
                Array.Copy(buffReceiver, 6, errorbytes, 0, errorbytes.Length);
                ModbusExcetion(errorbytes);
            }

            int SizeByte = buffReceiver[8]; // Số lượng byte dữ liệu thu được.
            var data = new byte[SizeByte];
            Array.Copy(buffReceiver, 9, data, 0,
                data.Length); // Dữ liệu cần lấy bắt đầu từ byte có chỉ số 9 trong buffReceive.            
            return Bit.ToByteArray(Bit.ToArray(data));
        }

        public byte[] ReadHoldingRegisters(byte slaveAddress, string startAddress, ushort nuMBErOfPoints)
        {
            var Address = DMT.DevToAddrW("DVP", startAddress, slaveAddress);
            var frame = ReadHoldingRegistersMessage(slaveAddress, $"{Address}", nuMBErOfPoints);
            EthernetAdaper.Write(frame);
            //RequestAndResponseMessage _RequestAndResponseMessage = new RequestAndResponseMessage("RequestRead", frame);

            Thread.Sleep(DELAY);
            var buffReceiver = EthernetAdaper.Read();
            if (FUNCTION_03 != buffReceiver[7])
            {
                var errorbytes = new byte[3];
                Array.Copy(buffReceiver, 6, errorbytes, 0, errorbytes.Length);
                ModbusExcetion(errorbytes);
            }

            int SizeByte = buffReceiver[8]; // Số lượng byte dữ liệu thu được.
            var data = new byte[SizeByte];
            Array.Copy(buffReceiver, 9, data, 0,
                data.Length); // Dữ liệu cần lấy bắt đầu từ byte có chỉ số 9 trong buffReceive.            
            return data;
        }

        public byte[] ReadInputRegisters(byte slaveAddress, string startAddress, ushort nuMBErOfPoints)
        {
            var Address = DMT.DevToAddrW("DVP", startAddress, slaveAddress);
            var frame = ReadInputRegistersMessage(slaveAddress, $"{Address}", nuMBErOfPoints);
            EthernetAdaper.Write(frame);
            // RequestAndResponseMessage _RequestAndResponseMessage = new RequestAndResponseMessage("RequestRead", frame);

            Thread.Sleep(DELAY);
            var buffReceiver = EthernetAdaper.Read();
            if (FUNCTION_04 != buffReceiver[7])
            {
                var errorbytes = new byte[3];
                Array.Copy(buffReceiver, 6, errorbytes, 0, errorbytes.Length);
                ModbusExcetion(errorbytes);
            }

            int SizeByte = buffReceiver[8]; // Số lượng byte dữ liệu thu được.
            var data = new byte[SizeByte];
            Array.Copy(buffReceiver, 9, data, 0,
                data.Length); // Dữ liệu cần lấy bắt đầu từ byte có chỉ số 9 trong buffReceive.            
            return data;
        }

        public byte[] WriteSingleCoil(byte slaveAddress, string startAddress, bool value)
        {
            var Address = DMT.DevToAddrW("DVP", startAddress, slaveAddress);
            var frame = WriteSingleCoilMessage(slaveAddress, $"{Address}", value);
            EthernetAdaper.Write(frame);
            //RequestAndResponseMessage _RequestAndResponseMessage = new RequestAndResponseMessage("RequestWrite", frame);

            Thread.Sleep(DELAY);
            var buffReceiver = EthernetAdaper.Read();
            if (FUNCTION_05 != buffReceiver[7])
            {
                var errorbytes = new byte[3];
                Array.Copy(buffReceiver, 6, errorbytes, 0, errorbytes.Length);
                ModbusExcetion(errorbytes);
            }

            return buffReceiver;
        }

        public byte[] WriteMultipleCoils(byte slaveAddress, string startAddress, bool[] values)
        {
            var Address = DMT.DevToAddrW("DVP", startAddress, slaveAddress);
            var frame = WriteMultipleCoilsMessage(slaveAddress, $"{Address}", values);
            EthernetAdaper.Write(frame);
            // RequestAndResponseMessage _RequestAndResponseMessage = new RequestAndResponseMessage("RequestWrite", frame);

            Thread.Sleep(DELAY);
            var buffReceiver = EthernetAdaper.Read();
            if (FUNCTION_15 != buffReceiver[7])
            {
                var errorbytes = new byte[3];
                Array.Copy(buffReceiver, 6, errorbytes, 0, errorbytes.Length);
                ModbusExcetion(errorbytes);
            }

            return buffReceiver;
        }

        public byte[] WriteSingleRegister(byte slaveAddress, string startAddress, byte[] values)
        {
            var Address = DMT.DevToAddrW("DVP", startAddress, slaveAddress);
            var frame = WriteSingleRegisterMessage(slaveAddress, $"{Address}", values);
            EthernetAdaper.Write(frame);
            // RequestAndResponseMessage _RequestAndResponseMessage = new RequestAndResponseMessage("RequestWrite", frame);

            Thread.Sleep(DELAY);
            var buffReceiver = EthernetAdaper.Read();
            if (FUNCTION_06 != buffReceiver[7])
            {
                var errorbytes = new byte[3];
                Array.Copy(buffReceiver, 6, errorbytes, 0, errorbytes.Length);
                ModbusExcetion(errorbytes);
            }

            return buffReceiver;
        }

        public byte[] WriteMultipleRegisters(byte slaveAddress, string startAddress, byte[] values)
        {
            var Address = DMT.DevToAddrW("DVP", startAddress, slaveAddress);
            var frame = WriteMultipleRegistersMessage(slaveAddress, $"{Address}", values);
            EthernetAdaper.Write(frame);
            // RequestAndResponseMessage _RequestAndResponseMessage = new RequestAndResponseMessage("RequestWrite", frame);

            Thread.Sleep(DELAY);
            var buffReceiver = EthernetAdaper.Read();
            if (FUNCTION_16 != buffReceiver[7])
            {
                var errorbytes = new byte[3];
                Array.Copy(buffReceiver, 6, errorbytes, 0, errorbytes.Length);
                ModbusExcetion(errorbytes);
            }

            return buffReceiver;
        }

        public void AllSerialPortAdapter(SerialPortAdapter iModbusSerialPortAdapter)
        {
            SerialAdaper = iModbusSerialPortAdapter;
        }

        public void AllEthernetAdapter(EthernetAdapter iModbusEthernetAdapter)
        {
            EthernetAdaper = iModbusEthernetAdapter;
        }
    }
}