

using AdvancedScada;
using AdvancedScada.Controls;
using AdvancedScada.Controls.Motor;
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

namespace AdvancedScada.Controls.DigitalDisplay
{
    public class HMIConveyor : Control
    {
        private Bitmap LightImage;

        private Bitmap OffImage;

        private Bitmap OnImage;

        private Rectangle TextRectangle;

        private StringFormat TextFormat;

        private SolidBrush TextBrush;

        private bool m_Value;

        private RotateFlipType m_Rotation;

        private OutputType m_OutputType;

        private bool BackNeedsRefreshed;

        private Bitmap _backBuffer;


        private Timer _tmrError;

        private decimal ControlSizeRatio;

        private decimal SourceImageRatio;

        private int LastWidth;

        private int LastHeight;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams_Renamed = base.CreateParams;
                createParams_Renamed.ExStyle |= 32;
                return createParams_Renamed;
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

        public RotateFlipType Rotation
        {
            get
            {
                return this.m_Rotation;
            }
            set
            {
                if (this.m_Rotation != value)
                {
                    this.m_Rotation = value;
                    this.BackNeedsRefreshed = true;
                    this.AdjustSize();
                    this.RefreshImage();
                }
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
                    if (!value)
                    {
                        this.LightImage = this.OffImage;
                    }
                    else
                    {
                        this.LightImage = this.OnImage;
                    }
                    this.m_Value = value;
                    this.Invalidate();
                    this.OnValueChanged(EventArgs.Empty);
                }
            }
        }



        public HMIConveyor()
        {

            this.TextRectangle = new Rectangle();
            this.m_Rotation = RotateFlipType.RotateNoneFlipNone;
            this.m_OutputType = OutputType.MomentarySet;
            this._tmrError = new Timer();
            this.SourceImageRatio = new decimal((double)Properties.Resources.ConveyorOff.Height / (double)Properties.Resources.ConveyorOff.Width);
            this.TextBrush = new SolidBrush(base.ForeColor);
            this.TextFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Far
            };
        }



        private void AdjustSize()
        {
            if (!(this.m_Rotation == RotateFlipType.Rotate90FlipNone || this.m_Rotation == RotateFlipType.Rotate270FlipNone || this.m_Rotation == RotateFlipType.Rotate90FlipX || this.m_Rotation == RotateFlipType.Rotate270FlipX || this.m_Rotation == RotateFlipType.Rotate270FlipX || this.m_Rotation == RotateFlipType.Rotate90FlipX || this.m_Rotation == RotateFlipType.Rotate270FlipNone || this.m_Rotation == RotateFlipType.Rotate90FlipNone))
            {
                this.SourceImageRatio = new decimal((double)Properties.Resources.ConveyorOff.Height / (double)Properties.Resources.ConveyorOff.Width);
            }
            else
            {
                this.SourceImageRatio = new decimal((double)Properties.Resources.ConveyorOff.Width / (double)Properties.Resources.ConveyorOff.Height);
            }
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
            this.BackNeedsRefreshed = true;
            this.RefreshImage();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (this.Enabled)
            {
                this.LightImage = this.OnImage;
                if (this.m_OutputType == OutputType.Toggle)
                {
                    this.Value = !this.Value;
                }
                this.Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (this.Enabled)
            {
                if (this.m_OutputType != OutputType.Toggle)
                {
                    this.LightImage = this.OffImage;
                }
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!(this._backBuffer == null || this.LightImage == null))
            {
                Graphics graphic = Graphics.FromImage(this._backBuffer);
                graphic.DrawImage(this.LightImage, 0, 0);
                if ((this.Text == null || string.Compare(this.Text, string.Empty) == 0) ? false : true)
                {
                    if (this.TextBrush.Color != this.ForeColor)
                    {
                        this.TextBrush.Color = this.ForeColor;
                    }
                    graphic.DrawString(this.Text, this.Font, this.TextBrush, this.TextRectangle, this.TextFormat);
                }
                e.Graphics.DrawImage(this._backBuffer, 0, 0);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (this.BackNeedsRefreshed)
            {
                base.OnPaintBackground(e);
                this.BackNeedsRefreshed = false;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.AdjustSize();
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
            decimal WidthLast = 0M;
            decimal HeightLast = 0M;
            if (!(this.Width <= 0 || this.Height <= 0))
            {
                if (!(this.m_Rotation == RotateFlipType.Rotate90FlipNone || this.m_Rotation == RotateFlipType.Rotate270FlipNone || this.m_Rotation == RotateFlipType.Rotate90FlipX || this.m_Rotation == RotateFlipType.Rotate270FlipX || this.m_Rotation == RotateFlipType.Rotate270FlipX || this.m_Rotation == RotateFlipType.Rotate90FlipX || this.m_Rotation == RotateFlipType.Rotate270FlipNone || this.m_Rotation == RotateFlipType.Rotate90FlipNone))
                {
                    this.SourceImageRatio = new decimal((double)Properties.Resources.ConveyorOff.Height / (double)Properties.Resources.ConveyorOff.Width);
                    HeightLast = new decimal((float)this.Width / (float)Properties.Resources.ConveyorOff.Width);
                    WidthLast = new decimal((float)this.Height / (float)Properties.Resources.ConveyorOff.Height);
                }
                else
                {
                    this.SourceImageRatio = new decimal((double)Properties.Resources.ConveyorOff.Width / (double)Properties.Resources.ConveyorOff.Height);
                    HeightLast = new decimal((float)this.Width / (float)Properties.Resources.ConveyorOff.Height);
                    WidthLast = new decimal((float)this.Height / (float)Properties.Resources.ConveyorOff.Width);
                }
                this.ControlSizeRatio = Math.Min(HeightLast, WidthLast);
                this.LightImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.ConveyorOff.Width), this.ControlSizeRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.ConveyorOff.Height), this.ControlSizeRatio)));
                Graphics graphic = Graphics.FromImage(this.LightImage);
                graphic.DrawImage(Properties.Resources.ConveyorOff, 0.0F, 0.0F, Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.ConveyorOff.Width), this.ControlSizeRatio)), Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.ConveyorOff.Height), this.ControlSizeRatio)));
                this.OffImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.ConveyorOff.Width), this.ControlSizeRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.ConveyorOff.Height), this.ControlSizeRatio)));
                this.OnImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.ConveyorOn.Width), this.ControlSizeRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.ConveyorOn.Height), this.ControlSizeRatio)));
                graphic = Graphics.FromImage(this.OffImage);
                Graphics graphic1 = Graphics.FromImage(this.OnImage);
                graphic.DrawImage(Properties.Resources.ConveyorOff, 0, 0, this.OffImage.Width, this.OffImage.Height);
                graphic1.DrawImage(Properties.Resources.ConveyorOn, 0, 0, this.OnImage.Width, this.OnImage.Height);
                this.OnImage.RotateFlip(this.m_Rotation);
                this.OffImage.RotateFlip(this.m_Rotation);
                if (!this.m_Value)
                {
                    this.LightImage = this.OffImage;
                }
                else
                {
                    this.LightImage = this.OnImage;
                }
                graphic.Dispose();
                graphic1.Dispose();
                this.TextRectangle.X = 0;
                this.TextRectangle.Width = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Width * 0.95)));
                this.TextRectangle.Y = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height * 0.47)));
                this.TextRectangle.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height * 0.5)));
                if (this._backBuffer != null)
                {
                    this._backBuffer.Dispose();
                }
                this._backBuffer = new Bitmap(this.Width, this.Height);
                this.Invalidate();
            }
        }

        public event EventHandler<EventArgs> ValueChanged;
    }


}