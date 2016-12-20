using Minor.Dag35.MarcosCooleAttributen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag35.TtyItOutLibje
{
    [Developer("Marco")]
    public class MyMath
    {
        [Developer("Tante Truus", Date = "2016-11-09")]
        [Developer("Marco")]
        public int Fac(int n)
        {
            return n<=1 ? 1 : n * Fac(n-1);
        }

        [Developer("Marco")]
        private int Plus21(int n)
        {
            return n + 21;
        }

        [Developer("Marco")]
        protected int Square(int n)
        {
            return n*n;
        }
    }

    [Developer("Tante Truus")]
    public class HerMath
    {
        [Developer("Tante Truus", Date = "2016-11-09")]
        [Developer("Marco")]
        public int PlusEen(int n)
        {
            return n + 21;
        }
    }


    [Developer("007")]
    internal class SecretMath
    {
        public int LicenceTo(int n)
        {
            return n + 21;
        }
    }
}
