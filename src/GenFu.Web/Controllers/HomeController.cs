using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenFu.Web.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.Dnx.Compilation;
using Microsoft.Dnx.Runtime;

namespace GenFu.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAssemblyLoadContextAccessor _accessor;
        private readonly ILibraryExporter _exporter;

        public HomeController(IAssemblyLoadContextAccessor accessor, ILibraryExporter exporter)
        {
            _accessor = accessor;
            _exporter = exporter;
        }

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

            // todo: make not hacky
            sourceCode.Accessor = _accessor;
            sourceCode.LibraryExporter = _exporter;

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
    }
}
