

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

namespace AdvancedScada.Controls.WeightIndicator
{
    public class HMIWeightIndicator2 : System.Windows.Forms.Control
    {
        #region Bitmap


        private Bitmap StaticImage;

        private Bitmap[] LED = new Bitmap[12];

        private Bitmap DecimalImage;
        #endregion
        private float ImageRatio;

        private Rectangle TextRectangle;

        private StringFormat sf;

        private SolidBrush TextBrush;

        private float x;

        private float y;

        private float m_Value;
        private string m_Button1Text;

        private string m_Button2Text;

        private decimal m_ValueScaleFactor;

        private decimal m_ValueScaleOffset;

        private decimal m_Resolution;

        private int m_NumberOfDigits;

        private int m_DecimalPos;

        private int SegWidth;

        private Bitmap _backBuffer;

        private int LastWidth;

        private int LastHeight;

        private float StaticImageRatio;
        #region Property
        [Category("Numeric Display")]
        public int DecimalPosition
        {
            get
            {
                return m_DecimalPos;
            }
            set
            {
                m_DecimalPos = Math.Max(Math.Min(m_NumberOfDigits - 1, value), 0);
                Invalidate();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                if (TextBrush != null)
                {
                    TextBrush.Color = value;
                }
                else
                {
                    TextBrush = new SolidBrush(value);
                }
                base.ForeColor = value;
                Invalidate();
            }
        }

        [Category("Numeric Display")]
        public int NumberOfDigits
        {
            get
            {
                return m_NumberOfDigits;
            }
            set
            {
                if (value != m_NumberOfDigits)
                {
                    m_NumberOfDigits = Math.Max(Math.Min(6, value), 4);
                    AdjustSize();
                    RefreshImage();
                }
            }
        }

        [Category("Numeric Display")]
        public decimal Resolution
        {
            get
            {
                return m_Resolution;
            }
            set
            {
                if (decimal.Compare(value, decimal.Zero) != 0)
                {
                    m_Resolution = value;
                    if (StaticImage != null)
                    {
                        Invalidate();
                    }
                }
            }
        }



