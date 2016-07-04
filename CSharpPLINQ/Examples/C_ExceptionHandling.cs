using System;
using System.Linq;

namespace CSharpPLINQ.Examples
{
    public class C_ExceptionHandling : Z_ExampleBase
    {
        public static void Run()
        {
            PrintManager.PrintTitle("PLINQ - EXCEPTION HANDLING");
            
            var customers = DataManager.CustomerManager.Customers.AsParallel().Take(20);

            try
            {
                foreach (var customer in customers)
                {
                    if (customer.CustomerName.Contains('C'))
                    {
                        Console.WriteLine($"{customer.CustomerName}");
                    }
                    else
                    {
                        throw new ArgumentException("Names does not contain a 'C'");
                    }
                }
            }

            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // In this design, we stop query processing when the exception occurs.
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    /*
                     * In some cases when PLINQ falls back to sequential execution, and an exception occurs, 
                     * the exception may be propagated directly, and not wrapped in an AggregateException. 
                     * Also, ThreadAbortExceptions are always propagated directly.
                     */
                    Console.WriteLine(e.Message);
                    if (e is ArgumentException)
                    {
                        Console.WriteLine("The data source is corrupt. Query stopped.");
                    }                        
                }
            }
        }
    }
}
