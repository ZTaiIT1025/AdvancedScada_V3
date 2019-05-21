using AdvancedScada.Controls.DialogEditor;
using AdvancedScada.Controls.Keyboard;
using AdvancedScada.Controls.Licenses;
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

namespace AdvancedScada.Controls.Display
{
    [Designer(typeof(HMITextBoxDesigner))]
    public class HMITextBox : System.Windows.Forms.TextBox
    {
        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string m_PLCAddressHighlight = string.Empty;

        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string m_PLCAddressValue = string.Empty;

        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string m_PLCAddressVisible = string.Empty;

        private string OriginalText;

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

        public int PollRate { get; set; }

        [DefaultValue(false)] public bool SuppressErrorDisplay { get; set; }

        [DefaultValue("")]
        [Category("PLC Properties")]
        public string PLCAddressHighlight
        {
            get { return m_PLCAddressHighlight; }
            set
            {
                if (m_PLCAddressHighlight != value) m_PLCAddressHighlight = value;
            }
        }

        public event EventHandler ValueChanged;

        #region "Private Methods"

        private void UpdateText()
        {
            //* Build the string with a temporary variable because Mybase.Text will keep firing Me.Invalidate
            var ResultText = m_Value;

            if (!string.IsNullOrEmpty(ResultText))
            {
                //* True/False comes from driver, change if BooleanDisplay is different 31-DEC-11
                if (string.Compare(m_Value, "True", true) == 0)
                {
                    if (m_BooleanDisplay == BooleanDisplayOption.OnOff)
                        ResultText = "On";
                    if (m_BooleanDisplay == BooleanDisplayOption.YesNo)
                        ResultText = "Yes";
                    if (m_BooleanDisplay == BooleanDisplayOption.TrueFalse)
                        ResultText = "True";
                    if (m_BooleanDisplay == BooleanDisplayOption.OneZero)
                        ResultText = "1";
                }
                else if (string.Compare(m_Value, "False", true) == 0)
                {
                    if (m_BooleanDisplay == BooleanDisplayOption.OnOff)
                        ResultText = "Off";
                    if (m_BooleanDisplay == BooleanDisplayOption.YesNo)
                        ResultText = "No";
                    if (m_BooleanDisplay == BooleanDisplayOption.TrueFalse)
                        ResultText = "False";
                    if (m_BooleanDisplay == BooleanDisplayOption.OneZero)
                        ResultText = "0";
                }
                else
                {
                    //* V3.99v
                    if (InterpretValueAsBCD)
                        try
                        {
                            var b = BitConverter.GetBytes(Convert.ToInt32(ResultText));
                            ResultText = string.Empty;

                            for (var index = 3; index >= 0; index += -1)
                            {
                                if (((b[index] & 240) > 0) | (ResultText.Length > 0))
                                    ResultText += Convert.ToString((b[index] & 240) >> 4);
                                if (((b[index] & 15) > 0) | (ResultText.Length > 0))
                                    ResultText += Convert.ToString(b[index] & 15);
                            }
                        }
                        catch
                        {
                            ResultText = "BCD Error";
                        }

                    //******************************************************
                    //* Scale Factor and Format only applied to non-Boolean
                    //******************************************************
                    //* Apply the scale factor
                    try
                    {
                        if (m_ValueScaleFactor != 1)
                            ResultText = (Convert.ToDouble(ResultText) * m_ValueScaleFactor).ToString();
                    }
                    catch (Exception ex)
                    {
                        if (!DesignMode)
                            DisplayError("Scale Factor Error - " + ex.Message);
                    }

                    //* Apply the format
                    if (!string.IsNullOrEmpty(m_NumericFormat) & !m_DisplayAsTime)
                        try
                        {
                            //* 31-MAY-13, 17-JUN-15 Changed from Single to Double to prevent rounding problems
                            double v = 0;
                            if (double.TryParse(ResultText, out v)) ResultText = v.ToString(m_NumericFormat);
                        }
                        catch (InvalidCastException)
                        {
                            if (!DesignMode)
                                ResultText = "----";
                            else
                                ResultText = Value;
                        }
                        catch (Exception)
                        {
                            if (!DesignMode) ResultText = "Check NumericFormat and variable type";
                        }

                    if (m_DisplayAsTime)
                        try
                        {
                            if (!string.IsNullOrEmpty(Value))
                            {
                                double ScaledValue = 0;
                                ScaledValue = Convert.ToDouble(Value) * m_ValueScaleFactor;
                                var remainder = 0;
                                ResultText = Math.DivRem(Convert.ToInt32(ScaledValue), 3600, out remainder) + ":" +
                                             Math.DivRem(remainder, 60, out remainder).ToString("00") + ":" +
                                             remainder.ToString("00");
                            }
                        }
                        catch (Exception ex)
                        {
                            if (!DesignMode)
                                base.Text = ex.Message;
                            return;
                        }
                }

                if (ValueToSubtractFrom != 0)
                    try
                    {
                        ResultText = (ValueToSubtractFrom - Convert.ToSingle(ResultText)).ToString();
                    }
                    catch (Exception)
                    {
                    }

                //* Apply the left padding
                if (m_ValueLeftPadLength > 0)
                    ResultText = ResultText.PadLeft(m_ValueLeftPadLength, m_ValueLeftPadCharacter);
            }
            else
            {
                ResultText = string.Empty;
            }

            //* Highlight in red if a Highlightcharacter found mark is in text
            if ((Value.IndexOf(_HighlightKeyChar) >= 0) | m_Highlight)
            {
                base.BackColor = m_Highlightcolor;
                base.ForeColor = m_HighlightForecolor;
            }
            else
            {
                base.BackColor = m_BackColor;
                base.ForeColor = m_ForeColor;
            }

            //* Apply the Prefix and Suffix
            if (!string.IsNullOrEmpty(m_Prefix)) ResultText = m_Prefix + ResultText;
            if (!string.IsNullOrEmpty(m_Suffix)) ResultText += m_Suffix;

            base.Text = ResultText;
        }

