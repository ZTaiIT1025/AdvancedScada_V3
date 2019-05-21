using System.Collections.Generic;
using System.Linq;

namespace AdvancedScada.Controls.Animation
{
    public static class PathExtensions
    {
        public static Path[] ContinueTo(this Path[] paths, float end, ulong duration)
        {
            return ((IEnumerable<Path>)paths).Concat<Path>((IEnumerable<Path>)new Path[1]
            {
        new Path(((IEnumerable<Path>) paths).Last<Path>().End, end, duration)
            }).ToArray<Path>();
        }

        public static Path[] ContinueTo(this Path[] paths, float end, ulong duration, AnimationFunctions.Function function)
        {
            return ((IEnumerable<Path>)paths).Concat<Path>((IEnumerable<Path>)new Path[1]
            {
        new Path(((IEnumerable<Path>) paths).Last<Path>().End, end, duration, function)
            }).ToArray<Path>();
        }

        public static Path[] ContinueTo(this Path[] paths, float end, ulong duration, ulong delay)
        {
            return ((IEnumerable<Path>)paths).Concat<Path>((IEnumerable<Path>)new Path[1]
            {
        new Path(((IEnumerable<Path>) paths).Last<Path>().End, end, duration, delay)
            }).ToArray<Path>();
        }

        public static Path[] ContinueTo(this Path[] paths, float end, ulong duration, ulong delay, AnimationFunctions.Function function)
        {
            return ((IEnumerable<Path>)paths).Concat<Path>((IEnumerable<Path>)new Path[1]
            {
        new Path(((IEnumerable<Path>) paths).Last<Path>().End, end, duration, delay, function)
            }).ToArray<Path>();
        }

        public static Path[] ContinueTo(this Path path, float end, ulong duration)
        {
            return path.ToArray().ContinueTo(end, duration);
        }

        public static Path[] ContinueTo(this Path path, float end, ulong duration, AnimationFunctions.Function function)
        {
            return path.ToArray().ContinueTo(end, duration, function);
        }

        public static Path[] ContinueTo(this Path path, float end, ulong duration, ulong delay)
        {
            return path.ToArray().ContinueTo(end, duration, delay);
        }

        public static Path[] ContinueTo(this Path path, float end, ulong duration, ulong delay, AnimationFunctions.Function function)
        {
            return path.ToArray().ContinueTo(end, duration, delay, function);
        }

        public static Path[] ContinueTo(this Path[] paths, params Path[] newPaths)
        {
            return ((IEnumerable<Path>)paths).Concat<Path>((IEnumerable<Path>)newPaths).ToArray<Path>();
        }

        public static Path[] ContinueTo(this Path path, params Path[] newPaths)
        {
            return path.ToArray().ContinueTo(newPaths);
        }

        public static Path[] ToArray(this Path path)
        {
            return new Path[1] { path };
        }
    }
}
