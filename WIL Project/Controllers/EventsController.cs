using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WIL_Project.DBContext; // Add the appropriate using statement for your DbContext
using WIL_Project.Models;

namespace WIL_Project.Controllers
{
    public class EventsController : Controller
    {
        private readonly MyDbContext _dbContext;

        public EventsController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            // Retrieve events with related reviews using Entity Framework
            var eventsWithReviews = _dbContext.EventInformation
                .Include(e => e.Reviews) // Include reviews related to events
                .ToList();

            return View(eventsWithReviews);
        }
    }
}
