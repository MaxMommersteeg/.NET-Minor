using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.DAL
{
    public class DummyKoffieRepository : IRepository<Koffie, int>
    {
        private List<Koffie> _koffieList { get; set; }

        public DummyKoffieRepository()
        {
            _koffieList = new List<Koffie>
            {
                new Koffie { Id = 1, Naam = "Bonen" },
                new Koffie { Id = 2, Naam = "Poeder" },
                new Koffie { Id = 3, Naam = "Cappucino" },
                new Koffie { Id = 4, Naam = "Latte Machiato" }
            };
        }

        public void Delete(int id)
        {
            _koffieList = _koffieList.Where(x => x.Id != id).ToList();
        }

        public IEnumerable<Koffie> GetAll()
        {
            return _koffieList;
        }

        public Koffie GetById(int id)
        {
            return _koffieList.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Insert(Koffie item)
        {
            var newKoffie = GetById(item.Id);
            if(newKoffie != null)
            {
                throw new ArgumentException();
            }
            _koffieList.Add(item);
        }

        public void Update(Koffie item)
        {
            var existingItem = GetById(item.Id);
            if(existingItem == null)
            {
                return;
            }
            int indexToUpdate = 0;
            for(var i = 0; i < _koffieList.Count; i++)
            {
                if(_koffieList[i].Id != existingItem.Id)
                {
                    continue;
                }
                indexToUpdate = i;
                break;
            }
            _koffieList[indexToUpdate] = item;
        }
    }
}
