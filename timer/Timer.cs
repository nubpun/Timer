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
        private TimeSpan elapsed;
        private bool isRunning;
        public void Dispose()
        {
            Stop();
        }
        public Timer()
        {
            Reset();
        }
        public Timer Start()
        {
            if (!isRunning)
            {
                Reset();
                isRunning = true;
                start = DateTime.Now;
            }
            return this;
        }
        public Timer StartNew()
        {
            var t = new Timer();
            return t.Start();
        }
        public Timer Stop()
        {
            if (isRunning)
            {
                isRunning = false;
                end = DateTime.Now;
                elapsed += end - start;                
            }
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
            elapsed = new TimeSpan(0);
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
                return elapsed.Milliseconds;
            }

        }

        public long ElapsedTicks
        {
            get
            {
                return elapsed.Ticks;
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
