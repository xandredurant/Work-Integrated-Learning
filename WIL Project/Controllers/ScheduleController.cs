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
            try
            {
                var events = _context.EventInformation.ToList(); // Fetch all events from the database
                return View(events);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return View(new List<EventInformation>()); // Display an empty list in case of an error
            }
        }

    }
}
