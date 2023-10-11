using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WIL_Project.Models;

namespace WIL_Project.Controllers
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
            return View();
        }
        public IActionResult Events()
        {
            return View();
        }

        public IActionResult Schedule()
        {
            return View();
        }
        public IActionResult Program()
        {
            return View();
        }

        public IActionResult survey()
        {
            return View();
        }

        public IActionResult contact()
        {
            return View();
        }

        public IActionResult speakers()
        {
            return View();
        }
        public IActionResult Voucher()
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