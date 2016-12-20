using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag35.VoorbeeldKlasse
{
    public class MyMath
    {
        [Test(25, Output = 5)]
        [Test(-25, ExpectedException = "ArgumentOutOfRangeException")]

        public int SquareRootInt(int n)
        {
            if(n<0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return (int)Math.Sqrt(n);
        }

        [Test(2.0, 3.0, Output = 2.5)]
        [Test(12.5, 15.0, Output = 13.75)]
        public double Average(double a, double b)

        {
            return (a+b)/2;
        }

        [Test(2.0, 3.0, Output = 6.0)]
        protected internal double multiply(double a, double b)
        {
            return (a * b);
        }

    }
}
