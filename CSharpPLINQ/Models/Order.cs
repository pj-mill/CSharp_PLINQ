using System;
using System.Collections.Generic;

namespace CSharpPLINQ.Models
{
    public class Order
    {
        public Order(){ OrderDetails = new List<OrderDetail>(); }
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
