namespace Structure
{
    public interface IGeldConverter
    {
        /// <summary>
        /// ValutaNaarEuro
        /// </summary>
        /// <param name="euro">Bedrag in Muntsoort</param>
        /// <param name="muntsoort">Muntsoort van bedrag</param>
        /// <returns></returns>
        decimal ValutaNaarEuro(decimal bedrag, Muntsoort muntsoort);

        decimal EuroNaarDukaat(decimal euro);
        decimal EuroNaarFlorijn(decimal euro);
        decimal GuldenNaarEuro(decimal gulden);
        decimal DukaatNaarEuro(decimal dukaat);
        decimal FlorijnNaarEuro(decimal florijn);
    }
}
