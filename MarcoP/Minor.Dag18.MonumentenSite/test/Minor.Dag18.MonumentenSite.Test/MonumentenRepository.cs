using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Minor.Dag18.MonumentenSite.Models;

namespace Minor.Dag18.MonumentenSite.Test
{
    public class MonumentenRepositoryMock : IMonumentenRepository
    {
        public bool InsertHasBeenCalled = false;
        public Monument InsertParameter = null;

        public void Insert(Monument monument)
        {
            InsertHasBeenCalled = true;
            InsertParameter = monument;
        }
    }
}
