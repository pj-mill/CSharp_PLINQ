using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace CSharpPLINQ.Examples
{
    public class F_MergeOptions
    {
        public static void Run()
        {
            NotBufferedExample();
            FullyBufferedExample();
            AutoBufferedExample();
        }

        private static void NotBufferedExample()
        {
            var nums = Enumerable.Range(1, 100000);
            
            var scanLines = from n in nums.AsParallel().WithMergeOptions(ParallelMergeOptions.NotBuffered)
                            where n % 2 == 0
                            select ExpensiveFunc(n);

            Stopwatch sw = Stopwatch.StartNew();
            foreach (var line in scanLines)
            {
                //Console.WriteLine(line);
            }

            Console.WriteLine($"Elapsed time (NotBuffered): {sw.ElapsedMilliseconds} ms. ");
        }

        private static void FullyBufferedExample()
        {
            var nums = Enumerable.Range(1, 100000);


            var scanLines = from n in nums.AsParallel().WithMergeOptions(ParallelMergeOptions.FullyBuffered)
                            where n % 2 == 0
                            select ExpensiveFunc(n);

            Stopwatch sw = Stopwatch.StartNew();
            foreach (var line in scanLines)
            {
                //Console.WriteLine(line);
            }

            Console.WriteLine($"Elapsed time (FullyBuffered): {sw.ElapsedMilliseconds} ms. ");
        }

        private static void AutoBufferedExample()
        {
            var nums = Enumerable.Range(1, 100000);

            var scanLines = from n in nums.AsParallel().WithMergeOptions(ParallelMergeOptions.AutoBuffered)
                            where n % 2 == 0
                            select ExpensiveFunc(n);

            Stopwatch sw = Stopwatch.StartNew();
            foreach (var line in scanLines)
            {
                //Console.WriteLine(line);
            }
            
            Console.WriteLine($"Elapsed time (AutoBuffered): {sw.ElapsedMilliseconds} ms..");
        }

        // A function that demonstrates what a fly
        // sees when it watches television :-)
        private static string ExpensiveFunc(int i)
        {
            Thread.SpinWait(200000);
            return String.Format("{0} *****************************************", i);
        }
    }
}
