using System;
using System.Runtime.Serialization;

namespace AdvancedScada.XModbus.Core.INException
{
    public class SlaveDeviceBusyException : Exception
    {
        public SlaveDeviceBusyException()
            : base(IMessage.SLAVE_DEVICE_BUSY)
        {
        }

        public SlaveDeviceBusyException(string message)
            : base(message)
        {
        }

        public SlaveDeviceBusyException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public SlaveDeviceBusyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public SlaveDeviceBusyException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected SlaveDeviceBusyException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}