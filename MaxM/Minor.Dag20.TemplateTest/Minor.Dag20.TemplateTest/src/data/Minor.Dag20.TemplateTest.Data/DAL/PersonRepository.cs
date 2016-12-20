using Minor.Dag20.TemplateTest.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Minor.Dag20.TemplateTest.Data.DAL
{
    public class PersonRepository : BaseRepository<Person, int, DatabaseContext>
    {

        public PersonRepository(DatabaseContext context) : base(context)
        {
        }

        public override IEnumerable<Person> FindBy(Expression<Func<Person, bool>> filter)
        {
            return _context.Persons.Where(filter);
        }

        protected override DbSet<Person> GetDbSet()
        {
            return _context.Persons;
        }

        protected override int GetKeyFrom(Person item)
        {
            return item.Id;
        }
    }
}
