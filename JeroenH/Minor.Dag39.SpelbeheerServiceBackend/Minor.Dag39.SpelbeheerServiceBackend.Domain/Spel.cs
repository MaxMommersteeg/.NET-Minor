using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag39.SpelbeheerServiceBackend.Domain
{
    public class Spel
    {
        public int SpelId { get; set; }

        public string SpelNaam { get; set; }

        public List<Speler> SpelerIds { get; set; }

        public int WinnerId { get; set; }


    }
}