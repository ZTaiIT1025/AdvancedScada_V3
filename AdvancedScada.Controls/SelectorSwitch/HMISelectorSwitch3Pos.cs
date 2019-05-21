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


namespace AdvancedScada.Controls.SelectorSwitch
{
    public class HMISelectorSwitch3Pos : Control
    {

        private Bitmap StaticImage;

        private Bitmap SwitchImage;

        private Bitmap SwitchLeftImage;

        private Bitmap SwitchCenterImage;

        private Bitmap SwitchRightImage;

        private Rectangle TextRectangle;

        private decimal ImageRatio;

        private int m_Value;

        private HMISelectorSwitch3Pos.LegendPlates m_LegendPlate;

        private OutputType m_OutputType;

        private StringFormat sf;

        private SolidBrush TextBrush;

        private Bitmap _backBuffer;


        private Timer tmrError;

        private decimal LegendPlateRatio;

        private int LastWidth;

        private int LastHeight;

        protected override CreateParams CreateParams
        {
            get
            {
                //INSTANT VB NOTE: The local variable createParams was renamed since Visual Basic will not allow local variables with the same name as their enclosing function or property:
                CreateParams createParams_Renamed = base.CreateParams;
                createParams_Renamed.ExStyle |= 32;
                return createParams_Renamed;
            }
        }

