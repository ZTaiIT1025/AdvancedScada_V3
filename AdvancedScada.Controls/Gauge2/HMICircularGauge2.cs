using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace AdvancedScada.Controls.Gauge2
{
    public partial class HMICircularGauge2 : UserControl
    {
        #region Private Attributes
        private float minValue;
        private float maxValue;
        private float threshold;
        private float currentValue;
        private float recommendedValue;
        private int noOfDivisions;
        private int noOfSubDivisions;
        private string dialText;
        private Color dialColor = Color.Lavender;
        private float glossinessAlpha = 25;
        private int oldWidth, oldHeight;
        int x, y, width, height;
        float fromAngle = 135F;
        float toAngle = 405F;
        private bool enableTransparentBackground;
        private bool requiresRedraw;
        private Image backgroundImg;
        private Rectangle rectImg;
        #endregion

        public HMICircularGauge2()
        {
            InitializeComponent();
            x = 5;
            y = 5;
            width = this.Width - 10;
            height = this.Height - 10;
            this.noOfDivisions = 10;
            this.noOfSubDivisions = 3;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.BackColor = Color.Transparent;
            //  this.Resize += new EventHandler(AquaGauge_Resize);
            this.requiresRedraw = true;
        }

        #region Public Properties
        /// <summary>
        /// Mininum value on the scale
        /// </summary>
        [DefaultValue(0)]
        [Description("Messaoud, Mininum value on the scale")]
        public float MinValue
        {
            get { return minValue; }
            set
            {
                if (value < maxValue)
                {
                    minValue = value;
                    if (currentValue < minValue)
                        currentValue = minValue;
                    if (recommendedValue < minValue)
                        recommendedValue = minValue;
                    requiresRedraw = true;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Maximum value on the scale
        /// </summary>
        [DefaultValue(100)]
        [Description("Messaoud, Maximum value on the scale")]
        public float MaxValue
        {
            get { return maxValue; }
            set
            {
                if (value > minValue)
                {
                    maxValue = value;
                    if (currentValue > maxValue)
                        currentValue = maxValue;
                    if (recommendedValue > maxValue)
                        recommendedValue = maxValue;
                    requiresRedraw = true;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or Sets the Threshold area from the Recommended Value. (1-99%)
        /// </summary>
        [DefaultValue(25)]
        [Description("Gets or Sets the Threshold area from the Recommended Value. (1-99%)")]
        public float ThresholdPercent
        {
            get { return threshold; }
            set
            {
                if (value > 0 && value < 100)
                {
                    threshold = value;
                    requiresRedraw = true;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Threshold value from which green area will be marked.
        /// </summary>
        [DefaultValue(25)]
        [Description("Threshold value from which green area will be marked.")]
        public float RecommendedValue
        {
            get { return recommendedValue; }
            set
            {
                if (value > minValue && value < maxValue)
                {
                    recommendedValue = value;
                    requiresRedraw = true;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Value where the pointer will point to.
        /// </summary>
        [DefaultValue(0)]
        [Description("Messaoud, Value where the pointer will point to.")]
        public float Value
        {
            get { return currentValue; }
            set
            {
                if (value >= minValue && value <= maxValue)
                {
                    currentValue = value;
                    this.Refresh();
                }
            }
        }

        /// <summary>
        /// Background color of the dial
        /// </summary>
        [Description("Background color of the dial")]
        public Color DialColor
        {
            get { return dialColor; }
            set
            {
                dialColor = value;
                requiresRedraw = true;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Glossiness strength. Range: 0-100
        /// </summary>
        [DefaultValue(72)]
        [Description("Glossiness strength. Range: 0-100")]
        public float Glossiness
        {
            get
            {
                return (glossinessAlpha * 100) / 220;
            }
            set
            {
                float val = value;
                if (val > 100)
                    value = 100;
                if (val < 0)
                    value = 0;
                glossinessAlpha = (value * 220) / 100;
                this.Refresh();
            }
        }

        /// <summary>
        /// Get or Sets the number of Divisions in the dial scale.
        /// </summary>
        [DefaultValue(10)]
        [Description("Get or Sets the number of Divisions in the dial scale.")]
        public int NoOfDivisions
        {
            get { return this.noOfDivisions; }
            set
            {
                if (value > 1 && value < 25)
                {
                    this.noOfDivisions = value;
                    requiresRedraw = true;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or Sets the number of Sub Divisions in the scale per Division.
        /// </summary>
        [DefaultValue(3)]
        [Description("Gets or Sets the number of Sub Divisions in the scale per Division.")]
        public int NoOfSubDivisions
        {
            get { return this.noOfSubDivisions; }
            set
            {
                if (value > 0 && value <= 10)
                {
                    this.noOfSubDivisions = value;
                    requiresRedraw = true;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or Sets the Text to be displayed in the dial
        /// </summary>
        [Description("Gets or Sets the Text to be displayed in the dial")]
        public string DialText
        {
            get { return this.dialText; }
            set
            {
                this.dialText = value;
                requiresRedraw = true;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Enables or Disables Transparent Background color.
        /// Note: Enabling this will reduce the performance and may make the control flicker.
        /// </summary>
        [DefaultValue(false)]
        [Description("Enables or Disables Transparent Background color. Note: Enabling this will reduce the performance and may make the control flicker.")]
        public bool EnableTransparentBackground
        {
            get { return this.enableTransparentBackground; }
            set
            {
                this.enableTransparentBackground = value;
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer, !enableTransparentBackground);
                requiresRedraw = true;
                this.Refresh();
            }
        }
        #endregion

        #region Overriden Control methods
        /// <summary>
        /// Draws the pointer.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; // lissage des graphiques
            dessinAiguille(e);
            dessinBrillance(e);

        }

        /// <summary>
        /// Draws the dial background.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (!enableTransparentBackground)
            {
                base.OnPaintBackground(e);

            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; // lissage des graphiques


            dessinFond(e);
            dessinCadre(e);
            dessinGraduations(e);


        }
        private void dessinFond(PaintEventArgs e)
        {
            //dessin du background  
            Color couleurFond = Color.FromArgb(255, Color.Lavender);
            e.Graphics.FillPie(new SolidBrush(couleurFond), new Rectangle(0, 0, 400, 400), 0, 380);

        }

        private void dessinCadre(PaintEventArgs e)
        {

            // dessin du cadre 

            LinearGradientBrush linGrBrush = new LinearGradientBrush(
             new Point(400, 40),
             new Point(0, 40),
             Color.Black,   // couleur foncée 
             Color.FromArgb(80, 77, 80, 86));  // couleur claire

            Pen pen1 = new Pen(linGrBrush, 23);

            Color couleur1 = Color.FromArgb(112, 77, 80, 86);
            Pen pen2 = new Pen(Color.FromArgb(60, couleur1), 30);
            int largeur = 400;
            int x;// valeur de la translation
            x = 12;
            e.Graphics.DrawArc(pen1, new Rectangle(x, x, ((largeur / 2) - x) * 2, ((largeur / 2) - x) * 2), 0, 380);
            x = 15;
            e.Graphics.DrawArc(pen2, new Rectangle(x, x, ((largeur / 2) - x) * 2, ((largeur / 2) - x) * 2), 0, 380);



        }
        private void dessinGraduations(PaintEventArgs e)
        {
            int largeur = 400;
            // pinceaux 
            Color couleur1 = Color.FromArgb(140, Color.Black);
            Color couleur2 = Color.FromArgb(200, Color.Black);
            Pen blackPen = new Pen(couleur1, this.Width / 200);
            Pen thickPen = new Pen(Color.Black, largeur / 50);
            Pen thinPen = new Pen(couleur1, largeur / 100);
            SolidBrush drawBrush1 = new SolidBrush(couleur1);
            SolidBrush drawBrush2 = new SolidBrush(couleur2);

            x = 100; y = 100;

            float a, b, x1, y1, x2, y2, radius;
            a = 200;
            b = 200;                           // a et b coordonée du centre 
            radius = 100;                      // rayon du cercle du milieu 
            float sweep = 4.71238898F;         // angle de balayage sur le cadran en radian (270 degree)
            float angleCourrant = 2.35619449F; // angle de depart ( 135 degree)
            int nbg = 5;                      // nombre de graduations 
            float incrt = sweep / nbg;        // angle entre deux graduations 
            float valeurGraduation = this.MinValue;
            float incrtGraduation = (MaxValue - MinValue) / 5;
            for (int i = 0; i <= nbg; i++)
            {
                x1 = (float)(a + radius * Math.Cos(angleCourrant));
                y1 = (float)(b + radius * Math.Sin(angleCourrant));
                x2 = (float)(a + (radius - 16) * Math.Cos(angleCourrant));
                y2 = (float)(b + (radius - 16) * Math.Sin(angleCourrant));

                e.Graphics.DrawLine(thinPen, x1, y1, x2, y2);

                Debug.WriteLine(" -- angle:" + angleCourrant + " x: " + x1 + " y: " + y1);

                // dessin des valeurs des graduations 
                x1 = (float)(a + (radius + 30) * Math.Cos(angleCourrant));
                y1 = (float)(b - 16 + (radius + 30) * Math.Sin(angleCourrant));
                Debug.WriteLine("-- dessin des valeurs x2: " + x1 + " y2: " + y1);
                Font drawFont = new Font(this.Font.FontFamily, 25.0F, FontStyle.Bold);

                // dessin des chiffres du cadran 
                StringFormat drawFormat = new StringFormat(StringFormatFlags.NoClip);
                drawFormat.Alignment = StringAlignment.Center;
                e.Graphics.DrawString(valeurGraduation + string.Empty, drawFont, drawBrush2, new PointF(x1, y1), drawFormat);
                valeurGraduation += incrtGraduation;

                // dessin des graduations intermediaires 
                float tempAngle = angleCourrant, tempIncrt = incrt / 4;
                int x3, y3, x4, y4;
                if (i != nbg)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        tempAngle += tempIncrt;

                        if ((j % 2) == 0)
                        {
                            x3 = (int)(a + (radius - 8) * Math.Cos(tempAngle));
                            y3 = (int)(b + (radius - 8) * Math.Sin(tempAngle));
                            e.Graphics.FillPie(drawBrush1, new Rectangle(x3 - 3, y3 - 3, 4, 4), 0, 380);
                        }
                        else
                        {
                            x3 = (int)(a + (radius - 3) * Math.Cos(tempAngle));
                            y3 = (int)(b + (radius - 3) * Math.Sin(tempAngle));
                            x4 = (int)(a + (radius - 13) * Math.Cos(tempAngle));
                            y4 = (int)(b + (radius - 13) * Math.Sin(tempAngle));
                            e.Graphics.DrawLine(blackPen, x3, y3, x4, y4);
                        }
                    }
                }

                angleCourrant += incrt;
            }

        }
        private void dessinAiguille(PaintEventArgs e)
        {
            PointF[] pts = new PointF[3];
            float angleCourant, angle1, angle2, angle3, radius;

            // dessin du point du centre 
            int a = 200, b = 200, shift = 7;  // coordonnées centre et decalage

            Rectangle rCentre = new Rectangle(a - shift, b - shift, shift * 2, shift * 2);
            SolidBrush brush = new SolidBrush(Color.Red);
            e.Graphics.FillEllipse(new SolidBrush(Color.Red), rCentre);


            //calcul de l'angle correspondant à la valeur courante
            float sweep = 270, angleMin = 135, valMax = this.MaxValue;
            angleCourant = (sweep * Value) / valMax + angleMin;

            // dessin d'un triangle 
            // calcul des coordonnées du triangle

            angle1 = GetRadian(angleCourant);
            angle2 = GetRadian(angleCourant - 90);
            angle3 = GetRadian(angleCourant - 270);
            radius = 150;

            float x1 = (float)(a + radius * Math.Cos(angle1));
            float y1 = (float)(b + radius * Math.Sin(angle1));
            float x2 = (float)(a + shift * Math.Cos(angle2));
            float y2 = (float)(b + shift * Math.Sin(angle2));
            float x3 = (float)(a + shift * Math.Cos(angle3));
            float y3 = (float)(b + shift * Math.Sin(angle3));

            pts[0] = new PointF(x1, y1);
            pts[1] = new PointF(x2, y2);
            pts[2] = new PointF(x3, y3);

            e.Graphics.FillPolygon(brush, pts);
        }

        private void dessinBrillance(PaintEventArgs e)
        {

            // effet vitre 
            float largeurCanvas = 400, largeurRect = 180, hauteurRect = 90;
            float x1 = (largeurCanvas / 2) - (largeurRect / 2);
            float y1 = (largeurCanvas / 2) - (largeurCanvas / 3);
            RectangleF glossRect = new RectangleF(x1, y1, largeurRect, hauteurRect);
            Debug.WriteLine(" x1: " + x1 + " y1: " + y1);
            LinearGradientBrush gradientBrush =
                new LinearGradientBrush(glossRect,
                Color.FromArgb(190, Color.White),
                Color.Transparent,
                LinearGradientMode.Vertical);
            e.Graphics.FillEllipse(gradientBrush, glossRect);


            // effet lumiere sur le coté 

            LinearGradientBrush linGrBrush = new LinearGradientBrush(
            new Point(400, 10),
            new Point(0, 10),
            Color.FromArgb(160, 30, 30, 30),
            Color.FromArgb(60, 240, 255, 255));

            Pen pen = new Pen(linGrBrush);
            linGrBrush.GammaCorrection = true;

            e.Graphics.FillPie(linGrBrush, new Rectangle(30, 30, 340, 340), 0, 380);
        }



        public float GetRadian(float theta)
        {
            return theta * (float)Math.PI / 180F;
        }
        #endregion

    }
}
