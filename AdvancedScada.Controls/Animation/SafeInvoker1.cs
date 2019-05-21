using System;

namespace AdvancedScada.Controls.Animation
{
    public class SafeInvoker<T> : SafeInvoker
    {
        public SafeInvoker(Action<T> action, object targetControl)
          : base((Delegate)action, targetControl)
        {
        }

        public SafeInvoker(Action<T> action)
          : this(action, (object)null)
        {
        }

        public void Invoke(T value)
        {
            this.Invoke((object)value);
        }
    }
}
