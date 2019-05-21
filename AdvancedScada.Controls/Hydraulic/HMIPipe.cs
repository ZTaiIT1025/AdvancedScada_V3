
using AdvancedScada;
using AdvancedScada.Controls;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;

using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Hydraulic
{
    public class HMIPipe : Control
    {

        private Bitmap StaticImage;

        private Rectangle TextRectangle;

        private SolidBrush TextBrush;

        private StringFormat sf;

        private float ImageRatio;

        private FittingType m_Fitting;

        private RotateFlipType m_Rotation;

        private bool BackNeedsRefreshed;

        private Bitmap _backBuffer;

        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                if (base.BackColor != value)
                {
                    base.BackColor = value;
                    this.BackNeedsRefreshed = true;
                    this.RefreshImage();
                }
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                //INSTANT VB NOTE: The local variable createParams was renamed since Visual Basic will not allow local variables with the same name as their enclosing function or property:
                CreateParams createParams_Renamed = base.CreateParams;
                if (this.m_Fitting != FittingType.Straight)
                {
                    createParams_Renamed.ExStyle |= 32;
                }
                return createParams_Renamed;
            }
        }

        public FittingType Fitting
        {
            get
            {
                return this.m_Fitting;
            }
            set
            {
                if (this.m_Fitting != value)
                {
                    this.m_Fitting = value;
                    this.BackNeedsRefreshed = true;
                    this.RefreshImage();
                }
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
                this.Invalidate();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                if (this.TextBrush != null)
                {
                    this.TextBrush.Color = value;
                }
                else
                {
                    this.TextBrush = new SolidBrush(base.ForeColor);
                }
                base.ForeColor = value;
                this.Invalidate();
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
                if (value != this.m_Rotation)
                {
                    this.m_Rotation = value;
                    this.BackNeedsRefreshed = true;
                    this.RefreshImage();
                }
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
                this.Invalidate();
            }
        }


        public HMIPipe()
        {

            this.TextRectangle = new Rectangle();
            this.sf = new StringFormat();
            this.m_Rotation = RotateFlipType.RotateNoneFlipNone;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }


        protected override void Dispose(bool disposing)
        {
            this._backBuffer.Dispose();
            this.StaticImage.Dispose();
            this.sf.Dispose();
            try
            {
                this.TextBrush.Dispose();
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (this.DesignMode)
            {
                if ((base.Text.Length <= 3 || Operators.CompareString(base.Text.Substring(0, 4).ToUpper(), "PIPE", false) != 0) ? false : true)
                {
                    base.Text = string.Empty;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!(this.StaticImage == null || this._backBuffer == null || this.TextBrush == null))
            {
                Graphics graphic = Graphics.FromImage(this._backBuffer);
                graphic.DrawImage(this.StaticImage, 0, 0);
                if ((base.Text == null || string.Compare(base.Text, string.Empty) == 0) ? false : true)
                {
                    if (this.TextBrush.Color != base.ForeColor)
                    {
                        this.TextBrush.Color = base.ForeColor;
                    }
                    graphic.DrawString(base.Text, base.Font, this.TextBrush, this.TextRectangle, this.sf);
                }
                e.Graphics.DrawImageUnscaled(this._backBuffer, 0, 0);
                graphic.Dispose();
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
            this.RefreshImage();
        }

        private void RefreshImage()
        {
            bool flag = false;
            System.Drawing.Image horizontalPipe = null;
            if (!(this.Width <= 0 || this.Height <= 0))
            {
                switch (this.m_Fitting)
                {
                    case FittingType.Straight:
                        horizontalPipe = Properties.Resources.HorizontalPipe;
                        break;
                    case FittingType.Elbow:
                        horizontalPipe = Properties.Resources.Elbow1;
                        break;
                    case FittingType.Tee:
                        horizontalPipe = Properties.Resources.Tee1;
                        break;
                    default:
                        horizontalPipe = Properties.Resources.HorizontalPipe;
                        break;
                }
                if (this.m_Rotation == RotateFlipType.Rotate90FlipNone || this.m_Rotation == RotateFlipType.Rotate270FlipNone || this.m_Rotation == RotateFlipType.Rotate90FlipX || this.m_Rotation == RotateFlipType.Rotate270FlipX || this.m_Rotation == RotateFlipType.Rotate270FlipX || this.m_Rotation == RotateFlipType.Rotate90FlipX || this.m_Rotation == RotateFlipType.Rotate270FlipNone || this.m_Rotation == RotateFlipType.Rotate90FlipNone)
                {
                    flag = true;
                }
                if (this._backBuffer != null)
                {
                    this._backBuffer.Dispose();
                }
                this._backBuffer = new Bitmap(this.Width, this.Height);
                if (flag)
                {
                    this.StaticImage = new Bitmap(Convert.ToInt32(this.Height), Convert.ToInt32(this.Width));
                }
                else
                {
                    this.StaticImage = new Bitmap(Convert.ToInt32(this.Width), Convert.ToInt32(this.Height));
                }
                Graphics graphic = Graphics.FromImage(this.StaticImage);
                if (this.BackColor != Color.Transparent)
                {
                    graphic.Clear(this.BackColor);
                }
                if (flag)
                {
                    graphic.DrawImage(horizontalPipe, 0, 0, this.Height, this.Width);
                }
                else
                {
                    graphic.DrawImage(horizontalPipe, 0, 0, this.Width, this.Height);
                }
                this.StaticImage.RotateFlip(this.m_Rotation);
                this.TextRectangle.X = 1;
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.TextRectangle.Width = checked(this.Width - 2);
                this.TextRectangle.Width = this.Width - 2;
                this.TextRectangle.Y = 1;
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.TextRectangle.Height = checked(this.Height - 2);
                this.TextRectangle.Height = this.Height - 2;
                this.sf = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                if (this.TextBrush == null)
                {
                    this.TextBrush = new SolidBrush(base.ForeColor);
                }
                SolidBrush solidBrush = new SolidBrush(Color.FromArgb(250, 60, 70, 60));
                graphic.Dispose();
                this.Invalidate();
            }
        }

        public enum FittingType
        {
            Straight,
            Elbow,
            Tee
        }
    }


}