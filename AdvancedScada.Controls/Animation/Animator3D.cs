using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace AdvancedScada.Controls.Animation
{
    public class Animator3D : IAnimator
    {
        private readonly List<Path3D> _paths = new List<Path3D>();
        protected SafeInvoker EndCallback;
        protected SafeInvoker<Float3D> FrameCallback;
        protected bool IsEnded;
        protected object TargetObject;
        protected float? XValue;
        protected float? YValue;
        protected float? ZValue;

        public Path3D ActivePath
        {
            get
            {
                return new Path3D(this.HorizontalAnimator.ActivePath, this.VerticalAnimator.ActivePath, this.DepthAnimator.ActivePath);
            }
        }

        public Animator HorizontalAnimator { get; protected set; }

        public Animator VerticalAnimator { get; protected set; }

        public Animator DepthAnimator { get; protected set; }

        public Path3D[] Paths
        {
            get
            {
                return this._paths.ToArray();
            }
            set
            {
                if (this.CurrentStatus != AnimatorStatus.Stopped)
                    throw new NotSupportedException("Animation is running.");
                this._paths.Clear();
                this._paths.AddRange((IEnumerable<Path3D>)value);
                List<Path> pathList1 = new List<Path>();
                List<Path> pathList2 = new List<Path>();
                List<Path> pathList3 = new List<Path>();
                foreach (Path3D path3D in value)
                {
                    pathList1.Add(path3D.HorizontalPath);
                    pathList2.Add(path3D.VerticalPath);
                    pathList3.Add(path3D.DepthPath);
                }
                this.HorizontalAnimator.Paths = pathList1.ToArray();
                this.VerticalAnimator.Paths = pathList2.ToArray();
                this.DepthAnimator.Paths = pathList3.ToArray();
            }
        }

        public virtual bool Repeat
        {
            get
            {
                if (this.HorizontalAnimator.Repeat && this.VerticalAnimator.Repeat)
                    return this.DepthAnimator.Repeat;
                return false;
            }
            set
            {
                this.HorizontalAnimator.Repeat = this.VerticalAnimator.Repeat = this.DepthAnimator.Repeat = value;
            }
        }

        public virtual bool ReverseRepeat
        {
            get
            {
                if (this.HorizontalAnimator.ReverseRepeat && this.VerticalAnimator.ReverseRepeat)
                    return this.DepthAnimator.ReverseRepeat;
                return false;
            }
            set
            {
                this.HorizontalAnimator.ReverseRepeat = this.VerticalAnimator.ReverseRepeat = this.DepthAnimator.ReverseRepeat = value;
            }
        }

        public virtual AnimatorStatus CurrentStatus
        {
            get
            {
                if (this.HorizontalAnimator.CurrentStatus == AnimatorStatus.Stopped && this.VerticalAnimator.CurrentStatus == AnimatorStatus.Stopped && this.DepthAnimator.CurrentStatus == AnimatorStatus.Stopped)
                    return AnimatorStatus.Stopped;
                if (this.HorizontalAnimator.CurrentStatus == AnimatorStatus.Paused && this.VerticalAnimator.CurrentStatus == AnimatorStatus.Paused && this.DepthAnimator.CurrentStatus == AnimatorStatus.Paused)
                    return AnimatorStatus.Paused;
                return this.HorizontalAnimator.CurrentStatus == AnimatorStatus.OnHold && this.VerticalAnimator.CurrentStatus == AnimatorStatus.OnHold && this.DepthAnimator.CurrentStatus == AnimatorStatus.OnHold ? AnimatorStatus.OnHold : AnimatorStatus.Playing;
            }
        }

        public Animator3D()
          : this(new Path3D[0])
        {
        }

        public Animator3D(FPSLimiterKnownValues fpsLimiter)
          : this(new Path3D[0], fpsLimiter)
        {
        }

        public Animator3D(Path3D path)
          : this(new Path3D[1] { path })
        {
        }

        public Animator3D(Path3D path, FPSLimiterKnownValues fpsLimiter)
          : this(new Path3D[1] { path }, fpsLimiter)
        {
        }

        public Animator3D(Path3D[] paths)
          : this(paths, FPSLimiterKnownValues.LimitThirty)
        {
        }

        public Animator3D(Path3D[] paths, FPSLimiterKnownValues fpsLimiter)
        {
            this.HorizontalAnimator = new Animator(fpsLimiter);
            this.VerticalAnimator = new Animator(fpsLimiter);
            this.DepthAnimator = new Animator(fpsLimiter);
            this.Paths = paths;
        }

        public virtual void Pause()
        {
            if (this.CurrentStatus != AnimatorStatus.OnHold && this.CurrentStatus != AnimatorStatus.Playing)
                return;
            this.HorizontalAnimator.Pause();
            this.VerticalAnimator.Pause();
            this.DepthAnimator.Pause();
        }

        public virtual void Play(object targetObject, string propertyName)
        {
            this.Play(targetObject, propertyName, (SafeInvoker)null);
        }

        public virtual void Play(object targetObject, string propertyName, SafeInvoker endCallback)
        {
            this.TargetObject = targetObject;
            PropertyInfo prop = this.TargetObject.GetType().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.SetProperty);
            if (prop == null)
                return;
            this.Play(new SafeInvoker<Float3D>((Action<Float3D>)(value => prop.SetValue(this.TargetObject, Convert.ChangeType((object)value, prop.PropertyType), (object[])null)), this.TargetObject), endCallback);
        }

        public virtual void Play<T>(T targetObject, Expression<Func<T, object>> propertySetter)
        {
            this.Play<T>(targetObject, propertySetter, (SafeInvoker)null);
        }

        public virtual void Play<T>(T targetObject, Expression<Func<T, object>> propertySetter, SafeInvoker endCallback)
        {
            if (propertySetter == null)
                return;
            this.TargetObject = (object)targetObject;
            MemberExpression memberExpression = propertySetter.Body as MemberExpression ?? ((UnaryExpression)propertySetter.Body).Operand as MemberExpression;
            PropertyInfo property = (memberExpression != null ? memberExpression.Member : (MemberInfo)null) as PropertyInfo;
            if (property == null)
                throw new ArgumentException("propertySetter");
            this.Play(new SafeInvoker<Float3D>((Action<Float3D>)(value => property.SetValue(this.TargetObject, Convert.ChangeType((object)value, property.PropertyType), (object[])null)), this.TargetObject), endCallback);
        }

        public virtual void Resume()
        {
            if (this.CurrentStatus != AnimatorStatus.Paused)
                return;
            this.HorizontalAnimator.Resume();
            this.VerticalAnimator.Resume();
            this.DepthAnimator.Resume();
        }

        public virtual void Stop()
        {
            this.HorizontalAnimator.Stop();
            this.VerticalAnimator.Stop();
            this.DepthAnimator.Stop();
            this.XValue = this.YValue = this.ZValue = new float?();
        }

        public void Play(object targetObject, Animator3D.KnownProperties property)
        {
            this.Play(targetObject, property, (SafeInvoker)null);
        }

        public void Play(object targetObject, Animator3D.KnownProperties property, SafeInvoker endCallback)
        {
            this.Play(targetObject, property.ToString(), endCallback);
        }

        public void Play(SafeInvoker<Float3D> frameCallback)
        {
            this.Play(frameCallback, (SafeInvoker)null);
        }

        public void Play(SafeInvoker<Float3D> frameCallback, SafeInvoker endCallback)
        {
            this.Stop();
            this.FrameCallback = frameCallback;
            this.EndCallback = endCallback;
            this.IsEnded = false;
            this.HorizontalAnimator.Play(new SafeInvoker<float>((Action<float>)(value =>
           {
               this.XValue = new float?(value);
               this.InvokeSetter();
           })), new SafeInvoker(new Action(this.InvokeFinisher)));
            this.VerticalAnimator.Play(new SafeInvoker<float>((Action<float>)(value =>
           {
               this.YValue = new float?(value);
               this.InvokeSetter();
           })), new SafeInvoker(new Action(this.InvokeFinisher)));
            this.DepthAnimator.Play(new SafeInvoker<float>((Action<float>)(value =>
           {
               this.ZValue = new float?(value);
               this.InvokeSetter();
           })), new SafeInvoker(new Action(this.InvokeFinisher)));
        }

        private void InvokeFinisher()
        {
            if (this.EndCallback == null || this.IsEnded)
                return;
            lock (this.EndCallback)
            {
                if (this.CurrentStatus != AnimatorStatus.Stopped)
                    return;
                this.IsEnded = true;
                this.EndCallback.Invoke();
            }
        }

        private void InvokeSetter()
        {
            if (!this.XValue.HasValue || !this.YValue.HasValue || !this.ZValue.HasValue)
                return;
            this.FrameCallback.Invoke(new Float3D(this.XValue.Value, this.YValue.Value, this.ZValue.Value));
        }

        public enum KnownProperties
        {
            BackColor,
            ForeColor,
        }
    }
}
