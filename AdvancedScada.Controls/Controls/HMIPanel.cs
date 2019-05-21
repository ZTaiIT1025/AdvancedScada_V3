

using AdvancedScada;
using AdvancedScada;
using AdvancedScada.Controls;
using AdvancedScada.Controls;
using AdvancedScada.Controls.Class;

using AdvancedScada.Controls.Class;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Controls
{
    public partial class HMIPanel : Panel
    {
        private int _borderWidth = 1;
        [Browsable(true), Category(A1PanelGlobals.A1Category), DefaultValue(1)]
        public int BorderWidth
        {
            get
            {
                return _borderWidth;
            }
            set
            {
                _borderWidth = value;
                Invalidate();
            }
        }

        private int _shadowOffSet = 5;
        [Browsable(true), Category(A1PanelGlobals.A1Category), DefaultValue(5)]
        public int ShadowOffSet
        {
            get
            {
                return _shadowOffSet;
            }
            set
            {
                _shadowOffSet = Math.Abs(value);
                Invalidate();
            }
        }

        private int _roundCornerRadius = 4;
        [Browsable(true), Category(A1PanelGlobals.A1Category), DefaultValue(4)]
        public int RoundCornerRadius
        {
            get
            {
                return _roundCornerRadius;
            }
            set
            {
                _roundCornerRadius = Math.Abs(value);
                Invalidate();
            }
        }

        private System.Drawing.Image _image;
        [Browsable(true), Category(A1PanelGlobals.A1Category)]
        public System.Drawing.Image Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                Invalidate();
            }
        }

        private Point _imageLocation = new Point(4, 4);
        [Browsable(true), Category(A1PanelGlobals.A1Category), DefaultValue("4,4")]
        public Point ImageLocation
        {
            get
            {
                return _imageLocation;
            }
            set
            {
                _imageLocation = value;
                Invalidate();
            }
        }

        private Color _borderColor = Color.Gray;
        [Browsable(true), Category(A1PanelGlobals.A1Category), DefaultValue("Color.Gray")]
        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        private Color _gradientStartColor = Color.White;
        [Browsable(true), Category(A1PanelGlobals.A1Category), DefaultValue("Color.White")]
        public Color GradientStartColor
        {
            get
            {
                return _gradientStartColor;
            }
            set
            {
                _gradientStartColor = value;
                Invalidate();
            }
        }

        private Color _gradientEndColor = Color.Gray;
        [Browsable(true), Category(A1PanelGlobals.A1Category), DefaultValue("Color.Gray")]
        public Color GradientEndColor
        {
            get
            {
                return _gradientEndColor;
            }
            set
            {
                _gradientEndColor = value;
                Invalidate();
            }
        }

        public HMIPanel()
        {
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            int tmpShadowOffSet = Math.Min(Math.Min(_shadowOffSet, this.Width - 2), this.Height - 2);
            int tmpSoundCornerRadius = Math.Min(Math.Min(_roundCornerRadius, this.Width - 2), this.Height - 2);
            if (this.Width > 1 && this.Height > 1)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                Rectangle rect = new Rectangle(0, 0, this.Width - tmpShadowOffSet - 1, this.Height - tmpShadowOffSet - 1);
                Rectangle rectShadow = new Rectangle(tmpShadowOffSet, tmpShadowOffSet, this.Width - tmpShadowOffSet - 1, this.Height - tmpShadowOffSet - 1);

                GraphicsPath graphPathShadow = PanelGraphics.GetRoundPath(rectShadow, tmpSoundCornerRadius);
                GraphicsPath graphPath = PanelGraphics.GetRoundPath(rect, tmpSoundCornerRadius);

                if (tmpSoundCornerRadius > 0)
                {
                    using (PathGradientBrush gBrush = new PathGradientBrush(graphPathShadow))
                    {
                        gBrush.WrapMode = WrapMode.Clamp;
                        ColorBlend colorBlend = new ColorBlend(3);
                        colorBlend.Colors = new Color[] { Color.Transparent, Color.FromArgb(180, Color.DimGray), Color.FromArgb(180, Color.DimGray) };

                        colorBlend.Positions = new float[] { 0.0F, 0.1F, 1.0F };

                        gBrush.InterpolationColors = colorBlend;
                        e.Graphics.FillPath(gBrush, graphPathShadow);
                    }
                }

                // Draw backgroup
                LinearGradientBrush brush = new LinearGradientBrush(rect, this._gradientStartColor, this._gradientEndColor, LinearGradientMode.BackwardDiagonal);
                e.Graphics.FillPath(brush, graphPath);
                e.Graphics.DrawPath(new Pen(Color.FromArgb(180, this._borderColor), _borderWidth), graphPath);

                // Draw Image
                if (_image != null)
                {
                    e.Graphics.DrawImageUnscaled(_image, _imageLocation);
                }
            }
        }
    }


}