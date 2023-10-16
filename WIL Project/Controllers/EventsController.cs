using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WIL_Project.DBContext; // Add the appropriate using statement for your DbContext
using WIL_Project.Models;

namespace WIL_Project.Controllers
{
    public class EventsController : Controller
    {
        private readonly DBContext.MyDbContext _dbContext;

        public EventsController(DBContext.MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var eventsWithReviews = _dbContext.EventInformation
                .Include(e => e.Reviews)
                    .ThenInclude(r => r.UserInfo)
                .ToList();

            // Load related UserInfo for each review
            foreach (var ev in eventsWithReviews)
            {
                foreach (var review in ev.Reviews)
                {
                    if (review.UserInfo != null)
                    {
                        _dbContext.Entry(review).Reference(r => r.UserInfo).Load();
                    }
                }
            }

            return View(eventsWithReviews);
        }
    }
}
