
using AdvancedScada;
using AdvancedScada.Controls;
using AdvancedScada.Controls.Motor;
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
    public class HMIPipes : Control
    {


        private Bitmap LightImage;

        private Bitmap LightOffImage;

        private Bitmap LightOnImage;

        private Rectangle TextRectangle;

        private StringFormat TextFormat;

        private SolidBrush TextBrush;

        private bool _Value;

        private LightColors m_LightColor;

        private RotateFlipType m_Rotation;

        private OutputType m_OutputType;

        private bool BackNeedsRefreshed;

        private Bitmap _backBuffer;


        private Timer tmrError;

        private decimal ControlSizeRatio;

        private decimal SourceImageRatio;

        private int LastWidth;

        private int LastHeight;
        public enum LightColors
        {
            Red,
            Green,
            Yellow,
            Gray,
            Blue
        }

        public LightColors LightColor
        {
            get
            {
                return m_LightColor;
            }
            set
            {
                m_LightColor = value;
                RefreshImage();
            }
        }
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

        //* This is necessary to make the background draw correctly
        //*  http://www.bobpowell.net/transcontrols.htm
        //*part of the transparent background code
        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                System.Windows.Forms.CreateParams cp = base.CreateParams;
                cp.ExStyle |= 32;
                return cp;
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

        public OutputType OutputType
        {
            get
            {
                return m_OutputType;
            }
            set
            {
                m_OutputType = value;
            }
        }

        public RotateFlipType Rotation
        {
            get
            {
                return m_Rotation;
            }
            set
            {
                if (m_Rotation != value)
                {
                    m_Rotation = value;
                    BackNeedsRefreshed = true;
                    AdjustRatio();
                    RefreshImage();
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

        public bool Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (!value)
                {
                    LightImage = LightOffImage;
                }
                else
                {
                    LightImage = LightOnImage;
                }
                _Value = value;
                Invalidate();
            }
        }
        public HMIPipes()
        {


            TextRectangle = new Rectangle();
            m_LightColor = LightColors.Green;
            m_Rotation = RotateFlipType.RotateNoneFlipNone;
            m_OutputType = OutputType.MomentarySet;
            tmrError = new Timer();
            SourceImageRatio = new decimal((double)Properties.Resources.Pipe_Gray_Vert.Height / (double)Properties.Resources.Pipe_Gray_Vert.Width);
            TextBrush = new SolidBrush(base.ForeColor);
            TextFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Far
            };
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (Enabled)
            {
                LightImage = LightOnImage;
                if (m_OutputType == OutputType.Toggle)
                {
                    Value = !Value;
                }
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (Enabled)
            {
                if (OutputType != OutputType.Toggle)
                {
                    LightImage = LightOffImage;
                }
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!(_backBuffer == null || LightImage == null))
            {
                Graphics g = Graphics.FromImage(_backBuffer);
                g.DrawImage(LightImage, 0, 0);
                if ((Text == null || string.Compare(Text, string.Empty) == 0) ? false : true)
                {
                    if (TextBrush.Color != ForeColor)
                    {
                        TextBrush.Color = ForeColor;
                    }
                    g.DrawString(Text, Font, TextBrush, TextRectangle, TextFormat);
                }
                e.Graphics.DrawImage(_backBuffer, 0, 0);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (BackNeedsRefreshed)
            {
                base.OnPaintBackground(e);
                BackNeedsRefreshed = false;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AdjustRatio();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            RefreshImage();
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
        private void AdjustRatio()
        {
            if (!(m_Rotation == RotateFlipType.Rotate90FlipNone || m_Rotation == RotateFlipType.Rotate270FlipNone || m_Rotation == RotateFlipType.Rotate90FlipX || m_Rotation == RotateFlipType.Rotate270FlipX || m_Rotation == RotateFlipType.Rotate270FlipX || m_Rotation == RotateFlipType.Rotate90FlipX || m_Rotation == RotateFlipType.Rotate270FlipNone || m_Rotation == RotateFlipType.Rotate90FlipNone))
            {
                SourceImageRatio = new decimal((double)Properties.Resources.Pipe_Gray_Vert.Height / (double)Properties.Resources.Pipe_Gray_Vert.Width);
            }
            else
            {
                SourceImageRatio = new decimal((double)Properties.Resources.Pipe_Gray_Vert.Width / (double)Properties.Resources.Pipe_Gray_Vert.Height);
            }
            if (LastHeight < Height || LastWidth < Width)
            {
                if ((double)Height / (double)Width <= Convert.ToDouble(SourceImageRatio))
                {
                    Height = Convert.ToInt32(decimal.Multiply(new decimal(Width), SourceImageRatio));
                }
                else
                {
                    Width = Convert.ToInt32(decimal.Divide(new decimal(Height), SourceImageRatio));
                }
            }
            else if ((double)Height / (double)Width <= Convert.ToDouble(SourceImageRatio))
            {
                Width = Convert.ToInt32(decimal.Divide(new decimal(Height), SourceImageRatio));
            }
            else
            {
                Height = Convert.ToInt32(decimal.Multiply(new decimal(Width), SourceImageRatio));
            }
            LastWidth = Width;
            LastHeight = Height;
            RefreshImage();
        }



        private void RefreshImage()
        {
            decimal WidthRatio = 0M;
            decimal HeightRatio = 0M;
            if (!(Width <= 0 || Height <= 0))
            {
                if (!(m_Rotation == RotateFlipType.Rotate90FlipNone || m_Rotation == RotateFlipType.Rotate270FlipNone || m_Rotation == RotateFlipType.Rotate90FlipX || m_Rotation == RotateFlipType.Rotate270FlipX || m_Rotation == RotateFlipType.Rotate270FlipX || m_Rotation == RotateFlipType.Rotate90FlipX || m_Rotation == RotateFlipType.Rotate270FlipNone || m_Rotation == RotateFlipType.Rotate90FlipNone))
                {
                    SourceImageRatio = new decimal((double)Properties.Resources.Pipe_Gray_Vert.Height / (double)Properties.Resources.Pipe_Gray_Vert.Width);
                    HeightRatio = new decimal((float)Width / (float)Properties.Resources.Pipe_Gray_Vert.Width);
                    WidthRatio = new decimal((float)Height / (float)Properties.Resources.Pipe_Gray_Vert.Height);
                }
                else
                {
                    SourceImageRatio = new decimal((double)Properties.Resources.Pipe_Gray_Vert.Width / (double)Properties.Resources.Pipe_Gray_Vert.Height);
                    HeightRatio = new decimal((float)Width / (float)Properties.Resources.Pipe_Gray_Vert.Height);
                    WidthRatio = new decimal((float)Height / (float)Properties.Resources.Pipe_Gray_Vert.Width);
                }
                ControlSizeRatio = Math.Min(HeightRatio, WidthRatio);
                LightImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.Pipe_Gray_Vert.Width), ControlSizeRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.Pipe_Gray_Vert.Height), ControlSizeRatio)));
                Graphics gr_dest = Graphics.FromImage(LightImage);
                gr_dest.DrawImage(Properties.Resources.Pipe_Gray_Vert, 0.0F, 0.0F, Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.Pipe_Gray_Vert.Width), ControlSizeRatio)), Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.Pipe_Gray_Vert.Height), ControlSizeRatio)));
                switch (this.m_LightColor)
                {
                    case LightColors.Red:
                        LightOffImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.Pipe_Red_Vert.Width), ControlSizeRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.Pipe_Gray_Vert.Height), ControlSizeRatio)));
                        LightOnImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.Pipe_Green_Vert.Width), ControlSizeRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.Pipe_Green_Vert.Height), ControlSizeRatio)));
                        break;
                    case LightColors.Green:

                        LightOffImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.Pipe_Green_Vert.Width), ControlSizeRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.Pipe_Green_Vert.Height), ControlSizeRatio)));
                        LightOnImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.Pipe_Red_Vert.Width), ControlSizeRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.Pipe_Red_Vert.Height), ControlSizeRatio)));
                        break;
                    case LightColors.Blue:
                        LightOffImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.Pipe_Blue_Vert.Width), ControlSizeRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.Pipe_Blue_Vert.Height), ControlSizeRatio)));
                        LightOnImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.Pipe_Green_Vert.Width), ControlSizeRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.Pipe_Green_Vert.Height), ControlSizeRatio)));
                        break;
                    case LightColors.Yellow:
                        LightOffImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.Pipe_Yellow_Vert.Width), ControlSizeRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.Pipe_Yellow_Vert.Height), ControlSizeRatio)));
                        LightOnImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.Pipe_Green_Vert.Width), ControlSizeRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.Pipe_Green_Vert.Height), ControlSizeRatio)));
                        break;
                    case LightColors.Gray:
                        LightOffImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.Pipe_Gray_Vert.Width), ControlSizeRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.Pipe_Gray_Vert.Height), ControlSizeRatio)));
                        LightOnImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.Pipe_Green_Vert.Width), ControlSizeRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.Pipe_Green_Vert.Height), ControlSizeRatio)));
                        break;
                    default:
                        LightOffImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.Pipe_Red_Vert.Width), ControlSizeRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.Pipe_Gray_Vert.Height), ControlSizeRatio)));
                        LightOnImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.Pipe_Green_Vert.Width), ControlSizeRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.Pipe_Green_Vert.Height), ControlSizeRatio)));
                        break;
                }
                gr_dest = Graphics.FromImage(LightOffImage);
                Graphics gr_dest2 = Graphics.FromImage(LightOnImage);

                switch (this.m_LightColor)
                {
                    case LightColors.Red:
                        gr_dest.DrawImage(Properties.Resources.Pipe_Red_Vert, 0, 0, LightOffImage.Width, LightOffImage.Height);
                        gr_dest2.DrawImage(Properties.Resources.Pipe_Green_Vert, 0, 0, LightOnImage.Width, LightOnImage.Height);
                        break;
                    case LightColors.Green:

                        gr_dest.DrawImage(Properties.Resources.Pipe_Green_Vert, 0, 0, LightOffImage.Width, LightOffImage.Height);
                        gr_dest2.DrawImage(Properties.Resources.Pipe_Red_Vert, 0, 0, LightOnImage.Width, LightOnImage.Height);
                        break;
                    case LightColors.Blue:
                        gr_dest.DrawImage(Properties.Resources.Pipe_Blue_Vert, 0, 0, LightOffImage.Width, LightOffImage.Height);
                        gr_dest2.DrawImage(Properties.Resources.Pipe_Green_Vert, 0, 0, LightOnImage.Width, LightOnImage.Height);
                        break;
                    case LightColors.Yellow:
                        gr_dest.DrawImage(Properties.Resources.Pipe_Yellow_Vert, 0, 0, LightOffImage.Width, LightOffImage.Height);
                        gr_dest2.DrawImage(Properties.Resources.Pipe_Green_Vert, 0, 0, LightOnImage.Width, LightOnImage.Height);
                        break;
                    case LightColors.Gray:
                        gr_dest.DrawImage(Properties.Resources.Pipe_Gray_Vert, 0, 0, LightOffImage.Width, LightOffImage.Height);
                        gr_dest2.DrawImage(Properties.Resources.Pipe_Green_Vert, 0, 0, LightOnImage.Width, LightOnImage.Height);
                        break;
                    default:
                        gr_dest.DrawImage(Properties.Resources.Pipe_Red_Vert, 0, 0, LightOffImage.Width, LightOffImage.Height);
                        gr_dest2.DrawImage(Properties.Resources.Pipe_Green_Vert, 0, 0, LightOnImage.Width, LightOnImage.Height);
                        break;
                }
                LightOnImage.RotateFlip(m_Rotation);
                LightOffImage.RotateFlip(m_Rotation);
                if (!_Value)
                {
                    LightImage = LightOffImage;
                }
                else
                {
                    LightImage = LightOnImage;
                }
                gr_dest.Dispose();
                gr_dest2.Dispose();
                TextRectangle.X = 0;
                TextRectangle.Width = Convert.ToInt32(Math.Truncate(Math.Round((double)Width * 0.95)));
                TextRectangle.Y = Convert.ToInt32(Math.Truncate(Math.Round((double)Height * 0.77)));
                TextRectangle.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)Height * 0.2)));
                if (_backBuffer != null)
                {
                    _backBuffer.Dispose();
                }
                _backBuffer = new Bitmap(Width, Height);
                Invalidate();
            }
        }
    }


}