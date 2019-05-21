using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AdvancedScada.Controls.Animation
{
    public class Timer
    {
        private static readonly object LockHandle = new object();
        private static readonly long StartTimeAsMs = DateTime.Now.Ticks;
        private static readonly List<Timer> Subscribers = new List<Timer>();
        private static Thread _timerThread;
        private readonly Action<ulong> _callback;

        public long LastTick { get; private set; }

        public int FrameLimiter { get; set; }

        public long FirstTick { get; private set; }

        public Timer(Action<ulong> callback, FPSLimiterKnownValues fpsKnownLimit = FPSLimiterKnownValues.LimitThirty)
          : this(callback, (int)fpsKnownLimit)
        {
        }

        public Timer(Action<ulong> callback, int fpsLimit)
        {
            if (callback == null)
                throw new ArgumentNullException("callback");
            this._callback = callback;
            this.FrameLimiter = fpsLimit;
            lock (Timer.LockHandle)
            {
                if (Timer._timerThread != null)
                    return;
                Thread temp_13 = new Thread(new ThreadStart(Timer.ThreadCycle));
                temp_13.IsBackground = true;
                Timer._timerThread = temp_13;
                temp_13.Start();
            }
        }

        private void Tick()
        {
            if ((long)(1000 / this.FrameLimiter) >= Timer.GetTimeDifferenceAsMs() - this.LastTick)
                return;
            this.LastTick = Timer.GetTimeDifferenceAsMs();
            this._callback((ulong)(this.LastTick - this.FirstTick));
        }

        private static long GetTimeDifferenceAsMs()
        {
            return (DateTime.Now.Ticks - Timer.StartTimeAsMs) / 10000L;
        }

        private static void ThreadCycle()
        {
            while (true)
            {
                try
                {
                    bool flag;
                    lock (Timer.Subscribers)
                    {
                        flag = Timer.Subscribers.Count == 0;
                        if (!flag)
                        {
                            foreach (Timer item_0 in Timer.Subscribers.ToList<Timer>())
                                item_0.Tick();
                        }
                    }
                    Thread.Sleep(flag ? 50 : 1);
                }
                catch
                {
                }
            }
        }

        public void ResetClock()
        {
            this.FirstTick = Timer.GetTimeDifferenceAsMs();
        }

        public void Resume()
        {
            lock (Timer.Subscribers)
            {
                if (Timer.Subscribers.Contains(this))
                    return;
                this.FirstTick = this.FirstTick + (Timer.GetTimeDifferenceAsMs() - this.LastTick);
                Timer.Subscribers.Add(this);
            }
        }

        public void Start()
        {
            lock (Timer.Subscribers)
            {
                if (Timer.Subscribers.Contains(this))
                    return;
                this.FirstTick = Timer.GetTimeDifferenceAsMs();
                Timer.Subscribers.Add(this);
            }
        }

        public void Stop()
        {
            lock (Timer.Subscribers)
            {
                if (!Timer.Subscribers.Contains(this))
                    return;
                Timer.Subscribers.Remove(this);
            }
        }
    }
}
