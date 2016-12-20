using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.WSA.Eventing
{
    [RoutingKey("BKE.GameService.*")]		// optional, defaults to "#"
    [EventBus(HostName="HostName", ExchangeName="BKEbus", QueueName="Wouter", 
              Port=5672, Username="gast", Password="G@5t")]		// optional
    public class MyCustomDispatcher : EventDispatcher
    {
        public void RoomCreatedHandler(RoomCreatedEvent rce)
        {
        }
        
        public void RoomJoinedHandler(RoomJoinedEvent rje)
        {
        }

        [Handles("BKE.PlayerService.*")]    // optional
        [Handles("BKE.GamingService.*")]
        public void GenericPlayerHandler(DomainEvent de)
        {
        }
    }


    // Framework Class
    public abstract class EventDispatcher : IDisposable
    {
        public EventDispatcher(BusOptions options = null)
        {
            // open connection to RabbitMQ
            
            // Hook up all Handlers
        }

        public virtual void Dispose()
        {
            // close connection to RabitMQ
        }
    }

}