        #endregion

        #region Events

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
        }

        protected virtual void OnvalueChanged(EventArgs e)
        {
            if (ValueChanged != null) ValueChanged(this, e);
        }

        #endregion

        #region "Basic Properties"

        //* Remove Text from the property window so users do not attempt to use it
        [Browsable(false)]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        //******************************************************************************************
        //* Use the base control's text property and make it visible as a property on the designer
        //******************************************************************************************
        private string m_Value;

        public string Value
        {
            get { return m_Value; }
            set
            {
                if (value != m_Value)
                {
                    if (value != null)
                    {
                        m_Value = value;
                        UpdateText();
                        OnvalueChanged(EventArgs.Empty);
                    }
                    else
                    {
                        //* version 3.99f
                        if (!string.IsNullOrEmpty(m_Value))
                            OnvalueChanged(EventArgs.Empty);
                        m_Value = string.Empty;
                        base.Text = string.Empty;
                    }

                    //* Be sure error handler doesn't revert back to an incorrect text
                    OriginalText = base.Text;
                }
            }
        }

        private char m_ValueLeftPadCharacter = ' ';

        public char ValueLeftPadCharacter
        {
            get { return m_ValueLeftPadCharacter; }
            set
            {
                m_ValueLeftPadCharacter = value;
                UpdateText();
            }
        }

        private int m_ValueLeftPadLength;

        public int ValueLeftPadLength
        {
            get { return m_ValueLeftPadLength; }
            set
            {
                m_ValueLeftPadLength = value;
                UpdateText();
            }
        }

        //**********************************
        //* Prefix and suffixes to text
        //**********************************
        private string m_Prefix;

        public string ValuePrefix
        {
            get { return m_Prefix; }
            set
            {
                if (m_Prefix != value)
                {
                    m_Prefix = value;
                    UpdateText();
                }
            }
        }

