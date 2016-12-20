using System;

public class NaaktslakRepository : IRepository<Naaktslak, long>
{
    private NaaktslakContext context;

    public NaaktslakRepository(NaaktslakContext context)
    {
        this.context = context;
    }

    public void Add(Naaktslak naaktslak)
    {
        throw new NotImplementedException();
    }
}