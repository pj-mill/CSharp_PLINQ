using CSharpPLINQ.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharpPLINQ.DataAccess
{  
    public class OrderDAO
    {
        private readonly string path = Environment.CurrentDirectory + @"\Data\Orders.csv";

        private IEnumerable<Order> orders;
        public IEnumerable<Order> Orders
        {
            get
            {
                if(orders == null)
                {
                    orders = LoadOrders();
                }
                return orders;
            }
        }

        private IEnumerable<Order> LoadOrders()
        {
            if (!File.Exists(path))
            {
                Console.WriteLine($"File doe's not exist: {path}");
                return null;
            }

            var orders = File.ReadAllLines(path);

            return from line in orders
                   let fields = line.Split(',')
                   select new Order()
                   {
                       OrderID = Convert.ToInt32(fields[0]),
                       CustomerID = fields[1].Trim(),
                       OrderDate = DateTime.Parse(fields[2]),
                       ShippedDate = DateTime.Parse(fields[3])
                   };
        }

        public List<Order> GetOrdersForCustomer(string customerID)
        {
            return (from order in Orders
                   where order.CustomerID.CompareTo(customerID) == 0
                   select order).ToList();
        }
    }
}
