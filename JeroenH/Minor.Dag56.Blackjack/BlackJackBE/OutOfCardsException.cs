using System;

namespace BlackJackBE.Domain.Entities
{
    internal class OutOfCardsException : Exception
    {
        public OutOfCardsException()
        {
        }

        public OutOfCardsException(string message) : base(message)
        {
        }

        public OutOfCardsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}