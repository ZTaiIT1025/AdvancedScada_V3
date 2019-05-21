

using AdvancedScada;
using AdvancedScada.Controls;
using System;
using System.Collections;
using System.Collections.Generic;

using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Motor
{
    public class HMIMotor3Color : Control
    {

        private Bitmap ActiveMotorImage;

        private Bitmap Motor1Image;

        private Bitmap Motor2Image;

        private Bitmap Motor3Image;

        private Rectangle TextRectangle;

        private StringFormat TextFormat;

        private SolidBrush TextBrush;

        private bool m_SelectColor2;

        private bool m_SelectColor3;

        private RotateFlipType m_Rotation;

        private OutputType m_OutputType;

        private bool BackNeedsRefreshed;

        private Bitmap _backBuffer;


        private Timer tmrError;

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
                    this.AdjustRatio();
                    this.RefreshImage();
                }
            }
        }

        [Category("Appearance")]
        public bool SelectColor2
        {
            get
            {
                return this.m_SelectColor2;
            }
            set
            {
                if (value != this.m_SelectColor2)
                {
                    this.m_SelectColor2 = value;
                    this.Invalidate();
                }
            }
        }

        [Category("Appearance")]
        public bool SelectColor3
        {
            get
            {
                return this.m_SelectColor3;
            }
            set
            {
                if (value != this.m_SelectColor3)
                {
                    this.m_SelectColor3 = value;
                    this.Invalidate();
                }
            }
        }




        public HMIMotor3Color()
        {

            this.TextRectangle = new Rectangle();
            this.m_Rotation = RotateFlipType.RotateNoneFlipNone;
            this.m_OutputType = OutputType.MomentarySet;
            this.tmrError = new Timer();
            this.SourceImageRatio = new decimal((double)Properties.Resources.MotorGray.Height / (double)Properties.Resources.MotorGray.Width);
            this.TextBrush = new SolidBrush(base.ForeColor);
            this.TextFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
        }


        private void AdjustRatio()
        {
            if (!(this.m_Rotation == RotateFlipType.Rotate90FlipNone || this.m_Rotation == RotateFlipType.Rotate270FlipNone || this.m_Rotation == RotateFlipType.Rotate90FlipX || this.m_Rotation == RotateFlipType.Rotate270FlipX || this.m_Rotation == RotateFlipType.Rotate270FlipX || this.m_Rotation == RotateFlipType.Rotate90FlipX || this.m_Rotation == RotateFlipType.Rotate270FlipNone || this.m_Rotation == RotateFlipType.Rotate90FlipNone))
            {
                this.SourceImageRatio = new decimal((double)Properties.Resources.MotorGray.Height / (double)Properties.Resources.MotorGray.Width);
            }
            else
            {
                this.SourceImageRatio = new decimal((double)Properties.Resources.MotorGray.Width / (double)Properties.Resources.MotorGray.Height);
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
            this.RefreshImage();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (this.Enabled)
            {
                this.Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (this.Enabled)
            {
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!(this._backBuffer == null || this.Motor1Image == null))
            {
                Graphics graphic = Graphics.FromImage(this._backBuffer);
                this.ActiveMotorImage = this.Motor1Image;
                if (this.m_SelectColor3)
                {
                    this.ActiveMotorImage = this.Motor3Image;
                }
                else if (this.m_SelectColor2)
                {
                    this.ActiveMotorImage = this.Motor2Image;
                }
                graphic.DrawImage(this.ActiveMotorImage, 0, 0);
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
            this.AdjustRatio();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Invalidate();
        }

        private void RefreshImage()
        {
            decimal num = 0M;
            decimal num1 = 0M;
            if (!(this.Width <= 0 || this.Height <= 0))
            {
                if (!(this.m_Rotation == RotateFlipType.Rotate90FlipNone || this.m_Rotation == RotateFlipType.Rotate270FlipNone || this.m_Rotation == RotateFlipType.Rotate90FlipX || this.m_Rotation == RotateFlipType.Rotate270FlipX || this.m_Rotation == RotateFlipType.Rotate270FlipX || this.m_Rotation == RotateFlipType.Rotate90FlipX || this.m_Rotation == RotateFlipType.Rotate270FlipNone || this.m_Rotation == RotateFlipType.Rotate90FlipNone))
                {
                    this.SourceImageRatio = new decimal((double)Properties.Resources.MotorGray.Height / (double)Properties.Resources.MotorGray.Width);
                    num1 = new decimal((float)this.Width / (float)Properties.Resources.MotorGray.Width);
                    num = new decimal((float)this.Height / (float)Properties.Resources.MotorGray.Height);
                }
                else
                {
                    this.SourceImageRatio = new decimal((double)Properties.Resources.MotorGray.Width / (double)Properties.Resources.MotorGray.Height);
                    num1 = new decimal((float)this.Width / (float)Properties.Resources.MotorGray.Height);
                    num = new decimal((float)this.Height / (float)Properties.Resources.MotorGray.Width);
                }
                this.ControlSizeRatio = Math.Min(num1, num);
                this.ActiveMotorImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.MotorGray.Width), this.ControlSizeRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.MotorGray.Height), this.ControlSizeRatio)));
                Graphics graphic = Graphics.FromImage(this.ActiveMotorImage);
                graphic.DrawImage(Properties.Resources.MotorGray, 0.0F, 0.0F, Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.MotorGray.Width), this.ControlSizeRatio)), Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.MotorGray.Height), this.ControlSizeRatio)));
                this.Motor1Image = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.MotorGray.Width), this.ControlSizeRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.MotorGray.Height), this.ControlSizeRatio)));
                this.Motor2Image = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.MotorGreen.Width), this.ControlSizeRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.MotorGreen.Height), this.ControlSizeRatio)));
                this.Motor3Image = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.MotorRed.Width), this.ControlSizeRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.MotorRed.Height), this.ControlSizeRatio)));
                graphic = Graphics.FromImage(this.Motor1Image);
                Graphics graphic1 = Graphics.FromImage(this.Motor2Image);
                Graphics graphic2 = Graphics.FromImage(this.Motor3Image);
                graphic.DrawImage(Properties.Resources.MotorGray, 0, 0, this.Motor1Image.Width, this.Motor1Image.Height);
                graphic1.DrawImage(Properties.Resources.MotorGreen, 0, 0, this.Motor2Image.Width, this.Motor2Image.Height);
                graphic2.DrawImage(Properties.Resources.MotorRed, 0, 0, this.Motor3Image.Width, this.Motor3Image.Height);
                this.Motor1Image.RotateFlip(this.m_Rotation);
                this.Motor2Image.RotateFlip(this.m_Rotation);
                this.ActiveMotorImage = this.Motor1Image;
                if (this.m_SelectColor2)
                {
                    this.ActiveMotorImage = this.Motor2Image;
                }
                else if (this.m_SelectColor3)
                {
                    this.ActiveMotorImage = this.Motor3Image;
                }
                graphic.Dispose();
                graphic1.Dispose();
                graphic2.Dispose();
                this.TextRectangle.X = 0;
                this.TextRectangle.Width = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Width * 0.95)));
                this.TextRectangle.Y = 0;
                this.TextRectangle.Height = this.Height;
                if (this._backBuffer != null)
                {
                    this._backBuffer.Dispose();
                }
                this._backBuffer = new Bitmap(this.Width, this.Height);
                this.Invalidate();
            }
        }
    }



}