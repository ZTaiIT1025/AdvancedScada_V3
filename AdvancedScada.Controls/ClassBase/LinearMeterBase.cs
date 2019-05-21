
using AdvancedScada;
using AdvancedScada.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvancedScada.Controls.ClassBase
{
    [ToolboxItem(false)]
    public class LinearMeterBase : AnalogMeterBase
    {
        public enum FillTypes
        {
            Fill,
            WideBand,
            NarrowBand
        }

        private EventHandler eventHandler_1;

        protected internal Rectangle BarRectangle;

        protected internal FillTypes m_FillType;

        protected internal Color m_FillColor;

        protected internal Color m_FillColorInRange;

        protected internal Color m_FillAreaBackcolor;

        protected internal Color m_BorderColor;

        protected internal int m_BorderWidth;

        protected internal string m_NumericFormat;

        protected internal bool m_CenterTargetValue;

        protected internal double m_TargetValue;

        protected internal bool m_ScaleTargetValue;

        protected internal double m_TolerancePlus;

        protected internal double m_ToleranceMinus;

        protected internal int m_MajorDivisions;

        protected internal int m_MinorDivisions;

        protected internal bool m_ShowValidRangeMarker;

        protected internal bool m_ShowValue;

        public event EventHandler BorderColorChanged;


        public FillTypes FillType
        {
            get
            {
                return this.m_FillType;
            }
            set
            {
                if (this.m_FillType != value)
                {
                    this.m_FillType = value;
                    base.Invalidate();
                }
            }
        }

        public Color FillColor
        {
            get
            {
                return this.m_FillColor;
            }
            set
            {
                if (this.m_FillColor != value)
                {
                    this.m_FillColor = value;
                    base.Invalidate();
                }
            }
        }

        public Color FillColorInRange
        {
            get
            {
                return this.m_FillColorInRange;
            }
            set
            {
                if (this.m_FillColorInRange != value)
                {
                    this.m_FillColorInRange = value;
                    base.Invalidate();
                }
            }
        }

        public Color FillAreaBackcolor
        {
            get
            {
                return this.m_FillAreaBackcolor;
            }
            set
            {
                if (this.m_FillAreaBackcolor != value)
                {
                    this.m_FillAreaBackcolor = value;
                    this.CreateStaticImage();
                }
            }
        }

        public Color BorderColor
        {
            get
            {
                return this.m_BorderColor;
            }
            set
            {
                if (this.m_BorderColor != value)
                {
                    this.m_BorderColor = value;
                    this.CreateStaticImage();
                    this.OnBorderColorChanged(EventArgs.Empty);
                }
            }
        }

        public int BorderWidth
        {
            get
            {
                return this.m_BorderWidth;
            }
            set
            {
                if (this.m_BorderWidth != value)
                {
                    this.m_BorderWidth = Math.Max(0, value);
                    this.m_BorderWidth = Math.Min(this.m_BorderWidth, 20);
                    this.CreateStaticImage();
                }
            }
        }

        public string NumericFormat
        {
            get
            {
                return this.m_NumericFormat;
            }
            set
            {
                this.m_NumericFormat = value;
            }
        }

        public bool CenterTargetValue
        {
            get
            {
                return this.m_CenterTargetValue;
            }
            set
            {
                if (this.m_CenterTargetValue != value)
                {
                    this.m_CenterTargetValue = value;
                    this.CreateStaticImage();
                }
            }
        }

        public double TargetValue
        {
            get
            {
                return this.m_TargetValue;
            }
            set
            {
                if (this.m_TargetValue != value)
                {
                    this.m_TargetValue = value;
                    this.CreateStaticImage();
                }
            }
        }

        public bool ScaleTargetValue
        {
            get
            {
                return this.m_ScaleTargetValue;
            }
            set
            {
                this.m_ScaleTargetValue = value;
            }
        }

        public double TolerancePlus
        {
            get
            {
                return this.m_TolerancePlus;
            }
            set
            {
                if (this.m_TolerancePlus != value)
                {
                    this.m_TolerancePlus = value;
                    this.CreateStaticImage();
                }
            }
        }

        public double ToleranceMinus
        {
            get
            {
                return this.m_ToleranceMinus;
            }
            set
            {
                if (this.m_ToleranceMinus != value)
                {
                    this.m_ToleranceMinus = value;
                    this.CreateStaticImage();
                }
            }
        }

        public int MajorDivisions
        {
            get
            {
                return this.m_MajorDivisions;
            }
            set
            {
                if (this.m_MajorDivisions != value)
                {
                    this.m_MajorDivisions = value;
                    this.CreateStaticImage();
                }
            }
        }

        public int MinorDivisions
        {
            get
            {
                return this.m_MinorDivisions;
            }
            set
            {
                if (this.m_MinorDivisions != value)
                {
                    this.m_MinorDivisions = value;
                    this.CreateStaticImage();
                }
            }
        }

        public bool ShowValidRangeMarker
        {
            get
            {
                return this.m_ShowValidRangeMarker;
            }
            set
            {
                if (this.m_ShowValidRangeMarker != value)
                {
                    this.m_ShowValidRangeMarker = value;
                    this.CreateStaticImage();
                }
            }
        }

        public bool ShowValue
        {
            get
            {
                return this.m_ShowValue;
            }
            set
            {
                if (this.m_ShowValue != value)
                {
                    this.m_ShowValue = value;
                    base.Invalidate();
                }
            }
        }

        public LinearMeterBase()
        {
            this.m_FillType = FillTypes.Fill;
            this.m_FillColor = Color.FromArgb(128, 16, 16);
            this.m_FillColorInRange = Color.FromArgb(16, 128, 16);
            this.m_FillAreaBackcolor = Color.LightGray;
            this.m_BorderColor = Color.DimGray;
            this.m_BorderWidth = 8;
            this.m_TargetValue = 50.0;
            this.m_ScaleTargetValue = true;
            this.m_TolerancePlus = 10.0;
            this.m_ToleranceMinus = 10.0;
            this.m_MajorDivisions = 2;
            this.m_MinorDivisions = 5;
            this.m_ShowValidRangeMarker = true;
            this.m_ShowValue = true;
            base.SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected virtual void OnBorderColorChanged(EventArgs e)
        {
            if (BorderColorChanged != null)
                BorderColorChanged(this, e);
        }

        protected override void OnValueChanged(EventArgs e)
        {
            base.OnValueChanged(e);
            base.Invalidate(this.BarRectangle);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.CreateStaticImage();
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            this.CreateStaticImage();
        }

        protected override void OnBackgroundImageChanged(EventArgs e)
        {
            base.OnBackgroundImageChanged(e);
            this.CreateStaticImage();
        }

        protected override void OnBackgroundImageLayoutChanged(EventArgs e)
        {
            base.OnBackgroundImageLayoutChanged(e);
            this.CreateStaticImage();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawImage(this.StaticImage, 0, 0);
        }

        protected override void CreateStaticImage()
        {
        }
    }




}