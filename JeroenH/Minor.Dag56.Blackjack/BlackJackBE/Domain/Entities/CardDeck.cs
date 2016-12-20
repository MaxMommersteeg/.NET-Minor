using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackBE.Domain.Entities
{
    public class CardDeck
    {
        private Card[] Cards { get; set; }
        private int CardCount { get; set; }
        private const int DeckSize = 52;

        public CardDeck()
        {
            CardCount = DeckSize;
            Cards = new Card[DeckSize];
            for (int i = 1; i < DeckSize / 4 + 1; i++)
            {
                Cards[0 + i * 13] = Card.Twee;
                Cards[1 + i * 13] = Card.Drie;
                Cards[2 + i * 13] = Card.Vier;
                Cards[3 + i * 13] = Card.Vijf;
                Cards[4 + i * 13] = Card.Zes;
                Cards[5 + i * 13] = Card.Zeven;
                Cards[6 + i * 13] = Card.Acht;
                Cards[7 + i * 13] = Card.Negen;
                Cards[8 + i * 13] = Card.Tien;
                Cards[9 + i * 13] = Card.Boer;
                Cards[10 + i * 13] = Card.Vrouw;
                Cards[11 + i * 13] = Card.Heer;
                Cards[12 + i * 13] = Card.Aas;
            }

            Shuffle();
        }

        private void Shuffle()
        {
            Random rnd = new Random();
            Cards = Cards.OrderBy(x => rnd.Next()).ToArray();
        }

        public Card DealCard()
        {
            if(CardCount>0)
            {
                CardCount--;
                CardDealtEvent cde = new CardDealtEvent() { Card = Cards[CardCount] };
                return Cards[CardCount];
            }
            else
            {
                throw new OutOfCardsException();
            }

        }
    }
}
