
using AdvancedScada;
using AdvancedScada;
using AdvancedScada.Controls;
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

//****************************************************************************
//* 12-DEC-08 Added line in OnPaint to exit is LegendText is nothing
//* 05-OCT-09 Exit OnPaint if GrayPen is Nothing
//****************************************************************************

namespace AdvancedScada.Controls.ImageAll
{
    public class HMIGraphicIndicator : Control
    {
        public event EventHandler ValueSelect1Changed;
        public event EventHandler ValueSelect2Changed;

        private Bitmap StaticImage;
        private Bitmap Image1;
        private Bitmap Image2;
        private Bitmap Image3;
        private Rectangle TextRect = new Rectangle();
        private float ImageRatio;

        #region Constructor
        public HMIGraphicIndicator() : base()
        {

            //'* reduce the flicker
            this.SetStyle(System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer | System.Windows.Forms.ControlStyles.AllPaintingInWmPaint | System.Windows.Forms.ControlStyles.UserPaint | System.Windows.Forms.ControlStyles.SupportsTransparentBackColor, true);

            ForeColor = Color.WhiteSmoke;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (sf2 != null)
            {
                sf2.Dispose();
            }
            if (sf != null)
            {
                sf.Dispose();
            }
            if (m_Font2 != null)
            {
                m_Font2.Dispose();
            }
            if (Image1 != null)
            {
                Image1.Dispose();
            }
            if (Image2 != null)
            {
                Image2.Dispose();
            }
            if (Image3 != null)
            {
                Image3.Dispose();
            }
            TextBrush.Dispose();
        }

        #endregion

        #region Properties
        private bool m_ValueSelect1;
        public bool ValueSelect1
        {
            get
            {
                return m_ValueSelect1;
            }
            set
            {
                if (value != m_ValueSelect1)
                {
                    m_ValueSelect1 = value;

                    //BackGroundNeedsRefreshed = True
                    this.Invalidate();

                    OnValueSelect1Changed(EventArgs.Empty);
                }
            }
        }

        private bool m_ValueSelect2;
        public bool ValueSelect2
        {
            get
            {
                return m_ValueSelect2;
            }
            set
            {
                if (value != m_ValueSelect2)
                {
                    m_ValueSelect2 = value;

                    //BackGroundNeedsRefreshed = True
                    this.Invalidate();

                    OnValueSelect2Changed(EventArgs.Empty);
                }
            }
        }

        //*****************************************
        //* Property - Image to Show when All is off
        //*****************************************
        //Private m_LightOnColor As Color = Color.Green
        private Bitmap m_GraphicAllOff;
        public Bitmap GraphicAllOff
        {
            get
            {
                return (m_GraphicAllOff);
            }
            set
            {
                if (m_GraphicAllOff != value)
                {
                    m_GraphicAllOff = value;
                    RefreshImages();
                    //Invalidate()
                }
            }
        }

        //*****************************************
        //* Property - Image to Show when
        //*****************************************
        //Private m_LightOnColor As Color = Color.Green
        private Bitmap m_GraphicSelect1;
        public Bitmap GraphicSelect1
        {
            get
            {
                return (m_GraphicSelect1);
            }
            set
            {
                m_GraphicSelect1 = value;
                RefreshImages();
                //Me.Invalidate()
            }
        }

        //*****************************************
        //* Property - Image to Show when
        //*****************************************
        //Private m_LightOnColor As Color = Color.Green
        private Bitmap m_GraphicSelect2;
        public Bitmap GraphicSelect2
        {
            get
            {
                return (m_GraphicSelect2);
            }
            set
            {
                m_GraphicSelect2 = value;
                RefreshImages();
                //Me.Invalidate()
            }
        }

        private System.Windows.Forms.Timer FlashTimer;
        private bool m_Flash1;
        public bool Flash1
        {
            get
            {
                return m_Flash1;
            }
            set
            {
                if (m_Flash1 != value)
                {
                    m_Flash1 = value;

                    if (m_Flash1)
                    {
                        if (FlashTimer == null)
                        {
                            FlashTimer = new System.Windows.Forms.Timer();
                            FlashTimer.Interval = 800;
                            FlashTimer.Tick += FlashTimerTick;
                            FlashTimer.Start();
                        }
                    }
                    else
                    {
                        if (FlashTimer != null)
                        {
                            FlashTimer.Stop();
                        }
                    }
                }
            }
        }

        private void FlashTimerTick(object sender, EventArgs e)
        {
            ValueSelect1 = !ValueSelect1;
        }

