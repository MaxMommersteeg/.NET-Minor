using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Minor.DagXX.XXX1.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Minor.DagXX.XXX1.DAL.DatabaseContexts;

namespace Minor.DagXX.XXX1.DAL.DAL
{
    public class EntityRepository
        : BaseRepository<Entity, int, DatabaseContext>
    {
        private DbContextOptions _options;

        public EntityRepository(DatabaseContext context) : base(context)
        {
        }

        protected override DbSet<Entity> GetDbSet()
        {
            return _context.Entities;
        }

        protected override int GetKeyFrom(Entity item)
        {
            return item.Id;
        }
    }
}