using AdvancedScada;
using AdvancedScada;
using AdvancedScada.Controls;
using AdvancedScada.Controls;
using AdvancedScada.Controls.DialogEditor;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AdvancedScada.Controls.ImageAll.Symbols
{
    //****************************************************************************
    //* 12-DEC-08 Added line in OnPaint to exit is LegendText is nothing
    //* 05-OCT-09 Exit OnPaint if GrayPen is Nothing
    //****************************************************************************
    [ToolboxItem(false)]
    public class GraphicIndicatorBase : Control
    {
        //private Bitmap StaticImage;
        private Bitmap Image1;
        private Bitmap Image2;
        private Bitmap Image3;
        public event EventHandler ValueSelect1Changed;
        public event EventHandler ValueSelect2Changed;

        private void RefreshImages()
        {
            if (Width > 0 && Height > 0)
            {
                if (m_GraphicAllOff != null)
                {
                    Image1 = new Bitmap(Width, Height);

                    using (var gr_dest = Graphics.FromImage(Image1))
                    {
                        using (var m = new Matrix())
                        {
                            if (m_RotationAngle == RotationAngleEnum.Rotate90)
                            {
                                //m.Translate(0, -m_GraphicAllOff.Height)
                                m.Translate(m_GraphicAllOff.Height, 0F);
                                m.Rotate(90F, MatrixOrder.Prepend);
                                if (SizeMode == PictureBoxSizeMode.StretchImage)
                                    m.Scale(Convert.ToSingle(Width / (double)m_GraphicAllOff.Height),
                                        Convert.ToSingle(Height / (double)m_GraphicAllOff.Width), MatrixOrder.Append);
                            }
                            else if (m_RotationAngle == RotationAngleEnum.Rotate180)
                            {
                                m.Translate(-m_GraphicAllOff.Width, -m_GraphicAllOff.Height);
                                m.Rotate(180F, MatrixOrder.Append);
                                if (SizeMode == PictureBoxSizeMode.StretchImage)
                                    m.Scale(Convert.ToSingle(Width / (double)m_GraphicAllOff.Width),
                                        Convert.ToSingle(Height / (double)m_GraphicAllOff.Height), MatrixOrder.Append);
                            }
                            else if (m_RotationAngle == RotationAngleEnum.Rotate270)
                            {
                                m.Translate(0F, m_GraphicAllOff.Width);
                                m.Rotate(270F, MatrixOrder.Prepend);
                                if (SizeMode == PictureBoxSizeMode.StretchImage)
                                    m.Scale(Convert.ToSingle(Width / (double)m_GraphicAllOff.Height),
                                        Convert.ToSingle(Height / (double)m_GraphicAllOff.Width), MatrixOrder.Append);
                            }
                            else
                            {
                                //* No Rotaion
                                if (SizeMode == PictureBoxSizeMode.StretchImage)
                                    m.Scale(Convert.ToSingle(Width / (double)m_GraphicAllOff.Width),
                                        Convert.ToSingle(Height / (double)m_GraphicAllOff.Height), MatrixOrder.Append);
                            }

                            gr_dest.Transform = m;
                            gr_dest.DrawImage(m_GraphicAllOff, 0, 0);
                        }
                    }
                }

                if (m_GraphicSelect1 != null)
                {
                    Image2 = new Bitmap(Width, Height);

                    using (var gr_dest = Graphics.FromImage(Image2))
                    {
                        using (var m = new Matrix())
                        {
                            if (m_RotationAngle == RotationAngleEnum.Rotate90)
                            {
                                m.Translate(m_GraphicSelect1.Height, 0F);
                                m.Rotate(90F, MatrixOrder.Prepend);
                                if (SizeMode == PictureBoxSizeMode.StretchImage)
                                    m.Scale(Convert.ToSingle(Width / (double)m_GraphicSelect1.Height),
                                        Convert.ToSingle(Height / (double)m_GraphicSelect1.Width), MatrixOrder.Append);
                            }
                            else if (m_RotationAngle == RotationAngleEnum.Rotate180)
                            {
                                m.Translate(-m_GraphicSelect1.Width, -m_GraphicSelect1.Height);
                                m.Rotate(180F, MatrixOrder.Append);
                                if (SizeMode == PictureBoxSizeMode.StretchImage)
                                    m.Scale(Convert.ToSingle(Width / (double)m_GraphicSelect1.Width),
                                        Convert.ToInt32(Height / (double)m_GraphicSelect1.Height), MatrixOrder.Append);
                            }
                            else if (m_RotationAngle == RotationAngleEnum.Rotate270)
                            {
                                m.Translate(0F, m_GraphicSelect1.Width);
                                m.Rotate(270F, MatrixOrder.Prepend);
                                if (SizeMode == PictureBoxSizeMode.StretchImage)
                                    m.Scale(Convert.ToSingle(Width / (double)m_GraphicSelect1.Height),
                                        Convert.ToSingle(Height / (double)m_GraphicSelect1.Width), MatrixOrder.Append);
                            }
                            else
                            {
                                //* No Rotaion
                                if (SizeMode == PictureBoxSizeMode.StretchImage)
                                    m.Scale(Convert.ToSingle(Width / (double)m_GraphicSelect1.Width),
                                        Convert.ToSingle(Height / (double)m_GraphicSelect1.Height),
                                        MatrixOrder.Append);
                            }

                            gr_dest.Transform = m;
                            gr_dest.DrawImage(m_GraphicSelect1, 0, 0);
                        }
                    }
                }

                if (m_GraphicSelect2 != null)
                {
                    Image3 = new Bitmap(Width, Height);

                    using (var gr_dest = Graphics.FromImage(Image3))
                    {
                        using (var m = new Matrix())
                        {
                            if (m_RotationAngle == RotationAngleEnum.Rotate90)
                            {
                                m.Translate(m_GraphicSelect2.Height, 0F);
                                m.Rotate(90F, MatrixOrder.Prepend);
                                if (SizeMode == PictureBoxSizeMode.StretchImage)
                                    m.Scale(Convert.ToSingle(Width / (double)m_GraphicSelect2.Height),
                                        Convert.ToSingle(Height / (double)m_GraphicSelect2.Width), MatrixOrder.Append);
                            }
                            else if (m_RotationAngle == RotationAngleEnum.Rotate180)
                            {
                                m.Translate(-m_GraphicSelect2.Width, -m_GraphicSelect2.Height);
                                m.Rotate(180F, MatrixOrder.Append);
                                if (SizeMode == PictureBoxSizeMode.StretchImage)
                                    m.Scale(Convert.ToSingle(Width / (double)m_GraphicSelect2.Width),
                                        Convert.ToSingle(Height / (double)m_GraphicSelect2.Height),
                                        MatrixOrder.Append);
                            }
                            else if (m_RotationAngle == RotationAngleEnum.Rotate270)
                            {
                                m.Translate(0F, m_GraphicSelect2.Width);
                                m.Rotate(270F, MatrixOrder.Prepend);
                                if (SizeMode == PictureBoxSizeMode.StretchImage)
                                    m.Scale(Convert.ToSingle(Width / (double)m_GraphicSelect2.Height),
                                        Convert.ToSingle(Height / (double)m_GraphicSelect2.Width), MatrixOrder.Append);
                            }
                            else
                            {
                                //* No Rotaion
                                if (SizeMode == PictureBoxSizeMode.StretchImage)
                                    m.Scale(Convert.ToSingle(Width / (double)m_GraphicSelect2.Width),
                                        Convert.ToSingle(Height / (double)m_GraphicSelect2.Height),
                                        MatrixOrder.Append);
                            }

                            gr_dest.Transform = m;
                            gr_dest.DrawImage(m_GraphicSelect2, 0, 0);
                        }
                    }
                }

                //BackGroundNeedsRefreshed = True

                Invalidate();
            }
        }
        // private Rectangle TextRect = new Rectangle();
        // private float ImageRatio;

        #region Constructor

        public GraphicIndicatorBase()
        {
            //'* reduce the flicker
            SetStyle(
                ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                ControlStyles.SupportsTransparentBackColor, true);

            ForeColor = Color.WhiteSmoke;

            BackgroundImageLayout = ImageLayout.Stretch;

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (sf2 != null) sf2.Dispose();
            if (sf != null) sf.Dispose();
            if (m_Font2 != null) m_Font2.Dispose();
            if (Image1 != null) Image1.Dispose();
            if (Image2 != null) Image2.Dispose();
            if (Image3 != null) Image3.Dispose();
            TextBrush.Dispose();
        }

        #endregion

        #region Properties


        private bool m_ValueSelect1;

        public bool ValueSelect1
        {
            get { return m_ValueSelect1; }
            set
            {
                if (value != m_ValueSelect1)
                {
                    m_ValueSelect1 = value;

                    //BackGroundNeedsRefreshed = True
                    Invalidate();

                    OnValueSelect1Changed(EventArgs.Empty);
                }
            }
        }

        private bool m_ValueSelect2;

        public bool ValueSelect2
        {
            get { return m_ValueSelect2; }
            set
            {
                if (value != m_ValueSelect2)
                {
                    m_ValueSelect2 = value;

                    //BackGroundNeedsRefreshed = True
                    Invalidate();

                    OnValueSelect2Changed(EventArgs.Empty);
                }
            }
        }

        //*****************************************
        //* Property - Image to Show when All is off
        //*****************************************
        //Private m_LightOnColor As Color = Color.Green
        private Bitmap m_GraphicAllOff;

        [Category("PLC Properties")]
        [Editor(typeof(GraphicDialogEditor), typeof(UITypeEditor))]
        public Bitmap GraphicAllOff
        {
            get { return m_GraphicAllOff; }
            set
            {
                if (m_GraphicAllOff != value)
                {
                    m_GraphicAllOff = value;

                    RefreshImages();

                    //Invalidate();
                }
            }
        }

        //*****************************************
        //* Property - Image to Show when
        //*****************************************
        //Private m_LightOnColor As Color = Color.Green
        private Bitmap m_GraphicSelect1;

        [Category("PLC Properties")]
        [Editor(typeof(GraphicDialogEditor), typeof(UITypeEditor))]
        public Bitmap GraphicSelect1
        {
            get { return m_GraphicSelect1; }
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

        [Category("PLC Properties")]
        [Editor(typeof(GraphicDialogEditor), typeof(UITypeEditor))]
        public Bitmap GraphicSelect2
        {
            get { return m_GraphicSelect2; }
            set
            {
                m_GraphicSelect2 = value;
                RefreshImages();
                //Me.Invalidate()
            }
        }

        private Timer FlashTimer;
        private bool m_Flash1;

        public bool Flash1
        {
            get { return m_Flash1; }
            set
            {
                if (m_Flash1 != value)
                {
                    m_Flash1 = value;

                    if (m_Flash1)
                    {
                        if (FlashTimer == null)
                        {
                            FlashTimer = new Timer();
                            FlashTimer.Interval = 800;
                            FlashTimer.Tick += FlashTimerTick;
                            FlashTimer.Start();
                        }
                    }
                    else
                    {
                        if (FlashTimer != null) FlashTimer.Stop();
                    }
                }
            }
        }

        private void FlashTimerTick(object sender, EventArgs e)
        {
            ValueSelect1 = !ValueSelect1;
        }

        private PictureBoxSizeMode m_SizeMode = PictureBoxSizeMode.StretchImage;

        public PictureBoxSizeMode SizeMode
        {
            get { return m_SizeMode; }
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
            get { return m_RotationAngle; }
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
            get { return m_Text2; }
            set
            {
                if (m_Text2 != value)
                {
                    m_Text2 = value;
                    if (!string.IsNullOrEmpty(NumericFormat) && !DesignMode)
                        try
                        {
                            m_Text2 = (float.Parse(value) * (float)m_ValueScaleFactor).ToString(NumericFormat);
                        }
                        catch (Exception ex)
                        {
                            m_Text2 = "Check NumericFormat and variable type";
                            Console.WriteLine(ex.Message);
                        }

                    Invalidate();
                }
            }
        }

        //*****************************************
        //* Property - Second Text
        //*****************************************
        private Font m_Font2 = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);

        public Font Font2
        {
            get { return m_Font2; }
            set
            {
                m_Font2 = value;
                //RefreshImage()
                Invalidate();
            }
        }

        public string NumericFormat { get; set; }

        private decimal m_ValueScaleFactor = 1M;

        public decimal ValueScaleFactor
        {
            get { return m_ValueScaleFactor; }
            set { m_ValueScaleFactor = value; }
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
            get { return m_OutputType; }
            set { m_OutputType = value; }
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

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
        }

        protected override void OnMouseHover(EventArgs e)
        {

            Invalidate();
            base.OnMouseHover(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {

            Invalidate();
            base.OnMouseLeave(e);
        }

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

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);

            if (TextBrush == null)
                TextBrush = new SolidBrush(ForeColor);
            else
                TextBrush.Color = ForeColor;

            Invalidate();
        }


        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);

            //******************************************************
            //* Go through all controls behind this and draw them
            //* to the background to simulate transparency
            //******************************************************
            if (BackColor == Color.Transparent)
                if (Parent != null)
                {
                    var index = Parent.Controls.GetChildIndex(this);

                    for (var i = Parent.Controls.Count - 1; i > index; i--)
                    {
                        var c = Parent.Controls[i];
                        if (c.Bounds.IntersectsWith(Bounds) && c.Visible)
                            using (var bmp = new Bitmap(c.Width, c.Height, pevent.Graphics))
                            {
                                c.DrawToBitmap(bmp, c.ClientRectangle);
                                pevent.Graphics.DrawImageUnscaled(bmp, c.Left - Left, c.Top - Top);
                            }
                    }
                }
        }

        //*************************************************************************
        //* Manually double buffer in order to allow a true transparent background
        //**************************************************************************
        private readonly StringFormat sf = new StringFormat();
        private readonly StringFormat sf2 = new StringFormat();
        private Rectangle Text2Rect;
        protected SolidBrush TextBrush;

        protected override void OnPaint(PaintEventArgs e)
        {
            if (TextBrush == null) return;

            var g = e.Graphics;
            //'g.RotateTransform(20.0)
            //If m_GraphicAllOff IsNot Nothing Then
            //    m_GraphicAllOff.RotateFlip(RotateFlipType.Rotate90FlipNone)
            //End If


            if (m_ValueSelect1)
            {
                if (Image2 != null) g.DrawImage(Image2, 0, 0);
            }
            else if (m_ValueSelect2)
            {
                if (Image3 != null) g.DrawImage(Image3, 0, 0);
            }
            else
            {
                if (Image1 != null) g.DrawImage(Image1, 0, 0);
            }


            if (!string.IsNullOrEmpty(Text))
                g.DrawString(Text, Font, TextBrush, Convert.ToSingle(Width / 2.0F), Height / 3.0F, sf);

            if (!string.IsNullOrEmpty(m_Text2)) g.DrawString(m_Text2, m_Font2, TextBrush, Text2Rect, sf2);

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

            if (TextBrush == null) TextBrush = new SolidBrush(ForeColor);
        }


        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            Text2Rect = new Rectangle(0, Convert.ToInt32(Height / 1.9), Width, Convert.ToInt32(Height / 2.1));

            RefreshImages();
        }

        #endregion
    }
}