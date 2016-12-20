using Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Entities;
using Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.Repository
{
    public class OnderhoudsopdrachtRepository : BaseRepository<Onderhoudsopdracht, long, OnderhoudBeheerContext>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public OnderhoudsopdrachtRepository(OnderhoudBeheerContext context) : base(context)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override DbSet<Onderhoudsopdracht> GetDbSet()
        {
            return _context.Onderhoudsopdrachten;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override long GetKeyFrom(Onderhoudsopdracht item)
        {
            return item.Id;
        }
    }
}
