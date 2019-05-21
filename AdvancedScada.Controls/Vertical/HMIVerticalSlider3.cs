

using AdvancedScada;
using AdvancedScada.Controls;
using System;
using System.Collections;
using System.Collections.Generic;

using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Vertical
{
    public class HMIVerticalSlider3 : System.Windows.Forms.Control
    {


        private int SliderHeight;

        private double SliderWidth;

        private Bitmap BackBuffer;

        private Bitmap BackImage;

        private double m_Minimum;

        private double m_Maximum;

        protected double m_Value;

        private double m_Increment;

        private bool m_ShowTickMarks;

        private int m_MajorTickMarks;

        private int m_MinorTickMarks;

        private Color m_BorderColor;

        public Color BorderColor
        {
            get
            {
                return this.m_BorderColor;
            }
            set
            {
                if (value != this.m_BorderColor)
                {
                    this.m_BorderColor = value;
                    this.RefreshImage();
                }
            }
        }

        public double Increment
        {
            get
            {
                return this.m_Increment;
            }
            set
            {
                this.m_Increment = value;
            }
        }

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

        public int MinorTickMarks
        {
            get
            {
                return this.m_MinorTickMarks;
            }
            set
            {
                if (this.m_MinorTickMarks != value)
                {
                    this.m_MinorTickMarks = Convert.ToInt32(Math.Min(Math.Max(value, 0), 10));
                    this.RefreshImage();
                }
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


        public HMIVerticalSlider3()
        {

            this.m_Maximum = 100;
            this.m_Increment = 0.1;
            this.m_MajorTickMarks = 5;
            this.m_MinorTickMarks = 4;
            this.m_BorderColor = Color.Transparent;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }



        private void CalcNewPosition(int y)
        {
            double height_Renamed = ((double)(this.Height - y) - (double)this.SliderHeight / 2) / (double)(this.Height - this.SliderHeight) * (this.m_Maximum - this.m_Minimum) + this.m_Minimum;
            height_Renamed = Math.Min(this.m_Maximum, height_Renamed);
            height_Renamed = Math.Max(this.m_Minimum, height_Renamed);
            if (this.m_Increment > 0)
            {
                height_Renamed = (double)Convert.ToInt32(height_Renamed / this.m_Increment) * this.m_Increment;
            }
            if (height_Renamed != this.m_Value)
            {
                this.m_Value = height_Renamed;
                this.OnValueChangedByMouse(EventArgs.Empty);
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
            double mMinimum = 0;
            base.OnPaint(e);
            if (this.BackBuffer != null)
            {
                Graphics graphic = Graphics.FromImage(this.BackBuffer);
                graphic.DrawImage(this.BackImage, 0, 0);
                if (this.SliderHeight > 0)
                {
                    double num = Math.Max(Math.Min(this.m_Value, this.m_Maximum), this.m_Minimum);
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: if (this.m_Maximum - this.m_Minimum > 0 & checked(this.Height - this.SliderHeight) > 0)
                    if (this.m_Maximum - this.m_Minimum > 0 && this.Height - this.SliderHeight > 0)
                    {
                        //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        //ORIGINAL LINE: mMinimum = (num - this.m_Minimum) / (this.m_Maximum - this.m_Minimum) * (double)(checked(this.Height - this.SliderHeight));
                        mMinimum = (num - this.m_Minimum) / (this.m_Maximum - this.m_Minimum) * (double)(this.Height - this.SliderHeight);
                    }
                    Bitmap verticalSlider = Properties.Resources.VerticalSlider;
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: Rectangle rectangle = new Rectangle(checked((int)Math.Round(((double)this.Width - this.SliderWidth) / 2)), checked((int)Math.Round((double)(checked(this.Height - this.SliderHeight)) - mMinimum)), checked((int)Math.Round(this.SliderWidth)), this.SliderHeight);
                    Rectangle rectangle = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round(((double)this.Width - this.SliderWidth) / 2))), Convert.ToInt32(Math.Truncate(Math.Round((double)(this.Height - this.SliderHeight) - mMinimum))), Convert.ToInt32(Math.Truncate(Math.Round(this.SliderWidth))), this.SliderHeight);
                    graphic.DrawImage(verticalSlider, rectangle);
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

        protected virtual void OnValueChangedByMouse(EventArgs e)
        {
            EventHandler eventHandler = this.ValueChangedByMouse;
            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }

        private void RefreshImage()
        {
            if (this.Height > 0 && this.Width > 0)
            {
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
                //INSTANT VB NOTE: The variable height was renamed since Visual Basic does not handle local variables named the same as class members well:
                double height_Renamed = (double)this.Height / (double)Properties.Resources.AnalogSliderSlot.Height;
                //INSTANT VB NOTE: The variable width was renamed since Visual Basic does not handle local variables named the same as class members well:
                double width_Renamed = (double)Properties.Resources.AnalogSliderSlot.Width * height_Renamed;
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: graphic.DrawImage(My.Resources.AnalogSliderSlot, checked((int)Math.Round((double)this.Width / 2 - width / 2)), 0, checked((int)Math.Round(width)), this.Height);
                graphic.DrawImage(Properties.Resources.AnalogSliderSlot, Convert.ToInt32(Math.Truncate(Math.Round((double)this.Width / 2 - width_Renamed / 2))), 0, Convert.ToInt32(Math.Truncate(Math.Round(width_Renamed))), this.Height);
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.SliderWidth = (double)(checked((int)Math.Round((double)My.Resources.VerticalSlider.Width * height)));
                this.SliderWidth = (double)Convert.ToInt32(Math.Truncate(Math.Round((double)Properties.Resources.VerticalSlider.Width * height_Renamed)));
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.SliderHeight = checked((int)Math.Round((double)My.Resources.VerticalSlider.Height * height));
                this.SliderHeight = Convert.ToInt32(Math.Truncate(Math.Round((double)Properties.Resources.VerticalSlider.Height * height_Renamed)));
                if (this.m_ShowTickMarks)
                {
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: int num = checked((int)Math.Round(((double)this.Width - width * 3) / 2));
                    int num = Convert.ToInt32(Math.Truncate(Math.Round(((double)this.Width - width_Renamed * 3) / 2)));
                    if (num <= 0)
                    {
                        num = 1;
                    }
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: int num1 = checked((int)Math.Round(Math.Max((double)num / 2, 1)));
                    int num1 = Convert.ToInt32(Math.Truncate(Math.Round(Math.Max((double)num / 2, 1))));
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: double height1 = (double)(checked(this.Height - this.SliderHeight)) / (double)(checked(this.m_MajorTickMarks - 1));
                    double height1 = (double)(this.Height - this.SliderHeight) / (double)(this.m_MajorTickMarks - 1);
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: int mMajorTickMarks = checked(this.m_MajorTickMarks - 1);
                    int mMajorTickMarks = this.m_MajorTickMarks - 1;
                    for (int i = 0; i <= mMajorTickMarks; i++)
                    {
                        graphic.DrawLine(new Pen(this.ForeColor), 0.0F, (float)((double)i * height1 + (double)this.SliderHeight / 2), (float)num, (float)((double)i * height1 + (double)this.SliderHeight / 2));
                        //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        //ORIGINAL LINE: graphic.DrawLine(new Pen(this.ForeColor), (float)(checked(this.Width - num)), (float)((double)i * height1 + (double)this.SliderHeight / 2), (float)this.Width, (float)((double)i * height1 + (double)this.SliderHeight / 2));
                        graphic.DrawLine(new Pen(this.ForeColor), (float)(this.Width - num), (float)((double)i * height1 + (double)this.SliderHeight / 2), (float)this.Width, (float)((double)i * height1 + (double)this.SliderHeight / 2));
                        //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        //ORIGINAL LINE: if (this.m_MinorTickMarks > 0 & i < checked(this.m_MajorTickMarks - 1))
                        if (this.m_MinorTickMarks > 0 && i < this.m_MajorTickMarks - 1)
                        {
                            //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                            //ORIGINAL LINE: double mMinorTickMarks = height1 / (double)(checked(this.m_MinorTickMarks + 1));
                            double mMinorTickMarks = height1 / (double)(this.m_MinorTickMarks + 1);
                            int mMinorTickMarks1 = this.m_MinorTickMarks;
                            for (int j = 0; j <= mMinorTickMarks1; j++)
                            {
                                graphic.DrawLine(new Pen(this.ForeColor), 0.0F, (float)((double)i * height1 + (double)this.SliderHeight / 2 + (double)j * mMinorTickMarks), (float)num1, (float)((double)i * height1 + (double)this.SliderHeight / 2 + (double)j * mMinorTickMarks));
                                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                                //ORIGINAL LINE: graphic.DrawLine(new Pen(this.ForeColor), (float)(checked(this.Width - num1)), (float)((double)i * height1 + (double)this.SliderHeight / 2 + (double)j * mMinorTickMarks), (float)this.Width, (float)((double)i * height1 + (double)this.SliderHeight / 2 + (double)j * mMinorTickMarks));
                                graphic.DrawLine(new Pen(this.ForeColor), (float)(this.Width - num1), (float)((double)i * height1 + (double)this.SliderHeight / 2 + (double)j * mMinorTickMarks), (float)this.Width, (float)((double)i * height1 + (double)this.SliderHeight / 2 + (double)j * mMinorTickMarks));
                            }
                        }
                    }
                }
                if (this.m_BorderColor != Color.Transparent)
                {
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: graphic.DrawRectangle(new Pen(this.m_BorderColor), 0, 0, checked(this.Width - 1), checked(this.Height - 1));
                    graphic.DrawRectangle(new Pen(this.m_BorderColor), 0, 0, this.Width - 1, this.Height - 1);
                }
                this.Invalidate();
            }
        }

        public event EventHandler ValueChanged;

        public event EventHandler ValueChangedByMouse;
    }


}