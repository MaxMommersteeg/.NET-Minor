using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1.DAL
{
    public class OrderDataMapper
    {
        DbContextOptions<OrderContext> _options;

        public OrderDataMapper()
        {
            _options = new DbContextOptions<OrderContext>();
        }
        public IEnumerable<Entities.Order> FindAllOrders()
        {
            using (var context = new OrderContext(_options))
            {
                return context.Orders.Include(o => o.OrderRules).ToList();
            }
        }

        public void Add(Entities.Order order)
        {
            using (var context = new OrderContext(_options))
            {
                context.Orders.Add(order);

                context.SaveChanges();
            }
        }
    }
}
