using AdvancedScada;
using AdvancedScada.Controls;
using AdvancedScada.Controls;
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

namespace AdvancedScada.Controls.Motor
{
    [Designer(typeof(HMIWaterPumpDesigner))]
    public class HMIWaterPump : Control
    {

        private Bitmap StaticImageOff;

        private Bitmap StaticImageOn;

        private float ImageRatio;

        private Rectangle TextRectangle;

        private StringFormat sfCenter;

        private StringFormat sfCenterBottom;

        private StringFormat sfRight;

        private StringFormat sfLeft;

        private bool m_Value;

        private float x;

        private float y;

        private Bitmap _backBuffer;

        private SolidBrush TextBrush;

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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                if (base.ForeColor != value)
                {
                    base.ForeColor = value;
                    if (this.TextBrush != null)
                    {
                        this.TextBrush.Color = value;
                    }
                    else
                    {
                        this.TextBrush = new SolidBrush(base.ForeColor);
                    }
                    this.Invalidate();
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
                this.Invalidate();
            }
        }



        public HMIWaterPump()
        {
            HMIWaterPump waterPump = this;
            base.Resize += waterPump._Resize;

            this.TextRectangle = new Rectangle();
            this.sfCenter = new StringFormat();
            this.sfCenterBottom = new StringFormat();
            this.sfRight = new StringFormat();
            this.sfLeft = new StringFormat();
            this.RefreshImage();
        }


        private void _Resize(object sender, EventArgs e)
        {
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    this.TextBrush.Dispose();
                    this._backBuffer.Dispose();
                    this.StaticImageOff.Dispose();
                    this.StaticImageOn.Dispose();
                    this.sfCenter.Dispose();
                    this.sfCenterBottom.Dispose();
                    this.sfRight.Dispose();
                    this.sfLeft.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!(this.StaticImageOff == null || this.TextBrush == null))
            {
                if (this._backBuffer == null)
                {
                    this._backBuffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
                }
                Graphics graphic = Graphics.FromImage(this._backBuffer);
                if (!this.m_Value)
                {
                    graphic.DrawImage(this.StaticImageOff, 0, 0);
                }
                else
                {
                    graphic.DrawImage(this.StaticImageOn, 0, 0);
                }
                if ((base.Text == null || string.Compare(base.Text, string.Empty) == 0) ? false : true)
                {
                    if (this.TextBrush.Color != base.ForeColor)
                    {
                        this.TextBrush.Color = base.ForeColor;
                    }
                    graphic.DrawString(base.Text, base.Font, this.TextBrush, this.TextRectangle, this.sfCenterBottom);
                }
                e.Graphics.DrawImageUnscaled(this._backBuffer, 0, 0);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (this._backBuffer != null)
            {
                this._backBuffer.Dispose();
                this._backBuffer = null;
            }
            this.RefreshImage();
            base.OnSizeChanged(e);
        }

        private void RefreshImage()
        {
            float width_Renamed = (float)((double)this.Width / (double)Properties.Resources.RSCorPumpOff.Width);
            float height_Renamed = (float)((double)this.Height / (double)Properties.Resources.RSCorPumpOff.Height);
            if (width_Renamed >= height_Renamed)
            {
                this.x = (float)this.Width;
                this.y = (float)((double)Properties.Resources.RSCorPumpOff.Height / (double)Properties.Resources.RSCorPumpOff.Width * (double)this.Width);
                this.ImageRatio = height_Renamed;
            }
            else
            {
                this.y = (float)this.Height;
                if (!(this.Height > 0 && Properties.Resources.RSCorPumpOff.Height > 0))
                {
                    this.x = 1.0F;
                }
                else
                {
                    this.x = (float)((double)Properties.Resources.RSCorPumpOff.Width / (double)Properties.Resources.RSCorPumpOff.Height * (double)this.Height);
                }
                this.ImageRatio = width_Renamed;
            }
            if (this.ImageRatio > 0.0F)
            {
                if (this.StaticImageOff != null)
                {
                    this.StaticImageOff.Dispose();
                }
                this.StaticImageOff = new Bitmap(Convert.ToInt32((float)Properties.Resources.RSCorPumpOff.Width * this.ImageRatio), Convert.ToInt32((float)Properties.Resources.RSCorPumpOff.Height * this.ImageRatio));
                Graphics graphic = Graphics.FromImage(this.StaticImageOff);
                graphic.DrawImage(Properties.Resources.RSCorPumpOff, 0, 0, this.StaticImageOff.Width, this.StaticImageOff.Height);
                if (this.StaticImageOn != null)
                {
                    this.StaticImageOn.Dispose();
                }
                this.StaticImageOn = new Bitmap(Convert.ToInt32((float)Properties.Resources.RSCorPumpOn.Width * this.ImageRatio), Convert.ToInt32((float)Properties.Resources.RSCorPumpOn.Height * this.ImageRatio));
                graphic = Graphics.FromImage(this.StaticImageOn);
                graphic.DrawImage(Properties.Resources.RSCorPumpOn, 0, 0, this.StaticImageOn.Width, this.StaticImageOn.Height);
                graphic.Dispose();
                this.TextRectangle.X = 0;
                this.TextRectangle.Y = 0;
                this.TextRectangle.Width = this.StaticImageOff.Width;
                this.TextRectangle.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)this.StaticImageOff.Height * 0.99)));
                this.sfCenterBottom.Alignment = StringAlignment.Center;
                this.sfCenterBottom.LineAlignment = StringAlignment.Far;
                if (this.TextBrush == null)
                {
                    this.TextBrush = new SolidBrush(base.ForeColor);
                }
                if (this._backBuffer != null)
                {
                    this._backBuffer.Dispose();
                }
                this._backBuffer = new Bitmap(this.Width, this.Height);
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

        public OutputType OutputType { get; set; }


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

    internal class HMIWaterPumpDesigner : ControlDesigner
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
                    actionLists.Add(new HMIWaterPumpActionList(Component));
                }

                return actionLists;
            }
        }
    }

    internal class HMIWaterPumpActionList : DesignerActionList
    {
        private readonly HMIWaterPump _HMIWaterPump;

        private DesignerActionUIService designerActionUISvc;

        //The constructor associates the control with the smart tag list.
        public HMIWaterPumpActionList(IComponent component)
            : base(component)
        {
            _HMIWaterPump = component as HMIWaterPump;

            // Cache a reference to DesignerActionUIService, 
            // so the DesigneractionList can be refreshed.
            designerActionUISvc = GetService(typeof(DesignerActionUIService))
                as DesignerActionUIService;
        }

        public string PLCAddressClick
        {
            get { return _HMIWaterPump.PLCAddressClick; }
            set { _HMIWaterPump.PLCAddressClick = value; }
        }

        // Implementation of this abstract method creates smart tag  items, 
        // associates their targets, and collects into list.
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("HMI Professional"));
            items.Add(new DesignerActionMethodItem(this, "ShowTagClick", "Click Tag"));
            items.Add(new DesignerActionPropertyItem("PLCAddressClick", "PLCAddressClick"));
            return items;
        }


        private void ShowTagClick()
        {
            var frm = new MonitorForm(this.PLCAddressClick);
            frm.OnTagSelected_Clicked += PLCAddressClick =>
            {
                var pd = TypeDescriptor.GetProperties(_HMIWaterPump)["PLCAddressClick"];
                pd.SetValue(_HMIWaterPump, PLCAddressClick);
            };
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }
    }
}