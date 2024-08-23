using BusinessLayer.Concrete;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using NetCoreV2.Areas.Admin.Models;

namespace NetCoreV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        BlogManager bm=new BlogManager(new EFBlogRepository());

        public IActionResult ExportStaticExelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog Id";
                worksheet.Cell(1, 2).Value = "Blog Adı";
                int BlogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.Id;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Çalışma1.xlsx");
                }
            }
        }
        public List<BlogModel> GetBlogList()
        {
            
            List<BlogModel> bm = new List<BlogModel>()
            {
                new BlogModel() {Id=1,BlogName="c#programlamaya giriş"},
                new BlogModel() {Id=2,BlogName="c# giriş"},
                new BlogModel() {Id=3,BlogName="giriş"},
            };
            return bm;
        }
        public IActionResult BlogListExell()
        {
            return View();
        }


        public IActionResult ExportDynamicExelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog Id";
                worksheet.Cell(1, 2).Value = "Blog Adı";
                worksheet.Cell(1, 3).Value = "Blog İçerik";
                worksheet.Cell(1, 4).Value = "Blog Yazar";
                worksheet.Cell(1, 5).Value = "Blog Kategori";
                worksheet.Cell(1, 6).Value = "Blog Tarih";
                worksheet.Cell(1, 7).Value = "Blog Durum";
                int BlogRowCount = 2;
                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.Id;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    worksheet.Cell(BlogRowCount, 3).Value = item.BlogDescription ;
                    worksheet.Cell(BlogRowCount, 4).Value = item.WriterName;
                    worksheet.Cell(BlogRowCount, 5).Value = item.CategoryName ;
                    worksheet.Cell(BlogRowCount, 6).Value = item.CreateDate;
                    worksheet.Cell(BlogRowCount, 7).Value = item.Status ;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Çalışma1.xlsx");
                }
            }
           
        }
        public List<BlogModel2> BlogTitleList()
        {
            List<BlogModel2> bm2 = new List<BlogModel2>();
            using (var c=new Context()) 
            {
                bm2=c.Blogs.Select(x=>new BlogModel2
                {
                    Id=x.BlogID,
                    BlogName=x.BlogTitle,
                    BlogDescription = x.BlogContent,
                    WriterName=x.Writer.WriterName,
                    CategoryName=x.Category.CategoryName,
                    CreateDate=x.BlogCreateDate,
                    Status=x.BlogStatus,

                }).ToList();
            }
            return bm2;
        }
        public IActionResult BlogTitleListExcel()
        {
            return View();
        }

        public IActionResult BlogListForAdmin()
        {
            var value=bm.GetBlogListWithCategory();
            
            return View(value);
        }
    }
}
