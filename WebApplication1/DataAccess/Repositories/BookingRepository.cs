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
        private readonly IPubSubRepository _pubSubRepo;
        public BookingRepository(ApplicationDbContext context, IPubSubRepository pubSubRepository)
        {
            _context = context;
            _pubSubRepo = pubSubRepository;
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

        public int GetBookingAmount()
        {
            return _context.Bookings.Count();

        }

        public void getBookingAmount()   
        {            
            GetBookingAmount();
        }

        public IQueryable<Booking> GetBookings()
        {
            return _context.Bookings;
        }

        public void UpdateAcceptance(int id, bool accepted, string driverName, string driver, string plate, int passAmount)
        {
            var originalBlog = GetBooking(id);
            originalBlog.accepted = accepted;
            _context.SaveChanges();


            if (originalBlog.Categories == "luxury")
            {
                _pubSubRepo.PullMessage(Category.luxury, driver, plate, passAmount);
                
            }
            if(originalBlog.Categories == "Business")
            {
                _pubSubRepo.PullMessage(Category.buisness, driver, plate, passAmount);

            }
            if(originalBlog.Categories == "Business")
            {
                _pubSubRepo.PullMessage(Category.buisness, driver, plate, passAmount);

            }
           
        }

        void IBookingRepository.GetBooking(int id)
        {
            getBookingAmount();
        }
    }
}
