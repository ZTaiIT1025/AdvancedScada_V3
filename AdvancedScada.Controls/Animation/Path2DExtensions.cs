using System.Collections.Generic;
using System.Linq;

namespace AdvancedScada.Controls.Animation
{
    public static class Path2DExtensions
    {
        public static Path2D[] ContinueTo(this Path2D[] paths, Float2D end, ulong duration)
        {
            return ((IEnumerable<Path2D>)paths).Concat<Path2D>((IEnumerable<Path2D>)new Path2D[1]
            {
        new Path2D(((IEnumerable<Path2D>) paths).Last<Path2D>().End, end, duration)
            }).ToArray<Path2D>();
        }

        public static Path2D[] ContinueTo(this Path2D[] paths, Float2D end, ulong duration, AnimationFunctions.Function function)
        {
            return ((IEnumerable<Path2D>)paths).Concat<Path2D>((IEnumerable<Path2D>)new Path2D[1]
            {
        new Path2D(((IEnumerable<Path2D>) paths).Last<Path2D>().End, end, duration, function)
            }).ToArray<Path2D>();
        }

        public static Path2D[] ContinueTo(this Path2D[] paths, Float2D end, ulong duration, ulong delay)
        {
            return ((IEnumerable<Path2D>)paths).Concat<Path2D>((IEnumerable<Path2D>)new Path2D[1]
            {
        new Path2D(((IEnumerable<Path2D>) paths).Last<Path2D>().End, end, duration, delay)
            }).ToArray<Path2D>();
        }

        public static Path2D[] ContinueTo(this Path2D[] paths, Float2D end, ulong duration, ulong delay, AnimationFunctions.Function function)
        {
            return ((IEnumerable<Path2D>)paths).Concat<Path2D>((IEnumerable<Path2D>)new Path2D[1]
            {
        new Path2D(((IEnumerable<Path2D>) paths).Last<Path2D>().End, end, duration, delay, function)
            }).ToArray<Path2D>();
        }

        public static Path2D[] ContinueTo(this Path2D[] paths, float endX, float endY, ulong duration)
        {
            return ((IEnumerable<Path2D>)paths).Concat<Path2D>((IEnumerable<Path2D>)new Path2D[1]
            {
        new Path2D(((IEnumerable<Path2D>) paths).Last<Path2D>().End, new Float2D(endX, endY), duration)
            }).ToArray<Path2D>();
        }

        public static Path2D[] ContinueTo(this Path2D[] paths, float endX, float endY, ulong duration, AnimationFunctions.Function function)
        {
            return ((IEnumerable<Path2D>)paths).Concat<Path2D>((IEnumerable<Path2D>)new Path2D[1]
            {
        new Path2D(((IEnumerable<Path2D>) paths).Last<Path2D>().End, new Float2D(endX, endY), duration, function)
            }).ToArray<Path2D>();
        }

        public static Path2D[] ContinueTo(this Path2D[] paths, float endX, float endY, ulong duration, ulong delay)
        {
            return ((IEnumerable<Path2D>)paths).Concat<Path2D>((IEnumerable<Path2D>)new Path2D[1]
            {
        new Path2D(((IEnumerable<Path2D>) paths).Last<Path2D>().End, new Float2D(endX, endY), duration, delay)
            }).ToArray<Path2D>();
        }

        public static Path2D[] ContinueTo(this Path2D[] paths, float endX, float endY, ulong duration, ulong delay, AnimationFunctions.Function function)
        {
            return ((IEnumerable<Path2D>)paths).Concat<Path2D>((IEnumerable<Path2D>)new Path2D[1]
            {
        new Path2D(((IEnumerable<Path2D>) paths).Last<Path2D>().End, new Float2D(endX, endY), duration, delay, function)
            }).ToArray<Path2D>();
        }

        public static Path2D[] ContinueTo(this Path2D path, Float2D end, ulong duration)
        {
            return path.ToArray().ContinueTo(end, duration);
        }

        public static Path2D[] ContinueTo(this Path2D path, Float2D end, ulong duration, AnimationFunctions.Function function)
        {
            return path.ToArray().ContinueTo(end, duration, function);
        }

        public static Path2D[] ContinueTo(this Path2D path, Float2D end, ulong duration, ulong delay)
        {
            return path.ToArray().ContinueTo(end, duration, delay);
        }

        public static Path2D[] ContinueTo(this Path2D path, Float2D end, ulong duration, ulong delay, AnimationFunctions.Function function)
        {
            return path.ToArray().ContinueTo(end, duration, delay, function);
        }

        public static Path2D[] ContinueTo(this Path2D path, float endX, float endY, ulong duration)
        {
            return path.ToArray().ContinueTo(endX, endY, duration);
        }

        public static Path2D[] ContinueTo(this Path2D path, float endX, float endY, ulong duration, AnimationFunctions.Function function)
        {
            return path.ToArray().ContinueTo(endX, endY, duration, function);
        }

        public static Path2D[] ContinueTo(this Path2D path, float endX, float endY, ulong duration, ulong delay)
        {
            return path.ToArray().ContinueTo(endX, endY, duration, delay);
        }

        public static Path2D[] ContinueTo(this Path2D path, float endX, float endY, ulong duration, ulong delay, AnimationFunctions.Function function)
        {
            return path.ToArray().ContinueTo(endX, endY, duration, delay, function);
        }

        public static Path2D[] ContinueTo(this Path2D[] paths, params Path2D[] newPaths)
        {
            return ((IEnumerable<Path2D>)paths).Concat<Path2D>((IEnumerable<Path2D>)newPaths).ToArray<Path2D>();
        }

        public static Path2D[] ContinueTo(this Path2D path, params Path2D[] newPaths)
        {
            return path.ToArray().ContinueTo(newPaths);
        }

        public static Path2D[] ToArray(this Path2D path)
        {
            return new Path2D[1] { path };
        }
    }
}
