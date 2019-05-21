

using AdvancedScada;
using AdvancedScada.Controls;
using AdvancedScada.Controls.ClassBase;
using AdvancedScada.Controls.DialogEditor;
using AdvancedScada.Controls.Keyboard;
using AdvancedScada.Controls.Licenses;
using AdvancedScada.DriverBase;

using AdvancedScada.DriverBase.Client;
using AdvancedScada.Monitor;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Drawing;

using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Linear
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(HMILinearMeter), "HMI7Segment.ico")]
    [Designer(typeof(HMILinearMeterDesigner))]
    public class HMILinearMeter : AnalogMeterBase
    {
        private StringFormat sfCenter;

        private StringFormat sfCenterTop;

        private float VerticalScaledValue;

        private float HorizontalScaledValue;

        private FlatStyle m_FlatStyle;

        private HatchBrush m_BarContentColor;

        private Pen m_BorderPen;

        private FillDirectionEnum m_FillDirection;

        private int m_MajorTicks;

        public Color BarContentColor
        {
            get
            {
                return this.m_BarContentColor.BackgroundColor;
            }
            set
            {
                this.m_BarContentColor = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(240, Math.Max(value.R - 40, 0), Math.Max(value.G - 40, 0), Math.Max(value.B - 40, 0)), value);
                this.Invalidate();
            }
        }

        public Color BorderColor
        {
            get
            {
                return this.m_BorderPen.Color;
            }
            set
            {
                if (this.m_BorderPen != null)
                {
                    this.m_BorderPen.Color = value;
                }
                else
                {
                    this.m_BorderPen = new Pen(value, 1.0F);
                }
                this.Invalidate();
            }
        }

        public FillDirectionEnum FillDirection
        {
            get
            {
                return this.m_FillDirection;
            }
            set
            {
                if (value != this.m_FillDirection)
                {
                    this.m_FillDirection = value;
                    this.Invalidate();
                }
            }
        }

        public FlatStyle FlatStyle
        {
            get
            {
                return this.m_FlatStyle;
            }
            set
            {
                this.m_FlatStyle = value;
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
                this.CreateStaticImage();
                this.Invalidate();
            }
        }

        public int MajorTicks
        {
            get
            {
                return this.m_MajorTicks;
            }
            set
            {
                if (value != this.m_MajorTicks)
                {
                    if (value >= 0)
                    {
                        this.m_MajorTicks = value;
                    }
                    else
                    {
                        this.m_MajorTicks = 0;
                    }
                    this.CreateStaticImage();
                    this.Invalidate();
                }
            }
        }

        public HMILinearMeter()
        {
            this.sfCenter = new StringFormat();
            this.sfCenterTop = new StringFormat();
            this.m_BarContentColor = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.Red, Color.DarkOrange);
            this.m_BorderPen = new Pen(Color.Wheat, 1.0F);
            this.m_FillDirection = FillDirectionEnum.Up;
            this.ForeColor = Color.WhiteSmoke;
            this.sfCenter = new StringFormat();
            this.sfCenterTop = new StringFormat();
            this.CreateStaticImage();
        }

        private void CalculateScaledValue()
        {
            float mMaximum = (float)(1 / (this.m_Maximum - this.m_Minimum) * (this.m_Value - this.m_Minimum));
            //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            //ORIGINAL LINE: this.VerticalScaledValue = (float)(checked(this.Height - 2)) * mMaximum;
            this.VerticalScaledValue = (float)(this.Height - 2) * mMaximum;
            //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            //ORIGINAL LINE: this.HorizontalScaledValue = (float)(checked(this.Width - 2)) * mMaximum;
            this.HorizontalScaledValue = (float)(this.Width - 2) * mMaximum;
        }

        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    this.BackBuffer.Dispose();
                    this.m_BarContentColor.Dispose();
                    this.sfCenterTop.Dispose();
                    this.sfCenter.Dispose();
                    this.TextBrush.Dispose();
                    this.m_BorderPen.Dispose();
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
            if (!(this.BackBuffer == null || this.TextBrush == null || this.m_BorderPen == null))
            {
                Graphics graphic = Graphics.FromImage(this.BackBuffer);
                graphic.FillRectangle(new SolidBrush(base.BackColor), 0, 0, this.Width, this.Height);
                //INSTANT VB NOTE: The variable width was renamed since Visual Basic does not handle local variables named the same as class members well:
                int width_Renamed = this.Width;
                if (this.m_BarContentColor != null)
                {
                    switch (this.m_FillDirection)
                    {
                        case FillDirectionEnum.Down:
                            //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                            //ORIGINAL LINE: graphic.FillRectangle(this.m_BarContentColor, 0, checked(Convert.ToInt32(this.VerticalScaledValue) - 1), width, 2);
                            graphic.FillRectangle(this.m_BarContentColor, 0, Convert.ToInt32(this.VerticalScaledValue) - 1, width_Renamed, 2);
                            if (this.VerticalScaledValue + (float)base.FontHeight < (float)this.Height)
                            {
                                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                                //ORIGINAL LINE: this.TextRectangle.Y = checked((int)Math.Round((double)((float)(this.VerticalScaledValue - (float)base.FontHeight - 2f))));
                                this.TextRectangle.Y = Convert.ToInt32(Math.Truncate(Math.Round((double)(this.VerticalScaledValue - (float)base.FontHeight - 2.0F))));
                                graphic.DrawString(Conversions.ToString(this.m_Value), base.Font, this.TextBrush, this.TextRectangle, this.sfCenterTop);
                            }
                            break;
                        case FillDirectionEnum.Left:
                            //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                            //ORIGINAL LINE: graphic.FillRectangle(this.m_BarContentColor, checked(this.Width - Convert.ToInt32(this.HorizontalScaledValue)), 0, Convert.ToInt32(this.HorizontalScaledValue), this.Height);
                            graphic.FillRectangle(this.m_BarContentColor, this.Width - Convert.ToInt32(this.HorizontalScaledValue), 0, Convert.ToInt32(this.HorizontalScaledValue), this.Height);
                            break;
                        case FillDirectionEnum.Right:
                            graphic.FillRectangle(this.m_BarContentColor, 0, 0, Convert.ToInt32(this.HorizontalScaledValue), this.Height);
                            break;
                        default:
                            //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                            //ORIGINAL LINE: graphic.FillRectangle(this.m_BarContentColor, Convert.ToInt32((double)this.Width / 3), checked(checked(this.Height - Convert.ToInt32(this.VerticalScaledValue)) - 1), width, 2);
                            graphic.FillRectangle(this.m_BarContentColor, Convert.ToInt32((double)this.Width / 3), (this.Height - Convert.ToInt32(this.VerticalScaledValue)) - 1, width_Renamed, 2);
                            if ((float)this.Height - this.VerticalScaledValue + (float)base.FontHeight < (float)this.Height)
                            {
                                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                                //ORIGINAL LINE: this.TextRectangle.Y = checked((int)Math.Round((double)((float)((float)this.Height - this.VerticalScaledValue))));
                                this.TextRectangle.Y = Convert.ToInt32(Math.Truncate(Math.Round((double)((float)this.Height - this.VerticalScaledValue))));
                                graphic.DrawString(Conversions.ToString(this.m_Value), base.Font, this.TextBrush, this.TextRectangle, this.sfCenterTop);
                            }
                            break;
                    }
                }
                if (this.m_MajorTicks != 0)
                {
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: graphic.DrawRectangle(this.m_BorderPen, Convert.ToInt32((double)this.Width / 3), 0, checked(width - 1), checked(this.Height - 1));
                    graphic.DrawRectangle(this.m_BorderPen, Convert.ToInt32((double)this.Width / 3), 0, width_Renamed - 1, this.Height - 1);
                    if (this.m_MajorTicks <= 1)
                    {
                        //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        //ORIGINAL LINE: graphic.FillRectangle(Brushes.Wheat, 0, Convert.ToInt32((double)this.Height / 2), checked(Convert.ToInt32((double)this.Width / 3) - 2), 2);
                        graphic.FillRectangle(Brushes.Wheat, 0, Convert.ToInt32((double)this.Height / 2), Convert.ToInt32((double)this.Width / 3) - 2, 2);
                    }
                    else
                    {
                        //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        //ORIGINAL LINE: int num = checked((int)Math.Round((double)(checked(this.Height - 2)) / (double)(checked(this.m_MajorTicks - 1))));
                        int num = Convert.ToInt32(Math.Truncate(Math.Round((double)(this.Height - 2) / (double)(this.m_MajorTicks - 1))));
                        //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        //ORIGINAL LINE: int mMajorTicks = checked(this.m_MajorTicks - 1);
                        int mMajorTicks = this.m_MajorTicks - 1;
                        for (int i = 0; i <= mMajorTicks; i++)
                        {
                            //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                            //ORIGINAL LINE: graphic.FillRectangle(Brushes.Wheat, 0, checked(i * num), checked(Convert.ToInt32((double)this.Width / 3) - 2), 2);
                            graphic.FillRectangle(Brushes.Wheat, 0, i * num, Convert.ToInt32((double)this.Width / 3) - 2, 2);
                        }
                    }
                }
                else
                {
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: graphic.DrawRectangle(this.m_BorderPen, 0, 0, checked(this.Width - 1), checked(this.Height - 1));
                    graphic.DrawRectangle(this.m_BorderPen, 0, 0, this.Width - 1, this.Height - 1);
                }
                e.Graphics.DrawImage(this.BackBuffer, 0, 0);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.CalculateScaledValue();
            this.CreateStaticImage();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (this.Parent != null)
            {
                this.Parent.Invalidate();
            }
        }

        protected override void OnValueChanged(EventArgs e)
        {
            base.OnValueChanged(e);
            this.CalculateScaledValue();
            this.Invalidate();
        }

        protected override void CreateStaticImage()
        {
            this.TextRectangle.X = 1;
            this.TextRectangle.Y = 1;
            //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            //ORIGINAL LINE: this.TextRectangle.Width = checked(this.Width - 2);
            this.TextRectangle.Width = this.Width - 2;
            if (this.m_MajorTicks > 0)
            {
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.TextRectangle.Width = Convert.ToInt32((double)(checked(this.Width * 2)) / 3);
                this.TextRectangle.Width = Convert.ToInt32((double)(this.Width * 2) / 3);
                this.TextRectangle.X = Convert.ToInt32((double)this.Width / 3);
            }
            //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            //ORIGINAL LINE: this.TextRectangle.Height = checked(base.FontHeight + 4);
            this.TextRectangle.Height = base.FontHeight + 4;
            if (this.sfCenterTop == null)
            {
                this.sfCenterTop = new StringFormat();
            }
            this.sfCenterTop.Alignment = StringAlignment.Center;
            this.sfCenterTop.LineAlignment = StringAlignment.Near;
            this.TextBrush = new SolidBrush(base.ForeColor);
            if (this.BackBuffer != null)
            {
                this.BackBuffer.Dispose();
            }
            if (this.Width > 0 && this.Height > 0)
            {
                this.BackBuffer = new Bitmap(this.Width, this.Height);
            }
            this.Invalidate();
        }

        public enum FillDirectionEnum
        {
            Up,
            Down,
            Left,
            Right
        }
        private string OriginalText;

        #region propartas

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

        [DefaultValue(false)]
        public bool SuppressErrorDisplay { get; set; }

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

        #region "Keypad popup for data entry"

        private Keypad_v3 KeypadPopUp;

        //*****************************************
        //* Property - Address in PLC to Write Data To
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

        public string KeypadText { get; set; }

        private Color m_KeypadFontColor = Color.WhiteSmoke;

        public Color KeypadFontColor
        {
            get { return m_KeypadFontColor; }
            set { m_KeypadFontColor = value; }
        }

        private int m_KeypadWidth = 300;

        public int KeypadWidth
        {
            get { return m_KeypadWidth; }
            set { m_KeypadWidth = value; }
        }

        private double m_KeypadScaleFactor = 1;

        public double KeypadScaleFactor
        {
            get { return m_KeypadScaleFactor; }
            set { m_KeypadScaleFactor = value; }
        }

        public double KeypadMinValue { get; set; }

        public double KeypadMaxValue { get; set; }


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
                        if ((KeypadScaleFactor == 1) | (KeypadScaleFactor == 0))
                            WCFChannelFactory.Write(m_PLCAddressKeypad, KeypadPopUp.Value);
                        else
                            WCFChannelFactory.Write(m_PLCAddressKeypad,
                                (Convert.ToDouble(KeypadPopUp.Value) / m_KeypadScaleFactor).ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to write value. " + ex.Message);
                    }
                }

                KeypadPopUp.Visible = false;
            }
        }

        //***********************************************************
        //* If labeled is clicked, pop up a keypad for data entry
        //***********************************************************
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            if (m_PLCAddressKeypad != null && (string.Compare(m_PLCAddressKeypad, string.Empty) != 0) & Enabled)
            {
                if (KeypadPopUp == null)
                {
                    KeypadPopUp = new Keypad_v3(m_KeypadWidth);
                    KeypadPopUp.ButtonClick += KeypadPopUp_ButtonClick;
                }

                KeypadPopUp.Text = KeypadText;
                KeypadPopUp.ForeColor = m_KeypadFontColor;
                KeypadPopUp.Value = string.Empty;
                KeypadPopUp.StartPosition = FormStartPosition.CenterScreen;
                KeypadPopUp.TopMost = true;
                KeypadPopUp.Show();
            }
        }

        #endregion
    }

    internal class HMILinearMeterDesigner : ControlDesigner
    {
        private DesignerActionListCollection actionLists;

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionLists == null)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new HMILinearMeterListItem(this));
                }

                return actionLists;
            }
        }
    }

    internal class HMILinearMeterListItem : DesignerActionList
    {
        private readonly HMILinearMeter _HMILinearMeter;

        public HMILinearMeterListItem(HMILinearMeterDesigner owner)
            : base(owner.Component)
        {
            _HMILinearMeter = (HMILinearMeter)owner.Component;
        }


        public string TagName
        {
            get { return _HMILinearMeter.PLCAddressValue; }
            set { _HMILinearMeter.PLCAddressValue = value; }
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();
            items.Add(new DesignerActionTextItem("HMI Professional Edition", "HMI Professional Edition"));
            items.Add(new DesignerActionMethodItem(this, "ShowTagDesignerForm", "Choote Tag"));
            items.Add(new DesignerActionPropertyItem("TagName", "TagName"));

            return items;
        }

        public void ShowTagDesignerForm()
        {
            var frm = new MonitorForm(TagName);
            frm.OnTagSelected_Clicked += tagName => { SetProperty(_HMILinearMeter, "TagName", tagName); };
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        public void SetProperty(Control control, string propertyName, object value)
        {
            var pd = TypeDescriptor.GetProperties(control)[propertyName];
            pd.SetValue(control, value);
        }
    }


}