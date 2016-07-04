using CSharpPLINQ.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharpPLINQ.DataAccess
{
    public class ProductDAO
    {
        private readonly string path = Environment.CurrentDirectory + @"\Data\Products.csv";

        private IEnumerable<Product> products;

        public IEnumerable<Product> Products
        {
            get
            {
                if(products == null)
                {
                    products = LoadProducts();
                }
                return products;
            }
        }

        private IEnumerable<Product> LoadProducts()
        {
            if (!File.Exists(path))
            {
                Console.WriteLine($"File doe's not exist: {path}");
                return null;
            }

            var products = File.ReadAllLines(path);

            return from line in products
                   let fields = line.Split(',')
                   select new Product()
                   {
                       ProductID = Convert.ToInt32(fields[0]),
                       ProductName = fields[1].Trim(),
                       UnitPrice = Convert.ToDouble(fields[2])
                   };
        }
    }
}
