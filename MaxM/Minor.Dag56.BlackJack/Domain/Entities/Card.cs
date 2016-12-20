namespace Domain.Entities
{
    public enum SuitType { Spades, Hearts, Clubs, Diamonds };

    public class Card
    {
        public int Value { get; set; }
        public SuitType Suit { get; set; }
    }
}
