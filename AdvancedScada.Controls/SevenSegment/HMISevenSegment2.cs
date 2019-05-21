
using AdvancedScada;
using AdvancedScada.Controls;
using AdvancedScada.Controls.DialogEditor;
using AdvancedScada.Controls.Keyboard;
using AdvancedScada.Controls.Licenses;
using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Client;
using AdvancedScada.Monitor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml.Linq;

namespace AdvancedScada.Controls.SevenSegment
{
    [Designer(typeof(SevenSegmentDesigner))]
    public class HMISevenSegment2 : System.Windows.Forms.Control
    {
        public event EventHandler ValueChanged;
        #region متغيرات
        private Point[] Seg0;

        private Point[] Seg1;

        private Point[] Seg2;

        private Point[] Seg3;

        private Point[] Seg4;

        private Point[] Seg5;

        private Point[] Seg6;

        private Bitmap[] LED;

        private Bitmap[] RedLED;

        private Bitmap[] GreenLED;

        private Bitmap StaticImage;

        private Bitmap RedDecimalImage;

        private Bitmap GreenDecimalImage;

        private float ImageRatio;

        private Color m_ForeColorInLimits;

        private Color m_ForeColorOverHighLimit;

        private Color m_ForeColorUnderLowLimit;

        private double m_ForecolorHighLimitValue;

        private double m_ForecolorLowLimitValue;

        private double m_Value;

        private decimal m_ResolutionOfLastDigit;

        private int m_NumberOfDigits;

        private int m_DecimalPosition;

        private bool m_ShowOffSegments;

        private int SegWidth;

        private Bitmap _backBuffer;

        private int LastWidth;

        private int LastHeight;

