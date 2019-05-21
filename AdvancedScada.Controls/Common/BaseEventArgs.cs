
using AdvancedScada;
using AdvancedScada.Controls;
using AdvancedScada.Controls.Class;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Common
{
    public delegate void ValueChangedEventHandler(object sender, DoubleValueChangedEventArgs e);

    public class BaseEventArgs : EventArgs
    {
        protected string m_ErrorMessage;

        protected int m_ErrorId;

        public string ErrorMessage
        {
            get
            {
                return this.m_ErrorMessage;
            }
            set
            {
                this.m_ErrorMessage = value;
            }
        }

        public int ErrorId
        {
            get
            {
                return this.m_ErrorId;
            }
            set
            {
                this.m_ErrorId = value;
            }
        }

        public BaseEventArgs()
        {
        }

        public BaseEventArgs(int errorId, string errorMessage)
        {
            this.m_ErrorId = errorId;
            this.m_ErrorMessage = errorMessage;
        }
    }


}