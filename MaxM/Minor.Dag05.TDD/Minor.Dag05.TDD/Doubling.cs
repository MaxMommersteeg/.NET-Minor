using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag05.TDD
{
    public class Doubling
    {
        public double FindStrangeDouble() {

            var numbers = new List<int>(Enumerable.Range(0, int.MaxValue - 1));

            for (var i = 0.0D; i < double.MaxValue - 1; i += 0.01D) {
                if (i == i + 1)
                    return i;
            }
            return 0.0D;
        }
    }
}
