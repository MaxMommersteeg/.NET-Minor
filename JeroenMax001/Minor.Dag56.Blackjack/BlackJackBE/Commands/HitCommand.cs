using BlackJackBE.Domain.Entities;

namespace BlackJackBE.Domain.Domain_Service
{
    public class HitCommand
    {
        public Round Round { get; internal set; }
    }
}