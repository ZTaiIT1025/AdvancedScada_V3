using System;
using System.Runtime.Serialization;

namespace AdvancedScada.XDelta.Core.INException
{
    public class GatewayTargetDeviceFailedToRespondException : Exception
    {
        public GatewayTargetDeviceFailedToRespondException()
            : base(IMessage.GATEWAY_TARGET_DEVICE_FAILED_TO_RESPOND)
        {
        }

        public GatewayTargetDeviceFailedToRespondException(string message)
            : base(message)
        {
        }

        public GatewayTargetDeviceFailedToRespondException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public GatewayTargetDeviceFailedToRespondException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public GatewayTargetDeviceFailedToRespondException(string format, Exception innerException,
            params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected GatewayTargetDeviceFailedToRespondException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}