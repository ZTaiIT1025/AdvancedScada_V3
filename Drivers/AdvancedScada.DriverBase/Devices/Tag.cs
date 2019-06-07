using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace AdvancedScada.DriverBase.Devices
{
    [Serializable]
    [DataContract]
    public class Tag : INotifyPropertyChanged, IDisposable, IComparable, IComparable<Tag>
    {
        public delegate void EventValueChanged(dynamic value);
        private bool _IsScaled;

        private ushort _AImax;

        private ushort _AImin;

        private ushort _AIcurrent;

        private float _RLmax;

        private float _RLmin;
        private bool m_Checked;

        private bool m_Enabled;

        private dynamic m_Value;
        private bool m_Visible;

        private bool m_ValueSelect1;

        private bool m_ValueSelect2;
        public EventValueChanged ValueChanged = null;

      
        public Tag()
        {
        }


        public Tag(int tagId, string tagName, dynamic value)
        {
            TagId = tagId;
            TagName = tagName;
            Value = value;

        }
        public Tag(int tagId, string tagName, dynamic value, bool isScaled, ushort aiMax, ushort aiMin, ushort aiCurr, float rlMax, float rlMin)
        {
            this.TagId = tagId;
            this.TagName = tagName;
            this.Value = value;
            this.IsScaled = isScaled;
            this.AImax = aiMax;
            this.AImin = aiMin;
            this.RLmax = rlMax;
            this.RLmin = rlMin;
        }
        [Browsable(false)]
        [Category("Tag")]
        [DataMember]
        public int ChannelId { get; set; }


        [Browsable(false)]
        [Category("Tag")]
        [DataMember]
        public int DataBlockId { get; set; }

        [Browsable(false)]
        [Category("Tag")]
        [DataMember]
        public int DeviceId { get; set; }

        /// <summary>
        ///     Kiểu dữ liệu.
        /// </summary>
        [DataMember]
        public string DataType { get; set; }

       
        [DataMember]
        public dynamic Value
        {
            get { return m_Value; }
            set
            {

                m_Value = value;
                OnPropertyChanged("Value");

            }
        }

        [DataMember]
        public string Address { get; set; }

       
        [DataMember]
        public string TagName { get; set; }

       
        [DataMember]
        public int TagId { get; set; }

        [DataMember]
        public DateTime Timestamp { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool Checked
        {
            get { return m_Checked; }

            set
            {
                m_Checked = value;
                OnPropertyChanged("Checked");
            }
        }

        [DataMember]
        public bool ValueSelect1
        {
            get { return m_ValueSelect1; }
            set
            {
                if (value != m_ValueSelect1)
                {
                    m_ValueSelect1 = value;

                    OnPropertyChanged("ValueSelect1");
                }
            }
        }

        [DataMember]
        public bool ValueSelect2
        {
            get { return m_ValueSelect2; }
            set
            {
                if (value != m_ValueSelect2)
                {
                    m_ValueSelect2 = value;

                    OnPropertyChanged("ValueSelect2");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string newName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(newName));
            if (ValueChanged != null) ValueChanged(Value);
        }

       
        public float RLmin
        {
            get { return _RLmin; }
            set { _RLmin = value; }
        }

       
        public float RLmax
        {
            get { return _RLmax; }
            set { _RLmax = value; }
        }

       
        public ushort AIcurrent
        {
            get { return _AIcurrent; }
            set { _AIcurrent = value; }
        }

        
        public ushort AImin
        {
            get { return _AImin; }
            set { _AImin = value; }
        }

       
        public ushort AImax
        {
            get { return _AImax; }
            set { _AImax = value; }
        }

       
        public bool IsScaled
        {
            get { return _IsScaled; }
            set { _IsScaled = value; }
        }
        [DataMember]
        public bool Enabled
        {
            get { return m_Enabled; }
            set
            {
                m_Enabled = value;
                OnPropertyChanged("Enabled");
            }
        }

        [DataMember]
        public bool Visible
        {
            get { return m_Visible; }
            set
            {
                m_Visible = value;
                OnPropertyChanged("Visible");
            }
        }

        public object TagPrefix { get; set; }
        public object Size { get; set; }

        public void Dispose()
        {
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Tag other = obj as Tag;
            if (other == null)
            {
                throw new ArgumentException(nameof(obj) + " is not a " + nameof(Tag));
            }

            return CompareTo(other);
        }

        public int CompareTo(Tag other)
        {
            if (other == null)
            {
                return 1;
            }

            int result = 0;
            result = m_Checked.CompareTo(other.m_Checked);
            if (result != 0)
            {
                return result;
            }

            result = m_Enabled.CompareTo(other.m_Enabled);
            if (result != 0)
            {
                return result;
            }

            result = m_Visible.CompareTo(other.m_Visible);
            if (result != 0)
            {
                return result;
            }

            result = m_ValueSelect1.CompareTo(other.m_ValueSelect1);
            if (result != 0)
            {
                return result;
            }

            result = m_ValueSelect2.CompareTo(other.m_ValueSelect2);
            if (result != 0)
            {
                return result;
            }

            result = ChannelId.CompareTo(other.ChannelId);
            if (result != 0)
            {
                return result;
            }

            result = DataBlockId.CompareTo(other.DataBlockId);
            if (result != 0)
            {
                return result;
            }

            result = DeviceId.CompareTo(other.DeviceId);
            if (result != 0)
            {
                return result;
            }

            result = DataType.CompareTo(other.DataType);
            if (result != 0)
            {
                return result;
            }

            result = Address.CompareTo(other.Address);
            if (result != 0)
            {
                return result;
            }

            result = TagName.CompareTo(other.TagName);
            if (result != 0)
            {
                return result;
            }

            result = TagId.CompareTo(other.TagId);
            if (result != 0)
            {
                return result;
            }

            result = Timestamp.CompareTo(other.Timestamp);
            if (result != 0)
            {
                return result;
            }

            result = Description.CompareTo(other.Description);
            if (result != 0)
            {
                return result;
            }

            return result;
        }
    }
}
