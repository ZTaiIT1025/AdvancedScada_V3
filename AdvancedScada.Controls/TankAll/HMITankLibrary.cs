
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvancedScada.Controls.TankAll
{
    public class HMITankLibrary : System.Windows.Forms.Control
    {
        #region Filde
        private Bitmap TankImage;
        private Bitmap TankCategory;
        private Rectangle TextRectangle;
        private SolidBrush TextBrush;
        private StringFormat sfCenter;
        private StringFormat sfCenterTop;
        private HatchBrush m_TankContentColor;
        //private bool m_LockAspectRatio;
        //private int BarHeight;
        //private int FullBarHeight;
        private Bitmap _backBuffer;
        private float ImageRatio;
        private HMITankColorFour _TankColor;
        private HMITankTypeFour _TankType;
        #endregion
        #region Enum


        public enum HMITankColorFour
        {
            Blue,
            Green,
            Gray,
            Red,
            Yellow
        }
        public enum HMITankTypeFour
        {
            Type1,
            Type2,
            Type3,
            Type4,
            Type5,
            Type6,
            Type7,
            Type8,
            Type9,
            Type10

        }
        #endregion
        #region Property
        public HMITankTypeFour TankType
        {
            get
            {
                return _TankType;
            }
            set
            {
                _TankType = value;
                switch (this.TankType)
                {
                    case HMITankTypeFour.Type1:
                        switch (this.TankColor)
                        {
                            case HMITankColorFour.Blue:
                                this.TankCategory = Properties.Resources.DrumBlue;
                                break;
                            case HMITankColorFour.Green:
                                this.TankCategory = Properties.Resources.DrumGreen;
                                break;
                            case HMITankColorFour.Gray:
                                this.TankCategory = Properties.Resources.Drum;
                                break;
                            case HMITankColorFour.Red:
                                this.TankCategory = Properties.Resources.DrumRed;
                                break;
                            case HMITankColorFour.Yellow:
                                this.TankCategory = Properties.Resources.DrumBlack;
                                break;
                        }
                        break;
                    case HMITankTypeFour.Type2:
                        switch (this.TankColor)
                        {

                            case HMITankColorFour.Green:
                                this.TankCategory = Properties.Resources.Ketlle1Green;
                                break;
                            case HMITankColorFour.Gray:
                                this.TankCategory = Properties.Resources.Ketlle1;
                                break;
                            case HMITankColorFour.Red:
                                this.TankCategory = Properties.Resources.Ketlle1Red;
                                break;

                        }
                        break;
                    case HMITankTypeFour.Type3:
                        switch (this.TankColor)
                        {

                            case HMITankColorFour.Green:
                                this.TankCategory = Properties.Resources.KetlleLongLegsGreen;
                                break;
                            case HMITankColorFour.Gray:
                                this.TankCategory = Properties.Resources.KetlleLongLegs;
                                break;
                            case HMITankColorFour.Red:
                                this.TankCategory = Properties.Resources.KetlleLongLegsRed;
                                break;

                        }
                        break;
                    case HMITankTypeFour.Type4:
                        switch (this.TankColor)
                        {

                            case HMITankColorFour.Green:
                                this.TankCategory = Properties.Resources.KettleShortLegsGreen;
                                break;
                            case HMITankColorFour.Gray:
                                this.TankCategory = Properties.Resources.KettleShortLegs;
                                break;
                            case HMITankColorFour.Red:
                                this.TankCategory = Properties.Resources.KettleShortLegsRed;
                                break;

                        }
                        break;
                    case HMITankTypeFour.Type5:
                        switch (this.TankColor)
                        {
                            case HMITankColorFour.Blue:
                                //' Me.TankCategory = My.Resources.SiloBlue
                                break;
                            case HMITankColorFour.Green:
                                this.TankCategory = Properties.Resources.SiloGreen;
                                break;
                            case HMITankColorFour.Gray:
                                this.TankCategory = Properties.Resources.Silo;
                                break;
                            case HMITankColorFour.Red:
                                this.TankCategory = Properties.Resources.SiloRed;
                                break;
                            case HMITankColorFour.Yellow:
                                //' Me.TankCategory = My.Resources.SiloYellow
                                break;
                        }
                        break;
                    case HMITankTypeFour.Type6:
                        switch (this.TankColor)
                        {

                            case HMITankColorFour.Green:
                                this.TankCategory = Properties.Resources.SiloWithLegsGreen;
                                break;
                            case HMITankColorFour.Gray:
                                this.TankCategory = Properties.Resources.SiloWithLegs;
                                break;
                            case HMITankColorFour.Red:
                                this.TankCategory = Properties.Resources.SiloWithLegsRed;
                                break;

                        }
                        break;
                    case HMITankTypeFour.Type7:
                        switch (this.TankColor)
                        {

                            case HMITankColorFour.Green:
                                this.TankCategory = Properties.Resources.Tank1Green;
                                break;
                            case HMITankColorFour.Gray:
                                this.TankCategory = Properties.Resources.Tank1;
                                break;
                            case HMITankColorFour.Red:
                                this.TankCategory = Properties.Resources.Tank1Red;
                                break;

                        }
                        break;
                    case HMITankTypeFour.Type8:
                        switch (this.TankColor)
                        {

                            case HMITankColorFour.Green:
                                this.TankCategory = Properties.Resources.Tank1WithLegsGreen;
                                break;
                            case HMITankColorFour.Gray:
                                this.TankCategory = Properties.Resources.Tank1WithLegs;
                                break;
                            case HMITankColorFour.Red:
                                this.TankCategory = Properties.Resources.Tank1WithLegsRed;
                                break;

                        }
                        break;

                    case HMITankTypeFour.Type9:
                        switch (this.TankColor)
                        {

                            case HMITankColorFour.Green:
                                this.TankCategory = Properties.Resources.VesselGreen;
                                break;
                            case HMITankColorFour.Gray:
                                this.TankCategory = Properties.Resources.Vessel;
                                break;
                            case HMITankColorFour.Red:
                                this.TankCategory = Properties.Resources.VesselRed;
                                break;

                        }
                        break;

                    case HMITankTypeFour.Type10:
                        switch (this.TankColor)
                        {

                            case HMITankColorFour.Green:
                                this.TankCategory = Properties.Resources.VesselWithLegsGreen;
                                break;
                            case HMITankColorFour.Gray:
                                this.TankCategory = Properties.Resources.VesselWithLegs;
                                break;
                            case HMITankColorFour.Red:
                                this.TankCategory = Properties.Resources.VesselRedWithLegs;
                                break;

                        }
                        break;




                }
                this.RefreshImage();
                this.Invalidate();
            }
        }

        public HMITankColorFour TankColor
        {
            get
            {
                return _TankColor;
            }
            set
            {
                _TankColor = value;
                switch (this.TankType)
                {
                    case HMITankTypeFour.Type1:
                        switch (this.TankColor)
                        {
                            case HMITankColorFour.Blue:
                                this.TankCategory = Properties.Resources.DrumBlue;
                                break;
                            case HMITankColorFour.Green:
                                this.TankCategory = Properties.Resources.DrumGreen;
                                break;
                            case HMITankColorFour.Gray:
                                this.TankCategory = Properties.Resources.Drum;
                                break;
                            case HMITankColorFour.Red:
                                this.TankCategory = Properties.Resources.DrumRed;
                                break;
                            case HMITankColorFour.Yellow:
                                this.TankCategory = Properties.Resources.DrumBlack;
                                break;
                        }
                        break;
                    case HMITankTypeFour.Type2:
                        switch (this.TankColor)
                        {

                            case HMITankColorFour.Green:
                                this.TankCategory = Properties.Resources.Ketlle1Green;
                                break;
                            case HMITankColorFour.Gray:
                                this.TankCategory = Properties.Resources.Ketlle1;
                                break;
                            case HMITankColorFour.Red:
                                this.TankCategory = Properties.Resources.Ketlle1Red;
                                break;

                        }
                        break;
                    case HMITankTypeFour.Type3:
                        switch (this.TankColor)
                        {

                            case HMITankColorFour.Green:
                                this.TankCategory = Properties.Resources.KetlleLongLegsGreen;
                                break;
                            case HMITankColorFour.Gray:
                                this.TankCategory = Properties.Resources.KetlleLongLegs;
                                break;
                            case HMITankColorFour.Red:
                                this.TankCategory = Properties.Resources.KetlleLongLegsRed;
                                break;

                        }
                        break;
                    case HMITankTypeFour.Type4:
                        switch (this.TankColor)
                        {

                            case HMITankColorFour.Green:
                                this.TankCategory = Properties.Resources.KettleShortLegsGreen;
                                break;
                            case HMITankColorFour.Gray:
                                this.TankCategory = Properties.Resources.KettleShortLegs;
                                break;
                            case HMITankColorFour.Red:
                                this.TankCategory = Properties.Resources.KettleShortLegsRed;
                                break;

                        }
                        break;
                    case HMITankTypeFour.Type5:
                        switch (this.TankColor)
                        {
                            case HMITankColorFour.Blue:
                                //' Me.TankCategory = My.Resources.SiloBlue
                                break;
                            case HMITankColorFour.Green:
                                this.TankCategory = Properties.Resources.SiloGreen;
                                break;
                            case HMITankColorFour.Gray:
                                this.TankCategory = Properties.Resources.Silo;
                                break;
                            case HMITankColorFour.Red:
                                this.TankCategory = Properties.Resources.SiloRed;
                                break;
                            case HMITankColorFour.Yellow:
                                //'  Me.TankCategory = My.Resources.SiloYellow
                                break;
                        }
                        break;
                    case HMITankTypeFour.Type6:
                        switch (this.TankColor)
                        {

                            case HMITankColorFour.Green:
                                this.TankCategory = Properties.Resources.SiloWithLegsGreen;
                                break;
                            case HMITankColorFour.Gray:
                                this.TankCategory = Properties.Resources.SiloWithLegs;
                                break;
                            case HMITankColorFour.Red:
                                this.TankCategory = Properties.Resources.SiloWithLegsRed;
                                break;

                        }
                        break;
                    case HMITankTypeFour.Type7:
                        switch (this.TankColor)
                        {

                            case HMITankColorFour.Green:
                                this.TankCategory = Properties.Resources.Tank1Green;
                                break;
                            case HMITankColorFour.Gray:
                                this.TankCategory = Properties.Resources.Tank1;
                                break;
                            case HMITankColorFour.Red:
                                this.TankCategory = Properties.Resources.Tank1Red;
                                break;

                        }
                        break;
                    case HMITankTypeFour.Type8:
                        switch (this.TankColor)
                        {

                            case HMITankColorFour.Green:
                                this.TankCategory = Properties.Resources.Tank1WithLegsGreen;
                                break;
                            case HMITankColorFour.Gray:
                                this.TankCategory = Properties.Resources.Tank1WithLegs;
                                break;
                            case HMITankColorFour.Red:
                                this.TankCategory = Properties.Resources.Tank1WithLegsRed;
                                break;

                        }
                        break;

                    case HMITankTypeFour.Type9:
                        switch (this.TankColor)
                        {

                            case HMITankColorFour.Green:
                                this.TankCategory = Properties.Resources.VesselGreen;
                                break;
                            case HMITankColorFour.Gray:
                                this.TankCategory = Properties.Resources.Vessel;
                                break;
                            case HMITankColorFour.Red:
                                this.TankCategory = Properties.Resources.VesselRed;
                                break;

                        }
                        break;

                    case HMITankTypeFour.Type10:
                        switch (this.TankColor)
                        {

                            case HMITankColorFour.Green:
                                this.TankCategory = Properties.Resources.VesselWithLegsGreen;
                                break;
                            case HMITankColorFour.Gray:
                                this.TankCategory = Properties.Resources.VesselWithLegs;
                                break;
                            case HMITankColorFour.Red:
                                this.TankCategory = Properties.Resources.VesselRedWithLegs;
                                break;

                        }
                        break;




                }
                this.RefreshImage();
                this.Invalidate();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(true)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                this.RefreshImage();
                this.Invalidate();
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
                this.RefreshImage();
                this.Invalidate();
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
                if (!(value != base.ForeColor))
                {
                    return;
                }
                base.ForeColor = value;
                if (this.TextBrush == null)
                {
                    this.TextBrush = new SolidBrush(base.ForeColor);
                }
                else
                {
                    this.TextBrush.Color = value;
                }
                this.Invalidate();
            }
        }


        public Color TankContentColor
        {
            get
            {
                return this.m_TankContentColor.BackgroundColor;
            }
            set
            {
                if (this.m_TankContentColor != null)
                {
                    this.m_TankContentColor.Dispose();
                }
                this.m_TankContentColor = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(240, Math.Max((int)value.R - 40, 0), Math.Max((int)value.G - 40, 0), Math.Max((int)value.B - 40, 0)), value);
                this.Invalidate();
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams__1 = base.CreateParams;
                createParams__1.ExStyle |= 32;
                return createParams__1;
            }
        }
        #endregion

        #region Constructor
        public HMITankLibrary()
        {
            //* reduce the flicker
            SetStyle(System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer | System.Windows.Forms.ControlStyles.AllPaintingInWmPaint | System.Windows.Forms.ControlStyles.UserPaint | System.Windows.Forms.ControlStyles.SupportsTransparentBackColor, true);

            this.Resize += this.Tank_Resize;
            this.TextRectangle = new Rectangle();
            this.sfCenter = new StringFormat();
            this.sfCenterTop = new StringFormat();
            this.m_TankContentColor = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.Aqua);
            TankCategory = Properties.Resources.Tank1Red;
            this.RefreshImage();
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (!disposing)
                {
                    return;
                }
                this.TankImage.Dispose();
                this._backBuffer.Dispose();
                this.m_TankContentColor.Dispose();
                this.sfCenterTop.Dispose();
                this.sfCenter.Dispose();
                this.TextBrush.Dispose();
            }
            finally
            {
                base.Dispose(disposing);
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.TankImage == null || this._backBuffer == null || this.TextBrush == null)
            {
                return;
            }
            Graphics graphics__1 = Graphics.FromImage((System.Drawing.Image)this._backBuffer);
            graphics__1.DrawImage((System.Drawing.Image)this.TankImage, 0, 0);
            if (this.m_TankContentColor != null)
            {
                graphics__1.FillRectangle((Brush)this.m_TankContentColor, Convert.ToInt32(361.0 * ((double)this.Width / (double)this.TankCategory.Width)), Convert.ToInt32(158.0 * ((double)this.Height / (double)this.TankCategory.Height)), Convert.ToInt32(68.0 * ((double)this.Width / (double)this.TankCategory.Width)), 0);
            }
            if (base.Text != null && string.Compare(base.Text, string.Empty) != 0)
            {
                if (this.TextBrush.Color != base.ForeColor)
                {
                    this.TextBrush.Color = base.ForeColor;
                }
                //graphics__1.DrawString(MyBase.Text, MyBase.Font, DirectCast(Me.TextBrush, Brush), DirectCast(Me.TextRectangle, RectangleF), Me.sfCenterTop)
            }
            e.Graphics.DrawImage((System.Drawing.Image)this._backBuffer, 0, 0);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (this._backBuffer != null)
            {
                this._backBuffer.Dispose();
                this._backBuffer = (Bitmap)null;
            }
            base.OnSizeChanged(e);
            if (this.Parent == null)
            {
                return;
            }
            this.Parent.Invalidate();
        }

        private void RefreshImage()
        {
            float num1 = (float)this.Width / (float)this.TankCategory.Width;
            float num2 = (float)this.Height / (float)this.TankCategory.Height;
            this.ImageRatio = (float)this.Width / (float)this.Height;
            this.ImageRatio = 1.0F;
            int num3 = 0;
            int num4 = 0;
            if ((double)num1 < (double)num2)
            {
                num3 = this.Height;
                num4 = !(this.Height > 0 && this.TankCategory.Height > 0) ? 1 : Convert.ToInt32(Math.Round((double)this.TankCategory.Width / (double)this.TankCategory.Height * (double)this.Height));
                this.ImageRatio = num1;
            }
            else
            {
                num4 = this.Width;
                num3 = Convert.ToInt32(Math.Round((double)this.TankCategory.Height / (double)this.TankCategory.Width * (double)this.Width));
                this.ImageRatio = num2;
            }
            if ((double)this.ImageRatio <= 0.0)
            {
                return;
            }
            if (this.TankImage != null)
            {
                this.TankImage.Dispose();
            }
            this.TankImage = new Bitmap(Convert.ToInt32(this.Width), Convert.ToInt32(this.Height));
            Graphics graphics__1 = Graphics.FromImage((System.Drawing.Image)this.TankImage);
            graphics__1.DrawImage((System.Drawing.Image)this.TankCategory, 0, 0, this.TankImage.Width, this.TankImage.Height);
            this.TextRectangle.X = 1;
            this.TextRectangle.Y = Convert.ToInt32(Math.Round(70.0 * (double)this.ImageRatio - 1.0));
            this.TextRectangle.Width = this.TankImage.Width - 2;
            this.TextRectangle.Height = Convert.ToInt32(Math.Round((double)this.TankImage.Height * 0.1));
            this.sfCenterTop.Alignment = StringAlignment.Center;
            this.sfCenterTop.LineAlignment = StringAlignment.Near;
            this.TextBrush = new SolidBrush(base.ForeColor);
            if (this._backBuffer != null)
            {
                this._backBuffer.Dispose();
            }
            this._backBuffer = new Bitmap(this.Width, this.Height);
            graphics__1.Dispose();
            this.Invalidate();
        }

        private void Tank_Resize(object sender, EventArgs e)
        {
            this.RefreshImage();
        }
        #endregion
    }

}