using System;
using System.Collections.Generic;
using Dag20.Minor.KanoWeb.Agents;
using Dag20.Minor.KanoWeb.Models;
using Models;

namespace Dag20.Minor.KanoWeb.Agents
{
    public class KanoAgent : IAgent<Kano, int>
    {

        private List<Kano> _KanoList { get; set; }
        public KanoAgent()
        {
            _KanoList = new List<Kano>()
            {
                new Kano() { kanoID=1, kanoType=KanoTypes.Polo }
            };
        }

        

        public IEnumerable<Kano> FindAll()
        {
            return _KanoList;
        }

        public Kano FindById(int id)
        {
            return _KanoList.Find(kano => kano.kanoID == id);
        }

        public void Add(Kano kano)
        {
            _KanoList.Add(kano);
        }

        public void Update(Kano kano)
        {
            int kanoIndex = _KanoList.FindIndex(k => k.kanoID == kano.kanoID);
            _KanoList[kanoIndex] = kano;
        }

        public void Delete(Kano kano)
        {
            _KanoList.Remove(kano);
        }
    }
}