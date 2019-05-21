
using AdvancedScada;
using AdvancedScada;
using AdvancedScada.Controls;
using AdvancedScada.Controls;
using AdvancedScada.Controls.Class;
using AdvancedScada.Controls.Class;
using System;
using System.Collections;

using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvancedScada.Controls.ImageAll
{
    public class HMIAnimatingPictureBox : PictureBox
    {


        private RotationScale m_ImageRotationScale;

        private float m_ImageRotationValue;

        private TranslationScale m_ImageTranslateXScale;

        private int m_ImageTranslateXValue;

        private TranslationScale m_ImageTranslateYScale;

        private int m_ImageTranslateYValue;

        private TranslationScale m_ImageSizeXScale;

        private double m_ImageSizeXValue;

        private TranslationScale m_ImageSizeYScale;

        private double m_ImageSizeYValue;

        private Bitmap rotatedBmp;

        private Matrix m;

        private Rectangle r;

        public RotationScale ImageRotationScale
        {
            get
            {
                return m_ImageRotationScale;
            }
            set
            {
                m_ImageRotationScale = value;
            }
        }

        public float ImageRotationValue
        {
            get
            {
                return m_ImageRotationValue;
            }
            set
            {
                if (m_ImageRotationValue != value)
                {
                    m_ImageRotationValue = value;
                    UpdateImage();
                }
            }
        }

        public TranslationScale ImageSizeXScale
        {
            get
            {
                return m_ImageSizeXScale;
            }
            set
            {
                m_ImageSizeXScale = value;
            }
        }

        public double ImageSizeXValue
        {
            get
            {
                return m_ImageSizeXValue;
            }
            set
            {
                if (m_ImageSizeXValue != value)
                {
                    m_ImageSizeXValue = value;
                    UpdateImage();
                }
            }
        }

        public TranslationScale ImageSizeYScale
        {
            get
            {
                return m_ImageSizeYScale;
            }
            set
            {
                m_ImageSizeYScale = value;
            }
        }

        public double ImageSizeYValue
        {
            get
            {
                return m_ImageSizeYValue;
            }
            set
            {
                if (m_ImageSizeYValue != value)
                {
                    m_ImageSizeYValue = value;
                    UpdateImage();
                }
            }
        }

        public TranslationScale ImageTranslateXScale
        {
            get
            {
                return m_ImageTranslateXScale;
            }
            set
            {
                m_ImageTranslateXScale = value;
            }
        }

        public int ImageTranslateXValue
        {
            get
            {
                return m_ImageTranslateXValue;
            }
            set
            {
                if (m_ImageTranslateXValue != value)
                {
                    m_ImageTranslateXValue = value;
                    UpdateImage();
                }
            }
        }

        public TranslationScale ImageTranslateYScale
        {
            get
            {
                return m_ImageTranslateYScale;
            }
            set
            {
                m_ImageTranslateYScale = value;
            }
        }

        public int ImageTranslateYValue
        {
            get
            {
                return m_ImageTranslateYValue;
            }
            set
            {
                if (m_ImageTranslateYValue != value)
                {
                    m_ImageTranslateYValue = value;
                    UpdateImage();
                }
            }
        }



        public HMIAnimatingPictureBox()
        {

            m_ImageRotationScale = new RotationScale();
            m_ImageTranslateXScale = new TranslationScale();
            m_ImageTranslateYScale = new TranslationScale();
            m_ImageSizeXValue = 1;
            m_ImageSizeYValue = 1;
            m = new Matrix();
            BackColor = Color.Transparent;
            BackgroundImageLayout = ImageLayout.Stretch;
            m_ImageSizeXScale = new TranslationScale()
            {
                InputMaxValue = 1,
                OutputMaxValue = 1,
                ErrorValue = 1
            };
            m_ImageSizeYScale = new TranslationScale()
            {
                InputMaxValue = 1,
                OutputMaxValue = 1,
                ErrorValue = 1
            };
        }



        protected override void OnPaint(PaintEventArgs pe)
        {
            Rectangle rectangle = new Rectangle();
            try
            {
                if ((Image == null || rotatedBmp != null && !(r == rectangle)) ? false : true)
                {
                    UpdateImage();
                }
                if ((rotatedBmp == null || !(r != rectangle)) ? false : true)
                {
                    pe.Graphics.DrawImage(rotatedBmp, r);
                }
            }
            catch
            {

            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            UpdateImage();
            base.OnSizeChanged(e);
        }

        private void UpdateImage()
        {
            int num = 0;
            int num1 = 0;
            bool flag = false;
            if (Image != null)
            {
                if (rotatedBmp != null && rotatedBmp.Width == Image.Width)
                {
                    if (rotatedBmp.Height != Image.Height)
                    {
                        goto Label1;
                    }
                    flag = false;
                    goto Label0;
                }
            Label1:
                flag = true;
            Label0:
                if (flag)
                {
                    rotatedBmp = new Bitmap(Width, Height);
                    rotatedBmp.SetResolution(Image.HorizontalResolution, Image.VerticalResolution);
                }
                if (m_ImageTranslateXScale != null)
                {
                    num = Convert.ToInt32(Math.Truncate(Math.Round(m_ImageTranslateXScale.GetValue((double)m_ImageTranslateXValue))));
                }
                if (m_ImageTranslateYScale != null)
                {
                    num1 = Convert.ToInt32(Math.Truncate(Math.Round(m_ImageTranslateXScale.GetValue((double)m_ImageTranslateYValue))));
                }
                r = new Rectangle(0, 0, Width, Height);
                using (Graphics g = Graphics.FromImage(rotatedBmp))
                {
                    m.Reset();
                    g.Clear(Color.Transparent);
                    double value = m_ImageSizeXScale.GetValue(m_ImageSizeXValue);
                    double value1 = m_ImageSizeYScale.GetValue(m_ImageSizeYValue);
                    if (value == 0)
                    {
                        value = 1;
                    }
                    if (value1 == 0)
                    {
                        value1 = 1;
                    }
                    Matrix matrix = m;
                    float angle = ImageRotationScale.GetAngle(m_ImageRotationValue);
                    Point point = new Point(Convert.ToInt32(Math.Truncate(Math.Round((double)Width / 2 + (double)ImageRotationScale.XPosition * value + (double)num * value))), Convert.ToInt32(Math.Truncate(Math.Round((double)Height / 2 + (double)ImageRotationScale.YPosition * value1 + (double)num1 * value1))));
                    matrix.RotateAt(angle, point);
                    m.Translate((float)(((double)Width - (double)Image.Width * value) / 2), (float)(((double)Height - (double)Image.Height * value1) / 2));
                    m.Scale((float)value, (float)value1);
                    g.Transform = m;
                    System.Drawing.Image image_Renamed = Image;
                    point = new Point(num, num1);
                    g.DrawImage(image_Renamed, point);
                }
            }
            Invalidate();
        }
    }


}