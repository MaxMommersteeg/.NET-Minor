using BKE.GameAdministration.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BKE.Common;
using Newtonsoft.Json;

namespace BKE.GameAdministation.Infrastructure
{
    public class ConsoleEventPublisher : IEventPublisher
    {
        public void Publish(DomainEvent domainEvent)
        {
            string eventString = JsonConvert.SerializeObject(domainEvent);
            Console.WriteLine("I do now publish: " + eventString);
        }
    }
}
