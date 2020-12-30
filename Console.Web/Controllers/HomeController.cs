using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Console.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Console.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<int> last100Years = new List<int>();
            int currentYear = DateTime.Now.Year;

            for (int i = currentYear - 100; i <= currentYear; i++)
            {
                last100Years.Add(i);
            }

            ViewBag.LastTenYears = new SelectList(last100Years);

            var x = new CustomViewModel();
            return View(x);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
