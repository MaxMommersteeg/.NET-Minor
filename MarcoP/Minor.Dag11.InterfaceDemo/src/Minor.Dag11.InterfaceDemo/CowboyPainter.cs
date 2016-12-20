using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag11.InterfaceDemo
{
    public class CowboyPainter : IPainter, ICowboy
    {

        //public void Draw()
        //{
        //    Console.WriteLine("paint paint");
        //    Console.WriteLine("pjoe pjoe");
        //}
        void IPainter.Draw()
        {
            Console.WriteLine("paint paint");
        }

        void ICowboy.Draw()
        {
            Console.WriteLine("pjoe pjoe");
        }

    }
}
