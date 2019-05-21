using System.ComponentModel;
using System.Drawing.Design;

namespace AdvancedScada.Controls.Alarm.Designers
{
    public class PLCAddressItem

    {
        private string m_PLCAddress = string.Empty;

        public PLCAddressItem()
        {
        }

        public PLCAddressItem(string plcAddress)
        {
            PLCAddress = plcAddress;
        }

        public PLCAddressItem(string plcAddress, int numberOfElements)
        {
            PLCAddress = plcAddress;
            NumberOfElements = numberOfElements;
        }

        public PLCAddressItem(string plcAddress, int numberOfElements, string name)
        {
            PLCAddress = plcAddress;
            NumberOfElements = numberOfElements;
            //if (name == String.Empty)
            //{
            //    this.Name = plcAddress;
            //}
            //else
            //{
            // this.Name = name;
            //}
        }

        public PLCAddressItem(string plcAddress, int numberOfElements, string name, string description)
        {
            PLCAddress = plcAddress;
            NumberOfElements = numberOfElements;
            //if (name == String.Empty)
            //{
            //    this.Name = plcAddress;
            //}
            //else
            //{
            //    this.Name = name;
            //}
            Description = description;
        }

        public string Description { get; set; }

        [Browsable(false)] public string LastValue { get; set; }

        public string Name { get; set; }
        public int NumberOfElements { get; set; }

        [Category("PLC Properties")]
        [Editor(typeof(TestDialogEditorAlarm), typeof(UITypeEditor))]
        public string PLCAddress
        {
            get { return m_PLCAddress; }
            set { m_PLCAddress = value; }
        }
    }
}