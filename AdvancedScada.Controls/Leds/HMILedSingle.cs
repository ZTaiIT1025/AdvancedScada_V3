
using AdvancedScada.Controls;
using AdvancedScada.Controls.DialogEditor;
using AdvancedScada.Controls.Enum;
using AdvancedScada.Controls.Leds.DrawAll;
using AdvancedScada.Controls.Licenses;
using AdvancedScada.Controls.Motor;
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

namespace AdvancedScada.Controls.Leds
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(HMILedSingle), "HMI7Segment.ico")]
    [Designer(typeof(LedSingleControlDesigner))]
    public partial class HMILedSingle : Control
    {




        #region MyRegion




        private int m_BorderExteriorLength;

        private Color m_BorderExteriorColor = Color.Blue;

        private int m_OuterBorderLength = 5;

        private int m_InnerBorderLength = 5;

        private Color m_OuterBorderDarkColor = Color.DimGray;

        private Color m_OuterBorderLightColor = Color.White;

        private Color m_InnerBorderDarkColor = Color.DimGray;

        private Color m_InnerBorderLightColor = Color.White;

        private int m_RoundRadius = 30;

        private int m_MiddleBorderLength;

        private Color m_MiddleBorderColor = Color.Gray;

        private DAS_BorderGradientStyle m_BorderGradientType = DAS_BorderGradientStyle.BGS_Path;

        private int m_BorderGradientAngle = 225;

        private float m_BorderGradientRate = 0.5f;

        private float m_BorderGradientLightPos1 = 1f;

        private float m_BorderGradientLightPos2 = -1f;

        private float m_BorderLightIntermediateBrightness;

        private DAS_ShapeStyle m_Shape = DAS_ShapeStyle.SS_RoundRect;

        private bool m_Value = true;

        private DAS_TextPosStyle m_TextPosition;

        private bool m_TextVisible;

        private float m_GradientRate = 0.6f;

        private int m_GradientAngle = 225;

        private DAS_BkGradientStyle m_GradientType = DAS_BkGradientStyle.BKGS_Shine;

        private float m_ShinePosition = 0.5f;

        private Color m_OnColor = Color.Lime;

        private Color m_OffColor = Color.FromArgb(0, 64, 0);

        private Color m_OnGradientColor = Color.White;

        private Color m_OffGradientColor = Color.Gray;

        private int m_ArrowWidth = 20;

        private bool m_IndicatorAutoSize = true;

        private int m_IndicatorWidth = 50;

        private int m_IndicatorHeight = 50;

        #endregion
        #region MyRegion


        [Category("General")]
        [DefaultValue("20")]
        [Description("Specify the shape width  of the indicator")]
        public int ArrowWidth
        {
            get
            {
                return this.m_ArrowWidth;
            }
            set
            {
                if (value >= 0)
                {
                    this.m_ArrowWidth = value;
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
                return this.m_BorderExteriorColor;
            }
            set
            {
                this.m_BorderExteriorColor = value;
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
                return this.m_BorderExteriorLength;
            }
            set
            {
                if (value >= 0)
                {
                    this.m_BorderExteriorLength = value;
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
                return this.m_BorderGradientAngle;
            }
            set
            {
                this.m_BorderGradientAngle = value;
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
                return this.m_BorderGradientLightPos1;
            }
            set
            {
                if (value <= 1f || (double)value >= 0)
                {
                    this.m_BorderGradientLightPos1 = value;
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
                return this.m_BorderGradientLightPos2;
            }
            set
            {
                if (value <= 1f || (double)value >= -1)
                {
                    this.m_BorderGradientLightPos2 = value;
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
                return this.m_BorderGradientRate;
            }
            set
            {
                if (value <= 1f || (double)value >= 0)
                {
                    this.m_BorderGradientRate = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Border Gradient")]
        [DefaultValue("BGS_Path")]
        [Description("Get/Set which border gradient style is used to draw the border of control")]
        public DAS_BorderGradientStyle BorderGradientType
        {
            get
            {
                return this.m_BorderGradientType;
            }
            set
            {
                this.m_BorderGradientType = value;
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
                return this.m_BorderLightIntermediateBrightness;
            }
            set
            {
                if (value <= 1f || (double)value >= 0)
                {
                    this.m_BorderLightIntermediateBrightness = value;
                    base.Invalidate();
                }
            }
        }

        [Category("General")]
        [DefaultValue("225")]
        [Description("Get/Set gradient angle")]
        public int GradientAngle
        {
            get
            {
                return this.m_GradientAngle;
            }
            set
            {
                this.m_GradientAngle = value;
                base.Invalidate();
            }
        }

        [Category("General")]
        [DefaultValue("0.6")]
        [Description("Get/Set gradient rate of the indicator")]
        public float GradientRate
        {
            get
            {
                return this.m_GradientRate;
            }
            set
            {
                if (value <= 1f || (double)value >= 0)
                {
                    this.m_GradientRate = value;
                    base.Invalidate();
                }
            }
        }

        [Category("General")]
        [DefaultValue("BKGS_Shine")]
        [Description("Get/Set gradient Type")]
        public DAS_BkGradientStyle GradientType
        {
            get
            {
                return this.m_GradientType;
            }
            set
            {
                this.m_GradientType = value;
                base.Invalidate();
            }
        }

        [Category("General")]
        [DefaultValue("true")]
        [Description("Specify whether the indicator size can be automatically resize to the control size when the text is invisible")]
        public bool IndicatorAutoSize
        {
            get
            {
                return this.m_IndicatorAutoSize;
            }
            set
            {
                this.m_IndicatorAutoSize = value;
                base.Invalidate();
            }
        }

        [Category("General")]
        [DefaultValue("50")]
        [Description("Set/Get the indicator height ")]
        public int IndicatorHeight
        {
            get
            {
                return this.m_IndicatorHeight;
            }
            set
            {
                if (value >= 0)
                {
                    this.m_IndicatorHeight = value;
                    base.Invalidate();
                }
            }
        }

        [Category("General")]
        [DefaultValue("50")]
        [Description("Set/Get the indicator width ")]
        public int IndicatorWidth
        {
            get
            {
                return this.m_IndicatorWidth;
            }
            set
            {
                if (value >= 0)
                {
                    this.m_IndicatorWidth = value;
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
                return this.m_InnerBorderDarkColor;
            }
            set
            {
                this.m_InnerBorderDarkColor = value;
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
                return this.m_InnerBorderLength;
            }
            set
            {
                if (value >= 0)
                {
                    this.m_InnerBorderLength = value;
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
                return this.m_InnerBorderLightColor;
            }
            set
            {
                this.m_InnerBorderLightColor = value;
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
                return this.m_MiddleBorderColor;
            }
            set
            {
                this.m_MiddleBorderColor = value;
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
                return this.m_MiddleBorderLength;
            }
            set
            {
                if (value >= 0)
                {
                    this.m_MiddleBorderLength = value;
                    base.Invalidate();
                }
            }
        }

        [Category("General")]
        [DefaultValue("Color.FromArgb(0, 64, 0)")]
        [Description("Specify the color of indicator when Value=false")]
        public Color OffColor
        {
            get
            {
                return this.m_OffColor;
            }
            set
            {
                this.m_OffColor = value;
                base.Invalidate();
            }
        }

        [Category("General")]
        [DefaultValue("Color.Gray")]
        [Description("Specify the Gradient Color of indicator when Value=false")]
        public Color OffGradientColor
        {
            get
            {
                return this.m_OffGradientColor;
            }
            set
            {
                this.m_OffGradientColor = value;
                base.Invalidate();
            }
        }

        [Category("General")]
        [DefaultValue("Color.Lime")]
        [Description("Specify the Gradient color of indicator when Value=true")]
        public Color OnColor
        {
            get
            {
                return this.m_OnColor;
            }
            set
            {
                this.m_OnColor = value;
                base.Invalidate();
            }
        }

        [Category("General")]
        [DefaultValue("Color.White")]
        [Description("Specify the Gradient Color of indicator when Value=true")]
        public Color OnGradientColor
        {
            get
            {
                return this.m_OnGradientColor;
            }
            set
            {
                this.m_OnGradientColor = value;
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
                return this.m_OuterBorderDarkColor;
            }
            set
            {
                this.m_OuterBorderDarkColor = value;
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
                return this.m_OuterBorderLength;
            }
            set
            {
                if (value >= 0)
                {
                    this.m_OuterBorderLength = value;
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
                return this.m_OuterBorderLightColor;
            }
            set
            {
                this.m_OuterBorderLightColor = value;
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
                return this.m_RoundRadius;
            }
            set
            {
                if (value >= 0)
                {
                    this.m_RoundRadius = value;
                    base.Invalidate();
                }
            }
        }

        [Category("General")]
        [DefaultValue("SS_RoundRect")]
        [Description("Get/Set the indicator shape")]
        public DAS_ShapeStyle Shape
        {
            get
            {
                return this.m_Shape;
            }
            set
            {
                this.m_Shape = value;
                base.Invalidate();
            }
        }

        [Category("General")]
        [DefaultValue("0.5")]
        [Description("Get/Set the shine position of the background gradient rendering")]
        public float ShinePosition
        {
            get
            {
                return this.m_ShinePosition;
            }
            set
            {
                if (value <= 1f || (double)value >= 0)
                {
                    this.m_ShinePosition = value;
                    base.Invalidate();
                }
            }
        }

        [Category("General")]
        [DefaultValue("DAS_TextPosStyle.TPS_Left")]
        [Description("Get/Set the text position")]
        public DAS_TextPosStyle TextPosition
        {
            get
            {
                return this.m_TextPosition;
            }
            set
            {
                this.m_TextPosition = value;
                base.Invalidate();
            }
        }

        [Category("General")]
        [DefaultValue("false")]
        [Description("Get/Set the visibility of the text ")]
        public bool TextVisible
        {
            get
            {
                return this.m_TextVisible;
            }
            set
            {
                this.m_TextVisible = value;
                base.Invalidate();
            }
        }

        [Category("General")]
        [DefaultValue("true")]
        [Description("Get/Set the value of the indicator")]
        public bool Value
        {
            get
            {
                return this.m_Value;
            }
            set
            {
                this.m_Value = value;
                base.Invalidate();
            }
        }
        #endregion
        #region MyRegion


        public HMILedSingle()
        {

            base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            base.SetStyle(ControlStyles.Opaque, true);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

        }


        protected override void Dispose(bool bool_4)
        {

            base.Dispose(bool_4);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                base.OnPaint(e);
                if (base.ClientRectangle.Width - 2 * (this.m_BorderExteriorLength + this.m_OuterBorderLength + this.m_MiddleBorderLength + this.m_InnerBorderLength) > 0 && base.ClientRectangle.Height - 2 * (this.m_BorderExteriorLength + this.m_OuterBorderLength + this.m_MiddleBorderLength + this.m_InnerBorderLength) > 0)
                {
                    DrawGraphics _DrawGraphics = new DrawGraphics();
                    int left = base.ClientRectangle.Left;
                    int top = base.ClientRectangle.Top;
                    Rectangle clientRectangle = base.ClientRectangle;
                    Rectangle rectangle = base.ClientRectangle;
                    Rectangle width = new Rectangle(left, top, clientRectangle.Width - 1, rectangle.Height - 1);
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                    SolidBrush solidBrush = new SolidBrush(base.Parent.BackColor);
                    e.Graphics.FillRectangle(solidBrush, base.ClientRectangle);
                    Pen pen = new Pen(solidBrush);
                    e.Graphics.DrawRectangle(pen, base.ClientRectangle);
                    pen.Dispose();
                    solidBrush.Dispose();
                    StringFormat stringFormat = new StringFormat()
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    if (this.m_TextVisible && this.Text != string.Empty || !this.m_IndicatorAutoSize)
                    {
                        int m_IndicatorWidth2 = this.m_IndicatorWidth;
                        int m_IndicatorHeight2 = this.m_IndicatorHeight;
                        if (m_IndicatorWidth2 > width.Width)
                        {
                            m_IndicatorWidth2 = width.Width;
                        }
                        if (m_IndicatorHeight2 > width.Height)
                        {
                            m_IndicatorHeight2 = width.Height;
                        }
                        width.Width = m_IndicatorWidth2;
                        width.Height = m_IndicatorHeight2;
                        if (this.m_TextPosition == DAS_TextPosStyle.TPS_Left)
                        {
                            int x_ClientRectangle = base.ClientRectangle.X;
                            Rectangle clientRectangle1 = base.ClientRectangle;
                            width.X = x_ClientRectangle + clientRectangle1.Width - 1 - m_IndicatorWidth2;
                            int y_ClientRectangle = base.ClientRectangle.Y;
                            Rectangle rectangle1 = base.ClientRectangle;
                            width.Y = y_ClientRectangle + (rectangle1.Height - 1 - m_IndicatorHeight2) / 2;
                            stringFormat.Alignment = StringAlignment.Near;
                        }
                        else if (this.m_TextPosition == DAS_TextPosStyle.TPS_Right)
                        {
                            width.X = base.ClientRectangle.X;
                            int num = base.ClientRectangle.Y;
                            Rectangle clientRectangle2 = base.ClientRectangle;
                            width.Y = num + (clientRectangle2.Height - 1 - m_IndicatorHeight2) / 2;
                            stringFormat.Alignment = StringAlignment.Far;
                        }
                        else if (this.m_TextPosition == DAS_TextPosStyle.TPS_Top)
                        {
                            int x1 = base.ClientRectangle.X;
                            Rectangle rectangle2 = base.ClientRectangle;
                            width.X = x1 + (rectangle2.Width - 1 - m_IndicatorWidth2) / 2;
                            int y1 = base.ClientRectangle.Y;
                            Rectangle clientRectangle3 = base.ClientRectangle;
                            width.Y = y1 + (clientRectangle3.Height - 1 - m_IndicatorHeight2);
                            stringFormat.LineAlignment = StringAlignment.Near;
                        }
                        else if (this.m_TextPosition != DAS_TextPosStyle.TPS_Bottom)
                        {
                            int num1 = base.ClientRectangle.X;
                            Rectangle rectangle3 = base.ClientRectangle;
                            width.X = num1 + (rectangle3.Width - 1 - m_IndicatorWidth2) / 2;
                            int y2 = base.ClientRectangle.Y;
                            Rectangle clientRectangle4 = base.ClientRectangle;
                            width.Y = y2 + (clientRectangle4.Height - 1 - m_IndicatorHeight2) / 2;
                        }
                        else
                        {
                            int x2 = base.ClientRectangle.X;
                            Rectangle rectangle4 = base.ClientRectangle;
                            width.X = x2 + (rectangle4.Width - 1 - m_IndicatorWidth2) / 2;
                            width.Y = base.ClientRectangle.Y;
                            stringFormat.LineAlignment = StringAlignment.Far;
                        }
                    }
                    Rectangle rectangle5 = new Rectangle(width.Left + this.m_BorderExteriorLength + this.m_OuterBorderLength + this.m_MiddleBorderLength + this.m_InnerBorderLength - 1, width.Top + this.m_BorderExteriorLength + this.m_OuterBorderLength + this.m_MiddleBorderLength + this.m_InnerBorderLength - 1, width.Width - 2 * (this.m_BorderExteriorLength + this.m_OuterBorderLength + this.m_MiddleBorderLength + this.m_InnerBorderLength - 1), width.Height - 2 * (this.m_BorderExteriorLength + this.m_OuterBorderLength + this.m_MiddleBorderLength + this.m_InnerBorderLength - 1));
                    GraphicsPath graphicsPath = null;
                    if (this.m_Shape != DAS_ShapeStyle.SS_Rect && this.m_Shape != DAS_ShapeStyle.SS_RoundRect && this.m_Shape != DAS_ShapeStyle.SS_Circle)
                    {
                        graphicsPath = new GraphicsPath();
                        _DrawGraphics.method_6(graphicsPath, width, this.m_Shape, this.m_ArrowWidth + this.m_BorderExteriorLength + this.m_OuterBorderLength + this.m_MiddleBorderLength + this.m_InnerBorderLength, this.m_BorderExteriorLength + this.m_OuterBorderLength + this.m_MiddleBorderLength + this.m_InnerBorderLength);
                    }
                    if (!this.m_Value)
                    {
                        _DrawGraphics.SetValue(e.Graphics, rectangle5, this.m_Shape, graphicsPath, this.m_OffColor, this.m_OffGradientColor, this.m_GradientType, this.m_GradientAngle, this.m_GradientRate, this.m_RoundRadius - this.m_BorderExteriorLength - this.m_OuterBorderLength - this.m_MiddleBorderLength - this.m_InnerBorderLength, this.m_ArrowWidth, this.m_ShinePosition);
                    }
                    else
                    {
                        _DrawGraphics.SetValue(e.Graphics, rectangle5, this.m_Shape, graphicsPath, this.m_OnColor, this.m_OnGradientColor, this.m_GradientType, this.m_GradientAngle, this.m_GradientRate, this.m_RoundRadius - this.m_BorderExteriorLength - this.m_OuterBorderLength - this.m_MiddleBorderLength - this.m_InnerBorderLength, this.m_ArrowWidth, this.m_ShinePosition);
                    }
                    if (graphicsPath != null)
                    {
                        graphicsPath.Dispose();
                    }
                    if (this.m_Shape == DAS_ShapeStyle.SS_Rect)
                    {
                        _DrawGraphics.SetRect(e.Graphics, width, this.m_OuterBorderLength, this.m_OuterBorderDarkColor, this.m_OuterBorderLightColor, this.m_MiddleBorderLength, this.m_MiddleBorderColor, this.m_InnerBorderLength, this.m_InnerBorderDarkColor, this.m_InnerBorderLightColor, this.m_BorderExteriorLength, this.m_BorderExteriorColor, this.m_BorderGradientType, this.m_BorderGradientAngle, this.m_BorderGradientRate, this.m_BorderGradientLightPos1, this.m_BorderGradientLightPos2, this.m_BorderLightIntermediateBrightness);
                    }
                    else if (this.m_Shape == DAS_ShapeStyle.SS_RoundRect)
                    {
                        System.Drawing.Region region = new System.Drawing.Region(base.ClientRectangle);
                        GraphicsPath graphicsPath1 = new GraphicsPath();
                        _DrawGraphics.SetRoundRect(graphicsPath1, rectangle5, this.m_RoundRadius - this.m_BorderExteriorLength - this.m_OuterBorderLength - this.m_MiddleBorderLength - this.m_InnerBorderLength);
                        region.Exclude(graphicsPath1);
                        SolidBrush solidBrush1 = new SolidBrush(base.Parent.BackColor);
                        e.Graphics.FillRegion(solidBrush1, region);
                        solidBrush1.Dispose();
                        graphicsPath1.Dispose();
                        region.Dispose();
                        _DrawGraphics.SetRoundRect2(e.Graphics, width, this.m_RoundRadius, this.m_OuterBorderLength, this.m_OuterBorderDarkColor, this.m_OuterBorderLightColor, this.m_MiddleBorderLength, this.m_MiddleBorderColor, this.m_InnerBorderLength, this.m_InnerBorderDarkColor, this.m_InnerBorderLightColor, this.m_BorderExteriorLength, this.m_BorderExteriorColor, this.m_BorderGradientType, (long)this.m_BorderGradientAngle, this.m_BorderGradientRate, this.m_BorderGradientLightPos1, this.m_BorderGradientLightPos2, this.m_BorderLightIntermediateBrightness);
                    }
                    else if (this.m_Shape != DAS_ShapeStyle.SS_Circle)
                    {
                        _DrawGraphics.SetArrow(e.Graphics, width, this.m_Shape, this.m_RoundRadius, this.m_ArrowWidth, this.m_OuterBorderLength, this.m_OuterBorderDarkColor, this.m_OuterBorderLightColor, this.m_MiddleBorderLength, this.m_MiddleBorderColor, this.m_InnerBorderLength, this.m_InnerBorderDarkColor, this.m_InnerBorderLightColor, this.m_BorderExteriorLength, this.m_BorderExteriorColor, this.m_BorderGradientType, (long)this.m_BorderGradientAngle, this.m_BorderGradientRate, this.m_BorderGradientLightPos1, this.m_BorderGradientLightPos2, this.m_BorderLightIntermediateBrightness);
                    }
                    else
                    {
                        System.Drawing.Region region1 = new System.Drawing.Region(base.ClientRectangle);
                        GraphicsPath graphicsPath2 = new GraphicsPath();
                        graphicsPath2.AddEllipse(rectangle5);
                        region1.Exclude(graphicsPath2);
                        SolidBrush solidBrush2 = new SolidBrush(base.Parent.BackColor);
                        e.Graphics.FillRegion(solidBrush2, region1);
                        solidBrush2.Dispose();
                        graphicsPath2.Dispose();
                        region1.Dispose();
                        _DrawGraphics.SetCircle(e.Graphics, width, this.m_OuterBorderLength, this.m_OuterBorderDarkColor, this.m_OuterBorderLightColor, this.m_MiddleBorderLength, this.m_MiddleBorderColor, this.m_InnerBorderLength, this.m_InnerBorderDarkColor, this.m_InnerBorderLightColor, this.m_BorderExteriorLength, this.m_BorderExteriorColor, this.m_BorderGradientType, (long)this.m_BorderGradientAngle, this.m_BorderGradientRate, this.m_BorderGradientLightPos1, this.m_BorderGradientLightPos2, this.m_BorderLightIntermediateBrightness);
                    }
                    if (this.m_TextVisible && this.Text != string.Empty)
                    {
                        SolidBrush solidBrush3 = new SolidBrush(this.ForeColor);
                        e.Graphics.DrawString(this.Text, this.Font, solidBrush3, base.ClientRectangle, stringFormat);
                        solidBrush3.Dispose();
                    }

                }
            }
            catch (ApplicationException applicationException)
            {
                MessageBox.Show(applicationException.ToString());
            }
        }


        #endregion

        public bool HoldTimeMet;
        private int m_MaximumHoldTime = 3000;
        private int m_MinimumHoldTime = 500;
        private OutputType m_OutputType = OutputType.MomentarySet;

        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string m_PLCAddressClick = string.Empty;


        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string m_PLCAddressText = string.Empty;

        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string m_PLCAddressValue = string.Empty;

        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string m_PLCAddressVisible = string.Empty;

        //**********************************************************************
        //* If output type is set to write value, then write this value to PLC
        //**********************************************************************

        //*****************************************
        //* Property - Hold time before bit reset
        //*****************************************
        private readonly Timer MaxHoldTimer = new Timer();

        //*****************************************
        //* Property - Hold time before bit reset
        //*****************************************
        private readonly Timer MinHoldTimer = new Timer();
        private readonly bool MouseIsDown = false;


        //***************************************
        //* Call backs for returned data
        //***************************************
        private string OriginalText;


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

        [Category("PLC Properties")]
        [Editor(typeof(TestDialogEditor), typeof(UITypeEditor))]
        public string PLCAddressClick
        {
            get { return m_PLCAddressClick; }
            set
            {
                if (m_PLCAddressClick != value) m_PLCAddressClick = value;
            }
        }

        public OutputType OutputType
        {
            get { return m_OutputType; }
            set { m_OutputType = value; }
        }
        private string m_LocationDialog;
        public string LocationDialog
        {
            get { return m_LocationDialog; }
            set { m_LocationDialog = value; }
        }
        [DefaultValue(false)]
        public bool SuppressErrorDisplay { get; set; }

        [Category("PLC Properties")]
        public int MinimumHoldTime
        {
            get { return m_MinimumHoldTime; }
            set
            {
                m_MinimumHoldTime = value;
                if (value > 0) MinHoldTimer.Interval = value;
            }
        }

        [Category("PLC Properties")]
        public int MaximumHoldTime
        {
            get { return m_MaximumHoldTime; }
            set
            {
                m_MaximumHoldTime = value;
                if (value > 0) MaxHoldTimer.Interval = value;
            }
        }

        [Category("PLC Properties")]
        public int ValueToWrite { get; set; }


        private void ReleaseValue()
        {
            try
            {
                switch (OutputType)
                {
                    case OutputType.MomentarySet:
                        WCFChannelFactory.Write(PLCAddressClick, Convert.ToString(false));
                        break;
                    case OutputType.MomentaryReset:
                        WCFChannelFactory.Write(PLCAddressClick, Convert.ToString(true));
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HoldTimer_Tick(object sender, EventArgs e)
        {
            MinHoldTimer.Enabled = false;
            HoldTimeMet = true;
            if (!MouseIsDown) ReleaseValue();
        }

        private void MaxHoldTimer_Tick(object sender, EventArgs e)
        {
            MaxHoldTimer.Enabled = false;
            ReleaseValue();
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);


            if (!string.IsNullOrWhiteSpace(m_PLCAddressClick) & Enabled && PLCAddressClick != null)
            {
                try
                {
                    switch (OutputType)
                    {
                        case OutputType.MomentarySet:
                            WCFChannelFactory.Write(m_PLCAddressClick, "1");
                            break;
                        case OutputType.MomentaryReset:
                            WCFChannelFactory.Write(m_PLCAddressClick, "0");
                            break;
                        case OutputType.SetTrue:
                            WCFChannelFactory.Write(m_PLCAddressClick, "1");
                            break;
                        case OutputType.SetFalse:
                            WCFChannelFactory.Write(m_PLCAddressClick, "0");
                            break;
                        case OutputType.Toggle:

                            var CurrentValue = Value;
                            if (CurrentValue)
                                WCFChannelFactory.Write(m_PLCAddressClick, "0");
                            else
                                WCFChannelFactory.Write(m_PLCAddressClick, "1");
                            break;
                        case OutputType.ValveWeiCtriDialog:
                            var objValveWeiCtriDialog = new ValveWeiCtriDialog(m_PLCAddressClick);
                            var LocationDialogArrays = LocationDialog.Split(';');
                            objValveWeiCtriDialog.SetDesktopLocation(int.Parse( LocationDialogArrays[0]),int.Parse( LocationDialogArrays[1]));
                            objValveWeiCtriDialog.TopMost = true;
                            objValveWeiCtriDialog.Show();
                            break;
                        default:

                            break;
                    }
                }
                catch (Exception ex)
                {
                    DisplayError("WRITE FAILED!" + ex.Message);
                }

                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (!string.IsNullOrWhiteSpace(m_PLCAddressClick) & Enabled)
            {
                try
                {
                    switch (OutputType)
                    {
                        case OutputType.MomentarySet:
                            WCFChannelFactory.Write(m_PLCAddressClick, "0");
                            break;
                        case OutputType.MomentaryReset:
                            WCFChannelFactory.Write(m_PLCAddressClick, "1");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    DisplayError("WRITE FAILED!" + ex.Message);
                }

                Invalidate();
            }
        }

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
    }

    internal class LedSingleControlDesigner : ControlDesigner
    {
        private DesignerActionListCollection actionLists;

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionLists == null)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new LedSingleControlListItem(this));
                }

                return actionLists;
            }
        }
    }

    internal class LedSingleControlListItem : DesignerActionList
    {
        private readonly HMILedSingle _LedSingleControl;

        public LedSingleControlListItem(LedSingleControlDesigner owner)
            : base(owner.Component)
        {
            _LedSingleControl = (HMILedSingle)owner.Component;
        }

        public DAS_ShapeStyle Shape
        {
            get { return _LedSingleControl.Shape; }
            set { _LedSingleControl.Shape = value; }
        }

        public Color OnColor
        {
            get { return _LedSingleControl.OnColor; }
            set { _LedSingleControl.OnColor = value; }
        }

        public Color OffColor
        {
            get { return _LedSingleControl.OffColor; }
            set { _LedSingleControl.OffColor = value; }
        }


        public string TagName
        {
            get { return _LedSingleControl.PLCAddressValue; }
            set { _LedSingleControl.PLCAddressValue = value; }
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();
            items.Add(new DesignerActionTextItem("HMI Professional Edition", "HMI Professional Edition"));
            items.Add(new DesignerActionMethodItem(this, "ShowTagDesignerForm", "Choote Tag"));
            items.Add(new DesignerActionPropertyItem("Shape", "Shape"));
            items.Add(new DesignerActionPropertyItem("OnColor", "OnColor"));
            items.Add(new DesignerActionPropertyItem("OffColor", "OffColor"));
            items.Add(new DesignerActionPropertyItem("TagName", "TagName"));

            return items;
        }

        public void ShowTagDesignerForm()
        {
            var frm = new MonitorForm(TagName);
            frm.OnTagSelected_Clicked += tagName =>
            {
                var pd = TypeDescriptor.GetProperties(_LedSingleControl)["TagName"];
                pd.SetValue(_LedSingleControl, tagName);
            };
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }
    }
}
