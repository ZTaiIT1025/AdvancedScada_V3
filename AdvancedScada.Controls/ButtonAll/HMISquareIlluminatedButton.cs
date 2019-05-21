
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
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvancedScada.Controls.ButtonAll
{
    public class HMISquareIlluminatedButton : System.Windows.Forms.Control
    {

        private Bitmap LightImage;

        private Bitmap OffImage;

        private Bitmap OnImage;

        private Bitmap ButtonDownImage;

        private Rectangle TextRectangle;

        private decimal ImageRatio;

        private bool MouseIsDown;

        private LightColors m_LightColor;

        private bool _Value;

        private OutputType m_OutputType;

        private StringFormat sf;

        private SolidBrush TextBrush;

        private Bitmap _backBuffer;


        private Timer tmrError;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams_Renamed = base.CreateParams;
                createParams_Renamed.ExStyle |= 32;
                return createParams_Renamed;
            }
        }

        public LightColors LightColor
        {
            get
            {
                return this.m_LightColor;
            }
            set
            {
                this.m_LightColor = value;
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






        public HMISquareIlluminatedButton()
        {

            this.m_LightColor = LightColors.Green;
            this.m_OutputType = OutputType.MomentarySet;
            this.sf = new StringFormat();
            this.tmrError = new Timer();
            this.sf.Alignment = StringAlignment.Center;
            this.sf.LineAlignment = StringAlignment.Center;
            this.TextBrush = new SolidBrush(Color.Black);
            this.TextRectangle = new Rectangle();
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
        protected override void OnPaint(PaintEventArgs e)
        {
            if (!(this._backBuffer == null || this.LightImage == null))
            {
                Graphics graphic = Graphics.FromImage(this._backBuffer);
                graphic.DrawImage(this.LightImage, 0, 0);
                if ((base.Text == null || string.Compare(base.Text, string.Empty) == 0) ? false : true)
                {
                    if (this.TextBrush.Color != base.ForeColor)
                    {
                        this.TextBrush.Color = base.ForeColor;
                    }
                    graphic.DrawString(base.Text, base.Font, this.TextBrush, this.TextRectangle, this.sf);
                }
                if (this.MouseIsDown)
                {
                    graphic.DrawImage(this.ButtonDownImage, 0, 0);
                }
                e.Graphics.DrawImage(this._backBuffer, 0, 0);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        private void RefreshImage()
        {
            if (!(this.Width <= 0 || this.Height <= 0))
            {
                this.OffImage = new Bitmap(this.Width, this.Height);
                this.OnImage = new Bitmap(this.Width, this.Height);
                Graphics graphic = Graphics.FromImage(this.OffImage);
                Graphics graphic1 = Graphics.FromImage(this.OnImage);
                switch (this.m_LightColor)
                {
                    case LightColors.Red:
                        graphic.DrawImage(Properties.Resources.SquareButtonRedOff, 0, 0, this.OffImage.Width, this.OffImage.Height);
                        graphic1.DrawImage(Properties.Resources.SquareButtonRedOn, 0, 0, this.OnImage.Width, this.OnImage.Height);
                        break;
                    case LightColors.Green:
                        graphic.DrawImage(Properties.Resources.SquareButtonGreenOff, 0, 0, this.OffImage.Width, this.OffImage.Height);
                        graphic1.DrawImage(Properties.Resources.SquareButtonGreenOn, 0, 0, this.OnImage.Width, this.OnImage.Height);
                        break;
                    case LightColors.Blue:
                        graphic.DrawImage(Properties.Resources.SquareButtonBlueOff, 0, 0, this.OffImage.Width, this.OffImage.Height);
                        graphic1.DrawImage(Properties.Resources.SquareButtonBlueOn, 0, 0, this.OnImage.Width, this.OnImage.Height);
                        break;
                }
                decimal num = new decimal((double)Properties.Resources.SquareButtonDown.Width / (double)Properties.Resources.SquareButtonBlueOff.Width);
                decimal num1 = new decimal((double)Properties.Resources.SquareButtonDown.Height / (double)Properties.Resources.SquareButtonBlueOff.Height);
                this.ButtonDownImage = new Bitmap(this.Width, this.Height);
                graphic = Graphics.FromImage(this.ButtonDownImage);
                graphic.DrawImage(Properties.Resources.SquareButtonDown, Convert.ToSingle(decimal.Multiply(new decimal((long)10), num)), Convert.ToSingle(decimal.Multiply(new decimal((long)10), num1)), Convert.ToSingle(decimal.Multiply(new decimal(this.ButtonDownImage.Width), num)), Convert.ToSingle(decimal.Multiply(new decimal(this.ButtonDownImage.Height), num1)));
                if (!this._Value)
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
                if (this._backBuffer != null)
                {
                    this._backBuffer.Dispose();
                }
                this._backBuffer = new Bitmap(this.Width, this.Height);
                this.Invalidate();
            }
        }

        public enum LightColors
        {
            Red,
            Green,
            Blue
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

            if (this.Enabled)
            {
                this.MouseIsDown = true;
                this.Invalidate();
            }
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
            this.MouseIsDown = false;
            this.Invalidate();
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

        private bool m_Value;

        public new bool Value
        {
            get { return m_Value; }
            set
            {
                if (!value)
                {
                    this.LightImage = this.OffImage;
                }
                else
                {
                    this.LightImage = this.OnImage;
                }

                if (m_Value != value)
                {
                    m_Value = value;

                    OnValueChanged(this, EventArgs.Empty);
                    Invalidate();
                }
            }
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