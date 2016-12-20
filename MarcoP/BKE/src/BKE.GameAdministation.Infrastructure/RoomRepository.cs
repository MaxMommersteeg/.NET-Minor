using BKE.GameAdministration.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BKE.GameAdministation.Domain;

namespace BKE.GameAdministation.Infrastructure
{
    public class RoomRepository : IRoomRepository
    {
        private static List<Room> _rooms = new List<Room>();
        private static long NEXTID = 0;
        public Room GetByName(string name)
        {
            return _rooms.FirstOrDefault(r => r.Name == name);
        }

        public bool RoomExists(string roomName)
        {
            return _rooms.Any(r => r.Name == roomName);
        }

        public void Create(Room room)
        {
            room.ID = NEXTID++;
            _rooms.Add(room);
        }

        public void Save(Room room)
        {
            var oldRoom = _rooms.FirstOrDefault(r => r.ID == room.ID);
            _rooms.Remove(oldRoom);
            _rooms.Add(room);
        }


    }
}
