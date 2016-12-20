using System;
using System.Collections.Generic;
using FE.Agents;
using FE.Models;
using System.Linq;

namespace Test.AgentMock
{
    public class DummyKoffieAgent : IKoffieAgent
    {
        private List<Koffie> _koffieList;

        public DummyKoffieAgent()
        {
            _koffieList = new List<Koffie>
            {
                new Koffie { Id = 1, Naam = "Zwarte bonen", MinimaleInhoudInCl = 12, MaximaleInhoudInCl = 25 },
                new Koffie { Id = 2, Naam = "Espresso", MinimaleInhoudInCl = 5, MaximaleInhoudInCl = 12 }
            };
        }

        public IEnumerable<Koffie> GetAll()
        {
            return _koffieList;
        }

        public Koffie GetById(int id)
        {
            return _koffieList.Where(koffie => koffie.Id == id).FirstOrDefault();
        }

        public void Add(Koffie koffie)
        {
            _koffieList.Add(koffie);
        }

        public void Delete(int id)
        {
            _koffieList = _koffieList.Where(koffie => koffie.Id != id).ToList();
        }
    }
}
