using CSharpPLINQ.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharpPLINQ.DataAccess
{
    public class CustomerDAO
    {
        private readonly string path = Environment.CurrentDirectory + @"\Data\Customers.csv";

        private IEnumerable<Customer> customers;
        public IEnumerable<Customer> Customers
        {
            get
            {
                if(customers == null)
                {
                    customers = LoadCustomers();
                }
                return customers;
            }
        }

        private IEnumerable<Customer> LoadCustomers()
        {
            if (!File.Exists(path))
            {
                Console.WriteLine($"File doe's not exist: {path}");
                return null;
            }

            var customers = File.ReadAllLines(path);

            return from line in customers
                   let fields = line.Split(',')
                   select new Customer()
                   {
                       CustomerID = fields[0].Trim(),
                       CustomerName = fields[1].Trim(),
                       Address = fields[2].Trim(),
                       City = fields[3].Trim(),
                       PostalCode = fields[4].Trim()
                   };
        }

        public string[] GetCustomersAsString()
        {
            if (!File.Exists(path))
            {
                Console.WriteLine($"File doe's not exist: {path}");
                return null;
            }

            return File.ReadAllLines(path);
        }
    }
}
