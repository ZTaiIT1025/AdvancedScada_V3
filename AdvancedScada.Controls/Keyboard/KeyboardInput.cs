

using AdvancedScada;
using AdvancedScada.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Keyboard
{
    [ToolboxItem(false)]
    public class KeyboardInput : TextBox
    {
        public event EventHandler EnterKeyPressed;
        private int m_GetFocusValue;

        private int m_GetFocusMatchValue;

        private bool m_ClearAfterEnterKey;

        public bool ClearAfterEnterKey
        {
            get
            {
                return this.m_ClearAfterEnterKey;
            }
            set
            {
                this.m_ClearAfterEnterKey = value;
            }
        }

        public int GetFocusMatchValue
        {
            get
            {
                return this.m_GetFocusMatchValue;
            }
            set
            {
                this.m_GetFocusMatchValue = value;
            }
        }

        public int GetFocusValue
        {
            get
            {
                return this.m_GetFocusValue;
            }
            set
            {
                if (this.m_GetFocusValue != value)
                {
                    this.m_GetFocusValue = value;
                    if (this.m_GetFocusValue == this.m_GetFocusMatchValue)
                    {
                        base.Focus();
                    }
                }
            }
        }

        public KeyboardInput() : base()
        {
            this.m_GetFocusMatchValue = 1;
        }

        protected virtual void OnEnterKeyPressed(EventArgs e)
        {
            if (EnterKeyPressed != null)
                EnterKeyPressed(this, e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar != Convert.ToChar(13))
            {
                base.OnKeyPress(e);
            }
            else
            {
                this.OnEnterKeyPressed(EventArgs.Empty);
                if (this.m_ClearAfterEnterKey)
                {
                    this.Text = string.Empty;
                }
                e.Handled = true;
            }
        }



    }


}