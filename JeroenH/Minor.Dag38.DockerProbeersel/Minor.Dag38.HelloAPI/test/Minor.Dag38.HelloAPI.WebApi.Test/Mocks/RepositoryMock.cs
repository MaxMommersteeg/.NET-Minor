using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Minor.Dag38.HelloAPI.WebApi.Test.Mocks
{
    public class RepositoryMock
        : ValueRepository
{
        public int TimesCalled { get; set; }
        public RepositoryMock(DatabaseContext context) : base(context)
        {
        }

        public RepositoryMock() : base(new DatabaseContext())
        {
           
        }

        public override IEnumerable<Value> FindBy(Expression<Func<Value, bool>> filter)
        {
            throw new NotImplementedException();
        }

        protected override DbSet<Value> GetDbSet()
        {
            return _context.Value;
        }
        public override Value Find(int id)
        {
            TimesCalled++;
            return null;
        }
        protected override int GetKeyFrom(Value item)
        {        
            return item.Id; ;
        }

        public int Count()
        {
            TimesCalled++;
            return 0;
        }

        public override void Insert(Value item)
        {
            TimesCalled++;
        }

        public override void Update(Value item)
        {
            TimesCalled++;
        }
        public override void Delete(int id)
        {
            TimesCalled++;
        }
        public override IEnumerable<Value> FindAll()
        {
            TimesCalled++;
            return null;
        }
    }
}