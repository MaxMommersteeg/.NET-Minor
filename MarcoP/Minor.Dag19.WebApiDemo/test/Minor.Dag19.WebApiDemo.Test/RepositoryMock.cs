using System;
using System.Collections.Generic;
using Minor.Dag19.WebApiDemo.DAL;
using Minor.Dag19.WebApiDemo.Entities;

namespace Minor.Dag19.WebApiDemo.Test
{
    internal class RepositoryMock : IRepository<Slak, long>
    {
        public IEnumerable<Slak> FindAll()
        {
            return new List<Slak>
            {
                new Slak { ID = 1, Naam="Wegslak" }
            };
        }

        public bool InsertHasBeenCalled = false;
        public Slak InsertParameter = null;
        public void Insert(Slak item)
        {
            InsertHasBeenCalled = true;
            InsertParameter = item;
        }

        public bool FindByHasBeenCalled = false;
        public long? FindByParameter = null;
        public Slak FindBy(long id)
        {
            FindByHasBeenCalled = true;
            FindByParameter = id;
        }

        public bool DeleteHasBeenCalled = false;
        public long? DeleteParameter = null;
        public void Delete(long id)
        {
            DeleteHasBeenCalled = true;
            DeleteParameter = id;
        }
    }
}