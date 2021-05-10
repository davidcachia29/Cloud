using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.DataAccess.Interfaces;
using WebApplication1.Models.Domain;

namespace WebApplication1.DataAccess.Repositories
{
    public class DriverInfoRepository : IDriverInfo
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;
        public DriverInfoRepository(ApplicationDbContext context, UserManager<IdentityUser> userManager, IConfiguration config)
        {
            _context = context;
            _userManager = userManager;
            _config = config;
        }

        public void AddInfo(Driver b)
        {
            _context.DriverInfo.Add(b);
            _context.SaveChanges();
        }

        public Driver GetInfo(string id)
        {
            return _context.DriverInfo.SingleOrDefault(x => x.DriverID == id);
        }      

        public IQueryable<Driver> GetInfo()
        {
            return _context.DriverInfo;
        }

        public void UpdateInfo(Driver b, string Field, string id, IFormFile logo)
        {

            if(b != null)
            {
                if(Field == "Update Image")
                {                    
                    var originalinfo = GetInfo(id);
                    if (originalinfo != null)
                    {
                        string bucketName = _config.GetSection("AppSettings").GetSection("BucketName").Value;
                        string uniqueFilename = Guid.NewGuid() + System.IO.Path.GetExtension(logo.FileName);
                        var storage = StorageClient.Create();

                        using (var myStream = logo.OpenReadStream())
                        {
                            storage.UploadObject(bucketName, uniqueFilename, null, myStream);
                        }

                        b.Url = $"https://storage.googleapis.com/{bucketName}/{uniqueFilename}";


                        originalinfo.Url = b.Url;
                        _context.SaveChanges();
                    }
                    else
                    {
                        b.DriverID = id;
                        _context.DriverInfo.Add(b);
                        _context.SaveChanges();
                    }

                }
                if (Field == "Update FoodDrink")
                {
                    var originalinfo = GetInfo(id);
                    if (originalinfo != null)
                    {
                        originalinfo.FoodDrink = b.FoodDrink;
                        _context.SaveChanges();
                    }
                    else
                    {
                        b.DriverID = id;
                        _context.DriverInfo.Add(b);
                        _context.SaveChanges();
                    }

                }
                if (Field == "Update AirCondition")
                {
                    var originalinfo = GetInfo(id);
                    if (originalinfo != null)
                    {
                        originalinfo.AirConditioned = b.AirConditioned;
                        _context.SaveChanges();
                    }
                    else
                    {
                        b.DriverID = id;
                        _context.DriverInfo.Add(b);
                        _context.SaveChanges();
                    }
                }
                if (Field == "Update WIFI")
                {
                    var originalinfo = GetInfo(id);
                    if (originalinfo != null)
                    {
                        originalinfo.WIFI = b.WIFI;
                        _context.SaveChanges();
                    }
                    else
                    {
                        b.DriverID = id;
                        _context.DriverInfo.Add(b);
                        _context.SaveChanges();
                    }

                }
                if (Field == "Update RegistrationPlate")
                {
                    var originalinfo = GetInfo(id);
                    if (originalinfo != null)
                    {
                        originalinfo.RegistrationPlate = b.RegistrationPlate;
                        _context.SaveChanges();
                    }
                    else
                    {
                        b.DriverID = id;
                        _context.DriverInfo.Add(b);
                        _context.SaveChanges();
                    }

                }
                if (Field == "Update Condition")
                {
                    var originalinfo = GetInfo(id);
                    if (originalinfo != null)
                    {
                        originalinfo.Condition = b.Condition;
                        _context.SaveChanges();
                    }

                    else
                    {
                        b.DriverID = id;
                        _context.DriverInfo.Add(b);
                        _context.SaveChanges();
                    }

                }
                if (Field == "Update PassangerCapacity")
                {
                    var originalinfo = GetInfo(id);
                    if(originalinfo != null)
                    {
                        originalinfo.PassangerCapacity = b.PassangerCapacity;
                        _context.SaveChanges();
                    }
                    else
                    {
                        b.DriverID = id;
                        _context.DriverInfo.Add(b);
                        _context.SaveChanges();
                    }
                   
                }               

            }
            else
            {
                AddInfo(b);
            }
          
        }

        public Driver GetTotalInfo(string id)
        {
            return _context.DriverInfo.SingleOrDefault(x => x.DriverID == id);

        }
        void IDriverInfo.GetInfo(string id)
        {
            GetInfo(id);
        }
    }
}
