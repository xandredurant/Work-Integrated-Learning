using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
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
                .Include(e => e.Sessions)
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

        [HttpPost]
        public IActionResult AddReview(int eventId, ReviewRating review, int sessionId)
        {
            // Retrieve the event and session based on the eventId and sessionId
            var ev = _dbContext.EventInformation
                .Include(e => e.Sessions)
                .FirstOrDefault(e => e.EventID == eventId);
            var session = ev?.Sessions.FirstOrDefault(s => s.SessionID == sessionId);

            if (ev == null || session == null)
            {
                // Handle cases where the event or session is not found
                return NotFound();
            }
            // Set the related properties for the review
            review.EventID = eventId;
            review.SessionID = sessionId;
            review.Id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            review.ReviewDate = DateTime.Now;

            
            // Add the review to the database
            _dbContext.ReviewRating.Add(review);
            _dbContext.SaveChanges();

            // Redirect back to the same page (event details)
            return RedirectToAction("Index");
            
        }
    }
}
