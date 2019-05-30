using System;
using System.Runtime.Serialization;

namespace AdvancedScada.IBaseService.Common
{
    [DataContract]
    public class Machine
    {
        private int _MachineId;

        private string _MachineName;

        private string _IPAddress;

        private string _Description;

        [DataMember]
        public int MachineId
        {
            get
            {
                return _MachineId;
            }
            set
            {
                _MachineId = value;
            }
        }

        [DataMember]
        public string MachineName
        {
            get
            {
                return _MachineName;
            }
            set
            {
                _MachineName = value;
            }
        }

        [DataMember]
        public string IPAddress
        {
            get
            {
                return _IPAddress;
            }
            set
            {
                _IPAddress = value;
            }
        }

        [DataMember]
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }
    }
}