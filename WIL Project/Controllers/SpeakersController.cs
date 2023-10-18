using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WIL_Project.DBContext;
using WIL_Project.Models;

namespace WIL_Project.Controllers
{
    public class SpeakersController : Controller
    {
        private readonly MyDbContext _context;

        public SpeakersController(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var speakers = await _context.SpeakerInformation.ToListAsync();
            return View(speakers);
        }
    }
}
