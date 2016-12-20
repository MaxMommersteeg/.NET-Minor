using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag33.MoQDemo
{
    public class AddProductCommand
    {
        public long Ordernumber { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
    }
}