        [Category("Numeric Display")]
        public float Value
        {
            get
            {
                return m_Value;
            }
            set
            {
                if (value != m_Value)
                {
                    m_Value = value;
                    Rectangle rectangle = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)StaticImage.Width * 0.08))), Convert.ToInt32(Math.Truncate(Math.Round((double)StaticImage.Height * 0.1))), Convert.ToInt32(Math.Truncate(Math.Round((double)StaticImage.Width * 0.85))), Convert.ToInt32(Math.Truncate(Math.Round((double)StaticImage.Height * 0.8))));
                    Invalidate(rectangle);
                    OnValueChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Numeric Display")]
        public decimal ValueScaleFactor
        {
            get
            {
                return m_ValueScaleFactor;
            }
            set
            {
                if (decimal.Compare(m_ValueScaleFactor, value) != 0)
                {
                    m_ValueScaleFactor = value;
                    Invalidate();
                    OnValueChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Numeric Display")]
        public decimal ValueScaleOffset
        {
            get
            {
                return m_ValueScaleOffset;
            }
            set
            {
                if (decimal.Compare(m_ValueScaleOffset, value) != 0)
                {
                    m_ValueScaleOffset = value;
                    Invalidate();
                    OnValueChanged(EventArgs.Empty);
                }
            }
        }

        #endregion


        public HMIWeightIndicator2()
        {
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 12);
            ForeColor = Color.FromArgb(150, 150, 150);
            Size = new Size(166, 40);

            TextRectangle = new Rectangle();
            m_ValueScaleFactor = decimal.One;
            m_Resolution = decimal.One;
            m_NumberOfDigits = 5;
            m_DecimalPos = 0;
            SegWidth = 70;
            StaticImageRatio = (float)((double)Properties.Resources.Indicator2.Height / (double)Properties.Resources.Indicator2.Width);
            if ((base.ForeColor == Color.FromKnownColor(KnownColor.ControlText)) || (ForeColor == Color.FromArgb(0, 0, 0, 0)))
            {
                ForeColor = Color.LightGray;
            }
            AdjustSize();
            sf = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Far
            };
        }
        protected void AdjustSize()
        {

            this.StaticImageRatio = (float)((double)Properties.Resources.Indicator2.Height / (double)Properties.Resources.Indicator2.Width);
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
            this.LastWidth = this.Width;
            this.LastHeight = this.Height;
            this.RefreshImage();
        }


        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    if (StaticImage != null)
                    {
                        StaticImage.Dispose();
                    }
                    if (DecimalImage != null)
                    {
                        DecimalImage.Dispose();
                    }
                    int length = (LED.Length) - 1;
                    for (int i = 0; i <= length; i++)
                    {
                        if (LED[i] != null)
                        {
                            LED[i].Dispose();
                        }
                    }
                    TextBrush.Dispose();
                    sf.Dispose();
                    _backBuffer.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            bool DigitsStarted = false;
            if (!(StaticImage == null || _backBuffer == null || TextBrush == null))
            {
                using (Graphics g = Graphics.FromImage(_backBuffer))
                {
                    g.Clear(base.BackColor);
                    g.FillRectangle(new SolidBrush(BackColor), 0, 0, Width, Height);
                    g.DrawImage(StaticImage, 0, 0);

                    decimal one = decimal.Divide(decimal.One, m_Resolution);
                    if (decimal.Compare(one, decimal.Zero) == 0)
                    {
                        one = decimal.One;
                    }
                    long num = Convert.ToInt64(Math.Truncate(Math.Round((m_Value + Convert.ToDouble(m_ValueScaleOffset)) * Convert.ToDouble(one) * Convert.ToDouble(m_ValueScaleFactor))));
                    long WorkValue = Convert.ToInt64(decimal.Divide(new decimal(num), one));
                    if (!(WorkValue <= Math.Pow(10, m_NumberOfDigits) - 1 && WorkValue >= (Math.Pow(10, m_NumberOfDigits - 1) - 1) * -1))
                    {
                        int mNumberOfDigits = m_NumberOfDigits;
                        for (int i = 1; i <= mNumberOfDigits; i++)
                        {
                            g.DrawImage(LED[11], (75 + SegWidth * (i - 1)) * ImageRatio, 35.0F * ImageRatio);
                        }
                    }
                    else
                    {
                        int mNumberOfDigits1 = m_NumberOfDigits;
                        for (int j = 1; j <= mNumberOfDigits1; j++)
                        {
                            if (WorkValue >= 0)
                            {
                                int d = Convert.ToInt32(Math.Floor(WorkValue / Math.Pow(10, m_NumberOfDigits - j)));
                                if (d > 0 || j == m_NumberOfDigits || j > m_NumberOfDigits - m_DecimalPos)
                                {
                                    DigitsStarted = true;
                                }
                                if (!DigitsStarted)
                                {
                                    g.DrawImage(LED[10], (75 + SegWidth * (j - 1)) * ImageRatio, 35.0F * ImageRatio);
                                }
                                else
                                {
                                    g.DrawImage(LED[d], (75 + SegWidth * (j - 1)) * ImageRatio, 35.0F * ImageRatio);
                                }
                                WorkValue = Convert.ToInt64(Math.Truncate(Math.Round((double)WorkValue - (double)d * Math.Pow(10, (double)(m_NumberOfDigits - j)))));
                            }
                            else
                            {
                                g.DrawImage(LED[11], (75 + SegWidth * (j - 1)) * ImageRatio, 35.0F * ImageRatio);
                                WorkValue = Math.Abs(WorkValue);
                            }
                        }
                    }
                    if (m_DecimalPos > 0)
                    {
                        g.DrawImage(DecimalImage, (((m_NumberOfDigits - m_DecimalPos) * SegWidth) + 65) * ImageRatio, 130.0F * ImageRatio);
                    }
                    e.Graphics.DrawImage(_backBuffer, 0, 0);
                }
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (_backBuffer != null)
            {
                _backBuffer.Dispose();
                _backBuffer = null;
            }
            RatioLock();
            base.OnSizeChanged(e);
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, e);
        }

        private void RatioLock()
        {
            if (Height != LastHeight | Width != LastWidth)
            {
                AdjustSize();
                LastWidth = Width;
                LastHeight = Height;
                RefreshImage();
            }
        }

        private void RefreshImage()
        {

            float WidthRatio = (float)((double)this.Width / (double)Properties.Resources.Indicator2.Width);
            float HeightRatio = (float)((double)this.Height / (double)Properties.Resources.Indicator2.Height);
            if (WidthRatio >= HeightRatio)
            {
                x = (float)Width;
                y = (float)((double)Properties.Resources.Indicator2.Height / (double)Properties.Resources.Indicator2.Width * (double)this.Width);
                this.ImageRatio = HeightRatio;
            }
            else
            {
                y = (float)this.Height;
                x = (!(this.Height > 0 && Properties.Resources.Indicator2.Height > 0) ? 1.0F : (float)((double)Properties.Resources.Indicator2.Width / (double)Properties.Resources.Indicator2.Height * (double)this.Height));
                this.ImageRatio = WidthRatio;
            }
            if (this.ImageRatio > 0.0F)
            {
                if (this.StaticImage != null)
                {
                    this.StaticImage.Dispose();
                }
                this.StaticImage = new Bitmap(Convert.ToInt32((float)Properties.Resources.Indicator2.Width * this.ImageRatio), Convert.ToInt32((float)Properties.Resources.Indicator2.Height * this.ImageRatio));
                Graphics gr_dest = Graphics.FromImage(this.StaticImage);
                gr_dest.DrawImage(Properties.Resources.Indicator2, 0, 0, this.StaticImage.Width, this.StaticImage.Height);


                int LEDWidth = Convert.ToInt32(Math.Truncate(Math.Round((double)Convert.ToInt32((float)Properties.Resources.LED7Segment8Red.Width * ImageRatio) * 0.7)));
                int LEDHeight = Convert.ToInt32(Math.Truncate(Math.Round((double)Convert.ToInt32((float)Properties.Resources.LED7Segment8Red.Height * ImageRatio) * 0.7)));
                int i = 0;
                do
                {
                    if (LED[i] != null)
                    {
                        LED[i].Dispose();
                    }
                    LED[i] = new Bitmap(LEDWidth, LEDHeight);
                    gr_dest = Graphics.FromImage(LED[i]);
                    switch (i)
                    {
                        case 0:
                            gr_dest.DrawImage(Properties.Resources.LED7Segment0Red, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 1:
                            gr_dest.DrawImage(Properties.Resources.LED7Segment1Red, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 2:
                            gr_dest.DrawImage(Properties.Resources.LED7Segment2Red, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 3:
                            gr_dest.DrawImage(Properties.Resources.LED7Segment3Red, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 4:
                            gr_dest.DrawImage(Properties.Resources.LED7Segment4Red, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 5:
                            gr_dest.DrawImage(Properties.Resources.LED7Segment5Red, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 6:
                            gr_dest.DrawImage(Properties.Resources.LED7Segment6Red, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 7:
                            gr_dest.DrawImage(Properties.Resources.LED7Segment7Red, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 8:
                            gr_dest.DrawImage(Properties.Resources.LED7Segment8Red, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 9:
                            gr_dest.DrawImage(Properties.Resources.LED7Segment9Red, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 10:
                            gr_dest.DrawImage(Properties.Resources.LED7SegmentOffRed, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 11:
                            gr_dest.DrawImage(Properties.Resources.LED7Segment_Red, 0, 0, LEDWidth, LEDHeight);
                            break;
                    }
                    i += 1;
                } while (i <= 11);
                DecimalImage = new Bitmap(Convert.ToInt32(Properties.Resources.LED7SegmentDecimalRed.Width * ImageRatio), Convert.ToInt32(Properties.Resources.LED7SegmentDecimalRed.Height * ImageRatio));
                gr_dest = Graphics.FromImage(DecimalImage);
                gr_dest.DrawImage(Properties.Resources.LED7SegmentDecimalRed, 0, 0, Convert.ToInt32(Properties.Resources.LED7SegmentDecimalRed.Width * ImageRatio), Convert.ToInt32(Properties.Resources.LED7SegmentDecimalRed.Height * ImageRatio));
                gr_dest.Dispose();
                if (_backBuffer != null)
                {
                    _backBuffer.Dispose();
                }
                _backBuffer = new Bitmap(Width, Height);
                Invalidate();
            }
        }

        public event EventHandler ValueChanged;
    }


}