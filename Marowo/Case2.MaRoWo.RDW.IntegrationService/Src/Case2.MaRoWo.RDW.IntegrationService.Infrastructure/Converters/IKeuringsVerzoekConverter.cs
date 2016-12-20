using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Generated;

namespace Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Converters
{
    public interface IKeuringsVerzoekConverter
    {
        KeuringsVerzoekAntwoord ToKeuringsVerzoekAntwoord(Keuringsregistratie registratie);
    }
}
