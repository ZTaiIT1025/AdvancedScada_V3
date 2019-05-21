

using AdvancedScada;
using AdvancedScada.Controls;
using System;
using System.Collections;
using System.Collections.Generic;

using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Common
{
    public class ValueChangedEventArgs : EventArgs
    {
        private long m_NewValue;

        private long m_OldValue;

        private int m_BitNumber;

        public int BitNumber
        {
            get
            {
                return this.m_BitNumber;
            }
            set
            {
                this.m_BitNumber = value;
            }
        }

        public long NewValue
        {
            get
            {
                return this.m_NewValue;
            }
            set
            {
                this.m_NewValue = value;
            }
        }

        public long OldValue
        {
            get
            {
                return this.m_OldValue;
            }
            set
            {
                this.m_OldValue = value;
            }
        }

        public ValueChangedEventArgs()
        {
        }

        public ValueChangedEventArgs(long newValue)
        {
            this.m_NewValue = newValue;
        }

        public ValueChangedEventArgs(long newValue, long oldValue) : this(newValue)
        {
            this.m_OldValue = oldValue;
        }

        public ValueChangedEventArgs(long newValue, long oldValue, int bitNumber) : this(newValue, oldValue)
        {
            this.m_BitNumber = bitNumber;
        }
    }


}