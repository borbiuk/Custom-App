using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Console.Web.Models;
using Console.Web.Services;

namespace Console.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomServiceClient _customServiceClient;

        public HomeController(ICustomServiceClient customServiceClient)
        {
            _customServiceClient = customServiceClient;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CustomViewModel model)
        {
            model.Result = _customServiceClient.GetResult(model);

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}
