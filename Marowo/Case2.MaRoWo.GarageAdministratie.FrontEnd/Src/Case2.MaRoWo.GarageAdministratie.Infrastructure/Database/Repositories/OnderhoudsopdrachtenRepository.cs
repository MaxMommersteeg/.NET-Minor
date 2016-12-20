using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Case2.MaRoWo.GarageAdministratie.Infrastructure.Database.Repositories
{
    public class OnderhoudsopdrachtenRepository : BaseRepository<Onderhoudsopdracht, long, GarageAdministratieContext>
    {
        public OnderhoudsopdrachtenRepository(GarageAdministratieContext context) : base(context) 
        {

        }

        protected override DbSet<Onderhoudsopdracht> GetDbSet()
        {
            return _context.Onderhoudsopdrachten;
        }

        protected override long GetKeyFrom(Onderhoudsopdracht item)
        {
            return item.Id;
        }

        public override void Update(Onderhoudsopdracht item)
        {
            var currentItem = Find(item.OnderhoudsId);
            currentItem.Kenteken = item.Kenteken;
            currentItem.Kilometerstand = item.Kilometerstand;
            currentItem.OnderhoudOmschrijving = item.OnderhoudOmschrijving;
            currentItem.OpdrachtAangemaakt = item.OpdrachtAangemaakt;
            currentItem.OpdrachtStatus = item.OpdrachtStatus;
            currentItem.OpdrachtStatusBeschrijving = item.OpdrachtStatusBeschrijving;
            currentItem.Bestuuder = item.Bestuuder;
            currentItem.TelefoonNrBestuuder = item.TelefoonNrBestuuder;
            base.Update(currentItem);
        }

        public override bool Exists(long onderhoudsOpdrachtId)
        {
            return GetDbSet().SingleOrDefault(a => a.OnderhoudsId.Equals(onderhoudsOpdrachtId)) != null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Onderhoudsopdracht Find(long  onderhoudsOpdrachtId)
        {
            return GetDbSet().Single(a => a.OnderhoudsId.Equals(onderhoudsOpdrachtId));
        }
    }
}
