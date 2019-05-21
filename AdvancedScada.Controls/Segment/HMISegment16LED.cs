using AdvancedScada.Controls.Enum;
using AdvancedScada.Controls.Segment.DrawAll;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;


namespace AdvancedScada.Controls.Segment
{
    [ToolboxBitmap(typeof(HMISegment16LED), "DASNetSegment16LED.ico")]
    public class HMISegment16LED : Control
    {
        private Timer timer_0 = new Timer();

        private bool bool_0;

        private DAS_BorderStyle das_BorderStyle_0;

        private int int_0;

        private Color color_0 = Color.Blue;

        private int int_1 = 5;

        private int int_2 = 3;

        private Color color_1 = Color.DimGray;

        private Color color_2 = Color.Lavender;

        private Color color_3 = Color.DimGray;

        private Color color_4 = Color.Lavender;

        private int int_3 = 10;

        private int int_4;

        private Color color_5 = Color.Gray;

        private DAS_BorderGradientStyle das_BorderGradientStyle_0 = DAS_BorderGradientStyle.BGS_Flat;

        private int int_5 = 225;

        private float float_0 = 0.5f;

        private float float_1 = 1f;

        private float float_2 = -1f;

        private float float_3;

        private float float_4;

        private float float_5 = 0.5f;

        private bool bool_1;

        private int int_6 = 90;

        private DAS_BkGradientStyle das_BkGradientStyle_0;

        private Color color_6 = Color.White;

        private float float_6 = 1f;

        private bool bool_2;

        private int int_7 = 8;

        private Color color_7 = Color.DimGray;

        private float float_7 = 0.5f;

        private string string_0 = string.Empty;

        private bool bool_3;

        private bool bool_4;

        private int int_8 = 1000;

        private string string_1 = "2 + 3 = 5";

        private bool bool_5;

        private Color color_8 = Color.Black;

        private Point point_0 = new Point(0, 0);

        private bool bool_6;

        private string string_2 = string.Empty;

        private Point point_1 = new Point(0, 0);

        private Color color_9 = Color.LightGreen;

        private DAS_Segment16Style das_Segment16Style_0 = DAS_Segment16Style.S16S_Rhomb;

        private System.Drawing.Size size_0 = new System.Drawing.Size(40, 40);

        private int int_9 = 4;

        private bool bool_7 = true;

        private Color color_10 = Color.Gray;

        private Color color_11 = Color.Silver;

        private int int_10 = 8;

        private int int_11;

        private float float_8 = 0.5f;

        private DAS_LEDSegmentLookupStyle das_LEDSegmentLookupStyle_0;

        private bool bool_8 = true;

        private Timer timer_1 = new Timer();

        private SortedList<string, ulong> sortedList_0 = new SortedList<string, ulong>();

        private SortedList<string, ulong> sortedList_1 = new SortedList<string, ulong>();

        private ArrayList arrayList_0 = new ArrayList();

        private ArrayList arrayList_1 = new ArrayList();

        private IContainer icontainer_0;

        [Category("Background")]
        [DefaultValue("False")]
        [Description("Get/Set whether or not background is rendered in gradient mode")]
        public bool BkGradient
        {
            get
            {
                return this.bool_1;
            }
            set
            {
                this.bool_1 = value;
                base.Invalidate();
            }
        }

        [Category("Background")]
        [DefaultValue("90")]
        [Description("Get/Set background gradient angle")]
        public int BkGradientAngle
        {
            get
            {
                return this.int_6;
            }
            set
            {
                this.int_6 = value;
                base.Invalidate();
            }
        }

        [Category("Background")]
        [DefaultValue("Color.White")]
        [Description("Get/Set background gradient color")]
        public Color BkGradientColor
        {
            get
            {
                return this.color_6;
            }
            set
            {
                this.color_6 = value;
                base.Invalidate();
            }
        }

