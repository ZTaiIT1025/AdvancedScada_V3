
using AdvancedScada;
using AdvancedScada.Controls;
using AdvancedScada.Controls.DialogEditor;
using AdvancedScada.Controls.Keyboard;
using AdvancedScada.Controls.Licenses;
using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Client;
using AdvancedScada.Monitor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml.Linq;

namespace AdvancedScada.Controls.DigitalDisplay
{
    public class HMIDigitalPanelMeter : Control
    {
        public event EventHandler ValueChanged;
        #region Faild
        private Rectangle TextRect = new Rectangle();

        private Bitmap StaticImage;

        private Bitmap[] LED = new Bitmap[12];

        private Bitmap DecimalImage;

        private float ImageRatio;

        private Rectangle TextRectangle;

        private StringFormat sf;

        private SolidBrush TextBrush;

        private float x;

        private float y;

        private float m_Value;

        private decimal m_ValueScaleFactor;

        private decimal m_ValueScaleOffset;

        private decimal m_Resolution;

        private int m_NumberOfDigits;

        private int m_DecimalPos;

        private int SegWidth;

        private Bitmap _backBuffer;

        private int LastWidth;

        private int LastHeight;

        private float StaticImageRatio;
        #endregion

        #region Property
        [Category("Numeric Display")]
        public int DecimalPosition
        {
            get
            {
                return m_DecimalPos;
            }
            set
            {
                m_DecimalPos = Math.Max(Math.Min(m_NumberOfDigits - 1, value), 0);
                Invalidate();
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
                if (TextBrush != null)
                {
                    TextBrush.Color = value;
                }
                else
                {
                    TextBrush = new SolidBrush(value);
                }
                base.ForeColor = value;
                Invalidate();
            }
        }

        [Category("Numeric Display")]
        public int NumberOfDigits
        {
            get
            {
                return m_NumberOfDigits;
            }
            set
            {
                if (value != m_NumberOfDigits)
                {
                    m_NumberOfDigits = Math.Max(Math.Min(6, value), 4);
                    AdjustSize();
                    RefreshImage();
                }
            }
        }

