using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpPLINQ.Examples
{
    /// <summary>
    /// Demonstrates deferred excecution with PLINQ
    /// </summary>
    public class H_DeferredExecution : Z_ExampleBase
    {
        public static void Run()
        {

            PrintManager.PrintTitle("PLINQ - DEFERRED EXECUTION");

            // Set up the data source
            int[] intArr = new int[100];
            for (int i = 0; i < intArr.Length; i++)
            {
                intArr[i] = i;
            }


            // Define a PLINQ query
            IEnumerable<double> squaredRoots = intArr.AsParallel().Select(
                num =>
                {
                    return Math.Sqrt(num);
                }
            );
            // (Query not executed at this point yet) => (We could though by appending '.ToList();')


            // Execute the query
            double total = 0;
            foreach (var root in squaredRoots)
            {
                total += root;
            }

            Console.WriteLine($"Total: {total}"); ;

        }
    }
}
