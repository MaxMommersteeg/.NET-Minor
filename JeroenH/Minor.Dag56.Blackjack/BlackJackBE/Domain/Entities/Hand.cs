using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackBE.Domain.Entities
{
    public class Hand
    {
        public List<Card> CardsInHand { get; set; }
    }
}
