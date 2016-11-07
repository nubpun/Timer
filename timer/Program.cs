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
                for (int i = 0; i < 111231445; i++)
                    s += i - s + 1;

            }
            Console.WriteLine(timer.ElapsedMilliseconds);

            using (timer.Continue())
            {
                for (int i = 0; i < 1231445; i++)
                    s += i - s + 2;
            }
            Console.WriteLine(timer.ElapsedMilliseconds);
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

        private bool isDisposed = false;
        ~Timer()
        {
            Dispose(false);
        }
        protected virtual void Dispose(bool fromDisposeMethod)
        {
            if (!isDisposed)
            {
                if (fromDisposeMethod)
                {
                    Console.WriteLine("Очистка управляемых ресурсов в {0}");
                }
                Console.WriteLine("Очистка неуправляемых ресурсов в {0}");
                isDisposed = true;
            }
        }
        public Timer Start()
        {
            start = DateTime.Now;
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
            get {
                return elapsedMilliseconds;
            }

        }
    }
}
