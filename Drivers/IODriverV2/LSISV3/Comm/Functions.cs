using AdvancedScada.DriverBase.Comm;
using Core.DataTypes;
using System;
using System.Collections.Generic;

namespace AdvancedScada.XLSIS.Core.Comm
{
    public class Functions
    {
        public static int commCountNeed;
        public byte[] commRecvBuf = new byte[MAX_RECV_BUF + 1];
        public byte[] commSendBuf = new byte[MAX_SEND_BUF + 1];
        public static int commCountSend;
        public static int SOH = 0x1;
        public static int STX = 0x2; // start of text
        public static int ETX = 0x3; // end of text
        public static int EOT = 0x4; // end of transmission
        public static int ENQ = 0x5; // enquiry
        public static int ACK = 0x6; // acknowledge
        public static int LF = 0xA; // line feed
        public static int CR = 0xD; // carriage return
        public static int DLE = 0x10;
        public static int NAK = 0x15; // negative acknowledge
        public static int MAX_SEND_BUF = 256;
        public static int MAX_RECV_BUF = 1024;
        public static byte ByteCheckSum(string strData)
        {
            int i = 0;
            int CheckSum = 0;
            int Length = 0;

            Length = strData.Length;

            CheckSum = 0;
            for (i = 1; i <= Length; i++)
            {
                CheckSum = CheckSum + Microsoft.VisualBasic.Strings.Asc(strData.Substring(i - 1, 1));
                if (CheckSum > 255)
                {
                    CheckSum = CheckSum - 256;
                }
            }

            return Convert.ToByte(CheckSum);
        }
        // BYTE DATA¸ 
        public static string ByteToHexStr(byte byData)
        {

            string strHex = string.Empty;

            strHex = Convert.ToString(byData, 16).ToUpper();

            if (strHex.Length < 2)
            {
                strHex = "0" + strHex;
            }

            return strHex;

        }

        public enum DTYPE
        {
            DATA_TYPE_BIT,
            DATA_TYPE_WORD,
            DATA_TYPE_DWORD
        } // WORD ' WORD

        public static int GetDataType(string Type, ref int data_type)
        {
            if (string.Compare(Type, "PW") == 0)
            {
                data_type = Convert.ToInt32(DTYPE.DATA_TYPE_WORD);
            }
            else if (string.Compare(Type, "MW") == 0)
            {
                data_type = Convert.ToInt32(DTYPE.DATA_TYPE_WORD);
            }
            else if (string.Compare(Type, "LW") == 0)
            {
                data_type = Convert.ToInt32(DTYPE.DATA_TYPE_WORD);
            }
            else if (string.Compare(Type, "KW") == 0)
            {
                data_type = Convert.ToInt32(DTYPE.DATA_TYPE_WORD);
            }
            else if (string.Compare(Type, "FW") == 0)
            {
                data_type = Convert.ToInt32(DTYPE.DATA_TYPE_WORD);
            }
            else if (string.Compare(Type, "TW") == 0)
            {
                data_type = Convert.ToInt32(DTYPE.DATA_TYPE_WORD);
            }
            else if (string.Compare(Type, "CW") == 0)
            {
                data_type = Convert.ToInt32(DTYPE.DATA_TYPE_WORD);
            }
            else if (string.Compare(Type, "DW") == 0)
            {
                data_type = Convert.ToInt32(DTYPE.DATA_TYPE_WORD);
            }
            else if (string.Compare(Type, "SW") == 0)
            {
                data_type = Convert.ToInt32(DTYPE.DATA_TYPE_WORD);

            }
            else if (string.Compare(Type, "PX") == 0)
            {
                data_type = Convert.ToInt32(DTYPE.DATA_TYPE_BIT);
            }
            else if (string.Compare(Type, "MX") == 0)
            {
                data_type = Convert.ToInt32(DTYPE.DATA_TYPE_BIT);
            }
            else if (string.Compare(Type, "LX") == 0)
            {
                data_type = Convert.ToInt32(DTYPE.DATA_TYPE_BIT);
            }
            else if (string.Compare(Type, "KX") == 0)
            {
                data_type = Convert.ToInt32(DTYPE.DATA_TYPE_BIT);
            }
            else if (string.Compare(Type, "FX") == 0)
            {
                data_type = Convert.ToInt32(DTYPE.DATA_TYPE_BIT);
            }
            else if (string.Compare(Type, "TX") == 0)
            {
                data_type = Convert.ToInt32(DTYPE.DATA_TYPE_BIT);
            }
            else if (string.Compare(Type, "CX") == 0)
            {
                data_type = Convert.ToInt32(DTYPE.DATA_TYPE_BIT);

            }
            else if (string.Compare(Type, "PD") == 0)
            {
                data_type = Convert.ToInt32(DTYPE.DATA_TYPE_DWORD);
            }
            else if (string.Compare(Type, "MD") == 0)
            {
                data_type = Convert.ToInt32(DTYPE.DATA_TYPE_DWORD);
            }
            else if (string.Compare(Type, "LD") == 0)
            {
                data_type = Convert.ToInt32(DTYPE.DATA_TYPE_DWORD);
            }
            else if (string.Compare(Type, "KD") == 0)
            {
                data_type = Convert.ToInt32(DTYPE.DATA_TYPE_DWORD);
            }
            else if (string.Compare(Type, "FD") == 0)
            {
                data_type = Convert.ToInt32(DTYPE.DATA_TYPE_DWORD);
            }
            else if (string.Compare(Type, "TD") == 0)
            {
                data_type = Convert.ToInt32(DTYPE.DATA_TYPE_DWORD);
            }
            else if (string.Compare(Type, "CD") == 0)
            {
                data_type = Convert.ToInt32(DTYPE.DATA_TYPE_DWORD);
            }
            else if (string.Compare(Type, "DD") == 0)
            {
                data_type = Convert.ToInt32(DTYPE.DATA_TYPE_DWORD);
            }
            else if (string.Compare(Type, "SD") == 0)
            {
                data_type = Convert.ToInt32(DTYPE.DATA_TYPE_DWORD);
            }
            else
            {
                return 0;
            }

            return 1;
        }

