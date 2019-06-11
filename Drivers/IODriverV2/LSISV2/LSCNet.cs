using AdvancedScada.DriverBase.Devices;
using AdvancedScada.XLSIS_V2.Core.Comm;
using Core.DataTypes;
using IODriverV2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using static AdvancedScada.IBaseService.Common.XCollection;

namespace AdvancedScada.XLSIS_V2.Core.Drivers
{
    public class LSCNet : IPLC_LS_Master
    {
        
        private object LockObject = new object();
        private const int DELAY = 200;// delay 100 ms
        private EthernetAdapter EthernetAdaper;
        private SerialPortAdapter SerialAdaper;
        public bool _IsConnected = false;
        //RequestAndResponseMessage _RequestAndResponseMessage = null;
        public LSCNet()
        {

        }
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

            Stopwatch stopwatch = Stopwatch.StartNew();
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
                 
                IsConnected = false;


            }
        }

        public void Disconnection()
        {

            try
            {
                this.SerialAdaper.Close();
              
                IsConnected = false;


            }
            catch (TimeoutException ex)
            {


                EventscadaException?.Invoke(this.GetType().Name, $"Could Not Connect to Server : {ex.Message}");
                
              
            }
        }


        private string _CalcBCC(byte[] data)
        {
            return $"{(byte)(data.Sum((byte b) => b) & 0xFF):X2}";
        }

        private byte[] _GetBytes(LSRequestMessage message)
        {
            if (message == null)
            {
                return null;
            }
            List<byte> list = new List<byte>(16);
            list.AddRange(new byte[1]
            {
            5
            });
            list.AddRange(message.GetAsciiData);
            list.AddRange(new byte[1]
            {
            4
            });
            if (message.IsEnableBCC)
            {
                list.AddRange(Encoding.ASCII.GetBytes(_CalcBCC(list.ToArray())));
            }
            return list.ToArray();
        }

        private bool _CheckedHeader(byte amble)
        {
            switch (amble)
            {
                case 6:
                case 21:
                    return true;
                default:
                    return false;
            }
        }

        protected void _WriteTo(Tag item, string value)
        {

        }
        public byte[] BeginRead(Channel ch, Device dv, DataBlock db)
        {
            byte[] frame = _PollingTo(ch, dv, db);
            this.SerialAdaper.Write(frame, 0, frame.Length);

         //   _RequestAndResponseMessage = new RequestAndResponseMessage("Reception", "XGT slave", frame);
            string tempStrg = string.Empty;
            string buffReceiver = string.Empty;
            Thread.Sleep(DELAY);
            buffReceiver = SerialAdaper.ReadExisting();

            if (buffReceiver == "null") return null;
        //    _RequestAndResponseMessage = new RequestAndResponseMessage("Transmission", "XGT slave", buffReceiver);
            tempStrg = buffReceiver.Substring(1, buffReceiver.Length - 2);
            tempStrg = tempStrg.Remove(0, 9);

            return Conversion.HexToBytes(tempStrg);

        }
        protected byte[] _PollingTo(Channel ch, Device dv, DataBlock db)
        {

            IODriverDataTypes dataType = (IODriverDataTypes)Enum.Parse(typeof(IODriverDataTypes), db.DataType);
            LSDomainTypes lsDomainType = (LSDomainTypes)Enum.Parse(typeof(LSDomainTypes), db.MemoryType);

            int baseAddress = db.StartAddress;
            switch (dataType)
            {
                case IODriverDataTypes.BitOnByte:
                    baseAddress = ((db.StartAddress >= 2) ? (db.StartAddress / 2) : 0) * 2;
                    break;
                case IODriverDataTypes.BitOnWord:
                    baseAddress = db.StartAddress * 2;
                    break;
                case IODriverDataTypes.Bit:
                    baseAddress = ((db.StartAddress >= 16) ? (db.StartAddress / 16) : 0) * 2;
                    break;
                default:
                    baseAddress = db.StartAddress;
                    break;
            }
            string originAddress = "%" + LSNetBase.GetDomainType(lsDomainType) + LSNetBase.GetAddress(dataType, lsDomainType, ch.Rack, ch.Slot, db.StartAddress);
            string str = "%" + LSNetBase.GetDomainType(lsDomainType);
            ushort requestCount = db.Length;
            if (dataType == IODriverDataTypes.Bit || dataType - 177 <= (IODriverDataTypes)1)
            {
                str += LSNetBase.GetAddress(IODriverDataTypes.Byte, lsDomainType, ch.Rack, ch.Slot, baseAddress);
                requestCount = LSNetBase.GetCount(dataType, db.StartAddress, db.Length);
            }
            else
            {
                str += LSNetBase.GetAddress(dataType, lsDomainType, ch.Rack, ch.Slot, baseAddress);
            }
            byte[] frame = _GetBytes(new LSRequestMessage(Guid.NewGuid(), LSRequestTyes.Consecutive, dataType, originAddress, (byte)dv.SlaveId, str, requestCount));

            return frame;

        }
        public bool BeginWrite(Channel ch, Device dv, Tag variable, string value)
        {
            IODriverDataTypes iODriverDataTypes = (IODriverDataTypes)Enum.Parse(typeof(IODriverDataTypes), variable?.DataType);
            string address = variable.Address;
            switch (iODriverDataTypes)
            {
                case IODriverDataTypes.BitOnByte:
                    {
                        string text3 = variable.Address.Substring(1, 1);
                        variable.Address.Substring(2, 1);
                        string text4 = variable.Address.Remove(0, 3);
                        int num3 = 0;
                        int num4 = 0;
                        switch (text3)
                        {
                            case "I":
                            case "Q":
                            case "U":
                                {
                                    string[] array4 = text4.Split(new char[1]
                                    {
                    '.'
                                    }, 4);
                                    address = "%" + text3 + "B" + array4[0] + "." + array4[1] + ".";
                                    num3 = int.Parse(array4[2]);
                                    num4 = int.Parse(array4[3]);
                                    break;
                                }
                            default:
                                {
                                    string[] array3 = text4.Split(new char[1]
                                    {
                    '.'
                                    }, 2);
                                    address = "%" + text3 + "B";
                                    num3 = int.Parse(array3[0]);
                                    num4 = int.Parse(array3[1]);
                                    break;
                                }
                        }
                        address = $"{address}{(num3 * 8 + num4) / 8}.{num4 % 8}";
                        break;
                    }
                case IODriverDataTypes.BitOnWord:
                    {
                        string text = variable.Address.Substring(1, 1);
                        variable.Address.Substring(2, 1);
                        string text2 = variable.Address.Remove(0, 3);
                        int num = 0;
                        int num2 = 0;
                        switch (text)
                        {
                            case "I":
                            case "Q":
                            case "U":
                                {
                                    string[] array2 = text2.Split(new char[1]
                                    {
                    '.'
                                    }, 4);
                                    address = "%" + text + "B" + array2[0] + "." + array2[1] + ".";
                                    num = int.Parse(array2[2]);
                                    num2 = int.Parse(array2[3]);
                                    break;
                                }
                            default:
                                {
                                    string[] array = text2.Split(new char[1]
                                    {
                    '.'
                                    }, 2);
                                    address = "%" + text + "B";
                                    num = int.Parse(array[0]);
                                    num2 = int.Parse(array[1]);
                                    break;
                                }
                        }
                        address = $"{address}{(num * 16 + num2) / 8}.{num2 % 8}";
                        break;
                    }
            }
            if (double.TryParse(value, out double result))
            {
                _Enqueue(new LSRequestMessage(LSNetBase.GetRequestType(iODriverDataTypes), (byte)dv.SlaveId, new _PieceData(address, iODriverDataTypes, result)));
            }
            return false;
        }
        protected void _Enqueue(IPLCMessage message)
        {
            var data = _GetBytes(message as LSRequestMessage);
           // this.SerialAdaper.Write(data, 0, data.Length);
            Thread.Sleep(DELAY);
        }
      
        protected PLCMessageChecker _CheckingOverride(IPLCMessage origin, List<byte> buffer)
        {
            try
            {
                if (buffer.Count < 6)
                {
                    return null;
                }
                if (_CheckedHeader(buffer[0]))
                {
                    byte[] array = buffer.ToArray();
                    int num = 0;
                    byte b = array[num];
                    num++;
                    Encoding.ASCII.GetString(array, num, 2);
                    num += 2;
                    Encoding.ASCII.GetString(array, num, 1);
                    num++;
                    Encoding.ASCII.GetString(array, num, 2);
                    num += 2;
                    int num2 = buffer.IndexOf(3);
                    if (num2 < 0)
                    {
                        return null;
                    }
                    PLCMessageChecker result = null;
                    switch (b)
                    {
                        case 6:
                            result = new PLCMessageChecker(PLCMessageTypes.Ascii, array.Skip(num));
                            break;
                        case 21:
                            {
                                string @string = Encoding.ASCII.GetString(buffer.ToArray(), num, 4);
                                num += 4;
                                //var err = new ErorrPLC.ErorrPLC(this.GetType().Name, "SerialAdaper.Read" + ", Request error - code:" + @string);
                                result = PLCMessageChecker.Complete;
                                break;
                            }
                    }
                    buffer.RemoveRange(0, (buffer.Count > 7 + num2) ? (7 + num2) : buffer.Count);
                    return result;
                }
             //   var err1 = new ErorrPLC.ErorrPLC(this.GetType().Name, "SerialAdaper.Read" + $"Drop Header Octat={buffer[0]:X2}");
                buffer.RemoveAt(0);
                return null;
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, "Error on " + "SerialAdaper.Read" + ", - " + ex.Message);
                return PLCMessageChecker.Complete;
            }
        }

        public byte[] BuildReadByte(byte station, string address, ushort length)
        {
            throw new NotImplementedException();
        }

        public byte[] BuildWriteByte(byte station, string address, byte[] value)
        {
            throw new NotImplementedException();
        }

        public TValue[] Read<TValue>(string address, ushort length)
        {
            throw new NotImplementedException();
        }

        

        public bool Write(string address, dynamic value)
        {
            throw new NotImplementedException();
        }

        public void AllSerialPortAdapter(SerialPortAdapter iXGTSerialPortAdapter)
        {
            SerialAdaper = iXGTSerialPortAdapter;
        }

        public void AllEthernetAdapter(EthernetAdapter iXGTEthernetAdapter)
        {
            EthernetAdaper = iXGTEthernetAdapter;
        }
    }
}
