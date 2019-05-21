

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
    public class HMIThumbDial : System.Windows.Forms.Control
    {


        private int AnimationFrame;

        private Bitmap BackBuffer;

        private Bitmap[] AnimationImages;

        private Bitmap BaseImage;

        private Point DialLocation;

        private Point BaseLocation;

        private double m_Minimum;

        private double m_Maximum;

        protected double m_Value;

        private double m_Increment;

        private double m_Sensitivity;

        private int LastX;

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

        public double Sensitivity
        {
            get
            {
                return this.m_Sensitivity;
            }
            set
            {
                this.m_Sensitivity = Math.Max(value, 0.1);
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



        public HMIThumbDial()
        {

            this.AnimationImages = new Bitmap[3];
            this.m_Maximum = 100;
            this.m_Increment = 1;
            this.m_Sensitivity = 1;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }



        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            this.RefreshImage();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            int num = Convert.ToInt32(Math.Truncate(Math.Round((double)(this.LastX - e.X) / 4 * this.m_Sensitivity)));
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (num < 0)
                {
                    if (this.AnimationFrame >= 2)
                    {
                        this.AnimationFrame = 0;
                    }
                    else
                    {
                        this.AnimationFrame = this.AnimationFrame + 1;
                    }
                    this.LastX = e.X;
                    this.m_Value = this.m_Value + this.m_Increment;
                    this.m_Value = Math.Min(this.m_Value, this.m_Maximum);
                    this.Invalidate();
                    this.OnValueChangedByMouse(EventArgs.Empty);
                }
                else if (num > 0)
                {
                    if (this.AnimationFrame <= 0)
                    {
                        this.AnimationFrame = 2;
                    }
                    else
                    {
                        this.AnimationFrame = this.AnimationFrame - 1;
                    }
                    this.LastX = e.X;
                    this.m_Value = this.m_Value - this.m_Increment;
                    this.m_Value = Math.Max(this.m_Value, this.m_Minimum);
                    this.Invalidate();
                    this.OnValueChangedByMouse(EventArgs.Empty);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Graphics graphic = Graphics.FromImage(this.BackBuffer))
            {
                graphic.Clear(this.BackColor);
                graphic.DrawImage(this.BaseImage, this.BaseLocation);
                if ((this.AnimationFrame > 2 || this.AnimationImages[this.AnimationFrame] == null) ? false : true)
                {
                    graphic.DrawImageUnscaled(this.AnimationImages[this.AnimationFrame], this.DialLocation);
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
            if (ValueChanged != null)
                ValueChanged(this, e);
        }

        protected virtual void OnValueChangedByMouse(EventArgs e)
        {
            if (ValueChangedByMouse != null)
                ValueChangedByMouse(this, e);
        }

        private void RefreshImage()
        {
            if (this.Height > 0 && this.Width > 0)
            {
                this.BackBuffer = new Bitmap(this.Width, this.Height);
                Math.Min((double)this.Width / (double)Properties.Resources.ThumbDialFrame1.Width, (double)this.Height / (double)Properties.Resources.ThumbDialFrame1.Height);
                int num = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Width * 0.58)));
                int num1 = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height * 0.45)));
                this.DialLocation = new Point(Convert.ToInt32(Math.Truncate(Math.Round((double)this.Width * 0.21))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height * 0.2))));
                this.AnimationImages[0] = new Bitmap(num, num1);
                Graphics graphic = Graphics.FromImage(this.AnimationImages[0]);
                graphic.DrawImage(Properties.Resources.ThumbDialFrame1, 0, 0, num, num1);
                this.AnimationImages[1] = new Bitmap(num, num1);
                graphic = Graphics.FromImage(this.AnimationImages[1]);
                graphic.DrawImage(Properties.Resources.ThumbDialFrame2, 0, 0, num, num1);
                this.AnimationImages[2] = new Bitmap(num, num1);
                graphic = Graphics.FromImage(this.AnimationImages[2]);
                graphic.DrawImage(Properties.Resources.ThumbDialFrame3, 0, 0, num, num1);
                this.BaseLocation = new Point(0, 0);
                this.BaseImage = new Bitmap(this.Width, this.Height);
                graphic = Graphics.FromImage(this.BaseImage);
                graphic.DrawImage(Properties.Resources.ThumbDialBase, 0, 0, this.BaseImage.Width, this.BaseImage.Height);
            }
        }

        public event EventHandler ValueChanged;

        public event EventHandler ValueChangedByMouse;
    }


}