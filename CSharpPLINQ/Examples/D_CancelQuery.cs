using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpPLINQ.Examples
{
    public class D_CancelQuery
    {
        public static void Run()
        {
            int[] nums = Enumerable.Range(0, 100000).ToArray();
            int[] results = null;
            CancellationTokenSource cts = new CancellationTokenSource();

            // Start a new asynchronous task that will cancel the operation from another thread.
            Task.Factory.StartNew(() =>
            {
                SimulateUserClickingCancelButton(cts);
            });

            try
            {
                results = (from num in nums.AsParallel().WithCancellation(cts.Token)
                           where num % 3 == 0
                           orderby num descending
                           select num).ToArray();


                if (results != null)
                {
                    for(int i = 0; i < results.Length / 200; i++)
                    {
                        cts.Token.ThrowIfCancellationRequested();
                        Console.WriteLine(results[i]);
                    }
                }
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (AggregateException ae)
            {
                if (ae.InnerExceptions != null)
                {
                    foreach (Exception e in ae.InnerExceptions)
                    {
                        Console.WriteLine(e.Message);
                    }                        
                }
            }
            finally
            {
                cts.Dispose();
            }
            

            
        }

        private static void SimulateUserClickingCancelButton(CancellationTokenSource cts)
        {
            Random r = new Random();
            Thread.Sleep(r.Next(50, 100));
            cts.Cancel();
            Console.WriteLine("Process cancelled");
        }
    }
}
