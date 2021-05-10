using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DataAccess.Repositories;
using WebApplication1.Models.Domain;

namespace WebApplication1.DataAccess.Interfaces
{
    public interface IPubSubRepository
    {
        void PublishMessage (Booking b, string email ,string classType);

        string PullMessage(Category cat, string driver, string plate, int passAmount);
    }
}
