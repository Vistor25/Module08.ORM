using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFORM.Models;

namespace ConsoleAppEF
{
    class Program
    {
        static void Main(string[] args)
        {
            Northwind db = new Northwind();

            var resultQuery = db.Order_Details.Select(item => new { item.Product.Category.CategoryName, item.Order })
                .GroupBy(key => key.CategoryName, (categoryname, enumerable) => new { Category = categoryname, Orders = enumerable.Where(item => item.CategoryName == categoryname).Select(item => item.Order).ToList() });

            foreach (var category in resultQuery)
            {
                Console.WriteLine($"Category: {category.Category}");

                foreach (var order in category.Orders)
                {
                    Console.WriteLine($"Order: {order.OrderID}");
                    var products = order.Order_Details.Select(item => item.Product).Where(item => item.Category.CategoryName == category.Category);
                    foreach (var product in products)
                    {
                        Console.WriteLine($"Product: {product.ProductName}");
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
