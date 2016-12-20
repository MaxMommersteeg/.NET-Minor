using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Generated;
using System;
using System.Globalization;

namespace Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Converters
{
    public class KeuringsVerzoekConverter : IKeuringsVerzoekConverter
    {
        /// <summary>
        /// Extract logical KeuringsVerzoekAntwoord for front-ends
        /// </summary>
        /// <param name="registratie"></param>
        /// <returns></returns>
        public KeuringsVerzoekAntwoord ToKeuringsVerzoekAntwoord(Keuringsregistratie registratie)
        {
            if(registratie == null)
            {
                throw new ArgumentNullException("Keuringsregistratie should not be null");
            }
            if(registratie.Steekproef == null) 
            {
                throw new ArgumentNullException("Steekproef on Keuringsregistratie should not be null");
            }

            var registratieAntwoord = new KeuringsVerzoekAntwoord();
            registratieAntwoord.IsSteekProef = registratie.Steekproef.Nil != "true";

            if(registratieAntwoord.IsSteekProef)
            {
                DateTime parsedSteekProefDateTime;
                if(DateTime.TryParseExact(registratie.Steekproef.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedSteekProefDateTime))
                {
                    registratieAntwoord.SteepkProefDate = parsedSteekProefDateTime;
                }
                else
                {
                    registratieAntwoord.SteepkProefDate = null;
                }
            }
            return registratieAntwoord;
        }
    }
}
