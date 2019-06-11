using AdvancedScada.DriverBase.Devices;
using AdvancedScada.XLSIS_V2.Core.Comm;
using Core.DataTypes;
using IODriverV2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using static AdvancedScada.IBaseService.Common.XCollection;

namespace AdvancedScada.XLSIS_V2.Core.Drivers
{
    public class LSFENet : IPLC_LS_Master, IDisposable
    {
        protected const string CONNECTED = "CONNECTED";
        protected const string DISCONNECTED = "DISCONNECTED";
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

        private EthernetAdapter EthernetAdaper;


        // Privates
        private SerialPortAdapter SerialAdaper;
        public LSFENet()
        {

        }
        // construction

        public LSFENet(string ip, int port)
            : this()
        {
            Requests = new Dictionary<ushort, LSRequestMessage>(1024);
            EthernetAdaper = new EthernetAdapter(ip, port);
        }

        public LSFENet(string ip, short port, int connectTimeout)
            : this()
        {
            Requests = new Dictionary<ushort, LSRequestMessage>(1024);
            EthernetAdaper = new EthernetAdapter(ip, port, connectTimeout);
        }

        public void AllSerialPortAdapter(SerialPortAdapter iXGTSerialPortAdapter)
        {
            SerialAdaper = iXGTSerialPortAdapter;
        }

        public void AllEthernetAdapter(EthernetAdapter iXGTEthernetAdapter)
        {
            EthernetAdaper = iXGTEthernetAdapter;
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
                    $"Could Not Connect to Server : {ex.SocketErrorCode}Time{stopwatch.ElapsedTicks}");
               
