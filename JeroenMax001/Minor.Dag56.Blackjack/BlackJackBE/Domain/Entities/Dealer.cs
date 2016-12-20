using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackBE.Domain.Entities
{
    public class Dealer
    {
        public DealerHand Hand { get; set; }
        private CardDeck _CardDeck { get; set; }

        public Dealer()
        {
            Console.WriteLine("blabla");
            _CardDeck = new CardDeck();
            Hand = new DealerHand() {  CardsInHand = new List<Card>() { Hit() } };
        }

        public Card Hit()
        {
            return _CardDeck.DealCard();
        }
    }
}
