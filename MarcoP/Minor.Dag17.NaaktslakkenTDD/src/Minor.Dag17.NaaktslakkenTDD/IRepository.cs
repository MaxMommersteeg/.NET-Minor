using Minor.Dag17.NaaktslakkenTDD.Entities;

namespace Minor.Dag17.NaaktslakkenTDD.DAL
{
    public interface IRepository<T1, T2>
    {
        void Add(Naaktslak naaktslak);
    }
}