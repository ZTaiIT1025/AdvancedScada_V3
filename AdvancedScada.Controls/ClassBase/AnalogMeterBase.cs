
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

namespace AdvancedScada.Controls.ClassBase
{
    [ToolboxItem(false)]
    public abstract class AnalogMeterBase : System.Windows.Forms.Control
    {
        protected Bitmap StaticImage;

        protected Bitmap NeedleImage;

        protected double ImageRatio;

        protected Rectangle TextRectangle;

        protected StringFormat sf;

        protected SolidBrush TextBrush;

        protected Bitmap BackBuffer;

        protected Bitmap m_BaseImage;

        protected double m_Value;

        protected double m_Maximum;

        protected double m_Minimum;

        protected double m_ValueScaleFactor;

        protected float x;

        protected float y;

        private int LastWidth;

        private int LastHeight;

        protected Bitmap BaseImage
        {
            get
            {
                return this.m_BaseImage;
            }
            set
            {
                this.m_BaseImage = value;
                this.ImageRatio = (double)this.m_BaseImage.Height / (double)this.m_BaseImage.Width;
            }
        }

        public double Maximum
        {
            get
            {
                return this.m_Maximum;
            }
            set
            {
                if (this.m_Maximum != value)
                {
                    this.m_Maximum = value;
                    this.CreateStaticImage();
                }
            }
        }

        public double Minimum
        {
            get
            {
                return this.m_Minimum;
            }
            set
            {
                if (this.m_Minimum != value)
                {
                    this.m_Minimum = value;
                    this.CreateStaticImage();
                }
            }
        }

        [Category("Numeric Display")]
        public virtual double Value
        {
            get
            {
                return this.m_Value;
            }
            set
            {
                if (value != this.m_Value)
                {
                    this.m_Value = value;
                    this.OnValueChanged(EventArgs.Empty);
                    this.Invalidate();
                }
            }
        }

        [Category("Numeric Display")]
        public double ValueScaleFactor
        {
            get
            {
                return this.m_ValueScaleFactor;
            }
            set
            {
                if (value != this.m_ValueScaleFactor)
                {
                    this.m_ValueScaleFactor = value;
                    if (this.StaticImage != null)
                    {
                        this.Invalidate();
                    }
                }
            }
        }

        public AnalogMeterBase()
        {
            this.m_Maximum = 100;
            this.m_ValueScaleFactor = 1;
            if ((base.ForeColor == Color.FromKnownColor(KnownColor.ControlText)) || (this.ForeColor == Color.FromArgb(0, 0, 0, 0)))
            {
                this.ForeColor = Color.LightGray;
            }
            this.sf = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            this.AdjustSize();
        }

        private void _Resize()
        {
            if (this.Height != this.LastHeight | this.Width != this.LastWidth)
            {
                this.LastWidth = this.Width;
                this.LastHeight = this.Height;
                this.CreateStaticImage();
            }
        }

        private void AdjustSize()
        {
            if (this.BaseImage != null)
            {
                this.ImageRatio = (double)this.m_BaseImage.Height / (double)this.m_BaseImage.Width;
                if (this.LastHeight < this.Height || this.LastWidth < this.Width)
                {
                    if ((double)this.Height / (double)this.Width <= this.ImageRatio)
                    {
                        this.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Width * this.ImageRatio)));
                    }
                    else
                    {
                        this.Width = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height / this.ImageRatio)));
                    }
                }
                else if ((double)this.Height / (double)this.Width <= this.ImageRatio)
                {
                    this.Width = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height / this.ImageRatio)));
                }
                else
                {
                    this.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Width * this.ImageRatio)));
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    if (this.StaticImage != null)
                    {
                        this.StaticImage.Dispose();
                    }
                    if (this.NeedleImage != null)
                    {
                        this.NeedleImage.Dispose();
                    }
                    if (this.TextBrush != null)
                    {
                        this.TextBrush.Dispose();
                    }
                    if (this.sf != null)
                    {
                        this.sf.Dispose();
                    }
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            this.CreateStaticImage();
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            if (this.TextBrush != null)
            {
                this.TextBrush.Color = base.ForeColor;
            }
            else
            {
                this.TextBrush = new SolidBrush(base.ForeColor);
            }
            this.CreateStaticImage();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (this.BackBuffer != null)
            {
                this.BackBuffer.Dispose();
                this.BackBuffer = null;
            }
            this._Resize();
            base.OnSizeChanged(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.CreateStaticImage();
        }

        protected virtual void OnValueChanged(EventArgs e)
        {

            if (ValueChanged != null)
                ValueChanged(this, e);

        }

        protected abstract void CreateStaticImage();

        public event EventHandler ValueChanged;
    }


}