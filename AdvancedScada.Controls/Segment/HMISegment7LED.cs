using AdvancedScada.Controls;
using AdvancedScada.Controls.DialogEditor;
using AdvancedScada.Controls.Enum;
using AdvancedScada.Controls.Keyboard;
using AdvancedScada.Controls.Licenses;
using AdvancedScada.Controls.Segment.DrawAll;
using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Client;
using AdvancedScada.Monitor;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace AdvancedScada.Controls.Segment
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(HMISegment7LED), "HMI7Segment.ico")]
    [Designer(typeof(HMI_Segment7LEDDesigner))]
    public class HMISegment7LED : Control
    {


        private DAS_BorderStyle das_BorderStyle_0;

        private int int_0;

        private Color color_0 = Color.Blue;

        private int int_1 = 5;

        private int int_2 = 5;

        private Color color_1 = Color.DarkGray;

        private Color color_2 = Color.Lavender;

        private Color color_3 = Color.DarkGray;

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

        private int int_8;

        private DAS_DisplayStyle das_DisplayStyle_0 = DAS_DisplayStyle.DS_Dec_Style;

        private string string_0 = string.Empty;

        private bool bool_3;

        private bool bool_4;

        private int int_9 = 1000;

        private double double_0 = 888;

        private DateTime dateTime_0 = DateTime.Now;

        private bool m_AllZeroVisible;

        private bool bool_6 = true;

        private DAS_SegmentStyle das_SegmentStyle_0;

        private int int_10 = 8;

        private System.Drawing.Size size_0 = new Size(20, 40);

        private int int_11 = 4;

        private bool bool_7 = true;

        private Color color_8 = Color.DimGray;

        private Color color_9 = Color.Black;

        private bool bool_8;

        private int int_12 = 10;

        private float float_8 = 0.5f;

        private bool[,] bool_9 = new bool[,] { { true, false, true, true, false, true, true, true, true, true, true, false, true, false, true, true }, { true, true, true, true, true, false, false, true, true, true, true, false, false, true, false, false }, { true, true, false, true, true, true, true, true, true, true, true, true, false, true, false, false }, { true, false, true, true, false, true, true, false, true, true, false, true, true, true, true, false }, { true, false, true, false, false, false, true, false, true, false, true, true, true, true, true, true }, { true, false, false, false, true, true, true, false, true, true, true, true, true, false, true, true }, { false, false, true, true, true, true, true, false, true, true, true, true, false, true, true, true } };

        private bool bool_10 = true;

        private Timer timer_1 = new Timer();

        [Category("General")]
        [DefaultValue("false")]
        [Description("Get/Set whether to show all zero digits")]
        public bool AllZeroVisible
        {
            get
            {
                return this.m_AllZeroVisible;
            }
            set
            {
                this.m_AllZeroVisible = value;
                base.Invalidate();
            }
        }

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

        [Category("Segment")]
        [DefaultValue("10")]
        [Description("Get/Set the gap between the digits ")]
        public int DigitGap
        {
            get
            {
                return this.int_12;
            }
            set
            {
                if (value >= 2)
                {
                    this.int_12 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Segment")]
        [DefaultValue("false")]
        [Description("Get/Set whether Digits are drawn inclined or not")]
        public bool DigitInclined
        {
            get
            {
                return this.bool_8;
            }
            set
            {
                this.bool_8 = value;
                base.Invalidate();
            }
        }

        [Category("Segment")]
        [DefaultValue("8")]
        [Description("Get/Set how many digits the control supports")]
        public int DigitNumber
        {
            get
            {
                return this.int_10;
            }
            set
            {
                this.int_10 = value;
                base.Invalidate();
            }
        }

        [Category("Segment")]
        [DefaultValue("(20,40)")]
        [Description("Get/Set the size of each digit")]
        public System.Drawing.Size DigitSize
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

        [Category("General")]
        [DefaultValue("DAS_DisplayStyle.DS_Dec_Style")]
        [Description("Get/Set the content display style")]
        public DAS_DisplayStyle DisplayType
        {
            get
            {
                return this.das_DisplayStyle_0;
            }
            set
            {
                this.das_DisplayStyle_0 = value;
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
                this.timer_1.Interval = this.int_9;
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
                return this.int_9;
            }
            set
            {
                this.int_9 = value;
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
        [DefaultValue("5")]
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

        [Category("General")]
        [DefaultValue("DateTime.Now")]
        [Description("Get/Set the LED DateTime value")]
        public DateTime LEDDateTime
        {
            get
            {
                return this.dateTime_0;
            }
            set
            {
                this.dateTime_0 = value;
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

        [Category("General")]
        [DefaultValue("0")]
        [Description("Get/Set the precision of the shown value ")]
        public int Precision
        {
            get
            {
                return this.int_8;
            }
            set
            {
                if (value >= 0)
                {
                    this.int_8 = value;
                    base.Invalidate();
                }
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

        [Category("Segment")]
        [DefaultValue("Color.Black")]
        [Description("Get/Set the border color of each segment")]
        public Color SegmentBorderColor
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

        [Category("Segment")]
        [DefaultValue("Color.DimGray")]
        [Description("Get/Set the frame color of each segment")]
        public Color SegmentFrameColor
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
        [DefaultValue("DAS_SegmentStyle.SS_Ladder")]
        [Description("Get/Set the shape type of the segment")]
        public DAS_SegmentStyle SegmentType
        {
            get
            {
                return this.das_SegmentStyle_0;
            }
            set
            {
                this.das_SegmentStyle_0 = value;
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
                return this.int_11;
            }
            set
            {
                this.int_11 = value;
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
        [DefaultValue("true")]
        [Description("Get/Set whether to show the sign of the LED value")]
        public bool SignVisible
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
        [DefaultValue("888.0")]
        [Description("Get/Set the LED value")]
        public double Value
        {
            get
            {
                return this.double_0;
            }
            set
            {
                this.double_0 = value;
                base.Invalidate();
            }
        }

        public HMISegment7LED()
        {

            this.BackColor = Color.FromArgb(50, 50, 50);
            this.ForeColor = Color.Lime;
            base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            base.SetStyle(ControlStyles.Opaque, true);

        }


        private void method_1(Graphics graphics_0, int int_13, int int_14, int int_15, bool bool_11)
        {
            int i = 0;
            int num = 0;
            if (this.bool_8)
            {
                num = 2;
            }
            Color foreColor = this.ForeColor;
            Color color8 = this.color_8;
            Color color9 = this.color_9;
            int float8 = 255;
            if ((double)this.float_8 > 0)
            {
                float8 = 255 - (int)(255f * this.float_8);
                color8 = Color.FromArgb(float8, this.color_8);
                color9 = Color.FromArgb(float8, this.color_9);
            }
            if (this.bool_4 && this.bool_10)
            {
                foreColor = color8;
            }
            Pen pen = new Pen(color9);
            SolidBrush solidBrush = new SolidBrush(foreColor);
            for (i = 0; i < 7; i++)
            {
                if (this.bool_9[i, int_15] && (this.bool_7 || !bool_11) || !this.bool_9[i, int_15] && this.bool_7)
                {
                    if (!this.bool_9[i, int_15] || bool_11)
                    {
                        solidBrush.Color = color8;
                    }
                    else
                    {
                        solidBrush.Color = foreColor;
                    }
                    if (this.das_SegmentStyle_0 == DAS_SegmentStyle.SS_Ladder)
                    {
                        if (i >= 6)
                        {
                            Point[] int13 = new Point[6];
                            int13[0].X = int_13 + 1;
                            int13[0].Y = int_14 + this.size_0.Height / 2;
                            int13[1].X = int_13 + this.int_11 + 1;
                            int13[1].Y = int_14 + this.size_0.Height / 2 - this.int_11 / 2;
                            int13[2].X = int_13 + this.size_0.Width - this.int_11 - 1;
                            int13[2].Y = int_14 + this.size_0.Height / 2 - this.int_11 / 2;
                            int13[3].X = int_13 + this.size_0.Width - 1;
                            int13[3].Y = int_14 + this.size_0.Height / 2;
                            int13[4].X = int_13 + this.size_0.Width - this.int_11 - 1;
                            int13[4].Y = int_14 + this.size_0.Height / 2 + this.int_11 / 2;
                            int13[5].X = int_13 + this.int_11 + 1;
                            int13[5].Y = int_14 + this.size_0.Height / 2 + this.int_11 / 2;
                            graphics_0.FillPolygon(solidBrush, int13);
                            graphics_0.DrawPolygon(pen, int13);
                        }
                        else
                        {
                            Point[] int14 = new Point[4];
                            switch (i)
                            {
                                case 0:
                                    {
                                        int14[0].X = int_13 + num;
                                        int14[0].Y = int_14;
                                        int14[1].X = int_13 + this.int_11 + num;
                                        int14[1].Y = int_14 + this.int_11;
                                        int14[2].X = int_13 + this.size_0.Width - this.int_11 + num;
                                        int14[2].Y = int_14 + this.int_11;
                                        int14[3].X = int_13 + this.size_0.Width + num;
                                        int14[3].Y = int_14;
                                        break;
                                    }
                                case 1:
                                    {
                                        int14[0].X = int_13 + this.size_0.Width - this.int_11 + num;
                                        int14[0].Y = int_14 + this.int_11 + 1;
                                        int14[1].X = int_13 + this.size_0.Width - this.int_11;
                                        int14[1].Y = int_14 + this.size_0.Height / 2 - this.int_11 / 2;
                                        int14[2].X = int_13 + this.size_0.Width;
                                        int14[2].Y = int_14 + this.size_0.Height / 2;
                                        int14[3].X = int_13 + this.size_0.Width + num;
                                        int14[3].Y = int_14 + 1;
                                        break;
                                    }
                                case 2:
                                    {
                                        int14[0].X = int_13 + this.size_0.Width - this.int_11;
                                        int14[0].Y = int_14 + this.size_0.Height / 2 + this.int_11 / 2;
                                        int14[1].X = int_13 + this.size_0.Width - this.int_11 - num;
                                        int14[1].Y = int_14 + this.size_0.Height - this.int_11 - 1;
                                        int14[2].X = int_13 + this.size_0.Width - num;
                                        int14[2].Y = int_14 + this.size_0.Height - 1;
                                        int14[3].X = int_13 + this.size_0.Width;
                                        int14[3].Y = int_14 + this.size_0.Height / 2;
                                        break;
                                    }
                                case 3:
                                    {
                                        int14[0].X = int_13 - num;
                                        int14[0].Y = int_14 + this.size_0.Height;
                                        int14[1].X = int_13 + this.int_11 - num;
                                        int14[1].Y = int_14 - this.int_11 + this.size_0.Height;
                                        int14[2].X = int_13 + this.size_0.Width - this.int_11 - num;
                                        int14[2].Y = int_14 - this.int_11 + this.size_0.Height;
                                        int14[3].X = int_13 + this.size_0.Width - num;
                                        int14[3].Y = int_14 + this.size_0.Height;
                                        break;
                                    }
                                case 4:
                                    {
                                        int14[0].X = int_13 + this.int_11;
                                        int14[0].Y = int_14 + this.size_0.Height / 2 + this.int_11 / 2;
                                        int14[1].X = int_13 + this.int_11 - num;
                                        int14[1].Y = int_14 + this.size_0.Height - this.int_11 - 1;
                                        int14[2].X = int_13 - num;
                                        int14[2].Y = int_14 + this.size_0.Height - 1;
                                        int14[3].X = int_13;
                                        int14[3].Y = int_14 + this.size_0.Height / 2;
                                        break;
                                    }
                                case 5:
                                    {
                                        int14[0].X = int_13 + this.int_11 + num;
                                        int14[0].Y = int_14 + this.int_11 + 1;
                                        int14[1].X = int_13 + this.int_11;
                                        int14[1].Y = int_14 + this.size_0.Height / 2 - this.int_11 / 2;
                                        int14[2].X = int_13;
                                        int14[2].Y = int_14 + this.size_0.Height / 2;
                                        int14[3].X = int_13 + num;
                                        int14[3].Y = int_14 + 1;
                                        break;
                                    }
                            }
                            graphics_0.FillPolygon(solidBrush, int14);
                            graphics_0.DrawPolygon(pen, int14);
                        }
                    }
                    else if (this.das_SegmentStyle_0 != DAS_SegmentStyle.SS_Rhomb)
                    {
                        Point[] pointArray = new Point[8];
                        switch (i)
                        {
                            case 0:
                                {
                                    pointArray[0].X = int_13 + this.int_11 / 2 + num;
                                    pointArray[0].Y = int_14;
                                    pointArray[1].X = int_13 + this.int_11 / 2 + num;
                                    pointArray[1].Y = int_14 + this.int_11 / 2;
                                    pointArray[2].X = int_13 + this.int_11 + num;
                                    pointArray[2].Y = int_14 + this.int_11 / 2;
                                    pointArray[3].X = int_13 + this.int_11 + num;
                                    pointArray[3].Y = int_14 + this.int_11;
                                    pointArray[4].X = int_13 + this.size_0.Width - this.int_11 + num;
                                    pointArray[4].Y = int_14 + this.int_11;
                                    pointArray[5].X = int_13 + this.size_0.Width - this.int_11 + num;
                                    pointArray[5].Y = int_14 + this.int_11 / 2;
                                    pointArray[6].X = int_13 + this.size_0.Width - this.int_11 / 2 + num;
                                    pointArray[6].Y = int_14 + this.int_11 / 2;
                                    pointArray[7].X = int_13 + this.size_0.Width - this.int_11 / 2 + num;
                                    pointArray[7].Y = int_14;
                                    break;
                                }
                            case 1:
                                {
                                    pointArray[0].X = int_13 + this.size_0.Width + num;
                                    pointArray[0].Y = int_14 + this.int_11 / 2;
                                    pointArray[1].X = int_13 + this.size_0.Width - this.int_11 / 2 + num;
                                    pointArray[1].Y = int_14 + this.int_11 / 2;
                                    pointArray[2].X = int_13 + this.size_0.Width - this.int_11 / 2 + num;
                                    pointArray[2].Y = int_14 + this.int_11;
                                    pointArray[3].X = int_13 + this.size_0.Width - this.int_11 + num;
                                    pointArray[3].Y = int_14 + this.int_11;
                                    pointArray[4].X = int_13 + this.size_0.Width - this.int_11;
                                    pointArray[4].Y = int_14 + this.size_0.Height / 2 - this.int_11 / 2;
                                    pointArray[5].X = int_13 + this.size_0.Width - this.int_11 / 2;
                                    pointArray[5].Y = int_14 + this.size_0.Height / 2 - this.int_11 / 2;
                                    pointArray[6].X = int_13 + this.size_0.Width - this.int_11 / 2;
                                    pointArray[6].Y = int_14 + this.size_0.Height / 2;
                                    pointArray[7].X = int_13 + this.size_0.Width;
                                    pointArray[7].Y = int_14 + this.size_0.Height / 2;
                                    break;
                                }
                            case 2:
                                {
                                    pointArray[0].X = int_13 + this.size_0.Width;
                                    pointArray[0].Y = int_14 + this.size_0.Height / 2;
                                    pointArray[1].X = int_13 + this.size_0.Width - this.int_11 / 2;
                                    pointArray[1].Y = int_14 + this.size_0.Height / 2;
                                    pointArray[2].X = int_13 + this.size_0.Width - this.int_11 / 2;
                                    pointArray[2].Y = int_14 + this.size_0.Height / 2 + this.int_11 / 2;
                                    pointArray[3].X = int_13 + this.size_0.Width - this.int_11;
                                    pointArray[3].Y = int_14 + this.size_0.Height / 2 + this.int_11 / 2;
                                    pointArray[4].X = int_13 + this.size_0.Width - this.int_11 - num;
                                    pointArray[4].Y = int_14 + this.size_0.Height - this.int_11;
                                    pointArray[5].X = int_13 + this.size_0.Width - this.int_11 / 2 - num;
                                    pointArray[5].Y = int_14 + this.size_0.Height - this.int_11;
                                    pointArray[6].X = int_13 + this.size_0.Width - this.int_11 / 2 - num;
                                    pointArray[6].Y = int_14 + this.size_0.Height - this.int_11 / 2;
                                    pointArray[7].X = int_13 + this.size_0.Width - num;
                                    pointArray[7].Y = int_14 + this.size_0.Height - this.int_11 / 2;
                                    break;
                                }
                            case 3:
                                {
                                    pointArray[0].X = int_13 + this.int_11 / 2 - num;
                                    pointArray[0].Y = int_14 + this.size_0.Height;
                                    pointArray[1].X = int_13 + this.int_11 / 2 - num;
                                    pointArray[1].Y = int_14 + this.size_0.Height - this.int_11 / 2;
                                    pointArray[2].X = int_13 + this.int_11 - num;
                                    pointArray[2].Y = int_14 + this.size_0.Height - this.int_11 / 2;
                                    pointArray[3].X = int_13 + this.int_11 - num;
                                    pointArray[3].Y = int_14 + this.size_0.Height - this.int_11;
                                    pointArray[4].X = int_13 + this.size_0.Width - this.int_11 - num;
                                    pointArray[4].Y = int_14 + this.size_0.Height - this.int_11;
                                    pointArray[5].X = int_13 + this.size_0.Width - this.int_11 - num;
                                    pointArray[5].Y = int_14 + this.size_0.Height - this.int_11 / 2;
                                    pointArray[6].X = int_13 + this.size_0.Width - this.int_11 / 2 - num;
                                    pointArray[6].Y = int_14 + this.size_0.Height - this.int_11 / 2;
                                    pointArray[7].X = int_13 + this.size_0.Width - this.int_11 / 2 - num;
                                    pointArray[7].Y = int_14 + this.size_0.Height;
                                    break;
                                }
                            case 4:
                                {
                                    pointArray[0].X = int_13;
                                    pointArray[0].Y = int_14 + this.size_0.Height / 2;
                                    pointArray[1].X = int_13 + this.int_11 / 2;
                                    pointArray[1].Y = int_14 + this.size_0.Height / 2;
                                    pointArray[2].X = int_13 + this.int_11 / 2;
                                    pointArray[2].Y = int_14 + this.size_0.Height / 2 + this.int_11 / 2;
                                    pointArray[3].X = int_13 + this.int_11;
                                    pointArray[3].Y = int_14 + this.size_0.Height / 2 + this.int_11 / 2;
                                    pointArray[4].X = int_13 + this.int_11 - num;
                                    pointArray[4].Y = int_14 + this.size_0.Height - this.int_11;
                                    pointArray[5].X = int_13 + this.int_11 / 2 - num;
                                    pointArray[5].Y = int_14 + this.size_0.Height - this.int_11;
                                    pointArray[6].X = int_13 + this.int_11 / 2 - num;
                                    pointArray[6].Y = int_14 + this.size_0.Height - this.int_11 / 2;
                                    pointArray[7].X = int_13 - num;
                                    pointArray[7].Y = int_14 + this.size_0.Height - this.int_11 / 2;
                                    break;
                                }
                            case 5:
                                {
                                    pointArray[0].X = int_13 + num;
                                    pointArray[0].Y = int_14 + this.int_11 / 2;
                                    pointArray[1].X = int_13 + this.int_11 / 2 + num;
                                    pointArray[1].Y = int_14 + this.int_11 / 2;
                                    pointArray[2].X = int_13 + this.int_11 / 2 + num;
                                    pointArray[2].Y = int_14 + this.int_11;
                                    pointArray[3].X = int_13 + this.int_11 + num;
                                    pointArray[3].Y = int_14 + this.int_11;
                                    pointArray[4].X = int_13 + this.int_11;
                                    pointArray[4].Y = int_14 + this.size_0.Height / 2 - this.int_11 / 2;
                                    pointArray[5].X = int_13 + this.int_11 / 2;
                                    pointArray[5].Y = int_14 + this.size_0.Height / 2 - this.int_11 / 2;
                                    pointArray[6].X = int_13 + this.int_11 / 2;
                                    pointArray[6].Y = int_14 + this.size_0.Height / 2;
                                    pointArray[7].X = int_13;
                                    pointArray[7].Y = int_14 + this.size_0.Height / 2;
                                    break;
                                }
                            case 6:
                                {
                                    pointArray[0].X = int_13 + this.int_11 / 2;
                                    pointArray[0].Y = int_14 + this.size_0.Height / 2 + this.int_11 / 2;
                                    pointArray[1].X = int_13 + this.int_11 / 2;
                                    pointArray[1].Y = int_14 + this.size_0.Height / 2;
                                    pointArray[2].X = int_13 + this.int_11;
                                    pointArray[2].Y = int_14 + this.size_0.Height / 2;
                                    pointArray[3].X = int_13 + this.int_11;
                                    pointArray[3].Y = int_14 + this.size_0.Height / 2 - this.int_11 / 2;
                                    pointArray[4].X = int_13 + this.size_0.Width - this.int_11;
                                    pointArray[4].Y = int_14 + this.size_0.Height / 2 - this.int_11 / 2;
                                    pointArray[5].X = int_13 + this.size_0.Width - this.int_11;
                                    pointArray[5].Y = int_14 + this.size_0.Height / 2;
                                    pointArray[6].X = int_13 + this.size_0.Width - this.int_11 / 2;
                                    pointArray[6].Y = int_14 + this.size_0.Height / 2;
                                    pointArray[7].X = int_13 + this.size_0.Width - this.int_11 / 2;
                                    pointArray[7].Y = int_14 + this.size_0.Height / 2 + this.int_11 / 2;
                                    break;
                                }
                        }
                        graphics_0.FillPolygon(solidBrush, pointArray);
                        graphics_0.DrawPolygon(pen, pointArray);
                    }
                    else
                    {
                        Point[] int131 = new Point[6];
                        switch (i)
                        {
                            case 0:
                                {
                                    int131[0].X = int_13 + this.int_11 / 2 + num;
                                    int131[0].Y = int_14 + this.int_11 / 2;
                                    int131[1].X = int_13 + this.int_11 + num;
                                    int131[1].Y = int_14 + this.int_11;
                                    int131[2].X = int_13 + this.size_0.Width - this.int_11 + num;
                                    int131[2].Y = int_14 + this.int_11;
                                    int131[3].X = int_13 + this.size_0.Width - this.int_11 / 2 + num;
                                    int131[3].Y = int_14 + this.int_11 / 2;
                                    int131[4].X = int_13 + this.size_0.Width - this.int_11 + num;
                                    int131[4].Y = int_14;
                                    int131[5].X = int_13 + this.int_11 + num;
                                    int131[5].Y = int_14;
                                    break;
                                }
                            case 1:
                                {
                                    int131[0].X = int_13 + this.size_0.Width - this.int_11 / 2 + num;
                                    int131[0].Y = int_14 + this.int_11 / 2 + 1;
                                    int131[1].X = int_13 + this.size_0.Width - this.int_11 + num;
                                    int131[1].Y = int_14 + this.int_11 + 1;
                                    int131[2].X = int_13 + this.size_0.Width - this.int_11;
                                    int131[2].Y = int_14 + this.size_0.Height / 2 - this.int_11 / 2;
                                    int131[3].X = int_13 + this.size_0.Width - this.int_11 / 2;
                                    int131[3].Y = int_14 + this.size_0.Height / 2;
                                    int131[4].X = int_13 + this.size_0.Width;
                                    int131[4].Y = int_14 + this.size_0.Height / 2 - this.int_11 / 2;
                                    int131[5].X = int_13 + this.size_0.Width + num;
                                    int131[5].Y = int_14 + this.int_11 + 1;
                                    break;
                                }
                            case 2:
                                {
                                    int131[0].X = int_13 + this.size_0.Width - this.int_11 / 2;
                                    int131[0].Y = int_14 + this.size_0.Height / 2;
                                    int131[1].X = int_13 + this.size_0.Width - this.int_11;
                                    int131[1].Y = int_14 + this.size_0.Height / 2 + this.int_11 / 2;
                                    int131[2].X = int_13 + this.size_0.Width - this.int_11 - num;
                                    int131[2].Y = int_14 + this.size_0.Height - this.int_11 - 1;
                                    int131[3].X = int_13 + this.size_0.Width - this.int_11 / 2 - num;
                                    int131[3].Y = int_14 + this.size_0.Height - this.int_11 / 2 - 1;
                                    int131[4].X = int_13 + this.size_0.Width - num;
                                    int131[4].Y = int_14 + this.size_0.Height - this.int_11 - 1;
                                    int131[5].X = int_13 + this.size_0.Width;
                                    int131[5].Y = int_14 + this.size_0.Height / 2 + this.int_11 / 2;
                                    break;
                                }
                            case 3:
                                {
                                    int131[0].X = int_13 + this.int_11 / 2 - num;
                                    int131[0].Y = int_14 + this.size_0.Height - this.int_11 / 2;
                                    int131[1].X = int_13 + this.int_11 - num;
                                    int131[1].Y = int_14 + this.size_0.Height - this.int_11;
                                    int131[2].X = int_13 + this.size_0.Width - this.int_11 - num;
                                    int131[2].Y = int_14 + this.size_0.Height - this.int_11;
                                    int131[3].X = int_13 + this.size_0.Width - this.int_11 / 2 - num;
                                    int131[3].Y = int_14 + this.size_0.Height - this.int_11 / 2;
                                    int131[4].X = int_13 + this.size_0.Width - this.int_11 - num;
                                    int131[4].Y = int_14 + this.size_0.Height;
                                    int131[5].X = int_13 + this.int_11 - num;
                                    int131[5].Y = int_14 + this.size_0.Height;
                                    break;
                                }
                            case 4:
                                {
                                    int131[0].X = int_13 + this.int_11 / 2;
                                    int131[0].Y = int_14 + this.size_0.Height / 2;
                                    int131[1].X = int_13 + this.int_11;
                                    int131[1].Y = int_14 + this.size_0.Height / 2 + this.int_11 / 2;
                                    int131[2].X = int_13 + this.int_11 - num;
                                    int131[2].Y = int_14 + this.size_0.Height - this.int_11 - 1;
                                    int131[3].X = int_13 + this.int_11 / 2 - num;
                                    int131[3].Y = int_14 + this.size_0.Height - this.int_11 / 2 - 1;
                                    int131[4].X = int_13 - num;
                                    int131[4].Y = int_14 + this.size_0.Height - this.int_11 - 1;
                                    int131[5].X = int_13;
                                    int131[5].Y = int_14 + this.size_0.Height / 2 + this.int_11 / 2;
                                    break;
                                }
                            case 5:
                                {
                                    int131[0].X = int_13 + this.int_11 / 2 + num;
                                    int131[0].Y = int_14 + this.int_11 / 2 + 1;
                                    int131[1].X = int_13 + this.int_11 + num;
                                    int131[1].Y = int_14 + this.int_11 + 1;
                                    int131[2].X = int_13 + this.int_11;
                                    int131[2].Y = int_14 + this.size_0.Height / 2 - this.int_11 / 2;
                                    int131[3].X = int_13 + this.int_11 / 2;
                                    int131[3].Y = int_14 + this.size_0.Height / 2;
                                    int131[4].X = int_13;
                                    int131[4].Y = int_14 + this.size_0.Height / 2 - this.int_11 / 2;
                                    int131[5].X = int_13 + num;
                                    int131[5].Y = int_14 + this.int_11 + 1;
                                    break;
                                }
                            case 6:
                                {
                                    int131[0].X = int_13 + this.int_11 / 2 + 1;
                                    int131[0].Y = int_14 + this.size_0.Height / 2;
                                    int131[1].X = int_13 + this.int_11 + 1;
                                    int131[1].Y = int_14 + this.size_0.Height / 2 - this.int_11 / 2;
                                    int131[2].X = int_13 + this.size_0.Width - this.int_11 - 1;
                                    int131[2].Y = int_14 + this.size_0.Height / 2 - this.int_11 / 2;
                                    int131[3].X = int_13 + this.size_0.Width - this.int_11 / 2 - 1;
                                    int131[3].Y = int_14 + this.size_0.Height / 2;
                                    int131[4].X = int_13 + this.size_0.Width - this.int_11 - 1;
                                    int131[4].Y = int_14 + this.size_0.Height / 2 + this.int_11 / 2;
                                    int131[5].X = int_13 + this.int_11 + 1;
                                    int131[5].Y = int_14 + this.size_0.Height / 2 + this.int_11 / 2;
                                    break;
                                }
                        }
                        graphics_0.FillPolygon(solidBrush, int131);
                        graphics_0.DrawPolygon(pen, int131);
                    }
                }
            }
            solidBrush.Dispose();
            pen.Dispose();
        }

        protected override void Dispose(bool bool_11)
        {

            base.Dispose(bool_11);
        }

        protected override void OnPaint(PaintEventArgs paintEventArgs_0)
        {
            int i;
            SizeF sizeF;
            int left;
            int height;
            int num;
            try
            {
                base.OnPaint(paintEventArgs_0);
                if (this.das_BorderGradientStyle_0 == DAS_BorderGradientStyle.BGS_None || base.ClientRectangle.Width - 2 * (this.int_0 + this.int_1 + this.int_4 + this.int_2) > 0 && base.ClientRectangle.Height - 2 * (this.int_0 + this.int_1 + this.int_4 + this.int_2) > 0)
                {
                    DrawGraphics _DrawGraphics = new DrawGraphics();
                    int left1 = base.ClientRectangle.Left;
                    int top = base.ClientRectangle.Top;
                    Rectangle clientRectangle = base.ClientRectangle;
                    int width = clientRectangle.Width - 2;
                    clientRectangle = base.ClientRectangle;
                    Rectangle rectangle = new Rectangle(left1, top, width, clientRectangle.Height - 2);
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
                    string str = "0";
                    if (this.int_8 > 0)
                    {
                        str = "0.";
                        for (i = 0; i < this.int_8; i++)
                        {
                            str = string.Concat(str, "0");
                        }
                    }
                    RectangleF right = new RectangleF();
                    StringFormat stringFormat = new StringFormat();
                    int int12 = this.int_12;
                    long year = (long)0;
                    int top1 = (x.Top + x.Bottom) / 2;
                    int int11 = int12;
                    Color color8 = this.color_8;
                    Color color9 = this.color_9;
                    if ((double)this.float_8 > 0)
                    {
                        int float8 = 255;
                        float8 = 255 - (int)(255f * this.float_8);
                        color8 = Color.FromArgb(float8, this.color_8);
                        color9 = Color.FromArgb(float8, this.color_9);
                    }
                    Pen pen1 = new Pen(color9);
                    SolidBrush solidBrush2 = new SolidBrush(this.ForeColor);
                    if (this.bool_4 && this.bool_10)
                    {
                        solidBrush2.Color = color8;
                    }
                    if (this.das_DisplayStyle_0 != DAS_DisplayStyle.DS_Time24_Style && this.das_DisplayStyle_0 != DAS_DisplayStyle.DS_TimeAP_Style && this.das_DisplayStyle_0 != DAS_DisplayStyle.DS_Date1_Style && this.das_DisplayStyle_0 != DAS_DisplayStyle.DS_Date2_Style && this.das_DisplayStyle_0 != DAS_DisplayStyle.DS_Time24_Date1_Style && this.das_DisplayStyle_0 != DAS_DisplayStyle.DS_TimeAP_Date1_Style && this.das_DisplayStyle_0 != DAS_DisplayStyle.DS_Time24_Date2_Style)
                    {
                        if (this.das_DisplayStyle_0 == DAS_DisplayStyle.DS_TimeAP_Date2_Style)
                        {
                            goto Label6;
                        }
                        if (this.int_10 > 0)
                        {
                            double double0 = this.double_0;
                            if (double0 < 0)
                            {
                                double0 = -this.double_0;
                            }
                            if (this.int_8 > 0)
                            {
                                for (i = 0; i < this.int_8; i++)
                                {
                                    double0 = double0 * 10;
                                }
                            }
                            year = (long)double0;
                            if (this.string_0 != string.Empty && this.bool_3)
                            {
                                sizeF = paintEventArgs_0.Graphics.MeasureString(this.string_0, this.Font);
                                right.X = (float)(x.Right - int11) - sizeF.Width;
                                right.Width = sizeF.Width;
                                right.Y = (float)(top1 + this.size_0.Height / 2) - sizeF.Height;
                                right.Height = sizeF.Height;
                                stringFormat.LineAlignment = StringAlignment.Far;
                                stringFormat.Alignment = StringAlignment.Center;
                                paintEventArgs_0.Graphics.DrawString(this.string_0, this.Font, solidBrush2, right, stringFormat);
                                int11 = (int)((float)int11 + sizeF.Width + (float)(int12 / 2));
                            }
                            int num1 = 10;
                            if (this.int_8 == 0)
                            {
                                if (this.das_DisplayStyle_0 == DAS_DisplayStyle.DS_Bin_Style)
                                {
                                    num1 = 2;
                                }
                                else if (this.das_DisplayStyle_0 == DAS_DisplayStyle.DS_Oct_Style)
                                {
                                    num1 = 8;
                                }
                                else if (this.das_DisplayStyle_0 == DAS_DisplayStyle.DS_Hex_Style)
                                {
                                    num1 = 16;
                                }
                            }
                            int int111 = 0;
                            left = x.Left;
                            for (i = 0; i < this.int_10; i++)
                            {
                                left = x.Right - this.size_0.Width - int11 - i * (this.size_0.Width + int12) - int111;
                                height = top1 - this.size_0.Height / 2;
                                num = (int)(year - year / (long)num1 * (long)num1);
                                if (year != (long)0 || this.m_AllZeroVisible || this.int_8 != 0 && i <= this.int_8)
                                {
                                    this.method_1(paintEventArgs_0.Graphics, left, height, num, false);
                                }
                                else
                                {
                                    this.method_1(paintEventArgs_0.Graphics, left, height, num, true);
                                }
                                if (this.int_8 > 0 && i == this.int_8 - 1)
                                {
                                    Rectangle rectangle1 = new Rectangle();
                                    int111 = int12 / 2 + this.int_11;
                                    rectangle1.X = left - int12 / 2 - this.int_11;
                                    rectangle1.Width = this.int_11;
                                    rectangle1.Y = top1 + this.size_0.Height / 2 - this.int_11;
                                    rectangle1.Height = this.int_11;
                                    paintEventArgs_0.Graphics.FillRectangle(solidBrush2, rectangle1);
                                    paintEventArgs_0.Graphics.DrawRectangle(pen1, rectangle1);
                                }
                                year = (year - (long)num) / (long)num1;
                            }
                            height = top1 - this.size_0.Height / 2;
                            if (this.bool_6)
                            {
                                Rectangle width1 = new Rectangle();
                                Rectangle left2 = new Rectangle();
                                Rectangle width2 = new Rectangle();
                                width1.X = left - int12 / 2 - this.size_0.Width + 1;
                                width1.Width = this.size_0.Width - 2;
                                width1.Y = top1 - this.size_0.Height / 4 - this.int_11 / 2;
                                width1.Height = this.int_11;
                                left2.X = (width1.Left + width1.Right - this.int_11) / 2;
                                left2.Width = this.int_11;
                                left2.Y = height + 1;
                                left2.Height = this.size_0.Height / 2 - 2;
                                width2.X = left - int12 / 2 - this.size_0.Width + 1;
                                width2.Width = this.size_0.Width - 2;
                                width2.Y = top1 + this.size_0.Height / 4 - this.int_11 / 2;
                                width2.Height = this.int_11;
                                GraphicsPath graphicsPath = new GraphicsPath();
                                graphicsPath.AddRectangle(width1);
                                graphicsPath.AddRectangle(left2);
                                graphicsPath.FillMode = FillMode.Winding;
                                if (this.double_0 < 0)
                                {
                                    paintEventArgs_0.Graphics.FillRectangle(solidBrush2, width2);
                                    paintEventArgs_0.Graphics.DrawRectangle(pen1, width2);
                                    if (this.bool_7)
                                    {
                                        paintEventArgs_0.Graphics.DrawPath(pen1, graphicsPath);
                                        SolidBrush solidBrush3 = new SolidBrush(color8);
                                        paintEventArgs_0.Graphics.FillPath(solidBrush3, graphicsPath);
                                        solidBrush3.Dispose();
                                    }
                                }
                                else
                                {
                                    paintEventArgs_0.Graphics.DrawPath(pen1, graphicsPath);
                                    paintEventArgs_0.Graphics.FillPath(solidBrush2, graphicsPath);
                                    if (this.bool_7)
                                    {
                                        SolidBrush solidBrush4 = new SolidBrush(color8);
                                        paintEventArgs_0.Graphics.FillRectangle(solidBrush4, width2);
                                        solidBrush4.Dispose();
                                        paintEventArgs_0.Graphics.DrawRectangle(pen1, width2);
                                    }
                                }
                                graphicsPath.Dispose();
                                goto Label0;
                            }
                            else
                            {
                                goto Label0;
                            }
                        }
                        else
                        {
                            goto Label0;
                        }
                    }
                Label6:
                    if (this.das_DisplayStyle_0 == DAS_DisplayStyle.DS_Date1_Style || this.das_DisplayStyle_0 == DAS_DisplayStyle.DS_Date2_Style || this.das_DisplayStyle_0 == DAS_DisplayStyle.DS_Time24_Date1_Style || this.das_DisplayStyle_0 == DAS_DisplayStyle.DS_TimeAP_Date1_Style || this.das_DisplayStyle_0 == DAS_DisplayStyle.DS_Time24_Date2_Style || this.das_DisplayStyle_0 == DAS_DisplayStyle.DS_TimeAP_Date2_Style)
                    {
                        year = (long)this.dateTime_0.Year;
                        left = x.Right - int11 - this.size_0.Width;
                        height = top1 - this.size_0.Height / 2;
                        num = (int)(year - year / (long)10 * (long)10);
                        year = (year - (long)num) / (long)10;
                        this.method_1(paintEventArgs_0.Graphics, left, height, num, false);
                        left = left - this.size_0.Width - int12;
                        num = (int)(year - year / (long)10 * (long)10);
                        year = (year - (long)num) / (long)10;
                        this.method_1(paintEventArgs_0.Graphics, left, height, num, false);
                        left = left - this.size_0.Width - int12;
                        num = (int)(year - year / (long)10 * (long)10);
                        year = (year - (long)num) / (long)10;
                        this.method_1(paintEventArgs_0.Graphics, left, height, num, false);
                        left = left - this.size_0.Width - int12;
                        num = (int)(year - year / (long)10 * (long)10);
                        year = (year - (long)num) / (long)10;
                        this.method_1(paintEventArgs_0.Graphics, left, height, num, false);
                        int11 = x.Right - (left - int12 / 2);
                        if (this.das_DisplayStyle_0 != DAS_DisplayStyle.DS_Date1_Style && this.das_DisplayStyle_0 != DAS_DisplayStyle.DS_Time24_Date1_Style)
                        {
                            if (this.das_DisplayStyle_0 == DAS_DisplayStyle.DS_TimeAP_Date1_Style)
                            {
                                goto Label7;
                            }
                            Pen pen2 = new Pen(solidBrush2, (float)this.int_11);
                            paintEventArgs_0.Graphics.DrawLine(pen2, x.Right - int11 - 2, top1 - this.size_0.Height / 2 + 3, x.Right - int11 - 2 - (this.size_0.Width - 4), top1 + this.size_0.Height / 2 - 6);
                            pen2.Dispose();
                            goto Label2;
                        }
                    Label7:
                        Rectangle rectangle2 = new Rectangle(x.Right - int11 - this.size_0.Width, top1 - this.int_11 / 2, this.size_0.Width, this.int_11);
                        paintEventArgs_0.Graphics.FillRectangle(solidBrush2, rectangle2);
                        paintEventArgs_0.Graphics.DrawRectangle(pen1, rectangle2);
                    Label2:
                        int11 = int11 + this.size_0.Width + int12 / 2;
                        year = (long)this.dateTime_0.Month;
                        left = x.Right - int11 - this.size_0.Width;
                        num = (int)(year - year / (long)10 * (long)10);
                        year = (year - (long)num) / (long)10;
                        this.method_1(paintEventArgs_0.Graphics, left, height, num, false);
                        left = left - this.size_0.Width - int12;
                        num = (int)(year - year / (long)10 * (long)10);
                        year = (year - (long)num) / (long)10;
                        this.method_1(paintEventArgs_0.Graphics, left, height, num, false);
                        int11 = x.Right - (left - int12 / 2);
                        if (this.das_DisplayStyle_0 != DAS_DisplayStyle.DS_Date1_Style && this.das_DisplayStyle_0 != DAS_DisplayStyle.DS_Time24_Date1_Style)
                        {
                            if (this.das_DisplayStyle_0 == DAS_DisplayStyle.DS_TimeAP_Date1_Style)
                            {
                                goto Label8;
                            }
                            Pen pen3 = new Pen(solidBrush2, (float)this.int_11);
                            paintEventArgs_0.Graphics.DrawLine(pen3, x.Right - int11 - 2, top1 - this.size_0.Height / 2 + 3, x.Right - int11 - 2 - (this.size_0.Width - 4), top1 + this.size_0.Height / 2 - 6);
                            pen3.Dispose();
                            goto Label4;
                        }
                    Label8:
                        Rectangle rectangle3 = new Rectangle(x.Right - int11 - this.size_0.Width, top1 - this.int_11 / 2, this.size_0.Width, this.int_11);
                        paintEventArgs_0.Graphics.FillRectangle(solidBrush2, rectangle3);
                        paintEventArgs_0.Graphics.DrawRectangle(pen1, rectangle3);
                    Label4:
                        int11 = int11 + this.size_0.Width + int12 / 2;
                        year = (long)this.dateTime_0.Day;
                        left = x.Right - int11 - this.size_0.Width;
                        num = (int)(year - year / (long)10 * (long)10);
                        year = (year - (long)num) / (long)10;
                        this.method_1(paintEventArgs_0.Graphics, left, height, num, false);
                        left = left - this.size_0.Width - int12;
                        num = (int)(year - year / (long)10 * (long)10);
                        year = (year - (long)num) / (long)10;
                        this.method_1(paintEventArgs_0.Graphics, left, height, num, false);
                        int11 = x.Right - (left - 2 * int12);
                    }
                    if (this.das_DisplayStyle_0 == DAS_DisplayStyle.DS_Time24_Style || this.das_DisplayStyle_0 == DAS_DisplayStyle.DS_TimeAP_Style || this.das_DisplayStyle_0 == DAS_DisplayStyle.DS_Time24_Date1_Style || this.das_DisplayStyle_0 == DAS_DisplayStyle.DS_TimeAP_Date1_Style || this.das_DisplayStyle_0 == DAS_DisplayStyle.DS_Time24_Date2_Style || this.das_DisplayStyle_0 == DAS_DisplayStyle.DS_TimeAP_Date2_Style)
                    {
                        if (this.das_DisplayStyle_0 == DAS_DisplayStyle.DS_TimeAP_Style || this.das_DisplayStyle_0 == DAS_DisplayStyle.DS_TimeAP_Date1_Style || this.das_DisplayStyle_0 == DAS_DisplayStyle.DS_TimeAP_Date2_Style)
                        {
                            string str1 = "AM";
                            if (this.dateTime_0.Hour >= 12)
                            {
                                str1 = "PM";
                            }
                            sizeF = paintEventArgs_0.Graphics.MeasureString(str1, this.Font);
                            right.X = (float)(x.Right - int11) - sizeF.Width;
                            right.Width = sizeF.Width;
                            right.Y = (float)(top1 + this.size_0.Height / 2) - sizeF.Height;
                            right.Height = sizeF.Height;
                            stringFormat.LineAlignment = StringAlignment.Far;
                            stringFormat.Alignment = StringAlignment.Center;
                            paintEventArgs_0.Graphics.DrawString(str1, this.Font, solidBrush2, right, stringFormat);
                            int11 = (int)((float)int11 + sizeF.Width + (float)int12);
                        }
                        year = (long)this.dateTime_0.Second;
                        left = x.Right - int11 - this.size_0.Width;
                        num = (int)(year - year / (long)10 * (long)10);
                        height = top1 - this.size_0.Height / 2;
                        year = (year - (long)num) / (long)10;
                        this.method_1(paintEventArgs_0.Graphics, left, height, num, false);
                        left = left - this.size_0.Width - int12;
                        num = (int)(year - year / (long)10 * (long)10);
                        year = (year - (long)num) / (long)10;
                        this.method_1(paintEventArgs_0.Graphics, left, height, num, false);
                        int11 = x.Right - left;
                        Rectangle height2 = new Rectangle()
                        {
                            X = left - int12 / 2 - this.int_11,
                            Width = this.int_11,
                            Y = top1 - this.size_0.Height / 4 - this.int_11 / 2,
                            Height = this.int_11
                        };
                        paintEventArgs_0.Graphics.FillRectangle(solidBrush2, height2);
                        paintEventArgs_0.Graphics.DrawRectangle(pen1, height2);
                        height2.Y = top1 + this.size_0.Height / 4 - this.int_11 / 2;
                        paintEventArgs_0.Graphics.FillRectangle(solidBrush2, height2);
                        paintEventArgs_0.Graphics.DrawRectangle(pen1, height2);
                        int11 = int11 + int12 + this.int_11;
                        year = (long)this.dateTime_0.Minute;
                        left = x.Right - int11 - this.size_0.Width;
                        num = (int)(year - year / (long)10 * (long)10);
                        year = (year - (long)num) / (long)10;
                        this.method_1(paintEventArgs_0.Graphics, left, height, num, false);
                        left = left - this.size_0.Width - int12;
                        num = (int)(year - year / (long)10 * (long)10);
                        year = (year - (long)num) / (long)10;
                        this.method_1(paintEventArgs_0.Graphics, left, height, num, false);
                        int11 = x.Right - left;
                        height2.X = left - int12 / 2 - this.int_11;
                        height2.Width = this.int_11;
                        height2.Y = top1 - this.size_0.Height / 4 - this.int_11 / 2;
                        height2.Height = this.int_11;
                        paintEventArgs_0.Graphics.FillRectangle(solidBrush2, height2);
                        paintEventArgs_0.Graphics.DrawRectangle(pen1, height2);
                        height2.Y = top1 + this.size_0.Height / 4 - this.int_11 / 2;
                        paintEventArgs_0.Graphics.FillRectangle(solidBrush2, height2);
                        paintEventArgs_0.Graphics.DrawRectangle(pen1, height2);
                        int11 = int11 + int12 + this.int_11;
                        year = (long)this.dateTime_0.Hour;
                        if ((this.das_DisplayStyle_0 == DAS_DisplayStyle.DS_TimeAP_Style || this.das_DisplayStyle_0 == DAS_DisplayStyle.DS_TimeAP_Date1_Style || this.das_DisplayStyle_0 == DAS_DisplayStyle.DS_TimeAP_Date2_Style) && year >= (long)12)
                        {
                            year = year - (long)12;
                        }
                        left = x.Right - int11 - this.size_0.Width;
                        num = (int)(year - year / (long)10 * (long)10);
                        year = (year - (long)num) / (long)10;
                        this.method_1(paintEventArgs_0.Graphics, left, height, num, false);
                        left = left - this.size_0.Width - int12;
                        num = (int)(year - year / (long)10 * (long)10);
                        year = (year - (long)num) / (long)10;
                        this.method_1(paintEventArgs_0.Graphics, left, height, num, false);
                    }
                Label0:
                    solidBrush2.Dispose();
                    pen1.Dispose();
                    if (this.das_BorderStyle_0 == DAS_BorderStyle.BS_RoundRect)
                    {
                        System.Drawing.Region region = new System.Drawing.Region(base.ClientRectangle);
                        GraphicsPath graphicsPath1 = new GraphicsPath();
                        _DrawGraphics.method_3(graphicsPath1, x, this.int_3 - this.int_0 - this.int_1 - this.int_4 - this.int_2);
                        region.Exclude(graphicsPath1);
                        SolidBrush solidBrush5 = new SolidBrush(base.Parent.BackColor);
                        paintEventArgs_0.Graphics.FillRegion(solidBrush5, region);
                        solidBrush5.Dispose();
                        graphicsPath1.Dispose();
                        region.Dispose();
                    }
                    if (this.bool_2 && this.int_7 > 0 && this.int_7 < rectangle.Width / 3 && this.int_7 < rectangle.Height / 3 && this.das_BorderGradientStyle_0 != DAS_BorderGradientStyle.BGS_None)
                    {
                        rectangle.X = rectangle.X + this.int_7;
                        rectangle.Y = rectangle.Y + this.int_7;
                        GraphicsPath graphicsPath2 = new GraphicsPath();
                        if (this.das_BorderStyle_0 != DAS_BorderStyle.BS_RoundRect)
                        {
                            _DrawGraphics.method_3(graphicsPath2, rectangle, 5);
                        }
                        else
                        {
                            _DrawGraphics.method_3(graphicsPath2, rectangle, this.int_3);
                        }
                        rectangle.X = rectangle.X - this.int_7;
                        rectangle.Y = rectangle.Y - this.int_7;
                        GraphicsPath graphicsPath3 = new GraphicsPath();
                        if (this.das_BorderStyle_0 != DAS_BorderStyle.BS_RoundRect)
                        {
                            _DrawGraphics.method_3(graphicsPath3, rectangle, 5);
                        }
                        else
                        {
                            _DrawGraphics.method_3(graphicsPath3, rectangle, this.int_3);
                        }
                        System.Drawing.Region region1 = new System.Drawing.Region(graphicsPath2);
                        System.Drawing.Region region2 = new System.Drawing.Region(graphicsPath2);
                        region2.Intersect(graphicsPath3);
                        region1.Xor(region2);
                        paintEventArgs_0.Graphics.SetClip(region1, CombineMode.Replace);
                        _DrawGraphics.method_4(paintEventArgs_0.Graphics, rectangle, graphicsPath3, this.color_7, this.int_7, this.float_7);
                        paintEventArgs_0.Graphics.ResetClip();
                        region2.Dispose();
                        region1.Dispose();
                        graphicsPath3.Dispose();
                        graphicsPath2.Dispose();
                    }
                    if (this.das_BorderStyle_0 != DAS_BorderStyle.BS_RoundRect)
                    {
                        _DrawGraphics.method_0(paintEventArgs_0.Graphics, rectangle, this.int_1, this.color_1, this.color_2, this.int_4, this.color_5, this.int_2, this.color_3, this.color_4, this.int_0, this.color_0, this.das_BorderGradientStyle_0, this.int_5, this.float_0, this.float_1, this.float_2, this.float_3);
                    }
                    else
                    {
                        _DrawGraphics.method_1(paintEventArgs_0.Graphics, rectangle, this.int_3, this.int_1, this.color_1, this.color_2, this.int_4, this.color_5, this.int_2, this.color_3, this.color_4, this.int_0, this.color_0, this.das_BorderGradientStyle_0, (long)this.int_5, this.float_0, this.float_1, this.float_2, this.float_3);
                    }

                }
            }
            catch (ApplicationException applicationException)
            {
                MessageBox.Show(applicationException.ToString());
            }
        }

        private string OriginalText;

        #region propartas

        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string m_PLCAddressText = string.Empty;

        [Category("PLC Properties")]
        [Editor(typeof(TestDialogEditor), typeof(UITypeEditor))]
        public string PLCAddressText
        {
            get { return m_PLCAddressText; }
            set
            {
                if (m_PLCAddressText != value)
                {
                    m_PLCAddressText = value;
                    try
                    {
                        //* When address is changed, re-subscribe to new address
                        if (string.IsNullOrEmpty(m_PLCAddressText) || string.IsNullOrWhiteSpace(m_PLCAddressText) ||
                            AdvancedScada.Controls.Licenses.LicenseManager.IsInDesignMode) return;
                        var bd = new Binding("Text", TagCollectionClient.Tags[m_PLCAddressValue], "Text", true);
                        DataBindings.Add(bd);
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
                            string.IsNullOrWhiteSpace(m_PLCAddressVisible) || AdvancedScada.Controls.Licenses.LicenseManager.IsInDesignMode) return;
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
                            AdvancedScada.Controls.Licenses.LicenseManager.IsInDesignMode) return;
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



        #endregion


        #region "Error Display"

        [DefaultValue(false)]
        public bool SuppressErrorDisplay { get; set; }

        //********************************************************
        //* Show an error via the text property for a short time
        //********************************************************
        private Timer ErrorDisplayTime;
        private readonly object ErrorLock = new object();

        private void DisplayError(string ErrorMessage)
        {
            if (!SuppressErrorDisplay)
            {
                //* Create the error display timer
                if (ErrorDisplayTime == null)
                {
                    ErrorDisplayTime = new Timer();
                    ErrorDisplayTime.Tick += ErrorDisplay_Tick;
                    ErrorDisplayTime.Interval = 5000;
                }

                //* Save the text to return to
                lock (ErrorLock)
                {
                    if (!ErrorDisplayTime.Enabled)
                    {
                        ErrorDisplayTime.Enabled = true;
                        OriginalText = Text;
                        Text = ErrorMessage;
                    }
                }
            }
        }


        //**************************************************************************************
        //* Return the text back to its original after displaying the error for a few seconds.
        //**************************************************************************************
        private void ErrorDisplay_Tick(object sender, EventArgs e)
        {
            //UpdateText()
            lock (ErrorLock)
            {
                Text = OriginalText;
                //If ErrorDisplayTime IsNot Nothing Then
                ErrorDisplayTime.Enabled = false;
                // ErrorIsDisplayed = False
            }

            //RemoveHandler ErrorDisplayTime.Tick, AddressOf ErrorDisplay_Tick
            //ErrorDisplayTime.Dispose()
            //ErrorDisplayTime = Nothing
            //End If
        }

        #endregion

        #region "Keypad popup for data entry"

        public string KeypadText { get; set; }

        private Font m_KeypadFont = new Font("Arial", 10);

        public Font KeypadFont
        {
            get { return m_KeypadFont; }
            set { m_KeypadFont = value; }
        }

        private Color m_KeypadForeColor = Color.WhiteSmoke;

        public Color KeypadFontColor
        {
            get { return m_KeypadForeColor; }
            set { m_KeypadForeColor = value; }
        }

        private int m_KeypadWidth = 400;

        public int KeypadWidth
        {
            get { return m_KeypadWidth; }
            set { m_KeypadWidth = value; }
        }

        //* 29-JAN-13

        public double KeypadMinValue { get; set; }

        public double KeypadMaxValue { get; set; }

        private double m_KeypadScaleFactor = 1;

        [DefaultValue(1)]
        public double KeypadScaleFactor
        {
            get { return m_KeypadScaleFactor; }
            set { m_KeypadScaleFactor = value; }
        }

        public bool KeypadAlphaNumeric { get; set; }

        public bool KeypadShowCurrentValue { get; set; }

        //*****************************************
        //* Property - Address in PLC to Write Data To
        //*****************************************
        private string m_PLCAddressKeypad = string.Empty;

        [Category("PLC Properties")]
        public string PLCAddressKeypad
        {
            get { return m_PLCAddressKeypad; }
            set
            {
                if (m_PLCAddressKeypad != value) m_PLCAddressKeypad = value;
            }
        }


        private IKeyboard KeypadPopUp;

        private void KeypadPopUp_ButtonClick(object sender, KeypadEventArgs e)
        {
            if (e.Key == "Quit")
            {
                KeypadPopUp.Visible = false;
            }
            else if (e.Key == "Enter")
            {
                if (KeypadPopUp.Value != null && string.Compare(KeypadPopUp.Value, string.Empty) != 0)
                {
                    //* 29-JAN-13 - Validate value if a Min/Max was specified
                    try
                    {
                        if (KeypadMaxValue != KeypadMinValue)
                            if ((Convert.ToDouble(KeypadPopUp.Value) < KeypadMinValue) |
                                (Convert.ToDouble(KeypadPopUp.Value) > KeypadMaxValue))
                            {
                                MessageBox.Show("Value must be >" + KeypadMinValue + " and <" + KeypadMaxValue);
                                return;
                            }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to validate value. " + ex.Message);
                        return;
                    }

                    try
                    {
                        //* 29-JAN-13 - reduced code and checked for divide by 0
                        if ((KeypadScaleFactor == 1) | (KeypadScaleFactor == 0))
                            WCFChannelFactory.Write(m_PLCAddressKeypad, KeypadPopUp.Value);
                        else
                            WCFChannelFactory.Write(m_PLCAddressKeypad,
                                (Convert.ToDouble(KeypadPopUp.Value) / m_KeypadScaleFactor).ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to write value - " + ex.Message);
                    }
                }

                KeypadPopUp.Visible = false;
            }
        }

        //***********************************************************
        //* If label is clicked, pop up a keypad for data entry.
        //* Limit this to the left-click of the mouse only.
        //***********************************************************
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            if (e.GetType() == typeof(MouseEventArgs))
            {
                var mea = (MouseEventArgs)e;
                if (mea.Button.ToString() == "Left")
                    if (m_PLCAddressKeypad != null && (string.Compare(m_PLCAddressKeypad, string.Empty) != 0) & Enabled)
                        ActivateKeypad();
            }
        }

        public void ActivateKeypad()
        {
            if (KeypadPopUp == null)
            {
                if (KeypadAlphaNumeric)
                    KeypadPopUp = new AlphaKeyboard3(m_KeypadWidth);
                else
                    KeypadPopUp = new Keypad_v3(m_KeypadWidth);
                KeypadPopUp.ButtonClick += KeypadPopUp_ButtonClick;
                KeypadPopUp.StartPosition = FormStartPosition.CenterScreen;
                KeypadPopUp.TopMost = true;
            }

            //***************************
            //*Set the font and forecolor
            //****************************
            if (m_KeypadFont != null)
                KeypadPopUp.Font = m_KeypadFont;
            KeypadPopUp.ForeColor = m_KeypadForeColor;

            KeypadPopUp.Text = KeypadText;
            if (KeypadShowCurrentValue)
                try
                {
                    try
                    {
                        var ScaledValue = Convert.ToDouble(Value);
                        KeypadPopUp.Value = ScaledValue.ToString();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Failed to Scale current value of " + Value);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Failed to read current value of " + m_PLCAddressKeypad);
                }
            else
                KeypadPopUp.Value = string.Empty;

            KeypadPopUp.Visible = true;
        }

        #endregion

    }
    internal class HMI_Segment7LEDDesigner : ControlDesigner
    {
        private DesignerActionListCollection actionLists;

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionLists == null)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new HMI_Segment7LEDListItem(this));
                }

                return actionLists;
            }
        }
    }

    internal class HMI_Segment7LEDListItem : DesignerActionList
    {
        private readonly HMISegment7LED _SevenSegment;

        public HMI_Segment7LEDListItem(HMI_Segment7LEDDesigner owner)
            : base(owner.Component)
        {
            _SevenSegment = (HMISegment7LED)owner.Component;
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
            items.Add(new DesignerActionMethodItem(this, "ShowTagList", "Choote Tag"));
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

        public void SetProperty(Control control, string propertyName, object value)
        {
            var pd = TypeDescriptor.GetProperties(control)[propertyName];
            pd.SetValue(control, value);
        }
    }
}
