using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Minor.RoWe.AuditCommon.Database.Enties;
using Minor.RoWe.AuditLog.Database;
using Microsoft.EntityFrameworkCore;

namespace Minor.RoWe.AuditCommon.Database.Repositories
{
    public class EventRepository : IEventRepository
    {

        /// <summary>
        /// 
        /// </summary>
        private DbContextOptions<AuditContext> _options;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbOptions"></param>
        public EventRepository(DbContextOptions<AuditContext> dbOptions)
        {
            _options = dbOptions;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public IEnumerable<Event> FindEventsFrom(DateTime date)
        {
            using (var context = new AuditContext(_options))
            {
                return context.Events.Where(e => e.Date >= date).ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Event> GetAllEvents()
        {
            using (var context = new AuditContext(_options))
            {
                return context.Events.ToList();

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventWrapper"></param>
        public void SaveEvent(Event eventWrapper)
        {
            using (var context = new AuditContext(_options))
            {
                context.Events.Add(eventWrapper);
                context.SaveChanges();
            }
        }
    }
}
