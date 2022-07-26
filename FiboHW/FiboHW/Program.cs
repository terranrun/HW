using System;
using System.Diagnostics;

namespace FiboHW
{
    class Program
    {
        static void Main()
        {
            Int32.TryParse(Console.ReadLine(), out int x);
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Console.WriteLine($"{x} = {FiboRecursia(x)}");

            stopWatch.Stop();
        
            Console.WriteLine(stopWatch.Elapsed);

            stopWatch.Start();
            Console.WriteLine($"{x} = {FiboCycle(x)}");
            stopWatch.Stop();

            Console.WriteLine(stopWatch.Elapsed);

        }

        static int FiboRecursia(int n)
        {
            if(n<=1)
            {
                return n;
            }

            return FiboRecursia(n - 1) + FiboRecursia(n - 2);
        }

        static int FiboCycle(int n)
        {
            int fib1=1,fib2 = 1;

          //Int32.TryParse(Console.ReadLine(), out int x);

            int i = 0;
            int sum=0;
            while (i < n - 2)
            {
                sum = fib1 + fib2;
                fib1 = fib2;
                fib2 = sum;
                i = i + 1;
            }

            return sum;
        }
    }
}