        private float StaticImageRatio;
        #endregion
        #region خصائص
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams exStyle = base.CreateParams;
                exStyle.ExStyle |= 32;
                return exStyle;
            }
        }
        [Category("Numeric Display")]
        public int DecimalPosition
        {
            get
            {
                return m_DecimalPosition;
            }
            set
            {
                if (value != m_DecimalPosition)
                {
                    m_DecimalPosition = Math.Max(Math.Min(m_NumberOfDigits - 1, value), 0);
                    RefreshImage();
                }
            }
        }

        [Browsable(false)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }

        public double ForecolorHighLimitValue
        {
            get
            {

                return m_ForecolorHighLimitValue;
            }
            set
            {
                if (m_ForecolorHighLimitValue != value)
                {
                    m_ForecolorHighLimitValue = value;
                    base.Invalidate();
                }
            }
        }

        public Color ForeColorInLimits
        {
            get
            {

                return m_ForeColorInLimits;
            }
            set
            {
                if (m_ForeColorInLimits != value)
                {
                    m_ForeColorInLimits = value;
                    RefreshImage();
                }
            }
        }

        public double ForecolorLowLimitValue
        {
            get
            {

                return m_ForecolorLowLimitValue;
            }
            set
            {
                if (m_ForecolorLowLimitValue != value)
                {
                    m_ForecolorLowLimitValue = value;
                    base.Invalidate();
                }
            }
        }

        public Color ForeColorOverHighLimit
        {
            get
            {

                return m_ForeColorOverHighLimit;
            }
            set
            {
                if (m_ForeColorOverHighLimit != value)
                {
                    m_ForeColorOverHighLimit = value;
                    RefreshImage();
                }
            }
        }

        public Color ForeColorUnderLowLimit
        {
            get
            {

                return m_ForeColorUnderLowLimit;
            }
            set
            {
                if (m_ForeColorUnderLowLimit != value)
                {
                    m_ForeColorUnderLowLimit = value;
                    RefreshImage();
                }
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
                    m_NumberOfDigits = Math.Max(Math.Min(50, value), 1);
                    AdjustSize();
                    RefreshImage();
                }
            }
        }

        [Category("Numeric Display")]
        public decimal ResolutionOfLastDigit
        {
            get
            {
                return m_ResolutionOfLastDigit;
            }
            set
            {
                if (decimal.Compare(value, decimal.Zero) != 0)
                {
                    m_ResolutionOfLastDigit = value;
                    base.Invalidate();
                }
            }
        }

        public bool ShowOffSegments
        {
            get
            {

                return m_ShowOffSegments;
            }
            set
            {
                if (m_ShowOffSegments != value)
                {
                    m_ShowOffSegments = value;
                    RefreshImage();
                }
            }
        }

        [Category("Numeric Display")]
        public double Value
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
                    base.Invalidate();
                    OnValueChanged(EventArgs.Empty);
                }
            }
        }
        #endregion
        #region مشيدات
        public HMISevenSegment2() : base()
        {
            Seg0 = new Point[12];
            Seg1 = new Point[12];
            Seg2 = new Point[12];
            Seg3 = new Point[12];
            Seg4 = new Point[7];
            Seg5 = new Point[17];
            Seg6 = new Point[17];
            LED = new Bitmap[12];
            RedLED = new Bitmap[12];
            GreenLED = new Bitmap[12];
            m_ForeColorInLimits = Color.White;
            m_ForeColorOverHighLimit = Color.Red;
            m_ForeColorUnderLowLimit = Color.Yellow;
            m_ForecolorHighLimitValue = 999999;
            m_ForecolorLowLimitValue = -999999;
            m_ResolutionOfLastDigit = decimal.One;
            m_NumberOfDigits = 5;
            m_DecimalPosition = 0;
            m_ShowOffSegments = true;
            SegWidth = 340;
            StaticImageRatio = (float)(486 / (340 * m_NumberOfDigits * 1.1));
            base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            Initialize();
            base.BackColor = Color.Transparent;
            AdjustSize();
        }
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    StaticImage.Dispose();
                    int length = RedLED.Length - 1;
                    int i = 0;
                    do
                    {
                        if (RedLED[i] != null)
                        {
                            RedLED[i].Dispose();
                        }
                        if (GreenLED[i] != null)
                        {
                            GreenLED[i].Dispose();
                        }
                        i = i + 1;
                    } while (i <= length);
                    if (GreenDecimalImage != null)
                    {
                        GreenDecimalImage.Dispose();
                    }
                    _backBuffer.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }
        #endregion
        #region طرق

        private void _Resize(object sender, EventArgs e)
        {
            if (base.Height != LastHeight || base.Width != LastWidth)
            {
                AdjustSize();
                LastWidth = base.Width;
                LastHeight = base.Height;
                RefreshImage();
            }
        }
        private void AdjustSize()
        {
            StaticImageRatio = (float)(486 / (340 * m_NumberOfDigits * 1.1));
            if (LastHeight < base.Height || LastWidth < base.Width)
            {
                if ((float)(base.Height / (double)base.Width) <= StaticImageRatio)
                {
                    base.Height = Convert.ToInt32(Math.Round((float)base.Width * StaticImageRatio));
                }
                else
                {
                    base.Width = Convert.ToInt32(Math.Round((float)base.Height / StaticImageRatio));
                }
            }
            else if ((float)(base.Height / (double)base.Width) <= StaticImageRatio)
            {
                base.Width = Convert.ToInt32(Math.Round((float)base.Height / StaticImageRatio));
            }
            else
            {
                base.Height = Convert.ToInt32(Math.Round((float)base.Width * StaticImageRatio));
            }
        }
        private void RefreshImage()
        {
            StaticImageRatio = (float)(486 / (340 * m_NumberOfDigits * 1.1));
            float WidthRatio = (float)((double)base.Width / ((double)(340 * m_NumberOfDigits) * 1.1));
            float HeightRatio = (float)((double)base.Height / 486);
            if (WidthRatio >= HeightRatio)
            {
                ImageRatio = HeightRatio;
            }
            else
            {
                ImageRatio = WidthRatio;
            }
            if (ImageRatio > 0.0F)
            {
                int LastWidth = Convert.ToInt32(340.0F * ImageRatio);
                int LastHeight = Convert.ToInt32(486.0F * ImageRatio);
                int i = 0;
                for (i = 0; i <= 11; i++)
                {
                    if (LED[i] != null)
                    {
                        LED[i].Dispose();
                    }
                    LED[i] = new Bitmap(LastWidth, LastHeight);
                    using (Graphics gr_dest = Graphics.FromImage(LED[i]))
                    {
                        gr_dest.ScaleTransform((float)((double)LastWidth / 700), (float)((double)LastWidth / 700));
                        SetNumber(gr_dest, i, m_ForeColorOverHighLimit, m_ShowOffSegments);
                    }
                }

                int y = 0;
                for (y = 0; y <= 11; y++)
                {
                    if (RedLED[y] != null)
                    {
                        RedLED[y].Dispose();
                    }
                    RedLED[y] = new Bitmap(LastWidth, LastHeight);
                    using (Graphics gr_dest1 = Graphics.FromImage(RedLED[y]))
                    {
                        gr_dest1.ScaleTransform((float)((double)LastWidth / 700), (float)((double)LastWidth / 700));
                        SetNumber(gr_dest1, y, m_ForeColorInLimits, m_ShowOffSegments);
                    }
                }

                int x = 0;
                for (x = 0; x <= 11; x++)
                {
                    if (GreenLED[x] != null)
                    {
                        GreenLED[x].Dispose();
                    }
                    GreenLED[x] = new Bitmap(LastWidth, LastHeight);
                    using (Graphics gr_dest2 = Graphics.FromImage(GreenLED[x]))
                    {
                        gr_dest2.ScaleTransform((float)((double)LastWidth / 700), (float)((double)LastWidth / 700));
                        SetNumber(gr_dest2, x, ForeColorUnderLowLimit, m_ShowOffSegments);
                    }
                }

                StaticImage = new Bitmap(Convert.ToInt32(75.0F * ImageRatio), Convert.ToInt32(75.0F * ImageRatio));
                Point[] point =
                {
                        new Point(Convert.ToInt32(Math.Round((double)StaticImage.Width / 2)), 0),
                        new Point(StaticImage.Width, Convert.ToInt32(Math.Round((double)StaticImage.Height / 2))),
                        new Point(Convert.ToInt32(Math.Round((double)StaticImage.Width / 2)), StaticImage.Height),
                        new Point(0, Convert.ToInt32(Math.Round((double)StaticImage.Height / 2))),
                        new Point(Convert.ToInt32(Math.Round((double)StaticImage.Width / 2)), 0)
                    };
                using (Graphics gr_dest3 = Graphics.FromImage(StaticImage))
                {
                    using (SolidBrush solidBrush = new SolidBrush(m_ForeColorOverHighLimit))
                    {
                        gr_dest3.FillPolygon(solidBrush, point);
                    }
                }

                GreenDecimalImage = new Bitmap(Convert.ToInt32(75.0F * ImageRatio), Convert.ToInt32(75.0F * ImageRatio));
                using (Graphics gr_dest4 = Graphics.FromImage(GreenDecimalImage))
                {
                    using (SolidBrush solidBrush1 = new SolidBrush(m_ForeColorUnderLowLimit))
                    {
                        gr_dest4.FillPolygon(solidBrush1, point);
                    }
                }

                RedDecimalImage = new Bitmap(Convert.ToInt32(75.0F * ImageRatio), Convert.ToInt32(75.0F * ImageRatio));
                using (Graphics gr_dest5 = Graphics.FromImage(RedDecimalImage))
                {
                    using (SolidBrush solidBrush2 = new SolidBrush(m_ForeColorInLimits))
                    {
                        gr_dest5.FillPolygon(solidBrush2, point);
                    }
                }

                if (_backBuffer != null)
                {
                    _backBuffer.Dispose();
                }
                _backBuffer = new Bitmap(base.Width, base.Height);
                base.Invalidate();
            }
        }
        private void Initialize()
        {
            Seg0[0] = new Point(75, 110);
            Seg0[1] = new Point(47, 415);
            Seg0[2] = new Point(98, 471);
            Seg0[3] = new Point(157, 417);
            Seg0[4] = new Point(182, 125);
            Seg0[5] = new Point(88, 21);
            Seg0[6] = new Point(88, 21);
            Seg0[7] = new Point(85, 27);
            Seg0[8] = new Point(82, 32);
            Seg0[9] = new Point(80, 38);
            Seg0[10] = new Point(79, 44);
            Seg0[11] = new Point(74, 110);
            Seg1[0] = new Point(580, 471);
            Seg1[1] = new Point(641, 415);
            Seg1[2] = new Point(668, 110);
            Seg1[3] = new Point(673, 44);
            Seg1[4] = new Point(673, 44);
            Seg1[5] = new Point(674, 38);
            Seg1[6] = new Point(673, 31);
            Seg1[7] = new Point(671, 26);
            Seg1[8] = new Point(669, 20);
            Seg1[9] = new Point(557, 123);
            Seg1[10] = new Point(531, 417);
            Seg1[11] = new Point(580, 471);
            Seg2[0] = new Point(96, 499);
            Seg2[1] = new Point(35, 555);
            Seg2[2] = new Point(8, 858);
            Seg2[3] = new Point(3, 924);
            Seg2[4] = new Point(3, 924);
            Seg2[5] = new Point(2, 930);
            Seg2[6] = new Point(3, 937);
            Seg2[7] = new Point(5, 942);
            Seg2[8] = new Point(7, 948);
            Seg2[9] = new Point(119, 845);
            Seg2[10] = new Point(145, 553);
            Seg2[11] = new Point(96, 499);
            Seg3[0] = new Point(602, 858);
            Seg3[1] = new Point(629, 555);
            Seg3[2] = new Point(578, 499);
            Seg3[3] = new Point(519, 553);
            Seg3[4] = new Point(493, 847);
            Seg3[5] = new Point(586, 949);
            Seg3[6] = new Point(586, 949);
            Seg3[7] = new Point(590, 943);
            Seg3[8] = new Point(593, 937);
            Seg3[9] = new Point(595, 931);
            Seg3[10] = new Point(597, 924);
            Seg3[11] = new Point(602, 858);
            Seg4[0] = new Point(515, 430);
            Seg4[1] = new Point(171, 430);
            Seg4[2] = new Point(111, 485);
            Seg4[3] = new Point(161, 540);
            Seg4[4] = new Point(505, 540);
            Seg4[5] = new Point(565, 485);
            Seg4[6] = new Point(515, 430);
            Seg5[0] = new Point(475, 858);
            Seg5[1] = new Point(133, 858);
            Seg5[2] = new Point(21, 962);
            Seg5[3] = new Point(21, 962);
            Seg5[4] = new Point(26, 965);
            Seg5[5] = new Point(31, 966);
            Seg5[6] = new Point(37, 968);
            Seg5[7] = new Point(43, 968);
            Seg5[8] = new Point(109, 968);
            Seg5[9] = new Point(483, 968);
            Seg5[10] = new Point(549, 968);
            Seg5[11] = new Point(549, 968);
            Seg5[12] = new Point(554, 968);
            Seg5[13] = new Point(560, 967);
            Seg5[14] = new Point(565, 965);
            Seg5[15] = new Point(570, 962);
            Seg5[16] = new Point(475, 858);
            Seg6[0] = new Point(192, 110);
            Seg6[1] = new Point(543, 110);
            Seg6[2] = new Point(655, 6);
            Seg6[3] = new Point(655, 6);
            Seg6[4] = new Point(650, 4);
            Seg6[5] = new Point(645, 2);
            Seg6[6] = new Point(639, 0);
            Seg6[7] = new Point(633, 0);
            Seg6[8] = new Point(567, 0);
            Seg6[9] = new Point(193, 0);
            Seg6[10] = new Point(127, 0);
            Seg6[11] = new Point(127, 0);
            Seg6[12] = new Point(121, 0);
            Seg6[13] = new Point(115, 2);
            Seg6[14] = new Point(109, 4);
            Seg6[15] = new Point(103, 7);
            Seg6[16] = new Point(197, 110);
        }
        internal static Point[] SetALL(int Number)
        {
            Point[] PrSetALL = null;
            switch (Number)
            {
                case 0:
                    PrSetALL = new Point[]
                    {
                            new Point(75, 110),
                            new Point(47, 415),
                            new Point(98, 471),
                            new Point(157, 417),
                            new Point(182, 125),
                            new Point(88, 21),
                            new Point(88, 21),
                            new Point(85, 27),
                            new Point(82, 32),
                            new Point(80, 38),
                            new Point(79, 44),
                            new Point(74, 110)
                    };
                    return PrSetALL;
                    break;
                case 1:
                    PrSetALL = new Point[]
                    {
                            new Point(580, 471),
                            new Point(641, 415),
                            new Point(668, 110),
                            new Point(673, 44),
                            new Point(673, 44),
                            new Point(674, 38),
                            new Point(673, 31),
                            new Point(671, 26),
                            new Point(669, 20),
                            new Point(557, 123),
                            new Point(531, 417),
                            new Point(580, 471)
                    };
                    return PrSetALL;
                    break;
                case 2:
                    PrSetALL = new Point[]
                    {
                            new Point(96, 499),
                            new Point(35, 555),
                            new Point(8, 858),
                            new Point(3, 924),
                            new Point(3, 924),
                            new Point(2, 930),
                            new Point(3, 937),
                            new Point(5, 942),
                            new Point(7, 948),
                            new Point(119, 845),
                            new Point(145, 553),
                            new Point(96, 499)
                    };
                    return PrSetALL;
                    break;
                case 3:
                    PrSetALL = new Point[]
                    {
                            new Point(602, 858),
                            new Point(629, 555),
                            new Point(578, 499),
                            new Point(519, 553),
                            new Point(493, 847),
                            new Point(586, 949),
                            new Point(586, 949),
                            new Point(590, 943),
                            new Point(593, 937),
                            new Point(595, 931),
                            new Point(597, 924),
                            new Point(602, 858)
                    };
                    return PrSetALL;
                    break;
                case 4:
                    PrSetALL = new Point[]
                    {
                            new Point(515, 430),
                            new Point(171, 430),
                            new Point(111, 485),
                            new Point(161, 540),
                            new Point(505, 540),
                            new Point(565, 485),
                            new Point(515, 430)
                    };
                    return PrSetALL;
                    break;
                case 5:
                    PrSetALL = new Point[]
                    {
                            new Point(475, 858),
                            new Point(133, 858),
                            new Point(21, 962),
                            new Point(21, 962),
                            new Point(26, 965),
                            new Point(31, 966),
                            new Point(37, 968),
                            new Point(43, 968),
                            new Point(109, 968),
                            new Point(483, 968),
                            new Point(549, 968),
                            new Point(549, 968),
                            new Point(554, 968),
                            new Point(560, 967),
                            new Point(565, 965),
                            new Point(570, 962),
                            new Point(475, 858)
                    };
                    return PrSetALL;
                    break;
                case 6:

                    PrSetALL = new Point[]
                    {
                            new Point(192, 110),
                            new Point(543, 110),
                            new Point(655, 6),
                            new Point(655, 6),
                            new Point(650, 4),
                            new Point(645, 2),
                            new Point(639, 0),
                            new Point(633, 0),
                            new Point(567, 0),
                            new Point(193, 0),
                            new Point(127, 0),
                            new Point(127, 0),
                            new Point(121, 0),
                            new Point(115, 2),
                            new Point(109, 4),
                            new Point(103, 7),
                            new Point(197, 110)
                    };
                    return PrSetALL;
                    break;
            }


            return null;
        }
        internal static void SetNumber(Graphics G0, int m_intCount, Color m_color, bool m_bool)
        {
            using (SolidBrush solidBrush = new SolidBrush(m_color))
            {
                using (SolidBrush solidBrush1 = new SolidBrush(Color.FromArgb(40, m_color.R, m_color.G, m_color.B)))
                {
                    G0.CompositingQuality = CompositingQuality.HighQuality;
                    G0.SmoothingMode = SmoothingMode.AntiAlias;
                    if (m_intCount == 0 || m_intCount == 4 || m_intCount == 5 || m_intCount == 6 || m_intCount == 8 || m_intCount == 9)
                    {
                        G0.FillPolygon(solidBrush, SetALL(0));
                    }
                    else if (m_bool)
                    {
                        G0.FillPolygon(solidBrush1, SetALL(0));
                    }
                    if (!(m_intCount == 5 || m_intCount == 6 || m_intCount == 10 || m_intCount == 11))
                    {
                        G0.FillPolygon(solidBrush, SetALL(1));
                    }
                    else if (m_bool)
                    {
                        G0.FillPolygon(solidBrush1, SetALL(1));
                    }
                    if (m_intCount == 0 || m_intCount == 2 || m_intCount == 6 || m_intCount == 8)
                    {
                        G0.FillPolygon(solidBrush, SetALL(2));
                    }
                    else if (m_bool)
                    {
                        G0.FillPolygon(solidBrush1, SetALL(2));
                    }
                    if (!(m_intCount == 2 || m_intCount == 10 || m_intCount == 11))
                    {
                        G0.FillPolygon(solidBrush, SetALL(3));
                    }
                    else if (m_bool)
                    {
                        G0.FillPolygon(solidBrush1, SetALL(3));
                    }
                    if (!(m_intCount == 0 || m_intCount == 1 || m_intCount == 7 || m_intCount == 10))
                    {
                        G0.FillPolygon(solidBrush, SetALL(4));
                    }
                    else if (m_bool)
                    {
                        G0.FillPolygon(solidBrush1, SetALL(4));
                    }
                    if (!(m_intCount == 1 || m_intCount == 4 || m_intCount == 7 || m_intCount == 9 || m_intCount == 10 || m_intCount == 11))
                    {
                        G0.FillPolygon(solidBrush, SetALL(5));
                    }
                    else if (m_bool)
                    {
                        G0.FillPolygon(solidBrush1, SetALL(5));
                    }
                    if (!(m_intCount == 1 || m_intCount == 4 || m_intCount == 10 || m_intCount == 11))
                    {
                        G0.FillPolygon(solidBrush, SetALL(6));
                    }
                    else if (m_bool)
                    {
                        G0.FillPolygon(solidBrush1, SetALL(6));
                    }
                }
            }
        }
        #endregion
        #region اعادة تعريف الاحداث

        protected override void OnPaint(PaintEventArgs e)
        {
            bool DigitsStarted = false;
            if (_backBuffer != null)
            {
                using (Graphics g = Graphics.FromImage(_backBuffer))
                {
                    g.Clear(BackColor);
                    if (BackgroundImage != null)
                    {
                        if (BackgroundImageLayout != ImageLayout.Stretch)
                        {
                            g.DrawImage(BackgroundImage, 0, 0);
                        }
                        else
                        {
                            g.DrawImage(BackgroundImage, 0, 0, base.Width, base.Height);
                        }
                    }
                    double one = m_Value * Math.Pow(10, m_DecimalPosition);
                    if (decimal.Compare(m_ResolutionOfLastDigit, decimal.Zero) != 0)
                    {
                        one = Convert.ToDouble(decimal.Multiply(new decimal(Convert.ToInt32(Math.Round(one / Convert.ToDouble(m_ResolutionOfLastDigit)))), m_ResolutionOfLastDigit));
                    }
                    bool m_DecimalPos = m_Value >= m_ForecolorLowLimitValue;
                    bool m_ForecolorHigh = m_Value >= m_ForecolorHighLimitValue;
                    if (!(one < Math.Pow(10, m_NumberOfDigits) && one > -Math.Pow(10, m_NumberOfDigits - 1)))
                    {
                        int int0 = m_NumberOfDigits;
                        for (int i = 1; i <= int0; i++)
                        {
                            g.DrawImage(GreenLED[11], Convert.ToInt32(Math.Round((float)(SegWidth * (i - 1)) * ImageRatio * 1.1)), 0);
                        }

                    }
                    else
                    {
                        int mNumberOfDigits = m_NumberOfDigits;
                        int i = 1;
                        do
                        {
                            if (one >= 0)
                            {
                                int j = Convert.ToInt32(Math.Floor(one / Math.Pow(10, m_NumberOfDigits - i)));
                                if (j > 0 || i == m_NumberOfDigits || i > m_NumberOfDigits - m_DecimalPosition)
                                {
                                    DigitsStarted = true;
                                }
                                if (DigitsStarted)
                                {
                                    if (m_ForecolorHigh)
                                    {
                                        g.DrawImage(LED[j], Convert.ToInt32((double)(SegWidth * (i - 1)) * 1.1) * ImageRatio, 0.0F);
                                    }
                                    else if (!m_DecimalPos)
                                    {
                                        g.DrawImage(GreenLED[j], Convert.ToInt32((double)(SegWidth * (i - 1)) * 1.1) * ImageRatio, 0.0F);
                                    }
                                    else
                                    {
                                        g.DrawImage(RedLED[j], Convert.ToInt32((double)(SegWidth * (i - 1)) * 1.1) * ImageRatio, 0.0F);
                                    }
                                }
                                else if (m_ForecolorHigh)
                                {
                                    g.DrawImage(LED[10], Convert.ToInt32((double)(SegWidth * (i - 1)) * 1.1) * ImageRatio, 0.0F);
                                }
                                else if (!m_DecimalPos)
                                {
                                    g.DrawImage(GreenLED[10], Convert.ToInt32((double)(SegWidth * (i - 1)) * 1.1) * ImageRatio, 0.0F);
                                }
                                else
                                {
                                    g.DrawImage(RedLED[10], Convert.ToInt32((double)(SegWidth * (i - 1)) * 1.1) * ImageRatio, 0.0F);
                                }
                                one = one - j * Math.Pow(10, m_NumberOfDigits - i);
                            }
                            else
                            {
                                if (m_ForecolorHigh)
                                {
                                    g.DrawImage(LED[11], SegWidth * (i - 1) * ImageRatio, 0.0F);
                                }
                                else if (!m_DecimalPos)
                                {
                                    g.DrawImage(GreenLED[11], SegWidth * (i - 1) * ImageRatio, 0.0F);
                                }
                                else
                                {
                                    g.DrawImage(RedLED[11], SegWidth * (i - 1) * ImageRatio, 0.0F);
                                }
                                one = Math.Abs(one);
                            }
                            i = i + 1;
                        } while (i <= mNumberOfDigits);
                        if (m_DecimalPosition > 0)
                        {
                            if (m_ForecolorHigh)
                            {
                                g.DrawImage(StaticImage, Convert.ToInt32((double)((float)((m_NumberOfDigits - m_DecimalPosition) * SegWidth - 70) * ImageRatio) * 1.1), 400.0F * ImageRatio);
                            }
                            else if (!m_DecimalPos)
                            {
                                g.DrawImage(GreenDecimalImage, Convert.ToInt32((double)((float)((m_NumberOfDigits - m_DecimalPosition) * SegWidth - 70) * ImageRatio) * 1.1), 400.0F * ImageRatio);
                            }
                            else
                            {
                                g.DrawImage(RedDecimalImage, Convert.ToInt32((double)((float)((m_NumberOfDigits - m_DecimalPosition) * SegWidth - 70) * ImageRatio) * 1.1), 400.0F * ImageRatio);
                            }
                        }
                    }
                    if ((e == null) ? false : e.Graphics != null)
                    {
                        e.Graphics.DrawImage(_backBuffer, 0, 0);
                    }
                }
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (_backBuffer != null)
            {
                _backBuffer.Dispose();
                _backBuffer = null;
            }
            _Resize(this, null);
            base.OnSizeChanged(e);
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, e);
        }
        #endregion


        private string OriginalText;


        #region PLC to Link

        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string m_PLCAddressVisible = string.Empty;

        [Category("PLC Properties")]
        [Editor(typeof(TestDialogEditor), typeof(UITypeEditor))]
        public string PLCAddressVisible
        {
            get { return m_PLCAddressVisible; }
            set
            {
                if (m_PLCAddressVisible != value)
                {
                    m_PLCAddressVisible = value;

                    try
                    {
                        // If Not String.IsNullOrEmpty(m_PLCAddressVisible) Then
                        //* When address is changed, re-subscribe to new address
                        if (string.IsNullOrEmpty(m_PLCAddressVisible) ||
                            string.IsNullOrWhiteSpace(m_PLCAddressVisible) || Licenses.LicenseManager.IsInDesignMode) return;
                        var bd = new Binding("Visible", TagCollectionClient.Tags[m_PLCAddressVisible], "Visible", true);
                        DataBindings.Add(bd);
                        //End If
                    }
                    catch (Exception ex)
                    {
                        DisplayError(ex.Message);
                    }
                }
            }
        }

        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string m_PLCAddressValue = string.Empty;

        [Category("PLC Properties")]
        [Editor(typeof(TestDialogEditor), typeof(UITypeEditor))]
        public string PLCAddressValue
        {
            get { return m_PLCAddressValue; }
            set
            {
                if (m_PLCAddressValue != value)
                {
                    m_PLCAddressValue = value;

                    try
                    {
                        //* When address is changed, re-subscribe to new address
                        if (string.IsNullOrEmpty(m_PLCAddressValue) || string.IsNullOrWhiteSpace(m_PLCAddressValue) ||
                            Licenses.LicenseManager.IsInDesignMode) return;
                        var bd = new Binding("Value", TagCollectionClient.Tags[m_PLCAddressValue], "Value", true);
                        DataBindings.Add(bd);
                    }
                    catch (Exception ex)
                    {
                        DisplayError(ex.Message);
                    }
                }
            }
        }

        [DefaultValue(false)]
        public bool SuppressErrorDisplay { get; set; }

        #endregion

        #region "Error Display"

        //********************************************************
        //* Show an error via the text property for a short time
        //********************************************************
        private Timer ErrorDisplayTime;

        private void DisplayError(string ErrorMessage)
        {
            if (!SuppressErrorDisplay)
            {
                if (ErrorDisplayTime == null)
                {
                    ErrorDisplayTime = new Timer();
                    ErrorDisplayTime.Tick += ErrorDisplay_Tick;
                    ErrorDisplayTime.Interval = 5000;
                }

                //* Save the text to return to
                if (!ErrorDisplayTime.Enabled) OriginalText = Text;

                ErrorDisplayTime.Enabled = true;

                Text = ErrorMessage;
            }
        }

        //**************************************************************************************
        //* Return the text back to its original after displaying the error for a few seconds.
        //**************************************************************************************
        private void ErrorDisplay_Tick(object sender, EventArgs e)
        {
            Text = OriginalText;

            if (ErrorDisplayTime != null)
            {
                ErrorDisplayTime.Enabled = false;
                ErrorDisplayTime.Dispose();
                ErrorDisplayTime = null;
            }
        }

        #endregion

        #region "Keypad popup for data entry"

        private Keypad_v3 KeypadPopUp;

        //*****************************************
        //* Property - Address in PLC to Write Data To
        //*****************************************
        private string m_PLCAddressKeypad = string.Empty;

        [Category("PLC Properties")]
        [Editor(typeof(TestDialogEditor), typeof(UITypeEditor))]
        public string PLCAddressKeypad
        {
            get { return m_PLCAddressKeypad; }
            set
            {
                if (m_PLCAddressKeypad != value) m_PLCAddressKeypad = value;
            }
        }

        public string KeypadText { get; set; }

        private Color m_KeypadFontColor = Color.WhiteSmoke;

        public Color KeypadFontColor
        {
            get { return m_KeypadFontColor; }
            set { m_KeypadFontColor = value; }
        }

        private int m_KeypadWidth = 300;

        public int KeypadWidth
        {
            get { return m_KeypadWidth; }
            set { m_KeypadWidth = value; }
        }

        private double m_KeypadScaleFactor = 1;

        public double KeypadScaleFactor
        {
            get { return m_KeypadScaleFactor; }
            set { m_KeypadScaleFactor = value; }
        }

        public double KeypadMinValue { get; set; }

        public double KeypadMaxValue { get; set; }


        private void KeypadPopUp_ButtonClick(object sender, KeypadEventArgs e)
        {
            if (e.Key == "Quit")
            {
                KeypadPopUp.Visible = false;
            }
            else if (e.Key == "Enter")
            {
                if (KeypadPopUp.Value != null && string.Compare(KeypadPopUp.Value, string.Empty) != 0)
                    try
                    {
                        WCFChannelFactory.Write(m_PLCAddressKeypad, KeypadPopUp.Value);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to write value. " + ex.Message);
                    }

                KeypadPopUp.Visible = false;
            }
        }

        //***********************************************************
        //* If labeled is clicked, pop up a keypad for data entry
        //***********************************************************
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            if (m_PLCAddressKeypad != null && (string.Compare(m_PLCAddressKeypad, string.Empty) != 0) & Enabled)
            {
                if (KeypadPopUp == null)
                {
                    KeypadPopUp = new Keypad_v3(m_KeypadWidth);
                    KeypadPopUp.ButtonClick += KeypadPopUp_ButtonClick;
                }

                KeypadPopUp.Text = KeypadText;
                KeypadPopUp.ForeColor = m_KeypadFontColor;
                KeypadPopUp.Value = string.Empty;
                KeypadPopUp.StartPosition = FormStartPosition.CenterScreen;
                KeypadPopUp.TopMost = true;
                KeypadPopUp.Show();
            }
        }

        #endregion
    }

    internal class SevenSegmentDesigner : ControlDesigner
    {
        private DesignerActionListCollection actionLists;

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionLists == null)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new SevenSegmentListItem(this));
                }

                return actionLists;
            }
        }
    }

    internal class SevenSegmentListItem : DesignerActionList
    {
        private readonly HMISevenSegment2 _SevenSegment;

        public SevenSegmentListItem(SevenSegmentDesigner owner)
            : base(owner.Component)
        {
            _SevenSegment = (HMISevenSegment2)owner.Component;
        }

        public int DecimalPosition
        {
            get { return _SevenSegment.DecimalPosition; }
            set { _SevenSegment.DecimalPosition = value; }
        }

        public int NumberOfDigits
        {
            get { return _SevenSegment.NumberOfDigits; }
            set { _SevenSegment.NumberOfDigits = value; }
        }

        public Color BackColor
        {
            get { return _SevenSegment.BackColor; }
            set { _SevenSegment.BackColor = value; }
        }

        public Color ForeColor
        {
            get { return _SevenSegment.ForeColor; }
            set { _SevenSegment.ForeColor = value; }
        }

        public string PLCAddressValue
        {
            get { return _SevenSegment.PLCAddressValue; }
            set { _SevenSegment.PLCAddressValue = value; }
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();
            items.Add(new DesignerActionTextItem("HMI Professional Edition", "HMI Professional Edition"));
            items.Add(new DesignerActionMethodItem(this, "ShowTagDesignerForm", "Choote Tag"));
            items.Add(new DesignerActionPropertyItem("DecimalPosition", "DecimalPosition"));
            items.Add(new DesignerActionPropertyItem("NumberOfDigits", "NumberOfDigits"));
            items.Add(new DesignerActionPropertyItem("BackColor", "BackColor"));
            items.Add(new DesignerActionPropertyItem("ForeColor", "ForeColor"));
            items.Add(new DesignerActionPropertyItem("PLCAddressValue", "PLCAddressValue"));

            return items;
        }

        public void ShowTagDesignerForm()
        {
            var frm = new MonitorForm(PLCAddressValue);
            frm.OnTagSelected_Clicked += tagName => { SetProperty(_SevenSegment, "PLCAddressValue", tagName); };
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        public void SetProperty(System.Windows.Forms.Control control, string propertyName, object value)
        {
            var pd = TypeDescriptor.GetProperties(control)[propertyName];
            pd.SetValue(control, value);
        }
    }


}