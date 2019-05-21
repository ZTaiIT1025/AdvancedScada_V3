
using AdvancedScada;
using AdvancedScada.Controls;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Meter
{
    public class HMIMeter : Control
    {
        private Bitmap StaticImage;

        private Bitmap BaseImage;

        private Bitmap Needle;

        private float Cx;

        private float Cy;

        private int Xoff;

        private int YOff;

        private bool ZeroCentered;

        private float ImageScale;

        private Rectangle TextRectangle;

        private Rectangle[] NumberLocations;

        private StringFormat sfCenter;

        private StringFormat sfCenterBottom;

        private double m_Value;

        private decimal m_Angle;

        private decimal m_ValueScaleFactor;

        private decimal m_MaxValue;

        private decimal m_MinValue;

        private Matrix m;

        private Bitmap _backBuffer;

        private SolidBrush TextBrush;

        private int LastWidth;

        private int LastHeight;

        public decimal MaxValue
        {
            get
            {
                return this.m_MaxValue;
            }
            set
            {
                this.m_MaxValue = value;
                this.Value = this.m_Value;
                this.CalculateAngle();
                this.RefreshImage();
                this.Invalidate();
            }
        }

        public decimal MinValue
        {
            get
            {
                return this.m_MinValue;
            }
            set
            {
                this.m_MinValue = value;
                if (decimal.Compare(this.m_MinValue, this.m_MaxValue) >= 0)
                {
                    this.m_MaxValue = decimal.Add(this.m_MinValue, decimal.One);
                }
                this.MaxValue = this.m_MaxValue;
                this.Value = this.m_Value;
                this.CalculateAngle();
                this.RefreshImage();
                this.Invalidate();
            }
        }

        public double Value
        {
            get
            {
                return this.m_Value;
            }
            set
            {
                if (value != this.m_Value)
                {
                    this.m_Value = Math.Max(Math.Min(value, Convert.ToDouble(decimal.Divide(this.m_MaxValue, this.m_ValueScaleFactor))), Convert.ToDouble(decimal.Divide(this.m_MinValue, this.m_ValueScaleFactor)));
                    this.CalculateAngle();
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: Rectangle rectangle = new Rectangle(0, 0, checked((int)Math.Round((double)this.StaticImage.Width * 0.85)), checked((int)Math.Round((double)this.StaticImage.Height * 0.58)));
                    Rectangle rectangle = new Rectangle(0, 0, Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Width * 0.85))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Height * 0.58))));
                    this.Invalidate(rectangle);
                    this.OnValueChanged(EventArgs.Empty);
                }
            }
        }

        public decimal ValueScaleFactor
        {
            get
            {
                return this.m_ValueScaleFactor;
            }
            set
            {
                this.m_ValueScaleFactor = value;
                value = new decimal(this.m_Value);
                this.CalculateAngle();
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: Rectangle rectangle = new Rectangle(checked((int)Math.Round((double)this.StaticImage.Width * 0.12)), checked((int)Math.Round((double)this.StaticImage.Height * 0.14)), checked((int)Math.Round((double)this.StaticImage.Width * 0.76)), checked((int)Math.Round((double)this.StaticImage.Height * 0.4)));
                Rectangle rectangle = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Width * 0.12))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Height * 0.14))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Width * 0.76))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Height * 0.4))));
                this.Invalidate(rectangle);
            }
        }



        public HMIMeter()
        {

            this.TextRectangle = new Rectangle();
            this.NumberLocations = new Rectangle[7];
            this.sfCenter = new StringFormat();
            this.sfCenterBottom = new StringFormat();
            this.m_Angle = new decimal(6125, 0, 0, false, 4);
            this.m_ValueScaleFactor = decimal.One;
            this.m_MaxValue = new decimal((long)100);
            this.m_MinValue = new decimal();
            this.m = new Matrix();
            this.TextBrush = new SolidBrush(Color.Black);
        }


        private void CalculateAngle()
        {
            if (!this.ZeroCentered)
            {
                this.m_Angle = new decimal((this.m_Value * Convert.ToDouble(this.m_ValueScaleFactor) - Convert.ToDouble(this.m_MinValue)) * (1.25 / Convert.ToDouble(decimal.Subtract(this.m_MaxValue, this.m_MinValue))) * -1 + 0.625);
            }
            else
            {
                this.m_Angle = new decimal((this.m_Value * Convert.ToDouble(this.m_ValueScaleFactor) - Convert.ToDouble(this.m_MinValue)) * (1.5 / Convert.ToDouble(decimal.Subtract(this.m_MaxValue, this.m_MinValue))) * -1 + 0.75);
            }
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    if (this.TextBrush != null)
                    {
                        this.TextBrush.Dispose();
                    }
                    if (this._backBuffer != null)
                    {
                        this._backBuffer.Dispose();
                    }
                    if (this.StaticImage != null)
                    {
                        this.StaticImage.Dispose();
                    }
                    if (this.Needle != null)
                    {
                        this.Needle.Dispose();
                    }
                    if (this.BaseImage != null)
                    {
                        this.BaseImage.Dispose();
                    }
                    this.sfCenter.Dispose();
                    this.sfCenterBottom.Dispose();
                    this.m.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!(this.StaticImage == null || this.BaseImage == null || this.Needle == null))
            {
                if (this._backBuffer == null)
                {
                    this._backBuffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
                }
                Graphics graphic = Graphics.FromImage(this._backBuffer);
                graphic.DrawImageUnscaled(this.StaticImage, 0, 0);
                if ((base.Text == null || string.Compare(base.Text, string.Empty) == 0) ? false : true)
                {
                    if (this.TextBrush.Color != base.ForeColor)
                    {
                        this.TextBrush.Color = base.ForeColor;
                    }
                    graphic.DrawString(base.Text, base.Font, this.TextBrush, this.TextRectangle, this.sfCenterBottom);
                }
                Matrix matrix = this.m;
                float num = (float)(Convert.ToDouble(decimal.Multiply(decimal.Negate(this.m_Angle), new decimal((long)180))) / 3.14159265358979);
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: Point point = new Point(checked((int)Math.Round((double)this.Cx)), checked((int)Math.Round((double)this.Cy)));
                Point point = new Point(Convert.ToInt32(Math.Truncate(Math.Round((double)this.Cx))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.Cy))));
                matrix.RotateAt(num, point);
                graphic.Transform = this.m;
                graphic.DrawImage(this.Needle, this.Xoff, this.YOff);
                this.m.Reset();
                graphic.Transform = this.m;
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: graphic.DrawImageUnscaled(this.BaseImage, 1, checked((int)Math.Round((double)((float)(135f * this.ImageScale)))));
                graphic.DrawImageUnscaled(this.BaseImage, 1, Convert.ToInt32(Math.Truncate(Math.Round((double)(135.0F * this.ImageScale)))));
                e.Graphics.DrawImageUnscaled(this._backBuffer, 0, 0);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            //INSTANT VB NOTE: The variable width was renamed since Visual Basic does not handle local variables named the same as class members well:
            float width_Renamed = (float)((double)Properties.Resources.MeterNoNeedle2.Width / (double)Properties.Resources.MeterNoNeedle2.Height);
            if (this.LastHeight != this.Height | this.LastWidth != this.Width)
            {
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: Size size = new Size(checked((int)Math.Round((double)((float)((float)this.Height * width)))), this.Height);
                //INSTANT VB NOTE: The variable size was renamed since Visual Basic does not handle local variables named the same as class members well:
                Size size_Renamed = new Size(Convert.ToInt32(Math.Truncate(Math.Round((double)((float)this.Height * width_Renamed)))), this.Height);
                this.Size = size_Renamed;
                this.RefreshImage();
                this.LastWidth = this.Width;
                this.LastHeight = this.Height;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (this._backBuffer != null)
            {
                this._backBuffer.Dispose();
                this._backBuffer = null;
            }
            this.RefreshImage();
            base.OnSizeChanged(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Invalidate();
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            EventHandler eventHandler = this.ValueChanged;
            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }

        private void RefreshImage()
        {
            this.ImageScale = (float)((double)this.Width / (double)Properties.Resources.MeterNoNeedle2.Width);
            if (this.ImageScale > 0.0F)
            {
                this.Cx = (float)((double)this.Width / 2);
                this.Cy = (float)((double)this.Height * 0.886);
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.Xoff = checked((int)Math.Round((double)this.Width / 2 - 2));
                this.Xoff = Convert.ToInt32(Math.Round((double)this.Width / 2 - 2));
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.YOff = checked((int)Math.Round((double)((float)(45f * this.ImageScale))));
                this.YOff = Convert.ToInt32(Math.Truncate(Math.Round((double)(45.0F * this.ImageScale))));
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.TextRectangle.Y = checked((int)Math.Round((double)((float)(75f * this.ImageScale))));
                this.TextRectangle.Y = Convert.ToInt32(Math.Truncate(Math.Round((double)(75.0F * this.ImageScale))));
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.TextRectangle.Width = checked((int)Math.Round((double)this.Width * 0.6));
                this.TextRectangle.Width = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Width * 0.6)));
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.TextRectangle.Height = checked((int)Math.Round((double)((float)(50f * this.ImageScale))));
                this.TextRectangle.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)(50.0F * this.ImageScale))));
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.TextRectangle.X = checked((int)Math.Round((double)(checked(this.Width - this.TextRectangle.Width)) / 2));
                this.TextRectangle.X = Convert.ToInt32(Math.Truncate(Math.Round((double)(this.Width - this.TextRectangle.Width) / 2)));
                this.sfCenterBottom.Alignment = StringAlignment.Center;
                this.sfCenterBottom.LineAlignment = StringAlignment.Far;
                if (this.TextBrush == null)
                {
                    this.TextBrush = new SolidBrush(base.ForeColor);
                }
                int num = 0;
                do
                {
                    this.NumberLocations[num] = new Rectangle();
                    num += 1;
                } while (num <= 6);
                if (!this.ZeroCentered)
                {
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: this.NumberLocations[0] = new Rectangle(checked((int)Math.Round((double)((float)(12f * this.ImageScale)))), checked((int)Math.Round((double)((float)(73f * this.ImageScale)))), checked((int)Math.Round((double)((float)(42f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                    this.NumberLocations[0] = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)(12.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(73.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(42.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(20.0F * this.ImageScale)))));
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: this.NumberLocations[1] = new Rectangle(checked((int)Math.Round((double)((float)(60f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(42f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                    this.NumberLocations[1] = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)(60.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(50.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(42.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(20.0F * this.ImageScale)))));
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: this.NumberLocations[2] = new Rectangle(checked((int)Math.Round((double)((float)(104f * this.ImageScale)))), checked((int)Math.Round((double)((float)(38f * this.ImageScale)))), checked((int)Math.Round((double)((float)(42f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                    this.NumberLocations[2] = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)(104.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(38.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(42.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(20.0F * this.ImageScale)))));
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: this.NumberLocations[3] = new Rectangle(checked((int)Math.Round((double)((float)(150f * this.ImageScale)))), checked((int)Math.Round((double)((float)(38f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                    this.NumberLocations[3] = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)(150.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(38.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(50.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(20.0F * this.ImageScale)))));
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: this.NumberLocations[4] = new Rectangle(checked((int)Math.Round((double)((float)(200f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                    this.NumberLocations[4] = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)(200.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(50.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(50.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(20.0F * this.ImageScale)))));
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: this.NumberLocations[5] = new Rectangle(checked((int)Math.Round((double)((float)(248f * this.ImageScale)))), checked((int)Math.Round((double)((float)(73f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                    this.NumberLocations[5] = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)(248.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(73.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(50.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(20.0F * this.ImageScale)))));
                }
                else
                {
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: this.NumberLocations[0] = new Rectangle(0, checked((int)Math.Round((double)((float)(85f * this.ImageScale)))), checked((int)Math.Round((double)((float)(42f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                    this.NumberLocations[0] = new Rectangle(0, Convert.ToInt32(Math.Truncate(Math.Round((double)(85.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(42.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(20.0F * this.ImageScale)))));
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: this.NumberLocations[1] = new Rectangle(checked((int)Math.Round((double)((float)(40f * this.ImageScale)))), checked((int)Math.Round((double)((float)(60f * this.ImageScale)))), checked((int)Math.Round((double)((float)(42f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                    this.NumberLocations[1] = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)(40.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(60.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(42.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(20.0F * this.ImageScale)))));
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: this.NumberLocations[2] = new Rectangle(checked((int)Math.Round((double)((float)(80f * this.ImageScale)))), checked((int)Math.Round((double)((float)(42f * this.ImageScale)))), checked((int)Math.Round((double)((float)(42f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                    this.NumberLocations[2] = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)(80.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(42.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(42.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(20.0F * this.ImageScale)))));
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: this.NumberLocations[3] = new Rectangle(checked((int)Math.Round((double)((float)(125f * this.ImageScale)))), checked((int)Math.Round((double)((float)(38f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                    this.NumberLocations[3] = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)(125.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(38.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(50.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(20.0F * this.ImageScale)))));
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: this.NumberLocations[4] = new Rectangle(checked((int)Math.Round((double)((float)(170f * this.ImageScale)))), checked((int)Math.Round((double)((float)(42f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                    this.NumberLocations[4] = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)(170.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(42.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(50.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(20.0F * this.ImageScale)))));
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: this.NumberLocations[5] = new Rectangle(checked((int)Math.Round((double)((float)(210f * this.ImageScale)))), checked((int)Math.Round((double)((float)(60f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                    this.NumberLocations[5] = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)(210.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(60.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(50.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(20.0F * this.ImageScale)))));
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: this.NumberLocations[6] = new Rectangle(checked((int)Math.Round((double)((float)(248f * this.ImageScale)))), checked((int)Math.Round((double)((float)(85f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                    this.NumberLocations[6] = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)(248.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(85.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(50.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(20.0F * this.ImageScale)))));
                }
                if (this.StaticImage != null)
                {
                    this.StaticImage.Dispose();
                }
                this.StaticImage = new Bitmap(Convert.ToInt32((float)Properties.Resources.MeterNoNeedle2.Width * this.ImageScale), Convert.ToInt32((float)Properties.Resources.MeterNoNeedle2.Height * this.ImageScale));
                Graphics graphic = Graphics.FromImage(this.StaticImage);
                if (decimal.Compare(Math.Abs(this.m_MinValue), Math.Abs(this.m_MaxValue)) != 0)
                {
                    graphic.DrawImage(Properties.Resources.MeterNoNeedle2, 0.0F, 0.0F, (float)Properties.Resources.MeterNoNeedle2.Width * this.ImageScale, (float)Properties.Resources.MeterNoNeedle2.Height * this.ImageScale);
                    this.ZeroCentered = false;
                }
                else
                {
                    graphic.DrawImage(Properties.Resources.MeterNoNeedleCenterScale, 0.0F, 0.0F, (float)Properties.Resources.MeterNoNeedle2.Width * this.ImageScale, (float)Properties.Resources.MeterNoNeedle2.Height * this.ImageScale);
                    this.ZeroCentered = true;
                }
                decimal num1 = decimal.Divide(decimal.Subtract(this.m_MaxValue, this.m_MinValue), new decimal((long)5));
                if (this.ZeroCentered)
                {
                    num1 = decimal.Divide(decimal.Subtract(this.m_MaxValue, this.m_MinValue), new decimal((long)6));
                }
                //INSTANT VB NOTE: The variable font was renamed since Visual Basic does not handle local variables named the same as class members well:
                Font font_Renamed = new Font("Arial", 11.0F * this.ImageScale, FontStyle.Regular, GraphicsUnit.Point);
                SolidBrush solidBrush = new SolidBrush(Color.FromArgb(245, 45, 45, 45));
                graphic.DrawString(Conversions.ToString(this.m_MinValue), font_Renamed, solidBrush, this.NumberLocations[0], this.sfCenter);
                graphic.DrawString(Conversions.ToString(decimal.Add(this.m_MinValue, num1)), font_Renamed, solidBrush, this.NumberLocations[1], this.sfCenter);
                graphic.DrawString(Conversions.ToString(decimal.Add(this.m_MinValue, decimal.Multiply(num1, new decimal((long)2)))), font_Renamed, solidBrush, this.NumberLocations[2], this.sfCenter);
                if (this.ZeroCentered)
                {
                    graphic.DrawString("0", font_Renamed, solidBrush, this.NumberLocations[3], this.sfCenter);
                }
                else
                {
                    graphic.DrawString(Conversions.ToString(decimal.Add(this.m_MinValue, decimal.Multiply(num1, new decimal((long)3)))), font_Renamed, solidBrush, this.NumberLocations[3], this.sfCenter);
                }
                graphic.DrawString(Conversions.ToString(decimal.Add(this.m_MinValue, decimal.Multiply(num1, new decimal((long)4)))), font_Renamed, solidBrush, this.NumberLocations[4], this.sfCenter);
                graphic.DrawString(Conversions.ToString(decimal.Add(this.m_MinValue, decimal.Multiply(num1, new decimal((long)5)))), font_Renamed, solidBrush, this.NumberLocations[5], this.sfCenter);
                if (this.ZeroCentered)
                {
                    graphic.DrawString(Conversions.ToString(decimal.Add(this.m_MinValue, decimal.Multiply(num1, new decimal((long)6)))), font_Renamed, solidBrush, this.NumberLocations[6], this.sfCenter);
                }
                int num2 = Math.Max(Convert.ToInt32((float)Properties.Resources.MeterNeedle.Width * this.ImageScale), 1);
                int num3 = Math.Max(Convert.ToInt32((float)Properties.Resources.MeterNeedle.Height * this.ImageScale), 1);
                this.Needle = new Bitmap(num2, num3);
                this.Needle = new Bitmap(num2, num3);
                graphic = Graphics.FromImage(this.Needle);
                graphic.Transform = this.m;
                graphic.DrawImage(Properties.Resources.MeterNeedle, 0.0F, 0.0F, (float)Properties.Resources.MeterNeedle.Width * this.ImageScale, (float)Properties.Resources.MeterNeedle.Height * this.ImageScale);
                if (this.BaseImage != null)
                {
                    this.BaseImage.Dispose();
                }
                this.BaseImage = new Bitmap(Convert.ToInt32((float)Properties.Resources.MeterBase.Width * this.ImageScale), Convert.ToInt32((float)Properties.Resources.MeterBase.Height * this.ImageScale));
                graphic.Dispose();
                graphic = Graphics.FromImage(this.BaseImage);
                graphic.DrawImage(Properties.Resources.MeterBase, 0.0F, 0.0F, (float)Properties.Resources.MeterBase.Width * this.ImageScale, (float)Properties.Resources.MeterBase.Height * this.ImageScale);
                graphic.Dispose();
            }
        }

        public event EventHandler ValueChanged;
    }


}