                IsConnected = false;

            }
        }

        public void Disconnection()
        {
            try
            {
                EthernetAdaper.Close();
                
                IsConnected = false;
            }
            catch (SocketException ex)
            {
                throw ex;
            }
            
        }

        private ushort _SerialNo;

        private string _Mode;

        public byte BaseNo
        {
            get;
            private set;
        }

        public string CompanyID
        {
            get;
            private set;
        }
        public byte SlotNo { get; private set; }
        private byte Position
        {
            get;
            set;
        }
        public Dictionary<ushort, LSRequestMessage> Requests
        {
            get;
            private set;
        }
        public static ushort Unsigned16(byte[] bytes, int offset)
        {
            return Unsigned16(bytes.Skip(offset).Take(2).ToArray());
        }
        public static ushort Unsigned16(byte[] bytes)
        {
            return BitConverter.ToUInt16(new byte[2]
            {
        bytes[1],
        bytes[0]
            }, 0);
        }
        protected string[] _OnReceivedOverride(byte[] data)
        {
            string[] dateString = null;
            try
            {
                if (data == null)
                {
                    throw new NullReferenceException();
                }
                if (data.Length < 20)
                {
                    throw new ArgumentException();
                }
                int offset = 0;
                string @string = Encoding.ASCII.GetString(data, offset, 10);
                offset += 10;
                if (!string.IsNullOrEmpty(@string))
                {
                    offset += 2;
                    offset++;
                    byte b = data[offset];
                    offset++;
                    ushort key = BitConverter.ToUInt16(data, offset);

                    offset += 2;
                    BitConverter.ToUInt16(data, offset);
                    offset += 2;
                    offset++;
                    offset++;
                    LSCommandTypes lSCommandTypes = (LSCommandTypes)data[offset];
                    offset += 2;
                    byte b2 = data[offset];
                    offset += 2;
                    offset += 2;
                    ushort num2 = Unsigned16(data, offset);
                    offset += 2;
                    switch (lSCommandTypes)
                    {
                        case LSCommandTypes.RspRead:
                            if (num2 == 0)
                            {
                                PLCResponseMessage pLCResponseMessage = Requests[1]?.CheckBinaryData(data.Skip(offset).ToArray());
                                if (pLCResponseMessage != null)
                                {
                                    return dateString;
                                }
                            }
                            else
                            {
                                EventscadaException?.Invoke(this.GetType().Name, $"Received error code::0x{data[offset]:X2}");
                                offset++;
                            }
                            break;
                        case LSCommandTypes.RspWrite:
                            if (num2 == 0)
                            {
                            }
                            break;
                        default:
                            throw new NotSupportedException();
                    }
                }
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name + ", Received date error - " , ex.Message);

            }
            return null;
        }
        public ushort BlockCount { get; private set; }
        #region FEnet
        public static string GetValStr(byte[] Buff, int iStart, int iDataSize)
        {
            var strVal = string.Empty;
            var strByteVal = string.Empty;
            var i = 0;

            for (i = 0; i < iDataSize; i++)
            {
                strByteVal = Convert.ToString(Buff[i + iStart], 16).ToUpper();
                if (strByteVal.Length == 1) strByteVal = "0" + strByteVal;
                strVal = strByteVal + strVal;
            }

            return strVal;
        }
        //**********************************
        //* Extract a header from a packet
        //**********************************
        public static byte[] Extract(byte[] packet, int length)
        {
            var m_EncapsulatedData = new List<byte>();
            var txtValue = string.Empty;

            // Read Response
            if (packet[20] == 0x55)
                switch (packet[22])
                {
                    case 0: // Bit X
                        for (var i = 32; i < packet.Length; i++) m_EncapsulatedData.Add(packet[i]);
                        break;
                    case 1: //Byte B
                        txtValue = GetValStr(packet, 20 + 12, 1);
                        m_EncapsulatedData.AddRange(Conversion.HexToBytes(txtValue));

                        break;
                    case 2: //Word
                        txtValue = GetValStr(packet, 20 + 12, length);
                        m_EncapsulatedData.AddRange(Conversion.HexToBytes(txtValue));
                        break;
                    case 3: //DWord
                        txtValue = GetValStr(packet, 20 + 12, length);

                        m_EncapsulatedData.AddRange(Conversion.HexToBytes(txtValue));

                        break;
                    case 4: //LWord
                        txtValue = GetValStr(packet, 20 + 12, length);
                        m_EncapsulatedData.AddRange(Conversion.HexToBytes(txtValue));

                        break;
                    case 20:
                        //m_EncapsulatedData.AddRange(ToStringArray(packet, packet.Length));
                        txtValue = GetValStr(packet, 20 + 12, length);
                        m_EncapsulatedData.AddRange(Conversion.HexToBytes(txtValue));

                        break;
                    default:

                        return null;
                }
            return m_EncapsulatedData.ToArray();
        }

        #endregion
        public byte[] BeginRead(Channel ch, Device dv, DataBlock db)
        {
            byte[] data = null;

            this.CompanyID = $"{ch.Mode}";
            this.SlotNo = (byte)ch.Slot;
            this.BaseNo = (byte)ch.Rack;
            this.Position = (byte)(this.SlotNo & 15 | this.BaseNo << 4 & 240);
            this._SerialNo = 0;
            this._Mode = this.CompanyID.PadRight(10, '\0');


            lock (this)
            {
                var FullPacket = _PollingTo(ch, dv, db);
                EthernetAdaper.Write(FullPacket.ToArray());
                Thread.Sleep(100);
                var buffReceiver = EthernetAdaper.Read();

                data = Extract(buffReceiver, db.Length);



                return data;
            }

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
                case IODriverDataTypes.Byte:
                    baseAddress = db.StartAddress;
                    break;
                case IODriverDataTypes.Short:
                case IODriverDataTypes.UShort:
                    baseAddress = db.StartAddress * 2;
                    break;
                case IODriverDataTypes.Int:
                case IODriverDataTypes.UInt:
                    baseAddress = db.StartAddress * 4;
                    break;
                case IODriverDataTypes.Long:
                case IODriverDataTypes.ULong:
                    baseAddress = db.StartAddress * 8;
                    break;
                case IODriverDataTypes.Float:
                    baseAddress = db.StartAddress * 4;
                    break;
                case IODriverDataTypes.Double:
                    baseAddress = db.StartAddress * 8;
                    break;
            }
            string originAddress = "%" + LSNetBase.GetDomainType(lsDomainType) + LSNetBase.GetAddress(dataType, lsDomainType, ch.Rack, ch.Slot, db.StartAddress);
            string requestAddress = "%" + LSNetBase.GetDomainType(lsDomainType) + LSNetBase.GetAddress(IODriverDataTypes.Byte, lsDomainType, ch.Rack, ch.Slot, baseAddress);
            ushort count = LSNetBase.GetCount(dataType, db.StartAddress, db.Length);
            var FullPacket = _WriteTo(new LSRequestMessage(Guid.NewGuid(), LSRequestTyes.Consecutive, dataType, originAddress, (byte)dv.SlaveId, requestAddress, count));
            return FullPacket;
        }
        private byte[] _GetBytes(LSRequestMessage message)
        {
            if (message == null)
            {
                return null;
            }
            byte[] getBinaryData = message.GetBinaryData;
            List<byte> list = new List<byte>(16);
            list.AddRange(Encoding.ASCII.GetBytes(_Mode));
            list.AddRange(new byte[3]
            {
            0,
            0,
            160
            });
            list.Add(51);
            list.AddRange(BitConverter.GetBytes(_SerialNo));
            list.AddRange(BitConverter.GetBytes((ushort)getBinaryData.Length));
            list.Add(Position);
            list.Add((byte)(list.Sum((byte b) => b) & 0xFF));
            list.AddRange(getBinaryData);
            return list.ToArray();
        }
        private byte[] _WriteTo(LSRequestMessage message)
        {
            _SerialNo = (ushort)((int)_SerialNo++ % 255 + 1);
            message?.SetSerial(_SerialNo);
            if (Requests.ContainsKey(_SerialNo))
            {
                Requests[_SerialNo] = message;
            }
            else
            {
                Requests.Add(_SerialNo, message);
            }
            return _GetBytes(message);
        }
        public bool BeginWrite(Channel ch, Device dv, Tag item, string value)
        {
            IODriverDataTypes iODriverDataTypes = (IODriverDataTypes)Enum.Parse(typeof(IODriverDataTypes), item?.DataType);
            string address = item.Address;
            switch (iODriverDataTypes)
            {
                case IODriverDataTypes.BitOnByte:
                    {
                        string text3 = item.Address.Substring(1, 1);
                        item.Address.Substring(2, 1);
                        string text4 = item.Address.Remove(0, 3);
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
                        string text = item.Address.Substring(1, 1);
                        item.Address.Substring(2, 1);
                        string text2 = item.Address.Remove(0, 3);
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
                _SendTo(new LSRequestMessage(LSNetBase.GetRequestType(iODriverDataTypes), (byte)dv.SlaveId, new _PieceData(address, iODriverDataTypes, result)));
            }
            return false;
        }
        protected void _SendTo(LSRequestMessage message)
        {
            EthernetAdaper.Write(_WriteTo(message));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


    }
}
