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
using System.Windows.Forms;

namespace AdvancedScada.Controls.Thermometer
{
    public class HMIThermometer2 : System.Windows.Forms.Control
    {


        private Bitmap StaticImage;

        private Bitmap BackBuffer;

        private Bitmap BulbImage;

        private Rectangle ValueRectangle;

        private Rectangle BulbCircle;

        private double m_Minimum;

        private double m_Value;

        private UnitsSelect m_ValueUnits;

        private Color m_FillColor;

        private ColumnColors m_ColumnColor;

        public ColumnColors ColumnColor
        {
            get
            {
                return this.m_ColumnColor;
            }
            set
            {
                if (this.m_ColumnColor != value)
                {
                    this.m_ColumnColor = value;
                    this.RefreshImage();
                }
            }
        }

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

        public UnitsSelect ValueUnits
        {
            get
            {
                return this.m_ValueUnits;
            }
            set
            {
                if (this.m_ValueUnits != value)
                {
                    this.m_ValueUnits = value;
                    this.UpdateValueRectangle();
                }
            }
        }


        public HMIThermometer2()
        {

            this.m_Minimum = -40;
            this.m_FillColor = Color.Red;
            this.m_ColumnColor = ColumnColors.Red;
            this.ValueRectangle = new Rectangle(0, 0, 10, 10);
            this.ForeColor = Color.Black;
            this.Height = 240;
            this.Width = 75;
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
                if (this.BulbImage != null)
                {
                    this.BulbImage.Dispose();
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
            if (this.BackBuffer != null || this.StaticImage != null || this.BulbImage != null)
            {
                using (Graphics graphic = Graphics.FromImage(this.BackBuffer))
                {
                    graphic.DrawImage(this.StaticImage, 0, 0);
                    switch (this.m_ColumnColor)
                    {
                        case ColumnColors.Red:
                            graphic.DrawImage(Properties.Resources.Thermometer2Column, this.ValueRectangle);
                            break;
                        case ColumnColors.Green:
                            graphic.DrawImage(Properties.Resources.Thermometer2ColumnGrn, this.ValueRectangle);
                            break;
                        case ColumnColors.Blue:
                            graphic.DrawImage(Properties.Resources.Thermometer2ColumnBlue, this.ValueRectangle);
                            break;
                    }
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: graphic.DrawImage(this.BulbImage, checked((int)Math.Round((double)this.Width * 0.335)), checked((int)Math.Round((double)this.Height * 0.822)));
                    graphic.DrawImage(this.BulbImage, Convert.ToInt32(Math.Truncate(Math.Round((double)this.Width * 0.335))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height * 0.822))));
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
                    graphic.DrawImage(Properties.Resources.Thermometer2Static, 0, 0, this.StaticImage.Width, this.StaticImage.Height);
                    StringFormat stringFormat = new StringFormat()
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Far
                    };
                    double num = 20;
                    Rectangle[] rectangle = new Rectangle[9];
                    int num1 = 0;
                    do
                    {
                        //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        //ORIGINAL LINE: rectangle[num1] = new Rectangle(0, checked((int)Math.Round((double)this.StaticImage.Height * (0.775 - (double)num1 * 0.08))), checked((int)Math.Round((double)this.StaticImage.Width * 0.24)), checked((int)Math.Round((double)this.StaticImage.Height * 0.05)));
                        rectangle[num1] = new Rectangle(0, Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Height * (0.775 - (double)num1 * 0.08)))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Width * 0.24))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Height * 0.05))));
                        graphic.DrawString(Convert.ToString(this.m_Minimum + num * (double)num1), new Font(this.Font.FontFamily, (float)((double)this.Height * 0.025), FontStyle.Regular, GraphicsUnit.Point), new SolidBrush(this.ForeColor), rectangle[num1], stringFormat);
                        num1 += 1;
                    } while (num1 <= 8);
                    num = 10;
                    stringFormat.Alignment = StringAlignment.Near;
                    double mMinimum = (this.m_Minimum - 32) * 5 / 9;
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: int num2 = checked((int)Math.Round((double)this.Width * 0.77));
                    int num2 = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Width * 0.77)));
                    int num3 = 0;
                    do
                    {
                        //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        //ORIGINAL LINE: rectangle[0] = new Rectangle(num2, checked((int)Math.Round((double)this.StaticImage.Height * (0.762 - (double)num3 * 0.071))), checked(this.Width - num2), checked((int)Math.Round((double)this.StaticImage.Height * 0.05)));
                        rectangle[0] = new Rectangle(num2, Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Height * (0.762 - (double)num3 * 0.071)))), this.Width - num2, Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Height * 0.05))));
                        //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        //ORIGINAL LINE: graphic.DrawString(Convert.ToString(checked((int)Math.Round(mMinimum + num * (double)num3))), new Font(this.Font.FontFamily, (float)((double)this.Height * 0.025), FontStyle.Regular, GraphicsUnit.Point), new SolidBrush(this.ForeColor), rectangle[0], stringFormat);
                        graphic.DrawString(Convert.ToString(Convert.ToInt32(Math.Truncate(Math.Round(mMinimum + num * (double)num3)))), new Font(this.Font.FontFamily, (float)((double)this.Height * 0.025), FontStyle.Regular, GraphicsUnit.Point), new SolidBrush(this.ForeColor), rectangle[0], stringFormat);
                        num3 += 1;
                    } while (num3 <= 9);
                    stringFormat.LineAlignment = StringAlignment.Near;
                    stringFormat.Alignment = StringAlignment.Center;
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: Rectangle rectangle1 = new Rectangle(0, checked((int)Math.Round((double)this.StaticImage.Height * 0.01)), this.StaticImage.Width, this.StaticImage.Height);
                    Rectangle rectangle1 = new Rectangle(0, Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImage.Height * 0.01))), this.StaticImage.Width, this.StaticImage.Height);
                    graphic.DrawString(base.Text, this.Font, new SolidBrush(this.ForeColor), rectangle1, stringFormat);
                }
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.BulbImage = new Bitmap(checked((int)Math.Round((double)this.Width * 0.366)), checked((int)Math.Round((double)this.Height * 0.125)));
                this.BulbImage = new Bitmap(Convert.ToInt32(Math.Truncate(Math.Round((double)this.Width * 0.366))), Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height * 0.125))));
                using (Graphics graphic1 = Graphics.FromImage(this.BulbImage))
                {
                    switch (this.m_ColumnColor)
                    {
                        case ColumnColors.Red:
                            graphic1.DrawImage(Properties.Resources.Thermometer2Bulb, 0, 0, this.BulbImage.Width, this.BulbImage.Height);
                            break;
                        case ColumnColors.Green:
                            graphic1.DrawImage(Properties.Resources.Thermometer2BulbGrn, 0, 0, this.BulbImage.Width, this.BulbImage.Height);
                            break;
                        case ColumnColors.Blue:
                            graphic1.DrawImage(Properties.Resources.Thermometer2BulbBlue, 0, 0, this.BulbImage.Width, this.BulbImage.Height);
                            break;
                    }
                }
                this.UpdateValueRectangle();
                this.Invalidate();
            }
        }

        private void UpdateValueRectangle()
        {
            double mMinimum = 0;
            double num = Math.Max(this.m_Value, this.m_Minimum - 5);
            if (this.m_ValueUnits != UnitsSelect.F)
            {
                num = Math.Min(num, this.m_Minimum + 92);
                mMinimum = (num * 1.8 + 32 - this.m_Minimum) / 160;
            }
            else
            {
                num = Math.Min(num, this.m_Minimum + 165);
                mMinimum = (num - this.m_Minimum) / 160;
            }
            //INSTANT VB NOTE: The variable height was renamed since Visual Basic does not handle local variables named the same as class members well:
            double height_Renamed = (double)this.Height * 0.85;
            double height1 = (double)this.Height * 0.645 * mMinimum + (double)this.Height * 0.05;
            //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            //ORIGINAL LINE: this.ValueRectangle.Height = checked((int)Math.Round(height1));
            this.ValueRectangle.Height = Convert.ToInt32(Math.Truncate(Math.Round(height1)));
            //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            //ORIGINAL LINE: this.ValueRectangle.Width = checked((int)Math.Round((double)this.Width * 0.08));
            this.ValueRectangle.Width = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Width * 0.08)));
            //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            //ORIGINAL LINE: this.ValueRectangle.X = checked((int)Math.Round((double)this.Width * 0.47));
            this.ValueRectangle.X = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Width * 0.47)));
            //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            //ORIGINAL LINE: this.ValueRectangle.Y = checked((int)Math.Round(height - height1));
            this.ValueRectangle.Y = Convert.ToInt32(Math.Truncate(Math.Round(height_Renamed - height1)));
            this.Invalidate();
        }

        public event EventHandler ValueChanged;

        public enum ColumnColors
        {
            Red,
            Green,
            Blue
        }

        public enum UnitsSelect
        {
            F,
            C
        }
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