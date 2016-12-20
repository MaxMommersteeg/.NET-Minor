using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag13.DisposePatternDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var r2d2 = new RobotArm())
            {
                r2d2.TurnLeft(30);
            }

            //RobotArm r2d2 = null;
            //try
            //{
            //    r2d2 = new RobotArm();

            //    r2d2.TurnLeft(30);
            //}
            //finally
            //{
            //    r2d2?.Dispose();
            }            
        }
    }
}
