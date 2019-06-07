using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace AdvancedScada.DriverBase.Devices
{
    [Serializable]
    [DataContract]
    public class Device
    {


        public Device()
        {
            DataBlocks = new List<DataBlock>();
        }


        [DisplayName("DataBlocks")]
        [DataMember]
        [Browsable(false)]
        [Category("Device")]
        public List<DataBlock> DataBlocks { get; set; }
        [Category("Device")]
        [DataMember]
        [Display(Name = "Description", Order = 6)]
        [Browsable(true)]
        public string Description { get; set; }

        [DataMember]
        [Display(Name = "Device Name", Order = 2)]
        [Browsable(true)]
        [Category("Device")]
        public string DeviceName { get; set; }

        [Browsable(true)]
        [DataMember]
        [Display(Name = "Device Id", Order = 1)]
        [Category("Device")]
        public int DeviceId { get; set; }

        [Browsable(true)]
        [DataMember]
        [Display(Name = "SlaveId", Order = 1)]
        [Category("Device")]
        public short SlaveId { get; set; }
        public object ChannelId { get; set; }
        public object CPUType { get; set; }
        public object IPAddress { get; set; }
        public object Rack { get; set; }
        public object Slot { get; set; }
        public object IsActived { get; set; }
    }
}
