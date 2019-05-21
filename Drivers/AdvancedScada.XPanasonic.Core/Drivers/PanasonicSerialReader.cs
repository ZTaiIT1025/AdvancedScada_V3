using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Comm;
using AdvancedScada.XPanasonic.Core.Comm;
using HslCommunication;
using HslCommunication.Profinet.Panasonic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedScada.XPanasonic.Core.Drivers
{
    public class PanasonicSerialReader : IPanasonic
    {
        
        private SerialPort serialPort;
        private PanasonicMewtocol panasonicMewtocol = null;
      
        public bool _IsConnected = false;
        private object LockObject = new object();
        public bool IsConnected { get => _IsConnected; set => _IsConnected = value; }
        public PanasonicSerialReader(short slaveId, SerialPort serialPort)
        {
            Station = (byte)slaveId;
            this.serialPort = serialPort;
        }
        public byte Station { get => station; set => station = value; }

      

        private byte station;
        public void Connection()
        {

            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                lock (LockObject)
                {


                    panasonicMewtocol?.Close();
                    panasonicMewtocol = new PanasonicMewtocol(station);

                    try
                    {
                        panasonicMewtocol.SerialPortInni(sp =>
                        {
                            sp.PortName = serialPort.PortName;
                            sp.BaudRate = serialPort.BaudRate;
                            sp.DataBits = serialPort.DataBits;
                            sp.StopBits = serialPort.StopBits;
                            sp.Parity = serialPort.Parity;
                        });
                        panasonicMewtocol.Open();
                        IsConnected = true;
                    }
                    catch (Exception ex)
                    {
                        var err1 = new HMIException.ScadaException(this.GetType().Name, ex.Message);
                    }
                    var err = new HMIException.ScadaException(IsConnected);
                    stopwatch.Stop();
                }
            }
            catch (TimeoutException ex)
            {
                stopwatch.Stop();
                var err = new HMIException.ScadaException(this.GetType().Name,
                    $"Could Not Connect to Server : {ex.Message}Time{stopwatch.ElapsedTicks}");
                var err1 = new HMIException.ScadaException(false);
                IsConnected = false;
            }
        }

        public void Disconnection()
        {

            try
            {
                panasonicMewtocol.Close();
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


        
        public bool  Write(string address, dynamic value)
        {
            if (value is bool)
            {
                panasonicMewtocol.Write(address, value);
            }
            else
            {
                panasonicMewtocol.Write(address, value);
            }

            return true;
        }

        public TValue[] Read<TValue>(string address, ushort length)
        {
            if (typeof(TValue) == typeof(bool))
            {
                var b = panasonicMewtocol.ReadBool(address, length).Content;
                return (TValue[])(object)b;
            }
            if (typeof(TValue) == typeof(ushort))
            {
                var b = panasonicMewtocol.ReadUInt16(address, length).Content;

                return (TValue[])(object)b;
            }
            if (typeof(TValue) == typeof(int))
            {
                var b = panasonicMewtocol.ReadInt32(address, length).Content;

                return (TValue[])(object)b;
            }
            if (typeof(TValue) == typeof(uint))
            {
                var b = panasonicMewtocol.ReadUInt32(address, length).Content;
                return (TValue[])(object)b;
            }
            if (typeof(TValue) == typeof(long))
            {
                var b = panasonicMewtocol.ReadInt64(address, length).Content;
                return (TValue[])(object)b;
            }
            if (typeof(TValue) == typeof(ulong))
            {
                var b = panasonicMewtocol.ReadUInt64(address, length).Content;
                return (TValue[])(object)b;
            }

            if (typeof(TValue) == typeof(short))
            {
                var b = panasonicMewtocol.ReadInt16(address, length).Content;
                return (TValue[])(object)b;
            }
            if (typeof(TValue) == typeof(double))
            {
                var b = panasonicMewtocol.ReadDouble(address, length).Content;
                return (TValue[])(object)b;
            }
            if (typeof(TValue) == typeof(float))
            {
                var b = panasonicMewtocol.ReadFloat(address, length).Content;
                return (TValue[])(object)b;

            }
            if (typeof(TValue) == typeof(string))
            {
                var b = panasonicMewtocol.ReadString(address, length).Content;
                return (TValue[])(object)b;
            }

            throw new InvalidOperationException(string.Format("type '{0}' not supported.", typeof(TValue)));
        }
    }
}
