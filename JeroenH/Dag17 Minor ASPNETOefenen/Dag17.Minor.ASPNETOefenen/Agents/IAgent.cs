using System.Collections;

namespace Dag17.Minor.ASPNETOefenen
{
    public interface IAgent
    {
        IEnumerable FindAll();

        void Add(Monument monument);

        void Remove(Monument monument);


    }
}