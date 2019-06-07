using System;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Serialization;

namespace AdvancedScada.DriverBase.Devices
{
    [Serializable]
    public sealed class DISerialPort : Channel
    { 
        public DISerialPort()
        {
            ConnectionType = "SerialPort";
        }

         
        public DISerialPort(int channelId, string channelName, string md,
            string connType = "SerialPort")
        {
            ChannelId = channelId;
            ChannelName = channelName;
            ConnectionType = connType;
            Mode = md;
        }
        [Browsable(true)]
        [Category("SerialPort")]
        [DataMember]
        [DisplayName("Handshake")]
        public Handshake Handshake { get; set; }
        [Browsable(true)]
        [Category("SerialPort")]
        [DataMember]
        [DisplayName("Parity")]
        public Parity Parity { get; set; }
        [Browsable(true)]
        [Category("SerialPort")]
        [DataMember]
        [DisplayName("StopBits")]
        public StopBits StopBits { get; set; }
        [Browsable(true)]
        [Category("SerialPort")]
        [DataMember]
        [DisplayName("DataBits")]
        public int DataBits { get; set; }
        [Browsable(true)]
        [Category("SerialPort")]
        [DataMember]
        [DisplayName("BaudRate")]
        public int BaudRate { get; set; }
        [Browsable(true)]
        [Category("SerialPort")]
        [DataMember]
        [DisplayName("PortName")]
        public string PortName { get; set; }
    }
}
