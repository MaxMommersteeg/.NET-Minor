using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities
{
    public class Order
    {
        public long ID { get; set; }
        public string CustomerName { get; set; }
        public List<OrderRule> OrderRules { get; set; }
    }
}
