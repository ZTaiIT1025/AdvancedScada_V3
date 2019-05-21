

using AdvancedScada;
using AdvancedScada.Controls;
using System;
using System.Collections;
using System.Collections.Generic;

using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Class
{
    [TypeConverter(typeof(TranslationScaleTypeConverter))]
    public class TranslationScale
    {
        private double m_InputMinValue;

        private double m_InputMaxValue;

        private double m_OutputMinValue;

        private double m_OutputMaxValue;

        private double m_ErrorValue;

        public double ErrorValue
        {
            get
            {
                return this.m_ErrorValue;
            }
            set
            {
                this.m_ErrorValue = value;
            }
        }

        public double InputMaxValue
        {
            get
            {
                return this.m_InputMaxValue;
            }
            set
            {
                this.m_InputMaxValue = value;
            }
        }

        public double InputMinValue
        {
            get
            {
                return this.m_InputMinValue;
            }
            set
            {
                this.m_InputMinValue = value;
            }
        }

        public double OutputMaxValue
        {
            get
            {
                return this.m_OutputMaxValue;
            }
            set
            {
                this.m_OutputMaxValue = value;
            }
        }

        public double OutputMinValue
        {
            get
            {
                return this.m_OutputMinValue;
            }
            set
            {
                this.m_OutputMinValue = value;
            }
        }

        public TranslationScale()
        {
            this.m_InputMaxValue = 100;
            this.m_OutputMaxValue = 100;
        }

        public TranslationScale(double inputMinValue, double inputMaxValue, double outputMinValue, double outputMaxValue) : this()
        {
            this.m_InputMinValue = inputMinValue;
            this.m_InputMaxValue = inputMaxValue;
            this.m_OutputMinValue = outputMinValue;
            this.m_OutputMaxValue = outputMaxValue;
        }

        public double GetValue(double value)
        {
            double num = 0;
            double mInputMaxValue = this.m_InputMaxValue - this.m_InputMinValue;
            double mOutputMaxValue = this.m_OutputMaxValue - this.m_OutputMinValue;
            num = ((mInputMaxValue == 0) ? this.m_ErrorValue : (value - this.m_InputMinValue) * (mOutputMaxValue / mInputMaxValue) + this.m_OutputMinValue);
            return num;
        }
    }


}