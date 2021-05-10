using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Domain;

namespace WebApplication1.DataAccess.Interfaces
{
    public interface IDriverInfo
    {
        void AddInfo(Driver b);

        void UpdateInfo(Driver b, string Field, string id, IFormFile logo);

        void GetInfo(string id);

        Driver GetTotalInfo(string id);
        

        IQueryable<Driver> GetInfo();
    }
}
