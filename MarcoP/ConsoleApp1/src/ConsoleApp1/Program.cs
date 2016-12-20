using ConsoleApp1.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var odm = new OrderDataMapper();

            var q = odm.FindAllOrders();
            foreach (var item in q)
            {
                Console.WriteLine($"{item.ID} - {item.CustomerName} - {item.OrderRules?.Count}");
            }


            q = odm.FindAllOrders();
            foreach (var item in q)
            {
                Console.WriteLine($"{item.ID} - {item.CustomerName} - {item.OrderRules?.Count}");
            }


        }

        private static void Intitialisation()
        {
            var options = new DbContextOptions<OrderContext>();
            using (var context = new OrderContext(options))
            {
                context.Orders.Add(new Entities.Order
                {
                    CustomerName = "Fatima",
                    OrderRules = new List<Entities.OrderRule>
                    {
                        new Entities.OrderRule { Amount=3, Price=2.50M, Product="Witte bonen" },
                        new Entities.OrderRule { Amount=5, Price=0.63M, Product="Tomaat" },
                        new Entities.OrderRule { Amount=1, Price=12.50M, Product="Pan" },
                    }
                });

                context.SaveChanges();
            }
        }
    }
}
