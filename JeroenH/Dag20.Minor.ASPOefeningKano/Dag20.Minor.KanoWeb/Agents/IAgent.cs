using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dag20.Minor.KanoWeb.Models;

namespace Dag20.Minor.KanoWeb.Agents
{
    public interface IAgent<T,K>
    {
        IEnumerable<T> FindAll();
        Kano FindById(int id);
        void Add(Kano kano);
        void Update(Kano kano);
        void Delete(Kano kano);
    }
}
