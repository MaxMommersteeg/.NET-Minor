using RPGRepoEFDB;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace RPGRepoEFDB
{
    public class RPGRepositoryEFDB : IRepository<RPG, int>
    {
        private RPGContext _context;



        public RPGRepositoryEFDB(RPGContext context)
        {
            _context = context;
        }

        public IEnumerable<RPG> FindAll()
        {

            return _context.RPGs.ToList();

        }


        public RPG Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RPG> FindBy(Expression<Func<RPG, bool>> filter)
        {

            return _context.RPGs.Where(filter).ToList();

        }

        public void Insert(RPG item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            _context.RPGs.Add(item);
            _context.SaveChanges();

        }

        public void Update(RPG item)
        {
            throw new NotImplementedException();
        }



        public void Delete(RPG item)
        {
           RPG RPG = _context.RPGs.First();
            _context.Remove(RPG);
            _context.SaveChanges();
        }


    }
}
