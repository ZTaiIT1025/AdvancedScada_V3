
using AdvancedScada;
using AdvancedScada.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;

using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Class
{
    public class RollingDigit : IDisposable
    {
        //* This class has some disposable objects, so we must implement IDisposable to clean up
        private System.Drawing.Bitmap[] DigitDrawings = new System.Drawing.Bitmap[10];
        private bool disposedValue; // To detect redundant calls

        #region Constructor
        public RollingDigit()
        {

        }

        // IDisposable - clean up DigitDrawings because they are disposable
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    for (var i = 0; i < DigitDrawings.Length; i++)
                    {
                        if (DigitDrawings[i] != null)
                        {
                            DigitDrawings[i].Dispose();
                        }
                    }

                    if (m_Font != null)
                    {
                        m_Font.Dispose();
                    }
                }
            }
            disposedValue = true;
        }


        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

        #region Properties
        private double m_Value;
        public double Value
        {
            get
            {
                return m_Value;
            }
            set
            {
                if (value != m_Value)
                {
                    //* Constrain the value withing a single digit
                    m_Value = Math.Max(value, 0);
                    m_Value = Math.Min(m_Value, 9.999999999);
                }
            }
        }

        private Font m_Font = new Font("Arial", 8);
        public Font Font
        {
            get
            {
                return m_Font;
            }
            set
            {
                m_Font = value;
                CreateDigitImages();
            }
        }

        private Color m_BackColor = Color.White;
        public Color BackColor
        {
            get
            {
                return m_BackColor;
            }
            set
            {
                if (value != m_BackColor)
                {
                    m_BackColor = value;
                    CreateDigitImages();
                }
            }
        }

        private Color m_ForeColor = Color.Black;
        public Color ForeColor
        {
            get
            {
                return m_ForeColor;
            }
            set
            {
                if (value != m_ForeColor)
                {
                    m_ForeColor = value;
                    CreateDigitImages();
                }
            }
        }

        private int m_Width;
        public int Width
        {
            get
            {
                return m_Width;
            }
            set
            {
                if (value != m_Width)
                {
                    m_Width = value;
                    CreateDigitImages();
                }
            }
        }

        private int m_Height;
        public int Height
        {
            get
            {
                return m_Height;
            }
            set
            {
                if (value != m_Height)
                {
                    m_Height = value;
                    CreateDigitImages();
                }
            }
        }
        #endregion

        #region Private Methods
        private void CreateDigitImages()
        {
            //* Make sure it has a valid size
            if (m_Width > 0 && m_Height > 0)
            {
                Font f = new Font(m_Font.FontFamily, 1, FontStyle.Regular, GraphicsUnit.Pixel);

                //* Search for the font size that fits the best
                SizeF TextSize = new SizeF();
                while (TextSize.Width < m_Width && TextSize.Height < m_Height)
                {
                    TextSize = TextRenderer.MeasureText("0", f);
                    //* Increment the text size
                    f = new Font(m_Font.FontFamily, f.Size + 1, FontStyle.Regular, GraphicsUnit.Pixel);
                }

                //* The loop will exceed the size, so reduce it by one step
                f = new Font(m_Font.FontFamily, f.Size - 1, FontStyle.Regular, GraphicsUnit.Pixel);
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                for (var Index = 0; Index <= 9; Index++)
                {
                    DigitDrawings[Index] = new Bitmap(m_Width, m_Height);
                    Graphics g = Graphics.FromImage(DigitDrawings[Index]);

                    //* Improve the quality of the text
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                    //* Draw the Text in the center of the DigitDrawing
                    g.DrawString(Convert.ToString(Index), f, new SolidBrush(m_ForeColor), (float)(DigitDrawings[Index].Width / 2.0), (float)(DigitDrawings[Index].Height / 2.0), sf);

                    //* Draw a separting vertical line
                    g.DrawLine(Pens.DarkGray, 0, 0, 0, m_Height);
                }
            }
        }
        #endregion

        public void Draw(Graphics g, int offsetX, int offsetY)
        {
            if (m_Width > 0 && m_Height > 0)
            {
                //* Fill with the backcolor
                //g.Clear(m_BackColor)
                g.FillRectangle(new SolidBrush(m_BackColor), offsetX, offsetY, this.Width, this.Height);

                //* Find the lowest digit in display
                int LowDigit = Convert.ToInt32(Math.Floor(m_Value));


                double PercentOfRoll = m_Value - LowDigit;
                int RollOffsetPosition = Convert.ToInt32(m_Height * PercentOfRoll);

                if ((DigitDrawings[LowDigit]) == null)
                {
                    CreateDigitImages();
                }

                //* Give the effect of rolling over the arc
                double ImageHeightCompress = this.Height;
                if (PercentOfRoll > 0)
                {
                    ImageHeightCompress = (1 - PercentOfRoll * 0.5) * this.Height;
                }

                //* Draw the digit that is rolling off the top
                g.DrawImage(DigitDrawings[LowDigit], offsetX, Convert.ToInt32(0 - RollOffsetPosition + (this.Height - ImageHeightCompress)), this.Width, Convert.ToInt32(ImageHeightCompress));

                //* Draw the next digit coming up
                if (RollOffsetPosition > 0)
                {
                    int NextDigit = LowDigit + 1;
                    if (NextDigit >= 10)
                    {
                        NextDigit = 0;
                    }
                    if (PercentOfRoll > 0)
                    {
                        ImageHeightCompress = Math.Min(this.Height, (PercentOfRoll * 1.75) * this.Height);
                    }
                    g.DrawImage(DigitDrawings[NextDigit], offsetX, 0 + m_Height - RollOffsetPosition, this.Width, Convert.ToInt32(ImageHeightCompress));
                }

                //* Overlay a shadow to give depth
                System.Drawing.Drawing2D.LinearGradientBrush gb = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, m_Height, m_Width), Color.Black, Color.Black, 0, false);
                System.Drawing.Drawing2D.ColorBlend cb = new System.Drawing.Drawing2D.ColorBlend();
                cb.Positions = new float[] { 0, 0.15F, 0.4F, 0.75F, 1.0F };
                cb.Colors = new Color[] { Color.FromArgb(144, 0, 0, 0), Color.FromArgb(64, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(64, 0, 0, 0), Color.FromArgb(240, 0, 0, 0) };
                gb.RotateTransform(90);
                gb.InterpolationColors = cb;

                g.FillRectangle(gb, offsetX, offsetY, this.Width, this.Height);
            }
        }


        public static System.Drawing.Color GetRelativeColor(System.Drawing.Color color, double intensity, int alpha)
        {
            intensity = Math.Max(intensity, 0);

            System.Drawing.Color c = System.Drawing.Color.FromArgb(alpha, Convert.ToInt32(Math.Min((color.R + 1) * intensity, 255)), Convert.ToInt32(Math.Min((color.G + 1) * intensity, 255)), Convert.ToInt32(Math.Min((color.B + 1) * intensity, 255)));

            return c;
        }
    }


}