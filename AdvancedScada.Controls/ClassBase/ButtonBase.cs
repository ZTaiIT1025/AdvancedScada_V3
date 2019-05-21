

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
    public abstract class ButtonBase : Control
    {
        protected System.Drawing.Image BackImage;

        protected System.Drawing.Image StaticImage;

        protected System.Drawing.Image OnImage;

        protected System.Drawing.Image OffImage;

        protected double ImageRatio;

        protected Rectangle TextRectangle;

        protected StringFormat sf;

        protected SolidBrush TextBrush;

        protected System.Drawing.Image BaseImage;

        protected Bitmap BackBuffer;

        protected bool m_Value;

        protected float x;

        protected float y;

        protected int LastWidth;

        protected int LastHeight;

        public virtual bool Value
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
                }
            }
        }

        public ButtonBase()
        {
            this.sf = new StringFormat();
        }

        private void _Resize()
        {
            if (this.Height != this.LastHeight | this.Width != this.LastWidth)
            {
                this.AdjustSize();
                this.LastWidth = this.Width;
                this.LastHeight = this.Height;
                if (this.Width > 0 && this.Height > 0)
                {
                    this.CreateStaticImage();
                }
            }
        }

        protected virtual void AdjustSize()
        {
            if (this.BaseImage != null)
            {
                this.ImageRatio = (double)this.BaseImage.Height / (double)this.BaseImage.Width;
                if (this.LastHeight < this.Height || this.LastWidth < this.Width)
                {
                    if ((double)this.Height / (double)this.Width <= this.ImageRatio)
                    {
                        this.Height = Convert.ToInt32((double)this.Width * this.ImageRatio);
                    }
                    else
                    {
                        this.Width = Convert.ToInt32((double)this.Height / this.ImageRatio);
                    }
                }
                else if ((double)this.Height / (double)this.Width <= this.ImageRatio)
                {
                    this.Width = Convert.ToInt32((double)this.Height / this.ImageRatio);
                }
                else
                {
                    this.Height = Convert.ToInt32((double)this.Width * this.ImageRatio);
                }
            }
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            if (this.Width > 0 && this.Height > 0)
            {
                this.CreateStaticImage();
            }
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
            if (this.Width > 0 && this.Height > 0)
            {
                this.CreateStaticImage();
            }
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
            if (this.Width > 0 && this.Height > 0)
            {
                this.CreateStaticImage();
            }
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, e);
            this.Invalidate();
        }

        protected abstract void CreateStaticImage();

        public event EventHandler ValueChanged;
    }


}