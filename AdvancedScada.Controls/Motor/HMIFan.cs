

using AdvancedScada;
using AdvancedScada.Controls;
using System;
using System.Collections;
using System.Collections.Generic;

using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Motor
{
    public class HMIFan : Control
    {

        private Bitmap FanFrame;

        private Bitmap FanCenterCap;

        private Bitmap FanBlades;

        private Bitmap BackBuffer;

        private float XScale;

        private float YScale;

        private StringFormat TextFormat;

        private Rectangle TextRectangle;


        private Timer _AnimateTimer = new Timer();

        private bool m_Value;

        private bool _Direction;

        private OutputType m_OutputType;

        private decimal SourceImageRatio;

        private int LastWidth;

        private int LastHeight;

        private Matrix MatrixForRotation;

        private Graphics AnimateGraphics;

        private Point BladeCenterPoint;



        public bool Direction
        {
            get
            {
                return this._Direction;
            }
            set
            {
                this._Direction = value;
            }
        }

        public OutputType OutputType
        {
            get
            {
                return this.m_OutputType;
            }
            set
            {
                this.m_OutputType = value;
            }
        }

        public StringAlignment TextPosition
        {
            get
            {
                return this.TextFormat.LineAlignment;
            }
            set
            {
                this.TextFormat.LineAlignment = value;
                this.Invalidate();
            }
        }

        public bool Value
        {
            get
            {
                return this.m_Value;
            }
            set
            {
                if (value != this.m_Value)
                {
                    this.m_Value = value;
                    this._AnimateTimer.Enabled = value && !this.DesignMode;
                    this.OnValueChanged(EventArgs.Empty);
                }
            }
        }


        public HMIFan()
        {
            _AnimateTimer.Tick += AnimateTimer_Elapsed;
            this.m_OutputType = OutputType.MomentarySet;
            this.SourceImageRatio = new decimal(Convert.ToInt32((double)Properties.Resources.FanFrame.Height / (double)Properties.Resources.FanFrame.Width));
            this.MatrixForRotation = new Matrix();
            this.TextFormat = new StringFormat() { Alignment = StringAlignment.Center };
            this._AnimateTimer.Interval = 250;
        }


        private void Adjustsize()
        {
            if (this.LastHeight < this.Height || this.LastWidth < this.Width)
            {
                if ((double)this.Height / (double)this.Width <= Convert.ToDouble(this.SourceImageRatio))
                {
                    this.Height = Convert.ToInt32(decimal.Multiply(new decimal(this.Width), this.SourceImageRatio));
                }
                else
                {
                    this.Width = Convert.ToInt32(decimal.Divide(new decimal(this.Height), this.SourceImageRatio));
                }
            }
            else if ((double)this.Height / (double)this.Width <= Convert.ToDouble(this.SourceImageRatio))
            {
                this.Width = Convert.ToInt32(decimal.Divide(new decimal(this.Height), this.SourceImageRatio));
            }
            else
            {
                this.Height = Convert.ToInt32(decimal.Multiply(new decimal(this.Width), this.SourceImageRatio));
            }
            this.LastWidth = this.Width;
            this.LastHeight = this.Height;
            this.RefreshImage();
        }

        private void AnimateTimer_Elapsed(object sender, EventArgs e)
        {
            this._AnimateTimer.Enabled = false;
            if (this.FanBlades != null && this.AnimateGraphics != null)
            {
                if (!this._Direction)
                {
                    this.MatrixForRotation.RotateAt(20.0F, this.BladeCenterPoint);
                }
                else
                {
                    this.MatrixForRotation.RotateAt(-20.0F, this.BladeCenterPoint);
                }
                this.AnimateGraphics.Transform = this.MatrixForRotation;
                this.AnimateGraphics.Clear(Color.Transparent);
                this.AnimateGraphics.DrawImage(Properties.Resources.FanBlades, 0, 0, this.FanBlades.Width, this.FanBlades.Height);
                this.Invalidate();
            }
            this._AnimateTimer.Enabled = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.FanCenterCap != null && this.FanBlades != null)
            {
                Graphics graphic = Graphics.FromImage(this.BackBuffer);
                graphic.DrawImage(this.FanFrame, 0, 0);
                graphic.DrawImage(this.FanBlades, Convert.ToInt32(40.0F * this.XScale), Convert.ToInt32(40.0F * this.YScale));
                graphic.DrawImage(this.FanCenterCap, Convert.ToInt32(151.0F * this.XScale), Convert.ToInt32(151.0F * this.YScale));
                graphic.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), this.TextRectangle, this.TextFormat);
                e.Graphics.DrawImage(this.BackBuffer, 0, 0);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Adjustsize();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Invalidate();
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, e);
        }

        private void RefreshImage()
        {
            if (!(this.Width <= 0 || this.Height <= 0))
            {
                this.XScale = (float)((double)this.Width / (double)Properties.Resources.FanFrame.Width);
                this.YScale = (float)((double)this.Height / (double)Properties.Resources.FanFrame.Height);
                this.BackBuffer = new Bitmap(this.Width, this.Height);
                this.FanCenterCap = new Bitmap(Convert.ToInt32((float)Properties.Resources.FanCenterCap.Width * this.XScale), Convert.ToInt32((float)Properties.Resources.FanCenterCap.Height * this.YScale));
                Graphics graphic = Graphics.FromImage(this.FanCenterCap);
                graphic.DrawImage(Properties.Resources.FanCenterCap, 0, 0, this.FanCenterCap.Width, this.FanCenterCap.Height);
                this.FanBlades = new Bitmap(Convert.ToInt32((float)Properties.Resources.FanBlades.Width * this.XScale), Convert.ToInt32((float)Properties.Resources.FanBlades.Height * this.YScale));
                graphic = Graphics.FromImage(this.FanBlades);
                graphic.DrawImage(Properties.Resources.FanBlades, 0, 0, this.FanBlades.Width, this.FanBlades.Height);
                this.FanFrame = new Bitmap(Convert.ToInt32((float)Properties.Resources.FanFrame.Width * this.XScale), Convert.ToInt32((float)Properties.Resources.FanFrame.Height * this.YScale));
                graphic = Graphics.FromImage(this.FanFrame);
                graphic.DrawImage(Properties.Resources.FanFrame, 0, 0, this.FanFrame.Width, this.FanFrame.Height);
                this.BladeCenterPoint = new Point(Convert.ToInt32((double)this.FanBlades.Width / 2), Convert.ToInt32((double)this.FanBlades.Height / 2));
                this.TextRectangle = new Rectangle(0, Convert.ToInt32(10.0F * this.YScale), this.Width, this.Height - Convert.ToInt32(20.0F * this.YScale));
                this.AnimateGraphics = Graphics.FromImage(this.FanBlades);
            }
        }

        public event EventHandler ValueChanged;
    }


}