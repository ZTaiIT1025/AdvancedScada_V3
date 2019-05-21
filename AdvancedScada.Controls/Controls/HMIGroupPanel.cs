
using AdvancedScada;
using AdvancedScada.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Controls
{
    public class HMIGroupPanel : Panel
    {
        private Color m_BackColor;

        private Color m_BackColor2;
        private Color m_BackColor3;

        private bool m_SelectBackColor2;
        private bool m_SelectBackColor3;

        public new Color BackColor
        {
            get
            {
                return this.m_BackColor;
            }
            set
            {
                this.m_BackColor = value;
                if (!this.m_SelectBackColor2)
                {
                    base.BackColor = this.m_BackColor;
                }
            }
        }
        private void SetBackColor()
        {
            if (this.m_SelectBackColor3)
            {
                base.BackColor = this.BackColor3;
            }
            else if (!this.m_SelectBackColor2)
            {
                base.BackColor = this.BackColor;
            }
            else
            {
                base.BackColor = this.BackColor2;
            }
        }
        public Color BackColor2
        {
            get
            {
                return this.m_BackColor2;
            }
            set
            {
                this.m_BackColor2 = value;
                if (!this.m_SelectBackColor2)
                {
                    base.BackColor = this.m_BackColor2;
                }
            }
        }
        public Color BackColor3
        {
            get
            {
                return this.m_BackColor3;
            }
            set
            {
                this.m_BackColor3 = value;
                this.SetBackColor();
            }
        }

        [Category("Appearance")]
        public bool SelectBackColor2
        {
            get
            {
                return this.m_SelectBackColor2;
            }
            set
            {
                if (value != this.m_SelectBackColor2)
                {
                    this.m_SelectBackColor2 = value;
                    if (!value)
                    {
                        base.BackColor = this.m_BackColor;
                    }
                    else
                    {
                        base.BackColor = this.m_BackColor2;
                    }
                    this.Invalidate();
                    this.OnSelectBackColor2Changed(EventArgs.Empty);
                }
            }
        }

        [Category("Appearance")]
        public bool SelectBackColor3
        {
            get
            {
                return this.m_SelectBackColor3;
            }
            set
            {
                if (value != this.m_SelectBackColor3)
                {
                    this.m_SelectBackColor3 = value;
                    this.SetBackColor();
                    base.Invalidate();
                    this.OnSelectBackColor2Changed(EventArgs.Empty);
                }
            }
        }

        public HMIGroupPanel() : base()
        {
            this.m_BackColor = Color.Transparent;
            this.m_BackColor2 = Color.Green;
            this.m_BackColor3 = Color.Red;
        }


        protected virtual void OnSelectBackColor2Changed(EventArgs e)
        {
            if (SelectBackColor2Changed != null)
                SelectBackColor2Changed(this, e);
        }

        public event EventHandler SelectBackColor2Changed;
    }


}