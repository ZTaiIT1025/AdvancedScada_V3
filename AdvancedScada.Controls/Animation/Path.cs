namespace AdvancedScada.Controls.Animation
{
    public class Path
    {
        public float Change
        {
            get
            {
                return this.End - this.Start;
            }
        }

        public ulong Delay { get; set; }

        public ulong Duration { get; set; }

        public float End { get; set; }

        public AnimationFunctions.Function Function { get; set; }

        public float Start { get; set; }

        public Path()
          : this(0.0f, 0.0f, 0UL, 0UL, (AnimationFunctions.Function)null)
        {
        }

        public Path(float start, float end, ulong duration)
          : this(start, end, duration, 0UL, (AnimationFunctions.Function)null)
        {
        }

        public Path(float start, float end, ulong duration, AnimationFunctions.Function function)
          : this(start, end, duration, 0UL, function)
        {
        }

        public Path(float start, float end, ulong duration, ulong delay)
          : this(start, end, duration, delay, (AnimationFunctions.Function)null)
        {
        }

        public Path(float start, float end, ulong duration, ulong delay, AnimationFunctions.Function function)
        {
            this.Start = start;
            this.End = end;
            this.Function = function ?? new AnimationFunctions.Function(AnimationFunctions.Liner);
            this.Duration = duration;
            this.Delay = delay;
        }

        public Path Reverse()
        {
            return new Path(this.End, this.Start, this.Duration, this.Delay, this.Function);
        }
    }
}
