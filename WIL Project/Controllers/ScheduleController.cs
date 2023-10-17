using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WIL_Project.DBContext;
using WIL_Project.Models;
using Serilog; // You need to import the Serilog namespace

public class ScheduleController : Controller
{
    private readonly MyDbContext _context;

    public ScheduleController(MyDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var events = await _context.EventInformation.ToListAsync();

            if (events == null)
            {
                // Log a message using Serilog
                Log.Error("Failed to retrieve events from the database.");
                // You can customize the logging as needed
            }

            return View(events);
        }
        catch (Exception ex)
        {
            // Log the exception using Serilog or another logging library
            Log.Error(ex, "An error occurred while fetching events from the database.");
            // Handle the exception, perhaps display an error page
            return View("Error");
        }
    }
}
