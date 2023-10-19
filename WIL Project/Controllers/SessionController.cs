using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WIL_Project.DBContext;
using WIL_Project.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace WIL_Project.Controllers
{
    public class SessionController : Controller
    {
        private readonly MyDbContext _context;
        private readonly UserManager<UserInfo> _userManager; // Include UserManager

        public SessionController(MyDbContext context, UserManager<UserInfo> userManager)
        {
            _context = context;
            _userManager = userManager; // Initialize UserManager
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                // Retrieve sessions with related event and speaker information
                var sessions = await _context.SessionInformation
                    .Include(s => s.EventInformation) // Include related event
                    .Include(s => s.SpeakerInformation) // Include related speaker
                    .ToListAsync();

                return View(sessions);
            }
            else
            {
                // Handle unauthenticated user
                return Redirect("/Identity/Account/Login");// Redirect to the login page
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddSession(int session_id, string date)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                    // Check if the user has already booked the session
                    var existingBooking = await _context.Sessions
                        .FirstOrDefaultAsync(s => s.Id == userId && s.SessionID == session_id);

                    if (existingBooking == null)
                    {
                        // Create a new UserProgram (booking)
                        var userProgram = new UserProgram
                        {
                            Id = userId, // Use the user's ID
                            SessionID = session_id,
                            date = date
                        };

                        // Add the booking to the DbSet of UserPrograms
                        _context.Sessions.Add(userProgram);

                        // Save changes to the database
                        await _context.SaveChangesAsync();

                        return Json(new { message = "Session booked successfully" });
                    }
                    else
                    {
                        // The user has already booked this session
                        return Json(new { message = "Session is already booked" });
                    }
                }
                else
                {
                    // User is not authenticated
                    return Json(new { message = "Authentication required" });
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine(ex.Message);
                return Json(new { message = "Failed to book session" });
            }
        }
        [HttpPost]
        public JsonResult IsSessionBooked(int session_id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Check if the user has booked the session with the given session_id
            var isBooked = _context.Sessions.Any(b => b.SessionID == session_id && b.Id == userId);

            return Json(new { isBooked });
        }
    }
}
