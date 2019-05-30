using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace AdvancedScada.IBaseService
{
    public enum ServiceType
    {
        DRIVER,
        SERVICE,
        LOGGING,
        SQLINFO,
        SQLCONFIG,
        TAGMANAGER
    }
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
    [DataContract]
    public class Service
    {
        private int _ServiceId;

        private string _ServiceName;

        private ServiceType _ServiceType;

        private DateTime _TimeStart;

        private DateTime _TimeFinish;

        private string _Message;

        [DataMember]
        public int ServiceId
        {
            get
            {
                return _ServiceId;
            }
            set
            {
                _ServiceId = value;
            }
        }

        [DataMember]
        public string ServiceName
        {
            get
            {
                return _ServiceName;
            }
            set
            {
                _ServiceName = value;
            }
        }

        [DataMember]
        public ServiceType ServiceType
        {
            get
            {
                return _ServiceType;
            }
            set
            {
                _ServiceType = value;
            }
        }

        [DataMember]
        public DateTime TimeStart
        {
            get
            {
                return _TimeStart;
            }
            set
            {
                _TimeStart = value;
            }
        }

        [DataMember]
        public DateTime TimeFinish
        {
            get
            {
                return _TimeFinish;
            }
            set
            {
                _TimeFinish = value;
            }
        }

        [DataMember]
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }
    }

   
}