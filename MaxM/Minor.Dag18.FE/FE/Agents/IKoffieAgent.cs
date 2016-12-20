using FE.Models;
using System.Collections.Generic;

namespace FE.Agents
{
    public interface IKoffieAgent
    {
        IEnumerable<Koffie> GetAll();

        Koffie GetById(int id);

        void Delete(int id);

        void Add(Koffie koffie);
    }
}
