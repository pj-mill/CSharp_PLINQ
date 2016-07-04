using CSharpPLINQ.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharpPLINQ.DataAccess
{
    public class OrderDetailDAO
    {
        private readonly string path = Environment.CurrentDirectory + @"\Data\OrderDetails.csv";
        private IEnumerable<OrderDetail> orderDetails;

        public IEnumerable<OrderDetail> OrderDetails
        {
            get
            {
                if(orderDetails == null)
                {
                    orderDetails = LoadOrderDetails();
                }
                return orderDetails;
            }
        }

        private IEnumerable<OrderDetail> LoadOrderDetails()
        {
            if (!File.Exists(path))
            {
                Console.WriteLine($"File doe's not exist: {path}");
                return null;
            }

            var orders = File.ReadAllLines(path);

            return from line in orders
                   let fields = line.Split(',')
                   select new OrderDetail()
                   {
                       OrderID = Convert.ToInt32(fields[0]),
                       ProductID = Convert.ToInt32(fields[1]),
                       UnitPrice = Convert.ToDouble(fields[2]),
                       Quantity = Convert.ToDouble(fields[3]),
                       Discount = Convert.ToDouble(fields[4])
                   };
        }

        public IEnumerable<OrderDetail> GetOrderDetailsForOrder(int orderid)
        {
            return from orderdetail in OrderDetails
                   where orderdetail.OrderID == orderid
                   select orderdetail;
        }
    }
}