        [Category("Numeric Display")]
        public decimal Resolution
        {
            get
            {
                return m_Resolution;
            }
            set
            {
                if (decimal.Compare(value, decimal.Zero) != 0)
                {
                    m_Resolution = value;
                    if (StaticImage != null)
                    {
                        Invalidate();
                    }
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
                Invalidate();
            }
        }

        [Category("Numeric Display")]
        public float Value
        {
            get
            {
                return m_Value;
            }
            set
            {
                if (value != m_Value)
                {
                    m_Value = value;
                    Rectangle rectangle = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)StaticImage.Width * 0.08))), Convert.ToInt32(Math.Truncate(Math.Round((double)StaticImage.Height * 0.1))), Convert.ToInt32(Math.Truncate(Math.Round((double)StaticImage.Width * 0.85))), Convert.ToInt32(Math.Truncate(Math.Round((double)StaticImage.Height * 0.8))));
                    Invalidate(rectangle);
                    OnValueChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Numeric Display")]
        public decimal ValueScaleFactor
        {
            get
            {
                return m_ValueScaleFactor;
            }
            set
            {
                if (decimal.Compare(m_ValueScaleFactor, value) != 0)
                {
                    m_ValueScaleFactor = value;
                    Invalidate();
                    OnValueChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Numeric Display")]
        public decimal ValueScaleOffset
        {
            get
            {
                return m_ValueScaleOffset;
            }
            set
            {
                if (decimal.Compare(m_ValueScaleOffset, value) != 0)
                {
                    m_ValueScaleOffset = value;
                    Invalidate();
                    OnValueChanged(EventArgs.Empty);
                }
            }
        }
        //*****************************************
        //* Property - Text on Legend Plate
        //*****************************************
        private string m_LegendText = "Text";
        public string LegendText
        {
            get
            {
                return m_LegendText;
            }
            set
            {
                m_LegendText = value;
                RefreshImage();
                this.Invalidate();
            }
        }

        public BackgroundColor BackgroundColors
        {
            get
            {
                return _backgroundColor1;
            }
            set
            {
                _backgroundColor1 = value;
                RefreshImage();
                this.Invalidate();
            }
        }
        #endregion
        #region Constructor

        public HMIDigitalPanelMeter()
        {


            TextRectangle = new Rectangle();
            m_ValueScaleFactor = decimal.One;
            m_Resolution = decimal.One;
            m_NumberOfDigits = 5;
            m_DecimalPos = 0;
            SegWidth = 75;
            //m_LegendText = "KG"
            StaticImageRatio = (float)((double)Properties.Resources.DigitalPanelMeter.Height / (double)Properties.Resources.DigitalPanelMeter.Width);
            _backgroundColor1 = BackgroundColor.Black;

            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            if ((base.ForeColor == Color.FromKnownColor(KnownColor.ControlText)) || (ForeColor == Color.FromArgb(0, 0, 0, 0)))
            {
                ForeColor = Color.LightGray;
            }
            AdjustSize();
            sf = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Far
            };
        }
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    if (StaticImage != null)
                    {
                        StaticImage.Dispose();
                    }
                    if (DecimalImage != null)
                    {
                        DecimalImage.Dispose();
                    }
                    int length = (LED.Length) - 1;
                    for (int i = 0; i <= length; i++)
                    {
                        if (LED[i] != null)
                        {
                            LED[i].Dispose();
                        }
                    }
                    TextBrush.Dispose();
                    sf.Dispose();
                    _backBuffer.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }
        #endregion
        #region Overrides Sub
        private void AdjustSize()
        {
            StaticImageRatio = (float)((double)Properties.Resources.DigitalPanelMeter.Height / (double)(Properties.Resources.DigitalPanelMeter.Width + (m_NumberOfDigits - 4) * SegWidth));
            if (LastHeight < Height || LastWidth < Width)
            {
                if ((float)(Height / (double)Width) <= StaticImageRatio)
                {
                    Height = Convert.ToInt32(Math.Truncate(Math.Round((double)((float)Width * StaticImageRatio))));
                }
                else
                {
                    Width = Convert.ToInt32(Math.Truncate(Math.Round((double)((float)Height / StaticImageRatio))));
                }
            }
            else if ((float)(Height / (double)Width) <= StaticImageRatio)
            {
                Width = Convert.ToInt32(Math.Truncate(Math.Round((double)((float)Height / StaticImageRatio))));
            }
            else
            {
                Height = Convert.ToInt32(Math.Truncate(Math.Round((double)((float)Width * StaticImageRatio))));
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            bool DigitsStarted = false;
            if (!(StaticImage == null || _backBuffer == null || TextBrush == null))
            {
                using (Graphics g = Graphics.FromImage(_backBuffer))
                {
                    g.Clear(base.BackColor);
                    g.FillRectangle(new SolidBrush(BackColor), 0, 0, Width, Height);

                    g.DrawImage(StaticImage, 0, 0);

                    if ((base.Text == null || string.Compare(base.Text, string.Empty) == 0) ? false : true)
                    {
                        if (TextBrush.Color != base.ForeColor)
                        {
                            TextBrush.Color = base.ForeColor;
                        }
                        g.DrawString(base.Text, base.Font, TextBrush, TextRectangle, sf);
                    }

                    decimal one = decimal.Divide(decimal.One, m_Resolution);
                    if (decimal.Compare(one, decimal.Zero) == 0)
                    {
                        one = decimal.One;
                    }
                    SolidBrush b = new SolidBrush(Color.FromArgb(250, 130, 140, 160));

                    long num = Convert.ToInt64(Math.Truncate(Math.Round((m_Value + Convert.ToDouble(m_ValueScaleOffset)) * Convert.ToDouble(one) * Convert.ToDouble(m_ValueScaleFactor))));
                    long WorkValue = Convert.ToInt64(decimal.Divide(new decimal(num), one));
                    if (!(WorkValue <= Math.Pow(10, m_NumberOfDigits) - 1 && WorkValue >= (Math.Pow(10, m_NumberOfDigits - 1) - 1) * -1))
                    {
                        int mNumberOfDigits = m_NumberOfDigits;
                        for (int i = 1; i <= mNumberOfDigits; i++)
                        {
                            g.DrawImage(LED[11], (75 + SegWidth * (i - 1)) * ImageRatio, 65.0F * ImageRatio);
                        }
                    }
                    else
                    {
                        int mNumberOfDigits1 = m_NumberOfDigits;
                        int j = 0;
                        for (j = 1; j <= mNumberOfDigits1; j++)
                        {
                            if (WorkValue >= 0)
                            {
                                int d = Convert.ToInt32(Math.Floor(WorkValue / Math.Pow(10, m_NumberOfDigits - j)));
                                if (d > 0 || j == m_NumberOfDigits || j > m_NumberOfDigits - m_DecimalPos)
                                {
                                    DigitsStarted = true;
                                }
                                if (!DigitsStarted)
                                {
                                    g.DrawImage(LED[10], (75 + SegWidth * (j - 1)) * ImageRatio, 65.0F * ImageRatio);
                                }
                                else
                                {
                                    g.DrawImage(LED[d], (75 + SegWidth * (j - 1)) * ImageRatio, 65.0F * ImageRatio);

                                }
                                WorkValue = Convert.ToInt64(Math.Truncate(Math.Round((double)WorkValue - (double)d * Math.Pow(10, (double)(m_NumberOfDigits - j)))));
                            }
                            else
                            {
                                g.DrawImage(LED[11], (75 + SegWidth * (j - 1)) * ImageRatio, 65.0F * ImageRatio);
                                WorkValue = Math.Abs(WorkValue);
                            }
                        }
                        //' g.DrawString(m_LegendText, MyBase.Font, TextBrush, (80 + SegWidth * (j - 1)) * ImageRatio, 150.0F * ImageRatio)

                    }
                    if (m_DecimalPos > 0)
                    {
                        g.DrawImage(DecimalImage, (((m_NumberOfDigits - m_DecimalPos) * SegWidth) + 55) * ImageRatio, 160.0F * ImageRatio);
                    }

                    e.Graphics.DrawImage(_backBuffer, 0, 0);
                }
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (_backBuffer != null)
            {
                _backBuffer.Dispose();
                _backBuffer = null;
            }
            RatioLock();
            base.OnSizeChanged(e);
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, e);
        }

        private void RatioLock()
        {
            if (Height != LastHeight | Width != LastWidth)
            {
                AdjustSize();
                LastWidth = Width;
                LastHeight = Height;
                RefreshImage();
            }
        }
        public enum BackgroundColor
        {
            White,
            Black,
            Gray
        }
        private BackgroundColor _backgroundColor1 = BackgroundColor.Black;
        private void RefreshImage()
        {
            //Color.Gray
            StaticImageRatio = (float)((double)Properties.Resources.DigitalPanelMeter.Height / (double)(Properties.Resources.DigitalPanelMeter.Width + (m_NumberOfDigits - 4) * SegWidth));
            float WidthRatio = (float)((double)Width / (double)(Properties.Resources.DigitalPanelMeter.Width + (m_NumberOfDigits - 4 * SegWidth)));
            float HeightRatio = (float)((double)Height / (double)Properties.Resources.DigitalPanelMeter.Height);
            if (WidthRatio >= HeightRatio)
            {
                x = Width;
                y = (float)((double)Properties.Resources.DigitalPanelMeter.Height / (double)(Properties.Resources.DigitalPanelMeter.Width + (m_NumberOfDigits - 4 * SegWidth)) * (double)Width);
                ImageRatio = HeightRatio;
            }
            else
            {
                y = Height;
                if (!(Height > 0 && Properties.Resources.DigitalPanelMeter.Height > 0))
                {
                    x = 1.0F;
                }
                else
                {
                    x = (float)((double)(Properties.Resources.DigitalPanelMeter.Width + (m_NumberOfDigits - 4 * SegWidth)) / (double)Properties.Resources.DigitalPanelMeter.Height * (double)Height);
                }
                ImageRatio = WidthRatio;
            }
            if (ImageRatio > 0.0F)
            {
                if (StaticImage != null)
                {
                    StaticImage.Dispose();
                }
                StaticImage = new Bitmap(Convert.ToInt32((Properties.Resources.DigitalPanelMeter.Width + (m_NumberOfDigits - 4) * SegWidth) * ImageRatio), Convert.ToInt32(Properties.Resources.DigitalPanelMeter.Height * ImageRatio));
                Graphics gr_dest = Graphics.FromImage(StaticImage);
                if (_backgroundColor1 == BackgroundColor.Black)
                {
                    gr_dest.DrawImage(Properties.Resources.DigitalPanelMeter, Convert.ToInt32((m_NumberOfDigits - 4) * SegWidth) * ImageRatio, 0.0F, Properties.Resources.DigitalPanelMeter.Width * ImageRatio, Properties.Resources.DigitalPanelMeter.Height * ImageRatio);
                }
                else if (_backgroundColor1 == BackgroundColor.White)
                {
                    gr_dest.DrawImage(Properties.Resources.DigitalPanelMeter2, Convert.ToInt32((m_NumberOfDigits - 4) * SegWidth) * ImageRatio, 0.0F, Properties.Resources.DigitalPanelMeter.Width * ImageRatio, Properties.Resources.DigitalPanelMeter.Height * ImageRatio);
                }
                else
                {
                    gr_dest.DrawImage(Properties.Resources.DigitalPanelMeter3, Convert.ToInt32((m_NumberOfDigits - 4) * SegWidth) * ImageRatio, 0.0F, Properties.Resources.DigitalPanelMeter.Width * ImageRatio, Properties.Resources.DigitalPanelMeter.Height * ImageRatio);

                }
                if (m_NumberOfDigits > 4)
                {
                    if (_backgroundColor1 == BackgroundColor.Black)
                    {
                        gr_dest.DrawImage(Properties.Resources.DigitalPanelMeterLeftHalf, 0.0F, 0.0F, Properties.Resources.DigitalPanelMeterLeftHalf.Width * ImageRatio, Convert.ToInt32((float)Properties.Resources.DigitalPanelMeterLeftHalf.Height * ImageRatio));

                    }
                    else if (_backgroundColor1 == BackgroundColor.White)
                    {
                        gr_dest.DrawImage(Properties.Resources.DigitalPanelMeterLeftHalf2, 0.0F, 0.0F, Properties.Resources.DigitalPanelMeterLeftHalf.Width * ImageRatio, Convert.ToInt32((float)Properties.Resources.DigitalPanelMeterLeftHalf.Height * ImageRatio));
                    }
                    else
                    {
                        gr_dest.DrawImage(Properties.Resources.DigitalPanelMeterLeftHalf3, 0.0F, 0.0F, Properties.Resources.DigitalPanelMeterLeftHalf.Width * ImageRatio, Convert.ToInt32((float)Properties.Resources.DigitalPanelMeterLeftHalf.Height * ImageRatio));

                    }
                }

                TextRect.X = 5;
                TextRect.Width = Convert.ToInt32(StaticImage.Width / 0.75 / ImageRatio);
                TextRect.Y = 5;
                TextRect.Height = Convert.ToInt32(StaticImage.Height / 0.75 / ImageRatio);
                StringFormat sf2 = new StringFormat();
                sf2.Alignment = StringAlignment.Center;
                sf2.LineAlignment = StringAlignment.Center;

                //gr_dest.DrawRectangle(Pens.Black, TextRect)
                //Dim b As New SolidBrush(Color.FromArgb(250, 130, 140, 160))
                //gr_dest.DrawString(m_LegendText, New Font("Arial", 22, FontStyle.Regular, GraphicsUnit.Point), b, TextRect, sf2)

                TextRectangle.X = 0;
                TextRectangle.Y = Convert.ToInt32(Math.Truncate(Math.Round((double)Height * 0.04)));
                TextRectangle.Width = Width;
                TextRectangle.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)Height * 0.18)));
                if (TextBrush == null)
                {
                    TextBrush = new SolidBrush(base.ForeColor);
                }

