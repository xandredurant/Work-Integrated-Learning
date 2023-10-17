using Microsoft.AspNetCore.Mvc;

namespace WIL_Project.Controllers
{
    public class ScheduleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
