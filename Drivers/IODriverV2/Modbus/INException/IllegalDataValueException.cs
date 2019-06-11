using System;
using System.Runtime.Serialization;

namespace AdvancedScada.XModbus.Core.INException
{
    public class IllegalDataValueException : Exception
    {
        public IllegalDataValueException()
            : base(IMessage.ILLEGAL_DATA_VALUE)
        {
        }

        public IllegalDataValueException(string message)
            : base(message)
        {
        }

        public IllegalDataValueException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public IllegalDataValueException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public IllegalDataValueException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected IllegalDataValueException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}