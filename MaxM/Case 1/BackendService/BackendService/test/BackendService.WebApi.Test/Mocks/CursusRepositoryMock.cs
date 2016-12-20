using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BackendService.DAL.DAL;
using BackendService.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendService.WebApi.Test.Mocks
{
    public class CursusRepositoryMock : IRepository<Cursus, int>
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

        public Cursus Find(int id)
        {
            TimesCalled++;
            if (id < 1)
            {
                throw new ArgumentNullException();
            }
            return new Cursus { Id = 1, Title = "C# Programmeren", AmountOfDays = 2, StartDate = DateTime.Now };
        }

        public IEnumerable<Cursus> FindAll()
        {
            TimesCalled++;
            return new List<Cursus>
            {
                new Cursus { Id = 1, Title = "C# Programmeren", AmountOfDays = 2, StartDate = new DateTime(2016, 5, 2) },
                new Cursus { Id = 3, Title = "C# Hands-on", AmountOfDays = 5, StartDate = new DateTime(2016, 5, 4) },
                new Cursus { Id = 2, Title = "Advanced C#", AmountOfDays = 3, StartDate = new DateTime(2016, 5, 3) },
            };
        }

        public IEnumerable<Cursus> FindBy(Expression<Func<Cursus, bool>> filter)
        {
            TimesCalled++;
            return new List<Cursus>
            {
                new Cursus { Id = 1, Title = "C# Programmeren", AmountOfDays = 2, StartDate = new DateTime(2016, 5, 2) },
                new Cursus { Id = 3, Title = "C# Hands-on", AmountOfDays = 5, StartDate = new DateTime(2016, 5, 4) },
                new Cursus { Id = 2, Title = "Advanced C#", AmountOfDays = 3, StartDate = new DateTime(2016, 5, 3) },
            };
        }

        public void Insert(Cursus item)
        {
            TimesCalled++;
        }
    }
}