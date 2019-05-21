
using AdvancedScada;
using AdvancedScada;
using AdvancedScada.Controls;
using AdvancedScada.Controls;
using AdvancedScada.Controls.DialogEditor;
using AdvancedScada.Controls.Licenses;
using AdvancedScada.Controls.Motor;
using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Client;
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

namespace AdvancedScada.Controls.ButtonAll
{
    public class HMIAnnunciator : System.Windows.Forms.Control
    {
        #region الاحداث
        public event EventHandler ValueChanged;
        #endregion
        #region متغيرات

        private Bitmap LightImage;

        private Bitmap OffImage;

        private Bitmap OnImage;

        private Rectangle TextRectangle;

        private SolidBrush TextBrush;

        private StringFormat sf;

        private bool m_Value;

        private OutputType m_OutputType;

        private Bitmap _backBuffer;
        #endregion
        #region خصائص
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
                    if (!value)
                    {
                        this.LightImage = this.OffImage;
                    }
                    else
                    {
                        this.LightImage = this.OnImage;
                    }
                    this.m_Value = value;
                    this.Invalidate();
                    this.OnValueChanged(EventArgs.Empty);
                }
            }
        }
        #endregion
        #region مشيدات
        public HMIAnnunciator()
        {
            MaxHoldTimer.Tick += MaxHoldTimer_Tick;
            MinHoldTimer.Tick += HoldTimer_Tick;
            this.m_OutputType = OutputType.MomentarySet;
            this.sf = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            this.TextRectangle = new Rectangle();
            this.TextBrush = new SolidBrush(Color.Black);
        }
        #endregion
        #region اعادة تعريف الاحداث


        protected override void OnPaint(PaintEventArgs e)
        {
            if (!(this._backBuffer == null || this.LightImage == null))
            {
                Graphics g = Graphics.FromImage(this._backBuffer);
                g.DrawImage(this.LightImage, 0, 0);
                if ((base.Text == null || string.Compare(base.Text, string.Empty) == 0) ? false : true)
                {
                    if (this.TextBrush.Color != base.ForeColor)
                    {
                        this.TextBrush.Color = base.ForeColor;
                    }
                    g.DrawString(base.Text, base.Font, this.TextBrush, this.TextRectangle, this.sf);
                }
                e.Graphics.DrawImage(this._backBuffer, 0, 0);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.RefreshImage();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Invalidate();
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, e);
        }
        #endregion
        #region طرق
        private void RefreshImage()
        {
            if (!(this.Width <= 0 || this.Height <= 0))
            {
                this.OffImage = new Bitmap(this.Width, this.Height);
                this.OnImage = new Bitmap(this.Width, this.Height);
                Graphics graphic = Graphics.FromImage(this.OffImage);
                Graphics graphic1 = Graphics.FromImage(this.OnImage);
                graphic.DrawImage(Properties.Resources.AnnunciatorOff, 0, 0, this.OffImage.Width, this.OffImage.Height);
                graphic1.DrawImage(Properties.Resources.AnnunciatorOn, 0, 0, this.OnImage.Width, this.OnImage.Height);
                if (!this.m_Value)
                {
                    this.LightImage = this.OffImage;
                }
                else
                {
                    this.LightImage = this.OnImage;
                }
                graphic.Dispose();
                graphic1.Dispose();
                this.TextRectangle.X = 0;
                this.TextRectangle.Width = this.Width;
                this.TextRectangle.Y = 0;
                this.TextRectangle.Height = this.Height;
                this._backBuffer = new Bitmap(this.Width, this.Height);
                this.Invalidate();
            }
        }
        #endregion


        private string OriginalText;


        #region PLC Related Properties

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

        //********************************************
        //* Property - Address in PLC for click event
        //********************************************
        private string m_PLCAddressClick = string.Empty;

        [Category("PLC Properties")]
        [Editor(typeof(TestDialogEditor), typeof(UITypeEditor))]
        public string PLCAddressClick
        {
            get { return m_PLCAddressClick; }
            set { m_PLCAddressClick = value; }
        }

        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string _PLCAddressHighlight = string.Empty;

        [Category("PLC Properties")]
        [Editor(typeof(TestDialogEditor), typeof(UITypeEditor))]
        public string PLCAddressHighlightX
        {
            get { return _PLCAddressHighlight; }
            set
            {
                if (_PLCAddressHighlight != value) _PLCAddressHighlight = value;
            }
        }

        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string m_PLCAddressText = string.Empty;

        [DefaultValue("")]
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

                    //* When address is changed, re-subscribe to new address
                    try
                    {
                        if (string.IsNullOrEmpty(m_PLCAddressText) || string.IsNullOrWhiteSpace(m_PLCAddressText) ||
                            Licenses.LicenseManager.IsInDesignMode) return;
                        var bd = new Binding("Text", TagCollectionClient.Tags[m_PLCAddressText], "Value", true);
                        DataBindings.Add(bd);
                    }
                    catch (Exception e1)
                    {
                        Console.WriteLine(e1.Message);
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

                    //* When address is changed, re-subscribe to new address

                    if (string.IsNullOrEmpty(m_PLCAddressVisible) || string.IsNullOrWhiteSpace(m_PLCAddressVisible) ||
                        Licenses.LicenseManager.IsInDesignMode) return;
                    var bd = new Binding("Visible", TagCollectionClient.Tags[m_PLCAddressVisible], "Visible", true);
                    DataBindings.Add(bd);
                }
            }
        }


        private string m_PLCAddressEnabled = string.Empty;

        [Category("PLC Properties")]
        [Editor(typeof(TestDialogEditor), typeof(UITypeEditor))]
        public string PLCAddressEnabled
        {
            get { return m_PLCAddressEnabled; }
            set
            {
                if (m_PLCAddressEnabled != value)
                {
                    m_PLCAddressEnabled = value;

                    //* When address is changed, re-subscribe to new address
                    if (string.IsNullOrEmpty(m_PLCAddressEnabled) || string.IsNullOrWhiteSpace(m_PLCAddressEnabled) ||
                        Licenses.LicenseManager.IsInDesignMode) return;
                    var bd = new Binding("Enabled", TagCollectionClient.Tags[m_PLCAddressEnabled], "Enabled", true);
                    DataBindings.Add(bd);
                }
            }
        }

        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string m_PLCAddressSelectTextAlternate = string.Empty;

        [Category("PLC Properties")]
        [Editor(typeof(TestDialogEditor), typeof(UITypeEditor))]
        public string PLCAddressSelectTextAlternate
        {
            get { return m_PLCAddressSelectTextAlternate; }
            set
            {
                if (m_PLCAddressSelectTextAlternate != value) m_PLCAddressSelectTextAlternate = value;
            }
        }

        [DefaultValue("0")]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }


        //******************************************************************************************
        //* Use the base control's text property and make it visible as a property on the designer
        //******************************************************************************************


        private void ReleaseValue()
        {
            try
            {
                if (OutputType == OutputType.MomentarySet)
                    WCFChannelFactory.Write(PLCAddressClick, "0");
                else if (OutputType == OutputType.MomentaryReset) WCFChannelFactory.Write(PLCAddressClick, "1");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool MouseIsDown;

        private bool HoldTimeMet;

        //*****************************************
        //* Property - Hold time before bit reset
        //*****************************************
        private readonly Timer MinHoldTimer = new Timer();
        private int m_MinimumHoldTime = 500;

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

        //*****************************************
        //* Property - Hold time before bit reset
        //*****************************************
        private readonly Timer MaxHoldTimer = new Timer();
        private int m_MaximumHoldTime = 3000;

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

        //**********************************************************************
        //* If output type is set to write value, then write this value to PLC
        //**********************************************************************

        [Category("PLC Properties")]
        public int ValueToWrite { get; set; }

        #endregion

        #region Event

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

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            MouseIsDown = false;
            if (this.Enabled)
            {
                this.Invalidate();
            }
            if (PLCAddressClick != null && string.Compare(PLCAddressClick, string.Empty) != 0)
                if (HoldTimeMet || m_MinimumHoldTime <= 0)
                {
                    MaxHoldTimer.Enabled = false;
                    ReleaseValue();
                }
        }


        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            if (this.Enabled)
            {
                this.LightImage = this.OnImage;
                if (this.m_OutputType == OutputType.Toggle)
                {
                    this.Value = !this.Value;
                }
                this.Invalidate();
            }
            if (PLCAddressClick != null && string.Compare(PLCAddressClick, string.Empty) != 0 && Enabled &&
                PLCAddressClick != null)
                try
                {
                    if (OutputType == OutputType.MomentarySet)
                    {
                        WCFChannelFactory.Write(PLCAddressClick, "1");
                        if (m_MinimumHoldTime > 0) MinHoldTimer.Enabled = true;
                        if (m_MaximumHoldTime > 0) MaxHoldTimer.Enabled = true;
                    }
                    else if (OutputType == OutputType.MomentaryReset)
                    {
                        WCFChannelFactory.Write(PLCAddressClick, "0");
                        if (m_MinimumHoldTime > 0) MinHoldTimer.Enabled = true;
                        if (m_MaximumHoldTime > 0) MaxHoldTimer.Enabled = true;
                    }

                    else if (OutputType == OutputType.SetTrue)
                    {
                        WCFChannelFactory.Write(PLCAddressClick, "1");
                    }

                    else if (OutputType == OutputType.SetFalse)
                    {
                        WCFChannelFactory.Write(PLCAddressClick, "0");
                    }

                    else if (OutputType == OutputType.Toggle)
                    {
                        var CurrentValue = Convert.ToBoolean(Value);
                        if (CurrentValue)
                            WCFChannelFactory.Write(PLCAddressClick, "0");
                        else
                            WCFChannelFactory.Write(PLCAddressClick, "1");
                    }
                }
                catch (Exception)
                {
                }

            //this.Invalidate();
        }

        #endregion

        #region "Error Display"

        //********************************************************
        //* Show an error via the text property for a short time

        //********************************************************

        [DefaultValue(false)]
        public bool SuppressErrorDisplay { get; set; }

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