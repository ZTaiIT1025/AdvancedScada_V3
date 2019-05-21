
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

namespace AdvancedScada.Controls.SevenSegment
{
    public class HMILED : System.Windows.Forms.Control
    {
        public event EventHandler ValueChanged;
        public HMILED()
        {

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.Selectable | ControlStyles.AllPaintingInWmPaint | ControlStyles.StandardClick | ControlStyles.UserPaint, true);

            this.BackgroundImageLayout = ImageLayout.Stretch;
            if (_lEDColors == LEDColor.GreenLED)
            {
                SetNumberGreen(m_Value);
            }
            else
            {
                SetNumberRed(m_Value);
            }

            this.Size = new Size(50, 50);
            this.DoubleBuffered = true;

        }
        protected virtual void OnValueChanged(EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, e);
        }
        private int m_Value = 0;
        [Category("Numeric Display")]
        public int Value
        {
            get
            {
                return this.m_Value;
            }
            set
            {

                if (value != this.m_Value)
                {
                    if (_lEDColors == LEDColor.GreenLED)
                    {
                        SetNumberGreen(value);
                    }
                    else
                    {
                        SetNumberRed(value);
                    }


                    this.Invalidate();
                    this.OnValueChanged(EventArgs.Empty);
                }
            }
        }

        public LEDColor LEDColors
        {
            get
            {
                return _lEDColors;
            }
            set
            {
                _lEDColors = value;
                if (value == LEDColor.GreenLED)
                {
                    this.SetNumberGreen(m_Value);
                }
                else
                {
                    this.SetNumberRed(m_Value);
                }
            }
        }

        public enum LEDColor
        {
            RedLED,
            GreenLED
        }
        private LEDColor _lEDColors = LEDColor.GreenLED;

        public int SetNumberGreen(int num)
        {

            switch (num)
            {
                case 0:
                    BackgroundImage = Properties.Resources.Green0;
                    break;
                case 1:
                    BackgroundImage = Properties.Resources.Green1;
                    break;
                case 2:
                    BackgroundImage = Properties.Resources.Green2;
                    break;
                case 3:
                    BackgroundImage = Properties.Resources.Green3;
                    break;
                case 4:
                    BackgroundImage = Properties.Resources.Green4;
                    break;
                case 5:
                    BackgroundImage = Properties.Resources.Green5;
                    break;
                case 6:
                    BackgroundImage = Properties.Resources.Green6;
                    break;
                case 7:
                    BackgroundImage = Properties.Resources.Green7;
                    break;
                case 8:
                    BackgroundImage = Properties.Resources.Green8;
                    break;
                case 9:
                    BackgroundImage = Properties.Resources.Green9;
                    break;
                default:
                    BackgroundImage = Properties.Resources.Green0;
                    break;
            }
            return num;
        }
        public int SetNumberRed(int num)
        {

            switch (num)
            {
                case 0:
                    BackgroundImage = Properties.Resources.RedZero;
                    break;
                case 1:
                    BackgroundImage = Properties.Resources.RedOne;
                    break;
                case 2:
                    BackgroundImage = Properties.Resources.RedTwo;
                    break;
                case 3:
                    BackgroundImage = Properties.Resources.RedThree;
                    break;
                case 4:
                    BackgroundImage = Properties.Resources.RedFour;
                    break;
                case 5:
                    BackgroundImage = Properties.Resources.RedFive;
                    break;
                case 6:
                    BackgroundImage = Properties.Resources.RedSix;
                    break;
                case 7:
                    BackgroundImage = Properties.Resources.RedSeven;
                    break;
                case 8:
                    BackgroundImage = Properties.Resources.RedEight;
                    break;
                case 9:
                    BackgroundImage = Properties.Resources.RedNine;
                    break;
                default:
                    BackgroundImage = Properties.Resources.RedZero;
                    break;
            }
            return num;
        }
    }


}