        public HMISelectorSwitch3Pos.LegendPlates LegendPlate
        {
            get
            {
                return this.m_LegendPlate;
            }
            set
            {
                if (this.m_LegendPlate != value)
                {
                    this.m_LegendPlate = value;
                    this.RefreshImage();
                }
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

        private int m_ValueOfCenterPosition;
        public int ValueOfCenterPosition
        {
            get
            {
                return m_ValueOfCenterPosition;
            }
            set
            {
                if (m_ValueOfCenterPosition != value)
                {
                    m_ValueOfCenterPosition = value;
                }
            }
        }
        private int m_ValueOfLeftPosition;
        public int ValueOfLeftPosition
        {
            get
            {
                return this.m_ValueOfLeftPosition;
            }
            set
            {
                if (this.m_ValueOfLeftPosition != value)
                {
                    this.m_ValueOfLeftPosition = value;
                }
            }
        }
        private int m_ValueOfRightPosition;
        public int ValueOfRightPosition
        {
            get
            {
                return m_ValueOfRightPosition;
            }
            set
            {
                if (m_ValueOfRightPosition != value)
                {
                    m_ValueOfRightPosition = value;
                }
            }
        }

        public int Value
        {
            get
            {
                return this.m_Value;
            }
            set
            {
                switch (value)
                {
                    case 0:
                        this.SwitchImage = this.SwitchLeftImage;
                        break;
                    case 1:
                        this.SwitchImage = this.SwitchCenterImage;
                        break;
                    case 2:
                        this.SwitchImage = this.SwitchRightImage;
                        break;
                    default:
                        this.SwitchImage = this.SwitchRightImage;
                        break;
                }
                this.m_Value = value;
                this.m_Value = Math.Max(0, Math.Min(this.m_Value, 2));
                this.Invalidate();
            }
        }



        public HMISelectorSwitch3Pos()
        {
            HMISelectorSwitch3Pos selectorSwitch3Po = this;
            base.MouseDown += selectorSwitch3Po.MomentaryButton_MouseDown;
            HMISelectorSwitch3Pos selectorSwitch3Po1 = this;
            base.TextChanged += selectorSwitch3Po1.SelectorSwitch_TextChanged;
            HMISelectorSwitch3Pos selectorSwitch3Po2 = this;
            base.Resize += selectorSwitch3Po2.MomentaryButton_Resize;

            this.TextRectangle = new Rectangle();
            this.m_Value = 1;
            this.m_LegendPlate = HMISelectorSwitch3Pos.LegendPlates.Large;
            this.m_OutputType = OutputType.MomentarySet;
            this.sf = new StringFormat();
            this.tmrError = new Timer();
            this.LegendPlateRatio = new decimal((double)Properties.Resources.LegendPlate.Height / (double)Properties.Resources.LegendPlate.Width);
        }


        private void MomentaryButton_MouseDown(object sender, MouseEventArgs e)
        {
            HMISelectorSwitch3Pos.SwitchCenterEventHandler switchCenterEventHandler = null;
            if ((double)e.X < (double)this.Width * 0.5)
            {
                if (this.m_Value > 0)
                {
                    if (this.m_Value != 1)
                    {
                        switchCenterEventHandler = this.SwitchCenter;
                        if (switchCenterEventHandler != null)
                        {
                            switchCenterEventHandler();
                        }
                    }
                    else
                    {
                        HMISelectorSwitch3Pos.SwitchLeftEventHandler switchLeftEventHandler = this.SwitchLeft;
                        if (switchLeftEventHandler != null)
                        {
                            switchLeftEventHandler();
                        }
                    }
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: this.Value = checked(this.Value - 1);
                    this.Value = this.Value - 1;
                }
            }
            else if ((double)e.Y > (double)this.Height / 2)
            {
                if (this.m_Value < 2)
                {
                    if (this.m_Value != 1)
                    {
                        switchCenterEventHandler = this.SwitchCenter;
                        if (switchCenterEventHandler != null)
                        {
                            switchCenterEventHandler();
                        }
                    }
                    else
                    {
                        HMISelectorSwitch3Pos.SwitchRightEventHandler switchRightEventHandler = this.SwitchRight;
                        if (switchRightEventHandler != null)
                        {
                            switchRightEventHandler();
                        }
                    }
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: this.Value = checked(this.Value + 1);
                    this.Value = this.Value + 1;
                }
            }
        }

        private void MomentaryButton_Resize(object sender, EventArgs e)
        {
            if (this.LastHeight < this.Height || this.LastWidth < this.Width)
            {
                if ((double)this.Height / (double)this.Width <= Convert.ToDouble(this.LegendPlateRatio))
                {
                    this.Height = Convert.ToInt32(decimal.Multiply(new decimal(this.Width), this.LegendPlateRatio));
                }
                else
                {
                    this.Width = Convert.ToInt32(decimal.Divide(new decimal(this.Height), this.LegendPlateRatio));
                }
            }
            else if ((double)this.Height / (double)this.Width <= Convert.ToDouble(this.LegendPlateRatio))
            {
                this.Width = Convert.ToInt32(decimal.Divide(new decimal(this.Height), this.LegendPlateRatio));
            }
            else
            {
                this.Height = Convert.ToInt32(decimal.Multiply(new decimal(this.Width), this.LegendPlateRatio));
            }
            this.LastWidth = this.Width;
            this.LastHeight = this.Height;
            this.RefreshImage();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!(this.StaticImage == null || this._backBuffer == null || this.SwitchImage == null))
            {
                Graphics graphic = Graphics.FromImage(this._backBuffer);
                graphic.DrawImage(this.StaticImage, 0, 0);
                if (this.m_LegendPlate != HMISelectorSwitch3Pos.LegendPlates.Large)
                {
                    graphic.DrawImage(this.SwitchImage, Convert.ToInt32((double)this.StaticImage.Width / 2 - (double)this.SwitchImage.Width / 2), Convert.ToInt32((double)this.StaticImage.Height * 0.59 - (double)this.SwitchImage.Height / 2));
                }
                else
                {
                    graphic.DrawImage(this.SwitchImage, Convert.ToInt32((double)this.StaticImage.Width / 2 - (double)this.SwitchImage.Width / 2), Convert.ToInt32((double)this.StaticImage.Height * 0.68 - (double)this.SwitchImage.Height / 2));
                }
                if ((base.Text == null || string.Compare(base.Text, string.Empty) == 0) ? false : true)
                {
                    if (this.TextBrush.Color != base.ForeColor)
                    {
                        this.TextBrush.Color = base.ForeColor;
                    }
                    graphic.DrawString(base.Text, base.Font, this.TextBrush, this.TextRectangle, this.sf);
                }
                e.Graphics.DrawImage(this._backBuffer, 0, 0);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        private void RefreshImage()
        {
            decimal num = 0M;
            decimal num1 = 0M;
            if (this.m_LegendPlate != HMISelectorSwitch3Pos.LegendPlates.Large)
            {
                num1 = new decimal((float)this.Width / (float)Properties.Resources.LegendPlateShort.Width);
                num = new decimal((float)this.Height / (float)Properties.Resources.LegendPlateShort.Height);
            }
            else
            {
                num1 = new decimal((float)this.Width / (float)Properties.Resources.LegendPlate.Width);
                num = new decimal((float)this.Height / (float)Properties.Resources.LegendPlate.Height);
            }
            if (decimal.Compare(num1, num) >= 0)
            {
                this.ImageRatio = num;
            }
            else
            {
                this.ImageRatio = num1;
            }
            if (decimal.Compare(this.ImageRatio, decimal.Zero) > 0)
            {
                if (this.StaticImage != null)
                {
                    this.StaticImage.Dispose();
                }
                if (this.m_LegendPlate != HMISelectorSwitch3Pos.LegendPlates.Large)
                {
                    this.StaticImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.LegendPlateShort.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.LegendPlateShort.Height), this.ImageRatio)));
                    this.LegendPlateRatio = new decimal((double)Properties.Resources.LegendPlateShort.Height / (double)Properties.Resources.LegendPlateShort.Width);
                }
                else
                {
                    this.StaticImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.LegendPlate.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.LegendPlate.Height), this.ImageRatio)));
                    this.LegendPlateRatio = new decimal((double)Properties.Resources.LegendPlate.Height / (double)Properties.Resources.LegendPlate.Width);
                }
                Graphics graphic = Graphics.FromImage(this.StaticImage);
                if (this.m_LegendPlate != HMISelectorSwitch3Pos.LegendPlates.Large)
                {
                    graphic.DrawImage(Properties.Resources.LegendPlateShort, 0.0F, 0.0F, Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.LegendPlateShort.Width), this.ImageRatio)), Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.LegendPlateShort.Height), this.ImageRatio)));
                }
                else
                {
                    graphic.DrawImage(Properties.Resources.LegendPlate, 0.0F, 0.0F, Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.LegendPlate.Width), this.ImageRatio)), Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.LegendPlate.Height), this.ImageRatio)));
                }
                this.SwitchLeftImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.SelectorSwitchLeft.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.SelectorSwitchLeft.Height), this.ImageRatio)));
                this.SwitchRightImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.SelectorSwitchRight.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.SelectorSwitchRight.Height), this.ImageRatio)));
                this.SwitchCenterImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.SelectorSwitchRight.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.SelectorSwitchRight.Height), this.ImageRatio)));
                graphic = Graphics.FromImage(this.SwitchLeftImage);
                Graphics graphic1 = Graphics.FromImage(this.SwitchRightImage);
                Graphics graphic2 = Graphics.FromImage(this.SwitchCenterImage);
                graphic.DrawImage(Properties.Resources.SelectorSwitchLeft, 0, 0, this.SwitchLeftImage.Width, this.SwitchLeftImage.Height);
                graphic1.DrawImage(Properties.Resources.SelectorSwitchRight, 0, 0, this.SwitchRightImage.Width, this.SwitchRightImage.Height);
                graphic2.DrawImage(Properties.Resources.SelectorSwitchCenter, 0, 0, this.SwitchCenterImage.Width, this.SwitchCenterImage.Height);
                this.SwitchImage = this.SwitchCenterImage;
                graphic.Dispose();
                graphic1.Dispose();
                graphic2.Dispose();
                this.TextRectangle.X = 0;
                this.TextRectangle.Width = this.Width;
                this.TextRectangle.Y = 0;
                if (this.m_LegendPlate != HMISelectorSwitch3Pos.LegendPlates.Large)
                {
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: this.TextRectangle.Height = checked((int)Math.Round((double)this.Height * 0.18));
                    this.TextRectangle.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height * 0.18)));
                }
                else
                {
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: this.TextRectangle.Height = checked((int)Math.Round((double)this.Height * 0.4));
                    this.TextRectangle.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height * 0.4)));
                }
                this.sf.Alignment = StringAlignment.Center;
                this.sf.LineAlignment = StringAlignment.Center;
                this.TextBrush = new SolidBrush(base.ForeColor);
                if (this._backBuffer != null)
                {
                    this._backBuffer.Dispose();
                }
                this._backBuffer = new Bitmap(this.Width, this.Height);
                this.Invalidate();
            }
        }

        private void SelectorSwitch_TextChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        public event HMISelectorSwitch3Pos.SwitchCenterEventHandler SwitchCenter;

        public event HMISelectorSwitch3Pos.SwitchLeftEventHandler SwitchLeft;

        public event HMISelectorSwitch3Pos.SwitchRightEventHandler SwitchRight;

        public enum LegendPlates
        {
            Large,
            Small
        }

        public delegate void SwitchCenterEventHandler();

        public delegate void SwitchLeftEventHandler();

        public delegate void SwitchRightEventHandler();
    }


}