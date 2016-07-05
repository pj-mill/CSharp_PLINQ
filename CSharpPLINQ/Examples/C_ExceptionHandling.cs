using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;

namespace CSharpPLINQ.Examples
{
    public class C_ExceptionHandling : Z_ExampleBase
    {
        public static void Run()
        {
            PrintManager.PrintTitle("PLINQ - EXCEPTION HANDLING");
            //Example1(); // Exception propagates directly and does not get wrapped into AggregateException
            //Example2(); // Runs the query through to the end and gathers all exceptions and outputs them           
        }

        private static void Example1()
        {
            /*
             * In some cases when PLINQ falls back to sequential execution, and an exception occurs, 
             * the exception may be propagated directly, and not wrapped in an AggregateException. 
             * Also, ThreadAbortExceptions are always propagated directly.
             * In this example, we stop query processing when the exception occurs.
             */
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
            /*
            // EXCEPTION WILL GET CAUGHT HERE IF UNCOMMENTED
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            */
            // EXCEPTION WILL NOT GET CAUGHT HERE, INSTEAD, AN UNHANDLED EXCEPTION GETS DIRECTLY THROWN 
            // IF ALL OTHER CATCH BLOCKS ARE COMMENTED OUT
            catch (AggregateException ex)
            {                
                foreach (var e in ex.InnerExceptions)
                {
                    Console.WriteLine(e.Message);
                    if (e is ArgumentException)
                    {
                        Console.WriteLine("The data source is corrupt. Query stopped.");
                    }
                }
            }
            // EXCEPTION WILL GET CAUGHT HERE
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Example2()
        {
            /*
             * In this example, we continue query processing after the exception occurs.
             */
            var customers = DataManager.CustomerManager.GetCustomersAsString();

            try
            {
                ProcessData(customers);                
            }

            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    Console.WriteLine(e.Message);
                    if (e is ArgumentException)
                    {
                        Console.WriteLine("The data source is corrupt. Query stopped.");
                    }
                    else
                    {
                        throw e;
                    }
                }
            }
        }

        private static void ProcessData(string[] customers)
        {
            /*
             * We will deliberatly grab cities with the letter 'C' and then throw an error because they contain the letter 'C' !?!
             * We will gather ALL exceptions, wrap them in an AggregateException and throw that.
             */
            var parallelQuery = from cust in customers.AsParallel()
                                let fields = cust.Split(',')
                                where fields[3].StartsWith("C")
                                select new { city = fields[3], thread = Thread.CurrentThread.ManagedThreadId };

            ConcurrentQueue<Exception> exceptions = new ConcurrentQueue<Exception>();

            foreach(var cust in parallelQuery)
            {
                try
                {
                    if (cust.city.Contains('C'))
                    {
                        throw new ArgumentException("City contains the letter 'C'");
                    }
                    else
                    {
                        Console.WriteLine(cust.city);
                    }
                }
                catch (Exception ex)
                {
                    exceptions.Enqueue(ex);
                }
            }

            // 
            if(exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
