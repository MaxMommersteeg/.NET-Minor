using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Generated;

namespace Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Agents
{
    public interface IRdwApkAgent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        string SendApkKeuringsVerzoek(string xml);
    }
}
