
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

namespace AdvancedScada.Controls.Keyboard
{
    public class KeypadEventArgs : EventArgs
    {
        private string m_Key;

        public string Key
        {
            get
            {
                return this.m_Key;
            }
        }

        public KeypadEventArgs(string Key)
        {
            this.m_Key = Key;
        }
    }


}