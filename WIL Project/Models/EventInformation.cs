namespace WIL_Project.Models
{
    public class EventInformation
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string EventLocation { get; set; }
        public string EventDescription { get; set; }
        public string EventType { get; set; }

        // Navigation property for sessions related to this event
        public List<SessionInformation> Sessions { get; set; }
    }
}
