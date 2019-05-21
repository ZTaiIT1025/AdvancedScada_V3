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
    [ToolboxBitmap(typeof(HMILCDMatrix), "DASNetLCDMatrix.ico")]
    public class HMILCDMatrix : Control
    {
        private IContainer icontainer_0;

        private Timer timer_0 = new Timer();

        private bool bool_0;

        private DAS_BorderStyle das_BorderStyle_0;

        private int int_0;

        private Color color_0 = Color.Blue;

        private int int_1 = 5;

        private int int_2 = 5;

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

        private string string_0 = "1234567890";

        private DAS_LCDMatrixStyle das_LCDMatrixStyle_0;

        private DAS_LCDDotStyle das_LCDDotStyle_0;

        private int int_8 = 4;

        private int int_9 = 1;

        private bool bool_3 = true;

        private Color color_8 = Color.DarkGray;

        private Color color_9 = Color.Silver;

        private int int_10 = 6;

        private float float_8 = 0.7f;

        private DAS_LCDCharLookupStyle das_LCDCharLookupStyle_0;

        private DAS_LCDWordWrapType das_LCDWordWrapType_0;

        private DAS_LCDCharTextMode das_LCDCharTextMode_0;

        private int int_11;

        private string string_1 = string.Empty;

        private int int_12;

        private Color color_10 = Color.LightGreen;

        private SortedList<string, CharMatrix> sortedList_0 = new SortedList<string, CharMatrix>();

        private SortedList<string, CharMatrix> sortedList_1 = new SortedList<string, CharMatrix>();

        private SortedList<string, CharMatrix> sortedList_2 = new SortedList<string, CharMatrix>();

        private SortedList<string, CharMatrix> sortedList_3 = new SortedList<string, CharMatrix>();

        private ArrayList arrayList_0 = new ArrayList();

        private ArrayList arrayList_1 = new ArrayList();

        private ArrayList arrayList_2 = new ArrayList();

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

        [Category("General")]
        [DefaultValue("6")]
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

        [Category("General")]
        [DefaultValue("DAS_LCDCharLookupStyle.LCLS_Standard")]
        [Description("Get/Set the LCD Char lookup type")]
        public DAS_LCDCharLookupStyle CharLookupType
        {
            get
            {
                return this.das_LCDCharLookupStyle_0;
            }
            set
            {
                this.das_LCDCharLookupStyle_0 = value;
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
        [DefaultValue("Color.Silver")]
        [Description("Get/Set the border color of LCD Dots")]
        public Color DotBorderColor
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
        [DefaultValue("Color.DarkGray")]
        [Description("Get/Set the frame color of the LCD Dots")]
        public Color DotFrameColor
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
        [DefaultValue("true")]
        [Description("Get/Set the visibility of the frame of LCD Dots")]
        public bool DotFrameVisible
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
        [DefaultValue("1")]
        [Description("Get/Set the gap between the LCD Dots")]
        public int DotGap
        {
            get
            {
                return this.int_9;
            }
            set
            {
                if (value >= 1)
                {
                    this.int_9 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("General")]
        [DefaultValue("4")]
        [Description("Get/Set the size of the LCD Dots")]
        public int DotSize
        {
            get
            {
                return this.int_8;
            }
            set
            {
                if (value >= 1)
                {
                    this.int_8 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("General")]
        [DefaultValue("0.7")]
        [Description("Get/Set the frame transparency rate of the LCD Dot Frames")]
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
        [DefaultValue("DAS_LCDDotStyle.LCDDS_Circle")]
        [Description("Get/Set the shape of the LCD Dots")]
        public DAS_LCDDotStyle LCDDotShape
        {
            get
            {
                return this.das_LCDDotStyle_0;
            }
            set
            {
                this.das_LCDDotStyle_0 = value;
                base.Invalidate();
            }
        }

        [Category("General")]
        [DefaultValue("DAS_LCDCharTextMode.LCTM_SingleText")]
        [Description("Get/Set the mode to display the LCD texts")]
        public DAS_LCDCharTextMode LCDTextMode
        {
            get
            {
                return this.das_LCDCharTextMode_0;
            }
            set
            {
                this.das_LCDCharTextMode_0 = value;
                base.Invalidate();
            }
        }

        [Category("General")]
        [DefaultValue("DAS_LCDMatrixStyle.LCDMX_5x7")]
        [Description("Get/Set the LCD Matrix Style")]
        public DAS_LCDMatrixStyle MatrixType
        {
            get
            {
                return this.das_LCDMatrixStyle_0;
            }
            set
            {
                this.das_LCDMatrixStyle_0 = value;
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
        [DefaultValue("0")]
        [Description("Get/Set the vertical offset of the second Text value display")]
        public int SecondTextOffsetY
        {
            get
            {
                return this.int_12;
            }
            set
            {
                this.int_12 = value;
                base.Invalidate();
            }
        }

        [Category("General")]
        [DefaultValue("")]
        [Description("Get/Set the second text value")]
        public string SecondValue
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

        [Category("General")]
        [DefaultValue("Color.LightGreean")]
        [Description("Get/Set the color to draw the second text value")]
        public Color SecondValueColor
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
        [DefaultValue("0")]
        [Description("Get/Set the vertical offset of the Text display")]
        public int TextOffsetY
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

        [Category("General")]
        [DefaultValue("1234567890")]
        [Description("Get/Set the LCD value")]
        public string Value
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
        [DefaultValue("DAS_LCDWordWrapType.LWWT_None")]
        [Description("Get/Set the wordwrap type which the LCD supports")]
        public DAS_LCDWordWrapType WordWrap
        {
            get
            {
                return this.das_LCDWordWrapType_0;
            }
            set
            {
                this.das_LCDWordWrapType_0 = value;
                base.Invalidate();
            }
        }

        public HMILCDMatrix()
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
            this.method_3();
            this.method_0();
        }

        public void AddCustomizedLCDSecondValue(CharMatrix stChar, bool bUIUpdate)
        {
            this.arrayList_1.Add(stChar);
            if (bUIUpdate)
            {
                base.Invalidate();
            }
        }

        public void AddCustomizedLCDValue(CharMatrix stChar, bool bUIUpdate)
        {
            this.arrayList_0.Add(stChar);
            if (bUIUpdate)
            {
                base.Invalidate();
            }
        }

        public void AddLCDLineText(LCDLineText stLine, bool bUIUpdate)
        {
            this.arrayList_2.Add(stLine);
            if (bUIUpdate)
            {
                base.Invalidate();
            }
        }

        private void method_0()
        {
            this.icontainer_0 = new System.ComponentModel.Container();
        }

        private string method_1(string string_2)
        {
            string str = string.Empty;
            str = string.Concat("Key_", string_2);
            if (!this.sortedList_0.ContainsKey(str))
            {
                str = string.Empty;
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
                string str13 = ".";
                string str14 = ",";
                string str15 = ";";
                string str16 = ":";
                string str17 = "!";
                string str18 = "\"";
                string str19 = "'";
                string str20 = "-";
                string str21 = "~";
                string str22 = "@";
                string str23 = "#";
                string str24 = "_";
                string str25 = "^";
                string str26 = "&";
                string str27 = "(";
                string str28 = ")";
                if (string_2 == str1)
                {
                    str = "Key_QuestionM";
                }
                else if (string_2 == str2)
                {
                    str = "Key_Dollar";
                }
                else if (string_2 == str3)
                {
                    str = "Key_Percentage";
                }
                else if (string_2 == str4)
                {
                    str = "Key_Star";
                }
                else if (string_2 == str5)
                {
                    str = "Key_LeftSP";
                }
                else if (string_2 == str6)
                {
                    str = "Key_RightSP";
                }
                else if (string_2 == str7)
                {
                    str = "Key_Plus";
                }
                else if (string_2 == str8)
                {
                    str = "Key_Minus";
                }
                else if (string_2 == str9)
                {
                    str = "Key_Divide";
                }
                else if (string_2 == str10)
                {
                    str = "Key_Equal";
                }
                else if (string_2 == str11)
                {
                    str = "Key_Greater";
                }
                else if (string_2 == str12)
                {
                    str = "Key_Less";
                }
                else if (string_2 == str13)
                {
                    str = "Key_Period";
                }
                else if (string_2 == str14)
                {
                    str = "Key_Comma";
                }
                else if (string_2 == str15)
                {
                    str = "Key_Semicolon";
                }
                else if (string_2 == str16)
                {
                    str = "Key_Colon";
                }
                else if (string_2 == str17)
                {
                    str = "Key_Exclamation";
                }
                else if (string_2 == str18)
                {
                    str = "Key_DQuotation";
                }
                else if (string_2 == str19)
                {
                    str = "Key_SQuotation";
                }
                else if (string_2 == str20)
                {
                    str = "Key_Dash";
                }
                else if (string_2 == str21)
                {
                    str = "Key_Title";
                }
                else if (string_2 == str22)
                {
                    str = "Key_At";
                }
                else if (string_2 == str23)
                {
                    str = "Key_Pound";
                }
                else if (string_2 == str24)
                {
                    str = "Key_UnderScore";
                }
                else if (string_2 == str25)
                {
                    str = "Key_Caret";
                }
                else if (string_2 == str26)
                {
                    str = "Key_And";
                }
                else if (string_2 == str27)
                {
                    str = "Key_LeftP";
                }
                else if (string_2 == str28)
                {
                    str = "Key_RightP";
                }
            }
            return str;
        }

        private bool method_2(Graphics graphics_0, int int_13, int int_14, string string_2, CharMatrix charMatrix_0, Color color_11, bool bool_4)
        {
            CharMatrix charMatrix0 = new CharMatrix();
            bool flag = false;
            int num = 0;
            int num1 = 0;
            if (this.das_LCDMatrixStyle_0 == DAS_LCDMatrixStyle.LCDMS_5x7)
            {
                num1 = 5;
                num = 7;
            }
            else if (this.das_LCDMatrixStyle_0 == DAS_LCDMatrixStyle.LCDMS_5x8)
            {
                num1 = 5;
                num = 8;
            }
            else if (this.das_LCDMatrixStyle_0 != DAS_LCDMatrixStyle.LCDMS_6x9)
            {
                if (this.das_LCDMatrixStyle_0 != DAS_LCDMatrixStyle.LCDMS_7x8)
                {
                    return flag;
                }
                num1 = 7;
                num = 8;
            }
            else
            {
                num1 = 6;
                num = 9;
            }
            charMatrix0.LowDWord = (ulong)0;
            charMatrix0.HiDWord = (ulong)0;
            if (this.das_LCDCharLookupStyle_0 != DAS_LCDCharLookupStyle.LCLS_Standard)
            {
                charMatrix0 = charMatrix_0;
            }
            else if (string_2 == string.Empty)
            {
                charMatrix0 = charMatrix_0;
            }
            else if (this.das_LCDMatrixStyle_0 == DAS_LCDMatrixStyle.LCDMS_5x7)
            {
                if (!this.sortedList_0.ContainsKey(string_2))
                {
                    return flag;
                }
                charMatrix0 = this.sortedList_0[string_2];
            }
            else if (this.das_LCDMatrixStyle_0 == DAS_LCDMatrixStyle.LCDMS_5x8)
            {
                if (!this.sortedList_1.ContainsKey(string_2))
                {
                    return flag;
                }
                charMatrix0 = this.sortedList_1[string_2];
            }
            else if (this.das_LCDMatrixStyle_0 == DAS_LCDMatrixStyle.LCDMS_6x9)
            {
                if (!this.sortedList_2.ContainsKey(string_2))
                {
                    return flag;
                }
                charMatrix0 = this.sortedList_2[string_2];
            }
            else if (this.das_LCDMatrixStyle_0 == DAS_LCDMatrixStyle.LCDMS_7x8)
            {
                if (!this.sortedList_3.ContainsKey(string_2))
                {
                    return flag;
                }
                charMatrix0 = this.sortedList_3[string_2];
            }
            Color color11 = color_11;
            Color color8 = this.color_8;
            Color color9 = this.color_9;
            int float8 = 255;
            if ((double)this.float_8 > 0)
            {
                float8 = 255 - (int)(255f * this.float_8);
                color8 = Color.FromArgb(float8, this.color_8);
                color9 = Color.FromArgb(float8, this.color_9);
            }
            Pen pen = new Pen(color9);
            SolidBrush solidBrush = new SolidBrush(color11);
            ulong num2 = (ulong)1;
            int num3 = 1;
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num1; j++)
                {
                    bool flag1 = false;
                    if (num3 < 32)
                    {
                        if ((charMatrix0.LowDWord & num2) != (long)0)
                        {
                            flag1 = true;
                        }
                    }
                    else if ((charMatrix0.HiDWord & num2) != (long)0)
                    {
                        flag1 = true;
                    }
                    num3++;
                    if (num3 != 32)
                    {
                        num2 = num2 * (long)2;
                    }
                    else
                    {
                        num2 = (ulong)1;
                    }
                    if (flag1 || !flag1 && bool_4)
                    {
                        if (flag1 || !bool_4)
                        {
                            solidBrush.Color = color11;
                        }
                        else
                        {
                            solidBrush.Color = color8;
                        }
                        Rectangle rectangle = new Rectangle()
                        {
                            X = int_13 + (this.int_9 + this.int_8) * j + this.int_9 / 2,
                            Width = this.int_8,
                            Y = int_14 + (this.int_9 + this.int_8) * i + this.int_9 / 2,
                            Height = this.int_8
                        };
                        if (this.das_LCDDotStyle_0 == DAS_LCDDotStyle.LCDDS_Circle)
                        {
                            graphics_0.FillEllipse(solidBrush, rectangle);
                            graphics_0.DrawEllipse(pen, rectangle);
                        }
                        else if (this.das_LCDDotStyle_0 == DAS_LCDDotStyle.LCDDS_Squre)
                        {
                            graphics_0.FillRectangle(solidBrush, rectangle);
                            graphics_0.DrawRectangle(pen, rectangle);
                        }
                        else if (this.das_LCDDotStyle_0 == DAS_LCDDotStyle.LCDDS_Diamond)
                        {
                            Point[] left = new Point[4];
                            left[0].X = (rectangle.Left + rectangle.Right) / 2;
                            left[0].Y = rectangle.Top;
                            left[1].X = rectangle.Left;
                            left[1].Y = (rectangle.Top + rectangle.Bottom) / 2;
                            left[2].X = (rectangle.Left + rectangle.Right) / 2;
                            left[2].Y = rectangle.Bottom;
                            left[3].X = rectangle.Right;
                            left[3].Y = (rectangle.Top + rectangle.Bottom) / 2;
                            graphics_0.FillPolygon(solidBrush, left);
                            graphics_0.DrawPolygon(pen, left);
                        }
                        else if (this.das_LCDDotStyle_0 == DAS_LCDDotStyle.LCDMS_LeftTriangle)
                        {
                            Point[] right = new Point[3];
                            right[0].X = rectangle.Right;
                            right[0].Y = rectangle.Top;
                            right[1].X = rectangle.Right;
                            right[1].Y = rectangle.Bottom;
                            right[2].X = rectangle.Left;
                            right[2].Y = (rectangle.Top + rectangle.Bottom) / 2;
                            graphics_0.FillPolygon(solidBrush, right);
                            graphics_0.DrawPolygon(pen, right);
                        }
                        else if (this.das_LCDDotStyle_0 == DAS_LCDDotStyle.LCDMS_RightTriangle)
                        {
                            Point[] top = new Point[3];
                            top[0].X = rectangle.Left;
                            top[0].Y = rectangle.Top;
                            top[1].X = rectangle.Left;
                            top[1].Y = rectangle.Bottom;
                            top[2].X = rectangle.Right;
                            top[2].Y = (rectangle.Top + rectangle.Bottom) / 2;
                            graphics_0.FillPolygon(solidBrush, top);
                            graphics_0.DrawPolygon(pen, top);
                        }
                        else if (this.das_LCDDotStyle_0 == DAS_LCDDotStyle.LCDMS_TopTriangle)
                        {
                            Point[] bottom = new Point[3];
                            bottom[0].X = rectangle.Left;
                            bottom[0].Y = rectangle.Bottom;
                            bottom[1].X = rectangle.Right;
                            bottom[1].Y = rectangle.Bottom;
                            bottom[2].X = (rectangle.Left + rectangle.Right) / 2;
                            bottom[2].Y = rectangle.Top;
                            graphics_0.FillPolygon(solidBrush, bottom);
                            graphics_0.DrawPolygon(pen, bottom);
                        }
                        else if (this.das_LCDDotStyle_0 == DAS_LCDDotStyle.LCDMS_BottomTriangle)
                        {
                            Point[] pointArray = new Point[3];
                            pointArray[0].X = rectangle.Left;
                            pointArray[0].Y = rectangle.Top;
                            pointArray[1].X = rectangle.Right;
                            pointArray[1].Y = rectangle.Top;
                            pointArray[2].X = (rectangle.Left + rectangle.Right) / 2;
                            pointArray[2].Y = rectangle.Bottom;
                            graphics_0.FillPolygon(solidBrush, pointArray);
                            graphics_0.DrawPolygon(pen, pointArray);
                        }
                    }
                }
            }
            solidBrush.Dispose();
            pen.Dispose();
            flag = true;
            return true;
        }

        private void method_3()
        {
            CharMatrix charMatrix = new CharMatrix();
            charMatrix.HiDWord = (ulong)7;
            charMatrix.LowDWord = (ulong)591062574;
            this.sortedList_0.Add("Key_0", charMatrix);
            charMatrix.HiDWord = (ulong)7;
            charMatrix.LowDWord = (ulong)138547396;
            this.sortedList_0.Add("Key_1", charMatrix);
            charMatrix.HiDWord = (ulong)15;
            charMatrix.LowDWord = (ulong)1145324078;
            this.sortedList_0.Add("Key_2", charMatrix);
            charMatrix.HiDWord = (ulong)7;
            charMatrix.LowDWord = (ulong)587469087;
            this.sortedList_0.Add("Key_3", charMatrix);
            charMatrix.HiDWord = (ulong)4;
            charMatrix.LowDWord = (ulong)301246856;
            this.sortedList_0.Add("Key_4", charMatrix);
            charMatrix.HiDWord = (ulong)7;
            charMatrix.LowDWord = (ulong)587742271;
            this.sortedList_0.Add("Key_5", charMatrix);
            charMatrix.HiDWord = (ulong)7;
            charMatrix.LowDWord = (ulong)588743756;
            this.sortedList_0.Add("Key_6", charMatrix);
            charMatrix.HiDWord = (ulong)4;
            charMatrix.LowDWord = (ulong)277094943;
            this.sortedList_0.Add("Key_7", charMatrix);
            charMatrix.HiDWord = (ulong)7;
            charMatrix.LowDWord = (ulong)588727854;
            this.sortedList_0.Add("Key_8", charMatrix);
            charMatrix.HiDWord = (ulong)3;
            charMatrix.LowDWord = (ulong)286213678;
            this.sortedList_0.Add("Key_9", charMatrix);
            charMatrix.HiDWord = (ulong)8;
            charMatrix.LowDWord = (ulong)1663026734;
            this.sortedList_0.Add("Key_A", charMatrix);
            charMatrix.HiDWord = (ulong)7;
            charMatrix.LowDWord = (ulong)1662502447;
            this.sortedList_0.Add("Key_B", charMatrix);
            charMatrix.HiDWord = (ulong)7;
            charMatrix.LowDWord = (ulong)571508270;
            this.sortedList_0.Add("Key_C", charMatrix);
            charMatrix.HiDWord = (ulong)3;
            charMatrix.LowDWord = (ulong)1394132263;
            this.sortedList_0.Add("Key_D", charMatrix);
            charMatrix.HiDWord = (ulong)15;
            charMatrix.LowDWord = (ulong)1108837439;
            this.sortedList_0.Add("Key_E", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)1108837439;
            this.sortedList_0.Add("Key_F", charMatrix);
            charMatrix.HiDWord = (ulong)15;
            charMatrix.LowDWord = (ulong)589202990;
            this.sortedList_0.Add("Key_G", charMatrix);
            charMatrix.HiDWord = (ulong)8;
            charMatrix.LowDWord = (ulong)1663026737;
            this.sortedList_0.Add("Key_H", charMatrix);
            charMatrix.HiDWord = (ulong)7;
            charMatrix.LowDWord = (ulong)138547342;
            this.sortedList_0.Add("Key_I", charMatrix);
            charMatrix.HiDWord = (ulong)3;
            charMatrix.LowDWord = (ulong)310649116;
            this.sortedList_0.Add("Key_J", charMatrix);
            charMatrix.HiDWord = (ulong)8;
            charMatrix.LowDWord = (ulong)1381078321;
            this.sortedList_0.Add("Key_K", charMatrix);
            charMatrix.HiDWord = (ulong)15;
            charMatrix.LowDWord = (ulong)1108378657;
            this.sortedList_0.Add("Key_L", charMatrix);
            charMatrix.HiDWord = (ulong)8;
            charMatrix.LowDWord = (ulong)1662703473;
            this.sortedList_0.Add("Key_M", charMatrix);
            charMatrix.HiDWord = (ulong)8;
            charMatrix.LowDWord = (ulong)1939525233;
            this.sortedList_0.Add("Key_N", charMatrix);
            charMatrix.HiDWord = (ulong)7;
            charMatrix.LowDWord = (ulong)588826158;
            this.sortedList_0.Add("Key_O", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)1108854319;
            this.sortedList_0.Add("Key_P", charMatrix);
            charMatrix.HiDWord = (ulong)8;
            charMatrix.LowDWord = (ulong)496682542;
            this.sortedList_0.Add("Key_Q", charMatrix);
            charMatrix.HiDWord = (ulong)8;
            charMatrix.LowDWord = (ulong)1381484079;
            this.sortedList_0.Add("Key_R", charMatrix);
            charMatrix.HiDWord = (ulong)7;
            charMatrix.LowDWord = (ulong)1627849790;
            this.sortedList_0.Add("Key_S", charMatrix);
            charMatrix.HiDWord = (ulong)2;
            charMatrix.LowDWord = (ulong)138547359;
            this.sortedList_0.Add("Key_T", charMatrix);
            charMatrix.HiDWord = (ulong)7;
            charMatrix.LowDWord = (ulong)588826161;
            this.sortedList_0.Add("Key_U", charMatrix);
            charMatrix.HiDWord = (ulong)2;
            charMatrix.LowDWord = (ulong)353945137;
            this.sortedList_0.Add("Key_V", charMatrix);
            charMatrix.HiDWord = (ulong)5;
            charMatrix.LowDWord = (ulong)727369265;
            this.sortedList_0.Add("Key_W", charMatrix);
            charMatrix.HiDWord = (ulong)8;
            charMatrix.LowDWord = (ulong)1654794801;
            this.sortedList_0.Add("Key_X", charMatrix);
            charMatrix.HiDWord = (ulong)2;
            charMatrix.LowDWord = (ulong)138757681;
            this.sortedList_0.Add("Key_Y", charMatrix);
            charMatrix.HiDWord = (ulong)15;
            charMatrix.LowDWord = (ulong)1109533215;
            this.sortedList_0.Add("Key_Z", charMatrix);
            charMatrix.HiDWord = (ulong)15;
            charMatrix.LowDWord = (ulong)602421248;
            this.sortedList_0.Add("Key_a", charMatrix);
            charMatrix.HiDWord = (ulong)7;
            charMatrix.LowDWord = (ulong)1662485537;
            this.sortedList_0.Add("Key_b", charMatrix);
            charMatrix.HiDWord = (ulong)7;
            charMatrix.LowDWord = (ulong)571521024;
            this.sortedList_0.Add("Key_c", charMatrix);
            charMatrix.HiDWord = (ulong)15;
            charMatrix.LowDWord = (ulong)589251088;
            this.sortedList_0.Add("Key_d", charMatrix);
            charMatrix.HiDWord = (ulong)15;
            charMatrix.LowDWord = (ulong)66631680;
            this.sortedList_0.Add("Key_e", charMatrix);
            charMatrix.HiDWord = (ulong)1;
            charMatrix.LowDWord = (ulong)69438028;
            this.sortedList_0.Add("Key_f", charMatrix);
            charMatrix.HiDWord = (ulong)7;
            charMatrix.LowDWord = (ulong)554649150;
            this.sortedList_0.Add("Key_g", charMatrix);
            charMatrix.HiDWord = (ulong)8;
            charMatrix.LowDWord = (ulong)1662628897;
            this.sortedList_0.Add("Key_h", charMatrix);
            charMatrix.HiDWord = (ulong)7;
            charMatrix.LowDWord = (ulong)138549252;
            this.sortedList_0.Add("Key_i", charMatrix);
            charMatrix.HiDWord = (ulong)3;
            charMatrix.LowDWord = (ulong)310652936;
            this.sortedList_0.Add("Key_j", charMatrix);
            charMatrix.HiDWord = (ulong)4;
            charMatrix.LowDWord = (ulong)1244832801;
            this.sortedList_0.Add("Key_k", charMatrix);
            charMatrix.HiDWord = (ulong)4;
            charMatrix.LowDWord = (ulong)138547332;
            this.sortedList_0.Add("Key_l", charMatrix);
            charMatrix.HiDWord = (ulong)10;
            charMatrix.LowDWord = (ulong)1801120768;
            this.sortedList_0.Add("Key_m", charMatrix);
            charMatrix.HiDWord = (ulong)8;
            charMatrix.LowDWord = (ulong)1662628864;
            this.sortedList_0.Add("Key_n", charMatrix);
            charMatrix.HiDWord = (ulong)7;
            charMatrix.LowDWord = (ulong)588822528;
            this.sortedList_0.Add("Key_o", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)1123597312;
            this.sortedList_0.Add("Key_p", charMatrix);
            charMatrix.HiDWord = (ulong)8;
            charMatrix.LowDWord = (ulong)568899584;
            this.sortedList_0.Add("Key_q", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)1108980736;
            this.sortedList_0.Add("Key_r", charMatrix);
            charMatrix.HiDWord = (ulong)7;
            charMatrix.LowDWord = (ulong)551598080;
            this.sortedList_0.Add("Key_s", charMatrix);
            charMatrix.HiDWord = (ulong)6;
            charMatrix.LowDWord = (ulong)606149698;
            this.sortedList_0.Add("Key_t", charMatrix);
            charMatrix.HiDWord = (ulong)11;
            charMatrix.LowDWord = (ulong)857261056;
            this.sortedList_0.Add("Key_u", charMatrix);
            charMatrix.HiDWord = (ulong)2;
            charMatrix.LowDWord = (ulong)353944576;
            this.sortedList_0.Add("Key_v", charMatrix);
            charMatrix.HiDWord = (ulong)5;
            charMatrix.LowDWord = (ulong)727237632;
            this.sortedList_0.Add("Key_w", charMatrix);
            charMatrix.HiDWord = (ulong)8;
            charMatrix.LowDWord = (ulong)1413825536;
            this.sortedList_0.Add("Key_x", charMatrix);
            charMatrix.HiDWord = (ulong)7;
            charMatrix.LowDWord = (ulong)568902656;
            this.sortedList_0.Add("Key_y", charMatrix);
            charMatrix.HiDWord = (ulong)15;
            charMatrix.LowDWord = (ulong)1145338880;
            this.sortedList_0.Add("Key_z", charMatrix);
            charMatrix.HiDWord = (ulong)2;
            charMatrix.LowDWord = (ulong)4473390;
            this.sortedList_0.Add("Key_QuestionM", charMatrix);
            charMatrix.HiDWord = (ulong)12;
            charMatrix.LowDWord = (ulong)841097827;
            this.sortedList_0.Add("Key_Percentage", charMatrix);
            charMatrix.HiDWord = (ulong)2;
            charMatrix.LowDWord = (ulong)524752836;
            this.sortedList_0.Add("Key_Dollar", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)156718208;
            this.sortedList_0.Add("Key_Star", charMatrix);
            charMatrix.HiDWord = (ulong)6;
            charMatrix.LowDWord = (ulong)138547340;
            this.sortedList_0.Add("Key_LeftSP", charMatrix);
            charMatrix.HiDWord = (ulong)3;
            charMatrix.LowDWord = (ulong)138547334;
            this.sortedList_0.Add("Key_RightSP", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)139432064;
            this.sortedList_0.Add("Key_Plus", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)1015808;
            this.sortedList_0.Add("Key_Minus", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)35791360;
            this.sortedList_0.Add("Key_Divide", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)32537600;
            this.sortedList_0.Add("Key_Equal", charMatrix);
            charMatrix.HiDWord = (ulong)1;
            charMatrix.LowDWord = (ulong)143138946;
            this.sortedList_0.Add("Key_Greater", charMatrix);
            charMatrix.HiDWord = (ulong)4;
            charMatrix.LowDWord = (ulong)136349832;
            this.sortedList_0.Add("Key_Less", charMatrix);
            charMatrix.HiDWord = (ulong)3;
            charMatrix.LowDWord = (ulong)201326592;
            this.sortedList_0.Add("Key_Period", charMatrix);
            charMatrix.HiDWord = (ulong)1;
            charMatrix.LowDWord = (ulong)140509184;
            this.sortedList_0.Add("Key_Comma", charMatrix);
            charMatrix.HiDWord = (ulong)1;
            charMatrix.LowDWord = (ulong)140515520;
            this.sortedList_0.Add("Key_Semicolon", charMatrix);
            charMatrix.HiDWord = (ulong)3;
            charMatrix.LowDWord = (ulong)201529344;
            this.sortedList_0.Add("Key_Colon", charMatrix);
            charMatrix.HiDWord = (ulong)2;
            charMatrix.LowDWord = (ulong)4329604;
            this.sortedList_0.Add("Key_Exclamation", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)10570;
            this.sortedList_0.Add("Key_DQuotation", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)4228;
            this.sortedList_0.Add("Key_SQuotation", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)1015808;
            this.sortedList_0.Add("Key_Dash", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)9078784;
            this.sortedList_0.Add("Key_Tilde", charMatrix);
            charMatrix.HiDWord = (ulong)7;
            charMatrix.LowDWord = (ulong)727433774;
            this.sortedList_0.Add("Key_At", charMatrix);
            charMatrix.HiDWord = (ulong)5;
            charMatrix.LowDWord = (ulong)368409930;
            this.sortedList_0.Add("Key_Pound", charMatrix);
            charMatrix.HiDWord = (ulong)15;
            charMatrix.LowDWord = (ulong)1073741824;
            this.sortedList_0.Add("Key_UnderScore", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)17732;
            this.sortedList_0.Add("Key_Caret", charMatrix);
            charMatrix.HiDWord = (ulong)2;
            charMatrix.LowDWord = (ulong)68191300;
            this.sortedList_0.Add("Key_LeftP", charMatrix);
            charMatrix.HiDWord = (ulong)2;
            charMatrix.LowDWord = (ulong)285753604;
            this.sortedList_0.Add("Key_RightP", charMatrix);
            charMatrix.HiDWord = (ulong)11;
            charMatrix.LowDWord = (ulong)324080934;
            this.sortedList_0.Add("Key_And", charMatrix);
            charMatrix.HiDWord = (ulong)232;
            charMatrix.LowDWord = (ulong)1664804398;
            this.sortedList_1.Add("Key_0", charMatrix);
            charMatrix.HiDWord = (ulong)226;
            charMatrix.LowDWord = (ulong)138547396;
            this.sortedList_1.Add("Key_1", charMatrix);
            charMatrix.HiDWord = (ulong)497;
            charMatrix.LowDWord = (ulong)143147566;
            this.sortedList_1.Add("Key_2", charMatrix);
            charMatrix.HiDWord = (ulong)232;
            charMatrix.LowDWord = (ulong)1619202335;
            this.sortedList_1.Add("Key_3", charMatrix);
            charMatrix.HiDWord = (ulong)132;
            charMatrix.LowDWord = (ulong)1049930120;
            this.sortedList_1.Add("Key_4", charMatrix);
            charMatrix.HiDWord = (ulong)248;
            charMatrix.LowDWord = (ulong)554140735;
            this.sortedList_1.Add("Key_5", charMatrix);
            charMatrix.HiDWord = (ulong)232;
            charMatrix.LowDWord = (ulong)1659929676;
            this.sortedList_1.Add("Key_6", charMatrix);
            charMatrix.HiDWord = (ulong)66;
            charMatrix.LowDWord = (ulong)138691103;
            this.sortedList_1.Add("Key_7", charMatrix);
            charMatrix.HiDWord = (ulong)232;
            charMatrix.LowDWord = (ulong)1662469678;
            this.sortedList_1.Add("Key_8", charMatrix);
            charMatrix.HiDWord = (ulong)100;
            charMatrix.LowDWord = (ulong)554649134;
            this.sortedList_1.Add("Key_9", charMatrix);
            charMatrix.HiDWord = (ulong)280;
            charMatrix.LowDWord = (ulong)1663026734;
            this.sortedList_1.Add("Key_A", charMatrix);
            charMatrix.HiDWord = (ulong)248;
            charMatrix.LowDWord = (ulong)1662502447;
            this.sortedList_1.Add("Key_B", charMatrix);
            charMatrix.HiDWord = (ulong)232;
            charMatrix.LowDWord = (ulong)1108379182;
            this.sortedList_1.Add("Key_C", charMatrix);
            charMatrix.HiDWord = (ulong)116;
            charMatrix.LowDWord = (ulong)1662567719;
            this.sortedList_1.Add("Key_D", charMatrix);
            charMatrix.HiDWord = (ulong)496;
            charMatrix.LowDWord = (ulong)1109361727;
            this.sortedList_1.Add("Key_E", charMatrix);
            charMatrix.HiDWord = (ulong)16;
            charMatrix.LowDWord = (ulong)1108837439;
            this.sortedList_1.Add("Key_F", charMatrix);
            charMatrix.HiDWord = (ulong)232;
            charMatrix.LowDWord = (ulong)1662944814;
            this.sortedList_1.Add("Key_G", charMatrix);
            charMatrix.HiDWord = (ulong)280;
            charMatrix.LowDWord = (ulong)1663026737;
            this.sortedList_1.Add("Key_H", charMatrix);
            charMatrix.HiDWord = (ulong)226;
            charMatrix.LowDWord = (ulong)138547342;
            this.sortedList_1.Add("Key_I", charMatrix);
            charMatrix.HiDWord = (ulong)100;
            charMatrix.LowDWord = (ulong)1350836508;
            this.sortedList_1.Add("Key_J", charMatrix);
            charMatrix.HiDWord = (ulong)276;
            charMatrix.LowDWord = (ulong)1244763441;
            this.sortedList_1.Add("Key_K", charMatrix);
            charMatrix.HiDWord = (ulong)496;
            charMatrix.LowDWord = (ulong)1108378657;
            this.sortedList_1.Add("Key_L", charMatrix);
            charMatrix.HiDWord = (ulong)280;
            charMatrix.LowDWord = (ulong)1666897777;
            this.sortedList_1.Add("Key_M", charMatrix);
            charMatrix.HiDWord = (ulong)280;
            charMatrix.LowDWord = (ulong)1939525169;
            this.sortedList_1.Add("Key_N", charMatrix);
            charMatrix.HiDWord = (ulong)232;
            charMatrix.LowDWord = (ulong)1662567982;
            this.sortedList_1.Add("Key_O", charMatrix);
            charMatrix.HiDWord = (ulong)16;
            charMatrix.LowDWord = (ulong)1108854319;
            this.sortedList_1.Add("Key_P", charMatrix);
            charMatrix.HiDWord = (ulong)356;
            charMatrix.LowDWord = (ulong)1796785710;
            this.sortedList_1.Add("Key_Q", charMatrix);
            charMatrix.HiDWord = (ulong)276;
            charMatrix.LowDWord = (ulong)1245169199;
            this.sortedList_1.Add("Key_R", charMatrix);
            charMatrix.HiDWord = (ulong)232;
            charMatrix.LowDWord = (ulong)549520430;
            this.sortedList_1.Add("Key_S", charMatrix);
            charMatrix.HiDWord = (ulong)66;
            charMatrix.LowDWord = (ulong)138547359;
            this.sortedList_1.Add("Key_T", charMatrix);
            charMatrix.HiDWord = (ulong)232;
            charMatrix.LowDWord = (ulong)1662567985;
            this.sortedList_1.Add("Key_U", charMatrix);
            charMatrix.HiDWord = (ulong)69;
            charMatrix.LowDWord = (ulong)588826161;
            this.sortedList_1.Add("Key_V", charMatrix);
            charMatrix.HiDWord = (ulong)285;
            charMatrix.LowDWord = (ulong)1801111089;
            this.sortedList_1.Add("Key_W", charMatrix);
            charMatrix.HiDWord = (ulong)280;
            charMatrix.LowDWord = (ulong)1413622321;
            this.sortedList_1.Add("Key_X", charMatrix);
            charMatrix.HiDWord = (ulong)66;
            charMatrix.LowDWord = (ulong)138757681;
            this.sortedList_1.Add("Key_Y", charMatrix);
            charMatrix.HiDWord = (ulong)496;
            charMatrix.LowDWord = (ulong)1145324063;
            this.sortedList_1.Add("Key_Z", charMatrix);
            charMatrix.HiDWord = (ulong)488;
            charMatrix.LowDWord = (ulong)1676163072;
            this.sortedList_1.Add("Key_a", charMatrix);
            charMatrix.HiDWord = (ulong)248;
            charMatrix.LowDWord = (ulong)1659929633;
            this.sortedList_1.Add("Key_b", charMatrix);
            charMatrix.HiDWord = (ulong)232;
            charMatrix.LowDWord = (ulong)1108916224;
            this.sortedList_1.Add("Key_c", charMatrix);
            charMatrix.HiDWord = (ulong)488;
            charMatrix.LowDWord = (ulong)1676165648;
            this.sortedList_1.Add("Key_d", charMatrix);
            charMatrix.HiDWord = (ulong)224;
            charMatrix.LowDWord = (ulong)2132326400;
            this.sortedList_1.Add("Key_e", charMatrix);
            charMatrix.HiDWord = (ulong)33;
            charMatrix.LowDWord = (ulong)69438028;
            this.sortedList_1.Add("Key_f", charMatrix);
            charMatrix.HiDWord = (ulong)232;
            charMatrix.LowDWord = (ulong)568903616;
            this.sortedList_1.Add("Key_g", charMatrix);
            charMatrix.HiDWord = (ulong)280;
            charMatrix.LowDWord = (ulong)1664517153;
            this.sortedList_1.Add("Key_h", charMatrix);
            charMatrix.HiDWord = (ulong)226;
            charMatrix.LowDWord = (ulong)138549252;
            this.sortedList_1.Add("Key_i", charMatrix);
            charMatrix.HiDWord = (ulong)100;
            charMatrix.LowDWord = (ulong)1350840328;
            this.sortedList_1.Add("Key_j", charMatrix);
            charMatrix.HiDWord = (ulong)276;
            charMatrix.LowDWord = (ulong)1314178081;
            this.sortedList_1.Add("Key_k", charMatrix);
            charMatrix.HiDWord = (ulong)130;
            charMatrix.LowDWord = (ulong)138547332;
            this.sortedList_1.Add("Key_l", charMatrix);
            charMatrix.HiDWord = (ulong)282;
            charMatrix.LowDWord = (ulong)1801120768;
            this.sortedList_1.Add("Key_m", charMatrix);
            charMatrix.HiDWord = (ulong)280;
            charMatrix.LowDWord = (ulong)1662628864;
            this.sortedList_1.Add("Key_n", charMatrix);
            charMatrix.HiDWord = (ulong)232;
            charMatrix.LowDWord = (ulong)1662564352;
            this.sortedList_1.Add("Key_o", charMatrix);
            charMatrix.HiDWord = (ulong)16;
            charMatrix.LowDWord = (ulong)1123597312;
            this.sortedList_1.Add("Key_p", charMatrix);
            charMatrix.HiDWord = (ulong)264;
            charMatrix.LowDWord = (ulong)568899584;
            this.sortedList_1.Add("Key_q", charMatrix);
            charMatrix.HiDWord = (ulong)16;
            charMatrix.LowDWord = (ulong)1108980736;
            this.sortedList_1.Add("Key_r", charMatrix);
            charMatrix.HiDWord = (ulong)232;
            charMatrix.LowDWord = (ulong)274774016;
            this.sortedList_1.Add("Key_s", charMatrix);
            charMatrix.HiDWord = (ulong)201;
            charMatrix.LowDWord = (ulong)69437504;
            this.sortedList_1.Add("Key_t", charMatrix);
            charMatrix.HiDWord = (ulong)364;
            charMatrix.LowDWord = (ulong)1662567424;
            this.sortedList_1.Add("Key_u", charMatrix);
            charMatrix.HiDWord = (ulong)69;
            charMatrix.LowDWord = (ulong)588825600;
            this.sortedList_1.Add("Key_v", charMatrix);
            charMatrix.HiDWord = (ulong)170;
            charMatrix.LowDWord = (ulong)1800979456;
            this.sortedList_1.Add("Key_w", charMatrix);
            charMatrix.HiDWord = (ulong)277;
            charMatrix.LowDWord = (ulong)138757120;
            this.sortedList_1.Add("Key_x", charMatrix);
            charMatrix.HiDWord = (ulong)232;
            charMatrix.LowDWord = (ulong)568902656;
            this.sortedList_1.Add("Key_y", charMatrix);
            charMatrix.HiDWord = (ulong)496;
            charMatrix.LowDWord = (ulong)1145338880;
            this.sortedList_1.Add("Key_z", charMatrix);
            charMatrix.HiDWord = (ulong)64;
            charMatrix.LowDWord = (ulong)138691118;
            this.sortedList_1.Add("Key_QuestionM", charMatrix);
            charMatrix.HiDWord = (ulong)396;
            charMatrix.LowDWord = (ulong)1145326688;
            this.sortedList_1.Add("Key_Percentage", charMatrix);
            charMatrix.HiDWord = (ulong)71;
            charMatrix.LowDWord = (ulong)1757616068;
            this.sortedList_1.Add("Key_Dollar", charMatrix);
            charMatrix.HiDWord = (ulong)2;
            charMatrix.LowDWord = (ulong)719803520;
            this.sortedList_1.Add("Key_Star", charMatrix);
            charMatrix.HiDWord = (ulong)194;
            charMatrix.LowDWord = (ulong)138547340;
            this.sortedList_1.Add("Key_LeftSP", charMatrix);
            charMatrix.HiDWord = (ulong)98;
            charMatrix.LowDWord = (ulong)138547334;
            this.sortedList_1.Add("Key_RightSP", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)139432064;
            this.sortedList_1.Add("Key_Plus", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)32505856;
            this.sortedList_1.Add("Key_Minus", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)1145323520;
            this.sortedList_1.Add("Key_Divide", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)1041203200;
            this.sortedList_1.Add("Key_Equal", charMatrix);
            charMatrix.HiDWord = (ulong)1;
            charMatrix.LowDWord = (ulong)143138946;
            this.sortedList_1.Add("Key_Greater", charMatrix);
            charMatrix.HiDWord = (ulong)4;
            charMatrix.LowDWord = (ulong)136349832;
            this.sortedList_1.Add("Key_Less", charMatrix);
            charMatrix.HiDWord = (ulong)99;
            charMatrix.LowDWord = (ulong)0;
            this.sortedList_1.Add("Key_Period", charMatrix);
            charMatrix.HiDWord = (ulong)34;
            charMatrix.LowDWord = (ulong)201326592;
            this.sortedList_1.Add("Key_Comma", charMatrix);
            charMatrix.HiDWord = (ulong)34;
            charMatrix.LowDWord = (ulong)201529344;
            this.sortedList_1.Add("Key_Semicolon", charMatrix);
            charMatrix.HiDWord = (ulong)99;
            charMatrix.LowDWord = (ulong)6488064;
            this.sortedList_1.Add("Key_Colon", charMatrix);
            charMatrix.HiDWord = (ulong)64;
            charMatrix.LowDWord = (ulong)138547332;
            this.sortedList_1.Add("Key_Exclamation", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)10570;
            this.sortedList_1.Add("Key_DQuotation", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)4228;
            this.sortedList_1.Add("Key_SQuotation", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)1015808;
            this.sortedList_1.Add("Key_Dash", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)9078784;
            this.sortedList_1.Add("Key_Tilde", charMatrix);
            charMatrix.HiDWord = (ulong)100;
            charMatrix.LowDWord = (ulong)1801373230;
            this.sortedList_1.Add("Key_At", charMatrix);
            charMatrix.HiDWord = (ulong)5;
            charMatrix.LowDWord = (ulong)1051032896;
            this.sortedList_1.Add("Key_Pound", charMatrix);
            charMatrix.HiDWord = (ulong)496;
            charMatrix.LowDWord = (ulong)0;
            this.sortedList_1.Add("Key_UnderScore", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)17732;
            this.sortedList_1.Add("Key_Caret", charMatrix);
            charMatrix.HiDWord = (ulong)130;
            charMatrix.LowDWord = (ulong)69273736;
            this.sortedList_1.Add("Key_LeftP", charMatrix);
            charMatrix.HiDWord = (ulong)34;
            charMatrix.LowDWord = (ulong)277094530;
            this.sortedList_1.Add("Key_RightP", charMatrix);
            charMatrix.HiDWord = (ulong)356;
            charMatrix.LowDWord = (ulong)1780655398;
            this.sortedList_1.Add("Key_And", charMatrix);
            charMatrix.HiDWord = (ulong)4000817;
            charMatrix.LowDWord = (ulong)1705449566;
            this.sortedList_2.Add("Key_0", charMatrix);
            charMatrix.HiDWord = (ulong)3686660;
            charMatrix.LowDWord = (ulong)136348424;
            this.sortedList_2.Add("Key_1", charMatrix);
            charMatrix.HiDWord = (ulong)8259616;
            charMatrix.LowDWord = (ulong)1585580126;
            this.sortedList_2.Add("Key_2", charMatrix);
            charMatrix.HiDWord = (ulong)4000784;
            charMatrix.LowDWord = (ulong)511838302;
            this.sortedList_2.Add("Key_3", charMatrix);
            charMatrix.HiDWord = (ulong)2131944;
            charMatrix.LowDWord = (ulong)1363756560;
            this.sortedList_2.Add("Key_4", charMatrix);
            charMatrix.HiDWord = (ulong)4000784;
            charMatrix.LowDWord = (ulong)520360063;
            this.sortedList_2.Add("Key_5", charMatrix);
            charMatrix.HiDWord = (ulong)4000816;
            charMatrix.LowDWord = (ulong)1594106136;
            this.sortedList_2.Add("Key_6", charMatrix);
            charMatrix.HiDWord = (ulong)1065220;
            charMatrix.LowDWord = (ulong)138545215;
            this.sortedList_2.Add("Key_7", charMatrix);
            charMatrix.HiDWord = (ulong)4000809;
            charMatrix.LowDWord = (ulong)206182494;
            this.sortedList_2.Add("Key_8", charMatrix);
            charMatrix.HiDWord = (ulong)803344;
            charMatrix.LowDWord = (ulong)1048975454;
            this.sortedList_2.Add("Key_9", charMatrix);
            charMatrix.HiDWord = (ulong)68656;
            charMatrix.LowDWord = (ulong)1644041356;
            this.sortedList_2.Add("Key_A", charMatrix);
            charMatrix.HiDWord = (ulong)64560;
            charMatrix.LowDWord = (ulong)1635653727;
            this.sortedList_2.Add("Key_B", charMatrix);
            charMatrix.HiDWord = (ulong)62496;
            charMatrix.LowDWord = (ulong)1090787422;
            this.sortedList_2.Add("Key_C", charMatrix);
            charMatrix.HiDWord = (ulong)31280;
            charMatrix.LowDWord = (ulong)1636176975;
            this.sortedList_2.Add("Key_D", charMatrix);
            charMatrix.HiDWord = (ulong)129056;
            charMatrix.LowDWord = (ulong)1594101887;
            this.sortedList_2.Add("Key_E", charMatrix);
            charMatrix.HiDWord = (ulong)2080;
            charMatrix.LowDWord = (ulong)1325666431;
            this.sortedList_2.Add("Key_F", charMatrix);
            charMatrix.HiDWord = (ulong)128048;
            charMatrix.LowDWord = (ulong)2030311518;
            this.sortedList_2.Add("Key_G", charMatrix);
            charMatrix.HiDWord = (ulong)68656;
            charMatrix.LowDWord = (ulong)2139494497;
            this.sortedList_2.Add("Key_H", charMatrix);
            charMatrix.HiDWord = (ulong)57604;
            charMatrix.LowDWord = (ulong)136348188;
            this.sortedList_2.Add("Key_I", charMatrix);
            charMatrix.HiDWord = (ulong)29224;
            charMatrix.LowDWord = (ulong)272696344;
            this.sortedList_2.Add("Key_J", charMatrix);
            charMatrix.HiDWord = (ulong)68132;
            charMatrix.LowDWord = (ulong)1192531041;
            this.sortedList_2.Add("Key_K", charMatrix);
            charMatrix.HiDWord = (ulong)129056;
            charMatrix.LowDWord = (ulong)1090785345;
            this.sortedList_2.Add("Key_L", charMatrix);
            charMatrix.HiDWord = (ulong)68656;
            charMatrix.LowDWord = (ulong)1636228321;
            this.sortedList_2.Add("Key_M", charMatrix);
            charMatrix.HiDWord = (ulong)68664;
            charMatrix.LowDWord = (ulong)1771452513;
            this.sortedList_2.Add("Key_N", charMatrix);
            charMatrix.HiDWord = (ulong)62512;
            charMatrix.LowDWord = (ulong)1636178014;
            this.sortedList_2.Add("Key_O", charMatrix);
            charMatrix.HiDWord = (ulong)2080;
            charMatrix.LowDWord = (ulong)1098782815;
            this.sortedList_2.Add("Key_P", charMatrix);
            charMatrix.HiDWord = (ulong)94772;
            charMatrix.LowDWord = (ulong)1636178014;
            this.sortedList_2.Add("Key_Q", charMatrix);
            charMatrix.HiDWord = (ulong)68132;
            charMatrix.LowDWord = (ulong)1165891679;
            this.sortedList_2.Add("Key_R", charMatrix);
            charMatrix.HiDWord = (ulong)62480;
            charMatrix.LowDWord = (ulong)404230238;
            this.sortedList_2.Add("Key_S", charMatrix);
            charMatrix.HiDWord = (ulong)16644;
            charMatrix.LowDWord = (ulong)136348222;
            this.sortedList_2.Add("Key_T", charMatrix);
            charMatrix.HiDWord = (ulong)62512;
            charMatrix.LowDWord = (ulong)1636178017;
            this.sortedList_2.Add("Key_U", charMatrix);
            charMatrix.HiDWord = (ulong)25168;
            charMatrix.LowDWord = (ulong)1636178017;
            this.sortedList_2.Add("Key_V", charMatrix);
            charMatrix.HiDWord = (ulong)69238;
            charMatrix.LowDWord = (ulong)1636178017;
            this.sortedList_2.Add("Key_W", charMatrix);
            charMatrix.HiDWord = (ulong)68649;
            charMatrix.LowDWord = (ulong)204548193;
            this.sortedList_2.Add("Key_X", charMatrix);
            charMatrix.HiDWord = (ulong)16644;
            charMatrix.LowDWord = (ulong)139602082;
            this.sortedList_2.Add("Key_Y", charMatrix);
            charMatrix.HiDWord = (ulong)129057;
            charMatrix.LowDWord = (ulong)69273663;
            this.sortedList_2.Add("Key_Z", charMatrix);
            charMatrix.HiDWord = (ulong)123985;
            charMatrix.LowDWord = (ulong)1015136256;
            this.sortedList_2.Add("Key_a", charMatrix);
            charMatrix.HiDWord = (ulong)128081;
            charMatrix.LowDWord = (ulong)503849090;
            this.sortedList_2.Add("Key_b", charMatrix);
            charMatrix.HiDWord = (ulong)58433;
            charMatrix.LowDWord = (ulong)42582016;
            this.sortedList_2.Add("Key_c", charMatrix);
            charMatrix.HiDWord = (ulong)123985;
            charMatrix.LowDWord = (ulong)1015154720;
            this.sortedList_2.Add("Key_d", charMatrix);
            charMatrix.HiDWord = (ulong)57439;
            charMatrix.LowDWord = (ulong)579452928;
            this.sortedList_2.Add("Key_e", charMatrix);
            charMatrix.HiDWord = (ulong)8322;
            charMatrix.LowDWord = (ulong)70797592;
            this.sortedList_2.Add("Key_f", charMatrix);
            charMatrix.HiDWord = (ulong)3736606;
            charMatrix.LowDWord = (ulong)579584000;
            this.sortedList_2.Add("Key_g", charMatrix);
            charMatrix.HiDWord = (ulong)70737;
            charMatrix.LowDWord = (ulong)644358274;
            this.sortedList_2.Add("Key_h", charMatrix);
            charMatrix.HiDWord = (ulong)57604;
            charMatrix.LowDWord = (ulong)136364040;
            this.sortedList_2.Add("Key_i", charMatrix);
            charMatrix.HiDWord = (ulong)3707400;
            charMatrix.LowDWord = (ulong)272728080;
            this.sortedList_2.Add("Key_j", charMatrix);
            charMatrix.HiDWord = (ulong)70213;
            charMatrix.LowDWord = (ulong)239739010;
            this.sortedList_2.Add("Key_k", charMatrix);
            charMatrix.HiDWord = (ulong)33028;
            charMatrix.LowDWord = (ulong)136348168;
            this.sortedList_2.Add("Key_l", charMatrix);
            charMatrix.HiDWord = (ulong)87381;
            charMatrix.LowDWord = (ulong)715874304;
            this.sortedList_2.Add("Key_m", charMatrix);
            charMatrix.HiDWord = (ulong)70737;
            charMatrix.LowDWord = (ulong)580493312;
            this.sortedList_2.Add("Key_n", charMatrix);
            charMatrix.HiDWord = (ulong)58449;
            charMatrix.LowDWord = (ulong)579452928;
            this.sortedList_2.Add("Key_o", charMatrix);
            charMatrix.HiDWord = (ulong)266319;
            charMatrix.LowDWord = (ulong)579461120;
            this.sortedList_2.Add("Key_p", charMatrix);
            charMatrix.HiDWord = (ulong)4260894;
            charMatrix.LowDWord = (ulong)579584000;
            this.sortedList_2.Add("Key_q", charMatrix);
            charMatrix.HiDWord = (ulong)4161;
            charMatrix.LowDWord = (ulong)43622400;
            this.sortedList_2.Add("Key_r", charMatrix);
            charMatrix.HiDWord = (ulong)58384;
            charMatrix.LowDWord = (ulong)470401024;
            this.sortedList_2.Add("Key_s", charMatrix);
            charMatrix.HiDWord = (ulong)50306;
            charMatrix.LowDWord = (ulong)70795520;
            this.sortedList_2.Add("Key_t", charMatrix);
            charMatrix.HiDWord = (ulong)91729;
            charMatrix.LowDWord = (ulong)579477504;
            this.sortedList_2.Add("Key_u", charMatrix);
            charMatrix.HiDWord = (ulong)17041;
            charMatrix.LowDWord = (ulong)579477504;
            this.sortedList_2.Add("Key_v", charMatrix);
            charMatrix.HiDWord = (ulong)71381;
            charMatrix.LowDWord = (ulong)713695232;
            this.sortedList_2.Add("Key_w", charMatrix);
            charMatrix.HiDWord = (ulong)70276;
            charMatrix.LowDWord = (ulong)139599872;
            this.sortedList_2.Add("Key_x", charMatrix);
            charMatrix.HiDWord = (ulong)3736606;
            charMatrix.LowDWord = (ulong)579477504;
            this.sortedList_2.Add("Key_y", charMatrix);
            charMatrix.HiDWord = (ulong)127042;
            charMatrix.LowDWord = (ulong)138665984;
            this.sortedList_2.Add("Key_z", charMatrix);
            charMatrix.HiDWord = (ulong)16388;
            charMatrix.LowDWord = (ulong)138545246;
            this.sortedList_2.Add("Key_QuestionM", charMatrix);
            charMatrix.HiDWord = (ulong)101954;
            charMatrix.LowDWord = (ulong)139341824;
            this.sortedList_2.Add("Key_Percentage", charMatrix);
            charMatrix.HiDWord = (ulong)1176852;
            charMatrix.LowDWord = (ulong)505716616;
            this.sortedList_2.Add("Key_Dollar", charMatrix);
            charMatrix.HiDWord = (ulong)17742;
            charMatrix.LowDWord = (ulong)1047699968;
            this.sortedList_2.Add("Key_Star", charMatrix);
            charMatrix.HiDWord = (ulong)1581186;
            charMatrix.LowDWord = (ulong)68174092;
            this.sortedList_2.Add("Key_LeftSP", charMatrix);
            charMatrix.HiDWord = (ulong)3179016;
            charMatrix.LowDWord = (ulong)272696344;
            this.sortedList_2.Add("Key_RightSP", charMatrix);
            charMatrix.HiDWord = (ulong)260;
            charMatrix.LowDWord = (ulong)1042317312;
            this.sortedList_2.Add("Key_Plus", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)1040187392;
            this.sortedList_2.Add("Key_Minus", charMatrix);
            charMatrix.HiDWord = (ulong)2114;
            charMatrix.LowDWord = (ulong)138543104;
            this.sortedList_2.Add("Key_Divide", charMatrix);
            charMatrix.HiDWord = (ulong)31;
            charMatrix.LowDWord = (ulong)16252928;
            this.sortedList_2.Add("Key_Equal", charMatrix);
            charMatrix.HiDWord = (ulong)270600;
            charMatrix.LowDWord = (ulong)541098242;
            this.sortedList_2.Add("Key_Greater", charMatrix);
            charMatrix.HiDWord = (ulong)2113665;
            charMatrix.LowDWord = (ulong)17318416;
            this.sortedList_2.Add("Key_Less", charMatrix);
            charMatrix.HiDWord = (ulong)24960;
            charMatrix.LowDWord = (ulong)0;
            this.sortedList_2.Add("Key_Period", charMatrix);
            charMatrix.HiDWord = (ulong)541056;
            charMatrix.LowDWord = (ulong)0;
            this.sortedList_2.Add("Key_Comma", charMatrix);
            charMatrix.HiDWord = (ulong)541056;
            charMatrix.LowDWord = (ulong)204472320;
            this.sortedList_2.Add("Key_Semicolon", charMatrix);
            charMatrix.HiDWord = (ulong)24960;
            charMatrix.LowDWord = (ulong)204472320;
            this.sortedList_2.Add("Key_Colon", charMatrix);
            charMatrix.HiDWord = (ulong)16388;
            charMatrix.LowDWord = (ulong)136348168;
            this.sortedList_2.Add("Key_Exclamation", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)83220;
            this.sortedList_2.Add("Key_DQuotation", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)16644;
            this.sortedList_2.Add("Key_SQuotation", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)1056964608;
            this.sortedList_2.Add("Key_Dash", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)34146;
            this.sortedList_2.Add("Key_Tilde", charMatrix);
            charMatrix.HiDWord = (ulong)4001594;
            charMatrix.LowDWord = (ulong)2110249054;
            this.sortedList_2.Add("Key_At", charMatrix);
            charMatrix.HiDWord = (ulong)607;
            charMatrix.LowDWord = (ulong)1380709504;
            this.sortedList_2.Add("Key_Pound", charMatrix);
            charMatrix.HiDWord = (ulong)8257536;
            charMatrix.LowDWord = (ulong)0;
            this.sortedList_2.Add("Key_UnderScore", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)70276;
            this.sortedList_2.Add("Key_Caret", charMatrix);
            charMatrix.HiDWord = (ulong)4227330;
            charMatrix.LowDWord = (ulong)68191264;
            this.sortedList_2.Add("Key_LeftP", charMatrix);
            charMatrix.HiDWord = (ulong)135300;
            charMatrix.LowDWord = (ulong)136331393;
            this.sortedList_2.Add("Key_RightP", charMatrix);
            charMatrix.HiDWord = (ulong)6065443;
            charMatrix.LowDWord = (ulong)103093326;
            this.sortedList_2.Add("Key_And", charMatrix);
            charMatrix.HiDWord = (ulong)16387128;
            charMatrix.LowDWord = (ulong)1496608958;
            this.sortedList_3.Add("Key_0", charMatrix);
            charMatrix.HiDWord = (ulong)7356545;
            charMatrix.LowDWord = (ulong)16909832;
            this.sortedList_3.Add("Key_1", charMatrix);
            charMatrix.HiDWord = (ulong)33294359;
            charMatrix.LowDWord = (ulong)1745887422;
            this.sortedList_3.Add("Key_2", charMatrix);
            charMatrix.HiDWord = (ulong)16387080;
            charMatrix.LowDWord = (ulong)131080255;
            this.sortedList_3.Add("Key_3", charMatrix);
            charMatrix.HiDWord = (ulong)8456180;
            charMatrix.LowDWord = (ulong)340333616;
            this.sortedList_3.Add("Key_4", charMatrix);
            charMatrix.HiDWord = (ulong)16647176;
            charMatrix.LowDWord = (ulong)132137215;
            this.sortedList_3.Add("Key_5", charMatrix);
            charMatrix.HiDWord = (ulong)16387127;
            charMatrix.LowDWord = (ulong)1344307768;
            this.sortedList_3.Add("Key_6", charMatrix);
            charMatrix.HiDWord = (ulong)4227330;
            charMatrix.LowDWord = (ulong)34087039;
            this.sortedList_3.Add("Key_7", charMatrix);
            charMatrix.HiDWord = (ulong)16387096;
            charMatrix.LowDWord = (ulong)399532222;
            this.sortedList_3.Add("Key_8", charMatrix);
            charMatrix.HiDWord = (ulong)3703304;
            charMatrix.LowDWord = (ulong)265314494;
            this.sortedList_3.Add("Key_9", charMatrix);
            charMatrix.HiDWord = (ulong)134168;
            charMatrix.LowDWord = (ulong)535847102;
            this.sortedList_3.Add("Key_A", charMatrix);
            charMatrix.HiDWord = (ulong)130072;
            charMatrix.LowDWord = (ulong)401629375;
            this.sortedList_3.Add("Key_B", charMatrix);
            charMatrix.HiDWord = (ulong)128016;
            charMatrix.LowDWord = (ulong)270557374;
            this.sortedList_3.Add("Key_C", charMatrix);
            charMatrix.HiDWord = (ulong)64024;
            charMatrix.LowDWord = (ulong)405819551;
            this.sortedList_3.Add("Key_D", charMatrix);
            charMatrix.HiDWord = (ulong)260112;
            charMatrix.LowDWord = (ulong)400572671;
            this.sortedList_3.Add("Key_E", charMatrix);
            charMatrix.HiDWord = (ulong)2064;
            charMatrix.LowDWord = (ulong)333463807;
            this.sortedList_3.Add("Key_F", charMatrix);
            charMatrix.HiDWord = (ulong)128024;
            charMatrix.LowDWord = (ulong)505438398;
            this.sortedList_3.Add("Key_G", charMatrix);
            charMatrix.HiDWord = (ulong)134168;
            charMatrix.LowDWord = (ulong)535847105;
            this.sortedList_3.Add("Key_H", charMatrix);
            charMatrix.HiDWord = (ulong)57473;
            charMatrix.LowDWord = (ulong)16909340;
            this.sortedList_3.Add("Key_I", charMatrix);
            charMatrix.HiDWord = (ulong)57892;
            charMatrix.LowDWord = (ulong)67637296;
            this.sortedList_3.Add("Key_J", charMatrix);
            charMatrix.HiDWord = (ulong)16845073;
            charMatrix.LowDWord = (ulong)1898205377;
            this.sortedList_3.Add("Key_K", charMatrix);
            charMatrix.HiDWord = (ulong)33294352;
            charMatrix.LowDWord = (ulong)270549121;
            this.sortedList_3.Add("Key_L", charMatrix);
            charMatrix.HiDWord = (ulong)134168;
            charMatrix.LowDWord = (ulong)422932929;
            this.sortedList_3.Add("Key_M", charMatrix);
            charMatrix.HiDWord = (ulong)134682;
            charMatrix.LowDWord = (ulong)422666689;
            this.sortedList_3.Add("Key_N", charMatrix);
            charMatrix.HiDWord = (ulong)128024;
            charMatrix.LowDWord = (ulong)405823678;
            this.sortedList_3.Add("Key_O", charMatrix);
            charMatrix.HiDWord = (ulong)2064;
            charMatrix.LowDWord = (ulong)401629375;
            this.sortedList_3.Add("Key_P", charMatrix);
            charMatrix.HiDWord = (ulong)193050;
            charMatrix.LowDWord = (ulong)405823678;
            this.sortedList_3.Add("Key_Q", charMatrix);
            charMatrix.HiDWord = (ulong)133650;
            charMatrix.LowDWord = (ulong)401629375;
            this.sortedList_3.Add("Key_R", charMatrix);
            charMatrix.HiDWord = (ulong)128008;
            charMatrix.LowDWord = (ulong)130039998;
            this.sortedList_3.Add("Key_S", charMatrix);
            charMatrix.HiDWord = (ulong)16513;
            charMatrix.LowDWord = (ulong)16909439;
            this.sortedList_3.Add("Key_T", charMatrix);
            charMatrix.HiDWord = (ulong)128024;
            charMatrix.LowDWord = (ulong)405823681;
            this.sortedList_3.Add("Key_U", charMatrix);
            charMatrix.HiDWord = (ulong)16708;
            charMatrix.LowDWord = (ulong)674259137;
            this.sortedList_3.Add("Key_V", charMatrix);
            charMatrix.HiDWord = (ulong)134714;
            charMatrix.LowDWord = (ulong)1496342721;
            this.sortedList_3.Add("Key_W", charMatrix);
            charMatrix.HiDWord = (ulong)133666;
            charMatrix.LowDWord = (ulong)1090851137;
            this.sortedList_3.Add("Key_X", charMatrix);
            charMatrix.HiDWord = (ulong)16513;
            charMatrix.LowDWord = (ulong)17109313;
            this.sortedList_3.Add("Key_Y", charMatrix);
            charMatrix.HiDWord = (ulong)260128;
            charMatrix.LowDWord = (ulong)1090785407;
            this.sortedList_3.Add("Key_Z", charMatrix);
            charMatrix.HiDWord = (ulong)255023;
            charMatrix.LowDWord = (ulong)1208942592;
            this.sortedList_3.Add("Key_a", charMatrix);
            charMatrix.HiDWord = (ulong)128040;
            charMatrix.LowDWord = (ulong)666927362;
            this.sortedList_3.Add("Key_b", charMatrix);
            charMatrix.HiDWord = (ulong)122912;
            charMatrix.LowDWord = (ulong)542048256;
            this.sortedList_3.Add("Key_c", charMatrix);
            charMatrix.HiDWord = (ulong)255016;
            charMatrix.LowDWord = (ulong)797974592;
            this.sortedList_3.Add("Key_d", charMatrix);
            charMatrix.HiDWord = (ulong)122927;
            charMatrix.LowDWord = (ulong)1750007808;
            this.sortedList_3.Add("Key_e", charMatrix);
            charMatrix.HiDWord = (ulong)8256;
            charMatrix.LowDWord = (ulong)1103172120;
            this.sortedList_3.Add("Key_f", charMatrix);
            charMatrix.HiDWord = (ulong)15861704;
            charMatrix.LowDWord = (ulong)676265984;
            this.sortedList_3.Add("Key_g", charMatrix);
            charMatrix.HiDWord = (ulong)136232;
            charMatrix.LowDWord = (ulong)684622082;
            this.sortedList_3.Add("Key_h", charMatrix);
            charMatrix.HiDWord = (ulong)57473;
            charMatrix.LowDWord = (ulong)16973832;
            this.sortedList_3.Add("Key_i", charMatrix);
            charMatrix.HiDWord = (ulong)6365700;
            charMatrix.LowDWord = (ulong)67895328;
            this.sortedList_3.Add("Key_j", charMatrix);
            charMatrix.HiDWord = (ulong)74049;
            charMatrix.LowDWord = (ulong)1116275204;
            this.sortedList_3.Add("Key_k", charMatrix);
            charMatrix.HiDWord = (ulong)32897;
            charMatrix.LowDWord = (ulong)16909320;
            this.sortedList_3.Add("Key_l", charMatrix);
            charMatrix.HiDWord = (ulong)86693;
            charMatrix.LowDWord = (ulong)625836032;
            this.sortedList_3.Add("Key_m", charMatrix);
            charMatrix.HiDWord = (ulong)70180;
            charMatrix.LowDWord = (ulong)616988672;
            this.sortedList_3.Add("Key_n", charMatrix);
            charMatrix.HiDWord = (ulong)123944;
            charMatrix.LowDWord = (ulong)676265984;
            this.sortedList_3.Add("Key_o", charMatrix);
            charMatrix.HiDWord = (ulong)529384;
            charMatrix.LowDWord = (ulong)676298752;
            this.sortedList_3.Add("Key_p", charMatrix);
            charMatrix.HiDWord = (ulong)16910280;
            charMatrix.LowDWord = (ulong)677314560;
            this.sortedList_3.Add("Key_q", charMatrix);
            charMatrix.HiDWord = (ulong)4128;
            charMatrix.LowDWord = (ulong)684621824;
            this.sortedList_3.Add("Key_r", charMatrix);
            charMatrix.HiDWord = (ulong)123911;
            charMatrix.LowDWord = (ulong)1078919168;
            this.sortedList_3.Add("Key_s", charMatrix);
            charMatrix.HiDWord = (ulong)99457;
            charMatrix.LowDWord = (ulong)17794048;
            this.sortedList_3.Add("Key_t", charMatrix);
            charMatrix.HiDWord = (ulong)189992;
            charMatrix.LowDWord = (ulong)676364288;
            this.sortedList_3.Add("Key_u", charMatrix);
            charMatrix.HiDWord = (ulong)16708;
            charMatrix.LowDWord = (ulong)608731136;
            this.sortedList_3.Add("Key_v", charMatrix);
            charMatrix.HiDWord = (ulong)136811;
            charMatrix.LowDWord = (ulong)676364288;
            this.sortedList_3.Add("Key_w", charMatrix);
            charMatrix.HiDWord = (ulong)69953;
            charMatrix.LowDWord = (ulong)42500096;
            this.sortedList_3.Add("Key_x", charMatrix);
            charMatrix.HiDWord = (ulong)7406607;
            charMatrix.LowDWord = (ulong)1213235200;
            this.sortedList_3.Add("Key_y", charMatrix);
            charMatrix.HiDWord = (ulong)127041;
            charMatrix.LowDWord = (ulong)34570240;
            this.sortedList_3.Add("Key_z", charMatrix);
            charMatrix.HiDWord = (ulong)16385;
            charMatrix.LowDWord = (ulong)118497470;
            this.sortedList_3.Add("Key_QuestionM", charMatrix);
            charMatrix.HiDWord = (ulong)25628737;
            charMatrix.LowDWord = (ulong)34185984;
            this.sortedList_3.Add("Key_Percentage", charMatrix);
            charMatrix.HiDWord = (ulong)2114537;
            charMatrix.LowDWord = (ulong)130178824;
            this.sortedList_3.Add("Key_Dollar", charMatrix);
            charMatrix.HiDWord = (ulong)17059;
            charMatrix.LowDWord = (ulong)1340544264;
            this.sortedList_3.Add("Key_Star", charMatrix);
            charMatrix.HiDWord = (ulong)6307969;
            charMatrix.LowDWord = (ulong)16909336;
            this.sortedList_3.Add("Key_LeftSP", charMatrix);
            charMatrix.HiDWord = (ulong)3162241;
            charMatrix.LowDWord = (ulong)16909324;
            this.sortedList_3.Add("Key_RightSP", charMatrix);
            charMatrix.HiDWord = (ulong)129;
            charMatrix.LowDWord = (ulong)130155520;
            this.sortedList_3.Add("Key_Plus", charMatrix);
            charMatrix.HiDWord = (ulong)7;
            charMatrix.LowDWord = (ulong)1610612736;
            this.sortedList_3.Add("Key_Minus", charMatrix);
            charMatrix.HiDWord = (ulong)266305;
            charMatrix.LowDWord = (ulong)34086912;
            this.sortedList_3.Add("Key_Divide", charMatrix);
            charMatrix.HiDWord = (ulong)992;
            charMatrix.LowDWord = (ulong)130023424;
            this.sortedList_3.Add("Key_Equal", charMatrix);
            charMatrix.HiDWord = (ulong)4161;
            charMatrix.LowDWord = (ulong)33686018;
            this.sortedList_3.Add("Key_Greater", charMatrix);
            charMatrix.HiDWord = (ulong)65793;
            charMatrix.LowDWord = (ulong)8521760;
            this.sortedList_3.Add("Key_Less", charMatrix);
            charMatrix.HiDWord = (ulong)24768;
            charMatrix.LowDWord = (ulong)0;
            this.sortedList_3.Add("Key_Period", charMatrix);
            charMatrix.HiDWord = (ulong)1065152;
            charMatrix.LowDWord = (ulong)0;
            this.sortedList_3.Add("Key_Comma", charMatrix);
            charMatrix.HiDWord = (ulong)1065152;
            charMatrix.LowDWord = (ulong)25362432;
            this.sortedList_3.Add("Key_Semicolon", charMatrix);
            charMatrix.HiDWord = (ulong)24768;
            charMatrix.LowDWord = (ulong)25362432;
            this.sortedList_3.Add("Key_Colon", charMatrix);
            charMatrix.HiDWord = (ulong)16385;
            charMatrix.LowDWord = (ulong)16909320;
            this.sortedList_3.Add("Key_Exclamation", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)330260;
            this.sortedList_3.Add("Key_DQuotation", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)132104;
            this.sortedList_3.Add("Key_SQuotation", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)266338304;
            this.sortedList_3.Add("Key_Dash", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)3238;
            this.sortedList_3.Add("Key_Tilde", charMatrix);
            charMatrix.HiDWord = (ulong)16477499;
            charMatrix.LowDWord = (ulong)1513316542;
            this.sortedList_3.Add("Key_At", charMatrix);
            charMatrix.HiDWord = (ulong)327;
            charMatrix.LowDWord = (ulong)1653574144;
            this.sortedList_3.Add("Key_Pound", charMatrix);
            charMatrix.HiDWord = (ulong)33292288;
            charMatrix.LowDWord = (ulong)0;
            this.sortedList_3.Add("Key_UnderScore", charMatrix);
            charMatrix.HiDWord = (ulong)0;
            charMatrix.LowDWord = (ulong)279812;
            this.sortedList_3.Add("Key_Caret", charMatrix);
            charMatrix.HiDWord = (ulong)32896;
            charMatrix.LowDWord = (ulong)1082197008;
            this.sortedList_3.Add("Key_LeftP", charMatrix);
            charMatrix.HiDWord = (ulong)8322;
            charMatrix.LowDWord = (ulong)33817604;
            this.sortedList_3.Add("Key_RightP", charMatrix);
            charMatrix.HiDWord = (ulong)18434325;
            charMatrix.LowDWord = (ulong)679643404;
            this.sortedList_3.Add("Key_And", charMatrix);
        }

        public void ResetCustomizedLCDSecondValue(bool bUIUpdate)
        {
            this.arrayList_1.Clear();
            if (bUIUpdate)
            {
                base.Invalidate();
            }
        }

        public void ResetCustomizedLCDValue(bool bUIUpdate)
        {
            this.arrayList_0.Clear();
            if (bUIUpdate)
            {
                base.Invalidate();
            }
        }

        public void ResetLCDLineText(bool bUIUpdate)
        {
            this.arrayList_2.Clear();
            if (bUIUpdate)
            {
                base.Invalidate();
            }
        }

        protected override void Dispose(bool bool_4)
        {
            if (bool_4 && this.icontainer_0 != null)
            {
                this.icontainer_0.Dispose();
            }
            base.Dispose(bool_4);
        }

        protected override void OnPaint(PaintEventArgs paintEventArgs_0)
        {
            int i;
            int num;
            int num1;
            int left;
            int top;
            int left1;
            int int11;
            CharMatrix charMatrix = new CharMatrix();
            CharMatrix charMatrix1 = new CharMatrix();
            CharMatrix charMatrix2 = new CharMatrix();
            CharMatrix charMatrix3 = new CharMatrix();
            CharMatrix charMatrix4 = new CharMatrix();
            CharMatrix charMatrix5 = new CharMatrix();
            CharMatrix item = new CharMatrix();
            CharMatrix item1 = new CharMatrix();
            CharMatrix item2 = new CharMatrix();
            CharMatrix item3 = new CharMatrix();
            CharMatrix charMatrix6 = new CharMatrix();
            try
            {
                base.OnPaint(paintEventArgs_0);
                if (this.das_BorderGradientStyle_0 == DAS_BorderGradientStyle.BGS_None || base.ClientRectangle.Width - 2 * (this.int_0 + this.int_1 + this.int_4 + this.int_2) > 0 && base.ClientRectangle.Height - 2 * (this.int_0 + this.int_1 + this.int_4 + this.int_2) > 0)
                {
                    DrawGraphics _DrawGraphics = new DrawGraphics();
                    int left2 = base.ClientRectangle.Left;
                    int top1 = base.ClientRectangle.Top;
                    Rectangle clientRectangle = base.ClientRectangle;
                    int width = clientRectangle.Width - 2;
                    clientRectangle = base.ClientRectangle;
                    Rectangle rectangle = new Rectangle(left2, top1, width, clientRectangle.Height - 2);
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
                                float height = (float)this.BackgroundImage.Height / (float)this.BackgroundImage.Width * single;
                                if (height > (float)x.Height)
                                {
                                    height = (float)x.Height;
                                    single = (float)this.BackgroundImage.Width / (float)this.BackgroundImage.Height * height;
                                }
                                RectangleF rectangleF = new RectangleF((float)x.Left + ((float)x.Width - single) / 2f, (float)x.Top + ((float)x.Height - height) / 2f, single, height);
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
                    int int10 = this.int_10;
                    int top2 = (x.Top + x.Bottom) / 2;
                    int num2 = 0;
                    int num3 = 0;
                    if (this.das_LCDMatrixStyle_0 == DAS_LCDMatrixStyle.LCDMS_5x7)
                    {
                        num3 = 5;
                        num2 = 7;
                    }
                    else if (this.das_LCDMatrixStyle_0 == DAS_LCDMatrixStyle.LCDMS_5x8)
                    {
                        num3 = 5;
                        num2 = 8;
                    }
                    else if (this.das_LCDMatrixStyle_0 == DAS_LCDMatrixStyle.LCDMS_6x9)
                    {
                        num3 = 6;
                        num2 = 9;
                    }
                    else if (this.das_LCDMatrixStyle_0 == DAS_LCDMatrixStyle.LCDMS_7x8)
                    {
                        num3 = 7;
                        num2 = 8;
                    }
                    int int8 = (this.int_8 + this.int_9) * num3 + this.int_10;
                    int int81 = (this.int_8 + this.int_9) * num2 + this.int_10;
                    if (int8 <= 0)
                    {
                        int8 = 0;
                    }
                    int width1 = (x.Width - 2 * this.int_10) / int8;
                    if (width1 < 1)
                    {
                        width1 = 1;
                    }
                    bool flag = true;
                    int j = 0;
                    if (this.das_LCDCharLookupStyle_0 != DAS_LCDCharLookupStyle.LCLS_Standard)
                    {
                        if (this.das_LCDCharTextMode_0 != DAS_LCDCharTextMode.LCTM_SingleText)
                        {
                            if (this.das_LCDCharTextMode_0 == DAS_LCDCharTextMode.LCTM_TwoText)
                            {
                                //goto Label3;
                            }
                            left1 = x.Left + this.int_10;
                            int11 = x.Top + this.int_10;
                            top = x.Top + this.int_10;
                            num = 0;
                            while (top + int10 < x.Bottom)
                            {
                                left = left1;
                                bool flag1 = false;
                                num1 = 0;
                                while (!flag1)
                                {
                                    charMatrix6.LowDWord = (ulong)0;
                                    charMatrix6.HiDWord = (ulong)0;
                                    left = x.Left + int10 + int8 * num1;
                                    string str = string.Empty;
                                    if (left + int8 + int8 >= x.Right - 1)
                                    {
                                        flag1 = true;
                                    }
                                    this.method_2(paintEventArgs_0.Graphics, left, top, str, charMatrix6, this.ForeColor, this.bool_3);
                                    num1++;
                                }
                                top = top + int81;
                                num++;
                            }
                            for (i = 0; i < this.arrayList_2.Count; i++)
                            {
                                LCDLineText lCDLineText = (LCDLineText)this.arrayList_2[i];
                                top = x.Top + this.int_10 + int81 * lCDLineText.iLine;
                                CharMatrix charMatrix7 = lCDLineText.stChar;
                                left = x.Left + this.int_10 + int8 * lCDLineText.iLineOffSet;
                                string str1 = string.Empty;
                                this.method_2(paintEventArgs_0.Graphics, left, top, str1, charMatrix7, lCDLineText.cLineColor, false);
                            }
                            goto Label0;
                        }
                        if (width1 > this.arrayList_0.Count)
                        {
                            left1 = x.Left + int8 * (width1 - this.arrayList_0.Count) / 2 + this.int_10;
                            int11 = top2 - int81 / 2 + this.int_11 * int81;
                            flag = true;
                        }
                        else if (this.das_LCDWordWrapType_0 != DAS_LCDWordWrapType.LWWT_None)
                        {
                            left1 = x.Left + (x.Width - width1 * int8) / 2;
                            int11 = x.Top + this.int_10 + this.int_11 * int81;
                            flag = false;
                        }
                        else
                        {
                            left1 = x.Left + int8 * (width1 - this.arrayList_0.Count) / 2 + this.int_10;
                            int11 = top2 - int81 / 2 + this.int_11 * int81;
                            flag = true;
                        }
                        if (this.das_LCDCharTextMode_0 == DAS_LCDCharTextMode.LCTM_TwoText)
                        {
                            flag = false;
                        }
                        left = x.Left + (x.Width - width1 * int8) / 2;
                        j = 0;
                        if (!flag)
                        {
                            bool flag2 = false;
                            top = x.Top + this.int_10;
                            if (this.int_11 < 0)
                            {
                                top = x.Top + this.int_10 + this.int_11 * int81;
                            }
                            num = 0;
                            while (top + int10 < x.Bottom)
                            {
                                left = left1;
                                bool flag3 = false;
                                bool flag4 = false;
                                num1 = 0;
                                while (!flag3)
                                {
                                    item1.LowDWord = (ulong)0;
                                    item1.HiDWord = (ulong)0;
                                    left = x.Left + (x.Width - width1 * int8) / 2 + int8 * num1;
                                    string str2 = string.Empty;
                                    if (left >= left1 && top >= int11 && j < this.arrayList_0.Count && !flag4)
                                    {
                                        item1 = (CharMatrix)this.arrayList_0[j];
                                    }
                                    if (num1 >= width1 - 1)
                                    {
                                        if (top < int11)
                                        {
                                            flag3 = true;
                                        }
                                        else
                                        {
                                            if (!flag2)
                                            {
                                                int11 = top;
                                                flag2 = true;
                                            }
                                            if (j >= this.arrayList_0.Count || this.das_LCDWordWrapType_0 == DAS_LCDWordWrapType.LWWT_WordWrap1 || flag4)
                                            {
                                                flag3 = true;
                                            }
                                            else if (item1.HiDWord == (long)0 && item1.LowDWord == (long)0)
                                            {
                                                flag3 = true;
                                            }
                                        }
                                    }
                                    else if (this.das_LCDWordWrapType_0 == DAS_LCDWordWrapType.LWWT_WordWrap3 && !flag4 && j < this.arrayList_0.Count && item1.HiDWord == (long)0 && item1.LowDWord == (long)0 && j + 1 < this.arrayList_0.Count - 1)
                                    {
                                        int num4 = -1;
                                        int num5 = j + 1;
                                        while (true)
                                        {
                                            if (num5 < this.arrayList_0.Count)
                                            {
                                                CharMatrix item4 = (CharMatrix)this.arrayList_0[num5];
                                                if (item4.LowDWord != (long)0 || item4.HiDWord != (long)0)
                                                {
                                                    num5++;
                                                }
                                                else
                                                {
                                                    num4 = num5;
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        if (num4 - 1 - j > width1 - 1 - num1)
                                        {
                                            flag4 = true;
                                            j++;
                                        }
                                        else if (num4 <= 0 && this.arrayList_0.Count - 1 - j > width1 - 1 - num1)
                                        {
                                            flag4 = true;
                                            j++;
                                        }
                                    }
                                    if (top >= int11)
                                    {
                                        if (left >= left1 && !flag4)
                                        {
                                            j++;
                                        }
                                        if (num1 >= width1 - 1)
                                        {
                                            if (j < this.arrayList_0.Count)
                                            {
                                                CharMatrix item5 = (CharMatrix)this.arrayList_0[j];
                                                if (item5.LowDWord == (long)0 && item5.HiDWord == (long)0)
                                                {
                                                    flag3 = true;
                                                    j++;
                                                }
                                            }
                                        }
                                        else if (this.das_LCDWordWrapType_0 == DAS_LCDWordWrapType.LWWT_WordWrap3 && j < this.arrayList_0.Count)
                                        {
                                            CharMatrix item6 = (CharMatrix)this.arrayList_0[j];
                                            if (item6.LowDWord == (long)0 && item6.HiDWord == (long)0 && flag3)
                                            {
                                                j++;
                                            }
                                        }
                                    }
                                    if (top + int8 >= x.Top)
                                    {
                                        this.method_2(paintEventArgs_0.Graphics, left, top, str2, item1, this.ForeColor, this.bool_3);
                                    }
                                    num1++;
                                }
                                top = top + int81;
                                num++;
                            }
                        }
                        else
                        {
                            top = int11;
                            i = 0;
                            while (left + int8 + int10 < x.Right)
                            {
                                item.LowDWord = (ulong)0;
                                item.HiDWord = (ulong)0;
                                left = x.Left + this.int_10 + int8 * i;
                                string str3 = string.Empty;
                                if (left >= left1 && j < this.arrayList_0.Count)
                                {
                                    item = (CharMatrix)this.arrayList_0[j];
                                    j++;
                                }
                                this.method_2(paintEventArgs_0.Graphics, left, top, str3, item, this.ForeColor, this.bool_3);
                                i++;
                            }
                        }
                        if (this.das_LCDCharTextMode_0 == DAS_LCDCharTextMode.LCTM_TwoText && this.arrayList_1.Count > 0)
                        {
                            j = 0;
                            if (width1 <= this.arrayList_1.Count)
                            {
                                left1 = x.Left + (x.Width - width1 * int8) / 2;
                                if (this.das_LCDWordWrapType_0 != DAS_LCDWordWrapType.LWWT_None)
                                {
                                    int11 = int11 - int81 - (this.arrayList_1.Count / width1 + 1) * int81 + this.int_12 * int81;
                                    flag = false;
                                }
                                else
                                {
                                    int11 = int11 - 2 * int81 + this.int_12 * int81;
                                    flag = true;
                                }
                            }
                            else
                            {
                                left1 = x.Left + int8 * (width1 - this.arrayList_1.Count) / 2 + this.int_10;
                                int11 = int11 - 2 * int81 + this.int_12 * int81;
                                flag = true;
                            }
                            left = x.Left + (x.Width - width1 * int8) / 2;
                            if (!flag)
                            {
                                top = int11;
                                left = left1;
                                j = 0;
                                num = 0;
                                while (top + int10 < x.Bottom)
                                {
                                    left = left1;
                                    bool flag5 = false;
                                    bool flag6 = false;
                                    num1 = 0;
                                    while (!flag5)
                                    {
                                        item3.LowDWord = (ulong)0;
                                        item3.HiDWord = (ulong)0;
                                        left = x.Left + int10 + int8 * num1;
                                        string str4 = string.Empty;
                                        if (left >= left1 && top >= int11 && j < this.arrayList_1.Count && !flag6)
                                        {
                                            item3 = (CharMatrix)this.arrayList_1[j];
                                        }
                                        if (num1 < width1 - 1)
                                        {
                                            if (this.das_LCDWordWrapType_0 == DAS_LCDWordWrapType.LWWT_WordWrap3 && !flag6 && j < this.arrayList_1.Count && item3.HiDWord == (long)0 && item3.LowDWord == (long)0 && j + 1 < this.arrayList_1.Count - 1)
                                            {
                                                int num6 = -1;
                                                int num7 = j + 1;
                                                while (true)
                                                {
                                                    if (num7 < this.arrayList_1.Count)
                                                    {
                                                        CharMatrix item7 = (CharMatrix)this.arrayList_1[num7];
                                                        if (item7.LowDWord != (long)0 || item7.HiDWord != (long)0)
                                                        {
                                                            num7++;
                                                        }
                                                        else
                                                        {
                                                            num6 = num7;
                                                            break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                                if (num6 - 1 - j > width1 - 1 - num1)
                                                {
                                                    flag6 = true;
                                                    j++;
                                                }
                                                else if (num6 <= 0 && this.arrayList_1.Count - 1 - j > width1 - 1 - num1)
                                                {
                                                    flag6 = true;
                                                    j++;
                                                }
                                            }
                                        }
                                        else if (top < int11)
                                        {
                                            flag5 = true;
                                        }
                                        else if (j >= this.arrayList_1.Count || this.das_LCDWordWrapType_0 == DAS_LCDWordWrapType.LWWT_WordWrap1 || flag6)
                                        {
                                            flag5 = true;
                                        }
                                        else if (item3.HiDWord == (long)0 && item3.LowDWord == (long)0)
                                        {
                                            flag5 = true;
                                        }
                                        if (top >= int11)
                                        {
                                            if (left >= left1 && !flag6)
                                            {
                                                j++;
                                            }
                                            if (num1 > width1 - 1)
                                            {
                                                if (j < this.arrayList_1.Count)
                                                {
                                                    CharMatrix item8 = (CharMatrix)this.arrayList_1[j];
                                                    if (item8.HiDWord == (long)0 && item8.LowDWord == (long)0)
                                                    {
                                                        flag5 = true;
                                                        j++;
                                                    }
                                                }
                                            }
                                            else if (this.das_LCDWordWrapType_0 == DAS_LCDWordWrapType.LWWT_WordWrap3 && j < this.arrayList_1.Count)
                                            {
                                                CharMatrix charMatrix8 = (CharMatrix)this.arrayList_1[j];
                                                if (charMatrix8.HiDWord == (long)0 && charMatrix8.LowDWord == (long)0 && flag5)
                                                {
                                                    j++;
                                                }
                                            }
                                        }
                                        if (top + int81 >= x.Top && (item3.LowDWord != (long)0 || item3.HiDWord != (long)0))
                                        {
                                            this.method_2(paintEventArgs_0.Graphics, left, top, str4, item3, this.color_10, false);
                                        }
                                        num1++;
                                    }
                                    top = top + int81;
                                    num++;
                                }
                            }
                            else
                            {
                                top = int11;
                                i = 0;
                                while (left + int8 + int10 < x.Right)
                                {
                                    item2.LowDWord = (ulong)0;
                                    item2.HiDWord = (ulong)0;
                                    left = x.Left + this.int_10 + int8 * i;
                                    string str5 = string.Empty;
                                    if (left >= left1 && j < this.arrayList_1.Count)
                                    {
                                        item2 = (CharMatrix)this.arrayList_1[j];
                                        j++;
                                    }
                                    this.method_2(paintEventArgs_0.Graphics, left, top, str5, item2, this.color_10, false);
                                    i++;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (this.das_LCDCharTextMode_0 != DAS_LCDCharTextMode.LCTM_SingleText)
                        {
                            if (this.das_LCDCharTextMode_0 == DAS_LCDCharTextMode.LCTM_TwoText)
                            {
                                //goto Label4;
                            }
                            left1 = x.Left + this.int_10;
                            int11 = x.Top + this.int_10;
                            top = x.Top + this.int_10;
                            num = 0;
                            while (top + int10 < x.Bottom)
                            {
                                left = left1;
                                bool flag7 = false;
                                num1 = 0;
                                while (!flag7)
                                {
                                    charMatrix4.LowDWord = (ulong)0;
                                    charMatrix4.HiDWord = (ulong)0;
                                    left = x.Left + int10 + int8 * num1;
                                    string str6 = string.Empty;
                                    if (left + int8 + int8 >= x.Right - 1)
                                    {
                                        flag7 = true;
                                    }
                                    this.method_2(paintEventArgs_0.Graphics, left, top, str6, charMatrix4, this.ForeColor, this.bool_3);
                                    num1++;
                                }
                                top = top + int81;
                                num++;
                            }
                            for (i = 0; i < this.arrayList_2.Count; i++)
                            {
                                LCDLineText lCDLineText1 = (LCDLineText)this.arrayList_2[i];
                                top = x.Top + this.int_10 + int81 * lCDLineText1.iLine;
                                if (lCDLineText1.strTextLine != string.Empty)
                                {
                                    for (j = 0; j < lCDLineText1.strTextLine.Length; j++)
                                    {
                                        charMatrix5.LowDWord = (ulong)0;
                                        charMatrix5.HiDWord = (ulong)0;
                                        left = x.Left + this.int_10 + int8 * (lCDLineText1.iLineOffSet + j);
                                        string str7 = string.Empty;
                                        str7 = this.method_1(lCDLineText1.strTextLine.Substring(j, 1));
                                        this.method_2(paintEventArgs_0.Graphics, left, top, str7, charMatrix5, lCDLineText1.cLineColor, false);
                                    }
                                }
                                else if (lCDLineText1.stChar.LowDWord != (long)0 || lCDLineText1.stChar.HiDWord != (long)0)
                                {
                                    left = x.Left + this.int_10 + int8 * lCDLineText1.iLineOffSet;
                                    string str8 = string.Empty;
                                    this.method_2(paintEventArgs_0.Graphics, left, top, str8, lCDLineText1.stChar, lCDLineText1.cLineColor, false);
                                }
                            }
                            goto Label0;
                        }
                        if (width1 > this.string_0.Length)
                        {
                            left1 = x.Left + int8 * (width1 - this.string_0.Length) / 2 + this.int_10;
                            int11 = top2 - int81 / 2 + this.int_11 * int81;
                            flag = true;
                        }
                        else if (this.das_LCDWordWrapType_0 != DAS_LCDWordWrapType.LWWT_None)
                        {
                            left1 = x.Left + (x.Width - width1 * int8) / 2;
                            int11 = x.Top + this.int_10 + this.int_11 * int81;
                            flag = false;
                        }
                        else
                        {
                            left1 = x.Left + int8 * (width1 - this.string_0.Length) / 2 + this.int_10;
                            int11 = top2 - int81 / 2 + this.int_11 * int81;
                            flag = true;
                        }
                        if (this.das_LCDCharTextMode_0 == DAS_LCDCharTextMode.LCTM_TwoText)
                        {
                            flag = false;
                        }
                        left = x.Left + (x.Width - width1 * int8) / 2;
                        if (!flag)
                        {
                            bool flag8 = false;
                            top = x.Top + this.int_10;
                            if (this.int_11 < 0)
                            {
                                top = x.Top + this.int_10 + this.int_11 * int81;
                            }
                            num = 0;
                            while (top + int10 < x.Bottom)
                            {
                                left = left1;
                                bool flag9 = false;
                                bool flag10 = false;
                                num1 = 0;
                                while (!flag9)
                                {
                                    charMatrix1.LowDWord = (ulong)0;
                                    charMatrix1.HiDWord = (ulong)0;
                                    left = x.Left + (x.Width - width1 * int8) / 2 + int8 * num1;
                                    string str9 = string.Empty;
                                    if (left >= left1 && top >= int11 && j < this.string_0.Length && !flag10)
                                    {
                                        str9 = this.method_1(this.string_0.Substring(j, 1));
                                    }
                                    if (num1 >= width1 - 1)
                                    {
                                        if (top < int11)
                                        {
                                            flag9 = true;
                                        }
                                        else
                                        {
                                            if (!flag8)
                                            {
                                                int11 = top;
                                                flag8 = true;
                                            }
                                            if (j >= this.string_0.Length || this.das_LCDWordWrapType_0 == DAS_LCDWordWrapType.LWWT_WordWrap1 || flag10)
                                            {
                                                flag9 = true;
                                            }
                                            else if (this.string_0.Substring(j, 1) == " " || this.string_0.Substring(j, 1) == "!" || this.string_0.Substring(j, 1) == "," || this.string_0.Substring(j, 1) == "." || this.string_0.Substring(j, 1) == ";" || this.string_0.Substring(j, 1) == "?")
                                            {
                                                flag9 = true;
                                            }
                                        }
                                    }
                                    else if (this.das_LCDWordWrapType_0 == DAS_LCDWordWrapType.LWWT_WordWrap3 && !flag10 && j < this.string_0.Length && (this.string_0.Substring(j, 1) == " " || this.string_0.Substring(j, 1) == "," || this.string_0.Substring(j, 1) == ";" || this.string_0.Substring(j, 1) == "?" || this.string_0.Substring(j, 1) == "!" || this.string_0.Substring(j, 1) == ".") && j + 1 < this.string_0.Length - 1)
                                    {
                                        int num8 = this.string_0.IndexOf(" ", j + 1);
                                        int num9 = this.string_0.IndexOf(",", j + 1);
                                        if (num8 > j && num9 > j && num9 < num8)
                                        {
                                            num8 = num9 + 1;
                                        }
                                        num9 = this.string_0.IndexOf(".", j + 1);
                                        if (num8 > j && num9 > j && num9 < num8)
                                        {
                                            num8 = num9 + 1;
                                        }
                                        num9 = this.string_0.IndexOf("?", j + 1);
                                        if (num8 > j && num9 > j && num9 < num8)
                                        {
                                            num8 = num9 + 1;
                                        }
                                        num9 = this.string_0.IndexOf(";", j + 1);
                                        if (num8 > j && num9 > j && num9 < num8)
                                        {
                                            num8 = num9 + 1;
                                        }
                                        num9 = this.string_0.IndexOf("!", j + 1);
                                        if (num8 > j && num9 > j && num9 < num8)
                                        {
                                            num8 = num9 + 1;
                                        }
                                        if (num8 - 1 - j > width1 - 1 - num1)
                                        {
                                            flag10 = true;
                                            j++;
                                        }
                                        else if (num8 <= 0 && this.string_0.Length - 1 - j > width1 - 1 - num1)
                                        {
                                            flag10 = true;
                                            j++;
                                        }
                                    }
                                    if (top >= int11)
                                    {
                                        if (left >= left1 && !flag10)
                                        {
                                            j++;
                                        }
                                        if (num1 >= width1 - 1)
                                        {
                                            if (j < this.string_0.Length && this.string_0.Substring(j, 1) == " ")
                                            {
                                                flag9 = true;
                                                j++;
                                            }
                                        }
                                        else if (this.das_LCDWordWrapType_0 == DAS_LCDWordWrapType.LWWT_WordWrap3 && j < this.string_0.Length && this.string_0.Substring(j, 1) == " " && flag9)
                                        {
                                            j++;
                                        }
                                    }
                                    if (top + int8 >= x.Top)
                                    {
                                        this.method_2(paintEventArgs_0.Graphics, left, top, str9, charMatrix1, this.ForeColor, this.bool_3);
                                    }
                                    num1++;
                                }
                                top = top + int81;
                                num++;
                            }
                        }
                        else
                        {
                            top = int11;
                            i = 0;
                            while (left + int8 + int10 < x.Right)
                            {
                                charMatrix.LowDWord = (ulong)0;
                                charMatrix.HiDWord = (ulong)0;
                                left = x.Left + this.int_10 + int8 * i;
                                string str10 = string.Empty;
                                if (left >= left1 && j < this.string_0.Length)
                                {
                                    str10 = this.method_1(this.string_0.Substring(j, 1));
                                    j++;
                                }
                                this.method_2(paintEventArgs_0.Graphics, left, top, str10, charMatrix, this.ForeColor, this.bool_3);
                                i++;
                            }
                        }
                        if (this.das_LCDCharTextMode_0 == DAS_LCDCharTextMode.LCTM_TwoText && this.string_1 != string.Empty)
                        {
                            j = 0;
                            if (width1 <= this.string_1.Length)
                            {
                                left1 = x.Left + (x.Width - width1 * int8) / 2;
                                if (this.das_LCDWordWrapType_0 != DAS_LCDWordWrapType.LWWT_None)
                                {
                                    int11 = int11 - int81 - (this.string_1.Length / width1 + 1) * int81 + this.int_12 * int81;
                                    flag = false;
                                }
                                else
                                {
                                    int11 = int11 - 2 * int81 + this.int_12 * int81;
                                    flag = true;
                                }
                            }
                            else
                            {
                                left1 = x.Left + int8 * (width1 - this.string_1.Length) / 2 + this.int_10;
                                int11 = int11 - 2 * int81 + this.int_12 * int81;
                                flag = true;
                            }
                            left = x.Left + (x.Width - width1 * int8) / 2;
                            if (!flag)
                            {
                                top = int11;
                                left = left1;
                                j = 0;
                                num = 0;
                                while (top + int10 < x.Bottom)
                                {
                                    left = left1;
                                    bool flag11 = false;
                                    bool flag12 = false;
                                    num1 = 0;
                                    while (!flag11)
                                    {
                                        charMatrix3.LowDWord = (ulong)0;
                                        charMatrix3.HiDWord = (ulong)0;
                                        left = x.Left + (x.Width - width1 * int8) / 2 + int8 * num1;
                                        string str11 = string.Empty;
                                        if (left >= left1 && top >= int11 && j < this.string_1.Length && !flag12)
                                        {
                                            str11 = this.method_1(this.string_1.Substring(j, 1));
                                        }
                                        if (num1 < width1 - 1)
                                        {
                                            if (this.das_LCDWordWrapType_0 == DAS_LCDWordWrapType.LWWT_WordWrap3 && !flag12 && j < this.string_1.Length && (this.string_1.Substring(j, 1) == " " || this.string_1.Substring(j, 1) == "," || this.string_1.Substring(j, 1) == ";" || this.string_1.Substring(j, 1) == "?" || this.string_1.Substring(j, 1) == "!" || this.string_1.Substring(j, 1) == ".") && j + 1 < this.string_0.Length - 1)
                                            {
                                                int num10 = this.string_1.IndexOf(" ", j + 1);
                                                int num11 = this.string_1.IndexOf(",", j + 1);
                                                if (num10 > j && num11 > j && num11 < num10)
                                                {
                                                    num10 = num11 + 1;
                                                }
                                                num11 = this.string_1.IndexOf(".", j + 1);
                                                if (num10 > j && num11 > j && num11 < num10)
                                                {
                                                    num10 = num11 + 1;
                                                }
                                                num11 = this.string_1.IndexOf("?", j + 1);
                                                if (num10 > j && num11 > j && num11 < num10)
                                                {
                                                    num10 = num11 + 1;
                                                }
                                                num11 = this.string_1.IndexOf(";", j + 1);
                                                if (num10 > j && num11 > j && num11 < num10)
                                                {
                                                    num10 = num11 + 1;
                                                }
                                                num11 = this.string_1.IndexOf("?", j + 1);
                                                if (num10 > j && num11 > j && num11 < num10)
                                                {
                                                    num10 = num11 + 1;
                                                }
                                                if (num10 - 1 - j > width1 - 1 - num1)
                                                {
                                                    flag12 = true;
                                                    j++;
                                                }
                                                else if (num10 <= 0 && this.string_1.Length - 1 - j > width1 - 1 - num1)
                                                {
                                                    flag12 = true;
                                                    j++;
                                                }
                                            }
                                        }
                                        else if (top < int11)
                                        {
                                            flag11 = true;
                                        }
                                        else if (j >= this.string_1.Length || this.das_LCDWordWrapType_0 == DAS_LCDWordWrapType.LWWT_WordWrap1 || flag12)
                                        {
                                            flag11 = true;
                                        }
                                        else if (this.string_1.Substring(j, 1) == " " || this.string_1.Substring(j, 1) == "!" || this.string_1.Substring(j, 1) == "," || this.string_1.Substring(j, 1) == "." || this.string_1.Substring(j, 1) == ";" || this.string_1.Substring(j, 1) == "?")
                                        {
                                            flag11 = true;
                                        }
                                        if (top >= int11)
                                        {
                                            if (left >= left1 && !flag12)
                                            {
                                                j++;
                                            }
                                            if (num1 > width1 - 1)
                                            {
                                                if (j < this.string_1.Length && this.string_1.Substring(j, 1) == " ")
                                                {
                                                    flag11 = true;
                                                    j++;
                                                }
                                            }
                                            else if (this.das_LCDWordWrapType_0 == DAS_LCDWordWrapType.LWWT_WordWrap3 && j < this.string_1.Length && this.string_1.Substring(j, 1) == " " && flag11)
                                            {
                                                j++;
                                            }
                                        }
                                        if (top + int81 >= x.Top && str11 != string.Empty)
                                        {
                                            this.method_2(paintEventArgs_0.Graphics, left, top, str11, charMatrix3, this.color_10, false);
                                        }
                                        num1++;
                                    }
                                    top = top + int81;
                                    num++;
                                }
                            }
                            else
                            {
                                top = int11;
                                i = 0;
                                while (left + int8 + int10 < x.Right)
                                {
                                    charMatrix2.LowDWord = (ulong)0;
                                    charMatrix2.HiDWord = (ulong)0;
                                    left = x.Left + this.int_10 + int8 * i;
                                    string str12 = string.Empty;
                                    if (left >= left1 && j < this.string_1.Length)
                                    {
                                        str12 = this.method_1(this.string_1.Substring(j, 1));
                                        j++;
                                    }
                                    this.method_2(paintEventArgs_0.Graphics, left, top, str12, charMatrix2, this.color_10, false);
                                    i++;
                                }
                            }
                        }
                    }
                Label0:
                    if (this.das_BorderStyle_0 != DAS_BorderStyle.BS_RoundRect)
                    {
                        System.Drawing.Region region = new System.Drawing.Region(base.ClientRectangle);
                        GraphicsPath graphicsPath = new GraphicsPath();
                        graphicsPath.AddRectangle(x);
                        region.Exclude(graphicsPath);
                        SolidBrush solidBrush2 = new SolidBrush(base.Parent.BackColor);
                        paintEventArgs_0.Graphics.FillRegion(solidBrush2, region);
                        solidBrush2.Dispose();
                        graphicsPath.Dispose();
                        region.Dispose();
                    }
                    else
                    {
                        System.Drawing.Region region1 = new System.Drawing.Region(base.ClientRectangle);
                        GraphicsPath graphicsPath1 = new GraphicsPath();
                        _DrawGraphics.method_3(graphicsPath1, x, this.int_3 - this.int_0 - this.int_1 - this.int_4 - this.int_2);
                        region1.Exclude(graphicsPath1);
                        SolidBrush solidBrush3 = new SolidBrush(base.Parent.BackColor);
                        paintEventArgs_0.Graphics.FillRegion(solidBrush3, region1);
                        solidBrush3.Dispose();
                        graphicsPath1.Dispose();
                        region1.Dispose();
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
                        System.Drawing.Region region2 = new System.Drawing.Region(graphicsPath2);
                        System.Drawing.Region region3 = new System.Drawing.Region(graphicsPath2);
                        region3.Intersect(graphicsPath3);
                        region2.Xor(region3);
                        paintEventArgs_0.Graphics.SetClip(region2, CombineMode.Replace);
                        _DrawGraphics.method_4(paintEventArgs_0.Graphics, rectangle, graphicsPath3, this.color_7, this.int_7, this.float_7);
                        paintEventArgs_0.Graphics.ResetClip();
                        region3.Dispose();
                        region2.Dispose();
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
                    if (this.bool_0)
                    {
                        SolidBrush solidBrush4 = new SolidBrush(Color.Red);
                        StringFormat stringFormat = new StringFormat()
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        };
                        paintEventArgs_0.Graphics.DrawString("Trial Period Expires !!!!", this.Font, solidBrush4, base.ClientRectangle, stringFormat);
                        solidBrush4.Dispose();
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

        public struct CharMatrix
        {
            public ulong HiDWord;

            public ulong LowDWord;
        }

        public struct LCDLineText
        {
            public int iLine;

            public int iLineOffSet;

            public string strTextLine;

            public CharMatrix stChar;

            public Color cLineColor;
        }
    }
}
