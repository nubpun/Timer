using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
                Thread.Sleep(100);

            }
            Console.WriteLine(timer.ElapsedMilliseconds);
            
            using (timer.Continue())
            {
                Thread.Sleep(300);
            }
            Console.WriteLine(timer.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }

}
