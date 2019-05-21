using AdvancedScada;
using AdvancedScada;
using AdvancedScada.Controls;
using AdvancedScada.Controls;
using AdvancedScada.Controls.DialogEditor;
using AdvancedScada.Controls.Keyboard;
using AdvancedScada.Controls.Licenses;
using AdvancedScada.Controls.Motor;
using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Client;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace AdvancedScada.Controls.ImageAll
{
    public class HMIImageDisplayByValue : Label
    {
        public HMIImageDisplayByValue()
        {

            this.AutoSize = false;
            if ((base.ForeColor == Color.FromKnownColor(KnownColor.ControlText)) || (this.ForeColor == Color.FromArgb(0, 0, 0, 0)))
            {
                this.ForeColor = Color.Black;
            }
        }



        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            int i = 0;
            int count = this.Parent.Site.Container.Components.Count;
            while (base.ImageList == null && i < count)
            {
                if (Operators.CompareString(((object)this.Parent.Site.Container.Components[i]).GetType().ToString(), "System.Windows.Forms.ImageList", false) == 0)
                {
                    this.ImageList = (ImageList)this.Parent.Site.Container.Components[i];
                }
                i += 1;
            }
            if (base.ImageList == null)
            {
                this.Parent.Site.Container.Add(new ImageList());
                base.ImageList = (ImageList)this.Parent.Site.Container.Components[this.Parent.Site.Container.Components.Count - 1];
            }
            base.ImageIndex = 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            try
            {
                if ((this.ImageList == null || this.ImageList.Images == null || this.ImageList.Images.Count <= 0 || this.ImageList.Images[0] == null) ? false : true)
                {
                    e.Graphics.DrawImage(this.ImageList.Images[0], 0, 0, this.Width, this.Height);
                }
            }
            catch
            {

            }
        }
        #region Basic Properties

        private Color SavedBackColor;

        //******************************************************************************************
        //* Use the base control's text property and make it visible as a property on the designer
        //******************************************************************************************
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get { return base.Text; }
            set
            {
                //* True/False comes from driver, change if BooleanDisplay is different 31-DEC-11
                if ((value == "True" || value == "False") && BooleanDisplay != BooleanDisplayOption.TrueFalse)
                {
                    if (value == "True")
                    {
                        if (BooleanDisplay == BooleanDisplayOption.OnOff) value = "On";
                        if (BooleanDisplay == BooleanDisplayOption.YesNo) value = "Yes";
                    }
                    else
                    {
                        if (BooleanDisplay == BooleanDisplayOption.OnOff) value = "Off";
                        if (BooleanDisplay == BooleanDisplayOption.YesNo) value = "No";
                    }
                }

                //* If suffix has already been added, then removed 17-OCT-11
                if (m_Suffix != null && string.Compare(m_Suffix, string.Empty) != 0 && value.IndexOf(m_Suffix) > 0)
                    value = value.Substring(0, value.IndexOf(m_Suffix));

                if (NumericFormat != null && string.Compare(NumericFormat, string.Empty) != 0 && !DesignMode)
                {
                    try
                    {
                        base.Text = _Prefix + (float.Parse(value) * (float)_ValueScaleFactor).ToString(NumericFormat) +
                                    m_Suffix;
                    }
                    catch
                    {
                        base.Text = value;
                    }
                }
                else
                {
                    //* Highlight in red if a Highlightcharacter found mark is in text
                    if (value.IndexOf(_HighlightKeyChar) >= 0)
                    {
                        if (BackColor != _Highlightcolor) SavedBackColor = BackColor;
                        BackColor = _Highlightcolor;
                    }
                    else
                    {
                        if (SavedBackColor != new Color()) BackColor = SavedBackColor;
                    }

                    if (_ValueScaleFactor == 1M)
                        base.Text = _Prefix + value + m_Suffix;
                    else
                        try
                        {
                            base.Text = (Convert.ToSingle(value) * (float)_ValueScaleFactor).ToString();
                        }
                        catch (Exception ex)
                        {
                            DisplayError("Scale Factor Error - " + ex.Message);
                        }
                }
            }
        }

        //**********************************
        //* Prefix and suffixes to text
        //**********************************
        private string _Prefix;

        public string TextPrefix
        {
            get { return _Prefix; }
            set
            {
                _Prefix = value;
                Invalidate();
            }
        }

        private string m_Suffix;

        public string TextSuffix
        {
            get { return m_Suffix; }
            set
            {
                m_Suffix = value;
                Invalidate();
            }
        }

        public int PollRate { get; set; }

        public string KeypadText { get; set; }

        private int m_KeypadWidth = 300;

        public int KeypadWidth
        {
            get { return m_KeypadWidth; }
            set { m_KeypadWidth = value; }
        }

        [DefaultValue(false)]
        public bool SuppressErrorDisplay { get; set; }

        //***************************************************************
        //* Property - Highlight Color
        //***************************************************************
        private Color _Highlightcolor = Color.Red;

        [Category("Appearance")]
        public Color HighlightColor
        {
            get { return _Highlightcolor; }
            set { _Highlightcolor = value; }
        }

        private string _HighlightKeyChar = "!";

        [Category("Appearance")]
        public string HighlightKeyCharacter
        {
            get { return _HighlightKeyChar; }
            set { _HighlightKeyChar = value; }
        }


        public string NumericFormat { get; set; }

        private decimal _ValueScaleFactor = 1M;

        public decimal ScaleFactor
        {
            get { return _ValueScaleFactor; }
            set { _ValueScaleFactor = value; }
        }

        public enum BooleanDisplayOption
        {
            TrueFalse,
            YesNo,
            OnOff
        }

        public BooleanDisplayOption BooleanDisplay { get; set; }

        #endregion

        #region PLC Related Properties

        private OutputType m_OutputType = OutputType.MomentarySet;

        public OutputType OutputType
        {
            get { return m_OutputType; }
            set { m_OutputType = value; }
        }

        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string m_PLCAddressText = string.Empty;

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

        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string m_PLCAddressKeypad = string.Empty;

        [Category("PLC Properties")]
        [Editor(typeof(TestDialogEditor), typeof(UITypeEditor))]
        public string PLCAddressKeypad
        {
            get { return m_PLCAddressKeypad; }
            set
            {
                if (m_PLCAddressKeypad != value) m_PLCAddressKeypad = value;
            }
        }


        //***************************************
        //* Call backs for returned data
        //***************************************
        private string OriginalText;

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

        #endregion

        #region Keypad popup for data entry

        private Keypad_v3 _KeypadPopUp;

        private Keypad_v3 KeypadPopUp
        {
            [DebuggerNonUserCode]
            get { return _KeypadPopUp; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            [DebuggerNonUserCode]
            set
            {
                if (_KeypadPopUp != null) _KeypadPopUp.ButtonClick -= KeypadPopUp_ButtonClick;

                _KeypadPopUp = value;

                if (value != null) _KeypadPopUp.ButtonClick += KeypadPopUp_ButtonClick;
            }
        }

        private void KeypadPopUp_ButtonClick(object sender, KeypadEventArgs e)
        {
            if (e.Key == "Quit")
                KeypadPopUp.Visible = false;
            else if (e.Key == "Enter")
                if (KeypadPopUp.Value != null && string.Compare(KeypadPopUp.Value, string.Empty) != 0)
                {
                    if (ScaleFactor == 1)
                        WCFChannelFactory.Write(m_PLCAddressKeypad, KeypadPopUp.Value);
                    else
                        WCFChannelFactory.Write(m_PLCAddressKeypad, KeypadPopUp.Value);

                    KeypadPopUp.Visible = false;
                }
        }

        //***********************************************************
        //* If labeled is clicked, pop up a keypad for data entry
        //***********************************************************
        private void BasicLabelWithEntry_Click(object sender, EventArgs e)
        {
            if (m_PLCAddressKeypad != null && (string.Compare(m_PLCAddressKeypad, string.Empty) != 0) & Enabled)
            {
                if (KeypadPopUp == null) KeypadPopUp = new Keypad_v3(m_KeypadWidth);

                KeypadPopUp.Text = KeypadText;
                KeypadPopUp.Value = string.Empty;
                KeypadPopUp.StartPosition = FormStartPosition.CenterScreen;
                KeypadPopUp.TopMost = true;
                KeypadPopUp.Show();
            }
        }

        #endregion
    }
}