        private string m_Suffix;

        public string ValueSuffix
        {
            get { return m_Suffix; }
            set
            {
                if (m_Suffix != value)
                {
                    m_Suffix = value;
                    UpdateText();
                }
            }
        }

        public float ValueToSubtractFrom { get; set; }

        public bool InterpretValueAsBCD { get; set; }

        private Color m_BackColor = Color.Black;

        public new Color BackColor
        {
            get { return m_BackColor; }
            set
            {
                if (m_BackColor != value)
                {
                    m_BackColor = value;
                    UpdateText();
                }
            }
        }

        //***************************************************************
        //* Property - Highlight Color
        //***************************************************************
        private Color m_Highlightcolor = Color.Red;

        [Category("Appearance")]
        public Color HighlightColor
        {
            get { return m_Highlightcolor; }
            set
            {
                if (m_Highlightcolor != value)
                {
                    m_Highlightcolor = value;
                    UpdateText();
                }
            }
        }

        private Color m_HighlightForecolor = Color.White;

        [Category("Appearance")]
        public Color HighlightForeColor
        {
            get { return m_HighlightForecolor; }
            set
            {
                if (m_HighlightForecolor != value)
                {
                    m_HighlightForecolor = value;
                    UpdateText();
                }
            }
        }

        private Color m_ForeColor = Color.White;

        public new Color ForeColor
        {
            get { return m_ForeColor; }
            set
            {
                if (m_ForeColor != value)
                {
                    m_ForeColor = value;
                    UpdateText();
                }
            }
        }

        private string _HighlightKeyChar = "!";

        [Category("Appearance")]
        public string HighlightKeyCharacter
        {
            get { return _HighlightKeyChar; }
            set
            {
                if (_HighlightKeyChar != value)
                {
                    _HighlightKeyChar = value;
                    UpdateText();
                }
            }
        }

        private bool m_Highlight;

        [Category("Appearance")]
        [Description("Switches to Highlight colors")]
        public bool Highlight
        {
            get { return m_Highlight; }
            set
            {
                if (m_Highlight != value)
                {
                    m_Highlight = value;
                    UpdateText();
                }
            }
        }

        private string m_NumericFormat;

        public string NumericFormat
        {
            get { return m_NumericFormat; }
            set
            {
                if (m_NumericFormat != value)
                {
                    m_NumericFormat = value;
                    UpdateText();
                }
            }
        }

        private double m_ValueScaleFactor = 1;

        public double ValueScaleFactor
        {
            get { return m_ValueScaleFactor; }
            set
            {
                if (m_ValueScaleFactor != value)
                {
                    m_ValueScaleFactor = value;
                    UpdateText();
                }
            }
        }

        public enum BooleanDisplayOption
        {
            TrueFalse,
            YesNo,
            OnOff,
            OneZero
        }

        private BooleanDisplayOption m_BooleanDisplay;

        public BooleanDisplayOption BooleanDisplay
        {
            get { return m_BooleanDisplay; }
            set
            {
                if (m_BooleanDisplay != value)
                {
                    m_BooleanDisplay = value;
                    UpdateText();
                }
            }
        }

        private bool m_DisplayAsTime;

        public bool DisplayAsTime
        {
            get { return m_DisplayAsTime; }
            set
            {
                if (m_DisplayAsTime != value)
                {
                    m_DisplayAsTime = value;
                    UpdateText();
                }
            }
        }

        #endregion


        #region "Error Display"

        //********************************************************
        //* Show an error via the text property for a short time
        //********************************************************
        private Timer ErrorDisplayTime;
        private readonly object ErrorLock = new object();

        private void DisplayError(string ErrorMessage)
        {
            if (!SuppressErrorDisplay)
            {
                //* Create the error display timer
                if (ErrorDisplayTime == null)
                {
                    ErrorDisplayTime = new Timer();
                    ErrorDisplayTime.Tick += ErrorDisplay_Tick;
                    ErrorDisplayTime.Interval = 5000;
                }

                //* Save the text to return to
                lock (ErrorLock)
                {
                    if (!ErrorDisplayTime.Enabled)
                    {
                        ErrorDisplayTime.Enabled = true;
                        OriginalText = base.Text;
                        base.Text = ErrorMessage;
                    }
                }
            }
        }


