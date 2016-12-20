using BKE.GameAdministation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BKE.GameAdministration.DomainServices
{
    public class RoomService
    {
        private IRoomRepository _repo;

        public RoomService(IRoomRepository repo)
        {

        }
        public void Execute(CreateRoomCommand command)
        {
            var room = new Room();
            room.Create(command);

        }
    }
}
