using Minor.Dag19.WebApiDemo.DAL;
using Minor.Dag19.WebApiDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag19.WebApiDemo.Dummies
{
    public class RepositoryDummy : IRepository<Slak, long>
    {
        private List<Slak> _slakken = new List<Slak>()
        {
            new Slak { ID=7, Naam="Slakkie" },
            new Slak { ID=17, Naam="Lars" },
            new Slak { ID=37, Naam="Gert" },
        };

        public void Delete(int id)
        {
            Slak slak = _slakken.Single(s => s.ID == id);
            _slakken.RemoveAt(_slakken.IndexOf(slak));
        }

        public IEnumerable<Slak> FindAll()
        {
            return _slakken;
        }

        public Slak FindBy(long id)
        {
            return _slakken.Single(s => s.ID == id);
        }

        public void Insert(Slak item)
        {
            _slakken.Add(item);
        }
    }
}