        //**************************************************************************************
        //* Return the text back to its original after displaying the error for a few seconds.
        //**************************************************************************************
        private void ErrorDisplay_Tick(object sender, EventArgs e)
        {
            //UpdateText()
            lock (ErrorLock)
            {
                base.Text = OriginalText;
                //If ErrorDisplayTime IsNot Nothing Then
                ErrorDisplayTime.Enabled = false;
                // ErrorIsDisplayed = False
            }

            //RemoveHandler ErrorDisplayTime.Tick, AddressOf ErrorDisplay_Tick
            //ErrorDisplayTime.Dispose()
            //ErrorDisplayTime = Nothing
            //End If
        }

        #endregion

        #region "Keypad popup for data entry"

        public string KeypadText { get; set; }

        private Font m_KeypadFont = new Font("Arial", 10);

        public Font KeypadFont
        {
            get { return m_KeypadFont; }
            set { m_KeypadFont = value; }
        }

        private Color m_KeypadForeColor = Color.WhiteSmoke;

        public Color KeypadFontColor
        {
            get { return m_KeypadForeColor; }
            set { m_KeypadForeColor = value; }
        }

        private int m_KeypadWidth = 400;

        public int KeypadWidth
        {
            get { return m_KeypadWidth; }
            set { m_KeypadWidth = value; }
        }

        //* 29-JAN-13

        public double KeypadMinValue { get; set; }

        public double KeypadMaxValue { get; set; }

        private double m_KeypadScaleFactor = 1;

        [DefaultValue(1)]
        public double KeypadScaleFactor
        {
            get { return m_KeypadScaleFactor; }
            set { m_KeypadScaleFactor = value; }
        }

        public bool KeypadAlphaNumeric { get; set; }

        public bool KeypadShowCurrentValue { get; set; }

        //*****************************************
        //* Property - Address in PLC to Write Data To
        //*****************************************
        private string m_PLCAddressKeypad = string.Empty;

        [Category("PLC Properties")]
        public string PLCAddressKeypad
        {
            get { return m_PLCAddressKeypad; }
            set
            {
                if (m_PLCAddressKeypad != value) m_PLCAddressKeypad = value;
            }
        }


        private IKeyboard KeypadPopUp;

        private void KeypadPopUp_ButtonClick(object sender, KeypadEventArgs e)
        {
            if (e.Key == "Quit")
            {
                KeypadPopUp.Visible = false;
            }
            else if (e.Key == "Enter")
            {
                if (KeypadPopUp.Value != null && string.Compare(KeypadPopUp.Value, string.Empty) != 0)
                {
                    //* 29-JAN-13 - Validate value if a Min/Max was specified
                    try
                    {
                        if (KeypadMaxValue != KeypadMinValue)
                            if ((Convert.ToDouble(KeypadPopUp.Value) < KeypadMinValue) |
                                (Convert.ToDouble(KeypadPopUp.Value) > KeypadMaxValue))
                            {
                                MessageBox.Show("Value must be >" + KeypadMinValue + " and <" + KeypadMaxValue);
                                return;
                            }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to validate value. " + ex.Message);
                        return;
                    }

                    try
                    {
                        //* 29-JAN-13 - reduced code and checked for divide by 0
                        if ((KeypadScaleFactor == 1) | (KeypadScaleFactor == 0))
                            WCFChannelFactory.Write(m_PLCAddressKeypad, KeypadPopUp.Value);
                        else
                            WCFChannelFactory.Write(m_PLCAddressKeypad,
                                (Convert.ToDouble(KeypadPopUp.Value) / m_KeypadScaleFactor).ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to write value - " + ex.Message);
                    }
                }

                KeypadPopUp.Visible = false;
            }
        }

        //***********************************************************
        //* If label is clicked, pop up a keypad for data entry.
        //* Limit this to the left-click of the mouse only.
        //***********************************************************
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            if (e.GetType() == typeof(MouseEventArgs))
            {
                var mea = (MouseEventArgs)e;
                if (mea.Button.ToString() == "Left")
                    if (m_PLCAddressKeypad != null && (string.Compare(m_PLCAddressKeypad, string.Empty) != 0) & Enabled)
                        ActivateKeypad();
            }
        }

