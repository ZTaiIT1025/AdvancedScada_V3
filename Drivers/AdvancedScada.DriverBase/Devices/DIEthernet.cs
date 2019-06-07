using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace AdvancedScada.DriverBase.Devices
{
    [Serializable]
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

