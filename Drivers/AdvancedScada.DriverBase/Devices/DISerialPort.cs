using System;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Serialization;

namespace AdvancedScada.DriverBase.Devices
{
    public sealed class DISerialPort : Channel
    {
        /// <summary>
        ///     Hàm khởi tạo.
        /// </summary>
        public DISerialPort()
        {
            ConnectionType = "SerialPort";
        }

        /// <summary>
        ///     Hàm khởi tạo.
        /// </summary>
        /// <param name="channelId">Mã kênh</param>
        /// <param name="channelName">Tên kênh</param>
        /// <param name="md">Chế độ của giao thức</param>
        /// <param name="connType">Kiểu kết nối</param>
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
