

using AdvancedScada;
using AdvancedScada.Controls;
using System;
using System.Collections;
using System.Collections.Generic;

using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Vertical
{
    public class HMIVerticalSlider : System.Windows.Forms.Control
    {


        private int SliderHeight;

        private double SliderWidth;

        private Bitmap BackBuffer;

        private Bitmap BackImage;

        private double m_Minimum;

        private double m_Maximum;

        protected double m_Value;

        private bool m_ShowTickMarks;

        private int m_MajorTickMarks;

        public int MajorTickMarks
        {
            get
            {
                return this.m_MajorTickMarks;
            }
            set
            {
                if (this.m_MajorTickMarks != value)
                {
                    this.m_MajorTickMarks = Math.Min(Math.Max(value, 2), 25);
                    this.RefreshImage();
                }
            }
        }

        public double Maximum
        {
            get
            {
                return this.m_Maximum;
            }
            set
            {
                this.m_Maximum = value;
            }
        }

        public double Minimum
        {
            get
            {
                return this.m_Minimum;
            }
            set
            {
                this.m_Minimum = value;
            }
        }

        public bool ShowTickMarks
        {
            get
            {
                return this.m_ShowTickMarks;
            }
            set
            {
                if (this.m_ShowTickMarks != value)
                {
                    this.m_ShowTickMarks = value;
                    this.RefreshImage();
                }
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
                if (this.m_Value != value)
                {
                    this.m_Value = value;
                    this.Invalidate();
                    this.OnValueChanged(EventArgs.Empty);
                }
            }
        }


        public HMIVerticalSlider()
        {

            this.m_Maximum = 100;
            this.m_MajorTickMarks = 4;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }



        private void CalcNewPosition(int y)
        {
            double height_Renamed = ((double)(this.Height - y) - (double)this.SliderHeight / 2) / (double)(this.Height - this.SliderHeight) * (this.m_Maximum - this.m_Minimum) + this.m_Minimum;
            height_Renamed = Math.Min(this.m_Maximum, height_Renamed);
            height_Renamed = Math.Max(this.m_Minimum, height_Renamed);
            if (height_Renamed != this.m_Value)
            {
                this.m_Value = height_Renamed;
                this.OnValueChangedWithSlider(EventArgs.Empty);
                this.Invalidate();
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.BackBuffer.Dispose();
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            this.RefreshImage();
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            this.RefreshImage();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.CalcNewPosition(e.Y);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            //INSTANT VB NOTE: The variable location was renamed since Visual Basic does not handle local variables named the same as class members well:
            Point location_Renamed = e.Location;
            Point point = e.Location;
            if (e.Button == System.Windows.Forms.MouseButtons.Left && location_Renamed.Y > -10 && point.X > -10)
            {
                this.CalcNewPosition(e.Y);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            double mValue = 0;
            base.OnPaint(e);
            if (this.BackBuffer != null)
            {
                Graphics graphic = Graphics.FromImage(this.BackBuffer);
                graphic.DrawImage(this.BackImage, 0, 0);
                if (this.SliderHeight > 0)
                {
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: if (this.m_Maximum - this.m_Minimum > 0 & checked(this.Height - this.SliderHeight) > 0)
                    if (this.m_Maximum - this.m_Minimum > 0 && this.Height - this.SliderHeight > 0)
                    {
                        //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        //ORIGINAL LINE: mValue = (this.m_Value - this.m_Minimum) / (this.m_Maximum - this.m_Minimum) * (double)(checked(this.Height - this.SliderHeight));
                        mValue = (this.m_Value - this.m_Minimum) / (this.m_Maximum - this.m_Minimum) * (double)(this.Height - this.SliderHeight);
                    }
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: Rectangle rectangle = new Rectangle(0, checked((int)Math.Round((double)(checked(this.Height - this.SliderHeight)) - mValue)), checked((int)Math.Round(this.SliderWidth)), this.SliderHeight);
                    Rectangle rectangle = new Rectangle(0, Convert.ToInt32(Math.Truncate(Math.Round((double)(this.Height - this.SliderHeight) - mValue))), Convert.ToInt32(Math.Truncate(Math.Round(this.SliderWidth))), this.SliderHeight);
                    ButtonRenderer.DrawButton(graphic, rectangle, PushButtonState.Normal);
                }
                e.Graphics.DrawImage(this.BackBuffer, 0, 0);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.RefreshImage();
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            EventHandler eventHandler = this.ValueChanged;
            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }

        protected virtual void OnValueChangedWithSlider(EventArgs e)
        {
            EventHandler eventHandler = this.ValueChangedWithSlider;
            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }

        private void RefreshImage()
        {
            if (this.Height > 0 && this.Width > 0)
            {
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.SliderHeight = checked((int)Math.Round((double)this.Height / 20));
                this.SliderHeight = Convert.ToInt32(Math.Round((double)this.Height / 20));
                this.SliderWidth = (double)this.Width;
                if (this.m_ShowTickMarks)
                {
                    this.SliderWidth = (double)this.Width * 0.6667;
                }
                this.BackBuffer = new Bitmap(this.Width, this.Height);
                this.BackImage = new Bitmap(this.Width, this.Height);
                Graphics graphic = Graphics.FromImage(this.BackImage);
                if ((this.BackColor != Color.Transparent) || this.Parent == null)
                {
                    graphic.Clear(this.BackColor);
                }
                else if (this.Parent != null)
                {
                    graphic.Clear(this.Parent.BackColor);
                }
                Point point = new Point(0, 0);
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: Point point1 = new Point(checked((int)Math.Round((double)this.Width / 5)), 0);
                Point point1 = new Point(Convert.ToInt32(Math.Round((double)this.Width / 5)), 0);
                LinearGradientBrush linearGradientBrush = new LinearGradientBrush(point, point1, Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 220, 220, 220));
                ColorBlend colorBlend = new ColorBlend();
                Color[] colorArray = { Color.FromArgb(255, 220, 220, 220), Color.FromArgb(255, 32, 32, 32), Color.FromArgb(255, 220, 220, 220) };
                colorBlend.Colors = colorArray;
                colorBlend.Positions = new float[] { 0.0F, 0.5F, 1.0F };
                linearGradientBrush.InterpolationColors = colorBlend;
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: int num = checked((int)Math.Round((double)this.Width / 2));
                int num = Convert.ToInt32(Math.Round((double)this.Width / 2));
                if (this.m_ShowTickMarks)
                {
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: num = checked((int)Math.Round((double)this.Width / 3));
                    num = Convert.ToInt32(Math.Round((double)this.Width / 3));
                }
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: graphic.FillRectangle(linearGradientBrush, checked((int)Math.Round((double)num - this.SliderWidth / 10)), checked((int)Math.Round((double)this.SliderHeight / 2)), checked((int)Math.Round(this.SliderWidth / 5)), checked(this.Height - this.SliderHeight));
                graphic.FillRectangle(linearGradientBrush, Convert.ToInt32(Math.Truncate(Math.Round((double)num - this.SliderWidth / 10))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.SliderHeight / 2))), Convert.ToInt32(Math.Truncate(Math.Round(this.SliderWidth / 5))), this.Height - this.SliderHeight);
                if (this.m_ShowTickMarks)
                {
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: double height = (double)(checked(this.Height - this.SliderHeight)) / (double)(checked(this.m_MajorTickMarks - 1));
                    //INSTANT VB NOTE: The variable height was renamed since Visual Basic does not handle local variables named the same as class members well:
                    double height_Renamed = (double)(this.Height - this.SliderHeight) / (double)(this.m_MajorTickMarks - 1);
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: int mMajorTickMarks = checked(this.m_MajorTickMarks - 1);
                    int mMajorTickMarks = this.m_MajorTickMarks - 1;
                    for (int i = 0; i <= mMajorTickMarks; i++)
                    {
                        graphic.DrawLine(new Pen(this.ForeColor), (float)((double)this.Width * 0.7), (float)((double)i * height_Renamed + (double)this.SliderHeight / 2), (float)this.Width, (float)((double)i * height_Renamed + (double)this.SliderHeight / 2));
                    }
                }
                this.Invalidate();
            }
        }

        public event EventHandler ValueChanged;

        public event EventHandler ValueChangedWithSlider;
    }


}