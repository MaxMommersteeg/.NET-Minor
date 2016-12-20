using System;
using System.Collections.Generic;
using FE.Models;
using System.Linq;

namespace FE.Agents
{
    public class KoffieAgent : IKoffieAgent
    {
        private List<Koffie> _koffieList;

        public KoffieAgent()
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
            return _koffieList.Where(Koffie => Koffie.Id == id).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var existingKoffie = GetById(id);
            if(existingKoffie == null)
            {
                throw new ArgumentNullException();
            }

            _koffieList = _koffieList.Where(koffie => koffie.Id != id).ToList();
        }

        public void Add(Koffie koffie)
        {
            if(koffie == null)
            {
                throw new ArgumentNullException();
            }

            var existingKoffie = GetById(koffie.Id);
            if(existingKoffie != null)
            {
                throw new ArgumentException();
            }

            _koffieList.Add(koffie);
        }
    }
}
