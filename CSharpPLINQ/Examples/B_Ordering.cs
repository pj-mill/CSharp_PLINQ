using System;
using System.Linq;

namespace CSharpPLINQ.Examples
{
    public class B_Ordering : Z_ExampleBase
    {
        public static void Run()
        {
            PrintManager.PrintTitle("PLINQ - ORDERING");

            var customers = from customer in DataManager.CustomerManager.Customers select customer;


            // Take the first 20, preserving the original order
            PrintManager.PrintSubTitle("TOP 20 CUSTOMERS ORDERED");            
            var firstTwentyCustomers = customers.AsParallel().AsOrdered().Take(20);

            foreach (var customer in firstTwentyCustomers)
            {
                Console.WriteLine($"{customer.CustomerName}");
            }


            // All elements in reverse order.
            PrintManager.PrintSubTitle("CUSTOMERS REVERSE ORDER");            
            var reverseOrder = customers.AsParallel().AsOrdered().Reverse();

            foreach (var customerRev in reverseOrder)
            {
                Console.WriteLine($"{customerRev.CustomerName}");
            }


            // Get the element at a specified index. 
            PrintManager.PrintSubTitle("SINGLE CUSTOMER ORDERED");
            var singleCustomer = customers.AsParallel().AsOrdered().ElementAt(48);
            {
                Console.WriteLine($"{singleCustomer.CustomerName}");
            }
        }
    }
}
