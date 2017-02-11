using Microsoft.AspNetCore.Mvc;

namespace GenFu.Web.Controllers
{
    public class WireframeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Docs() => View();
    }
}
