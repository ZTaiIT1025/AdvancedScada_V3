
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Xml.Linq;


namespace AdvancedScada.Controls.SelectorSwitch
{
    public class HMIPilotLightEx : HMIPilotLight
    {
        private bool InstanceFieldsInitialized = false;

        public HMIPilotLightEx()
        {
            if (!InstanceFieldsInitialized)
            {
                InitializeInstanceFields();
                InstanceFieldsInitialized = true;
            }
        }

        private void InitializeInstanceFields()
        {
            m_LightColorTextFont = this.Font;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle TextRectangle = new Rectangle();
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            if (this.LegendPlate == LegendPlates.Large)
            {
                TextRectangle = new Rectangle(0, Convert.ToInt32(this.Height * 0.4), this.Width, Convert.ToInt32(this.Height * 0.6));
            }
            else
            {
                TextRectangle = new Rectangle(0, Convert.ToInt32(this.Height * 0.2), this.Width, Convert.ToInt32(this.Height * 0.8));
            }

            if (this.Value == true)
            {
                SolidBrush TextBrush = new SolidBrush(LightColorOnTextColor);
                e.Graphics.DrawString(LightColorOnText, LightColorTextFont, TextBrush, TextRectangle, sf);
            }
            else
            {
                SolidBrush TextBrush = new SolidBrush(LightColorOffTextColor);
                e.Graphics.DrawString(LightColorOffText, LightColorTextFont, TextBrush, TextRectangle, sf);
            }

        }

        #region Properties

        private string m_LightColorOnText = "ON";
        public string LightColorOnText
        {
            get
            {
                return m_LightColorOnText;
            }
            set
            {
                m_LightColorOnText = value;
            }
        }

        private string m_LightColorOffText = "OFF";
        public string LightColorOffText
        {
            get
            {
                return m_LightColorOffText;
            }
            set
            {
                m_LightColorOffText = value;
            }
        }

        private System.Drawing.Font m_LightColorTextFont;
        public System.Drawing.Font LightColorTextFont
        {
            get
            {
                return m_LightColorTextFont;
            }
            set
            {
                m_LightColorTextFont = value;
            }
        }

        private Color m_LightColorOnTextColor = Color.Black;
        public Color LightColorOnTextColor
        {
            get
            {
                return m_LightColorOnTextColor;
            }
            set
            {
                m_LightColorOnTextColor = value;
            }
        }

        private Color m_LightColorOffTextColor = Color.White;
        public Color LightColorOffTextColor
        {
            get
            {
                return m_LightColorOffTextColor;
            }
            set
            {
                m_LightColorOffTextColor = value;
            }
        }
        #endregion

    }


}