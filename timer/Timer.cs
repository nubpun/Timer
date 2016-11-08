using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timer
{
    class Timer: IDisposable
    {
        private DateTime start;
        private DateTime end;
        private long elapsedTicks;
        private bool isRunning;
        public void Dispose()
        {
            if(isRunning)
                Stop();
        }
        public Timer()
        {
            Reset();
        }
        public Timer Start()
        {
            isRunning = true;
            start = DateTime.Now;
            elapsedTicks = 0;
            return this;
        }
        public Timer Stop()
        {
            isRunning = false;
            end = DateTime.Now;
            elapsedTicks += (end.Ticks - start.Ticks);
            return this;
        }
        public Timer Continue()
        {
            isRunning = true;
            start = DateTime.Now;
            return this;
        }
        public Timer Reset()
        {
            start = DateTime.Now;
            end = DateTime.Now;
            isRunning = false;
            elapsedTicks = 0;
            return this;
        }
        public Timer Restart()
        {
            Reset();
            return Start();
        }
        public long ElapsedMilliseconds
        {
            get
            {
                return elapsedTicks / TimeSpan.TicksPerMillisecond;
            }

        }

        public long ElapsedTicks
        {
            get
            {
                return elapsedTicks;
            }
        }

        public bool IsRunning
        {
            get
            {
                return isRunning;
            }
        }
    }
}