                int LEDWidth = Convert.ToInt32(Math.Truncate(Math.Round((double)Convert.ToInt32((float)Properties.Resources.LED7Segment8Red.Width * ImageRatio) * 0.7)));
                int LEDHeight = Convert.ToInt32(Math.Truncate(Math.Round((double)Convert.ToInt32((float)Properties.Resources.LED7Segment8Red.Height * ImageRatio) * 0.7)));
                int i = 0;
                do
                {
                    if (LED[i] != null)
                    {
                        LED[i].Dispose();
                    }
                    LED[i] = new Bitmap(LEDWidth, LEDHeight);
                    gr_dest = Graphics.FromImage(LED[i]);
                    switch (i)
                    {
                        case 0:
                            gr_dest.DrawImage(Properties.Resources.LED7Segment0Red, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 1:
                            gr_dest.DrawImage(Properties.Resources.LED7Segment1Red, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 2:
                            gr_dest.DrawImage(Properties.Resources.LED7Segment2Red, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 3:
                            gr_dest.DrawImage(Properties.Resources.LED7Segment3Red, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 4:
                            gr_dest.DrawImage(Properties.Resources.LED7Segment4Red, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 5:
                            gr_dest.DrawImage(Properties.Resources.LED7Segment5Red, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 6:
                            gr_dest.DrawImage(Properties.Resources.LED7Segment6Red, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 7:
                            gr_dest.DrawImage(Properties.Resources.LED7Segment7Red, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 8:
                            gr_dest.DrawImage(Properties.Resources.LED7Segment8Red, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 9:
                            gr_dest.DrawImage(Properties.Resources.LED7Segment9Red, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 10:
                            gr_dest.DrawImage(Properties.Resources.LED7SegmentOffRed, 0, 0, LEDWidth, LEDHeight);
                            break;
                        case 11:
                            gr_dest.DrawImage(Properties.Resources.LED7Segment_Red, 0, 0, LEDWidth, LEDHeight);
                            break;
                    }
                    i += 1;
                } while (i <= 11);
                DecimalImage = new Bitmap(Convert.ToInt32(Properties.Resources.LED7SegmentDecimalRed.Width * ImageRatio), Convert.ToInt32(Properties.Resources.LED7SegmentDecimalRed.Height * ImageRatio));
                gr_dest = Graphics.FromImage(DecimalImage);
                gr_dest.DrawImage(Properties.Resources.LED7SegmentDecimalRed, 0, 0, Convert.ToInt32(Properties.Resources.LED7SegmentDecimalRed.Width * ImageRatio), Convert.ToInt32(Properties.Resources.LED7SegmentDecimalRed.Height * ImageRatio));
                gr_dest.Dispose();
                if (_backBuffer != null)
                {
                    _backBuffer.Dispose();
                }
                _backBuffer = new Bitmap(Width, Height);
                Invalidate();
            }
        }

        #endregion
        #region propartas

        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string m_PLCAddressText = string.Empty;

        [Category("PLC Properties")]
        [Editor(typeof(TestDialogEditor), typeof(UITypeEditor))]
        public string PLCAddressText
        {
            get { return m_PLCAddressText; }
            set
            {
                if (m_PLCAddressText != value)
                {
                    m_PLCAddressText = value;
                    try
                    {
                        //* When address is changed, re-subscribe to new address
                        if (string.IsNullOrEmpty(m_PLCAddressText) || string.IsNullOrWhiteSpace(m_PLCAddressText) ||
                            Licenses.LicenseManager.IsInDesignMode) return;
                        var bd = new Binding("Text", TagCollectionClient.Tags[m_PLCAddressValue], "Text", true);
                        DataBindings.Add(bd);
                    }
                    catch (Exception ex)
                    {
                        DisplayError(ex.Message);
                    }
                }
            }
        }

        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string m_PLCAddressVisible = string.Empty;

        [Category("PLC Properties")]
        [Editor(typeof(TestDialogEditor), typeof(UITypeEditor))]
        public string PLCAddressVisible
        {
            get { return m_PLCAddressVisible; }
            set
            {
                if (m_PLCAddressVisible != value)
                {
                    m_PLCAddressVisible = value;
                    try
                    {
                        // If Not String.IsNullOrEmpty(m_PLCAddressVisible) Then
                        //* When address is changed, re-subscribe to new address
                        if (string.IsNullOrEmpty(m_PLCAddressVisible) ||
                            string.IsNullOrWhiteSpace(m_PLCAddressVisible) || Licenses.LicenseManager.IsInDesignMode) return;
                        var bd = new Binding("Visible", TagCollectionClient.Tags[m_PLCAddressVisible], "Visible", true);
                        DataBindings.Add(bd);
                        //End If
                    }
                    catch (Exception ex)
                    {
                        DisplayError(ex.Message);
                    }
                }
            }
        }

        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string m_PLCAddressValue = string.Empty;

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

        [DefaultValue(false)]
        public bool SuppressErrorDisplay { get; set; }

        #endregion

        #region "Error Display"

        private string OriginalText;

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

        #region "Keypad popup for data entry"

        private Keypad_v3 KeypadPopUp;

        //*****************************************
        //* Property - Address in PLC to Write Data To
        //*****************************************
        private string m_PLCAddressKeypad = string.Empty;

        [Category("PLC Properties")]
        public string PLCAddressKeypad
        {
            get { return m_PLCAddressKeypad; }
            set
            {
                if (m_PLCAddressKeypad != value) m_PLCAddressKeypad = value;
            }
        }

        public string KeypadText { get; set; }

        private Color m_KeypadFontColor = Color.WhiteSmoke;

        public Color KeypadFontColor
        {
            get { return m_KeypadFontColor; }
            set { m_KeypadFontColor = value; }
        }

        private int m_KeypadWidth = 300;

        public int KeypadWidth
        {
            get { return m_KeypadWidth; }
            set { m_KeypadWidth = value; }
        }

        private double m_KeypadScaleFactor = 1;

        public double KeypadScaleFactor
        {
            get { return m_KeypadScaleFactor; }
            set { m_KeypadScaleFactor = value; }
        }

        public double KeypadMinValue { get; set; }

        public double KeypadMaxValue { get; set; }


        private void KeypadPopUp_ButtonClick(object sender, KeypadEventArgs e)
        {
            if (e.Key == "Quit")
            {
                KeypadPopUp.Visible = false;
            }
            else if (e.Key == "Enter")
            {
                if (KeypadPopUp.Value != null && string.Compare(KeypadPopUp.Value, string.Empty) != 0)
                {
                    try
                    {
                        if (KeypadMaxValue != KeypadMinValue)
                            if ((Convert.ToDouble(KeypadPopUp.Value) < KeypadMinValue) |
                                (Convert.ToDouble(KeypadPopUp.Value) > KeypadMaxValue))
                            {
                                MessageBox.Show("Value must be >" + KeypadMinValue + " and <" + KeypadMaxValue);
                                return;
                            }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to validate value. " + ex.Message);
                        return;
                    }

                    try
                    {
                        if ((KeypadScaleFactor == 1) | (KeypadScaleFactor == 0))
                        {
                            WCFChannelFactory.Write(m_PLCAddressKeypad, KeypadPopUp.Value);
                        }
                        else
                        {
                            var v = Convert.ToDouble(KeypadPopUp.Value);
                            var z = v / m_KeypadScaleFactor;
                            WCFChannelFactory.Write(m_PLCAddressKeypad,
                                (Convert.ToDouble(KeypadPopUp.Value) / m_KeypadScaleFactor).ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to write value. " + ex.Message);
                    }
                }

                KeypadPopUp.Visible = false;
            }
        }

        //***********************************************************
        //* If labeled is clicked, pop up a keypad for data entry
        //***********************************************************
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            if (m_PLCAddressKeypad != null && (string.Compare(m_PLCAddressKeypad, string.Empty) != 0) & Enabled)
            {
                if (KeypadPopUp == null)
                {
                    KeypadPopUp = new Keypad_v3(m_KeypadWidth);
                    KeypadPopUp.ButtonClick += KeypadPopUp_ButtonClick;
                }

                KeypadPopUp.Text = KeypadText;
                KeypadPopUp.ForeColor = m_KeypadFontColor;
                KeypadPopUp.Value = string.Empty;
                KeypadPopUp.StartPosition = FormStartPosition.CenterScreen;
                KeypadPopUp.TopMost = true;
                KeypadPopUp.Show();
            }
        }

        #endregion
    }

    internal class HMIDigitalPanelMeterDesigner : ControlDesigner
    {
        private DesignerActionListCollection actionLists;

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionLists == null)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new HMIDigitalPanelMeterListItem(this));
                }

                return actionLists;
            }
        }
    }

    internal class HMIDigitalPanelMeterListItem : DesignerActionList
    {
        private readonly HMIDigitalPanelMeter _HMIDigitalPanelMeter;

        public HMIDigitalPanelMeterListItem(HMIDigitalPanelMeterDesigner owner)
            : base(owner.Component)
        {
            _HMIDigitalPanelMeter = (HMIDigitalPanelMeter)owner.Component;
        }

        public int DecimalPosition
        {
            get { return _HMIDigitalPanelMeter.DecimalPosition; }
            set { _HMIDigitalPanelMeter.DecimalPosition = value; }
        }

        public int NumberOfDigits
        {
            get { return _HMIDigitalPanelMeter.NumberOfDigits; }
            set { _HMIDigitalPanelMeter.NumberOfDigits = value; }
        }

        public Color BackColor
        {
            get { return _HMIDigitalPanelMeter.BackColor; }
            set { _HMIDigitalPanelMeter.BackColor = value; }
        }

        public Color ForeColor
        {
            get { return _HMIDigitalPanelMeter.ForeColor; }
            set { _HMIDigitalPanelMeter.ForeColor = value; }
        }

        public string PLCAddressValue
        {
            get { return _HMIDigitalPanelMeter.PLCAddressValue; }
            set { _HMIDigitalPanelMeter.PLCAddressValue = value; }
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();
            items.Add(new DesignerActionTextItem("HMI Professional Edition", "HMI Professional Edition"));
            items.Add(new DesignerActionMethodItem(this, "ShowTagDesignerForm", "Choote Tag"));
            items.Add(new DesignerActionPropertyItem("DecimalPosition", "DecimalPosition"));
            items.Add(new DesignerActionPropertyItem("NumberOfDigits", "NumberOfDigits"));
            items.Add(new DesignerActionPropertyItem("BackColor", "BackColor"));
            items.Add(new DesignerActionPropertyItem("ForeColor", "ForeColor"));

            return items;
        }

        public void ShowTagDesignerForm()
        {
            var frm = new MonitorForm(PLCAddressValue);
            frm.OnTagSelected_Clicked += tagName => { SetProperty(_HMIDigitalPanelMeter, "PLCAddressValue", tagName); };
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        public void SetProperty(Control control, string propertyName, object value)
        {
            var pd = TypeDescriptor.GetProperties(control)[propertyName];
            pd.SetValue(control, value);
        }
    }
}