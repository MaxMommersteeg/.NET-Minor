using System;

namespace Minor.Dag06.MicroOefening
{
    public class Kaart
    {
        private decimal v;

        public decimal Saldo { get; private set; }


        public Kaart(decimal beginsaldo)
        {
            Saldo = beginsaldo;
        }

        public virtual void Betaal(decimal bedrag)
        {
            if (bedrag < 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                Saldo -= bedrag;
            }
        }
    }
}