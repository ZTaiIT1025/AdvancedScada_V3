using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AdvancedScada.Controls.Animation
{
    public class Animator : IAnimator
    {
        private readonly List<Path> _paths = new List<Path>();
        private readonly List<Path> _tempPaths = new List<Path>();
        private readonly Timer _timer;
        private bool _tempReverseRepeat;
        protected SafeInvoker EndCallback;
        protected SafeInvoker<float> FrameCallback;
        protected object TargetObject;

        public Path[] Paths
        {
            get
            {
                return this._paths.ToArray();
            }
            set
            {
                if (this.CurrentStatus != AnimatorStatus.Stopped)
                    throw new InvalidOperationException("Animation is running.");
                this._paths.Clear();
                this._paths.AddRange((IEnumerable<Path>)value);
            }
        }

        public Path ActivePath { get; private set; }

        public virtual bool Repeat { get; set; }

        public virtual bool ReverseRepeat { get; set; }

        public virtual AnimatorStatus CurrentStatus { get; private set; }

        public Animator()
          : this(new Path[0])
        {
        }

        public Animator(FPSLimiterKnownValues fpsLimiter)
          : this(new Path[0], fpsLimiter)
        {
        }

        public Animator(Path path)
          : this(new Path[1] { path })
        {
        }

        public Animator(Path path, FPSLimiterKnownValues fpsLimiter)
          : this(new Path[1] { path }, fpsLimiter)
        {
        }

        public Animator(Path[] paths)
          : this(paths, FPSLimiterKnownValues.LimitThirty)
        {
        }

        public Animator(Path[] paths, FPSLimiterKnownValues fpsLimiter)
        {
            this.CurrentStatus = AnimatorStatus.Stopped;
            this._timer = new Timer(new Action<ulong>(this.Elapsed), fpsLimiter);
            this.Paths = paths;
        }

        public virtual void Pause()
        {
            if (this.CurrentStatus != AnimatorStatus.OnHold && this.CurrentStatus != AnimatorStatus.Playing)
                return;
            this._timer.Stop();
            this.CurrentStatus = AnimatorStatus.Paused;
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
            this.Play(new SafeInvoker<float>((Action<float>)(value => prop.SetValue(this.TargetObject, Convert.ChangeType((object)value, prop.PropertyType), (object[])null)), this.TargetObject), endCallback);
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
            this.Play(new SafeInvoker<float>((Action<float>)(value => property.SetValue(this.TargetObject, Convert.ChangeType((object)value, property.PropertyType), (object[])null)), this.TargetObject), endCallback);
        }

        public virtual void Resume()
        {
            if (this.CurrentStatus != AnimatorStatus.Paused)
                return;
            this._timer.Resume();
        }

        public virtual void Stop()
        {
            this._timer.Stop();
            lock (this._tempPaths)
                this._tempPaths.Clear();
            this.ActivePath = (Path)null;
            this.CurrentStatus = AnimatorStatus.Stopped;
            this._tempReverseRepeat = false;
        }

        public virtual void Play(object targetObject, Animator.KnownProperties property)
        {
            this.Play(targetObject, property, (SafeInvoker)null);
        }

        public virtual void Play(object targetObject, Animator.KnownProperties property, SafeInvoker endCallback)
        {
            this.Play(targetObject, property.ToString(), endCallback);
        }

        public virtual void Play(SafeInvoker<float> frameCallback)
        {
            this.Play(frameCallback, (SafeInvoker)null);
        }

        public virtual void Play(SafeInvoker<float> frameCallback, SafeInvoker endCallback)
        {
            this.Stop();
            this.FrameCallback = frameCallback;
            this.EndCallback = endCallback;
            this._timer.ResetClock();
            lock (this._tempPaths)
                this._tempPaths.AddRange((IEnumerable<Path>)this._paths);
            this._timer.Start();
        }

        private void Elapsed(ulong millSinceBeginning)
        {
            lock (this._tempPaths)
            {
                if (this._tempPaths != null && this.ActivePath == null && this._tempPaths.Count > 0)
                {
                    while (this.ActivePath == null)
                    {
                        if (this._tempReverseRepeat)
                        {
                            this.ActivePath = this._tempPaths.LastOrDefault<Path>();
                            this._tempPaths.RemoveAt(this._tempPaths.Count - 1);
                        }
                        else
                        {
                            this.ActivePath = this._tempPaths.FirstOrDefault<Path>();
                            this._tempPaths.RemoveAt(0);
                        }
                        this._timer.ResetClock();
                        millSinceBeginning = 0UL;
                    }
                }
                if (this.ActivePath != null)
                {
                    if (!this._tempReverseRepeat && millSinceBeginning < this.ActivePath.Delay)
                        this.CurrentStatus = AnimatorStatus.OnHold;
                    else if (millSinceBeginning - (!this._tempReverseRepeat ? this.ActivePath.Delay : 0UL) <= this.ActivePath.Duration)
                    {
                        if (this.CurrentStatus != AnimatorStatus.Playing)
                        {
                            this.FrameCallback.Invoke(this._tempReverseRepeat ? this.ActivePath.End : this.ActivePath.Start);
                            this.CurrentStatus = AnimatorStatus.Playing;
                        }
                        this.FrameCallback.Invoke(this.ActivePath.Function(this._tempReverseRepeat ? (float)(this.ActivePath.Duration - millSinceBeginning) : (float)(millSinceBeginning - this.ActivePath.Delay), this.ActivePath.Start, this.ActivePath.Change, (float)this.ActivePath.Duration));
                    }
                    else
                    {
                        if (this.CurrentStatus == AnimatorStatus.Playing)
                            this.FrameCallback.Invoke(this._tempReverseRepeat ? this.ActivePath.Start : this.ActivePath.End);
                        if (this._tempReverseRepeat && millSinceBeginning - this.ActivePath.Duration < this.ActivePath.Delay)
                            this.CurrentStatus = AnimatorStatus.OnHold;
                        else
                            this.ActivePath = (Path)null;
                    }
                }
                else if (this.Repeat)
                {
                    lock (this._tempPaths)
                    {
                        this._tempPaths.AddRange((IEnumerable<Path>)this._paths);
                        this._tempReverseRepeat = this.ReverseRepeat && !this._tempReverseRepeat;
                    }
                }
                else
                {
                    this.Stop();
                    SafeInvoker temp_11 = this.EndCallback;
                    if (temp_11 == null)
                        return;
                    temp_11.Invoke();
                }
            }
        }

        public enum KnownProperties
        {
            Value,
            Text,
            Caption,
            BackColor,
            ForeColor,
            Opacity,
        }
    }
}
