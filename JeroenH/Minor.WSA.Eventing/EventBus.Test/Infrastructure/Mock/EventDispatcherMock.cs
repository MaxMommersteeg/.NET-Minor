using EventBus.Infrastructure;
using Common.Infrastructure;
using Common.Attributes;
using Common.Event;

namespace EventBus.Test.Infrastructure.Mock
{
    public class EventDispatcherMock : EventDispatcher
    {
        public GameRoomEventMock GameRoomEventMock { get; set; }
        public int GameRoomCreatedCalled { get; set; }

        public EventDispatcherMock(BusOptions busOptions = null) : base(busOptions)
        {
        }

        [Handle(RoutingKey = "Minor.WSA.GameRoom.Created")]
        public void GameRoomCreated(GameRoomEventMock gameRoomEventMock)
        {
            GameRoomCreatedCalled++;
            GameRoomEventMock = gameRoomEventMock;
        }
    }
}
