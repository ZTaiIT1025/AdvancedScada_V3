using AdvancedScada.Controls.ClassBase;
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

namespace AdvancedScada.Controls.SelectorSwitch
{
    public class HMISelectorSwitch : ClassBase.ButtonBase
    {
        #region تعريفات
        private Bitmap ButtonImage;

        private LegendPlates m_LegendPlate;

        private OutputType m_OutputType;

        private decimal LegendPlateRatio;
        #endregion

        #region Property
        public enum LegendPlates
        {
            Large,
            Small
        }
        public HMISelectorSwitch.LegendPlates LegendPlate
        {
            get
            {
                return this.m_LegendPlate;
            }
            set
            {
                if (this.m_LegendPlate != value)
                {
                    this.m_LegendPlate = value;
                    this.CreateStaticImage();
                }
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
        #endregion
        #region المشيدات
        public HMISelectorSwitch()
        {
            this.m_LegendPlate = LegendPlates.Large;
            this.m_OutputType = OutputType.MomentarySet;
            this.LegendPlateRatio = new decimal((double)Properties.Resources.LegendPlate.Height / (double)Properties.Resources.LegendPlate.Width);
        }
        #endregion
        #region اعدة تعريف الاحداث



        protected override void OnPaint(PaintEventArgs e)
        {
            if (!(this.StaticImage == null || this.BackBuffer == null || this.ButtonImage == null))
            {
                Graphics g = Graphics.FromImage(this.BackBuffer);
                g.DrawImage(this.StaticImage, 0, 0);
                if (!this.m_Value)
                {
                    this.ButtonImage = (Bitmap)this.OffImage;
                }
                else
                {
                    this.ButtonImage = (Bitmap)this.OnImage;
                }
                if (this.m_LegendPlate != HMISelectorSwitch.LegendPlates.Large)
                {
                    g.DrawImage(this.ButtonImage, Convert.ToInt32((double)this.StaticImage.Width / 2 - (double)this.ButtonImage.Width / 2), Convert.ToInt32((double)this.StaticImage.Height * 0.59 - (double)this.ButtonImage.Height / 2));
                }
                else
                {
                    g.DrawImage(this.ButtonImage, Convert.ToInt32((double)this.StaticImage.Width / 2 - (double)this.ButtonImage.Width / 2), Convert.ToInt32((double)this.StaticImage.Height * 0.68 - (double)this.ButtonImage.Height / 2));
                }
                if ((base.Text == null || string.Compare(base.Text, string.Empty) == 0) ? false : true)
                {
                    if (this.TextBrush.Color != base.ForeColor)
                    {
                        this.TextBrush.Color = base.ForeColor;
                    }
                    g.DrawString(base.Text, base.Font, this.TextBrush, this.TextRectangle, this.sf);
                }
                e.Graphics.DrawImage(this.BackBuffer, 0, 0);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (this.LastHeight < this.Height || this.LastWidth < this.Width)
            {
                if ((double)this.Height / (double)this.Width <= Convert.ToDouble(this.LegendPlateRatio))
                {
                    this.Height = Convert.ToInt32(decimal.Multiply(new decimal(this.Width), this.LegendPlateRatio));
                }
                else
                {
                    this.Width = Convert.ToInt32(decimal.Divide(new decimal(this.Height), this.LegendPlateRatio));
                }
            }
            else if ((double)this.Height / (double)this.Width <= Convert.ToDouble(this.LegendPlateRatio))
            {
                this.Width = Convert.ToInt32(decimal.Divide(new decimal(this.Height), this.LegendPlateRatio));
            }
            else
            {
                this.Height = Convert.ToInt32(decimal.Multiply(new decimal(this.Width), this.LegendPlateRatio));
            }
            this.LastWidth = this.Width;
            this.LastHeight = this.Height;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Invalidate();
        }
        #endregion
        #region طرق
        protected override void CreateStaticImage()
        {
            decimal HeightRatio = 0M;
            decimal WidthRatio = 0M;
            if (this.m_LegendPlate != HMISelectorSwitch.LegendPlates.Large)
            {
                WidthRatio = new decimal((float)this.Width / (float)Properties.Resources.LegendPlateShort.Width);
                HeightRatio = new decimal((float)this.Height / (float)Properties.Resources.LegendPlateShort.Height);
            }
            else
            {
                WidthRatio = new decimal((float)this.Width / (float)Properties.Resources.LegendPlate.Width);
                HeightRatio = new decimal((float)this.Height / (float)Properties.Resources.LegendPlate.Height);
            }
            if (decimal.Compare(WidthRatio, HeightRatio) >= 0)
            {
                this.ImageRatio = Convert.ToDouble(HeightRatio);
            }
            else
            {
                this.ImageRatio = Convert.ToDouble(WidthRatio);
            }
            if (this.ImageRatio > 0)
            {
                if (this.StaticImage != null)
                {
                    this.StaticImage.Dispose();
                }
                if (this.m_LegendPlate != HMISelectorSwitch.LegendPlates.Large)
                {
                    this.StaticImage = new Bitmap(Convert.ToInt32((double)Properties.Resources.LegendPlateShort.Width * this.ImageRatio), Convert.ToInt32((double)Properties.Resources.LegendPlateShort.Height * this.ImageRatio));
                    this.LegendPlateRatio = new decimal((double)Properties.Resources.LegendPlateShort.Height / (double)Properties.Resources.LegendPlateShort.Width);
                }
                else
                {
                    this.StaticImage = new Bitmap(Convert.ToInt32((double)Properties.Resources.LegendPlate.Width * this.ImageRatio), Convert.ToInt32((double)Properties.Resources.LegendPlate.Height * this.ImageRatio));
                    this.LegendPlateRatio = new decimal((double)Properties.Resources.LegendPlate.Height / (double)Properties.Resources.LegendPlate.Width);
                }
                Graphics gr_dest = Graphics.FromImage(this.StaticImage);
                if (this.m_LegendPlate != HMISelectorSwitch.LegendPlates.Large)
                {
                    gr_dest.DrawImage(Properties.Resources.LegendPlateShort, 0, 0, Convert.ToInt32((double)Properties.Resources.LegendPlateShort.Width * this.ImageRatio), Convert.ToInt32((double)Properties.Resources.LegendPlateShort.Height * this.ImageRatio));
                }
                else
                {
                    gr_dest.DrawImage(Properties.Resources.LegendPlate, 0, 0, Convert.ToInt32((double)Properties.Resources.LegendPlate.Width * this.ImageRatio), Convert.ToInt32((double)Properties.Resources.LegendPlate.Height * this.ImageRatio));
                }
                this.OffImage = new Bitmap(Convert.ToInt32((double)Properties.Resources.SelectorSwitchLeft.Width * this.ImageRatio), Convert.ToInt32((double)Properties.Resources.SelectorSwitchLeft.Height * this.ImageRatio));
                this.OnImage = new Bitmap(Convert.ToInt32((double)Properties.Resources.SelectorSwitchRight.Width * this.ImageRatio), Convert.ToInt32((double)Properties.Resources.SelectorSwitchRight.Height * this.ImageRatio));
                gr_dest = Graphics.FromImage(this.OffImage);
                Graphics gr_dest1 = Graphics.FromImage(this.OnImage);
                gr_dest.DrawImage(Properties.Resources.SelectorSwitchLeft, 0, 0, this.OffImage.Width, this.OffImage.Height);
                gr_dest1.DrawImage(Properties.Resources.SelectorSwitchRight, 0, 0, this.OnImage.Width, this.OnImage.Height);
                this.ButtonImage = (Bitmap)this.OffImage;
                gr_dest.Dispose();
                gr_dest1.Dispose();
                this.TextRectangle.X = 0;
                this.TextRectangle.Width = this.Width;
                this.TextRectangle.Y = 0;
                if (this.m_LegendPlate != HMISelectorSwitch.LegendPlates.Large)
                {
                    this.TextRectangle.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height * 0.18)));
                }
                else
                {
                    this.TextRectangle.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height * 0.4)));
                }
                this.sf.Alignment = StringAlignment.Center;
                this.sf.LineAlignment = StringAlignment.Center;
                this.TextBrush = new SolidBrush(base.ForeColor);
                if (this.BackBuffer != null)
                {
                    this.BackBuffer.Dispose();
                }
                this.BackBuffer = new Bitmap(this.Width, this.Height);
                this.Invalidate();
            }
        }
        #endregion
        #region PLC Properties


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


        #region "Basic Properties"

        public new bool Value
        {
            get { return m_Value; }
            set
            {
                if (m_Value != value)
                {
                    m_Value = value;
                    base.Value = m_Value;
                    OnValueChanged(this, EventArgs.Empty);
                    Invalidate();
                }
            }
        }

        #endregion

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

        public new event EventHandler ValueChanged;


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
                this.ButtonImage = (Bitmap)this.OnImage;
                if (this.m_OutputType == OutputType.Toggle)
                {
                    this.Value = !this.m_Value;
                }
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
                    this.ButtonImage = (Bitmap)this.OffImage;
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

        protected virtual void OnValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null) ValueChanged(this, e);
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