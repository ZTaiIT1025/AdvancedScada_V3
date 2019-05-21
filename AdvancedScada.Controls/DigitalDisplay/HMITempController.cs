
using AdvancedScada;
using AdvancedScada.Controls;
using AdvancedScada.Controls.DialogEditor;
using AdvancedScada.Controls.Licenses;
using AdvancedScada.Controls.Motor;
using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Client;
using Microsoft.VisualBasic.CompilerServices;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvancedScada.Controls.DigitalDisplay
{
    public class HMITempController : Control
    {

        public event EventHandler Button1MouseDown;

        public event EventHandler Button1MouseUp;

        public event EventHandler Button2MouseDown;

        public event EventHandler Button2MouseUp;

        public event EventHandler Button3MouseDown;

        public event EventHandler Button3MouseUp;

        public event EventHandler Button4MouseDown;

        public event EventHandler Button4MouseUp;
        private Bitmap StaticImage;

        private Bitmap[] LED;

        private Bitmap[] LEDGreen;

        private Bitmap DecimalImage;

        private Bitmap Button1Image;

        private Bitmap Button1UpImage;

        private Bitmap Button1PressedImage;

        private Bitmap Button2Image;

        private Bitmap Button2UpImage;

        private Bitmap Button2PressedImage;

        private Bitmap Button3Image;

        private Bitmap Button3UpImage;

        private Bitmap Button3PressedImage;

        private Bitmap Button4Image;

        private Bitmap Button4UpImage;

        private Bitmap Button4PressedImage;

        private float ImageRatio;

        private Rectangle TextRectangle;

        private Rectangle[] NumberLocations;

        private StringFormat sf;

        private SolidBrush TextBrush;

        private float m_ValuePV;

        private decimal m_Value_ValueScaleFactor;

        private float m_ValueSP;

        private decimal m_Value_ValueScaleFactorSP;

        private string m_Value2Text;

        private string m_Button1Text;

        private string m_Button2Text;

        private int m_NumberOfDigits;

        private int m_DecimalPos;

        private int SegWidth;

        private Bitmap _backBuffer;

        private int LastWidth;

        private int LastHeight;

        private float StaticImageRatio;

        public string Button1Text
        {
            get
            {
                return this.m_Button1Text;
            }
            set
            {
                if (Operators.CompareString(this.m_Button1Text, value, false) != 0)
                {
                    this.m_Button1Text = value;
                    this.Invalidate();
                }
            }
        }

        public string Button2Text
        {
            get
            {
                return this.m_Button2Text;
            }
            set
            {
                if (Operators.CompareString(this.m_Button2Text, value, false) != 0)
                {
                    this.m_Button2Text = value;
                    this.Invalidate();
                }
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams_Renamed = base.CreateParams;
                createParams_Renamed.ExStyle |= 32;
                return createParams_Renamed;
            }
        }

        public int DecimalPosition
        {
            get
            {
                return this.m_DecimalPos;
            }
            set
            {
                this.m_DecimalPos = Math.Max(Math.Min(this.m_NumberOfDigits - 1, value), 0);
                this.RefreshImage();
                this.Invalidate();
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
                    this.TextBrush = new SolidBrush(value);
                }
                base.ForeColor = value;
                this.Invalidate();
            }
        }

        public decimal Value_ValueScaleFactor
        {
            get
            {
                return this.m_Value_ValueScaleFactor;
            }
            set
            {
                this.m_Value_ValueScaleFactor = value;
                Rectangle rectangle = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Width * 0.08))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Height * 0.19))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Width * 0.65))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Height * 0.4))));
                this.Invalidate(rectangle);
            }
        }

        public decimal Value_ValueScaleFactorSP
        {
            get
            {
                return this.m_Value_ValueScaleFactorSP;
            }
            set
            {
                this.m_Value_ValueScaleFactorSP = value;
                Rectangle rectangle = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Width * 0.08))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Height * 0.19))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Width * 0.65))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Height * 0.4))));
                this.Invalidate(rectangle);
            }
        }

        public string Value2Text
        {
            get
            {
                return this.m_Value2Text;
            }
            set
            {
                if (Operators.CompareString(this.m_Value2Text, value, false) != 0)
                {
                    this.m_Value2Text = value;
                    this.Invalidate();
                }
            }
        }

        public float ValuePV
        {
            get
            {
                return this.m_ValuePV;
            }
            set
            {
                if (value != this.m_ValuePV)
                {
                    this.m_ValuePV = value;
                    Rectangle rectangle = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Width * 0.08))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Height * 0.1))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Width * 0.85))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Height * 0.7))));
                    this.Invalidate(rectangle);
                }
            }
        }

        public float ValueSP
        {
            get
            {
                return this.m_ValueSP;
            }
            set
            {
                if (value != this.m_ValueSP)
                {
                    this.m_ValueSP = value;
                    Rectangle rectangle = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Width * 0.08))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Height * 0.1))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Width * 0.85))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Height * 0.8))));
                    this.Invalidate(rectangle);
                }
            }
        }



        public HMITempController()
        {

            this.LED = new Bitmap[12];
            this.LEDGreen = new Bitmap[12];
            this.TextRectangle = new Rectangle();
            this.NumberLocations = new Rectangle[6];
            this.sf = new StringFormat();
            this.m_Value_ValueScaleFactor = decimal.One;
            this.m_Value_ValueScaleFactorSP = decimal.One;
            this.m_Value2Text = "SP";
            this.m_NumberOfDigits = 5;
            this.m_DecimalPos = 0;
            this.SegWidth = 98;
            this.StaticImageRatio = (float)((double)Properties.Resources.TempController.Height / (double)Properties.Resources.TempController.Width);
            if ((base.ForeColor == Color.FromKnownColor(KnownColor.ControlText)) || (this.ForeColor == Color.FromArgb(0, 0, 0, 0)))
            {
                this.ForeColor = Color.LightGray;
            }
            Button4MouseUp += _MouseUp4;
            Button4MouseDown += _click4;
            Button3MouseUp += _MouseUp3;
            Button3MouseDown += _click3;
            Button2MouseUp += _MouseUp2;
            Button2MouseDown += _click2;
            Button1MouseUp += _MouseUp1;
            Button1MouseDown += _Click1;
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.StaticImageRatio = (float)((double)Properties.Resources.TempController.Height / (double)Properties.Resources.TempController.Width);
            if (this.LastHeight < this.Height || this.LastWidth < this.Width)
            {
                if ((double)this.Height / (double)this.Width <= (double)this.StaticImageRatio)
                {
                    this.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)((float)this.Width * this.StaticImageRatio))));
                }
                else
                {
                    this.Width = Convert.ToInt32(Math.Truncate(Math.Round((double)((float)this.Height / this.StaticImageRatio))));
                }
            }
            else if ((double)this.Height / (double)this.Width <= (double)this.StaticImageRatio)
            {
                this.Width = Convert.ToInt32(Math.Truncate(Math.Round((double)((float)this.Height / this.StaticImageRatio))));
            }
            else
            {
                this.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)((float)this.Width * this.StaticImageRatio))));
            }
            this.LastWidth = this.Width;
            this.LastHeight = this.Height;
            this.RefreshImage();
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if ((double)e.Location.Y > (double)this.StaticImage.Height * 0.7)
            {
                Point location_Renamed = e.Location;
                Point point = e.Location;
                if ((double)location_Renamed.X > (double)this.StaticImage.Width * 0.1 && (double)point.X < (double)this.StaticImage.Width * 0.24)
                {
                    this.Button1Image = this.Button1PressedImage;
                    this.Invalidate();
                    if (Button1MouseDown != null)
                        Button1MouseDown(this, e);
                }
                point = e.Location;
                location_Renamed = e.Location;
                if ((double)point.X > (double)this.StaticImage.Width * 0.31 && (double)location_Renamed.X < (double)this.StaticImage.Width * 0.46)
                {
                    this.Button2Image = this.Button2PressedImage;
                    this.Invalidate();
                    if (Button2MouseDown != null)
                        Button2MouseDown(this, e);
                }
                point = e.Location;
                location_Renamed = e.Location;
                if ((double)point.X > (double)this.StaticImage.Width * 0.54 && (double)location_Renamed.X < (double)this.StaticImage.Width * 0.69)
                {
                    this.Button3Image = this.Button3PressedImage;
                    this.Invalidate();
                    if (Button3MouseDown != null)
                        Button3MouseDown(this, e);
                }
                point = e.Location;
                location_Renamed = e.Location;
                if ((double)point.X > (double)this.StaticImage.Width * 0.76 && (double)location_Renamed.X < (double)this.StaticImage.Width * 0.91)
                {
                    this.Button4Image = this.Button4PressedImage;
                    this.Invalidate();
                    if (Button4MouseDown != null)
                        Button4MouseDown(this, e);
                }
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            int num = 0;
            bool flag = false;
            if (!(this.StaticImage == null || this._backBuffer == null || this.TextBrush == null))
            {
                Graphics graphic = Graphics.FromImage(this._backBuffer);
                graphic.DrawImage(this.StaticImage, 0, 0);
                graphic.DrawImage(this.Button1Image, Convert.ToInt32((double)this.StaticImage.Width * 0.09), Convert.ToInt32((double)this.StaticImage.Height * 0.7));
                graphic.DrawImage(this.Button2Image, Convert.ToInt32((double)this.StaticImage.Width * 0.31), Convert.ToInt32((double)this.StaticImage.Height * 0.7));
                graphic.DrawImage(this.Button3Image, Convert.ToInt32((double)this.StaticImage.Width * 0.53), Convert.ToInt32((double)this.StaticImage.Height * 0.7));
                graphic.DrawImage(this.Button4Image, Convert.ToInt32((double)this.StaticImage.Width * 0.75), Convert.ToInt32((double)this.StaticImage.Height * 0.7));
                Rectangle rectangle = new Rectangle(Convert.ToInt32((double)this.StaticImage.Width * 0.09), Convert.ToInt32((double)this.StaticImage.Height * 0.7), this.Button1Image.Width, this.Button1Image.Height);
                this.sf.Alignment = StringAlignment.Center;
                this.sf.LineAlignment = StringAlignment.Center;
                graphic.DrawString(this.m_Button1Text, this.Font, Brushes.Brown, rectangle, this.sf);
                rectangle = new Rectangle(Convert.ToInt32((double)this.StaticImage.Width * 0.31), Convert.ToInt32((double)this.StaticImage.Height * 0.7), this.Button2Image.Width, this.Button2Image.Height);
                graphic.DrawString(this.m_Button2Text, this.Font, Brushes.Brown, rectangle, this.sf);
                if ((this.m_Value2Text == null || string.Compare(this.m_Value2Text, string.Empty) == 0) ? false : true)
                {
                    rectangle = new Rectangle(0, Convert.ToInt32((double)this.StaticImage.Height * 0.45), Convert.ToInt32((double)this.StaticImage.Width * 0.31), Convert.ToInt32((double)this.StaticImage.Height * 0.5));
                    this.sf.LineAlignment = StringAlignment.Near;
                    this.sf.Alignment = StringAlignment.Far;
                    graphic.DrawString(this.m_Value2Text, this.Font, Brushes.Brown, rectangle, this.sf);
                }
                if ((base.Text == null || string.Compare(base.Text, string.Empty) == 0) ? false : true)
                {
                    if (this.TextBrush.Color != base.ForeColor)
                    {
                        this.TextBrush.Color = base.ForeColor;
                    }
                    this.sf.Alignment = StringAlignment.Center;
                    this.sf.LineAlignment = StringAlignment.Center;
                    graphic.DrawString(base.Text, base.Font, this.TextBrush, this.TextRectangle, this.sf);
                }
                int num1 = Convert.ToInt32(this.m_ValuePV * Convert.ToSingle(this.m_Value_ValueScaleFactor));
                if (!((double)num1 <= Math.Pow(10, (double)this.m_NumberOfDigits) - 1 && (double)num1 >= (Math.Pow(10, (double)(this.m_NumberOfDigits - 1)) - 1) * -1))
                {
                    int mNumberOfDigits = this.m_NumberOfDigits;
                    for (int i = 1; i <= mNumberOfDigits; i++)
                    {
                        graphic.DrawImage(this.LED[11], (float)(90 + this.SegWidth * (i - 1)) * this.ImageRatio, 105.0F * this.ImageRatio);
                    }
                }
                else
                {
                    int mNumberOfDigits1 = this.m_NumberOfDigits;
                    for (int j = 1; j <= mNumberOfDigits1; j++)
                    {
                        if (num1 >= 0)
                        {
                            num = Convert.ToInt32(Math.Floor((double)num1 / Math.Pow(10, (double)(this.m_NumberOfDigits - j))));
                            if (num > 0 || j == this.m_NumberOfDigits || j > this.m_NumberOfDigits - this.m_DecimalPos)
                            {
                                flag = true;
                            }
                            if (!flag)
                            {
                                graphic.DrawImage(this.LED[10], (float)(90 + this.SegWidth * (j - 1)) * this.ImageRatio, 105.0F * this.ImageRatio);
                            }
                            else
                            {
                                graphic.DrawImage(this.LED[num], (float)(90 + this.SegWidth * (j - 1)) * this.ImageRatio, 105.0F * this.ImageRatio);
                            }
                            num1 = Convert.ToInt32(Math.Truncate(Math.Round((double)num1 - (double)num * Math.Pow(10, (double)(this.m_NumberOfDigits - j)))));
                        }
                        else
                        {
                            graphic.DrawImage(this.LED[11], (float)(90 + this.SegWidth * (j - 1)) * this.ImageRatio, 105.0F * this.ImageRatio);
                            num1 = Math.Abs(num1);
                        }
                    }
                }
                if (this.m_DecimalPos > 0)
                {
                    graphic.DrawImage(this.DecimalImage, (float)(((this.m_NumberOfDigits - this.m_DecimalPos) * this.SegWidth) + 50) * this.ImageRatio, 150.0F * this.ImageRatio);
                }
                int num2 = 80;
                int num3 = 250;
                int num4 = 275;
                int num5 = 4;
                num = 0;
                num1 = Convert.ToInt32(Math.Truncate(Math.Round((double)(this.m_ValueSP * Convert.ToSingle(this.m_Value_ValueScaleFactorSP)))));
                flag = false;
                if (!((double)num1 <= Math.Pow(10, (double)num5) - 1 && (double)num1 >= (Math.Pow(10, (double)(num5 - 1)) - 1) * -1))
                {
                    int num6 = num5;
                    for (int k = 1; k <= num6; k++)
                    {
                        graphic.DrawImage(this.LEDGreen[11], (float)(num3 + num2 * (k - 1)) * this.ImageRatio, (float)num4 * this.ImageRatio);
                    }
                }
                else
                {
                    int num7 = num5;
                    for (int l = 1; l <= num7; l++)
                    {
                        if (num1 >= 0)
                        {
                            num = Convert.ToInt32(Math.Floor((double)num1 / Math.Pow(10, (double)(num5 - l))));
                            if (num > 0 || l == num5 || l > num5 - this.m_DecimalPos)
                            {
                                flag = true;
                            }
                            if (!flag)
                            {
                                graphic.DrawImage(this.LEDGreen[10], (float)(num3 + num2 * (l - 1)) * this.ImageRatio, (float)num4 * this.ImageRatio);
                            }
                            else
                            {
                                graphic.DrawImage(this.LEDGreen[num], (float)(num3 + num2 * (l - 1)) * this.ImageRatio, (float)num4 * this.ImageRatio);
                            }
                            num1 = Convert.ToInt32(Math.Truncate(Math.Round((double)num1 - (double)num * Math.Pow(10, (double)(num5 - l)))));
                        }
                        else
                        {
                            graphic.DrawImage(this.LEDGreen[11], (float)(num3 + num2 * (l - 1)) * this.ImageRatio, (float)num4 * this.ImageRatio);
                            num1 = Math.Abs(num1);
                        }
                    }
                }
                e.Graphics.DrawImage(this._backBuffer, 0, 0);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Invalidate();
        }

        private void RefreshImage()
        {
            float width_Renamed = 0;
            float height_Renamed = 0;
            float single = (float)((double)this.Width / (double)Properties.Resources.TempController.Width);
            float height1 = (float)((double)this.Height / (double)Properties.Resources.TempController.Height);
            if (single >= height1)
            {
                width_Renamed = (float)this.Width;
                height_Renamed = (float)((double)Properties.Resources.TempController.Height / (double)Properties.Resources.TempController.Width * (double)this.Width);
                this.ImageRatio = height1;
            }
            else
            {
                height_Renamed = (float)this.Height;
                width_Renamed = (!(this.Height > 0 && Properties.Resources.TempController.Height > 0) ? 1.0F : (float)((double)Properties.Resources.TempController.Width / (double)Properties.Resources.TempController.Height * (double)this.Height));
                this.ImageRatio = single;
            }
            if (this.ImageRatio > 0.0F)
            {
                if (this.StaticImage != null)
                {
                    this.StaticImage.Dispose();
                }
                this.StaticImage = new Bitmap(Convert.ToInt32((float)Properties.Resources.TempController.Width * this.ImageRatio), Convert.ToInt32((float)Properties.Resources.TempController.Height * this.ImageRatio));
                Graphics graphic = Graphics.FromImage(this.StaticImage);
                graphic.DrawImage(Properties.Resources.TempController, 0, 0, this.StaticImage.Width, this.StaticImage.Height);
                this.Button1UpImage = new Bitmap(Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.TempControllerButton1.Width * this.ImageRatio))), Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.TempControllerButton1.Height * this.ImageRatio))));
                this.Button2UpImage = new Bitmap(Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.TempControllerButton2.Width * this.ImageRatio))), Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.TempControllerButton1.Height * this.ImageRatio))));
                this.Button3UpImage = new Bitmap(Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.TempControllerButton3.Width * this.ImageRatio))), Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.TempControllerButton1.Height * this.ImageRatio))));
                this.Button4UpImage = new Bitmap(Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.TempControllerButton4.Width * this.ImageRatio))), Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.TempControllerButton1.Height * this.ImageRatio))));
                this.Button1PressedImage = new Bitmap(Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.TempControllerButton1Pressed.Width * this.ImageRatio))), Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.TempControllerButton1Pressed.Height * this.ImageRatio))));
                this.Button2PressedImage = new Bitmap(Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.TempControllerButton2Pressed.Width * this.ImageRatio))), Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.TempControllerButton2Pressed.Height * this.ImageRatio))));
                this.Button3PressedImage = new Bitmap(Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.TempControllerButton3Pressed.Width * this.ImageRatio))), Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.TempControllerButton3Pressed.Height * this.ImageRatio))));
                this.Button4PressedImage = new Bitmap(Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.TempControllerButton4Pressed.Width * this.ImageRatio))), Convert.ToInt32(Math.Ceiling((double)((float)Properties.Resources.TempControllerButton4Pressed.Height * this.ImageRatio))));
                graphic = Graphics.FromImage(this.Button1UpImage);
                graphic.DrawImage(Properties.Resources.TempControllerButton1, 0.0F, 0.0F, (float)Properties.Resources.TempControllerButton1.Width * this.ImageRatio, (float)Properties.Resources.TempControllerButton1.Height * this.ImageRatio);
                graphic = Graphics.FromImage(this.Button2UpImage);
                graphic.DrawImage(Properties.Resources.TempControllerButton2, 0.0F, 0.0F, (float)Properties.Resources.TempControllerButton2.Width * this.ImageRatio, (float)Properties.Resources.TempControllerButton2.Height * this.ImageRatio);
                graphic = Graphics.FromImage(this.Button3UpImage);
                graphic.DrawImage(Properties.Resources.TempControllerButton3, 0.0F, 0.0F, (float)Properties.Resources.TempControllerButton3.Width * this.ImageRatio, (float)Properties.Resources.TempControllerButton3.Height * this.ImageRatio);
                graphic = Graphics.FromImage(this.Button4UpImage);
                graphic.DrawImage(Properties.Resources.TempControllerButton4, 0.0F, 0.0F, (float)Properties.Resources.TempControllerButton4.Width * this.ImageRatio, (float)Properties.Resources.TempControllerButton4.Height * this.ImageRatio);
                graphic = Graphics.FromImage(this.Button1PressedImage);
                graphic.DrawImage(Properties.Resources.TempControllerButton1Pressed, 0.0F, 0.0F, (float)Properties.Resources.TempControllerButton1Pressed.Width * this.ImageRatio, (float)Properties.Resources.TempControllerButton1Pressed.Height * this.ImageRatio);
                graphic = Graphics.FromImage(this.Button2PressedImage);
                graphic.DrawImage(Properties.Resources.TempControllerButton2Pressed, 0.0F, 0.0F, (float)Properties.Resources.TempControllerButton2Pressed.Width * this.ImageRatio, (float)Properties.Resources.TempControllerButton2Pressed.Height * this.ImageRatio);
                graphic = Graphics.FromImage(this.Button3PressedImage);
                graphic.DrawImage(Properties.Resources.TempControllerButton3Pressed, 0.0F, 0.0F, (float)Properties.Resources.TempControllerButton3Pressed.Width * this.ImageRatio, (float)Properties.Resources.TempControllerButton3Pressed.Height * this.ImageRatio);
                graphic = Graphics.FromImage(this.Button4PressedImage);
                graphic.DrawImage(Properties.Resources.TempControllerButton4Pressed, 0.0F, 0.0F, (float)Properties.Resources.TempControllerButton4Pressed.Width * this.ImageRatio, (float)Properties.Resources.TempControllerButton4Pressed.Height * this.ImageRatio);
                this.Button1Image = this.Button1UpImage;
                this.Button2Image = this.Button2UpImage;
                this.Button3Image = this.Button3UpImage;
                this.Button4Image = this.Button4UpImage;
                this.TextRectangle.X = 0;
                this.TextRectangle.Y = Convert.ToInt32(Math.Truncate(Math.Round((double)(30.0F * this.ImageRatio))));
                this.TextRectangle.Width = this.StaticImage.Width - 1;
                this.TextRectangle.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)(60.0F * this.ImageRatio))));
                this.sf.Alignment = StringAlignment.Center;
                this.sf.LineAlignment = StringAlignment.Center;
                Font font_Renamed = new Font("Arial", 32.0F, FontStyle.Regular, GraphicsUnit.Point);
                SolidBrush solidBrush = new SolidBrush(Color.FromArgb(245, 100, 100, 100));
                if (this.TextBrush == null)
                {
                    this.TextBrush = new SolidBrush(base.ForeColor);
                }
                int num = Convert.ToInt32((float)Properties.Resources.LED7Segment8Red.Width * this.ImageRatio);
                int num1 = Convert.ToInt32((float)Properties.Resources.LED7Segment8Red.Height * this.ImageRatio);
                int num2 = 0;
                do
                {
                    if (this.LED[num2] != null)
                    {
                        this.LED[num2].Dispose();
                    }
                    this.LED[num2] = new Bitmap(num, num1);
                    graphic = Graphics.FromImage(this.LED[num2]);
                    graphic.ScaleTransform((float)((double)this.ImageRatio * 0.95), (float)((double)this.ImageRatio * 0.95));
                    if (this.LEDGreen[num2] != null)
                    {
                        this.LEDGreen[num2].Dispose();
                    }
                    this.LEDGreen[num2] = new Bitmap(num, num1);
                    Graphics graphic1 = Graphics.FromImage(this.LEDGreen[num2]);
                    graphic1.ScaleTransform((float)((double)this.ImageRatio * 2.5), (float)((double)this.ImageRatio * 2.5));
                    switch (num2)
                    {
                        case 0:
                            graphic.DrawImage(Properties.Resources.LED7Segment0Red, 0, 0);
                            graphic1.DrawImage(Properties.Resources.LED7Segement0, 0, 0);
                            break;
                        case 1:
                            graphic.DrawImage(Properties.Resources.LED7Segment1Red, 0, 0);
                            graphic1.DrawImage(Properties.Resources.LED7Segement1, 0, 0);
                            break;
                        case 2:
                            graphic.DrawImage(Properties.Resources.LED7Segment2Red, 0, 0);
                            graphic1.DrawImage(Properties.Resources.LED7Segement2, 0, 0);
                            break;
                        case 3:
                            graphic.DrawImage(Properties.Resources.LED7Segment3Red, 0, 0);
                            graphic1.DrawImage(Properties.Resources.LED7Segement3, 0, 0);
                            break;
                        case 4:
                            graphic.DrawImage(Properties.Resources.LED7Segment4Red, 0, 0);
                            graphic1.DrawImage(Properties.Resources.LED7Segement4, 0, 0);
                            break;
                        case 5:
                            graphic.DrawImage(Properties.Resources.LED7Segment5Red, 0, 0);
                            graphic1.DrawImage(Properties.Resources.LED7Segement5, 0, 0);
                            break;
                        case 6:
                            graphic.DrawImage(Properties.Resources.LED7Segment6Red, 0, 0);
                            graphic1.DrawImage(Properties.Resources.LED7Segement6, 0, 0);
                            break;
                        case 7:
                            graphic.DrawImage(Properties.Resources.LED7Segment7Red, 0, 0);
                            graphic1.DrawImage(Properties.Resources.LED7Segement7, 0, 0);
                            break;
                        case 8:
                            graphic.DrawImage(Properties.Resources.LED7Segment8Red, 0, 0);
                            graphic1.DrawImage(Properties.Resources.LED7Segement8, 0, 0);
                            break;
                        case 9:
                            graphic.DrawImage(Properties.Resources.LED7Segment9Red, 0, 0);
                            graphic1.DrawImage(Properties.Resources.LED7Segement9, 0, 0);
                            break;
                        case 10:
                            graphic.DrawImage(Properties.Resources.LED7SegmentOffRed, 0, 0);
                            graphic1.DrawImage(Properties.Resources.LED7SegementOff, 0, 0);
                            break;
                        case 11:
                            graphic.DrawImage(Properties.Resources.LED7Segment_Red, 0, 0);
                            graphic1.DrawImage(Properties.Resources.LED7SegementOff, 0, 0);
                            break;
                    }
                    graphic.Dispose();
                    graphic1.Dispose();
                    num2 += 1;
                } while (num2 <= 11);
                this.DecimalImage = new Bitmap(Convert.ToInt32((float)Properties.Resources.LED7SegmentDecimalRed.Width * this.ImageRatio), Convert.ToInt32((float)Properties.Resources.LED7SegmentDecimalRed.Height * this.ImageRatio));
                graphic = Graphics.FromImage(this.DecimalImage);
                graphic.DrawImage(Properties.Resources.LED7SegmentDecimalRed, 0, 0);
                if (this._backBuffer != null)
                {
                    this._backBuffer.Dispose();
                }
                this._backBuffer = new Bitmap(this.Width, this.Height);
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (this.Button1Image == this.Button1PressedImage)
            {
                if (Button1MouseUp != null)
                    Button1MouseUp(this, e);
            }
            if (this.Button2Image == this.Button2PressedImage)
            {
                if (Button2MouseUp != null)
                    Button2MouseUp(this, e);
            }
            if (this.Button3Image == this.Button3PressedImage)
            {
                if (Button3MouseUp != null)
                    Button3MouseUp(this, e);
            }
            if (this.Button4Image == this.Button4PressedImage)
            {
                if (Button4MouseUp != null)
                    Button4MouseUp(this, e);
            }
            this.Button1Image = this.Button1UpImage;
            this.Button2Image = this.Button2UpImage;
            this.Button3Image = this.Button3UpImage;
            this.Button4Image = this.Button4UpImage;
            this.Invalidate();
        }
        private decimal _ValueScaleFactor = 1;

        //*****************************************
        //* Property - What to do to bit in PLC
        //*****************************************
        private OutputType m_OutputType = OutputType.MomentarySet;

        //****************************
        //* Event - Button Click
        //****************************
        //********************************************
        //* Property - Address in PLC for click event
        //********************************************
        private string m_PLCAddressClick1 = string.Empty;

        private string m_PLCAddressClick2 = string.Empty;

        private string m_PLCAddressClick3 = string.Empty;

        private string m_PLCAddressClick4 = string.Empty;

        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string m_PLCAddressValue = string.Empty;

        private string OriginalText;



        [Category("PLC Properties")]
        [Editor(typeof(TestDialogEditor), typeof(UITypeEditor))]
        public string PLCAddressValue
        {
            get { return m_PLCAddressValue; }
            set
            {
                if (m_PLCAddressValue != value)
                {
                    m_PLCAddressValue = value;
                    try
                    {
                        //* When address is changed, re-subscribe to new address
                        if (string.IsNullOrEmpty(m_PLCAddressValue) || string.IsNullOrWhiteSpace(m_PLCAddressValue) ||
                            Licenses.LicenseManager.IsInDesignMode) return;
                        var bd = new Binding("Value", TagCollectionClient.Tags[m_PLCAddressValue], "Value", true);
                        DataBindings.Add(bd);
                    }
                    catch (Exception ex)
                    {
                        DisplayError(ex.Message);
                    }
                }
            }
        }

        [Category("Numeric Display")]
        public decimal ScaleFactor
        {
            get { return _ValueScaleFactor; }
            set { _ValueScaleFactor = value; }
        }

        [Category("PLC Properties")]
        [Editor(typeof(TestDialogEditor), typeof(UITypeEditor))]
        public string PLCAddressClick1
        {
            get { return m_PLCAddressClick1; }
            set { m_PLCAddressClick1 = value; }
        }

        [Category("PLC Properties")]
        [Editor(typeof(TestDialogEditor), typeof(UITypeEditor))]
        public string PLCAddressClick2
        {
            get { return m_PLCAddressClick2; }
            set { m_PLCAddressClick2 = value; }
        }

        [Category("PLC Properties")]
        [Editor(typeof(TestDialogEditor), typeof(UITypeEditor))]
        public string PLCAddressClick3
        {
            get { return m_PLCAddressClick3; }
            set { m_PLCAddressClick3 = value; }
        }

        [Category("PLC Properties")]
        [Editor(typeof(TestDialogEditor), typeof(UITypeEditor))]
        public string PLCAddressClick4
        {
            get { return m_PLCAddressClick4; }
            set { m_PLCAddressClick4 = value; }
        }

        [Category("PLC Properties")]
        public OutputType OutputType
        {
            get { return m_OutputType; }
            set { m_OutputType = value; }
        }

        [DefaultValue(false)]
        public bool SuppressErrorDisplay { get; set; }

        private void _Click1(object sender, EventArgs e)
        {
            MouseDownAction(m_PLCAddressClick1);
        }

        private void _MouseUp1(object sender, EventArgs e)
        {
            MouseUpAction(m_PLCAddressClick1);
        }

        private void _click2(object sender, EventArgs e)
        {
            MouseDownAction(m_PLCAddressClick2);
        }

        private void _MouseUp2(object sender, EventArgs e)
        {
            MouseUpAction(m_PLCAddressClick2);
        }

        private void _click3(object sender, EventArgs e)
        {
            MouseDownAction(m_PLCAddressClick3);
        }

        private void _MouseUp3(object sender, EventArgs e)
        {
            MouseUpAction(m_PLCAddressClick3);
        }

        private void _click4(object sender, EventArgs e)
        {
            MouseDownAction(m_PLCAddressClick4);
        }

        private void _MouseUp4(object sender, EventArgs e)
        {
            MouseUpAction(m_PLCAddressClick4);
        }


        private void MouseDownAction(string PLCAddress)
        {
            if (PLCAddress != null && string.Compare(PLCAddress, string.Empty) != 0)
                try
                {
                    switch (m_OutputType)
                    {
                        case OutputType.MomentarySet:
                            WCFChannelFactory.Write(PLCAddress, "1");
                            break;
                        case OutputType.MomentaryReset:
                            WCFChannelFactory.Write(PLCAddress, "0");
                            break;
                        case OutputType.SetTrue:
                            WCFChannelFactory.Write(PLCAddress, "1");
                            break;
                        case OutputType.SetFalse:
                            WCFChannelFactory.Write(PLCAddress, "0");
                            break;
                        case OutputType.Toggle:
                            var CurrentValue = false;
                            CurrentValue = Convert.ToBoolean(PLCAddress);
                            if (CurrentValue)
                                WCFChannelFactory.Write(PLCAddress, "0");
                            else
                                WCFChannelFactory.Write(PLCAddress, "1");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    DisplayError(ex.Message);
                }
        }

        private void MouseUpAction(string PLCAddress)
        {
            if (PLCAddress != null && (string.Compare(PLCAddress, string.Empty) != 0) & Enabled)
                try
                {
                    switch (OutputType)
                    {
                        case OutputType.MomentarySet:
                            WCFChannelFactory.Write(PLCAddress, "0");
                            break;
                        case OutputType.MomentaryReset:
                            WCFChannelFactory.Write(PLCAddress, "1");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    DisplayError(ex.Message);
                }
        }

        #region "Error Display"

        //********************************************************
        //* Show an error via the text property for a short time
        //********************************************************
        private Timer ErrorDisplayTime;

        private void DisplayError(string ErrorMessage)
        {
            if (!SuppressErrorDisplay)
            {
                if (ErrorDisplayTime == null)
                {
                    ErrorDisplayTime = new Timer();
                    ErrorDisplayTime.Tick += ErrorDisplay_Tick;
                    ErrorDisplayTime.Interval = 6000;
                }

                //* Save the text to return to
                if (!ErrorDisplayTime.Enabled) OriginalText = Text;

                ErrorDisplayTime.Enabled = true;

                Text = ErrorMessage;
            }
        }

        //**************************************************************************************
        //* Return the text back to its original after displaying the error for a few seconds.
        //**************************************************************************************
        private void ErrorDisplay_Tick(object sender, EventArgs e)
        {
            Text = OriginalText;

            if (ErrorDisplayTime != null)
            {
                ErrorDisplayTime.Enabled = false;
                ErrorDisplayTime.Dispose();
                ErrorDisplayTime = null;
            }
        }

        #endregion

    }


}