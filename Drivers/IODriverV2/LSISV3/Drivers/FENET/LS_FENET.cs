
using AdvancedScada.DriverBase.Comm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using AdvancedScada.XLSIS.Core.Comm;
using IODriverV2;
using static AdvancedScada.IBaseService.Common.XCollection;
using Core.DataTypes;

namespace AdvancedScada.XLSIS.Core.Drivers.FENET
{
    public class LS_FENET : IPLC_LS_Master, IDisposable
    {
        protected const string CONNECTED = "CONNECTED";
        protected const string DISCONNECTED = "DISCONNECTED";
        public bool _IsConnected = false;
      //  RequestAndResponseMessage _RequestAndResponseMessage = null;
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

        public EventConnectionStateChanged eventConnectionStateChanged = null;
        // Privates
        private SerialPortAdapter SerialAdaper;
        object mutexDispose = new object();

        #region Write

        public bool BeginWrite(int station, string variable, int numberOfElements, string value)
        {
            var stopwatch = Stopwatch.StartNew();
            try
            {
                var TxWrite = Write(variable, value);
                EthernetAdaper.Write(TxWrite.ToArray());
                //Thread.Sleep(100);
                //var buffReceiver = EthernetAdaper.Read();
                //RequestAndResponseMessage _RequestAndResponseMessage = new RequestAndResponseMessage("ResponseWrite", buffReceiver);

                stopwatch.Stop();

                // return buffReceiver;
                return true;
            }
            catch (SocketException ex)
            {

                EventscadaException?.Invoke(this.GetType().Name,
                    $"Write : {ex.ErrorCode} : {ex.SocketErrorCode} : TimeElapsedMilliseconds :={stopwatch.ElapsedTicks} ");


                throw ex;
            }
        }

