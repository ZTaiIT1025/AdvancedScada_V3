
using AdvancedScada;
using AdvancedScada.Controls;
using AdvancedScada.Controls.DialogEditor;
using AdvancedScada.Controls.Licenses;
using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Client;
using AdvancedScada.Monitor;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Motor
{
    [Designer(typeof(HMIMotorDesigner))]
    public class HMIMotor : Control
    {

        private Bitmap LightImage;

        private Bitmap LightOffImage;

        private Bitmap LightOnImage;

        private Rectangle TextRectangle;

        private StringFormat TextFormat;

        private SolidBrush TextBrush;

        private bool _Value;

        private LightColorOption m_LightColor;

        private RotateFlipType m_Rotation;

        private OutputType m_OutputType;

        private bool BackNeedsRefreshed;

        private Bitmap _backBuffer;


        private Timer tmrError;

        private decimal ControlSizeRatio;

        private decimal SourceImageRatio;

        private int LastWidth;

        private int LastHeight;
        #region Property
        //* This is necessary to make the background draw correctly
        //*  http://www.bobpowell.net/transcontrols.htm
        //*part of the transparent background code
        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                System.Windows.Forms.CreateParams cp = base.CreateParams;
                cp.ExStyle |= 32;
                return cp;
            }
        }
        public LightColorOption LightColor
        {
            get
            {
                return m_LightColor;
            }
            set
            {
                m_LightColor = value;
                RefreshImage();
            }
        }

        public OutputType OutputType
        {
            get
            {
                return m_OutputType;
            }
            set
            {
                m_OutputType = value;
            }
        }

        public RotateFlipType Rotation
        {
            get
            {
                return m_Rotation;
            }
            set
            {
                if (m_Rotation != value)
                {
                    m_Rotation = value;
                    BackNeedsRefreshed = true;
                    AdjustRatio();
                    RefreshImage();
                }
            }
        }




        #endregion



        public HMIMotor()
        {

            TextRectangle = new Rectangle();
            m_LightColor = LightColorOption.Green;
            m_Rotation = RotateFlipType.RotateNoneFlipNone;
            m_OutputType = OutputType.MomentarySet;
            tmrError = new Timer();
            SourceImageRatio = new decimal((double)Properties.Resources.MotorGray.Height / (double)Properties.Resources.MotorGray.Width);
            TextBrush = new SolidBrush(base.ForeColor);
            TextFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Far
            };
        }


        private void AdjustRatio()
        {
            if (!(m_Rotation == RotateFlipType.Rotate90FlipNone || m_Rotation == RotateFlipType.Rotate270FlipNone || m_Rotation == RotateFlipType.Rotate90FlipX || m_Rotation == RotateFlipType.Rotate270FlipX || m_Rotation == RotateFlipType.Rotate270FlipX || m_Rotation == RotateFlipType.Rotate90FlipX || m_Rotation == RotateFlipType.Rotate270FlipNone || m_Rotation == RotateFlipType.Rotate90FlipNone))
            {
                SourceImageRatio = new decimal((double)Properties.Resources.MotorGray.Height / (double)Properties.Resources.MotorGray.Width);
            }
            else
            {
                SourceImageRatio = new decimal((double)Properties.Resources.MotorGray.Width / (double)Properties.Resources.MotorGray.Height);
            }
            if (LastHeight < Height || LastWidth < Width)
            {
                if ((double)Height / (double)Width <= Convert.ToDouble(SourceImageRatio))
                {
                    Height = Convert.ToInt32(decimal.Multiply(new decimal(Width), SourceImageRatio));
                }
                else
                {
                    Width = Convert.ToInt32(decimal.Divide(new decimal(Height), SourceImageRatio));
                }
            }
            else if ((double)Height / (double)Width <= Convert.ToDouble(SourceImageRatio))
            {
                Width = Convert.ToInt32(decimal.Divide(new decimal(Height), SourceImageRatio));
            }
            else
            {
                Height = Convert.ToInt32(decimal.Multiply(new decimal(Width), SourceImageRatio));
            }
            LastWidth = Width;
            LastHeight = Height;
            RefreshImage();
        }




        protected override void OnPaint(PaintEventArgs e)
        {
            if (!(_backBuffer == null || LightImage == null))
            {
                Graphics g = Graphics.FromImage(_backBuffer);
                g.DrawImage(LightImage, 0, 0);
                if ((Text == null || string.Compare(Text, string.Empty) == 0) ? false : true)
                {
                    if (TextBrush.Color != ForeColor)
                    {
                        TextBrush.Color = ForeColor;
                    }
                    g.DrawString(Text, Font, TextBrush, TextRectangle, TextFormat);
                }
                e.Graphics.DrawImage(_backBuffer, 0, 0);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (BackNeedsRefreshed)
            {
                base.OnPaintBackground(e);
                BackNeedsRefreshed = false;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AdjustRatio();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            RefreshImage();
        }

        private void RefreshImage()
        {
            decimal WidthRatio = 0M;
            decimal HeightRatio = 0M;
            if (!(Width <= 0 || Height <= 0))
            {
                if (!(m_Rotation == RotateFlipType.Rotate90FlipNone || m_Rotation == RotateFlipType.Rotate270FlipNone || m_Rotation == RotateFlipType.Rotate90FlipX || m_Rotation == RotateFlipType.Rotate270FlipX || m_Rotation == RotateFlipType.Rotate270FlipX || m_Rotation == RotateFlipType.Rotate90FlipX || m_Rotation == RotateFlipType.Rotate270FlipNone || m_Rotation == RotateFlipType.Rotate90FlipNone))
                {
                    SourceImageRatio = new decimal((double)Properties.Resources.MotorGray.Height / (double)Properties.Resources.MotorGray.Width);
                    HeightRatio = new decimal((float)Width / (float)Properties.Resources.MotorGray.Width);
                    WidthRatio = new decimal((float)Height / (float)Properties.Resources.MotorGray.Height);
                }
                else
                {
                    SourceImageRatio = new decimal((double)Properties.Resources.MotorGray.Width / (double)Properties.Resources.MotorGray.Height);
                    HeightRatio = new decimal((float)Width / (float)Properties.Resources.MotorGray.Height);
                    WidthRatio = new decimal((float)Height / (float)Properties.Resources.MotorGray.Width);
                }
                ControlSizeRatio = Math.Min(HeightRatio, WidthRatio);
                LightImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.MotorGray.Width), ControlSizeRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.MotorGray.Height), ControlSizeRatio)));
                Graphics gr_dest = Graphics.FromImage(LightImage);
                gr_dest.DrawImage(Properties.Resources.MotorGray, 0.0F, 0.0F, Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.MotorGray.Width), ControlSizeRatio)), Convert.ToSingle(decimal.Multiply(new decimal(Properties.Resources.MotorGray.Height), ControlSizeRatio)));
                LightOffImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.MotorGray.Width), ControlSizeRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.MotorGray.Height), ControlSizeRatio)));
                LightOnImage = new Bitmap(Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.MotorGreen.Width), ControlSizeRatio)), Convert.ToInt32(decimal.Multiply(new decimal(Properties.Resources.MotorGreen.Height), ControlSizeRatio)));
                gr_dest = Graphics.FromImage(LightOffImage);
                Graphics gr_dest2 = Graphics.FromImage(LightOnImage);
                gr_dest.DrawImage(Properties.Resources.MotorGray, 0, 0, LightOffImage.Width, LightOffImage.Height);
                gr_dest2.DrawImage(Properties.Resources.MotorGreen, 0, 0, LightOnImage.Width, LightOnImage.Height);
                LightOnImage.RotateFlip(m_Rotation);
                LightOffImage.RotateFlip(m_Rotation);
                if (!_Value)
                {
                    LightImage = LightOffImage;
                }
                else
                {
                    LightImage = LightOnImage;
                }
                gr_dest.Dispose();
                gr_dest2.Dispose();
                TextRectangle.X = 0;
                TextRectangle.Width = Convert.ToInt32(Math.Truncate(Math.Round((double)Width * 0.95)));
                TextRectangle.Y = Convert.ToInt32(Math.Truncate(Math.Round((double)Height * 0.77)));
                TextRectangle.Height = Convert.ToInt32(Math.Truncate(Math.Round((double)Height * 0.2)));
                if (_backBuffer != null)
                {
                    _backBuffer.Dispose();
                }
                _backBuffer = new Bitmap(Width, Height);
                Invalidate();
            }
        }

        public enum LightColorOption
        {
            Red,
            Green, Yellow
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

            if (Enabled)
            {
                LightImage = LightOnImage;

                Invalidate();
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
            if (!string.IsNullOrWhiteSpace(m_PLCAddressClick) & Enabled)
            {
                try
                {
                    if (Enabled)
                    {
                        if (OutputType != OutputType.Toggle)
                        {
                            LightImage = LightOffImage;
                        }
                        Invalidate();
                    }
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

        public bool Value
        {
            get { return m_Value; }
            set
            {
                if (m_Value != value)
                {
                    m_Value = value;
                    if (!value)
                    {
                        LightImage = LightOffImage;
                    }
                    else
                    {
                        LightImage = LightOnImage;
                    }
                    _Value = value;
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
    internal class HMIMotorDesigner : ControlDesigner
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
                    actionLists.Add(new HMIMotorActionList(Component));
                }

                return actionLists;
            }
        }
    }

    internal class HMIMotorActionList : DesignerActionList
    {
        private readonly HMIMotor _HMIMotor;

        private DesignerActionUIService designerActionUISvc;

        //The constructor associates the control with the smart tag list.
        public HMIMotorActionList(IComponent component)
            : base(component)
        {
            _HMIMotor = component as HMIMotor;

            // Cache a reference to DesignerActionUIService, 
            // so the DesigneractionList can be refreshed.
            designerActionUISvc = GetService(typeof(DesignerActionUIService))
                as DesignerActionUIService;
        }

        public string PLCAddressValue
        {
            get { return _HMIMotor.PLCAddressValue; }
            set { _HMIMotor.PLCAddressValue = value; }
        }

        public string PLCAddressClick
        {
            get { return _HMIMotor.PLCAddressClick; }
            set { _HMIMotor.PLCAddressClick = value; }
        }

        // Implementation of this abstract method creates smart tag  items, 
        // associates their targets, and collects into list.
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("HMI Professional"));
            items.Add(new DesignerActionMethodItem(this, "ShowTagList", "Choose Tag"));
            items.Add(new DesignerActionMethodItem(this, "ShowTagClick", "Click Tag"));
            items.Add(new DesignerActionPropertyItem("PLCAddressValue", "PLCAddressValue"));
            items.Add(new DesignerActionPropertyItem("PLCAddressClick", "PLCAddressClick"));
            return items;
        }

        private void ShowTagList()
        {
            var frm = new MonitorForm(PLCAddressValue);
            frm.OnTagSelected_Clicked += tagName =>
            {
                var pd = TypeDescriptor.GetProperties(_HMIMotor)["PLCAddressValue"];
                pd.SetValue(_HMIMotor, tagName);
            };
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void ShowTagClick()
        {
            var frm = new MonitorForm(this.PLCAddressClick);
            frm.OnTagSelected_Clicked += PLCAddressClick =>
            {
                var pd = TypeDescriptor.GetProperties(_HMIMotor)["PLCAddressClick"];
                pd.SetValue(_HMIMotor, PLCAddressClick);
            };
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }
    }

}