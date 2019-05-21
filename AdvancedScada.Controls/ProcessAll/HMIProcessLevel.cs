using AdvancedScada.Controls;
using AdvancedScada.Controls.DialogEditor;
using AdvancedScada.Controls.Enum;
using AdvancedScada.Controls.Keyboard;
using AdvancedScada.Controls.Licenses;
using AdvancedScada.Controls.ProcessAll.DrawAll;
using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Client;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace AdvancedScada.Controls.ProcessAll
{
    [ToolboxBitmap(typeof(HMIProcessLevel), "DASNetProcessLevel.ico")]
    public class HMIProcessLevel : Control
    {


        private DAS_BorderStyle das_BorderStyle_0;

        private int int_0;

        private Color color_0 = Color.Blue;

        private int int_1 = 5;

        private int int_2 = 5;

        private Color color_1 = Color.DimGray;

        private Color color_2 = Color.White;

        private Color color_3 = Color.DimGray;

        private Color color_4 = Color.White;

        private int int_3 = 10;

        private int int_4;

        private Color color_5 = Color.Gray;

        private DAS_BorderGradientStyle das_BorderGradientStyle_0;

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

        private bool bool_3 = true;

        private string string_0 = string.Empty;

        private double double_0 = 50;

        private int int_9;

        private int int_10;

        private DAS_ProgressLevelShape das_ProgressLevelShape_0;

        private Image image_0;

        private int int_11 = 20;

        private int int_12;

        private int int_13;

        private int int_14;

        private Color color_8 = Color.DimGray;

        private Color color_9 = Color.Silver;

        private bool bool_4 = true;

        private float float_8 = 0.5f;

        private Color color_10 = Color.LightGray;

        private Color color_11 = Color.White;

        private float float_9 = 0.5f;

        private bool bool_5 = true;

        private Color color_12 = Color.Green;

        private Color color_13 = Color.White;

        private float float_10 = 0.5f;

        private System.Drawing.Size size_0 = new System.Drawing.Size(30, 50);

        private bool bool_6 = true;

        private double double_1 = 100;

        private double double_2;

        private int int_15 = 6;

        private int int_16 = 4;

        private Color color_14 = Color.Black;

        private Color color_15 = Color.Black;

        private int int_17 = 1;

        private int int_18 = 16;

        private Color color_16 = Color.White;

        private DAS_TickerShapeStyle das_TickerShapeStyle_0;

        private int int_19 = 1;

        private int int_20 = 6;

        private Color color_17 = Color.White;

        private DAS_TickerShapeStyle das_TickerShapeStyle_1;

        private DAS_TickerAlignmentStyle das_TickerAlignmentStyle_0 = DAS_TickerAlignmentStyle.TAS_Center;

        private int int_21 = 10;

        private int int_22 = 2;

        private DrawGraphics _DrawGraphics = new DrawGraphics();

        private IContainer icontainer_0;

        [Category("General")]
        [DefaultValue("true")]
        [Description("Get/Set the visibility of the actual value")]
        public bool ActualValueVisible
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
        [DefaultValue("BGS_None")]
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

        [Category("Shape")]
        [DefaultValue("30")]
        [Description("Get/Set the size of the shape duct")]
        public System.Drawing.Size DuctSize
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
        [DefaultValue("Color.White")]
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

        [Category("Shape")]
        [DefaultValue("DAS_ProgressLevelShape.PLS_Tube")]
        [Description("Get/Set the shape type of the process level")]
        public DAS_ProgressLevelShape LevelShape
        {
            get
            {
                return this.das_ProgressLevelShape_0;
            }
            set
            {
                this.das_ProgressLevelShape_0 = value;
                base.Invalidate();
            }
        }

        [Category("Scale")]
        [DefaultValue("100.0")]
        [Description("Get/Set Max value of the scale")]
        public double Max
        {
            get
            {
                return this.double_1;
            }
            set
            {
                this.double_1 = value;
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

        [Category("Scale")]
        [DefaultValue("0.0")]
        [Description("Get/Set Min value of the scale")]
        public double Min
        {
            get
            {
                return this.double_2;
            }
            set
            {
                this.double_2 = value;
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
        [DefaultValue("Color.White")]
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

        [Category("Scale")]
        [DefaultValue("2")]
        [Description("Get/Set the bottom gap between the border of shape and the scale")]
        public int ScaleBottomGap
        {
            get
            {
                return this.int_22;
            }
            set
            {
                if (value >= 0)
                {
                    this.int_22 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Scale")]
        [DefaultValue("Color.Black")]
        [Description("Get/Set the scale Text color")]
        public Color ScaleTextColor
        {
            get
            {
                return this.color_15;
            }
            set
            {
                this.color_15 = value;
                base.Invalidate();
            }
        }

        [Category("Scale")]
        [DefaultValue("10")]
        [Description("Get/Set the top gap between the border of shape and the scale")]
        public int ScaleTopGap
        {
            get
            {
                return this.int_21;
            }
            set
            {
                if (value >= 0)
                {
                    this.int_21 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Scale")]
        [DefaultValue("true")]
        [Description("Get/Set the visibility of the scale")]
        public bool ScaleVisible
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

        [Category("Shape")]
        [DefaultValue("Color.LightGray")]
        [Description("Get/Set the background color of the shape")]
        public Color ShapeBackColor
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

        [Category("Shape")]
        [DefaultValue("true")]
        [Description("Get/Set whether the background of the shape is drawn in gradient mode")]
        public bool ShapeBackGradient
        {
            get
            {
                return this.bool_4;
            }
            set
            {
                this.bool_4 = value;
                base.Invalidate();
            }
        }

        [Category("Shape")]
        [DefaultValue("Color.white")]
        [Description("Get/Set the background gradient color of the shape")]
        public Color ShapeBackGradientColor
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

        [Category("Shape")]
        [DefaultValue("0.5")]
        [Description("Get/Set the transparency of the shape background")]
        public float ShapeBackTransparency
        {
            get
            {
                return this.float_9;
            }
            set
            {
                if ((double)value >= 0 && (double)value <= 1)
                {
                    this.float_9 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Shape")]
        [DefaultValue("Color.DimGray")]
        [Description("Get/Set the border color of the shape")]
        public Color ShapeBorderColor
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

        [Category("Shape")]
        [DefaultValue("Color.Green")]
        [Description("Get/Set the process bar color of the shape")]
        public Color ShapeForeColor
        {
            get
            {
                return this.color_12;
            }
            set
            {
                this.color_12 = value;
                base.Invalidate();
            }
        }

        [Category("Shape")]
        [DefaultValue("true")]
        [Description("Get/Set whether the process bar of the shape is drawn in gradient mode")]
        public bool ShapeForeGradient
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

        [Category("Shape")]
        [DefaultValue("Color.white")]
        [Description("Get/Set the process bar gradient color of the shape")]
        public Color ShapeForeGradientColor
        {
            get
            {
                return this.color_13;
            }
            set
            {
                this.color_13 = value;
                base.Invalidate();
            }
        }

        [Category("Shape")]
        [DefaultValue("0.5")]
        [Description("Get/Set the transparency of the shape process bar")]
        public float ShapeForeTransparency
        {
            get
            {
                return this.float_10;
            }
            set
            {
                if ((double)value >= 0 && (double)value <= 1)
                {
                    this.float_10 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Shape")]
        [DefaultValue("0.5")]
        [Description("Get/Set the gradient rate of the shape")]
        public float ShapeGradientRate
        {
            get
            {
                return this.float_8;
            }
            set
            {
                if ((double)value >= 0 && (double)value <= 1)
                {
                    this.float_8 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Shape")]
        [DefaultValue("20")]
        [Description("Get/Set the height of the shape header")]
        public int ShapeHeaderHeight
        {
            get
            {
                return this.int_11;
            }
            set
            {
                if (value >= 0)
                {
                    this.int_11 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Shape")]
        [DefaultValue("null")]
        [Description("Get/Set the shape image if the shape type is PLS_Image")]
        public Image ShapeImage
        {
            get
            {
                return this.image_0;
            }
            set
            {
                this.image_0 = value;
                base.Invalidate();
            }
        }

        [Category("Shape")]
        [DefaultValue("0")]
        [Description("Get/Set the X Offset of the shape")]
        public int ShapeOffsetX
        {
            get
            {
                return this.int_13;
            }
            set
            {
                this.int_13 = value;
                base.Invalidate();
            }
        }

        [Category("Shape")]
        [DefaultValue("0")]
        [Description("Get/Set the Y Offset of the shape")]
        public int ShapeOffsetY
        {
            get
            {
                return this.int_14;
            }
            set
            {
                this.int_14 = value;
                base.Invalidate();
            }
        }

        [Category("Shape")]
        [DefaultValue("Color.Silver")]
        [Description("Get/Set the wall color of the shape")]
        public Color ShapeWallColor
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

        [Category("Shape")]
        [DefaultValue("0")]
        [Description("Get/Set the thickness of the shape wall")]
        public int ShapeWallThickness
        {
            get
            {
                return this.int_12;
            }
            set
            {
                if (value >= 0)
                {
                    this.int_12 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Scale")]
        [DefaultValue("Color.White")]
        [Description("Get/Set the color to fill the interior of the sub ticker if its width is greater than 1")]
        public Color SubTickerFillColor
        {
            get
            {
                return this.color_17;
            }
            set
            {
                this.color_17 = value;
                base.Invalidate();
            }
        }

        [Category("Scale")]
        [DefaultValue("6")]
        [Description("Get/Set  length of the sub tickers")]
        public int SubTickerLength
        {
            get
            {
                return this.int_20;
            }
            set
            {
                this.int_20 = value;
                base.Invalidate();
            }
        }

        [Category("Scale")]
        [DefaultValue("4")]
        [Description("Get/Set the scale sub ticker number")]
        public int SubTickerNumber
        {
            get
            {
                return this.int_16;
            }
            set
            {
                this.int_16 = value;
                base.Invalidate();
            }
        }

        [Category("Scale")]
        [DefaultValue("DAS_TickerShapeStyle.Line")]
        [Description("Get/Set the sub  ticker shape")]
        public DAS_TickerShapeStyle SubTickerShape
        {
            get
            {
                return this.das_TickerShapeStyle_1;
            }
            set
            {
                this.das_TickerShapeStyle_1 = value;
                base.Invalidate();
            }
        }

        [Category("Scale")]
        [DefaultValue("1")]
        [Description("Get/Set the size of the sub ticker")]
        public int SubTickerWidth
        {
            get
            {
                return this.int_19;
            }
            set
            {
                this.int_19 = value;
                base.Invalidate();
            }
        }

        [Category("General")]
        [DefaultValue("0")]
        [Description("Get/Set the X Offset of the text (value string & unit)")]
        public int TextOffsetX
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

        [Category("General")]
        [DefaultValue("0")]
        [Description("Get/Set the Y Offset of the text (value string & unit)")]
        public int TextOffsetY
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

        [Category("Scale")]
        [DefaultValue("DAS_TickerAlignmentStyle.TAS_Center")]
        [Description("Get/Set the alignment type of scale tickers")]
        public DAS_TickerAlignmentStyle TickerAlignment
        {
            get
            {
                return this.das_TickerAlignmentStyle_0;
            }
            set
            {
                this.das_TickerAlignmentStyle_0 = value;
                base.Invalidate();
            }
        }

        [Category("Scale")]
        [DefaultValue("Color.White")]
        [Description("Get/Set the color to fill the interior of the ticker if its width is greater than 1")]
        public Color TickerFillColor
        {
            get
            {
                return this.color_16;
            }
            set
            {
                this.color_16 = value;
                base.Invalidate();
            }
        }

        [Category("Scale")]
        [DefaultValue("16")]
        [Description("Get/Set  length of the tickers")]
        public int TickerLength
        {
            get
            {
                return this.int_18;
            }
            set
            {
                this.int_18 = value;
                base.Invalidate();
            }
        }

        [Category("Scale")]
        [DefaultValue("Color.Black")]
        [Description("Get/Set the ticker line color")]
        public Color TickerLineColor
        {
            get
            {
                return this.color_14;
            }
            set
            {
                this.color_14 = value;
                base.Invalidate();
            }
        }

        [Category("Scale")]
        [DefaultValue("6")]
        [Description("Get/Set the scale ticker number")]
        public int TickerNumber
        {
            get
            {
                return this.int_15;
            }
            set
            {
                this.int_15 = value;
                base.Invalidate();
            }
        }

        [Category("Scale")]
        [DefaultValue("DAS_TickerShapeStyle.Line")]
        [Description("Get/Set the ticker shape")]
        public DAS_TickerShapeStyle TickerShape
        {
            get
            {
                return this.das_TickerShapeStyle_0;
            }
            set
            {
                this.das_TickerShapeStyle_0 = value;
                base.Invalidate();
            }
        }

        [Category("Scale")]
        [DefaultValue("1")]
        [Description("Get/Set the size of the ticker")]
        public int TickerWidth
        {
            get
            {
                return this.int_17;
            }
            set
            {
                this.int_17 = value;
                base.Invalidate();
            }
        }

        [Category("General")]
        [DefaultValue("")]
        [Description("Get/Set the unit of the scale")]
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
        [DefaultValue("50.0")]
        [Description("Get/Set the actual value of the process")]
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

        public HMIProcessLevel()
        {


            base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            base.SetStyle(ControlStyles.Opaque, true);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.method_13();
        }

        private void method_0(Graphics graphics_0, Rectangle rectangle_0, int int_23, int int_24)
        {
            if (this.bool_2 && this.int_7 > 0 && this.int_7 < rectangle_0.Width / 3 && this.int_7 < rectangle_0.Height / 3 && this.das_BorderGradientStyle_0 == DAS_BorderGradientStyle.BGS_None)
            {
                rectangle_0.X = rectangle_0.X + this.int_7;
                rectangle_0.Y = rectangle_0.Y + this.int_7;
                GraphicsPath graphicsPath = new GraphicsPath();
                this.method_5(graphicsPath, rectangle_0, this.das_ProgressLevelShape_0, this.int_11, int_24);
                rectangle_0.X = rectangle_0.X - this.int_7;
                rectangle_0.Y = rectangle_0.Y - this.int_7;
                GraphicsPath graphicsPath1 = new GraphicsPath();
                this.method_5(graphicsPath1, rectangle_0, this.das_ProgressLevelShape_0, this.int_11, int_24);
                System.Drawing.Region region = new System.Drawing.Region(graphicsPath);
                System.Drawing.Region region1 = new System.Drawing.Region(graphicsPath);
                region1.Intersect(graphicsPath1);
                region.Xor(region1);
                graphics_0.SetClip(region, CombineMode.Replace);
                this._DrawGraphics.method_4(graphics_0, rectangle_0, graphicsPath1, this.color_7, this.int_7, this.float_7);
                graphics_0.ResetClip();
                region1.Dispose();
                region.Dispose();
                graphicsPath1.Dispose();
                graphicsPath.Dispose();
            }
            GraphicsPath graphicsPath2 = new GraphicsPath();
            this.method_5(graphicsPath2, rectangle_0, this.das_ProgressLevelShape_0, this.int_11, int_24);
            int float9 = 255;
            if ((double)this.float_9 > 0)
            {
                float9 = 255 - (int)(255f * this.float_9);
            }
            Color color = Color.FromArgb(float9, this.color_10);
            Color color1 = Color.FromArgb(float9, this.color_9);
            Color color2 = Color.FromArgb(float9, this.color_11);
            Pen pen = new Pen(Color.FromArgb(float9, this.color_8));
            if (this.int_12 > 0)
            {
                Rectangle rectangle = new Rectangle(rectangle_0.Left + this.int_12 + 1, rectangle_0.Top, rectangle_0.Width - 2 * this.int_12 - 2, rectangle_0.Height - this.int_12 - 1);
                GraphicsPath graphicsPath3 = new GraphicsPath();
                if (this.int_11 <= this.int_12 + 3)
                {
                    this.method_5(graphicsPath3, rectangle, this.das_ProgressLevelShape_0, this.int_11, int_24);
                }
                else
                {
                    this.method_5(graphicsPath3, rectangle, this.das_ProgressLevelShape_0, this.int_11 - this.int_12, int_24 - this.int_12);
                }
                graphics_0.SetClip(graphicsPath3, CombineMode.Exclude);
                SolidBrush solidBrush = new SolidBrush(color1);
                graphics_0.FillPath(solidBrush, graphicsPath2);
                solidBrush.Dispose();
                graphics_0.ResetClip();
                graphicsPath3.Reset();
                rectangle.X = rectangle.X - 1;
                rectangle.Width = rectangle.Width + 2;
                rectangle.Height = rectangle.Height + 1;
                if (this.int_11 <= this.int_12 + 3)
                {
                    this.method_5(graphicsPath3, rectangle, this.das_ProgressLevelShape_0, this.int_11, int_24);
                }
                else
                {
                    this.method_5(graphicsPath3, rectangle, this.das_ProgressLevelShape_0, this.int_11 - this.int_12, int_24 - this.int_12);
                }
                if (!this.bool_4)
                {
                    SolidBrush solidBrush1 = new SolidBrush(color);
                    graphics_0.FillPath(solidBrush1, graphicsPath3);
                    solidBrush1.Dispose();
                }
                else
                {
                    this._DrawGraphics.method_2(graphics_0, rectangle, DAS_BorderStyle.BS_Rect, graphicsPath3, color, color2, DAS_BkGradientStyle.BKGS_Linear2, 0, this.float_8, 0, 0f);
                }
                graphicsPath3.Dispose();
            }
            else if (!this.bool_4)
            {
                SolidBrush solidBrush2 = new SolidBrush(color);
                graphics_0.FillPath(solidBrush2, graphicsPath2);
                solidBrush2.Dispose();
            }
            else
            {
                this._DrawGraphics.method_2(graphics_0, rectangle_0, DAS_BorderStyle.BS_Rect, graphicsPath2, color, color2, DAS_BkGradientStyle.BKGS_Linear2, 0, this.float_8, 0, 0f);
            }
            graphics_0.DrawPath(pen, graphicsPath2);
            graphicsPath2.Dispose();
            if (this.das_ProgressLevelShape_0 == DAS_ProgressLevelShape.PLS_Tube3)
            {
                Color color3 = Color.FromArgb(255, (this.color_9.R + 255) / 2, (this.color_9.G + 255) / 2, (this.color_9.B + 255) / 2);
                Color color4 = Color.FromArgb(255, (this.color_10.R + 255) / 2, (this.color_10.G + 255) / 2, (this.color_10.B + 255) / 2);
                Rectangle rectangle1 = new Rectangle(rectangle_0.Left, rectangle_0.Top - int_24, rectangle_0.Width, 2 * int_24);
                if (this.int_12 > 0)
                {
                    Rectangle rectangle2 = new Rectangle(rectangle1.Left + this.int_12, rectangle1.Top + this.int_12, rectangle1.Width - 2 * this.int_12, rectangle1.Height - 2 * this.int_12);
                    SolidBrush solidBrush3 = new SolidBrush(color3);
                    graphics_0.FillEllipse(solidBrush3, rectangle1);
                    if (this.bool_4)
                    {
                        GraphicsPath graphicsPath4 = new GraphicsPath();
                        graphicsPath4.AddEllipse(rectangle2);
                        this._DrawGraphics.method_2(graphics_0, rectangle2, DAS_BorderStyle.BS_Rect, graphicsPath4, color4, this.color_11, DAS_BkGradientStyle.BKGS_Linear2, 0, this.float_8, 0, 0f);
                        graphicsPath4.Dispose();
                    }
                    else
                    {
                        solidBrush3.Color = color4;
                        graphics_0.FillEllipse(solidBrush3, rectangle2);
                    }
                    solidBrush3.Dispose();
                }
                else if (this.bool_4)
                {
                    GraphicsPath graphicsPath5 = new GraphicsPath();
                    graphicsPath5.AddEllipse(rectangle1);
                    this._DrawGraphics.method_2(graphics_0, rectangle1, DAS_BorderStyle.BS_Rect, graphicsPath5, color4, this.color_11, DAS_BkGradientStyle.BKGS_Linear2, 0, this.float_8, 0, 0f);
                    graphicsPath5.Dispose();
                }
                else
                {
                    SolidBrush solidBrush4 = new SolidBrush(color4);
                    graphics_0.FillEllipse(solidBrush4, rectangle1);
                    solidBrush4.Dispose();
                }
                graphics_0.DrawEllipse(pen, rectangle1);
            }
            pen.Dispose();
            float9 = 255;
            if ((double)this.float_10 > 0)
            {
                float9 = 255 - (int)(255f * this.float_10);
            }
            Color color5 = Color.FromArgb(float9, this.color_12);
            Color color6 = Color.FromArgb(float9, this.color_13);
            Rectangle x = new Rectangle(rectangle_0.Left + this.int_12 + 1, int_23, rectangle_0.Width - 2 * this.int_12 - 2, rectangle_0.Bottom - int_23 - this.int_12 - 1);
            if (this.das_ProgressLevelShape_0 == DAS_ProgressLevelShape.PLS_Tube2)
            {
                x.X = x.X + 5;
                x.Width = x.Width - 10;
            }
            GraphicsPath graphicsPath6 = new GraphicsPath();
            if (this.int_11 > this.int_12 + 3)
            {
                if (this.das_ProgressLevelShape_0 != DAS_ProgressLevelShape.PLS_Tube2)
                {
                    this.method_5(graphicsPath6, x, this.das_ProgressLevelShape_0, this.int_11 - this.int_12, int_24 - this.int_12);
                }
                else
                {
                    this.method_5(graphicsPath6, x, DAS_ProgressLevelShape.PLS_Tube, this.int_11 - this.int_12, int_24 - this.int_12);
                }
            }
            else if (this.das_ProgressLevelShape_0 != DAS_ProgressLevelShape.PLS_Tube2)
            {
                this.method_5(graphicsPath6, x, this.das_ProgressLevelShape_0, this.int_11, int_24 - this.int_12);
            }
            else
            {
                this.method_5(graphicsPath6, x, DAS_ProgressLevelShape.PLS_Tube, this.int_11, int_24 - this.int_12);
            }
            if (!this.bool_5)
            {
                SolidBrush solidBrush5 = new SolidBrush(color5);
                graphics_0.FillPath(solidBrush5, graphicsPath6);
                solidBrush5.Dispose();
            }
            else
            {
                this._DrawGraphics.method_2(graphics_0, x, DAS_BorderStyle.BS_Rect, graphicsPath6, color5, color6, DAS_BkGradientStyle.BKGS_Linear2, 0, this.float_8, 0, 0f);
            }
            graphicsPath6.Dispose();
            if (this.das_ProgressLevelShape_0 == DAS_ProgressLevelShape.PLS_Tube3)
            {
                Color color7 = Color.FromArgb(float9, (this.color_12.R + 255) / 2, (this.color_12.G + 255) / 2, (this.color_12.B + 255) / 2);
                Rectangle rectangle3 = new Rectangle(x.Left, x.Top - int_24 + this.int_12, x.Width, 2 * (int_24 - this.int_12));
                if (!this.bool_5)
                {
                    SolidBrush solidBrush6 = new SolidBrush(color7);
                    graphics_0.FillEllipse(solidBrush6, rectangle3);
                    solidBrush6.Dispose();
                    return;
                }
                Color color8 = Color.FromArgb(float9, (this.color_13.R + 255) / 2, (this.color_13.G + 255) / 2, (this.color_13.B + 255) / 2);
                GraphicsPath graphicsPath7 = new GraphicsPath();
                graphicsPath7.AddEllipse(rectangle3);
                this._DrawGraphics.method_2(graphics_0, rectangle3, DAS_BorderStyle.BS_Rect, graphicsPath7, color7, color8, DAS_BkGradientStyle.BKGS_Linear2, 0, this.float_8, 0, 0f);
                graphicsPath7.Dispose();
            }
        }

        private void method_1(Graphics graphics_0, Rectangle rectangle_0, int int_23, int int_24)
        {
            if (this.bool_2 && this.int_7 > 0 && this.int_7 < rectangle_0.Width / 3 && this.int_7 < rectangle_0.Height / 3 && this.das_BorderGradientStyle_0 == DAS_BorderGradientStyle.BGS_None)
            {
                rectangle_0.X = rectangle_0.X + this.int_7;
                rectangle_0.Y = rectangle_0.Y + this.int_7;
                GraphicsPath graphicsPath = new GraphicsPath();
                this.method_7(graphicsPath, rectangle_0, this.das_ProgressLevelShape_0, int_24, this.size_0, int_23, false);
                rectangle_0.X = rectangle_0.X - this.int_7;
                rectangle_0.Y = rectangle_0.Y - this.int_7;
                GraphicsPath graphicsPath1 = new GraphicsPath();
                this.method_7(graphicsPath1, rectangle_0, this.das_ProgressLevelShape_0, int_24, this.size_0, int_23, false);
                System.Drawing.Region region = new System.Drawing.Region(graphicsPath);
                System.Drawing.Region region1 = new System.Drawing.Region(graphicsPath);
                region1.Intersect(graphicsPath1);
                region.Xor(region1);
                graphics_0.SetClip(region, CombineMode.Replace);
                this._DrawGraphics.method_4(graphics_0, rectangle_0, graphicsPath1, this.color_7, this.int_7, this.float_7);
                graphics_0.ResetClip();
                region1.Dispose();
                region.Dispose();
                graphicsPath1.Dispose();
                graphicsPath.Dispose();
            }
            System.Drawing.Size size0 = this.size_0;
            size0.Width = this.size_0.Width - 2 * this.int_12;
            if (size0.Width < 3)
            {
                size0.Width = this.size_0.Width;
            }
            GraphicsPath graphicsPath2 = new GraphicsPath();
            this.method_7(graphicsPath2, rectangle_0, this.das_ProgressLevelShape_0, int_24, this.size_0, int_23, false);
            int float9 = 255;
            if ((double)this.float_9 > 0)
            {
                float9 = 255 - (int)(255f * this.float_9);
            }
            Color color = Color.FromArgb(float9, this.color_10);
            Color color1 = Color.FromArgb(float9, this.color_9);
            Color color2 = Color.FromArgb(float9, this.color_11);
            Pen pen = new Pen(Color.FromArgb(float9, this.color_8));
            if (this.int_12 > 0)
            {
                Rectangle rectangle = new Rectangle(rectangle_0.Left + this.int_12 + 1, rectangle_0.Top, rectangle_0.Width - 2 * this.int_12 - 2, rectangle_0.Height);
                GraphicsPath graphicsPath3 = new GraphicsPath();
                if (int_24 <= this.int_12 + 3)
                {
                    this.method_7(graphicsPath3, rectangle, this.das_ProgressLevelShape_0, int_24, size0, int_23, false);
                }
                else
                {
                    this.method_7(graphicsPath3, rectangle, this.das_ProgressLevelShape_0, int_24 - this.int_12, size0, int_23, false);
                }
                graphics_0.SetClip(graphicsPath3, CombineMode.Exclude);
                SolidBrush solidBrush = new SolidBrush(color1);
                graphics_0.FillPath(solidBrush, graphicsPath2);
                solidBrush.Dispose();
                graphics_0.ResetClip();
                graphicsPath3.Reset();
                rectangle.X = rectangle.X - 1;
                rectangle.Width = rectangle.Width + 2;
                rectangle.Height = rectangle.Height + 1;
                if (int_24 <= this.int_12 + 3)
                {
                    this.method_7(graphicsPath3, rectangle, this.das_ProgressLevelShape_0, int_24, size0, int_23, false);
                }
                else
                {
                    this.method_7(graphicsPath3, rectangle, this.das_ProgressLevelShape_0, int_24 - this.int_12, size0, int_23, false);
                }
                if (!this.bool_4)
                {
                    SolidBrush solidBrush1 = new SolidBrush(color);
                    graphics_0.FillPath(solidBrush1, graphicsPath3);
                    solidBrush1.Dispose();
                }
                else
                {
                    this.method_11(graphics_0, rectangle, graphicsPath3, color, color2, this.float_8);
                }
                graphicsPath3.Dispose();
            }
            else if (!this.bool_4)
            {
                SolidBrush solidBrush2 = new SolidBrush(color);
                graphics_0.FillPath(solidBrush2, graphicsPath2);
                solidBrush2.Dispose();
            }
            else
            {
                this.method_11(graphics_0, rectangle_0, graphicsPath2, color, color2, this.float_8);
            }
            graphics_0.DrawPath(pen, graphicsPath2);
            graphicsPath2.Dispose();
            if (this.das_ProgressLevelShape_0 == DAS_ProgressLevelShape.PLS_Funnel2)
            {
                Color color3 = Color.FromArgb(255, (this.color_9.R + 255) / 2, (this.color_9.G + 255) / 2, (this.color_9.B + 255) / 2);
                Color color4 = Color.FromArgb(255, (this.color_10.R + 255) / 2, (this.color_10.G + 255) / 2, (this.color_10.B + 255) / 2);
                Color color5 = Color.FromArgb(255, (this.color_11.R + 255) / 2, (this.color_11.G + 255) / 2, (this.color_11.B + 255) / 2);
                Rectangle rectangle1 = new Rectangle(rectangle_0.Left, rectangle_0.Top - int_24, rectangle_0.Width, 2 * int_24);
                if (this.int_12 > 0)
                {
                    Rectangle rectangle2 = new Rectangle(rectangle1.Left + this.int_12, rectangle1.Top + this.int_12, rectangle1.Width - 2 * this.int_12, rectangle1.Height - 2 * this.int_12);
                    SolidBrush solidBrush3 = new SolidBrush(color3);
                    graphics_0.FillEllipse(solidBrush3, rectangle1);
                    if (this.bool_4)
                    {
                        GraphicsPath graphicsPath4 = new GraphicsPath();
                        graphicsPath4.AddEllipse(rectangle2);
                        this._DrawGraphics.method_2(graphics_0, rectangle2, DAS_BorderStyle.BS_Rect, graphicsPath4, color4, color5, DAS_BkGradientStyle.BKGS_Linear2, 0, this.float_8, 0, 0f);
                        graphicsPath4.Dispose();
                    }
                    else
                    {
                        solidBrush3.Color = color4;
                        graphics_0.FillEllipse(solidBrush3, rectangle2);
                    }
                    solidBrush3.Dispose();
                }
                else if (this.bool_4)
                {
                    GraphicsPath graphicsPath5 = new GraphicsPath();
                    graphicsPath5.AddEllipse(rectangle1);
                    this._DrawGraphics.method_2(graphics_0, rectangle1, DAS_BorderStyle.BS_Rect, graphicsPath5, color4, color5, DAS_BkGradientStyle.BKGS_Linear2, 0, this.float_8, 0, 0f);
                    graphicsPath5.Dispose();
                }
                else
                {
                    SolidBrush solidBrush4 = new SolidBrush(color4);
                    graphics_0.FillEllipse(solidBrush4, rectangle1);
                    solidBrush4.Dispose();
                }
                graphics_0.DrawEllipse(pen, rectangle1);
            }
            pen.Dispose();
            Rectangle rectangle3 = new Rectangle(rectangle_0.Left + this.int_12 + 1, rectangle_0.Top, rectangle_0.Width - 2 * this.int_12 - 2, rectangle_0.Height);
            GraphicsPath graphicsPath6 = new GraphicsPath();
            if (this.int_11 <= this.int_12 + 3)
            {
                this.method_7(graphicsPath6, rectangle3, this.das_ProgressLevelShape_0, int_24, size0, int_23, true);
            }
            else
            {
                this.method_7(graphicsPath6, rectangle3, this.das_ProgressLevelShape_0, int_24 - this.int_12, size0, int_23, true);
            }
            float9 = 255;
            if ((double)this.float_10 > 0)
            {
                float9 = 255 - (int)(255f * this.float_10);
            }
            Color color6 = Color.FromArgb(float9, this.color_12);
            Color color7 = Color.FromArgb(float9, this.color_13);
            if (!this.bool_5)
            {
                SolidBrush solidBrush5 = new SolidBrush(color6);
                graphics_0.FillPath(solidBrush5, graphicsPath6);
                solidBrush5.Dispose();
            }
            else
            {
                this.method_11(graphics_0, rectangle3, graphicsPath6, color6, color7, this.float_8);
            }
            graphicsPath6.Dispose();
            if (this.das_ProgressLevelShape_0 == DAS_ProgressLevelShape.PLS_Funnel2)
            {
                Color color8 = Color.FromArgb(float9, (this.color_12.R + 255) / 2, (this.color_12.G + 255) / 2, (this.color_12.B + 255) / 2);
                Rectangle rectangle4 = new Rectangle(rectangle_0.Left + this.int_12 + 1, rectangle_0.Top, rectangle_0.Width - 2 * this.int_12 - 2, rectangle_0.Height);
                int width = size0.Width;
                if (int_23 < rectangle4.Bottom - size0.Height && size0.Width < rectangle4.Width)
                {
                    width = (int)((float)size0.Width + (float)(rectangle4.Bottom - size0.Height - int_23) * (float)(rectangle4.Width - size0.Width) / (float)(rectangle4.Height - size0.Height));
                }
                int int24 = int_24 * width / rectangle4.Width;
                if (int24 < 2)
                {
                    int24 = 2;
                }
                Rectangle rectangle5 = new Rectangle((rectangle4.Left + rectangle4.Right) / 2 - width / 2, int_23 - int24, width / 2 + width / 2, 2 * int24);
                if (!this.bool_5)
                {
                    SolidBrush solidBrush6 = new SolidBrush(color8);
                    graphics_0.FillEllipse(solidBrush6, rectangle5);
                    solidBrush6.Dispose();
                    return;
                }
                Color color9 = Color.FromArgb(float9, (this.color_13.R + 255) / 2, (this.color_13.G + 255) / 2, (this.color_13.B + 255) / 2);
                GraphicsPath graphicsPath7 = new GraphicsPath();
                graphicsPath7.AddEllipse(rectangle5);
                this._DrawGraphics.method_2(graphics_0, rectangle5, DAS_BorderStyle.BS_Rect, graphicsPath7, color8, color9, DAS_BkGradientStyle.BKGS_Linear2, 0, this.float_8, 0, 0f);
                graphicsPath7.Dispose();
            }
        }

        internal void method_10(Graphics graphics_0, DAS_TickerShapeStyle das_TickerShapeStyle_2, Point point_0, bool bool_7, int int_23, int int_24, bool bool_8, Color color_18, Color color_19)
        {
            graphics_0.TranslateTransform((float)point_0.X, (float)point_0.Y);
            Pen pen = new Pen(color_18);
            SolidBrush solidBrush = new SolidBrush(color_19);
            if (das_TickerShapeStyle_2 != DAS_TickerShapeStyle.Line && int_24 > 1)
            {
                if (das_TickerShapeStyle_2 != DAS_TickerShapeStyle.Rectangle && das_TickerShapeStyle_2 != DAS_TickerShapeStyle.Solid_Rectangle && das_TickerShapeStyle_2 != DAS_TickerShapeStyle.Circle)
                {
                    if (das_TickerShapeStyle_2 == DAS_TickerShapeStyle.Solid_Circle)
                    {
                        goto Label4;
                    }
                    if (das_TickerShapeStyle_2 != DAS_TickerShapeStyle.Triangle)
                    {
                        if (das_TickerShapeStyle_2 == DAS_TickerShapeStyle.Solid_Triangle)
                        {
                            goto Label5;
                        }
                        if (das_TickerShapeStyle_2 == DAS_TickerShapeStyle.Trapezoid || das_TickerShapeStyle_2 == DAS_TickerShapeStyle.Solid_Trapezoid)
                        {
                            int int23 = 0;
                            if (bool_7)
                            {
                                int23 = -int_23 / 2;
                            }
                            GraphicsPath graphicsPath = new GraphicsPath();
                            if (!bool_8)
                            {
                                graphicsPath.AddLine(-int_24 / 4, int_23 + int23, -int_24 / 2, int23);
                                graphicsPath.AddLine(-int_24 / 2, int23, int_24 - int_24 / 2, int23);
                                graphicsPath.AddLine(int_24 - int_24 / 2, int23, int_24 / 4, int_23 + int23);
                                graphicsPath.AddLine(int_24 / 4, int_23 + int23, -int_24 / 4, int_23 + int23);
                            }
                            else
                            {
                                graphicsPath.AddLine(int_23 + int23, -int_24 / 4, int23, -int_24 / 2);
                                graphicsPath.AddLine(int23, -int_24 / 2, int23, int_24 - int_24 / 2);
                                graphicsPath.AddLine(int23, int_24 - int_24 / 2, int_23 + int23, int_24 / 4);
                                graphicsPath.AddLine(int_23 + int23, int_24 / 4, int_23 + int23, -int_24 / 4);
                            }
                            graphicsPath.CloseFigure();
                            if (das_TickerShapeStyle_2 == DAS_TickerShapeStyle.Solid_Trapezoid)
                            {
                                graphics_0.FillPath(solidBrush, graphicsPath);
                            }
                            graphics_0.DrawPath(pen, graphicsPath);
                            pen.Dispose();
                            solidBrush.Dispose();
                            graphics_0.ResetTransform();
                            return;
                        }
                        else
                        {
                            pen.Dispose();
                            solidBrush.Dispose();
                            graphics_0.ResetTransform();
                            return;
                        }
                    }
                Label5:
                    GraphicsPath graphicsPath1 = new GraphicsPath();
                    int num = 0;
                    if (bool_7)
                    {
                        num = -int_23 / 2;
                    }
                    if (!bool_8)
                    {
                        graphicsPath1.AddLine(0, int_23 + num, -int_24 / 2, num);
                        graphicsPath1.AddLine(-int_24 / 2, num, int_24 - int_24 / 2, num);
                        graphicsPath1.AddLine(int_24 - int_24 / 2, num, 0, int_23 + num);
                    }
                    else
                    {
                        graphicsPath1.AddLine(int_23 + num, 0, num, -int_24 / 2);
                        graphicsPath1.AddLine(num, -int_24 / 2, num, int_24 - int_24 / 2);
                        graphicsPath1.AddLine(num, int_24 - int_24 / 2, int_23 + num, 0);
                    }
                    graphicsPath1.CloseFigure();
                    if (das_TickerShapeStyle_2 == DAS_TickerShapeStyle.Solid_Triangle)
                    {
                        graphics_0.FillPath(solidBrush, graphicsPath1);
                    }
                    graphics_0.DrawPath(pen, graphicsPath1);
                    pen.Dispose();
                    solidBrush.Dispose();
                    graphics_0.ResetTransform();
                    return;
                }
            Label4:
                Rectangle rectangle = new Rectangle(-Math.Abs(int_23) / 2, -int_24 / 2, Math.Abs(int_23), int_24);
                if (!bool_7)
                {
                    if (bool_8)
                    {
                        rectangle.Y = -int_24 / 2;
                        if (int_23 < 0)
                        {
                            rectangle.X = int_23;
                        }
                        else
                        {
                            rectangle.X = 0;
                        }
                        rectangle.Width = Math.Abs(int_23);
                        rectangle.Height = int_24;
                    }
                    else
                    {
                        rectangle.X = -int_24 / 2;
                        if (int_23 < 0)
                        {
                            rectangle.Y = int_23;
                        }
                        else
                        {
                            rectangle.Y = 0;
                        }
                        rectangle.Width = int_24;
                        rectangle.Height = Math.Abs(int_23);
                    }
                }
                else if (!bool_8)
                {
                    rectangle.X = -int_24 / 2;
                    rectangle.Y = -Math.Abs(int_23) / 2;
                    rectangle.Width = int_24;
                    rectangle.Height = Math.Abs(int_23);
                }
                if (das_TickerShapeStyle_2 != DAS_TickerShapeStyle.Rectangle)
                {
                    if (das_TickerShapeStyle_2 == DAS_TickerShapeStyle.Solid_Rectangle)
                    {
                        goto Label6;
                    }
                    if (das_TickerShapeStyle_2 == DAS_TickerShapeStyle.Solid_Circle)
                    {
                        graphics_0.FillEllipse(solidBrush, rectangle);
                    }
                    graphics_0.DrawEllipse(pen, rectangle);
                    pen.Dispose();
                    solidBrush.Dispose();
                    graphics_0.ResetTransform();
                    return;
                }
            Label6:
                if (das_TickerShapeStyle_2 == DAS_TickerShapeStyle.Solid_Rectangle)
                {
                    graphics_0.FillRectangle(solidBrush, rectangle);
                }
                graphics_0.DrawRectangle(pen, rectangle);
            }
            else if (!bool_7)
            {
                if (!bool_8)
                {
                    graphics_0.DrawLine(pen, 0, 0, 0, int_23);
                }
                else
                {
                    graphics_0.DrawLine(pen, 0, 0, int_23, 0);
                }
            }
            else if (!bool_8)
            {
                graphics_0.DrawLine(pen, 0, -int_23 / 2, 0, int_23 - int_23 / 2);
            }
            else
            {
                graphics_0.DrawLine(pen, -int_23 / 2, 0, int_23 - int_23 / 2, 0);
            }
            pen.Dispose();
            solidBrush.Dispose();
            graphics_0.ResetTransform();
        }

        private void method_11(Graphics graphics_0, Rectangle rectangle_0, GraphicsPath graphicsPath_0, Color color_18, Color color_19, float float_11)
        {
            PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath_0);
            Blend blend = new Blend()
            {
                Factors = new float[3],
                Positions = new float[3]
            };
            blend.Factors[0] = 0f;
            blend.Positions[0] = 0f;
            blend.Factors[2] = 1f;
            blend.Positions[2] = 1f;
            blend.Factors[1] = float_11;
            blend.Positions[1] = 1f - float_11;
            pathGradientBrush.SurroundColors = new Color[] { color_18 };
            pathGradientBrush.Blend = blend;
            pathGradientBrush.CenterColor = color_19;
            PointF pointF = new PointF()
            {
                X = 2f / (float)rectangle_0.Width,
                Y = ((float)rectangle_0.Height - 2f) / (float)rectangle_0.Height
            };
            pathGradientBrush.FocusScales = pointF;
            graphics_0.FillPath(pathGradientBrush, graphicsPath_0);
            pathGradientBrush.Dispose();
        }

        private void method_12(Graphics graphics_0, GraphicsPath graphicsPath_0, bool bool_7)
        {
            Color color;
            Color color1;
            if (!bool_7)
            {
                Color.FromKnownColor(KnownColor.ControlDark);
                color = Color.FromKnownColor(KnownColor.ControlDarkDark);
                color1 = Color.FromKnownColor(KnownColor.ControlLightLight);
                Color.FromKnownColor(KnownColor.ControlLight);
            }
            else
            {
                Color.FromKnownColor(KnownColor.ControlLight);
                color = Color.FromKnownColor(KnownColor.ControlLightLight);
                color1 = Color.FromKnownColor(KnownColor.ControlDarkDark);
                Color.FromKnownColor(KnownColor.ControlDark);
            }
            System.Drawing.Region region = new System.Drawing.Region(graphicsPath_0);
            region.Translate(-1, -1);
            region.Xor(graphicsPath_0);
            System.Drawing.Region region1 = new System.Drawing.Region(graphicsPath_0);
            region1.Translate(-1, -1);
            region.Intersect(region1);
            SolidBrush solidBrush = new SolidBrush(color);
            graphics_0.FillRegion(solidBrush, region);
            solidBrush.Dispose();
            region.Dispose();
            region1.Dispose();
            region = new System.Drawing.Region(graphicsPath_0);
            region.Translate(1, 1);
            region.Xor(graphicsPath_0);
            region1 = new System.Drawing.Region(graphicsPath_0);
            region1.Translate(1, 1);
            region.Intersect(region1);
            solidBrush = new SolidBrush(color1);
            graphics_0.FillRegion(solidBrush, region);
            solidBrush.Dispose();
            region.Dispose();
            region1.Dispose();
        }

        private void method_13()
        {
            this.icontainer_0 = new System.ComponentModel.Container();
        }

        private void method_2(Graphics graphics_0, Rectangle rectangle_0, int int_23, int int_24)
        {
            if (this.bool_2 && this.int_7 > 0 && this.int_7 < rectangle_0.Width / 3 && this.int_7 < rectangle_0.Height / 3 && this.das_BorderGradientStyle_0 == DAS_BorderGradientStyle.BGS_None)
            {
                rectangle_0.X = rectangle_0.X + this.int_7;
                rectangle_0.Y = rectangle_0.Y + this.int_7;
                GraphicsPath graphicsPath = new GraphicsPath();
                this.method_8(graphicsPath, rectangle_0, this.das_ProgressLevelShape_0, this.int_11, this.size_0);
                rectangle_0.X = rectangle_0.X - this.int_7;
                rectangle_0.Y = rectangle_0.Y - this.int_7;
                GraphicsPath graphicsPath1 = new GraphicsPath();
                this.method_8(graphicsPath1, rectangle_0, this.das_ProgressLevelShape_0, this.int_11, this.size_0);
                System.Drawing.Region region = new System.Drawing.Region(graphicsPath);
                System.Drawing.Region region1 = new System.Drawing.Region(graphicsPath);
                region1.Intersect(graphicsPath1);
                region.Xor(region1);
                graphics_0.SetClip(region, CombineMode.Replace);
                this._DrawGraphics.method_4(graphics_0, rectangle_0, graphicsPath1, this.color_7, this.int_7, this.float_7);
                graphics_0.ResetClip();
                region1.Dispose();
                region.Dispose();
                graphicsPath1.Dispose();
                graphicsPath.Dispose();
            }
            GraphicsPath graphicsPath2 = new GraphicsPath();
            this.method_8(graphicsPath2, rectangle_0, this.das_ProgressLevelShape_0, this.int_11, this.size_0);
            int float9 = 255;
            if ((double)this.float_9 > 0)
            {
                float9 = 255 - (int)(255f * this.float_9);
            }
            Color color = Color.FromArgb(float9, this.color_10);
            Color color1 = Color.FromArgb(float9, this.color_9);
            Color color2 = Color.FromArgb(float9, this.color_11);
            Pen pen = new Pen(Color.FromArgb(float9, this.color_8));
            System.Drawing.Size size0 = this.size_0;
            if (size0.Width > 2 * this.int_12)
            {
                size0.Width = this.size_0.Width - 2 * this.int_12;
            }
            size0.Height = this.size_0.Height + this.int_12;
            GraphicsPath graphicsPath3 = new GraphicsPath();
            if (this.int_12 <= 0)
            {
                this.method_8(graphicsPath3, rectangle_0, this.das_ProgressLevelShape_0, this.int_11, this.size_0);
                if (!this.bool_4)
                {
                    SolidBrush solidBrush = new SolidBrush(color);
                    graphics_0.FillPath(solidBrush, graphicsPath2);
                    solidBrush.Dispose();
                }
                else
                {
                    this.method_11(graphics_0, rectangle_0, graphicsPath2, color, color2, this.float_8);
                }
            }
            else
            {
                Rectangle rectangle = new Rectangle(rectangle_0.Left + this.int_12 + 1, rectangle_0.Top, rectangle_0.Width - 2 * this.int_12 - 2, rectangle_0.Height - this.int_12 - 1);
                if (this.size_0.Height > 0 && (this.das_ProgressLevelShape_0 == DAS_ProgressLevelShape.PLS_Tank2 || this.das_ProgressLevelShape_0 == DAS_ProgressLevelShape.PLS_Tank4 || this.das_ProgressLevelShape_0 == DAS_ProgressLevelShape.PLS_Tank6))
                {
                    rectangle.Y = rectangle_0.Top + this.int_12;
                }
                this.method_8(graphicsPath3, rectangle, this.das_ProgressLevelShape_0, this.int_11, size0);
                graphics_0.SetClip(graphicsPath3, CombineMode.Exclude);
                SolidBrush solidBrush1 = new SolidBrush(color1);
                graphics_0.FillPath(solidBrush1, graphicsPath2);
                solidBrush1.Dispose();
                graphics_0.ResetClip();
                graphicsPath3.Reset();
                rectangle.X = rectangle.X - 1;
                rectangle.Width = rectangle.Width + 2;
                rectangle.Height = rectangle.Height + 1;
                this.method_8(graphicsPath3, rectangle, this.das_ProgressLevelShape_0, this.int_11, size0);
                if (!this.bool_4)
                {
                    SolidBrush solidBrush2 = new SolidBrush(color);
                    graphics_0.FillPath(solidBrush2, graphicsPath3);
                    solidBrush2.Dispose();
                }
                else
                {
                    this.method_11(graphics_0, rectangle, graphicsPath3, color, color2, this.float_8);
                }
            }
            float9 = 255;
            if ((double)this.float_10 > 0)
            {
                float9 = 255 - (int)(255f * this.float_10);
            }
            Color color3 = Color.FromArgb(float9, this.color_12);
            Color color4 = Color.FromArgb(float9, this.color_13);
            Rectangle bottom = new Rectangle(rectangle_0.Left + this.int_12 + 1, int_23, rectangle_0.Width - 2 * this.int_12 - 2, rectangle_0.Bottom - int_23 - this.int_12 - 1);
            if (this.size_0.Height > 0 && (this.das_ProgressLevelShape_0 == DAS_ProgressLevelShape.PLS_Tank2 || this.das_ProgressLevelShape_0 == DAS_ProgressLevelShape.PLS_Tank4 || this.das_ProgressLevelShape_0 == DAS_ProgressLevelShape.PLS_Tank6))
            {
                bottom.Height = rectangle_0.Bottom - int_23 - 1;
            }
            GraphicsPath graphicsPath4 = new GraphicsPath();
            graphicsPath4.AddRectangle(bottom);
            graphics_0.SetClip(graphicsPath4);
            if (!this.bool_5)
            {
                SolidBrush solidBrush3 = new SolidBrush(color3);
                graphics_0.FillPath(solidBrush3, graphicsPath3);
                solidBrush3.Dispose();
            }
            else
            {
                this.method_11(graphics_0, rectangle_0, graphicsPath3, color3, color4, this.float_8);
            }
            graphicsPath4.Dispose();
            graphics_0.ResetClip();
            graphicsPath3.Dispose();
            graphics_0.DrawPath(pen, graphicsPath2);
            pen.Dispose();
            graphicsPath2.Dispose();
        }

        private void method_3(Graphics graphics_0, Rectangle rectangle_0, int int_23, int int_24, int int_25)
        {
            if (this.bool_2 && this.int_7 > 0 && this.int_7 < rectangle_0.Width / 3 && this.int_7 < rectangle_0.Height / 3 && this.das_BorderGradientStyle_0 == DAS_BorderGradientStyle.BGS_None)
            {
                rectangle_0.X = rectangle_0.X + this.int_7;
                rectangle_0.Y = rectangle_0.Y + this.int_7;
                GraphicsPath graphicsPath = new GraphicsPath();
                this.method_9(graphicsPath, rectangle_0, this.das_ProgressLevelShape_0, this.int_11, false, int_24, int_25);
                rectangle_0.X = rectangle_0.X - this.int_7;
                rectangle_0.Y = rectangle_0.Y - this.int_7;
                GraphicsPath graphicsPath1 = new GraphicsPath();
                this.method_9(graphicsPath1, rectangle_0, this.das_ProgressLevelShape_0, this.int_11, false, int_24, int_25);
                System.Drawing.Region region = new System.Drawing.Region(graphicsPath);
                System.Drawing.Region region1 = new System.Drawing.Region(graphicsPath);
                region1.Intersect(graphicsPath1);
                region.Xor(region1);
                graphics_0.SetClip(region, CombineMode.Replace);
                this._DrawGraphics.method_4(graphics_0, rectangle_0, graphicsPath1, this.color_7, this.int_7, this.float_7);
                graphics_0.ResetClip();
                region1.Dispose();
                region.Dispose();
                graphicsPath1.Dispose();
                graphicsPath.Dispose();
            }
            GraphicsPath graphicsPath2 = new GraphicsPath();
            this.method_9(graphicsPath2, rectangle_0, this.das_ProgressLevelShape_0, this.int_11, false, int_24, int_25);
            int float9 = 255;
            if ((double)this.float_9 > 0)
            {
                float9 = 255 - (int)(255f * this.float_9);
            }
            Color color = Color.FromArgb(float9, this.color_10);
            Color color1 = Color.FromArgb(float9, this.color_9);
            Color color2 = Color.FromArgb(float9, this.color_11);
            Pen pen = new Pen(Color.FromArgb(float9, this.color_8));
            GraphicsPath graphicsPath3 = new GraphicsPath();
            if (this.int_12 <= 0 || this.das_ProgressLevelShape_0 != DAS_ProgressLevelShape.PLS_Boiler)
            {
                this.method_9(graphicsPath3, rectangle_0, this.das_ProgressLevelShape_0, this.int_11, false, int_24, int_25);
                if (!this.bool_4)
                {
                    SolidBrush solidBrush = new SolidBrush(color);
                    graphics_0.FillPath(solidBrush, graphicsPath2);
                    solidBrush.Dispose();
                }
                else
                {
                    this.method_11(graphics_0, rectangle_0, graphicsPath2, color, color2, this.float_8);
                }
            }
            else
            {
                Rectangle rectangle = new Rectangle(rectangle_0.Left + this.int_12 + 1, rectangle_0.Top + this.int_12, rectangle_0.Width - 2 * this.int_12 - 2, rectangle_0.Height - 2 * this.int_12 - 1);
                if (this.int_11 <= this.int_12 + 3)
                {
                    this.method_9(graphicsPath3, rectangle, this.das_ProgressLevelShape_0, this.int_11, false, int_24, int_25);
                }
                else
                {
                    this.method_9(graphicsPath3, rectangle, this.das_ProgressLevelShape_0, this.int_11 - this.int_12, false, int_24, int_25);
                }
                graphics_0.SetClip(graphicsPath3, CombineMode.Exclude);
                SolidBrush solidBrush1 = new SolidBrush(color1);
                graphics_0.FillPath(solidBrush1, graphicsPath2);
                solidBrush1.Dispose();
                graphics_0.ResetClip();
                graphicsPath3.Reset();
                rectangle.X = rectangle.X - 1;
                rectangle.Width = rectangle.Width + 2;
                rectangle.Height = rectangle.Height + 1;
                if (this.int_11 <= this.int_12 + 3)
                {
                    this.method_9(graphicsPath3, rectangle, this.das_ProgressLevelShape_0, this.int_11, false, int_24, int_25);
                }
                else
                {
                    this.method_9(graphicsPath3, rectangle, this.das_ProgressLevelShape_0, this.int_11 - this.int_12, false, int_24, int_25);
                }
                if (!this.bool_4)
                {
                    SolidBrush solidBrush2 = new SolidBrush(color);
                    graphics_0.FillPath(solidBrush2, graphicsPath3);
                    solidBrush2.Dispose();
                }
                else
                {
                    this.method_11(graphics_0, rectangle, graphicsPath3, color, color2, this.float_8);
                }
            }
            float9 = 255;
            if ((double)this.float_10 > 0)
            {
                float9 = 255 - (int)(255f * this.float_10);
            }
            Color color3 = Color.FromArgb(float9, this.color_12);
            Color color4 = Color.FromArgb(float9, this.color_13);
            if (this.das_ProgressLevelShape_0 == DAS_ProgressLevelShape.PLS_Boiler)
            {
                Rectangle rectangle1 = new Rectangle(rectangle_0.Left + this.int_12 + 1, int_23, rectangle_0.Width - 2 * this.int_12 - 2, rectangle_0.Bottom - int_23 - this.int_12 - 1);
                GraphicsPath graphicsPath4 = new GraphicsPath();
                graphicsPath4.AddRectangle(rectangle1);
                graphics_0.SetClip(graphicsPath4);
                if (!this.bool_5)
                {
                    SolidBrush solidBrush3 = new SolidBrush(color3);
                    graphics_0.FillPath(solidBrush3, graphicsPath3);
                    solidBrush3.Dispose();
                }
                else
                {
                    this.method_11(graphics_0, rectangle_0, graphicsPath3, color3, color4, this.float_8);
                }
                graphicsPath4.Dispose();
                graphics_0.ResetClip();
            }
            else if (this.das_ProgressLevelShape_0 == DAS_ProgressLevelShape.PLS_Boiler2)
            {
                GraphicsPath graphicsPath5 = new GraphicsPath();
                this.method_9(graphicsPath5, rectangle_0, this.das_ProgressLevelShape_0, this.int_11, true, int_24, int_25);
                HatchBrush hatchBrush = new HatchBrush(HatchStyle.BackwardDiagonal, this.color_10, Color.FromArgb(255, this.color_10.R / 2, this.color_10.G / 2, this.color_10.B / 2));
                graphics_0.FillPath(hatchBrush, graphicsPath5);
                hatchBrush.Dispose();
                graphics_0.SetClip(graphicsPath5);
                Rectangle rectangle2 = new Rectangle(rectangle_0.Left + this.int_12 + 1, int_23, rectangle_0.Width - 2 * this.int_12 - 2, rectangle_0.Bottom - int_23 - this.int_12 - 1);
                GraphicsPath graphicsPath6 = new GraphicsPath();
                graphicsPath6.AddRectangle(rectangle2);
                if (!this.bool_5)
                {
                    SolidBrush solidBrush4 = new SolidBrush(color3);
                    graphics_0.FillRectangle(solidBrush4, rectangle2);
                    solidBrush4.Dispose();
                }
                else
                {
                    this.method_11(graphics_0, rectangle2, graphicsPath6, color3, color4, this.float_8);
                }
                graphicsPath6.Dispose();
                graphics_0.ResetClip();
                this.method_12(graphics_0, graphicsPath5, false);
                graphicsPath5.Dispose();
            }
            graphicsPath3.Dispose();
            graphics_0.DrawPath(pen, graphicsPath2);
            pen.Dispose();
            graphicsPath2.Dispose();
        }

        private void method_4(Graphics graphics_0, Rectangle rectangle_0, int int_23, int int_24)
        {
            if (this.bool_2 && this.int_7 > 0 && this.int_7 < rectangle_0.Width / 3 && this.int_7 < rectangle_0.Height / 3 && this.das_BorderGradientStyle_0 == DAS_BorderGradientStyle.BGS_None)
            {
                rectangle_0.X = rectangle_0.X + this.int_7;
                rectangle_0.Y = rectangle_0.Y + this.int_7;
                GraphicsPath graphicsPath = new GraphicsPath();
                this.method_6(graphicsPath, rectangle_0, this.das_ProgressLevelShape_0, int_24);
                rectangle_0.X = rectangle_0.X - this.int_7;
                rectangle_0.Y = rectangle_0.Y - this.int_7;
                GraphicsPath graphicsPath1 = new GraphicsPath();
                this.method_6(graphicsPath1, rectangle_0, this.das_ProgressLevelShape_0, int_24);
                System.Drawing.Region region = new System.Drawing.Region(graphicsPath);
                System.Drawing.Region region1 = new System.Drawing.Region(graphicsPath);
                region1.Intersect(graphicsPath1);
                region.Xor(region1);
                graphics_0.SetClip(region, CombineMode.Replace);
                this._DrawGraphics.method_4(graphics_0, rectangle_0, graphicsPath1, this.color_7, this.int_7, this.float_7);
                graphics_0.ResetClip();
                region1.Dispose();
                region.Dispose();
                graphicsPath1.Dispose();
                graphicsPath.Dispose();
            }
            GraphicsPath graphicsPath2 = new GraphicsPath();
            this.method_6(graphicsPath2, rectangle_0, this.das_ProgressLevelShape_0, int_24);
            int float9 = 255;
            if ((double)this.float_9 > 0)
            {
                float9 = 255 - (int)(255f * this.float_9);
            }
            Color color = Color.FromArgb(float9, this.color_10);
            Color.FromArgb(float9, this.color_9);
            Color color1 = Color.FromArgb(float9, this.color_11);
            Pen pen = new Pen(Color.FromArgb(float9, this.color_8));
            if (!this.bool_4)
            {
                SolidBrush solidBrush = new SolidBrush(color);
                graphics_0.FillPath(solidBrush, graphicsPath2);
                solidBrush.Dispose();
            }
            else
            {
                this._DrawGraphics.method_2(graphics_0, rectangle_0, DAS_BorderStyle.BS_Rect, graphicsPath2, color, color1, DAS_BkGradientStyle.BKGS_Linear2, 0, this.float_8, 0, 0f);
            }
            graphics_0.DrawPath(pen, graphicsPath2);
            graphicsPath2.Dispose();
            if (int_24 > 0)
            {
                Color color2 = Color.FromArgb(255, (this.color_10.R + 255) / 2, (this.color_10.G + 255) / 2, (this.color_10.B + 255) / 2);
                Rectangle rectangle = new Rectangle(rectangle_0.Left, rectangle_0.Top - int_24, rectangle_0.Width, 2 * int_24);
                if (this.bool_4)
                {
                    GraphicsPath graphicsPath3 = new GraphicsPath();
                    graphicsPath3.AddEllipse(rectangle);
                    this._DrawGraphics.method_2(graphics_0, rectangle, DAS_BorderStyle.BS_Rect, graphicsPath3, color2, this.color_11, DAS_BkGradientStyle.BKGS_Linear2, 0, this.float_8, 0, 0f);
                    graphicsPath3.Dispose();
                }
                else
                {
                    SolidBrush solidBrush1 = new SolidBrush(color2);
                    graphics_0.FillEllipse(solidBrush1, rectangle);
                    solidBrush1.Dispose();
                }
                graphics_0.DrawEllipse(pen, rectangle);
            }
            pen.Dispose();
            float9 = 255;
            if ((double)this.float_10 > 0)
            {
                float9 = 255 - (int)(255f * this.float_10);
            }
            Color color3 = Color.FromArgb(float9, this.color_12);
            Color color4 = Color.FromArgb(float9, this.color_13);
            Rectangle rectangle1 = new Rectangle(rectangle_0.Left + this.int_12 + 1, int_23, rectangle_0.Width - 2 * this.int_12 - 2, rectangle_0.Bottom - int_23 - this.int_12 - 1);
            GraphicsPath graphicsPath4 = new GraphicsPath();
            if (int_24 <= this.int_12 + 3)
            {
                this.method_6(graphicsPath4, rectangle1, this.das_ProgressLevelShape_0, int_24);
            }
            else
            {
                this.method_6(graphicsPath4, rectangle1, this.das_ProgressLevelShape_0, int_24 - this.int_12);
            }
            if (!this.bool_5)
            {
                SolidBrush solidBrush2 = new SolidBrush(color3);
                graphics_0.FillPath(solidBrush2, graphicsPath4);
                solidBrush2.Dispose();
            }
            else
            {
                this._DrawGraphics.method_2(graphics_0, rectangle1, DAS_BorderStyle.BS_Rect, graphicsPath4, color3, color4, DAS_BkGradientStyle.BKGS_Linear2, 0, this.float_8, 0, 0f);
            }
            graphicsPath4.Dispose();
            if (int_24 > 0)
            {
                Color color5 = Color.FromArgb(float9, (this.color_12.R + 255) / 2, (this.color_12.G + 255) / 2, (this.color_12.B + 255) / 2);
                Rectangle rectangle2 = new Rectangle(rectangle1.Left, rectangle1.Top - int_24 + this.int_12, rectangle1.Width, 2 * (int_24 - this.int_12));
                if (!this.bool_5)
                {
                    SolidBrush solidBrush3 = new SolidBrush(color5);
                    graphics_0.FillEllipse(solidBrush3, rectangle2);
                    solidBrush3.Dispose();
                    return;
                }
                Color color6 = Color.FromArgb(float9, (this.color_13.R + 255) / 2, (this.color_13.G + 255) / 2, (this.color_13.B + 255) / 2);
                GraphicsPath graphicsPath5 = new GraphicsPath();
                graphicsPath5.AddEllipse(rectangle2);
                this._DrawGraphics.method_2(graphics_0, rectangle2, DAS_BorderStyle.BS_Rect, graphicsPath5, color5, color6, DAS_BkGradientStyle.BKGS_Linear2, 0, this.float_8, 0, 0f);
                graphicsPath5.Dispose();
            }
        }

        private void method_5(GraphicsPath graphicsPath_0, Rectangle rectangle_0, DAS_ProgressLevelShape das_ProgressLevelShape_1, int int_23, int int_24)
        {
            if (das_ProgressLevelShape_1 == DAS_ProgressLevelShape.PLS_Tube)
            {
                graphicsPath_0.AddLine(rectangle_0.Left, rectangle_0.Top, rectangle_0.Right, rectangle_0.Top);
                graphicsPath_0.AddLine(rectangle_0.Right, rectangle_0.Top, rectangle_0.Right, rectangle_0.Bottom - int_23);
                graphicsPath_0.AddArc(rectangle_0.Left, rectangle_0.Bottom - 2 * int_23, rectangle_0.Width, 2 * int_23, 0f, 180f);
                graphicsPath_0.AddLine(rectangle_0.Left, rectangle_0.Bottom - int_23, rectangle_0.Left, rectangle_0.Top);
                return;
            }
            if (das_ProgressLevelShape_1 != DAS_ProgressLevelShape.PLS_Tube2)
            {
                if (das_ProgressLevelShape_1 == DAS_ProgressLevelShape.PLS_Tube3)
                {
                    if (int_24 <= 0)
                    {
                        graphicsPath_0.AddLine(rectangle_0.Left, rectangle_0.Top, rectangle_0.Right, rectangle_0.Top);
                    }
                    else
                    {
                        graphicsPath_0.AddArc(rectangle_0.Left, rectangle_0.Top - int_24, rectangle_0.Width, 2 * int_24, 180f, -180f);
                    }
                    graphicsPath_0.AddLine(rectangle_0.Right, rectangle_0.Top, rectangle_0.Right, rectangle_0.Bottom - int_23);
                    graphicsPath_0.AddArc(rectangle_0.Left, rectangle_0.Bottom - 2 * int_23, rectangle_0.Width, 2 * int_23, 0f, 180f);
                    graphicsPath_0.AddLine(rectangle_0.Left, rectangle_0.Bottom - int_23, rectangle_0.Left, rectangle_0.Top);
                }
                return;
            }
            graphicsPath_0.AddLine(rectangle_0.Left, rectangle_0.Top, rectangle_0.Right, rectangle_0.Top);
            graphicsPath_0.AddLine(rectangle_0.Right, rectangle_0.Top, rectangle_0.Right - 5, rectangle_0.Top + 5);
            graphicsPath_0.AddLine(rectangle_0.Right - 5, rectangle_0.Top + 5, rectangle_0.Right - 5, rectangle_0.Bottom - int_23);
            graphicsPath_0.AddArc(rectangle_0.Left + 5, rectangle_0.Bottom - 2 * int_23, rectangle_0.Width - 10, 2 * int_23, 0f, 180f);
            graphicsPath_0.AddLine(rectangle_0.Left + 5, rectangle_0.Bottom - int_23, rectangle_0.Left + 5, rectangle_0.Top + 5);
            graphicsPath_0.AddLine(rectangle_0.Left + 5, rectangle_0.Top + 5, rectangle_0.Left, rectangle_0.Top);
        }

        private void method_6(GraphicsPath graphicsPath_0, Rectangle rectangle_0, DAS_ProgressLevelShape das_ProgressLevelShape_1, int int_23)
        {
            if (das_ProgressLevelShape_1 == DAS_ProgressLevelShape.PLS_Cyclinder)
            {
                if (int_23 <= 0)
                {
                    graphicsPath_0.AddLine(rectangle_0.Left, rectangle_0.Top, rectangle_0.Right, rectangle_0.Top);
                }
                else
                {
                    graphicsPath_0.AddArc(rectangle_0.Left, rectangle_0.Top - int_23, rectangle_0.Width, 2 * int_23, 180f, -180f);
                }
                graphicsPath_0.AddLine(rectangle_0.Right, rectangle_0.Top, rectangle_0.Right, rectangle_0.Bottom - int_23);
                if (int_23 <= 0)
                {
                    graphicsPath_0.AddLine(rectangle_0.Right, rectangle_0.Bottom, rectangle_0.Left, rectangle_0.Bottom);
                }
                else
                {
                    graphicsPath_0.AddArc(rectangle_0.Left, rectangle_0.Bottom - 2 * int_23, rectangle_0.Width, 2 * int_23, 0f, 180f);
                }
                graphicsPath_0.AddLine(rectangle_0.Left, rectangle_0.Bottom - int_23, rectangle_0.Left, rectangle_0.Top);
            }
        }

        private void method_7(GraphicsPath graphicsPath_0, Rectangle rectangle_0, DAS_ProgressLevelShape das_ProgressLevelShape_1, int int_23, System.Drawing.Size size_1, int int_24, bool bool_7)
        {
            if (rectangle_0.Height <= size_1.Height)
            {
                return;
            }
            int left = (rectangle_0.Left + rectangle_0.Right) / 2;
            int bottom = rectangle_0.Bottom - size_1.Height;
            if (size_1.Width <= 0)
            {
                size_1.Width = 2;
            }
            if (size_1.Height <= 0)
            {
                size_1.Height = 1;
            }
            int width = size_1.Width;
            if (int_24 < rectangle_0.Bottom - size_1.Height && size_1.Width < rectangle_0.Width)
            {
                width = (int)((float)size_1.Width + (float)(rectangle_0.Bottom - size_1.Height - int_24) * (float)(rectangle_0.Width - size_1.Width) / (float)(rectangle_0.Height - size_1.Height));
            }
            if (das_ProgressLevelShape_1 == DAS_ProgressLevelShape.PLS_Funnel)
            {
                if (!bool_7)
                {
                    graphicsPath_0.AddLine(rectangle_0.Left, rectangle_0.Top, rectangle_0.Right, rectangle_0.Top);
                    graphicsPath_0.AddLine(rectangle_0.Right, rectangle_0.Top, left + size_1.Width / 2, bottom);
                    graphicsPath_0.AddLine(left + size_1.Width / 2, bottom, left + size_1.Width / 2, rectangle_0.Bottom);
                    graphicsPath_0.AddLine(left + size_1.Width / 2, rectangle_0.Bottom, left - size_1.Width / 2, rectangle_0.Bottom);
                    graphicsPath_0.AddLine(left - size_1.Width / 2, rectangle_0.Bottom, left - size_1.Width / 2, bottom);
                    graphicsPath_0.AddLine(left - size_1.Width / 2, bottom, rectangle_0.Left, rectangle_0.Top);
                    return;
                }
                if (int_24 >= rectangle_0.Bottom - size_1.Height)
                {
                    graphicsPath_0.AddLine(left - size_1.Width / 2, int_24, left + size_1.Width / 2, int_24);
                    graphicsPath_0.AddLine(left + size_1.Width / 2, int_24, left + size_1.Width / 2, rectangle_0.Bottom);
                    graphicsPath_0.AddLine(left + size_1.Width / 2, rectangle_0.Bottom, left - size_1.Width / 2, rectangle_0.Bottom);
                    graphicsPath_0.AddLine(left - size_1.Width / 2, rectangle_0.Bottom, left - size_1.Width / 2, int_24);
                    return;
                }
                graphicsPath_0.AddLine(left - width / 2, int_24, left + width / 2, int_24);
                graphicsPath_0.AddLine(left + width / 2, int_24, left + size_1.Width / 2, bottom);
                graphicsPath_0.AddLine(left + size_1.Width / 2, bottom, left + size_1.Width / 2, rectangle_0.Bottom);
                graphicsPath_0.AddLine(left + size_1.Width / 2, rectangle_0.Bottom, left - size_1.Width / 2, rectangle_0.Bottom);
                graphicsPath_0.AddLine(left - size_1.Width / 2, rectangle_0.Bottom, left - size_1.Width / 2, bottom);
                graphicsPath_0.AddLine(left - size_1.Width / 2, bottom, left - width / 2, int_24);
                return;
            }
            if (das_ProgressLevelShape_1 == DAS_ProgressLevelShape.PLS_Funnel2)
            {
                int int23 = int_23 * size_1.Width / rectangle_0.Width;
                if (int23 < 2)
                {
                    int23 = 2;
                }
                if (!bool_7)
                {
                    if (int_23 <= 0)
                    {
                        graphicsPath_0.AddLine(rectangle_0.Left, rectangle_0.Top, rectangle_0.Right, rectangle_0.Top);
                    }
                    else
                    {
                        graphicsPath_0.AddArc(rectangle_0.Left, rectangle_0.Top - int_23, rectangle_0.Width, 2 * int_23, 180f, -180f);
                    }
                    graphicsPath_0.AddLine(rectangle_0.Right, rectangle_0.Top, left + size_1.Width / 2, bottom);
                    graphicsPath_0.AddLine(left + size_1.Width / 2, bottom, left + size_1.Width / 2, rectangle_0.Bottom - int23);
                    graphicsPath_0.AddArc(left - size_1.Width / 2, rectangle_0.Bottom - 2 * int23, size_1.Width / 2 + size_1.Width / 2, 2 * int23, 0f, 180f);
                    graphicsPath_0.AddLine(left - size_1.Width / 2, rectangle_0.Bottom - int23, left - size_1.Width / 2, bottom);
                    graphicsPath_0.AddLine(left - size_1.Width / 2, bottom, rectangle_0.Left, rectangle_0.Top);
                    return;
                }
                if (int_24 < rectangle_0.Bottom - size_1.Height)
                {
                    int num = int_23 * width / rectangle_0.Width;
                    if (num < 0)
                    {
                        num = 0;
                    }
                    if (num <= 0)
                    {
                        graphicsPath_0.AddLine(left - width / 2, int_24, left + width / 2, int_24);
                    }
                    else
                    {
                        graphicsPath_0.AddArc(left - width / 2, int_24 - num, width / 2 + width / 2, 2 * num, 180f, -180f);
                    }
                    graphicsPath_0.AddLine(left + width / 2, int_24, left + size_1.Width / 2, bottom);
                    graphicsPath_0.AddLine(left + size_1.Width / 2, bottom, left + size_1.Width / 2, rectangle_0.Bottom - int23);
                    graphicsPath_0.AddArc(left - size_1.Width / 2, rectangle_0.Bottom - 2 * int23, size_1.Width / 2 + size_1.Width / 2, 2 * int23, 0f, 180f);
                    graphicsPath_0.AddLine(left - size_1.Width / 2, rectangle_0.Bottom - int23, left - size_1.Width / 2, bottom);
                    graphicsPath_0.AddLine(left - size_1.Width / 2, bottom, left - width / 2, int_24);
                    return;
                }
                if (int23 <= 0)
                {
                    graphicsPath_0.AddLine(left - size_1.Width / 2, int_24, left + size_1.Width / 2, int_24);
                }
                else
                {
                    graphicsPath_0.AddArc(left - size_1.Width / 2, int_24 - int23, size_1.Width / 2 + size_1.Width / 2, 2 * int23, 180f, -180f);
                }
                graphicsPath_0.AddLine(left + size_1.Width / 2, int_24, left + size_1.Width / 2, rectangle_0.Bottom - int23);
                graphicsPath_0.AddArc(left - size_1.Width / 2, rectangle_0.Bottom - 2 * int23, size_1.Width / 2 + size_1.Width / 2, 2 * int23, 0f, 180f);
                graphicsPath_0.AddLine(left - size_1.Width / 2, rectangle_0.Bottom - int23, left - size_1.Width / 2, int_24);
            }
        }

        private void method_8(GraphicsPath graphicsPath_0, Rectangle rectangle_0, DAS_ProgressLevelShape das_ProgressLevelShape_1, int int_23, System.Drawing.Size size_1)
        {
            if (rectangle_0.Height <= size_1.Height || rectangle_0.Width < size_1.Width || rectangle_0.Height < int_23 || rectangle_0.Height < int_23 + size_1.Height)
            {
                return;
            }
            int left = (rectangle_0.Left + rectangle_0.Right) / 2;
            if (size_1.Width <= 0)
            {
                size_1.Width = 0;
            }
            if (size_1.Height <= 0)
            {
                size_1.Height = 0;
            }
            if (int_23 <= 0)
            {
                int_23 = 0;
            }
            if (das_ProgressLevelShape_1 == DAS_ProgressLevelShape.PLS_Tank)
            {
                graphicsPath_0.AddLine(left - size_1.Width / 2, rectangle_0.Top, left + size_1.Width / 2, rectangle_0.Top);
                graphicsPath_0.AddLine(left + size_1.Width / 2, rectangle_0.Top, left + size_1.Width / 2, rectangle_0.Top + size_1.Height);
                graphicsPath_0.AddLine(left + size_1.Width / 2, rectangle_0.Top + size_1.Height, rectangle_0.Right, rectangle_0.Top + size_1.Height + int_23);
                graphicsPath_0.AddLine(rectangle_0.Right, rectangle_0.Top + size_1.Height + int_23, rectangle_0.Right, rectangle_0.Bottom);
                graphicsPath_0.AddLine(rectangle_0.Right, rectangle_0.Bottom, rectangle_0.Left, rectangle_0.Bottom);
                graphicsPath_0.AddLine(rectangle_0.Left, rectangle_0.Bottom, rectangle_0.Left, rectangle_0.Top + size_1.Height + int_23);
                graphicsPath_0.AddLine(rectangle_0.Left, rectangle_0.Top + size_1.Height + int_23, left - size_1.Width / 2, rectangle_0.Top + size_1.Height);
                graphicsPath_0.AddLine(left - size_1.Width / 2, rectangle_0.Top + size_1.Height, left - size_1.Width / 2, rectangle_0.Top);
                return;
            }
            if (das_ProgressLevelShape_1 == DAS_ProgressLevelShape.PLS_Tank2)
            {
                graphicsPath_0.AddLine(left - size_1.Width / 2, rectangle_0.Bottom, left + size_1.Width / 2, rectangle_0.Bottom);
                graphicsPath_0.AddLine(left + size_1.Width / 2, rectangle_0.Bottom, left + size_1.Width / 2, rectangle_0.Bottom - size_1.Height);
                graphicsPath_0.AddLine(left + size_1.Width / 2, rectangle_0.Bottom - size_1.Height, rectangle_0.Right, rectangle_0.Bottom - size_1.Height - int_23);
                graphicsPath_0.AddLine(rectangle_0.Right, rectangle_0.Bottom - size_1.Height - int_23, rectangle_0.Right, rectangle_0.Top);
                graphicsPath_0.AddLine(rectangle_0.Right, rectangle_0.Top, rectangle_0.Left, rectangle_0.Top);
                graphicsPath_0.AddLine(rectangle_0.Left, rectangle_0.Top, rectangle_0.Left, rectangle_0.Bottom - size_1.Height - int_23);
                graphicsPath_0.AddLine(rectangle_0.Left, rectangle_0.Bottom - size_1.Height - int_23, left - size_1.Width / 2, rectangle_0.Bottom - size_1.Height);
                graphicsPath_0.AddLine(left - size_1.Width / 2, rectangle_0.Bottom - size_1.Height, left - size_1.Width / 2, rectangle_0.Bottom);
                return;
            }
            if (das_ProgressLevelShape_1 == DAS_ProgressLevelShape.PLS_Tank3)
            {
                graphicsPath_0.AddLine(left - size_1.Width / 2, rectangle_0.Top, left + size_1.Width / 2, rectangle_0.Top);
                graphicsPath_0.AddLine(left + size_1.Width / 2, rectangle_0.Top, left + size_1.Width / 2, rectangle_0.Top + size_1.Height);
                graphicsPath_0.AddLine(left + size_1.Width / 2, rectangle_0.Top + size_1.Height, rectangle_0.Right, rectangle_0.Top + size_1.Height);
                graphicsPath_0.AddLine(rectangle_0.Right, rectangle_0.Top + size_1.Height, rectangle_0.Right, rectangle_0.Bottom - int_23);
                if (int_23 != 0)
                {
                    graphicsPath_0.AddArc(rectangle_0.Left, rectangle_0.Bottom - 2 * int_23, rectangle_0.Width, 2 * int_23, 0f, 180f);
                }
                else
                {
                    graphicsPath_0.AddLine(rectangle_0.Right, rectangle_0.Bottom - int_23, rectangle_0.Left, rectangle_0.Bottom - int_23);
                }
                graphicsPath_0.AddLine(rectangle_0.Left, rectangle_0.Bottom - int_23, rectangle_0.Left, rectangle_0.Top + size_1.Height);
                graphicsPath_0.AddLine(rectangle_0.Left, rectangle_0.Top + size_1.Height, left - size_1.Width / 2, rectangle_0.Top + size_1.Height);
                graphicsPath_0.AddLine(left - size_1.Width / 2, rectangle_0.Top + size_1.Height, left - size_1.Width / 2, rectangle_0.Top);
                return;
            }
            if (das_ProgressLevelShape_1 == DAS_ProgressLevelShape.PLS_Tank4)
            {
                graphicsPath_0.AddLine(left - size_1.Width / 2, rectangle_0.Bottom, left + size_1.Width / 2, rectangle_0.Bottom);
                graphicsPath_0.AddLine(left + size_1.Width / 2, rectangle_0.Bottom, left + size_1.Width / 2, rectangle_0.Bottom - size_1.Height);
                graphicsPath_0.AddLine(left + size_1.Width / 2, rectangle_0.Bottom - size_1.Height, rectangle_0.Right, rectangle_0.Bottom - size_1.Height);
                graphicsPath_0.AddLine(rectangle_0.Right, rectangle_0.Bottom - size_1.Height, rectangle_0.Right, rectangle_0.Top + int_23);
                if (int_23 != 0)
                {
                    graphicsPath_0.AddArc(rectangle_0.Left, rectangle_0.Top, rectangle_0.Width, 2 * int_23, 0f, -180f);
                }
                else
                {
                    graphicsPath_0.AddLine(rectangle_0.Right, rectangle_0.Top + int_23, rectangle_0.Left, rectangle_0.Top + int_23);
                }
                graphicsPath_0.AddLine(rectangle_0.Left, rectangle_0.Top + int_23, rectangle_0.Left, rectangle_0.Bottom - size_1.Height);
                graphicsPath_0.AddLine(rectangle_0.Left, rectangle_0.Bottom - size_1.Height, left - size_1.Width / 2, rectangle_0.Bottom - size_1.Height);
                graphicsPath_0.AddLine(left - size_1.Width / 2, rectangle_0.Bottom - size_1.Height, left - size_1.Width / 2, rectangle_0.Bottom);
                return;
            }
            if (das_ProgressLevelShape_1 == DAS_ProgressLevelShape.PLS_Tank5)
            {
                graphicsPath_0.AddLine(left - size_1.Width / 2, rectangle_0.Top, left + size_1.Width / 2, rectangle_0.Top);
                graphicsPath_0.AddLine(left + size_1.Width / 2, rectangle_0.Top, left + size_1.Width / 2, rectangle_0.Top + size_1.Height);
                if (int_23 <= size_1.Width)
                {
                    graphicsPath_0.AddLine(left + size_1.Width / 2, rectangle_0.Top + size_1.Height, rectangle_0.Right, rectangle_0.Bottom);
                }
                else
                {
                    graphicsPath_0.AddLine(left + size_1.Width / 2, rectangle_0.Top + size_1.Height, left + int_23 / 2, rectangle_0.Top + size_1.Height);
                    graphicsPath_0.AddLine(left + int_23 / 2, rectangle_0.Top + size_1.Height, rectangle_0.Right, rectangle_0.Bottom);
                }
                graphicsPath_0.AddLine(rectangle_0.Right, rectangle_0.Bottom, rectangle_0.Left, rectangle_0.Bottom);
                if (int_23 <= size_1.Width)
                {
                    graphicsPath_0.AddLine(rectangle_0.Left, rectangle_0.Bottom, left - size_1.Width / 2, rectangle_0.Top + size_1.Height);
                }
                else
                {
                    graphicsPath_0.AddLine(rectangle_0.Left, rectangle_0.Bottom, left - int_23 / 2, rectangle_0.Top + size_1.Height);
                    graphicsPath_0.AddLine(left - int_23 / 2, rectangle_0.Top + size_1.Height, left - size_1.Width / 2, rectangle_0.Top + size_1.Height);
                }
                graphicsPath_0.AddLine(left - size_1.Width / 2, rectangle_0.Top + size_1.Height, left - size_1.Width / 2, rectangle_0.Top);
                return;
            }
            if (das_ProgressLevelShape_1 == DAS_ProgressLevelShape.PLS_Tank6)
            {
                graphicsPath_0.AddLine(left - size_1.Width / 2, rectangle_0.Bottom, left + size_1.Width / 2, rectangle_0.Bottom);
                graphicsPath_0.AddLine(left + size_1.Width / 2, rectangle_0.Bottom, left + size_1.Width / 2, rectangle_0.Bottom - size_1.Height);
                if (int_23 <= size_1.Width)
                {
                    graphicsPath_0.AddLine(left + size_1.Width / 2, rectangle_0.Bottom - size_1.Height, rectangle_0.Right, rectangle_0.Top);
                }
                else
                {
                    graphicsPath_0.AddLine(left + size_1.Width / 2, rectangle_0.Bottom - size_1.Height, left + int_23 / 2, rectangle_0.Bottom - size_1.Height);
                    graphicsPath_0.AddLine(left + int_23 / 2, rectangle_0.Bottom - size_1.Height, rectangle_0.Right, rectangle_0.Top);
                }
                graphicsPath_0.AddLine(rectangle_0.Right, rectangle_0.Top, rectangle_0.Left, rectangle_0.Top);
                if (int_23 <= size_1.Width)
                {
                    graphicsPath_0.AddLine(rectangle_0.Left, rectangle_0.Top, left - size_1.Width / 2, rectangle_0.Bottom - size_1.Height);
                }
                else
                {
                    graphicsPath_0.AddLine(rectangle_0.Left, rectangle_0.Top, left - int_23 / 2, rectangle_0.Bottom - size_1.Height);
                    graphicsPath_0.AddLine(left - int_23 / 2, rectangle_0.Bottom - size_1.Height, left - size_1.Width / 2, rectangle_0.Bottom - size_1.Height);
                }
                graphicsPath_0.AddLine(left - size_1.Width / 2, rectangle_0.Bottom - size_1.Height, left - size_1.Width / 2, rectangle_0.Bottom);
            }
        }

        private void method_9(GraphicsPath graphicsPath_0, Rectangle rectangle_0, DAS_ProgressLevelShape das_ProgressLevelShape_1, int int_23, bool bool_7, int int_24, int int_25)
        {
            if (2 * int_23 > rectangle_0.Height)
            {
                int_23 = rectangle_0.Height / 2;
            }
            if (das_ProgressLevelShape_1 == DAS_ProgressLevelShape.PLS_Boiler || !bool_7)
            {
                if (int_23 <= 0)
                {
                    graphicsPath_0.AddLine(rectangle_0.Left, rectangle_0.Top, rectangle_0.Right, rectangle_0.Top);
                }
                else
                {
                    graphicsPath_0.AddArc(rectangle_0.Left, rectangle_0.Top, rectangle_0.Width, 2 * int_23, 180f, 180f);
                }
                graphicsPath_0.AddLine(rectangle_0.Right, rectangle_0.Top + int_23, rectangle_0.Right, rectangle_0.Bottom - int_23);
                if (int_23 <= 0)
                {
                    graphicsPath_0.AddLine(rectangle_0.Right, rectangle_0.Bottom, rectangle_0.Left, rectangle_0.Bottom);
                }
                else
                {
                    graphicsPath_0.AddArc(rectangle_0.Left, rectangle_0.Bottom - 2 * int_23, rectangle_0.Width, 2 * int_23, 0f, 180f);
                }
                graphicsPath_0.AddLine(rectangle_0.Left, rectangle_0.Bottom - int_23, rectangle_0.Left, rectangle_0.Top + int_23);
                return;
            }
            if (das_ProgressLevelShape_1 == DAS_ProgressLevelShape.PLS_Boiler2 && bool_7)
            {
                int left = (rectangle_0.Left + rectangle_0.Right) / 2;
                int width = rectangle_0.Width / 16 + 1;
                int int25 = (int_25 - int_24) / 3;
                graphicsPath_0.AddLine(left + 5 * width, int_24, left - 3 * width, int_24);
                graphicsPath_0.AddLine(left - 3 * width, int_24, left - 5 * width, int_24 + int25);
                graphicsPath_0.AddLine(left - 5 * width, int_24 + int25, left - 3 * width, int_24 + 2 * int25);
                graphicsPath_0.AddLine(left - 3 * width, int_24 + 2 * int25, left - 5 * width, int_25);
                graphicsPath_0.AddLine(left - 5 * width, int_25, left + 3 * width, int_25);
                graphicsPath_0.AddLine(left + 3 * width, int_25, left + 5 * width, int_24 + 2 * int25);
                graphicsPath_0.AddLine(left + 5 * width, int_24 + 2 * int25, left + 3 * width, int_24 + int25);
                graphicsPath_0.AddLine(left + 3 * width, int_24 + int25, left + 5 * width, int_24);
            }
        }

        protected override void Dispose(bool bool_7)
        {
            if (bool_7 && this.icontainer_0 != null)
            {
                this.icontainer_0.Dispose();
            }
            base.Dispose(bool_7);
        }

        protected override void OnPaint(PaintEventArgs paintEventArgs_0)
        {
            int int11;
            Rectangle rectangle;
            int bottom;
            int double0;
            int i;
            try
            {
                base.OnPaint(paintEventArgs_0);
                if (this.das_BorderGradientStyle_0 == DAS_BorderGradientStyle.BGS_None || base.ClientRectangle.Width - 2 * (this.int_0 + this.int_1 + this.int_4 + this.int_2) > 0 && base.ClientRectangle.Height - 2 * (this.int_0 + this.int_1 + this.int_4 + this.int_2) > 0)
                {
                    DrawGraphics _DrawGraphics = new DrawGraphics();
                    int left = base.ClientRectangle.Left;
                    int top = base.ClientRectangle.Top;
                    Rectangle clientRectangle = base.ClientRectangle;
                    Rectangle clientRectangle1 = base.ClientRectangle;
                    Rectangle width = new Rectangle(left, top, clientRectangle.Width - 2, clientRectangle1.Height - 2);
                    paintEventArgs_0.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    paintEventArgs_0.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                    SolidBrush solidBrush = new SolidBrush(base.Parent.BackColor);
                    paintEventArgs_0.Graphics.FillRectangle(solidBrush, base.ClientRectangle);
                    Pen pen = new Pen(solidBrush);
                    paintEventArgs_0.Graphics.DrawRectangle(pen, base.ClientRectangle);
                    pen.Dispose();
                    solidBrush.Dispose();
                    if (this.bool_2 && this.int_7 > 0 && this.int_7 < width.Width / 3 && this.int_7 < width.Height / 3)
                    {
                        width.Width = width.Width - this.int_7;
                        width.Height = width.Height - this.int_7;
                    }
                    Rectangle x = new Rectangle(width.Left + this.int_0 + this.int_1 + this.int_4 + this.int_2, width.Top + this.int_0 + this.int_1 + this.int_4 + this.int_2, width.Width - 2 * (this.int_0 + this.int_1 + this.int_4 + this.int_2), width.Height - 2 * (this.int_0 + this.int_1 + this.int_4 + this.int_2));
                    if (this.das_BorderGradientStyle_0 == DAS_BorderGradientStyle.BGS_None)
                    {
                        x.X = width.X;
                        x.Y = width.Y;
                        x.Width = width.Width;
                        x.Height = width.Height;
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
                        x.X = x.X + 2;
                        x.Y = x.Y + 2;
                        x.Width = x.Width - 4;
                        x.Height = x.Height - 4;
                    }
                    SizeF sizeF = paintEventArgs_0.Graphics.MeasureString("H", this.Font);
                    int11 = 0;
                    if (this.das_ProgressLevelShape_0 == DAS_ProgressLevelShape.PLS_Tube3 || this.das_ProgressLevelShape_0 == DAS_ProgressLevelShape.PLS_Funnel2 || this.das_ProgressLevelShape_0 == DAS_ProgressLevelShape.PLS_Cyclinder)
                    {
                        int11 = this.int_11 / 2;
                    }
                    rectangle = new Rectangle(x.Left + 2, x.Top + 2 + int11, x.Width - 4, x.Height - 4 - int11);
                    int num = (rectangle.Left + rectangle.Right) / 2;
                    int top1 = rectangle.Top + this.int_21;
                    bottom = rectangle.Bottom - this.int_22;
                    rectangle.X = rectangle.X + this.int_13;
                    rectangle.Y = rectangle.Y + this.int_14;
                    if (this.das_ProgressLevelShape_0 != DAS_ProgressLevelShape.PLS_Tube)
                    {
                        if (this.das_ProgressLevelShape_0 == DAS_ProgressLevelShape.PLS_Tube2)
                        {
                            bottom = rectangle.Bottom - this.int_11 - this.int_22;
                        }
                        if (this.das_ProgressLevelShape_0 != DAS_ProgressLevelShape.PLS_Tube3)
                        {
                            if (this.das_ProgressLevelShape_0 == DAS_ProgressLevelShape.PLS_Cyclinder)
                            {
                                goto Label15;
                            }
                            if (this.das_ProgressLevelShape_0 == DAS_ProgressLevelShape.PLS_Funnel)
                            {
                                bottom = rectangle.Bottom - this.size_0.Height - this.int_22;
                                goto Label2;
                            }
                            else if (this.das_ProgressLevelShape_0 != DAS_ProgressLevelShape.PLS_Funnel2)
                            {
                                if (this.das_ProgressLevelShape_0 != DAS_ProgressLevelShape.PLS_Tank && this.das_ProgressLevelShape_0 != DAS_ProgressLevelShape.PLS_Tank3)
                                {
                                    if (this.das_ProgressLevelShape_0 == DAS_ProgressLevelShape.PLS_Tank5)
                                    {
                                        goto Label16;
                                    }
                                    if (this.das_ProgressLevelShape_0 == DAS_ProgressLevelShape.PLS_Tank2 || this.das_ProgressLevelShape_0 == DAS_ProgressLevelShape.PLS_Tank4 || this.das_ProgressLevelShape_0 == DAS_ProgressLevelShape.PLS_Tank6)
                                    {
                                        top1 = rectangle.Top + this.int_21;
                                        bottom = rectangle.Bottom - this.size_0.Height - this.int_22;
                                        goto Label2;
                                    }
                                    else
                                    {
                                        goto Label2;
                                    }
                                }
                            Label16:
                                top1 = rectangle.Top + this.size_0.Height + this.int_21;
                                bottom = rectangle.Bottom - this.int_22;
                                goto Label2;
                            }
                            else
                            {
                                top1 = rectangle.Top + int11 + this.int_21;
                                bottom = rectangle.Bottom - this.size_0.Height - this.int_22;
                                goto Label2;
                            }
                        }
                    Label15:
                        top1 = rectangle.Top + int11 + this.int_21;
                        bottom = rectangle.Bottom - this.int_11 - this.int_22;
                    }
                    else
                    {
                        bottom = rectangle.Bottom - this.int_11 - this.int_22;
                    }
                Label2:
                    double0 = bottom;
                    if (this.double_1 > this.double_2 + 1E-12)
                    {
                        double0 = (int)((double)bottom - (this.double_0 - this.double_2) * (double)(bottom - top1) / (this.double_1 - this.double_2));
                    }
                    if (this.das_ProgressLevelShape_0 != DAS_ProgressLevelShape.PLS_Tube && this.das_ProgressLevelShape_0 != DAS_ProgressLevelShape.PLS_Tube2)
                    {
                        if (this.das_ProgressLevelShape_0 == DAS_ProgressLevelShape.PLS_Tube3)
                        {
                            this.method_0(paintEventArgs_0.Graphics, rectangle, double0, int11);
                        }
                        if (this.das_ProgressLevelShape_0 != DAS_ProgressLevelShape.PLS_Funnel)
                        {
                            if (this.das_ProgressLevelShape_0 == DAS_ProgressLevelShape.PLS_Funnel2)
                            {
                                goto Label17;
                            }
                            if (this.das_ProgressLevelShape_0 != DAS_ProgressLevelShape.PLS_Tank && this.das_ProgressLevelShape_0 != DAS_ProgressLevelShape.PLS_Tank2 && this.das_ProgressLevelShape_0 != DAS_ProgressLevelShape.PLS_Tank3 && this.das_ProgressLevelShape_0 != DAS_ProgressLevelShape.PLS_Tank4 && this.das_ProgressLevelShape_0 != DAS_ProgressLevelShape.PLS_Tank5)
                            {
                                if (this.das_ProgressLevelShape_0 == DAS_ProgressLevelShape.PLS_Tank6)
                                {
                                    goto Label18;
                                }
                                if (this.das_ProgressLevelShape_0 != DAS_ProgressLevelShape.PLS_Boiler)
                                {
                                    if (this.das_ProgressLevelShape_0 == DAS_ProgressLevelShape.PLS_Boiler2)
                                    {
                                        goto Label19;
                                    }
                                    if (this.das_ProgressLevelShape_0 == DAS_ProgressLevelShape.PLS_Cyclinder)
                                    {
                                        this.method_4(paintEventArgs_0.Graphics, rectangle, double0, int11);
                                        goto Label7;
                                    }
                                    else if (this.das_ProgressLevelShape_0 == DAS_ProgressLevelShape.PLS_Image && this.image_0 != null)
                                    {
                                        float width1 = (float)rectangle.Width;
                                        float height1 = (float)this.image_0.Height / (float)this.image_0.Width * width1;
                                        if (height1 > (float)rectangle.Height)
                                        {
                                            height1 = (float)rectangle.Height;
                                            width1 = (float)this.image_0.Width / (float)this.image_0.Height * height1;
                                        }
                                        RectangleF rectangleF1 = new RectangleF((float)rectangle.Left + ((float)rectangle.Width - width1) / 2f, (float)rectangle.Top + ((float)rectangle.Height - height1) / 2f, width1, height1);
                                        paintEventArgs_0.Graphics.DrawImage(this.image_0, rectangleF1);
                                        goto Label7;
                                    }
                                    else
                                    {
                                        goto Label7;
                                    }
                                }
                            Label19:
                                this.method_3(paintEventArgs_0.Graphics, rectangle, double0, (int)((float)top1 - sizeF.Height / 2f - 1f + (float)this.int_13), (int)((float)bottom + sizeF.Height / 2f + 1f + (float)this.int_14));
                                goto Label7;
                            }
                        Label18:
                            this.method_2(paintEventArgs_0.Graphics, rectangle, double0, int11);
                            goto Label7;
                        }
                    Label17:
                        this.method_1(paintEventArgs_0.Graphics, rectangle, double0, int11);
                    }
                    else
                    {
                        this.method_0(paintEventArgs_0.Graphics, rectangle, double0, int11);
                    }
                Label7:
                    string str = "0";
                    if (this.int_8 > 0)
                    {
                        str = "0.";
                        for (i = 0; i < this.int_8; i++)
                        {
                            str = string.Concat(str, "0");
                        }
                    }
                    RectangleF int18 = new RectangleF();
                    StringFormat stringFormat = new StringFormat();
                    SolidBrush foreColor = new SolidBrush(this.color_15);
                    string str1 = this.double_1.ToString(str);
                    string str2 = this.double_2.ToString(str);
                    sizeF = paintEventArgs_0.Graphics.MeasureString(str1, this.Font);
                    float single1 = sizeF.Width;
                    sizeF = paintEventArgs_0.Graphics.MeasureString(str2, this.Font);
                    if (single1 < sizeF.Width)
                    {
                        single1 = sizeF.Width;
                    }
                    if (this.int_15 > 1 && this.bool_6)
                    {
                        double double1 = (this.double_1 - this.double_2) / (double)(this.int_15 - 1);
                        Point point = new Point();
                        int int20 = this.int_18;
                        double int15 = (double)(bottom - top1) / (double)(this.int_15 - 1);
                        double int16 = int15 / (double)(this.int_16 + 1);
                        int18.Width = single1;
                        int18.Height = sizeF.Height;
                        stringFormat.LineAlignment = StringAlignment.Center;
                        for (i = 0; i < this.int_15; i++)
                        {
                            point.Y = bottom - (int)((double)i * int15);
                            if (this.das_TickerAlignmentStyle_0 != DAS_TickerAlignmentStyle.TAS_Text_Left)
                            {
                                if (this.das_TickerAlignmentStyle_0 == DAS_TickerAlignmentStyle.TAS_Text_Right)
                                {
                                    goto Label20;
                                }
                                if (this.das_TickerAlignmentStyle_0 != DAS_TickerAlignmentStyle.TAS_Text_LeftRight)
                                {
                                    point.X = num;
                                    int20 = this.int_18;
                                    this.method_10(paintEventArgs_0.Graphics, this.das_TickerShapeStyle_0, point, true, int20, this.int_17, true, this.color_14, this.color_16);
                                    int18.X = (float)(num - this.int_18 / 2 - 1) - single1;
                                    stringFormat.Alignment = StringAlignment.Far;
                                    goto Label11;
                                }
                                else
                                {
                                    point.X = (int)((float)num - single1 / 2f - 1f);
                                    int20 = -this.int_18;
                                    this.method_10(paintEventArgs_0.Graphics, this.das_TickerShapeStyle_0, point, false, int20, this.int_17, true, this.color_14, this.color_16);
                                    point.X = (int)((float)num + single1 / 2f + 1f);
                                    int20 = this.int_18;
                                    this.method_10(paintEventArgs_0.Graphics, this.das_TickerShapeStyle_0, point, false, int20, this.int_17, true, this.color_14, this.color_16);
                                    int18.X = (float)num - single1 / 2f;
                                    stringFormat.Alignment = StringAlignment.Center;
                                    goto Label11;
                                }
                            }
                        Label20:
                            point.X = num;
                            if (this.das_TickerAlignmentStyle_0 != DAS_TickerAlignmentStyle.TAS_Text_Left)
                            {
                                int20 = this.int_18;
                                int18.X = (float)(num + this.int_18 + 1);
                                stringFormat.Alignment = StringAlignment.Near;
                            }
                            else
                            {
                                int20 = -this.int_18;
                                int18.X = (float)(num - this.int_18 - 1) - int18.Width;
                                stringFormat.Alignment = StringAlignment.Far;
                            }
                            this.method_10(paintEventArgs_0.Graphics, this.das_TickerShapeStyle_0, point, false, int20, this.int_17, true, this.color_14, this.color_16);
                        Label11:
                            double double2 = this.double_2 + double1 * (double)i;
                            string str3 = double2.ToString(str);
                            int18.Y = (float)(bottom - (int)((double)i * int15)) - sizeF.Height / 2f;
                            paintEventArgs_0.Graphics.DrawString(str3, this.Font, foreColor, int18, stringFormat);
                            if (i < this.int_15 - 1)
                            {
                                for (int j = 1; j <= this.int_16; j++)
                                {
                                    point.Y = bottom - (int)((double)i * int15 + (double)j * int16);
                                    if (this.das_TickerAlignmentStyle_0 != DAS_TickerAlignmentStyle.TAS_Text_Left)
                                    {
                                        if (this.das_TickerAlignmentStyle_0 == DAS_TickerAlignmentStyle.TAS_Text_Right)
                                        {
                                            goto Label21;
                                        }
                                        if (this.das_TickerAlignmentStyle_0 != DAS_TickerAlignmentStyle.TAS_Text_LeftRight)
                                        {
                                            point.X = num;
                                            int20 = this.int_20;
                                            this.method_10(paintEventArgs_0.Graphics, this.das_TickerShapeStyle_1, point, true, int20, this.int_19, true, this.color_14, this.color_17);

                                        }
                                        else
                                        {
                                            point.X = (int)((float)num - single1 / 2f - 1f);
                                            int20 = -this.int_20;
                                            this.method_10(paintEventArgs_0.Graphics, this.das_TickerShapeStyle_1, point, false, int20, this.int_19, true, this.color_14, this.color_17);
                                            point.X = (int)((float)num + single1 / 2f + 1f);
                                            int20 = this.int_20;
                                            this.method_10(paintEventArgs_0.Graphics, this.das_TickerShapeStyle_1, point, false, int20, this.int_19, true, this.color_14, this.color_17);

                                        }
                                    }
                                Label21:
                                    point.X = num;
                                    int20 = (this.das_TickerAlignmentStyle_0 != DAS_TickerAlignmentStyle.TAS_Text_Left ? this.int_20 : -this.int_20);
                                    this.method_10(paintEventArgs_0.Graphics, this.das_TickerShapeStyle_1, point, false, int20, this.int_19, true, this.color_14, this.color_17);

                                }
                            }
                        }
                    }
                    string str4 = string.Empty;
                    if (this.bool_3)
                    {
                        str4 = this.double_0.ToString(str);
                    }
                    if (this.string_0 != string.Empty)
                    {
                        str4 = (str4 == string.Empty ? this.string_0 : string.Concat(str4, " (", this.string_0, ")"));
                    }
                    if (str4 != string.Empty)
                    {
                        foreColor.Color = this.ForeColor;
                        stringFormat.LineAlignment = StringAlignment.Center;
                        stringFormat.Alignment = StringAlignment.Center;
                        sizeF = paintEventArgs_0.Graphics.MeasureString(str4, this.Font);
                        Rectangle rectangle1 = new Rectangle((int)((float)num - sizeF.Width / 2f + (float)this.int_9), (int)((float)bottom + sizeF.Height / 2f + 1f + (float)this.int_10), (int)(sizeF.Width + 1f), (int)sizeF.Height);
                        paintEventArgs_0.Graphics.DrawString(str4, this.Font, foreColor, rectangle1, stringFormat);
                    }
                    if (this.das_BorderStyle_0 == DAS_BorderStyle.BS_RoundRect)
                    {
                        System.Drawing.Region region = new System.Drawing.Region(base.ClientRectangle);
                        GraphicsPath graphicsPath = new GraphicsPath();
                        _DrawGraphics.method_3(graphicsPath, x, this.int_3 - this.int_0 - this.int_1 - this.int_4 - this.int_2);
                        region.Exclude(graphicsPath);
                        SolidBrush solidBrush2 = new SolidBrush(base.Parent.BackColor);
                        paintEventArgs_0.Graphics.FillRegion(solidBrush2, region);
                        solidBrush2.Dispose();
                        graphicsPath.Dispose();
                        region.Dispose();
                    }
                    if (this.bool_2 && this.int_7 > 0 && this.int_7 < width.Width / 3 && this.int_7 < width.Height / 3 && this.das_BorderGradientStyle_0 != DAS_BorderGradientStyle.BGS_None)
                    {
                        width.X = width.X + this.int_7;
                        width.Y = width.Y + this.int_7;
                        GraphicsPath graphicsPath1 = new GraphicsPath();
                        if (this.das_BorderStyle_0 != DAS_BorderStyle.BS_RoundRect)
                        {
                            _DrawGraphics.method_3(graphicsPath1, width, 5);
                        }
                        else
                        {
                            _DrawGraphics.method_3(graphicsPath1, width, this.int_3);
                        }
                        width.X = width.X - this.int_7;
                        width.Y = width.Y - this.int_7;
                        GraphicsPath graphicsPath2 = new GraphicsPath();
                        if (this.das_BorderStyle_0 != DAS_BorderStyle.BS_RoundRect)
                        {
                            _DrawGraphics.method_3(graphicsPath2, width, 5);
                        }
                        else
                        {
                            _DrawGraphics.method_3(graphicsPath2, width, this.int_3);
                        }
                        System.Drawing.Region region1 = new System.Drawing.Region(graphicsPath1);
                        System.Drawing.Region region2 = new System.Drawing.Region(graphicsPath1);
                        region2.Intersect(graphicsPath2);
                        region1.Xor(region2);
                        paintEventArgs_0.Graphics.SetClip(region1, CombineMode.Replace);
                        _DrawGraphics.method_4(paintEventArgs_0.Graphics, width, graphicsPath2, this.color_7, this.int_7, this.float_7);
                        paintEventArgs_0.Graphics.ResetClip();
                        region2.Dispose();
                        region1.Dispose();
                        graphicsPath2.Dispose();
                        graphicsPath1.Dispose();
                    }
                    if (this.das_BorderStyle_0 != DAS_BorderStyle.BS_RoundRect)
                    {
                        _DrawGraphics.method_0(paintEventArgs_0.Graphics, width, this.int_1, this.color_1, this.color_2, this.int_4, this.color_5, this.int_2, this.color_3, this.color_4, this.int_0, this.color_0, this.das_BorderGradientStyle_0, this.int_5, this.float_0, this.float_1, this.float_2, this.float_3);
                    }
                    else
                    {
                        _DrawGraphics.method_1(paintEventArgs_0.Graphics, width, this.int_3, this.int_1, this.color_1, this.color_2, this.int_4, this.color_5, this.int_2, this.color_3, this.color_4, this.int_0, this.color_0, this.das_BorderGradientStyle_0, (long)this.int_5, this.float_0, this.float_1, this.float_2, this.float_3);
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
                            Licenses.LicenseManager.IsInDesignMode) return;
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
                {
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
                        if ((KeypadScaleFactor == 1) | (KeypadScaleFactor == 0))
                            WCFChannelFactory.Write(m_PLCAddressKeypad, KeypadPopUp.Value);
                        else
                            WCFChannelFactory.Write(m_PLCAddressKeypad,
                                (Convert.ToDouble(KeypadPopUp.Value) / m_KeypadScaleFactor).ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to write value. " + ex.Message);
                    }
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
}
