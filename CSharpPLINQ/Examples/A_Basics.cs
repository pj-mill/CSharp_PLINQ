using CSharpPLINQ.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace CSharpPLINQ.Examples
{

    public class A_Basics : ExampleBase
    {

        public static void Run()
        {
            PrintManager.PrintTitle("PLINQ - BASICS");

            // Vars
            Stopwatch stopWatch = new Stopwatch();

            // NON Parallel Queries
            var customers = from customer in DataManager.CustomerManager.Customers select customer;
            var customersFiltered = from customer in DataManager.CustomerManager.Customers
                                    where customer.CustomerName.Contains("L")
                                    select customer;

            // Parallel Queries
            var customersParallel = from customer in DataManager.CustomerManager.Customers.AsParallel() select customer;
            var customersFilteredParallel = from customer in DataManager.CustomerManager.Customers.AsParallel()
                                            where customer.CustomerName.Contains("L")
                                            select customer;

            PrintManager.PrintSubTitle("ALL CUSTOMER NAMES: NON PARALLEL");
            stopWatch = Stopwatch.StartNew();
            foreach(Customer cust in customers)
            {
                Console.WriteLine(cust.CustomerName);
            }
            PrintManager.PrintTime(stopWatch.Elapsed.TotalSeconds);


            PrintManager.PrintSubTitle("ALL CUSTOMER NAMES: PARALLEL");
            stopWatch = Stopwatch.StartNew();
            foreach (Customer cust in customersParallel)
            {
                Console.WriteLine(cust.CustomerName);
            }
            PrintManager.PrintTime(stopWatch.Elapsed.TotalSeconds);

            PrintManager.PrintSubTitle("FILTERED CUSTOMER NAMES: NON PARALLEL");
            stopWatch = Stopwatch.StartNew();
            foreach (Customer cust in customersFiltered)
            {
                Console.WriteLine(cust.CustomerName);
            }
            PrintManager.PrintTime(stopWatch.Elapsed.TotalSeconds);


            PrintManager.PrintSubTitle("FILTERED CUSTOMER NAMES: PARALLEL");
            stopWatch = Stopwatch.StartNew();
            foreach (Customer cust in customersFilteredParallel)
            {
                Console.WriteLine(cust.CustomerName);
            }
            PrintManager.PrintTime(stopWatch.Elapsed.TotalSeconds);
        }
    }
}