        private System.Windows.Forms.PictureBoxSizeMode m_SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        public System.Windows.Forms.PictureBoxSizeMode SizeMode
        {
            get
            {
                return m_SizeMode;
            }
            set
            {
                if (m_SizeMode != value)
                {
                    m_SizeMode = value;
                    RefreshImages();
                }
            }
        }

        public enum RotationAngleEnum
        {
            NoRotation,
            Rotate90,
            Rotate180,
            Rotate270
        }
        private RotationAngleEnum m_RotationAngle = RotationAngleEnum.NoRotation;
        public RotationAngleEnum RotationAngle
        {
            get
            {
                return m_RotationAngle;
            }
            set
            {
                if (m_RotationAngle != value)
                {
                    m_RotationAngle = value;
                    RefreshImages();
                }
            }
        }


        //    <System.ComponentModel.Browsable(True)> _
        //<System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        //Public Overrides Property Text() As String
        //        Get
        //            Return MyBase.Text
        //        End Get
        //        Set(ByVal value As String)
        //            MyBase.Text = value
        //        End Set
        //    End Property

        //    'Private m_font As New Font("Arial", 22, FontStyle.Regular, GraphicsUnit.Point)
        //    '* These next properties are overriden so that we can refresh the image when changed
        //    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        //    Public Overrides Property Font() As Font
        //        Get
        //            Return MyBase.Font
        //        End Get
        //        Set(ByVal value As Font)
        //            MyBase.Font = value
        //        End Set
        //    End Property


        //*****************************************
        //* Property - Second Text
        //*****************************************
        private string m_Text2 = string.Empty;
        public string Text2
        {
            get
            {
                return m_Text2;
            }
            set
            {
                if (m_Text2 != value)
                {
                    m_Text2 = value;
                    if (!string.IsNullOrEmpty(m_Format) && (!DesignMode))
                    {
                        try
                        {
                            m_Text2 = (float.Parse(value) * (float)m_ValueScaleFactor).ToString(m_Format);
                        }
                        catch (Exception ex)
                        {
                            m_Text2 = "Check NumericFormat and variable type";
                        }
                    }
                    this.Invalidate();
                }
            }
        }

        //*****************************************
        //* Property - Second Text
        //*****************************************
        private Font m_Font2 = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point);
        public Font Font2
        {
            get
            {
                return m_Font2;
            }
            set
            {
                m_Font2 = value;
                //RefreshImage()
                this.Invalidate();
            }
        }

        private string m_Format;
        public string NumericFormat
        {
            get
            {
                return m_Format;
            }
            set
            {
                m_Format = value;
            }
        }

        private decimal m_ValueScaleFactor = 1M;
        public decimal ValueScaleFactor
        {
            get
            {
                return m_ValueScaleFactor;
            }
            set
            {
                m_ValueScaleFactor = value;
            }
        }

        //*****************************************
        //* Property - What to do to bit in PLC
        //*****************************************
        public enum OutputTypes
        {
            MomentarySet,
            MomentaryReset,
            SetTrue,
            SetFalse,
            Toggle
        }
        private OutputTypes m_OutputType = OutputTypes.MomentarySet;
        public OutputTypes OutputType
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

        //'* This is necessary to make the background draw correctly
        //'*  http://www.bobpowell.net/transcontrols.htm
        //'*part of the transparent background code
        //Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        //    Get
        //        Dim cp As System.Windows.Forms.CreateParams = MyBase.CreateParams
        //        cp.ExStyle = cp.ExStyle Or 32
        //        Return cp
        //        Return MyBase.CreateParams
        //    End Get
        //End Property
        #endregion


        #region Events
        protected virtual void OnValueSelect1Changed(EventArgs e)
        {
            if (ValueSelect1Changed != null)
                ValueSelect1Changed(this, e);
        }

        protected virtual void OnValueSelect2Changed(EventArgs e)
        {
            if (ValueSelect2Changed != null)
                ValueSelect2Changed(this, e);
        }

