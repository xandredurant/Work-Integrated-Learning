using Microsoft.AspNetCore.Mvc;

namespace WIL_Project.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
