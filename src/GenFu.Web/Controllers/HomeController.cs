namespace GenFu.Web.Controllers;

using global::GenFu.Web.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Linq;
//using Microsoft.DotNet.Tools.Compiler;
//using Microsoft.VisualStudio.Web.CodeGeneration.DotNet;
using System.Runtime.Loader;
using System.Text;
using System.Text.Json;

public class HomeController : Controller
{
    private const string RandomObjectsSessionKey = nameof(GenerateDataModel.RandomObjects);

    private readonly AssemblyLoadContext _accessor;

    public HomeController(AssemblyLoadContext accessor)
    {
        _accessor = accessor;
    }

    public IActionResult Index()
    {
        GenerateDataModel model = new GenerateDataModel();
        model.Source =
@"public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string EmailAddress { get; set; }
    //Add your own properties here
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

        var compileResult = sourceCode.Compile();

        if (!compileResult.IsValid)
        {
            model.HasCompileErrors = true;
            model.CompileErrors = compileResult.Errors;

            HttpContext.Session.Remove(RandomObjectsSessionKey);
        }
        else
        {
            model.RandomObjects = sourceCode.GenerateData(10);
            model.PropertyNames = model.RandomObjects.First().Keys;

            HttpContext.Session.SetString(RandomObjectsSessionKey, JsonSerializer.Serialize(model.RandomObjects));
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult Download()
    {
        var randomObjectsJson = HttpContext.Session.GetString(RandomObjectsSessionKey);

        if (randomObjectsJson == null)
        {
            return BadRequest();
        }

        var randomObjectsJsonAsBytes = new UTF8Encoding().GetBytes(randomObjectsJson);

        return File(randomObjectsJsonAsBytes, "application/json", "random-data.json");
    }
}
