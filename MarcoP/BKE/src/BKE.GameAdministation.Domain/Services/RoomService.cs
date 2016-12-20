using BKE.Common;
using BKE.GameAdministation.Commands;
using BKE.GameAdministation.Domain;
using BKE.GameAdministation.Events;
using BKE.GameAdministration.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BKE.GameAdministration.Domain
{
    public class RoomService
    {
        private IRoomRepository _repo;
        private IEventPublisher _publisher;

        public RoomService(IRoomRepository repo, IEventPublisher publisher)
        {
            _repo = repo;
            _publisher = publisher;
        }
        public void Execute(CreateRoomCommand command)
        {
            var room = new Room();
            if (_repo.RoomExists(command.RoomName))
            {
                throw new FunctionalException(new FunctionalError("US003.1", $"A room with the name '{command.RoomName}' already exists"));
            }
            room.Create(command.RoomName, command.GameID);
            _repo.Create(room);
            room.Join(command.PlayerID, command.Colour);
            _repo.Save(room);

            var createdEvent = new RoomCreatedEvent() { RoomName = room.Name, GameID = room.GameID };
            _publisher.Publish(createdEvent);
            var joinedEvent = new PlayerJoinedRoomEvent() { RoomName = room.Name, PlayerID = command.PlayerID, Colour = command.Colour };
            _publisher.Publish(joinedEvent);
        }

        public void Execute(JoinRoomCommand command)
        {
            Room room = _repo.GetByName(command.RoomName);
            if (room == null)
            {
                throw new FunctionalException(new FunctionalError("US004.1", $"A room with the name '{command.RoomName}' does not exist"));
            }
            room.Join(command.PlayerID, command.Colour);
            _repo.Save(room);
        }
    }
}
