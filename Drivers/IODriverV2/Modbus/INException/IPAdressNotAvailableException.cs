using System;
using System.Runtime.Serialization;

namespace AdvancedScada.XModbus.Core.INException
{
    public class IPAdressNotAvailableException : Exception
    {
        public IPAdressNotAvailableException()
            : base("Mã lỗi 03: Địa chỉ IP không có trong mạng")
        {
        }

        public IPAdressNotAvailableException(string message)
            : base($"Mã lỗi 03: {message}")
        {
        }

        public IPAdressNotAvailableException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public IPAdressNotAvailableException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public IPAdressNotAvailableException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected IPAdressNotAvailableException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}