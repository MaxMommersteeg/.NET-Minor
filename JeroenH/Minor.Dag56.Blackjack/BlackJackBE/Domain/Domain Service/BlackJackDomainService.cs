using BlackJackBE.Domain.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackBE.Domain.Domain_Service
{
    public class BlackJackDomainService
    {
        public Round StartGame(StartGameCommand command)
        {
            CardDeck cardDeck = new CardDeck();
            Round round = new Round() {
                CardDeck = cardDeck,
                DealerHand = new Hand() { CardsInHand = new List<Card>() { cardDeck.DealCard() } },
                PlayerHand = new Hand() { CardsInHand = new List<Card>() { cardDeck.DealCard(), cardDeck.DealCard() } }
            };
            GameStartedEvent gse = new GameStartedEvent() { round = round };

            return round;
        }
    }
}
