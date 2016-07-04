using System.Collections.Generic;

namespace CSharpPLINQ.Models
{
    public class Customer
    {
        public Customer() { Orders = new List<Order>(); }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public List<Order> Orders { get; set; }
    }
}
