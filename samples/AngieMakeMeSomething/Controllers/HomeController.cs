using Angela.Core;
using AngieMakeMeSomething.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngieMakeMeSomething.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var posts = Angie.FastList<BlogPost>();
            return View(posts);
        }

   }
}
