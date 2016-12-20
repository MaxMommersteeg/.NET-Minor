using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag21.CAS.BackEnd.Entities.Entities
{
    public class Cursus
    {
        public int CursusId { get; set; }
        public string Cursuscode { get; set; }
        public string Titel { get; set; }
        public int Duur { get; set; }

    }
}