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
            GenerateDataModel model = new GenerateDataModel();
            model.Source = @"public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string EmailAddress { get; set; }
    }";
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(SourceCode sourceCode)
        {
            GenerateDataModel model = new GenerateDataModel();
            model.Source = sourceCode.Source;

            var compileResult = sourceCode.Compile();

            if (!compileResult.IsValid)
            {
                model.HasCompileErrors = true;
                model.CompileErrors = compileResult.Errors;
            }
            else
            {
                model.RandomObjects = sourceCode.GenerateData(10);
                model.PropertyNames = model.RandomObjects.First().Keys;
            }
            
            return View(model);
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