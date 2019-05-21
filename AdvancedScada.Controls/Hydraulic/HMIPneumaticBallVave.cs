
using AdvancedScada;
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

namespace AdvancedScada.Controls.Hydraulic
{
    public class HMIPneumaticBallVave : Control
    {

        private Bitmap LightImage;

        private Bitmap OffImage;

        private Bitmap OnImage;

        private Rectangle TextRectangle;

        private decimal ImageRatio;

        private StringFormat sf;

        private SolidBrush TextBrush;

        private Bitmap _backBuffer;

        private bool _Value;

        private RotateFlipType m_Rotation;

        private OutputType m_OutputType;

        private bool BackNeedsRefreshed;


        private Timer tmrError;

        private decimal SourceImageRatio;

        private int LastWidth;

        private int LastHeight;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams_Renamed = base.CreateParams;
                createParams_Renamed.ExStyle |= 32;
                return createParams_Renamed;
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

        public RotateFlipType Rotation
        {
            get
            {
                return this.m_Rotation;
            }
            set
            {
                this.m_Rotation = value;
                this.BackNeedsRefreshed = true;
                this.RefreshImage();
            }
        }



        public bool Value
        {
            get
            {
                return this._Value;
            }
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
                this._Value = value;
                this.Invalidate();
            }
        }



        public HMIPneumaticBallVave()
        {

            this.TextRectangle = new Rectangle();
            this.sf = new StringFormat();
            this.m_Rotation = RotateFlipType.RotateNoneFlipNone;
            this.m_OutputType = OutputType.MomentarySet;
            this.tmrError = new Timer();
            this.SourceImageRatio = new decimal((double)Properties.Resources.PneumaticBallValveOff.Height / (double)Properties.Resources.PneumaticBallValveOff.Width);
            if ((base.ForeColor == Color.FromKnownColor(KnownColor.ControlText)) || (this.ForeColor == Color.FromArgb(0, 0, 0, 0)))
            {
                this.ForeColor = Color.LightGray;
            }
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
                e.Graphics.DrawImage(this._backBuffer, 0, 0);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (this.BackNeedsRefreshed)
            {
                base.OnPaintBackground(e);
                this.BackNeedsRefreshed = false;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.LastHeight < this.Height || this.LastWidth < this.Width)
            {
                if ((double)this.Height / (double)this.Width <= Convert.ToDouble(this.SourceImageRatio))
                {
                    this.Height = Convert.ToInt32(decimal.Multiply(new decimal(this.Width), this.SourceImageRatio));
                }
                else
                {
                    this.Width = Convert.ToInt32(decimal.Divide(new decimal(this.Height), this.SourceImageRatio));
                }
            }
            else if ((double)this.Height / (double)this.Width <= Convert.ToDouble(this.SourceImageRatio))
            {
                this.Width = Convert.ToInt32(decimal.Divide(new decimal(this.Height), this.SourceImageRatio));
            }
            else
            {
                this.Height = Convert.ToInt32(decimal.Multiply(new decimal(this.Width), this.SourceImageRatio));
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

        private void RefreshImage()
        {
            decimal num = new decimal((float)this.Width / (float)Properties.Resources.PneumaticBallValveOff.Width);
            decimal num1 = new decimal((float)this.Height / (float)Properties.Resources.PneumaticBallValveOff.Height);
            if (decimal.Compare(num, num1) >= 0)
            {
                this.ImageRatio = num1;
            }
            else
            {
                this.ImageRatio = num;
            }
            if (decimal.Compare(this.ImageRatio, decimal.Zero) > 0)
            {
                this.LightImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.PneumaticBallValveOff.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.PneumaticBallValveOff.Height), this.ImageRatio)));
                Graphics graphic = Graphics.FromImage(this.LightImage);
                graphic.DrawImage(Properties.Resources.PneumaticBallValveOff, 0.0F, 0.0F, Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.PneumaticBallValveOff.Width), this.ImageRatio)), Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.PneumaticBallValveOff.Height), this.ImageRatio)));
                this.OffImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.PneumaticBallValveOff.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.PneumaticBallValveOff.Height), this.ImageRatio)));
                this.OnImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.PneumaticBallValveOn.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.PneumaticBallValveOn.Height), this.ImageRatio)));
                graphic = Graphics.FromImage(this.OffImage);
                Graphics graphic1 = Graphics.FromImage(this.OnImage);
                graphic.DrawImage(Properties.Resources.PneumaticBallValveOff, 0, 0, this.OffImage.Width, this.OffImage.Height);
                graphic1.DrawImage(Properties.Resources.PneumaticBallValveOn, 0, 0, this.OnImage.Width, this.OnImage.Height);
                this.OffImage.RotateFlip(this.m_Rotation);
                this.OnImage.RotateFlip(this.m_Rotation);
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
                this.TextRectangle.Width = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Width * 0.95)));
                this.TextRectangle.Y = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height * 0.55)));
                this.TextRectangle.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height * 0.45)));
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
                this.LightImage = this.OnImage;
                //if (this.m_OutputType == AdvancedScada.Controls.OutputType.Toggle)
                //{
                //    this.Value = !this.Value;
                //}
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
            if (this.Enabled)
            {
                if (this.OutputType != OutputType.Toggle)
                {
                    this.LightImage = this.OffImage;
                }
                this.Invalidate();
            }
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