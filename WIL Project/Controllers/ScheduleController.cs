using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WIL_Project.DBContext;
using WIL_Project.Models;

public class ScheduleController : Controller
{
    private readonly MyDbContext _context;

    public ScheduleController(MyDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var events = await _context.EventInformation.ToListAsync();
        return View(events);
    }

}
