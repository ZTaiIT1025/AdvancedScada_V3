
using System;
using System.Linq.Expressions;

namespace AdvancedScada.Controls.Animation
{
    public interface IAnimator
    {
        AnimatorStatus CurrentStatus { get; }

        bool Repeat { get; set; }

        bool ReverseRepeat { get; set; }

        void Play(object targetObject, string propertyName);

        void Play(object targetObject, string propertyName, SafeInvoker endCallback);

        void Play<T>(T targetObject, Expression<Func<T, object>> propertySetter);

        void Play<T>(T targetObject, Expression<Func<T, object>> propertySetter, SafeInvoker endCallback);

        void Resume();

        void Stop();

        void Pause();
    }
}
