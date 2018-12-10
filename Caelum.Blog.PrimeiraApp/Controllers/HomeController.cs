using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Caelum.Blog.PrimeiraApp
{
    //http://localhost:5000/Home/Index
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(); //ViewResult, JsonResult, Redirect
        }
    }
}
