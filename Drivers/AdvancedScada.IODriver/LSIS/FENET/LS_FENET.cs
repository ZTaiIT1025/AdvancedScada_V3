
using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Comm;
using HslCommunication;
using HslCommunication.Profinet.LSIS;
using System;
using System.Net.Sockets;

namespace AdvancedScada.IODriver.FENET
{
    public class LS_FENET : IDriverAdapter
    {
        private XGBFastEnet fastEnet = null;
        RequestAndResponseMessage _RequestAndResponseMessage = null;
        public bool IsConnected { get; set; } = false;

        private readonly int Port = 502;
        private readonly string IP = "127.0.0.1";
    
        private object slotNo;
 
        #region construction

        public LS_FENET()
        {
        }
        public LS_FENET(string ip, int port)
            : this()
        {
          
            IP = ip;
            Port = port;
            fastEnet = new XGBFastEnet();
        }

        public LS_FENET(string ip, int port, object slotNo) 
            : this(ip, port)
        {
             
           IP = ip;
            Port = port;
            fastEnet = new XGBFastEnet();
            this.slotNo = slotNo;
            
        }
        

        public void Connection()
        {
           
            try
            {
                
                fastEnet.IpAddress = IP;
                fastEnet.Port = Port;
                fastEnet.SlotNo = 3;

                try
                {
                    OperateResult connect = fastEnet.ConnectServer();
                    if (connect.IsSuccess)
                    {
                         IsConnected = true;
                    }
                   
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                var err = new HMIException.ScadaException(IsConnected);
               
            }
            catch (SocketException ex)
            {

                var err = new HMIException.ScadaException(this.GetType().Name,
                    $"Could Not Connect to Server : {ex.SocketErrorCode}");
                var err1 = new HMIException.ScadaException(false);
                IsConnected = false;

            }
        }

        public void Disconnection()
        {
            try
            {
                fastEnet.ConnectClose();
                var err = new HMIException.ScadaException(false);
                IsConnected = false;
            }
            catch (SocketException ex)
            {
                throw ex;
            }
            finally
            {
                 var err = new HMIException.ScadaException(false);

            }
        }

        #endregion
  
        public byte[] BuildReadByte(byte station, string address, ushort length)
        {
            var frame = DemoUtils.BulkReadRenderResult(fastEnet, address, length);
            _RequestAndResponseMessage = new RequestAndResponseMessage("Reception", "XGT slave", frame);
            return frame;
        }

        public byte[] BuildWriteByte(byte station, string address, byte[] value)
        {
            try
            {
                DemoUtils.WriteResultRender(fastEnet.Write(address, value), address);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new byte[0];
        }
        public bool Write(string address, dynamic value)
        {
            if (value is bool)
            {
                fastEnet.WriteCoil(address, value);
            }
            else
            {
                fastEnet.Write(address, value);
            }
            


            return true;
        }

        public TValue[] Read<TValue>(string address, ushort length)
        {
            if (typeof(TValue) == typeof(bool))
            {
                var b = ReadCoil(address, length);
                return (TValue[])(object)b;
            }
            if (typeof(TValue) == typeof(ushort))
            {
                var b = fastEnet.ReadUInt16(address, length).Content;
               
                    return (TValue[])(object)b;
            }
            if (typeof(TValue) == typeof(int))
            {
                var b = fastEnet.ReadInt32(address, length).Content;

                return (TValue[])(object)b;
            }
            if (typeof(TValue) == typeof(uint))
            {
                var b = fastEnet.ReadUInt32(address, length).Content;
                return (TValue[])(object)b;
            }
            if (typeof(TValue) == typeof(long))
            {
                var b = fastEnet.ReadInt64(address, length).Content;
                return (TValue[])(object)b;
            }
            if (typeof(TValue) == typeof(ulong))
            {
                var b = fastEnet.ReadUInt64(address, length).Content;
                return (TValue[])(object)b;
            }

            if (typeof(TValue) == typeof(short))
            {
                var b = fastEnet.ReadInt16(address, length).Content;
                return (TValue[])(object)b;
            }
            if (typeof(TValue) == typeof(double))
            {
                var b = fastEnet.ReadDouble(address, length).Content;
                return (TValue[])(object)b;
            }
            if (typeof(TValue) == typeof(float))
            {
                var b = fastEnet.ReadFloat(address, length).Content;
                return (TValue[])(object)b;

            }
            if (typeof(TValue) == typeof(string))
            {
                var b = fastEnet.ReadString(address, length).Content;
                return (TValue[])(object)b;
            }

            throw new InvalidOperationException(string.Format("type '{0}' not supported.", typeof(TValue)));
        }

        private object ReadCoil(string address, ushort length)
        {
            var bitArys = DemoUtils.BulkReadRenderResult(fastEnet, address, length);
            return  HslCommunication.BasicFramework.SoftBasic.ByteToBoolArray(bitArys);
        }

        public OperateResult<bool[]> ReadDiscrete(string address, ushort length)
        {
            throw new NotImplementedException();
        }
    }
}