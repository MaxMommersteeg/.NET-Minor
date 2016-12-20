using System;
using System.Collections;
using System.Collections.Generic;

namespace Dag17.Minor.ASPNETOefenen
{
    public class MonumentAgent : IAgent
    {
        private List<Monument> _MonumentList { get; set; }

        public MonumentAgent ()
        {
            _MonumentList = new List<Monument>();
        }
        public IEnumerable FindAll()
        {
            return _MonumentList;
        }

        public void Add(Monument monument)
        {
            _MonumentList.Add(monument);
        }

        public void Remove(Monument monument)
        {
            _MonumentList.Remove(monument);
        }
    }
}