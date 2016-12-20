using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Minor.Dag39.SpelbeheerServiceBackend.DAL.DAL;
using Minor.Dag39.SpelbeheerServiceBackend.Domain;
using Minor.Dag39.SpelbeheerServiceBackend.DAL.DatabaseContexts;

namespace Minor.Dag39.SpelbeheerServiceBackend.WebApi.Test.Mocks
{
    public class RepositoryMock
        : SpelRepository
{
        public int TimesCalled { get; set; }
        public RepositoryMock(DatabaseContext context) : base(context)
        {
        }

        public RepositoryMock() : base(new DatabaseContext())
        {
           
        }

        public override IEnumerable<Spel> FindBy(Expression<Func<Spel, bool>> filter)
        {
            throw new NotImplementedException();
        }

        protected override DbSet<Spel> GetDbSet()
        {
            return _context.Spellen;
        }
        public override Spel Find(int id)
        {
            TimesCalled++;
            return null;
        }
        protected override int GetKeyFrom(Spel item)
        {        
            return item.SpelId; ;
        }

        public override int Count()
        {
            TimesCalled++;
            return 0;
        }

        public override void Insert(Spel item)
        {
            TimesCalled++;
        }

        public override void Update(Spel item)
        {
            TimesCalled++;
        }
        public override void Delete(int id)
        {
            TimesCalled++;
        }
        public override IEnumerable<Spel> FindAll()
        {
            TimesCalled++;
            return null;
        }
    }
}