using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WIL_Project.DBContext;
using WIL_Project.Models;

namespace WIL_Project.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly MyDbContext _context;

        public ScheduleController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var events = _context.EventInformation.Take(9).ToList(); // Fetch the first 9 events from the database
            return View(events);
        }
    }
}
