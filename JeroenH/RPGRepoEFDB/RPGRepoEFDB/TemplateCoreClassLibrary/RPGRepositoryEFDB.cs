using RPGRepoEFDB;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RPGRepoEFDB
{
    public class RPGRepositoryEFDB : IRepository<RPG, int>
    {
        public RPGRepositoryEFDB()
        {
        }



        public RPG Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RPG> FindBy(Expression<Func<RPG, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(RPG item)
        {
            using (var context = new RPGContext())
            {

            }
        }

        public void Update(RPG item)
        {
            throw new NotImplementedException();
        }



        public void Delete(RPG item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RPG> FindAll()
        {
            return new List<RPG>();
        }
    }
}
