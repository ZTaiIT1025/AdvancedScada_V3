
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvancedScada.Controls.SevenSegment
{
    [ToolboxItem(false)]
    public class SevenSegmentGDI : System.Windows.Forms.Control
    {
        private Point[] point_0;

        private Point[] point_1;

        private Point[] point_2;

        private Point[] point_3;

        private Point[] point_4;

        private Point[] point_5;

        private Point[] point_6;

        private Bitmap[] bitmap_0;

        private Bitmap[] bitmap_1;

        private Bitmap bitmap_2;

        private Bitmap bitmap_3;

        private float float_0;

        private Rectangle rectangle_0;

        private StringFormat stringFormat_0;

        private SolidBrush solidBrush_0;

        private bool bool_0;

        private double double_0;

        private float float_1;

        private float float_2;

        private decimal decimal_0;

        private decimal decimal_1;

        private int int_0;

        private int int_1;

        private bool bool_1;

        private float float_3;

        private float float_4;

        private int int_2;

        private Bitmap bitmap_4;

        private int int_3;

        private int int_4;

        private float float_5;

        [Category("Numeric Display")]
        public decimal _ValueScaleFactor
        {
            get
            {
                return this.decimal_0;
            }
            set
            {
                this.decimal_0 = value;
                base.Invalidate();
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams exStyle = base.CreateParams;
                exStyle.ExStyle |= 32;
                return exStyle;
            }
        }

        [Category("Numeric Display")]
        public int DecimalPosition
        {
            get
            {
                return this.int_1;
            }
            set
            {
                if (value != this.int_1)
                {
                    this.int_1 = Math.Max(Math.Min(this.int_0 - 1, value), 0);
                    this.method_3();
                }
            }
        }

        [Category("Numeric Display")]
        public float MaxValueForRed
        {
            get
            {
                return this.float_2;
            }
            set
            {
                if (value != this.float_2)
                {
                    this.float_2 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Numeric Display")]
        public float MinValueForRed
        {
            get
            {
                return this.float_1;
            }
            set
            {
                if (value != this.float_1)
                {
                    this.float_1 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Numeric Display")]
        public int NumberOfDigits
        {
            get
            {
                return this.int_0;
            }
            set
            {
                if (value != this.int_0)
                {
                    this.int_0 = Math.Max(Math.Min(50, value), 1);
                    this.method_1();
                    this.method_3();
                }
            }
        }

        [Category("Numeric Display")]
        public decimal Resolution
        {
            get
            {
                return this.decimal_1;
            }
            set
            {
                if (decimal.Compare(value, decimal.Zero) != 0)
                {
                    this.decimal_1 = value;
                    base.Invalidate();
                }
            }
        }

        public bool ShowOffSegments
        {
            get
            {
                return this.bool_1;
            }
            set
            {
                if (this.bool_1 != value)
                {
                    this.bool_1 = value;
                    this.method_3();
                }
            }
        }

        [Category("Numeric Display")]
        public double Value
        {
            get
            {
                return this.double_0;
            }
            set
            {
                if (value != this.double_0)
                {
                    this.double_0 = value;
                    base.Invalidate();
                    this.OnValueChanged(EventArgs.Empty);
                }
            }
        }

        public SevenSegmentGDI() : base()
        {
            this.point_0 = new Point[12];
            this.point_1 = new Point[12];
            this.point_2 = new Point[12];
            this.point_3 = new Point[12];
            this.point_4 = new Point[7];
            this.point_5 = new Point[17];
            this.point_6 = new Point[17];
            this.bitmap_0 = new Bitmap[12];
            this.bitmap_1 = new Bitmap[12];
            this.rectangle_0 = new Rectangle();
            this.stringFormat_0 = new StringFormat();
            this.bool_0 = true;
            this.float_1 = 100.0F;
            this.float_2 = 200.0F;
            this.decimal_0 = decimal.One;
            this.decimal_1 = decimal.One;
            this.int_0 = 5;
            this.int_1 = 0;
            this.bool_1 = true;
            this.int_2 = 340;
            this.float_5 = (float)(486 / ((double)(340 * this.int_0) * 1.1));
            this.method_2();
            base.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            if ((base.ForeColor == Color.FromKnownColor(KnownColor.ControlText)) || (this.ForeColor == Color.FromArgb(0, 0, 0, 0)))
            {
                this.ForeColor = Color.LightGray;
            }
            this.BackColor = Color.Transparent;
            this.method_1();
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    this.bitmap_2.Dispose();
                    int length = this.bitmap_0.Length - 1;
                    int num = 0;
                    do
                    {
                        if (this.bitmap_0[num] != null)
                        {
                            this.bitmap_0[num].Dispose();
                        }
                        if (this.bitmap_1[num] != null)
                        {
                            this.bitmap_1[num].Dispose();
                        }
                        num = num + 1;
                    } while (num <= length);
                    this.solidBrush_0.Dispose();
                    this.stringFormat_0.Dispose();
                    this.bitmap_4.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        private void method_0(object sender, EventArgs e)
        {
            if (base.Height != this.int_4 | base.Width != this.int_3)
            {
                this.method_1();
                this.int_3 = base.Width;
                this.int_4 = base.Height;
                this.method_3();
            }
        }

        private void method_1()
        {
            this.float_5 = (float)(486 / ((double)(340 * this.int_0) * 1.1));
            if (this.int_4 < base.Height || this.int_3 < base.Width)
            {
                if ((double)base.Height / (double)base.Width <= (double)this.float_5)
                {
                    base.Height = Convert.ToInt32(Math.Round((double)((float)base.Width * this.float_5)));
                }
                else
                {
                    base.Width = Convert.ToInt32(Math.Round((double)((float)base.Height / this.float_5)));
                }
            }
            else if ((double)base.Height / (double)base.Width <= (double)this.float_5)
            {
                base.Width = Convert.ToInt32(Math.Round((double)((float)base.Height / this.float_5)));
            }
            else
            {
                base.Height = Convert.ToInt32(Math.Round((double)((float)base.Width * this.float_5)));
            }
        }

        private void method_2()
        {
            this.point_0[0] = new Point(75, 110);
            this.point_0[1] = new Point(47, 415);
            this.point_0[2] = new Point(98, 471);
            this.point_0[3] = new Point(157, 417);
            this.point_0[4] = new Point(182, 125);
            this.point_0[5] = new Point(88, 21);
            this.point_0[6] = new Point(88, 21);
            this.point_0[7] = new Point(85, 27);
            this.point_0[8] = new Point(82, 32);
            this.point_0[9] = new Point(80, 38);
            this.point_0[10] = new Point(79, 44);
            this.point_0[11] = new Point(74, 110);
            this.point_1[0] = new Point(580, 471);
            this.point_1[1] = new Point(641, 415);
            this.point_1[2] = new Point(668, 110);
            this.point_1[3] = new Point(673, 44);
            this.point_1[4] = new Point(673, 44);
            this.point_1[5] = new Point(674, 38);
            this.point_1[6] = new Point(673, 31);
            this.point_1[7] = new Point(671, 26);
            this.point_1[8] = new Point(669, 20);
            this.point_1[9] = new Point(557, 123);
            this.point_1[10] = new Point(531, 417);
            this.point_1[11] = new Point(580, 471);
            this.point_2[0] = new Point(96, 499);
            this.point_2[1] = new Point(35, 555);
            this.point_2[2] = new Point(8, 858);
            this.point_2[3] = new Point(3, 924);
            this.point_2[4] = new Point(3, 924);
            this.point_2[5] = new Point(2, 930);
            this.point_2[6] = new Point(3, 937);
            this.point_2[7] = new Point(5, 942);
            this.point_2[8] = new Point(7, 948);
            this.point_2[9] = new Point(119, 845);
            this.point_2[10] = new Point(145, 553);
            this.point_2[11] = new Point(96, 499);
            this.point_3[0] = new Point(602, 858);
            this.point_3[1] = new Point(629, 555);
            this.point_3[2] = new Point(578, 499);
            this.point_3[3] = new Point(519, 553);
            this.point_3[4] = new Point(493, 847);
            this.point_3[5] = new Point(586, 949);
            this.point_3[6] = new Point(586, 949);
            this.point_3[7] = new Point(590, 943);
            this.point_3[8] = new Point(593, 937);
            this.point_3[9] = new Point(595, 931);
            this.point_3[10] = new Point(597, 924);
            this.point_3[11] = new Point(602, 858);
            this.point_4[0] = new Point(515, 430);
            this.point_4[1] = new Point(171, 430);
            this.point_4[2] = new Point(111, 485);
            this.point_4[3] = new Point(161, 540);
            this.point_4[4] = new Point(505, 540);
            this.point_4[5] = new Point(565, 485);
            this.point_4[6] = new Point(515, 430);
            this.point_5[0] = new Point(475, 858);
            this.point_5[1] = new Point(133, 858);
            this.point_5[2] = new Point(21, 962);
            this.point_5[3] = new Point(21, 962);
            this.point_5[4] = new Point(26, 965);
            this.point_5[5] = new Point(31, 966);
            this.point_5[6] = new Point(37, 968);
            this.point_5[7] = new Point(43, 968);
            this.point_5[8] = new Point(109, 968);
            this.point_5[9] = new Point(483, 968);
            this.point_5[10] = new Point(549, 968);
            this.point_5[11] = new Point(549, 968);
            this.point_5[12] = new Point(554, 968);
            this.point_5[13] = new Point(560, 967);
            this.point_5[14] = new Point(565, 965);
            this.point_5[15] = new Point(570, 962);
            this.point_5[16] = new Point(475, 858);
            this.point_6[0] = new Point(192, 110);
            this.point_6[1] = new Point(543, 110);
            this.point_6[2] = new Point(655, 6);
            this.point_6[3] = new Point(655, 6);
            this.point_6[4] = new Point(650, 4);
            this.point_6[5] = new Point(645, 2);
            this.point_6[6] = new Point(639, 0);
            this.point_6[7] = new Point(633, 0);
            this.point_6[8] = new Point(567, 0);
            this.point_6[9] = new Point(193, 0);
            this.point_6[10] = new Point(127, 0);
            this.point_6[11] = new Point(127, 0);
            this.point_6[12] = new Point(121, 0);
            this.point_6[13] = new Point(115, 2);
            this.point_6[14] = new Point(109, 4);
            this.point_6[15] = new Point(103, 7);
            this.point_6[16] = new Point(197, 110);
        }

        private void method_3()
        {
            Graphics graphic = null;
            this.float_5 = (float)(486 / ((double)(340 * this.int_0) * 1.1));
            float width = (float)((double)base.Width / ((double)(340 * this.int_0) * 1.1));
            float height = (float)((double)base.Height / 486);
            if (width >= height)
            {
                this.float_3 = (float)base.Width;
                this.float_4 = (float)(486 / (double)(340 * this.int_0) * (double)base.Width);
                this.float_0 = height;
            }
            else
            {
                this.float_4 = (float)base.Height;
                if (base.Height <= 0)
                {
                    this.float_3 = 1.0F;
                }
                else
                {
                    this.float_3 = (float)((double)(340 * this.int_0) * 1.1 / 486 * (double)base.Height);
                }
                this.float_0 = width;
            }
            if (this.float_0 > 0.0F)
            {
                this.rectangle_0.X = 0;
                this.rectangle_0.Y = Convert.ToInt32(Math.Round((double)base.Height * 0.04));
                this.rectangle_0.Width = base.Width;
                this.rectangle_0.Height = Convert.ToInt32(Math.Round((double)base.Height * 0.18));
                if (this.solidBrush_0 == null)
                {
                    this.solidBrush_0 = new SolidBrush(base.ForeColor);
                }
                int num = Convert.ToInt32(340.0F * this.float_0);
                int num1 = Convert.ToInt32(486.0F * this.float_0);
                int num2 = 0;
                do
                {
                    if (this.bitmap_0[num2] != null)
                    {
                        this.bitmap_0[num2].Dispose();
                    }
                    this.bitmap_0[num2] = new Bitmap(num, num1);
                    graphic = Graphics.FromImage(this.bitmap_0[num2]);
                    graphic.ScaleTransform(0.0925F, 0.095F);
                    this.method_4(graphic, num2, Color.Red);
                    num2 = num2 + 1;
                } while (num2 <= 11);
                int num3 = 0;
                do
                {
                    if (this.bitmap_1[num3] != null)
                    {
                        this.bitmap_1[num3].Dispose();
                    }
                    this.bitmap_1[num3] = new Bitmap(num, num1);
                    graphic = Graphics.FromImage(this.bitmap_1[num3]);
                    graphic.ScaleTransform((float)((double)num / 700), (float)((double)num / 700));
                    this.method_4(graphic, num3, Color.Green);
                    num3 = num3 + 1;
                } while (num3 <= 11);
                this.bitmap_2 = new Bitmap(Convert.ToInt32(50.0F * this.float_0), Convert.ToInt32(50.0F * this.float_0));
                graphic = Graphics.FromImage(this.bitmap_2);
                System.Drawing.Point[] point =
                {
                        new System.Drawing.Point(Convert.ToInt32(Math.Round((double)this.bitmap_2.Width / 2)), 0),
                        new System.Drawing.Point(this.bitmap_2.Width, Convert.ToInt32(Math.Round((double)this.bitmap_2.Height / 2))),
                        new System.Drawing.Point(Convert.ToInt32(Math.Round((double)this.bitmap_2.Width / 2)), this.bitmap_2.Height),
                        new System.Drawing.Point(0, Convert.ToInt32(Math.Round((double)this.bitmap_2.Height / 2))),
                        new System.Drawing.Point(Convert.ToInt32(Math.Round((double)this.bitmap_2.Width / 2)), 0)
                    };
                graphic.FillPolygon(new SolidBrush(Color.Red), point);
                this.bitmap_3 = new Bitmap(Convert.ToInt32(50.0F * this.float_0), Convert.ToInt32(50.0F * this.float_0));
                graphic = Graphics.FromImage(this.bitmap_3);
                graphic.FillPolygon(new SolidBrush(Color.Green), point);
                graphic.Dispose();
                if (this.bitmap_4 != null)
                {
                    this.bitmap_4.Dispose();
                }
                this.bitmap_4 = new Bitmap(base.Width, base.Height);
                this.bool_0 = true;
                base.Invalidate();
            }
        }

        private void method_4(Graphics graphics_0, int int_5, Color color_0)
        {
            System.Drawing.SolidBrush solidBrush = new System.Drawing.SolidBrush(color_0);
            System.Drawing.SolidBrush solidBrush1 = new System.Drawing.SolidBrush(Color.FromArgb(64, 0, 0, 0));
            graphics_0.CompositingQuality = CompositingQuality.HighQuality;
            graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
            if (int_5 == 0 || int_5 == 4 || int_5 == 5 || int_5 == 6 || int_5 == 8 || int_5 == 9)
            {
                graphics_0.FillPolygon(solidBrush, this.point_0);
            }
            else if (this.bool_1)
            {
                graphics_0.FillPolygon(solidBrush1, this.point_0);
            }
            if (!(int_5 == 5 || int_5 == 6 || int_5 == 10 || int_5 == 11))
            {
                graphics_0.FillPolygon(solidBrush, this.point_1);
            }
            else if (this.bool_1)
            {
                graphics_0.FillPolygon(solidBrush1, this.point_1);
            }
            if (int_5 == 0 || int_5 == 2 || int_5 == 6 || int_5 == 8)
            {
                graphics_0.FillPolygon(solidBrush, this.point_2);
            }
            else if (this.bool_1)
            {
                graphics_0.FillPolygon(solidBrush1, this.point_2);
            }
            if (!(int_5 == 2 || int_5 == 10 || int_5 == 11))
            {
                graphics_0.FillPolygon(solidBrush, this.point_3);
            }
            else if (this.bool_1)
            {
                graphics_0.FillPolygon(solidBrush1, this.point_3);
            }
            if (!(int_5 == 0 || int_5 == 1 || int_5 == 7 || int_5 == 10))
            {
                graphics_0.FillPolygon(solidBrush, this.point_4);
            }
            else if (this.bool_1)
            {
                graphics_0.FillPolygon(solidBrush1, this.point_4);
            }
            if (!(int_5 == 1 || int_5 == 4 || int_5 == 7 || int_5 == 9 || int_5 == 10 || int_5 == 11))
            {
                graphics_0.FillPolygon(solidBrush, this.point_5);
            }
            else if (this.bool_1)
            {
                graphics_0.FillPolygon(solidBrush1, this.point_5);
            }
            if (!(int_5 == 1 || int_5 == 4 || int_5 == 10 || int_5 == 11))
            {
                graphics_0.FillPolygon(solidBrush, this.point_6);
            }
            else if (this.bool_1)
            {
                graphics_0.FillPolygon(solidBrush1, this.point_6);
            }
        }

        protected override void OnCreateControl()
        {
            this.stringFormat_0.Alignment = StringAlignment.Center;
            this.stringFormat_0.LineAlignment = StringAlignment.Far;
            base.OnCreateControl();
        }

        protected override void OnFontChanged(EventArgs eventArgs_0)
        {
            base.OnFontChanged(eventArgs_0);
            base.Invalidate();
        }

        protected override void OnForeColorChanged(EventArgs eventArgs_0)
        {
            base.OnForeColorChanged(eventArgs_0);
            if (this.solidBrush_0 != null)
            {
                this.solidBrush_0.Color = base.ForeColor;
            }
            else
            {
                this.solidBrush_0 = new SolidBrush(base.ForeColor);
            }
            base.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            bool flag = false;
            if (!(this.bitmap_4 == null || this.solidBrush_0 == null))
            {
                using (Graphics graphic = Graphics.FromImage(this.bitmap_4))
                {
                    graphic.Clear(this.BackColor);
                    if (this.BackgroundImage != null)
                    {
                        if (this.BackgroundImageLayout != ImageLayout.Stretch)
                        {
                            graphic.DrawImage(this.BackgroundImage, 0, 0);
                        }
                        else
                        {
                            graphic.DrawImage(this.BackgroundImage, 0, 0, base.Width, base.Height);
                        }
                    }
                    decimal one = decimal.Divide(decimal.One, this.decimal_1);
                    if (decimal.Compare(one, decimal.Zero) == 0)
                    {
                        one = decimal.One;
                    }
                    long num = Convert.ToInt64(Math.Round(this.double_0 * Convert.ToDouble(one) * Convert.ToDouble(this.decimal_0)));
                    long num1 = Convert.ToInt64(decimal.Divide(new decimal(num), one));
                    if (!((double)num1 <= Math.Pow(10, (double)this.int_0) - 1 && (double)num1 >= (Math.Pow(10, (double)(this.int_0 - 1)) - 1) * -1))
                    {
                        int int0 = this.int_0;
                        for (int i = 1; i <= int0; i++)
                        {
                            graphic.DrawImage(this.bitmap_0[11], (float)(this.int_2 * (i - 1)) * this.float_0, 0.0F);
                        }

                    }
                    else
                    {
                        int int01 = this.int_0;
                        for (int j = 1; j <= int01; j++)
                        {
                            if (num1 >= (long)0)
                            {
                                int num2 = Convert.ToInt32(Math.Floor((double)num1 / Math.Pow(10, (double)(this.int_0 - j))));
                                if (num2 > 0 || j == this.int_0 || j > this.int_0 - this.int_1)
                                {
                                    flag = true;
                                }
                                if (flag)
                                {
                                    if (!(this.double_0 >= (double)this.float_1 && this.double_0 <= (double)this.float_2))
                                    {
                                        graphic.DrawImage(this.bitmap_1[num2], (float)Convert.ToInt32((double)(this.int_2 * (j - 1)) * 1.1) * this.float_0, 0.0F);
                                    }
                                    else
                                    {
                                        graphic.DrawImage(this.bitmap_0[num2], (float)Convert.ToInt32((double)(this.int_2 * (j - 1)) * 1.1) * this.float_0, 0.0F);
                                    }
                                }
                                else if (!(this.double_0 >= (double)this.float_1 && this.double_0 <= (double)this.float_2))
                                {
                                    graphic.DrawImage(this.bitmap_1[10], (float)Convert.ToInt32((double)(this.int_2 * (j - 1)) * 1.1) * this.float_0, 0.0F);
                                }
                                else
                                {
                                    graphic.DrawImage(this.bitmap_0[10], (float)Convert.ToInt32((double)(this.int_2 * (j - 1)) * 1.1) * this.float_0, 0.0F);
                                }
                                num1 = Convert.ToInt64(Math.Round((double)num1 - (double)num2 * Math.Pow(10, (double)(this.int_0 - j))));
                            }
                            else
                            {
                                if (!(this.double_0 >= (double)this.float_1 && this.double_0 <= (double)this.float_2))
                                {
                                    graphic.DrawImage(this.bitmap_1[11], (float)(this.int_2 * (j - 1)) * this.float_0, 0.0F);
                                }
                                else
                                {
                                    graphic.DrawImage(this.bitmap_0[11], (float)(this.int_2 * (j - 1)) * this.float_0, 0.0F);
                                }
                                num1 = Math.Abs(num1);
                            }
                        }

                    }
                    if (this.int_1 > 0)
                    {
                        if (!(this.double_0 >= (double)this.float_1 && this.double_0 <= (double)this.float_2))
                        {
                            graphic.DrawImage(this.bitmap_3, (float)Convert.ToInt32((double)((float)((this.int_0 - this.int_1) * this.int_2 - 50) * this.float_0) * 1.1), 440.0F * this.float_0);
                        }
                        else
                        {
                            graphic.DrawImage(this.bitmap_2, (float)Convert.ToInt32((double)((float)((this.int_0 - this.int_1) * this.int_2 - 50) * this.float_0) * 1.1), 440.0F * this.float_0);
                        }
                    }
                    pevent.Graphics.DrawImage(this.bitmap_4, 0, 0);
                }
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            this.bool_0 = false;
        }

        protected override void OnSizeChanged(EventArgs eventArgs_0)
        {
            if (this.bitmap_4 != null)
            {
                this.bitmap_4.Dispose();
                this.bitmap_4 = null;
            }
            this.method_0(this, null);
            base.OnSizeChanged(eventArgs_0);
        }

        protected override void OnTextChanged(EventArgs eventArgs_0)
        {
            base.OnTextChanged(eventArgs_0);
            base.Invalidate();
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, e);
        }

        public event EventHandler ValueChanged;

    }


}