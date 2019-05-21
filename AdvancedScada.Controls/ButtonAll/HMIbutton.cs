using AdvancedScada;
using AdvancedScada;
using AdvancedScada.Controls;
using AdvancedScada.Controls;
using AdvancedScada.Controls.DialogEditor;
using AdvancedScada.Controls.Display;
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
using System.Security.Permissions;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace AdvancedScada.Controls.ButtonAll
{
    [Designer(typeof(HMIbuttonDesigner))]
    public class HMIbutton : System.Windows.Forms.Button
    {
        public HMIbutton()
        {
            MaxHoldTimer.Tick += MaxHoldTimer_Tick;
            MinHoldTimer.Tick += HoldTimer_Tick;
        }

        #region Property

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

        private OutputType m_OutputType = OutputType.MomentarySet;

        public OutputType OutputType
        {
            get { return m_OutputType; }
            set { m_OutputType = value; }
        }

        //******************************************************************************************
        //* Use the base control's text property and make it visible as a property on the designer
        //******************************************************************************************
        private dynamic m_Value;

        public dynamic Value
        {
            get { return m_Value; }
            set
            {
                if (value != m_Value)
                {
                    if (value != null)
                    {
                        m_Value = value;
                        SetLabel.SetLabelText(this, m_Value);
                    }
                    else
                    {
                        m_Value = string.Empty;
                        base.Text = string.Empty;
                    }
                }
            }
        }

        private void ReleaseValue()
        {
            try
            {
                if (m_OutputType == OutputType.MomentarySet)
                    WCFChannelFactory.Write(PLCAddressClick, "0");
                else if (m_OutputType == OutputType.MomentaryReset) WCFChannelFactory.Write(PLCAddressClick, "1");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool MouseIsDown;

        public bool HoldTimeMet;

        //*****************************************
        //* Property - Hold time before bit reset
        //*****************************************
        public readonly Timer MinHoldTimer = new Timer();
        public int m_MinimumHoldTime = 500;

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
        public readonly Timer MaxHoldTimer = new Timer();
        public int m_MaximumHoldTime = 3000;

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

        [Category("PLC Properties")] public int ValueToWrite { get; set; }

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
                        bool CurrentValue = Convert.ToBoolean(Value);
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
    }

    [PermissionSet
        (SecurityAction.Demand, Name = "FullTrust")]
    internal class HMIbuttonDesigner : ControlDesigner
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
                    actionLists.Add(new HMIbuttonActionList(Component));
                }

                return actionLists;
            }
        }
    }

    internal class HMIbuttonActionList : DesignerActionList
    {
        private readonly HMIbutton _HMIbutton;

        private DesignerActionUIService designerActionUISvc;

        //The constructor associates the control with the smart tag list.
        public HMIbuttonActionList(IComponent component)
            : base(component)
        {
            _HMIbutton = component as HMIbutton;

            // Cache a reference to DesignerActionUIService, 
            // so the DesigneractionList can be refreshed.
            designerActionUISvc = GetService(typeof(DesignerActionUIService))
                as DesignerActionUIService;
        }


        public string PLCAddressText
        {
            get { return _HMIbutton.PLCAddressText; }
            set { _HMIbutton.PLCAddressText = value; }
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
            items.Add(new DesignerActionPropertyItem("TagName", "TagName"));
            items.Add(new DesignerActionPropertyItem("Text", "Text"));
            return items;
        }

        private void ShowTagList()
        {
            var frm = new MonitorForm(PLCAddressText);
            frm.OnTagSelected_Clicked += tagName =>
            {
                var pd = TypeDescriptor.GetProperties(_HMIbutton)["TagName"];
                pd.SetValue(_HMIbutton, tagName);
            };
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }
    }
}