
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
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvancedScada.Controls.LED
{
    public class HMISimpleLED : Control
    {


        private Timer BlinkTimer;

        private Color[] _brushONColor;

        private Color color1;

        private Color color2;

        private bool LED_ON;

        private bool _border;

        private Color _borderColor;

        private LED_Bri _LEDBrightness;

        private LED_Col _LEDColor;

        private bool m_Value;

        private bool _blink;

        private int _blinkInterval;

        private bool _interaction;



        [Browsable(false)]
        public BorderStyle BorderStyle { get; set; }

        [Browsable(true), DefaultValue(false), Description("Enable LED blink (also controlled by the mouse DoubleClick event when user interaction is enabled)."), RefreshProperties(RefreshProperties.All)]
        public bool LED_Blink
        {
            get
            {
                return this._blink;
            }
            set
            {
                if (this._blink != value)
                {
                    this._blink = value;
                    if (!this._blink)
                    {
                        this.BlinkTimer.Enabled = false;
                    }
                    else
                    {
                        this.BlinkTimer.Enabled = true;
                    }
                    this.Invalidate();
                }
            }
        }

        [Browsable(true), DefaultValue(500), Description("LED blinking interval in milliseconds."), RefreshProperties(RefreshProperties.All)]
        public int LED_BlinkInterval
        {
            get
            {
                return this._blinkInterval;
            }
            set
            {
                if (!Versioned.IsNumeric(value))
                {
                    value = 500;
                }
                if (value < 0)
                {
                    value = 500;
                }
                if (this._blinkInterval != value)
                {
                    this._blinkInterval = value;
                    this.BlinkTimer.Interval = this._blinkInterval;
                    this.Invalidate();
                }
            }
        }

        [Browsable(true), DefaultValue(false), Description("Enable LED border."), RefreshProperties(RefreshProperties.All)]
        public bool LED_Border
        {
            get
            {
                return this._border;
            }
            set
            {
                if (this._border != value)
                {
                    this._border = value;
                    this.Invalidate();
                }
            }
        }

        [Browsable(true), DefaultValue(typeof(Color), "MediumSeaGreen"), Description("LED border color."), RefreshProperties(RefreshProperties.All)]
        public Color LED_BorderColor
        {
            get
            {
                return this._borderColor;
            }
            set
            {
                if (this._borderColor != value)
                {
                    this._borderColor = value;
                    this.Invalidate();
                }
            }
        }

        [Browsable(true), DefaultValue(0), Description("LED brightness."), RefreshProperties(RefreshProperties.All)]
        public LED_Bri LED_Brightness
        {
            get
            {
                return this._LEDBrightness;
            }
            set
            {
                if (this._LEDBrightness != value)
                {
                    this._LEDBrightness = value;
                    this.Invalidate();
                }
            }
        }

        [Browsable(true), DefaultValue(0), Description("LED color."), RefreshProperties(RefreshProperties.All)]
        public LED_Col LED_Color
        {
            get
            {
                return this._LEDColor;
            }
            set
            {
                if (this._LEDColor != value)
                {
                    this._LEDColor = value;
                    this.Invalidate();
                }
            }
        }

        [Browsable(true), DefaultValue(false), Description("Enable user interaction at Runtime (events: Click for ON/OFF, DoubleClick for blink)."), RefreshProperties(RefreshProperties.All)]
        public bool LED_UserInteraction
        {
            get
            {
                return this._interaction;
            }
            set
            {
                if (this._interaction != value)
                {
                    this._interaction = value;
                    this.Invalidate();
                }
            }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (string.Compare(base.Text, value) != 0)
                {
                    base.Text = value;
                    this.Invalidate();
                }
            }
        }

        [Browsable(true), DefaultValue(false), Description("Turn LED ON (also controlled by the mouse Click event when user interaction is enabled)."), RefreshProperties(RefreshProperties.All)]
        public bool Value
        {
            get
            {
                return this.m_Value;
            }
            set
            {
                if (this.m_Value != value)
                {
                    this.m_Value = value;
                }
                this.Invalidate();
            }
        }



        public HMISimpleLED()
        {
            HMISimpleLED simpleLED = this;
            base.Click += simpleLED.LED_Click;
            HMISimpleLED simpleLED1 = this;
            base.DoubleClick += simpleLED1.LED_DoubleClick;
            HMISimpleLED simpleLED2 = this;
            base.Resize += simpleLED2.LED_Resize;

            Color[] red = { Color.Red, Color.Green, Color.Lime, Color.Blue, Color.Cyan, Color.Orange, Color.Yellow, Color.Violet, Color.White };
            this._brushONColor = red;
            this.LED_ON = false;
            this.BorderStyle = BorderStyle.None;
            this._borderColor = Color.MediumSeaGreen;
            this._LEDBrightness = LED_Bri.Normal;
            this._LEDColor = LED_Col.Red;
            this._blinkInterval = 500;
            this.SetStyle(ControlStyles.ContainerControl | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            base.DoubleBuffered = true;
            this.DoubleBuffered = true;
            this.BackColor = Color.Transparent;
            //INSTANT VB NOTE: The variable size was renamed since Visual Basic does not handle local variables named the same as class members well:
            Size size_Renamed = new Size(30, 30);
            this.MinimumSize = size_Renamed;
            size_Renamed = new Size(360, 360);
            this.MaximumSize = size_Renamed;
            this.Width = this.Height;
            this.BlinkTimer = new Timer()
            {
                Interval = this._blinkInterval,
                Enabled = false
            };
        }


        private void LED_Click(object sender, EventArgs e)
        {
            this.Focus();
            if (!this._blink)
            {
                if (this._interaction)
                {
                    this.m_Value = !this.m_Value;
                    this.Invalidate();
                }
            }
        }

        private void LED_DoubleClick(object sender, EventArgs e)
        {
            if (!this._blink)
            {
                if (this._interaction)
                {
                    this.BlinkTimer.Enabled = !this.BlinkTimer.Enabled;
                    this.Invalidate();
                }
            }
        }

        private void LED_Resize(object sender, EventArgs e)
        {
            this.Width = this.Height;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Color[] colorArray = null;
            bool flag = false;
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            //ORIGINAL LINE: Rectangle rectangle = new Rectangle(0, 0, checked((int)Math.Round((double)((float)((float)this.Width - 1f)))), checked((int)Math.Round((double)((float)((float)this.Height - 1f)))));
            Rectangle rectangle = new Rectangle(0, 0, Convert.ToInt32(Math.Truncate(Math.Round((double)((float)this.Width - 1.0F)))), Convert.ToInt32(Math.Truncate(Math.Round((double)((float)this.Height - 1.0F)))));
            //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            //ORIGINAL LINE: Rectangle rectangle1 = new Rectangle(2, 2, checked((int)Math.Round((double)((float)((float)this.Width - 5f)))), checked((int)Math.Round((double)((float)((float)this.Height - 5f)))));
            Rectangle rectangle1 = new Rectangle(2, 2, Convert.ToInt32(Math.Truncate(Math.Round((double)((float)this.Width - 5.0F)))), Convert.ToInt32(Math.Truncate(Math.Round((double)((float)this.Height - 5.0F)))));
            //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            //ORIGINAL LINE: Rectangle rectangle2 = new Rectangle(3, 3, checked((int)Math.Round((double)((float)((float)this.Width - 7f)))), checked((int)Math.Round((double)((float)((float)this.Height - 7f)))));
            Rectangle rectangle2 = new Rectangle(3, 3, Convert.ToInt32(Math.Truncate(Math.Round((double)((float)this.Width - 7.0F)))), Convert.ToInt32(Math.Truncate(Math.Round((double)((float)this.Height - 7.0F)))));
            //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            //ORIGINAL LINE: Rectangle rectangle3 = new Rectangle(5, 5, checked((int)Math.Round((double)((float)((float)this.Width - 11f)))), checked((int)Math.Round((double)((float)((float)this.Height - 11f)))));
            Rectangle rectangle3 = new Rectangle(5, 5, Convert.ToInt32(Math.Truncate(Math.Round((double)((float)this.Width - 11.0F)))), Convert.ToInt32(Math.Truncate(Math.Round((double)((float)this.Height - 11.0F)))));
            if (this._border)
            {
                e.Graphics.DrawEllipse(new Pen(this._borderColor, 1.5F), rectangle);
            }
            if (!this.BlinkTimer.Enabled)
            {
                if (!this.m_Value)
                {
                    this.LED_ON = false;
                }
                else
                {
                    this.LED_ON = true;
                }
            }
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddEllipse(rectangle3);
            PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
            if (!this.LED_ON)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Black), rectangle1);
                this.color1 = Color.FromArgb(255, ControlPaint.Dark(this._brushONColor[Convert.ToInt32(this._LEDColor)]));
                this.color2 = Color.FromArgb(100, this.color1);
                e.Graphics.DrawEllipse(new Pen(Color.FromArgb(45, this._brushONColor[Convert.ToInt32(this._LEDColor)]), 2.5F), rectangle2);
            }
            else
            {
                if (this._LEDColor != LED_Col.Green && this._LEDColor != LED_Col.Orange)
                {
                    if (this._LEDColor == LED_Col.Violet)
                    {
                        goto Label1;
                    }
                    flag = false;
                    goto Label0;
                }
            Label1:
                flag = true;
            Label0:
                if (!flag)
                {
                    e.Graphics.FillEllipse(new SolidBrush(ControlPaint.Dark(this._brushONColor[Convert.ToInt32(this._LEDColor)], 20.0F)), rectangle1);
                }
                else
                {
                    e.Graphics.FillEllipse(new SolidBrush(ControlPaint.Dark(this._brushONColor[Convert.ToInt32(this._LEDColor)])), rectangle1);
                }
                this.color1 = Color.FromArgb(255, this._brushONColor[Convert.ToInt32(this._LEDColor)]);
                this.color2 = Color.FromArgb(0, this.color1);
                e.Graphics.DrawEllipse(new Pen(Color.FromArgb(125, this._brushONColor[Convert.ToInt32(this._LEDColor)]), 2.5F), rectangle2);
                if (this._LEDBrightness == LED_Bri.Brighter)
                {
                    pathGradientBrush.CenterColor = ControlPaint.Light(this._brushONColor[Convert.ToInt32(this._LEDColor)]);
                    colorArray = new Color[] { Color.FromArgb(25, ControlPaint.Light(this._brushONColor[Convert.ToInt32(this._LEDColor)])) };
                    pathGradientBrush.SurroundColors = colorArray;
                    e.Graphics.FillEllipse(pathGradientBrush, rectangle3);
                }
            }
            pathGradientBrush.CenterColor = this.color1;
            colorArray = new Color[] { this.color2 };
            pathGradientBrush.SurroundColors = colorArray;
            e.Graphics.FillEllipse(pathGradientBrush, rectangle3);
            if (!string.IsNullOrEmpty(this.Text))
            {
                StringFormat stringFormat = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                Graphics graphics = e.Graphics;
                //INSTANT VB NOTE: The variable text was renamed since Visual Basic does not handle local variables named the same as class members well:
                string text_Renamed = this.Text;
                //INSTANT VB NOTE: The variable font was renamed since Visual Basic does not handle local variables named the same as class members well:
                Font font_Renamed = this.Font;
                SolidBrush solidBrush = new SolidBrush(this.ForeColor);
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: Point point = new Point(checked((int)Math.Round((double)this.Width / 2)), checked((int)Math.Round((double)this.Height / 2)));
                Point point = new Point(Convert.ToInt32(Math.Round((double)this.Width / 2)), Convert.ToInt32(Math.Round((double)this.Height / 2)));
                graphics.DrawString(text_Renamed, font_Renamed, solidBrush, point, stringFormat);
            }
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            this.LED_ON = !this.LED_ON;
            this.Invalidate();
        }

        public enum LED_Bri
        {
            Normal,
            Brighter
        }

        public enum LED_Col
        {
            Red,
            Green,
            Lime,
            Blue,
            Cyan,
            Orange,
            Yellow,
            Violet,
            White
        }
        public bool HoldTimeMet;
        private int m_MaximumHoldTime = 3000;
        private int m_MinimumHoldTime = 500;

        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string m_PLCAddressClick = string.Empty;

        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string m_PLCAddressText = string.Empty;

        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string m_PLCAddressValue = string.Empty;

        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string m_PLCAddressVisible = string.Empty;

        //**********************************************************************
        //* If output type is set to write value, then write this value to PLC
        //**********************************************************************

        //*****************************************
        //* Property - Hold time before bit reset
        //*****************************************
        private readonly Timer MaxHoldTimer = new Timer();

        //*****************************************
        //* Property - Hold time before bit reset
        //*****************************************
        private readonly Timer MinHoldTimer = new Timer();
        private readonly bool MouseIsDown = false;

        //***************************************
        //* Call backs for returned data
        //***************************************
        private string OriginalText;


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

        [Category("PLC Properties")]
        [Editor(typeof(TestDialogEditor), typeof(UITypeEditor))]
        public string PLCAddressClick
        {
            get { return m_PLCAddressClick; }
            set
            {
                if (m_PLCAddressClick != value) m_PLCAddressClick = value;
            }
        }

        [DefaultValue(false)]
        public bool SuppressErrorDisplay { get; set; }

        [Category("PLC Properties")]
        public int MinimumHoldTime
        {
            get { return m_MinimumHoldTime; }
            set
            {
                m_MinimumHoldTime = value;
                if (value > 0) MinHoldTimer.Interval = value;
            }
        }

        [Category("PLC Properties")]
        public int MaximumHoldTime
        {
            get { return m_MaximumHoldTime; }
            set
            {
                m_MaximumHoldTime = value;
                if (value > 0) MaxHoldTimer.Interval = value;
            }
        }

        [Category("PLC Properties")]
        public int ValueToWrite { get; set; }

        public event EventHandler ValueChanged;


        private void ReleaseValue()
        {
            try
            {
                switch (OutputType)
                {
                    case OutputType.MomentarySet:
                        WCFChannelFactory.Write(PLCAddressClick, Convert.ToString(false));
                        break;
                    case OutputType.MomentaryReset:
                        WCFChannelFactory.Write(PLCAddressClick, Convert.ToString(true));
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HoldTimer_Tick(object sender, EventArgs e)
        {
            MinHoldTimer.Enabled = false;
            HoldTimeMet = true;
            if (!MouseIsDown) ReleaseValue();
        }

        private void MaxHoldTimer_Tick(object sender, EventArgs e)
        {
            MaxHoldTimer.Enabled = false;
            ReleaseValue();
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);


            if (!string.IsNullOrWhiteSpace(m_PLCAddressClick) & Enabled && PLCAddressClick != null)
            {
                try
                {
                    switch (OutputType)
                    {
                        case OutputType.MomentarySet:
                            WCFChannelFactory.Write(m_PLCAddressClick, "1");
                            break;
                        case OutputType.MomentaryReset:
                            WCFChannelFactory.Write(m_PLCAddressClick, "0");
                            break;
                        case OutputType.SetTrue:
                            WCFChannelFactory.Write(m_PLCAddressClick, "1");
                            break;
                        case OutputType.SetFalse:
                            WCFChannelFactory.Write(m_PLCAddressClick, "0");
                            break;
                        case OutputType.Toggle:

                            var CurrentValue = Value;
                            if (CurrentValue)
                                WCFChannelFactory.Write(m_PLCAddressClick, "0");
                            else
                                WCFChannelFactory.Write(m_PLCAddressClick, "1");
                            break;
                        default:

                            break;
                    }
                }
                catch (Exception ex)
                {
                    DisplayError("WRITE FAILED!" + ex.Message);
                }

                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (!string.IsNullOrWhiteSpace(m_PLCAddressClick) & Enabled)
            {
                try
                {
                    switch (OutputType)
                    {
                        case OutputType.MomentarySet:
                            WCFChannelFactory.Write(m_PLCAddressClick, "0");
                            break;
                        case OutputType.MomentaryReset:
                            WCFChannelFactory.Write(m_PLCAddressClick, "1");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    DisplayError("WRITE FAILED!" + ex.Message);
                }

                Invalidate();
            }
        }

        protected virtual void OnValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null) ValueChanged(this, e);
        }

        #region "Basic Properties"

        //private bool m_Value;

        //public new bool Value
        //{
        //    get { return m_Value; }
        //    set
        //    {
        //        if (m_Value != value)
        //        {
        //            m_Value = value;
        //            base.Value = m_Value;
        //            OnValueChanged(this, EventArgs.Empty);
        //            Invalidate();
        //        }
        //    }
        //}

        private OutputType m_OutputType = OutputType.MomentarySet;

        public OutputType OutputType
        {
            get { return m_OutputType; }
            set { m_OutputType = value; }
        }

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
    }




}