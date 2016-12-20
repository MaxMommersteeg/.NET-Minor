using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Minor.Dag16.DAL.Repositories
{
    public class ProductRepository : IRepository<Products, int>
    {
        public ProductRepository()
        {
        }

        public Products Find(int id)
        {
            using(var context = new NorthwindContext())
            {
                return context.Products
                            .Include(product => product.Category)
                            .FirstOrDefault(product => product.ProductId == id);
            }
        }

        public IEnumerable<Products> FindAll()
        {
            using(var context = new NorthwindContext())
            {
                return context.Products
                              .Include(x => x.Category);
            }
        }

        public IEnumerable<Products> FindBy(System.Linq.Expressions.Expression<Func<Products, bool>> filter)
        {
            using(var context = new NorthwindContext())
            {
                return context.Products
                              .Include(x => x.Category)
                              .Where(filter);
            }
        }

        public void Insert(Products item)
        {
            if(item == null)
            {
                throw new ArgumentNullException();
            }

            using(var context = new NorthwindContext())
            {
                try
                {

                    var productCategory = context.Categories.FirstOrDefault(x => x.CategoryId == item.CategoryId);
                    if (productCategory == null)
                    {
                        if (item.Category == null)
                        {
                            throw new ArgumentNullException();
                        }

                        if (String.IsNullOrWhiteSpace(item.Category.CategoryName))
                        {
                            throw new ArgumentNullException();
                        }
                        context.Categories.Add(item.Category);
                        context.SaveChanges();
                    }
                    context.Products.Add(item);
                    context.SaveChanges();
                } 
                catch(DbUpdateException due)
                {
                    Debug.WriteLine(due);
                }
            }
        }

        public void Update(Products item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            using (var context = new NorthwindContext())
            {
                var currentProduct = Find(item.ProductId);   
                if(currentProduct == null)
                {
                    throw new ArgumentNullException();
                }
                currentProduct = item;
                context.Products.Update(currentProduct);
                context.SaveChanges();
            }
        }

        public void Delete(Products item)
        {
            if(item == null)
            {
                throw new ArgumentNullException();
            }

            using(var context = new NorthwindContext())
            {
                var currentProduct = Find(item.ProductId);
                if (currentProduct == null)
                {
                    throw new ArgumentNullException();
                }
                currentProduct = item;
                context.Products.Remove(currentProduct);

                context.SaveChanges();
            }
        }
    }
}
