using CSharpPLINQ.DataAccess;
using System;
using System.Threading.Tasks;

namespace CSharpPLINQ
{
    class Program
    {
        static DataAccessManager DataManager = new DataAccessManager();
        static void Main(string[] args)
        {
            //CustomersDAO.Test();
            Parallel.ForEach(DataManager.CustomerManager.Customers, (customer) =>
            {
                Console.WriteLine($"{customer.CustomerName}");
            });
        }
    }
}
