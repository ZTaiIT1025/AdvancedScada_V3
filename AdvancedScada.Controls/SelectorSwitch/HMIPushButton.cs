using AdvancedScada.Controls.DialogEditor;
using AdvancedScada.Controls.Licenses;
using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Client;
using AdvancedScada.Monitor;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace AdvancedScada.Controls.SelectorSwitch
{
    [DefaultEvent("Click")]
    [Designer(typeof(HMIPushButtonDesigner))]
    public class HMIPushButton : System.Windows.Forms.Control
    {
        #region Fild
        private Bitmap StaticImage;

        private Bitmap ButtonImage;

        private Bitmap ButtonUpImage;

        private Bitmap ButtonPressedImage;

        private Rectangle TextRectangle;

        private decimal ImageRatio;

        private ButtonColors m_ButtonColor;

        private LegendPlates m_LegendPlate;

        private OutputTypes m_OutputType;

        private StringFormat sf;

        private SolidBrush TextBrush;

        private Bitmap _backBuffer;

        private decimal LegendPlateRatio;

        private int LastWidth;

        private int LastHeight;
        #endregion
        #region Property
        public ButtonColors ButtonColor
        {
            get
            {
                return this.m_ButtonColor;
            }
            set
            {
                this.m_ButtonColor = value;
                this.RefreshImage();
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
                this.RefreshImage();
                this.Invalidate();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                this.TextBrush.Color = value;
                this.RefreshImage();
                this.Invalidate();
            }
        }

        public HMIPushButton.LegendPlates LegendPlate
        {
            get
            {
                return this.m_LegendPlate;
            }
            set
            {
                this.m_LegendPlate = value;
                this.RefreshImage();
                this.OnResize(EventArgs.Empty);
            }
        }

        public HMIPushButton.OutputTypes OutputType
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
                this.Invalidate();
            }
        }

        #endregion

        #region Sub
        public HMIPushButton()
        {

            this.TextRectangle = new Rectangle();
            this.m_ButtonColor = ButtonColors.Green;
            this.m_LegendPlate = LegendPlates.Large;
            this.m_OutputType = OutputTypes.MomentarySet;
            this.sf = new StringFormat();
            this.TextBrush = new SolidBrush(Color.Black);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.Height != this.LastHeight | this.Width != this.LastWidth)
            {
                if (this.m_LegendPlate != HMIPushButton.LegendPlates.Large)
                {
                    this.LegendPlateRatio = new decimal((double)Properties.Resources.LegendPlateShort.Height / (double)Properties.Resources.LegendPlateShort.Width);
                }
                else
                {
                    this.LegendPlateRatio = new decimal((double)Properties.Resources.LegendPlate.Height / (double)Properties.Resources.LegendPlate.Width);
                }
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
                this.RefreshImage();
            }
        }



        protected override void OnCreateControl()
        {
            base.OnCreateControl();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!(this.StaticImage == null || this._backBuffer == null))
            {
                Graphics graphic = Graphics.FromImage(this._backBuffer);
                graphic.DrawImage(this.StaticImage, 0, 0);
                if (this.m_LegendPlate != HMIPushButton.LegendPlates.Large)
                {
                    graphic.DrawImage(this.ButtonImage, Convert.ToInt32((double)this.StaticImage.Width / 2 - (double)this.ButtonImage.Width / 2), Convert.ToInt32((double)this.StaticImage.Height * 0.59 - (double)this.ButtonImage.Height / 2));
                }
                else
                {
                    graphic.DrawImage(this.ButtonImage, Convert.ToInt32((double)this.StaticImage.Width / 2 - (double)this.ButtonImage.Width / 2), Convert.ToInt32((double)this.StaticImage.Height * 0.68 - (double)this.ButtonImage.Height / 2));
                }
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
        }

        private void RefreshImage()
        {
            decimal WidthRatio = 0M;
            decimal HeightRatio = 0M;
            if (this.m_LegendPlate != HMIPushButton.LegendPlates.Large)
            {
                HeightRatio = new decimal((float)this.Width / (float)Properties.Resources.LegendPlateShort.Width);
                WidthRatio = new decimal((float)this.Height / (float)Properties.Resources.LegendPlateShort.Height);
            }
            else
            {
                HeightRatio = new decimal((float)this.Width / (float)Properties.Resources.LegendPlate.Width);
                WidthRatio = new decimal((float)this.Height / (float)Properties.Resources.LegendPlate.Height);
            }
            if (decimal.Compare(HeightRatio, WidthRatio) >= 0)
            {
                this.ImageRatio = WidthRatio;
            }
            else
            {
                this.ImageRatio = HeightRatio;
            }
            if (decimal.Compare(this.ImageRatio, decimal.Zero) > 0)
            {
                if (this.StaticImage != null)
                {
                    this.StaticImage.Dispose();
                }
                if (this.m_LegendPlate != HMIPushButton.LegendPlates.Large)
                {
                    this.StaticImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.LegendPlateShort.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.LegendPlateShort.Height), this.ImageRatio)));
                    this.LegendPlateRatio = new decimal((double)Properties.Resources.LegendPlateShort.Height / (double)Properties.Resources.LegendPlateShort.Width);
                }
                else
                {
                    this.StaticImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.LegendPlate.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.LegendPlate.Height), this.ImageRatio)));
                    this.LegendPlateRatio = new decimal((double)Properties.Resources.LegendPlate.Height / (double)Properties.Resources.LegendPlate.Width);
                }
                Graphics gr_dest = Graphics.FromImage(this.StaticImage);
                if (this.m_LegendPlate != HMIPushButton.LegendPlates.Large)
                {
                    gr_dest.DrawImage(Properties.Resources.LegendPlateShort, 0.0F, 0.0F, Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.LegendPlateShort.Width), this.ImageRatio)), Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.LegendPlateShort.Height), this.ImageRatio)));
                }
                else
                {
                    gr_dest.DrawImage(Properties.Resources.LegendPlate, 0.0F, 0.0F, Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.LegendPlate.Width), this.ImageRatio)), Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.LegendPlate.Height), this.ImageRatio)));
                }
                this.TextBrush = new SolidBrush(base.ForeColor);
                switch (this.m_ButtonColor)
                {
                    case ButtonColors.Red:
                        this.ButtonUpImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.RedButton.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.RedButton.Height), this.ImageRatio)));
                        this.ButtonPressedImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.RedButtonPressed.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.RedButtonPressed.Height), this.ImageRatio)));
                        break;
                    case ButtonColors.Green:

                        this.ButtonUpImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.GreenButton.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.GreenButton.Height), this.ImageRatio)));
                        this.ButtonPressedImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.GreenButtonPressed.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.GreenButtonPressed.Height), this.ImageRatio)));
                        break;
                    case ButtonColors.Blue:
                        this.ButtonUpImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.BlueButton.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.BlueButton.Height), this.ImageRatio)));
                        this.ButtonPressedImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.BlueButtonPressed.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.BlueButtonPressed.Height), this.ImageRatio)));
                        break;
                    case ButtonColors.Black:
                        this.ButtonUpImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.BlackButton.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.BlackButton.Height), this.ImageRatio)));
                        this.ButtonPressedImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.BlackButtonPressed.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.BlackButtonPressed.Height), this.ImageRatio)));
                        break;
                    case ButtonColors.RedMushroom:
                        this.ButtonUpImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.EstopButton.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.EstopButton.Height), this.ImageRatio)));
                        this.ButtonPressedImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.EstopButtonDown.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.EstopButtonDown.Height), this.ImageRatio)));
                        break;
                    default:
                        this.ButtonUpImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.GreenButton.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.GreenButton.Height), this.ImageRatio)));
                        this.ButtonPressedImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.GreenButtonPressed.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.GreenButtonPressed.Height), this.ImageRatio)));
                        break;
                }
                gr_dest = Graphics.FromImage(this.ButtonUpImage);
                Graphics gr_dest2 = Graphics.FromImage(this.ButtonPressedImage);
                switch (this.m_ButtonColor)
                {
                    case ButtonColors.Red:
                        gr_dest.DrawImage(Properties.Resources.RedButton, 0.0F, 0.0F, Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.GreenButton.Width), this.ImageRatio)), Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.GreenButton.Height), this.ImageRatio)));
                        gr_dest2.DrawImage(Properties.Resources.RedButtonPressed, 0.0F, 0.0F, Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.GreenButtonPressed.Width), this.ImageRatio)), Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.GreenButtonPressed.Height), this.ImageRatio)));
                        break;
                    case ButtonColors.Green:

                        gr_dest.DrawImage(Properties.Resources.GreenButton, 0.0F, 0.0F, Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.GreenButton.Width), this.ImageRatio)), Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.GreenButton.Height), this.ImageRatio)));
                        gr_dest2.DrawImage(Properties.Resources.GreenButtonPressed, 0.0F, 0.0F, Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.GreenButtonPressed.Width), this.ImageRatio)), Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.GreenButtonPressed.Height), this.ImageRatio)));
                        break;
                    case ButtonColors.Blue:
                        gr_dest.DrawImage(Properties.Resources.BlueButton, 0.0F, 0.0F, Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.GreenButton.Width), this.ImageRatio)), Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.GreenButton.Height), this.ImageRatio)));
                        gr_dest2.DrawImage(Properties.Resources.BlueButtonPressed, 0.0F, 0.0F, Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.GreenButtonPressed.Width), this.ImageRatio)), Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.GreenButtonPressed.Height), this.ImageRatio)));
                        break;
                    case ButtonColors.Black:
                        gr_dest.DrawImage(Properties.Resources.BlackButton, 0.0F, 0.0F, Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.GreenButton.Width), this.ImageRatio)), Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.GreenButton.Height), this.ImageRatio)));
                        gr_dest2.DrawImage(Properties.Resources.BlackButtonPressed, 0.0F, 0.0F, Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.GreenButtonPressed.Width), this.ImageRatio)), Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.GreenButtonPressed.Height), this.ImageRatio)));
                        break;
                    case ButtonColors.RedMushroom:
                        gr_dest.DrawImage(Properties.Resources.EstopButton, 0.0F, 0.0F, Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.EstopButton.Width), this.ImageRatio)), Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.EstopButton.Height), this.ImageRatio)));
                        gr_dest2.DrawImage(Properties.Resources.EstopButtonDown, 0.0F, 0.0F, Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.EstopButtonDown.Width), this.ImageRatio)), Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.EstopButtonDown.Height), this.ImageRatio)));
                        break;
                    default:
                        gr_dest.DrawImage(Properties.Resources.GreenButton, 0.0F, 0.0F, Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.GreenButton.Width), this.ImageRatio)), Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.GreenButton.Height), this.ImageRatio)));
                        gr_dest2.DrawImage(Properties.Resources.GreenButtonPressed, 0.0F, 0.0F, Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.GreenButtonPressed.Width), this.ImageRatio)), Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.GreenButtonPressed.Height), this.ImageRatio)));
                        break;
                }
                this.ButtonImage = this.ButtonUpImage;
                this.TextRectangle.X = 0;
                this.TextRectangle.Width = this.Width;
                this.TextRectangle.Y = 0;
                if (this.m_LegendPlate != HMIPushButton.LegendPlates.Large)
                {
                    this.TextRectangle.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height * 0.18)));
                }
                else
                {
                    this.TextRectangle.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height * 0.4)));
                }
                this.sf.Alignment = StringAlignment.Center;
                this.sf.LineAlignment = StringAlignment.Center;
                gr_dest.Dispose();
                gr_dest2.Dispose();
                if (this._backBuffer != null)
                {
                    this._backBuffer.Dispose();
                }
                this._backBuffer = new Bitmap(this.Width, this.Height);
                this.Invalidate();
            }
        }
        #endregion
        #region Enum
        public enum ButtonColors
        {
            Red,
            Green,
            Blue,
            Black,
            RedMushroom
        }

        public enum LegendPlates
        {
            Large,
            Small
        }

        public enum OutputTypes
        {
            MomentarySet,
            MomentaryReset,
            SetTrue,
            SetFalse,
            Toggle
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
                    case OutputTypes.MomentarySet:
                        WCFChannelFactory.Write(PLCAddressClick, Convert.ToString(false));
                        break;
                    case OutputTypes.MomentaryReset:
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
            this.ButtonImage = this.ButtonPressedImage;
            this.Invalidate();

            if (!string.IsNullOrWhiteSpace(m_PLCAddressClick) & Enabled && PLCAddressClick != null)
            {
                try
                {
                    switch (OutputType)
                    {
                        case OutputTypes.MomentarySet:
                            WCFChannelFactory.Write(m_PLCAddressClick, "1");
                            break;
                        case OutputTypes.MomentaryReset:
                            WCFChannelFactory.Write(m_PLCAddressClick, "0");
                            break;
                        case OutputTypes.SetTrue:
                            WCFChannelFactory.Write(m_PLCAddressClick, "1");
                            break;
                        case OutputTypes.SetFalse:
                            WCFChannelFactory.Write(m_PLCAddressClick, "0");
                            break;
                        case OutputTypes.Toggle:

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
            this.ButtonImage = this.ButtonUpImage;
            this.Invalidate();
            if (!string.IsNullOrWhiteSpace(m_PLCAddressClick) & Enabled)
            {
                try
                {
                    switch (OutputType)
                    {
                        case OutputTypes.MomentarySet:
                            WCFChannelFactory.Write(m_PLCAddressClick, "0");
                            break;
                        case OutputTypes.MomentaryReset:
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
        #region "Basic Properties"

        private bool m_Value;

        public bool Value
        {
            get { return m_Value; }
            set
            {
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

    internal class HMIPushButtonDesigner : ControlDesigner
    {
        private DesignerActionListCollection actionLists;

        // Use pull model to populate smart tag menu.
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == actionLists)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new HMIPushButtonActionList(Component));
                }

                return actionLists;
            }
        }
    }

    internal class HMIPushButtonActionList : DesignerActionList
    {
        private readonly HMIPushButton _HMIbutton;

        private DesignerActionUIService designerActionUISvc;

        //The constructor associates the control with the smart tag list.
        public HMIPushButtonActionList(IComponent component)
            : base(component)
        {
            _HMIbutton = component as HMIPushButton;

            // Cache a reference to DesignerActionUIService, 
            // so the DesigneractionList can be refreshed.
            designerActionUISvc = GetService(typeof(DesignerActionUIService))
                as DesignerActionUIService;
        }

        public string PLCAddressValue
        {
            get { return _HMIbutton.PLCAddressValue; }
            set { _HMIbutton.PLCAddressValue = value; }
        }

        public Color BackColor
        {
            get { return _HMIbutton.BackColor; }
            set { _HMIbutton.BackColor = value; }
        }

        public Color ForeColor
        {
            get { return _HMIbutton.ForeColor; }
            set { _HMIbutton.ForeColor = value; }
        }

        public Font Font
        {
            get { return _HMIbutton.Font; }
            set { _HMIbutton.Font = value; }
        }

        public string Text
        {
            get { return _HMIbutton.Text; }
            set { _HMIbutton.Text = value; }
        }

        // Implementation of this abstract method creates smart tag  items, 
        // associates their targets, and collects into list.
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("HMI Professional"));
            items.Add(new DesignerActionMethodItem(this, "ShowTagList", "Choose Tag"));
            items.Add(new DesignerActionPropertyItem("BackColor", "BackColor"));
            items.Add(new DesignerActionPropertyItem("ForeColor", "ForeColor"));
            items.Add(new DesignerActionPropertyItem("Font", "Font"));
            items.Add(new DesignerActionPropertyItem("PLCAddressValue", "PLCAddressValue"));
            items.Add(new DesignerActionPropertyItem("Text", "Text"));
            return items;
        }

        private void ShowTagList()
        {
            var frm = new MonitorForm(PLCAddressValue);
            frm.OnTagSelected_Clicked += tagName => { SetProperty(_HMIbutton, "PLCAddressValue", tagName); };
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        public void SetProperty(System.Windows.Forms.Control control, string propertyName, object value)
        {
            var pd = TypeDescriptor.GetProperties(control)[propertyName];
            pd.SetValue(control, value);
        }
    }
}