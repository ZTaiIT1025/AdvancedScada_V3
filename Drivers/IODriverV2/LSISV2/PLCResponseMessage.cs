using AdvancedScada.XLSIS_V2.Core.Comm;
using System;
using System.Collections.Generic;

namespace AdvancedScada.XLSIS_V2.Core.Drivers
{
    public class PLCResponseMessage
    {
        public List<double> Values
        {
            get;
            private set;
        }

        public int ValuesCount
        {
            get
            {
                List<double> values = Values;
                if (values == null)
                {
                    return 0;
                }
                return values.Count;
            }
        }

        public PLCMessageTypes MessageType
        {
            get;
            private set;
        }

        public Guid RequestUniqueId
        {
            get;
            private set;
        }

        private PLCResponseMessage()
        {
            Values = new List<double>(16);
        }

        protected PLCResponseMessage(PLCMessageTypes messageType, Guid requestUniqueId)
            : this()
        {
            MessageType = messageType;
            RequestUniqueId = requestUniqueId;
        }

        public virtual string GetAddressName(int index)
        {
            throw new NotImplementedException();
        }
    }
}