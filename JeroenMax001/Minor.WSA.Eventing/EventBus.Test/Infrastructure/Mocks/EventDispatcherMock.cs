using EventBus.Infrastructure;
using Common.Infrastructure;
using Common.Attributes;
using Common.Event;
using EventAuditLog;

namespace EventBus.Test.Infrastructure.Mocks
{
    public class EventDispatcherMock : EventDispatcher
    {
        public GameRoomEventMock GameRoomEventMock { get; set; }
        public int GameRoomCreatedCalled { get; set; }

        public EventDispatcherMock(IAuditLog auditLog, BusOptions busOptions = null) : base(auditLog, busOptions)
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
