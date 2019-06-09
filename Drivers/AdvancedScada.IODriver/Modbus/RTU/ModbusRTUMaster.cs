
using AdvancedScada.DriverBase;
using HslCommunication;
using HslCommunication.ModBus;
using System;
using System.IO.Ports;
using static AdvancedScada.IBaseService.Common.XCollection;
namespace AdvancedScada.IODriver.RTU
{
    public class ModbusRTUMaster : IDriverAdapter
    {
         private SerialPort serialPort;

        public bool IsConnected { get; set; }
        public byte Station { get; set; }
        public ModbusRTUMaster(short slaveId, SerialPort serialPort)
        {
            Station = (byte)slaveId;
            this.serialPort = serialPort;
        }
       
        private ModbusRtu busRtuClient = null;

        public void Connection()
        {
            
            busRtuClient?.Close();
            busRtuClient = new ModbusRtu(Station);
            busRtuClient.AddressStartWithZero = true;

            busRtuClient.IsStringReverse = false;
            try
            {
               
                busRtuClient.SerialPortInni(sp =>
                {
                    sp.PortName = serialPort.PortName;
                    sp.BaudRate = serialPort.BaudRate;
                    sp.DataBits = serialPort.DataBits;
                    sp.StopBits = serialPort.StopBits;
                    sp.Parity = serialPort.Parity;
                });
                busRtuClient.Open();
                IsConnected = true;
                
                
            }
            catch (TimeoutException ex)
            {


               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        public void Disconnection()
        {
            try
            {
                busRtuClient.Close();
                
            }
            catch (TimeoutException ex)
            {

               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

       
        
        public byte[] BuildReadByte(byte station, string address, ushort length)
        {
            var frame = DemoUtils.BulkReadRenderResult(busRtuClient, address, length);
 

            return frame;
         }

        public byte[] BuildWriteByte(byte station, string address, byte[] value)
        {
            try
            {
                DemoUtils.WriteResultRender(busRtuClient.Write(address, value), address);
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
            return new byte[0];
        }

       

        public OperateResult<bool[]> ReadDiscrete(string address, ushort length)
        {
            return busRtuClient.ReadDiscrete(address, length);
        }
        public bool Write(string address, dynamic value)
        {
            if (value is bool)
            {
                busRtuClient.WriteCoil(address, value);
            }
            else
            {
                busRtuClient.Write(address, value);
            }

            return true;
        }

        public TValue[] Read<TValue>(string address, ushort length)
        {
            if (typeof(TValue) == typeof(bool))
            {
                var b = busRtuClient.ReadCoil(address, length).Content;
                return (TValue[])(object)b;
            }
            if (typeof(TValue) == typeof(ushort))
            {
                var b = busRtuClient.ReadUInt16(address, length).Content;

                return (TValue[])(object)b;
            }
            if (typeof(TValue) == typeof(int))
            {
                var b = busRtuClient.ReadInt32(address, length).Content;

                return (TValue[])(object)b;
            }
            if (typeof(TValue) == typeof(uint))
            {
                var b = busRtuClient.ReadUInt32(address, length).Content;
                return (TValue[])(object)b;
            }
            if (typeof(TValue) == typeof(long))
            {
                var b = busRtuClient.ReadInt64(address, length).Content;
                return (TValue[])(object)b;
            }
            if (typeof(TValue) == typeof(ulong))
            {
                var b = busRtuClient.ReadUInt64(address, length).Content;
                return (TValue[])(object)b;
            }

            if (typeof(TValue) == typeof(short))
            {
                var b = busRtuClient.ReadInt16(address, length).Content;
                return (TValue[])(object)b;
            }
            if (typeof(TValue) == typeof(double))
            {
                var b = busRtuClient.ReadDouble(address, length).Content;
                return (TValue[])(object)b;
            }
            if (typeof(TValue) == typeof(float))
            {
                var b = busRtuClient.ReadFloat(address, length).Content;
                return (TValue[])(object)b;

            }
            if (typeof(TValue) == typeof(string))
            {
                var b = busRtuClient.ReadString(address, length).Content;
                return (TValue[])(object)b;
            }

            throw new InvalidOperationException(string.Format("type '{0}' not supported.", typeof(TValue)));
        }
    }
}