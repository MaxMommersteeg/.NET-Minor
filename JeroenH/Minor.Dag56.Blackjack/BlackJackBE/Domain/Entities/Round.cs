using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackBE.Domain.Entities
{
    public class Round
    {
        public CardDeck CardDeck { get; set; }
        public Hand DealerHand { get; set; }
        public Hand PlayerHand { get; set; }
    }
}
