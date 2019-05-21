
using AdvancedScada;
using AdvancedScada;
using AdvancedScada.Controls;
using AdvancedScada.Controls;
using AdvancedScada.Controls.ClassBase;
using AdvancedScada.Controls.ClassBase;
using AdvancedScada.Controls.DialogEditor;
using AdvancedScada.Controls.Licenses;
using AdvancedScada.Controls.Motor;
using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Client;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvancedScada.Controls.ButtonAll
{
    public class HMIBeveledButtonDisplay : ClassBase.ButtonBase
    {

        private string m_Text2;

        private Color m_BorderColor;

        private Color m_BackColorOn;

        private int m_BorderWidth;

        private bool m_BeepOnClick;

        private OutputType m_OutputType;

        public Color BackcolorOn
        {
            get
            {
                return this.m_BackColorOn;
            }
            set
            {
                this.m_BackColorOn = value;
                this.CreateStaticImage();
            }
        }

        public bool BeepOnClick
        {
            get
            {
                return this.m_BeepOnClick;
            }
            set
            {
                this.m_BeepOnClick = value;
            }
        }

        public Color BorderColor
        {
            get
            {
                return this.m_BorderColor;
            }
            set
            {
                this.m_BorderColor = value;
                this.CreateStaticImage();
                this.OnBorderColorChanged(EventArgs.Empty);
            }
        }

        public int BorderWidth
        {
            get
            {
                return this.m_BorderWidth;
            }
            set
            {
                if (this.m_BorderWidth != value)
                {
                    this.m_BorderWidth = Math.Min(Math.Max(2, value), 10);
                    this.CreateStaticImage();
                    this.OnBorderWidthChanged(EventArgs.Empty);
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

        public string Text2
        {
            get
            {
                return this.m_Text2;
            }
            set
            {
                if (Operators.CompareString(this.m_Text2, value, false) != 0)
                {
                    this.m_Text2 = value;
                    this.Invalidate();
                    this.OnValueChanged(EventArgs.Empty);
                }
            }
        }



        public HMIBeveledButtonDisplay() : base()
        {

            this.m_BackColorOn = Color.Black;
            this.m_BeepOnClick = true;
            this.m_OutputType = OutputType.MomentarySet;
            this.m_BorderColor = Color.DimGray;
            base.BackColor = Color.LightGray;
            this.m_BorderWidth = 7;
            this.CreateStaticImage();
        }



        public static void Draw3DBorder(Control c, Graphics g, System.Drawing.Color color, int width)
        {
            System.Drawing.Point[] point =
            {
                    new System.Drawing.Point(0, 0),
                    new System.Drawing.Point(0, c.Height),
                    new System.Drawing.Point(width, c.Height - width),
                    new System.Drawing.Point(width, width),
                    new System.Drawing.Point(c.Width - width, width),
                    new System.Drawing.Point(c.Width, 0)
                };
            g.FillPolygon(new SolidBrush(HMIBeveledButtonDisplay.GetRelativeColor(color, 1.8)), point);
            g.DrawLine(new Pen(System.Drawing.Color.FromArgb(128, 32, 32, 32), 1.0F), point[0], point[3]);
            point[0].X = c.Width;
            point[0].Y = c.Height;
            point[3].X = c.Width - width;
            point[3].Y = c.Height - width;
            g.FillPolygon(new SolidBrush(HMIBeveledButtonDisplay.GetRelativeColor(color, 0.5)), point);
            g.DrawLine(new Pen(System.Drawing.Color.FromArgb(128, 120, 120, 120), 1.0F), point[0], point[3]);
            System.Drawing.Point point1 = new System.Drawing.Point(0, 0);
            System.Drawing.Point point2 = new System.Drawing.Point(c.Width, c.Height);
            System.Drawing.Drawing2D.LinearGradientBrush linearGradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(point1, point2, HMIBeveledButtonDisplay.GetRelativeColor(color, 1.2), HMIBeveledButtonDisplay.GetRelativeColor(color, 2.1));
            g.FillRectangle(linearGradientBrush, width, width, c.Width - width * 2, c.Height - width * 2);
        }

        public static System.Drawing.Color GetRelativeColor(System.Drawing.Color color, double intensity)
        {
            intensity = Math.Max(intensity, 0);
            System.Drawing.Color color1 = System.Drawing.Color.FromArgb(Convert.ToInt32(Math.Round(Math.Min((double)(color.R + 1) * intensity, 255))), Convert.ToInt32(Math.Round(Math.Min((double)(color.G + 1) * intensity, 255))), Convert.ToInt32(Math.Round(Math.Min((double)(color.B + 1) * intensity, 255))));
            return color1;
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            this.CreateStaticImage();
        }

        protected virtual void OnBorderColorChanged(EventArgs e)
        {
            if (BorderColorChanged != null)
                BorderColorChanged(this, e);
        }

        protected virtual void OnBorderWidthChanged(EventArgs e)
        {
            if (BorderWidthChanged != null)
                BorderWidthChanged(this, e);
        }





        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.OnImage != null)
            {
                this.sf.LineAlignment = StringAlignment.Center;
                this.sf.Alignment = StringAlignment.Center;
                if (!this.m_Value)
                {
                    e.Graphics.DrawImage(this.OffImage, 0, 0);
                    e.Graphics.DrawString(this.Text, this.Font, this.TextBrush, this.TextRectangle, this.sf);
                }
                else
                {
                    e.Graphics.DrawImage(this.OnImage, 0, 0);
                    e.Graphics.DrawString(this.m_Text2, this.Font, this.TextBrush, this.TextRectangle, this.sf);
                }
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (Operators.CompareString(this.m_Text2, string.Empty, false) == 0)
            {
                this.m_Text2 = this.Text;
            }
            base.OnTextChanged(e);
        }

        protected override void CreateStaticImage()
        {
            if (!(this.Width <= 0 || this.Height <= 0))
            {
                this.OnImage = new Bitmap(this.Width, this.Height);
                this.OffImage = new Bitmap(this.Width, this.Height);
                Graphics graphic = Graphics.FromImage(this.OnImage);
                Graphics graphic1 = Graphics.FromImage(this.OffImage);
                HMIBeveledButtonDisplay.Draw3DBorder(this, graphic, this.m_BorderColor, this.m_BorderWidth);
                HMIBeveledButtonDisplay.Draw3DBorder(this, graphic1, this.m_BorderColor, this.m_BorderWidth);
                int width = this.Width - this.m_BorderWidth * 4;
                if (width <= 0)
                {
                    width = 1;
                }
                int height = this.Height - this.m_BorderWidth * 4;
                if (height <= 0)
                {
                    height = 1;
                }
                System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(this.m_BorderWidth * 2, this.m_BorderWidth * 2, width, height);
                System.Drawing.Drawing2D.GraphicsPath graphicsPath = new System.Drawing.Drawing2D.GraphicsPath();
                graphicsPath.AddRectangle(rectangle);
                System.Drawing.Drawing2D.PathGradientBrush pathGradientBrush = new System.Drawing.Drawing2D.PathGradientBrush(graphicsPath);
                if (this.m_BackColorOn != Color.Black)
                {
                    pathGradientBrush.CenterColor = HMIBeveledButtonDisplay.GetRelativeColor(this.m_BackColorOn, 20);
                }
                else
                {
                    pathGradientBrush.CenterColor = HMIBeveledButtonDisplay.GetRelativeColor(this.BackColor, 20);
                }
                Color[] mBackColorOn = new Color[1];
                if (this.m_BackColorOn != Color.Black)
                {
                    mBackColorOn[0] = this.m_BackColorOn;
                }
                else
                {
                    mBackColorOn[0] = HMIBeveledButtonDisplay.GetRelativeColor(this.BackColor, 0.9);
                }
                pathGradientBrush.SurroundColors = mBackColorOn;
                graphic.FillRectangle(pathGradientBrush, rectangle);
                if (this.m_BackColorOn != Color.Black)
                {
                    graphic.DrawRectangle(new Pen(new SolidBrush(HMIBeveledButtonDisplay.GetRelativeColor(this.m_BackColorOn, 0.75)), 2.0F), rectangle);
                }
                else
                {
                    graphic.DrawRectangle(new Pen(new SolidBrush(HMIBeveledButtonDisplay.GetRelativeColor(this.m_BorderColor, 0.5)), 2.0F), rectangle);
                }
                graphic1.FillRectangle(new SolidBrush(this.BackColor), rectangle);
                graphic1.DrawRectangle(new Pen(new SolidBrush(HMIBeveledButtonDisplay.GetRelativeColor(this.m_BorderColor, 0.5)), 2.0F), rectangle);
                this.TextRectangle = new System.Drawing.Rectangle(this.m_BorderWidth * 2 + 1, this.m_BorderWidth * 2 + 1, this.Width - (this.m_BorderWidth * 4 + 2), this.Height - (this.m_BorderWidth * 4 + 2));
                byte r = this.ForeColor.R;
                byte g = this.ForeColor.G;
                Color foreColor = this.ForeColor;
                this.TextBrush = new SolidBrush(Color.FromArgb(216, (int)r, (int)g, (int)foreColor.B));
                this.Invalidate();
            }
        }

        public event EventHandler BorderColorChanged;

        public event EventHandler BorderWidthChanged;

        //***************************************
        //* Call backs for returned data
        //***************************************
        private string OriginalText;

        #region PLC Related Properties

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
        private string m_PLCAddressClick = string.Empty;

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

        #endregion

        #region Event

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

        private readonly bool MouseIsDown = false;

        public bool HoldTimeMet;

        //*****************************************
        //* Property - Hold time before bit reset
        //*****************************************
        private readonly Timer MinHoldTimer = new Timer();
        private int m_MinimumHoldTime = 500;

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
        private readonly Timer MaxHoldTimer = new Timer();
        private int m_MaximumHoldTime = 3000;

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

        [Category("PLC Properties")]
        public int ValueToWrite { get; set; }

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
            Console.Beep();

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