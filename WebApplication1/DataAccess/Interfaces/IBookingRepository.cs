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

        void getBookingAmount();

        void UpdateAcceptance(int b, bool accepted, string driverId, string driverid, string RegistrationPlate, int PassAmount);

        IQueryable<Booking> GetBookings();

    }
}
