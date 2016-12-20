using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BackendService.DAL.DAL;
using BackendService.Entities.Entities;

namespace BackendService.WebApi.Test.Mocks
{
    public class FaultyCursusRepositoryMock : IRepository<Cursus, int>
    {
        public int TimesCalled { get; set; }

        public int Count()
        {
            TimesCalled++;
            return 0;
        }

        public void Dispose()
        {

        }

        public IEnumerable<Cursus> FindBy(Expression<Func<Cursus, bool>> filter)
        {
            TimesCalled++;
            return null;
        }

        public void Insert(Cursus item)
        {
            TimesCalled++;
            throw new NotImplementedException();
        }
    }
}