
using System.Drawing;

namespace AdvancedScada.Controls.Animation
{
    public static class FloatExtensions
    {
        public static Float2D ToFloat2D(this Point point)
        {
            return Float2D.FromPoint(point);
        }

        public static Float2D ToFloat2D(this PointF point)
        {
            return Float2D.FromPoint(point);
        }

        public static Float2D ToFloat2D(this Size size)
        {
            return Float2D.FromSize(size);
        }

        public static Float2D ToFloat2D(this SizeF size)
        {
            return Float2D.FromSize(size);
        }

        public static Float3D ToFloat3D(this Color color)
        {
            return Float3D.FromColor(color);
        }
    }
}
