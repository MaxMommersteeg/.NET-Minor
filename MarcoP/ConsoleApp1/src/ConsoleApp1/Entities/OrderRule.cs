using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities
{
    public class OrderRule
    {
        public long ID { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public string Product { get; set; }
    }
}
