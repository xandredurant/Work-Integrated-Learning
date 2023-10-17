using Microsoft.AspNetCore.Mvc;

namespace WIL_Project.Controllers
{
    public class SpeakersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
