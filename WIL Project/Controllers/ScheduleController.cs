﻿using Microsoft.AspNetCore.Mvc;
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
            var events = _context.EventInformation.ToList(); // Fetch all events from the database

            // Log the count of events
            Console.WriteLine("Event Count: " + events.Count);

            return View(events);
        }


    }
}
