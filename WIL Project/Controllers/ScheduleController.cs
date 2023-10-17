using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic; // Make sure to import this namespace
using WIL_Project.Models;

namespace WIL_Project.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            // Assuming you have a list of events that you want to display
            var events = new List<EventInformation>
            {
                // Populate this list with EventInformation objects retrieved from the database
                new EventInformation
                {
                    // Fill in properties for the event
                    EventName = "Sample Event 1",
                    EventDate = DateTime.Now,
                    EventType = "Seminar",
                    EventDescription = "This is a sample event description."
                },
                // Add more events as needed
            };

            return View(events); // Pass the list of events to the view
        }
    }
}
