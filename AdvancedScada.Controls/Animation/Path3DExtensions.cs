
using System.Collections.Generic;
using System.Linq;

namespace AdvancedScada.Controls.Animation
{
    public static class Path3DExtensions
    {
        public static Path3D[] ContinueTo(this Path3D[] paths, Float3D end, ulong duration)
        {
            return ((IEnumerable<Path3D>)paths).Concat<Path3D>((IEnumerable<Path3D>)new Path3D[1]
            {
        new Path3D(((IEnumerable<Path3D>) paths).Last<Path3D>().End, end, duration)
            }).ToArray<Path3D>();
        }

        public static Path3D[] ContinueTo(this Path3D[] paths, Float3D end, ulong duration, AnimationFunctions.Function function)
        {
            return ((IEnumerable<Path3D>)paths).Concat<Path3D>((IEnumerable<Path3D>)new Path3D[1]
            {
        new Path3D(((IEnumerable<Path3D>) paths).Last<Path3D>().End, end, duration, function)
            }).ToArray<Path3D>();
        }

        public static Path3D[] ContinueTo(this Path3D[] paths, Float3D end, ulong duration, ulong delay)
        {
            return ((IEnumerable<Path3D>)paths).Concat<Path3D>((IEnumerable<Path3D>)new Path3D[1]
            {
        new Path3D(((IEnumerable<Path3D>) paths).Last<Path3D>().End, end, duration, delay)
            }).ToArray<Path3D>();
        }

        public static Path3D[] ContinueTo(this Path3D[] paths, Float3D end, ulong duration, ulong delay, AnimationFunctions.Function function)
        {
            return ((IEnumerable<Path3D>)paths).Concat<Path3D>((IEnumerable<Path3D>)new Path3D[1]
            {
        new Path3D(((IEnumerable<Path3D>) paths).Last<Path3D>().End, end, duration, delay, function)
            }).ToArray<Path3D>();
        }

        public static Path3D[] ContinueTo(this Path3D[] paths, float endX, float endY, float endZ, ulong duration)
        {
            return ((IEnumerable<Path3D>)paths).Concat<Path3D>((IEnumerable<Path3D>)new Path3D[1]
            {
        new Path3D(((IEnumerable<Path3D>) paths).Last<Path3D>().End, new Float3D(endX, endY, endZ), duration)
            }).ToArray<Path3D>();
        }

        public static Path3D[] ContinueTo(this Path3D[] paths, float endX, float endY, float endZ, ulong duration, AnimationFunctions.Function function)
        {
            return ((IEnumerable<Path3D>)paths).Concat<Path3D>((IEnumerable<Path3D>)new Path3D[1]
            {
        new Path3D(((IEnumerable<Path3D>) paths).Last<Path3D>().End, new Float3D(endX, endY, endZ), duration, function)
            }).ToArray<Path3D>();
        }

        public static Path3D[] ContinueTo(this Path3D[] paths, float endX, float endY, float endZ, ulong duration, ulong delay)
        {
            return ((IEnumerable<Path3D>)paths).Concat<Path3D>((IEnumerable<Path3D>)new Path3D[1]
            {
        new Path3D(((IEnumerable<Path3D>) paths).Last<Path3D>().End, new Float3D(endX, endY, endZ), duration, delay)
            }).ToArray<Path3D>();
        }

        public static Path3D[] ContinueTo(this Path3D[] paths, float endX, float endY, float endZ, ulong duration, ulong delay, AnimationFunctions.Function function)
        {
            return ((IEnumerable<Path3D>)paths).Concat<Path3D>((IEnumerable<Path3D>)new Path3D[1]
            {
        new Path3D(((IEnumerable<Path3D>) paths).Last<Path3D>().End, new Float3D(endX, endY, endZ), duration, delay, function)
            }).ToArray<Path3D>();
        }

        public static Path3D[] ContinueTo(this Path3D path, Float3D end, ulong duration)
        {
            return path.ToArray().ContinueTo(end, duration);
        }

        public static Path3D[] ContinueTo(this Path3D path, Float3D end, ulong duration, AnimationFunctions.Function function)
        {
            return path.ToArray().ContinueTo(end, duration, function);
        }

        public static Path3D[] ContinueTo(this Path3D path, Float3D end, ulong duration, ulong delay)
        {
            return path.ToArray().ContinueTo(end, duration, delay);
        }

        public static Path3D[] ContinueTo(this Path3D path, Float3D end, ulong duration, ulong delay, AnimationFunctions.Function function)
        {
            return path.ToArray().ContinueTo(end, duration, delay, function);
        }

        public static Path3D[] ContinueTo(this Path3D path, float endX, float endY, float endZ, ulong duration)
        {
            return path.ToArray().ContinueTo(endX, endY, endZ, duration);
        }

        public static Path3D[] ContinueTo(this Path3D path, float endX, float endY, float endZ, ulong duration, AnimationFunctions.Function function)
        {
            return path.ToArray().ContinueTo(endX, endY, endZ, duration, function);
        }

        public static Path3D[] ContinueTo(this Path3D path, float endX, float endY, float endZ, ulong duration, ulong delay)
        {
            return path.ToArray().ContinueTo(endX, endY, endZ, duration, delay);
        }

        public static Path3D[] ContinueTo(this Path3D path, float endX, float endY, float endZ, ulong duration, ulong delay, AnimationFunctions.Function function)
        {
            return path.ToArray().ContinueTo(endX, endY, endZ, duration, delay, function);
        }

        public static Path3D[] ContinueTo(this Path3D[] paths, params Path3D[] newPaths)
        {
            return ((IEnumerable<Path3D>)paths).Concat<Path3D>((IEnumerable<Path3D>)newPaths).ToArray<Path3D>();
        }

        public static Path3D[] ContinueTo(this Path3D path, params Path3D[] newPaths)
        {
            return path.ToArray().ContinueTo(newPaths);
        }

        public static Path3D[] ToArray(this Path3D path)
        {
            return new Path3D[1] { path };
        }
    }
}
