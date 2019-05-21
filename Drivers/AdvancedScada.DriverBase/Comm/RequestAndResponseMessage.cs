using System;
using System.ComponentModel;
using System.Linq;

namespace AdvancedScada.DriverBase.Comm
{
    public class RequestAndResponseMessage : EventArgs
    {
        public static EventReceptionChanged eventDataChanged = null;
        //public static EventSDataChanged eventSDataChanged = null;
        //public static EventbDataChanged eventbDataChanged = null;
        public static EventTransmissionChanged eventTransmissionChanged = null;
        public RequestAndResponseMessage(string Type, string Result, byte[] FullPacket)
        {

            if (eventDataChanged != null) eventDataChanged(Type, Result, FullPacket.ToArray());
        }
        public RequestAndResponseMessage(string Type, string Result, string FullPacket)
        {

            if (eventTransmissionChanged != null) eventTransmissionChanged(Type, Result, FullPacket);
        }
        //public RequestAndResponseMessage(string Type, string Result, string[] FullPacket)
        //{

        //    if (eventSDataChanged != null) eventSDataChanged(Type, Result, FullPacket.ToArray());
        //}
        //public RequestAndResponseMessage(string Type, string Result, bool[] FullPacket)
        //{

        //    if (eventbDataChanged != null) eventbDataChanged(Type, Result, FullPacket.ToArray());
        //}
    }
    public class ReceptionTransmissionMessage : INotifyPropertyChanged
    {


        private string _Type;

        private string _Result;
        private string size;
        private string cTime;
        private string _Frame_Data;

        public string Type
        {
            get
            {
                return _Type;
            }

            set
            {
                _Type = value;
                OnPropertyChanged("Type");
            }
        }

        public string Result
        {
            get
            {
                return _Result;
            }

            set
            {
                _Result = value;
                OnPropertyChanged("Result");
            }
        }

        public string Size
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
                OnPropertyChanged("Size");
            }
        }

        public string CTime
        {
            get
            {
                return cTime;
            }

            set
            {
                cTime = value;
                OnPropertyChanged("CTime");
            }
        }

        public string FrameData
        {
            get
            {
                return _Frame_Data;
            }

            set
            {
                _Frame_Data = value;
                OnPropertyChanged("FrameData");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string newName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(newName));

        }
    }
    public class ResponseMessage : INotifyPropertyChanged
    {
        private string form;

        private string processing;
        private string size;
        private string cTime;
        private string frame;

        public string Form
        {
            get
            {
                return form;
            }

            set
            {
                form = value;
                OnPropertyChanged("Form");
            }
        }

        public string Processing
        {
            get
            {
                return processing;
            }

            set
            {
                processing = value;
                OnPropertyChanged("Processing");
            }
        }

        public string Size
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
                OnPropertyChanged("Size");
            }
        }

        public string CTime
        {
            get
            {
                return cTime;
            }

            set
            {
                cTime = value;
                OnPropertyChanged("CTime");
            }
        }

        public string Frame
        {
            get
            {
                return frame;
            }

            set
            {
                frame = value;
                OnPropertyChanged("Frame");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string newName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(newName));

        }
    }
}
