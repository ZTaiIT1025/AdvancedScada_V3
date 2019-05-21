using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace AdvancedScada.DriverBase.Devices
{
    public sealed class DIEthernet : Channel
    {
        private string _IPAddress = "127.0.0.1";

        private short _Port = 502;

        /// <summary>
        ///     Hàm khởi tạo.
        /// </summary>
        public DIEthernet()
        {
            ConnectionType = "Ethernet";
        }

        /// <summary>
        ///     Hàm khởi tạo.
        /// </summary>
        /// <param name="channelId">Mã kênh</param>
        /// <param name="channelName">Tên kênh</param>
        /// <param name="md">Chế độ của giao thức</param>
        /// <param name="ip">Địa chỉ IP</param>
        /// <param name="port">Port</param>
        /// <param name="desc">Mô tả thông tin thiết bị</param>
        /// <param name="connType">Kiểu kết nối</param>
        public DIEthernet(int channelId, string channelName, string md, string ip, short port = 102, string desc = null,
            string connType = "Ethernet")
            : this()
        {
            ChannelId = channelId;
            ChannelName = channelName;
            ConnectionType = connType;
            Mode = md;
            IPAddress = ip;
            Port = port;
            Description = desc;
        }

        [DisplayName("Port")]
        [Category("Ethernet")]
        [DataMember]
        [Browsable(true)]
        public short Port
        {
            get { return _Port; }
            set { _Port = value; }
        }

        [DisplayName("IPAddress")]
        [Category("Ethernet")]
        [DataMember]
        [Browsable(true)]
        public string IPAddress
        {
            get { return _IPAddress; }
            set { _IPAddress = value; }
        }

    }
}

