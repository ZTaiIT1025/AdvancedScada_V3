

using AdvancedScada;
using AdvancedScada.Controls;
using System;
using System.Collections;
using System.Collections.Generic;

using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Class
{
    [Editor(typeof(RotationValueEditor), typeof(UITypeEditor)), TypeConverter(typeof(RotationTypeConverter))]
    public class RotationScale
    {
        private float m_RotationCCWAngle;

        private float m_RotationCWAngle;

        private float m_RotationMaxValueCCW;

        private float m_RotationMaxValueCW;

        private int m_XPosition;

        private int m_YPosition;

        public float RotationCCWAngle
        {
            get
            {
                return this.m_RotationCCWAngle;
            }
            set
            {
                this.m_RotationCCWAngle = value;
            }
        }

        public float RotationCWAngle
        {
            get
            {
                return this.m_RotationCWAngle;
            }
            set
            {
                this.m_RotationCWAngle = value;
            }
        }

        public float RotationMaxValueCCW
        {
            get
            {
                return this.m_RotationMaxValueCCW;
            }
            set
            {
                this.m_RotationMaxValueCCW = value;
            }
        }

        public float RotationMaxValueCW
        {
            get
            {
                return this.m_RotationMaxValueCW;
            }
            set
            {
                this.m_RotationMaxValueCW = value;
            }
        }

        public int XPosition
        {
            get
            {
                return this.m_XPosition;
            }
            set
            {
                this.m_XPosition = value;
            }
        }

        public int YPosition
        {
            get
            {
                return this.m_YPosition;
            }
            set
            {
                this.m_YPosition = value;
            }
        }

        public RotationScale()
        {
            this.m_RotationCWAngle = 90.0F;
            this.m_RotationMaxValueCCW = 0.0F;
            this.m_RotationMaxValueCW = 90.0F;
        }

        public RotationScale(float rotationCCWAngle, float rotationCWAngle, float rotationMaxValueCCW, float rotationMaxValueCW, int XPosition, int YPosition) : this()
        {
            this.m_RotationCCWAngle = rotationCCWAngle;
            this.m_RotationCWAngle = rotationCWAngle;
            this.m_RotationMaxValueCW = rotationMaxValueCW;
            this.m_RotationMaxValueCCW = rotationMaxValueCCW;
            this.m_XPosition = XPosition;
            this.m_YPosition = YPosition;
        }

        public float GetAngle(float value)
        {
            float mRotationMaxValueCCW = this.m_RotationMaxValueCCW - this.m_RotationMaxValueCW;
            float mRotationCCWAngle = this.m_RotationCCWAngle - this.m_RotationCWAngle;
            return mRotationCCWAngle / mRotationMaxValueCCW * value + this.m_RotationCCWAngle;
        }
    }


}