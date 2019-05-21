

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
    public class HMISevenSegment : System.Windows.Forms.Control
    {
        public event EventHandler ValueChanged;
        #region متغيرات
        //* These are used to keep prescaled images in memory. Scaling in Paint event is expensive operation

        private Bitmap[] RedLED;

        private Bitmap[] GreenLED;

        private Bitmap RedDecimalImage;

        private Bitmap GreenDecimalImage;

        private float ImageRatio;

        private Rectangle TextRectangle;

        private StringFormat sf;

        private SolidBrush TextBrush;

        private bool BackgroundNeedsRefreshed;

        private double m_Value;

        private float m_MinValueForRed;

        private float m_MaxValueForRed;

        private decimal m_ValueScaleFactor;

        private decimal m_Resolution;

        private int m_NumberOfDigits;

        private int m_DecimalPos;

        private float x;

        private float y;

        private int SegWidth;

        private Bitmap _backBuffer;

        private int LastWidth;

        private int LastHeight;

        private float StaticImageRatio;
        #endregion
        #region خصائص
        [Category("Numeric Display")]
        public decimal _ValueScaleFactor
        {
            get
            {
                return this.m_ValueScaleFactor;
            }
            set
            {
                this.m_ValueScaleFactor = value;
                this.Invalidate();
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams_Renamed = base.CreateParams;
                createParams_Renamed.ExStyle |= 32;
                return createParams_Renamed;
            }
        }

        [Category("Numeric Display")]
        public int DecimalPosition
        {
            get
            {
                return this.m_DecimalPos;
            }
            set
            {
                if (value != this.m_DecimalPos)
                {
                    this.m_DecimalPos = Math.Max(Math.Min(this.m_NumberOfDigits - 1, value), 0);
                    this.RefreshImage();
                }
            }
        }

        [Category("Numeric Display")]
        public float MaxValueForRed
        {
            get
            {
                return this.m_MaxValueForRed;
            }
            set
            {
                if (value != this.m_MaxValueForRed)
                {
                    this.m_MaxValueForRed = value;
                    this.Invalidate();
                }
            }
        }

        [Category("Numeric Display")]
        public float MinValueForRed
        {
            get
            {
                return this.m_MinValueForRed;
            }
            set
            {
                if (value != this.m_MinValueForRed)
                {
                    this.m_MinValueForRed = value;
                    this.Invalidate();
                }
            }
        }

        [Category("Numeric Display")]
        public int NumberOfDigits
        {
            get
            {
                return this.m_NumberOfDigits;
            }
            set
            {
                if (value != this.m_NumberOfDigits)
                {
                    this.m_NumberOfDigits = Math.Max(Math.Min(50, value), 1);
                    this.AdjustSize();
                    this.RefreshImage();
                }
            }
        }

        [Category("Numeric Display")]
        public decimal Resolution
        {
            get
            {
                return this.m_Resolution;
            }
            set
            {
                if (decimal.Compare(value, decimal.Zero) != 0)
                {
                    this.m_Resolution = value;
                    this.Invalidate();
                }
            }
        }

        [Category("Numeric Display")]
        public double Value
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
                    this.Invalidate();
                    this.OnValueChanged(EventArgs.Empty);
                }
            }
        }

        #endregion
        #region مشيدات
        public HMISevenSegment()
        {

            this.RedLED = new Bitmap[12];
            this.GreenLED = new Bitmap[12];
            this.TextRectangle = new Rectangle();
            this.sf = new StringFormat();
            this.BackgroundNeedsRefreshed = true;
            this.m_MinValueForRed = 100.0F;
            this.m_MaxValueForRed = 200.0F;
            this.m_ValueScaleFactor = decimal.One;
            this.m_Resolution = decimal.One;
            this.m_NumberOfDigits = 5;
            this.m_DecimalPos = 0;
            this.SegWidth = Properties.Resources.RedZero.Width;
            this.StaticImageRatio = (float)((double)Properties.Resources.DigitalPanelMeter.Height / ((double)Properties.Resources.DigitalPanelMeter.Width * 1.1));
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            if ((base.ForeColor == Color.FromKnownColor(KnownColor.ControlText)) || (this.ForeColor == Color.FromArgb(0, 0, 0, 0)))
            {
                this.ForeColor = Color.LightGray;
            }
            this.AdjustSize();
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    this.RedDecimalImage.Dispose();
                    int length = this.RedLED.Length - 1;
                    for (int i = 0; i <= length; i++)
                    {
                        if (this.RedLED[i] != null)
                        {
                            this.RedLED[i].Dispose();
                        }
                        if (this.GreenLED[i] != null)
                        {
                            this.GreenLED[i].Dispose();
                        }
                    }
                    this.TextBrush.Dispose();
                    this.sf.Dispose();
                    this._backBuffer.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }
        #endregion
        #region اعادة تعريف الاحداث
        protected override void OnCreateControl()
        {
            this.sf.Alignment = StringAlignment.Center;
            this.sf.LineAlignment = StringAlignment.Far;
            base.OnCreateControl();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            this.Invalidate();
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
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            bool flag = false;
            if (!(this._backBuffer == null || this.TextBrush == null))
            {
                using (Graphics graphic = Graphics.FromImage(this._backBuffer))
                {
                    graphic.Clear(this.BackColor);
                    if (this.BackgroundImage != null)
                    {
                        if (this.BackgroundImageLayout != ImageLayout.Stretch)
                        {
                            graphic.DrawImage(this.BackgroundImage, 0, 0);
                        }
                        else
                        {
                            graphic.DrawImage(this.BackgroundImage, 0, 0, this.Width, this.Height);
                        }
                    }
                    decimal one = decimal.Divide(decimal.One, this.m_Resolution);
                    if (decimal.Compare(one, decimal.Zero) == 0)
                    {
                        one = decimal.One;
                    }
                    long num = Convert.ToInt64(Math.Truncate(Math.Round(this.m_Value * Convert.ToDouble(one) * Convert.ToDouble(this.m_ValueScaleFactor))));
                    long num1 = Convert.ToInt64(decimal.Divide(new decimal(num), one));
                    if (!((double)num1 <= Math.Pow(10, (double)this.m_NumberOfDigits) - 1 && (double)num1 >= (Math.Pow(10, (double)(this.m_NumberOfDigits - 1)) - 1) * -1))
                    {
                        int mNumberOfDigits = this.m_NumberOfDigits;
                        for (int i = 1; i <= mNumberOfDigits; i++)
                        {
                            graphic.DrawImage(this.RedLED[11], (float)(this.SegWidth * (i - 1)) * this.ImageRatio, 0.0F);
                        }
                    }
                    else
                    {
                        int mNumberOfDigits1 = this.m_NumberOfDigits;
                        for (int j = 1; j <= mNumberOfDigits1; j++)
                        {
                            if (num1 >= (long)0)
                            {
                                int num2 = Convert.ToInt32(Math.Floor((double)num1 / Math.Pow(10, (double)(this.m_NumberOfDigits - j))));
                                if (num2 > 0 || j == this.m_NumberOfDigits || j > this.m_NumberOfDigits - this.m_DecimalPos)
                                {
                                    flag = true;
                                }
                                if (flag)
                                {
                                    if (!(this.m_Value >= (double)this.m_MinValueForRed && this.m_Value <= (double)this.m_MaxValueForRed))
                                    {
                                        graphic.DrawImage(this.GreenLED[num2], (float)Convert.ToInt32((double)(this.SegWidth * (j - 1)) * 1.1) * this.ImageRatio, 0.0F);
                                    }
                                    else
                                    {
                                        graphic.DrawImage(this.RedLED[num2], (float)Convert.ToInt32((double)(this.SegWidth * (j - 1)) * 1.1) * this.ImageRatio, 0.0F);
                                    }
                                }
                                else if (!(this.m_Value >= (double)this.m_MinValueForRed && this.m_Value <= (double)this.m_MaxValueForRed))
                                {
                                    graphic.DrawImage(this.GreenLED[10], (float)Convert.ToInt32((double)(this.SegWidth * (j - 1)) * 1.1) * this.ImageRatio, 0.0F);
                                }
                                else
                                {
                                    graphic.DrawImage(this.RedLED[10], (float)Convert.ToInt32((double)(this.SegWidth * (j - 1)) * 1.1) * this.ImageRatio, 0.0F);
                                }
                                num1 = Convert.ToInt64(Math.Truncate(Math.Round((double)num1 - (double)num2 * Math.Pow(10, (double)(this.m_NumberOfDigits - j)))));
                            }
                            else
                            {
                                if (!(this.m_Value >= (double)this.m_MinValueForRed && this.m_Value <= (double)this.m_MaxValueForRed))
                                {
                                    graphic.DrawImage(this.GreenLED[11], (float)(this.SegWidth * (j - 1)) * this.ImageRatio, 0.0F);
                                }
                                else
                                {
                                    graphic.DrawImage(this.RedLED[11], (float)(this.SegWidth * (j - 1)) * this.ImageRatio, 0.0F);
                                }
                                num1 = Math.Abs(num1);
                            }
                        }
                    }
                    if (this.m_DecimalPos > 0)
                    {
                        if (!(this.m_Value >= (double)this.m_MinValueForRed && this.m_Value <= (double)this.m_MaxValueForRed))
                        {
                            graphic.DrawImage(this.GreenDecimalImage, (float)Convert.ToInt32((double)((float)(((this.m_NumberOfDigits - this.m_DecimalPos) * this.SegWidth) - 50) * this.ImageRatio) * 1.1), 440.0F * this.ImageRatio);
                        }
                        else
                        {
                            graphic.DrawImage(this.RedDecimalImage, (float)Convert.ToInt32((double)((float)(((this.m_NumberOfDigits - this.m_DecimalPos) * this.SegWidth) - 50) * this.ImageRatio) * 1.1), 440.0F * this.ImageRatio);
                        }
                    }
                    e.Graphics.DrawImage(this._backBuffer, 0, 0);
                }
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (this.BackgroundNeedsRefreshed)
            {
                base.OnPaintBackground(e);
                this.BackgroundNeedsRefreshed = false;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (this._backBuffer != null)
            {
                this._backBuffer.Dispose();
                this._backBuffer = null;
            }
            this._Resize(this, null);
            base.OnSizeChanged(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Invalidate();
        }

        protected virtual void OnValueChanged(EventArgs e)
        {

            if (ValueChanged != null)
                ValueChanged(this, e);

        }
        #endregion
        #region طرق
        private void _Resize(object sender, EventArgs e)
        {
            if (this.Height != this.LastHeight | this.Width != this.LastWidth)
            {
                this.AdjustSize();
                this.LastWidth = this.Width;
                this.LastHeight = this.Height;
                this.RefreshImage();
            }
        }
        private void AdjustSize()
        {
            this.StaticImageRatio = (float)((double)Properties.Resources.RedZero.Height / ((double)(Properties.Resources.RedZero.Width * this.m_NumberOfDigits) * 1.1));
            if (this.LastHeight < this.Height || this.LastWidth < this.Width)
            {
                if ((double)this.Height / (double)this.Width <= (double)this.StaticImageRatio)
                {
                    this.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)((float)this.Width * this.StaticImageRatio))));
                }
                else
                {
                    this.Width = Convert.ToInt32(Math.Truncate(Math.Round((double)((float)this.Height / this.StaticImageRatio))));
                }
            }
            else if ((double)this.Height / (double)this.Width <= (double)this.StaticImageRatio)
            {
                this.Width = Convert.ToInt32(Math.Truncate(Math.Round((double)((float)this.Height / this.StaticImageRatio))));
            }
            else
            {
                this.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)((float)this.Width * this.StaticImageRatio))));
            }
        }
        private void RefreshImage()
        {
            Graphics gr_dest = null;
            this.StaticImageRatio = (float)((double)Properties.Resources.RedZero.Height / ((double)(Properties.Resources.RedZero.Width * this.m_NumberOfDigits) * 1.1));
            //************************************************************
            //* Calculate the size ratio of the original t resized image
            //************************************************************
            float WidthRatio = (float)((double)this.Width / ((double)(Properties.Resources.RedZero.Width * this.m_NumberOfDigits) * 1.1));
            float HeightRatio = (float)((double)this.Height / (double)Properties.Resources.RedZero.Height);
            //========================================================
            if (WidthRatio >= HeightRatio)
            {
                this.x = (float)this.Width;
                this.y = (float)((double)Properties.Resources.RedZero.Height / (double)(Properties.Resources.RedZero.Width * this.m_NumberOfDigits) * (double)this.Width);
                this.ImageRatio = HeightRatio;
            }
            else
            {
                this.y = (float)this.Height;
                if (!(this.Height > 0 && Properties.Resources.LED7Segment0Red.Height > 0))
                {
                    this.x = 1.0F;
                }
                else
                {
                    this.x = (float)((double)(Properties.Resources.RedZero.Width * this.m_NumberOfDigits) * 1.1 / (double)Properties.Resources.RedZero.Height * (double)this.Height);
                }
                this.ImageRatio = WidthRatio;
            }
            //==============================================================
            //************************************************
            //* Create a text rectangle and align to center
            //************************************************
            if (this.ImageRatio > 0.0F)
            {
                this.TextRectangle.X = 0;
                this.TextRectangle.Y = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height * 0.04)));
                this.TextRectangle.Width = this.Width;
                this.TextRectangle.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height * 0.18)));
                if (this.TextBrush == null)
                {
                    this.TextBrush = new SolidBrush(base.ForeColor);
                }
                //============================================================
                //* If number of digits is more than default image size (4), then draw left meter over right

                int LEDWidth = Convert.ToInt32((float)Properties.Resources.RedEight.Width * this.ImageRatio);
                int LEDHeight = Convert.ToInt32((float)Properties.Resources.RedEight.Height * this.ImageRatio);

                //****************************************************************
                // Create Scaled LED images so it will draw faster in Paint event
                //****************************************************************
                int i = 0;
                //****************************************
                //* Draw each of the RED digits
                //****************************************
                for (i = 0; i <= 11; i++)
                {
                    if (this.RedLED[i] != null)
                    {
                        this.RedLED[i].Dispose();
                    }
                    this.RedLED[i] = new Bitmap(LEDWidth, LEDHeight);
                    gr_dest = Graphics.FromImage(this.RedLED[i]);
                    switch (i)
                    {
                        case 0:
                            gr_dest.DrawImage(Properties.Resources.RedZero, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 1:
                            gr_dest.DrawImage(Properties.Resources.RedOne, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 2:
                            gr_dest.DrawImage(Properties.Resources.RedTwo, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 3:
                            gr_dest.DrawImage(Properties.Resources.RedThree, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 4:
                            gr_dest.DrawImage(Properties.Resources.RedFour, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 5:
                            gr_dest.DrawImage(Properties.Resources.RedFive, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 6:
                            gr_dest.DrawImage(Properties.Resources.RedSix, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 7:
                            gr_dest.DrawImage(Properties.Resources.RedSeven, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 8:
                            gr_dest.DrawImage(Properties.Resources.RedEight, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 9:
                            gr_dest.DrawImage(Properties.Resources.RedNine, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 10:
                            gr_dest.DrawImage(Properties.Resources.RedOff, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 11:
                            gr_dest.DrawImage(Properties.Resources.RedDash, 0, 0, LEDWidth, LEDHeight);
                            break;
                    }
                }

                //****************************************
                //* Draw each of the Green  digits
                //****************************************
                int r = 0;
                for (r = 0; r <= 11; r++)
                {
                    if (this.GreenLED[r] != null)
                    {
                        this.GreenLED[r].Dispose();
                    }
                    this.GreenLED[r] = new Bitmap(LEDWidth, LEDHeight);
                    gr_dest = Graphics.FromImage(this.GreenLED[r]);
                    switch (r)
                    {
                        case 0:
                            gr_dest.DrawImage(Properties.Resources.Green0, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 1:
                            gr_dest.DrawImage(Properties.Resources.Green1, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 2:
                            gr_dest.DrawImage(Properties.Resources.Green2, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 3:
                            gr_dest.DrawImage(Properties.Resources.Green3, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 4:
                            gr_dest.DrawImage(Properties.Resources.Green4, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 5:
                            gr_dest.DrawImage(Properties.Resources.Green5, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 6:
                            gr_dest.DrawImage(Properties.Resources.Green6, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 7:
                            gr_dest.DrawImage(Properties.Resources.Green7, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 8:
                            gr_dest.DrawImage(Properties.Resources.Green8, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 9:
                            gr_dest.DrawImage(Properties.Resources.Green9, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 10:
                            gr_dest.DrawImage(Properties.Resources.RedOff, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 11:
                            gr_dest.DrawImage(Properties.Resources.GreenDash, 0, 0, LEDWidth, LEDHeight);
                            break;
                    }
                }
                //* Draw the decimal point to the bitmap

                this.RedDecimalImage = new Bitmap(Convert.ToInt32((float)Properties.Resources.RedDecimal.Width * this.ImageRatio), Convert.ToInt32((float)Properties.Resources.RedDecimal.Height * this.ImageRatio));
                gr_dest = Graphics.FromImage(this.RedDecimalImage);
                gr_dest.DrawImage(Properties.Resources.RedDecimal, 0, 0, this.RedDecimalImage.Width, this.RedDecimalImage.Height);
                this.GreenDecimalImage = new Bitmap(Convert.ToInt32((float)Properties.Resources.GreenDecimal.Width * this.ImageRatio), Convert.ToInt32((float)Properties.Resources.GreenDecimal.Height * this.ImageRatio));
                gr_dest = Graphics.FromImage(this.GreenDecimalImage);
                gr_dest.DrawImage(Properties.Resources.GreenDecimal, 0, 0, this.GreenDecimalImage.Width, this.GreenDecimalImage.Height);


                //* Perform some cleanup
                gr_dest.Dispose();
                if (this._backBuffer != null)
                {
                    this._backBuffer.Dispose();
                }
                this._backBuffer = new Bitmap(this.Width, this.Height);
                this.BackgroundNeedsRefreshed = true;
                this.Invalidate();
            }
        }
        #endregion


    }


}