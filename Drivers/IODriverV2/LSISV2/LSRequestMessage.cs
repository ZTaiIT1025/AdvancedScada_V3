using AdvancedScada.XLSIS_V2.Core.Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedScada.XLSIS_V2.Core.Drivers
{
    public class LSRequestMessage : IPLCMessage
    {
        public Guid UniqueId
        {
            get;
            private set;
        }

        public LSRequestTyes RequestType
        {
            get;
            private set;
        }

        public IODriverDataTypes DataType
        {
            get;
            private set;
        }

        public string OriginAddress
        {
            get;
            private set;
        }

        public byte Device
        {
            get;
            private set;
        }

        public string Device2String => $"{Device:X2}";

        public ushort SerialNo
        {
            get;
            private set;
        }

        public LSCommandTypes Command
        {
            get;
            private set;
        }

        public string Command2String
        {
            get
            {
                switch (Command)
                {
                    case LSCommandTypes.ReqRead:
                    case LSCommandTypes.RspRead:
                        return "R";
                    case LSCommandTypes.ReqWrite:
                    case LSCommandTypes.RspWrite:
                        return "W";
                    case LSCommandTypes.ReqReadWithBCC:
                        return "r";
                    case LSCommandTypes.ReqWriteWithBCC:
                        return "w";
                    default:
                        return "E";
                }
            }
        }

        public string RequestAddress
        {
            get;
            private set;
        }

        public ushort RequestCount
        {
            get;
            private set;
        }

        internal List<_PieceData> Data
        {
            get;
            private set;
        }

        internal int BlockCount
        {
            get
            {
                List<_PieceData> data = Data;
                if (data == null)
                {
                    return 0;
                }
                return data.Count;
            }
        }

        internal string BlockCount2String => $"{BlockCount:X2}";

        internal bool IsEnableBCC
        {
            get
            {
                LSCommandTypes command = Command;
                if (command == LSCommandTypes.ReqReadWithBCC || command == LSCommandTypes.ReqWriteWithBCC)
                {
                    return true;
                }
                return false;
            }
        }

        public int GetAsciiCount
        {
            get
            {
                byte[] getAsciiData = GetAsciiData;
                if (getAsciiData == null)
                {
                    return 0;
                }
                return getAsciiData.Length;
            }
        }

        public int GetBinaryCount
        {
            get
            {
                byte[] getBinaryData = GetBinaryData;
                if (getBinaryData == null)
                {
                    return 0;
                }
                return getBinaryData.Length;
            }
        }

        public byte[] GetAsciiData
        {
            get
            {
                List<byte> list = new List<byte>(16);
                switch (Command)
                {
                    case LSCommandTypes.ReqRead:
                    case LSCommandTypes.ReqReadWithBCC:
                        {
                            LSRequestTyes requestType = RequestType;
                            if (requestType == LSRequestTyes.Consecutive)
                            {
                                list.AddRange(Encoding.ASCII.GetBytes(Device2String + Command2String + "SB"));
                                list.AddRange(Encoding.ASCII.GetBytes($"{RequestAddress.Length:X2}{RequestAddress}{RequestCount:X2}"));
                            }
                            else
                            {
                                list.AddRange(Encoding.ASCII.GetBytes(Device2String + Command2String + "SS" + BlockCount2String));
                                foreach (_PieceData datum in Data)
                                {
                                    list.AddRange(datum.GetAsciiBytesWithoutValue);
                                }
                            }
                            break;
                        }
                    case LSCommandTypes.ReqWrite:
                    case LSCommandTypes.ReqWriteWithBCC:
                        {
                            LSRequestTyes requestType = RequestType;
                            if (requestType != LSRequestTyes.Consecutive)
                            {
                                list.AddRange(Encoding.ASCII.GetBytes(Device2String + Command2String + "SS" + BlockCount2String));
                                foreach (_PieceData datum2 in Data)
                                {
                                    list.AddRange(datum2.GetAsciiBytes);
                                }
                            }
                            break;
                        }
                }
                return list.ToArray();
            }
        }

        public byte[] GetBinaryData
        {
            get
            {
                List<byte> list = new List<byte>(16);
                list.AddRange(new byte[6]
                {
                (byte)Command,
                0,
                (byte)RequestType,
                0,
                0,
                0
                });
                switch (Command)
                {
                    case LSCommandTypes.ReqRead:
                        {
                            LSRequestTyes requestType = RequestType;
                            if (requestType == LSRequestTyes.Consecutive)
                            {
                                list.AddRange(BitConverter.GetBytes((ushort)1));
                                list.AddRange(BitConverter.GetBytes((ushort)Encoding.ASCII.GetByteCount(RequestAddress)));
                                list.AddRange(Encoding.ASCII.GetBytes(RequestAddress));
                                list.AddRange(BitConverter.GetBytes(RequestCount));
                            }
                            else
                            {
                                list.AddRange(BitConverter.GetBytes((ushort)BlockCount));
                                foreach (_PieceData datum in Data)
                                {
                                    list.AddRange(datum.GetBinaryBytesWithoutValue);
                                }
                            }
                            break;
                        }
                    case LSCommandTypes.ReqWrite:
                        {
                            LSRequestTyes requestType = RequestType;
                            if (requestType != LSRequestTyes.Consecutive)
                            {
                                list.AddRange(BitConverter.GetBytes((ushort)BlockCount));
                                foreach (_PieceData datum2 in Data)
                                {
                                    list.AddRange(datum2.GetBinaryBytes);
                                }
                            }
                            break;
                        }
                }
                return list.ToArray();
            }
        }

        private LSRequestMessage()
        {
            Data = new List<_PieceData>(16);
        }

        public LSRequestMessage(LSRequestTyes requestType, byte deviceAddress, _PieceData data)
            : this()
        {
            RequestType = requestType;
            Device = deviceAddress;
            Command = LSCommandTypes.ReqWrite;
            Data.Add(data);
        }

        public LSRequestMessage(LSRequestTyes requestType, byte deviceAddress, IEnumerable<_PieceData> data)
            : this()
        {
            RequestType = requestType;
            Device = deviceAddress;
            Command = LSCommandTypes.ReqWrite;
            Data.AddRange(data);
        }

        public LSRequestMessage(Guid uniqueId, LSRequestTyes requestType, IODriverDataTypes dataType, string originAddress, byte deviceAddress, string requestAddress, ushort requestCount)
            : this()
        {
            UniqueId = uniqueId;
            RequestType = LSRequestTyes.Consecutive;
            DataType = dataType;
            OriginAddress = originAddress;
            Device = deviceAddress;
            Command = LSCommandTypes.ReqRead;
            RequestAddress = requestAddress;
            RequestCount = requestCount;
        }

        public void SetSerial(ushort serial)
        {
            SerialNo = serial;
        }

        public PLCResponseMessage CheckAsciiData(byte[] data)
        {
            LSCommandTypes command = Command;
            if (command == LSCommandTypes.ReqRead || command == LSCommandTypes.ReqReadWithBCC)
            {
                return new LSResponseMessage(PLCMessageTypes.Ascii, this, data);
            }
            return null;
        }

        public PLCResponseMessage CheckBinaryData(byte[] data)
        {
            LSCommandTypes command = Command;
            if (command == LSCommandTypes.ReqRead || command == LSCommandTypes.ReqReadWithBCC)
            {
                return new LSResponseMessage(PLCMessageTypes.Binary, this, data);
            }
            return null;
        }
    }
}
