using AdvancedScada.Controls.DialogEditor;
using AdvancedScada.Controls.Licenses;
using AdvancedScada.Controls.Motor;
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
    [Designer(typeof(HMIPilotLightDesigner))]
    public class HMIPilotLight : Control
    {

        private Bitmap StaticImage;

        private Bitmap LightImage;

        private Bitmap LightOffImage;

        private Bitmap LightOnImage;

        private Bitmap ButtonDownImage;

        private Rectangle TextRectangle;

        private decimal ImageRatio;

        private bool ButtonIsDown;

        private StringFormat sf;

        private SolidBrush TextBrush;

        private System.Timers.Timer BlinkTimer;

        private bool LightState;

        private bool m_Value;

        private LightColorOption m_LightColor;

        private LightColorOption m_LightColorOff;

        private bool m_Blink;

        private LegendPlates m_LegendPlate;

        private OutputType m_OutputType;

        private Bitmap _backBuffer;


        private System.Windows.Forms.Timer tmrError;

        private double LegendPlateRatio;

        private int LastWidth;

        private int LastHeight;

        public bool Blink
        {
            get
            {
                return this.m_Blink;
            }
            set
            {
                this.m_Blink = value;
                if (!value)
                {
                    if (this.BlinkTimer != null)
                    {
                        this.BlinkTimer.Enabled = false;
                    }
                    if (!this.m_Value)
                    {
                        this.LightImage = this.LightOffImage;
                    }
                    else
                    {
                        this.LightImage = this.LightOnImage;
                    }
                }
                else
                {
                    if (this.BlinkTimer == null)
                    {
                        this.BlinkTimer = new System.Timers.Timer(600);
                        HMIPilotLight pilotLight = this;
                        BlinkTimer.Elapsed += pilotLight.BlinkElapsed;
                    }
                    this.BlinkTimer.Enabled = true;
                }
            }
        }

        public LegendPlates LegendPlate
        {
            get
            {
                return this.m_LegendPlate;
            }
            set
            {
                this.m_LegendPlate = value;
                this.OnResize(EventArgs.Empty);
                this.RefreshImage();
            }
        }

        public LightColorOption LightColor
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

        public LightColorOption LightColorOff
        {
            get
            {
                return this.m_LightColorOff;
            }
            set
            {
                this.m_LightColorOff = value;
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







        public HMIPilotLight()
        {

            this.TextRectangle = new Rectangle();
            this.sf = new StringFormat();
            this.m_LightColor = LightColorOption.Green;
            this.m_LightColorOff = LightColorOption.White;
            this.m_LegendPlate = LegendPlates.Large;
            this.m_OutputType = OutputType.MomentarySet;
            this.tmrError = new System.Windows.Forms.Timer();
            this.LegendPlateRatio = (double)Properties.Resources.LegendPlate.Height / (double)Properties.Resources.LegendPlate.Width;
            this.sf = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            this.TextBrush = new SolidBrush(Color.Black);
        }


        private void BlinkElapsed(object sender, EventArgs e)
        {
            if ((this.LightImage == this.LightOnImage || !this.m_Value) ? false : true)
            {
                this.LightImage = this.LightOnImage;
            }
            else
            {
                this.LightImage = this.LightOffImage;
            }
            this.Invalidate();
        }




        protected override void OnPaint(PaintEventArgs e)
        {
            if (!(this.StaticImage == null || this._backBuffer == null || this.LightImage == null))
            {
                Graphics g = Graphics.FromImage(this._backBuffer);
                g.DrawImage(this.StaticImage, 0, 0);
                if (this.m_LegendPlate != LegendPlates.Large)
                {
                    g.DrawImage(this.LightImage, Convert.ToInt32((double)this.StaticImage.Width / 2 - (double)this.LightImage.Width / 2), Convert.ToInt32((double)this.StaticImage.Height * 0.59 - (double)this.LightImage.Height / 2));
                }
                else
                {
                    g.DrawImage(this.LightImage, Convert.ToInt32((double)this.StaticImage.Width / 2 - (double)this.LightImage.Width / 2), Convert.ToInt32((double)this.StaticImage.Height * 0.68 - (double)this.LightImage.Height / 2));
                }
                if ((this.Text == null || string.Compare(this.Text, string.Empty) == 0) ? false : true)
                {
                    if (this.TextBrush.Color != base.ForeColor)
                    {
                        this.TextBrush.Color = base.ForeColor;
                    }
                    g.DrawString(base.Text, base.Font, this.TextBrush, this.TextRectangle, this.sf);
                }
                if (this.ButtonIsDown)
                {
                    if (this.m_LegendPlate != LegendPlates.Large)
                    {
                        g.DrawImage(this.ButtonDownImage, Convert.ToSingle(decimal.Multiply(new decimal((long)102), this.ImageRatio)), Convert.ToSingle(decimal.Multiply(new decimal((long)170), this.ImageRatio)));
                    }
                    else
                    {
                        g.DrawImage(this.ButtonDownImage, Convert.ToSingle(decimal.Multiply(new decimal((long)102), this.ImageRatio)), Convert.ToSingle(decimal.Multiply(new decimal((long)360), this.ImageRatio)));
                    }
                }
                e.Graphics.DrawImage(this._backBuffer, 0, 0);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        protected override void OnResize(EventArgs e)
        {
            if (this.m_LegendPlate != LegendPlates.Large)
            {
                this.LegendPlateRatio = (double)Properties.Resources.LegendPlateShort.Height / (double)Properties.Resources.LegendPlateShort.Width;
            }
            else
            {
                this.LegendPlateRatio = (double)Properties.Resources.LegendPlate.Height / (double)Properties.Resources.LegendPlate.Width;
            }
            base.OnResize(e);
            if (this.LastHeight < this.Height || this.LastWidth < this.Width)
            {
                if ((double)this.Height / (double)this.Width <= this.LegendPlateRatio)
                {
                    this.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Width * this.LegendPlateRatio)));
                }
                else
                {
                    this.Width = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height / this.LegendPlateRatio)));
                }
            }
            else if ((double)this.Height / (double)this.Width <= this.LegendPlateRatio)
            {
                this.Width = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height / this.LegendPlateRatio)));
            }
            else
            {
                this.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Width * this.LegendPlateRatio)));
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

        protected virtual void OnValueChanged(EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, e);
        }

        private void RefreshImage()
        {
            Graphics gr_dest = null;
            decimal WidthRatio = 0M;
            decimal HeightRatio = 0M;
            if (this.m_LegendPlate != LegendPlates.Large)
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
                if (this.m_LegendPlate != LegendPlates.Large)
                {
                    this.StaticImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.LegendPlateShort.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.LegendPlateShort.Height), this.ImageRatio)));
                    this.LegendPlateRatio = (double)Properties.Resources.LegendPlateShort.Height / (double)Properties.Resources.LegendPlateShort.Width;
                    gr_dest = Graphics.FromImage(this.StaticImage);
                    gr_dest.DrawImage(Properties.Resources.LegendPlateShort, 0.0F, 0.0F, Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.LegendPlateShort.Width), this.ImageRatio)), Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.LegendPlateShort.Height), this.ImageRatio)));
                }
                else
                {
                    this.StaticImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.LegendPlate.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.LegendPlate.Height), this.ImageRatio)));
                    this.LegendPlateRatio = (double)Properties.Resources.LegendPlate.Height / (double)Properties.Resources.LegendPlate.Width;
                    gr_dest = Graphics.FromImage(this.StaticImage);
                    gr_dest.DrawImage(Properties.Resources.LegendPlate, 0.0F, 0.0F, Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.LegendPlate.Width), this.ImageRatio)), Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.LegendPlate.Height), this.ImageRatio)));
                }
                this.LightOffImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.GreenPilotOff.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.GreenPilotOff.Height), this.ImageRatio)));
                this.LightOnImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.GreenPilotOff.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.GreenPilotOff.Height), this.ImageRatio)));
                gr_dest = Graphics.FromImage(this.LightOffImage);
                Graphics graphic1 = Graphics.FromImage(this.LightOnImage);
                if (this.m_LightColorOff == LightColorOption.Green)
                {
                    gr_dest.DrawImage(Properties.Resources.GreenPilotOff, 0, 0, this.LightOffImage.Width, this.LightOffImage.Height);
                }
                else if (this.m_LightColorOff == LightColorOption.Red)
                {
                    gr_dest.DrawImage(Properties.Resources.RedPilotOff, 0, 0, this.LightOffImage.Width, this.LightOffImage.Height);
                }
                else if (this.m_LightColorOff == LightColorOption.Blue)
                {
                    gr_dest.DrawImage(Properties.Resources.BluePilotOff, 0, 0, this.LightOffImage.Width, this.LightOffImage.Height);
                }
                else if (this.m_LightColorOff != LightColorOption.White)
                {
                    gr_dest.DrawImage(Properties.Resources.YellowPilotOff, 0, 0, this.LightOffImage.Width, this.LightOffImage.Height);
                }
                else
                {
                    gr_dest.DrawImage(Properties.Resources.WhitePilotOff, 0, 0, this.LightOffImage.Width, this.LightOffImage.Height);
                }
                if (this.m_LightColor == LightColorOption.Green)
                {
                    graphic1.DrawImage(Properties.Resources.GreenPilotOn, 0, 0, this.LightOnImage.Width, this.LightOnImage.Height);
                }
                else if (this.m_LightColor == LightColorOption.Red)
                {
                    graphic1.DrawImage(Properties.Resources.RedPilotOn, 0, 0, this.LightOnImage.Width, this.LightOnImage.Height);
                }
                else if (this.m_LightColor == LightColorOption.Blue)
                {
                    graphic1.DrawImage(Properties.Resources.BluePilotOn, 0, 0, this.LightOnImage.Width, this.LightOnImage.Height);
                }
                else if (this.m_LightColor != LightColorOption.White)
                {
                    graphic1.DrawImage(Properties.Resources.YellowPilotOn, 0, 0, this.LightOnImage.Width, this.LightOnImage.Height);
                }
                else
                {
                    graphic1.DrawImage(Properties.Resources.WhitePilotOn, 0, 0, this.LightOnImage.Width, this.LightOnImage.Height);
                }
                this.ButtonDownImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.PilotLightDown.Width), this.ImageRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.PilotLightDown.Height), this.ImageRatio)));
                gr_dest = Graphics.FromImage(this.ButtonDownImage);
                gr_dest.DrawImage(Properties.Resources.PilotLightDown, 0, 0, this.ButtonDownImage.Width, this.ButtonDownImage.Height);
                if (!this.m_Value)
                {
                    this.LightImage = this.LightOffImage;
                }
                else
                {
                    this.LightImage = this.LightOnImage;
                }
                gr_dest.Dispose();
                graphic1.Dispose();
                this.TextRectangle.X = 0;
                this.TextRectangle.Width = this.Width;
                this.TextRectangle.Y = 0;
                if (this.m_LegendPlate != LegendPlates.Large)
                {
                    this.TextRectangle.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height * 0.18)));
                }
                else
                {
                    this.TextRectangle.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)this.Height * 0.4)));
                }
                if (this._backBuffer != null)
                {
                    this._backBuffer.Dispose();
                }
                this._backBuffer = new Bitmap(this.Width, this.Height);
                this.Invalidate();
            }
        }

        public event EventHandler ValueChanged;

        public enum LegendPlates
        {
            Large,
            Small
        }

        public enum LightColorOption
        {
            Red,
            Green,
            Blue,
            Yellow,
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




        private void ReleaseValue()
        {
            try
            {
                switch (OutputType)
                {
                    case OutputType.MomentarySet:
                        WCFChannelFactory.Write(PLCAddressClick, "0");
                        break;
                    case OutputType.MomentaryReset:
                        WCFChannelFactory.Write(PLCAddressClick, "1");
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
            this.ButtonIsDown = true;
            if (this.Enabled)
            {
                this.LightImage = this.LightOnImage;
                if (this.m_OutputType == OutputType.Toggle)
                {
                    this.Value = !this.Value;
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
                            if (!CurrentValue)
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
            this.ButtonIsDown = false;
            if (this.Enabled)
            {
                if (this.OutputType != OutputType.Toggle)
                {
                    this.LightImage = this.LightOffImage;
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

        #region "Basic Properties"



        public bool Value
        {
            get { return m_Value; }
            set
            {
                if (value != this.m_Value)
                {
                    if (!value)
                    {
                        this.LightImage = this.LightOffImage;
                    }
                    else
                    {
                        this.LightImage = this.LightOnImage;
                    }
                    this.m_Value = value;
                    this.Invalidate();
                    this.OnValueChanged(EventArgs.Empty);
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

    internal class HMIPilotLightDesigner : ControlDesigner
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
                    actionLists.Add(new HMIPilotLightActionList(Component));
                }

                return actionLists;
            }
        }
    }

    internal class HMIPilotLightActionList : DesignerActionList
    {
        private readonly HMIPilotLight _HMIbutton;

        private DesignerActionUIService designerActionUISvc;

        //The constructor associates the control with the smart tag list.
        public HMIPilotLightActionList(IComponent component)
            : base(component)
        {
            _HMIbutton = component as HMIPilotLight;

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
            frm.OnTagSelected_Clicked += tagName =>
            {
                var pd = TypeDescriptor.GetProperties(_HMIbutton)["PLCAddressValue"];
                pd.SetValue(_HMIbutton, tagName);
            };
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }
    }
}