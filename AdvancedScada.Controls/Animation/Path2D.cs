
namespace AdvancedScada.Controls.Animation
{
    public class Path2D
    {
        public Path HorizontalPath { get; set; }

        public Path VerticalPath { get; set; }

        public Float2D Start
        {
            get
            {
                return new Float2D(this.HorizontalPath.Start, this.VerticalPath.Start);
            }
        }

        public Float2D End
        {
            get
            {
                return new Float2D(this.HorizontalPath.End, this.VerticalPath.End);
            }
        }

        public Path2D(float startX, float endX, float startY, float endY, ulong duration, ulong delay, AnimationFunctions.Function function)
          : this(new Path(startX, endX, duration, delay, function), new Path(startY, endY, duration, delay, function))
        {
        }

        public Path2D(float startX, float endX, float startY, float endY, ulong duration, ulong delay)
          : this(new Path(startX, endX, duration, delay), new Path(startY, endY, duration, delay))
        {
        }

        public Path2D(float startX, float endX, float startY, float endY, ulong duration, AnimationFunctions.Function function)
          : this(new Path(startX, endX, duration, function), new Path(startY, endY, duration, function))
        {
        }

        public Path2D(float startX, float endX, float startY, float endY, ulong duration)
          : this(new Path(startX, endX, duration), new Path(startY, endY, duration))
        {
        }

        public Path2D(Float2D start, Float2D end, ulong duration, ulong delay, AnimationFunctions.Function function)
          : this(new Path(start.X, end.X, duration, delay, function), new Path(start.Y, end.Y, duration, delay, function))
        {
        }

        public Path2D(Float2D start, Float2D end, ulong duration, ulong delay)
          : this(new Path(start.X, end.X, duration, delay), new Path(start.Y, end.Y, duration, delay))
        {
        }

        public Path2D(Float2D start, Float2D end, ulong duration, AnimationFunctions.Function function)
          : this(new Path(start.X, end.X, duration, function), new Path(start.Y, end.Y, duration, function))
        {
        }

        public Path2D(Float2D start, Float2D end, ulong duration)
          : this(new Path(start.X, end.X, duration), new Path(start.Y, end.Y, duration))
        {
        }

        public Path2D(Path x, Path y)
        {
            this.HorizontalPath = x;
            this.VerticalPath = y;
            ////// ISSUE: reference to a compiler-generated field
            ////this.\u003CHorizontalPath\u003Ek__BackingField = x;
            ////// ISSUE: reference to a compiler-generated field
            ////this.\u003CVerticalPath\u003Ek__BackingField = y;
        }

        public Path2D Reverse()
        {
            return new Path2D(this.HorizontalPath.Reverse(), this.VerticalPath.Reverse());
        }
    }
}
