using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Minor.Dag21.CAS.BackEnd.DAL.DatabaseContexts;
using Minor.Dag21.CAS.BackEnd.Entities.Entities;

namespace Minor.Dag21.CAS.BackEnd.DAL.DAL
{
    public class CursusRepository
        : BaseRepository<CursusInstantie, int, DatabaseContext>
    {
        private DbContextOptions _options;

        public CursusRepository(DatabaseContext context) : base(context)
        {
        }

        protected override DbSet<CursusInstantie> GetDbSet()
        {
            return _context.CursusInstantie;
        }

        public override IEnumerable<CursusInstantie> FindAll()
        {
            return _context.CursusInstantie.Include(t => t.Cursus).ToList();
        }

        public override IEnumerable<CursusInstantie> FindBy(Expression<Func<CursusInstantie, bool>> filter)
        {
            return _context.CursusInstantie.Include(t => t.Cursus).Where(filter).ToList();
        }

        protected override int GetKeyFrom(CursusInstantie item)
        {
            return item.CursusInstantieID;
        }

        public override void Insert(CursusInstantie item)
        {
            var cursusInstantieBestaatAl = FindBy(c => c.Cursus.Cursuscode == item.Cursus.Cursuscode && c.Startdatum == item.Startdatum);
            if(cursusInstantieBestaatAl.Count() != 0)
            {
                throw new DbUpdateException("Duplicate cursus",new InvalidOperationException());
            }
            var cursusBestaatAl = FindBy(c => c.Cursus.Cursuscode == item.Cursus.Cursuscode);
            if (cursusBestaatAl.Count() == 0)
            {
                _context.Cursus.Add(item.Cursus);
                _context.SaveChanges();
            }
            item.Cursus = _context.Cursus.First(c => c.Cursuscode == item.Cursus.Cursuscode);
            _context.CursusInstantie.Add(item);
            _context.SaveChanges();
        }

        public void Delete(CursusInstantie item)
        {
            var cursusList = FindBy(c => c.Cursus.Cursuscode == item.Cursus.Cursuscode && c.Startdatum == item.Startdatum);

            _context.Remove(cursusList.Single());
            _context.SaveChanges();
        }

        public override CursusInstantie Find(int id)
        {
            return _context.CursusInstantie.Include(t => t.Cursus).First(c => c.CursusInstantieID == id);
        }

    }
}