using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag11.InterfaceDemo
{
    public class Painter : IPainter
    {
        public void Draw()
        {
            Console.WriteLine("=--->");
        }

    }
}
