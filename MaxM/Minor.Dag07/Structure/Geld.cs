using System;
using System.Globalization;

namespace Structure
{
    public struct Geld : IEquatable<Geld>
    {
        private readonly decimal _bedrag;
        private readonly Muntsoort _muntsoort;
        private readonly IGeldConverter _geldConverter;

        /// <summary>
        /// Geld Constructor, ontvangt bedrag en muntsoort
        /// </summary>
        /// <param name="bedrag">bedrag als decimal</param>
        /// <param name="muntsoort">muntsoort als Muntsoort</param>
        public Geld(decimal bedrag, Muntsoort muntsoort)
        {
            _muntsoort = muntsoort;
            _geldConverter = new GeldConverter();
            _bedrag = _geldConverter.ValutaNaarEuro(bedrag, _muntsoort);
        }

        /// <summary>
        /// ToString, geeft muntsoort samen met bedrag terug.
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return string.Format("{0} {1:N2}", _muntsoort, _bedrag);
        }

        public bool Equals(Geld other)
        {
            if (_bedrag != other._bedrag)
            {
                return false;
            }

            if (_muntsoort != other._muntsoort)
            {
                return false;
            }

            return true;
        }

        public static Geld operator +(Geld g1, Geld g2)
        {
            var bedrag = g1._bedrag + g2._bedrag;
            return new Geld(bedrag, Muntsoort.Euro);
        }

        public static Geld operator -(Geld g1, Geld g2)
        {
            var bedrag = g1._bedrag - g2._bedrag;
            return new Geld(bedrag, Muntsoort.Euro);
        }

        public static bool operator ==(Geld g1, Geld g2)
        {
            return g1.Equals(g2);
        }

        public static bool operator !=(Geld g1, Geld g2)
        {
            return !g1.Equals(g2);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj);
        }

        public override int GetHashCode()
        {
            return 1;
        }
    }
}
