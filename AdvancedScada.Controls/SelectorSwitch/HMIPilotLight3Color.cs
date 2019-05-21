using AdvancedScada.Controls.Motor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class HMIPilotLight3Color : Control
    {

        private Bitmap StaticImage;

        private Bitmap LightColor1Image;

        private Bitmap LightColor2Image;

        private Bitmap LightColor3Image;

        private Bitmap ActiveLightImage;

        private Bitmap ButtonDownImage;

        private Rectangle TextRectangle;

        private decimal ImageRatio;

        private bool ButtonIsDown;

        private StringFormat sf;

        private SolidBrush TextBrush;

        private bool m_SelectColor2;

        private bool m_SelectColor3;

        private HMIPilotLight3Color.LightColors m_LightColor1;

        private HMIPilotLight3Color.LightColors m_LightColor2;

        private HMIPilotLight3Color.LightColors m_LightColor3;

        private HMIPilotLight3Color.LegendPlates m_LegendPlate;

        private OutputType m_OutputType;

        private Bitmap _backBuffer;


        private Timer tmrError;

        private double LegendPlateRatio;

        private int LastWidth;

        private int LastHeight;

        public HMIPilotLight3Color.LegendPlates LegendPlate
        {
            get
            {
                return this.m_LegendPlate;
            }
            set
            {
                this.m_LegendPlate = value;
                this.OnResize(EventArgs.Empty);
                this.RefreshImage();
            }
        }

        public HMIPilotLight3Color.LightColors LightColor1
        {
            get
            {
                return this.m_LightColor1;
            }
            set
            {
                this.m_LightColor1 = value;
                this.RefreshImage();
            }
        }

        public HMIPilotLight3Color.LightColors LightColor3
        {
            get
            {
                return this.m_LightColor3;
            }
            set
            {
                this.m_LightColor3 = value;
                this.RefreshImage();
            }
        }

        public HMIPilotLight3Color.LightColors LightColorOff
        {
            get
            {
                return this.m_LightColor2;
            }
            set
            {
                this.m_LightColor2 = value;
                this.RefreshImage();
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
                    this.OnValueSelectColor1Changed(EventArgs.Empty);
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




        public HMIPilotLight3Color()
        {

            this.TextRectangle = new Rectangle();
            this.sf = new StringFormat();
            this.m_LightColor1 = HMIPilotLight3Color.LightColors.White;
            this.m_LightColor2 = HMIPilotLight3Color.LightColors.Green;
            this.m_LightColor3 = HMIPilotLight3Color.LightColors.Red;
            this.m_LegendPlate = HMIPilotLight3Color.LegendPlates.Large;
            this.m_OutputType = OutputType.MomentarySet;
            this.tmrError = new Timer();
            this.LegendPlateRatio = (double)Properties.Resources.LegendPlate.Height / (double)Properties.Resources.LegendPlate.Width;
            this.sf = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            this.TextBrush = new SolidBrush(Color.Black);
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.ButtonIsDown = true;
            if (this.Enabled)
            {
                this.Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.ButtonIsDown = false;
            if (this.Enabled)
            {
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!(this.StaticImage == null || this._backBuffer == null || this.ActiveLightImage == null))
            {
                Graphics graphic = Graphics.FromImage(this._backBuffer);
                graphic.DrawImage(this.StaticImage, 0, 0);
                this.ActiveLightImage = this.LightColor1Image;
                if (this.m_SelectColor3)
                {
                    this.ActiveLightImage = this.LightColor3Image;
                }
                else if (this.m_SelectColor2)
                {
                    this.ActiveLightImage = this.LightColor2Image;
                }
                if (this.m_LegendPlate != HMIPilotLight3Color.LegendPlates.Large)
                {
                    graphic.DrawImage(this.ActiveLightImage, Convert.ToInt32((double)this.StaticImage.Width / 2 - (double)this.ActiveLightImage.Width / 2), Convert.ToInt32((double)this.StaticImage.Height * 0.59 - (double)this.ActiveLightImage.Height / 2));
                }
                else
                {
                    graphic.DrawImage(this.ActiveLightImage, Convert.ToInt32((double)this.StaticImage.Width / 2 - (double)this.ActiveLightImage.Width / 2), Convert.ToInt32((double)this.StaticImage.Height * 0.68 - (double)this.ActiveLightImage.Height / 2));
                }
                if ((this.Text == null || string.Compare(this.Text, string.Empty) == 0) ? false : true)
                {
                    if (this.TextBrush.Color != base.ForeColor)
                    {
                        this.TextBrush.Color = base.ForeColor;
                    }
                    graphic.DrawString(base.Text, base.Font, this.TextBrush, this.TextRectangle, this.sf);
                }
                if (this.ButtonIsDown)
                {
                    if (this.m_LegendPlate != HMIPilotLight3Color.LegendPlates.Large)
                    {
                        graphic.DrawImage(this.ButtonDownImage, Convert.ToSingle(decimal.Multiply(new decimal((long)102), this.ImageRatio)), Convert.ToSingle(decimal.Multiply(new decimal((long)170), this.ImageRatio)));
                    }
                    else
                    {
                        graphic.DrawImage(this.ButtonDownImage, Convert.ToSingle(decimal.Multiply(new decimal((long)102), this.ImageRatio)), Convert.ToSingle(decimal.Multiply(new decimal((long)360), this.ImageRatio)));
                    }
                }
                e.Graphics.DrawImage(this._backBuffer, 0, 0);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        protected override void OnResize(EventArgs e)
        {
            if (this.m_LegendPlate != HMIPilotLight3Color.LegendPlates.Large)
            {
                this.LegendPlateRatio = (double)Properties.Resources.LegendPlateShort.Height / (double)Properties.Resources.LegendPlateShort.Width;
            }
            else
            {
                this.LegendPlateRatio = (double)Properties.Resources.LegendPlate.Height / (double)Properties.Resources.LegendPlate.Width;
            }
            base.OnResize(e);
            if (this.LastHeight < this.Height || this.LastWidth < this.Width)
            {
                if ((double)this.Height / (double)this.Width <= this.LegendPlateRatio)
                {
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: this.Height = checked((int)Math.Round((double)this.Width * this.LegendPlateRatio));
                    this.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Width * this.LegendPlateRatio)));
                }
                else
                {
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: this.Width = checked((int)Math.Round((double)this.Height / this.LegendPlateRatio));
                    this.Width = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height / this.LegendPlateRatio)));
                }
            }
            else if ((double)this.Height / (double)this.Width <= this.LegendPlateRatio)
            {
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.Width = checked((int)Math.Round((double)this.Height / this.LegendPlateRatio));
                this.Width = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height / this.LegendPlateRatio)));
            }
            else
            {
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.Height = checked((int)Math.Round((double)this.Width * this.LegendPlateRatio));
                this.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Width * this.LegendPlateRatio)));
            }
            this.LastWidth = this.Width;
            this.LastHeight = this.Height;
            this.RefreshImage();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Invalidate();
        }

        protected virtual void OnValueSelectColor1Changed(EventArgs e)
        {
            EventHandler eventHandler = this.ValueSelectColor1Changed;
            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }

        private void RefreshImage()
        {
            Graphics graphic = null;
            decimal num = 0M;
            decimal num1 = 0M;
            if (this.m_LegendPlate != HMIPilotLight3Color.LegendPlates.Large)
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
                if (this.m_LegendPlate != HMIPilotLight3Color.LegendPlates.Large)
                {
                    this.StaticImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.LegendPlateShort.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.LegendPlateShort.Height), this.ImageRatio)));
                    this.LegendPlateRatio = (double)Properties.Resources.LegendPlateShort.Height / (double)Properties.Resources.LegendPlateShort.Width;
                    graphic = Graphics.FromImage(this.StaticImage);
                    graphic.DrawImage(Properties.Resources.LegendPlateShort, 0.0F, 0.0F, Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.LegendPlateShort.Width), this.ImageRatio)), Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.LegendPlateShort.Height), this.ImageRatio)));
                }
                else
                {
                    this.StaticImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.LegendPlate.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.LegendPlate.Height), this.ImageRatio)));
                    this.LegendPlateRatio = (double)Properties.Resources.LegendPlate.Height / (double)Properties.Resources.LegendPlate.Width;
                    graphic = Graphics.FromImage(this.StaticImage);
                    graphic.DrawImage(Properties.Resources.LegendPlate, 0.0F, 0.0F, Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.LegendPlate.Width), this.ImageRatio)), Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.LegendPlate.Height), this.ImageRatio)));
                }
                this.LightColor1Image = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.WhitePilotOn.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.GreenPilotOff.Height), this.ImageRatio)));
                this.LightColor2Image = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.GreenPilotOn.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.GreenPilotOff.Height), this.ImageRatio)));
                this.LightColor3Image = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.RedPilotOn.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.GreenPilotOff.Height), this.ImageRatio)));
                graphic = Graphics.FromImage(this.LightColor1Image);
                Graphics graphic1 = Graphics.FromImage(this.LightColor2Image);
                Graphics graphic2 = Graphics.FromImage(this.LightColor3Image);
                if (this.m_LightColor1 == HMIPilotLight3Color.LightColors.Green)
                {
                    graphic.DrawImage(Properties.Resources.GreenPilotOn, 0, 0, this.LightColor1Image.Width, this.LightColor1Image.Height);
                }
                else if (this.m_LightColor1 == HMIPilotLight3Color.LightColors.Red)
                {
                    graphic.DrawImage(Properties.Resources.RedPilotOn, 0, 0, this.LightColor1Image.Width, this.LightColor1Image.Height);
                }
                else if (this.m_LightColor1 == HMIPilotLight3Color.LightColors.Blue)
                {
                    graphic.DrawImage(Properties.Resources.BluePilotOn, 0, 0, this.LightColor1Image.Width, this.LightColor1Image.Height);
                }
                else if (this.m_LightColor1 != HMIPilotLight3Color.LightColors.White)
                {
                    graphic.DrawImage(Properties.Resources.YellowPilotOn, 0, 0, this.LightColor1Image.Width, this.LightColor1Image.Height);
                }
                else
                {
                    graphic.DrawImage(Properties.Resources.WhitePilotOn, 0, 0, this.LightColor1Image.Width, this.LightColor1Image.Height);
                }
                if (this.m_LightColor2 == HMIPilotLight3Color.LightColors.Green)
                {
                    graphic1.DrawImage(Properties.Resources.GreenPilotOn, 0, 0, this.LightColor2Image.Width, this.LightColor2Image.Height);
                }
                else if (this.m_LightColor2 == HMIPilotLight3Color.LightColors.Red)
                {
                    graphic1.DrawImage(Properties.Resources.RedPilotOn, 0, 0, this.LightColor2Image.Width, this.LightColor2Image.Height);
                }
                else if (this.m_LightColor2 == HMIPilotLight3Color.LightColors.Blue)
                {
                    graphic1.DrawImage(Properties.Resources.BluePilotOn, 0, 0, this.LightColor2Image.Width, this.LightColor2Image.Height);
                }
                else if (this.m_LightColor2 != HMIPilotLight3Color.LightColors.White)
                {
                    graphic1.DrawImage(Properties.Resources.YellowPilotOn, 0, 0, this.LightColor2Image.Width, this.LightColor2Image.Height);
                }
                else
                {
                    graphic1.DrawImage(Properties.Resources.WhitePilotOn, 0, 0, this.LightColor2Image.Width, this.LightColor2Image.Height);
                }
                if (this.m_LightColor3 == HMIPilotLight3Color.LightColors.Green)
                {
                    graphic2.DrawImage(Properties.Resources.GreenPilotOn, 0, 0, this.LightColor3Image.Width, this.LightColor3Image.Height);
                }
                else if (this.m_LightColor3 == HMIPilotLight3Color.LightColors.Red)
                {
                    graphic2.DrawImage(Properties.Resources.RedPilotOn, 0, 0, this.LightColor3Image.Width, this.LightColor3Image.Height);
                }
                else if (this.m_LightColor3 == HMIPilotLight3Color.LightColors.Blue)
                {
                    graphic2.DrawImage(Properties.Resources.BluePilotOn, 0, 0, this.LightColor3Image.Width, this.LightColor3Image.Height);
                }
                else if (this.m_LightColor3 != HMIPilotLight3Color.LightColors.White)
                {
                    graphic2.DrawImage(Properties.Resources.YellowPilotOn, 0, 0, this.LightColor3Image.Width, this.LightColor3Image.Height);
                }
                else
                {
                    graphic2.DrawImage(Properties.Resources.WhitePilotOn, 0, 0, this.LightColor3Image.Width, this.LightColor3Image.Height);
                }
                this.ButtonDownImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.PilotLightDown.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.PilotLightDown.Height), this.ImageRatio)));
                graphic = Graphics.FromImage(this.ButtonDownImage);
                graphic.DrawImage(Properties.Resources.PilotLightDown, 0, 0, this.ButtonDownImage.Width, this.ButtonDownImage.Height);
                graphic.Dispose();
                graphic1.Dispose();
                this.TextRectangle.X = 0;
                this.TextRectangle.Width = this.Width;
                this.TextRectangle.Y = 0;
                if (this.m_LegendPlate != HMIPilotLight3Color.LegendPlates.Large)
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
                if (this._backBuffer != null)
                {
                    this._backBuffer.Dispose();
                }
                this._backBuffer = new Bitmap(this.Width, this.Height);
                this.ActiveLightImage = this.LightColor1Image;
                if (this.m_SelectColor2)
                {
                    this.ActiveLightImage = this.LightColor2Image;
                }
                else if (this.m_SelectColor3)
                {
                    this.ActiveLightImage = this.LightColor3Image;
                }
                this.Invalidate();
            }
        }

        public event EventHandler ValueChanged;

        public event EventHandler ValueSelectColor1Changed;

        public enum LegendPlates
        {
            Large,
            Small
        }

        public enum LightColors
        {
            Red,
            Green,
            Blue,
            Yellow,
            White
        }
    }


}