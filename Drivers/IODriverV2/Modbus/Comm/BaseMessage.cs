using AdvancedScada.XModbus.Core.INException;
using System.Collections.Generic;

namespace AdvancedScada.XModbus.Core.Comm
{
    public abstract class BaseMessage
    {
        protected const string CONNECTED = "CONNECTED";
        protected const string DISCONNECTED = "DISCONNECTED";

        #region Functions.

        protected const byte FUNCTION_01 = 1;

        protected const byte FUNCTION_02 = 2;

        protected const byte FUNCTION_03 = 3;

        protected const byte FUNCTION_04 = 4;

        protected const byte FUNCTION_05 = 5;

        protected const byte FUNCTION_06 = 6;

        protected const byte FUNCTION_15 = 15;

        protected const byte FUNCTION_16 = 16;

        public static Dictionary<int, string> GetCommands()
        {
            var result = new Dictionary<int, string>();
            result.Add(1, "Read Coil Status");
            result.Add(2, "Read Input Status");
            result.Add(3, "Read Holding Register");
            result.Add(4, "Read Input Register");
            result.Add(5, "Write Single Coil");
            result.Add(6, "Write Single Register");
            result.Add(15, "Write Multiple Coils");
            result.Add(16, "Write Multiple Registers");
            return result;
        }

        public void ModbusExcetion(byte[] messageReceived)
        {
            switch (messageReceived[1])
            {
                case 129: // Hex: 81                     
                case 130: // Hex: 82 
                case 131: // Hex: 83 
                case 132: // Hex: 83 
                case 133: // Hex: 84 
                case 134: // Hex: 86 
                case 143: // Hex: 8F 
                case 144: // hex: 90
                    switch (messageReceived[2])
                    {
                        case 1:
                            throw new IllegalFunctionException();
                        case 2:
                            throw new IllegalDataAddressException();
                        case 3:
                            throw new IllegalDataValueException();
                        case 4:
                            throw new SlaveDeviceFailureException();
                        case 5:
                            throw new AcknowledgeException();
                        case 6:
                            throw new SlaveDeviceBusyException();
                        case 7:
                            throw new NegativeKnowledgementException();
                        case 8:
                            throw new MemoryParityErrorException();
                        case 10:
                            throw new GatewayPathUnavailableException();
                        case 11:
                            throw new GatewayTargetDeviceFailedToRespondException();
                        default:
                            break;
                    }

                    break;
            }
        }

        #endregion
    }
}