        /// <summary>
        /// Write
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="numberOfElements"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] Write(string variable, string value)
        {
            string[] DataAsArray = { value };
            object objValue = string.Empty;
            List<byte> dataPacket = new List<byte>();
            string txt = variable.ToUpper();
            txt = txt.Replace(" ", string.Empty); // Leerzeichen entfernen
            string strVar = string.Empty;
            byte[] x = null;
            strVar = variable.ToUpper();
            try
            {
                switch (txt.Substring(1, 2))
                {
                    case "DW":
                        x = new byte[4];
                        for (int i = 0; i < DataAsArray.Length; i++)
                        {
                            BitConverter.GetBytes(short.Parse(DataAsArray[i])).CopyTo(x, 0);
                        }
                        Array.Reverse(x);
                        return WriteVariable(strVar, x, 2);
                    case "DD":
                        // Eingangsbyte
                        x = new byte[8];
                        for (int i = 0; i < DataAsArray.Length; i++)
                        {
                            BitConverter.GetBytes(short.Parse(DataAsArray[i])).CopyTo(x, 0);
                        }

                        return WriteVariable(strVar, x, 8);
                    case "MB":
                    case "MW":
                    case "MD":
                    case "MX":
                        short temp = 0;
                        // Merkerdoppelwort
                        if (value == "1" || value == "True")
                        {
                            temp = 1;
                        }
                        else
                        {
                            temp = 0;
                        }
                        byte[] data = Conversion.HexToBytes($"{temp:X8}");
                        return WriteVariable(strVar, data, 2);
                    default:
                        break;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Write
        /// </summary>
        /// <param name="strVar"></param>
        /// <param name="strValue"></param>
        /// <param name="iDataType"></param>
        /// <returns></returns>
        public byte[] WriteVariable(string strVar, byte[] strValue, int iDataType)
        {

            byte[] TxWrite = null;
            byte[] bReceive = new byte[513];
            try
            {



                TxWrite = new byte[19];
                //
                TxWrite[0] = (byte)Microsoft.VisualBasic.Strings.Asc("L");
                TxWrite[1] = (byte)Microsoft.VisualBasic.Strings.Asc("S");
                TxWrite[2] = (byte)Microsoft.VisualBasic.Strings.Asc("I");
                TxWrite[3] = (byte)Microsoft.VisualBasic.Strings.Asc("S");
                TxWrite[4] = (byte)Microsoft.VisualBasic.Strings.Asc("-");
                TxWrite[5] = (byte)Microsoft.VisualBasic.Strings.Asc("X");
                TxWrite[6] = (byte)Microsoft.VisualBasic.Strings.Asc("G");
                TxWrite[7] = (byte)Microsoft.VisualBasic.Strings.Asc("T");

                TxWrite[8] = 0; //Reserved
                TxWrite[9] = 0;

                TxWrite[10] = 0; //PLC_Info
                TxWrite[11] = 0;

                TxWrite[12] = 0xA0; //CPU_Info

                TxWrite[13] = 0x33; //Source_of_Frame

                TxWrite[14] = 0; //Invoke ID
                TxWrite[15] = 0;

                int iVarLength = 0;
                int i = 0;
                int iDataSize = 0;
                int iInDataLen = 0;
                int iInDataByte = 0;
                int iRemLen = 0;
                string strHexa = string.Empty;
                string strRem = string.Empty;


                iVarLength = strVar.Length;
                iDataSize = Functions.GetDataSize(iDataType);
                iInDataLen = strValue.Length;
                iInDataByte = (iInDataLen + 1) / 2;



                Array.Resize(ref TxWrite, 32 + iVarLength + iDataSize);

                TxWrite[16] = (byte)(12 + iVarLength + iDataSize); //Length (2)

                TxWrite[17] = 0;


                TxWrite[18] = 3; //Fenet_Position(1)

                TxWrite[19] = Functions.ByteCheckSum(TxWrite, 0, 18);

                TxWrite[20] = 0x58; //0x58 (2)
                TxWrite[21] = 0;

                TxWrite[22] = (byte)iDataType; //DataType (2)
                TxWrite[23] = 0;
                TxWrite[24] = 0; //Reserved area (2)
                TxWrite[25] = 0;
                TxWrite[26] = 1; //Variable Number (2)
                TxWrite[27] = 0;
                TxWrite[28] = (byte)iVarLength; //Variable Length
                TxWrite[29] = 0;

                for (i = 0; i < iVarLength; i++)
                {
                    TxWrite[30 + i] = (byte)Microsoft.VisualBasic.Strings.Asc(strVar.Substring(i, 1));
                }

                TxWrite[30 + iVarLength] = (byte)iDataSize;
                TxWrite[31 + iVarLength] = 0;

                iRemLen = iInDataLen;
                strRem = strValue.Length.ToString();

                i = 0;

                Array.Reverse(strValue);
                while (iRemLen > 0)
                {
                    strHexa = (strValue.Length - 2).ToString();
                    TxWrite[32 + iVarLength + i] = strValue[i];
                    i = i + 1;
                    iRemLen = iRemLen - int.Parse(strHexa);
                }

               // _RequestAndResponseMessage = new RequestAndResponseMessage("Reception", "XGT slave", TxWrite);


                return TxWrite;

            }
            catch
            {
                //* Return an error code

                return null;
            }

        }
        #endregion
        #region construction

        public LS_FENET()
        {
        }


        // construction

        public LS_FENET(string ip, int port)
            : this()
        {
            EthernetAdaper = new EthernetAdapter(ip, port);
        }

        public LS_FENET(string ip, short port, int connectTimeout)
            : this()
        {
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
                if (eventConnectionStateChanged != null) eventConnectionStateChanged(DISCONNECTED);
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
            finally
            {
                if (eventConnectionStateChanged != null) eventConnectionStateChanged(DISCONNECTED);
                 

            }
        }

        #endregion
        #region Read


        public byte[] BeginRead(int station, string type, int strVar, int numberOfElements, string DataBlockName)
        {
            var stopwatch = Stopwatch.StartNew();
            byte[] data = null;

            try
            {
                lock (this)
                {
                    var FullPacket = ReadBytes(type, strVar, numberOfElements);
                    EthernetAdaper.Write(FullPacket.ToArray());
                    Thread.Sleep(100);
                    var buffReceiver = EthernetAdaper.Read();
                    data = Functions.Extract(buffReceiver, numberOfElements);
                    stopwatch.Stop();

                    return data;
                }
            }
            catch (SocketException ex)
            {
                stopwatch.Stop();

                //* Return an error code

                EventscadaException?.Invoke(this.GetType().Name,
                     $"Read : {ex.ErrorCode} : {ex.SocketErrorCode} : TimeElapsedMilliseconds :={stopwatch.ElapsedTicks} ");
                throw ex;
            }
        }

        public static byte[] Read(string strVar, int iDataType)
        {

            try
            {

                byte[] TxRead = null;
                TxRead = new byte[19];
                TxRead[0] = (byte)Microsoft.VisualBasic.Strings.Asc("L");
                TxRead[1] = (byte)Microsoft.VisualBasic.Strings.Asc("S");
                TxRead[2] = (byte)Microsoft.VisualBasic.Strings.Asc("I");
                TxRead[3] = (byte)Microsoft.VisualBasic.Strings.Asc("S");
                TxRead[4] = (byte)Microsoft.VisualBasic.Strings.Asc("-");
                TxRead[5] = (byte)Microsoft.VisualBasic.Strings.Asc("X");
                TxRead[6] = (byte)Microsoft.VisualBasic.Strings.Asc("G");
                TxRead[7] = (byte)Microsoft.VisualBasic.Strings.Asc("T");

                TxRead[8] = 0; //Reserved
                TxRead[9] = 0;

                TxRead[10] = 0; //PLC_Info
                TxRead[11] = 0;

                TxRead[12] = 0xA0; //CPU_Info

                TxRead[13] = 0x33; //Source_of_Frame

                TxRead[14] = 0; //CByte(Invoke_ID) 'Invoke ID
                TxRead[15] = 0;


                int Length = 0;
                int i = 0;

                Length = strVar.Length;

                if (!(Length > 0))
                {
                    return null;
                }


                Array.Resize(ref TxRead, 30 + Length);

                TxRead[16] = (byte)(10 + Length); //Length (2)

                TxRead[17] = 0;

                TxRead[18] = 3; //Fenet_Position(1)

                TxRead[19] = Functions.ByteCheckSum(TxRead, 0, 18);

                TxRead[20] = 0x54; //Command (2)
                TxRead[21] = 0;

                TxRead[22] = Convert.ToByte(iDataType); //DataType (2)
                TxRead[23] = 0;
                TxRead[24] = 0; //Reserved area (2)
                TxRead[25] = 0;
                TxRead[26] = 1; //Variable Number (2)
                TxRead[27] = 0;

                TxRead[28] = (byte)Length; //Variable Length
                TxRead[29] = 0;

                for (i = 0; i < Length; i++)
                {
                    TxRead[30 + i] = (byte)Microsoft.VisualBasic.Strings.Asc(strVar.Substring(i, 1));
                }

                return TxRead;

            }
            catch
            {


                return null;
            }


        }

        /// <summary>
        /// ReadBytes
        /// </summary>
        /// <param name="DataType"></param>
        /// <param name="DB"></param>
        /// <param name="StartByteAdr"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public byte[] ReadBytes(string type, int strVar, int count)
        {
            int iLen = 0;
            string imsi = new string(new char[80]);
            string strTmp = String.Empty;

            if (strVar.ToString().Length == 2)
            {
                imsi = $"%{type}{strVar:D2}";
            }
            else if (strVar.ToString().Length == 3)
            {
                imsi = $"%{type}{strVar:D3}";
            }
            else
            {
                imsi = $"%{type}{strVar:D0}";
            }


            int Length = 0;
            for (int i = 0; i < imsi.Length; i++)
            {
                strTmp += Microsoft.VisualBasic.Strings.Asc(imsi.Substring(i, 1));
            }

            Length = imsi.Length;

            string ReqData = $"{Length:D4}{strTmp}{count:D4}";

            iLen = Functions.GetDataSize(ReqData);

            if (!(Length > 0))
            {
                return null;
            }

            //ReadBytes
            List<byte> FullPacket = new List<byte>();


            FullPacket.Clear();

            try
            {
                // first create the header

                FullPacket.Add((byte)Microsoft.VisualBasic.Strings.Asc("L"));
                FullPacket.Add((byte)Microsoft.VisualBasic.Strings.Asc("S"));
                FullPacket.Add((byte)Microsoft.VisualBasic.Strings.Asc("I"));
                FullPacket.Add((byte)Microsoft.VisualBasic.Strings.Asc("S"));
                FullPacket.Add((byte)Microsoft.VisualBasic.Strings.Asc("-"));
                FullPacket.Add((byte)Microsoft.VisualBasic.Strings.Asc("X"));
                FullPacket.Add((byte)Microsoft.VisualBasic.Strings.Asc("G"));
                FullPacket.Add((byte)Microsoft.VisualBasic.Strings.Asc("T"));

                FullPacket.AddRange(new byte[] { 0, 0 }); //Reserved
                FullPacket.AddRange(new byte[] { 0, 0 }); //PLC_Info
                FullPacket.Add(0xA0); //CPU_Info
                FullPacket.Add(0x33); //Source_of_Frame
                FullPacket.AddRange(new byte[] { 0, 0 });//CByte(Invoke_ID) 'Invoke ID
                FullPacket.AddRange(new byte[] { (byte)(8 + iLen), 0 });//Length (2)
                FullPacket.Add(3);           //Fenet_Position(1) 
                FullPacket.Add(Functions.ByteCheckSum(FullPacket.ToArray(), 0, 18));

                FullPacket.AddRange(new byte[] { 0x54, 0 });//Command (2)

                FullPacket.AddRange(new byte[] { 0x14, 0 });//DataType (2)

                FullPacket.AddRange(new byte[] { 0, 0 });//Reserved area (2)

                FullPacket.AddRange(new byte[] { 1, 0 });//Variable Number (2)

                FullPacket.AddRange(new byte[] { (byte)Length, 0 });//Variable Length

                FullPacket.AddRange(Encoding.ASCII.GetBytes(imsi));

                FullPacket.AddRange(new byte[] { (byte)count, 0 }); //Count Adr

               // _RequestAndResponseMessage = new RequestAndResponseMessage("Reception", "XGT slave", FullPacket.ToArray());



                return FullPacket.ToArray();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }

        }
        #endregion


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


                
            }



        }
        ~LS_FENET()
        {
            Dispose(false);
        }
    }
}