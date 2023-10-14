using Microsoft.AspNetCore.Mvc;

namespace WIL_Project.Controllers
{
    public class ProgramController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
