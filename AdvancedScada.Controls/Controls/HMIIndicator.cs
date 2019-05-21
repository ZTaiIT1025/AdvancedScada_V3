
using AdvancedScada;
using AdvancedScada.Controls;
using AdvancedScada.Controls.DialogEditor;
using AdvancedScada.Controls.Licenses;
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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Controls
{
    public class HMIIndicator : System.Windows.Forms.Control
    {
        private Bitmap StaticImage;

        private Rectangle TextRect;

        private float ImageRatio;

        private bool m_SelectColor2;

        private bool m_SelectColor3;

        private Color m_Color1;

        private SolidBrush BrushColor1;

        private Color m_Color2;

        private SolidBrush BrushColor2;

        private Color m_Color3;

        private SolidBrush BrushColor3;

        private Color _OutlineColor;

        private int m_OutlineWidth;

        private ShapeTypes m_Shape;

        private bool RefreshBackground;

        private StringFormat sf;

        private SolidBrush TextBrush;

        private SolidBrush BackgroundBrush;

        private Pen BorderPen;

        [Category("Appearance")]
        public Color Color1
        {
            get
            {
                return this.m_Color1;
            }
            set
            {
                if (this.m_Color1 != value)
                {
                    this.m_Color1 = value;
                    if (this.BrushColor1 != null)
                    {
                        this.BrushColor1.Color = value;
                    }
                    else
                    {
                        this.BrushColor1 = new SolidBrush(this.m_Color1);
                    }
                    this.Invalidate();
                }
            }
        }

        [Category("Appearance")]
        public Color Color2
        {
            get
            {
                return this.m_Color2;
            }
            set
            {
                if (this.m_Color2 != value)
                {
                    this.m_Color2 = value;
                    if (this.BrushColor2 != null)
                    {
                        this.BrushColor2.Color = value;
                    }
                    else
                    {
                        this.BrushColor2 = new SolidBrush(this.m_Color2);
                    }
                    this.Invalidate();
                }
            }
        }

        [Category("Appearance")]
        public Color Color3
        {
            get
            {
                return this.m_Color3;
            }
            set
            {
                if (this.m_Color3 != value)
                {
                    this.m_Color3 = value;
                    if (this.BrushColor3 != null)
                    {
                        this.BrushColor3.Color = value;
                    }
                    else
                    {
                        this.BrushColor3 = new SolidBrush(this.m_Color3);
                    }
                    this.Invalidate();
                }
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                //INSTANT VB NOTE: The local variable createParams was renamed since Visual Basic will not allow local variables with the same name as their enclosing function or property:
                CreateParams createParams_Renamed = base.CreateParams;
                createParams_Renamed.ExStyle |= 32;
                return createParams_Renamed;
            }
        }

        [Category("Appearance")]
        public Color OutlineColor
        {
            get
            {
                return this._OutlineColor;
            }
            set
            {
                this._OutlineColor = value;
                if (this.BorderPen != null)
                {
                    this.BorderPen.Color = value;
                }
                else
                {
                    this.BorderPen = new Pen(this._OutlineColor, (float)this.m_OutlineWidth);
                }
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        public int OutlineWidth
        {
            get
            {
                return this.m_OutlineWidth;
            }
            set
            {
                if (value != this.m_OutlineWidth)
                {
                    this.m_OutlineWidth = Math.Max(value, 1);
                    this.BorderPen = new Pen(this._OutlineColor, (float)this.m_OutlineWidth);
                    this.Invalidate();
                }
            }
        }

        [Category("Appearance")]
        public bool SelectColor2
        {
            get
            {
                return this.m_SelectColor2;
            }
            set
            {
                if (value != this.m_SelectColor2)
                {
                    this.m_SelectColor2 = value;
                    this.RefreshBackground = true;
                    this.Invalidate();
                    this.OnValueSelectColor1Changed(EventArgs.Empty);
                }
            }
        }

        [Category("Appearance")]
        public bool SelectColor3
        {
            get
            {
                return this.m_SelectColor3;
            }
            set
            {
                if (value != this.m_SelectColor3)
                {
                    this.m_SelectColor3 = value;
                    this.Invalidate();
                    this.OnValueSelectColor3Changed(EventArgs.Empty);
                }
            }
        }

        [Category("Appearance")]
        public ShapeTypes Shape
        {
            get
            {
                return this.m_Shape;
            }
            set
            {
                if (value != this.m_Shape)
                {
                    this.m_Shape = value;
                    this.RefreshBackground = true;
                    this.Invalidate();
                }
            }
        }



        public HMIIndicator()
        {

            this.TextRect = new Rectangle();
            this.m_Color1 = Color.DarkGray;
            this.m_Color2 = Color.Green;
            this.m_Color3 = Color.Red;
            this._OutlineColor = Color.Transparent;
            this.m_OutlineWidth = 1;
            this.m_Shape = ShapeTypes.Round;
            this.sf = new StringFormat();
        }


        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    this.BrushColor1.Dispose();
                    this.BrushColor2.Dispose();
                    this.BrushColor3.Dispose();
                    this.BorderPen.Dispose();
                    this.TextBrush.Dispose();
                    this.BackgroundBrush.Dispose();
                    this.sf.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            if (this.BackgroundBrush != null)
            {
                this.BackgroundBrush.Color = this.BackColor;
            }
            else
            {
                this.BackgroundBrush = new SolidBrush(this.BackColor);
            }
            this.Invalidate();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.sf.Alignment = StringAlignment.Center;
            this.sf.LineAlignment = StringAlignment.Center;
            if (this.DesignMode)
            {
                if ((this.Parent.BackColor == Color.Black) && (base.ForeColor == Color.FromKnownColor(KnownColor.ControlText)))
                {
                    this.ForeColor = Color.WhiteSmoke;
                }
            }
            if (this.TextBrush == null)
            {
                this.TextBrush = new SolidBrush(base.ForeColor);
            }
            if (this.BorderPen == null)
            {
                this.BorderPen = new Pen(this._OutlineColor);
            }
            if (this.BrushColor1 == null)
            {
                this.BrushColor1 = new SolidBrush(this.Color1);
            }
            if (this.BrushColor2 == null)
            {
                this.BrushColor2 = new SolidBrush(this.Color2);
            }
            if (this.BrushColor3 == null)
            {
                this.BrushColor3 = new SolidBrush(this.Color3);
            }
            if (this.BackgroundBrush == null)
            {
                this.BackgroundBrush = new SolidBrush(this.BackColor);
            }
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            if (this.TextBrush != null)
            {
                this.TextBrush.Color = base.ForeColor;
            }
            else
            {
                this.TextBrush = new SolidBrush(base.ForeColor);
            }
            if (this.BorderPen != null)
            {
                this.BorderPen.Color = this._OutlineColor;
            }
            else
            {
                this.BorderPen = new Pen(this._OutlineColor, (float)this.m_OutlineWidth);
            }
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!(this.TextBrush == null || this.BorderPen == null || this.BrushColor1 == null || this.BrushColor2 == null || this.BrushColor3 == null || this.BackgroundBrush == null))
            {
                Bitmap bitmap = new Bitmap(this.Width, this.Height);
                Graphics graphic = Graphics.FromImage(bitmap);
                graphic.FillRectangle(this.BackgroundBrush, 0, 0, this.Width, this.Height);
                if (this.m_Shape != ShapeTypes.Round)
                {
                    if (this.m_SelectColor2)
                    {
                        graphic.FillRectangle(this.BrushColor2, 0, 0, this.Width, this.Height);
                    }
                    else if (!this.m_SelectColor3)
                    {
                        graphic.FillRectangle(this.BrushColor1, 0, 0, this.Width, this.Height);
                    }
                    else
                    {
                        graphic.FillRectangle(this.BrushColor3, 0, 0, this.Width, this.Height);
                    }
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: graphic.DrawRectangle(this.BorderPen, 0, 0, checked(this.Width - 1), checked(this.Height - 1));
                    graphic.DrawRectangle(this.BorderPen, 0, 0, this.Width - 1, this.Height - 1);
                }
                else
                {
                    if (this.m_SelectColor2)
                    {
                        //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        //ORIGINAL LINE: graphic.FillEllipse(this.BrushColor2, 0, 0, checked(this.Width - 1), checked(this.Height - 1));
                        graphic.FillEllipse(this.BrushColor2, 0, 0, this.Width - 1, this.Height - 1);
                    }
                    else if (!this.m_SelectColor3)
                    {
                        //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        //ORIGINAL LINE: graphic.FillEllipse(this.BrushColor1, 0, 0, checked(this.Width - 1), checked(this.Height - 1));
                        graphic.FillEllipse(this.BrushColor1, 0, 0, this.Width - 1, this.Height - 1);
                    }
                    else
                    {
                        //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        //ORIGINAL LINE: graphic.FillEllipse(this.BrushColor3, 0, 0, checked(this.Width - 1), checked(this.Height - 1));
                        graphic.FillEllipse(this.BrushColor3, 0, 0, this.Width - 1, this.Height - 1);
                    }
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: graphic.DrawEllipse(this.BorderPen, checked((int)Math.Round(Math.Floor((double)this.m_OutlineWidth / 2))), checked((int)Math.Round(Math.Floor((double)this.m_OutlineWidth / 2))), checked(this.Width - this.m_OutlineWidth), checked(this.Height - this.m_OutlineWidth));
                    graphic.DrawEllipse(this.BorderPen, Convert.ToInt32(Math.Truncate(Math.Round(Math.Floor((double)this.m_OutlineWidth / 2)))), Convert.ToInt32(Math.Truncate(Math.Round(Math.Floor((double)this.m_OutlineWidth / 2)))), this.Width - this.m_OutlineWidth, this.Height - this.m_OutlineWidth);
                }
                if ((base.Text == null || string.Compare(base.Text, string.Empty) == 0) ? false : true)
                {
                    if (this.TextBrush.Color != base.ForeColor)
                    {
                        this.TextBrush.Color = base.ForeColor;
                    }
                    graphic.DrawString(base.Text, base.Font, this.TextBrush, (float)((double)this.Width / 2), (float)((double)this.Height / 2), this.sf);
                }
                e.Graphics.DrawImage(bitmap, 0, 0);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (this.RefreshBackground)
            {
                base.OnPaintBackground(e);
            }
            this.RefreshBackground = false;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Invalidate();
        }

        protected virtual void OnValueSelectColor1Changed(EventArgs e)
        {
            if (ValueSelectColor1Changed != null)
                ValueSelectColor1Changed(this, e);
        }

        protected virtual void OnValueSelectColor3Changed(EventArgs e)
        {
            if (ValueSelectColor3Changed != null)
                ValueSelectColor3Changed(this, e);
        }

        public event EventHandler ValueSelectColor1Changed;

        public event EventHandler ValueSelectColor3Changed;

        public enum ShapeTypes
        {
            Round,
            Rectangle
        }
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
    }


}