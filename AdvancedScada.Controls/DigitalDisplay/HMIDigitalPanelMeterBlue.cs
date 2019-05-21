

using AdvancedScada;
using AdvancedScada.Controls;
using AdvancedScada.Controls.ClassBase;
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

namespace AdvancedScada.Controls.DigitalDisplay
{
    public class HMIDigitalPanelMeterBlue : AnalogMeterBase
    {
        private Bitmap[] LED;

        private Bitmap DecimalImage;

        private decimal m_Resolution;

        private int m_DecimalPos;

        private ColorSelect m_BackLightColor;

        private int LastWidth;

        private int LastHeight;
        #region Property
        public ColorSelect BackLightColor
        {
            get
            {
                return this.m_BackLightColor;
            }
            set
            {
                if (this.m_BackLightColor != value)
                {
                    this.m_BackLightColor = value;
                    this.CreateStaticImage();
                }
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
                this.m_DecimalPos = Math.Max(Math.Min(99, value), 0);
                this.Invalidate();
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
                    if (this.StaticImage != null)
                    {
                        this.Invalidate();
                    }
                }
            }
        }
        #endregion
        public HMIDigitalPanelMeterBlue()
        {
            this.LED = new Bitmap[12];
            this.m_Resolution = decimal.One;
            this.m_DecimalPos = 0;
            this.m_BackLightColor = ColorSelect.Blue;
            if ((base.ForeColor == Color.LightGray) || (this.ForeColor == Color.FromArgb(0, 0, 0, 0)))
            {
                this.ForeColor = Color.Black;
            }
            this.Maximum = 0;
            this.Minimum = 0;
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    if (this.DecimalImage != null)
                    {
                        this.DecimalImage.Dispose();
                    }
                    int length = this.LED.Length - 1;
                    for (int i = 0; i <= length; i++)
                    {
                        if (this.LED[i] != null)
                        {
                            this.LED[i].Dispose();
                        }
                    }
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            bool flag = false;
            if (!(this.StaticImage == null || this.BackBuffer == null))
            {
                using (Graphics graphic = Graphics.FromImage(this.BackBuffer))
                {
                    graphic.DrawImage(this.StaticImage, 0, 0);
                    if ((base.Text == null || string.Compare(base.Text, string.Empty) == 0) ? false : true)
                    {
                        if (this.TextBrush == null)
                        {
                            this.TextBrush = new SolidBrush(base.ForeColor);
                        }
                        else if (this.TextBrush.Color != base.ForeColor)
                        {
                            this.TextBrush.Color = base.ForeColor;
                        }
                        graphic.DrawString(base.Text, base.Font, this.TextBrush, this.TextRectangle, this.sf);
                    }
                    decimal one = decimal.Divide(decimal.One, this.m_Resolution);
                    if (decimal.Compare(one, decimal.Zero) == 0)
                    {
                        one = decimal.One;
                    }
                    long num = Convert.ToInt64(decimal.Divide(new decimal(Convert.ToInt64(Math.Truncate(Math.Round(this.m_Value * Convert.ToDouble(one) * this.m_ValueScaleFactor)))), one));
                    int num1 = Convert.ToInt32(0.24 * (double)this.Height);
                    int num2 = Convert.ToInt32((double)(this.LED[0].Width) * 1.15);
                    float width_Renamed = (float)((double)Properties.Resources.BlueBackgroundFrame.Width * 1 / (double)Properties.Resources.BlueBackgroundFrame.Height / ((double)this.StaticImage.Width * 1 / (double)this.StaticImage.Height));
                    int num3 = Convert.ToInt32((double)this.Width * 0.8 / ((double)(this.LED[0].Width) * 1.15));
                    if (!((double)num <= Math.Pow(10, (double)num3) - 1 && (double)num >= (Math.Pow(10, (double)(num3 - 1)) - 1) * -1))
                    {
                        int num4 = num3;
                        for (int i = 1; i <= num4; i++)
                        {
                            graphic.DrawImage(this.LED[11], Convert.ToInt32((double)this.StaticImage.Width * 0.1) + num2 * (i - 1), num1);
                        }
                    }
                    else
                    {
                        int num5 = num3;
                        for (int j = 1; j <= num5; j++)
                        {
                            if (num >= (long)0)
                            {
                                int num6 = Convert.ToInt32(Math.Floor((double)num / Math.Pow(10, (double)(num3 - j))));
                                if (num6 > 0 || j == num3 || j > num3 - this.m_DecimalPos)
                                {
                                    flag = true;
                                }
                                if (flag)
                                {
                                    graphic.DrawImage(this.LED[num6], Convert.ToInt32((double)this.StaticImage.Width * 0.1) + num2 * (j - 1), num1);
                                }
                                num = Convert.ToInt64(Math.Truncate(Math.Round((double)num - (double)num6 * Math.Pow(10, (double)(num3 - j)))));
                            }
                            else
                            {
                                graphic.DrawImage(this.LED[11], Convert.ToInt32((double)this.StaticImage.Width * 0.1) + num2 * (j - 1), num1);
                                num = Math.Abs(num);
                            }
                        }
                    }
                    if (this.m_DecimalPos > 0)
                    {
                        graphic.DrawImage(this.DecimalImage, ((num3 - this.m_DecimalPos) * num2) + Convert.ToInt32((double)this.StaticImage.Width * 0.072), Convert.ToInt32((double)this.Height * 0.77));
                    }
                    e.Graphics.DrawImage(this.BackBuffer, 0, 0);
                }
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (this.Height != this.LastHeight | this.Width != this.LastWidth)
            {
                this.LastWidth = this.Width;
                this.LastHeight = this.Height;
                this.CreateStaticImage();
            }
            base.OnSizeChanged(e);
        }

        protected override void OnValueChanged(EventArgs e)
        {
            base.OnValueChanged(e);
            this.Invalidate();
        }

        protected override void CreateStaticImage()
        {
            if (!(this.Width <= 0 || this.Height <= 0))
            {
                if (this.StaticImage != null)
                {
                    this.StaticImage.Dispose();
                }
                this.StaticImage = new Bitmap(this.Width, this.Height);
                Graphics graphic = Graphics.FromImage(this.StaticImage);
                if (this.m_BackLightColor == ColorSelect.Green)
                {
                    graphic.DrawImage(Properties.Resources.GreenBackgroundFrame, 0, 0, this.StaticImage.Width, this.StaticImage.Height);
                }
                else if (this.m_BackLightColor != ColorSelect.Yellow)
                {
                    graphic.DrawImage(Properties.Resources.BlueBackgroundFrame, 0, 0, this.StaticImage.Width, this.StaticImage.Height);
                }
                else
                {
                    graphic.DrawImage(Properties.Resources.YellowBackgroundFrame, 0, 0, this.StaticImage.Width, this.StaticImage.Height);
                }
                this.TextRectangle.X = 0;
                this.TextRectangle.Y = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height * 0.02)));
                this.TextRectangle.Width = this.Width;
                this.TextRectangle.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height * 0.17)));
                if (this.TextBrush == null)
                {
                    this.TextBrush = new SolidBrush(base.ForeColor);
                }
                this.ImageRatio = (double)this.Height / (double)Properties.Resources.BlueBackgroundFrame.Height;
                int LEDWidth = Convert.ToInt32((double)Properties.Resources.SevenSegment0.Width * this.ImageRatio);
                int LEDHeight = Convert.ToInt32((double)Properties.Resources.SevenSegment0.Height * this.ImageRatio);
                int i = 0;
                do
                {
                    if (this.LED[i] != null)
                    {
                        this.LED[i].Dispose();
                    }
                    this.LED[i] = new Bitmap(LEDWidth, LEDHeight);
                    graphic = Graphics.FromImage(this.LED[i]);
                    switch (i)
                    {
                        case 0:
                            graphic.DrawImage(Properties.Resources.SevenSegment0, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 1:
                            graphic.DrawImage(Properties.Resources.SevenSegment1, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 2:
                            graphic.DrawImage(Properties.Resources.SevenSegment2, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 3:
                            graphic.DrawImage(Properties.Resources.SevenSegment3, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 4:
                            graphic.DrawImage(Properties.Resources.SevenSegment4, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 5:
                            graphic.DrawImage(Properties.Resources.SevenSegment5, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 6:
                            graphic.DrawImage(Properties.Resources.SevenSegment6, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 7:
                            graphic.DrawImage(Properties.Resources.SevenSegment7, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 8:
                            graphic.DrawImage(Properties.Resources.SevenSegment8, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 9:
                            graphic.DrawImage(Properties.Resources.SevenSegment9, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 10:
                            graphic.DrawImage(Properties.Resources.LED7SegmentOffRed, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 11:
                            graphic.DrawImage(Properties.Resources.SevenSegment_, 0, 0, LEDWidth, LEDHeight);
                            break;
                    }
                    i += 1;
                } while (i <= 11);
                this.DecimalImage = new Bitmap(Convert.ToInt32((double)Properties.Resources.BlueSevenSegmentDot.Width * this.ImageRatio), Convert.ToInt32((double)Properties.Resources.BlueSevenSegmentDot.Height * this.ImageRatio));
                graphic = Graphics.FromImage(this.DecimalImage);
                graphic.DrawImage(Properties.Resources.BlueSevenSegmentDot, 0, 0, this.DecimalImage.Width, this.DecimalImage.Height);
                graphic.Dispose();
                if (this.BackBuffer != null)
                {
                    this.BackBuffer.Dispose();
                }
                this.BackBuffer = new Bitmap(this.Width, this.Height);
                this.Invalidate();
            }
        }

        public enum ColorSelect
        {
            Blue,
            Yellow,
            Green
        }
    }


}