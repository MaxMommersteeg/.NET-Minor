using System.Collections.Generic;
using System.Linq;

namespace Minor.Dag05.TDD {
    public class Faculty
    {
        public int CalculateFaculty(int n) {
            for (var i = n - 1; i > 0; i--) {
                n = n * i;
            }
            return n;
        }
    }
}
