using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace WorkingWithEntityFramework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using(var context = new NorthwindContext())
            {
                #region Vraag 2 & 4 & 5(?)

                var productsMoreThan100Query = context.Products
                                                      .Include(product => product.Category)
                                                      .Include(product => product.Supplier)
                                                      .Where(product => product.UnitPrice > 100);

                Console.WriteLine("Vraag 2 & 4:");
                foreach(var product in productsMoreThan100Query)
                {
                    Console.WriteLine($"{product.ProductName} - {product.UnitPrice} - {product.Category.CategoryName} - {product.Supplier.CompanyName}");
                }

                #endregion

                #region Vraag 3

                var beveragesProductNameQuantityQuery = context.Products
                                            .Include(product => product.Category)
                                            .Where(product => product.Category.CategoryName == "Beverages")
                                            .Select(product => new { product.ProductName, product.QuantityPerUnit });

                Console.WriteLine("Vraag 3:");
                foreach (var beverage in beveragesProductNameQuantityQuery)
                {
                    Console.WriteLine($"{beverage.ProductName} - {beverage.QuantityPerUnit}");
                }

                #endregion
            }

            Console.ReadKey();
        }
    }
}
