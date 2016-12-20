using System;

namespace Structure
{
    public class GeldConverter : IGeldConverter
    {
        /// <summary>
        /// ValutaNaarEuro
        /// </summary>
        /// <param name="bedrag"></param>
        /// <param name="muntsoort"></param>
        /// <returns></returns>
        public decimal ValutaNaarEuro(decimal bedrag, Muntsoort muntsoort)
        {
            switch (muntsoort)
            {
                case Muntsoort.Onbekend:
                {
                    throw new OnbekendeValuteExceptie();
                }
                case Muntsoort.Euro:
                {
                    return bedrag;
                }
                case Muntsoort.Gulden:
                {
                    var euro = GuldenNaarEuro(bedrag);
                    return EuroNaarGulden(euro);
                }
                case Muntsoort.Dukaat:
                {
                    var euro = DukaatNaarEuro(bedrag);
                    return EuroNaarDukaat(euro);
                }
                case Muntsoort.Florijn:
                {
                    var euro = FlorijnNaarEuro(bedrag);
                    return EuroNaarFlorijn(euro);
                }
            }
            throw new OnbekendeValuteExceptie();
        }

        public decimal EuroNaarDukaat(decimal euro)
        {
            return euro * 11.238921M;
        }

        public decimal EuroNaarFlorijn(decimal euro)
        {
            return euro * 2.20371M;
        }

        public decimal EuroNaarGulden(decimal euro)
        {
            return euro * 2.20371M;
        }

        public decimal GuldenNaarEuro(decimal gulden)
        {
            return gulden / 2.20371M;
        }

        public decimal DukaatNaarEuro(decimal dukaat)
        {
            return dukaat / 11.238921M;
        }

        public decimal FlorijnNaarEuro(decimal florijn)
        {
            return florijn / 2.20371M;
        }
    }
}
