using AdvancedScada;
using AdvancedScada.Controls;
using AdvancedScada.Controls.DialogEditor;
using AdvancedScada.Controls.Keyboard;
using AdvancedScada.Controls.Licenses;
using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Client;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AdvancedScada.Controls.Thermometer
{
    public class HMIThermometer : System.Windows.Forms.Control
    {


        private Bitmap StaticImage;

        private Bitmap BackBuffer;

        private Rectangle ValueRectangle;

        private Rectangle BulbCircle;

        private PathGradientBrush BulbBrush;

        private LinearGradientBrush FillBrush;

        private double m_Minimum;

        private double m_Maximum;

        private double m_Value;

        private Color m_FillColor;

        public Color FillColor
        {
            get
            {
                return this.m_FillColor;
            }
            set
            {
                if (this.m_FillColor != value)
                {
                    this.m_FillColor = value;
                    this.RefreshImage();
                }
            }
        }

        public double Maximum
        {
            get
            {
                return this.m_Maximum;
            }
            set
            {
                if (this.m_Maximum != value)
                {
                    this.m_Maximum = value;
                    this.RefreshImage();
                }
            }
        }

        public double Minimum
        {
            get
            {
                return this.m_Minimum;
            }
            set
            {
                if (this.m_Minimum != value)
                {
                    this.m_Minimum = value;
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
                this.RefreshImage();
            }
        }

        public double Value
        {
            get
            {
                return this.m_Value;
            }
            set
            {
                if (value != this.m_Value)
                {
                    this.m_Value = value;
                    this.UpdateValueRectangle();
                }
            }
        }


        public HMIThermometer()
        {

            this.m_Minimum = 0;
            this.m_Maximum = 100;
            this.m_FillColor = Color.Red;
            this.ValueRectangle = new Rectangle(0, 0, 10, 10);
        }



        protected override void Dispose(bool disposing)
        {
            try
            {
                if (this.StaticImage != null)
                {
                    this.StaticImage.Dispose();
                }
                if (this.BackBuffer != null)
                {
                    this.BackBuffer.Dispose();
                }
                if (this.FillBrush != null)
                {
                    this.FillBrush.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        public static Color GetRelativeColor(Color color, double intensity)
        {
            intensity = Math.Max(intensity, 0);
            //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            //ORIGINAL LINE: Color color1 = Color.FromArgb(checked((int)Math.Round(Math.Min((double)(checked(color.R + 1)) * intensity, 255))), checked((int)Math.Round(Math.Min((double)(checked(color.G + 1)) * intensity, 255))), checked((int)Math.Round(Math.Min((double)(checked(color.B + 1)) * intensity, 255))));
            Color color1 = System.Drawing.Color.FromArgb(Convert.ToInt32(Math.Truncate(Math.Round(Math.Min((double)(color.R + 1) * intensity, 255)))), Convert.ToInt32(Math.Truncate(Math.Round(Math.Min((double)(color.G + 1) * intensity, 255)))), Convert.ToInt32(Math.Truncate(Math.Round(Math.Min((double)(color.B + 1) * intensity, 255)))));
            return color1;
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            this.RefreshImage();
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            this.RefreshImage();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this.BackBuffer != null || this.StaticImage != null || this.FillBrush != null)
            {
                using (Graphics graphic = Graphics.FromImage(this.BackBuffer))
                {
                    graphic.SmoothingMode = SmoothingMode.AntiAlias;
                    graphic.DrawImage(this.StaticImage, 0, 0);
                    graphic.FillRectangle(this.FillBrush, this.ValueRectangle);
                    graphic.FillEllipse(this.BulbBrush, this.BulbCircle);
                }
                e.Graphics.DrawImageUnscaled(this.BackBuffer, 0, 0);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.RefreshImage();
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            EventHandler eventHandler = this.ValueChanged;
            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }

        private void RefreshImage()
        {
            if (this.Width > 0 && this.Height > 0)
            {
                this.BackBuffer = new Bitmap(this.Width, this.Height);
                this.StaticImage = new Bitmap(this.Width, this.Height);
                using (Graphics graphic = Graphics.FromImage(this.StaticImage))
                {
                    graphic.DrawImage(Properties.Resources.ThermometerStatic, 0, 0, this.StaticImage.Width, this.StaticImage.Height);
                    StringFormat stringFormat = new StringFormat()
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Far
                    };
                    double mMaximum = (this.m_Maximum - this.m_Minimum) / 10;
                    Rectangle[] rectangle = new Rectangle[11];
                    int num = 0;
                    do
                    {
                        //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        //ORIGINAL LINE: rectangle[num] = new Rectangle(0, checked((int)Math.Round((double)this.StaticImage.Height * (0.75 - (double)num * 0.065))), checked((int)Math.Round((double)this.StaticImage.Width * 0.48)), checked((int)Math.Round((double)this.StaticImage.Height * 0.05)));
                        rectangle[num] = new Rectangle(0, Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Height * (0.75 - (double)num * 0.065)))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Width * 0.48))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Height * 0.05))));
                        graphic.DrawString(Convert.ToString(this.m_Minimum + mMaximum * (double)num), new Font(this.Font.FontFamily, (float)((double)this.Height * 0.025), FontStyle.Regular, GraphicsUnit.Point), new SolidBrush(this.ForeColor), rectangle[num], stringFormat);
                        num += 1;
                    } while (num <= 10);
                    stringFormat.LineAlignment = StringAlignment.Near;
                    stringFormat.Alignment = StringAlignment.Center;
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: Rectangle rectangle1 = new Rectangle(0, checked((int)Math.Round((double)this.StaticImage.Height * 0.01)), this.StaticImage.Width, this.StaticImage.Height);
                    Rectangle rectangle1 = new Rectangle(0, Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Height * 0.01))), this.StaticImage.Width, this.StaticImage.Height);
                    graphic.DrawString(base.Text, this.Font, new SolidBrush(this.ForeColor), rectangle1, stringFormat);
                }
                this.UpdateValueRectangle();
                this.FillBrush = new LinearGradientBrush(this.ValueRectangle, Color.FromArgb(0, 0, 180), Color.FromArgb(0, 0, 180), 0.0F);
                ColorBlend colorBlend = new ColorBlend();
                Color[] relativeColor = { HMIThermometer.GetRelativeColor(this.m_FillColor, 0.5), this.m_FillColor, HMIThermometer.GetRelativeColor(this.m_FillColor, 0.5) };
                colorBlend.Colors = relativeColor;
                colorBlend.Positions = new float[] { 0.0F, 0.5F, 1.0F };
                this.FillBrush.InterpolationColors = colorBlend;
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.BulbCircle = new Rectangle(checked((int)Math.Round((double)this.Width * 0.63)), checked((int)Math.Round((double)this.Height * 0.865)), checked((int)Math.Round((double)this.Width * 0.2)), checked((int)Math.Round((double)this.Height * 0.05)));
                this.BulbCircle = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)this.Width * 0.63))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height * 0.865))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.Width * 0.2))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height * 0.05))));
                GraphicsPath graphicsPath = new GraphicsPath();
                graphicsPath.AddEllipse(this.BulbCircle);
                this.BulbBrush = new PathGradientBrush(graphicsPath);
                //INSTANT VB NOTE: The variable bulbBrush was renamed since Visual Basic does not handle local variables named the same as class members well:
                PathGradientBrush bulbBrush_Renamed = this.BulbBrush;
                Color[] colorArray = { HMIThermometer.GetRelativeColor(this.m_FillColor, 0.5) };
                bulbBrush_Renamed.SurroundColors = colorArray;
                this.BulbBrush.CenterColor = this.m_FillColor;
                this.Invalidate();
            }
        }

        private void UpdateValueRectangle()
        {
            double num = Math.Min(this.m_Value, this.m_Maximum);
            double mMinimum = (num - this.m_Minimum) / (this.m_Maximum - this.m_Minimum);
            //INSTANT VB NOTE: The variable height was renamed since Visual Basic does not handle local variables named the same as class members well:
            double height_Renamed = (double)this.Height * 0.88;
            double height1 = (double)this.Height * 0.65 * mMinimum + (double)this.Height * 0.105;
            if (height1 < 1)
            {
                height1 = 1;
            }
            //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            //ORIGINAL LINE: this.ValueRectangle.Height = checked((int)Math.Round(height1));
            this.ValueRectangle.Height = Convert.ToInt32(Math.Truncate(Math.Round(height1)));
            //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            //ORIGINAL LINE: this.ValueRectangle.Width = checked((int)Math.Round((double)this.Width * 0.125));
            this.ValueRectangle.Width = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Width * 0.125)));
            //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            //ORIGINAL LINE: this.ValueRectangle.X = checked((int)Math.Round((double)this.Width * 0.67));
            this.ValueRectangle.X = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Width * 0.67)));
            //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            //ORIGINAL LINE: this.ValueRectangle.Y = checked((int)Math.Round(height - height1));
            this.ValueRectangle.Y = Convert.ToInt32(Math.Truncate(Math.Round(height_Renamed - height1)));
            this.Invalidate();
        }

        public event EventHandler ValueChanged;
        private string OriginalText;

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
                    ErrorDisplayTime.Interval = 5000;
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
        [Editor(typeof(TestDialogEditor), typeof(UITypeEditor))]
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
                            WCFChannelFactory.Write(m_PLCAddressKeypad, KeypadPopUp.Value);
                        else
                            WCFChannelFactory.Write(m_PLCAddressKeypad,
                                (Convert.ToDouble(KeypadPopUp.Value) / m_KeypadScaleFactor).ToString());
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


}