
using AdvancedScada.Controls.DialogEditor;
using AdvancedScada.Controls.Enum;
using AdvancedScada.Controls.Keyboard;
using AdvancedScada.Controls.Licenses;
using AdvancedScada.Controls.ProcessAll.DrawAll;
using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedScada.Controls.ProcessAll
{
    public class HMIProcessIndicator : Control
    {

        #region Flied


        private DAS_BorderStyle _BorderShape;

        private int _BorderExteriorLength;

        private Color _BorderExteriorColor = Color.Blue;

        private int _OuterBorderLength = 3;

        private int _InnerBorderLength = 2;

        private Color _OuterBorderDarkColor = Color.DimGray;

        private Color _OuterBorderLightColor = Color.White;

        private Color _InnerBorderDarkColor = Color.DimGray;

        private Color _InnerBorderLightColor = Color.White;

        private int _RoundRadius = 30;

        private int _MiddleBorderLength;

        private Color _MiddleBorderColor = Color.Gray;

        private DAS_BorderGradientStyle _BorderGradientType = DAS_BorderGradientStyle.BGS_Ring;

        private int _BorderGradientAngle = 225;

        private float _BorderGradientRate = 0.5f;

        private float _BorderGradientLightPos1 = 1f;

        private float _BorderGradientLightPos2 = -1f;

        private float _BorderLightIntermediateBrightness;

        private float _BkTransparency;

        private float _BkGradientRate = 0.5f;

        private bool _BkGradient;

        private int _BkGradientAngle = 90;

        private DAS_BkGradientStyle _BkGradientType;

        private Color _BkGradientColor = Color.White;

        private float _BkShinePosition = 1f;

        private bool _ControlShadow;

        private int _ShadowDepth = 8;

        private Color _ShadowColor = Color.DimGray;

        private float _ShadowRate = 0.5f;

        private bool _Vertical;

        private DAS_ProcessIndicatorType _IndicatorType = DAS_ProcessIndicatorType.PIT_Triangle;

        private bool _InverseDirection;

        private bool _Value;

        private int _UpdateDuration = 500;

        private float _UpdatePercentage = 0.1f;

        private int _IndicatorSize = 20;

        private int _IndicatorGap = 30;

        private Color _IndicatorColor = Color.YellowGreen;

        private Color _IndicatorColor2 = Color.DarkGreen;

        private Color _IndicatorColor3 = Color.Red;

        private Color _IndicatorBorderColor = Color.DimGray;

        private string _IndicatorString = "...";

        private Image _IndicatorImage;

        private bool _Gradient;

        private Color _IndicatorGradientColor = Color.White;

        private float _IndicatorGradientRate = 0.5f;

        private int _IndicatorGradientAngle = 90;

        private DAS_BkGradientStyle _IndicatorGradientType;

        private float _IndicatorShinePosition = 1f;

        private DrawGraphics2 class0_0 = new DrawGraphics2();

        private double double_0;
        #endregion
        private Timer timer_1 = new Timer();

        private IContainer icontainer_0;
        #region Porpartes


        [Category("Background")]
        [DefaultValue("False")]
        [Description("Get/Set whether or not background is rendered in gradient mode")]
        public bool BkGradient
        {
            get
            {
                return this._BkGradient;
            }
            set
            {
                this._BkGradient = value;
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
                return this._BkGradientAngle;
            }
            set
            {
                this._BkGradientAngle = value;
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
                return this._BkGradientColor;
            }
            set
            {
                this._BkGradientColor = value;
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
                return this._BkGradientRate;
            }
            set
            {
                if (value <= 1f || (double)value >= 0)
                {
                    this._BkGradientRate = value;
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
                return this._BkGradientType;
            }
            set
            {
                this._BkGradientType = value;
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
                return this._BkShinePosition;
            }
            set
            {
                if (value <= 1f || (double)value >= 0)
                {
                    this._BkShinePosition = value;
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
                return this._BkTransparency;
            }
            set
            {
                if (value <= 1f || (double)value >= 0)
                {
                    this._BkTransparency = value;
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
                return this._BorderExteriorColor;
            }
            set
            {
                this._BorderExteriorColor = value;
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
                return this._BorderExteriorLength;
            }
            set
            {
                if (value >= 0)
                {
                    this._BorderExteriorLength = value;
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
                return this._BorderGradientAngle;
            }
            set
            {
                this._BorderGradientAngle = value;
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
                return this._BorderGradientLightPos1;
            }
            set
            {
                if (value <= 1f || (double)value >= 0)
                {
                    this._BorderGradientLightPos1 = value;
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
                return this._BorderGradientLightPos2;
            }
            set
            {
                if (value <= 1f || (double)value >= -1)
                {
                    this._BorderGradientLightPos2 = value;
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
                return this._BorderGradientRate;
            }
            set
            {
                if (value <= 1f || (double)value >= 0)
                {
                    this._BorderGradientRate = value;
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
                return this._BorderGradientType;
            }
            set
            {
                this._BorderGradientType = value;
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
                return this._BorderLightIntermediateBrightness;
            }
            set
            {
                if (value <= 1f || (double)value >= 0)
                {
                    this._BorderLightIntermediateBrightness = value;
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
                return this._BorderShape;
            }
            set
            {
                this._BorderShape = value;
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
                return this._ControlShadow;
            }
            set
            {
                this._ControlShadow = value;
                base.Invalidate();
            }
        }

        [Category("Indicator")]
        [DefaultValue("false")]
        [Description("Specify whether to draw the indicator in gradient mode or not")]
        public bool Gradient
        {
            get
            {
                return this._Gradient;
            }
            set
            {
                this._Gradient = value;
                base.Invalidate();
            }
        }

        [Category("Indicator")]
        [DefaultValue("Color.DimGray")]
        [Description("Specify the border color of the indicator")]
        public Color IndicatorBorderColor
        {
            get
            {
                return this._IndicatorBorderColor;
            }
            set
            {
                this._IndicatorBorderColor = value;
                base.Invalidate();
            }
        }

        [Category("Indicator")]
        [DefaultValue("Color.Green")]
        [Description("Specify the first color used to draw the indicator")]
        public Color IndicatorColor
        {
            get
            {
                return this._IndicatorColor;
            }
            set
            {
                this._IndicatorColor = value;
                base.Invalidate();
            }
        }

        [Category("Indicator")]
        [DefaultValue("Color.DarkGreen")]
        [Description("Specify the second color to draw the indicator")]
        public Color IndicatorColor2
        {
            get
            {
                return this._IndicatorColor2;
            }
            set
            {
                this._IndicatorColor2 = value;
                base.Invalidate();
            }
        }

        [Category("Indicator")]
        [DefaultValue("Color.Red")]
        [Description("Specify the third color to draw the indicator")]
        public Color IndicatorColor3
        {
            get
            {
                return this._IndicatorColor3;
            }
            set
            {
                this._IndicatorColor3 = value;
                base.Invalidate();
            }
        }

        [Category("Indicator")]
        [DefaultValue("30")]
        [Description("Get/Set the gap between the indicators")]
        public int IndicatorGap
        {
            get
            {
                return this._IndicatorGap;
            }
            set
            {
                this._IndicatorGap = value;
                base.Invalidate();
            }
        }

        [Category("Indicator")]
        [DefaultValue("90")]
        [Description("Get/Set gradient angle of the indicator")]
        public int IndicatorGradientAngle
        {
            get
            {
                return this._IndicatorGradientAngle;
            }
            set
            {
                this._IndicatorGradientAngle = value;
                base.Invalidate();
            }
        }

        [Category("Indicator")]
        [DefaultValue("Color.White")]
        [Description("Specify the gradient color of the indicator")]
        public Color IndicatorGradientColor
        {
            get
            {
                return this._IndicatorGradientColor;
            }
            set
            {
                this._IndicatorGradientColor = value;
                base.Invalidate();
            }
        }

        [Category("Indicator")]
        [DefaultValue("0.5")]
        [Description("Get/Set gradient rate of the indicator")]
        public float IndicatorGradientRate
        {
            get
            {
                return this._IndicatorGradientRate;
            }
            set
            {
                if (value <= 1f || (double)value >= 0)
                {
                    this._IndicatorGradientRate = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Indicator")]
        [DefaultValue("BKGS_Linear")]
        [Description("Get/Set gradient Type of the indicator")]
        public DAS_BkGradientStyle IndicatorGradientType
        {
            get
            {
                return this._IndicatorGradientType;
            }
            set
            {
                this._IndicatorGradientType = value;
                base.Invalidate();
            }
        }

        [Category("Indicator")]
        [DefaultValue("null")]
        [Description("Get/Set the indicator image when the indicator is PIT_Image")]
        public Image IndicatorImage
        {
            get
            {
                return this._IndicatorImage;
            }
            set
            {
                this._IndicatorImage = value;
                base.Invalidate();
            }
        }

        [Category("Indicator")]
        [DefaultValue("1.0")]
        [Description("Get/Set the shine position of the background gradient rendering of the indicator")]
        public float IndicatorShinePosition
        {
            get
            {
                return this._IndicatorShinePosition;
            }
            set
            {
                if (value <= 1f || (double)value >= 0)
                {
                    this._IndicatorShinePosition = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Indicator")]
        [DefaultValue("20")]
        [Description("Get/Set the indicator size")]
        public int IndicatorSize
        {
            get
            {
                return this._IndicatorSize;
            }
            set
            {
                this._IndicatorSize = value;
                base.Invalidate();
            }
        }

        [Category("Indicator")]
        [DefaultValue("")]
        [Description("Get/Set the Indicator string when the indicator is PIT_Text")]
        public string IndicatorString
        {
            get
            {
                return this._IndicatorString;
            }
            set
            {
                this._IndicatorString = value;
                base.Invalidate();
            }
        }

        [Category("General")]
        [DefaultValue("DAS_ProcessIndicatorType.PIT_Triangle")]
        [Description("Get/Set the type of the process indicator")]
        public DAS_ProcessIndicatorType IndicatorType
        {
            get
            {
                return this._IndicatorType;
            }
            set
            {
                this._IndicatorType = value;
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
                return this._InnerBorderDarkColor;
            }
            set
            {
                this._InnerBorderDarkColor = value;
                base.Invalidate();
            }
        }

        [Category("Border")]
        [DefaultValue("2")]
        [Description("Get/Set inner border length of control")]
        public int InnerBorderLength
        {
            get
            {
                return this._InnerBorderLength;
            }
            set
            {
                if (value >= 0)
                {
                    this._InnerBorderLength = value;
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
                return this._InnerBorderLightColor;
            }
            set
            {
                this._InnerBorderLightColor = value;
                base.Invalidate();
            }
        }

        [Category("General")]
        [DefaultValue("false")]
        [Description("Get/Set whether the moving direction of the process indicator is at opposite direction or not")]
        public bool InverseDirection
        {
            get
            {
                return this._InverseDirection;
            }
            set
            {
                this._InverseDirection = value;
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
                return this._MiddleBorderColor;
            }
            set
            {
                this._MiddleBorderColor = value;
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
                return this._MiddleBorderLength;
            }
            set
            {
                if (value >= 0)
                {
                    this._MiddleBorderLength = value;
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
                return this._OuterBorderDarkColor;
            }
            set
            {
                this._OuterBorderDarkColor = value;
                base.Invalidate();
            }
        }

        [Category("Border")]
        [DefaultValue("3")]
        [Description("Get/Set outer border length of control")]
        public int OuterBorderLength
        {
            get
            {
                return this._OuterBorderLength;
            }
            set
            {
                if (value >= 0)
                {
                    this._OuterBorderLength = value;
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
                return this._OuterBorderLightColor;
            }
            set
            {
                this._OuterBorderLightColor = value;
                base.Invalidate();
            }
        }

        [Category("Border")]
        [DefaultValue("30")]
        [Description("Get/Set Round Radius of Round Rectangle Border of control")]
        public int RoundRadius
        {
            get
            {
                return this._RoundRadius;
            }
            set
            {
                if (value >= 0)
                {
                    this._RoundRadius = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Shadow")]
        [DefaultValue("Color.DimGray")]
        [Description("Get/Set the shadow color")]
        public Color ShadowColor
        {
            get
            {
                return this._ShadowColor;
            }
            set
            {
                this._ShadowColor = value;
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
                return this._ShadowDepth;
            }
            set
            {
                if (value > 0)
                {
                    this._ShadowDepth = value;
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
                return this._ShadowRate;
            }
            set
            {
                if ((double)value >= 0.05 && (double)value <= 0.95)
                {
                    this._ShadowRate = value;
                    base.Invalidate();
                }
            }
        }

        [Category("General")]
        [DefaultValue("500")]
        [Description("Specify the update duration to show the indicator moving status")]
        public int UpdateDuration
        {
            get
            {
                return this._UpdateDuration;
            }
            set
            {
                this._UpdateDuration = value;
                this.timer_1.Interval = this._UpdateDuration;
                base.Invalidate();
            }
        }

        [Category("General")]
        [DefaultValue("0.05")]
        [Description("Get/Set the moving percentage in each update")]
        public float UpdatePercentage
        {
            get
            {
                return this._UpdatePercentage;
            }
            set
            {
                if (value <= 1f || (double)value >= 0)
                {
                    this._UpdatePercentage = value;
                    base.Invalidate();
                }
            }
        }

        [Category("General")]
        [DefaultValue("false")]
        [Description("Specify the value of the process indicator")]
        public bool Value
        {
            get
            {
                return this._Value;
            }
            set
            {
                this._Value = value;
                this.timer_1.Enabled = this._Value;
                this.timer_1.Interval = this._UpdateDuration;
                base.Invalidate();
            }
        }

        [Category("General")]
        [DefaultValue("false")]
        [Description("Get/Set whether the process indicator is rendered in vertical direction or not.")]
        public bool Vertical
        {
            get
            {
                return this._Vertical;
            }
            set
            {
                this._Vertical = value;
                base.Invalidate();
            }
        }
        #endregion
        public HMIProcessIndicator()
        {

            base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            base.SetStyle(ControlStyles.Opaque, true);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.method_2();
            this.timer_1.Tick += new EventHandler(this.timer_1_Tick);
        }
        #region Method


        private void method_0(Graphics graphics_0, GraphicsPath graphicsPath_0, bool bool_7)
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

        private void method_1(Graphics graphics_0, Rectangle rectangle_0, DAS_ProcessIndicatorType das_ProcessIndicatorType_1)
        {
            DAS_ShapeStyle dASShapeStyle = DAS_ShapeStyle.SS_Rect;
            if (das_ProcessIndicatorType_1 == DAS_ProcessIndicatorType.PIT_Image && this._IndicatorImage != null)
            {
                PointF pointF = new PointF()
                {
                    X = (float)rectangle_0.Left + (float)(rectangle_0.Width - this._IndicatorImage.Width) / 2f,
                    Y = (float)rectangle_0.Top + (float)(rectangle_0.Height - this._IndicatorImage.Height) / 2f
                };
                graphics_0.DrawImage(this._IndicatorImage, pointF);
                return;
            }
            if (das_ProcessIndicatorType_1 == DAS_ProcessIndicatorType.PIT_Circle)
            {
                dASShapeStyle = DAS_ShapeStyle.SS_Circle;
            }
            else if (das_ProcessIndicatorType_1 == DAS_ProcessIndicatorType.PIT_Diamond)
            {
                dASShapeStyle = DAS_ShapeStyle.SS_Diamond;
            }
            else if (das_ProcessIndicatorType_1 == DAS_ProcessIndicatorType.PIT_Squre)
            {
                dASShapeStyle = DAS_ShapeStyle.SS_Rect;
            }
            else if (!this._Vertical)
            {
                if (!this._InverseDirection)
                {
                    if (das_ProcessIndicatorType_1 != DAS_ProcessIndicatorType.PIT_Triangle)
                    {
                        if (das_ProcessIndicatorType_1 != DAS_ProcessIndicatorType.PIT_Arrow)
                        {
                            return;
                        }
                        dASShapeStyle = DAS_ShapeStyle.SS_Right_Arrow;
                    }
                    else
                    {
                        dASShapeStyle = DAS_ShapeStyle.SS_Right_Triangle;
                    }
                }
                else if (das_ProcessIndicatorType_1 != DAS_ProcessIndicatorType.PIT_Triangle)
                {
                    if (das_ProcessIndicatorType_1 != DAS_ProcessIndicatorType.PIT_Arrow)
                    {
                        return;
                    }
                    dASShapeStyle = DAS_ShapeStyle.SS_Left_Arrow;
                }
                else
                {
                    dASShapeStyle = DAS_ShapeStyle.SS_Left_Triangle;
                }
            }
            else if (!this._InverseDirection)
            {
                if (das_ProcessIndicatorType_1 != DAS_ProcessIndicatorType.PIT_Triangle)
                {
                    if (das_ProcessIndicatorType_1 != DAS_ProcessIndicatorType.PIT_Arrow)
                    {
                        return;
                    }
                    dASShapeStyle = DAS_ShapeStyle.SS_Top_Arrow;
                }
                else
                {
                    dASShapeStyle = DAS_ShapeStyle.SS_Top_Triangle;
                }
            }
            else if (das_ProcessIndicatorType_1 != DAS_ProcessIndicatorType.PIT_Triangle)
            {
                if (das_ProcessIndicatorType_1 != DAS_ProcessIndicatorType.PIT_Arrow)
                {
                    return;
                }
                dASShapeStyle = DAS_ShapeStyle.SS_Bottom_Arrow;
            }
            else
            {
                dASShapeStyle = DAS_ShapeStyle.SS_Bottom_Triangle;
            }
            GraphicsPath graphicsPath = new GraphicsPath();
            if (dASShapeStyle == DAS_ShapeStyle.SS_Rect)
            {
                graphicsPath.AddRectangle(rectangle_0);
            }
            else if (dASShapeStyle != DAS_ShapeStyle.SS_Circle)
            {
                this.class0_0.method_6(graphicsPath, rectangle_0, dASShapeStyle, this._IndicatorSize / 2, 0);
            }
            else
            {
                graphicsPath.AddEllipse(rectangle_0);
            }
            Color color8 = this._IndicatorColor;
            Color color12 = this._IndicatorGradientColor;
            if (!this._Gradient)
            {
                SolidBrush solidBrush = new SolidBrush(color8);
                graphics_0.FillPath(solidBrush, graphicsPath);
                solidBrush.Dispose();
            }
            else
            {
                this.class0_0.method_3(graphics_0, rectangle_0, dASShapeStyle, graphicsPath, color8, color12, this._IndicatorGradientType, this._IndicatorGradientAngle, this._IndicatorGradientRate, 0, this._IndicatorSize / 2, this._IndicatorShinePosition);
            }
            Pen pen = new Pen(this._IndicatorBorderColor);
            graphics_0.DrawPath(pen, graphicsPath);
            pen.Dispose();
            if (graphicsPath != null)
            {
                graphicsPath.Dispose();
            }
        }

        private void method_2()
        {
            this.icontainer_0 = new System.ComponentModel.Container();
        }

        protected override void Dispose(bool bool_7)
        {
            if (bool_7 && this.icontainer_0 != null)
            {
                this.icontainer_0.Dispose();
            }
            base.Dispose(bool_7);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int num;
            int right;
            int i;
            try
            {
                base.OnPaint(e);
                if (base.ClientRectangle.Width - 2 * (this._BorderExteriorLength + this._OuterBorderLength + this._MiddleBorderLength + this._InnerBorderLength) > 0 && base.ClientRectangle.Height - 2 * (this._BorderExteriorLength + this._OuterBorderLength + this._MiddleBorderLength + this._InnerBorderLength) > 0)
                {
                    int left = base.ClientRectangle.Left;
                    int top = base.ClientRectangle.Top;
                    Rectangle clientRectangle = base.ClientRectangle;
                    int width = clientRectangle.Width - 1;
                    clientRectangle = base.ClientRectangle;
                    Rectangle rectangle = new Rectangle(left, top, width, clientRectangle.Height - 1);
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                    SolidBrush solidBrush = new SolidBrush(base.Parent.BackColor);
                    e.Graphics.FillRectangle(solidBrush, base.ClientRectangle);
                    Pen pen = new Pen(solidBrush);
                    e.Graphics.DrawRectangle(pen, base.ClientRectangle);
                    pen.Dispose();
                    solidBrush.Dispose();
                    if (this._ControlShadow && this._ShadowDepth > 0 && this._ShadowDepth < rectangle.Width / 3 && this._ShadowDepth < rectangle.Height / 3 && this._BorderGradientType != DAS_BorderGradientStyle.BGS_None)
                    {
                        rectangle.Width = rectangle.Width - this._ShadowDepth;
                        rectangle.Height = rectangle.Height - this._ShadowDepth;
                    }
                    Rectangle rectangle1 = new Rectangle(rectangle.Left + this._BorderExteriorLength + this._OuterBorderLength + this._MiddleBorderLength + this._InnerBorderLength, rectangle.Top + this._BorderExteriorLength + this._OuterBorderLength + this._MiddleBorderLength + this._InnerBorderLength, rectangle.Width - 2 * (this._BorderExteriorLength + this._OuterBorderLength + this._MiddleBorderLength + this._InnerBorderLength), rectangle.Height - 2 * (this._BorderExteriorLength + this._OuterBorderLength + this._MiddleBorderLength + this._InnerBorderLength));
                    if (this.BackgroundImage != null)
                    {
                        if (this.BackgroundImageLayout == ImageLayout.Center)
                        {
                            PointF pointF = new PointF()
                            {
                                X = (float)rectangle1.Left + (float)(rectangle1.Width - this.BackgroundImage.Width) / 2f,
                                Y = (float)rectangle1.Top + (float)(rectangle1.Height - this.BackgroundImage.Height) / 2f
                            };
                            e.Graphics.DrawImage(this.BackgroundImage, pointF);
                        }
                        else if (this.BackgroundImageLayout == ImageLayout.None)
                        {
                            PointF pointF1 = new PointF()
                            {
                                X = (float)rectangle1.Left,
                                Y = (float)rectangle1.Top
                            };
                            e.Graphics.DrawImage(this.BackgroundImage, pointF1);
                        }
                        else if (this.BackgroundImageLayout == ImageLayout.Stretch)
                        {
                            e.Graphics.DrawImage(this.BackgroundImage, rectangle1);
                        }
                        else if (this.BackgroundImageLayout == ImageLayout.Zoom)
                        {
                            float single = (float)rectangle1.Width;
                            float height = (float)this.BackgroundImage.Height / (float)this.BackgroundImage.Width * single;
                            if (height > (float)rectangle1.Height)
                            {
                                height = (float)rectangle1.Height;
                                single = (float)this.BackgroundImage.Width / (float)this.BackgroundImage.Height * height;
                            }
                            RectangleF rectangleF = new RectangleF((float)rectangle1.Left + ((float)rectangle1.Width - single) / 2f, (float)rectangle1.Top + ((float)rectangle1.Height - height) / 2f, single, height);
                            e.Graphics.DrawImage(this.BackgroundImage, rectangleF);
                        }
                        else if (this.BackgroundImageLayout == ImageLayout.Tile)
                        {
                            TextureBrush textureBrush = new TextureBrush(this.BackgroundImage);
                            e.Graphics.FillRectangle(textureBrush, rectangle1);
                            textureBrush.Dispose();
                        }
                    }
                    int float4 = 255;
                    if ((double)this._BkTransparency > 0)
                    {
                        float4 = 255 - (int)(255f * this._BkTransparency);
                    }
                    Color color = Color.FromArgb(float4, this.BackColor);
                    Color color1 = Color.FromArgb(float4, this._BkGradientColor);
                    if (!this._BkGradient)
                    {
                        SolidBrush solidBrush1 = new SolidBrush(color);
                        e.Graphics.FillRectangle(solidBrush1, rectangle1);
                        solidBrush1.Dispose();
                    }
                    else
                    {
                        this.class0_0.method_3(e.Graphics, rectangle1, DAS_ShapeStyle.SS_Rect, null, color, color1, this._BkGradientType, this._BkGradientAngle, this._BkGradientRate, this._RoundRadius, 0, this._BkShinePosition);
                    }
                    if (this._IndicatorType != DAS_ProcessIndicatorType.PIT_Arrow && this._IndicatorType != DAS_ProcessIndicatorType.PIT_Circle && this._IndicatorType != DAS_ProcessIndicatorType.PIT_Diamond && this._IndicatorType != DAS_ProcessIndicatorType.PIT_Image && this._IndicatorType != DAS_ProcessIndicatorType.PIT_Squre)
                    {
                        if (this._IndicatorType == DAS_ProcessIndicatorType.PIT_Triangle)
                        {
                            goto Label2;
                        }
                        if (this._IndicatorType == DAS_ProcessIndicatorType.PIT_Text && this._IndicatorString != string.Empty)
                        {
                            StringFormat stringFormat = new StringFormat();
                            SizeF sizeF = e.Graphics.MeasureString(this._IndicatorString, this.Font);
                            stringFormat.Alignment = StringAlignment.Center;
                            stringFormat.LineAlignment = StringAlignment.Center;
                            SolidBrush solidBrush2 = new SolidBrush(this.ForeColor);
                            Rectangle bottom = new Rectangle();
                            float height1 = 0f;
                            if (this._Vertical)
                            {
                                height1 = (float)((double)rectangle1.Height * this.double_0);
                                bottom.Height = (int)(sizeF.Width + 1f);
                                bottom.Width = (int)(sizeF.Height + 1f);
                                bottom.X = (int)((float)rectangle1.Left + ((float)rectangle1.Width - sizeF.Height) / 2f);
                                if (this._InverseDirection)
                                {
                                    bottom.Y = (int)((float)rectangle1.Top + height1);
                                    e.Graphics.TranslateTransform((float)(bottom.Left + bottom.Width / 2), (float)(bottom.Y + bottom.Height / 2));
                                    e.Graphics.RotateTransform(90f);
                                    e.Graphics.DrawString(this._IndicatorString, this.Font, solidBrush2, -sizeF.Width / 2f, -sizeF.Height / 2f);
                                    e.Graphics.ResetTransform();
                                    if (bottom.Bottom > rectangle1.Bottom)
                                    {
                                        int bottom1 = bottom.Bottom;
                                        bottom.Y = (int)((float)rectangle1.Top - sizeF.Width + (float)(bottom1 - rectangle1.Bottom));
                                        e.Graphics.TranslateTransform((float)(bottom.Left + bottom.Width / 2), (float)(bottom.Y + bottom.Height / 2));
                                        e.Graphics.RotateTransform(90f);
                                        e.Graphics.DrawString(this._IndicatorString, this.Font, solidBrush2, -sizeF.Width / 2f, -sizeF.Height / 2f);
                                        e.Graphics.ResetTransform();
                                    }
                                }
                                else
                                {
                                    bottom.Y = (int)((float)rectangle1.Bottom - height1 - sizeF.Width);
                                    e.Graphics.TranslateTransform((float)(bottom.Left + bottom.Width / 2), (float)(bottom.Y + bottom.Height / 2));
                                    e.Graphics.RotateTransform(90f);
                                    e.Graphics.DrawString(this._IndicatorString, this.Font, solidBrush2, -sizeF.Width / 2f, -sizeF.Height / 2f);
                                    e.Graphics.ResetTransform();
                                    if (bottom.Top < rectangle1.Top)
                                    {
                                        int top1 = bottom.Top;
                                        bottom.Y = rectangle1.Bottom - (rectangle1.Top - top1);
                                        e.Graphics.TranslateTransform((float)(bottom.Left + bottom.Width / 2), (float)(bottom.Y + bottom.Height / 2));
                                        e.Graphics.RotateTransform(90f);
                                        e.Graphics.DrawString(this._IndicatorString, this.Font, solidBrush2, -sizeF.Width / 2f, -sizeF.Height / 2f);
                                        e.Graphics.ResetTransform();
                                    }
                                }
                            }
                            else
                            {
                                height1 = (float)((double)rectangle1.Width * this.double_0);
                                bottom.Width = (int)(sizeF.Width + 1f);
                                bottom.Height = (int)(sizeF.Height + 1f);
                                bottom.Y = (int)((float)rectangle1.Top + ((float)rectangle1.Height - sizeF.Height) / 2f);
                                if (this._InverseDirection)
                                {
                                    bottom.X = (int)((float)rectangle1.Right - height1 - sizeF.Width);
                                    e.Graphics.DrawString(this._IndicatorString, this.Font, solidBrush2, bottom, stringFormat);
                                    if (bottom.Left < rectangle1.Left)
                                    {
                                        int left1 = bottom.Left;
                                        bottom.X = rectangle1.Right - (rectangle1.Left - left1);
                                        e.Graphics.DrawString(this._IndicatorString, this.Font, solidBrush2, bottom, stringFormat);
                                    }
                                }
                                else
                                {
                                    bottom.X = (int)((float)rectangle1.Left + height1);
                                    e.Graphics.DrawString(this._IndicatorString, this.Font, solidBrush2, bottom, stringFormat);
                                    if (bottom.Right > rectangle1.Right)
                                    {
                                        int right1 = bottom.Right;
                                        bottom.X = (int)((float)rectangle1.Left - sizeF.Width + (float)right1 - (float)rectangle1.Right);
                                        e.Graphics.DrawString(this._IndicatorString, this.Font, solidBrush2, bottom, stringFormat);
                                    }
                                }
                            }
                            solidBrush2.Dispose();
                            goto Label0;
                        }
                        else if (this._IndicatorType != DAS_ProcessIndicatorType.PIT_Curve || rectangle1.Width <= 8 || rectangle1.Height <= 8)
                        {
                            double double0 = 360 * this.double_0;
                            if (this._InverseDirection)
                            {
                                double0 = -double0;
                            }
                            Pen pen1 = new Pen(this._IndicatorBorderColor);
                            Rectangle rectangle2 = new Rectangle()
                            {
                                X = rectangle1.Left + 5,
                                Y = rectangle1.Top + 5,
                                Width = rectangle1.Width - 10,
                                Height = rectangle1.Height - 10
                            };
                            if (this._IndicatorType == DAS_ProcessIndicatorType.PIT_Rotation1)
                            {
                                if (this._Gradient)
                                {
                                    GraphicsPath graphicsPath = new GraphicsPath();
                                    graphicsPath.AddPie(rectangle2, (float)double0, 90f);
                                    this.class0_0.method_3(e.Graphics, rectangle2, DAS_ShapeStyle.SS_Circle, graphicsPath, this._IndicatorColor, this._IndicatorGradientColor, this._IndicatorGradientType, this._IndicatorGradientAngle, this._IndicatorGradientRate, 0, 0, this._IndicatorShinePosition);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)double0, 90f);
                                    graphicsPath.Reset();
                                    graphicsPath.AddPie(rectangle2, (float)(90 + double0), 90f);
                                    this.class0_0.method_3(e.Graphics, rectangle2, DAS_ShapeStyle.SS_Circle, graphicsPath, this._IndicatorColor2, this._IndicatorGradientColor, this._IndicatorGradientType, this._IndicatorGradientAngle, this._IndicatorGradientRate, 0, 0, this._IndicatorShinePosition);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(90 + double0), 90f);
                                    graphicsPath.Reset();
                                    graphicsPath.AddPie(rectangle2, (float)(180 + double0), 90f);
                                    this.class0_0.method_3(e.Graphics, rectangle2, DAS_ShapeStyle.SS_Circle, graphicsPath, this._IndicatorColor, this._IndicatorGradientColor, this._IndicatorGradientType, this._IndicatorGradientAngle, this._IndicatorGradientRate, 0, 0, this._IndicatorShinePosition);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(180 + double0), 90f);
                                    graphicsPath.Reset();
                                    graphicsPath.AddPie(rectangle2, (float)(270 + double0), 90f);
                                    this.class0_0.method_3(e.Graphics, rectangle2, DAS_ShapeStyle.SS_Circle, graphicsPath, this._IndicatorColor2, this._IndicatorGradientColor, this._IndicatorGradientType, this._IndicatorGradientAngle, this._IndicatorGradientRate, 0, 0, this._IndicatorShinePosition);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(270 + double0), 90f);
                                    graphicsPath.Reset();
                                    graphicsPath.Dispose();
                                }
                                else
                                {
                                    SolidBrush solidBrush3 = new SolidBrush(this._IndicatorColor);
                                    SolidBrush solidBrush4 = new SolidBrush(this._IndicatorColor2);
                                    e.Graphics.FillPie(solidBrush3, rectangle2, (float)double0, 90f);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)double0, 90f);
                                    e.Graphics.FillPie(solidBrush4, rectangle2, (float)(90 + double0), 90f);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(90 + double0), 90f);
                                    e.Graphics.FillPie(solidBrush3, rectangle2, (float)(180 + double0), 90f);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(180 + double0), 90f);
                                    e.Graphics.FillPie(solidBrush4, rectangle2, (float)(270 + double0), 90f);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(270 + double0), 90f);
                                    solidBrush4.Dispose();
                                    solidBrush3.Dispose();
                                }
                            }
                            else if (this._IndicatorType == DAS_ProcessIndicatorType.PIT_Rotation2)
                            {
                                if (this._Gradient)
                                {
                                    GraphicsPath graphicsPath1 = new GraphicsPath();
                                    graphicsPath1.AddPie(rectangle2, (float)double0, 30f);
                                    this.class0_0.method_3(e.Graphics, rectangle2, DAS_ShapeStyle.SS_Circle, graphicsPath1, this._IndicatorColor, this._IndicatorGradientColor, this._IndicatorGradientType, this._IndicatorGradientAngle, this._IndicatorGradientRate, 0, 0, this._IndicatorShinePosition);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)double0, 30f);
                                    graphicsPath1.Reset();
                                    graphicsPath1.AddPie(rectangle2, (float)(30 + double0), 30f);
                                    this.class0_0.method_3(e.Graphics, rectangle2, DAS_ShapeStyle.SS_Circle, graphicsPath1, this._IndicatorColor2, this._IndicatorGradientColor, this._IndicatorGradientType, this._IndicatorGradientAngle, this._IndicatorGradientRate, 0, 0, this._IndicatorShinePosition);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(30 + double0), 30f);
                                    graphicsPath1.Reset();
                                    graphicsPath1.AddPie(rectangle2, (float)(60 + double0), 30f);
                                    this.class0_0.method_3(e.Graphics, rectangle2, DAS_ShapeStyle.SS_Circle, graphicsPath1, this._IndicatorColor3, this._IndicatorGradientColor, this._IndicatorGradientType, this._IndicatorGradientAngle, this._IndicatorGradientRate, 0, 0, this._IndicatorShinePosition);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(60 + double0), 30f);
                                    graphicsPath1.Reset();
                                    graphicsPath1.AddPie(rectangle2, (float)(90 + double0), 30f);
                                    this.class0_0.method_3(e.Graphics, rectangle2, DAS_ShapeStyle.SS_Circle, graphicsPath1, this._IndicatorColor, this._IndicatorGradientColor, this._IndicatorGradientType, this._IndicatorGradientAngle, this._IndicatorGradientRate, 0, 0, this._IndicatorShinePosition);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(90 + double0), 30f);
                                    graphicsPath1.Reset();
                                    graphicsPath1.AddPie(rectangle2, (float)(120 + double0), 30f);
                                    this.class0_0.method_3(e.Graphics, rectangle2, DAS_ShapeStyle.SS_Circle, graphicsPath1, this._IndicatorColor2, this._IndicatorGradientColor, this._IndicatorGradientType, this._IndicatorGradientAngle, this._IndicatorGradientRate, 0, 0, this._IndicatorShinePosition);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(120 + double0), 30f);
                                    graphicsPath1.Reset();
                                    graphicsPath1.AddPie(rectangle2, (float)(150 + double0), 30f);
                                    this.class0_0.method_3(e.Graphics, rectangle2, DAS_ShapeStyle.SS_Circle, graphicsPath1, this._IndicatorColor3, this._IndicatorGradientColor, this._IndicatorGradientType, this._IndicatorGradientAngle, this._IndicatorGradientRate, 0, 0, this._IndicatorShinePosition);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(150 + double0), 30f);
                                    graphicsPath1.Reset();
                                    graphicsPath1.AddPie(rectangle2, (float)(180 + double0), 30f);
                                    this.class0_0.method_3(e.Graphics, rectangle2, DAS_ShapeStyle.SS_Circle, graphicsPath1, this._IndicatorColor, this._IndicatorGradientColor, this._IndicatorGradientType, this._IndicatorGradientAngle, this._IndicatorGradientRate, 0, 0, this._IndicatorShinePosition);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(180 + double0), 30f);
                                    graphicsPath1.Reset();
                                    graphicsPath1.AddPie(rectangle2, (float)(210 + double0), 30f);
                                    this.class0_0.method_3(e.Graphics, rectangle2, DAS_ShapeStyle.SS_Circle, graphicsPath1, this._IndicatorColor2, this._IndicatorGradientColor, this._IndicatorGradientType, this._IndicatorGradientAngle, this._IndicatorGradientRate, 0, 0, this._IndicatorShinePosition);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(210 + double0), 30f);
                                    graphicsPath1.Reset();
                                    graphicsPath1.AddPie(rectangle2, (float)(240 + double0), 30f);
                                    this.class0_0.method_3(e.Graphics, rectangle2, DAS_ShapeStyle.SS_Circle, graphicsPath1, this._IndicatorColor3, this._IndicatorGradientColor, this._IndicatorGradientType, this._IndicatorGradientAngle, this._IndicatorGradientRate, 0, 0, this._IndicatorShinePosition);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(240 + double0), 30f);
                                    graphicsPath1.Reset();
                                    graphicsPath1.AddPie(rectangle2, (float)(270 + double0), 30f);
                                    this.class0_0.method_3(e.Graphics, rectangle2, DAS_ShapeStyle.SS_Circle, graphicsPath1, this._IndicatorColor, this._IndicatorGradientColor, this._IndicatorGradientType, this._IndicatorGradientAngle, this._IndicatorGradientRate, 0, 0, this._IndicatorShinePosition);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(270 + double0), 30f);
                                    graphicsPath1.Reset();
                                    graphicsPath1.AddPie(rectangle2, (float)(300 + double0), 30f);
                                    this.class0_0.method_3(e.Graphics, rectangle2, DAS_ShapeStyle.SS_Circle, graphicsPath1, this._IndicatorColor2, this._IndicatorGradientColor, this._IndicatorGradientType, this._IndicatorGradientAngle, this._IndicatorGradientRate, 0, 0, this._IndicatorShinePosition);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(300 + double0), 30f);
                                    graphicsPath1.Reset();
                                    graphicsPath1.AddPie(rectangle2, (float)(330 + double0), 30f);
                                    this.class0_0.method_3(e.Graphics, rectangle2, DAS_ShapeStyle.SS_Circle, graphicsPath1, this._IndicatorColor3, this._IndicatorGradientColor, this._IndicatorGradientType, this._IndicatorGradientAngle, this._IndicatorGradientRate, 0, 0, this._IndicatorShinePosition);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(330 + double0), 30f);
                                    graphicsPath1.Reset();
                                    graphicsPath1.Dispose();
                                }
                                else
                                {
                                    SolidBrush solidBrush5 = new SolidBrush(this._IndicatorColor);
                                    SolidBrush solidBrush6 = new SolidBrush(this._IndicatorColor2);
                                    SolidBrush solidBrush7 = new SolidBrush(this._IndicatorColor3);
                                    e.Graphics.FillPie(solidBrush5, rectangle2, (float)double0, 30f);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)double0, 30f);
                                    e.Graphics.FillPie(solidBrush6, rectangle2, (float)(30 + double0), 30f);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(30 + double0), 30f);
                                    e.Graphics.FillPie(solidBrush7, rectangle2, (float)(60 + double0), 30f);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(60 + double0), 30f);
                                    e.Graphics.FillPie(solidBrush5, rectangle2, (float)(90 + double0), 30f);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(90 + double0), 30f);
                                    e.Graphics.FillPie(solidBrush6, rectangle2, (float)(120 + double0), 30f);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(120 + double0), 30f);
                                    e.Graphics.FillPie(solidBrush7, rectangle2, (float)(150 + double0), 30f);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(150 + double0), 30f);
                                    e.Graphics.FillPie(solidBrush5, rectangle2, (float)(180 + double0), 30f);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(180 + double0), 30f);
                                    e.Graphics.FillPie(solidBrush6, rectangle2, (float)(210 + double0), 30f);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(210 + double0), 30f);
                                    e.Graphics.FillPie(solidBrush7, rectangle2, (float)(240 + double0), 30f);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(240 + double0), 30f);
                                    e.Graphics.FillPie(solidBrush5, rectangle2, (float)(270 + double0), 30f);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(270 + double0), 30f);
                                    e.Graphics.FillPie(solidBrush6, rectangle2, (float)(300 + double0), 30f);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(300 + double0), 30f);
                                    e.Graphics.FillPie(solidBrush7, rectangle2, (float)(330 + double0), 30f);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(330 + double0), 30f);
                                    solidBrush7.Dispose();
                                    solidBrush6.Dispose();
                                    solidBrush5.Dispose();
                                }
                            }
                            else if (this._IndicatorType == DAS_ProcessIndicatorType.PIT_Rotation3)
                            {
                                GraphicsPath graphicsPath2 = new GraphicsPath();
                                graphicsPath2.AddEllipse(rectangle2);
                                graphicsPath2.AddEllipse(rectangle2.Left + this._IndicatorSize + 4, rectangle2.Top + this._IndicatorSize + 4, rectangle2.Width - 2 * (this._IndicatorSize + 4), rectangle2.Height - 2 * (this._IndicatorSize + 4));
                                SolidBrush solidBrush8 = new SolidBrush(this._IndicatorColor2);
                                e.Graphics.FillPath(solidBrush8, graphicsPath2);
                                graphicsPath2.Reset();
                                solidBrush8.Dispose();
                                graphicsPath2.AddEllipse(rectangle2);
                                this.method_0(e.Graphics, graphicsPath2, false);
                                graphicsPath2.Reset();
                                graphicsPath2.AddEllipse(rectangle2.Left + this._IndicatorSize + 4, rectangle2.Top + this._IndicatorSize + 4, rectangle2.Width - 2 * (this._IndicatorSize + 4), rectangle2.Height - 2 * (this._IndicatorSize + 4));
                                this.method_0(e.Graphics, graphicsPath2, true);
                                graphicsPath2.Dispose();
                                double num1 = double0 * 3.14159265358979 / 180;
                                RectangleF rectangleF1 = new RectangleF()
                                {
                                    X = (float)((double)((rectangle2.Left + rectangle2.Right) / 2) + (double)(rectangle2.Width - 4 - this._IndicatorSize) * Math.Cos(num1) * 0.5) - (float)(this._IndicatorSize / 2),
                                    Y = (float)((double)((rectangle2.Top + rectangle2.Bottom) / 2) + (double)(rectangle2.Height - 4 - this._IndicatorSize) * Math.Sin(num1) * 0.5) - (float)(this._IndicatorSize / 2),
                                    Width = (float)this._IndicatorSize,
                                    Height = (float)this._IndicatorSize
                                };
                                if (this._Gradient)
                                {
                                    Rectangle rectangle3 = new Rectangle((int)rectangleF1.Left, (int)rectangleF1.Top, (int)rectangleF1.Width, (int)rectangleF1.Height);
                                    GraphicsPath graphicsPath3 = new GraphicsPath();
                                    graphicsPath3.AddEllipse(rectangle3);
                                    this.class0_0.method_3(e.Graphics, rectangle3, DAS_ShapeStyle.SS_Circle, graphicsPath3, this._IndicatorColor, this._IndicatorGradientColor, this._IndicatorGradientType, this._IndicatorGradientAngle, this._IndicatorGradientRate, 0, 0, this._IndicatorShinePosition);
                                    graphicsPath3.Dispose();
                                }
                                else
                                {
                                    solidBrush8 = new SolidBrush(this._IndicatorColor);
                                    e.Graphics.FillEllipse(solidBrush8, rectangleF1);
                                    solidBrush8.Dispose();
                                }
                                e.Graphics.DrawEllipse(pen1, rectangleF1);
                            }
                            else if (this._IndicatorType == DAS_ProcessIndicatorType.PIT_Rotation4)
                            {
                                SolidBrush solidBrush9 = new SolidBrush(this._IndicatorColor2);
                                e.Graphics.FillEllipse(solidBrush9, rectangle2);
                                e.Graphics.DrawEllipse(pen1, rectangle2);
                                solidBrush9.Dispose();
                                if (this._Gradient)
                                {
                                    GraphicsPath graphicsPath4 = new GraphicsPath();
                                    graphicsPath4.AddPie(rectangle2, (float)(double0 - 15), 30f);
                                    this.class0_0.method_3(e.Graphics, rectangle2, DAS_ShapeStyle.SS_Circle, graphicsPath4, this._IndicatorColor, this._IndicatorGradientColor, this._IndicatorGradientType, this._IndicatorGradientAngle, this._IndicatorGradientRate, 0, 0, this._IndicatorShinePosition);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(double0 - 15), 30f);
                                    graphicsPath4.Reset();
                                    graphicsPath4.AddPie(rectangle2, (float)(75 + double0), 30f);
                                    this.class0_0.method_3(e.Graphics, rectangle2, DAS_ShapeStyle.SS_Circle, graphicsPath4, this._IndicatorColor, this._IndicatorGradientColor, this._IndicatorGradientType, this._IndicatorGradientAngle, this._IndicatorGradientRate, 0, 0, this._IndicatorShinePosition);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(75 + double0), 30f);
                                    graphicsPath4.Reset();
                                    graphicsPath4.AddPie(rectangle2, (float)(165 + double0), 30f);
                                    this.class0_0.method_3(e.Graphics, rectangle2, DAS_ShapeStyle.SS_Circle, graphicsPath4, this._IndicatorColor, this._IndicatorGradientColor, this._IndicatorGradientType, this._IndicatorGradientAngle, this._IndicatorGradientRate, 0, 0, this._IndicatorShinePosition);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(165 + double0), 30f);
                                    graphicsPath4.Reset();
                                    graphicsPath4.AddPie(rectangle2, (float)(255 + double0), 30f);
                                    this.class0_0.method_3(e.Graphics, rectangle2, DAS_ShapeStyle.SS_Circle, graphicsPath4, this._IndicatorColor, this._IndicatorGradientColor, this._IndicatorGradientType, this._IndicatorGradientAngle, this._IndicatorGradientRate, 0, 0, this._IndicatorShinePosition);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(255 + double0), 30f);
                                    graphicsPath4.Reset();
                                    graphicsPath4.Dispose();
                                }
                                else
                                {
                                    SolidBrush solidBrush10 = new SolidBrush(this._IndicatorColor);
                                    e.Graphics.FillPie(solidBrush10, rectangle2, (float)(double0 - 15), 30f);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(double0 - 15), 30f);
                                    e.Graphics.FillPie(solidBrush10, rectangle2, (float)(75 + double0), 30f);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(75 + double0), 30f);
                                    e.Graphics.FillPie(solidBrush10, rectangle2, (float)(165 + double0), 30f);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(165 + double0), 30f);
                                    e.Graphics.FillPie(solidBrush10, rectangle2, (float)(255 + double0), 30f);
                                    e.Graphics.DrawPie(pen1, rectangle2, (float)(255 + double0), 30f);
                                    solidBrush10.Dispose();
                                }
                            }
                            else if (this._IndicatorType == DAS_ProcessIndicatorType.PIT_ImageRotation && this._IndicatorImage != null)
                            {
                                e.Graphics.TranslateTransform((float)(rectangle2.Left + rectangle2.Width / 2), (float)(rectangle2.Y + rectangle2.Height / 2));
                                e.Graphics.RotateTransform((float)double0);
                                PointF pointF2 = new PointF()
                                {
                                    X = (float)(-this._IndicatorImage.Width) / 2f,
                                    Y = (float)(-this._IndicatorImage.Height) / 2f
                                };
                                e.Graphics.DrawImage(this._IndicatorImage, pointF2);
                                e.Graphics.ResetTransform();
                            }
                            pen1.Dispose();
                            goto Label0;
                        }
                        else
                        {
                            int int9 = this._IndicatorSize / 5;
                            if (int9 <= 0)
                            {
                                int9 = 1;
                            }
                            Pen pen2 = new Pen(this._IndicatorColor, (float)int9);
                            int num2 = 20;
                            double num3 = 0.314159265358979;
                            double double01 = 6.28318530717959 * this.double_0;
                            PointF[] pointFArray = new PointF[20];
                            if (this._Vertical)
                            {
                                double height2 = (double)(rectangle1.Height - 8) / (double)(num2 - 1);
                                for (i = 0; i < num2; i++)
                                {
                                    pointFArray[i].Y = (float)((double)(rectangle1.Top + 4) + height2 * (double)i);
                                    pointFArray[i].X = (float)((double)(rectangle1.Left + rectangle1.Width / 2) + Math.Sin(num3 * (double)i + double01) * (double)(rectangle1.Width - 8) / 2);
                                }
                            }
                            else
                            {
                                double width1 = (double)(rectangle1.Width - 8) / (double)(num2 - 1);
                                for (i = 0; i < num2; i++)
                                {
                                    pointFArray[i].X = (float)((double)(rectangle1.Left + 4) + width1 * (double)i);
                                    pointFArray[i].Y = (float)((double)(rectangle1.Top + rectangle1.Height / 2) + Math.Sin(num3 * (double)i + double01) * (double)(rectangle1.Height - 8) / 2);
                                }
                            }
                            e.Graphics.DrawCurve(pen2, pointFArray);
                            goto Label0;
                        }
                    }
                Label2:
                    float int91 = (float)((double)(this._IndicatorSize + this._IndicatorGap) * this.double_0);
                    if (!this._Vertical)
                    {
                        if (this._InverseDirection)
                        {
                            right = (int)((float)(rectangle1.Right + this._IndicatorSize + this._IndicatorGap / 2) - int91);
                            num = 0;
                            while (right - this._IndicatorSize > rectangle1.Left - 2)
                            {
                                right = (int)((float)(rectangle1.Right + this._IndicatorSize + this._IndicatorGap / 2) - int91 - (float)((this._IndicatorSize + this._IndicatorGap) * num));
                                Rectangle rectangle4 = new Rectangle(right - this._IndicatorSize, rectangle1.Top + (rectangle1.Height - this._IndicatorSize) / 2, this._IndicatorSize, this._IndicatorSize);
                                this.method_1(e.Graphics, rectangle4, this._IndicatorType);
                                num++;
                            }
                        }
                        else
                        {
                            right = (int)((float)(rectangle1.Left - this._IndicatorSize - this._IndicatorGap / 2) + int91);
                            num = 0;
                            while (right + this._IndicatorSize < rectangle1.Right + 2)
                            {
                                right = (int)((float)(rectangle1.Left - this._IndicatorSize - this._IndicatorGap / 2) + int91 + (float)((this._IndicatorSize + this._IndicatorGap) * num));
                                Rectangle rectangle5 = new Rectangle(right, rectangle1.Top + (rectangle1.Height - this._IndicatorSize) / 2, this._IndicatorSize, this._IndicatorSize);
                                this.method_1(e.Graphics, rectangle5, this._IndicatorType);
                                num++;
                            }
                        }
                    }
                    else if (this._InverseDirection)
                    {
                        right = (int)((float)(rectangle1.Top - this._IndicatorSize - this._IndicatorGap / 2) + int91);
                        num = 0;
                        while (right + this._IndicatorSize < rectangle1.Bottom - 2)
                        {
                            right = (int)((float)(rectangle1.Top - this._IndicatorSize - this._IndicatorGap / 2) + int91 + (float)((this._IndicatorSize + this._IndicatorGap) * num));
                            Rectangle rectangle6 = new Rectangle(rectangle1.Left + (rectangle1.Width - this._IndicatorSize) / 2, right, this._IndicatorSize, this._IndicatorSize);
                            this.method_1(e.Graphics, rectangle6, this._IndicatorType);
                            num++;
                        }
                    }
                    else
                    {
                        right = (int)((float)(rectangle1.Bottom + this._IndicatorSize + this._IndicatorGap / 2) - int91);
                        num = 0;
                        while (right - this._IndicatorSize > rectangle1.Top - 2)
                        {
                            right = (int)((float)(rectangle1.Bottom + this._IndicatorSize + this._IndicatorGap / 2) - int91 - (float)((this._IndicatorSize + this._IndicatorGap) * num));
                            Rectangle rectangle7 = new Rectangle(rectangle1.Left + (rectangle1.Width - this._IndicatorSize) / 2, right - this._IndicatorSize, this._IndicatorSize, this._IndicatorSize);
                            this.method_1(e.Graphics, rectangle7, this._IndicatorType);
                            num++;
                        }
                    }
                Label0:
                    if (this._BorderShape != DAS_BorderStyle.BS_RoundRect)
                    {
                        System.Drawing.Region region = new System.Drawing.Region(base.ClientRectangle);
                        GraphicsPath graphicsPath5 = new GraphicsPath();
                        graphicsPath5.AddRectangle(rectangle1);
                        region.Exclude(graphicsPath5);
                        SolidBrush solidBrush11 = new SolidBrush(base.Parent.BackColor);
                        e.Graphics.FillRegion(solidBrush11, region);
                        solidBrush11.Dispose();
                        graphicsPath5.Dispose();
                        region.Dispose();
                    }
                    else
                    {
                        System.Drawing.Region region1 = new System.Drawing.Region(base.ClientRectangle);
                        GraphicsPath graphicsPath6 = new GraphicsPath();
                        this.class0_0.method_4(graphicsPath6, rectangle1, this._RoundRadius - this._BorderExteriorLength - this._OuterBorderLength - this._MiddleBorderLength - this._InnerBorderLength);
                        region1.Exclude(graphicsPath6);
                        SolidBrush solidBrush12 = new SolidBrush(base.Parent.BackColor);
                        e.Graphics.FillRegion(solidBrush12, region1);
                        solidBrush12.Dispose();
                        graphicsPath6.Dispose();
                        region1.Dispose();
                    }
                    if (this._ControlShadow && this._ShadowDepth > 0 && this._ShadowDepth < rectangle.Width / 3 && this._ShadowDepth < rectangle.Height / 3 && this._BorderGradientType != DAS_BorderGradientStyle.BGS_None)
                    {
                        rectangle.X = rectangle.X + this._ShadowDepth;
                        rectangle.Y = rectangle.Y + this._ShadowDepth;
                        GraphicsPath graphicsPath7 = new GraphicsPath();
                        if (this._BorderShape != DAS_BorderStyle.BS_RoundRect)
                        {
                            this.class0_0.method_4(graphicsPath7, rectangle, 5);
                        }
                        else
                        {
                            this.class0_0.method_4(graphicsPath7, rectangle, this._RoundRadius);
                        }
                        rectangle.X = rectangle.X - this._ShadowDepth;
                        rectangle.Y = rectangle.Y - this._ShadowDepth;
                        GraphicsPath graphicsPath8 = new GraphicsPath();
                        if (this._BorderShape != DAS_BorderStyle.BS_RoundRect)
                        {
                            this.class0_0.method_4(graphicsPath8, rectangle, 5);
                        }
                        else
                        {
                            this.class0_0.method_4(graphicsPath8, rectangle, this._RoundRadius);
                        }
                        System.Drawing.Region region2 = new System.Drawing.Region(graphicsPath7);
                        System.Drawing.Region region3 = new System.Drawing.Region(graphicsPath7);
                        region3.Intersect(graphicsPath8);
                        region2.Xor(region3);
                        e.Graphics.SetClip(region2, CombineMode.Replace);
                        this.class0_0.method_7(e.Graphics, rectangle, graphicsPath8, this._ShadowColor, this._ShadowDepth, this._ShadowRate);
                        e.Graphics.ResetClip();
                        region3.Dispose();
                        region2.Dispose();
                        graphicsPath8.Dispose();
                        graphicsPath7.Dispose();
                    }
                    if (this._BorderShape != DAS_BorderStyle.BS_RoundRect)
                    {
                        this.class0_0.method_0(e.Graphics, rectangle, this._OuterBorderLength, this._OuterBorderDarkColor, this._OuterBorderLightColor, this._MiddleBorderLength, this._MiddleBorderColor, this._InnerBorderLength, this._InnerBorderDarkColor, this._InnerBorderLightColor, this._BorderExteriorLength, this._BorderExteriorColor, this._BorderGradientType, this._BorderGradientAngle, this._BorderGradientRate, this._BorderGradientLightPos1, this._BorderGradientLightPos2, this._BorderLightIntermediateBrightness);
                    }
                    else
                    {
                        this.class0_0.method_2(e.Graphics, rectangle, this._RoundRadius, this._OuterBorderLength, this._OuterBorderDarkColor, this._OuterBorderLightColor, this._MiddleBorderLength, this._MiddleBorderColor, this._InnerBorderLength, this._InnerBorderDarkColor, this._InnerBorderLightColor, this._BorderExteriorLength, this._BorderExteriorColor, this._BorderGradientType, (long)this._BorderGradientAngle, this._BorderGradientRate, this._BorderGradientLightPos1, this._BorderGradientLightPos2, this._BorderLightIntermediateBrightness);
                    }

                }
            }
            catch (ApplicationException applicationException)
            {
                MessageBox.Show(applicationException.ToString());
            }
        }



        private void timer_1_Tick(object sender, EventArgs e)
        {
            this.double_0 += (double)this._UpdatePercentage;
            if (this.double_0 >= 1)
            {
                this.double_0 = 0;
            }
            base.Invalidate();
        }

        private string OriginalText;
        #endregion
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
