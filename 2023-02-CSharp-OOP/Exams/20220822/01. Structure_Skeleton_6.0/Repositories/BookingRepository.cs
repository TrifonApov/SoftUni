using System.Collections.Generic;
using System.Linq;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> bookings;

        public BookingRepository()
        {
            this.bookings = new List<IBooking>();
        }

        public void AddNew(IBooking booking) => bookings.Add(booking);

        public IBooking Select(string bookingNumberAsString) => this.bookings.FirstOrDefault(b => b.BookingNumber.ToString() == bookingNumberAsString);

        public IReadOnlyCollection<IBooking> All() => bookings.AsReadOnly();
    }
}