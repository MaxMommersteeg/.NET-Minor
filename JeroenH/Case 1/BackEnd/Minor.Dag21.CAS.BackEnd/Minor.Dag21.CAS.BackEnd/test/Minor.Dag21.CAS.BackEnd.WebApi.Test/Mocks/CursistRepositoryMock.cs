using System;
using Minor.Dag21.CAS.BackEnd.DAL.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

public class CursistRepositoryMock
        : CursistRepository
{
    public int TimesInsertCalled { get; internal set; }
    public Cursist InsertLastCallContent { get; internal set; }
    public int TimesFindAllCalled { get; internal set; }
    public int FindByIdLastCallContent { get; private set; }
    public int TimesFindCalled { get; private set; }
    public Cursist UpdateLastCallContent { get; private set; }
    public int TimesUpdateCalled { get; private set; }
    public int TimesFindByCalled { get; internal set; }
    public Expression<Func<Cursist, bool>> FindByLastCallContent { get; private set; }

    public CursistRepositoryMock(DatabaseContext context) : base(context)
    {
    }

    public CursistRepositoryMock() : base(new DatabaseContext())
    {
    }

    public override void Insert(Cursist item)
    {
        InsertLastCallContent = item;
        TimesInsertCalled++;
        if (InsertLastCallContent?.GetHashCode() == item.GetHashCode())
        {
            throw new DbUpdateException("Duplicate Cursist", new InvalidOperationException());
        }

    }

    public override IEnumerable<Cursist> FindAll()
    {
        TimesFindAllCalled++;
        return null;
    }

    public override IEnumerable<Cursist> FindBy(Expression<Func<Cursist, bool>> filter)
    {
        TimesFindByCalled++;
        FindByLastCallContent = filter;

        return null;
    }

    public override Cursist Find(int id)
    {
        FindByIdLastCallContent = id;
        TimesFindCalled++;
        return null;
    }

    public override void Update(Cursist item)
    {
        UpdateLastCallContent = item;
        TimesUpdateCalled++;
    }
}