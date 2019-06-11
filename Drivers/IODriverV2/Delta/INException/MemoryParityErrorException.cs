using System;
using System.Runtime.Serialization;

namespace AdvancedScada.XDelta.Core.INException
{
    public class MemoryParityErrorException : Exception
    {
        public MemoryParityErrorException()
            : base(IMessage.MEMORY_PARITY_ERROR)
        {
        }

        public MemoryParityErrorException(string message)
            : base(message)
        {
        }

        public MemoryParityErrorException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public MemoryParityErrorException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public MemoryParityErrorException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected MemoryParityErrorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}