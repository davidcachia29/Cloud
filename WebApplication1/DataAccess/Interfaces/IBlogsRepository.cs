using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Domain;

namespace WebApplication1.DataAccess.Interfaces
{
    public interface IBlogsRepository
    {
        void AddBlog(Blog b);

        void GetBlog(int id);

        void DeleteBlog(int id);

        IQueryable<Blog> GetBlogs();

        void UpdateBlog(Blog b);
    }
}
