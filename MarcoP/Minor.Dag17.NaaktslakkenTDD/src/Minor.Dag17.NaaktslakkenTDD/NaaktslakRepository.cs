using Minor.Dag17.NaaktslakkenTDD.DAL;
using Minor.Dag17.NaaktslakkenTDD.Entities;
using System;

namespace Minor.Dag17.NaaktslakkenTDD.DAL
{
    public class NaaktslakRepository : IRepository<Naaktslak, long>
    {
        private NaaktslakContext context;

        public NaaktslakRepository(NaaktslakContext context)
        {
            this.context = context;
        }

        public void Add(Naaktslak naaktslak)
        {
            context.Add(naaktslak);
            context.SaveChanges();
        }
    }
}