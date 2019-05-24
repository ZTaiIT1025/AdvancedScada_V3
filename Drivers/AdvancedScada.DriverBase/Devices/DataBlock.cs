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
    public class DataBlock
    {
        
        public DataBlock()
        {
            Tags = new List<Tag>();
        }

        
        public DataBlock(int chId, int dvId, int dbId, string dbName, string typeOfRead, ushort startAddr, ushort length, string dType, string desp)
            : this()
        {
            ChannelId = chId;
            DeviceId = dvId;
            DataBlockId = dbId;
            DataBlockName = dbName;
            typeOfRead = TypeOfRead;
            StartAddress = startAddr;
            Length = length;
            DataType = dType;
            Description = desp;
        }

        [Browsable(true)]
        [DataMember]
        [Category("DataBlock")]
        [Display(Name = "Description", Order = 7)]
        public string Description { get; set; }
        [Display(Name = "DataType", Order = 6)]
        [Category("DataBlock")]
        [DataMember]
        [Browsable(true)]
        public string DataType { get; set; }
        [Display(Name = "Length", Order = 5)]
        [Category("DataBlock")]
        [DataMember]
        [Browsable(true)]
        public ushort Length { get; set; }


        [Display(Name = "StartAddress", Order = 4)]
        [Category("DataBlock")]
        [DataMember]
        [Browsable(true)]
        public ushort StartAddress { get; set; }

        [Display(Name = "DataBlock Name", Order = 2)]
        [DataMember]
        [Browsable(true)]
        [Category("DataBlock")]
        public string DataBlockName { get; set; }
 
        [Category("DataBlock")]
        [DataMember]
        [Display(Name = "DataBlockId", Order = 1)]
        [Browsable(true)]
        public int DataBlockId { get; set; }

        [DataMember]
        [Browsable(true)]
        [Display(Name = "MemoryType", Order = 3)]
        [Category("DataBlock")]
        public string MemoryType { get; set; }

        [Browsable(false)]
        [Display(Name = "Channel Id", Order = 1)]
        [DataMember]
        [Category("DataBlock")]
        public int ChannelId { get; set; }

        [Browsable(false)]
        [Display(Name = "Device Id", Order = 1)]
        [DataMember]
        [Category("DataBlock")]
        public int DeviceId { get; set; }

        [Category("DataBlock")]
        [DataMember]
        [Display(Name = "Tags")]
        [Browsable(false)]
        public List<Tag> Tags { get; set; }
        [Category("DataBlock")]
        [DataMember]
        [Browsable(false)]
        [Display(Name = "TypeOfRead")]
        public string TypeOfRead { get; set; }

    }
}
