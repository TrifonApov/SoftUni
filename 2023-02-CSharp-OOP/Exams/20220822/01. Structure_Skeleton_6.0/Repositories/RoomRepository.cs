using System.Collections.Generic;
using System.Linq;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private List<IRoom> rooms;

        public RoomRepository()
        {
            rooms = new List<IRoom>();
        }

        public void AddNew(IRoom room) => rooms.Add(room);

        public IRoom Select(string Name) => rooms.FirstOrDefault(r => r.GetType().Name == Name);

        public IReadOnlyCollection<IRoom> All() => rooms.AsReadOnly();
    }
}