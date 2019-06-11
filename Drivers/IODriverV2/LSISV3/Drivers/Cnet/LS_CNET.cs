using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using AdvancedScada.XLSIS.Core.Comm;
using Core.DataTypes;
using IODriverV2;
using static AdvancedScada.IBaseService.Common.XCollection;

namespace AdvancedScada.XLSIS.Core.Drivers.Cnet
{
    public class LS_CNET : IPLC_LS_Master, IDisposable
    {
       // public static ConnectionPlc eventConnectionPlc = null;
        private object LockObject = new object();
        private const int DELAY = 200;// delay 100 ms
        private SerialPortAdapter SerialAdaper = null;
        private EthernetAdapter EthernetAdaper = null;
        public bool _IsConnected = false;
        private static string txtValue;
      //  RequestAndResponseMessage _RequestAndResponseMessage = null;
        #region IPLC_LS_Master
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
                 
                throw ex;
            }
        }

        public byte[] BeginRead(int station, string type, int strVar, int numberOfElements, string DataBlockName)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                lock (LockObject)
                {

                    string tempStrg = string.Empty;
                    string buffReceiver = string.Empty;
                    byte[] frame = ReadBytes(station, type, strVar, numberOfElements);
                    this.SerialAdaper.Write(frame, 0, frame.Length);

                 //   _RequestAndResponseMessage = new RequestAndResponseMessage("Reception", "XGT slave", frame);

                    Thread.Sleep(500);
                    buffReceiver = SerialAdaper.ReadExisting();

                    if (buffReceiver == "null") return null;
                   // _RequestAndResponseMessage = new RequestAndResponseMessage("Transmission", "XGT slave", buffReceiver);
                    tempStrg = buffReceiver.Substring(1, buffReceiver.Length - 2);
                    tempStrg = tempStrg.Remove(0, 9);

                    return Conversion.HexToBytes(tempStrg);
                }
            }
            catch (TimeoutException ex)
            {
                EventscadaException?.Invoke(this.GetType().Name,
                    $"Write : {ex.Message} : {ex.Message} : TimeElapsedMilliseconds :={stopwatch.ElapsedTicks} ");

                throw ex;
            }
        }

        public bool BeginWrite(int station, string type, int strVar, string value)
        {

           
            try
            {
                lock (LockObject)
                {
                    string buffReceiver = string.Empty;

                    byte[] frame = WriteBytes(station, type, ushort.Parse(value));
                    this.SerialAdaper.Write(frame, 0, frame.Length);
                    Thread.Sleep(500);
                    buffReceiver = SerialAdaper.ReadExisting();
                   // _RequestAndResponseMessage = new RequestAndResponseMessage("Transmission", "XGT slave", buffReceiver);

                    if (buffReceiver == null) return false;

                    

                }
                return true;
            }
            catch (TimeoutException ex)
            {
                EventscadaException?.Invoke(this.GetType().Name,
                    $"Write : {ex.Message} : {ex.Message} : TimeElapsedMilliseconds");

                throw ex;
            }
        }
        #endregion
        #region Read
        public static byte[] Read(int station, ref string type, int address, int size, int datatype, ref int CountSend, ref int CountNeed)
        {
            byte[] commSendBuf = new byte[Functions.MAX_SEND_BUF + 1];
            string imsi = new string(new char[80]);

            commSendBuf[0] = (byte)Functions.ENQ; // STX
            Encoding.ASCII.GetBytes($"{station:X2}").CopyTo(commSendBuf, 1); // status
            Encoding.ASCII.GetBytes("R").CopyTo(commSendBuf, 3); // status
            Encoding.ASCII.GetBytes("SB").CopyTo(commSendBuf, 4); // mode
            imsi = $"%{type}{address:D4}";
            Encoding.ASCII.GetBytes($"{imsi.Length:X2}").CopyTo(commSendBuf, 6);
            Encoding.ASCII.GetBytes($"{imsi}").CopyTo(commSendBuf, 8);
            Functions.commCountSend = 8 + imsi.Length;
            Encoding.ASCII.GetBytes($"{size:X2}").CopyTo(commSendBuf, Functions.commCountSend); // module no
            Functions.commCountSend += 2;
            commSendBuf[Functions.commCountSend] = (byte)Functions.EOT; // STX
            Functions.commCountSend += 1;
            CountSend = Functions.commCountSend;
            byte[] SendBuf = new byte[Functions.commCountSend];
            Array.Copy(commSendBuf, 0, SendBuf, 0, SendBuf.Length);

            if (datatype == 1)
            {
                Functions.commCountNeed = 13 + size * 4; // STX+COMMAND+STATION+ADDRESS+SIZE+DATA+CRC+ETX
            }
            else
            {
                Functions.commCountNeed = 13 + size * 8; // STX+COMMAND+STATION+ADDRESS+SIZE+DATA+CRC+ETX
            }
            CountNeed = Functions.commCountNeed;
            return SendBuf;
        }
        public static byte[] ReadBytes(int station, string type, int strVar, int count)
        {
            try
            {
                int commCountNeed = 0;
                int commCountSend = 0;
                int data_type2 = 0;
                int num = Functions.GetDataType(type, ref data_type2);
                byte[] FullPacket = Read(station, ref type, strVar, count, data_type2, ref commCountSend, ref commCountNeed);
                return FullPacket;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }

        }
        #endregion
        #region Write
        public  byte[] WriteBytes(int station, string type, ushort value)
        {
            try
            {
                byte[] FullPacket = null;
                string frame = type.Substring(1, 2);
                int data_type2 = 0;
                int num = Functions.GetDataType(frame, ref data_type2);
                switch (frame)
                {
                    case "MX":
                        FullPacket = WriteBit(station, type, value, data_type2);

                        break;
                    case "DW":
                        FullPacket = WriteWord(station, type, (double)value, data_type2);
                        break;
                }
                //  _RequestAndResponseMessage = new RequestAndResponseMessage("Reception", "XGT slave", FullPacket);

                return FullPacket;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }

        }

        public static byte[] WriteBit(int station, string address, ushort flag, int data_type)
        {
            int commCountSend = 0;
            byte[] commSendBuf = new byte[Functions.MAX_SEND_BUF + 1];
            byte[] commRecvBuf = new byte[Functions.MAX_SEND_BUF + 1];
            string imsi = new string(new char[80]);

            commSendBuf[0] = (byte)Functions.ENQ; // STX
            Encoding.ASCII.GetBytes($"{station:X2}").CopyTo(commSendBuf, 1); // status
            Encoding.ASCII.GetBytes(string.Format("WSS", station)).CopyTo(commSendBuf, 3); // status
            Encoding.ASCII.GetBytes($"{(byte) 1:X2}").CopyTo(commSendBuf, 6);

            Encoding.ASCII.GetBytes($"{address.Length:X2}").CopyTo(commSendBuf, 8);

            Encoding.ASCII.GetBytes($"{address}").CopyTo(commSendBuf, 10); // module no
            commCountSend = 10 + address.Length;


            if (data_type == 0)
            {
                Encoding.ASCII.GetBytes($"{(byte) flag:X2}").CopyTo(commSendBuf, commCountSend); // module no
                commCountSend += 2;
            }
            else if (data_type == 2)
            {
                Encoding.ASCII.GetBytes($"{(uint) flag:X8}").CopyTo(commSendBuf, commCountSend); // module no
                commCountSend += 8;
            }
            else // WORD
            {
                Encoding.ASCII.GetBytes($"{flag:X4}").CopyTo(commSendBuf, commCountSend); // module no
                commCountSend += 4;
            }
            commSendBuf[commCountSend] = (byte)Functions.EOT; // STX
            commCountSend += 1;
            byte[] DATA = new byte[commCountSend];

            Array.Copy(commSendBuf, DATA, commCountSend);

            return DATA;
        }

        public static byte[] WriteWord(int station, string address, double value, int data_type)
        {
            int commCountSend = 0;
            byte[] commSendBuf = new byte[Functions.MAX_SEND_BUF + 1];
            byte[] commRecvBuf = new byte[Functions.MAX_SEND_BUF + 1];
            string imsi = new string(new char[80]);

            commSendBuf[0] = (byte)Functions.ENQ; // STX
            Encoding.ASCII.GetBytes($"{station:X2}").CopyTo(commSendBuf, 1); // status
            Encoding.ASCII.GetBytes(string.Format("WSB", station)).CopyTo(commSendBuf, 3); // status

            Encoding.ASCII.GetBytes($"{address.Length:X2}").CopyTo(commSendBuf, 6);
            Encoding.ASCII.GetBytes($"{address}").CopyTo(commSendBuf, 8);
            commCountSend = 8 + address.Length;
            Encoding.ASCII.GetBytes($"{byte.Parse("1"):X2}").CopyTo(commSendBuf, commCountSend);
            commCountSend += 2;
            if (data_type == 0)
            {
                Encoding.ASCII.GetBytes($"{System.Convert.ToByte(Math.Truncate(value)):X2}").CopyTo(commSendBuf, commCountSend); // module no
                commCountSend += 2;
            }
            else if (data_type == 2)
            {
                Encoding.ASCII.GetBytes($"{System.Convert.ToUInt32(Math.Truncate(value)):X8}").CopyTo(commSendBuf, commCountSend); // module no
                commCountSend += 8;
            }
            else // WORD
            {
                Encoding.ASCII.GetBytes($"{System.Convert.ToUInt16(Math.Truncate(value)):X4}").CopyTo(commSendBuf, commCountSend); // module no
                commCountSend += 4;
            }
            commSendBuf[commCountSend] = (byte)Functions.EOT; // STX
            commCountSend += 1;



            byte[] DATA = new byte[commCountSend];

            Array.Copy(commSendBuf, DATA, commCountSend);

            return DATA;


        }

        public   byte[] Write(int station, string variable, int numberOfElements, string value)
        {

            var dataPacket = new List<byte>();
            byte Bcc = 0;
            int iBcc = 0;
            byte[] x;
            string sBcc = string.Empty;
            string frame = string.Empty;
            switch (variable.Substring(1, 2))
            {
                case "MX":

                    frame += $"{station:X2}";
                    frame += $"WSS01{$"{variable.Length:X2}"}{variable}";
                    //frame += string.Format("{0:X2}", startAddress);
                    frame += $"{byte.Parse(value):X2}";


                    // BCC
                    iBcc = 5 + Functions.ByteCheckSum(frame) + 4;
                    if (iBcc > 255)
                    {
                        iBcc = iBcc - 256;
                    }
                    Bcc = Convert.ToByte(iBcc);
                    sBcc = Functions.ByteToHexStr(Bcc);

                    break;
                case "DW":
                    string[] dataAsArray = { value };
                    foreach (var t in dataAsArray)
                    {
                        x = BitConverter.GetBytes(Convert.ToInt16(t));
                        dataPacket.Add(x[1]);
                        dataPacket.Add(x[0]);
                    }
                    txtValue = Functions.GetValStr(dataPacket.ToArray(), 0, dataPacket.Count);
                    frame += $"{station:X2}";
                    frame += $"WSB{$"{variable.Length:X2}"}{variable}";
                    frame += "01" + txtValue;

                    // BCC
                    iBcc = 5 + Functions.ByteCheckSum(frame) + 4;
                    if (iBcc > 255)
                    {
                        iBcc = iBcc - 256;
                    }
                    Bcc = Convert.ToByte(iBcc);
                    sBcc = Functions.ByteToHexStr(Bcc);

                    break;
                default:
                    break;
            }
            byte[] TxWrite = Encoding.ASCII.GetBytes((char)5 + frame + (char)4 + sBcc);
          //  _RequestAndResponseMessage = new RequestAndResponseMessage("Reception", "XGT slave", TxWrite);


            return TxWrite;

        }
        object mutexDispose = new object();
        public void Dispose()
        {
            lock (mutexDispose)
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }
        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {

                txtValue = null;
            }
         
        }

       
        ~ LS_CNET()
        {
            Dispose(false);
        }
        #endregion

    }
}
