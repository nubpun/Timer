using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timer
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Timer();
            long s = 0;
            using (timer.Start())
            {
                for (int i = 0; i < 2e8; i++)
                    s += i - s;

            }
            Console.WriteLine(timer.ElapsedMilliseconds);

            using (timer.Continue())
            {
                for (int i = 0; i < 2e8; i++)
                    s += i - s;
            }
            Console.WriteLine(timer.ElapsedMilliseconds);
            //Console.ReadKey();
        }
    }

    class Timer : IDisposable
    {
        DateTime start;
        DateTime end;
        long elapsedMilliseconds;
        public void Dispose()
        {
            Stop();
        }

        public Timer()
        {
            elapsedMilliseconds = 0;
        }        
        public Timer Start()
        {
            start = DateTime.Now;
            elapsedMilliseconds = 0;
            return this;
        }
        public Timer Stop()
        {
            end = DateTime.Now;
            elapsedMilliseconds += (end.Ticks - start.Ticks) / TimeSpan.TicksPerMillisecond;
            return this;
        }
        public Timer Continue()
        {
            start = DateTime.Now;
            return this;
        }
        public long ElapsedMilliseconds
        {
            get
            {
                return elapsedMilliseconds;
            }

        }
    }
}