        public static byte ByteCheckSum(byte[] Buff, int iStart, int iEnd)
        {


            int i = 0;
            int CheckSum = 0;

            for (i = iStart; i <= iEnd; i++)
            {
                CheckSum = CheckSum + Buff[i];
                if (CheckSum > 255)
                {
                    CheckSum = CheckSum - 256;
                }
            }

            return (byte)CheckSum;


        }
        public static int GetDataType(string strVar)
        {
            int tempGetDataType = 0;
            string strType = string.Empty;

            strType = strVar.Substring(2, 1);

            switch (strType)
            {
                case "X":
                    tempGetDataType = 0;
                    break;
                case "B":
                    tempGetDataType = 1;
                    break;
                case "W":
                    tempGetDataType = 2;
                    break;
                case "D":
                    tempGetDataType = 3;
                    break;
                case "L":
                    tempGetDataType = 4;
                    break;
            }
            return tempGetDataType;
        }
        public static int GetDataSize(int iDataType)
        {
            int tempGetDataSize = 0;

            switch (iDataType)
            {
                case 0:
                    tempGetDataSize = 0;
                    break;
                case 1:
                    tempGetDataSize = 1;
                    break;
                case 2:
                    tempGetDataSize = 2;
                    break;
                case 3:
                    tempGetDataSize = 4;
                    break;
                case 4:
                    tempGetDataSize = 8;
                    break;
            }

            return tempGetDataSize;
        }
        public static int GetDataSize(string strVar)
        {
            int iLen = 0;


            iLen = strVar.Length;


            return iLen / 2;
        }



        #region FEnet
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

        #region Shared Function

        public string[] ToStringArray(string value, int Length)
        {
            var startIndex = 0;
            var bytes = new string[Length];
            try
            {
                for (var cnt = 0; cnt < bytes.Length; cnt++)
                {
                    bytes[cnt] = value.Substring(startIndex, 4);
                    startIndex += 4;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return bytes;
        }

        public byte[] ToStringArray(byte[] value, int Length)
        {
            var bytes = new byte[Length];
            var bReceive = new byte[bytes.Length];
            try
            {
                value.CopyTo(bReceive, 0);
                var r = 0;

                for (var cnt = 32; cnt < bReceive.Length; cnt++)
                {
                    bytes[r] = bReceive[cnt];
                    r += 1;

                    if (r >= bytes.Length) break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return bytes;
        }

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
     
        #endregion


    }
}
