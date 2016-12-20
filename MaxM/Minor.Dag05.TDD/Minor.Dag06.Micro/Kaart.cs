using System;

namespace Minor.Dag06.Micro {
    public abstract class Kaart
    {
        public decimal Saldo { get; protected set; }

        public Kaart(decimal saldo) {
            Saldo = saldo;
        }

        public abstract void Betalen(decimal bedrag);
    }
}
