using Case2.MaRoWo.RDW.IntegrationService.Domain.Entities;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Repositories {
    public class ApkAanvraagLogRepository : BaseRepository<ApkAanvraagLog, long, RdwContext> 
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public ApkAanvraagLogRepository(RdwContext context) : base(context) 
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override DbSet<ApkAanvraagLog> GetDbSet() 
        {
            return _context.ApkAanvraagLogs;   
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override long GetKeyFrom(ApkAanvraagLog item) 
        {
            return item.Id;
        }
    }
}
