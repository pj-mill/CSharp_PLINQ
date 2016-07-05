using System;
using System.Linq;

namespace CSharpPLINQ.Examples
{
    /// <summary>
    /// Calculate the standard deviation of a sequence of integers
    /// </summary>
    public class E_AggregateFunction
    {
        public static void Run()
        {
            int[] nums = new int[10000];
            Random r = new Random();

            for(int i = 0; i < nums.Length; i++)
            {
                nums[i] = r.Next(10, 20);
            }

            // Get the mean
            double mean = nums.AsParallel().Average();


            double standardDeviation = nums.AsParallel().Aggregate(
                0.0, // initialize subtotal. Use decimal point to tell the compiler that this is a double type
                (subtotal, item) => subtotal + Math.Pow((item-mean),2), // do this on each thread
                (total, thisThread) => total + thisThread,              // aggregate results after all threads are done.
                (finalSum) => Math.Sqrt((finalSum / (nums.Length - 1))) // perform standard deviation calc on the aggregated result.
            );

            Console.WriteLine($"Mean value is = {mean}");
            Console.WriteLine($"Standard deviation is {standardDeviation}");
        }
    }
}
