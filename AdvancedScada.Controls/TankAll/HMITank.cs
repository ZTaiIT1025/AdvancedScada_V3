

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace AdvancedScada.Controls.TankAll
{
    public class HMITank : System.Windows.Forms.Control
    {
        private float BarValue;

        private Bitmap TankImage;

        private Rectangle TextRectangle;

        private SolidBrush TextBrush;

        private StringFormat sfCenter;

        private StringFormat sfCenterTop;

        private float m_Value;

        private decimal m_ValueScaleFactor;

        private int m_MaxValue;

        private int m_MinValue;

        private HatchBrush m_TankContentColor;

        private bool m_LockAspectRatio;

        private int BarHeight;

        private int FullBarHeight;

        private Bitmap _backBuffer;

        private float ImageRatio;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams_Renamed = base.CreateParams;
                createParams_Renamed.ExStyle |= 32;
                return createParams_Renamed;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                this.RefreshImage();
                this.Invalidate();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                if (value != base.ForeColor)
                {
                    base.ForeColor = value;
                    if (this.TextBrush != null)
                    {
                        this.TextBrush.Color = value;
                    }
                    else
                    {
                        this.TextBrush = new SolidBrush(base.ForeColor);
                    }
                    this.Invalidate();
                }
            }
        }

        public int MaxValue
        {
            get
            {
                return this.m_MaxValue;
            }
            set
            {
                this.m_MaxValue = Convert.ToInt32(Math.Truncate(Math.Round(Math.Ceiling((double)(value - this.m_MinValue) / 10) * 10 + (double)this.m_MinValue)));
                this.CalculateScaledValue();
                this.RefreshImage();
                this.Invalidate();
            }
        }

        public int MinValue
        {
            get
            {
                return this.m_MinValue;
            }
            set
            {
                this.m_MinValue = value;
                this.MaxValue = this.m_MaxValue;
                this.CalculateScaledValue();
                this.RefreshImage();
                this.Invalidate();
            }
        }

        public Color TankContentColor
        {
            get
            {
                return this.m_TankContentColor.BackgroundColor;
            }
            set
            {
                if (this.m_TankContentColor != null)
                {
                    this.m_TankContentColor.Dispose();
                }
                this.m_TankContentColor = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(240, Math.Max(value.R - 40, 0), Math.Max(value.G - 40, 0), Math.Max(value.B - 40, 0)), value);
                this.Invalidate();
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                this.RefreshImage();
                this.Invalidate();
            }
        }

        public float Value
        {
            get
            {
                return this.m_Value;
            }
            set
            {
                if (value != this.m_Value)
                {
                    this.m_Value = Math.Max(Math.Min(value, (float)this.m_MaxValue), (float)this.m_MinValue);
                    this.CalculateScaledValue();
                    Rectangle rectangle = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)this.TankImage.Width * 0.49))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.TankImage.Height * 0.1))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.TankImage.Width * 0.2))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.TankImage.Height * 0.6))));
                    this.Invalidate(rectangle);
                }
            }
        }

        [Category("Numeric Display")]
        public decimal ValueScaleFactor
        {
            get
            {
                return this.m_ValueScaleFactor;
            }
            set
            {
                this.m_ValueScaleFactor = value;
            }
        }



        public HMITank()
        {
            HMITank tank = this;
            base.Resize += tank.Tank_Resize;

            this.BarValue = 20.0F;
            this.TextRectangle = new Rectangle();
            this.sfCenter = new StringFormat();
            this.sfCenterTop = new StringFormat();
            this.m_ValueScaleFactor = decimal.One;
            this.m_MaxValue = 100;
            this.m_TankContentColor = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.Aqua);
            this.RefreshImage();
        }



        private void CalculateScaledValue()
        {
            this.BarHeight = Convert.ToInt32(Math.Truncate(Math.Round((double)((this.m_Value * Convert.ToSingle(this.m_ValueScaleFactor) + (float)this.m_MinValue) / (float)(this.m_MaxValue - this.m_MinValue)) * ((double)this.Height / (double)Properties.Resources.TankWithWindow.Height) * 550)));
            this.FullBarHeight = Convert.ToInt32(Math.Truncate(Math.Round((double)(this.m_MaxValue + this.m_MinValue) / (double)(this.m_MaxValue - this.m_MinValue) * ((double)this.Height / (double)Properties.Resources.TankWithWindow.Height) * 550)));
        }


        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    this.TankImage.Dispose();
                    this._backBuffer.Dispose();
                    this.m_TankContentColor.Dispose();
                    this.sfCenterTop.Dispose();
                    this.sfCenter.Dispose();
                    this.TextBrush.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!(this.TankImage == null || this._backBuffer == null || this.TextBrush == null))
            {
                Graphics graphic = Graphics.FromImage(this._backBuffer);
                graphic.DrawImage(this.TankImage, 0, 0);
                if (this.m_TankContentColor != null)
                {
                    graphic.FillRectangle(this.m_TankContentColor, Convert.ToInt32(361 * ((double)this.Width / (double)Properties.Resources.TankWithWindow.Width)), Convert.ToInt32(158 * ((double)this.Height / (double)Properties.Resources.TankWithWindow.Height) + (double)this.FullBarHeight - (double)this.BarHeight), Convert.ToInt32(68 * ((double)this.Width / (double)Properties.Resources.TankWithWindow.Width)), this.BarHeight);
                }
                if ((base.Text == null || string.Compare(base.Text, string.Empty) == 0) ? false : true)
                {
                    if (this.TextBrush.Color != base.ForeColor)
                    {
                        this.TextBrush.Color = base.ForeColor;
                    }
                    graphic.DrawString(base.Text, base.Font, this.TextBrush, this.TextRectangle, this.sfCenterTop);
                }
                e.Graphics.DrawImage(this._backBuffer, 0, 0);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (this._backBuffer != null)
            {
                this._backBuffer.Dispose();
                this._backBuffer = null;
            }
            base.OnSizeChanged(e);
            if (this.Parent != null)
            {
                this.Parent.Invalidate();
            }
        }

        private void RefreshImage()
        {
            //INSTANT VB NOTE: The variable width was renamed since Visual Basic does not handle local variables named the same as class members well:
            int width_Renamed = 0;
            //INSTANT VB NOTE: The variable height was renamed since Visual Basic does not handle local variables named the same as class members well:
            int height_Renamed = 0;
            float single = (float)((double)this.Width / (double)Properties.Resources.TankWithWindow.Width);
            float height1 = (float)((double)this.Height / (double)Properties.Resources.TankWithWindow.Height);
            this.ImageRatio = (float)((double)this.Width / (double)this.Height);
            this.ImageRatio = 1.0F;
            if (single >= height1)
            {
                width_Renamed = this.Width;
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: height = checked((int)Math.Round((double)My.Resources.TankWithWindow.Height / (double)My.Resources.TankWithWindow.Width * (double)this.Width));
                height_Renamed = Convert.ToInt32(Math.Round((double)Properties.Resources.TankWithWindow.Height / (double)Properties.Resources.TankWithWindow.Width * (double)this.Width));
                this.ImageRatio = height1;
            }
            else
            {
                height_Renamed = this.Height;
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: width = (!(this.Height > 0 & My.Resources.TankWithWindow.Height > 0) ? 1 : checked((int)Math.Round((double)My.Resources.TankWithWindow.Width / (double)My.Resources.TankWithWindow.Height * (double)this.Height)));
                width_Renamed = (!(this.Height > 0 && Properties.Resources.TankWithWindow.Height > 0) ? 1 : Convert.ToInt32(Math.Round((double)Properties.Resources.TankWithWindow.Width / (double)Properties.Resources.TankWithWindow.Height * (double)this.Height)));
                this.ImageRatio = single;
            }
            if (this.ImageRatio > 0.0F)
            {
                if (this.TankImage != null)
                {
                    this.TankImage.Dispose();
                }
                this.TankImage = new Bitmap(Convert.ToInt32(this.Width), Convert.ToInt32(this.Height));
                Graphics graphic = Graphics.FromImage(this.TankImage);
                graphic.DrawImage(Properties.Resources.TankWithWindow, 0, 0, this.TankImage.Width, this.TankImage.Height);
                this.TextRectangle.X = 1;
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.TextRectangle.Y = checked((int)Math.Round((double)((float)(70f * this.ImageRatio - 1f))));
                this.TextRectangle.Y = Convert.ToInt32(Math.Truncate(Math.Round((double)(70.0F * this.ImageRatio - 1.0F))));
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.TextRectangle.Width = checked(this.TankImage.Width - 2);
                this.TextRectangle.Width = this.TankImage.Width - 2;
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.TextRectangle.Height = checked((int)Math.Round((double)this.TankImage.Height * 0.1));
                this.TextRectangle.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)this.TankImage.Height * 0.1)));
                this.sfCenterTop.Alignment = StringAlignment.Center;
                this.sfCenterTop.LineAlignment = StringAlignment.Near;
                this.TextBrush = new SolidBrush(base.ForeColor);
                if (this._backBuffer != null)
                {
                    this._backBuffer.Dispose();
                }
                this._backBuffer = new Bitmap(this.Width, this.Height);
                graphic.Dispose();
                this.Invalidate();
            }
        }

        private void Tank_Resize(object sender, EventArgs e)
        {
            this.CalculateScaledValue();
            this.RefreshImage();
        }
    }


}