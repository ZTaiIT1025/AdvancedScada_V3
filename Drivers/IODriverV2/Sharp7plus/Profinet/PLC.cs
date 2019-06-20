using AdvancedScada.DriverBase.Devices;
using AdvancedScada.IODriverV2.Sharp7plus.Comm;
using Sharp7;
using System;
using System.Diagnostics;
using System.Net.Sockets;
using static AdvancedScada.IBaseService.Common.XCollection;

namespace AdvancedScada.IODriverV2.Sharp7plus.Profinet

{
    /// <summary>
    /// Creates an instance of S7Net.Core driver
    /// </summary>
    public class Plc : IPLCS7Master
    {
        private const int CONNECTION_TIMED_OUT_ERROR_CODE = 10060;


        S7Client client = null;
        private volatile object _locker = new object();
        bool _IsConnected;
        /// <summary>
        /// IP address of the PLC
        /// </summary>
        public string IP { get; private set; }

        /// <summary>
        /// CPU type of the PLC
        /// </summary>
        public string CPU { get; private set; }

        /// <summary>
        /// Rack of the PLC
        /// </summary>
        public Int16 Rack { get; private set; }

        /// <summary>
        /// Slot of the CPU of the PLC
        /// </summary>
        public Int16 Slot { get; private set; }

        /// <summary>
        /// Max PDU size this cpu supports
        /// </summary>
        public Int16 MaxPDUSize { get; set; }

        /// <summary>
        /// Returns true if a connection to the PLC can be established
        /// </summary>
        public bool IsAvailable
        {
            //TODO: Fix This
            get
            {
                try
                {
                    //  Connect();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Checks if the socket is connected and polls the other peer (the PLC) to see if it's connected.
        /// This is the variable that you should continously check to see if the communication is working
        /// See also: http://stackoverflow.com/questions/2661764/how-to-check-if-a-socket-is-connected-disconnected-in-c
        /// </summary>
        public bool IsConnected
        {
            get
            {
                return _IsConnected;
            }
            set
            {

            }
        }

        public Plc(string ip, Int16 rack, Int16 slot)
        {

            if (string.IsNullOrEmpty(ip))
                throw new ArgumentException("IP address must valid.", nameof(ip));


            IP = ip;
            Rack = rack;
            Slot = slot;
            MaxPDUSize = 240;
        }



        /// <summary>
        /// 
        /// </summary>
        public string DeviceName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object Tag { get; set; }


        // construction
        /// <summary>
        /// 
        /// </summary>
        public Plc()
        {
            IP = "localhost";

            Rack = 0;
            Slot = 3;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cpu"></param>
        /// <param name="ip"></param>
        /// <param name="rack"></param>
        /// <param name="slot"></param>
        /// <param name="name"></param>
        /// <param name="tag"></param>
        public Plc(string ip, Int16 rack, Int16 slot, string name, object tag)
        {
            IP = ip;

            Rack = rack;
            Slot = slot;
            DeviceName = name;
            Tag = tag;
        }
        #region Connection (Open, Close)


        public void Connection()
        {
            var stopwatch = Stopwatch.StartNew();
            try
            {
                //-------------- Create and connect the client
                client = new S7Client();
                int result = client.ConnectTo(IP, Rack, Slot);
                if (result == 0)
                {
                    Console.WriteLine("Connected to 127.0.0.1");
                    _IsConnected = true;

                }
                else
                {
                    _IsConnected = false;
                    Console.WriteLine(client.ErrorText(result));

                    return;
                }

                stopwatch.Stop();
            }
            catch (SocketException ex)
            {

                stopwatch.Stop();

                EventscadaException?.Invoke(this.GetType().Name, string.Format("Could Not Connect to Server : {0} Time: {1}", ex.SocketErrorCode,
                    stopwatch.ElapsedTicks));


            }
        }

        public void Disconnection()
        {
            try
            {
                client.Disconnect();


            }
            catch (SocketException ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }

        }
        int result;
        #endregion
        public object ReadStruct(DataBlock structType, int db, int startByteAdr = 0)
        {
            int numBytes = Struct.GetStructSize(structType);
            // now read the package
            byte[] db1Buffer = new byte[512];

            result = client.DBRead(db, startByteAdr, numBytes, db1Buffer);
            if (result != 0)
            {
                Console.WriteLine("Error: " + client.ErrorText(result));
            }

            // and decode it
            return Struct.FromBytes(structType, db1Buffer, this);
        }



        public void Write(string address, string varType, object value)
        {


            switch (varType)
            {
                case "Byte":

                    return;
                case "Word":
                    var writeResult = WriteWord(address, short.Parse(value.ToString()));
                    if (writeResult != 0)
                    {
                        Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss") + "\t Write error: " +
                                        client.ErrorText(writeResult));
                    }
                    return;
                case "Int":


                    return;

                case "DWord":
                    //  S7.SetDWordAt(db1Buffer, address, (uint)value);

                    return;
                case "DInt":
                    // S7.SetDIntAt(db1Buffer, address, (int)value);

                    return;
                case "Real":
                    var writeResultReal = WriteReal(address, float.Parse(value.ToString()));
                    if (writeResultReal != 0)
                    {
                        Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss") + "\t Write error: " +
                                        client.ErrorText(writeResultReal));
                    }

                    return;
                case "String":
                    var writeResultString = WriteString(address, (string)value);
                    if (writeResultString != 0)
                    {
                        Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss") + "\t Write error: " +
                                        client.ErrorText(writeResultString));
                    }


                    break;
                case "Bit":
                    int writeResultBit = WriteBit(address, (bool)value);
                    if (writeResultBit != 0)
                    {
                        Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss") + "\t Write error: " +
                                        client.ErrorText(writeResultBit));
                    }
                    return;
                default:
                    break;
            }

        }



