using System;
using System.Runtime.Serialization;

namespace AdvancedScada.XDelta.Core.INException
{
    public class NegativeKnowledgementException : Exception
    {
        public NegativeKnowledgementException()
            : base(IMessage.NEGATIVE_KNOWLEDGEMENT)
        {
        }

        public NegativeKnowledgementException(string message)
            : base(message)
        {
        }

        public NegativeKnowledgementException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public NegativeKnowledgementException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public NegativeKnowledgementException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected NegativeKnowledgementException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}