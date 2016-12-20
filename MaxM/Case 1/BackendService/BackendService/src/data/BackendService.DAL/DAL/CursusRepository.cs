using Microsoft.EntityFrameworkCore;
using BackendService.Entities.Entities;
using BackendService.DAL.DatabaseContexts;

namespace BackendService.DAL.DAL
{
    public class CursusRepository : BaseRepository<Cursus, int, DatabaseContext>
    {
        private DbContextOptions _options;

        public CursusRepository(DatabaseContext context) : base(context)
        {
        }

        protected override DbSet<Cursus> GetDbSet()
        {
            return _context.Cursussen;
        }

        protected override int GetKeyFrom(Cursus item)
        {
            return item.Id;
        }
    }
}