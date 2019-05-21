using System;
using System.Reflection;
using System.Threading;

namespace AdvancedScada.Controls.Animation
{
    public class SafeInvoker
    {
        private MethodInfo _invokeMethod;
        private PropertyInfo _invokeRequiredProperty;
        private object _targetControl;

        protected object TargetControl
        {
            get
            {
                return this._targetControl;
            }
            set
            {
                this._invokeRequiredProperty = value.GetType().GetProperty("InvokeRequired", BindingFlags.Instance | BindingFlags.Public);
                this._invokeMethod = value.GetType().GetMethod("Invoke", BindingFlags.Instance | BindingFlags.Public, Type.DefaultBinder, new Type[1]
                {
          typeof (Delegate)
                }, (ParameterModifier[])null);
                if (this._invokeRequiredProperty == null || this._invokeMethod == null)
                    return;
                this._targetControl = value;
            }
        }

        protected Delegate UnderlyingDelegate { get; set; }

        public SafeInvoker(Action action, object targetControl)
          : this((Delegate)action, targetControl)
        {
        }

        protected SafeInvoker(Delegate action, object targetControl)
        {
            this.UnderlyingDelegate = action;
            if (targetControl == null)
                return;
            this.TargetControl = targetControl;
        }

        public SafeInvoker(Action action)
          : this(action, (object)null)
        {
        }

        public virtual void Invoke()
        {
            this.Invoke((object)null);
        }

        protected void Invoke(object value)
        {
            try
            {
                ThreadPool.QueueUserWorkItem((WaitCallback)(state =>
               {
                   if (this.TargetControl != null && (bool)this._invokeRequiredProperty.GetValue(this.TargetControl, (object[])null))
                   {
                       this._invokeMethod.Invoke(this.TargetControl, new object[1]
                {
              (object) (Action) (() =>
              {
                Delegate underlyingDelegate = this.UnderlyingDelegate;
                object[] objArray;
                if (value == null)
                  objArray = (object[]) null;
                else
                  objArray = new object[1]{ value };
                underlyingDelegate.DynamicInvoke(objArray);
              })
                   });
                   }
                   else
                   {
                       Delegate underlyingDelegate = this.UnderlyingDelegate;
                       object[] objArray;
                       if (value == null)
                           objArray = (object[])null;
                       else
                           objArray = new object[1] { value };
                       underlyingDelegate.DynamicInvoke(objArray);
                   }
               }));
            }
            catch
            {
            }
        }
    }
}
