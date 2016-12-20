using System;
using BKE.GameAdministation.Domain;
using System.Linq.Expressions;

namespace BKE.GameAdministration.Infrastructure
{
    public interface IRoomRepository
    {
        Room GetByName(string name);
        bool RoomExists(string roomName);

        void Create(Room room);
        void Save(Room room);
    }
}