        /// <summary>
        /// Writes a bit at the specified address. Es.: DB1.DBX10.2 writes the bit in db 1, word 10, 3rd bit
        /// </summary>
        /// <param name="address">Es.: DB1.DBX10.2 writes the bit in db 1, word 10, 3rd bit</param>
        /// <param name="value">true or false</param>
        /// <returns></returns>
        private int WriteBit(string address, bool value)
        {
            var strings = address.Split('.');
            int db = Convert.ToInt32(strings[0].Replace("DB", string.Empty));
            int pos = Convert.ToInt32(strings[1].Replace("DBX", string.Empty));
            int bit = Convert.ToInt32(strings[2]);
            return WriteBit(db, pos, bit, value);
        }

        private int WriteBit(int db, int pos, int bit, bool value)
        {
            lock (_locker)
            {
                var buffer = new byte[1];
                Sharp7.S7.SetBitAt(ref buffer, 0, bit, value);
                return client.WriteArea(S7Consts.S7AreaDB, db, pos + bit, buffer.Length, S7Consts.S7WLBit, buffer);
            }
        }


        private int WriteWord(string address, short value)
        {
            var strings = address.Split('.');
            var db = Convert.ToInt32(strings[0].Replace("DB", string.Empty));
            var pos = Convert.ToInt32(strings[1].Replace("DBW", string.Empty));
            return WriteWord(db, pos, value);
        }

        private int WriteWord(int dbNumber, int startIndex, short value)
        {
            lock (_locker)
            {
                var buffer = new byte[2];
                Sharp7.S7.SetIntAt(buffer, 0, value);
                return client.DBWrite(dbNumber, startIndex, buffer.Length, buffer);
            }
        }

        private int WriteReal(string address, float value)
        {
            var strings = address.Split('.');
            var db = Convert.ToInt32(strings[0].Replace("DB", string.Empty));
            var pos = Convert.ToInt32(strings[1].Replace("DBD", string.Empty));
            return WriteReal(db, pos, value);
        }

        private int WriteReal(int dbNumber, int startIndex, float value)
        {
            lock (_locker)
            {
                var buffer = new byte[4];
                Sharp7.S7.SetRealAt(buffer, 0, value);

                return client.DBWrite(dbNumber, startIndex, buffer.Length, buffer);
            }
        }
        private int WriteString(string address, string value)
        {
            var strings = address.Split('.');
            var db = Convert.ToInt32(strings[0].Replace("DB", string.Empty));
            var pos = Convert.ToInt32(strings[1].Replace("DBB", string.Empty));
            return WriteString(db, pos, value);
        }

        private int WriteString(int dbNumber, int startIndex, string value)
        {
            lock (_locker)
            {
                var buffer = new byte[value.Length + 2];
                Sharp7.S7.SetStringAt(buffer, 0, value.Length, value);

                return client.DBWrite(dbNumber, startIndex, buffer.Length, buffer);
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

        public void AllSerialPortAdapter(SerialPortAdapter iModbusSerialPortAdapter)
        {
            throw new NotImplementedException();
        }

        public void AllEthernetAdapter(EthernetAdapter iModbusEthernetAdapter)
        {
            throw new NotImplementedException();
        }
    }
}
