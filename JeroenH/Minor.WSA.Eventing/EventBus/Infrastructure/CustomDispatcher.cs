using Common.Event;
using Common.Infrastructure;

namespace EventBus.Infrastructure
{
    public class CustomDispatcher : EventDispatcher
    {
        public CustomDispatcher(BusOptions busOptions = null) : base(busOptions)
        {

        }

        public void GameRoomJoined(DomainEvent de)
        {

        }
    }
}
