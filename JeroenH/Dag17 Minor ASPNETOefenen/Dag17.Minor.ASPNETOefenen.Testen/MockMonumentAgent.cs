using System;
using System.Collections;
using System.Collections.Generic;

namespace Dag17.Minor.ASPNETOefenen.Testen
{
    public class MockMonumentAgent : IAgent
    {
        public List<Monument> _MonumentList { get; private set; }
        
        public void Add(Monument monument)
        {
            _MonumentList.Add(monument);
        }

        public IEnumerable FindAll()
        {
            return _MonumentList;
        }

        public void Remove(Monument monument)
        {
            _MonumentList.Remove(monument);
        }

        public void setList(List<Monument> monumentList)
        {
            _MonumentList = monumentList;
        }
    }
}