        [Category("Background")]
        [DefaultValue("0.5")]
        [Description("Get/Set background gradient rate of the control")]
        public float BkGradientRate
        {
            get
            {
                return this.float_5;
            }
            set
            {
                if (value <= 1f || (double)value >= 0)
                {
                    this.float_5 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Background")]
        [DefaultValue("BKGS_Linear")]
        [Description("Get/Set background gradient Type")]
        public DAS_BkGradientStyle BkGradientType
        {
            get
            {
                return this.das_BkGradientStyle_0;
            }
            set
            {
                this.das_BkGradientStyle_0 = value;
                base.Invalidate();
            }
        }

        [Category("Background")]
        [DefaultValue("1.0")]
        [Description("Get/Set the shine position of the background gradient rendering")]
        public float BkShinePosition
        {
            get
            {
                return this.float_6;
            }
            set
            {
                if (value <= 1f || (double)value >= 0)
                {
                    this.float_6 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Background")]
        [DefaultValue("0.0")]
        [Description("Get/Set background transparency rate of the control")]
        public float BkTransparency
        {
            get
            {
                return this.float_4;
            }
            set
            {
                if (value <= 1f || (double)value >= 0)
                {
                    this.float_4 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Border")]
        [DefaultValue("Color.Blue")]
        [Description("Get/Set exterior line color of control")]
        public Color BorderExteriorColor
        {
            get
            {
                return this.color_0;
            }
            set
            {
                this.color_0 = value;
                base.Invalidate();
            }
        }

        [Category("Border")]
        [DefaultValue("0")]
        [Description("Get/Set exterior line width outside of the outer border of control")]
        public int BorderExteriorLength
        {
            get
            {
                return this.int_0;
            }
            set
            {
                if (value >= 0)
                {
                    this.int_0 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Border Gradient")]
        [DefaultValue("225")]
        [Description("Get/Set gradient angle of the border of control")]
        public int BorderGradientAngle
        {
            get
            {
                return this.int_5;
            }
            set
            {
                this.int_5 = value;
                base.Invalidate();
            }
        }

        [Category("Border Gradient")]
        [DefaultValue("1.0")]
        [Description("Get/Set border gradient light position 1 of control")]
        public float BorderGradientLightPos1
        {
            get
            {
                return this.float_1;
            }
            set
            {
                if (value <= 1f || (double)value >= 0)
                {
                    this.float_1 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Border Gradient")]
        [DefaultValue("-1.0")]
        [Description("Get/Set border gradient light position 2 of control")]
        public float BorderGradientLightPos2
        {
            get
            {
                return this.float_2;
            }
            set
            {
                if (value <= 1f || (double)value >= -1)
                {
                    this.float_2 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Border Gradient")]
        [DefaultValue("0.5")]
        [Description("Get/Set gradient rate of the border of control")]
        public float BorderGradientRate
        {
            get
            {
                return this.float_0;
            }
            set
            {
                if (value <= 1f || (double)value >= 0)
                {
                    this.float_0 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Border Gradient")]
        [DefaultValue("BGS_Flat")]
        [Description("Get/Set which border gradient style is used to draw the border of control")]
        public DAS_BorderGradientStyle BorderGradientType
        {
            get
            {
                return this.das_BorderGradientStyle_0;
            }
            set
            {
                this.das_BorderGradientStyle_0 = value;
                base.Invalidate();
            }
        }

        [Category("Border Gradient")]
        [DefaultValue("0.0")]
        [Description("Get/Set intermediate brightness between border lights of control")]
        public float BorderLightIntermediateBrightness
        {
            get
            {
                return this.float_3;
            }
            set
            {
                if (value <= 1f || (double)value >= 0)
                {
                    this.float_3 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Border")]
        [DefaultValue("BS_Rect")]
        [Description("Get/Set which border shape (Rectangle or Round Rectangle) is used to draw the border of control")]
        public DAS_BorderStyle BorderShape
        {
            get
            {
                return this.das_BorderStyle_0;
            }
            set
            {
                this.das_BorderStyle_0 = value;
                base.Invalidate();
            }
        }

        [Category("Segment")]
        [DefaultValue("8")]
        [Description("Get/Set the gap between the chars ")]
        public int CharGap
        {
            get
            {
                return this.int_10;
            }
            set
            {
                if (value >= 2)
                {
                    this.int_10 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Segment")]
        [DefaultValue("(20,40)")]
        [Description("Get/Set the size of each Char")]
        public System.Drawing.Size CharSize
        {
            get
            {
                return this.size_0;
            }
            set
            {
                this.size_0 = value;
                base.Invalidate();
            }
        }

        [Category("Shadow")]
        [DefaultValue("false")]
        [Description("Get/Set whether the shadow is rendered or not")]
        public bool ControlShadow
        {
            get
            {
                return this.bool_2;
            }
            set
            {
                this.bool_2 = value;
                base.Invalidate();
            }
        }

        [Category("General")]
        [DefaultValue("false")]
        [Description("Get/Set whether to flash the digits or not")]
        public bool Flashing
        {
            get
            {
                return this.bool_4;
            }
            set
            {
                this.bool_4 = value;
                this.timer_1.Enabled = this.bool_4;
                this.timer_1.Interval = this.int_8;
                base.Invalidate();
            }
        }

        [Category("General")]
        [DefaultValue("1000")]
        [Description("Get/Set the flashing duration")]
        public int FlashingDuration
        {
            get
            {
                return this.int_8;
            }
            set
            {
                this.int_8 = value;
                base.Invalidate();
            }
        }

        [Category("Segment")]
        [DefaultValue("0.5")]
        [Description("Get/Set the frame transparency rate of the control")]
        public float FrameTransparency
        {
            get
            {
                return this.float_8;
            }
            set
            {
                if (value <= 1f || (double)value >= 0)
                {
                    this.float_8 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Border")]
        [DefaultValue("Color.DimGray")]
        [Description("Get/Set inner border dark color of control")]
        public Color InnerBorderDarkColor
        {
            get
            {
                return this.color_3;
            }
            set
            {
                this.color_3 = value;
                base.Invalidate();
            }
        }

        [Category("Border")]
        [DefaultValue("3")]
        [Description("Get/Set inner border length of control")]
        public int InnerBorderLength
        {
            get
            {
                return this.int_2;
            }
            set
            {
                if (value >= 0)
                {
                    this.int_2 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Border")]
        [DefaultValue("Color.Lavender")]
        [Description("Get/Set Inner border light color of control")]
        public Color InnerBorderLightColor
        {
            get
            {
                return this.color_4;
            }
            set
            {
                this.color_4 = value;
                base.Invalidate();
            }
        }

        [Category("Border")]
        [DefaultValue("Color.Gray")]
        [Description("Get/Set Middle Border color of control")]
        public Color MiddleBorderColor
        {
            get
            {
                return this.color_5;
            }
            set
            {
                this.color_5 = value;
                base.Invalidate();
            }
        }

        [Category("Border")]
        [DefaultValue("0")]
        [Description("Get/Set Middle border length of control")]
        public int MiddleBorderLength
        {
            get
            {
                return this.int_4;
            }
            set
            {
                if (value >= 0)
                {
                    this.int_4 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("General")]
        [DefaultValue("(0,0)")]
        [Description("Get/Set the drawing offset")]
        public Point Offset
        {
            get
            {
                return this.point_0;
            }
            set
            {
                this.point_0 = value;
                base.Invalidate();
            }
        }

        [Category("Border")]
        [DefaultValue("Color.DimGray")]
        [Description("Get/Set outer border dark color of control")]
        public Color OuterBorderDarkColor
        {
            get
            {
                return this.color_1;
            }
            set
            {
                this.color_1 = value;
                base.Invalidate();
            }
        }

        [Category("Border")]
        [DefaultValue("5")]
        [Description("Get/Set outer border length of control")]
        public int OuterBorderLength
        {
            get
            {
                return this.int_1;
            }
            set
            {
                if (value >= 0)
                {
                    this.int_1 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Border")]
        [DefaultValue("Color.Lavender")]
        [Description("Get/Set outer border light color of control")]
        public Color OuterBorderLightColor
        {
            get
            {
                return this.color_2;
            }
            set
            {
                this.color_2 = value;
                base.Invalidate();
            }
        }

        [Category("Border")]
        [DefaultValue("10")]
        [Description("Get/Set Round Radius of Round Rectangle Border of control")]
        public int RoundRadius
        {
            get
            {
                return this.int_3;
            }
            set
            {
                if (value >= 0)
                {
                    this.int_3 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("General")]
        [DefaultValue("")]
        [Description("Get/Set the second text value")]
        public string SecondValue
        {
            get
            {
                return this.string_2;
            }
            set
            {
                this.string_2 = value;
                base.Invalidate();
            }
        }

        [Category("General")]
        [DefaultValue("Color.LightGreean")]
        [Description("Get/Set the color to draw the second text value")]
        public Color SecondValueColor
        {
            get
            {
                return this.color_9;
            }
            set
            {
                this.color_9 = value;
                base.Invalidate();
            }
        }

        [Category("General")]
        [DefaultValue("(0,0)")]
        [Description("Get/Set the drawing offset of the second text value")]
        public Point SecondValueOffset
        {
            get
            {
                return this.point_1;
            }
            set
            {
                this.point_1 = value;
                base.Invalidate();
            }
        }

        [Category("General")]
        [DefaultValue("false")]
        [Description("Get/Set whether the 14 segment LED is used or the 16 segment LED is used")]
        public bool Segment14
        {
            get
            {
                return this.bool_5;
            }
            set
            {
                this.bool_5 = value;
                base.Invalidate();
            }
        }

        [Category("Segment")]
        [DefaultValue("Color.Silver")]
        [Description("Get/Set the border color of each segment")]
        public Color SegmentBorderColor
        {
            get
            {
                return this.color_11;
            }
            set
            {
                this.color_11 = value;
                base.Invalidate();
            }
        }

        [Category("Segment")]
        [DefaultValue("Color.Gray")]
        [Description("Get/Set the frame color of each segment")]
        public Color SegmentFrameColor
        {
            get
            {
                return this.color_10;
            }
            set
            {
                this.color_10 = value;
                base.Invalidate();
            }
        }

        [Category("Segment")]
        [DefaultValue("true")]
        [Description("Get/Set the visibility of the frame of each segment")]
        public bool SegmentFrameVisible
        {
            get
            {
                return this.bool_7;
            }
            set
            {
                this.bool_7 = value;
                base.Invalidate();
            }
        }

        [Category("Segment")]
        [DefaultValue("0")]
        [Description("Get/Set the gap between the segments ")]
        public int SegmentGap
        {
            get
            {
                return this.int_11;
            }
            set
            {
                if (value >= 0 && value <= 2)
                {
                    this.int_11 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Segment")]
        [DefaultValue("DAS_LEDSegmentLookupStyle.LSLS_Standard")]
        [Description("Get/Set the LED segment lookup type")]
        public DAS_LEDSegmentLookupStyle SegmentLookupType
        {
            get
            {
                return this.das_LEDSegmentLookupStyle_0;
            }
            set
            {
                this.das_LEDSegmentLookupStyle_0 = value;
                base.Invalidate();
            }
        }

        [Category("Segment")]
        [DefaultValue("DAS_Segment16Style.S16S_Ladder")]
        [Description("Get/Set the shape type of the segment")]
        public DAS_Segment16Style SegmentType
        {
            get
            {
                return this.das_Segment16Style_0;
            }
            set
            {
                this.das_Segment16Style_0 = value;
                base.Invalidate();
            }
        }

        [Category("Segment")]
        [DefaultValue("4")]
        [Description("Get/Set the width of each segment")]
        public int SegmentWidth
        {
            get
            {
                return this.int_9;
            }
            set
            {
                this.int_9 = value;
                base.Invalidate();
            }
        }

        [Category("Shadow")]
        [DefaultValue("Color.DimGray")]
        [Description("Get/Set the shadow color")]
        public Color ShadowColor
        {
            get
            {
                return this.color_7;
            }
            set
            {
                this.color_7 = value;
                base.Invalidate();
            }
        }

        [Category("Shadow")]
        [DefaultValue("8")]
        [Description("Get/Set the shadow depth")]
        public int ShadowDepth
        {
            get
            {
                return this.int_7;
            }
            set
            {
                if (value > 0)
                {
                    this.int_7 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Shadow")]
        [DefaultValue("0.5")]
        [Description("Get/Set the shadow rate")]
        public float ShadowRate
        {
            get
            {
                return this.float_7;
            }
            set
            {
                if ((double)value >= 0.05 && (double)value <= 0.95)
                {
                    this.float_7 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("General")]
        [DefaultValue("false")]
        [Description("Get/Set whether to support the second text value display")]
        public bool SupportSecondValue
        {
            get
            {
                return this.bool_6;
            }
            set
            {
                this.bool_6 = value;
                base.Invalidate();
            }
        }

        [Category("General")]
        [DefaultValue("Color.Black")]
        [Description("Get/Set the color to render the text")]
        public Color TextColor
        {
            get
            {
                return this.color_8;
            }
            set
            {
                this.color_8 = value;
                base.Invalidate();
            }
        }

        [Category("General")]
        [DefaultValue("")]
        [Description("Get/Set the unit")]
        public string Unit
        {
            get
            {
                return this.string_0;
            }
            set
            {
                this.string_0 = value;
                base.Invalidate();
            }
        }

        [Category("General")]
        [DefaultValue("false")]
        [Description("Get/Set the visibility of the unit")]
        public bool UnitVisible
        {
            get
            {
                return this.bool_3;
            }
            set
            {
                this.bool_3 = value;
                base.Invalidate();
            }
        }

        [Category("General")]
        [DefaultValue("2 + 3 = 5")]
        [Description("Get/Set the LED value")]
        public string Value
        {
            get
            {
                return this.string_1;
            }
            set
            {
                this.string_1 = value;
                base.Invalidate();
            }
        }

        public HMISegment16LED()
        {
            this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.timer_0.Interval = 1800000;
            }
            else
            {
                this.timer_0.Interval = 7200000;
            }
            this.timer_0.Enabled = true;
            this.ForeColor = Color.Lime;
            this.BackColor = Color.Black;
            base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            base.SetStyle(ControlStyles.Opaque, true);
            this.method_2();
            this.method_3();
            this.timer_1.Tick += new EventHandler(this.timer_1_Tick);
        }

        public void AddCustomizedLEDSecondValue(long lngCharMap, bool bUIUpdate)
        {
            this.arrayList_1.Add(lngCharMap);
            if (bUIUpdate)
            {
                base.Invalidate();
            }
        }

        public void AddCustomizedLEDValue(long lngCharMap, bool bUIUpdate)
        {
            this.arrayList_0.Add(lngCharMap);
            if (bUIUpdate)
            {
                base.Invalidate();
            }
        }

        private void method_0(Graphics graphics_0, int int_12, int int_13, string string_3, ulong ulong_0, Color color_12, bool bool_9)
        {
            ulong item = (ulong)0;
            if (this.das_LEDSegmentLookupStyle_0 == DAS_LEDSegmentLookupStyle.LSLS_Standard)
            {
                if (!this.sortedList_0.ContainsKey(string_3))
                {
                    return;
                }
                item = this.sortedList_0[string_3];
            }
            else if (ulong_0 != (long)0)
            {
                item = ulong_0;
            }
            int i = 0;
            Color color12 = color_12;
            Color color10 = this.color_10;
            Color color11 = this.color_11;
            int float8 = 255;
            if ((double)this.float_8 > 0)
            {
                float8 = 255 - (int)(255f * this.float_8);
                color10 = Color.FromArgb(float8, this.color_10);
                color11 = Color.FromArgb(float8, this.color_11);
            }
            if (this.bool_4 && this.bool_8)
            {
                color12 = color10;
            }
            Pen pen = new Pen(color11);
            SolidBrush solidBrush = new SolidBrush(color12);
            ulong num = (ulong)1;
            for (i = 0; i < 16; i++)
            {
                if ((item & num) != (long)0 && (this.bool_7 || !bool_9) || (item & num) == (long)0 && this.bool_7)
                {
                    if ((item & num) == (long)0 || bool_9)
                    {
                        solidBrush.Color = color10;
                    }
                    else
                    {
                        solidBrush.Color = color12;
                    }
                    if (this.das_Segment16Style_0 == DAS_Segment16Style.S16S_Ladder)
                    {
                        if (i >= 8)
                        {
                            Point[] int12 = new Point[6];
                            switch (i)
                            {
                                case 8:
                                    {
                                        int12[0].X = int_12 + this.int_11;
                                        int12[0].Y = int_13 + this.size_0.Height / 2;
                                        int12[1].X = int_12 + this.int_9 + this.int_11;
                                        int12[1].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2;
                                        int12[2].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11;
                                        int12[2].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2;
                                        int12[3].X = int_12 + this.size_0.Width / 2 - this.int_11;
                                        int12[3].Y = int_13 + this.size_0.Height / 2;
                                        int12[4].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11;
                                        int12[4].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2;
                                        int12[5].X = int_12 + this.int_9 + this.int_11;
                                        int12[5].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2;
                                        break;
                                    }
                                case 9:
                                    {
                                        int12[0].X = int_12 + this.size_0.Width / 2 + this.int_11;
                                        int12[0].Y = int_13 + this.size_0.Height / 2;
                                        int12[1].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11;
                                        int12[1].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2;
                                        int12[2].X = int_12 + this.size_0.Width - this.int_9 - this.int_11;
                                        int12[2].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2;
                                        int12[3].X = int_12 + this.size_0.Width - this.int_11;
                                        int12[3].Y = int_13 + this.size_0.Height / 2;
                                        int12[4].X = int_12 + this.size_0.Width - this.int_9 - this.int_11;
                                        int12[4].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2;
                                        int12[5].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11;
                                        int12[5].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2;
                                        break;
                                    }
                                case 10:
                                    {
                                        int12[0].X = int_12 + this.size_0.Width / 2;
                                        int12[0].Y = int_13 + this.int_11;
                                        int12[1].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2;
                                        int12[1].Y = int_13 + this.int_9 + this.int_11;
                                        int12[2].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2;
                                        int12[2].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11;
                                        int12[3].X = int_12 + this.size_0.Width / 2;
                                        int12[3].Y = int_13 + this.size_0.Height / 2 - this.int_11;
                                        int12[4].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2;
                                        int12[4].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11;
                                        int12[5].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2;
                                        int12[5].Y = int_13 + this.int_9 + this.int_11;
                                        break;
                                    }
                                case 11:
                                    {
                                        int12[0].X = int_12 + this.size_0.Width / 2;
                                        int12[0].Y = int_13 + this.size_0.Height / 2 + this.int_11;
                                        int12[1].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2;
                                        int12[1].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11;
                                        int12[2].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2;
                                        int12[2].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                        int12[3].X = int_12 + this.size_0.Width / 2;
                                        int12[3].Y = int_13 + this.size_0.Height - this.int_11;
                                        int12[4].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2;
                                        int12[4].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                        int12[5].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2;
                                        int12[5].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11;
                                        break;
                                    }
                                case 12:
                                    {
                                        int12[0].X = int_12 + this.int_9 + this.int_11;
                                        int12[0].Y = int_13 + this.int_9 + this.int_11;
                                        int12[1].X = int_12 + this.int_9 + this.int_11;
                                        int12[1].Y = int_13 + this.int_9 + this.int_11 + 2 * this.int_9 / 3;
                                        int12[2].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11 - 2 * this.int_9 / 3;
                                        int12[2].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11;
                                        int12[3].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11;
                                        int12[3].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11;
                                        int12[4].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11;
                                        int12[4].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11 - 2 * this.int_9 / 3;
                                        int12[5].X = int_12 + this.int_9 + this.int_11 + 2 * this.int_9 / 3;
                                        int12[5].Y = int_13 + this.int_9 + this.int_11;
                                        break;
                                    }
                                case 13:
                                    {
                                        int12[0].X = int_12 + this.size_0.Width - this.int_9 - this.int_11;
                                        int12[0].Y = int_13 + this.int_9 + this.int_11;
                                        int12[1].X = int_12 + this.size_0.Width - this.int_9 - this.int_11;
                                        int12[1].Y = int_13 + this.int_9 + this.int_11 + 2 * this.int_9 / 3;
                                        int12[2].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11 + 2 * this.int_9 / 3;
                                        int12[2].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11;
                                        int12[3].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11;
                                        int12[3].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11;
                                        int12[4].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11;
                                        int12[4].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11 - 2 * this.int_9 / 3;
                                        int12[5].X = int_12 + this.size_0.Width - this.int_9 - this.int_11 - 2 * this.int_9 / 3;
                                        int12[5].Y = int_13 + this.int_9 + this.int_11;
                                        break;
                                    }
                                case 14:
                                    {
                                        int12[0].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11;
                                        int12[0].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11;
                                        int12[1].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11;
                                        int12[1].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11 + 2 * this.int_9 / 3;
                                        int12[2].X = int_12 + this.int_9 + this.int_11 + 2 * this.int_9 / 3;
                                        int12[2].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                        int12[3].X = int_12 + this.int_9 + this.int_11;
                                        int12[3].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                        int12[4].X = int_12 + this.int_9 + this.int_11;
                                        int12[4].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11 - 2 * this.int_9 / 3;
                                        int12[5].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11 - 2 * this.int_9 / 3;
                                        int12[5].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11;
                                        break;
                                    }
                                case 15:
                                    {
                                        int12[0].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11;
                                        int12[0].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11;
                                        int12[1].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11;
                                        int12[1].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11 + 2 * this.int_9 / 3;
                                        int12[2].X = int_12 + this.size_0.Width - this.int_9 - this.int_11 - 2 * this.int_9 / 3;
                                        int12[2].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                        int12[3].X = int_12 + this.size_0.Width - this.int_9 - this.int_11;
                                        int12[3].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                        int12[4].X = int_12 + this.size_0.Width - this.int_9 - this.int_11;
                                        int12[4].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11 - 2 * this.int_9 / 3;
                                        int12[5].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11 + 2 * this.int_9 / 3;
                                        int12[5].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11;
                                        break;
                                    }
                            }
                            graphics_0.FillPolygon(solidBrush, int12);
                            graphics_0.DrawPolygon(pen, int12);
                        }
                        else
                        {
                            Point[] int13 = new Point[4];
                            switch (i)
                            {
                                case 0:
                                    {
                                        int13[0].X = int_12;
                                        int13[0].Y = int_13;
                                        int13[1].X = int_12 + this.int_9;
                                        int13[1].Y = int_13 + this.int_9;
                                        int13[2].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11;
                                        int13[2].Y = int_13 + this.int_9;
                                        int13[3].X = int_12 + this.size_0.Width / 2 - this.int_11;
                                        int13[3].Y = int_13;
                                        break;
                                    }
                                case 1:
                                    {
                                        int13[0].X = int_12 + this.size_0.Width / 2 + this.int_11;
                                        int13[0].Y = int_13;
                                        int13[1].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11;
                                        int13[1].Y = int_13 + this.int_9;
                                        int13[2].X = int_12 + this.size_0.Width - this.int_9;
                                        int13[2].Y = int_13 + this.int_9;
                                        int13[3].X = int_12 + this.size_0.Width;
                                        int13[3].Y = int_13;
                                        break;
                                    }
                                case 2:
                                    {
                                        int13[0].X = int_12 + this.size_0.Width - this.int_9;
                                        int13[0].Y = int_13 + this.int_9 + this.int_11;
                                        int13[1].X = int_12 + this.size_0.Width - this.int_9;
                                        int13[1].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11;
                                        int13[2].X = int_12 + this.size_0.Width;
                                        int13[2].Y = int_13 + this.size_0.Height / 2 - this.int_11;
                                        int13[3].X = int_12 + this.size_0.Width;
                                        int13[3].Y = int_13 + this.int_11;
                                        break;
                                    }
                                case 3:
                                    {
                                        int13[0].X = int_12 + this.size_0.Width - this.int_9;
                                        int13[0].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11;
                                        int13[1].X = int_12 + this.size_0.Width - this.int_9;
                                        int13[1].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                        int13[2].X = int_12 + this.size_0.Width;
                                        int13[2].Y = int_13 + this.size_0.Height - this.int_11;
                                        int13[3].X = int_12 + this.size_0.Width;
                                        int13[3].Y = int_13 + this.size_0.Height / 2 + this.int_11;
                                        break;
                                    }
                                case 4:
                                    {
                                        int13[0].X = int_12 + this.size_0.Width / 2 + this.int_11;
                                        int13[0].Y = int_13 + this.size_0.Height;
                                        int13[1].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11;
                                        int13[1].Y = int_13 + this.size_0.Height - this.int_9;
                                        int13[2].X = int_12 + this.size_0.Width - this.int_9;
                                        int13[2].Y = int_13 + this.size_0.Height - this.int_9;
                                        int13[3].X = int_12 + this.size_0.Width;
                                        int13[3].Y = int_13 + this.size_0.Height;
                                        break;
                                    }
                                case 5:
                                    {
                                        int13[0].X = int_12;
                                        int13[0].Y = int_13 + this.size_0.Height;
                                        int13[1].X = int_12 + this.int_9;
                                        int13[1].Y = int_13 + this.size_0.Height - this.int_9;
                                        int13[2].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11;
                                        int13[2].Y = int_13 + this.size_0.Height - this.int_9;
                                        int13[3].X = int_12 + this.size_0.Width / 2 - this.int_11;
                                        int13[3].Y = int_13 + this.size_0.Height;
                                        break;
                                    }
                                case 6:
                                    {
                                        int13[0].X = int_12 + this.int_9;
                                        int13[0].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11;
                                        int13[1].X = int_12 + this.int_9;
                                        int13[1].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                        int13[2].X = int_12;
                                        int13[2].Y = int_13 + this.size_0.Height - this.int_11;
                                        int13[3].X = int_12;
                                        int13[3].Y = int_13 + this.size_0.Height / 2 + this.int_11;
                                        break;
                                    }
                                case 7:
                                    {
                                        int13[0].X = int_12 + this.int_9;
                                        int13[0].Y = int_13 + this.int_9 + this.int_11;
                                        int13[1].X = int_12 + this.int_9;
                                        int13[1].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11;
                                        int13[2].X = int_12;
                                        int13[2].Y = int_13 + this.size_0.Height / 2 - this.int_11;
                                        int13[3].X = int_12;
                                        int13[3].Y = int_13 + this.int_11;
                                        break;
                                    }
                            }
                            graphics_0.FillPolygon(solidBrush, int13);
                            graphics_0.DrawPolygon(pen, int13);
                        }
                    }
                    else if (this.das_Segment16Style_0 == DAS_Segment16Style.S16S_Rhomb)
                    {
                        Point[] pointArray = new Point[6];
                        switch (i)
                        {
                            case 0:
                                {
                                    pointArray[0].X = int_12 + this.int_9 / 2;
                                    pointArray[0].Y = int_13 + this.int_9 / 2;
                                    pointArray[1].X = int_12 + this.int_9;
                                    pointArray[1].Y = int_13 + this.int_9;
                                    pointArray[2].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2;
                                    pointArray[2].Y = int_13 + this.int_9;
                                    pointArray[3].X = int_12 + this.size_0.Width / 2;
                                    pointArray[3].Y = int_13 + this.int_9 / 2;
                                    pointArray[4].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2;
                                    pointArray[4].Y = int_13;
                                    pointArray[5].X = int_12 + this.int_9;
                                    pointArray[5].Y = int_13;
                                    break;
                                }
                            case 1:
                                {
                                    pointArray[0].X = int_12 + this.size_0.Width / 2;
                                    pointArray[0].Y = int_13 + this.int_9 / 2;
                                    pointArray[1].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2;
                                    pointArray[1].Y = int_13 + this.int_9;
                                    pointArray[2].X = int_12 + this.size_0.Width - this.int_9;
                                    pointArray[2].Y = int_13 + this.int_9;
                                    pointArray[3].X = int_12 + this.size_0.Width - this.int_9 / 2;
                                    pointArray[3].Y = int_13 + this.int_9 / 2;
                                    pointArray[4].X = int_12 + this.size_0.Width - this.int_9 / 2;
                                    pointArray[4].Y = int_13;
                                    pointArray[5].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2;
                                    pointArray[5].Y = int_13;
                                    break;
                                }
                            case 2:
                                {
                                    pointArray[0].X = int_12 + this.size_0.Width - this.int_9 / 2;
                                    pointArray[0].Y = int_13 + this.int_9 / 2 + this.int_11;
                                    pointArray[1].X = int_12 + this.size_0.Width - this.int_9;
                                    pointArray[1].Y = int_13 + this.int_9 + this.int_11;
                                    pointArray[2].X = int_12 + this.size_0.Width - this.int_9;
                                    pointArray[2].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2;
                                    pointArray[3].X = int_12 + this.size_0.Width - this.int_9 / 2;
                                    pointArray[3].Y = int_13 + this.size_0.Height / 2;
                                    pointArray[4].X = int_12 + this.size_0.Width;
                                    pointArray[4].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2;
                                    pointArray[5].X = int_12 + this.size_0.Width;
                                    pointArray[5].Y = int_13 + this.int_9 + this.int_11;
                                    break;
                                }
                            case 3:
                                {
                                    pointArray[0].X = int_12 + this.size_0.Width - this.int_9 / 2;
                                    pointArray[0].Y = int_13 + this.size_0.Height / 2;
                                    pointArray[1].X = int_12 + this.size_0.Width - this.int_9;
                                    pointArray[1].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2;
                                    pointArray[2].X = int_12 + this.size_0.Width - this.int_9;
                                    pointArray[2].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                    pointArray[3].X = int_12 + this.size_0.Width - this.int_9 / 2;
                                    pointArray[3].Y = int_13 + this.size_0.Height - this.int_9 / 2 - this.int_11;
                                    pointArray[4].X = int_12 + this.size_0.Width;
                                    pointArray[4].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                    pointArray[5].X = int_12 + this.size_0.Width;
                                    pointArray[5].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2;
                                    break;
                                }
                            case 4:
                                {
                                    pointArray[0].X = int_12 + this.size_0.Width / 2;
                                    pointArray[0].Y = int_13 + this.size_0.Height - this.int_9 / 2;
                                    pointArray[1].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2;
                                    pointArray[1].Y = int_13 + this.size_0.Height - this.int_9;
                                    pointArray[2].X = int_12 + this.size_0.Width - this.int_9;
                                    pointArray[2].Y = int_13 + this.size_0.Height - this.int_9;
                                    pointArray[3].X = int_12 + this.size_0.Width - this.int_9 / 2;
                                    pointArray[3].Y = int_13 + this.size_0.Height - this.int_9 / 2;
                                    pointArray[4].X = int_12 + this.size_0.Width - this.int_9;
                                    pointArray[4].Y = int_13 + this.size_0.Height;
                                    pointArray[5].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2;
                                    pointArray[5].Y = int_13 + this.size_0.Height;
                                    break;
                                }
                            case 5:
                                {
                                    pointArray[0].X = int_12 + this.int_9 / 2;
                                    pointArray[0].Y = int_13 + this.size_0.Height - this.int_9 / 2;
                                    pointArray[1].X = int_12 + this.int_9;
                                    pointArray[1].Y = int_13 + this.size_0.Height - this.int_9;
                                    pointArray[2].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2;
                                    pointArray[2].Y = int_13 + this.size_0.Height - this.int_9;
                                    pointArray[3].X = int_12 + this.size_0.Width / 2;
                                    pointArray[3].Y = int_13 + this.size_0.Height - this.int_9 / 2;
                                    pointArray[4].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2;
                                    pointArray[4].Y = int_13 + this.size_0.Height;
                                    pointArray[5].X = int_12 + this.int_9;
                                    pointArray[5].Y = int_13 + this.size_0.Height;
                                    break;
                                }
                            case 6:
                                {
                                    pointArray[0].X = int_12 + this.int_9 / 2;
                                    pointArray[0].Y = int_13 + this.size_0.Height / 2;
                                    pointArray[1].X = int_12 + this.int_9;
                                    pointArray[1].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2;
                                    pointArray[2].X = int_12 + this.int_9;
                                    pointArray[2].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                    pointArray[3].X = int_12 + this.int_9 / 2;
                                    pointArray[3].Y = int_13 + this.size_0.Height - this.int_9 / 2 - this.int_11;
                                    pointArray[4].X = int_12;
                                    pointArray[4].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                    pointArray[5].X = int_12;
                                    pointArray[5].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2;
                                    break;
                                }
                            case 7:
                                {
                                    pointArray[0].X = int_12 + this.int_9 / 2;
                                    pointArray[0].Y = int_13 + this.int_9 / 2 + this.int_11;
                                    pointArray[1].X = int_12 + this.int_9;
                                    pointArray[1].Y = int_13 + this.int_9 + this.int_11;
                                    pointArray[2].X = int_12 + this.int_9;
                                    pointArray[2].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2;
                                    pointArray[3].X = int_12 + this.int_9 / 2;
                                    pointArray[3].Y = int_13 + this.size_0.Height / 2;
                                    pointArray[4].X = int_12;
                                    pointArray[4].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2;
                                    pointArray[5].X = int_12;
                                    pointArray[5].Y = int_13 + this.int_9 + this.int_11;
                                    break;
                                }
                            case 8:
                                {
                                    pointArray[0].X = int_12 + this.int_9 / 2 + this.int_11;
                                    pointArray[0].Y = int_13 + this.size_0.Height / 2;
                                    pointArray[1].X = int_12 + this.int_9 + this.int_11;
                                    pointArray[1].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2;
                                    pointArray[2].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2;
                                    pointArray[2].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2;
                                    pointArray[3].X = int_12 + this.size_0.Width / 2;
                                    pointArray[3].Y = int_13 + this.size_0.Height / 2;
                                    pointArray[4].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2;
                                    pointArray[4].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2;
                                    pointArray[5].X = int_12 + this.int_9 + this.int_11;
                                    pointArray[5].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2;
                                    break;
                                }
                            case 9:
                                {
                                    pointArray[0].X = int_12 + this.size_0.Width / 2;
                                    pointArray[0].Y = int_13 + this.size_0.Height / 2;
                                    pointArray[1].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2;
                                    pointArray[1].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2;
                                    pointArray[2].X = int_12 + this.size_0.Width - this.int_9 - this.int_11;
                                    pointArray[2].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2;
                                    pointArray[3].X = int_12 + this.size_0.Width - this.int_9 / 2 - this.int_11;
                                    pointArray[3].Y = int_13 + this.size_0.Height / 2;
                                    pointArray[4].X = int_12 + this.size_0.Width - this.int_9 - this.int_11;
                                    pointArray[4].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2;
                                    pointArray[5].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2;
                                    pointArray[5].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2;
                                    break;
                                }
                            case 10:
                                {
                                    pointArray[0].X = int_12 + this.size_0.Width / 2;
                                    pointArray[0].Y = int_13 + this.int_9 / 2 + this.int_11;
                                    pointArray[1].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2;
                                    pointArray[1].Y = int_13 + this.int_9 + this.int_11;
                                    pointArray[2].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2;
                                    pointArray[2].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - 2;
                                    pointArray[3].X = int_12 + this.size_0.Width / 2;
                                    pointArray[3].Y = int_13 + this.size_0.Height / 2 - this.int_11;
                                    pointArray[4].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2;
                                    pointArray[4].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11;
                                    pointArray[5].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2;
                                    pointArray[5].Y = int_13 + this.int_9 + this.int_11;
                                    break;
                                }
                            case 11:
                                {
                                    pointArray[0].X = int_12 + this.size_0.Width / 2;
                                    pointArray[0].Y = int_13 + this.size_0.Height / 2 + this.int_11;
                                    pointArray[1].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2;
                                    pointArray[1].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11;
                                    pointArray[2].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2;
                                    pointArray[2].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                    pointArray[3].X = int_12 + this.size_0.Width / 2;
                                    pointArray[3].Y = int_13 + this.size_0.Height - this.int_9 / 2 - this.int_11;
                                    pointArray[4].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2;
                                    pointArray[4].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                    pointArray[5].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2;
                                    pointArray[5].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11;
                                    break;
                                }
                            case 12:
                                {
                                    pointArray[0].X = int_12 + this.int_9 + this.int_11;
                                    pointArray[0].Y = int_13 + this.int_9 + this.int_11;
                                    pointArray[1].X = int_12 + this.int_9 + this.int_11;
                                    pointArray[1].Y = int_13 + this.int_9 + this.int_11 + 2 * this.int_9 / 3;
                                    pointArray[2].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11 - 2 * this.int_9 / 3;
                                    pointArray[2].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11;
                                    pointArray[3].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11;
                                    pointArray[3].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11;
                                    pointArray[4].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11;
                                    pointArray[4].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11 - 2 * this.int_9 / 3;
                                    pointArray[5].X = int_12 + this.int_9 + this.int_11 + 2 * this.int_9 / 3;
                                    pointArray[5].Y = int_13 + this.int_9 + this.int_11;
                                    break;
                                }
                            case 13:
                                {
                                    pointArray[0].X = int_12 + this.size_0.Width - this.int_9 - this.int_11;
                                    pointArray[0].Y = int_13 + this.int_9 + this.int_11;
                                    pointArray[1].X = int_12 + this.size_0.Width - this.int_9 - this.int_11;
                                    pointArray[1].Y = int_13 + this.int_9 + this.int_11 + 2 * this.int_9 / 3;
                                    pointArray[2].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11 + 2 * this.int_9 / 3;
                                    pointArray[2].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11;
                                    pointArray[3].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11;
                                    pointArray[3].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11;
                                    pointArray[4].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11;
                                    pointArray[4].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11 - 2 * this.int_9 / 3;
                                    pointArray[5].X = int_12 + this.size_0.Width - this.int_9 - this.int_11 - 2 * this.int_9 / 3;
                                    pointArray[5].Y = int_13 + this.int_9 + this.int_11;
                                    break;
                                }
                            case 14:
                                {
                                    pointArray[0].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11;
                                    pointArray[0].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11;
                                    pointArray[1].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11;
                                    pointArray[1].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11 + 2 * this.int_9 / 3;
                                    pointArray[2].X = int_12 + this.int_9 + this.int_11 + 2 * this.int_9 / 3;
                                    pointArray[2].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                    pointArray[3].X = int_12 + this.int_9 + this.int_11;
                                    pointArray[3].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                    pointArray[4].X = int_12 + this.int_9 + this.int_11;
                                    pointArray[4].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11 - 2 * this.int_9 / 3;
                                    pointArray[5].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11 - 2 * this.int_9 / 3;
                                    pointArray[5].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11;
                                    break;
                                }
                            case 15:
                                {
                                    pointArray[0].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11;
                                    pointArray[0].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11;
                                    pointArray[1].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11;
                                    pointArray[1].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11 + 2 * this.int_9 / 3;
                                    pointArray[2].X = int_12 + this.size_0.Width - this.int_9 - this.int_11 - 2 * this.int_9 / 3;
                                    pointArray[2].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                    pointArray[3].X = int_12 + this.size_0.Width - this.int_9 - this.int_11;
                                    pointArray[3].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                    pointArray[4].X = int_12 + this.size_0.Width - this.int_9 - this.int_11;
                                    pointArray[4].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11 - 2 * this.int_9 / 3;
                                    pointArray[5].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11 + 2 * this.int_9 / 3;
                                    pointArray[5].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11;
                                    break;
                                }
                        }
                        graphics_0.FillPolygon(solidBrush, pointArray);
                        graphics_0.DrawPolygon(pen, pointArray);
                    }
                }
                num = num * (long)2;
            }
            solidBrush.Dispose();
            pen.Dispose();
        }

        private void method_1(Graphics graphics_0, int int_12, int int_13, string string_3, ulong ulong_0, Color color_12, bool bool_9)
        {
            ulong item = (ulong)0;
            if (this.das_LEDSegmentLookupStyle_0 == DAS_LEDSegmentLookupStyle.LSLS_Standard)
            {
                if (!this.sortedList_1.ContainsKey(string_3))
                {
                    return;
                }
                item = this.sortedList_1[string_3];
            }
            else if (ulong_0 != (long)0)
            {
                item = ulong_0;
            }
            int i = 0;
            Color color12 = color_12;
            Color color10 = this.color_10;
            Color color11 = this.color_11;
            int float8 = 255;
            if ((double)this.float_8 > 0)
            {
                float8 = 255 - (int)(255f * this.float_8);
                color10 = Color.FromArgb(float8, this.color_10);
                color11 = Color.FromArgb(float8, this.color_11);
            }
            if (this.bool_4 && this.bool_8)
            {
                color12 = color10;
            }
            Pen pen = new Pen(color11);
            SolidBrush solidBrush = new SolidBrush(color12);
            ulong num = (ulong)1;
            for (i = 0; i < 16; i++)
            {
                if ((item & num) != (long)0 && (this.bool_7 || !bool_9) || (item & num) == (long)0 && this.bool_7)
                {
                    if ((item & num) == (long)0 || bool_9)
                    {
                        solidBrush.Color = color10;
                    }
                    else
                    {
                        solidBrush.Color = color12;
                    }
                    if (this.das_Segment16Style_0 == DAS_Segment16Style.S16S_Ladder)
                    {
                        if (i >= 6)
                        {
                            Point[] int12 = new Point[6];
                            switch (i)
                            {
                                case 6:
                                    {
                                        int12[0].X = int_12 + this.int_11;
                                        int12[0].Y = int_13 + this.size_0.Height / 2;
                                        int12[1].X = int_12 + this.int_9 + this.int_11;
                                        int12[1].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2;
                                        int12[2].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11;
                                        int12[2].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2;
                                        int12[3].X = int_12 + this.size_0.Width / 2 - this.int_11;
                                        int12[3].Y = int_13 + this.size_0.Height / 2;
                                        int12[4].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11;
                                        int12[4].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2;
                                        int12[5].X = int_12 + this.int_9 + this.int_11;
                                        int12[5].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2;
                                        break;
                                    }
                                case 7:
                                    {
                                        int12[0].X = int_12 + this.size_0.Width / 2 + this.int_11;
                                        int12[0].Y = int_13 + this.size_0.Height / 2;
                                        int12[1].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11;
                                        int12[1].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2;
                                        int12[2].X = int_12 + this.size_0.Width - this.int_9 - this.int_11;
                                        int12[2].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2;
                                        int12[3].X = int_12 + this.size_0.Width - this.int_11;
                                        int12[3].Y = int_13 + this.size_0.Height / 2;
                                        int12[4].X = int_12 + this.size_0.Width - this.int_9 - this.int_11;
                                        int12[4].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2;
                                        int12[5].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11;
                                        int12[5].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2;
                                        break;
                                    }
                                case 8:
                                    {
                                        int12[0].X = int_12 + this.size_0.Width / 2;
                                        int12[0].Y = int_13 + this.int_9 + this.int_11;
                                        int12[1].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2;
                                        int12[1].Y = int_13 + this.int_9 + this.int_11;
                                        int12[2].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2;
                                        int12[2].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11;
                                        int12[3].X = int_12 + this.size_0.Width / 2;
                                        int12[3].Y = int_13 + this.size_0.Height / 2 - this.int_11;
                                        int12[4].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2;
                                        int12[4].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11;
                                        int12[5].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2;
                                        int12[5].Y = int_13 + this.int_9 + this.int_11;
                                        break;
                                    }
                                case 9:
                                    {
                                        int12[0].X = int_12 + this.size_0.Width / 2;
                                        int12[0].Y = int_13 + this.size_0.Height / 2 + this.int_11;
                                        int12[1].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2;
                                        int12[1].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11;
                                        int12[2].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2;
                                        int12[2].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                        int12[3].X = int_12 + this.size_0.Width / 2;
                                        int12[3].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                        int12[4].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2;
                                        int12[4].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                        int12[5].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2;
                                        int12[5].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11;
                                        break;
                                    }
                                case 10:
                                    {
                                        int12[0].X = int_12 + this.int_9 + this.int_11;
                                        int12[0].Y = int_13 + this.int_9 + this.int_11;
                                        int12[1].X = int_12 + this.int_9 + this.int_11;
                                        int12[1].Y = int_13 + this.int_9 + this.int_11 + 2 * this.int_9 / 3;
                                        int12[2].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11 - 2 * this.int_9 / 3;
                                        int12[2].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11;
                                        int12[3].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11;
                                        int12[3].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11;
                                        int12[4].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11;
                                        int12[4].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11 - 2 * this.int_9 / 3;
                                        int12[5].X = int_12 + this.int_9 + this.int_11 + 2 * this.int_9 / 3;
                                        int12[5].Y = int_13 + this.int_9 + this.int_11;
                                        break;
                                    }
                                case 11:
                                    {
                                        int12[0].X = int_12 + this.size_0.Width - this.int_9 - this.int_11;
                                        int12[0].Y = int_13 + this.int_9 + this.int_11;
                                        int12[1].X = int_12 + this.size_0.Width - this.int_9 - this.int_11;
                                        int12[1].Y = int_13 + this.int_9 + this.int_11 + 2 * this.int_9 / 3;
                                        int12[2].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11 + 2 * this.int_9 / 3;
                                        int12[2].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11;
                                        int12[3].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11;
                                        int12[3].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11;
                                        int12[4].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11;
                                        int12[4].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11 - 2 * this.int_9 / 3;
                                        int12[5].X = int_12 + this.size_0.Width - this.int_9 - this.int_11 - 2 * this.int_9 / 3;
                                        int12[5].Y = int_13 + this.int_9 + this.int_11;
                                        break;
                                    }
                                case 12:
                                    {
                                        int12[0].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11;
                                        int12[0].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11;
                                        int12[1].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11;
                                        int12[1].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11 + 2 * this.int_9 / 3;
                                        int12[2].X = int_12 + this.int_9 + this.int_11 + 2 * this.int_9 / 3;
                                        int12[2].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                        int12[3].X = int_12 + this.int_9 + this.int_11;
                                        int12[3].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                        int12[4].X = int_12 + this.int_9 + this.int_11;
                                        int12[4].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11 - 2 * this.int_9 / 3;
                                        int12[5].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11 - 2 * this.int_9 / 3;
                                        int12[5].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11;
                                        break;
                                    }
                                case 13:
                                    {
                                        int12[0].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11;
                                        int12[0].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11;
                                        int12[1].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11;
                                        int12[1].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11 + 2 * this.int_9 / 3;
                                        int12[2].X = int_12 + this.size_0.Width - this.int_9 - this.int_11 - 2 * this.int_9 / 3;
                                        int12[2].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                        int12[3].X = int_12 + this.size_0.Width - this.int_9 - this.int_11;
                                        int12[3].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                        int12[4].X = int_12 + this.size_0.Width - this.int_9 - this.int_11;
                                        int12[4].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11 - 2 * this.int_9 / 3;
                                        int12[5].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11 + 2 * this.int_9 / 3;
                                        int12[5].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11;
                                        break;
                                    }
                            }
                            graphics_0.FillPolygon(solidBrush, int12);
                            graphics_0.DrawPolygon(pen, int12);
                        }
                        else
                        {
                            Point[] int13 = new Point[4];
                            switch (i)
                            {
                                case 0:
                                    {
                                        int13[0].X = int_12;
                                        int13[0].Y = int_13;
                                        int13[1].X = int_12 + this.int_9;
                                        int13[1].Y = int_13 + this.int_9;
                                        int13[2].X = int_12 + this.size_0.Width - this.int_9;
                                        int13[2].Y = int_13 + this.int_9;
                                        int13[3].X = int_12 + this.size_0.Width;
                                        int13[3].Y = int_13;
                                        break;
                                    }
                                case 1:
                                    {
                                        int13[0].X = int_12 + this.size_0.Width - this.int_9;
                                        int13[0].Y = int_13 + this.int_9 + this.int_11;
                                        int13[1].X = int_12 + this.size_0.Width - this.int_9;
                                        int13[1].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11;
                                        int13[2].X = int_12 + this.size_0.Width;
                                        int13[2].Y = int_13 + this.size_0.Height / 2 - this.int_11;
                                        int13[3].X = int_12 + this.size_0.Width;
                                        int13[3].Y = int_13 + this.int_11;
                                        break;
                                    }
                                case 2:
                                    {
                                        int13[0].X = int_12 + this.size_0.Width - this.int_9;
                                        int13[0].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11;
                                        int13[1].X = int_12 + this.size_0.Width - this.int_9;
                                        int13[1].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                        int13[2].X = int_12 + this.size_0.Width;
                                        int13[2].Y = int_13 + this.size_0.Height - this.int_11;
                                        int13[3].X = int_12 + this.size_0.Width;
                                        int13[3].Y = int_13 + this.size_0.Height / 2 + this.int_11;
                                        break;
                                    }
                                case 3:
                                    {
                                        int13[0].X = int_12;
                                        int13[0].Y = int_13 + this.size_0.Height;
                                        int13[1].X = int_12 + this.int_9;
                                        int13[1].Y = int_13 + this.size_0.Height - this.int_9;
                                        int13[2].X = int_12 + this.size_0.Width - this.int_9;
                                        int13[2].Y = int_13 + this.size_0.Height - this.int_9;
                                        int13[3].X = int_12 + this.size_0.Width;
                                        int13[3].Y = int_13 + this.size_0.Height;
                                        break;
                                    }
                                case 4:
                                    {
                                        int13[0].X = int_12 + this.int_9;
                                        int13[0].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11;
                                        int13[1].X = int_12 + this.int_9;
                                        int13[1].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                        int13[2].X = int_12;
                                        int13[2].Y = int_13 + this.size_0.Height - this.int_11;
                                        int13[3].X = int_12;
                                        int13[3].Y = int_13 + this.size_0.Height / 2 + this.int_11;
                                        break;
                                    }
                                case 5:
                                    {
                                        int13[0].X = int_12 + this.int_9;
                                        int13[0].Y = int_13 + this.int_9 + this.int_11;
                                        int13[1].X = int_12 + this.int_9;
                                        int13[1].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11;
                                        int13[2].X = int_12;
                                        int13[2].Y = int_13 + this.size_0.Height / 2 - this.int_11;
                                        int13[3].X = int_12;
                                        int13[3].Y = int_13 + this.int_11;
                                        break;
                                    }
                            }
                            graphics_0.FillPolygon(solidBrush, int13);
                            graphics_0.DrawPolygon(pen, int13);
                        }
                    }
                    else if (this.das_Segment16Style_0 == DAS_Segment16Style.S16S_Rhomb)
                    {
                        Point[] pointArray = new Point[6];
                        switch (i)
                        {
                            case 0:
                                {
                                    pointArray[0].X = int_12 + this.int_9 / 2;
                                    pointArray[0].Y = int_13 + this.int_9 / 2;
                                    pointArray[1].X = int_12 + this.int_9;
                                    pointArray[1].Y = int_13 + this.int_9;
                                    pointArray[2].X = int_12 + this.size_0.Width - this.int_9;
                                    pointArray[2].Y = int_13 + this.int_9;
                                    pointArray[3].X = int_12 + this.size_0.Width - this.int_9 / 2;
                                    pointArray[3].Y = int_13 + this.int_9 / 2;
                                    pointArray[4].X = int_12 + this.size_0.Width - this.int_9;
                                    pointArray[4].Y = int_13;
                                    pointArray[5].X = int_12 + this.int_9;
                                    pointArray[5].Y = int_13;
                                    break;
                                }
                            case 1:
                                {
                                    pointArray[0].X = int_12 + this.size_0.Width - this.int_9 / 2;
                                    pointArray[0].Y = int_13 + this.int_9 / 2 + this.int_11;
                                    pointArray[1].X = int_12 + this.size_0.Width - this.int_9;
                                    pointArray[1].Y = int_13 + this.int_9 + this.int_11;
                                    pointArray[2].X = int_12 + this.size_0.Width - this.int_9;
                                    pointArray[2].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2;
                                    pointArray[3].X = int_12 + this.size_0.Width - this.int_9 / 2;
                                    pointArray[3].Y = int_13 + this.size_0.Height / 2;
                                    pointArray[4].X = int_12 + this.size_0.Width;
                                    pointArray[4].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2;
                                    pointArray[5].X = int_12 + this.size_0.Width;
                                    pointArray[5].Y = int_13 + this.int_9 + this.int_11;
                                    break;
                                }
                            case 2:
                                {
                                    pointArray[0].X = int_12 + this.size_0.Width - this.int_9 / 2;
                                    pointArray[0].Y = int_13 + this.size_0.Height / 2;
                                    pointArray[1].X = int_12 + this.size_0.Width - this.int_9;
                                    pointArray[1].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2;
                                    pointArray[2].X = int_12 + this.size_0.Width - this.int_9;
                                    pointArray[2].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                    pointArray[3].X = int_12 + this.size_0.Width - this.int_9 / 2;
                                    pointArray[3].Y = int_13 + this.size_0.Height - this.int_9 / 2 - this.int_11;
                                    pointArray[4].X = int_12 + this.size_0.Width;
                                    pointArray[4].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                    pointArray[5].X = int_12 + this.size_0.Width;
                                    pointArray[5].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2;
                                    break;
                                }
                            case 3:
                                {
                                    pointArray[0].X = int_12;
                                    pointArray[0].Y = int_13 + this.size_0.Height - this.int_9 / 2;
                                    pointArray[1].X = int_12 + this.int_9 / 2;
                                    pointArray[1].Y = int_13 + this.size_0.Height - this.int_9;
                                    pointArray[2].X = int_12 + this.size_0.Width - this.int_9;
                                    pointArray[2].Y = int_13 + this.size_0.Height - this.int_9;
                                    pointArray[3].X = int_12 + this.size_0.Width - this.int_9 / 2;
                                    pointArray[3].Y = int_13 + this.size_0.Height - this.int_9 / 2;
                                    pointArray[4].X = int_12 + this.size_0.Width - this.int_9;
                                    pointArray[4].Y = int_13 + this.size_0.Height;
                                    pointArray[5].X = int_12 + this.int_9 / 2;
                                    pointArray[5].Y = int_13 + this.size_0.Height;
                                    break;
                                }
                            case 4:
                                {
                                    pointArray[0].X = int_12 + this.int_9 / 2;
                                    pointArray[0].Y = int_13 + this.size_0.Height / 2;
                                    pointArray[1].X = int_12 + this.int_9;
                                    pointArray[1].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2;
                                    pointArray[2].X = int_12 + this.int_9;
                                    pointArray[2].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                    pointArray[3].X = int_12 + this.int_9 / 2;
                                    pointArray[3].Y = int_13 + this.size_0.Height - this.int_9 / 2 - this.int_11;
                                    pointArray[4].X = int_12;
                                    pointArray[4].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                    pointArray[5].X = int_12;
                                    pointArray[5].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2;
                                    break;
                                }
                            case 5:
                                {
                                    pointArray[0].X = int_12 + this.int_9 / 2;
                                    pointArray[0].Y = int_13 + this.int_9 / 2 + this.int_11;
                                    pointArray[1].X = int_12 + this.int_9;
                                    pointArray[1].Y = int_13 + this.int_9 + this.int_11;
                                    pointArray[2].X = int_12 + this.int_9;
                                    pointArray[2].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2;
                                    pointArray[3].X = int_12 + this.int_9 / 2;
                                    pointArray[3].Y = int_13 + this.size_0.Height / 2;
                                    pointArray[4].X = int_12;
                                    pointArray[4].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2;
                                    pointArray[5].X = int_12;
                                    pointArray[5].Y = int_13 + this.int_9 + this.int_11;
                                    break;
                                }
                            case 6:
                                {
                                    pointArray[0].X = int_12 + this.int_9 / 2 + this.int_11;
                                    pointArray[0].Y = int_13 + this.size_0.Height / 2;
                                    pointArray[1].X = int_12 + this.int_9 + this.int_11;
                                    pointArray[1].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2;
                                    pointArray[2].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2;
                                    pointArray[2].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2;
                                    pointArray[3].X = int_12 + this.size_0.Width / 2;
                                    pointArray[3].Y = int_13 + this.size_0.Height / 2;
                                    pointArray[4].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2;
                                    pointArray[4].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2;
                                    pointArray[5].X = int_12 + this.int_9 + this.int_11;
                                    pointArray[5].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2;
                                    break;
                                }
                            case 7:
                                {
                                    pointArray[0].X = int_12 + this.size_0.Width / 2;
                                    pointArray[0].Y = int_13 + this.size_0.Height / 2;
                                    pointArray[1].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2;
                                    pointArray[1].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2;
                                    pointArray[2].X = int_12 + this.size_0.Width - this.int_9 - this.int_11;
                                    pointArray[2].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2;
                                    pointArray[3].X = int_12 + this.size_0.Width - this.int_9 / 2 - this.int_11;
                                    pointArray[3].Y = int_13 + this.size_0.Height / 2;
                                    pointArray[4].X = int_12 + this.size_0.Width - this.int_9 - this.int_11;
                                    pointArray[4].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2;
                                    pointArray[5].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2;
                                    pointArray[5].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2;
                                    break;
                                }
                            case 8:
                                {
                                    pointArray[0].X = int_12 + this.size_0.Width / 2;
                                    pointArray[0].Y = int_13 + this.int_9 + this.int_11;
                                    pointArray[1].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2;
                                    pointArray[1].Y = int_13 + this.int_9 + this.int_11;
                                    pointArray[2].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2;
                                    pointArray[2].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - 2;
                                    pointArray[3].X = int_12 + this.size_0.Width / 2;
                                    pointArray[3].Y = int_13 + this.size_0.Height / 2 - this.int_11;
                                    pointArray[4].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2;
                                    pointArray[4].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11;
                                    pointArray[5].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2;
                                    pointArray[5].Y = int_13 + this.int_9 + this.int_11;
                                    break;
                                }
                            case 9:
                                {
                                    pointArray[0].X = int_12 + this.size_0.Width / 2;
                                    pointArray[0].Y = int_13 + this.size_0.Height / 2 + this.int_11;
                                    pointArray[1].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2;
                                    pointArray[1].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11;
                                    pointArray[2].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2;
                                    pointArray[2].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                    pointArray[3].X = int_12 + this.size_0.Width / 2;
                                    pointArray[3].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                    pointArray[4].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2;
                                    pointArray[4].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                    pointArray[5].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2;
                                    pointArray[5].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11;
                                    break;
                                }
                            case 10:
                                {
                                    pointArray[0].X = int_12 + this.int_9 + this.int_11;
                                    pointArray[0].Y = int_13 + this.int_9 + this.int_11;
                                    pointArray[1].X = int_12 + this.int_9 + this.int_11;
                                    pointArray[1].Y = int_13 + this.int_9 + this.int_11 + 2 * this.int_9 / 3;
                                    pointArray[2].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11 - 2 * this.int_9 / 3;
                                    pointArray[2].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11;
                                    pointArray[3].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11;
                                    pointArray[3].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11;
                                    pointArray[4].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11;
                                    pointArray[4].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11 - 2 * this.int_9 / 3;
                                    pointArray[5].X = int_12 + this.int_9 + this.int_11 + 2 * this.int_9 / 3;
                                    pointArray[5].Y = int_13 + this.int_9 + this.int_11;
                                    break;
                                }
                            case 11:
                                {
                                    pointArray[0].X = int_12 + this.size_0.Width - this.int_9 - this.int_11;
                                    pointArray[0].Y = int_13 + this.int_9 + this.int_11;
                                    pointArray[1].X = int_12 + this.size_0.Width - this.int_9 - this.int_11;
                                    pointArray[1].Y = int_13 + this.int_9 + this.int_11 + 2 * this.int_9 / 3;
                                    pointArray[2].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11 + 2 * this.int_9 / 3;
                                    pointArray[2].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11;
                                    pointArray[3].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11;
                                    pointArray[3].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11;
                                    pointArray[4].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11;
                                    pointArray[4].Y = int_13 + this.size_0.Height / 2 - this.int_9 / 2 - this.int_11 - 2 * this.int_9 / 3;
                                    pointArray[5].X = int_12 + this.size_0.Width - this.int_9 - this.int_11 - 2 * this.int_9 / 3;
                                    pointArray[5].Y = int_13 + this.int_9 + this.int_11;
                                    break;
                                }
                            case 12:
                                {
                                    pointArray[0].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11;
                                    pointArray[0].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11;
                                    pointArray[1].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11;
                                    pointArray[1].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11 + 2 * this.int_9 / 3;
                                    pointArray[2].X = int_12 + this.int_9 + this.int_11 + 2 * this.int_9 / 3;
                                    pointArray[2].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                    pointArray[3].X = int_12 + this.int_9 + this.int_11;
                                    pointArray[3].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                    pointArray[4].X = int_12 + this.int_9 + this.int_11;
                                    pointArray[4].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11 - 2 * this.int_9 / 3;
                                    pointArray[5].X = int_12 + this.size_0.Width / 2 - this.int_9 / 2 - this.int_11 - 2 * this.int_9 / 3;
                                    pointArray[5].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11;
                                    break;
                                }
                            case 13:
                                {
                                    pointArray[0].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11;
                                    pointArray[0].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11;
                                    pointArray[1].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11;
                                    pointArray[1].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11 + 2 * this.int_9 / 3;
                                    pointArray[2].X = int_12 + this.size_0.Width - this.int_9 - this.int_11 - 2 * this.int_9 / 3;
                                    pointArray[2].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                    pointArray[3].X = int_12 + this.size_0.Width - this.int_9 - this.int_11;
                                    pointArray[3].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11;
                                    pointArray[4].X = int_12 + this.size_0.Width - this.int_9 - this.int_11;
                                    pointArray[4].Y = int_13 + this.size_0.Height - this.int_9 - this.int_11 - 2 * this.int_9 / 3;
                                    pointArray[5].X = int_12 + this.size_0.Width / 2 + this.int_9 / 2 + this.int_11 + 2 * this.int_9 / 3;
                                    pointArray[5].Y = int_13 + this.size_0.Height / 2 + this.int_9 / 2 + this.int_11;
                                    break;
                                }
                        }
                        graphics_0.FillPolygon(solidBrush, pointArray);
                        graphics_0.DrawPolygon(pen, pointArray);
                    }
                }
                num = num * (long)2;
            }
            solidBrush.Dispose();
            pen.Dispose();
        }

        private void method_2()
        {
            this.sortedList_0.Add("Key_0", (ulong)3102);
            this.sortedList_0.Add("Key_1", (ulong)12);
            this.sortedList_0.Add("Key_2", (ulong)2582);
            this.sortedList_0.Add("Key_3", (ulong)542);
            this.sortedList_0.Add("Key_4", (ulong)1548);
            this.sortedList_0.Add("Key_5", (ulong)1562);
            this.sortedList_0.Add("Key_6", (ulong)3610);
            this.sortedList_0.Add("Key_7", (ulong)14);
            this.sortedList_0.Add("Key_8", (ulong)3614);
            this.sortedList_0.Add("Key_9", (ulong)1566);
            this.sortedList_0.Add("Key_A", (ulong)975);
            this.sortedList_0.Add("Key_B", (ulong)3647);
            this.sortedList_0.Add("Key_C", (ulong)243);
            this.sortedList_0.Add("Key_D", (ulong)3135);
            this.sortedList_0.Add("Key_E", (ulong)1011);
            this.sortedList_0.Add("Key_F", (ulong)963);
            this.sortedList_0.Add("Key_G", (ulong)763);
            this.sortedList_0.Add("Key_H", (ulong)972);
            this.sortedList_0.Add("Key_I", (ulong)3123);
            this.sortedList_0.Add("Key_J", (ulong)124);
            this.sortedList_0.Add("Key_K", (ulong)41408);
            this.sortedList_0.Add("Key_L", (ulong)240);
            this.sortedList_0.Add("Key_M", (ulong)12492);
            this.sortedList_0.Add("Key_N", (ulong)37068);
            this.sortedList_0.Add("Key_O", (ulong)255);
            this.sortedList_0.Add("Key_P", (ulong)967);
            this.sortedList_0.Add("Key_Q", (ulong)33023);
            this.sortedList_0.Add("Key_R", (ulong)33735);
            this.sortedList_0.Add("Key_S", (ulong)955);
            this.sortedList_0.Add("Key_T", (ulong)3075);
            this.sortedList_0.Add("Key_U", (ulong)252);
            this.sortedList_0.Add("Key_V", (ulong)24768);
            this.sortedList_0.Add("Key_W", (ulong)49356);
            this.sortedList_0.Add("Key_X", (ulong)61440);
            this.sortedList_0.Add("Key_Y", (ulong)14336);
            this.sortedList_0.Add("Key_Z", (ulong)24627);
            this.sortedList_0.Add("Key_a", (ulong)2590);
            this.sortedList_0.Add("Key_b", (ulong)3608);
            this.sortedList_0.Add("Key_c", (ulong)2576);
            this.sortedList_0.Add("Key_d", (ulong)2588);
            this.sortedList_0.Add("Key_e", (ulong)3606);
            this.sortedList_0.Add("Key_f", (ulong)3842);
            this.sortedList_0.Add("Key_g", (ulong)1566);
            this.sortedList_0.Add("Key_h", (ulong)3592);
            this.sortedList_0.Add("Key_i", (ulong)3072);
            this.sortedList_0.Add("Key_j", (ulong)2076);
            this.sortedList_0.Add("Key_k", (ulong)44032);
            this.sortedList_0.Add("Key_l", (ulong)12);
            this.sortedList_0.Add("Key_m", (ulong)2888);
            this.sortedList_0.Add("Key_n", (ulong)2568);
            this.sortedList_0.Add("Key_o", (ulong)2584);
            this.sortedList_0.Add("Key_p", (ulong)3590);
            this.sortedList_0.Add("Key_q", (ulong)1550);
            this.sortedList_0.Add("Key_r", (ulong)2560);
            this.sortedList_0.Add("Key_s", (ulong)1562);
            this.sortedList_0.Add("Key_t", (ulong)3856);
            this.sortedList_0.Add("Key_u", (ulong)2072);
            this.sortedList_0.Add("Key_v", (ulong)16448);
            this.sortedList_0.Add("Key_w", (ulong)49224);
            this.sortedList_0.Add("Key_x", (ulong)61440);
            this.sortedList_0.Add("Key_y", (ulong)28672);
            this.sortedList_0.Add("Key_z", (ulong)16672);
            this.sortedList_0.Add("Key_QuestionM", (ulong)2695);
            this.sortedList_0.Add("Key_Percentage", (ulong)28569);
            this.sortedList_0.Add("Key_Dollar", (ulong)4027);
            this.sortedList_0.Add("Key_Star", (ulong)65280);
            this.sortedList_0.Add("Key_LeftP", (ulong)225);
            this.sortedList_0.Add("Key_RightP", (ulong)30);
            this.sortedList_0.Add("Key_Plus", (ulong)3840);
            this.sortedList_0.Add("Key_Minus", (ulong)768);
            this.sortedList_0.Add("Key_Divide", (ulong)24576);
            this.sortedList_0.Add("Key_Equal", (ulong)816);
            this.sortedList_0.Add("Key_Greater", (ulong)20480);
            this.sortedList_0.Add("Key_Less", (ulong)40960);
            this.sortedList_1.Add("Key_0", (ulong)6207);
            this.sortedList_1.Add("Key_1", (ulong)6);
            this.sortedList_1.Add("Key_2", (ulong)219);
            this.sortedList_1.Add("Key_3", (ulong)143);
            this.sortedList_1.Add("Key_4", (ulong)230);
            this.sortedList_1.Add("Key_5", (ulong)8297);
            this.sortedList_1.Add("Key_6", (ulong)253);
            this.sortedList_1.Add("Key_7", (ulong)7);
            this.sortedList_1.Add("Key_8", (ulong)255);
            this.sortedList_1.Add("Key_9", (ulong)239);
            this.sortedList_1.Add("Key_A", (ulong)247);
            this.sortedList_1.Add("Key_B", (ulong)911);
            this.sortedList_1.Add("Key_C", (ulong)57);
            this.sortedList_1.Add("Key_D", (ulong)783);
            this.sortedList_1.Add("Key_E", (ulong)249);
            this.sortedList_1.Add("Key_F", (ulong)113);
            this.sortedList_1.Add("Key_G", (ulong)189);
            this.sortedList_1.Add("Key_H", (ulong)246);
            this.sortedList_1.Add("Key_I", (ulong)768);
            this.sortedList_1.Add("Key_J", (ulong)30);
            this.sortedList_1.Add("Key_K", (ulong)10352);
            this.sortedList_1.Add("Key_L", (ulong)56);
            this.sortedList_1.Add("Key_M", (ulong)3126);
            this.sortedList_1.Add("Key_N", (ulong)9270);
            this.sortedList_1.Add("Key_O", (ulong)63);
            this.sortedList_1.Add("Key_P", (ulong)243);
            this.sortedList_1.Add("Key_Q", (ulong)8255);
            this.sortedList_1.Add("Key_R", (ulong)8435);
            this.sortedList_1.Add("Key_S", (ulong)237);
            this.sortedList_1.Add("Key_T", (ulong)769);
            this.sortedList_1.Add("Key_U", (ulong)62);
            this.sortedList_1.Add("Key_V", (ulong)6192);
            this.sortedList_1.Add("Key_W", (ulong)12342);
            this.sortedList_1.Add("Key_X", (ulong)15360);
            this.sortedList_1.Add("Key_Y", (ulong)3584);
            this.sortedList_1.Add("Key_Z", (ulong)6153);
            this.sortedList_1.Add("Key_a", (ulong)223);
            this.sortedList_1.Add("Key_b", (ulong)252);
            this.sortedList_1.Add("Key_c", (ulong)216);
            this.sortedList_1.Add("Key_d", (ulong)222);
            this.sortedList_1.Add("Key_e", (ulong)251);
            this.sortedList_1.Add("Key_f", (ulong)113);
            this.sortedList_1.Add("Key_g", (ulong)239);
            this.sortedList_1.Add("Key_h", (ulong)244);
            this.sortedList_1.Add("Key_i", (ulong)768);
            this.sortedList_1.Add("Key_j", (ulong)8198);
            this.sortedList_1.Add("Key_k", (ulong)11008);
            this.sortedList_1.Add("Key_l", (ulong)6);
            this.sortedList_1.Add("Key_m", (ulong)724);
            this.sortedList_1.Add("Key_n", (ulong)644);
            this.sortedList_1.Add("Key_o", (ulong)220);
            this.sortedList_1.Add("Key_p", (ulong)243);
            this.sortedList_1.Add("Key_q", (ulong)231);
            this.sortedList_1.Add("Key_r", (ulong)640);
            this.sortedList_1.Add("Key_s", (ulong)237);
            this.sortedList_1.Add("Key_t", (ulong)385);
            this.sortedList_1.Add("Key_u", (ulong)28);
            this.sortedList_1.Add("Key_v", (ulong)4112);
            this.sortedList_1.Add("Key_w", (ulong)12308);
            this.sortedList_1.Add("Key_x", (ulong)15360);
            this.sortedList_1.Add("Key_y", (ulong)7168);
            this.sortedList_1.Add("Key_z", (ulong)6153);
            this.sortedList_1.Add("Key_QuestionM", (ulong)675);
            this.sortedList_1.Add("Key_Percentage", (ulong)15588);
            this.sortedList_1.Add("Key_Dollar", (ulong)1005);
            this.sortedList_1.Add("Key_Star", (ulong)16320);
            this.sortedList_1.Add("Key_LeftP", (ulong)57);
            this.sortedList_1.Add("Key_RightP", (ulong)15);
            this.sortedList_1.Add("Key_Plus", (ulong)960);
            this.sortedList_1.Add("Key_Minus", (ulong)192);
            this.sortedList_1.Add("Key_Divide", (ulong)6144);
            this.sortedList_1.Add("Key_Equal", (ulong)200);
            this.sortedList_1.Add("Key_Greater", (ulong)5120);
            this.sortedList_1.Add("Key_Less", (ulong)10240);
        }

        private void method_3()
        {
            this.icontainer_0 = new System.ComponentModel.Container();
        }

        public void ResetCustomizedLEDSecondValue(bool bUIUpdate)
        {
            this.arrayList_1.Clear();
            if (bUIUpdate)
            {
                base.Invalidate();
            }
        }

        public void ResetCustomizedLEDValue(bool bUIUpdate)
        {
            this.arrayList_0.Clear();
            if (bUIUpdate)
            {
                base.Invalidate();
            }
        }

        protected override void Dispose(bool bool_9)
        {
            if (bool_9 && this.icontainer_0 != null)
            {
                this.icontainer_0.Dispose();
            }
            base.Dispose(bool_9);
        }

        protected override void OnPaint(PaintEventArgs paintEventArgs_0)
        {
            int i;
            SizeF sizeF;
            int height;
            try
            {
                base.OnPaint(paintEventArgs_0);
                if (this.das_BorderGradientStyle_0 == DAS_BorderGradientStyle.BGS_None || base.ClientRectangle.Width - 2 * (this.int_0 + this.int_1 + this.int_4 + this.int_2) > 0 && base.ClientRectangle.Height - 2 * (this.int_0 + this.int_1 + this.int_4 + this.int_2) > 0)
                {
                    DrawGraphics _DrawGraphics = new DrawGraphics();
                    int left = base.ClientRectangle.Left;
                    int top = base.ClientRectangle.Top;
                    Rectangle clientRectangle = base.ClientRectangle;
                    int width = clientRectangle.Width - 2;
                    clientRectangle = base.ClientRectangle;
                    Rectangle rectangle = new Rectangle(left, top, width, clientRectangle.Height - 2);
                    paintEventArgs_0.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    paintEventArgs_0.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                    SolidBrush solidBrush = new SolidBrush(base.Parent.BackColor);
                    paintEventArgs_0.Graphics.FillRectangle(solidBrush, base.ClientRectangle);
                    Pen pen = new Pen(solidBrush);
                    paintEventArgs_0.Graphics.DrawRectangle(pen, base.ClientRectangle);
                    pen.Dispose();
                    solidBrush.Dispose();
                    if (this.bool_2 && this.int_7 > 0 && this.int_7 < rectangle.Width / 3 && this.int_7 < rectangle.Height / 3 && this.das_BorderGradientStyle_0 != DAS_BorderGradientStyle.BGS_None)
                    {
                        rectangle.Width = rectangle.Width - this.int_7;
                        rectangle.Height = rectangle.Height - this.int_7;
                    }
                    Rectangle x = new Rectangle(rectangle.Left + this.int_0 + this.int_1 + this.int_4 + this.int_2, rectangle.Top + this.int_0 + this.int_1 + this.int_4 + this.int_2, rectangle.Width - 2 * (this.int_0 + this.int_1 + this.int_4 + this.int_2), rectangle.Height - 2 * (this.int_0 + this.int_1 + this.int_4 + this.int_2));
                    if (this.das_BorderGradientStyle_0 == DAS_BorderGradientStyle.BGS_None)
                    {
                        x.X = rectangle.X;
                        x.Y = rectangle.Y;
                        x.Width = rectangle.Width;
                        x.Height = rectangle.Height;
                    }
                    else
                    {
                        if (this.BackgroundImage != null)
                        {
                            if (this.BackgroundImageLayout == ImageLayout.Center)
                            {
                                PointF pointF = new PointF()
                                {
                                    X = (float)x.Left + (float)(x.Width - this.BackgroundImage.Width) / 2f,
                                    Y = (float)x.Top + (float)(x.Height - this.BackgroundImage.Height) / 2f
                                };
                                paintEventArgs_0.Graphics.DrawImage(this.BackgroundImage, pointF);
                            }
                            else if (this.BackgroundImageLayout == ImageLayout.None)
                            {
                                PointF pointF1 = new PointF()
                                {
                                    X = (float)x.Left,
                                    Y = (float)x.Top
                                };
                                paintEventArgs_0.Graphics.DrawImage(this.BackgroundImage, pointF1);
                            }
                            else if (this.BackgroundImageLayout == ImageLayout.Stretch)
                            {
                                paintEventArgs_0.Graphics.DrawImage(this.BackgroundImage, x);
                            }
                            else if (this.BackgroundImageLayout == ImageLayout.Zoom)
                            {
                                float single = (float)x.Width;
                                float height1 = (float)this.BackgroundImage.Height / (float)this.BackgroundImage.Width * single;
                                if (height1 > (float)x.Height)
                                {
                                    height1 = (float)x.Height;
                                    single = (float)this.BackgroundImage.Width / (float)this.BackgroundImage.Height * height1;
                                }
                                RectangleF rectangleF = new RectangleF((float)x.Left + ((float)x.Width - single) / 2f, (float)x.Top + ((float)x.Height - height1) / 2f, single, height1);
                                paintEventArgs_0.Graphics.DrawImage(this.BackgroundImage, rectangleF);
                            }
                            else if (this.BackgroundImageLayout == ImageLayout.Tile)
                            {
                                TextureBrush textureBrush = new TextureBrush(this.BackgroundImage);
                                paintEventArgs_0.Graphics.FillRectangle(textureBrush, x);
                                textureBrush.Dispose();
                            }
                        }
                        int float4 = 255;
                        if ((double)this.float_4 > 0)
                        {
                            float4 = 255 - (int)(255f * this.float_4);
                        }
                        Color color = Color.FromArgb(float4, this.BackColor);
                        Color color1 = Color.FromArgb(float4, this.color_6);
                        x.X = x.X - 1;
                        x.Y = x.Y - 1;
                        x.Width = x.Width + 2;
                        x.Height = x.Height + 2;
                        if (!this.bool_1)
                        {
                            SolidBrush solidBrush1 = new SolidBrush(color);
                            paintEventArgs_0.Graphics.FillRectangle(solidBrush1, x);
                            solidBrush1.Dispose();
                        }
                        else
                        {
                            _DrawGraphics.method_2(paintEventArgs_0.Graphics, x, this.das_BorderStyle_0, null, color, color1, this.das_BkGradientStyle_0, this.int_6, this.float_5, this.int_3, this.float_6);
                        }
                        x.X = x.X + 1;
                        x.Y = x.Y + 1;
                        x.Width = x.Width - 2;
                        x.Height = x.Height - 2;
                    }
                    RectangleF right = new RectangleF();
                    StringFormat stringFormat = new StringFormat();
                    int int10 = this.int_10;
                    int num = (x.Top + x.Bottom) / 2 + this.point_0.Y;
                    int x1 = int10 - this.point_0.X;
                    Color color10 = this.color_10;
                    Color color11 = this.color_11;
                    if ((double)this.float_8 > 0)
                    {
                        int float8 = 255;
                        float8 = 255 - (int)(255f * this.float_8);
                        color10 = Color.FromArgb(float8, this.color_10);
                        color11 = Color.FromArgb(float8, this.color_11);
                    }
                    Pen pen1 = new Pen(color11);
                    SolidBrush color9 = new SolidBrush(this.ForeColor);
                    if (this.bool_4 && this.bool_8)
                    {
                        color9.Color = color10;
                    }
                    if (this.string_0 != string.Empty && this.bool_3)
                    {
                        sizeF = paintEventArgs_0.Graphics.MeasureString(this.string_0, this.Font);
                        right.X = (float)(x.Right - x1) - sizeF.Width;
                        right.Width = sizeF.Width;
                        right.Y = (float)(num + this.size_0.Height / 2) - sizeF.Height;
                        right.Height = sizeF.Height;
                        stringFormat.LineAlignment = StringAlignment.Far;
                        stringFormat.Alignment = StringAlignment.Center;
                        paintEventArgs_0.Graphics.DrawString(this.string_0, this.Font, color9, right, stringFormat);
                        x1 = (int)((float)x1 + sizeF.Width + (float)(int10 / 2));
                    }
                    int int9 = x.Right - x1;
                    int num1 = 0;
                    if (this.das_LEDSegmentLookupStyle_0 != DAS_LEDSegmentLookupStyle.LSLS_Standard)
                    {
                        for (i = 0; i < this.arrayList_0.Count; i++)
                        {
                            if (Convert.ToUInt32(this.arrayList_0[i]) != 0)
                            {
                                int9 = int9 - this.size_0.Width;
                                height = num - this.size_0.Height / 2;
                                if (!this.bool_5)
                                {
                                    this.method_0(paintEventArgs_0.Graphics, int9, height, string.Empty, (ulong)Convert.ToUInt32(this.arrayList_0[i]), this.ForeColor, false);
                                }
                                else
                                {
                                    this.method_1(paintEventArgs_0.Graphics, int9, height, string.Empty, (ulong)Convert.ToUInt32(this.arrayList_0[i]), this.ForeColor, false);
                                }
                                int9 = int9 - int10;
                                num1++;
                            }
                        }
                    }
                    else
                    {
                        bool flag = false;
                        bool flag1 = false;
                        for (i = this.string_1.Length - 1; i >= 0; i--)
                        {
                            if (this.string_1.Substring(i, 1) != "\"")
                            {
                                string str = string.Concat("Key_", this.string_1.Substring(i, 1));
                                if (!this.sortedList_0.ContainsKey(str) || flag)
                                {
                                    string str1 = "?";
                                    string str2 = "$";
                                    string str3 = "%";
                                    string str4 = "*";
                                    string str5 = "[";
                                    string str6 = "]";
                                    string str7 = "+";
                                    string str8 = "-";
                                    string str9 = "/";
                                    string str10 = "=";
                                    string str11 = ">";
                                    string str12 = "<";
                                    str = "Key";
                                    if (this.string_1.Substring(i, 1) == str1)
                                    {
                                        str = "Key_QuestionM";
                                    }
                                    else if (this.string_1.Substring(i, 1) == str2)
                                    {
                                        str = "Key_Dollar";
                                    }
                                    else if (this.string_1.Substring(i, 1) == str3)
                                    {
                                        str = "Key_Percentage";
                                    }
                                    else if (this.string_1.Substring(i, 1) == str4)
                                    {
                                        str = "Key_Star";
                                    }
                                    else if (this.string_1.Substring(i, 1) == str5)
                                    {
                                        str = "Key_LeftP";
                                    }
                                    else if (this.string_1.Substring(i, 1) == str6)
                                    {
                                        str = "Key_RightP";
                                    }
                                    else if (this.string_1.Substring(i, 1) == str7)
                                    {
                                        str = "Key_Plus";
                                    }
                                    else if (this.string_1.Substring(i, 1) == str8)
                                    {
                                        str = "Key_Minus";
                                    }
                                    else if (this.string_1.Substring(i, 1) == str9)
                                    {
                                        str = "Key_Divide";
                                    }
                                    else if (this.string_1.Substring(i, 1) == str10)
                                    {
                                        str = "Key_Equal";
                                    }
                                    else if (this.string_1.Substring(i, 1) == str11)
                                    {
                                        str = "Key_Greater";
                                    }
                                    else if (this.string_1.Substring(i, 1) == str12)
                                    {
                                        str = "Key_Less";
                                    }
                                    if (this.sortedList_0.ContainsKey(str) && !flag)
                                    {
                                        int9 = int9 - int10 - this.size_0.Width;
                                        height = num - this.size_0.Height / 2;
                                        if (!this.bool_5)
                                        {
                                            this.method_0(paintEventArgs_0.Graphics, int9, height, str, (ulong)0, this.ForeColor, false);
                                        }
                                        else
                                        {
                                            this.method_1(paintEventArgs_0.Graphics, int9, height, str, (ulong)0, this.ForeColor, false);
                                        }
                                        num1++;
                                        flag1 = false;
                                    }
                                    else if (!(this.string_1.Substring(i, 1) == ".") || flag)
                                    {
                                        SolidBrush solidBrush2 = new SolidBrush(this.color_8);
                                        sizeF = paintEventArgs_0.Graphics.MeasureString(this.string_1.Substring(i, 1), this.Font);
                                        int9 = (flag1 ? (int)((float)int9 - sizeF.Width) : (int)((float)int9 - sizeF.Width - (float)int10));
                                        right.X = (float)int9;
                                        right.Width = sizeF.Width;
                                        right.Y = (float)num - sizeF.Height / 2f;
                                        right.Height = sizeF.Height;
                                        stringFormat.LineAlignment = StringAlignment.Center;
                                        stringFormat.Alignment = StringAlignment.Center;
                                        paintEventArgs_0.Graphics.DrawString(this.string_1.Substring(i, 1), this.Font, solidBrush2, right, stringFormat);
                                        flag1 = true;
                                        solidBrush2.Dispose();
                                    }
                                    else
                                    {
                                        Rectangle int91 = new Rectangle();
                                        int9 = int9 - int10 - this.int_9;
                                        int91.X = int9;
                                        int91.Width = this.int_9;
                                        int91.Y = num + this.size_0.Height / 2 - this.int_9;
                                        int91.Height = this.int_9;
                                        paintEventArgs_0.Graphics.FillRectangle(color9, int91);
                                        paintEventArgs_0.Graphics.DrawRectangle(pen1, int91);
                                        flag1 = false;
                                    }
                                }
                                else
                                {
                                    int9 = int9 - int10 - this.size_0.Width;
                                    height = num - this.size_0.Height / 2;
                                    if (!this.bool_5)
                                    {
                                        this.method_0(paintEventArgs_0.Graphics, int9, height, str, (ulong)0, this.ForeColor, false);
                                    }
                                    else
                                    {
                                        this.method_1(paintEventArgs_0.Graphics, int9, height, str, (ulong)0, this.ForeColor, false);
                                    }
                                    num1++;
                                    flag1 = false;
                                }
                            }
                            else
                            {
                                flag = !flag;
                            }
                        }
                    }
                    if (this.bool_6 && this.string_2 != string.Empty)
                    {
                        num = (x.Top + x.Bottom) / 2 + this.point_1.Y;
                        x1 = int10 + this.point_1.X;
                        color9.Color = this.color_9;
                        if (this.bool_4 && this.bool_8)
                        {
                            color9.Color = color10;
                        }
                        int9 = x.Left + x1;
                        num1 = 0;
                        if (this.das_LEDSegmentLookupStyle_0 != DAS_LEDSegmentLookupStyle.LSLS_Standard)
                        {
                            for (i = this.arrayList_1.Count - 1; i >= 0; i--)
                            {
                                if (Convert.ToUInt32(this.arrayList_1[i]) != 0)
                                {
                                    height = num - this.size_0.Height / 2;
                                    if (!this.bool_5)
                                    {
                                        this.method_0(paintEventArgs_0.Graphics, int9, height, string.Empty, (ulong)Convert.ToUInt32(this.arrayList_0[i]), this.color_9, false);
                                    }
                                    else
                                    {
                                        this.method_1(paintEventArgs_0.Graphics, int9, height, string.Empty, (ulong)Convert.ToUInt32(this.arrayList_0[i]), this.color_9, false);
                                    }
                                    int9 = int9 + this.size_0.Width + int10;
                                    num1++;
                                }
                            }
                        }
                        else
                        {
                            bool flag2 = false;
                            bool flag3 = false;
                            for (i = 0; i < this.string_2.Length; i++)
                            {
                                if (this.string_2.Substring(i, 1) != "\"")
                                {
                                    string str13 = string.Concat("Key_", this.string_2.Substring(i, 1));
                                    if (!this.sortedList_0.ContainsKey(str13) || flag2)
                                    {
                                        string str14 = "?";
                                        string str15 = "$";
                                        string str16 = "%";
                                        string str17 = "*";
                                        string str18 = "[";
                                        string str19 = "]";
                                        string str20 = "+";
                                        string str21 = "-";
                                        string str22 = "/";
                                        string str23 = "=";
                                        string str24 = ">";
                                        string str25 = "<";
                                        str13 = "Key";
                                        if (this.string_2.Substring(i, 1) == str14)
                                        {
                                            str13 = "Key_QuestionM";
                                        }
                                        else if (this.string_2.Substring(i, 1) == str15)
                                        {
                                            str13 = "Key_Dollar";
                                        }
                                        else if (this.string_2.Substring(i, 1) == str16)
                                        {
                                            str13 = "Key_Percentage";
                                        }
                                        else if (this.string_2.Substring(i, 1) == str17)
                                        {
                                            str13 = "Key_Star";
                                        }
                                        else if (this.string_2.Substring(i, 1) == str18)
                                        {
                                            str13 = "Key_LeftP";
                                        }
                                        else if (this.string_2.Substring(i, 1) == str19)
                                        {
                                            str13 = "Key_RightP";
                                        }
                                        else if (this.string_2.Substring(i, 1) == str20)
                                        {
                                            str13 = "Key_Plus";
                                        }
                                        else if (this.string_2.Substring(i, 1) == str21)
                                        {
                                            str13 = "Key_Minus";
                                        }
                                        else if (this.string_2.Substring(i, 1) == str22)
                                        {
                                            str13 = "Key_Divide";
                                        }
                                        else if (this.string_2.Substring(i, 1) == str23)
                                        {
                                            str13 = "Key_Equal";
                                        }
                                        else if (this.string_2.Substring(i, 1) == str24)
                                        {
                                            str13 = "Key_Greater";
                                        }
                                        else if (this.string_2.Substring(i, 1) == str25)
                                        {
                                            str13 = "Key_Less";
                                        }
                                        if (this.sortedList_0.ContainsKey(str13) && !flag2)
                                        {
                                            int9 = int9 + int10;
                                            height = num - this.size_0.Height / 2;
                                            if (!this.bool_5)
                                            {
                                                this.method_0(paintEventArgs_0.Graphics, int9, height, str13, (ulong)0, this.color_9, false);
                                            }
                                            else
                                            {
                                                this.method_1(paintEventArgs_0.Graphics, int9, height, str13, (ulong)0, this.color_9, false);
                                            }
                                            num1++;
                                            flag3 = false;
                                            int9 = int9 + this.size_0.Width;
                                        }
                                        else if (!(this.string_2.Substring(i, 1) == ".") || flag2)
                                        {
                                            SolidBrush solidBrush3 = new SolidBrush(this.color_8);
                                            sizeF = paintEventArgs_0.Graphics.MeasureString(this.string_2.Substring(i, 1), this.Font);
                                            if (!flag3)
                                            {
                                                int9 = int9 + int10;
                                            }
                                            right.X = (float)int9;
                                            right.Width = sizeF.Width;
                                            right.Y = (float)num - sizeF.Height / 2f;
                                            right.Height = sizeF.Height;
                                            stringFormat.LineAlignment = StringAlignment.Center;
                                            stringFormat.Alignment = StringAlignment.Center;
                                            paintEventArgs_0.Graphics.DrawString(this.string_2.Substring(i, 1), this.Font, solidBrush3, right, stringFormat);
                                            flag3 = true;
                                            int9 = (int)((float)int9 + sizeF.Width);
                                            solidBrush3.Dispose();
                                        }
                                        else
                                        {
                                            Rectangle rectangle1 = new Rectangle();
                                            int9 = int9 + int10;
                                            rectangle1.X = int9;
                                            rectangle1.Width = this.int_9;
                                            rectangle1.Y = num + this.size_0.Height / 2 - this.int_9;
                                            rectangle1.Height = this.int_9;
                                            paintEventArgs_0.Graphics.FillRectangle(color9, rectangle1);
                                            paintEventArgs_0.Graphics.DrawRectangle(pen1, rectangle1);
                                            flag3 = false;
                                            int9 = int9 + this.int_9;
                                        }
                                    }
                                    else
                                    {
                                        int9 = int9 + int10;
                                        height = num - this.size_0.Height / 2;
                                        if (!this.bool_5)
                                        {
                                            this.method_0(paintEventArgs_0.Graphics, int9, height, str13, (ulong)0, this.color_9, false);
                                        }
                                        else
                                        {
                                            this.method_1(paintEventArgs_0.Graphics, int9, height, str13, (ulong)0, this.color_9, false);
                                        }
                                        num1++;
                                        int9 = int9 + this.size_0.Width;
                                        flag3 = false;
                                    }
                                }
                                else
                                {
                                    flag2 = !flag2;
                                }
                            }
                        }
                    }
                    color9.Dispose();
                    pen1.Dispose();
                    if (this.das_BorderStyle_0 == DAS_BorderStyle.BS_RoundRect)
                    {
                        System.Drawing.Region region = new System.Drawing.Region(base.ClientRectangle);
                        GraphicsPath graphicsPath = new GraphicsPath();
                        _DrawGraphics.method_3(graphicsPath, x, this.int_3 - this.int_0 - this.int_1 - this.int_4 - this.int_2);
                        region.Exclude(graphicsPath);
                        SolidBrush solidBrush4 = new SolidBrush(base.Parent.BackColor);
                        paintEventArgs_0.Graphics.FillRegion(solidBrush4, region);
                        solidBrush4.Dispose();
                        graphicsPath.Dispose();
                        region.Dispose();
                    }
                    if (this.bool_2 && this.int_7 > 0 && this.int_7 < rectangle.Width / 3 && this.int_7 < rectangle.Height / 3 && this.das_BorderGradientStyle_0 != DAS_BorderGradientStyle.BGS_None)
                    {
                        rectangle.X = rectangle.X + this.int_7;
                        rectangle.Y = rectangle.Y + this.int_7;
                        GraphicsPath graphicsPath1 = new GraphicsPath();
                        if (this.das_BorderStyle_0 != DAS_BorderStyle.BS_RoundRect)
                        {
                            _DrawGraphics.method_3(graphicsPath1, rectangle, 5);
                        }
                        else
                        {
                            _DrawGraphics.method_3(graphicsPath1, rectangle, this.int_3);
                        }
                        rectangle.X = rectangle.X - this.int_7;
                        rectangle.Y = rectangle.Y - this.int_7;
                        GraphicsPath graphicsPath2 = new GraphicsPath();
                        if (this.das_BorderStyle_0 != DAS_BorderStyle.BS_RoundRect)
                        {
                            _DrawGraphics.method_3(graphicsPath2, rectangle, 5);
                        }
                        else
                        {
                            _DrawGraphics.method_3(graphicsPath2, rectangle, this.int_3);
                        }
                        System.Drawing.Region region1 = new System.Drawing.Region(graphicsPath1);
                        System.Drawing.Region region2 = new System.Drawing.Region(graphicsPath1);
                        region2.Intersect(graphicsPath2);
                        region1.Xor(region2);
                        paintEventArgs_0.Graphics.SetClip(region1, CombineMode.Replace);
                        _DrawGraphics.method_4(paintEventArgs_0.Graphics, rectangle, graphicsPath2, this.color_7, this.int_7, this.float_7);
                        paintEventArgs_0.Graphics.ResetClip();
                        region2.Dispose();
                        region1.Dispose();
                        graphicsPath2.Dispose();
                        graphicsPath1.Dispose();
                    }
                    if (this.das_BorderStyle_0 != DAS_BorderStyle.BS_RoundRect)
                    {
                        _DrawGraphics.method_0(paintEventArgs_0.Graphics, rectangle, this.int_1, this.color_1, this.color_2, this.int_4, this.color_5, this.int_2, this.color_3, this.color_4, this.int_0, this.color_0, this.das_BorderGradientStyle_0, this.int_5, this.float_0, this.float_1, this.float_2, this.float_3);
                    }
                    else
                    {
                        _DrawGraphics.method_1(paintEventArgs_0.Graphics, rectangle, this.int_3, this.int_1, this.color_1, this.color_2, this.int_4, this.color_5, this.int_2, this.color_3, this.color_4, this.int_0, this.color_0, this.das_BorderGradientStyle_0, (long)this.int_5, this.float_0, this.float_1, this.float_2, this.float_3);
                    }
                    if (this.bool_0)
                    {
                        SolidBrush solidBrush5 = new SolidBrush(Color.Red);
                        StringFormat stringFormat1 = new StringFormat()
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        };
                        paintEventArgs_0.Graphics.DrawString("Trial Period Expires !!!!", this.Font, solidBrush5, base.ClientRectangle, stringFormat1);
                        solidBrush5.Dispose();
                    }
                }
            }
            catch (ApplicationException applicationException)
            {
                MessageBox.Show(applicationException.ToString());
            }
        }

        private void timer_0_Tick(object sender, EventArgs e)
        {
            this.bool_0 = true;
            this.timer_0.Enabled = false;
        }

        private void timer_1_Tick(object sender, EventArgs e)
        {
            this.bool_8 = !this.bool_8;
            base.Invalidate();
        }
    }
}
