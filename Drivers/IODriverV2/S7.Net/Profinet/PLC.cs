using AdvancedScada;
using AdvancedScada.DriverBase.Devices;
using IODriverV2;
using S7.Net;
using System;
using System.Diagnostics;
using System.Net.Sockets;
using XSiemens.Core.Comm;
using static AdvancedScada.IBaseService.Common.XCollection;

namespace XSiemens.Core.Profinet

{
    /// <summary>
    /// Creates an instance of S7Net.Core driver
    /// </summary>
    public class PLC : S7.Net.Plc, IPLCS7Master, IDisposable
    {
        private EthernetAdapter EthernetAdaper;
        public EventConnectionStateChanged eventConnectionStateChanged = null;
        private SerialPortAdapter SerialAdaper;
        
        public PLC(CpuType cpu, string ip, short rack, short slot) : base(cpu, ip, rack, slot)
        {
        }







        /// <summary>
        /// 
        /// </summary>
        public string DeviceName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object Tag { get; set; }
        bool IDriverAdapterV2.IsConnected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


      
       
        #region Connection (Open, Close)


        public void Connection()
        {
            var stopwatch = Stopwatch.StartNew();
            try
            {
                Open();
              
                stopwatch.Stop();
            }
            catch (SocketException ex)
            {
                Close();
                stopwatch.Stop();

                EventscadaException?.Invoke(this.GetType().Name, string.Format("Could Not Connect to Server : {0} Time: {1}", ex.SocketErrorCode,
                    stopwatch.ElapsedTicks));
             

            }
        }

        public void Disconnection()
        {
            try
            {
                Close();

                
            }
            catch (SocketException ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
           
        }

        #endregion
        public object ReadStruct(DataBlock structType, int db, int startByteAdr = 0)
        {
            int numBytes = Struct.GetStructSize(structType);
            // now read the package

            var resultBytes = ReadBytes(DataType.DataBlock, db, startByteAdr, numBytes);
            // and decode it
            return Struct.FromBytes(structType, resultBytes, this);
        }

        public void AllSerialPortAdapter(SerialPortAdapter iS7SerialPortAdapter)
        {
            SerialAdaper = iS7SerialPortAdapter;
        }

        public void AllEthernetAdapter(EthernetAdapter iS7EthernetAdapter)
        {
            EthernetAdaper = iS7EthernetAdapter;
        }

        public void WriteString(string variable, object value)
        {
            throw new NotImplementedException();
        }
    }
}
