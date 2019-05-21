
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

namespace AdvancedScada.Controls.Inverter
{
    public class HMIInverter : Control
    {
        #region Bitmap


        private Bitmap StaticImage;

        private Bitmap[] LED = new Bitmap[12];

        private Bitmap DecimalImage;
        #endregion
        private float ImageRatio;
        private StringFormat sfCenter = new StringFormat();
        private StringFormat sfCenterBottom = new StringFormat();
        private StringFormat sfRight = new StringFormat();
        private StringFormat sfLeft = new StringFormat();

        private Rectangle TextRectangle;

        private StringFormat sf;

        private SolidBrush TextBrush;

        private float x;

        private float y;

        private float m_Value;



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
                return this.m_DecimalPos;
            }
            set
            {
                this.m_DecimalPos = Math.Max(Math.Min(this.m_NumberOfDigits - 1, value), 0);
                this.RefreshImage();
                this.Invalidate();
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




        private string m_Text = "Text";
        public string LegendText
        {
            get
            {
                return m_Text;
            }
            set
            {
                m_Text = value;
                RefreshImage();
                this.Invalidate();
            }
        }
        #endregion


        private Rectangle[] NumberLocations;
        public HMIInverter()
        {
            this.LED = new Bitmap[12];


            this.NumberLocations = new Rectangle[3];
            this.sf = new StringFormat();

            this.m_NumberOfDigits = 4;
            this.m_DecimalPos = 0;
            this.SegWidth = 25;
            this.m_Value = 9999;
            TextRectangle = new Rectangle();

            m_Resolution = decimal.One;
            this.Size = new Size(260, 225);
            this.StaticImageRatio = (float)((double)Properties.Resources.InverterMain.Height / (double)Properties.Resources.InverterMain.Width);
            if ((base.ForeColor == Color.FromKnownColor(KnownColor.ControlText)) || (ForeColor == Color.FromArgb(0, 0, 0, 0)))
            {
                ForeColor = Color.LightGray;
            }

            sf = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Far
            };

        }


        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            StaticImageRatio = (float)(Properties.Resources.InverterMain.Height / (double)Properties.Resources.InverterMain.Width);

            //* Is the size increasing or decreasing?
            if (LastHeight < this.Height || LastWidth < this.Width)
            {
                if ((float)(this.Height / (double)this.Width) > StaticImageRatio)
                {
                    this.Width = Convert.ToInt32(this.Height / StaticImageRatio);
                }
                else
                {
                    this.Height = Convert.ToInt32(this.Width * StaticImageRatio);
                }
            }
            else
            {
                if ((float)(this.Height / (double)this.Width) > StaticImageRatio)
                {
                    this.Height = Convert.ToInt32(this.Width * StaticImageRatio);
                }
                else
                {
                    this.Width = Convert.ToInt32(this.Height / StaticImageRatio);
                }
            }

            LastWidth = this.Width;
            LastHeight = this.Height;


            RefreshImage();
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
            if (StaticImage == null || _backBuffer == null)
            {
                return;
            }

            Graphics g = Graphics.FromImage(_backBuffer);


            g.DrawImage(StaticImage, 0, 0);


            //****************************************
            //* Draw each of the RED digits
            //****************************************
            int d = 0;
            float WorkValue = m_Value;
            bool DigitsStarted = false;
            if (WorkValue <= (float)(Math.Pow(10, m_NumberOfDigits) - 1) && WorkValue >= (float)((Math.Pow(10, m_NumberOfDigits - 1) - 1) * -1))
            {
                for (var i = 1; i <= m_NumberOfDigits; i++)
                {
                    if (WorkValue < 0)
                    {
                        //* draw in the - sign, then make the work value positive
                        g.DrawImage(LED[11], (200 + SegWidth * (i - 1)) * ImageRatio, 30 * ImageRatio);
                        WorkValue = Math.Abs(WorkValue);
                    }
                    else
                    {

                        d = Convert.ToInt32(Math.Floor(WorkValue / Math.Pow(10, m_NumberOfDigits - i)));

                        //* Determine when to use Blank(all off) or zero
                        if (d > 0 || i == (m_NumberOfDigits) || i > (m_NumberOfDigits - m_DecimalPos))
                        {
                            DigitsStarted = true;
                        }

                        if (DigitsStarted)
                        {
                            g.DrawImage(LED[d], (85 + SegWidth * (i - 1)) * ImageRatio, 30 * ImageRatio);
                        }
                        else
                        {
                            g.DrawImage(LED[10], (85 + SegWidth * (i - 1)) * ImageRatio, 30 * ImageRatio);
                        }

                        WorkValue -= (float)(d * Math.Pow(10, m_NumberOfDigits - i));
                    }
                }
            }
            else
            {
                //* Draw all -'s
                for (var i = 1; i <= m_NumberOfDigits; i++)
                {
                    g.DrawImage(LED[11], (85 + SegWidth * (i - 1)) * ImageRatio, 30 * ImageRatio);
                }
            }


            //* Draw the decimal point
            if (m_DecimalPos > 0)
            {
                g.DrawImage(DecimalImage, ((m_NumberOfDigits - m_DecimalPos) * SegWidth + 50) * ImageRatio, 150 * ImageRatio);
            }
            //Copy the back buffer to the screen
            e.Graphics.DrawImage(_backBuffer, 0, 0);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (_backBuffer != null)
            {
                _backBuffer.Dispose();
                _backBuffer = null;
            }

