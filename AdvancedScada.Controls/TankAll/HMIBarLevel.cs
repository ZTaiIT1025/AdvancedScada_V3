
using AdvancedScada;
using AdvancedScada.Controls;
using AdvancedScada.Controls.ClassBase;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;

using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvancedScada.Controls.TankAll
{
    public class HMIBarLevel : AnalogMeterBase
    {
        private StringFormat sfCenter;

        private StringFormat sfCenterTop;

        private StringFormat sfLeftCenter;

        private StringFormat sfRightCenter;

        private float VerticalScaledValue;

        private float HorizontalScaledValue;

        private string m_TextSuffix;

        private FlatStyle m_FlatStyle;

        private string m_Format;

        private Brush m_BarFillBrush;

        private Color m_BarContentColor;

        private BarStyle m_FillStyle;

        private Pen m_BorderPen;

        private FillDirectionEnum m_FillDirection;

        public Color BarContentColor
        {
            get
            {
                return this.m_BarContentColor;
            }
            set
            {
                this.m_BarContentColor = value;
                if (this.m_FillStyle != BarStyle.Hatch)
                {
                    this.m_BarFillBrush = new SolidBrush(this.m_BarContentColor);
                }
                else
                {
                    this.m_BarFillBrush = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(240, Math.Max(value.R - 40, 0), Math.Max(value.G - 40, 0), Math.Max(value.B - 40, 0)), value);
                }
                this.Invalidate();
            }
        }

        public Color BorderColor
        {
            get
            {
                return this.m_BorderPen.Color;
            }
            set
            {
                if (this.m_BorderPen != null)
                {
                    this.m_BorderPen.Color = value;
                }
                else
                {
                    this.m_BorderPen = new Pen(value, 1.0F);
                }
                this.CreateStaticImage();
            }
        }

        public FillDirectionEnum FillDirection
        {
            get
            {
                return this.m_FillDirection;
            }
            set
            {
                if (value != this.m_FillDirection)
                {
                    this.m_FillDirection = value;
                    this.Invalidate();
                }
            }
        }

        public BarStyle FillStyle
        {
            get
            {
                return this.m_FillStyle;
            }
            set
            {
                if (this.m_FillStyle != value)
                {
                    this.m_FillStyle = value;
                    if (this.m_FillStyle != BarStyle.Hatch)
                    {
                        this.m_BarFillBrush = new SolidBrush(this.m_BarContentColor);
                    }
                    else
                    {
                        //INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
                        //ORIGINAL LINE: this.m_BarFillBrush = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(240, Math.Max((this.m_BarContentColor.R - 40), 0), Math.Max((this.m_BarContentColor.G - 40), 0), Math.Max((this.m_BarContentColor.B - 40), 0)), this.m_BarContentColor);
                        this.m_BarFillBrush = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(240, Math.Max(this.m_BarContentColor.R - 40, 0), Math.Max(this.m_BarContentColor.G - 40, 0), Math.Max(this.m_BarContentColor.B - 40, 0)), this.m_BarContentColor);
                    }
                    this.Invalidate();
                }
            }
        }

        public FlatStyle FlatStyle
        {
            get
            {
                return this.m_FlatStyle;
            }
            set
            {
                if (this.m_FlatStyle != value)
                {
                    this.m_FlatStyle = value;
                    this.Invalidate();
                }
            }
        }

        public string NumericFormat
        {
            get
            {
                return this.m_Format;
            }
            set
            {
                this.m_Format = value;
            }
        }

        public string TextSuffix
        {
            get
            {
                return this.m_TextSuffix;
            }
            set
            {
                this.m_TextSuffix = value;
            }
        }

        public HMIBarLevel()
        {
            this.sfCenter = new StringFormat();
            this.sfCenterTop = new StringFormat();
            this.sfLeftCenter = new StringFormat();
            this.sfRightCenter = new StringFormat();
            this.m_FillStyle = BarStyle.Hatch;
            this.m_BorderPen = new Pen(Color.Wheat, 1.0F);
            this.m_FillDirection = FillDirectionEnum.Up;
            this.ForeColor = Color.WhiteSmoke;
            this.sfCenterTop = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Near
            };
            this.sfCenter = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            this.sfLeftCenter = new StringFormat()
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            };
            this.sfRightCenter = new StringFormat()
            {
                Alignment = StringAlignment.Far,
                LineAlignment = StringAlignment.Center
            };
            this.m_BarContentColor = Color.Red;
            this.m_BarFillBrush = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.Black, Color.Red);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.CreateStaticImage();
        }

        private void CalculateScaledValue()
        {
            float mMaximum = (float)(1 / (this.m_Maximum - this.m_Minimum) * (this.m_Value * this.ValueScaleFactor - this.m_Minimum));
            //INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
            //ORIGINAL LINE: this.VerticalScaledValue = (float)((this.Height - 2)) * mMaximum;
            this.VerticalScaledValue = (float)(this.Height - 2) * mMaximum;
            //INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
            //ORIGINAL LINE: this.HorizontalScaledValue = (float)((this.Width - 2)) * mMaximum;
            this.HorizontalScaledValue = (float)(this.Width - 2) * mMaximum;
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    if (this.BackBuffer != null)
                    {
                        this.BackBuffer.Dispose();
                    }
                    if (this.m_BarFillBrush != null)
                    {
                        this.m_BarFillBrush.Dispose();
                    }
                    if (this.sfCenter != null)
                    {
                        this.sfCenter.Dispose();
                    }
                    if (this.sfCenterTop != null)
                    {
                        this.sfCenterTop.Dispose();
                    }
                    if (this.sfLeftCenter != null)
                    {
                        this.sfLeftCenter.Dispose();
                    }
                    if (this.sfRightCenter != null)
                    {
                        this.sfRightCenter.Dispose();
                    }
                    if (this.m_BorderPen != null)
                    {
                        this.m_BorderPen.Dispose();
                    }
                    if (this.TextBrush != null)
                    {
                        this.TextBrush.Dispose();
                    }
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            this.CreateStaticImage();
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            if (this.TextBrush != null)
            {
                this.TextBrush.Color = base.ForeColor;
            }
            else
            {
                this.TextBrush = new SolidBrush(base.ForeColor);
            }
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle();
            Rectangle rectangle1 = new Rectangle();
            if (!(this.BackBuffer == null || this.TextBrush == null || this.m_BorderPen == null))
            {
                Graphics graphic = Graphics.FromImage(this.BackBuffer);
                graphic.Clear(base.BackColor);
                if (this.m_BarFillBrush != null)
                {
                    string str = Convert.ToString(this.m_Value * this.m_ValueScaleFactor);
                    if (((this.m_Format == null || string.Compare(this.m_Format, string.Empty) == 0) ? false : true) && !this.DesignMode)
                    {
                        try
                        {
                            this.m_Value.ToString();
                            double mValue = (double)(float)this.m_Value * this.m_ValueScaleFactor;
                            str = mValue.ToString(this.m_Format);
                        }
                        catch (Exception exception)
                        {
                            ProjectData.SetProjectError(exception);
                            str = "Check NumericFormat and variable type";
                            ProjectData.ClearProjectError();
                        }
                    }
                    switch (this.m_FillDirection)
                    {
                        case FillDirectionEnum.Down:
                            graphic.FillRectangle(this.m_BarFillBrush, 1, 1, this.Width, Convert.ToInt32(this.VerticalScaledValue));
                            this.TextRectangle.Y = Convert.ToInt32(Math.Truncate(Math.Round((double)Math.Max(this.VerticalScaledValue - (float)base.FontHeight - 2.0F, 0.0F))));
                            this.TextRectangle.Y = Math.Min(this.TextRectangle.Y, (this.Height - base.FontHeight) - 2);
                            graphic.DrawString(string.Concat(str, this.m_TextSuffix), base.Font, this.TextBrush, this.TextRectangle, this.sfCenterTop);
                            break;
                        case FillDirectionEnum.Left:
                            rectangle = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)Math.Max(2.0F, (float)this.Width - this.HorizontalScaledValue + 2.0F)))), 2, Convert.ToInt32(this.HorizontalScaledValue), this.Height - 4);
                            graphic.FillRectangle(this.m_BarFillBrush, this.Width - Convert.ToInt32(this.HorizontalScaledValue), 0, Convert.ToInt32(this.HorizontalScaledValue), this.Height);
                            if (Convert.ToInt32(Math.Round((double)(graphic.MeasureString(string.Concat(Conversions.ToString(this.m_Value), this.m_TextSuffix), base.Font).Width))) >= Convert.ToInt32(this.HorizontalScaledValue))
                            {
                                string str1 = string.Concat(str, this.m_TextSuffix);
                                Font font_Renamed = base.Font;
                                SolidBrush textBrush_Renamed = this.TextBrush;
                                rectangle1 = new Rectangle(1, 1, this.Width - 2, this.Height - 2);
                                graphic.DrawString(str1, font_Renamed, textBrush_Renamed, rectangle1, this.sfRightCenter);
                            }
                            else
                            {
                                graphic.DrawString(string.Concat(str, this.m_TextSuffix), base.Font, this.TextBrush, rectangle, this.sfLeftCenter);
                            }
                            break;
                        case FillDirectionEnum.Right:
                            rectangle = new Rectangle(2, 2, Convert.ToInt32(this.HorizontalScaledValue), this.Height - 4);
                            if (!(this.m_FlatStyle == FlatStyle.Flat || !ProgressBarRenderer.IsSupported))
                            {
                                ProgressBarRenderer.DrawHorizontalChunks(graphic, rectangle);
                            }
                            else
                            {
                                graphic.FillRectangle(this.m_BarFillBrush, 1, 1, Convert.ToInt32(this.HorizontalScaledValue), this.Height - 2);
                            }
                            if (Convert.ToInt32(Math.Round((double)(graphic.MeasureString(string.Concat(Conversions.ToString(this.m_Value), this.m_TextSuffix), base.Font).Width))) >= Convert.ToInt32(this.HorizontalScaledValue))
                            {
                                string str2 = string.Concat(str, this.m_TextSuffix);
                                Font font1 = base.Font;
                                SolidBrush solidBrush = this.TextBrush;
                                rectangle1 = new Rectangle(1, 1, this.Width - 2, this.Height - 2);
                                graphic.DrawString(str2, font1, solidBrush, rectangle1, this.sfLeftCenter);
                            }
                            else
                            {
                                graphic.DrawString(string.Concat(str, this.m_TextSuffix), base.Font, this.TextBrush, rectangle, this.sfRightCenter);
                            }
                            break;
                        default:
                            rectangle = new Rectangle(1, this.Height - Convert.ToInt32(this.VerticalScaledValue), this.Width, Convert.ToInt32(this.VerticalScaledValue));
                            if (!(this.m_FlatStyle == FlatStyle.Flat || !ProgressBarRenderer.IsSupported))
                            {
                                ProgressBarRenderer.DrawVerticalChunks(graphic, rectangle);
                            }
                            else
                            {
                                graphic.FillRectangle(this.m_BarFillBrush, 1, this.Height - Convert.ToInt32(this.VerticalScaledValue), this.Width, Convert.ToInt32(this.VerticalScaledValue));
                            }
                            this.TextRectangle.Y = Convert.ToInt32(Math.Truncate(Math.Round((double)((float)this.Height - Math.Max(this.VerticalScaledValue, (float)base.FontHeight)))));
                            this.TextRectangle.Y = Math.Max(this.TextRectangle.Y, 0);
                            graphic.DrawString(string.Concat(str, this.m_TextSuffix), base.Font, this.TextBrush, this.TextRectangle, this.sfCenterTop);
                            break;
                    }
                }
                graphic.DrawRectangle(this.m_BorderPen, 0, 0, this.Width - 1, this.Height - 1);
                e.Graphics.DrawImage(this.BackBuffer, 0, 0);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.CalculateScaledValue();
            this.CreateStaticImage();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (this.Parent != null)
            {
                this.Parent.Invalidate();
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.CreateStaticImage();
        }

        protected override void OnValueChanged(EventArgs e)
        {
            base.OnValueChanged(e);
            this.CalculateScaledValue();
            this.Invalidate();
        }

        protected override void CreateStaticImage()
        {
            this.TextRectangle.X = 1;
            this.TextRectangle.Y = 1;
            this.TextRectangle.Width = this.Width - 2;
            this.TextRectangle.Height = base.FontHeight + 4;
            if (this.BackBuffer != null)
            {
                this.BackBuffer.Dispose();
            }
            if (this.Width > 0 && this.Height > 0)
            {
                this.BackBuffer = new Bitmap(this.Width, this.Height);
            }
            this.CalculateScaledValue();
            this.Invalidate();
        }

        public enum BarStyle
        {
            Solid,
            Hatch
        }

        public enum FillDirectionEnum
        {
            Up,
            Down,
            Left,
            Right
        }
    }


}