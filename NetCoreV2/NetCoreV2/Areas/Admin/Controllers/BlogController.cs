using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using NetCoreV2.Areas.Admin.Models;

namespace NetCoreV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {

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
                    return File(content, "application/vnd.openxmlformats - officedocument.spreadsheetml.sheet", "Çalışma1.xlsx");
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
    }
}
