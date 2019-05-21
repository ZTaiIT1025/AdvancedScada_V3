
using AdvancedScada;
using AdvancedScada.Controls;
using AdvancedScada.Controls.Class;
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

namespace AdvancedScada.Controls.DigitalDisplay
{
    public class HMIOdometer : Control
    {
        private Bitmap BackBuffer;
        private RollingDigit[] digits = new RollingDigit[5];

        #region Constructor
        public HMIOdometer()
        {
            for (var i = 0; i < digits.Length; i++)
            {
                digits[i] = new RollingDigit();
            }
        }
        #endregion


        #region Properties
        private double m_Value;
        public double Value
        {
            get
            {
                return m_Value;
            }
            set
            {
                if (value != m_Value)
                {
                    //* Constrain the value withing a single digit
                    m_Value = value;

                    //*****************************************************
                    //* Break the value into the individual digits
                    //*****************************************************
                    double WorkingValue = m_Value;
                    //* Extract each digit's value
                    for (var i = 0; i < digits.Count(); i++)
                    {
                        double DigitValue = WorkingValue / (Math.Pow(10, digits.Count() - i - 1));
                        digits[i].Value = DigitValue;

                        WorkingValue -= (Math.Truncate(DigitValue) * (Math.Pow(10, digits.Count() - i - 1)));
                    }

                    //****************************************************************
                    //* Last digit always rolls, all other digits roll with next nine
                    //****************************************************************
                    for (var index = digits.Count() - 2; index >= 0; index--)
                    {
                        if (digits[index + 1].Value <= 9)
                        {
                            digits[index].Value = Math.Truncate(digits[index].Value);
                        }
                        else
                        {
                            //* Is the digits after in a roll? If so, roll the same
                            double v = (digits[index + 1].Value - Math.Truncate(digits[index + 1].Value));
                            digits[index].Value = Math.Truncate(digits[index].Value) + v;
                        }
                    }

                    this.Invalidate();
                }
            }
        }

        //* Use the ont in the base control for the font of the rolling digits
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                for (var i = 0; i < digits.Length; i++)
                {
                    digits[i].Font = value;
                }
            }
        }

        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                for (var i = 0; i < digits.Length; i++)
                {
                    digits[i].BackColor = value;
                }
            }
        }

        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                for (var i = 0; i < digits.Length; i++)
                {
                    digits[i].ForeColor = value;
                }
            }
        }
        #endregion


        #region Events
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (BackBuffer == null)
            {
                BackBuffer = new Bitmap(this.Width, this.Height);
            }

            using (Graphics g = Graphics.FromImage(BackBuffer))
            {
                for (var index = 0; index < digits.Count(); index++)
                {
                    digits[index].Draw(g, index * digits[index].Width, 0);
                }

                e.Graphics.DrawImageUnscaled(BackBuffer, 0, 0);
            }
        }

        //* Block background painting to reduce flicker
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //MyBase.OnPaintBackground(pevent)
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            int DigitWidth = Convert.ToInt32(this.Width / (double)digits.Count());
            for (var index = 0; index < digits.Count(); index++)
            {
                digits[index].Height = this.Height;
                digits[index].Width = DigitWidth;
            }

            //* Create this for doubke buffer to reduce flicker
            BackBuffer = new Bitmap(this.Width, this.Height);
        }
        #endregion
    }


}