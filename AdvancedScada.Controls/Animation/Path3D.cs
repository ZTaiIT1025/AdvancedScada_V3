
namespace AdvancedScada.Controls.Animation
{
    public class Path3D
    {
        public Path HorizontalPath { get; set; }

        public Path VerticalPath { get; set; }

        public Path DepthPath { get; set; }

        public Float3D Start
        {
            get
            {
                return new Float3D(this.HorizontalPath.Start, this.VerticalPath.Start, this.DepthPath.Start);
            }
        }

        public Float3D End
        {
            get
            {
                return new Float3D(this.HorizontalPath.End, this.VerticalPath.End, this.DepthPath.End);
            }
        }

        public Path3D(float startX, float endX, float startY, float endY, float startZ, float endZ, ulong duration, ulong delay, AnimationFunctions.Function function)
          : this(new Path(startX, endX, duration, delay, function), new Path(startY, endY, duration, delay, function), new Path(startZ, endZ, duration, delay, function))
        {
        }

        public Path3D(float startX, float endX, float startY, float endY, float startZ, float endZ, ulong duration, ulong delay)
          : this(new Path(startX, endX, duration, delay), new Path(startY, endY, duration, delay), new Path(startZ, endZ, duration, delay))
        {
        }

        public Path3D(float startX, float endX, float startY, float endY, float startZ, float endZ, ulong duration, AnimationFunctions.Function function)
          : this(new Path(startX, endX, duration, function), new Path(startY, endY, duration, function), new Path(startZ, endZ, duration, function))
        {
        }

        public Path3D(float startX, float endX, float startY, float endY, float startZ, float endZ, ulong duration)
          : this(new Path(startX, endX, duration), new Path(startY, endY, duration), new Path(startZ, endZ, duration))
        {
        }

        public Path3D(Float3D start, Float3D end, ulong duration, ulong delay, AnimationFunctions.Function function)
          : this(new Path(start.X, end.X, duration, delay, function), new Path(start.Y, end.Y, duration, delay, function), new Path(start.Z, end.Z, duration, delay, function))
        {
        }

        public Path3D(Float3D start, Float3D end, ulong duration, ulong delay)
          : this(new Path(start.X, end.X, duration, delay), new Path(start.Y, end.Y, duration, delay), new Path(start.Z, end.Z, duration, delay))
        {
        }

        public Path3D(Float3D start, Float3D end, ulong duration, AnimationFunctions.Function function)
          : this(new Path(start.X, end.X, duration, function), new Path(start.Y, end.Y, duration, function), new Path(start.Z, end.Z, duration, function))
        {
        }

        public Path3D(Float3D start, Float3D end, ulong duration)
          : this(new Path(start.X, end.X, duration), new Path(start.Y, end.Y, duration), new Path(start.Z, end.Z, duration))
        {
        }

        public Path3D(Path x, Path y, Path z)
        {
            this.HorizontalPath = x;
            this.VerticalPath = y;
            this.DepthPath = z;

            //// ISSUE: reference to a compiler-generated field
            //this.\u003CHorizontalPath\u003Ek__BackingField = x;
            //  this.HorizontalPath.
            //// ISSUE: reference to a compiler-generated field
            //this.\u003CVerticalPath\u003Ek__BackingField = y;
            //// ISSUE: reference to a compiler-generated field
            //this.\u003CDepthPath\u003Ek__BackingField = z;
        }

        public Path3D Reverse()
        {
            return new Path3D(this.HorizontalPath.Reverse(), this.VerticalPath.Reverse(), this.DepthPath.Reverse());
        }
    }
}
