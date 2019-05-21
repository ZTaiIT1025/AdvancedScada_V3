
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
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Linear
{
    public class HMILinearMeterVertical : AnalogMeterBase
    {
        public HMILinearMeterVertical()
        {
            this.BaseImage = Properties.Resources.LinearMeterVertical;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!(this.StaticImage == null || this.BackBuffer == null || this.TextBrush == null))
            {
                using (Graphics graphic = Graphics.FromImage(this.BackBuffer))
                {
                    graphic.DrawImage(this.StaticImage, 0, 0);
                    if ((base.Text == null || string.Compare(base.Text, string.Empty) == 0) ? false : true)
                    {
                        if (this.TextBrush.Color != base.ForeColor)
                        {
                            this.TextBrush.Color = base.ForeColor;
                        }
                        graphic.DrawString(base.Text, base.Font, this.TextBrush, this.TextRectangle, this.sf);
                    }
                    graphic.DrawImage(this.NeedleImage, Convert.ToInt32((double)this.Width * 0.32), Convert.ToInt32((double)this.Height - (double)this.Height * ((this.m_Value * this.m_ValueScaleFactor - this.m_Minimum) / (this.m_Maximum - this.m_Minimum)) * 0.794 - (double)this.Height * 0.072));
                }
                e.Graphics.DrawImage(this.BackBuffer, 0, 0);
            }
        }

        protected override void OnValueChanged(EventArgs e)
        {
            base.OnValueChanged(e);
            this.Invalidate();
        }

        protected override void CreateStaticImage()
        {
            this.ImageRatio = (double)Properties.Resources.LinearMeterVertical.Height / (double)Properties.Resources.LinearMeterVertical.Width;
            //INSTANT VB NOTE: The variable width was renamed since Visual Basic does not handle local variables named the same as class members well:
            float width_Renamed = (float)((double)this.Width / (double)Properties.Resources.LinearMeterVertical.Width);
            //INSTANT VB NOTE: The variable height was renamed since Visual Basic does not handle local variables named the same as class members well:
            float height_Renamed = (float)((double)this.Height / (double)Properties.Resources.LinearMeterVertical.Height);
            if (!(this.ImageRatio <= 0 || width_Renamed <= 0.0F || height_Renamed <= 0.0F))
            {
                if (this.StaticImage != null)
                {
                    this.StaticImage.Dispose();
                }
                this.StaticImage = new Bitmap(Convert.ToInt32((float)Properties.Resources.LinearMeterVertical.Width * width_Renamed), Convert.ToInt32((float)Properties.Resources.LinearMeterVertical.Height * height_Renamed));
                Graphics graphic = Graphics.FromImage(this.StaticImage);
                graphic.DrawImage(Properties.Resources.LinearMeterVertical, 0, 0, this.StaticImage.Width, this.StaticImage.Height);
                this.sf.Alignment = StringAlignment.Center;
                this.sf.LineAlignment = StringAlignment.Center;
                this.TextRectangle.X = 0;
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.TextRectangle.Y = checked((int)Math.Round((double)this.Height * 0.005));
                this.TextRectangle.Y = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height * 0.005)));
                this.TextRectangle.Width = this.Width;
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.TextRectangle.Height = checked((int)Math.Round((double)this.Height * 0.1));
                this.TextRectangle.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height * 0.1)));
                if (this.TextBrush == null)
                {
                    this.TextBrush = new SolidBrush(base.ForeColor);
                }
                SolidBrush solidBrush = new SolidBrush(Color.FromArgb(220, 24, 24, 24));
                this.sf.Alignment = StringAlignment.Near;
                int num = 0;
                do
                {
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: Rectangle rectangle = new Rectangle(checked((int)Math.Round((double)this.Width * 0.52)), Convert.ToInt32((double)this.Height - (double)this.Height * 0.0794 * (double)num - (double)this.Height * 0.105), checked((int)Math.Round((double)this.Width * 0.3)), checked((int)Math.Round((double)this.Height * 0.07)));
                    Rectangle rectangle = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)this.Width * 0.52))), Convert.ToInt32((double)this.Height - (double)this.Height * 0.0794 * (double)num - (double)this.Height * 0.105), Convert.ToInt32(Math.Truncate(Math.Round((double)this.Width * 0.3))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height * 0.07))));
                    graphic.DrawString(Conversions.ToString(this.m_Minimum + (this.m_Maximum - this.m_Minimum) / 10 * (double)num), new Font("Arial", (float)Convert.ToInt32((double)this.Height * 0.024), FontStyle.Bold, GraphicsUnit.Point), solidBrush, rectangle, this.sf);
                    num += 1;
                } while (num <= 10);
                this.sf.Alignment = StringAlignment.Center;
                int num1 = Convert.ToInt32((float)Properties.Resources.LinearMeterVerticalNeedle.Width * width_Renamed);
                if (num1 <= 0)
                {
                    num1 = 1;
                }
                int num2 = Convert.ToInt32((float)Properties.Resources.LinearMeterVerticalNeedle.Height * height_Renamed);
                if (num2 <= 0)
                {
                    num2 = 1;
                }
                this.NeedleImage = new Bitmap(num1, num2);
                graphic = Graphics.FromImage(this.NeedleImage);
                graphic.DrawImage(Properties.Resources.LinearMeterVerticalNeedle, 0, 0, num1, num2);
                graphic.Dispose();
                if (this.BackBuffer != null)
                {
                    this.BackBuffer.Dispose();
                }
                this.BackBuffer = new Bitmap(this.Width, this.Height);
                this.Invalidate();
            }
        }
    }


}