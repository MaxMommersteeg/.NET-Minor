using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag14.EFdemo.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new pubsContext())
            {
                Boek boek = context.Boeken.SingleOrDefault(b => b.TitleId == "BU9999");

                context.Boeken.Remove(boek);

                context.SaveChanges();
            }
            // InsertBoek();
            // DureBoekenQuery();
        }

        private static void InsertBoek()
        {
            using (var context = new pubsContext())
            {
                var mijnboek = new Boek
                {
                    Price = 13.37M,
                    Title = "How to write a book",
                    TitleId = "BU9999",
                    Type = "Business",
                };
                context.Boeken.Add(mijnboek);

                context.SaveChanges();
            }
            Console.WriteLine("It has been done");
        }

        private static void DureBoekenQuery()
        {
            using (var context = new pubsContext())
            {
                var dureBoekenQueryEager = from boek in context.Boeken.Include(t => t.Pub)
                                           where boek.Price > 20.00M
                                           select boek;
                var dureBoekenQuery = from boek in context.Boeken
                                      where boek.Price > 20.00M
                                      select new
                                      {
                                          boek.Price,
                                          boek.Title,
                                          //boek.Pub.PubName
                                      };

                Console.WriteLine("Dit is de nieuwe!!");
                foreach (var item in dureBoekenQuery)
                {
                    Console.WriteLine($"{item.Price:C2} - {item.Title} - item.PubName");
                }
            }
        }
    }
}
