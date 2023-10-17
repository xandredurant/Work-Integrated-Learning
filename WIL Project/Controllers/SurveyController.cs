using Microsoft.AspNetCore.Mvc;

namespace WIL_Project.Controllers
{
    public class SurveyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
