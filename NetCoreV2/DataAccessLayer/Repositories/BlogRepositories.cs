using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BlogRepositories : IBlogDal
    {
        public void AddBlog(Blog blogs)
        {
            using var c= new Context();
            c.Add(blogs);
            c.SaveChanges();
        }

        public void DeleteBlog(Blog blogs)
        {
            using var c = new Context();
            c.Remove(blogs);
            c.SaveChanges();
        }

        public Blog GetByID(int id)
        {
            using var c = new Context();
            return c.Blogs.Find(id);
        }

        public List<Blog> ListAllBlog()
        {
            using var c = new Context();
            return c.Blogs.ToList();
        }

        public void UpdateBlog(Blog blogs)
        {
            using var c = new Context();
            c.Update(blogs);
            c.SaveChanges();
        }
    }
}
