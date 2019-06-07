using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
namespace AdvancedScada.DriverBase.Devices
{
    [Serializable]
    [DataContract]
    public class Channel
    {
        public Channel()
        {
            Devices = new List<Device>();
        }

        public Channel(int chId, string chName, string cpu = null, string desp = null)
            : this()
        {
            ChannelId = chId;
            ChannelName = chName;
            this.CPU = cpu;
            Description = desp;
        }
        [DisplayName("ChannelTypes")]
        [Category("Channel")]
        [DataMember]
        [Browsable(true)]
        public string ChannelTypes { get; set; }
        [DisplayName("Channel Id")]
        [Category("Channel")]
        [DataMember]
        [Browsable(true)]
        public int ChannelId { get; set; }
        [DataMember]
        [Browsable(true)]
        [DisplayName("Channel Name")]
        [Category("Channel")]
        public string ChannelName { get; set; }
        [Display(Name = "CPU Type", Order = 3)]
        [Browsable(true)]
        [Category("Channel")]
        [DataMember]
        public string CPU { get; set; }
        [DataMember]
        [Browsable(true)]
        [Display(Name = "Rack", Order = 5)]
        [Category("Channel")]
        public int Rack { get; set; }

        [Browsable(true)]
        [Display(Name = "Slot", Order = 6)]
        [Category("Channel")]
        [DataMember]
        public int Slot { get; set; }
        [Browsable(true)]
        [Category("Channel")]
        [DataMember]
        [DisplayName("Description")]
        public string Description { get; set; }

        [DataMember]
        [Browsable(false)]
        public string Mode { get; set; }

        [DataMember]
        [Category("Channel")]
        [Browsable(true)]
        [DisplayName("ConnectionType")]
        public string ConnectionType { get; set; }
        [DataMember]
        [Category("Channel")]
        [Browsable(false)]
        [DisplayName("Channel")]
        public List<Device> Devices { get; set; }

        [DataMember]
        [Browsable(false)]
        public Device this[string deviceName]
        {
            get
            {
                foreach (var item in Devices)
                    if (deviceName.Equals(item.DeviceName))
                        return item;
                return null;
            }
        }
    }
}
