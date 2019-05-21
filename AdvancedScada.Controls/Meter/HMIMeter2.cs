
using AdvancedScada;
using AdvancedScada.Controls;
using AdvancedScada.Controls.ClassBase;
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
    public class HMIMeter2 : AnalogMeterBase
    {
        private Bitmap Frame;

        private Bitmap BackGround;

        private Bitmap Needle;

        private Bitmap LineScale;

        private Bitmap ScaledNeedle;

        private float Cx;

        private float Cy;

        private int Xoff;

        private int YOff;

        private bool ZeroCentered;

        private float ImageScale;

        private Rectangle[] NumberLocations;

        private StringFormat sfCenterBottom;

        private Matrix m;

        private decimal m_Angle;

        public HMIMeter2()
        {
            this.NumberLocations = new Rectangle[11];
            this.m = new Matrix();
            this.m_Angle = new decimal(87, 0, 0, false, 2);
            this.sfCenterBottom = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Far
            };
            this.BaseImage = Properties.Resources.Frame;
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    if (this.Frame != null)
                    {
                        this.Frame.Dispose();
                    }
                    if (this.Needle != null)
                    {
                        this.Needle.Dispose();
                    }
                    this.sfCenterBottom.Dispose();
                    this.LineScale.Dispose();
                    this.m.Dispose();
                    this.ScaledNeedle.Dispose();
                    this.BackGround.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!(this.Frame == null || this.BackGround == null || this.Needle == null))
            {
                Graphics graphic = Graphics.FromImage(this.BackBuffer);
                graphic.DrawImageUnscaled(this.BackGround, 0, 0);
                if ((base.Text == null || string.Compare(base.Text, string.Empty) == 0) ? false : true)
                {
                    if (this.TextBrush.Color != base.ForeColor)
                    {
                        this.TextBrush.Color = base.ForeColor;
                    }
                    graphic.DrawString(this.Text, this.Font, this.TextBrush, this.TextRectangle, this.sfCenterBottom);
                }
                graphic.DrawImageUnscaled(this.Needle, 0, 0);
                graphic.DrawImageUnscaled(this.Frame, 0, 0);
                graphic.Dispose();
                e.Graphics.DrawImageUnscaled(this.BackBuffer, 0, 0);
            }
        }

        protected override void OnValueChanged(EventArgs e)
        {
            base.OnValueChanged(e);
            this.UpdateNeedleImage();
        }

        protected override void CreateStaticImage()
        {
            this.ImageScale = (float)((double)this.Width / (double)Properties.Resources.Frame.Width);
            if (!(this.ImageScale <= 0.0F || this.ImageScale > 100.0F))
            {
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.TextRectangle.Y = checked((int)Math.Round((double)((float)(150f * this.ImageScale))));
                this.TextRectangle.Y = Convert.ToInt32(Math.Truncate(Math.Round((double)(150.0F * this.ImageScale))));
                this.TextRectangle.Width = this.Width;
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.TextRectangle.Height = checked((int)Math.Round((double)((float)(50f * this.ImageScale))));
                this.TextRectangle.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)(50.0F * this.ImageScale))));
                this.TextRectangle.X = 0;
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
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.NumberLocations[0] = new Rectangle(checked((int)Math.Round((double)((float)(6f * this.ImageScale)))), checked((int)Math.Round((double)((float)(171f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                this.NumberLocations[0] = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)(6.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(171.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(50.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(20.0F * this.ImageScale)))));
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.NumberLocations[1] = new Rectangle(checked((int)Math.Round((double)((float)(58f * this.ImageScale)))), checked((int)Math.Round((double)((float)(124f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                this.NumberLocations[1] = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)(58.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(124.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(50.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(20.0F * this.ImageScale)))));
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.NumberLocations[2] = new Rectangle(checked((int)Math.Round((double)((float)(113f * this.ImageScale)))), checked((int)Math.Round((double)((float)(87f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                this.NumberLocations[2] = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)(113.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(87.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(50.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(20.0F * this.ImageScale)))));
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.NumberLocations[3] = new Rectangle(checked((int)Math.Round((double)((float)(169f * this.ImageScale)))), checked((int)Math.Round((double)((float)(62f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                this.NumberLocations[3] = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)(169.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(62.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(50.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(20.0F * this.ImageScale)))));
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.NumberLocations[4] = new Rectangle(checked((int)Math.Round((double)((float)(231f * this.ImageScale)))), checked((int)Math.Round((double)((float)(44f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                this.NumberLocations[4] = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)(231.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(44.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(50.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(20.0F * this.ImageScale)))));
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.NumberLocations[5] = new Rectangle(checked((int)Math.Round((double)((float)(297f * this.ImageScale)))), checked((int)Math.Round((double)((float)(37f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                this.NumberLocations[5] = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)(297.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(37.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(50.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(20.0F * this.ImageScale)))));
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.NumberLocations[6] = new Rectangle(checked((int)Math.Round((double)((float)(362f * this.ImageScale)))), checked((int)Math.Round((double)((float)(44f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                this.NumberLocations[6] = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)(362.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(44.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(50.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(20.0F * this.ImageScale)))));
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.NumberLocations[7] = new Rectangle(checked((int)Math.Round((double)((float)(423f * this.ImageScale)))), checked((int)Math.Round((double)((float)(62f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                this.NumberLocations[7] = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)(423.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(62.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(50.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(20.0F * this.ImageScale)))));
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.NumberLocations[8] = new Rectangle(checked((int)Math.Round((double)((float)(483f * this.ImageScale)))), checked((int)Math.Round((double)((float)(87f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                this.NumberLocations[8] = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)(483.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(87.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(50.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(20.0F * this.ImageScale)))));
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.NumberLocations[9] = new Rectangle(checked((int)Math.Round((double)((float)(535f * this.ImageScale)))), checked((int)Math.Round((double)((float)(124f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                this.NumberLocations[9] = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)(535.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(124.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(50.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(20.0F * this.ImageScale)))));
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.NumberLocations[10] = new Rectangle(checked((int)Math.Round((double)((float)(584f * this.ImageScale)))), checked((int)Math.Round((double)((float)(171f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                this.NumberLocations[10] = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)(584.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(171.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(50.0F * this.ImageScale)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(20.0F * this.ImageScale)))));
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.Xoff = checked((int)Math.Round((double)this.Width / 2 - (double)((float)My.Resources.Needle.Width * this.ImageScale / 2f)));
                this.Xoff = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Width / 2 - (double)((float)Properties.Resources.Needle.Width * this.ImageScale / 2.0F))));
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.YOff = checked((int)Math.Round((double)((float)(56f * this.ImageScale))));
                this.YOff = Convert.ToInt32(Math.Truncate(Math.Round((double)(56.0F * this.ImageScale))));
                this.Cx = (float)((double)this.Width / 2);
                this.Cy = (float)Properties.Resources.Needle.Height * this.ImageScale + (float)this.YOff;
                this.BackGround = new Bitmap(Convert.ToInt32((float)Properties.Resources.MeterScaleBackGround.Width * this.ImageScale), Convert.ToInt32((float)Properties.Resources.MeterScaleBackGround.Height * this.ImageScale));
                Graphics graphic = Graphics.FromImage(this.BackGround);
                if (Math.Abs(this.m_Minimum) != Math.Abs(this.m_Maximum))
                {
                    graphic.DrawImage(Properties.Resources.MeterScaleBackGround, 0.0F, 0.0F, (float)Properties.Resources.MeterScaleBackGround.Width * this.ImageScale, (float)Properties.Resources.MeterScaleBackGround.Height * this.ImageScale);
                    this.ZeroCentered = false;
                }
                else
                {
                    graphic.DrawImage(Properties.Resources.MeterScaleBackGround, 0.0F, 0.0F, (float)Properties.Resources.MeterScaleBackGround.Width * this.ImageScale, (float)Properties.Resources.MeterScaleBackGround.Height * this.ImageScale);
                    this.ZeroCentered = true;
                }
                this.LineScale = new Bitmap(Convert.ToInt32((float)Properties.Resources.MeterScale.Width * this.ImageScale), Convert.ToInt32((float)Properties.Resources.MeterScale.Height * this.ImageScale));
                this.m.Reset();
                graphic.Transform = this.m;
                graphic.DrawImage(Properties.Resources.MeterScale, 40.0F * this.ImageScale, 60.0F * this.ImageScale, (float)Properties.Resources.MeterScale.Width * this.ImageScale, (float)Properties.Resources.MeterScale.Height * this.ImageScale);
                decimal num1 = new decimal((this.m_Maximum - this.m_Minimum) / 10);
                //INSTANT VB NOTE: The variable font was renamed since Visual Basic does not handle local variables named the same as class members well:
                Font font_Renamed = new Font("Arial", 14.0F * this.ImageScale, FontStyle.Regular, GraphicsUnit.Point);
                SolidBrush solidBrush = new SolidBrush(Color.FromArgb(245, 45, 45, 45));
                int num2 = 0;
                do
                {
                    graphic.DrawString(Conversions.ToString(this.m_Minimum + Convert.ToDouble(decimal.Multiply(new decimal(num2), num1))), font_Renamed, solidBrush, this.NumberLocations[num2], this.sf);
                    num2 += 1;
                } while (num2 <= 10);
                if (this.ZeroCentered)
                {
                    graphic.DrawString(Conversions.ToString(this.m_Minimum + Convert.ToDouble(decimal.Multiply(num1, new decimal((long)6)))), font_Renamed, solidBrush, this.NumberLocations[6], this.sf);
                }
                int num3 = Math.Max(Convert.ToInt32((float)Properties.Resources.Needle.Width * this.ImageScale), 1);
                int num4 = Math.Max(Convert.ToInt32((float)Properties.Resources.Needle.Height * this.ImageScale), 1);
                this.ScaledNeedle = new Bitmap(num3, num4);
                Graphics.FromImage(this.ScaledNeedle).DrawImage(Properties.Resources.Needle, 0, 0, this.ScaledNeedle.Width, this.ScaledNeedle.Height);
                this.Needle = new Bitmap(this.Width, this.Height);
                this.UpdateNeedleImage();
                this.Frame = new Bitmap(Convert.ToInt32((float)Properties.Resources.Frame.Width * this.ImageScale), Convert.ToInt32((float)Properties.Resources.Frame.Height * this.ImageScale));
                graphic.Dispose();
                graphic = Graphics.FromImage(this.Frame);
                graphic.DrawImage(Properties.Resources.Frame, 0.0F, 0.0F, (float)Properties.Resources.Frame.Width * this.ImageScale, (float)Properties.Resources.Frame.Height * this.ImageScale);
                this.BackBuffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
                graphic.Dispose();
                this.Invalidate();
            }
        }

        private void UpdateNeedleImage()
        {
            if (this.Needle != null)
            {
                if (!this.ZeroCentered)
                {
                    this.m_Angle = new decimal((this.m_Value * this.m_ValueScaleFactor - this.m_Minimum) * (1 / (this.m_Maximum - this.m_Minimum)) * -1.735 + 0.8675);
                }
                else
                {
                    this.m_Angle = new decimal((this.m_Value * this.m_ValueScaleFactor - this.m_Minimum) * (1.5 / (this.m_Maximum - this.m_Minimum)) * -1 + 0.75);
                }
                Graphics graphic = Graphics.FromImage(this.Needle);
                this.m.Reset();
                graphic.Clear(Color.Transparent);
                Matrix matrix = this.m;
                float num = (float)(Convert.ToDouble(decimal.Multiply(decimal.Negate(this.m_Angle), new decimal((long)180))) / 3.14159265358979);
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: Point point = new Point(checked((int)Math.Round((double)this.Cx)), checked((int)Math.Round((double)this.Cy)));
                Point point = new Point(Convert.ToInt32(Math.Truncate(Math.Round((double)this.Cx))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.Cy))));
                matrix.RotateAt(num, point);
                graphic.Transform = this.m;
                graphic.DrawImage(this.ScaledNeedle, (float)this.Xoff, (float)this.YOff, (float)Properties.Resources.Needle.Width * this.ImageScale, (float)Properties.Resources.Needle.Height * this.ImageScale);
            }
        }
    }


}