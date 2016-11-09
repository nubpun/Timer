using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timer
{
    class Timer: IDisposable
    {
        Stopwatch stopwatch;
        TimeSpan elapsed;
        public void Dispose()
        {
            stopwatch.Stop();
            elapsed = elapsed + stopwatch.Elapsed;
        }
        public Timer()
        {
            Reset();
        }
        public Timer Start()
        {
            Reset();
            stopwatch.Start();
            return this;
        }
        public Timer Continue()
        {
            stopwatch.Restart();
            return this;
        }
        private Timer Reset()
        {
            stopwatch = new Stopwatch();
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
                return stopwatch.IsRunning;
            }
        }
    }
}
