using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Minor.Dag14.EFdemo.Test.DAL
{
    public class BoekRepository : IRepository<Boek, string>
    {
        private pubsContext _context;

        public BoekRepository(pubsContext context)
        {
            _context = context;
        }

        public Boek Find(string id)
        {
            return _context.Boeken.Single(b => b.TitleId == id);
        }

        public IEnumerable<Boek> FindAll()
        {
            return _context.Boeken.ToList();
        }

        public IEnumerable<Boek> FindBy(Expression<Func<Boek, bool>> filter)
        {
            return _context.Boeken.Where(filter).ToList();
        }

        public void Insert(Boek item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Update(Boek item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Delete(Boek item)
        {
            Boek oldItem = _context.Boeken.FirstOrDefault(b => b.TitleId == item.TitleId);
            _context.Remove(oldItem);
            _context.SaveChanges();
        }
    }
}