        public void ActivateKeypad()
        {
            if (KeypadPopUp == null)
            {
                if (KeypadAlphaNumeric)
                    KeypadPopUp = new AlphaKeyboard3(m_KeypadWidth);
                else
                    KeypadPopUp = new Keypad_v3(m_KeypadWidth);
                KeypadPopUp.ButtonClick += KeypadPopUp_ButtonClick;
                KeypadPopUp.StartPosition = FormStartPosition.CenterScreen;
                KeypadPopUp.TopMost = true;
            }

            //***************************
            //*Set the font and forecolor
            //****************************
            if (m_KeypadFont != null)
                KeypadPopUp.Font = m_KeypadFont;
            KeypadPopUp.ForeColor = m_KeypadForeColor;

            KeypadPopUp.Text = KeypadText;
            if (KeypadShowCurrentValue)
                try
                {
                    var CurrentValue = Value;
                    //* v3.99p - added scaling
                    if (m_ValueScaleFactor == 1)
                        KeypadPopUp.Value = CurrentValue;
                    else
                        try
                        {
                            var ScaledValue = Convert.ToDouble(CurrentValue) * m_ValueScaleFactor;
                            KeypadPopUp.Value = ScaledValue.ToString();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Failed to Scale current value of " + CurrentValue);
                        }
                }
                catch (Exception)
                {
                    MessageBox.Show("Failed to read current value of " + m_PLCAddressKeypad);
                }
            else
                KeypadPopUp.Value = string.Empty;

            KeypadPopUp.Visible = true;
        }

        #endregion
    }

    [PermissionSet
        (SecurityAction.Demand, Name = "FullTrust")]
    internal class HMITextBoxDesigner : ControlDesigner
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
                    actionLists.Add(new INetTextBoxActionList(Component));
                }

                return actionLists;
            }
        }
    }

    internal class INetTextBoxActionList : DesignerActionList
    {
        private readonly HMITextBox _INetTextBox;

        private DesignerActionUIService designerActionUISvc;

        //The constructor associates the control with the smart tag list.
        public INetTextBoxActionList(IComponent component)
            : base(component)
        {
            _INetTextBox = component as HMITextBox;

            // Cache a reference to DesignerActionUIService, 
            // so the DesigneractionList can be refreshed.
            designerActionUISvc = GetService(typeof(DesignerActionUIService))
                as DesignerActionUIService;
        }


        public string PLCAddressValue
        {
            get { return _INetTextBox.PLCAddressValue; }
            set { _INetTextBox.PLCAddressValue = value; }
        }

        public Color BackColor
        {
            get { return _INetTextBox.BackColor; }
            set { _INetTextBox.BackColor = value; }
        }

        public Color ForeColor
        {
            get { return _INetTextBox.ForeColor; }
            set { _INetTextBox.ForeColor = value; }
        }

        public Font Font
        {
            get { return _INetTextBox.Font; }
            set { _INetTextBox.Font = value; }
        }

        public string Text
        {
            get { return _INetTextBox.Text; }
            set { _INetTextBox.Text = value; }
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
            var frm = new MonitorForm(PLCAddressValue);
            frm.OnTagSelected_Clicked += tagName =>
            {
                var pd = TypeDescriptor.GetProperties(_INetTextBox)["PLCAddressValue"];
                pd.SetValue(_INetTextBox, tagName);
            };
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }
    }
}