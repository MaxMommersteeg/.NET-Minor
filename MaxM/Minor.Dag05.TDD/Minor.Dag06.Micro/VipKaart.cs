namespace Minor.Dag06.Micro {
    public class VipKaart : Kaart {

        public decimal Korting { get; set; }

        public VipKaart(decimal saldo, decimal korting) : this(saldo) {
            Korting = korting;
        }

        public VipKaart(decimal saldo) : base(saldo) {
        }

        public override void Betalen(decimal bedrag) {
            var kortingsBedrag = ((bedrag / 100) * Korting);
            var totaalBedrag = (bedrag - kortingsBedrag);

            Saldo = (Saldo - totaalBedrag);
        }
    }
}
