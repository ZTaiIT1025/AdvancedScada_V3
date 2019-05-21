using System.Drawing;
using System.Drawing.Drawing2D;

namespace AdvancedScada.Controls.TankAll
{
    #region Wll Side Enumeration.

    /// <summary>
    ///     Wall Side
    /// </summary>
    public enum WallSide
    {
        /// <summary>
        ///     Left
        /// </summary>
        Left,

        /// <summary>
        ///     Right
        /// </summary>
        Right,

        /// <summary>
        ///     Top
        /// </summary>
        Top,

        /// <summary>
        ///     Bottom
        /// </summary>
        Bottom,

        /// <summary>
        ///     Back
        /// </summary>
        Back,

        /// <summary>
        ///     Front
        /// </summary>
        Front
    }

    #endregion

    /// <summary>
    ///     Summary description for DrawingUtils.
    /// </summary>
    public class DrawingUtils
    {
        #region Static Method.


        public static void FillCylinder(Graphics g, RectangleF front, SizeF depth, Color fillColor, Color borderColor,
            bool outLine)
        {
            if (front.Width <= 0 || front.Height <= 0)
                return;

            // Make Back Side Area
            var aback = front;

            // Make Depth
            aback.X += depth.Width;
            aback.Y -= depth.Height;

            // Create Top and Bottom Plane.
            RectangleF bottomPlane;
            RectangleF topPlane;

            // Create Graphics Object
            var gp = new GraphicsPath();

            topPlane = new RectangleF((front.X + aback.X) / 4, aback.Location.Y, front.Width, front.Y - aback.Y);

            bottomPlane = new RectangleF(new PointF((front.X + aback.X) / 4, aback.Bottom + 7),
                new SizeF(front.Width, front.Y - aback.Y + 4));

            // Brush
            var brush = new SolidBrush(fillColor);

            // Border Pen
            var borderPen = new Pen(borderColor);

            /***************
             *   Bottom    *
             * ************/
            // Make GP On Bottom
            //gp.AddEllipse(bottomPlane);

            // Get Bottom color
            brush.Color = GetSideColor(fillColor, WallSide.Bottom);

            // Fill Bottom Plane
            g.FillPath(brush, gp);

            // Check Draw Border
            if (outLine)
                g.DrawPath(borderPen, gp);

            gp.Reset();
            gp.AddArc(topPlane, 0, 180);
            gp.AddLine(gp.GetLastPoint(), new PointF((front.X + aback.X) / 4, (front.Bottom + aback.Bottom) / 2.0f));

            gp.AddArc(bottomPlane, 180, -180);
            gp.CloseFigure();

            /***************
             *     Body    *
             * ************/
            // Color For Body is real Fill Color.
            brush.Color = fillColor;

            // Fill Body
            g.FillPath(brush, gp);

            // Shadow of the Body
            FillCylinderShadow(g, front, gp, false);

            // Check Draw Border
            if (outLine)
                g.DrawPath(borderPen, gp);

            /***************
			 *     Top     *
			 * ************/
            gp.Reset();
            gp.AddEllipse(topPlane);

            // Get Bottom color
            brush.Color = GetSideColor(fillColor, WallSide.Top);

            // Fill Top Plane
            g.FillPath(brush, gp);

            // Check Draw Border
            if (outLine)
                g.DrawPath(borderPen, gp);

            // Dispose
            gp.Dispose();
            brush.Dispose();
            borderPen.Dispose();
        } //End Method Fill

        /// <summary>
        ///     Draw the Shadow for Cylinder.
        /// </summary>
        /// <param name="g">Graphics Object</param>
        /// <param name="bound">Front Bound</param>
        /// <param name="gp">Graphics Path</param>
        /// <param name="horizontal">Indicated use draw Horionzotal</param>
        public static void FillCylinderShadow(Graphics g, RectangleF bound, GraphicsPath gp, bool horizontal)
        {
            var angle = -180.0f;

            if (horizontal)
                angle = -90.0f;

            var linGrBrush = new LinearGradientBrush(
                bound,
                Color.FromArgb(100, 128, 128, 128), // Opaque black 
                Color.FromArgb(100, Color.White),
                angle); // Opaque red

            linGrBrush.SetSigmaBellShape(0.70f);

            g.FillPath(linGrBrush, gp);

            linGrBrush.Dispose();
        } //end Method FillCylinderShadow

        /// <summary>
        ///     Get Side Color
        /// </summary>
        /// <param name="color"></param>
        /// <param name="side"></param>
        /// <returns>Color</returns>
        public static Color GetSideColor(Color color, WallSide side)
        {
            var bright = 1.0f;

            var a = color.A;
            var r = color.R;
            var g = color.G;
            var b = color.B;

            switch (side)
            {
                case WallSide.Back:
                    {
                        bright = 1.0f;
                        break;
                    }

                case WallSide.Front:
                    {
                        bright = 1.0f;
                        break;
                    }

                case WallSide.Left:
                    {
                        bright = 0.7f;
                        break;
                    }

                case WallSide.Right:
                    {
                        bright = 0.5f;
                        break;
                    }

                case WallSide.Top:
                    {
                        bright = 0.8f;
                        break;
                    }

                case WallSide.Bottom:
                    {
                        bright = 0.4f;
                        break;
                    }
            } //end swithc case

            r = (byte)(r / 2 + r * bright / 2);
            g = (byte)(g / 2 + g * bright / 2);
            b = (byte)(b / 2 + b * bright / 2);

            return Color.FromArgb(a, r, g, b);
        }

        public static void elipse(Graphics g, RectangleF front, SizeF depth, Color fillColor, Color borderColor,
            bool outLine)
        {
            if (front.Width <= 0 || front.Height <= 0)
                return;

            // Make Back Side Area
            var aback = front;

            // Make Depth
            aback.X += depth.Width;
            aback.Y -= depth.Height;

            // Create Top and Bottom Plane.
            //   RectangleF bottomPlane;
            RectangleF topPlane;

            // Create Graphics Object
            var gp = new GraphicsPath();

            topPlane = new RectangleF((front.X + aback.X) / 4, aback.Location.Y, front.Width, front.Y - aback.Y);

            // Brush
            var brush = new SolidBrush(fillColor);

            // Border Pen
            var borderPen = new Pen(borderColor);


            /***************
             *     Body    *
             * ************/
            // Color For Body is real Fill Color.
            brush.Color = fillColor;

            // Fill Body
            g.FillPath(brush, gp);

            // Shadow of the Body
            FillCylinderShadow(g, front, gp, false);
            gp.Reset();
            gp.AddEllipse(topPlane);

            // Get Bottom color
            brush.Color = GetSideColor(fillColor, WallSide.Top);

            // Fill Top Plane
            g.FillPath(brush, gp);

            // Check Draw Border
            if (outLine)
                g.DrawPath(borderPen, gp);

            // Dispose
            gp.Dispose();
            brush.Dispose();
            borderPen.Dispose();
        }

        #endregion
    }
}
