using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Minor.Dag21.CAS.BackEnd.DAL.DatabaseContexts;
using Minor.Dag21.CAS.BackEnd.DAL.DAL;
using Minor.Dag21.CAS.BackEnd.Entities.Entities;

namespace Minor.Dag21.CAS.BackEnd.WebApi.Test.Mocks
{
    public class CursusRepositoryMock
        : CursusRepository
{
        public int TimesFindCalled { get; set; }
        public int TimesCountCalled { get; private set; }
        public int TimesInsertCalled { get; private set; }
        public int TimesUpdateCalled { get; private set; }
        public int TimesDeleteCalled { get; private set; }
        public int TimesFindAllCalled { get; private set; }
        public int FindByIdLastCallContent { get; internal set; }
        public CursusInstantie InsertLastCallContent { get; private set; }
        public CursusInstantie UpdateLastCallContent { get; private set; }
        public int DeleteLastCallContent { get; private set; }
        public int TimesFindByCalled { get; internal set; }
        public Expression<Func<CursusInstantie, bool>> FindByLastCallContent { get; internal set; }

        public CursusRepositoryMock(DatabaseContext context) : base(context)
        {

        }

        public CursusRepositoryMock() : base(new DatabaseContext())
        {
           
        }

        public override IEnumerable<CursusInstantie> FindBy(Expression<Func<CursusInstantie, bool>> filter)
        {
            TimesFindByCalled++;
            FindByLastCallContent = filter;
            
            return null;
        }

        protected override DbSet<CursusInstantie> GetDbSet()
        {
            return _context.CursusInstantie;
        }
        public override CursusInstantie Find(int id)
        {
            FindByIdLastCallContent = id;
            TimesFindCalled++;
            return null;
        }


        protected override int GetKeyFrom(CursusInstantie item)
        {    
            return item.Cursus.CursusId; ;
        }

        public override int Count()
        {
            TimesCountCalled++;
            return 0;
        }        

        public override void Insert(CursusInstantie item)
        {
            InsertLastCallContent = item;
            TimesInsertCalled++;
            if (InsertLastCallContent?.GetHashCode() == item.GetHashCode())
            {
                throw new DbUpdateException("Duplicate cursus", new InvalidOperationException());
            }

        }

        public override void Update(CursusInstantie item)
        {
            UpdateLastCallContent = item;
            TimesUpdateCalled++;
        }
        public override void Delete(int id)
        {
            DeleteLastCallContent = id;
            TimesDeleteCalled++;
            if (InsertLastCallContent.Equals(null))
            {
                throw new DbUpdateException("Duplicate cursus", new InvalidOperationException());
            }

        }
        public override IEnumerable<CursusInstantie> FindAll()
        {
            TimesFindAllCalled++;
            return null;
        }
    }
}