using System;

namespace AdvancedScada.Controls.Animation
{
    public static class AnimationFunctions
    {
        public static float CubicEaseIn(float t, float b, float c, float d)
        {
            t /= d;
            return c * t * t * t + b;
        }

        public static float CubicEaseInOut(float t, float b, float c, float d)
        {
            t /= d / 2f;
            if ((double)t < 1.0)
                return c / 2f * t * t * t + b;
            t -= 2f;
            return (float)((double)c / 2.0 * ((double)t * (double)t * (double)t + 2.0)) + b;
        }

        public static float CubicEaseOut(float t, float b, float c, float d)
        {
            t /= d;
            --t;
            return c * (float)((double)t * (double)t * (double)t + 1.0) + b;
        }

        public static float Liner(float t, float b, float c, float d)
        {
            return c * t / d + b;
        }

        public static float CircularEaseInOut(float t, float b, float c, float d)
        {
            t /= d / 2f;
            if ((double)t < 1.0)
                return (float)(-(double)c / 2.0 * (Math.Sqrt(1.0 - (double)t * (double)t) - 1.0)) + b;
            t -= 2f;
            return (float)((double)c / 2.0 * (Math.Sqrt(1.0 - (double)t * (double)t) + 1.0)) + b;
        }

        public static float CircularEaseIn(float t, float b, float c, float d)
        {
            t /= d;
            return (float)(-(double)c * (Math.Sqrt(1.0 - (double)t * (double)t) - 1.0)) + b;
        }

        public static float CircularEaseOut(float t, float b, float c, float d)
        {
            t /= d;
            --t;
            return c * (float)Math.Sqrt(1.0 - (double)t * (double)t) + b;
        }

        public static float QuadraticEaseIn(float t, float b, float c, float d)
        {
            t /= d;
            return c * t * t + b;
        }

        public static float QuadraticEaseOut(float t, float b, float c, float d)
        {
            t /= d;
            return (float)(-(double)c * (double)t * ((double)t - 2.0)) + b;
        }

        public static float QuadraticEaseInOut(float t, float b, float c, float d)
        {
            t /= d / 2f;
            if ((double)t < 1.0)
                return c / 2f * t * t + b;
            --t;
            return (float)(-(double)c / 2.0 * ((double)t * ((double)t - 2.0) - 1.0)) + b;
        }

        public static float QuarticEaseIn(float t, float b, float c, float d)
        {
            t /= d;
            return c * t * t * t * t + b;
        }

        public static float QuarticEaseOut(float t, float b, float c, float d)
        {
            t /= d;
            --t;
            return (float)(-(double)c * ((double)t * (double)t * (double)t * (double)t - 1.0)) + b;
        }

        public static float QuarticEaseInOut(float t, float b, float c, float d)
        {
            t /= d / 2f;
            if ((double)t < 1.0)
                return c / 2f * t * t * t * t + b;
            t -= 2f;
            return (float)(-(double)c / 2.0 * ((double)t * (double)t * (double)t * (double)t - 2.0)) + b;
        }

        public static float QuinticEaseInOut(float t, float b, float c, float d)
        {
            t /= d / 2f;
            if ((double)t < 1.0)
                return c / 2f * t * t * t * t * t + b;
            t -= 2f;
            return (float)((double)c / 2.0 * ((double)t * (double)t * (double)t * (double)t * (double)t + 2.0)) + b;
        }

        public static float QuinticEaseIn(float t, float b, float c, float d)
        {
            t /= d;
            return c * t * t * t * t * t + b;
        }

        public static float QuinticEaseOut(float t, float b, float c, float d)
        {
            t /= d;
            --t;
            return c * (float)((double)t * (double)t * (double)t * (double)t * (double)t + 1.0) + b;
        }

        public static float SinusoidalEaseIn(float t, float b, float c, float d)
        {
            return (float)(-(double)c * Math.Cos((double)t / (double)d * (Math.PI / 2.0))) + c + b;
        }

        public static float SinusoidalEaseOut(float t, float b, float c, float d)
        {
            return c * (float)Math.Sin((double)t / (double)d * (Math.PI / 2.0)) + b;
        }

        public static float SinusoidalEaseInOut(float t, float b, float c, float d)
        {
            return (float)(-(double)c / 2.0 * (Math.Cos(Math.PI * (double)t / (double)d) - 1.0)) + b;
        }

        public static float ExponentialEaseIn(float t, float b, float c, float d)
        {
            return c * (float)Math.Pow(2.0, 10.0 * ((double)t / (double)d - 1.0)) + b;
        }

        public static float ExponentialEaseOut(float t, float b, float c, float d)
        {
            return c * (float)(-Math.Pow(2.0, -10.0 * (double)t / (double)d) + 1.0) + b;
        }

        public static float ExponentialEaseInOut(float t, float b, float c, float d)
        {
            t /= d / 2f;
            if ((double)t < 1.0)
                return (float)((double)c / 2.0 * Math.Pow(2.0, 10.0 * ((double)t - 1.0))) + b;
            --t;
            return (float)((double)c / 2.0 * (-Math.Pow(2.0, -10.0 * (double)t) + 2.0)) + b;
        }

        public delegate float Function(float time, float beginningValue, float changeInValue, float duration);
    }
}
