﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.Controllers
{
	public class CommentController : Controller
	{
		CommentManager cm=new CommentManager(new EFCommentRepository());
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public PartialViewResult PartialAddComment()
		{
			return PartialView();
		}

		[HttpPost]
        public PartialViewResult PartialAddComment(Comment p)
        {
			p.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			p.CommentStatus = true;
			p.BlogID = 2;
			cm.CommentAdd(p);
			return PartialView();
        }

        public PartialViewResult CommentListByBlog(int id)
		{
			var values = cm.GetList(id); 
			return PartialView(values);
		}
	}
}
