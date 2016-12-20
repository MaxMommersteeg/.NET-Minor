using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EFTesten
{
    public class Program
    {
        //public static void Main(string[] args)
        //{
        //    #region Opdracht2
        //    Console.WriteLine("Opdracht 2");
        //    using (var context = new NorthwindContext())
        //    {
        //        var dureProductenQuery = from product in context.Products
        //                                 where product.UnitPrice > 100
        //                                 select new
        //                                 {
        //                                     product.ProductName,
        //                                     product.UnitPrice
        //                                 };
        //        foreach (var product in dureProductenQuery)
        //        {
        //            Console.WriteLine($"{product.ProductName} - {product.UnitPrice}");
        //        }
        //    }

        //    #endregion

        //    #region Opdracht 3
        //    Console.WriteLine("Opdracht 3");
        //    using (var context = new NorthwindContext())
        //    {
        //        var dureProductenQuery = from product in context.Products.Include(t => t.Category)
        //                                 where product.Category.CategoryName == "Beverages"
        //                                 select new
        //                                 {
        //                                     product.ProductName,
        //                                     product.QuantityPerUnit
        //                                 };
        //        foreach (var product in dureProductenQuery)
        //        {
        //            Console.WriteLine($"{product.ProductName} - {product.QuantityPerUnit}");
        //        }
        //    }

        //    #endregion

        //    #region Opdracht 4
        //    Console.WriteLine("Opdracht 4");
        //    using (var context = new NorthwindContext())
        //    {
        //        var dureProductenQuery = from product in context.Products.Include(t => t.Category).Include(t => t.Supplier)
        //                                 where product.UnitPrice > 100
        //                                 select new
        //                                 {
        //                                     product.ProductName,
        //                                     product.QuantityPerUnit,
        //                                     product.Supplier.CompanyName,
        //                                     product.Category.CategoryName
        //                                 };
        //        foreach (var product in dureProductenQuery)
        //        {
        //            Console.WriteLine($"{product.ProductName} - {product.QuantityPerUnit} - {product.CategoryName} - {product.CompanyName}");
        //        }
        //    }

        //    #endregion

        //    Console.ReadKey();



        //}
    }
}
