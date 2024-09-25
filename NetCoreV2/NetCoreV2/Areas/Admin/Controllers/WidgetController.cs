﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WidgetController : Controller
    {
        Context  c =new  Context();
        BlogManager bm = new BlogManager(new EFBlogRepository());
        public IActionResult Index()
        {
             
            var value = bm.GetBlogListWithCategory();

            return View();
        }
    }
}
