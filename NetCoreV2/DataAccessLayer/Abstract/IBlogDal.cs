using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal
    {
        List<Blog> ListAllBlog();

        void AddBlog(Blog blogs);

        void DeleteBlog(Blog blogs);

        void UpdateBlog(Blog blogs);
        Blog GetByID(int id);



    }
}
