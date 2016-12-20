using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackBE.Domain.Entities
{
    public class Round
    {
        public Dealer Dealer { get; set; }
        public Player Player { get; set; }
    }
}
