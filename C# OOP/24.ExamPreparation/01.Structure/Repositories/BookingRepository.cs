using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private readonly List<IBooking> bookings;
        
        public BookingRepository()
        {
            bookings = new List<IBooking>();
        }

        public void AddNew(IBooking model)
        {
            bookings.Add(model);
        }

        public IBooking Select(string criteria)
        {
            return bookings.FirstOrDefault(b => b.BookingNumber.ToString() == criteria);
        }

        public IReadOnlyCollection<IBooking> All()
        {
            return bookings.AsReadOnly();
        }

    }
}
