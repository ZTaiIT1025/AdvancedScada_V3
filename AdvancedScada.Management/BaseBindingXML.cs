using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedScada.Management
{
   public  class BaseBindingXML
    {
        //=============================Channel=======================
        public const string ROOT = "Root";
        public const string CHANNEL = "Channel";
        public const string CHANNEL_ID = "ChannelId";
        public const string CHANNEL_NAME = "ChannelName";
        public const string CHANNEL_Types = "ChannelTypes";
        public  const string RACK = "Rack";
        public  const string SLOT = "Slot";
        public  const string MODEL = "Model";
        public const string DESCRIPTION = "Description";

        public const string IP_ADDRESS = "IPAddress";
        public const string PORT = "Port";

        public const string PORT_NAME = "PortName";
        public const string BAUDRATE = "BaudRate";
        public const string DATABITS = "DataBits";
        public const string STOPBITS = "StopBits";
        public const string PARITY = "Parity";
        public const string HANDSHAKE = "Handshake";

        public const string MODE = "Mode";
        public const string Connection_Type = "ConnectionType";

        //==========================Device========================

        public const string DEVICE = "Device";
        public const string DEVICE_ID = "DeviceId";
        public const string DEVICE_NAME = "DeviceName";
        public const string SLAVE_ID = "SlaveId";
        //============================DataBlock======================
        public const string DATABLOCK = "DataBlock";
        public const string DATABLOCK_ID = "DataBlockId";
        public const string DATABLOCK_NAME = "DataBlockName";
        public const string TypeOfRead = "TypeOfRead";
        public const string START_ADDRESS = "StartAddress";
        public const string MemoryType = "MemoryType";
        public const string LENGTH = "Length";
        public const string DATA_TYPE = "DataType";
        //================================Tag=====================
        public const string TAG = "Tag";
        public const string TAG_ID = "TagId";
        public const string TAG_NAME = "TagName";
        public const string ADDRESS = "Address";
      
    }
}