            base.OnSizeChanged(e);
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, e);
        }


        private void RefreshImage()
        {

            StaticImageRatio = (float)(Properties.Resources.InverterMain.Height / (double)Properties.Resources.InverterMain.Width);

            //************************************************************
            //* Calculate the size ratio of the original t resized image
            //************************************************************
            float WidthRatio = (float)(this.Width / (double)Properties.Resources.InverterMain.Width);
            float HeightRatio = (float)(this.Height / (double)Properties.Resources.InverterMain.Height);

            if (WidthRatio < HeightRatio)
            {
                y = this.Height;
                if (this.Height > 0 && Properties.Resources.InverterMain.Height > 0)
                {
                    x = (float)(Properties.Resources.InverterMain.Width / (double)Properties.Resources.InverterMain.Height * this.Height);
                }
                else
                {
                    x = 1;
                }
                ImageRatio = WidthRatio;
            }
            else
            {
                x = this.Width;
                y = (float)(Properties.Resources.InverterMain.Height / (double)Properties.Resources.InverterMain.Width * this.Width);
                ImageRatio = HeightRatio;
            }

            //****************************************************************
            // Scale the gauge image so it will draw faster in Paint event
            //****************************************************************
            // Make a bitmap for the result.
            if (StaticImage != null)
            {
                StaticImage.Dispose();
            }
            StaticImage = new Bitmap(Convert.ToInt32(Properties.Resources.InverterMain.Width * ImageRatio), Convert.ToInt32(Properties.Resources.InverterMain.Height * ImageRatio));

            // Make a Graphics object for the result Bitmap.
            Graphics gr_dest = Graphics.FromImage(StaticImage);

            gr_dest.ScaleTransform((float)(ImageRatio * 0.75), (float)(ImageRatio * 0.75));

            // Copy the source image into the destination bitmap.
            gr_dest.DrawImage(Properties.Resources.InverterMain, 0, 0);


            //************************************************
            //* Create a text rectangle and align to center
            //************************************************
            TextRectangle.X = 0;
            TextRectangle.Y = 85;
            TextRectangle.Width = Convert.ToInt32(Properties.Resources.InverterMain.Width / 0.75 - 1);
            TextRectangle.Height = 50;

            sfCenterBottom.Alignment = StringAlignment.Center;
            sfCenterBottom.LineAlignment = StringAlignment.Far;

            Font f = new Font("Arial", 32, FontStyle.Regular, GraphicsUnit.Point);
            SolidBrush b = new SolidBrush(Color.FromArgb(245, 100, 100, 100));


            gr_dest.DrawString(m_Text, f, b, TextRectangle, sfCenterBottom);


            //****************************************************************
            // Create Scaled LED images so it will draw faster in Paint event
            //****************************************************************

            int LEDWidth = 0;
            int LEDHeight = 0;
            LEDWidth = Convert.ToInt32(Properties.Resources.LED7Segment8Red.Width * ImageRatio);
            LEDHeight = Convert.ToInt32(Properties.Resources.LED7Segment8Red.Height * ImageRatio);



            for (int i = 0; i <= 11; i++)
            {
                if (LED[i] != null)
                {
                    LED[i].Dispose();
                }
                LED[i] = new Bitmap(LEDWidth, LEDHeight);
                gr_dest = Graphics.FromImage(LED[i]);
                gr_dest.ScaleTransform((float)(ImageRatio * 0.25), (float)(ImageRatio * 0.25));


                switch (i)
                {
                    case 0:
                        gr_dest.DrawImage(Properties.Resources.LED7Segment0Red, 0, 0);
                        break;
                    case 1:
                        gr_dest.DrawImage(Properties.Resources.LED7Segment1Red, 0, 0);
                        break;
                    case 2:
                        gr_dest.DrawImage(Properties.Resources.LED7Segment2Red, 0, 0);
                        break;
                    case 3:
                        gr_dest.DrawImage(Properties.Resources.LED7Segment3Red, 0, 0);
                        break;
                    case 4:
                        gr_dest.DrawImage(Properties.Resources.LED7Segment4Red, 0, 0);
                        break;
                    case 5:
                        gr_dest.DrawImage(Properties.Resources.LED7Segment5Red, 0, 0);
                        break;
                    case 6:
                        gr_dest.DrawImage(Properties.Resources.LED7Segment6Red, 0, 0);
                        break;
                    case 7:
                        gr_dest.DrawImage(Properties.Resources.LED7Segment7Red, 0, 0);
                        break;
                    case 8:
                        gr_dest.DrawImage(Properties.Resources.LED7Segment8Red, 0, 0);
                        break;
                    case 9:
                        gr_dest.DrawImage(Properties.Resources.LED7Segment9Red, 0, 0);
                        break;
                    case 10:
                        gr_dest.DrawImage(Properties.Resources.LED7SegmentOffRed, 0, 0);
                        break;
                    case 11:
                        gr_dest.DrawImage(Properties.Resources.LED7Segment_Red, 0, 0);
                        break;
                }


                //* Perform some cleanup
                gr_dest.Dispose();

            }

            //* Draw the decimal point to the bitmap
            DecimalImage = new Bitmap(Convert.ToInt32(Properties.Resources.LED7SegmentDecimalRed.Width * ImageRatio), Convert.ToInt32(Properties.Resources.LED7SegmentDecimalRed.Height * ImageRatio));
            gr_dest = Graphics.FromImage(DecimalImage);
            //gr_dest.Transform = m
            gr_dest.DrawImage(Properties.Resources.LED7SegmentDecimalRed, 0, 0);



            //* Create a new resized backbuffer for double buffering
            if (_backBuffer != null)
            {
                _backBuffer.Dispose();
            }
            _backBuffer = new Bitmap(this.Width, this.Height);

        }


        public event EventHandler ValueChanged;
    }


}