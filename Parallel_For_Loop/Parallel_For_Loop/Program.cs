using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Collections.Concurrent;

namespace Parallel_For_Loop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Double> sequentialList = new List<double>();
            ConcurrentBag<double> parallelBag = new ConcurrentBag<double>();

            Stopwatch sw1 = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();
            //regular for loop
            Console.WriteLine("\n\nSequential for loop...\n");
            sw1.Start();
            for(int i = 1; i < 100000000; i++)
            {
                double result = Math.Sqrt(Math.Log(i)+5);
                //Console.WriteLine("index: {0} result {1}", i, result);
                sequentialList.Add(result);
            }
            sw1.Stop();
            //Parallel For
            /*
             *  public static ParallelLoopResult For(
	            int fromInclusive,
	            int toExclusive,
	            Action<int> body
                )
                The body delegate is invoked once for each value in the iteration range
                (fromInculsive, toExclusive).
                It is provided with the iteration count (Int32) as a parameter.
             */
            Console.WriteLine("Parallel for loop...");
            sw2.Start();
            Parallel.For(1, 100000000, i =>
              {
                  double result = Math.Sqrt(Math.Log(i) + 5);
                  //Console.WriteLine("index: {0}\t taskID: {1}\t result {2}", i, Task.CurrentId, result);
                  parallelBag.Add(result);
              });
            sw2.Stop();

            //Display elapsed time
            Console.WriteLine("\n\nSequential time: {0}", sw1.Elapsed);
            Console.WriteLine("\n\nParallel time: {0}", sw2.Elapsed);

            Console.ReadLine();
        }
    }
}
//Exercise:
/*
 * new project (console application)
 * Create a list and populate it with 1000 values
 * use regular foreach to compute the square root of each element and display the result
 * use parallel ForEach to compute the square root of each element and display the result
 */
