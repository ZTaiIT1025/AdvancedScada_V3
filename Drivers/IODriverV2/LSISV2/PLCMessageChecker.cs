using AdvancedScada.XLSIS_V2.Core.Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedScada.XLSIS_V2.Core.Drivers
{
    public class PLCMessageChecker
    {
        public PLCMessageTypes MessageType
        {
            get;
            private set;
        }

        public byte[] Data
        {
            get;
            private set;
        }

        public int DataLength
        {
            get
            {
                byte[] data = Data;
                if (data == null)
                {
                    return 0;
                }
                return data.Length;
            }
        }

        public static PLCMessageChecker Complete => new PLCMessageChecker(PLCMessageTypes.Complete);

        public static PLCMessageChecker Continue => new PLCMessageChecker(PLCMessageTypes.Continue);

        public static PLCMessageChecker Error => new PLCMessageChecker(PLCMessageTypes.Error);

        private PLCMessageChecker()
        {
        }

        public PLCMessageChecker(PLCMessageTypes messageType)
            : this()
        {
            MessageType = messageType;
        }

        public PLCMessageChecker(PLCMessageTypes messageType, IEnumerable<byte> data)
            : this(messageType)
        {
            Data = data?.ToArray();
        }

        public override string ToString()
        {
            byte[] data = Data;
            StringBuilder stringBuilder = new StringBuilder(((data != null) ? data.Length : 0) * 2);
            byte[] data2 = Data;
            foreach (byte b in data2)
            {
                stringBuilder.AppendFormat("{0:X2} ", b);
            }
            return stringBuilder.ToString();
        }
    }
}