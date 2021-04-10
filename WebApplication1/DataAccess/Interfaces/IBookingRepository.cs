using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Domain;

namespace WebApplication1.DataAccess.Interfaces
{
    public interface IBookingRepository
    {
        void AddBooking(Booking b);

        void GetBooking(int id);

        IQueryable<Booking> GetBookings();
    }
}
