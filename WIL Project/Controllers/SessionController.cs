using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WIL_Project.DBContext;
using WIL_Project.Models;

namespace WIL_Project.Controllers
{
    public class SessionController : Controller
    {
        SqlConnection con = new SqlConnection("Server=tcp:work-integrated-learning.database.windows.net,1433;Initial Catalog=WILProject;Persist Security Info=False;User ID=Group1;Password=Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        private readonly MyDbContext _context;

        public SessionController(MyDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSession(int session_id, string session_name, string date)
        {
            try
            {
                // Create a new session
                var session = new UserProgram
                {
                    session_name = session_name,
                    date = date
                };

                // Add the session to the DbSet of UserPrograms
                _context.Sessions.Add(session);

                // Save changes to the database
                _context.SaveChanges();

                return Json(new { message = "Session added successfully" });
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine(ex.Message);
                return Json(new { message = "Failed to add session" });
            }
        }
    }
}
