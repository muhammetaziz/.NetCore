﻿using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
