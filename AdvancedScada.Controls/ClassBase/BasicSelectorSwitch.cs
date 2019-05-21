using AdvancedScada;
using AdvancedScada.Controls;
using AdvancedScada.Controls.Motor;
using AdvancedScada.Controls.SelectorSwitch;
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

namespace AdvancedScada.Controls.ClassBase
{
    [ToolboxItem(false)]
    public class BasicSelectorSwitch : ButtonBase
    {
        private OutputType m_OutputType;

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

        public BasicSelectorSwitch()
        {

            this.m_OutputType = OutputType.MomentarySet;
        }

        protected override void AdjustSize()
        {
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (this.Enabled)
            {
                if (this.m_OutputType == OutputType.Toggle)
                {
                    this.m_Value = !this.m_Value;
                }
                this.Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (this.Enabled)
            {
                this.Invalidate();
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            if (!(this.BackBuffer == null || this.OnImage == null))
            {
                Graphics g = Graphics.FromImage(this.BackBuffer);
                if (!this.m_Value)
                {
                    g.DrawImage(this.OffImage, 0, 0);
                }
                else
                {
                    g.DrawImage(this.OnImage, 0, 0);
                }
                e.Graphics.DrawImage(this.BackBuffer, 0, 0);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        protected override void CreateStaticImage()
        {
            if (!(this.Width <= 0 || this.Height <= 0))
            {
                int num = Math.Max(this.Width, this.Height);
                Bitmap bitmap = new Bitmap(num, num);
                Graphics g = Graphics.FromImage(bitmap);
                Matrix matrix = new Matrix();
                PointF pointF = new PointF((float)this.Width / 2.0F, (float)this.Height / 2.0F);
                matrix.RotateAt(-25.0F, pointF);
                g.Transform = matrix;
                g.FillRectangle(Brushes.DarkGray, Convert.ToInt32((double)this.Width / 2 - (double)this.Width * 0.1), Convert.ToInt32((double)this.Height * 0.1), Convert.ToInt32((double)this.Width * 0.2), Convert.ToInt32((double)this.Height * 0.8));
                g.DrawRectangle(Pens.Red, 0, 0, num - 1, num - 1);
                this.OffImage = new Bitmap(this.Width, this.Height);
                this.OnImage = new Bitmap(this.Width, this.Height);
                Graphics gr_dest = Graphics.FromImage(this.OffImage);
                Graphics gr_dest2 = Graphics.FromImage(this.OnImage);
                gr_dest.FillEllipse(Brushes.Gray, 0, 0, this.Width - 1, this.Height - 1);
                gr_dest.DrawEllipse(Pens.White, 0, 0, this.Width - 1, this.Height - 1);
                gr_dest.DrawImage(bitmap, 0, 0, this.Width, this.Height);
                gr_dest.Dispose();
                gr_dest2.Dispose();
                if (this.BackBuffer != null)
                {
                    this.BackBuffer.Dispose();
                }
                this.BackBuffer = new Bitmap(this.Width, this.Height);
                this.Invalidate();
            }
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Invalidate();
        }

    }


}