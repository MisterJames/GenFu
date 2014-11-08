using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using GenFu.Web.Models;

namespace GenFu.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SourceCode sourceCode)
        {
            var result = sourceCode.Process();

            if (!sourceCode.IsLegit())
                result = null;

            return View("Result", SourceCode.GetPropertyValues(result));
        }

        public IActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}