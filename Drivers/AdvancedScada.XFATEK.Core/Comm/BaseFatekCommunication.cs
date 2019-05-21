using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedScada.XFATEK.Core.Comm
{    public class BaseFatekCommunication
    {
        public const byte STX = 0x02; // Start code.
        public const byte EXT = 0x03; // End code.

        /// <summary>
        /// The table is the response format of communication error of FACON PLC
        /// </summary>
        public Dictionary<int, string> FATEK_ERROR = null; // Error list.

        // Frame: Start code + Slave station no + Command no + Data + CheckSum + End code.


        public BaseFatekCommunication()
        {
            FATEK_ERROR = new Dictionary<int, string>();
            FATEK_ERROR.Add(0, "Error free.");
            FATEK_ERROR.Add(2, "Illegal value.");
            FATEK_ERROR.Add(4, "Illegal format, or communication command can not execute.");
            FATEK_ERROR.Add(5, "Can not run（Ladder Checksum error when run PLC).");
            FATEK_ERROR.Add(6, "Can not run（PLC ID≠Ladder ID when run PLC.");
            FATEK_ERROR.Add(7, "Can not run（Snytax check error when run PLC).");
            FATEK_ERROR.Add(9, "Can not run（Function not supported).");
            FATEK_ERROR.Add(10, "Illegal address.");
        }


        /// <summary>
        /// Check buffReceiver[0] == EXT then buffReceiver = string.Empty.
        /// </summary>
        /// <param name="buffReceiver">string</param>
        public void CheckBufferReceiver(string buffReceiver)
        {
            if (buffReceiver.Length > 0)
            {
                if ((byte)buffReceiver[0] != STX)
                {
                    buffReceiver = string.Empty;
                }
            }
        }

        /// <summary>
        /// Get Exception.
        /// </summary>
        /// <param name="buffReceiver">string</param>
        /// <returns>string</returns>
        public string GetException(string buffReceiver)
        {
            string result = string.Empty;
            if (buffReceiver.Length >= 6)
            {
                int errorCode = Convert.ToInt32(buffReceiver[5].ToString());
                if (errorCode == 0) return result;
                result = FATEK_ERROR[errorCode];
            }
            else
            {
                result = "Pass parameter is invalid";
            }
            return result;
        }


        /// <summary>
        ///  Checksum check the hexadecimal value of ASCII code in the previous c～ f columns and produce
        ///  one checksum value in one byte length(two hexadecimal value 00～ FF） with “LRC (Longitudinal
        ///  Redundancy Check)” method.This message will be checked with the same way at the receiving
        ///  side when the message is received.When the two check values are the same, it means the data
        ///  transferred correctly.If the two check values are different, there are some error happened.The
        ///  calculation of LRC method is to add all the hexadecimal value(8 bits length) of ASCII code and
        ///  ignore to carry the number to keep the check value at 8 bits length.
        /// </summary>
        /// <param name="frame">string</param>
        /// <returns>string</returns>
        private string CheckSum(string frame)
        {
            if (frame == null)
                throw new ArgumentNullException("Pass parameter is invalid");
            int Checksum = 0x02;
            foreach (char item in frame)
            {
                Checksum = (Checksum + Convert.ToByte(item)) % 256;
            }
            return Checksum.ToString("X2");

        }

        /// <summary>
        /// Command code 40: The gist read the system status of PLC
        /// </summary>
        /// <param name="slaveStationNo">Slave Station No</param>
        /// <param name="cmmdCode">Command Code</param>
        /// <returns>string</returns>
        public string GetMessageOfPLCStatus(int slaveStationNo, CommandCode cmmdCode)
        {
            string frame = string.Format("{0:X2}", slaveStationNo); // Slave station no.
            frame += string.Format("{0:X2}", (byte)cmmdCode); // Command no.
            frame += CheckSum(frame);
            return Convert.ToChar(STX) + frame + Convert.ToChar(EXT);
        }

        /// <summary>
        /// Command code 41: Control RUN/STOP of PLC
        /// </summary>
        /// <param name="slaveStationNo">Slave Station No</param>
        /// <param name="cmmdCode">Command Code</param>
        /// <param name="status">Control Code, 1: RUN, 0: STOP</param>
        /// <returns>string</returns>
        public string GetMessageOfControlPLC(int slaveStationNo, CommandCode cmmdCode, PLCMode status)
        {
            string frame = string.Format("{0:X2}", slaveStationNo); // Slave station no.
            frame += string.Format("{0:X2}", (byte)cmmdCode); // Command no.
            frame += string.Format("{0}", status == PLCMode.RUN ? 1 : 0); // data.
            frame += CheckSum(frame);
            return Convert.ToChar(STX) + frame + Convert.ToChar(EXT);
        }

        /// <summary>
        ///  Command code 42:  Single discrete control.
        /// </summary>
        /// <param name="slaveStationNo">Slave Station No</param>
        /// <param name="cmmdCode">Command Code</param>
        /// <param name="runCode">Running Code</param>
        /// <param name="mType">Memory Type</param>
        /// <param name="discreteNo">Discrete No</param>
        /// <param name="dType">Data Type</param>
        /// <returns>string</returns>
        public string GetMessageWriteSingleDiscrete(int slaveStationNo, CommandCode cmmdCode, RunningCode runCode, MemoryType mType, ushort discreteNo, DataType dType)
        {
            string frame = string.Format("{0:X2}", slaveStationNo); // Slave station no.
            frame += string.Format("{0:X2}", (byte)cmmdCode); // Command no.
            frame += string.Format("{0}", (byte)runCode); // Runiing code.
            switch (dType)
            {
                case DataType.BOOL:
                    frame += string.Format("{0}{1:X4}", mType, discreteNo); // Discrete No.
                    break;
                default:
                    throw new InvalidOperationException("Data type is invalid");
            }
            frame += CheckSum(frame);
            return Convert.ToChar(STX) + frame + Convert.ToChar(EXT);
        }

        /// <summary>
        /// Command code 43: The status reading of ENABLE/DISABLE of continuous discrete.
        /// </summary>
        /// <param name="slaveStationNo">Slave Station No</param>
        /// <param name="cmmdCode">Command Code</param>
        /// <param name="numberOfPoints">Number Of Points.</param>
        /// <param name="mType">Memory Type</param>
        /// <param name="startNo">Start No</param>
        /// <param name="dType">Data Type</param>
        /// <returns>string</returns>
        public string GetMessageReadEnableOrDisable(int slaveStationNo, CommandCode cmmdCode, ushort numberOfPoints, MemoryType mType, ushort startNo, DataType dType)
        {
            return GetMessageReadDiscretes(slaveStationNo, cmmdCode, numberOfPoints, mType, Conversion.HEXToWORD(startNo.ToString()), dType);
        }

        /// <summary>
        /// Command code 44: The status reading of continuous discrete.
        /// </summary>
        /// <param name="slaveStationNo">Slave Station No</param>
        /// <param name="cmmdCode">Command Code</param>
        /// <param name="numberOfPoints">Number Of Points.</param>
        /// <param name="mType">Memory Type</param>
        /// <param name="startNo">Start No</param>
        /// <param name="dType">Data Type</param>
        /// <returns>string</returns>
        public string GetMessageReadDiscretes(int slaveStationNo, CommandCode cmmdCode, ushort numberOfPoints, MemoryType mType, ushort startNo, DataType dType)
        {
            string frame = string.Format("{0:X2}", slaveStationNo); // Slave station no.
            frame += string.Format("{0:X2}", (byte)cmmdCode); // Command no.
            frame += string.Format("{0:X2}", numberOfPoints); // Number Of Points.            
            switch (dType)
            {
                case DataType.BOOL:
                    frame += string.Format("{0}{1:X4}", mType, Conversion.HEXToWORD(startNo.ToString())); // Start No.
                    break;
                default:
                    throw new InvalidOperationException("Data type is invalid");
            }
            frame += CheckSum(frame);
            return Convert.ToChar(STX) + frame + Convert.ToChar(EXT);
        }

        /// <summary>
        /// Command code 45: Write the status to continuous discrete.
        /// </summary>
        /// <param name="slaveStationNo">Slave Station No</param>
        /// <param name="cmmdCode">Command Code</param>
        /// <param name="numberOfPoints">Number Of Points.</param>
        /// <param name="mType">Memory Type</param>
        /// <param name="startNo">Start No</param>
        /// <param name="dType">Data Type</param>
        /// <param name="data">Status</param>
        /// <returns>string</returns>
        public string GetMessageWriteMultipeDiscretes(int slaveStationNo, CommandCode cmmdCode, ushort numberOfPoints, MemoryType mType, ushort startNo, DataType dType, bool[] data)
        {
            string status = "";
            foreach (bool item in data)
            {
                status += string.Format("{0}", item ? 1 : 0);
            }
            string frame = string.Format("{0:X2}", slaveStationNo); // Slave station no.
            frame += string.Format("{0:X2}", (byte)cmmdCode); // Command no.
            frame += string.Format("{0:X2}", numberOfPoints); // Number Of Points.
            switch (dType)
            {
                case DataType.BOOL:
                    frame += string.Format("{0}{1:X4}", mType, Conversion.HEXToWORD(startNo.ToString())); // Start No.
                    break;
                default:
                    throw new InvalidOperationException("Data type is invalid");
            }
            frame += string.Format("{0}", status); // Status.
            frame += CheckSum(frame);
            return Convert.ToChar(STX) + frame + Convert.ToChar(EXT);
        }

        /// <summary>
        /// Command code 46:  Read the data from continuous registers.
        /// </summary>
        /// <param name="slaveStationNo">Slave Station No</param>
        /// <param name="cmmdCode">Command Code</param>
        /// <param name="numberOfPoints">Number Of Points.</param>
        /// <param name="mType">Memory Type.</param>
        /// <param name="startRegister">Start register No(6 or 7 words)</param>
        /// <param name="dType">Data Type.</param>
        /// <returns>string</returns>
        public string GetMessageReadRegisters(int slaveStationNo, CommandCode cmmdCode, ushort numberOfPoints, MemoryType mType, ushort startRegister, DataType dType)
        {
            string frame = string.Format("{0:X2}", slaveStationNo); // Slave station no.
            frame += string.Format("{0:X2}", (byte)cmmdCode); // Command no.
            frame += string.Format("{0:X2}", numberOfPoints); // Number Of Points.
            switch (dType)
            {
                case DataType.INT:
                case DataType.WORD:
                    frame += string.Format("W{0}{1:X4}", mType, Conversion.HEXToWORD(startRegister.ToString())); // Start register No.
                    break;
                case DataType.DINT:
                case DataType.DWORD:
                case DataType.REAL:
                    frame += string.Format("DW{0}{1:X8}", mType, Conversion.HEXToWORD(startRegister.ToString())); // Start register No.
                    break;
                default:
                    throw new InvalidOperationException("Data type is invalid");
            }
            frame += CheckSum(frame);
            return Convert.ToChar(STX) + frame + Convert.ToChar(EXT);
        }

        /// <summary>
        /// Command code 47: Write to continuous registers.
        /// </summary>
        /// <param name="slaveStationNo">Slave Station No</param>
        /// <param name="cmmdCode">Command Code</param>
        /// <param name="numberOfPoints">Number Of Points.</param>
        /// <param name="mType">Memory Type</param>
        ///  <param name="startRegister">Start register No(6 or 7 words)</param>
        ///  <param name="dType">Data Type</param>
        /// <param name="data">Data of registers</param>
        /// <returns>string</returns>
        public string GetMessageWriteMultipeRegisters(int slaveStationNo, CommandCode cmmdCode, ushort numberOfPoints, MemoryType mType, ushort startRegister, DataType dType, object[] data)
        {
            string values = string.Empty;
            string frame = string.Format("{0:X2}", slaveStationNo); // Slave station no.
            frame += string.Format("{0:X2}", (byte)cmmdCode); // Command no.
            frame += string.Format("{0:X2}", numberOfPoints); // Number Of Points.
            switch (dType)
            {
                case DataType.INT:
                    frame += string.Format("W{0}{1:X4}", mType, Conversion.HEXToWORD(startRegister.ToString())); // Start register No.
                    foreach (short item in data)
                    {
                        values += string.Format("{0:X4}", item);
                    }
                    break;
                case DataType.WORD:
                    frame += string.Format("W{0}{1:X4}", mType, Conversion.HEXToWORD(startRegister.ToString())); // Start register No.
                    foreach (ushort item in data)
                    {
                        values += string.Format("{0:X4}", item);
                    }
                    break;
                case DataType.DINT:
                    frame += string.Format("DW{0}{1:X8}", mType, Conversion.HEXToWORD(startRegister.ToString())); // Start register No.
                    foreach (int item in data)
                    {
                        values += string.Format("{0:X8}", item);
                    }
                    break;
                case DataType.DWORD:
                    frame += string.Format("DW{0}{1:X8}", mType, Conversion.HEXToWORD(startRegister.ToString())); // Start register No.
                    foreach (uint item in data)
                    {
                        values += string.Format("{0:X8}", item);
                    }
                    break;
                case DataType.REAL:
                    frame += string.Format("DW{0}{1:X8}", mType, Conversion.HEXToWORD(startRegister.ToString())); // Start register No.
                    foreach (float item in data)
                    {
                        values += string.Format("{0:X8}", item);
                    }
                    break;
                default:
                    throw new InvalidOperationException("Data type is invalid");
            }
            frame += string.Format("{0}", values); // values.
            frame += CheckSum(frame);
            return Convert.ToChar(STX) + frame + Convert.ToChar(EXT);
        }

        /// <summary>
        /// Command code 48:  Mixed read the random discrete status or register data.
        /// </summary>
        /// <param name="slaveStationNo">Slave Station No</param>
        /// <param name="cmmdCode">Command Code</param>
        /// <param name="numberOfPoints">Number Of Points.</param>
        /// <param name="components">List<RandomRegister></param>
        /// <returns>string</returns>
        public string GetMessageReadRadomDiscreteOrRegisters(int slaveStationNo, CommandCode cmmdCode, ushort numberOfPoints, List<RandomRegister> components)
        {
            string frame = string.Format("{0:X2}", slaveStationNo); // Slave station no.
            frame += string.Format("{0:X2}", (byte)cmmdCode); // Command no.
            frame += string.Format("{0:X2}", numberOfPoints); // Number Of Points.
            foreach (RandomRegister item in components)
            {
                switch (item.DataType)
                {
                    case DataType.BOOL:
                        frame += string.Format("{0}{1:X4}", item.MemoryType, Conversion.HEXToWORD(item.Address.ToString())); // Components.
                        break;
                    case DataType.INT:
                    case DataType.WORD:
                        frame += string.Format("W{0}{1:X4}", item.MemoryType, Conversion.HEXToWORD(item.Address.ToString())); // Components.
                        break;
                    case DataType.DINT:
                    case DataType.DWORD:
                    case DataType.REAL:
                        frame += string.Format("DW{0}{1:X8}", item.MemoryType, Conversion.HEXToWORD(item.Address.ToString())); // Components.
                        break;
                    default:
                        throw new InvalidOperationException("Data type is invalid");
                }
            }
            frame += CheckSum(frame);
            return Convert.ToChar(STX) + frame + Convert.ToChar(EXT);
        }

    }
}
