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
            Console.ReadKey();
        }
    }

}
