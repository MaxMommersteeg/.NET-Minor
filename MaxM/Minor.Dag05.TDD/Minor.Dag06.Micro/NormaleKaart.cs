using System;

namespace Minor.Dag06.Micro {
    public class NormaleKaart : Kaart
    {
        public NormaleKaart(decimal saldo) : base(saldo) {

        }

        public override void Betalen(decimal bedrag) {
            if (bedrag > Saldo)
                throw new ArgumentOutOfRangeException("Saldo te laag");

            Saldo = Saldo - bedrag;
        }
    }
}