        protected override void OnForeColorChanged(System.EventArgs e)
        {
            base.OnForeColorChanged(e);

            if (TextBrush == null)
            {
                //* V3.99f - would always revert to black
                TextBrush = new SolidBrush(base.ForeColor);
            }
            else
            {
                TextBrush.Color = base.ForeColor;
            }

            this.Invalidate();
        }


        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);

            //******************************************************
            //* Go through all controls behind this and draw them
            //* to the background to simulate transparency
            //******************************************************
            if (BackColor == Color.Transparent)
            {
                if (Parent != null)
                {
                    int index = Parent.Controls.GetChildIndex(this);

                    for (int i = Parent.Controls.Count - 1; i > index; i--)
                    {
                        System.Windows.Forms.Control c = Parent.Controls[i];
                        if (c.Bounds.IntersectsWith(Bounds) && c.Visible)
                        {
                            using (Bitmap bmp = new Bitmap(c.Width, c.Height, pevent.Graphics))
                            {
                                c.DrawToBitmap(bmp, c.ClientRectangle);
                                pevent.Graphics.DrawImageUnscaled(bmp, c.Left - Left, c.Top - Top);
                            }
                        }
                    }
                }
            }
        }

        //*************************************************************************
        //* Manually double buffer in order to allow a true transparent background
        //**************************************************************************
        private StringFormat sf = new StringFormat();
        private StringFormat sf2 = new StringFormat();
        private Rectangle Text2Rect;
        protected SolidBrush TextBrush;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            if (TextBrush == null)
            {
                return;
            }

            Graphics g = e.Graphics;
            //'g.RotateTransform(20.0)
            //If m_GraphicAllOff IsNot Nothing Then
            //    m_GraphicAllOff.RotateFlip(RotateFlipType.Rotate90FlipNone)
            //End If


            if (m_ValueSelect1)
            {
                if (Image2 != null)
                {
                    g.DrawImage(Image2, 0, 0);
                }
            }
            else if (m_ValueSelect2)
            {
                if (Image3 != null)
                {
                    g.DrawImage(Image3, 0, 0);
                }
            }
            else
            {
                if (Image1 != null)
                {
                    g.DrawImage(Image1, 0, 0);
                }
            }



            if (!string.IsNullOrEmpty(base.Text))
            {
                g.DrawString(base.Text, base.Font, TextBrush, Convert.ToSingle(this.Width / 2.0F), this.Height / 3.0F, sf);
            }

            if (!string.IsNullOrEmpty(m_Text2))
            {
                // g.DrawString(m_Text2, m_Font2, Brushes.Bisque, Me.Width / 2, (Me.Height / 3) * 2, sf)
                g.DrawString(m_Text2, m_Font2, TextBrush, Text2Rect, sf2);
            }

            //Copy the back buffer to the screen
            //e.Graphics.DrawImage(_backBuffer, 0, 0)
        }


        //********************************************************************
        //* When an instance is added to the form, set the comm component
        //* property. If a comm component does not exist, add one to the form
        //********************************************************************
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            sf2.Alignment = StringAlignment.Center;
            sf2.LineAlignment = StringAlignment.Near;

            if (TextBrush == null)
            {
                TextBrush = new SolidBrush(base.ForeColor);
            }

        }


        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);

            Text2Rect = new Rectangle(0, Convert.ToInt32(this.Height / 1.9), this.Width, Convert.ToInt32(Height / 2.1));

            RefreshImages();
        }

        #endregion

        private void RefreshImages()
        {
            if (Width > 0 && Height > 0)
            {
                if (m_GraphicAllOff != null)
                {
                    Image1 = new Bitmap(this.Width, this.Height);

                    using (Graphics gr_dest = Graphics.FromImage(Image1))
                    {
                        using (System.Drawing.Drawing2D.Matrix m = new System.Drawing.Drawing2D.Matrix())
                        {
                            if (m_RotationAngle == RotationAngleEnum.Rotate90)
                            {
                                //m.Translate(0, -m_GraphicAllOff.Height)
                                m.Translate(m_GraphicAllOff.Height, 0);
                                m.Rotate(90, System.Drawing.Drawing2D.MatrixOrder.Prepend);
                                if (SizeMode == System.Windows.Forms.PictureBoxSizeMode.StretchImage)
                                {
                                    m.Scale(Convert.ToSingle(Width / (double)m_GraphicAllOff.Height), Convert.ToSingle(Height / (double)m_GraphicAllOff.Width), System.Drawing.Drawing2D.MatrixOrder.Append);
                                }
                            }
                            else if (m_RotationAngle == RotationAngleEnum.Rotate180)
                            {
                                m.Translate(-m_GraphicAllOff.Width, -m_GraphicAllOff.Height);
                                m.Rotate(180, System.Drawing.Drawing2D.MatrixOrder.Append);
                                if (SizeMode == System.Windows.Forms.PictureBoxSizeMode.StretchImage)
                                {
                                    m.Scale(Convert.ToSingle(Width / (double)m_GraphicAllOff.Width), Convert.ToSingle(Height / (double)m_GraphicAllOff.Height), System.Drawing.Drawing2D.MatrixOrder.Append);
                                }
                            }
                            else if (m_RotationAngle == RotationAngleEnum.Rotate270)
                            {
                                m.Translate(0, m_GraphicAllOff.Width);
                                m.Rotate(270, System.Drawing.Drawing2D.MatrixOrder.Prepend);
                                if (SizeMode == System.Windows.Forms.PictureBoxSizeMode.StretchImage)
                                {
                                    m.Scale(Convert.ToSingle(Width / (double)m_GraphicAllOff.Height), Convert.ToSingle(Height / (double)m_GraphicAllOff.Width), System.Drawing.Drawing2D.MatrixOrder.Append);
                                }
                            }
                            else
                            {
                                //* No Rotaion
                                if (SizeMode == System.Windows.Forms.PictureBoxSizeMode.StretchImage)
                                {
                                    m.Scale(Convert.ToSingle(Width / (double)m_GraphicAllOff.Width), Convert.ToSingle(Height / (double)m_GraphicAllOff.Height), System.Drawing.Drawing2D.MatrixOrder.Append);
                                }

                            }

                            gr_dest.Transform = m;
                            gr_dest.DrawImage(m_GraphicAllOff, 0, 0);
                        }
                    }
                }

                if (m_GraphicSelect1 != null)
                {
                    Image2 = new Bitmap(this.Width, this.Height);

                    using (Graphics gr_dest = Graphics.FromImage(Image2))
                    {
                        using (System.Drawing.Drawing2D.Matrix m = new System.Drawing.Drawing2D.Matrix())
                        {
                            if (m_RotationAngle == RotationAngleEnum.Rotate90)
                            {
                                m.Translate(m_GraphicSelect1.Height, 0);
                                m.Rotate(90, System.Drawing.Drawing2D.MatrixOrder.Prepend);
                                if (SizeMode == System.Windows.Forms.PictureBoxSizeMode.StretchImage)
                                {
                                    m.Scale(Convert.ToSingle(Width / (double)m_GraphicSelect1.Height), Convert.ToSingle(Height / (double)m_GraphicSelect1.Width), System.Drawing.Drawing2D.MatrixOrder.Append);
                                }
                            }
                            else if (m_RotationAngle == RotationAngleEnum.Rotate180)
                            {
                                m.Translate(-m_GraphicSelect1.Width, -m_GraphicSelect1.Height);
                                m.Rotate(180, System.Drawing.Drawing2D.MatrixOrder.Append);
                                if (SizeMode == System.Windows.Forms.PictureBoxSizeMode.StretchImage)
                                {
                                    m.Scale(Convert.ToSingle(Width / (double)m_GraphicSelect1.Width), Convert.ToInt32((Height / (double)m_GraphicSelect1.Height)), System.Drawing.Drawing2D.MatrixOrder.Append);
                                }
                            }
                            else if (m_RotationAngle == RotationAngleEnum.Rotate270)
                            {
                                m.Translate(0, m_GraphicSelect1.Width);
                                m.Rotate(270, System.Drawing.Drawing2D.MatrixOrder.Prepend);
                                if (SizeMode == System.Windows.Forms.PictureBoxSizeMode.StretchImage)
                                {
                                    m.Scale(Convert.ToSingle(Width / (double)m_GraphicSelect1.Height), Convert.ToSingle(Height / (double)m_GraphicSelect1.Width), System.Drawing.Drawing2D.MatrixOrder.Append);
                                }
                            }
                            else
                            {
                                //* No Rotaion
                                if (SizeMode == System.Windows.Forms.PictureBoxSizeMode.StretchImage)
                                {
                                    m.Scale(Convert.ToSingle(Width / (double)m_GraphicSelect1.Width), Convert.ToSingle(Height / (double)m_GraphicSelect1.Height), System.Drawing.Drawing2D.MatrixOrder.Append);
                                }

                            }

                            gr_dest.Transform = m;
                            gr_dest.DrawImage(m_GraphicSelect1, 0, 0);
                        }
                    }
                }

                if (m_GraphicSelect2 != null)
                {
                    Image3 = new Bitmap(this.Width, this.Height);

                    using (Graphics gr_dest = Graphics.FromImage(Image3))
                    {
                        using (System.Drawing.Drawing2D.Matrix m = new System.Drawing.Drawing2D.Matrix())
                        {
                            if (m_RotationAngle == RotationAngleEnum.Rotate90)
                            {
                                m.Translate(m_GraphicSelect2.Height, 0);
                                m.Rotate(90, System.Drawing.Drawing2D.MatrixOrder.Prepend);
                                if (SizeMode == System.Windows.Forms.PictureBoxSizeMode.StretchImage)
                                {
                                    m.Scale(Convert.ToSingle(Width / (double)m_GraphicSelect2.Height), Convert.ToSingle(Height / (double)m_GraphicSelect2.Width), System.Drawing.Drawing2D.MatrixOrder.Append);
                                }
                            }
                            else if (m_RotationAngle == RotationAngleEnum.Rotate180)
                            {
                                m.Translate(-m_GraphicSelect2.Width, -m_GraphicSelect2.Height);
                                m.Rotate(180, System.Drawing.Drawing2D.MatrixOrder.Append);
                                if (SizeMode == System.Windows.Forms.PictureBoxSizeMode.StretchImage)
                                {
                                    m.Scale(Convert.ToSingle(Width / (double)m_GraphicSelect2.Width), Convert.ToSingle(Height / (double)m_GraphicSelect2.Height), System.Drawing.Drawing2D.MatrixOrder.Append);
                                }
                            }
                            else if (m_RotationAngle == RotationAngleEnum.Rotate270)
                            {
                                m.Translate(0, m_GraphicSelect2.Width);
                                m.Rotate(270, System.Drawing.Drawing2D.MatrixOrder.Prepend);
                                if (SizeMode == System.Windows.Forms.PictureBoxSizeMode.StretchImage)
                                {
                                    m.Scale(Convert.ToSingle(Width / (double)m_GraphicSelect2.Height), Convert.ToSingle(Height / (double)m_GraphicSelect2.Width), System.Drawing.Drawing2D.MatrixOrder.Append);
                                }
                            }
                            else
                            {
                                //* No Rotaion
                                if (SizeMode == System.Windows.Forms.PictureBoxSizeMode.StretchImage)
                                {
                                    m.Scale(Convert.ToSingle(Width / (double)m_GraphicSelect2.Width), Convert.ToSingle(Height / (double)m_GraphicSelect2.Height), System.Drawing.Drawing2D.MatrixOrder.Append);
                                }

                            }

                            gr_dest.Transform = m;
                            gr_dest.DrawImage(m_GraphicSelect2, 0, 0);
                        }
                    }
                }

                //BackGroundNeedsRefreshed = True

                this.Invalidate();
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
        private string m_PLCAddressSelect1 = string.Empty;

        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string m_PLCAddressSelect2 = string.Empty;


        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string m_PLCAddressText2 = string.Empty;

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


        public string PLCAddressValueSelect1
        {
            get { return m_PLCAddressSelect1; }
            set
            {
                if (m_PLCAddressSelect1 != value)
                {
                    m_PLCAddressSelect1 = value;
                    try
                    {
                        //* When address is changed, re-subscribe to new address
                        if (string.IsNullOrEmpty(m_PLCAddressSelect1) ||
                            string.IsNullOrWhiteSpace(m_PLCAddressSelect1) || Licenses.LicenseManager.IsInDesignMode) return;
                        var bd = new Binding("ValueSelect1", TagCollectionClient.Tags[m_PLCAddressSelect1], "ValueSelect1", true);
                        DataBindings.Add(bd);
                    }
                    catch (Exception ex)
                    {
                        DisplayError(ex.Message);
                    }
                }
            }
        }

        public string PLCAddressValueSelect2
        {
            get { return m_PLCAddressSelect2; }
            set
            {
                if (m_PLCAddressSelect2 != value) m_PLCAddressSelect2 = value;
            }
        }

        public string PLCAddressVisible
        {
            get { return m_PLCAddressVisible; }
            set
            {
                if (m_PLCAddressVisible != value)
                {
                    m_PLCAddressVisible = value;
                    //* When address is changed, re-subscribe to new address
                    try
                    {
                        //* When address is changed, re-subscribe to new address
                        if (string.IsNullOrEmpty(m_PLCAddressVisible) ||
                            string.IsNullOrWhiteSpace(m_PLCAddressVisible) || Licenses.LicenseManager.IsInDesignMode) return;
                        var bd = new Binding("Visible", TagCollectionClient.Tags[m_PLCAddressVisible], "Visible", true);
                        DataBindings.Add(bd);
                    }
                    catch (Exception ex)
                    {
                        DisplayError(ex.Message);
                    }
                }
            }
        }

        public string PLCAddressText2
        {
            get { return m_PLCAddressText2; }
            set
            {
                if (m_PLCAddressText2 != value) m_PLCAddressText2 = value;
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
                    case OutputTypes.MomentarySet:
                        WCFChannelFactory.Write(m_PLCAddressClick, Convert.ToString(false));
                        break;
                    case OutputTypes.MomentaryReset:
                        WCFChannelFactory.Write(m_PLCAddressClick, Convert.ToString(true));
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


            if (!string.IsNullOrWhiteSpace(m_PLCAddressClick) & Enabled && m_PLCAddressClick != null)
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

                            var CurrentValue = false;
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