using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Minor.Dag14.EFdemo.Test.DAL
{
    public class AuthorRepository : RepositoryBase<Authors, string, pubsContext>
    {
        public AuthorRepository(pubsContext context) : base(context)
        {
        }

        protected override DbSet<Authors> GetDbSet()
        {
            return _context.Authors;
        }

        protected override string GetKeyFrom(Authors item)
        {
            return item.AuId;
        }
    }
}
