using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.DataAccess.Interfaces;
using WebApplication1.Models.Domain;

namespace WebApplication1.DataAccess.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;
        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddBooking(Booking b)
        {
            _context.Add(b);
            _context.SaveChanges();
        }

        public Booking GetBooking(int id)
        {
            return _context.Bookings.SingleOrDefault(x => x.BookingID == id);
        }

        public IQueryable<Booking> GetBookings()
        {
            return _context.Bookings;
        }

        void IBookingRepository.GetBooking(int id)
        {
            throw new NotImplementedException();
        }
    }
}
