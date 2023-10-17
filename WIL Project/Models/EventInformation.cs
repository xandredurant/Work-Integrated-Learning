using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WIL_Project.Models
{
    [Table("EventInformation")]
    public class EventInformation
    {
        [Key]
        public int EventID { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string EventLocation { get; set; }
        public string EventDescription { get; set; }
        public string EventType { get; set; }

        // Navigation property for sessions related to this event
        public List<SessionInformation> Sessions { get; set; }

        // Navigation property for reviews related to this event
        public List<ReviewRating> Reviews { get; set; }
        public List<Survey> Surveys { get; set; }
    }
}
