

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
    public class HMIWeightIndicator : System.Windows.Forms.Control
    {
        #region Event
        public event EventHandler Button1MouseDown;

        public event EventHandler Button1MouseUp;

        public event EventHandler Button2MouseDown;

        public event EventHandler Button2MouseUp;

        public event EventHandler Button3MouseDown;

        public event EventHandler Button3MouseUp;

        public event EventHandler Button4MouseDown;

        public event EventHandler Button4MouseUp;
        #endregion
        #region Bitmap
        private Bitmap Button1Image;

        private Bitmap Button1UpImage;

        private Bitmap Button1PressedImage;

        private Bitmap Button2Image;

        private Bitmap Button2UpImage;

        private Bitmap Button2PressedImage;

        private Bitmap Button3Image;

        private Bitmap Button3UpImage;

        private Bitmap Button3PressedImage;

        private Bitmap Button4Image;

        private Bitmap Button4UpImage;

        private Bitmap Button4PressedImage;

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


        public HMIWeightIndicator()
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
            StaticImageRatio = (float)((double)Properties.Resources.Indicator_SI580E.Height / (double)Properties.Resources.Indicator_SI580E.Width);
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

            this.StaticImageRatio = (float)((double)Properties.Resources.Indicator_SI580E.Height / (double)Properties.Resources.Indicator_SI580E.Width);
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
                    g.DrawImage(this.Button1Image, Convert.ToInt32((double)this.StaticImage.Width * 0.03), Convert.ToInt32((double)this.StaticImage.Height * 0.6));
                    g.DrawImage(this.Button2Image, Convert.ToInt32((double)this.StaticImage.Width * 0.22), Convert.ToInt32((double)this.StaticImage.Height * 0.6));
                    g.DrawImage(this.Button3Image, Convert.ToInt32((double)this.StaticImage.Width * 0.59), Convert.ToInt32((double)this.StaticImage.Height * 0.6));
                    g.DrawImage(this.Button4Image, Convert.ToInt32((double)this.StaticImage.Width * 0.78), Convert.ToInt32((double)this.StaticImage.Height * 0.6));
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
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if ((double)e.Location.Y > (double)this.StaticImage.Height * 0.7)
            {
                Point location_Renamed = e.Location;
                Point point = e.Location;
                if ((double)location_Renamed.X > (double)this.StaticImage.Width * 0.1 && (double)point.X < (double)this.StaticImage.Width * 0.24)
                {
                    this.Button1Image = this.Button1PressedImage;
                    this.Invalidate();
                    if (Button1MouseDown != null)
                        Button1MouseDown(this, e);
                }
                point = e.Location;
                location_Renamed = e.Location;
                if ((double)point.X > (double)this.StaticImage.Width * 0.31 && (double)location_Renamed.X < (double)this.StaticImage.Width * 0.46)
                {
                    this.Button2Image = this.Button2PressedImage;
                    this.Invalidate();
                    if (Button2MouseDown != null)
                        Button2MouseDown(this, e);
                }
                point = e.Location;
                location_Renamed = e.Location;
                if ((double)point.X > (double)this.StaticImage.Width * 0.54 && (double)location_Renamed.X < (double)this.StaticImage.Width * 0.69)
                {
                    this.Button3Image = this.Button3PressedImage;
                    this.Invalidate();
                    if (Button3MouseDown != null)
                        Button3MouseDown(this, e);
                }
                point = e.Location;
                location_Renamed = e.Location;
                if ((double)point.X > (double)this.StaticImage.Width * 0.76 && (double)location_Renamed.X < (double)this.StaticImage.Width * 0.91)
                {
                    this.Button4Image = this.Button4PressedImage;
                    this.Invalidate();
                    if (Button4MouseDown != null)
                        Button4MouseDown(this, e);
                }
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (this.Button1Image == this.Button1PressedImage)
            {
                if (Button1MouseUp != null)
                    Button1MouseUp(this, e);
            }
            if (this.Button2Image == this.Button2PressedImage)
            {
                if (Button2MouseUp != null)
                    Button2MouseUp(this, e);
            }
            if (this.Button3Image == this.Button3PressedImage)
            {
                if (Button3MouseUp != null)
                    Button3MouseUp(this, e);
            }
            if (this.Button4Image == this.Button4PressedImage)
            {
                if (Button4MouseUp != null)
                    Button4MouseUp(this, e);
            }
            this.Button1Image = this.Button1UpImage;
            this.Button2Image = this.Button2UpImage;
            this.Button3Image = this.Button3UpImage;
            this.Button4Image = this.Button4UpImage;
            this.Invalidate();
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

            float WidthRatio = (float)((double)this.Width / (double)Properties.Resources.Indicator_SI580E.Width);
            float HeightRatio = (float)((double)this.Height / (double)Properties.Resources.Indicator_SI580E.Height);
            if (WidthRatio >= HeightRatio)
            {
                x = (float)Width;
                y = (float)((double)Properties.Resources.Indicator_SI580E.Height / (double)Properties.Resources.Indicator_SI580E.Width * (double)this.Width);
                this.ImageRatio = HeightRatio;
            }
            else
            {
                y = (float)this.Height;
                x = (!(this.Height > 0 && Properties.Resources.Indicator_SI580E.Height > 0) ? 1.0F : (float)((double)Properties.Resources.Indicator_SI580E.Width / (double)Properties.Resources.Indicator_SI580E.Height * (double)this.Height));
                this.ImageRatio = WidthRatio;
            }
            if (this.ImageRatio > 0.0F)
            {
                if (this.StaticImage != null)
                {
                    this.StaticImage.Dispose();
                }
                this.StaticImage = new Bitmap(Convert.ToInt32((float)Properties.Resources.Indicator_SI580E.Width * this.ImageRatio), Convert.ToInt32((float)Properties.Resources.Indicator_SI580E.Height * this.ImageRatio));
                Graphics gr_dest = Graphics.FromImage(this.StaticImage);
                gr_dest.DrawImage(Properties.Resources.Indicator_SI580E, 0, 0, this.StaticImage.Width, this.StaticImage.Height);

                this.Button1UpImage = new Bitmap(Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.ZEROpng.Width * this.ImageRatio))), Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.TempControllerButton1.Height * this.ImageRatio))));
                this.Button2UpImage = new Bitmap(Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.ButoneTARE.Width * this.ImageRatio))), Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.TempControllerButton1.Height * this.ImageRatio))));
                this.Button3UpImage = new Bitmap(Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.PRINT.Width * this.ImageRatio))), Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.TempControllerButton1.Height * this.ImageRatio))));
                this.Button4UpImage = new Bitmap(Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.Fpng.Width * this.ImageRatio))), Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.TempControllerButton1.Height * this.ImageRatio))));
                this.Button1PressedImage = new Bitmap(Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.DwonZERO.Width * this.ImageRatio))), Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.DwonZERO.Height * this.ImageRatio))));
                this.Button2PressedImage = new Bitmap(Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.DwonTARE.Width * this.ImageRatio))), Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.DwonTARE.Height * this.ImageRatio))));
                this.Button3PressedImage = new Bitmap(Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.DwonPRINT.Width * this.ImageRatio))), Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.DwonPRINT.Height * this.ImageRatio))));
                this.Button4PressedImage = new Bitmap(Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.DwonF.Width * this.ImageRatio))), Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.DwonF.Height * this.ImageRatio))));
                gr_dest = Graphics.FromImage(this.Button1UpImage);
                gr_dest.DrawImage(Properties.Resources.ZEROpng, 0.0F, 0.0F, (float)Properties.Resources.ZEROpng.Width * this.ImageRatio, (float)Properties.Resources.ZEROpng.Height * this.ImageRatio);
                gr_dest = Graphics.FromImage(this.Button2UpImage);
                gr_dest.DrawImage(Properties.Resources.ButoneTARE, 0.0F, 0.0F, (float)Properties.Resources.ButoneTARE.Width * this.ImageRatio, (float)Properties.Resources.ButoneTARE.Height * this.ImageRatio);
                gr_dest = Graphics.FromImage(this.Button3UpImage);
                gr_dest.DrawImage(Properties.Resources.PRINT, 0.0F, 0.0F, (float)Properties.Resources.PRINT.Width * this.ImageRatio, (float)Properties.Resources.PRINT.Height * this.ImageRatio);
                gr_dest = Graphics.FromImage(this.Button4UpImage);
                gr_dest.DrawImage(Properties.Resources.Fpng, 0.0F, 0.0F, (float)Properties.Resources.Fpng.Width * this.ImageRatio, (float)Properties.Resources.Fpng.Height * this.ImageRatio);
                gr_dest = Graphics.FromImage(this.Button1PressedImage);
                gr_dest.DrawImage(Properties.Resources.DwonZERO, 0.0F, 0.0F, (float)Properties.Resources.DwonZERO.Width * this.ImageRatio, (float)Properties.Resources.DwonZERO.Height * this.ImageRatio);
                gr_dest = Graphics.FromImage(this.Button2PressedImage);
                gr_dest.DrawImage(Properties.Resources.DwonTARE, 0.0F, 0.0F, (float)Properties.Resources.DwonTARE.Width * this.ImageRatio, (float)Properties.Resources.DwonTARE.Height * this.ImageRatio);
                gr_dest = Graphics.FromImage(this.Button3PressedImage);
                gr_dest.DrawImage(Properties.Resources.DwonPRINT, 0.0F, 0.0F, (float)Properties.Resources.DwonPRINT.Width * this.ImageRatio, (float)Properties.Resources.DwonPRINT.Height * this.ImageRatio);
                gr_dest = Graphics.FromImage(this.Button4PressedImage);
                gr_dest.DrawImage(Properties.Resources.DwonF, 0.0F, 0.0F, (float)Properties.Resources.DwonF.Width * this.ImageRatio, (float)Properties.Resources.DwonF.Height * this.ImageRatio);
                this.Button1Image = this.Button1UpImage;
                this.Button2Image = this.Button2UpImage;
                this.Button3Image = this.Button3UpImage;
                this.Button4Image = this.Button4UpImage;
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