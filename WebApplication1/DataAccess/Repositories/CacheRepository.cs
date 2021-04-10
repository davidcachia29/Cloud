using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DataAccess.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.DataAccess.Repositories
{
    public class CacheRepository : ICacheRepository
    {
        private IDatabase db;
        private readonly IConfiguration _config;
        public CacheRepository(IConfiguration config)
        {
            _config = config;
            string connectionString = _config.GetConnectionString("CacheConnection");

            var cm = ConnectionMultiplexer.Connect(connectionString);
            db = cm.GetDatabase();
        }
        public List<Menu> GetMenus()
        {
            if (db.KeyExists("navbar-menus"))
            {
                var menusSerialized = db.StringGet("navbar-menus");

                var list = JsonConvert.DeserializeObject<List<Menu>>(menusSerialized);
                return list;
            }
            else
            {
                return new List<Menu>();
            }
        }

        public void UpsertMenu(Menu m)
        {
            var originalList = GetMenus();

            var existentMenu = originalList.SingleOrDefault(x => x.Title == m.Title);

            if(existentMenu != null)
            {
                existentMenu.URL = m.URL;
                existentMenu.Title = m.Title;
            }
            else
            {
                originalList.Add(m);
            }

            var serializedMenus = JsonConvert.SerializeObject(originalList);
            db.StringSet("navbar-menus", serializedMenus);
        }
    }
}
