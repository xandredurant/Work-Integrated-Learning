using Microsoft.AspNetCore.Mvc;
using WIL_Project.DBContext;
using WIL_Project.Models;

namespace WIL_Project.Controllers
{
    public class SurveyController : Controller
    {
        private readonly MyDbContext _context;

        public SurveyController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Survey survey)
        {
            if (ModelState.IsValid)
            {
                _context.Survey.Add(survey);
                _context.SaveChanges();

                // Optionally, you can redirect to a thank-you page or display a success message.
                return RedirectToAction("ThankYou");
            }

            return View(survey); // If model validation fails, return the view with validation errors.
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
