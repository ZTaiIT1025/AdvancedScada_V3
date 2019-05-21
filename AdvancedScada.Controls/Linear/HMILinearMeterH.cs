using AdvancedScada;
using AdvancedScada.Controls;
using AdvancedScada.Controls.ButtonAll;
using AdvancedScada.Controls.ClassBase;
using AdvancedScada.Controls.Licenses;
using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Client;

using AdvancedScada.Monitor;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Linear
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(HMILinearMeterH), "HMI7Segment.ico")]
    [Designer(typeof(HMILinearMeterHDesigner))]
    public class HMILinearMeterH : LinearMeterBase
    {


        private Rectangle ValueRectangle;

        private SolidBrush ValueBrush;

        private Blend m_blend;

        public HMILinearMeterH()
        {
            this.ValueRectangle = new Rectangle();

            m_blend = new Blend();
            this.ValueRectangle = new Rectangle();
            this.m_blend.Factors = new float[] { 0.5F, 0.85F, 0.2F };
            this.m_blend.Positions = new float[] { 0.0F, 0.3F, 1.0F };
            base.BackColor = Color.FromArgb(255, 255, 255);
            base.ForeColor = Color.Black;


        }


        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            this.CreateStaticImage();
        }



        protected override void OnPaint(PaintEventArgs e)
        {
            string str = null;
            LinearGradientBrush linearGradientBrush = null;
            if (this.BackBuffer != null)
            {
                Graphics graphic = Graphics.FromImage(this.BackBuffer);
                graphic.FillRectangle(Brushes.LightGray, this.BarRectangle);
                graphic.DrawImage(this.StaticImage, 0, 0);
                double num = Math.Max(Math.Min(this.Value, this.m_Maximum / this.m_ValueScaleFactor), this.m_Minimum / this.m_ValueScaleFactor);
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.ValueRectangle.Height = checked(this.BarRectangle.Height - 2);
                this.ValueRectangle.Height = this.BarRectangle.Height - 2;
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.ValueRectangle.Y = checked(this.BarRectangle.Y + 1);
                this.ValueRectangle.Y = this.BarRectangle.Y + 1;
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.ValueRectangle.Width = Convert.ToInt32((num * this.m_ValueScaleFactor - this.m_Minimum) / (this.m_Maximum - this.m_Minimum) * (double)(checked(this.BarRectangle.Width - 2)));
                this.ValueRectangle.Width = Convert.ToInt32((num * this.m_ValueScaleFactor - this.m_Minimum) / (this.m_Maximum - this.m_Minimum) * (double)(this.BarRectangle.Width - 2));
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: int x = checked(checked(this.BarRectangle.X + this.ValueRectangle.Width) + 1);
                int x = (this.BarRectangle.X + this.ValueRectangle.Width) + 1;
                if (this.m_FillType == FillTypes.WideBand)
                {
                    this.ValueRectangle.Width = 12;
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: this.ValueRectangle.X = checked(x - 6);
                    this.ValueRectangle.X = x - 6;
                }
                else if (this.m_FillType != FillTypes.NarrowBand)
                {
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: this.ValueRectangle.X = checked(this.BarRectangle.X + 1);
                    this.ValueRectangle.X = this.BarRectangle.X + 1;
                }
                else
                {
                    this.ValueRectangle.Width = 4;
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: this.ValueRectangle.X = checked(x - 2);
                    this.ValueRectangle.X = x - 2;
                }
                if (this.ValueRectangle.Width > 0 && this.ValueRectangle.Height > 0)
                {
                    if (!(this.m_Value * this.m_ValueScaleFactor >= this.m_TargetValue - this.m_ToleranceMinus && this.m_Value * this.m_ValueScaleFactor <= this.m_TargetValue + this.m_TolerancePlus))
                    {
                        this.ValueBrush.Color = Color.Red;
                        linearGradientBrush = new LinearGradientBrush(this.ValueRectangle, HMIBeveledButtonDisplay.GetRelativeColor(this.m_FillColor, 0.5), HMIBeveledButtonDisplay.GetRelativeColor(this.m_FillColor, 2), 90.0F, false);
                    }
                    else
                    {
                        this.ValueBrush.Color = Color.Green;
                        linearGradientBrush = new LinearGradientBrush(this.ValueRectangle, HMIBeveledButtonDisplay.GetRelativeColor(this.m_FillColorInRange, 0.5), HMIBeveledButtonDisplay.GetRelativeColor(this.m_FillColorInRange, 1.5), 90.0F, false);
                    }
                    Blend blend = new Blend();
                    float[] singleArray = { 0.5F, 0.85F, 0.2F };
                    blend.Factors = singleArray;
                    singleArray = new float[] { 0.0F, 0.3F, 1.0F };
                    blend.Positions = singleArray;
                    linearGradientBrush.Blend = blend;
                    graphic.FillRectangle(linearGradientBrush, this.ValueRectangle);
                }
                if (this.m_FillType != FillTypes.Fill)
                {
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: graphic.DrawLine(Pens.Black, x, this.ValueRectangle.Y, x, checked(checked(this.ValueRectangle.Y + this.ValueRectangle.Height) - 1));
                    graphic.DrawLine(Pens.Black, x, this.ValueRectangle.Y, x, (this.ValueRectangle.Y + this.ValueRectangle.Height) - 1);
                }
                this.sf.LineAlignment = StringAlignment.Center;
                if ((this.m_NumericFormat == null || string.Compare(this.m_NumericFormat, string.Empty) == 0) ? true : false)
                {
                    str = Conversions.ToString(this.m_Value);
                }
                else
                {
                    try
                    {
                        str = this.m_Value.ToString(this.m_NumericFormat);
                    }
                    catch (Exception exception)
                    {
                        ProjectData.SetProjectError(exception);
                        str = "NumericFormat Invalid";
                        ProjectData.ClearProjectError();
                    }
                }
                if (this.m_FillType != FillTypes.Fill)
                {
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: this.TextRectangle.X = checked(checked(this.ValueRectangle.X + this.ValueRectangle.Width) + 1);
                    this.TextRectangle.X = (this.ValueRectangle.X + this.ValueRectangle.Width) + 1;
                    this.TextRectangle.Y = this.BarRectangle.Y;
                    this.TextRectangle.Height = this.BarRectangle.Height;
                    SizeF sizeF = graphic.MeasureString(str, this.Font);
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: this.TextRectangle.Width = checked((int)Math.Round((double)((float)(sizeF.Width + 2f))));
                    this.TextRectangle.Width = Convert.ToInt32(Math.Truncate(Math.Round((double)(sizeF.Width + 2.0F))));
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: if (checked(this.TextRectangle.X + this.TextRectangle.Width) > checked(this.BarRectangle.X + this.BarRectangle.Width) & (double)(checked(this.TextRectangle.X + this.TextRectangle.Width)) <= (double)(checked(this.BarRectangle.X + this.BarRectangle.Width)) + (double)this.ValueRectangle.Width / 2 + 1)
                    if (this.TextRectangle.X + this.TextRectangle.Width > this.BarRectangle.X + this.BarRectangle.Width && (double)(this.TextRectangle.X + this.TextRectangle.Width) <= (double)(this.BarRectangle.X + this.BarRectangle.Width) + (double)this.ValueRectangle.Width / 2 + 1)
                    {
                        //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        //ORIGINAL LINE: this.TextRectangle.X = checked(checked(this.BarRectangle.X + this.BarRectangle.Width) - this.TextRectangle.Width);
                        this.TextRectangle.X = (this.BarRectangle.X + this.BarRectangle.Width) - this.TextRectangle.Width;
                    }
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: if ((double)(checked(this.TextRectangle.X + this.TextRectangle.Width)) > (double)(checked(this.BarRectangle.X + this.BarRectangle.Width)) + (double)this.ValueRectangle.Width / 2 + 1)
                    if ((double)(this.TextRectangle.X + this.TextRectangle.Width) > (double)(this.BarRectangle.X + this.BarRectangle.Width) + (double)this.ValueRectangle.Width / 2 + 1)
                    {
                        //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        //ORIGINAL LINE: this.TextRectangle.X = checked(checked(this.ValueRectangle.X - this.TextRectangle.Width) - 1);
                        this.TextRectangle.X = (this.ValueRectangle.X - this.TextRectangle.Width) - 1;
                    }
                    this.sf.LineAlignment = StringAlignment.Center;
                    this.sf.Alignment = StringAlignment.Center;
                    graphic.DrawString(str, this.Font, this.TextBrush, this.TextRectangle, this.sf);
                }
                else if ((float)this.ValueRectangle.Width <= graphic.MeasureString(str, this.Font).Width)
                {
                    this.sf.Alignment = StringAlignment.Near;
                    graphic.DrawString(str, this.Font, this.TextBrush, this.BarRectangle, this.sf);
                }
                else
                {
                    this.sf.Alignment = StringAlignment.Far;
                    graphic.DrawString(str, this.Font, this.TextBrush, this.ValueRectangle, this.sf);
                }
                e.Graphics.DrawImage(this.BackBuffer, 0, 0);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.CreateStaticImage();
        }

        protected override void OnValueChanged(EventArgs e)
        {
            base.OnValueChanged(e);
            this.Invalidate(this.BarRectangle);
        }

        protected override void CreateStaticImage()
        {
            Rectangle rectangle = new Rectangle();
            int num = 0;
            int num1 = 0;
            int y = 0;
            if (!(this.Width <= 0 && this.Height <= 0))
            {
                this.BackBuffer = new Bitmap(this.Width, this.Height);
                this.StaticImage = new Bitmap(this.Width, this.Height);
                Graphics graphic = Graphics.FromImage(this.StaticImage);
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: graphic.FillRectangle(new SolidBrush(BeveledButtonDisplay.GetRelativeColor(this.m_BorderColor, 1)), checked(this.m_BorderWidth * 2), checked(this.m_BorderWidth * 2), checked(this.Width - checked(this.m_BorderWidth * 4)), checked(this.Height - checked(this.m_BorderWidth * 4)));
                graphic.FillRectangle(new SolidBrush(HMIBeveledButtonDisplay.GetRelativeColor(this.m_BorderColor, 1)), this.m_BorderWidth * 2, this.m_BorderWidth * 2, this.Width - this.m_BorderWidth * 4, this.Height - this.m_BorderWidth * 4);
                HMIBeveledButtonDisplay.Draw3DBorder(this, graphic, this.m_BorderColor, this.m_BorderWidth);
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: graphic.FillRectangle(new SolidBrush(this.BackColor), checked(this.m_BorderWidth * 2), checked(this.m_BorderWidth * 2), checked(this.Width - checked(this.m_BorderWidth * 4)), checked(this.Height - checked(this.m_BorderWidth * 4)));
                graphic.FillRectangle(new SolidBrush(this.BackColor), this.m_BorderWidth * 2, this.m_BorderWidth * 2, this.Width - this.m_BorderWidth * 4, this.Height - this.m_BorderWidth * 4);
                StringFormat stringFormat = new StringFormat();
                if ((this.Text == null || string.Compare(this.Text, string.Empty) == 0) ? false : true)
                {
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: rectangle = new Rectangle(checked(this.m_BorderWidth * 2), checked(checked(this.m_BorderWidth * 2) + 1), checked(checked(this.Width - checked(this.m_BorderWidth * 4)) - 1), checked(checked(this.Height - checked(this.m_BorderWidth * 4)) - 2));
                    rectangle = new Rectangle(this.m_BorderWidth * 2, (this.m_BorderWidth * 2) + 1, (this.Width - this.m_BorderWidth * 4) - 1, (this.Height - this.m_BorderWidth * 4) - 2);
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Near;
                    graphic.DrawString(this.Text, this.Font, this.TextBrush, rectangle, stringFormat);
                }
                SizeF sizeF = graphic.MeasureString(this.Text, this.Font, rectangle.Width);
                byte r = this.ForeColor.R;
                byte g = this.ForeColor.G;
                //INSTANT VB NOTE: The variable foreColor was renamed since Visual Basic does not handle local variables named the same as class members well:
                Color foreColor_Renamed = this.ForeColor;
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: graphic.DrawLine(new Pen(Color.FromArgb(80, (int)r, (int)g, (int)foreColor.B), 2f), (float)(checked(this.m_BorderWidth * 2)), sizeF.Height + (float)(checked(this.m_BorderWidth * 2)) + 2f, (float)(checked(this.Width - checked(this.m_BorderWidth * 2))), sizeF.Height + (float)(checked(this.m_BorderWidth * 2)) + 2f);
                graphic.DrawLine(new Pen(Color.FromArgb(80, (int)r, (int)g, (int)foreColor_Renamed.B), 2.0F), (float)(this.m_BorderWidth * 2), sizeF.Height + (float)(this.m_BorderWidth * 2) + 2.0F, (float)(this.Width - this.m_BorderWidth * 2), sizeF.Height + (float)(this.m_BorderWidth * 2) + 2.0F);
                int num2 = Convert.ToInt32((double)this.Height * 0.12);
                int num3 = Convert.ToInt32((double)this.Height * 0.08);
                Pen pen = new Pen(this.ForeColor, 2.0F);
                Pen pen1 = new Pen(this.ForeColor, 1.0F);
                SizeF sizeF1 = graphic.MeasureString(Conversions.ToString(this.m_Maximum), this.Font);
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: int num4 = checked((int)Math.Round((double)sizeF1.Width));
                int num4 = Convert.ToInt32(Math.Round((double)sizeF1.Width));
                sizeF1 = graphic.MeasureString(Conversions.ToString(this.m_Minimum), this.Font);
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: int num5 = checked((int)Math.Round((double)sizeF1.Width));
                int num5 = Convert.ToInt32(Math.Round((double)sizeF1.Width));
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.BarRectangle = new Rectangle() { X = checked((int)Math.Round((double)num5 / 2 + (double)(checked(this.m_BorderWidth * 2)))), Y = checked((int)Math.Round((double)(sizeF.Height + (float)this.Font.Height + (float)(checked(this.m_BorderWidth * 2)) + (float)num2) + (double)this.Height * 0.1)), Width = checked((int)Math.Round((double)this.Width - (double)num4 / 2 - (double)num5 / 2 - (double)(checked(this.BorderWidth * 4)))), Height = checked((int)Math.Round((double)((float)(checked(this.Height - checked(this.m_BorderWidth * 4))) - sizeF.Height - (float)num2 - (float)this.Font.Height) - (double)this.Height * 0.15)) };
                this.BarRectangle = new Rectangle()
                {
                    X = Convert.ToInt32(Math.Truncate(Math.Round((double)num5 / 2 + (double)(this.m_BorderWidth * 2)))),
                    Y = Convert.ToInt32(Math.Truncate(Math.Round((double)(sizeF.Height + (float)this.Font.Height + (float)(this.m_BorderWidth * 2) + (float)num2) + (double)this.Height * 0.1))),
                    Width = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Width - (double)num4 / 2 - (double)num5 / 2 - (double)(this.BorderWidth * 4)))),
                    Height = Convert.ToInt32(Math.Truncate(Math.Round((double)((float)(this.Height - this.m_BorderWidth * 4) - sizeF.Height - (float)num2 - (float)this.Font.Height) - (double)this.Height * 0.15)))
                };
                graphic.FillRectangle(Brushes.LightGray, this.BarRectangle);
                if (this.m_ShowValidRangeMarker)
                {
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: int xPos = checked(this.ValueToXPos(Math.Max(this.m_TargetValue - this.m_ToleranceMinus, this.m_Minimum)) - this.ValueToXPos(Math.Min(this.m_TargetValue + this.m_TolerancePlus, this.m_Maximum)));
                    int xPos = this.ValueToXPos(Math.Max(this.m_TargetValue - this.m_ToleranceMinus, this.m_Minimum)) - this.ValueToXPos(Math.Min(this.m_TargetValue + this.m_TolerancePlus, this.m_Maximum));
                    if (xPos > 0)
                    {
                        //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        //ORIGINAL LINE: graphic.FillRectangle(new SolidBrush(BeveledButtonDisplay.GetRelativeColor(this.m_FillColorInRange, 0.7)), this.ValueToXPos(Math.Min(this.m_TargetValue + this.m_TolerancePlus, this.m_Maximum)), checked(checked(this.BarRectangle.Y - 2) - num3), xPos, num3);
                        graphic.FillRectangle(new SolidBrush(HMIBeveledButtonDisplay.GetRelativeColor(this.m_FillColorInRange, 0.7)), this.ValueToXPos(Math.Min(this.m_TargetValue + this.m_TolerancePlus, this.m_Maximum)), (this.BarRectangle.Y - 2) - num3, xPos, num3);
                    }
                }
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: Point point = new Point(checked(this.BarRectangle.X + 1), checked(this.BarRectangle.Y - 2));
                Point point = new Point(this.BarRectangle.X + 1, this.BarRectangle.Y - 2);
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: Point point1 = new Point(checked(this.BarRectangle.X + 1), checked(checked(this.BarRectangle.Y - 2) - num2));
                Point point1 = new Point(this.BarRectangle.X + 1, (this.BarRectangle.Y - 2) - num2);
                graphic.DrawLine(pen, point, point1);
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: Rectangle rectangle1 = new Rectangle(checked((int)Math.Round((double)this.BarRectangle.X - (double)num5 / 2)), checked(checked(checked(this.BarRectangle.Y - this.Font.Height) - num2) - 4), checked(num5 + 2), checked(this.Font.Height + 4));
                Rectangle rectangle1 = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)this.BarRectangle.X - (double)num5 / 2))), (this.BarRectangle.Y - this.Font.Height - num2) - 4, num5 + 2, this.Font.Height + 4);
                stringFormat.LineAlignment = StringAlignment.Center;
                stringFormat.Alignment = StringAlignment.Center;
                graphic.DrawString(Conversions.ToString(this.m_Minimum), this.Font, this.TextBrush, rectangle1, stringFormat);
                if (this.m_MajorDivisions > 0)
                {
                    while (num < this.m_MajorDivisions)
                    {
                        //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        //ORIGINAL LINE: num1 = checked((int)Math.Round((double)this.BarRectangle.X + (double)this.BarRectangle.Width / (double)this.m_MajorDivisions * (double)(checked(num + 1)) - 1));
                        num1 = Convert.ToInt32(Math.Truncate(Math.Round((double)this.BarRectangle.X + (double)this.BarRectangle.Width / (double)this.m_MajorDivisions * (double)(num + 1) - 1)));
                        //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        //ORIGINAL LINE: y = checked(this.BarRectangle.Y - 2);
                        y = this.BarRectangle.Y - 2;
                        //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        //ORIGINAL LINE: int num6 = checked(y - num2);
                        int num6 = y - num2;
                        point1 = new Point(num1, y);
                        point = new Point(num1, num6);
                        graphic.DrawLine(pen, point1, point);
                        //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        //ORIGINAL LINE: rectangle1 = new Rectangle(checked(num1 - 20), checked(checked(num6 - this.Font.Height) - 2), 40, checked(this.Font.Height + 2));
                        rectangle1 = new Rectangle(num1 - 20, (num6 - this.Font.Height) - 2, 40, this.Font.Height + 2);
                        //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        //ORIGINAL LINE: graphic.DrawString(Conversions.ToString(this.m_Minimum + (double)(checked(num + 1)) * ((this.m_Maximum - this.m_Minimum) / (double)this.m_MajorDivisions)), this.Font, this.TextBrush, rectangle1, stringFormat);
                        graphic.DrawString(Conversions.ToString(this.m_Minimum + (double)(num + 1) * ((this.m_Maximum - this.m_Minimum) / (double)this.m_MajorDivisions)), this.Font, this.TextBrush, rectangle1, stringFormat);
                        if (this.m_MinorDivisions > 1)
                        {
                            int i = 0;
                            //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                            //ORIGINAL LINE: for (int i = 0; i < checked(this.m_MinorDivisions - 1); i += 1)
                            while (i < this.m_MinorDivisions - 1)
                            {
                                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                                //ORIGINAL LINE: int num7 = checked((int)Math.Round((double)this.BarRectangle.X + (double)this.BarRectangle.Width / (double)(checked(this.m_MajorDivisions * this.m_MinorDivisions)) * (double)(checked(i + 1)) + (double)this.BarRectangle.Width / (double)this.m_MajorDivisions * (double)num - 1));
                                int num7 = Convert.ToInt32(Math.Truncate(Math.Round((double)this.BarRectangle.X + (double)this.BarRectangle.Width / (double)(this.m_MajorDivisions * this.m_MinorDivisions) * (double)(i + 1) + (double)this.BarRectangle.Width / (double)this.m_MajorDivisions * (double)num - 1)));
                                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                                //ORIGINAL LINE: point1 = new Point(num7, checked(this.BarRectangle.Y - 2));
                                point1 = new Point(num7, this.BarRectangle.Y - 2);
                                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                                //ORIGINAL LINE: point = new Point(num7, checked(checked(this.BarRectangle.Y - 2) - num3));
                                point = new Point(num7, (this.BarRectangle.Y - 2) - num3);
                                graphic.DrawLine(pen1, point1, point);
                                i += 1;
                            }
                        }
                        num += 1;
                    }
                    graphic.DrawLine(pen1, Convert.ToInt32(this.BarRectangle.X), y, num1, y);
                }
                this.Invalidate();
            }
        }

        private int ValueToXPos(double value)
        {
            double mMaximum = this.m_Maximum - this.m_Minimum;
            double num = (value - this.m_Minimum) / mMaximum;
            int num1 = Convert.ToInt32(Math.Truncate(Math.Round((double)this.BarRectangle.Width * num)));
            int x = (this.BarRectangle.X + this.BarRectangle.Width) - num1;
            return x;
        }

        #region propartas

        private string _TagName;

        [Category("Link TagName")]
        [Browsable(true)]
        public string TagName
        {
            get { return _TagName; }

            set
            {
                _TagName = value;
                try
                {
                    if (string.IsNullOrEmpty(_TagName) || string.IsNullOrWhiteSpace(_TagName) ||
                        Licenses.LicenseManager.IsInDesignMode) return;
                    var bd = new Binding("Value", TagCollectionClient.Tags[_TagName], "Value", true);
                    if (DataBindings.Count > 0) DataBindings.Clear();
                    DataBindings.Add(bd);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        #endregion
    }

    internal class HMILinearMeterHDesigner : ControlDesigner
    {
        private DesignerActionListCollection actionLists;

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionLists == null)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new HMILinearMeterHListItem(this));
                }

                return actionLists;
            }
        }
    }

    internal class HMILinearMeterHListItem : DesignerActionList
    {
        private readonly HMILinearMeterH _HMILinearMeterH;

        public HMILinearMeterHListItem(HMILinearMeterHDesigner owner)
            : base(owner.Component)
        {
            _HMILinearMeterH = (HMILinearMeterH)owner.Component;
        }


        public string TagName
        {
            get { return _HMILinearMeterH.TagName; }
            set { _HMILinearMeterH.TagName = value; }
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();
            items.Add(new DesignerActionTextItem("HMI Professional Edition", "HMI Professional Edition"));
            items.Add(new DesignerActionMethodItem(this, "ShowTagDesignerForm", "Choote Tag"));
            items.Add(new DesignerActionPropertyItem("TagName", "TagName"));

            return items;
        }

        public void ShowTagDesignerForm()
        {
            var frm = new MonitorForm(TagName);
            frm.OnTagSelected_Clicked += tagName => { SetProperty(_HMILinearMeterH, "TagName", tagName); };
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