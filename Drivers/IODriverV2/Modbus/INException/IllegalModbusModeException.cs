using System;
using System.Runtime.Serialization;

namespace AdvancedScada.XModbus.Core.INException
{
    public class IllegalModbusModeException : Exception
    {
        public IllegalModbusModeException()
            : base(IMessage.ILLEGAL_MODBUS_MODE)
        {
        }

        public IllegalModbusModeException(string message)
            : base(message)
        {
        }

        public IllegalModbusModeException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public IllegalModbusModeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public IllegalModbusModeException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected IllegalModbusModeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}