using Minor.RoWe.AuditCommon.Database.Enties;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Minor.RoWe.AuditCommon.Database.Repositories 
{
    public interface IEventRepository
    {
        void SaveEvent(Event eventWrapper);
        IEnumerable<Event> GetAllEvents();
        IEnumerable<Event> FindEventsFrom(DateTime date);      

    }
}