using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EFTesten
{
    public class ProductRepository : IRepository<Products, int>
    {
        public static void Main(string[] args)
        {
            var PR = new ProductRepository();
            Products product = PR.Find(78);
            PR.Delete(product);
            PR.Insert(product);

            Console.ReadKey();


        }
        public Products Find(int id)
        {

            using (var context = new NorthwindContext())
            {
                var productenQuery = from product in context.Products.Include(t => t.Category)
                                     where product.ProductId == id
                                     select product;
                return productenQuery.FirstOrDefault();
            }
        }

        public IEnumerable<Products> FindAll()
        {
            using (var context = new NorthwindContext())
            {
                var productenQuery = from product in context.Products.Include(t => t.Category)
                                     select product;
                return productenQuery.ToList();
            }
        }

        public IEnumerable<Products> FindBy(Expression<Func<Products, bool>> filter)
        {
            using (var context = new NorthwindContext())
            {                
                return context.Products.Include(t => t.Category).Where(filter).ToList();
            }
        }

        public void Insert(Products item)
        {
            using (var context = new NorthwindContext())
            {
                try
                {
                    item.Category = ExistingOrInsertCategory(item);
                    
                    context.Products.Add(item);
                    context.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void Update(Products item)
        {
            Products current = OphalenCurrent(item);
            using (var context = new NorthwindContext())
            {
                item.Category = ExistingOrInsertCategory(item);
                current = item;
                             
                context.Products.Update(current);
                context.SaveChanges();
            }
        }
        public void Delete(Products item)
        {
            Products current = OphalenCurrent(item);
            using (var context = new NorthwindContext())
            {
                context.Products.Remove(current);
                context.SaveChanges();
            }
        }

        private Products OphalenCurrent(Products item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            Products current = Find(item.ProductId);
            if (current == null)
            {
                throw new ArgumentNullException();
            }
            return current;
        }

        private Categories ExistingOrInsertCategory(Products item)
        {
            using (var context = new NorthwindContext())
            {
                var categoryQuery = from category in context.Categories
                                    where category.CategoryId == item.CategoryId
                                    select category;
                Categories existingCategory = categoryQuery.FirstOrDefault();
                if (existingCategory == null)
                {
                    if (item.Category == null)
                    {
                        throw new ArgumentNullException();
                    }
                    try
                    {
                        existingCategory = item.Category;
                        context.Categories.Add(existingCategory);
                        context.SaveChanges();
                        
                    }
                    catch (DbUpdateException e)
                    {
                        Debug.WriteLine(e);
                    }
                }
                return existingCategory;
            }
           
        }
    }
}
