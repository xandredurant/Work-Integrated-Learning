using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq; 
using WIL_Project.Models;
using WIL_Project.DBContext; 

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
            // Retrieve the first 9 events from the database
            var events = _context.EventInformation.Take(9).ToList();

            return View(events); // Pass the list of events to the view
        }
    }
}
