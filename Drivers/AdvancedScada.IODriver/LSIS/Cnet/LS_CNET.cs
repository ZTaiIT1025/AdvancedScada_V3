using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Comm;
using HslCommunication;
using HslCommunication.Profinet.LSIS;
using System;
using System.IO.Ports;

namespace AdvancedScada.IODriver.Cnet
{
    public class LS_CNET : IDriverAdapter
    {
        private SerialPort serialPort;
        private XGBCnet xGBCnet = null;
        RequestAndResponseMessage _RequestAndResponseMessage = null;

        private object LockObject = new object();
        public LS_CNET(short slaveId, SerialPort serialPort)
        {
            Station = (byte)slaveId;
            this.serialPort = serialPort;
        }

        #region IReadWritePLC
        public bool IsConnected { get; set; } = false;
        public byte Station { get; set; }
        public void Connection()
        {

           
            try
            {
                lock (LockObject)
                {
                    xGBCnet?.Close();
                    xGBCnet = new XGBCnet();
                    xGBCnet.Station = Station;

                    try
                    {
                        xGBCnet.SerialPortInni(sp =>
                        {
                            sp.PortName = serialPort.PortName;
                            sp.BaudRate = serialPort.BaudRate;
                            sp.DataBits = serialPort.DataBits;
                            sp.StopBits = serialPort.StopBits;
                            sp.Parity = serialPort.Parity;
                        });
                        xGBCnet.Open();
                        IsConnected = true;
                    }
                    catch (Exception ex)
                    {
                        var err1 = new  HMIException.ScadaException(this.GetType().Name, ex.Message);
                    }
                    var err = new HMIException.ScadaException(IsConnected);
                   
                }
            }
            catch (TimeoutException ex)
            {
                var err = new HMIException.ScadaException(this.GetType().Name,
                    $"Could Not Connect to Server : {ex.Message}");
                var err1 = new HMIException.ScadaException(false);
                IsConnected = false;
            }
        }
        public void Disconnection()
        {

            try
            {
                xGBCnet.Close();
                var err = new HMIException.ScadaException(false);
                IsConnected = false;
            }
            catch (TimeoutException ex)
            {
                var err = new HMIException.ScadaException(this.GetType().Name, $"Could Not Connect to Server : {ex.Message}");
                var err1 = new HMIException.ScadaException(false);
                throw ex;
            }
        }
        #endregion
      
        public byte[] BuildReadByte(byte station, string address, ushort length)
        {
            var frame = DemoUtils.BulkReadRenderResult(xGBCnet, address, length);
            _RequestAndResponseMessage = new RequestAndResponseMessage("Reception", "XGT slave", frame);
            return frame;
        }

        public byte[] BuildWriteByte(byte station, string address, byte[] value)
        {
            try
            {
                DemoUtils.WriteResultRender(xGBCnet.Write(address, value), address);
            }
            catch (Exception ex)
            {
               
            }
            return new byte[0];
        }

        public bool  Write(string address, dynamic value)
        {

            if (value is bool)
            {
                xGBCnet.WriteCoil(address, value);
            }
            else
            {
                xGBCnet.Write(address, value);
            }
            return true;
        }

        public TValue[] Read<TValue>(string address, ushort length)
        {

            if (typeof(TValue) == typeof(ushort))
            {
                var b = xGBCnet.ReadUInt16(address, length).Content;

                return (TValue[])(object)b;
            }
            if (typeof(TValue) == typeof(int))
            {
                var b = xGBCnet.ReadInt32(address, length).Content;

                return (TValue[])(object)b;
            }
            if (typeof(TValue) == typeof(uint))
            {
                var b = xGBCnet.ReadUInt32(address, length).Content;
                return (TValue[])(object)b;
            }
            if (typeof(TValue) == typeof(long))
            {
                var b = xGBCnet.ReadInt64(address, length).Content;
                return (TValue[])(object)b;
            }
            if (typeof(TValue) == typeof(ulong))
            {
                var b = xGBCnet.ReadUInt64(address, length).Content;
                return (TValue[])(object)b;
            }

            if (typeof(TValue) == typeof(short))
            {
                var b = xGBCnet.ReadInt16(address, length).Content;
                return (TValue[])(object)b;
            }
            if (typeof(TValue) == typeof(double))
            {
                var b = xGBCnet.ReadDouble(address, length).Content;
                return (TValue[])(object)b;
            }
            if (typeof(TValue) == typeof(float))
            {
                var b = xGBCnet.ReadFloat(address, length).Content;
                return (TValue[])(object)b;

            }
            if (typeof(TValue) == typeof(string))
            {
                var b = xGBCnet.ReadString(address, length).Content;
                return (TValue[])(object)b;
            }

            throw new InvalidOperationException(string.Format("type '{0}' not supported.", typeof(TValue)));
        }

        public OperateResult<bool[]> ReadDiscrete(string address, ushort length)
        {
            throw new NotImplementedException();
        }
    }
}
