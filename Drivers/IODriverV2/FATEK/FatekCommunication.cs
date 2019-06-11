using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace AdvancedScada.XFATEK.Core.Comm
{/// <summary>
 /// PLC FATEK COMMNUNICATION WITH C# LANGUAGE.
 /// </summary>
    public class FatekCommunication : BaseFatekCommunication
    {
        
        private SerialPort objSerialPort = null;

        public bool IsConnected { get; internal set; }

        /// <summary>
        /// Contructor FATEK Commnucation.
        /// </summary>
        /// <param name="serialPort">Serial Port</param>
        public FatekCommunication(SerialPort serialPort)
        {
            try
            {
                
                this.objSerialPort = serialPort;
                objSerialPort.ReadTimeout = 2000;
                objSerialPort.WriteTimeout = 2000;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Contructor FATEK Commnucation.
        /// </summary>
        /// <param name="port">Port name</param>
        /// <param name="baudRate">Baud rate</param>
        /// <param name="parity">Parity</param>
        /// <param name="dataBits">DataBits</param>
        /// <param name="stopBits">StopBits</param>
        public FatekCommunication(string port, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            try
            {
                
                objSerialPort = new SerialPort(port, baudRate, parity, dataBits, stopBits);
                objSerialPort.ReadTimeout = 2000;
                objSerialPort.WriteTimeout = 2000;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FatekCommunication()
        {
        }




        /// <summary>
        /// PC connect with PLC FATEK.
        /// </summary>
        public void Connect()
        {
            try
            {
                if (objSerialPort.IsOpen) objSerialPort.Close();
                objSerialPort.Open();
                IsConnected = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// PC disconnect with PLC FATEK.
        /// </summary>
        public void Disconnect()
        {
            try
            {
                if (objSerialPort.IsOpen) objSerialPort.Close();
                IsConnected = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// FATEK PLC Information
        /// </summary>
        /// <param name="slaveStationNo">Slave Station No</param>
        /// <returns>FATEK PLC Information</returns>
        public string GetPLCInfo(int slaveStationNo)
        {
            StringBuilder result = new StringBuilder();
            try
            {
                string frame = this.GetMessageOfPLCStatus(slaveStationNo, CommandCode.PLC_STATUS);
                objSerialPort.WriteLine(frame);

                // Read SerialPort
                int sizeOfMessageReceiver = 15;
                string buffReceiver = string.Empty;
                DateTime startDateTime = DateTime.Now;
                do
                {
                    this.CheckBufferReceiver(buffReceiver);
                    buffReceiver = objSerialPort.ReadExisting();
                    System.Threading.Thread.Sleep(100);
                } while (buffReceiver.Length < sizeOfMessageReceiver && (DateTime.Now.Subtract(startDateTime).TotalMilliseconds < objSerialPort.ReadTimeout));
                string errorMsg = this.GetException(buffReceiver);
                if (!string.IsNullOrEmpty(errorMsg) || !string.IsNullOrWhiteSpace(errorMsg))
                    throw new Exception(errorMsg);

                string dataReceiver = buffReceiver.Substring(6, 2); // STATUS 1.
                ushort plcStatus = Conversion.HEXToWORD(dataReceiver);

                result.AppendLine("FATEK PLC COMMUNICATION PROTOCOL VIA SERIALPORT");
                result.AppendLine("===============================================================");
                PLCMode objPLCMode = (PLCMode)plcStatus;
                result.AppendLine(string.Format("B0. PLC Mode: {0}", objPLCMode));

                LADDER_CHECKSUM ladder = (LADDER_CHECKSUM)((plcStatus & (ushort)Math.Pow(2, 2)) >> 2);
                result.AppendLine(string.Format("B2. Ladder Checksum: {0}", ladder));

                USE_ROM_PACK_OR_NOT_USE objUseRomPack = (USE_ROM_PACK_OR_NOT_USE)((plcStatus & (ushort)Math.Pow(2, 3)) >> 3);
                result.AppendLine(string.Format("B3. Use ROM Pack: {0}", objUseRomPack));

                WDT_TIMEOUT_OR_NORMAL objWDTTimeout = (WDT_TIMEOUT_OR_NORMAL)((plcStatus & (ushort)Math.Pow(2, 4)) >> 4);
                result.AppendLine(string.Format("B4. WDT Timeout: {0}", objWDTTimeout));

                SET_ID_OR_NOT_SET_ID objSetID = (SET_ID_OR_NOT_SET_ID)((plcStatus & (ushort)Math.Pow(2, 5)) >> 5);
                result.AppendLine(string.Format("B5. Set ID: {0}", objSetID));

                EMERGENCY_STOP_OR_NORMAL objEmergencyStop = (EMERGENCY_STOP_OR_NORMAL)((plcStatus & (ushort)Math.Pow(2, 6)) >> 6);
                result.AppendLine(string.Format("B6. Emergency Stop: {0}", objEmergencyStop));

                //RESERVE FOR FUTURE
                result.AppendLine("B7. Reserver For Future");
                result.AppendLine("===============================================================");
                result.AppendLine("Designed By Industrial Networks");
                result.AppendLine("Skype: katllu");
                result.AppendLine("Mobile: (+84) 909.886.483");
                result.AppendLine("E-mail: hoangluu.automation@gmail.com");
                result.AppendLine("Youtube: https://www.youtube.com/industrialnetworks");
                result.AppendLine();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result.ToString();
        }

        /// <summary>
        /// Command code 40: The gist read the system status of PLC.
        /// </summary>
        /// <param name="slaveStationNo">Slave Station No</param>
        /// <returns>bool</returns>
        public PLCMode GetPLCStatus(int slaveStationNo)
        {
            PLCMode result = PLCMode.STOP;
            try
            {
                string frame = this.GetMessageOfPLCStatus(slaveStationNo, CommandCode.PLC_STATUS);
                objSerialPort.WriteLine(frame);

                // Read SerialPort
                int sizeOfMessageReceiver = 15;
                string buffReceiver = string.Empty;
                DateTime startDateTime = DateTime.Now;
                do
                {
                    this.CheckBufferReceiver(buffReceiver);
                    buffReceiver = objSerialPort.ReadExisting();
                    System.Threading.Thread.Sleep(100);
                } while (buffReceiver.Length < sizeOfMessageReceiver && (DateTime.Now.Subtract(startDateTime).TotalMilliseconds < objSerialPort.ReadTimeout));
                string errorMsg = this.GetException(buffReceiver);
                if (!string.IsNullOrEmpty(errorMsg) || !string.IsNullOrWhiteSpace(errorMsg))
                    throw new Exception(errorMsg);

                string dataReceiver = buffReceiver.Substring(6, 2); // STATUS 1.
                ushort plcStatus = Conversion.HEXToWORD(dataReceiver);
                result = (PLCMode)plcStatus;
                //Console.WriteLine("PLC STATUS = " + dataReceiver);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Command code 41: Control RUN/STOP of PLC.
        /// </summary>
        /// <param name="slaveStationNo">Slave Station No</param>
        /// <param name="status">Control Code, 1: RUN, 0: STOP</param>
        /// <returns>string</returns>
        public bool SetPLCMode(int slaveStationNo, PLCMode status)
        {
            bool result = false;
            try
            {
                string frame = this.GetMessageOfControlPLC(slaveStationNo, CommandCode.CONTROL_RUN_STOP, status);
                objSerialPort.WriteLine(frame);

                // Read SerialPort
                int sizeOfMessageReceiver = 9;
                string buffReceiver = string.Empty;
                DateTime startDateTime = DateTime.Now;
                do
                {
                    this.CheckBufferReceiver(buffReceiver);
                    buffReceiver = objSerialPort.ReadExisting();
                    System.Threading.Thread.Sleep(100);
                } while (buffReceiver.Length < sizeOfMessageReceiver && (DateTime.Now.Subtract(startDateTime).TotalMilliseconds < objSerialPort.ReadTimeout));
                string errorMsg = this.GetException(buffReceiver);
                if (!string.IsNullOrEmpty(errorMsg) || !string.IsNullOrWhiteSpace(errorMsg))
                    throw new Exception(errorMsg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
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
        public void WriteSingleDiscrete(int slaveStationNo, CommandCode cmmdCode, RunningCode runCode, MemoryType mType, ushort discreteNo, DataType dType)
        {
            try
            {
                string frame = this.GetMessageWriteSingleDiscrete(slaveStationNo, cmmdCode, runCode, mType, discreteNo, dType);
                objSerialPort.WriteLine(frame);

                // Read SerialPort
                int sizeOfMessageReceiver = 9;
                string buffReceiver = string.Empty;
                DateTime startDateTime = DateTime.Now;
                do
                {
                    this.CheckBufferReceiver(buffReceiver);
                    buffReceiver = objSerialPort.ReadExisting();
                    System.Threading.Thread.Sleep(100);
                } while (buffReceiver.Length < sizeOfMessageReceiver && (DateTime.Now.Subtract(startDateTime).TotalMilliseconds < objSerialPort.ReadTimeout));
                string errorMsg = this.GetException(buffReceiver);
                if (!string.IsNullOrEmpty(errorMsg) || !string.IsNullOrWhiteSpace(errorMsg))
                    throw new Exception(errorMsg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Command code 43: The status reading of ENABLE/DISABLE of continuous discrete.
        /// </summary>
        /// <param name="slaveStationNo">Slave Station No</param>
        /// <param name="numberOfPoints">Number Of Points.</param>
        /// <param name="mType">Memory Type</param>
        /// <param name="startNo">Start No</param>
        /// <param name="dType">Data Type</param>
        public void ReadEnableOrDisable(int slaveStationNo, CommandCode cmmdCode, ushort numberOfPoints, MemoryType mType, ushort startNo, DataType dType)
        {
            try
            {
                string frame = this.GetMessageReadDiscretes(slaveStationNo, cmmdCode, numberOfPoints, mType, startNo, dType);
                objSerialPort.WriteLine(frame);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Command code 44: The status reading of continuous discrete.
        /// </summary>
        /// <param name="slaveStationNo">Slave Station No</param>
        /// <param name="numberOfPoints">Number Of Points.</param>
        /// <param name="mType">Memory Type</param>
        /// <param name="startNo">Start No</param>
        /// <param name="dType">Data Type</param>
        /// <returns>bool[]</returns>
        public bool[] ReadDiscretes(int slaveStationNo, ushort numberOfPoints, MemoryType mType, ushort startNo, DataType dType)
        {
            List<bool> result = new List<bool>();
            try
            {
                if (numberOfPoints < 1 || numberOfPoints > 256) throw new InvalidOperationException("Number of points is invalid, Number of points valid: 1 to 256.");
                string frame = this.GetMessageReadDiscretes(slaveStationNo, CommandCode.THE_STATUS_READING_OF_CONTINUOUS_DISCRETE, numberOfPoints, mType, startNo, dType);
                objSerialPort.WriteLine(frame);

                // Read SerialPort
                int sizeOfMessageReceiver = numberOfPoints + 9;
                string buffReceiver = string.Empty;
                DateTime startDateTime = DateTime.Now;
                do
                {
                    this.CheckBufferReceiver(buffReceiver);
                    buffReceiver = objSerialPort.ReadExisting();
                    System.Threading.Thread.Sleep(100);
                } while (buffReceiver.Length < sizeOfMessageReceiver && (DateTime.Now.Subtract(startDateTime).TotalMilliseconds < objSerialPort.ReadTimeout));
                string errorMsg = this.GetException(buffReceiver);
                if (!string.IsNullOrEmpty(errorMsg) || !string.IsNullOrWhiteSpace(errorMsg))
                    throw new Exception(errorMsg);

                string dataReceiver = buffReceiver.Substring(6, numberOfPoints);
                foreach (char item in dataReceiver)
                {
                    result.Add(!"0".Equals(item.ToString()) ? true : false);
                }
                //Console.WriteLine("buffReceiver: {0}", buffReceiver);
                //Console.WriteLine("dataReceiver: {0}", dataReceiver);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result.ToArray();
        }


        /// <summary>
        /// Command code 45: Write the status to continuous discrete.
        /// </summary>
        /// <param name="slaveStationNo">Slave Station No</param>
        /// <param name="numberOfPoints">Number Of Points.</param>
        /// <param name="mType">Memory Type</param>
        /// <param name="startNo">Start No</param>
        /// <param name="dType">Data Type</param>
        /// <param name="data">Status</param>    
        public void WriteMultipeDiscretes(int slaveStationNo, ushort numberOfPoints, MemoryType mType, ushort startNo, DataType dType, bool[] data)
        {
            try
            {
                string frame = this.GetMessageWriteMultipeDiscretes(slaveStationNo, CommandCode.WRITE_THE_STATUS_TO_CONTINUOUS_DISCRETE, numberOfPoints, mType, startNo, dType, data);
                objSerialPort.WriteLine(frame);

                // Read SerialPort
                int sizeOfMessageReceiver = 9;
                string buffReceiver = string.Empty;
                DateTime startDateTime = DateTime.Now;
                do
                {
                    this.CheckBufferReceiver(buffReceiver);
                    buffReceiver = objSerialPort.ReadExisting();
                    System.Threading.Thread.Sleep(100);
                } while (buffReceiver.Length < sizeOfMessageReceiver && (DateTime.Now.Subtract(startDateTime).TotalMilliseconds < objSerialPort.ReadTimeout));
                string errorMsg = this.GetException(buffReceiver);
                if (!string.IsNullOrEmpty(errorMsg) || !string.IsNullOrWhiteSpace(errorMsg))
                    throw new Exception(errorMsg);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Command code 46:  Read the data from continuous registers.
        /// </summary>
        /// <param name="slaveStationNo">Slave Station No</param>        
        /// <param name="numberOfPoints">Number Of Points.</param>
        /// <param name="mType">Memory Type.</param>
        /// <param name="startRegister">Start register No(6 or 7 words)</param>
        /// <param name="dType">Data Type.</param>
        /// <returns>object[]</returns>
        public object[] ReadRegisters(int slaveStationNo, ushort numberOfPoints, MemoryType mType, ushort startRegister, DataType dType)
        {
            List<object> result = new List<object>();
            try
            {
                string frame = this.GetMessageReadRegisters(slaveStationNo, CommandCode.READ_THE_DATA_FROM_CONTINUOUS_REGISTERS, numberOfPoints, mType, startRegister, dType);
                objSerialPort.WriteLine(frame);

                // Read SerialPort
                int CONST = 4;
                switch (dType)
                {
                    case DataType.INT:
                    case DataType.WORD:
                        CONST = 4;
                        break;
                    case DataType.DINT:
                    case DataType.DWORD:
                    case DataType.REAL:
                        CONST = 8;
                        break;
                    default:
                        throw new InvalidOperationException("Data type is invalid");
                }
                int sizeOfMessageReceiver = numberOfPoints * CONST + 9;
                string buffReceiver = string.Empty;
                DateTime startDateTime = DateTime.Now;
                do
                {
                    this.CheckBufferReceiver(buffReceiver);
                    buffReceiver = objSerialPort.ReadExisting();
                    System.Threading.Thread.Sleep(100);
                } while (buffReceiver.Length < sizeOfMessageReceiver && (DateTime.Now.Subtract(startDateTime).TotalMilliseconds < objSerialPort.ReadTimeout));
                //Console.WriteLine("ReadTimeout: {0}", DateTime.Now.Subtract(startDateTime).TotalMilliseconds);
                string errorMsg = this.GetException(buffReceiver);
                if (!string.IsNullOrEmpty(errorMsg) || !string.IsNullOrWhiteSpace(errorMsg))
                    throw new Exception(errorMsg);

                int index = 0;
                string dataReceiver = string.Empty;
                string valueString = string.Empty;

                dataReceiver = buffReceiver.Substring(6, numberOfPoints * CONST); // data.
                switch (dType)
                {
                    case DataType.INT:
                        do
                        {
                            valueString = dataReceiver.Substring(CONST * index, CONST);
                            short value = Conversion.HEXToINT(valueString);
                            result.Add(value);
                        } while (++index < numberOfPoints);
                        break;
                    case DataType.WORD:
                        do
                        {
                            valueString = dataReceiver.Substring(CONST * index, CONST);
                            ushort value = Conversion.HEXToWORD(valueString);
                            result.Add(value);
                        } while (++index < numberOfPoints);
                        break;
                    case DataType.DINT:
                        do
                        {
                            valueString = dataReceiver.Substring(CONST * index, CONST);
                            int value = Conversion.HEXToDINT(valueString);
                            result.Add(value);
                        } while (++index < numberOfPoints);
                        break;
                    case DataType.DWORD:
                        do
                        {
                            valueString = dataReceiver.Substring(CONST * index, CONST);
                            uint value = Conversion.HEXToDWORD(valueString);
                            result.Add(value);
                        } while (++index < numberOfPoints);
                        break;
                    case DataType.REAL:
                        do
                        {
                            valueString = dataReceiver.Substring(CONST * index, CONST);
                            float value = Conversion.HEXToREAL(valueString);
                            result.Add(value);
                        } while (++index < numberOfPoints);
                        break;
                    default:
                        throw new InvalidOperationException("Data type is invalid");
                }
                //Console.WriteLine("buffReceiver: {0}", buffReceiver);
                //Console.WriteLine("dataReceiver: {0}", dataReceiver);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result.ToArray();
        }

        /// <summary>
        /// Command code 47: Write to continuous registers.
        /// </summary>
        /// <param name="slaveStationNo">Slave Station No</param>
        /// <param name="numberOfPoints">Number Of Points.</param>
        /// <param name="mType">Memory Type</param>
        ///  <param name="startRegister">Start register No(6 or 7 words)</param>
        ///  <param name="dType">Data Type</param>
        /// <param name="data">Data of registers</param>
        public void WriteMultipeRegisters(int slaveStationNo, ushort numberOfPoints, MemoryType mType, ushort startRegister, DataType dType, object[] data)
        {
            try
            {
                string frame = this.GetMessageWriteMultipeRegisters(slaveStationNo, CommandCode.WRITE_TO_CONTINUOUS_REGISTERS, numberOfPoints, mType, startRegister, dType, data);
                objSerialPort.WriteLine(frame);

                // Read SerialPort
                int sizeOfMessageReceiver = 9;
                string buffReceiver = string.Empty;
                DateTime startDateTime = DateTime.Now;
                do
                {
                    this.CheckBufferReceiver(buffReceiver);
                    buffReceiver = objSerialPort.ReadExisting();
                    System.Threading.Thread.Sleep(100);
                } while (buffReceiver.Length < sizeOfMessageReceiver && (DateTime.Now.Subtract(startDateTime).TotalMilliseconds < objSerialPort.ReadTimeout));
                string errorMsg = this.GetException(buffReceiver);
                if (!string.IsNullOrEmpty(errorMsg) || !string.IsNullOrWhiteSpace(errorMsg))
                    throw new Exception(errorMsg);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Command code 48:  Mixed read the random discrete status or register data.
        /// </summary>
        /// <param name="slaveStationNo">Slave Station No</param>
        /// <param name="numberOfPoints">Number Of Points.</param>
        /// <param name="components">List<RandomRegister></param>
        /// <returns>string</returns>
        public RandomRegister[] ReadRadomDiscreteOrRegisters(int slaveStationNo, ushort numberOfPoints, List<RandomRegister> components)
        {
            List<RandomRegister> result = new List<RandomRegister>();
            try
            {
                string frame = this.GetMessageReadRadomDiscreteOrRegisters(slaveStationNo, CommandCode.MIXED_READ_THE_RADOM_DISCRETE_STATUS_OF_REGISTER_DATA, numberOfPoints, components);
                objSerialPort.WriteLine(frame);


                // Read SerialPort
                int CONST = 0;
                foreach (RandomRegister item in components)
                {
                    switch (item.DataType)
                    {
                        case DataType.BOOL:
                            CONST += 1;
                            break;
                        case DataType.INT:
                        case DataType.WORD:
                            CONST += 4;
                            break;
                        case DataType.DINT:
                        case DataType.DWORD:
                        case DataType.REAL:
                            CONST += 8;
                            break;
                        default:
                            throw new InvalidOperationException("Data type is invalid");
                    }
                }

                int sizeOfMessageReceiver = CONST + 9;
                string buffReceiver = string.Empty;
                DateTime startDateTime = DateTime.Now;
                do
                {
                    this.CheckBufferReceiver(buffReceiver);
                    buffReceiver = objSerialPort.ReadExisting();
                    System.Threading.Thread.Sleep(100);
                } while (buffReceiver.Length < sizeOfMessageReceiver && (DateTime.Now.Subtract(startDateTime).TotalMilliseconds < objSerialPort.ReadTimeout));
                //Console.WriteLine("ReadTimeout: {0}", DateTime.Now.Subtract(startDateTime).TotalMilliseconds);
                string errorMsg = this.GetException(buffReceiver);
                if (!string.IsNullOrEmpty(errorMsg) || !string.IsNullOrWhiteSpace(errorMsg))
                    throw new Exception(errorMsg);

                int index = 0;
                string dataReceiver = string.Empty;
                string valueString = string.Empty;

                dataReceiver = buffReceiver.Substring(6, CONST); // data.

                foreach (RandomRegister item in components)
                {
                    switch (item.DataType)
                    {
                        case DataType.BOOL:
                            valueString = dataReceiver.Substring(index, 1);
                            item.Value = !"0".Equals(valueString) ? true : false;
                            index += 1;
                            break;
                        case DataType.INT:
                            valueString = dataReceiver.Substring(index, 4);
                            item.Value = Conversion.HEXToINT(valueString);
                            index += 4;
                            break;
                        case DataType.WORD:
                            valueString = dataReceiver.Substring(index, 4);
                            item.Value = Conversion.HEXToWORD(valueString);
                            index += 4;
                            break;
                        case DataType.DINT:
                            valueString = dataReceiver.Substring(index, 8);
                            item.Value = Conversion.HEXToDINT(valueString);
                            index += 8;
                            break;
                        case DataType.DWORD:
                            valueString = dataReceiver.Substring(index, 8);
                            item.Value = Conversion.HEXToDWORD(valueString);
                            index += 8;
                            break;
                        case DataType.REAL:
                            valueString = dataReceiver.Substring(index, 8);
                            item.Value = Conversion.HEXToREAL(valueString);
                            index += 8;
                            break;
                        default:
                            throw new InvalidOperationException("Data type is invalid");
                    }
                    result.Add(item);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result.ToArray();
        }
    }
}
