
using AdvancedScada;
using AdvancedScada.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Class
{
    public class DoubleValueChangedEventArgs : EventArgs
    {
        private double m_NewValue;

        public double NewValue
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

        public DoubleValueChangedEventArgs()
        {
        }

        public DoubleValueChangedEventArgs(double val)
        {
            this.m_NewValue = val;
        }
    }


}