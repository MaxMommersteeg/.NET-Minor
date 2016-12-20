using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Converters;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Incoming;

namespace Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Managers
{
    public interface IRdwApkManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apkRequestCommand"></param>
        /// <returns></returns>
        KeuringsVerzoekAntwoord HandleApkKeuringsVerzoek(ApkKeuringsVerzoekCommand apkCommand);
    }
}
