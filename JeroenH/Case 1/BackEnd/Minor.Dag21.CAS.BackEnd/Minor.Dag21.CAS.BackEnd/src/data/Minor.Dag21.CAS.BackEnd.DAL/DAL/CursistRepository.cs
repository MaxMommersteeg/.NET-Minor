using System;
using Minor.Dag21.CAS.BackEnd.DAL.DatabaseContexts;
using Minor.Dag21.CAS.BackEnd.DAL.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

public class CursistRepository
        : BaseRepository<Cursist, int, DatabaseContext>
{
    private DbContextOptions _options;

    public CursistRepository(DatabaseContext context) : base(context)
    {
    }

    protected override DbSet<Cursist> GetDbSet()
    {
        return _context.Cursist;
    }

    protected override int GetKeyFrom(Cursist item)
    {
        return item.CursistId;
    }

    public override IEnumerable<Cursist> FindAll()
    {
        return _context.Cursist.ToList();
    }

    public override IEnumerable<Cursist> FindBy(Expression<Func<Cursist, bool>> filter)
    {
        return _context.Cursist.Where(filter).ToList();
    }

    public override Cursist Find(int id)
    {
        return _context.Cursist.First(c => c.CursistId == id);
    }
}